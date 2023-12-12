using Opc.Ua;
using Opc.Ua.Export;
using System.Text;

namespace ModelCompiler
{
    internal class BaseSchemaExporter
    {
        protected SystemContext m_context;
        protected TypeTable m_typeTable;
        protected NodeIdDictionary<DataTypeState> m_index;
        protected Dictionary<string, BaseSchemaElement> m_builtInTypes;
        protected string m_modelUri;

        public BaseSchemaExporter()
        {
            m_context = new SystemContext();
            m_context.NamespaceUris = new NamespaceTable();
            m_context.ServerUris = new StringTable();

            m_typeTable = new TypeTable(m_context.NamespaceUris);
            m_context.TypeTable = m_typeTable;

            m_index = new NodeIdDictionary<DataTypeState>();
        }

        protected void AddTypesToTypeTree(NodeStateCollection nodes, BaseTypeState type)
        {
            if (!NodeId.IsNull(type.SuperTypeId))
            {
                if (!m_typeTable.IsKnown(type.SuperTypeId))
                {
                    if (m_index.TryGetValue(type.SuperTypeId, out var node))
                    {
                        if (node is BaseTypeState superType)
                        {
                            AddTypesToTypeTree(nodes, superType);
                        }
                    }
                }
            }

            if (type.NodeClass != NodeClass.ReferenceType)
            {
                m_typeTable.AddSubtype(type.NodeId, type.SuperTypeId);
            }
            else
            {
                m_typeTable.AddReferenceSubtype(type.NodeId, type.SuperTypeId, type.BrowseName);
            }
        }

        public void Load(Dictionary<string,string> nodesets, string modelUri)
        {
            if (nodesets == null) throw new ArgumentNullException(nameof(nodesets));
            if (modelUri == null) throw new ArgumentNullException(nameof(modelUri));

            if (!nodesets.TryGetValue(modelUri, out var filePath))
            {
                throw new ArgumentException(nameof(modelUri), "File not found.");
            }

            using (var istrm = File.OpenRead(filePath))
            {
                IndexDataTypes(istrm);
            }

            bool found;
            HashSet<string> loadedNodeSets = new();
            loadedNodeSets.Add(modelUri);

            do
            {
                found = false;
                var uris = m_context.NamespaceUris.ToArray();

                foreach (var uri in uris)
                {
                    if (!loadedNodeSets.Contains(uri) && nodesets.TryGetValue(uri, out var dependencyFilePath))
                    {
                        using (var istrm = File.OpenRead(dependencyFilePath))
                        {
                            IndexDataTypes(istrm);
                        }

                        loadedNodeSets.Add(uri);
                        found = true;
                        break;
                    }
                }
            }
            while (found);

            m_modelUri = modelUri;

            foreach (var type in m_index.Values)
            {
                Stack<DataTypeState> dataTypes = new Stack<DataTypeState>();
                dataTypes.Push(type);

                var superTypeId = type.SuperTypeId;

                while (superTypeId != null)
                {
                    if (m_index.TryGetValue(superTypeId, out var superType))
                    {
                        dataTypes.Push(superType);
                    }

                    superTypeId = superType.SuperTypeId;
                }

                while (dataTypes.Count > 0)
                {
                    var dataType = dataTypes.Pop();

                    m_typeTable.AddSubtype(dataType.NodeId, dataType.SuperTypeId);

                    if (dataType.SymbolicName == null)
                    {
                        dataType.SymbolicName = dataType.BrowseName?.Name;
                    }
                }
            }
        }

        public void Load(string filePath)
        {
            using (var istrm = File.OpenRead(filePath))
            {
                Load(istrm);
            }
        }

        public void IndexDataTypes(Stream istrm)
        {
            var nodeset = UANodeSet.Read(istrm);
            var collection = new NodeStateCollection();
            nodeset.Import(m_context, collection);

            m_modelUri = nodeset.Models?.FirstOrDefault()?.ModelUri;

            foreach (var node in collection)
            {
                if (node is DataTypeState dt)
                {
                    m_index[node.NodeId] = dt;
                }
            }
        }

