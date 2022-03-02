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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using NodeSet = Opc.Ua.Export;

namespace ModelCompiler
{
    public class NodeSetReaderSettings
    {
        public NodeSetReaderSettings()
        {
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
        private NamespaceTable m_namespaceUris = new NamespaceTable();
        private StringTable m_serverUris = new StringTable();
        private NodeSet.UANodeSet m_nodeset;
        private Dictionary<string,NodeId> m_aliases = new Dictionary<string, NodeId>();
        private Dictionary<NodeId,NodeSet.UANode> m_index;
        ushort[] m_nsMapping;

        public NodeSetToModelDesign(NodeSetReaderSettings settings, string filePath)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            m_settings = settings;
            m_index = new Dictionary<NodeId, NodeSet.UANode>();

            using (var istrm = File.OpenRead(filePath))
            {
                m_nodeset = Opc.Ua.Export.UANodeSet.Read(istrm);

                if (m_nodeset.NamespaceUris != null)
                {
                    foreach (var ns in m_nodeset.NamespaceUris)
                    {
                        m_namespaceUris.Append(ns);
                    }
                }

                if (m_nodeset.Aliases != null)
                {
                    foreach (var ii in m_nodeset.Aliases)
                    {
;                        m_aliases[ii.Alias] = ImportNodeId(ii.Value, false);
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


        private void ImportModel(IList<Namespace> namespaces, NodeSet.ModelTableEntry model)
        {
            var ns = (from x in namespaces where x.Value == model.ModelUri select x).FirstOrDefault();

            if (ns != null)
            {
                return;
            }

            ns = new Namespace()
            {
                Value = model.ModelUri,
                XmlNamespace = model.XmlSchemaUri,
                PublicationDate = model.PublicationDate.ToString("yyyy-MM-ddT00:00:00Z"),
                Version = model.Version
            };

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

                    parentId = parent.SymbolicId;
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
            
            return browseName;
        }

        private string ImportCategories(IList<string> input)
        {
            StringBuilder builder = new StringBuilder();

            if (input != null)
            {
                foreach (var ii in input)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append(',');
                    }

                    builder.Append(ii);
                }
            }

            return builder.ToString();
        }

        private LocalizedText ImportLocalizedText(IList<NodeSet.LocalizedText> input)
        {
            if (input != null && input.Count > 0)
            {
                return new LocalizedText() { Value = input[0].Value, IsAutogenerated = false };
            }

            return null;
        }

        private NodeId MapNodeId(ExpandedNodeId nodeId)
        {
            if (!nodeId.IsAbsolute)
            {
                return new NodeId(nodeId.Identifier, m_nsMapping[nodeId.NamespaceIndex]);
            }

            return null;
        }

        private XmlQualifiedName NodeIdToQName(ExpandedNodeId nodeId)
        {
            if (!nodeId.IsAbsolute)
            {
                if (m_settings.NodesById.TryGetValue(MapNodeId(nodeId), out NodeDesign design))
                {
                    return design.SymbolicId;
                }
            }

            return null;
        }

        private ReferenceTypeDesign FindReferenceType(ExpandedNodeId targetId) 
        {
            if (m_settings.NodesById.TryGetValue(MapNodeId(targetId), out NodeDesign design))
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
            if (m_settings.NodesById.TryGetValue(MapNodeId(targetId), out NodeDesign design))
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

                    if (ReferenceTypeIds.HasSubtype != rtid && !reference.IsForward)
                    {
                        continue;
                    }

                    var targetId = ImportNodeId(reference.Value);
                    return FindNode<T>(targetId) as T;
                }
            }

            return null;
        }

        private ReferenceTypeDesign ImportReferenceType(NodeSet.UAReferenceType input)
        {
            NodeId nodeId = ImportNodeId(input.NodeId);
            NodeId importedNodeId = new NodeId(nodeId.Identifier, m_nsMapping[nodeId.NamespaceIndex]);

            if (m_settings.NodesById.TryGetValue(importedNodeId, out NodeDesign existing))
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
            m_settings.NodesById[importedNodeId] = output;

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
                return new ObjectTypeDesign();
            }

