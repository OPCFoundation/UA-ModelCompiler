/* Copyright (c) 1996-2020 The OPC Foundation. All rights reserved.
   The source code in m_nodeset file is covered under a dual-license scenario:
     - RCL: for OPC Foundation members in good-standing
     - GPL V2: everybody else
   RCL license terms accompanied with m_nodeset source code. See http://opcfoundation.org/License/RCL/1.00/
   GNU General Public License as published by the Free Software Foundation;
   version 2 of the License are accompanied with m_nodeset source code. See http://opcfoundation.org/License/GPLv2
   This source code is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
*/

using Opc.Ua;
using Opc.Ua.Export;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using NodeSet = Opc.Ua.Export;

namespace ModelCompiler
{
    public class NodeSetReaderSettings
    {
        public NodeSetReaderSettings()
        {
            NamespaceUris = new NamespaceTable();
            DesignFilePaths = new Dictionary<string, string>();
            NodesByQName = new Dictionary<XmlQualifiedName, NodeDesign>();
            NodesById = new Dictionary<NodeId, NodeDesign>();
        }

        public NamespaceTable NamespaceUris { get; private set; }

        public IDictionary<string, string> DesignFilePaths { get; set; }

        public IDictionary<XmlQualifiedName, NodeDesign> NodesByQName { get; set; }

        public IDictionary<NodeId, NodeDesign> NodesById { get; set; }
    }

    /// <summary>
    /// A set of nodes in an address space.
    /// </summary>
    public partial class NodeSetToModelDesign
    {
        private NodeSetReaderSettings m_settings;
        private StringTable m_serverUris = new StringTable();
        private NodeSet.UANodeSet m_nodeset;
        private Dictionary<string, NodeId> m_aliases = new Dictionary<string, NodeId>();
        private Dictionary<NodeId, NodeSet.UANode> m_index;
        private Dictionary<string, XmlQualifiedName> m_symbolicIds;

        public NodeSetToModelDesign(NodeSetReaderSettings settings, string filePath)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            m_settings = settings;
            m_index = new Dictionary<NodeId, NodeSet.UANode>();
            m_symbolicIds = new Dictionary<string, XmlQualifiedName>();

            using (var istrm = File.OpenRead(filePath))
            {
                m_nodeset = Opc.Ua.Export.UANodeSet.Read(istrm);

                if (m_nodeset.NamespaceUris != null)
                {
                    foreach (var ns in m_nodeset.NamespaceUris)
                    {
                        m_settings.NamespaceUris.GetIndexOrAppend(ns);
                    }
                }

                if (m_nodeset.Aliases != null)
                {
                    foreach (var ii in m_nodeset.Aliases)
                    {
                        var nodeId = ImportNodeId(ii.Value, false);

                        if (nodeId == null)
                        {
                            throw new InvalidDataException($"Alias ({ii.Alias}) is not valid.");
                        }

                        m_aliases[ii.Alias] = nodeId;
                    }
                }

                if (m_nodeset.Items != null)
                {
                    foreach (var node in m_nodeset.Items)
                    {
                        var nodeId = ImportNodeId(node.NodeId, false);

                        if (nodeId == null)
                        {
                            throw new InvalidDataException($"NodeId ({node.BrowseName}) is not valid.");
                        }

                        m_index.Add(nodeId, node);
                    }
                }
            }
        }

        public static bool IsNodeSet(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            var lines = File.ReadAllLines(filePath);

            for (int ii = 0; ii < 40; ii++)
            {
                var line = lines[ii].TrimStart();

                if (line.StartsWith("<?") || line.StartsWith("<!") || !line.StartsWith("<") || String.IsNullOrEmpty(line))
                {
                    continue;
                }

                var fields = line.Split();

                if (fields.Length == 0)
                {
                    break;
                }

                return fields[0].Contains("UANodeSet");
            }

            return false;
        }