        public void Load(Stream istrm)
        {
            var nodeset = UANodeSet.Read(istrm);
            var collection = new NodeStateCollection();
            nodeset.Import(m_context, collection);

            m_modelUri = nodeset.Models?.FirstOrDefault()?.ModelUri;

            foreach (var node in collection)
            {
                if (node is DataTypeState dt)
                {
                    m_index[node.NodeId] = dt;
                }
            }

            foreach (var node in collection)
            {
                if (node is BaseTypeState type)
                {
                    if (type.NodeClass != NodeClass.ReferenceType)
                    {
                        m_typeTable.AddSubtype(type.NodeId, type.SuperTypeId);
                    }
                    else
                    {
                        m_typeTable.AddReferenceSubtype(type.NodeId, type.SuperTypeId, type.BrowseName);
                    }

                    if (type.SymbolicName == null)
                    {
                        type.SymbolicName = type.BrowseName?.Name;
                    }
                }
            }
        }

        protected DataTypeState FindDataType(NodeId typeId)
        {
            if (m_index.TryGetValue(typeId, out var type))
            {
                if (type.NodeClass == NodeClass.DataType)
                {
                    return type as DataTypeState;
                }
            }

            return null;
        }

        protected NodeState FindBuiltInType(NodeId typeId)
        {
            if (m_index.TryGetValue(typeId, out var type))
            {
                if (type.NodeClass != NodeClass.DataType)
                {
                    return null;
                }

                if (m_builtInTypes.ContainsKey(type.SymbolicName))
                {
                    return type;
                }

                var dt = type as DataTypeState;

                if (dt != null && dt.SuperTypeId != null)
                {
                    return FindBuiltInType(dt.SuperTypeId);
                }
            }

            return null;
        }

        protected virtual string GetDefaultExportType()
        {
            return "BaseDataType";
        }

        protected virtual string GetStructureType()
        {
            return "ExtensionObject";
        }

        protected virtual string GetEnumerationExportType()
        {
            return "integer";
        }

        private BaseSchemaField FindFieldSchema(
            StructureDefinition definition,
            StructureField field,
            DataTypeState fieldType)
        {
            var schema = new BaseSchemaField()
            {
                Name = field.Name,
                DataTypeId = fieldType.NodeId,
                IsArray = field.ValueRank != ValueRanks.Scalar
            };

            var bit = FindBuiltInType(fieldType.NodeId);

            if (bit == null)
            {
                schema.ExportType = GetDefaultExportType();
                return schema;
            }

            if (bit.NodeId == Opc.Ua.DataTypes.Structure || bit.NodeId == Opc.Ua.DataTypes.Union)
            {
                if (
                    definition.StructureType == StructureType.StructureWithSubtypedValues ||
                    definition.StructureType == StructureType.UnionWithSubtypedValues ||
                    field.IsOptional ||
                    fieldType.IsAbstract)
                {
                    schema.ExportType = GetStructureType();
                    return schema;
                }

                schema.ExportType = (fieldType.NodeId.NamespaceIndex != 0) ? $"{fieldType.NodeId.NamespaceIndex}:{fieldType.SymbolicName}" : fieldType.SymbolicName;
                return schema;
            }

            if (bit.NodeId == Opc.Ua.DataTypes.BaseDataType)
            {
                schema.ExportType = GetDefaultExportType();
                return schema;
            }

            if (bit.NodeId == Opc.Ua.DataTypes.Enumeration)
            {
                schema.ExportType = GetEnumerationExportType();
                return schema;
            }

            if (m_builtInTypes.TryGetValue(bit.SymbolicName, out var type))
            {
                if (type.ExportType != "object")
                {
                    schema.ExportType = type.ExportType;
                    schema.ExportSubType = type.ExportSubType;
                }
                else
                {
                    schema.ExportType = bit.SymbolicName;
                }

                return schema;
            }

            schema.ExportType = (bit.NodeId.NamespaceIndex != 0) ? $"{bit.NodeId.NamespaceIndex}:{bit.SymbolicName}" : bit.SymbolicName;
            return schema;
        }

