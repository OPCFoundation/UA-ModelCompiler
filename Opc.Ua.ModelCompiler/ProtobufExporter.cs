using Opc.Ua;
using Opc.Ua.Export;
using System.Net.Http.Headers;
using DataTypeDefinition = Opc.Ua.Export.DataTypeDefinition;

namespace ModelCompiler
{

    enum ProtobufSchemaType
    {
        Simple = 0,
        Strucure = 1,
        Enumeration = 2
    }

    class ProtobufSchema
    {
        public string Type { get; set; }
        public List<ProtobufFieldSchema> Fields { get; set; }
        public bool IsEnumeration { get; set; }
    }

    class ProtobufFieldSchema
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsArray { get; set; }
        public long Value { get; set; }
    }

    internal class ProtobufExporter
    {
        private SystemContext m_context;
        private TypeTable m_typeTable;
        private NodeIdDictionary<DataTypeState> m_index;

        readonly Dictionary<string, ProtobufSchema> m_builtInTypes = new Dictionary<string, ProtobufSchema>()
        {
            ["Boolean"] = new ProtobufSchema()
            {
                Type = "bool"
            },
            ["SByte"] = new ProtobufSchema()
            {
                Type = "sint32"
            },
            ["Byte"] = new ProtobufSchema()
            {
                Type = "uint32"
            },
            ["Int16"] = new ProtobufSchema()
            {
                Type = "sint32"
            },
            ["UInt16"] = new ProtobufSchema()
            {
                Type = "uint32"
            },
            ["Int32"] = new ProtobufSchema()
            {
                Type = "sint32"
            },
            ["UInt32"] = new ProtobufSchema()
            {
                Type = "uint32"
            },
            ["Int64"] = new ProtobufSchema()
            {
                Type = "sint64"
            },
            ["UInt64"] = new ProtobufSchema()
            {
                Type = "uint64"
            },
            ["Float"] = new ProtobufSchema()
            {
                Type = "float"
            },
            ["Double"] = new ProtobufSchema()
            {
                Type = "double"
            },
            ["String"] = new ProtobufSchema()
            {
                Type = "string"
            },
            ["DateTime"] = new ProtobufSchema()
            {
                Type = "google.protobuf.Timestamp"
            },
            ["NodeId"] = new ProtobufSchema()
            {
                Type = "opcua.NodeId"
            },
            ["ExpandedNodeId"] = new ProtobufSchema()
            {
                Type = "opcua.ExpandedNodeId"
            },
            ["StatusCode"] = new ProtobufSchema()
            {
                Type = "uint32",
            },
            ["QualifiedName"] = new ProtobufSchema()
            {
                Type = "opcua.QualifiedName"
            },
            ["LocalizedText"] = new ProtobufSchema()
            {
                Type = "opcua.LocalizedText"
            },
            ["Guid"] = new ProtobufSchema()
            {
                Type = "bytes"
            },
            ["ByteString"] = new ProtobufSchema()
            {
                Type = "bytes"
            },
            ["XmlElement"] = new ProtobufSchema()
            {
                Type = "bytes"
            },
            ["ExtensionObject"] = new ProtobufSchema()
            {
                Type = "opcua.ExtensionObject"
            },
            ["Variant"] = new ProtobufSchema()
            {
                Type = "opcua.Variant"
            },
            ["DataValue"] = new ProtobufSchema()
            {
                Type = "opcua.DataValue"
            },
            ["DiagnosticInfo"] = new ProtobufSchema()
            {
                Type = "opcua.DiagnosticInfo"
            },
            ["Decimal"] = new ProtobufSchema()
            {
                Type = "opcua.Decimal"
            },
            ["Number"] = new ProtobufSchema()
            {
                Type = "opcua.Number"
            },
            ["Integer"] = new ProtobufSchema()
            {
                Type = "opcua.Integer"
            },
            ["UInteger"] = new ProtobufSchema()
            {
                Type = "opcua.UInteger"
            },
            ["Structure"] = new ProtobufSchema()
            {
                Type = "opcua.ExtensionObject"
            },
            ["Union"] = new ProtobufSchema()
            {
                Type = "opcua.ExtensionObject"
            },
            ["Enumeration"] = new ProtobufSchema()
            {
                Type = "int32"
            },
        };

        public ProtobufExporter()
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

        public void Load(Stream istrm)
        {
            var nodeset = UANodeSet.Read(istrm);
            var collection = new NodeStateCollection();
            nodeset.Import(m_context, collection);

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

        private NodeState FindBuiltInType(NodeId typeId)
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

        private ProtobufFieldSchema FindFieldSchema(
            StructureDefinition definition,
            StructureField field,
            DataTypeState fieldType)
        {

            bool isArray = field.ValueRank != ValueRanks.Scalar;

            var bit = FindBuiltInType(fieldType.NodeId);

            if (bit == null)
            {
                return new ProtobufFieldSchema()
                {
                    Name = field.Name,
                    Type = "bytes", 
                    IsArray = isArray 
                };
            }

            if (bit.NodeId == Opc.Ua.DataTypes.Structure || bit.NodeId == Opc.Ua.DataTypes.Union)
            {
                if (
                    definition.StructureType == StructureType.StructureWithSubtypedValues ||
                    definition.StructureType == StructureType.UnionWithSubtypedValues ||
                    field.IsOptional ||
                    fieldType.IsAbstract)
                {
                    return new ProtobufFieldSchema()
                    {
                        Name = field.Name,
                        Type = "opcua.ExtensionObject",
                        IsArray = isArray
                    };
                }

                return new ProtobufFieldSchema()
                {
                    Name = field.Name,
                    Type = fieldType.SymbolicName,
                    IsArray = isArray
                };
            }

            if (bit.NodeId == Opc.Ua.DataTypes.BaseDataType)
            {
                return new ProtobufFieldSchema()
                {
                    Name = field.Name,
                    Type = "opcua.Variant",
                    IsArray = isArray
                };
            }

            if (bit.NodeId == Opc.Ua.DataTypes.Enumeration)
            {
                return new ProtobufFieldSchema()
                {
                    Name = field.Name,
                    Type = "int32",
                    IsArray = isArray
                };
            }

            if (m_builtInTypes.TryGetValue(bit.SymbolicName, out var schema))
            {
                return new ProtobufFieldSchema()
                {
                    Name = field.Name,
                    Type = schema.Type,
                    IsArray = isArray
                };
            }

            return new ProtobufFieldSchema()
            {
                Name = field.Name,
                Type = bit.SymbolicName,
                IsArray = isArray
            };
        }

        public void Generate(Stream ostrm, string @namespace)
        {
            var schemas = new Dictionary<string, ProtobufSchema>();

            foreach (var type in m_builtInTypes)
            {
                schemas.Add(type.Key, type.Value);
            }

            foreach (var node in m_index.Values)
            {
                if (node is DataTypeState dt)
                {
                    if (m_builtInTypes.ContainsKey(dt.SymbolicName))
                    {
                        continue;
                    }

                    var definition = ExtensionObject.ToEncodeable(dt.DataTypeDefinition);

                    if (definition is StructureDefinition st)
                    {
                        ProtobufSchema schema = new ProtobufSchema();
                        schema.Fields = new();

                        foreach (var field in st.Fields)
                        {
                            if (field.DataType == null || !m_index.TryGetValue(field.DataType, out var fieldType))
                            {
                                fieldType = m_index[Opc.Ua.DataTypes.BaseDataType];
                            }

                            var fieldSchema = FindFieldSchema(st, field, fieldType);
                            schema.Fields.Add(fieldSchema);
                        }

                        schemas.Add(dt.SymbolicName, schema);
                    }

                    else if (definition is EnumDefinition et)
                    {
                        ProtobufSchema schema = new ProtobufSchema();

                        if (!et.IsOptionSet)
                        {
                            schema.Type = "uint64";
                        }
                        else
                        {
                            schema.Fields = new();
                            schema.Type = "int64";
                            schema.IsEnumeration = true;

                            foreach (var field in et.Fields)
                            {
                                schema.Fields.Add(new ProtobufFieldSchema() 
                                {
                                     Name = field.Name,
                                     Value = field.Value
                                });
                            }
                        }

                        schemas.Add(dt.SymbolicName, schema);
                    }

                    else
                    {
                        ProtobufSchema schema;

                        var bit = FindBuiltInType(dt.NodeId);

                        if (bit == null || bit.NodeId == Opc.Ua.DataTypes.BaseDataType)
                        {
                            schema = new ProtobufSchema()
                            {
                                Type = "opcua.Variant"
                            };
                        }
                        else
                        {
                            m_builtInTypes.TryGetValue(bit.SymbolicName, out schema);
                        }

                        schemas.Add(dt.SymbolicName, schema);
                    }
                }
            }

            string header = @"
syntax = ""proto3"";
package {1};

import ""google/protobuf/timestamp.proto"";
import ""BuiltInTypes.proto"";

option java_multiple_files = true;
option java_package = ""org.opcfoundation.{1}.protos"";
option java_outer_classname = ""{0}Protos"";

option csharp_namespace = ""Opc.Ua.Protos.{0}"";
option go_package = ""github.com/OPCFoundation/UA-Protobuf/{1}pb"";
";

            const string indent = "    ";

            using (StreamWriter writer = new StreamWriter(ostrm))
            {
                writer.WriteLine(String.Format(header, @namespace, @namespace.ToLower()));
                writer.WriteLine();

                foreach (var schema in schemas)
                {
                    if (schema.Value.IsEnumeration)
                    {
                        writer.Write("enum ");
                        writer.Write(schema.Key);
                        writer.WriteLine(" {");

                        var defaultValue = schema.Value.Fields.Where(x => x.Value == 0).FirstOrDefault();

                        if (defaultValue == null)
                        {
                            writer.Write(indent);
                            writer.WriteLine("Unknown = 0;");
                        }

                        foreach (var field in schema.Value.Fields)
                        {
                            writer.Write(indent);
                            writer.Write(schema.Key);
                            writer.Write("_");
                            writer.Write(field.Name);
                            writer.Write(" = ");
                            writer.Write(field.Value);
                            writer.WriteLine(";");
                        }

                        writer.WriteLine("}");
                        writer.WriteLine();
                    }
                    else if (schema.Value.Fields != null) 
                    {
                        writer.Write("message ");
                        writer.Write(schema.Key);
                        writer.WriteLine(" {");

                        int index = 1;

                        foreach (var field in schema.Value.Fields)
                        {
                            writer.Write(indent);

                            if (field.IsArray)
                            {
                                writer.Write("repeated ");
                            }

                            writer.Write(field.Type);
                            writer.Write(" ");
                            writer.Write(field.Name);
                            writer.Write(" = ");
                            writer.Write(index++);
                            writer.WriteLine(";");
                        }

                        writer.WriteLine("}");
                        writer.WriteLine();
                    }
                }
            }
        }
    }
}
