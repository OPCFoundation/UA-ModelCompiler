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
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using NodeSet = Opc.Ua.Export;

namespace ModelCompiler
{
    /// <summary>
    /// A set of nodes in an address space.
    /// </summary>
    public partial class NodeSetToModelDesign
    {
        private SystemContext m_context;
        private NodeSet.UANodeSet m_nodeset;
        private Dictionary<NodeId,NodeDesign> m_index;

        public NodeSetToModelDesign(SystemContext context, string filePath)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            m_context = context;
            m_index = new Dictionary<NodeId, NodeDesign>();

            using (var istrm = File.OpenRead(filePath))
            {
                m_nodeset = Opc.Ua.Export.UANodeSet.Read(istrm);
            }
        }

        public NodeSetToModelDesign(SystemContext context, Stream istrm)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (istrm == null) throw new ArgumentNullException(nameof(istrm));

            m_context = context;

            using (istrm)
            {
                m_nodeset = Opc.Ua.Export.UANodeSet.Read(istrm);
            }
        }

        public static bool IsNodeSet(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            var text = File.ReadAllText(filePath);

            if (text.Contains("<UANodeSet"))
            {
                return true;
            }

            return false;
        }

        public IDictionary<XmlQualifiedName, NodeDesign> Nodes { get; set; }

        #region Public Methods
        /// <summary>
        /// Imports a node from the set.
        /// </summary>
        public ModelDesign Import(IDictionary<XmlQualifiedName, NodeDesign> nodes)
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

                if (model.RequiredModel != null)
                {
                    // TBD
                }
            }

            List<NodeDesign> list = new ();

            for (int ii = 0; ii < m_nodeset.Items.Length; ii++)
            {
                var node = m_nodeset.Items[ii];
                NodeDesign importedNode = Import(m_context, node);
                list.Add(importedNode);
            }

            return dictionary;
        }
        #endregion

        #region Private Members
        /// <summary>
        /// Creates an decoder to restore Variant values.
        /// </summary>
        private XmlDecoder CreateDecoder(ISystemContext context, XmlElement source)
        {
            IServiceMessageContext messageContext = new ServiceMessageContext() {
                NamespaceUris = context.NamespaceUris,
                ServerUris = context.ServerUris,
                Factory = context.EncodeableFactory
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
                serverUris.Append(context.ServerUris.GetString(0));

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
                            Opc.Ua.NodeId referenceTypeId = ImportNodeId(node.References[ii].ReferenceType, context.NamespaceUris, true);
                            bool isInverse = !node.References[ii].IsForward;
                            Opc.Ua.ExpandedNodeId targetId = ImportExpandedNodeId(node.References[ii].Value, context.NamespaceUris, context.ServerUris);

                            if (referenceTypeId == ReferenceTypeIds.HasTypeDefinition && !isInverse)
                            {
                                typeDefinitionId = Opc.Ua.ExpandedNodeId.ToNodeId(targetId, context.NamespaceUris);
                                break;
                            }
                        }
                    }

                    VariableDesign value = new ();

                    value.DataType = NodeIdToQName(ImportNodeId(o.DataType, context.NamespaceUris, true));
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
                        XmlDecoder decoder = CreateDecoder(context, o.Value);
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
                    value.Declaration = NodeIdToQName(ImportNodeId(o.MethodDeclarationId, context.NamespaceUris, true));
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
                    value.IsAbstract = o.IsAbstract; value.DataType = NodeIdToQName(ImportNodeId(o.DataType, context.NamespaceUris, true));
                    value.ValueRank = ImportValueRank(o.ValueRank);
                    value.ValueRankSpecified = true;
                    value.ArrayDimensions = o.ArrayDimensions;
                    value.DefaultValue = o.Value;

                    if (o.Value != null)
                    {
                        XmlDecoder decoder = CreateDecoder(context, o.Value);
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

            importedNode.SymbolicId = NodeIdToQName(ImportNodeId(node.NodeId, context.NamespaceUris, false));
            importedNode.SymbolicName = ImportQualifiedName(node.BrowseName, context.NamespaceUris);
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
                    Opc.Ua.NodeId referenceTypeId = ImportNodeId(node.References[ii].ReferenceType, context.NamespaceUris, true);
                    bool isInverse = !node.References[ii].IsForward;
                    Opc.Ua.ExpandedNodeId targetId = ImportExpandedNodeId(node.References[ii].Value, context.NamespaceUris, context.ServerUris);

                    List<Reference> references = new List<Reference>();

                    if (instance != null)
                    {
                        if (referenceTypeId == ReferenceTypeIds.HasModellingRule && !isInverse)
                        {
                            instance.ModellingRule = ImportModellingRule(targetId, context.NamespaceUris);
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

        private ModellingRule ImportModellingRule(ExpandedNodeId targetId, NamespaceTable namespaceUris)
        {
            throw new NotImplementedException();
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
        private Opc.Ua.NodeId ImportNodeId(string source, NamespaceTable namespaceUris, bool lookupAlias)
        {
            if (String.IsNullOrEmpty(source))
            {
                return Opc.Ua.NodeId.Null;
            }

            // lookup alias.
            if (lookupAlias && m_nodeset.Aliases != null)
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

            // parse the string.
            Opc.Ua.NodeId nodeId = Opc.Ua.NodeId.Parse(source);

            if (nodeId.NamespaceIndex > 0)
            {
                ushort namespaceIndex = ImportNamespaceIndex(nodeId.NamespaceIndex, namespaceUris);
                nodeId = new Opc.Ua.NodeId(nodeId.Identifier, namespaceIndex);
            }

            return nodeId;
        }

        /// <summary>
        /// Imports a ExpandedNodeId
        /// </summary>
        private Opc.Ua.ExpandedNodeId ImportExpandedNodeId(string source, NamespaceTable namespaceUris, StringTable serverUris)
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

            uint serverIndex = ImportServerIndex(nodeId.ServerIndex, serverUris);
            ushort namespaceIndex = ImportNamespaceIndex(nodeId.NamespaceIndex, namespaceUris);

            if (serverIndex > 0)
            {
                string namespaceUri = nodeId.NamespaceUri;

                if (String.IsNullOrEmpty(nodeId.NamespaceUri))
                {
                    namespaceUri = namespaceUris.GetString(namespaceIndex);
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
                    sd.BaseType = NodeIdToQName(ImportNodeId(source.BaseType, namespaceUris, true));

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
                            output.DataType = NodeIdToQName(ImportNodeId(field.DataType, namespaceUris, true));
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
        private XmlQualifiedName ImportQualifiedName(string source, NamespaceTable namespaceUris)
        {
            if (String.IsNullOrEmpty(source))
            {
                return null;
            }

            var qname = Opc.Ua.QualifiedName.Parse(source);

            if (qname.NamespaceIndex > 0)
            {
                ushort namespaceIndex = ImportNamespaceIndex(qname.NamespaceIndex, namespaceUris);
                return new XmlQualifiedName(qname.Name, namespaceUris.GetString(namespaceIndex));
            }

            return new XmlQualifiedName(qname.Name, namespaceUris.GetString(0));
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