        protected virtual Dictionary<string, BaseSchemaElement> GetTypesToExport(string @namespace)
        {
            var exportedTypes = new Dictionary<string,BaseSchemaElement>();

            foreach (var type in m_builtInTypes)
            {
                exportedTypes.Add(type.Key, type.Value);
            }

            foreach (var node in m_index.Values)
            {
                if (node is DataTypeState dt)
                {
                    var key = (dt.NodeId.NamespaceIndex == 0) ? dt.SymbolicName : $"{dt.NodeId.NamespaceIndex}:{dt.SymbolicName}";

                    if (m_builtInTypes.ContainsKey(dt.SymbolicName))
                    {
                        continue;
                    }

                    var definition = ExtensionObject.ToEncodeable(dt.DataTypeDefinition);

                    var bit = FindBuiltInType(dt.NodeId);

                    if (bit != null && m_builtInTypes.TryGetValue(bit.SymbolicName, out var type))
                    {
                        if (definition == null && bit.NodeId == DataTypeIds.Structure)
                        {
                            var st2 = new StructureDefinition();
                            st2.StructureType = StructureType.Structure;
                            st2.Fields = new StructureFieldCollection();
                            definition = st2;
                        }
                    }

                    if (definition is StructureDefinition st)
                    {
                        BaseSchemaElement element = new BaseSchemaElement();
                        element.Name = node.BrowseName.Name;
                        element.Namespace = m_context.NamespaceUris.GetString(node.NodeId.NamespaceIndex);
                        element.ExportType = (node.NodeId.NamespaceIndex != 0) ? $"{node.NodeId.NamespaceIndex}:{element.Name}" : element.Name;
                        element.DataTypeId = node.NodeId;
                        element.Type = SchemaElementType.Structure;
                        element.Fields = new();

                        if (st.StructureType == StructureType.UnionWithSubtypedValues ||
                            st.StructureType == StructureType.UnionWithSubtypedValues)
                        {
                            element.Type = SchemaElementType.Union;
                        }

                        foreach (var field in st.Fields)
                        {
                            if (field.DataType == null || !m_index.TryGetValue(field.DataType, out var fieldType))
                            {
                                fieldType = m_index[Opc.Ua.DataTypes.BaseDataType];
                            }

                            var fieldSchema = FindFieldSchema(st, field, fieldType);
                            element.Fields.Add(fieldSchema);
                        }

                        exportedTypes.Add(key, element);
                    }

                    else if (definition is EnumDefinition et)
                    {
                        BaseSchemaElement element = new BaseSchemaElement();
                        element.Name = node.BrowseName.Name;
                        element.Namespace = m_context.NamespaceUris.GetString(node.NodeId.NamespaceIndex);
                        element.ExportType = (node.NodeId.NamespaceIndex != 0) ? $"{node.NodeId.NamespaceIndex}:{element.Name}" : element.Name;
                        element.DataTypeId = node.NodeId;
                        element.Type = (et.IsOptionSet) ? SchemaElementType.OptionSet : SchemaElementType.Enumeration;
                        element.Fields = new();

                        foreach (var field in et.Fields)
                        {
                            var fs = new BaseSchemaField()
                            {
                                Name = field.Name,
                                Value = field.Value
                            };

                            element.Fields.Add(fs);
                        }

                        exportedTypes.Add(key, element);
                    }
                    else
                    {
                        BaseSchemaElement element = new BaseSchemaElement();
                        element.Name = node.BrowseName.Name;
                        element.Namespace = m_context.NamespaceUris.GetString(node.NodeId.NamespaceIndex);
                        element.ExportType = (node.NodeId.NamespaceIndex != 0) ? $"{node.NodeId.NamespaceIndex}:{element.Name}" : element.Name;
                        element.DataTypeId = node.NodeId;
                        element.Type = SchemaElementType.Simple;

                        exportedTypes.Add(key, element);
                    }
                }
            }

            return exportedTypes;
        }

        protected string GetRef(string @namespace, string name)
        {
            if (name == null)
            {
                return String.Empty;
            }

            StringBuilder builder = new();

            if ((@namespace == null && @namespace != Namespaces.OpcUa && m_modelUri != Namespaces.OpcUa) ||
                (@namespace != null && @namespace != m_modelUri))
            {
                builder.Append(@namespace ?? Namespaces.OpcUa);
            }

            if (builder.Length == 0 || builder[builder.Length - 1] != '/')
            {
                builder.Append('/');
            }

            builder.Append(name.ToLowerInvariant());

            return builder.ToString();
        }
    }

    internal class BaseSchemaElement
    {
        public string Name { get; set; }
        public string Namespace { get; set; }
        public SchemaElementType Type { get; set; }
        public string ExportType { get; set; }
        public string ExportSubType { get; set; }
        public NodeId DataTypeId { get; set; }
        public List<BaseSchemaField> Fields { get; set; }
    }

    internal class BaseSchemaField
    {
        public string Name { get; set; }
        public string ExportType { get; set; }
        public string ExportSubType { get; set; }
        public NodeId DataTypeId { get; set; }
        public bool IsArray { get; set; }
        public long Value { get; set; }
    }

    enum SchemaElementType
    {
        Simple = 0,
        Structure = 1,
        Enumeration = 2,
        Union = 3,
        OptionSet = 4
    }
}