            if (input is NodeSet.UAVariable)
            {
                return new VariableTypeDesign();
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

            output.IsAbstract = input.IsAbstract;

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
        }

        private void UpdateVariableTypeDesign(NodeSet.UAVariableType input, VariableTypeDesign output)
        {
            if (input == null || output == null)
            {
                return;
            }

            output.DefaultValue = input.Value;
            output.ValueRank = ImportValueRank(input.ValueRank);
            output.ArrayDimensions = input.ArrayDimensions;

            var dataType = FindNode<DataTypeDesign>(ImportNodeId(input.DataType));

            if (dataType == null)
            {
                throw new InvalidDataException($"Could not find DataType Node for '{input.BrowseName}/{input.DataType}'.");
            }

            output.DataType = dataType.SymbolicId;
            output.DataTypeNode = dataType;
        }

        private void UpdateReferenceTypeDesign(NodeSet.UAReferenceType input, ReferenceTypeDesign output)
        {
            if (input == null || output == null)
            {
                return;
            }

            output.InverseName = ImportLocalizedText(input.InverseName);
            output.Symmetric = input.Symmetric;
            output.SymmetricSpecified = true;
        }

        private bool IsTypeOf(NodeSet.UAType subtype, NodeId superTypeId)
        {
            NodeId nodeId = ImportNodeId(subtype.NodeId);
            NodeId importedNodeId = new NodeId(nodeId.Identifier, m_nsMapping[nodeId.NamespaceIndex]);

            if (importedNodeId == superTypeId)
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

        private void UpdateDataTypeDesign(NodeSet.UADataType input, DataTypeDesign output)
        {
            if (input == null || output == null)
            {
                return;
            }

            if (input.Definition != null)
            {
                output.IsOptionSet = input.Definition.IsOptionSet;
                output.IsUnion = input.Definition.IsUnion;

                if (IsTypeOf(input, DataTypeIds.Enumeration))
                {
                    output.IsEnumeration = true;
                }

                var fields = new List<Parameter>();

                if (input.Definition.Field != null)
                {
                    foreach (var ii in input.Definition.Field)
                    {
                        var field = new Parameter()
                        {
                            Name = ii.Name,
                            Description = ImportLocalizedText(ii.Description),
                            ArrayDimensions = ii.ArrayDimensions,
                            ValueRank = ImportValueRank(ii.ValueRank)
                        };

                        if (!String.IsNullOrEmpty(ii.SymbolicName))
                        {
                            field.Name = ii.SymbolicName;
                        }

                        var dataType = FindNode<DataTypeDesign>(ImportNodeId(ii.DataType));

                        if (dataType == null)
                        {
                            throw new InvalidDataException($"Could not find DataType Node for Field '{input.BrowseName}/{ii.Name}/{ii.DataType}'.");
                        }

                        field.DataType = dataType.SymbolicId;
                        field.DataTypeNode = dataType;
                        field.AllowSubTypes = ii.AllowSubTypes;

                        if (output.IsOptionSet)
                        {
                            long mask = 1 << ii.Value;
                            field.BitMask = $"{mask:X8}";
                            field.Identifier = 0;
                            field.IdentifierSpecified = false;
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

            output.DefaultValue = input.Value;
            output.ValueRank = ImportValueRank(input.ValueRank);
            output.ArrayDimensions = input.ArrayDimensions;
            output.MinimumSamplingInterval = (int)input.MinimumSamplingInterval;
            output.MinimumSamplingIntervalSpecified = true;
            output.Historizing = input.Historizing;
            output.AccessLevel = ImportAccessLevel(input.AccessLevel);
            output.AccessLevelSpecified = true;
 
            var dataType = FindNode<DataTypeDesign>(ImportNodeId(input.DataType));

            if (dataType == null)
            {
                throw new InvalidDataException($"Could not find DataType Node for '{input.BrowseName}/{input.DataType}'.");
            }

            output.DataType = dataType.SymbolicId;
            output.DataTypeNode = dataType;
        }
        
        private List<Parameter> ImportArguments(XmlElement input)
        {
            List<Parameter> output = new List<Parameter>();

            if (input != null)
            {
                XmlDecoder decoder = CreateDecoder(input);
                TypeInfo typeInfo = null;
                var value = decoder.ReadVariantContents(out typeInfo);
                decoder.Close();

            }

            return output;
        }

        private void UpdateMethodDesign(NodeSet.UAMethod input, MethodDesign output)
        {
            if (input == null || output == null)
            {
                return;
            }

            output.NonExecutable = !input.Executable;
            output.NonExecutableSpecified = !input.Executable;

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
                            output.InputArguments = ImportArguments(property.DefaultValue).ToArray();
                        }
                        else if (property.BrowseName == BrowseNames.OutputArguments)
                        {
                            output.OutputArguments = ImportArguments(property.DefaultValue).ToArray();
                        }
                    }
                }
            }
        }

        private NodeDesign ImportNode(NodeSet.UANode input)
        {
            NodeId nodeId = ImportNodeId(input.NodeId);
            NodeId importedNodeId = new NodeId(nodeId.Identifier, m_nsMapping[nodeId.NamespaceIndex]);

            if (m_settings.NodesById.TryGetValue(importedNodeId, out NodeDesign existing))
            {
                return existing;
            }

            var output = CreateNodeDesign(input);

            output.SymbolicName = ImportSymbolicName(input);
            output.SymbolicId = output.SymbolicName;
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

            if (output is TypeDesign type)
            {
                UpdateTypeDesign(input as NodeSet.UAType, type);
            }

            if (output is VariableTypeDesign vt)
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

            m_settings.NodesByQName[output.SymbolicId] = output;
            m_settings.NodesById[importedNodeId] = output;

            return output;
        }

        private void AddChildIfNotExists(NodeDesign parent, InstanceDesign child)
        {
            if (parent == null || child == null)
            {
                return;
            }

            List<InstanceDesign> children = new List<InstanceDesign>();

            if (parent.Children?.Items != null)
            {
                children.AddRange(parent.Children?.Items);

                foreach (var ii in parent.Children.Items)
                {
                    if (ii.SymbolicId == child.SymbolicId)
                    {
                        return;
                    }
                }
            }

            child.Parent = parent;
            children.Add(child);

            parent.Children = new ListOfChildren()
            {
                Items = children.ToArray()
            };

            parent.HasChildren = true;
        }

        private void ImportReferences(NodeSet.UANode input)
        {
            NodeId nodeId = ImportNodeId(input.NodeId);
            NodeId importedNodeId = new NodeId(nodeId.Identifier, m_nsMapping[nodeId.NamespaceIndex]);

            if (!m_settings.NodesById.TryGetValue(importedNodeId, out NodeDesign existing))
            {
                return;
            }

            NodeDesign parent = null;

            if (input is NodeSet.UAInstance instance)
            {
                if (!String.IsNullOrEmpty(instance.ParentNodeId))
                {
                    NodeId parentId = ImportNodeId(instance.ParentNodeId);
                    parent = FindNode<NodeDesign>(parentId);
                    AddChildIfNotExists(parent, existing as InstanceDesign);
                }
            }

            List<Reference> references = new List<Reference>();

            foreach (var ii in input.References)
            {
                NodeId referenceTypeId = ImportNodeId(ii.ReferenceType);
                
                var referenceType = FindNode<NodeDesign>(ii.Value);

                if (referenceType == null)
                {
                    continue;
                }

                NodeId targetId = ImportNodeId(ii.Value);

                var target = FindNode<NodeDesign>(ii.Value);

                if (target ==  null)
                {
                    continue;
                }

                if (IsTypeOf(referenceTypeId, ReferenceTypeIds.NonHierarchicalReferences))
                {
                    if (referenceTypeId == ReferenceTypeIds.HasTypeDefinition ||
                        referenceTypeId == ReferenceTypeIds.HasSubtype ||
                        referenceTypeId == ReferenceTypeIds.HasModellingRule)
                    {
                        continue;
                    }

                    references.Add(new Reference()
                    { 
                        ReferenceType = referenceType.SymbolicId,
                        IsInverse = !ii.IsForward,
                        TargetId = target.SymbolicId,
                        TargetNode = target
                    });

                    continue;
                }
            }
        }

        #region Public Methods
        /// <summary>
        /// Imports a node from the set.
        /// </summary>
        public ModelDesign Import()
        {
            ModelDesign dictionary = new ModelDesign();

            if (m_nodeset.Models != null)
            {
                var model = m_nodeset.Models[0];

                dictionary.TargetNamespace = model.ModelUri;
                dictionary.TargetXmlNamespace = model.XmlSchemaUri;
                dictionary.TargetPublicationDate = model.PublicationDate;
                dictionary.TargetPublicationDateSpecified = model.PublicationDateSpecified;
                dictionary.TargetVersion = model.Version;

                List<Namespace> namespaces = new ();
                ImportModel(namespaces, model);
                dictionary.Namespaces = namespaces.ToArray();
            }

            m_nsMapping = m_namespaceUris.CreateMapping(m_settings.NamespaceUris, true);

            foreach (var node in m_nodeset.Items)
            {
                ImportNode(node);
            }

            foreach (var node in m_nodeset.Items)
            {
                ImportReferences(node);
            }


            Dictionary<NodeId, List<Opc.Ua.ReferenceNode>> references = new();

            foreach (var node in m_nodeset.Items)
            {
                var nid = ImportNodeId(node.NodeId, true);
                m_index[nid] = node;

                if (node.References != null)
                {
                    if (!references.TryGetValue(nid, out List<Opc.Ua.ReferenceNode> list))
                    {
                        references[nid] = list = new List<ReferenceNode>();
                    }

                    foreach (var ii in node.References)
                    {
                        var reference = ImportReference(ii);
                        list.Add(reference);
                    }
                }
            }


            List<NodeDesign> items = new ();

            /*
            for (int ii = 0; ii < m_nodeset.Items.Length; ii++)
            {
                var node = m_nodeset.Items[ii];
                NodeDesign importedNode = Import(node);
                list.Add(importedNode);
            }
            */

            dictionary.Items = items.ToArray();
            return dictionary;
        }
        #endregion

        #region Private Members
        /// <summary>
        /// Creates an decoder to restore Variant values.
        /// </summary>
        private XmlDecoder CreateDecoder(XmlElement source)
        {
            IServiceMessageContext messageContext = new ServiceMessageContext() {
                NamespaceUris = m_namespaceUris,
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
            if ((AccessLevelExType.CurrentRead | (AccessLevelExType)input) != 0)
            {
                if ((AccessLevelExType.CurrentWrite | (AccessLevelExType)input) != 0)
                {
                    return AccessLevel.ReadWrite;
                }

                return AccessLevel.Read;
            }

            if ((AccessLevelExType.CurrentWrite | (AccessLevelExType)input) != 0)
            {
                return AccessLevel.Write;
            }

            if ((AccessLevelExType.HistoryRead | (AccessLevelExType)input) != 0)
            {
                if ((AccessLevelExType.HistoryWrite | (AccessLevelExType)input) != 0)
                {
                    return AccessLevel.HistoryReadWrite;
                }

                return AccessLevel.HistoryRead;
            }

            if ((AccessLevelExType.HistoryWrite | (AccessLevelExType)input) != 0)
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
                (<= -2) => ValueRank.ScalarOrArray
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

        /// <summary>
        /// Imports a node from the set.
        /// </summary>
        private NodeDesign Import(ISystemContext context, NodeSet.UANode node)
        {
            NodeDesign importedNode = null;

            NodeClass nodeClass = NodeClass.Unspecified;

            if (node is NodeSet.UAObject) nodeClass = NodeClass.Object;
            else if (node is NodeSet.UAVariable) nodeClass = NodeClass.Variable;
            else if (node is NodeSet.UAMethod) nodeClass = NodeClass.Method;
            else if (node is NodeSet.UAObjectType) nodeClass = NodeClass.ObjectType;
            else if (node is NodeSet.UAVariableType) nodeClass = NodeClass.VariableType;
            else if (node is NodeSet.UADataType) nodeClass = NodeClass.DataType;
            else if (node is NodeSet.UAReferenceType) nodeClass = NodeClass.ReferenceType;
            else if (node is NodeSet.UAView) nodeClass = NodeClass.View;

            switch (nodeClass)
            {
                case NodeClass.Object:
                {
                    NodeSet.UAObject o = (NodeSet.UAObject)node;
                    ObjectDesign value = new ();
                    value.SupportsEvents = ((EventNotifierType)o.EventNotifier & EventNotifierType.SubscribeToEvents) != 0;
                    importedNode = value;
                    break;
                }

                case NodeClass.Variable:
                {
                    NodeSet.UAVariable o = (NodeSet.UAVariable)node;

                    NodeId typeDefinitionId = null;

                    if (node.References != null)
                    {
                        for (int ii = 0; ii < node.References.Length; ii++)
                        {
                            Opc.Ua.NodeId referenceTypeId = ImportNodeId(node.References[ii].ReferenceType, true);
                            bool isInverse = !node.References[ii].IsForward;
                            Opc.Ua.ExpandedNodeId targetId = ImportExpandedNodeId(node.References[ii].Value);

                            if (referenceTypeId == ReferenceTypeIds.HasTypeDefinition && !isInverse)
                            {
                                typeDefinitionId = Opc.Ua.ExpandedNodeId.ToNodeId(targetId, context.NamespaceUris);
                                break;
                            }
                        }
                    }

                    VariableDesign value = new ();

                    value.DataType = NodeIdToQName(ImportNodeId(o.DataType, true));
                    value.ValueRank = ImportValueRank(o.ValueRank);
                    value.ValueRankSpecified = true;
                    value.ArrayDimensions = o.ArrayDimensions;
                    value.AccessLevel = ImportAccessLevel(o.AccessLevel);
                    value.AccessLevelSpecified = true;
                    value.MinimumSamplingInterval = (int)o.MinimumSamplingInterval;
                    value.MinimumSamplingIntervalSpecified = true;
                    value.Historizing = o.Historizing;
                    value.HistorizingSpecified = true;
                    value.DefaultValue = o.Value;

                    if (o.Value != null)
                    {
                        XmlDecoder decoder = CreateDecoder(o.Value);
                        TypeInfo typeInfo = null;
                        value.DecodedValue = decoder.ReadVariantContents(out typeInfo);
                        decoder.Close();
                    }

                    importedNode = value;
                    break;
                }

                case NodeClass.Method:
                {
                    NodeSet.UAMethod o = (NodeSet.UAMethod)node;
                    MethodDesign value = new ();
                    value.NonExecutable = !o.Executable;
                    value.Declaration = NodeIdToQName(ImportNodeId(o.MethodDeclarationId, true));
                    importedNode = value;
                    break;
                }

                case NodeClass.View:
                {
                    NodeSet.UAView o = (NodeSet.UAView)node;
                    ViewDesign value = new ();
                    value.ContainsNoLoops = o.ContainsNoLoops;
                    importedNode = value;
                    break;
                }

                case NodeClass.ObjectType:
                {
                    NodeSet.UAObjectType o = (NodeSet.UAObjectType)node;
                    ObjectTypeDesign value = new ();
                    value.IsAbstract = o.IsAbstract;
                    importedNode = value;
                    break;
                }

                case NodeClass.VariableType:
                {
                    NodeSet.UAVariableType o = (NodeSet.UAVariableType)node;
                    VariableTypeDesign value = new ();
                    value.IsAbstract = o.IsAbstract; value.DataType = NodeIdToQName(ImportNodeId(o.DataType, true));
                    value.ValueRank = ImportValueRank(o.ValueRank);
                    value.ValueRankSpecified = true;
                    value.ArrayDimensions = o.ArrayDimensions;
                    value.DefaultValue = o.Value;

                    if (o.Value != null)
                    {
                        XmlDecoder decoder = CreateDecoder(o.Value);
                        TypeInfo typeInfo = null;
                        value.DecodedValue = decoder.ReadVariantContents(out typeInfo);
                        decoder.Close();
                    }

                    importedNode = value;
                    break;
                }

                case NodeClass.DataType:
                {
                    NodeSet.UADataType o = (NodeSet.UADataType)node;
                    DataTypeDesign value = new ();
                    value.IsAbstract = o.IsAbstract;

                    Opc.Ua.DataTypeDefinition dataTypeDefinition = Import(o, o.Definition, context.NamespaceUris);

                    // TBD

                    value.Purpose = ImportPurpose(o.Purpose);
                    importedNode = value;
                    break;
                }

                case NodeClass.ReferenceType:
                {
                    NodeSet.UAReferenceType o = (NodeSet.UAReferenceType)node;
                    ReferenceTypeDesign value = new ();
                    value.IsAbstract = o.IsAbstract;
                    value.InverseName = Import(o.InverseName);
                    value.Symmetric = o.Symmetric;
                    importedNode = value;
                    break;
                }
            }

            importedNode.SymbolicId = NodeIdToQName(ImportNodeId(node.NodeId, false));
            importedNode.SymbolicName = ImportQualifiedName(node.BrowseName);
            importedNode.DisplayName = Import(node.DisplayName);

            if (importedNode.DisplayName == null)
            {
                importedNode.DisplayName = new LocalizedText() { Value = importedNode.SymbolicName.Name };
            }

            importedNode.Description = Import(node.Description);
            importedNode.Category = ImportCategories(node.Category);
            importedNode.ReleaseStatus = ImportReleaseStatus(node.ReleaseStatus);

            if (node.References != null)
            {
                InstanceDesign instance = importedNode as InstanceDesign;
                TypeDesign type = importedNode as TypeDesign;

                for (int ii = 0; ii < node.References.Length; ii++)
                {
                    Opc.Ua.NodeId referenceTypeId = ImportNodeId(node.References[ii].ReferenceType, true);
                    bool isInverse = !node.References[ii].IsForward;
                    Opc.Ua.ExpandedNodeId targetId = ImportExpandedNodeId(node.References[ii].Value);

                    List<Reference> references = new List<Reference>();

                    if (instance != null)
                    {
                        if (referenceTypeId == ReferenceTypeIds.HasModellingRule && !isInverse)
                        {
                            instance.ModellingRule = ImportModellingRule(targetId);
                            continue;
                        }

                        if (referenceTypeId == ReferenceTypeIds.HasTypeDefinition && !isInverse)
                        {
                            instance.TypeDefinition = NodeIdToQName((NodeId)targetId);
                            continue;
                        }
                    }

                    if (type != null)
                    {
                        if (referenceTypeId == ReferenceTypeIds.HasSubtype && isInverse)
                        {
                            type.BaseType = NodeIdToQName((NodeId)targetId);
                            continue;
                        }
                    }

                    references.Add(new Reference()
                    {
                        IsInverse = isInverse,
                        ReferenceType = NodeIdToQName(referenceTypeId),
                        TargetId = NodeIdToQName((NodeId)targetId)
                    });
                }
            }

            return importedNode;
        }

        private string ImportCategories(string[] category)
        {
            throw new NotImplementedException();
        }

        private ReleaseStatus ImportReleaseStatus(NodeSet.ReleaseStatus releaseStatus)
        {
            throw new NotImplementedException();
        }

        private DataTypePurpose ImportPurpose(NodeSet.DataTypePurpose purpose)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Imports a NodeId
        /// </summary>
        private XmlQualifiedName NodeIdToQName(Opc.Ua.NodeId nodeId)
        {
            return new XmlQualifiedName(nodeId.Identifier.ToString());
        }

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
                return Opc.Ua.NodeId.Null;
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
                ushort namespaceIndex = ImportNamespaceIndex(nodeId.NamespaceIndex, m_namespaceUris);
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
            ushort namespaceIndex = ImportNamespaceIndex(nodeId.NamespaceIndex, m_namespaceUris);

            if (serverIndex > 0)
            {
                string namespaceUri = nodeId.NamespaceUri;

                if (String.IsNullOrEmpty(nodeId.NamespaceUri))
                {
                    namespaceUri = m_namespaceUris.GetString(namespaceIndex);
                }

                nodeId = new Opc.Ua.ExpandedNodeId(nodeId.Identifier, 0, namespaceUri, serverIndex);
                return nodeId;
            }


            nodeId = new Opc.Ua.ExpandedNodeId(nodeId.Identifier, namespaceIndex, null, 0);
            return nodeId;
        }

        /// <summary>
        /// Imports a DataTypeDefinition
        /// </summary>
        private Opc.Ua.DataTypeDefinition Import(NodeSet.UADataType dataType, NodeSet.DataTypeDefinition source, NamespaceTable namespaceUris)
        {
            if (source == null)
            {
                return null;
            }

            if (source.Field != null)
            {
                // check if definition is for enumeration or structure.
                bool isStructure = Array.Exists<NodeSet.DataTypeField>(source.Field, delegate (NodeSet.DataTypeField fieldLookup) {
                    return fieldLookup.Value == -1;
                });

                if (isStructure)
                {
                    DataTypeDesign sd = new ();
                    sd.BaseType = NodeIdToQName(ImportNodeId(source.BaseType, true));

                    if (source.IsUnion)
                    {
                        sd.IsUnion = true;
                    }

                    if (source.Field != null)
                    {
                        List<Parameter> fields = new List<Parameter>();

                        foreach (NodeSet.DataTypeField field in source.Field)
                        {
                            if (!sd.IsEnumeration && !sd.IsOptionSet)
                            {
                                // TBD - optional fields and allow subtypes.
                            }

                            Parameter output = new ();

                            output.Name = field.Name;
                            output.Description = Import(field.Description);
                            output.DataType = NodeIdToQName(ImportNodeId(field.DataType, true));
                            output.ValueRank = ImportValueRank(field.ValueRank);

                            if (!String.IsNullOrWhiteSpace(field.ArrayDimensions))
                            {
                                if (output.ValueRank == ValueRank.OneOrMoreDimensions || field.ArrayDimensions[0] > 0)
                                {
                                    output.ArrayDimensions = field.ArrayDimensions;
                                }
                            }

                            output.IsOptional = field.IsOptional;

                            fields.Add(output);
                        }

                        sd.Fields = fields.ToArray();
                    }
                }
                else
                {
                    DataTypeDesign ed = new ();
                    ed.IsOptionSet = source.IsOptionSet;

                    if (source.Field != null)
                    {
                        List<Parameter> fields = new List<Parameter>();

                        foreach (NodeSet.DataTypeField field in source.Field)
                        {
                            Parameter output = new ();

                            output.Name = field.Name;
                            output.Description = Import(field.Description);
                            output.Identifier = field.Value;

                            fields.Add(output);
                        }

                        ed.Fields = fields.ToArray();
                    }
                }
            }

            return null;
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
                ushort namespaceIndex = ImportNamespaceIndex(qname.NamespaceIndex, m_namespaceUris);
                return new XmlQualifiedName(builder.ToString(), m_namespaceUris.GetString(namespaceIndex));
            }

            return new XmlQualifiedName(builder.ToString(), m_namespaceUris.GetString(0));
        }

        /// <summary>
        /// Imports the array dimensions.
        /// </summary>
        private uint[] ImportArrayDimensions(string arrayDimensions)
        {
            if (String.IsNullOrEmpty(arrayDimensions))
            {
                return null;
            }

            string[] fields = arrayDimensions.Split(',');
            uint[] dimensions = new uint[fields.Length];

            for (int ii = 0; ii < fields.Length; ii++)
            {
                try
                {
                    dimensions[ii] = Convert.ToUInt32(fields[ii]);
                }
                catch
                {
                    dimensions[ii] = 0;
                }
            }

            return dimensions;
        }

        /// <summary>
        /// Imports localized text.
        /// </summary>
        private LocalizedText Import(params NodeSet.LocalizedText[] input)
        {
            if (input == null)
            {
                return null;
            }

            for (int ii = 0; ii < input.Length; ii++)
            {
                if (input[ii] != null)
                {
                    return new LocalizedText() { Value = input[ii].Value };
                }
            }

            return null;
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

        #region Private Fields
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