        private static T Load<T>(string path)
        {
            var settings = new XmlReaderSettings()
            {
                DtdProcessing = DtdProcessing.Prohibit
            };

            using (var stream = File.OpenRead(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using (var reader = XmlReader.Create(stream, settings))
                {
                    return (T)serializer.Deserialize(reader);
                }
            }
        }

        private static void CollectModels(ModelTableEntry model, List<ModelTableEntry> models)
        {
            if (model.RequiredModel != null)
            {
                foreach (var dependency in model.RequiredModel)
                {
                    CollectModels(dependency, models);
                }
            }

            for (int ii = 0; ii < models.Count; ii++)
            {
                if (models[ii].ModelUri == model.ModelUri)
                {
                    if (model.PublicationDate > models[ii].PublicationDate)
                    {
                        models[ii] = model;
                    }

                    return;
                }
            }

            models.Add(model);
        }

        private static Namespace CreateNamespace(ModelTableEntry model)
        {
            Namespace ns = null;

            if (model.ModelUri.StartsWith(Namespaces.OpcUa))
            {
                ns = new Namespace()
                {
                    Name = model.ModelUri.Substring(Namespaces.OpcUa.Length).Replace("/", " ").Trim().Replace(" ", "."),
                    Value = model.ModelUri,
                    XmlNamespace = model.XmlSchemaUri,
                    PublicationDate = model.PublicationDate.ToString("yyyy-MM-ddT00:00:00Z"),
                    Version = model.Version
                };
                ns.XmlPrefix = ns.Prefix = "Opc.Ua." + ns.Name;
                ns.Name = ns.Name.Replace(".", "").Replace("-", "").Replace(",", "").Replace(":", "");
            }
            else
            {
                ns = new Namespace()
                {
                    Name = model.ModelUri.Replace("http://", "").Replace("/", " ").Trim().Replace(" ", "."),
                    Value = model.ModelUri,
                    XmlNamespace = model.XmlSchemaUri,
                    PublicationDate = model.PublicationDate.ToString("yyyy-MM-ddT00:00:00Z"),
                    Version = model.Version
                };
                ns.XmlPrefix = ns.Prefix = ns.Name;
                ns.Name = ns.Name.Replace(".", "").Replace("-", "").Replace(",", "").Replace(":", "");
            }

            if (ns.Value == Namespaces.OpcUa)
            {
                ns.Name = "OpcUa";
                ns.XmlPrefix = ns.Prefix = "Opc.Ua";
            }

            return ns;
        }

        public static List<Namespace> LoadNamespaces(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            var nodeset = Load<UANodeSet>(filePath);

            List<ModelTableEntry> models = new();

            if (nodeset.Models != null)
            {
                foreach (var model in nodeset.Models)
                {
                    CollectModels(model, models);
                }
            }

            List<Namespace> namespaces = new();

            foreach (var model in models)
            {
                var ns = CreateNamespace(model);
                var topLevelModel = nodeset.Models.Where(x => x.ModelUri == model.ModelUri).FirstOrDefault();

                if (topLevelModel != null)
                {
                    ns.FilePath = filePath;
                }

                namespaces.Add(ns);
            }

            return namespaces;
        }

        private void ImportModel(IList<Namespace> namespaces, NodeSet.ModelTableEntry model)
        {
            var ns = (from x in namespaces where x.Value == model.ModelUri select x).FirstOrDefault();

            if (ns != null)
            {
                return;
            }

            ns = CreateNamespace(model);
            namespaces.Add(ns);

            if (model.RequiredModel != null)
            {
                foreach (var ii in model.RequiredModel)
                {
                    ImportModel(namespaces, ii);
                }
            }
        }

        private bool IsTypeOf(NodeId subTypeId, NodeId superTypeId)
        {
            if (!m_settings.NodesById.TryGetValue(subTypeId, out NodeDesign node1))
            {
                return false;
            }

            if (!m_settings.NodesById.TryGetValue(superTypeId, out NodeDesign node2))
            {
                return false;
            }

            if (node1 is TypeDesign td1 && node2 is TypeDesign td2)
            {
                XmlQualifiedName parentId = td1.BaseType;

                while (parentId != null)
                {
                    if (parentId == td2.SymbolicId)
                    {
                        return true;
                    }

                    if (!m_settings.NodesByQName.TryGetValue(parentId, out NodeDesign parent))
                    {
                        return false;
                    }

                    td1 = parent as TypeDesign;

                    if (td1?.BaseType == null)
                    {
                        return false;
                    }

                    parentId = td1.BaseType;
                }
            }

            return false;
        }

        private XmlQualifiedName ImportSymbolicName(NodeSet.UANode input)
        {
            var browseName = ImportQualifiedName(input.BrowseName);

            if (!String.IsNullOrEmpty(input.SymbolicName))
            {
                return new XmlQualifiedName(input.SymbolicName, browseName.Namespace);
            }

            return new XmlQualifiedName(ToSymbolicName(browseName.Name), browseName.Namespace);
        }

        private LocalizedText ImportLocalizedText(IList<NodeSet.LocalizedText> input)
        {
            if (input != null && input.Count > 0 && !String.IsNullOrWhiteSpace(input[0].Value))
            {
                return new LocalizedText() { Value = input[0].Value, IsAutogenerated = false };
            }

            return null;
        }

        private ReferenceTypeDesign FindReferenceType(ExpandedNodeId targetId)
        {
            if (m_settings.NodesById.TryGetValue((NodeId)targetId, out NodeDesign design))
            {
                return design as ReferenceTypeDesign;
            }

            if (m_index.TryGetValue((NodeId)targetId, out NodeSet.UANode node))
            {
                if (node is NodeSet.UAReferenceType rt)
                {
                    return ImportReferenceType(rt);
                }
            }

            return null;
        }

        private T FindNode<T>(ExpandedNodeId targetId) where T : NodeDesign
        {
            if (targetId == null)
            {
                return default(T);
            }

            if (m_settings.NodesById.TryGetValue((NodeId)targetId, out NodeDesign design))
            {
                return design as T;
            }

            if (m_index.TryGetValue((NodeId)targetId, out NodeSet.UANode node))
            {
                return ImportNode(node) as T;
            }

            return null;
        }

        private T FindSuperType<T>(NodeSet.UAType source) where T : TypeDesign
        {
            if (source.References != null)
            {
                foreach (var reference in source.References)
                {
                    var rtid = ImportNodeId(reference.ReferenceType);

                    if (rtid == null || ReferenceTypeIds.HasSubtype != rtid || reference.IsForward)
                    {
                        continue;
                    }

                    var targetId = ImportNodeId(reference.Value);

                    if (targetId == null)
                    {
                        return default(T);
                    }

                    return FindNode<T>(targetId) as T;
                }
            }

            return null;
        }

        private ReferenceTypeDesign ImportReferenceType(NodeSet.UAReferenceType input)
        {
            NodeId nodeId = ImportNodeId(input.NodeId);
            NodeDesign existing = null;

            if (nodeId == null || m_settings.NodesById.TryGetValue(nodeId, out existing))
            {
                if (existing is ReferenceTypeDesign rt)
                {
                    return rt;
                }

                throw new InvalidDataException($"Node exists and it is not a ReferenceType: {existing.SymbolicId}'.");
            }

            var output = new ReferenceTypeDesign();

            output.SymbolicName = ImportSymbolicName(input);
            output.SymbolicId = output.SymbolicName;
            output.BrowseName = QualifiedName.Parse(input.BrowseName).Name;
            output.Description = ImportLocalizedText(input.Description);
            output.DisplayName = ImportLocalizedText(input.DisplayName);
            output.IsAbstract = input.IsAbstract;
            output.InverseName = ImportLocalizedText(input.InverseName);
            output.Symmetric = input.Symmetric;
            output.SymmetricSpecified = true;
            output.ReleaseStatus = ImportReleaseStatus(input.ReleaseStatus);
            output.Category = ImportCategories(input.Category);

            if (nodeId.Identifier is uint id)
            {
                output.NumericId = id;
                output.NumericIdSpecified = true;
            }

            foreach (var ii in input.References)
            {
                var reference = ImportReference(ii);

                if (reference.ReferenceTypeId == Opc.Ua.ReferenceTypes.HasSubtype && reference.IsInverse)
                {
                    var superType = FindReferenceType(reference.TargetId);

                    if (superType != null)
                    {
                        output.BaseType = superType.SymbolicId;
                        output.BaseTypeNode = superType;
                    }

                    break;
                }
            }

            if (output.BaseType == null)
            {
                throw new InvalidDataException($"Could not find supertype for '{input.BrowseName}'.");
            }

            m_settings.NodesByQName[output.SymbolicId] = output;
            m_settings.NodesById[nodeId] = output;

            return output;
        }

        private NodeDesign CreateNodeDesign(NodeSet.UANode input)
        {
            if (input is NodeSet.UAObjectType)
            {
                return new ObjectTypeDesign();
            }

            if (input is NodeSet.UAVariableType)
            {
                return new VariableTypeDesign();
            }

            if (input is NodeSet.UADataType)
            {
                return new DataTypeDesign();
            }

            if (input is NodeSet.UAReferenceType)
            {
                return new ReferenceTypeDesign();
            }

            if (input is NodeSet.UAObject)
            {
                return new ObjectDesign();
            }

            if (input is NodeSet.UAVariable)
            {
                return new VariableDesign();
            }

            if (input is NodeSet.UAMethod)
            {
                return new MethodDesign();
            }

            if (input is NodeSet.UAView)
            {
                return new ViewDesign();
            }

            throw new InvalidDataException($"Object is not a valid NodeClass: '{input.BrowseName}/{input.GetType().Name}'.");
        }

        private void UpdateTypeDesign(NodeSet.UAType input, TypeDesign output)
        {
            if (input == null || output == null)
            {
                return;
            }

            output.ClassName = output.SymbolicName.Name;
            output.IsAbstract = input.IsAbstract;

            foreach (var ii in input.References)
            {
                var reference = ImportReference(ii);

                if (reference.ReferenceTypeId == Opc.Ua.ReferenceTypes.HasSubtype && reference.IsInverse)
                {
                    var superType = FindNode<TypeDesign>(reference.TargetId);

                    if (superType != null)
                    {
                        output.BaseType = superType.SymbolicId;
                        output.BaseTypeNode = superType;
                    }

                    break;
                }
            }

            if (output.BaseType == null)
            {
                throw new InvalidDataException($"Could not find supertype for '{input.BrowseName}'.");
            }
        }

        private void UpdateVariableTypeDesign(NodeSet.UAVariableType input, VariableTypeDesign output)
        {
            if (input == null || output == null)
            {
                return;
            }


            UpdateTypeDesign(input, output);

            output.DefaultValue = input.Value;
            output.ValueRankSpecified = true;
            output.ValueRank = ImportValueRank(input.ValueRank);
            output.ValueRankSpecified = true;
            output.ArrayDimensions = input.ArrayDimensions;

            if (input.Value != null)
            {
                XmlDecoder decoder = CreateDecoder(input.Value);
                TypeInfo typeInfo = null;
                output.DecodedValue = decoder.ReadVariantContents(out typeInfo);
                decoder.Close();
            }

            var dataType = FindNode<DataTypeDesign>(ImportNodeId(input.DataType));

            if (dataType == null)
            {
                throw new InvalidDataException($"Could not find DataType Node for '{input.BrowseName}/{input.DataType}'.");
            }

            output.DataType = dataType.SymbolicId;
            output.DataTypeNode = dataType;
        }

        private void UpdateObjectTypeDesign(NodeSet.UAObjectType input, ObjectTypeDesign output)
        {
            if (input == null || output == null)
            {
                return;
            }

            UpdateTypeDesign(input, output);
        }

        private void UpdateReferenceTypeDesign(NodeSet.UAReferenceType input, ReferenceTypeDesign output)
        {
            if (input == null || output == null)
            {
                return;
            }

            UpdateTypeDesign(input, output);

            output.InverseName = ImportLocalizedText(input.InverseName);
            output.Symmetric = input.Symmetric;
            output.SymmetricSpecified = true;

            if (!output.Symmetric && output.InverseName == null)
            {
                output.InverseName = new LocalizedText()
                {
                    Value = output.BrowseName ?? output.SymbolicName.Name,
                    IsAutogenerated = false
                };
            }
        }

        private bool IsTypeOf(NodeSet.UAType subtype, NodeId superTypeId)
        {
            NodeId nodeId = ImportNodeId(subtype.NodeId);

            if (nodeId == null)
            {
                return false;
            }

            if (nodeId == superTypeId)
            {
                return true;
            }

            var parent = FindSuperType<TypeDesign>(subtype);

            while (parent != null)
            {
                var parentId = new NodeId(parent.NumericId, (ushort)m_settings.NamespaceUris.GetIndex(parent.SymbolicId.Namespace));

                if (parentId == superTypeId)
                {
                    return true;
                }

                if (parent.BaseTypeNode == null)
                {
                    return false;
                }

                parent = parent.BaseTypeNode;
            }

            return false;
        }

        private BasicDataType GetBasicDataType(DataTypeDesign dataType)
        {
            if (dataType == null)
            {
                return BasicDataType.BaseDataType;
            }

            if (dataType.IsOptionSet)
            {
                return BasicDataType.Enumeration;
            }

            // check if it is a built in data type.
            if (dataType.SymbolicName.Namespace == Namespaces.OpcUa)
            {
                foreach (string name in Enum.GetNames(typeof(BasicDataType)))
                {
                    if (name == dataType.SymbolicName.Name)
                    {
                        return (BasicDataType)Enum.Parse(typeof(BasicDataType), dataType.SymbolicName.Name);
                    }
                }
            }

            // recursively search hierarchy if conversion to enum fails.
            BasicDataType basicType = GetBasicDataType(dataType.BaseTypeNode as DataTypeDesign);

            // data type is user defined if a sub-type of structure.
            if (basicType == BasicDataType.Structure)
            {
                return BasicDataType.UserDefined;
            }

            return basicType;
        }

        private static bool IsLetterOrDigit(char ch)
        {
            if (ch >= '0' && ch <= '9')
            {
                return true;
            }

            if (ch >= 'A' && ch <= 'Z')
            {
                return true;
            }

            if (ch >= 'a' && ch <= 'z')
            {
                return true;
            }

            return false;
        }

        private static readonly string[] Keywords = new string[]
        {
            "private",
            "public",
            "protected",
            "internal",
            "lock",
            "char",
            "byte",
            "int",
            "uint",
            "long",
            "ulong",
            "float",
            "double",
            "decimal",
            "for",
            "foreach",
            "while",
            "string"
        };

        public static string ToSymbolicName(string name)
        {
            if (Keywords.Contains(name))
            {
                name = "_" + name;
            }

            StringBuilder output = new();

            foreach (var ch in name)
            {
                if (!IsLetterOrDigit(ch))
                {
                    if (output.Length == 0)
                    {
                        output.Append('x');
                        continue;
                    }

                    output.Append('_');
                    continue;
                }

                if (output.Length == 0 && ch >= '0' && ch <= '9')
                {
                    output.Append('n');
                }

                output.Append(ch);
            }

            return output.ToString();
        }

        private void UpdateDataTypeDesign(NodeSet.UADataType input, DataTypeDesign output)
        {
            if (input == null || output == null)
            {
                return;
            }

            UpdateTypeDesign(input, output);

            output.IsStructure = false;
            output.IsUnion = false;
            output.IsEnumeration = input.Definition?.IsOptionSet ?? false;
            output.IsOptionSet = input.Definition?.IsOptionSet ?? false;
            output.BasicDataType = GetBasicDataType(output);
            output.HasFields = false;
            output.Fields = null;
            output.HasEncodings = false;

            if (input.Definition != null)
            {
                if (IsTypeOf(input, DataTypeIds.OptionSet))
                {
                    output.IsEnumeration = true;
                    output.IsStructure = false;
                    output.IsUnion = false;
                    output.IsOptionSet = true;
                }

                else if (IsTypeOf(input, DataTypeIds.Structure))
                {
                    output.IsStructure = true;
                    output.IsUnion = input.Definition.IsUnion;
                    output.IsEnumeration = false;
                    output.IsOptionSet = false;
                    output.HasEncodings = true;
                }

                else if (IsTypeOf(input, DataTypeIds.Enumeration))
                {
                    output.IsEnumeration = true;
                    output.IsStructure = false;
                    output.IsUnion = false;
                    output.IsOptionSet = false;
                }

                var fields = new List<Parameter>();

                if (input.Definition.Field != null)
                {
                    foreach (var ii in input.Definition.Field)
                    {
                        var symbolicName = ii.SymbolicName;

                        if (String.IsNullOrEmpty(symbolicName))
                        {
                            symbolicName = ToSymbolicName(ii.Name);
                        }

                        var field = new Parameter()
                        {
                            Name = symbolicName,
                            Description = ImportLocalizedText(ii.Description),
                            ArrayDimensions = ii.ArrayDimensions,
                            ValueRank = ImportValueRank(ii.ValueRank),
                            Parent = output
                        };

                        if (ii.Name != field.Name)
                        {
                            field.DisplayName = new LocalizedText() { Value = ii.Name, IsAutogenerated = false };
                        }

                        var dataType = FindNode<DataTypeDesign>(ImportNodeId(ii.DataType));

                        if (dataType == null)
                        {
                            throw new InvalidDataException($"Could not find DataType Node for Field '{input.BrowseName}/{ii.Name}/{ii.DataType}'.");
                        }

                        field.DataType = dataType.SymbolicId;
                        field.DataTypeNode = dataType;
                        field.AllowSubTypes = ii.AllowSubTypes;
                        field.IsOptional = ii.IsOptional;

                        if (output.IsOptionSet)
                        {
                            long mask = 1 << ii.Value;
                            field.BitMask = $"{mask:X8}";
                            field.Identifier = (int)mask;
                            field.IdentifierSpecified = true;
                        }
                        else if (output.IsEnumeration)
                        {
                            field.BitMask = null;
                            field.Identifier = ii.Value;
                            field.IdentifierSpecified = true;
                        }

                        fields.Add(field);
                    }
                }

                output.HasFields = fields.Count > 0;
                output.Fields = fields.ToArray();
            }
        }

        private void UpdateInstanceDesign(NodeSet.UAInstance input, InstanceDesign output)
        {
            if (input == null || output == null)
            {
                return;
            }

            output.ModellingRule = ModellingRule.None;
            output.ModellingRuleSpecified = false;

            foreach (var ii in input.References)
            {
                var reference = ImportReference(ii);

                if (reference.ReferenceTypeId == Opc.Ua.ReferenceTypes.HasTypeDefinition && !reference.IsInverse)
                {
                    var typeDefinition = FindNode<TypeDesign>(reference.TargetId);

                    if (typeDefinition != null)
                    {
                        output.TypeDefinition = typeDefinition.SymbolicId;
                        output.TypeDefinitionNode = typeDefinition;
                    }
                }

                if (reference.ReferenceTypeId == Opc.Ua.ReferenceTypes.HasModellingRule && !reference.IsInverse)
                {
                    output.ModellingRule = ImportModellingRule(reference.TargetId);
                    output.ModellingRuleSpecified = true;
                }
            }

            if (output.TypeDefinition == null)
            {
                throw new InvalidDataException($"Could not find TypeDefinition for '{input.BrowseName}'.");
            }
        }

        private void UpdateObjectDesign(NodeSet.UAObject input, ObjectDesign output)
        {
            if (input == null || output == null)
            {
                return;
            }

            UpdateInstanceDesign(input, output);

            output.SupportsEvents = (input.EventNotifier & EventNotifiers.SubscribeToEvents) != 0;
        }

        private void UpdateViewDesign(NodeSet.UAView input, ViewDesign output)
        {
            if (input == null || output == null)
            {
                return;
            }

            output.SupportsEvents = (input.EventNotifier & EventNotifiers.SubscribeToEvents) != 0;
        }

        private void UpdateVariableDesign(NodeSet.UAVariable input, VariableDesign output)
        {
            if (input == null || output == null)
            {
                return;
            }

            UpdateInstanceDesign(input, output);

            output.DefaultValue = input.Value;
            output.ValueRank = ImportValueRank(input.ValueRank);
            output.ValueRankSpecified = true;
            output.ArrayDimensions = input.ArrayDimensions;
            output.MinimumSamplingInterval = (int)input.MinimumSamplingInterval;
            output.MinimumSamplingIntervalSpecified = true;
            output.Historizing = input.Historizing;
            output.HistorizingSpecified = input.Historizing;
            output.AccessLevel = ImportAccessLevel(input.AccessLevel);
            output.AccessLevelSpecified = true;

            if (input.Value != null)
            {
                XmlDecoder decoder = CreateDecoder(input.Value);
                TypeInfo typeInfo = null;
                output.DecodedValue = decoder.ReadVariantContents(out typeInfo);
                decoder.Close();
            }

            var dataType = FindNode<DataTypeDesign>(ImportNodeId(input.DataType));

            if (dataType == null)
            {
                throw new InvalidDataException($"Could not find DataType Node for '{input.BrowseName}/{input.DataType}'.");
            }

            output.DataType = dataType.SymbolicId;
            output.DataTypeNode = dataType;
        }

        private List<Parameter> ImportArguments(MethodDesign method, XmlElement input)
        {
            List<Parameter> output = new List<Parameter>();

            if (input != null)
            {
                XmlDecoder decoder = CreateDecoder(input);
                TypeInfo typeInfo = null;
                var value = decoder.ReadVariantContents(out typeInfo);
                decoder.Close();

                var arguments = (IList<Argument>)ExtensionObject.ToArray(value, typeof(Argument));

                foreach (var argument in arguments)
                {
                    var dataTypeId = new NodeId(
                        argument.DataType.Identifier,
                        ImportNamespaceIndex(argument.DataType.NamespaceIndex, m_settings.NamespaceUris));

                    var dataType = FindNode<DataTypeDesign>(argument.DataType);

                    if (dataType == null)
                    {
                        throw new InvalidDataException($"Method ({method.SymbolicId.Name}) argument ({argument.Name}) datatype ({argument.DataType}) not found.");
                    }

                    Parameter parameter = new Parameter()
                    {
                        Name = argument.Name,
                        ArrayDimensions = ImportArrayDimensions(argument.ArrayDimensions),
                        ValueRank = ImportValueRank(argument.ValueRank),
                        Parent = method,
                        DataType = dataType?.SymbolicId,
                        DataTypeNode = dataType,
                        Description = null
                    };

                    if (!String.IsNullOrEmpty(argument.Description?.Text))
                    {
                        parameter.Description = new LocalizedText() { Value = argument.Description?.Text, IsAutogenerated = false };
                    }

                    output.Add(parameter);
                }

            }

            return output;
        }

        private void UpdateMethodDesign(NodeSet.UAMethod input, MethodDesign output)
        {
            if (input == null || output == null)
            {
                return;
            }

            output.ModellingRule = ModellingRule.None;
            output.ModellingRuleSpecified = false;

            if (input.References != null)
            {
                foreach (var ii in input.References)
                {
                    var reference = ImportReference(ii);

                    if (reference.ReferenceTypeId == Opc.Ua.ReferenceTypes.HasModellingRule && !reference.IsInverse)
                    {
                        output.ModellingRule = ImportModellingRule(reference.TargetId);
                        output.ModellingRuleSpecified = true;
                        break;
                    }
                }
            }

            output.NonExecutable = !input.Executable;
            output.NonExecutableSpecified = !input.Executable;

            if (input.MethodDeclarationId != null)
            {
                NodeId methodId = ImportNodeId(input.MethodDeclarationId);
                output.MethodDeclarationNode = FindNode<MethodDesign>(methodId);
            }

            if (input.References != null)
            {
                foreach (var ii in input.References)
                {
                    var reference = ImportReference(ii);

                    if (reference.ReferenceTypeId == Opc.Ua.ReferenceTypes.HasProperty && !reference.IsInverse)
                    {
                        var property = FindNode<VariableDesign>(reference.TargetId);

                        if (property != null && property.DefaultValue != null)
                        {
                            if (property.BrowseName == BrowseNames.InputArguments)
                            {
                                output.InputArguments = ImportArguments(output, property.DefaultValue).ToArray();
                                output.HasArguments = true;
                            }
                            else if (property.BrowseName == BrowseNames.OutputArguments)
                            {
                                output.OutputArguments = ImportArguments(output, property.DefaultValue).ToArray();
                                output.HasArguments = true;
                            }
                        }
                    }
                }
            }
        }

        private void LinkChildToParent(UAInstance input)
        {
            NodeId nodeId = ImportNodeId(input.NodeId);
            NodeId parentId = ImportNodeId(input.ParentNodeId);

            if (nodeId.NamespaceIndex != parentId.NamespaceIndex)
            {
                return;
            }

            NodeDesign parent;
            NodeDesign referenceType = null;
            var parentNode = FindNode(m_nodeset, parentId);

            if (parentNode == null)
            {
                throw new InvalidDataException($"ParentNode ({input.ParentNodeId}) not found for node {input.NodeId} ({input.BrowseName}).");
            }

            if (!m_settings.NodesById.TryGetValue(parentId, out parent))
            {
                parent = ImportNode(parentNode);
            }

            if (parentNode.References != null)
            {
                foreach (var reference in parentNode.References)
                {
                    if (reference.Value == input.NodeId && reference.IsForward)
                    {
                        var referenceTypeId = ImportNodeId(reference.ReferenceType);

                        if (!IsTypeOf(referenceTypeId, ReferenceTypeIds.HierarchicalReferences))
                        {
                            continue;
                        }

                        referenceType = FindReferenceType(referenceTypeId);
                    }
                }
            }

            if (referenceType == null && input.References != null)
            {
                foreach (var reference in input.References)
                {
                    if (reference.Value == input.ParentNodeId && !reference.IsForward)
                    {
                        var referenceTypeId = ImportNodeId(reference.ReferenceType);

                        if (!IsTypeOf(referenceTypeId, ReferenceTypeIds.HierarchicalReferences))
                        {
                            continue;
                        }

                        referenceType = FindReferenceType(referenceTypeId);
                    }
                }
            }

            if (referenceType == null)
            {
                throw new InvalidDataException($"HierarchicalReference from ParentNode ({input.ParentNodeId}) to Node {input.NodeId} ({input.BrowseName}) not found.");
            }

            if (m_settings.NodesById.TryGetValue(nodeId, out var child))
            {
                LinkChildToParent(parent, referenceType.SymbolicId, nodeId, child as InstanceDesign);
            }
        }

        private void LinkChildToParent(NodeDesign parent, XmlQualifiedName referenceTypeId, NodeId childId, InstanceDesign child)
        {
            if (!child.SymbolicId.Name.StartsWith(parent.SymbolicId.Name))
            {
                child.SymbolicId = new XmlQualifiedName($"{parent.SymbolicId.Name}_{child.SymbolicId.Name}", m_settings.NamespaceUris.GetString(childId.NamespaceIndex));
            }

            List<InstanceDesign> children = new();

            if (parent.Children?.Items != null)
            {
                children.AddRange(parent.Children?.Items);
            }

            child.Parent = parent;
            child.ReferenceType = referenceTypeId;
            children.Add(child);
            parent.Children = new ListOfChildren() { Items = children.ToArray() };
            parent.HasChildren = true;
        }

        private NodeDesign ImportNode(NodeSet.UANode input)
        {
            NodeId nodeId = ImportNodeId(input.NodeId);

            if (m_settings.NodesById.TryGetValue(nodeId, out NodeDesign existing))
            {
                return existing;
            }

            var output = CreateNodeDesign(input);

            output.SymbolicId = m_symbolicIds[input.NodeId];
            output.SymbolicName = ImportSymbolicName(input);
            output.Extensions = input.Extensions;

            if (input is UAType)
            {
                if (output.SymbolicId.Name.EndsWith("_" + nodeId.Identifier.ToString()))
                {
                    output.SymbolicName = new XmlQualifiedName(
                        $"{output.SymbolicName.Name}_{nodeId.Identifier}",
                        output.SymbolicName.Namespace);
                }
            }

            output.BrowseName = QualifiedName.Parse(input.BrowseName).Name;
            output.Description = ImportLocalizedText(input.Description);
            output.DisplayName = ImportLocalizedText(input.DisplayName);
            output.ReleaseStatus = ImportReleaseStatus(input.ReleaseStatus);
            output.Category = ImportCategories(input.Category);

            if (nodeId.Identifier is uint id)
            {
                output.NumericId = id;
                output.NumericIdSpecified = true;
            }
            else if (nodeId.Identifier is string stringId)
            {
                output.StringId = stringId;
                output.NumericIdSpecified = false;
            }

            m_settings.NodesByQName[output.SymbolicId] = output;
            m_settings.NodesById[nodeId] = output;

            if (output is ObjectTypeDesign ot)
            {
                UpdateObjectTypeDesign(input as NodeSet.UAObjectType, ot);
            }
            else if (output is VariableTypeDesign vt)
            {
                UpdateVariableTypeDesign(input as NodeSet.UAVariableType, vt);
            }
            else if (output is ReferenceTypeDesign rt)
            {
                UpdateReferenceTypeDesign(input as NodeSet.UAReferenceType, rt);
            }
            else if (output is DataTypeDesign dt)
            {
                UpdateDataTypeDesign(input as NodeSet.UADataType, dt);
            }
            else if (output is ObjectDesign oi)
            {
                UpdateObjectDesign(input as NodeSet.UAObject, oi);
            }
            else if (output is VariableDesign vi)
            {
                UpdateVariableDesign(input as NodeSet.UAVariable, vi);
            }
            else if (output is MethodDesign mi)
            {
                UpdateMethodDesign(input as NodeSet.UAMethod, mi);
            }
            else if (output is ViewDesign wi)
            {
                UpdateViewDesign(input as NodeSet.UAView, wi);
            }

            return output;
        }

        private UANode FindNode(UANodeSet nodeset, ExpandedNodeId targetId)
        {
            if (targetId == null)
            {
                return null;
            }

            foreach (var ii in nodeset.Items)
            {
                var id = ImportNodeId(ii.NodeId, true);

                if (id == targetId)
                {
                    return ii;
                }
            }

            return null;
        }

        private NodeId FindTarget(
            UANode source,
            NodeId referenceTypeId,
            bool isInverse,
            ExpandedNodeId targetId = null)
        {
            if (source.References == null)
            {
                return null;
            }

            foreach (var ii in source.References)
            {
                var reference = ImportReference(ii);

                if (reference.ReferenceTypeId == referenceTypeId && reference.IsInverse == isInverse)
                {
                    if (targetId != null && reference.TargetId != targetId)
                    {
                        continue;
                    }

                    return ExpandedNodeId.ToNodeId(reference.TargetId, m_settings.NamespaceUris);
                }
            }

            return null;
        }

        private XmlQualifiedName ImportAndFixSymbolicName(UANode input)
        {
            var name = ImportSymbolicName(input);

            var typeDefinitionId = FindTarget(input, ReferenceTypes.HasTypeDefinition, false);

            if (typeDefinitionId == ObjectTypeIds.DataTypeEncodingType)
            {
                if (input.SymbolicName.Contains("Default") && input.SymbolicName.Contains("XML", StringComparison.OrdinalIgnoreCase))
                {
                    if (input.SymbolicName != "DefaultXml")
                    {
                        throw new InvalidDataException($"{input.SymbolicName} is not a valid symbolic name for a DataTypeEncoding node (should be 'DefaultXml').");
                    }
                }

                var dataTypeId = FindTarget(input, ReferenceTypes.HasEncoding, true);

                if (dataTypeId == null)
                {
                    var encodingId = ImportNodeId(input.NodeId);

                    foreach (var dataType in m_nodeset.Items.Where(x => x is UADataType))
                    {
                        var result = FindTarget(dataType, ReferenceTypes.HasEncoding, false, encodingId);

                        if (result != null)
                        {
                            dataTypeId = ImportNodeId(dataType.NodeId);

                            return new XmlQualifiedName(
                                $"{ImportSymbolicName(dataType).Name}_Encoding_{name.Name}",
                                m_settings.NamespaceUris.GetString(dataTypeId.NamespaceIndex));
                        }
                    }
                }
                else
                {
                    var dataType = FindNode(m_nodeset, dataTypeId);

                    if (dataType != null)
                    {
                        return new XmlQualifiedName(
                            $"{ImportSymbolicName(dataType).Name}_Encoding_{name.Name}",
                            m_settings.NamespaceUris.GetString(dataTypeId.NamespaceIndex));
                    }
                }
            }

            return name;
        }

        private void ImportReferences(NodeSet.UANode input)
        {
            NodeId nodeId = ImportNodeId(input.NodeId);

            if (!m_settings.NodesById.TryGetValue(nodeId, out NodeDesign existing))
            {
                return;
            }

            List<Reference> references = new List<Reference>();

            if (existing.References != null)
            {
                references.AddRange(existing.References);
            }

            if (input.References != null)
            {
                foreach (var ii in input.References)
                {
                    NodeId referenceTypeId = ImportNodeId(ii.ReferenceType);
                    var referenceType = FindNode<NodeDesign>(referenceTypeId);

                    if (referenceType == null)
                    {
                        continue;
                    }

                    NodeId targetId = ImportNodeId(ii.Value);
                    var target = FindNode<NodeDesign>(targetId);

                    if (target == null)
                    {
                        continue;
                    }

                    if (referenceTypeId == ReferenceTypeIds.HasTypeDefinition ||
                        referenceTypeId == ReferenceTypeIds.HasSubtype ||
                        referenceTypeId == ReferenceTypeIds.HasModellingRule)
                    {
                        continue;
                    }

                    if (targetId.NamespaceIndex != nodeId.NamespaceIndex || IsTypeOf(referenceTypeId, ReferenceTypeIds.NonHierarchicalReferences))
                    {
                        references.Add(new Reference()
                        {
                            ReferenceType = referenceType.SymbolicId,
                            IsInverse = !ii.IsForward,
                            TargetId = target.SymbolicId,
                            TargetNode = target,
                            SourceNode = existing
                        });

                        continue;
                    }

                    if (!ii.IsForward)
                    {
                        bool found = false;

                        if (target.Children?.Items != null)
                        {
                            foreach (var child in target.Children.Items)
                            {
                                if (existing.SymbolicId == child.SymbolicId)
                                {
                                    found = true;
                                    break;
                                }
                            }
                        }

                        if (!found)
                        {
                            references.Add(new Reference()
                            {
                                ReferenceType = referenceType.SymbolicId,
                                IsInverse = !ii.IsForward,
                                TargetId = target.SymbolicId,
                                TargetNode = target,
                                SourceNode = existing
                            });
                        }
                    }
                }
            }

            if (references.Count > 0)
            {
                existing.HasReferences = true;
                existing.References = references.ToArray();
            }
        }

        private Permissions[] ToPermissions(PermissionType input)
        {
            List<Permissions> permissions = new List<Permissions>();

            if ((input & PermissionType.Browse) != 0)
            {
                permissions.Add(Permissions.Browse);
            }

            if ((input & PermissionType.ReadRolePermissions) != 0)
            {
                permissions.Add(Permissions.ReadRolePermissions);
            }

            if ((input & PermissionType.WriteAttribute) != 0)
            {
                permissions.Add(Permissions.WriteAttribute);
            }

            if ((input & PermissionType.WriteRolePermissions) != 0)
            {
                permissions.Add(Permissions.WriteRolePermissions);
            }

            if ((input & PermissionType.WriteHistorizing) != 0)
            {
                permissions.Add(Permissions.WriteHistorizing);
            }

            if ((input & PermissionType.Read) != 0)
            {
                permissions.Add(Permissions.Read);
            }

            if ((input & PermissionType.Write) != 0)
            {
                permissions.Add(Permissions.Write);
            }

            if ((input & PermissionType.ReadHistory) != 0)
            {
                permissions.Add(Permissions.ReadHistory);
            }

            if ((input & PermissionType.InsertHistory) != 0)
            {
                permissions.Add(Permissions.InsertHistory);
            }

            if ((input & PermissionType.ModifyHistory) != 0)
            {
                permissions.Add(Permissions.ModifyHistory);
            }

            if ((input & PermissionType.DeleteHistory) != 0)
            {
                permissions.Add(Permissions.DeleteHistory);
            }

            if ((input & PermissionType.ReceiveEvents) != 0)
            {
                permissions.Add(Permissions.ReceiveEvents);
            }

            if ((input & PermissionType.Call) != 0)
            {
                permissions.Add(Permissions.Call);
            }

            if ((input & PermissionType.AddReference) != 0)
            {
                permissions.Add(Permissions.AddReference);
            }

            if ((input & PermissionType.RemoveReference) != 0)
            {
                permissions.Add(Permissions.RemoveReference);
            }

            if ((input & PermissionType.DeleteNode) != 0)
            {
                permissions.Add(Permissions.DeleteNode);
            }

            if ((input & PermissionType.AddNode) != 0)
            {
                permissions.Add(Permissions.AddNode);
            }

            return permissions.ToArray();
        }
        
        private RolePermissionSet ToPermissionSet(NodeSet.UANode node, NodeSet.RolePermission[] input)
        {
            if (input == null)
            {
                return null;
            }

            List<RolePermission> permissions = new List<RolePermission>();

            foreach (var ii in input)
            {
                NodeId roleId = ImportNodeId(ii.Value);
                var role = FindNode<NodeDesign>(roleId);

                if (role == null)
                {
                    continue;
                }

                permissions.Add(new RolePermission()
                {
                    Role = role.SymbolicId,
                    Permission = ToPermissions((PermissionType)ii.Permissions)
                });
            }

            if (permissions.Count == 0)
            {
                return null;
            }

            return new RolePermissionSet()
            {
                RolePermission = permissions.ToArray()
            };
        }

        private ModelCompiler.AccessRestrictions ToAccessRestrictions(AccessRestrictionType input)
        {
            if ((input & AccessRestrictionType.EncryptionRequired) != 0)
            {
                input &= ~AccessRestrictionType.SigningRequired;
            }

            switch (input)
            {
                case AccessRestrictionType.SigningRequired: { return AccessRestrictions.SigningRequired; }
                case AccessRestrictionType.EncryptionRequired: { return AccessRestrictions.EncryptionRequired; }
                case AccessRestrictionType.SessionRequired: { return AccessRestrictions.SessionRequired; }
                case AccessRestrictionType.SigningRequired | AccessRestrictionType.SessionRequired: { return AccessRestrictions.SessionWithSigningRequired; }
                case AccessRestrictionType.EncryptionRequired | AccessRestrictionType.SessionRequired: { return AccessRestrictions.SessionWithEncryptionRequired; }
                case AccessRestrictionType.SigningRequired | AccessRestrictionType.ApplyRestrictionsToBrowse: { return AccessRestrictions.SigningAndApplyToBrowseRequired; }
                case AccessRestrictionType.EncryptionRequired | AccessRestrictionType.ApplyRestrictionsToBrowse: { return AccessRestrictions.EncryptionAndApplyToBrowseRequired; }
                case AccessRestrictionType.SessionRequired | AccessRestrictionType.ApplyRestrictionsToBrowse: { return AccessRestrictions.SessionAndApplyToBrowseRequired; }
                case AccessRestrictionType.SigningRequired | AccessRestrictionType.SessionRequired | AccessRestrictionType.ApplyRestrictionsToBrowse: { return AccessRestrictions.SessionWithSigningAndApplyToBrowseRequired; }
                case AccessRestrictionType.EncryptionRequired | AccessRestrictionType.SessionRequired | AccessRestrictionType.ApplyRestrictionsToBrowse: { return AccessRestrictions.SessionWithEncryptionAndApplyToBrowseRequired; }
            }

            return AccessRestrictions.EncryptionRequired;
        }

        private void ImportPermissions(NodeSet.UANode input)
        {
            NodeId nodeId = ImportNodeId(input.NodeId);

            if (!m_settings.NodesById.TryGetValue(nodeId, out NodeDesign existing))
            {
                return;
            }

            existing.RolePermissions = ToPermissionSet(input, input.RolePermissions);
            existing.AccessRestrictions = (input.AccessRestrictionsSpecified) ? ToAccessRestrictions((AccessRestrictionType)input.AccessRestrictions) : 0;
            existing.AccessRestrictionsSpecified = input.AccessRestrictionsSpecified;
        }

        private XmlQualifiedName BuildSymbolicId(UANode node)
        {
            var nodeId = ImportNodeId(node.NodeId, false);

            if (!(node is UAInstance instance))
            {
                return new XmlQualifiedName(
                    ImportAndFixSymbolicName(node).Name,
                    m_settings.NamespaceUris.GetString(nodeId.NamespaceIndex));
            }

            if (String.IsNullOrWhiteSpace(instance.ParentNodeId))
            {
                return new XmlQualifiedName(
                    ImportAndFixSymbolicName(instance).Name,
                    m_settings.NamespaceUris.GetString(nodeId.NamespaceIndex));
            }

            var parentId = ImportNodeId(instance.ParentNodeId);

            if (parentId.NamespaceIndex != nodeId.NamespaceIndex)
            {
                return new XmlQualifiedName(
                    ImportAndFixSymbolicName(instance).Name,
                    m_settings.NamespaceUris.GetString(nodeId.NamespaceIndex));
            }

            UANode parent;

            if (parentId == null || !m_index.TryGetValue(parentId, out parent))
            {
                throw new InvalidDataException($"Parent node ({instance.ParentNodeId}) for {node.NodeId} not found.");
            }

            var symbolicId = BuildSymbolicId(parent);
            var symbolicName = ImportSymbolicName(node);

            if (nodeId == null)
            {
                throw new InvalidDataException($"Node ({symbolicId.Name}) does not have a valid NodeId.");
            }

            return new XmlQualifiedName(
                $"{symbolicId.Name}_{symbolicName.Name}",
                m_settings.NamespaceUris.GetString(nodeId.NamespaceIndex));
        }

        #region Public Methods
        /// <summary>
        /// Imports a node from the set.
        /// </summary>
        public ModelDesign Import(string prefix, string name)
        {
            ModelDesign dictionary = new ModelDesign();

            if (m_nodeset.Models == null || m_nodeset.Models.Length == 0)
            {
                throw new InvalidOperationException($"NodeSet ({m_nodeset.NamespaceUris[0]}) does not have any Models defined!");
            }

            if (m_nodeset.Models != null)
            {
                var model = m_nodeset.Models[0];

                dictionary.TargetNamespace = model.ModelUri;
                dictionary.TargetXmlNamespace = model.XmlSchemaUri;
                dictionary.TargetPublicationDate = model.PublicationDate;
                dictionary.TargetPublicationDateSpecified = model.PublicationDateSpecified;
                dictionary.TargetVersion = model.Version;

                List<Namespace> namespaces = new();
                ImportModel(namespaces, model);
                dictionary.Namespaces = namespaces.ToArray();

                var targetNamespace = namespaces[0];

                if (name != null) targetNamespace.Name = name;
                if (prefix != null) targetNamespace.XmlPrefix = targetNamespace.Prefix = prefix;
            }

            foreach (var node in m_nodeset.Items)
            {
                // hack to ensure DataTypeEncodings have right symbolic names. 
                if (node is UAObject)
                {
                    if (String.IsNullOrEmpty(node.SymbolicName))
                    {
                        switch (node.BrowseName)
                        {
                            case BrowseNames.DefaultBinary: { node.SymbolicName = "DefaultBinary"; break; }
                            case BrowseNames.DefaultXml: { node.SymbolicName = "DefaultXml"; break; }
                            case BrowseNames.DefaultJson: { node.SymbolicName = "DefaultJson"; break; }
                        }
                    }
                    else if (node.SymbolicName == "DefaultXML")
                    {
                        node.SymbolicName = "DefaultXml";
                    }
                }

                if (node is UAInstance instance)
                {
                    // ensure parents are in the same namespace.
                    if (instance.ParentNodeId != null)
                    {
                        var parentId = ImportNodeId(instance.ParentNodeId);
                        var childId = ImportNodeId(instance.NodeId);

                        if (parentId.NamespaceIndex != childId.NamespaceIndex)
                        {
                            instance.ParentNodeId = null;
                        }
                    }

                    // handle missing ParentNodeId when an inverse reference exists.
                    else
                    {
                        foreach (var ii in instance.References.Where(x => !x.IsForward))
                        {
                            var referenceTypeId = ImportNodeId(ii.ReferenceType);

                            if (referenceTypeId == Opc.Ua.ReferenceTypes.HasProperty ||
                                referenceTypeId == Opc.Ua.ReferenceTypes.HasComponent)
                            {
                                instance.ParentNodeId = ii.Value;
                                break;
                            }
                        }
                    }
                }

                var symbolicId = BuildSymbolicId(node);

                while (m_symbolicIds.Values.Where(x => x == symbolicId).FirstOrDefault() != null)
                {
                    symbolicId = new XmlQualifiedName(
                        $"{symbolicId.Name}_{NodeId.Parse(node.NodeId).Identifier}",
                        symbolicId.Namespace);
                }

                m_symbolicIds.Add(node.NodeId, symbolicId);
            }

            foreach (var node in m_nodeset.Items)
            {
                ImportNode(node);
            }

            foreach (var node in m_nodeset.Items)
            {
                if (node is UAInstance child && !String.IsNullOrWhiteSpace(child.ParentNodeId))
                {
                    LinkChildToParent(child);
                }
            }

            foreach (var node in m_nodeset.Items)
            {
                ImportReferences(node);
            }

            foreach (var node in m_nodeset.Items)
            {
                ImportPermissions(node);
            }

            List<NodeDesign> items = new();

            for (int ii = 0; ii < m_nodeset.Items.Length; ii++)
            {
                var node = m_nodeset.Items[ii];

                if (node is UAInstance instance)
                {
                    if (instance.ParentNodeId != null)
                    {
                        continue;
                    }
                }

                NodeId nodeId = ImportNodeId(node.NodeId);

                if (nodeId != null && m_settings.NodesById.TryGetValue(nodeId, out NodeDesign design))
                {
                    items.Add(design);
                }
            }

            Dictionary<XmlQualifiedName, MethodDesign> methods = new();
            CollectMethodDefinitions(dictionary.TargetNamespace, methods);

            foreach (var method in methods.Values)
            {
                items.Add(method);
            }

            dictionary.Items = items.ToArray();
            return dictionary;
        }

        private void CollectMethodDefinitions(string targetNamespace, Dictionary<XmlQualifiedName, MethodDesign> methods)
        {
            foreach (var node in m_settings.NodesById.Values)
            {
                if (node is MethodDesign method)
                {
                    if (node.SymbolicId.Namespace != targetNamespace)
                    {
                        continue;
                    }

                    if (method.HasArguments && method.MethodDeclarationNode == null)
                    {
                        var name = new XmlQualifiedName(node.SymbolicName.Name + "MethodType", node.SymbolicId.Namespace);

                        if (methods.ContainsKey(name))
                        {
                            continue;
                        }

                        MethodDesign declaration = new MethodDesign()
                        {
                            SymbolicId = new XmlQualifiedName(node.SymbolicId.Name + "MethodType", node.SymbolicId.Namespace),
                            SymbolicName = name,
                            BrowseName = name.Name,
                            DisplayName = new LocalizedText() { Value = name.Name, IsAutogenerated = true },
                            InputArguments = method.InputArguments,
                            OutputArguments = method.OutputArguments,
                            HasArguments = true
                        };

                        methods.Add(declaration.SymbolicName, declaration);
                    }
                }
            }
        }
        #endregion

        #region Private Members
        /// <summary>
        /// Creates an decoder to restore Variant values.
        /// </summary>
        private XmlDecoder CreateDecoder(XmlElement source)
        {
            IServiceMessageContext messageContext = new ServiceMessageContext()
            {
                NamespaceUris = m_settings.NamespaceUris,
                ServerUris = m_serverUris,
                Factory = ServiceMessageContext.GlobalContext.Factory
            };

            XmlDecoder decoder = new XmlDecoder(source, messageContext);

            NamespaceTable namespaceUris = new NamespaceTable();

            if (m_nodeset.NamespaceUris != null)
            {
                for (int ii = 0; ii < m_nodeset.NamespaceUris.Length; ii++)
                {
                    namespaceUris.Append(m_nodeset.NamespaceUris[ii]);
                }
            }

            StringTable serverUris = new StringTable();

            if (m_nodeset.ServerUris != null)
            {
                serverUris.Append(m_serverUris.GetString(0));

                for (int ii = 0; ii < m_nodeset.ServerUris.Length; ii++)
                {
                    serverUris.Append(m_nodeset.ServerUris[ii]);
                }
            }

            decoder.SetMappingTables(namespaceUris, serverUris);

            return decoder;
        }

        private AccessLevel ImportAccessLevel(uint input)
        {
            if ((AccessLevelExType.CurrentRead & (AccessLevelExType)input) != 0)
            {
                if ((AccessLevelExType.CurrentWrite & (AccessLevelExType)input) != 0)
                {
                    return AccessLevel.ReadWrite;
                }

                return AccessLevel.Read;
            }

            if ((AccessLevelExType.CurrentWrite & (AccessLevelExType)input) != 0)
            {
                return AccessLevel.Write;
            }

            if ((AccessLevelExType.HistoryRead & (AccessLevelExType)input) != 0)
            {
                if ((AccessLevelExType.HistoryWrite & (AccessLevelExType)input) != 0)
                {
                    return AccessLevel.HistoryReadWrite;
                }

                return AccessLevel.HistoryRead;
            }

            if ((AccessLevelExType.HistoryWrite & (AccessLevelExType)input) != 0)
            {
                return AccessLevel.HistoryWrite;
            }

            return AccessLevel.None;
        }

        private ValueRank ImportValueRank(int input) =>
            input switch
            {
                (> 1) => ValueRank.OneOrMoreDimensions,
                (1) => ValueRank.Array,
                (0) => ValueRank.OneOrMoreDimensions,
                (-1) => ValueRank.Scalar,
                (-2) => ValueRank.ScalarOrArray,
                (-3) => ValueRank.ScalarOrOneDimension,
                (< -3) => ValueRank.ScalarOrArray
            };

        private ModellingRule ImportModellingRule(ExpandedNodeId input)
        {
            if (input == ObjectIds.ModellingRule_Mandatory)
            {
                return ModellingRule.Mandatory;
            }

            if (input == ObjectIds.ModellingRule_Optional)
            {
                return ModellingRule.Optional;
            }

            if (input == ObjectIds.ModellingRule_MandatoryPlaceholder)
            {
                return ModellingRule.MandatoryPlaceholder;
            }

            if (input == ObjectIds.ModellingRule_OptionalPlaceholder)
            {
                return ModellingRule.OptionalPlaceholder;
            }

            if (input == ObjectIds.ModellingRule_ExposesItsArray)
            {
                return ModellingRule.ExposesItsArray;
            }

            return ModellingRule.None;
        }

        private string ImportCategories(string[] input)
        {
            if (input != null)
            {
                StringBuilder output = new();

                foreach (var ii in input)
                {
                    if (output.Length > 0)
                    {
                        output.Append(',');
                    }

                    output.Append(ii);
                }

                return output.ToString();
            }

            return null;
        }

        private ReleaseStatus ImportReleaseStatus(NodeSet.ReleaseStatus input) =>
            input switch
            {
                (NodeSet.ReleaseStatus.Deprecated) => ReleaseStatus.Deprecated,
                (NodeSet.ReleaseStatus.Released) => ReleaseStatus.Released,
                (NodeSet.ReleaseStatus.Draft) => ReleaseStatus.Draft,
                _ => ReleaseStatus.Released
            };

        /// <summary>
        ///  Imports a NodeId
        /// </summary>
        private Opc.Ua.ReferenceNode ImportReference(NodeSet.Reference source)
        {
            if (source == null)
            {
                return null;
            }

            var referenceTypeId = ImportNodeId(source.ReferenceType, true);

            if (referenceTypeId == null)
            {
                throw new InvalidDataException($"ReferenceType ({source.ReferenceType}) is not valid.");
            }

            var targetId = ImportExpandedNodeId(source.Value);

            return new ReferenceNode()
            {
                ReferenceTypeId = referenceTypeId,
                IsInverse = !source.IsForward,
                TargetId = targetId
            };
        }

        /// <summary>
        ///  Imports a NodeId
        /// </summary>
        private Opc.Ua.NodeId ImportNodeId(string source, bool lookupAlias = true)
        {
            if (String.IsNullOrEmpty(source))
            {
                return null;
            }

            // lookup alias.
            if (lookupAlias && m_aliases.TryGetValue(source, out NodeId nodeId))
            {
                return nodeId;
            }

            // parse the string.
            nodeId = NodeId.Parse(source);

            if (nodeId.NamespaceIndex > 0)
            {
                ushort namespaceIndex = ImportNamespaceIndex(nodeId.NamespaceIndex, m_settings.NamespaceUris);
                nodeId = new NodeId(nodeId.Identifier, namespaceIndex);
            }

            return nodeId;
        }

        /// <summary>
        /// Imports a ExpandedNodeId
        /// </summary>
        private Opc.Ua.ExpandedNodeId ImportExpandedNodeId(string source)
        {
            if (String.IsNullOrEmpty(source))
            {
                return Opc.Ua.ExpandedNodeId.Null;
            }

            // lookup aliases
            if (m_nodeset.Aliases != null)
            {
                for (int ii = 0; ii < m_nodeset.Aliases.Length; ii++)
                {
                    if (m_nodeset.Aliases[ii].Alias == source)
                    {
                        source = m_nodeset.Aliases[ii].Value;
                        break;
                    }
                }
            }

            // parse the node.
            Opc.Ua.ExpandedNodeId nodeId = Opc.Ua.ExpandedNodeId.Parse(source);

            if (nodeId.ServerIndex <= 0 && nodeId.NamespaceIndex <= 0 && String.IsNullOrEmpty(nodeId.NamespaceUri))
            {
                return nodeId;
            }

            uint serverIndex = ImportServerIndex(nodeId.ServerIndex, m_serverUris);
            ushort namespaceIndex = ImportNamespaceIndex(nodeId.NamespaceIndex, m_settings.NamespaceUris);

            if (serverIndex > 0)
            {
                string namespaceUri = nodeId.NamespaceUri;

                if (String.IsNullOrEmpty(nodeId.NamespaceUri))
                {
                    namespaceUri = m_settings.NamespaceUris.GetString(namespaceIndex);
                }

                nodeId = new Opc.Ua.ExpandedNodeId(nodeId.Identifier, 0, namespaceUri, serverIndex);
                return nodeId;
            }


            nodeId = new Opc.Ua.ExpandedNodeId(nodeId.Identifier, namespaceIndex, null, 0);
            return nodeId;
        }

        /// <summary>
        /// Imports a QualifiedName
        /// </summary>
        private XmlQualifiedName ImportQualifiedName(string source)
        {
            if (String.IsNullOrEmpty(source))
            {
                return null;
            }

            var qname = Opc.Ua.QualifiedName.Parse(source);

            StringBuilder builder = new StringBuilder();

            foreach (var ch in qname.Name)
            {
                if (builder.Length == 0)
                {
                    if (!Char.IsLetter(ch) && ch != '_')
                    {
                        builder.Append('_');
                        continue;
                    }
                }
                else
                {
                    if (!Char.IsLetterOrDigit(ch) && ch != '_' && ch != '.' && ch != '+')
                    {
                        builder.Append('_');
                        continue;
                    }
                }

                builder.Append(ch);
            }

            if (qname.NamespaceIndex > 0)
            {
                ushort namespaceIndex = ImportNamespaceIndex(qname.NamespaceIndex, m_settings.NamespaceUris);
                return new XmlQualifiedName(builder.ToString(), m_settings.NamespaceUris.GetString(namespaceIndex));
            }

            return new XmlQualifiedName(builder.ToString(), m_settings.NamespaceUris.GetString(0));
        }

        /// <summary>
        /// Imports the array dimensions.
        /// </summary>
        private string ImportArrayDimensions(IList<uint> arrayDimensions)
        {
            if (arrayDimensions == null)
            {
                return null;
            }

            StringBuilder output = new();

            foreach (var ii in arrayDimensions)
            {
                if (output.Length > 0)
                {
                    output.Append(',');
                }

                output.Append(ii);
            }

            return output.ToString();
        }

        /// <summary>
        /// Imports a namespace index.
        /// </summary>
        private ushort ImportNamespaceIndex(ushort namespaceIndex, NamespaceTable namespaceUris)
        {
            // nothing special required for indexes 0 and 1.
            if (namespaceIndex < 1)
            {
                return namespaceIndex;
            }

            // return a bad value if parameters are bad.
            if (namespaceUris == null || m_nodeset.NamespaceUris == null || m_nodeset.NamespaceUris.Length <= namespaceIndex - 1)
            {
                return UInt16.MaxValue;
            }

            // find or append uri.
            return namespaceUris.GetIndexOrAppend(m_nodeset.NamespaceUris[namespaceIndex - 1]);
        }

        /// <summary>
        /// Imports a server index.
        /// </summary>
        private uint ImportServerIndex(uint serverIndex, StringTable serverUris)
        {
            // nothing special required for indexes 0.
            if (serverIndex <= 0)
            {
                return serverIndex;
            }

            // return a bad value if parameters are bad.
            if (serverUris == null || m_nodeset.ServerUris == null || m_nodeset.ServerUris.Length <= serverIndex - 1)
            {
                return UInt16.MaxValue;
            }

            // find or append uri.
            return serverUris.GetIndexOrAppend(m_nodeset.ServerUris[serverIndex - 1]);
        }
        #endregion
    }

    internal static class Extensions
    {
        /// <summary>
        /// Safe version for assignment of InnerXml.
        /// </summary>
        /// <param name="doc">The XmlDocument.</param>
        /// <param name="xml">The Xml document string.</param>
        internal static void LoadInnerXml(this XmlDocument doc, string xml)
        {
            using (var sreader = new StringReader(xml))
            using (var reader = XmlReader.Create(sreader, DefaultXmlReaderSettings()))
            {
                doc.XmlResolver = null;
                doc.Load(reader);
            }
        }

        internal static XmlReaderSettings DefaultXmlReaderSettings()
        {
            return new XmlReaderSettings()
            {
                DtdProcessing = DtdProcessing.Prohibit,
                XmlResolver = null,
                ConformanceLevel = ConformanceLevel.Document
            };
        }
    }
}
