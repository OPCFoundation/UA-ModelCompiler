using Newtonsoft.Json;
using Opc.Ua;
using System.Text;

namespace ModelCompiler
{
    internal class JsonSchemaExporter : BaseSchemaExporter
    {
        public JsonSchemaExporter(bool useReversibleEncoding)
        {
            m_builtInTypes = new Dictionary<string, BaseSchemaElement>()
            {
                ["Boolean"] = new BaseSchemaElement()
                {
                    ExportType = "boolean"
                },
                ["SByte"] = new BaseSchemaElement()
                {
                    ExportType = "integer",
                    ExportSubType = "int8"
                },
                ["Byte"] = new BaseSchemaElement()
                {
                    ExportType = "integer",
                    ExportSubType = "uint8"
                },
                ["Int16"] = new BaseSchemaElement()
                {
                    ExportType = "integer",
                    ExportSubType = "int16"
                },
                ["UInt16"] = new BaseSchemaElement()
                {
                    ExportType = "integer",
                    ExportSubType = "uint16"
                },
                ["Int32"] = new BaseSchemaElement()
                {
                    ExportType = "integer",
                    ExportSubType = "int32"
                },
                ["UInt32"] = new BaseSchemaElement()
                {
                    ExportType = "integer",
                    ExportSubType = "uint32"
                },
                ["Int64"] = new BaseSchemaElement()
                {
                    ExportType = "integer",
                    ExportSubType = "int32"
                },
                ["UInt64"] = new BaseSchemaElement()
                {
                    ExportType = "integer",
                    ExportSubType = "uint64"
                },
                ["Float"] = new BaseSchemaElement()
                {
                    ExportType = "number",
                    ExportSubType = "float"
                },
                ["Double"] = new BaseSchemaElement()
                {
                    ExportType = "number",
                    ExportSubType = "double"
                },
                ["String"] = new BaseSchemaElement()
                {
                    ExportType = "string"
                },
                ["DateTime"] = new BaseSchemaElement()
                {
                    ExportType = "string",
                    ExportSubType = "date-time"
                },
                ["Identifier"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Union,
                    Fields = new List<BaseSchemaField>()
                    {
                        new BaseSchemaField() { ExportType = "number" },
                        new BaseSchemaField() { ExportType = "string" }
                    }
                },
                ["Namespace"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Union,
                    Fields = new List<BaseSchemaField>()
                    {
                        new BaseSchemaField() { ExportType = "number" },
                        new BaseSchemaField() { ExportType = "string" }
                    }
                },
                ["NodeId"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Structure,
                    ExportType = "object",
                    Fields = new List<BaseSchemaField>()
                    {
                        new BaseSchemaField()
                        {
                            Name = "IdType",
                            ExportType = "IdType"
                        },
                        new BaseSchemaField()
                        {
                            Name = "Id",
                            ExportType = "Identifier"
                        },
                        new BaseSchemaField()
                        {
                            Name = "Namespace",
                            ExportType = "Namespace"
                        }
                    }
                },
                ["ExpandedNodeId"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Structure,
                    ExportType = "object",
                    Fields = new List<BaseSchemaField>()
                    {
                        new BaseSchemaField()
                        {
                            Name = "IdType",
                            ExportType = "IdType"
                        },
                        new BaseSchemaField()
                        {
                            Name = "Id",
                            ExportType = "Identifier"
                        },
                        new BaseSchemaField()
                        {
                            Name = "Namespace",
                            ExportType = "Namespace"
                        },
                        new BaseSchemaField()
                        {
                            Name = "ServerUri",
                            ExportType = "Namespace"
                        }
                    }
                },
                ["StatusCode"] = new BaseSchemaElement()
                {
                    ExportType = "integer",
                    ExportSubType = "uint32"
                },
                ["QualifiedName"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Structure,
                    ExportType = "object",
                    Fields = new List<BaseSchemaField>()
                    {
                        new BaseSchemaField()
                        {
                            Name = "Name",
                            ExportType = "string"
                        },
                        new BaseSchemaField()
                        {
                            Name = "Uri",
                            ExportType = "Namespace"
                        },
                    }
                },
                ["LocalizedText"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Structure,
                    ExportType = "object",
                    Fields = new List<BaseSchemaField>()
                    {
                        new BaseSchemaField()
                        {
                            Name = "Locale",
                            ExportType = "string",
                            ExportSubType = "rfc3066"
                        },
                        new BaseSchemaField()
                        {
                            Name = "Text",
                            ExportType = "string"
                        }
                    }
                },
                ["Locale"] = new BaseSchemaElement()
                {
                    ExportType = "string",
                    ExportSubType = "rfc3066"
                },
                ["Guid"] = new BaseSchemaElement()
                {
                    ExportType = "string",
                    ExportSubType = "uuid"
                },
                ["ByteString"] = new BaseSchemaElement()
                {
                    ExportType = "string",
                    ExportSubType = "byte"
                },
                ["XmlElement"] = new BaseSchemaElement()
                {
                    ExportType = "string",
                    ExportSubType = "xml"
                },
                ["ExtensionObjectBody"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Union,
                    Fields = new List<BaseSchemaField>()
                    {
                        new BaseSchemaField() { ExportType = "string" },
                        new BaseSchemaField() { ExportType = "object" }
                    }
                },
                ["ExtensionObject"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Structure,
                    ExportType = "object",
                    Fields = new List<BaseSchemaField>()
                    {
                        new BaseSchemaField()
                        {
                            Name = "TypeId",
                            ExportType = "string",
                            ExportSubType = "NodeId"
                        },
                        new BaseSchemaField()
                        {
                            Name = "Encoding",
                            ExportType = "number",
                            ExportSubType = "uint8"
                        },
                        new BaseSchemaField()
                        {
                            Name = "Body",
                            ExportType = "ExtensionObjectBody"
                        },
                    },
                },
                ["BaseDataTypeBody"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Union,
                    Fields = new List<BaseSchemaField>()
                    {
                        new BaseSchemaField() { ExportType = "boolean" },
                        new BaseSchemaField() { ExportType = "number" },
                        new BaseSchemaField() { ExportType = "string" },
                        new BaseSchemaField() { ExportType = "LocalizedText" },
                        new BaseSchemaField() { ExportType = "ExtensionObject" },
                        new BaseSchemaField() { ExportType = "boolean", IsArray = true },
                        new BaseSchemaField() { ExportType = "number", IsArray = true },
                        new BaseSchemaField() { ExportType = "string", IsArray = true },
                        new BaseSchemaField() { ExportType = "LocalizedText", IsArray = true },
                        new BaseSchemaField() { ExportType = "ExtensionObject", IsArray = true },
                        new BaseSchemaField() { ExportType = "BaseDataType", IsArray = true },
                    }
                },
                ["BaseDataType"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Structure,
                    ExportType = "object",
                    Fields = new List<BaseSchemaField>()
                    {
                        new BaseSchemaField()
                        {
                            Name = "Type",
                            ExportType = "integer",
                            ExportSubType = "uint8"
                        },
                        new BaseSchemaField()
                        {
                            Name = "Body",
                            ExportType = "BaseDataTypeBody"
                        },
                        new BaseSchemaField()
                        {
                            Name = "Dimensions",
                            ExportType = "integer",
                            ExportSubType = "uint32",
                            IsArray = true
                        }
                    }
                },
                ["DataValue"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Structure,
                    ExportType = "object",
                    Fields = new List<BaseSchemaField>()
                    {
                        new BaseSchemaField()
                        {
                            Name = "Value",
                            ExportType = "BaseDataType"
                        },
                        new BaseSchemaField()
                        {
                            Name = "StatusCode",
                            ExportType = "StatusCode"
                        },
                        new BaseSchemaField()
                        {
                            Name = "SourceTimestamp",
                            ExportType = "string",
                            ExportSubType = "date-time"
                        },
                        new BaseSchemaField()
                        {
                            Name = "SourcePicoSeconds",
                            ExportType = "integer",
                            ExportSubType = "uint16"
                        },
                        new BaseSchemaField()
                        {
                            Name = "ServerTimestamp",
                            ExportType = "string",
                            ExportSubType = "date-time"
                        },
                        new BaseSchemaField()
                        {
                            Name = "ServerPicoSeconds",
                            ExportType = "integer",
                            ExportSubType = "uint16"
                        }
                    }
                },
                ["DiagnosticInfo"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Structure,
                    ExportType = "object",
                    Fields = new List<BaseSchemaField>()
                    {
                        new BaseSchemaField()
                        {
                            Name = "SymbolicId",
                            ExportType = "integer",
                            ExportSubType = "int32"
                        },
                        new BaseSchemaField()
                        {
                            Name = "NamespaceUri",
                            ExportType = "integer",
                            ExportSubType = "int32"
                        },
                        new BaseSchemaField()
                        {
                            Name = "Locale",
                            ExportType = "integer",
                            ExportSubType = "int32"
                        },
                        new BaseSchemaField()
                        {
                            Name = "LocalizedText",
                            ExportType = "integer",
                            ExportSubType = "int32"
                        },
                        new BaseSchemaField()
                        {
                            Name = "AdditionalInfo",
                            ExportType = "string"
                        },
                        new BaseSchemaField()
                        {
                            Name = "InnerStatusCode",
                            ExportType = "integer",
                            ExportSubType = "StatusCode"
                        },
                        new BaseSchemaField()
                        {
                            Name = "InnerDiagnosticInfo",
                            ExportType = "DiagnosticInfo"
                        }
                    }
                },
                ["Decimal"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Structure,
                    ExportType = "object",
                    Fields = new List<BaseSchemaField>()
                    {
                        new BaseSchemaField()
                        {
                            Name = "Scale",
                            ExportType = "integer",
                            ExportSubType = "int16"
                        },
                        new BaseSchemaField()
                        {
                            Name = "Value",
                            ExportType = "string",
                            ExportSubType = "uinteger"
                        }
                    }
                },
                ["Number"] = new BaseSchemaElement()
                {
                    ExportType = "number"
                },
                ["Integer"] = new BaseSchemaElement()
                {
                    ExportType = "integer"
                },
                ["UInteger"] = new BaseSchemaElement()
                {
                    ExportType = "integer"
                },
                ["Structure"] = new BaseSchemaElement()
                {
                    Name = "Structure",
                    ExportType = "ExtensionObject"
                },
                ["Union"] = new BaseSchemaElement()
                {
                    Name = "Union",
                    ExportType = "ExtensionObject"
                },
                ["Enumeration"] = new BaseSchemaElement()
                {
                    ExportType = "integer",
                    ExportSubType = "int32"
                },
            };

            if (!useReversibleEncoding)
            {
                m_builtInTypes["StatusCode"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Structure,
                    ExportType = "object",
                    Fields = new List<BaseSchemaField>()
                    {
                        new BaseSchemaField()
                        {
                            Name = "Code",
                            ExportType = "integer",
                            ExportSubType = "uint32"
                        },
                        new BaseSchemaField()
                        {
                            Name = "Symbol",
                            ExportType = "string"
                        }
                    }
                };

                m_builtInTypes["LocalizedText"] = new BaseSchemaElement()
                {
                    ExportType = "string"
                };

                m_builtInTypes["ExtensionObject"] = new BaseSchemaElement()
                {
                    ExportType = "object"
                };
            }
        }

        private void WriteField(JsonWriter writer, BaseSchemaField field, Dictionary<string, BaseSchemaElement> types)
        {
            if (field.IsArray)
            {
                writer.WritePropertyName("type");
                writer.WriteValue("array");
                writer.WritePropertyName("items");
                writer.WriteStartObject();
            }

            if (field.ExportType != null && types.TryGetValue(field.ExportType, out var fieldType))
            {
                writer.WritePropertyName("$ref");
                writer.WriteValue(GetRef(fieldType.Namespace, fieldType.Name ?? field.ExportType));
            }
            else
            {
                writer.WritePropertyName("type");
                writer.WriteValue(field.ExportType);
            }

            if (field.ExportSubType != null)
            {
                writer.WritePropertyName("format");
                writer.WriteValue(field.ExportSubType);
            }

            if (field.IsArray)
            {
                writer.WriteEndObject();
            }
        }

        public void Generate(Stream ostrm)
        {
            var types = GetTypesToExport(m_modelUri);

            using (JsonWriter writer = new JsonTextWriter(new StreamWriter(ostrm)))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("$id");
                writer.WriteValue(m_modelUri);
                writer.WritePropertyName("schema");
                writer.WriteValue("https://json-schema.org/draft/2020-12/schema");
                writer.WritePropertyName("type");
                writer.WriteValue("object");

                bool first = false;

                foreach (var type in types)
                {
                    if ((type.Value.Namespace != null && m_modelUri != type.Value.Namespace) || (type.Value.Namespace == null && m_modelUri != Namespaces.OpcUa))
                    {
                        continue;
                    }

                    var name = (type.Value.Name != null) ? type.Value.Name : type.Key;

                    if (!first)
                    {
                        writer.WritePropertyName("$ref");
                        writer.WriteValue((m_modelUri == Opc.Ua.Namespaces.OpcUa) ? "/basedatatype" : "/" + name.ToLowerInvariant());
                        writer.WritePropertyName("$defs");
                        writer.WriteStartObject();
                        first = true;
                    }

                    writer.WritePropertyName(name);
                    writer.WriteStartObject();
                    writer.WritePropertyName("$id");
                    writer.WriteValue("/" + name.ToLowerInvariant());

                    if (type.Value.Type == SchemaElementType.Simple)
                    {
                        var dataTypeName = (type.Value.DataTypeId != null && type.Value.DataTypeId.NamespaceIndex != 0)
                            ? $"{type.Value.DataTypeId.NamespaceIndex}:{type.Value.ExportType}"
                            : type.Value.ExportType;

                        if (types.TryGetValue(dataTypeName, out var dataType) && dataType.Name != null)
                        {
                            writer.WritePropertyName("$ref");
                            writer.WriteValue(GetRef(type.Value.Namespace, dataType.Name));
                        }
                        else
                        {
                            writer.WritePropertyName("type");
                            writer.WriteValue(type.Value.ExportType);
                        }

                        if (type.Value.ExportSubType != null)
                        {
                            writer.WritePropertyName("format");
                            writer.WriteValue(type.Value.ExportSubType);
                        }
                    }
                    else if (type.Value.Type == SchemaElementType.Enumeration)
                    {
                        writer.WritePropertyName("anyOf");
                        writer.WriteStartArray();

                        foreach (var field in type.Value.Fields)
                        {
                            writer.WriteStartObject();
                            writer.WritePropertyName("const");
                            writer.WriteValue(field.Value);
                            writer.WritePropertyName("title");
                            writer.WriteValue(field.Name);
                            writer.WriteEndObject();
                        }

                        writer.WriteEndArray();
                    }
                    else if (type.Value.Type == SchemaElementType.OptionSet)
                    {
                        writer.WritePropertyName("type");
                        writer.WriteValue("integer");

                        if (type.Value.DataTypeId != null)
                        {
                            var baseTypeNode = FindBuiltInType(type.Value.DataTypeId);

                            if (baseTypeNode != null)
                            {
                                if (types.TryGetValue(baseTypeNode.SymbolicName, out var baseType))
                                {
                                    if (baseType.ExportSubType != null)
                                    {
                                        writer.WritePropertyName("format");
                                        writer.WriteValue(baseType.ExportSubType);
                                    }
                                }
                            }
                        }

                        StringBuilder builder = new();

                        foreach (var field in type.Value.Fields)
                        {
                            if (builder.Length > 0)
                            {
                                builder.Append(";");
                            }

                            builder.Append(field.Name);
                            builder.Append("=");
                            builder.Append($"0x{field.Value:X2}");
                        }

                        writer.WritePropertyName("description");
                        writer.WriteValue(builder.ToString());
                    }
                    else if (type.Value.Type == SchemaElementType.Union)
                    {
                        writer.WritePropertyName("oneOf");
                        writer.WriteStartArray();

                        foreach (var field in type.Value.Fields)
                        {
                            if (!String.IsNullOrEmpty(field.Name))
                            {
                                writer.WritePropertyName("type");
                                writer.WriteValue("object");
                                writer.WritePropertyName("properties");
                                writer.WriteStartObject();
                                writer.WritePropertyName(field.Name);
                            }

                            writer.WriteStartObject();
                            WriteField(writer, field, types);
                            writer.WriteEndObject();
                        }

                        writer.WriteEndArray();
                    }
                    else if (type.Value.Type == SchemaElementType.Structure)
                    {
                        writer.WritePropertyName("type");
                        writer.WriteValue("object");

                        var dataType = FindDataType(type.Value.DataTypeId);

                        if (dataType?.SuperTypeId != null)
                        {
                            var st = FindDataType(dataType.SuperTypeId);

                            var key = (st.NodeId.NamespaceIndex == 0) ? st.SymbolicName : $"{st.NodeId.NamespaceIndex}:{st.SymbolicName}";

                            if (st.NodeId != DataTypeIds.Structure && types.TryGetValue(key, out var baseType))
                            {
                                writer.WritePropertyName("allOf");
                                writer.WriteStartArray();
                                writer.WriteStartObject();
                                writer.WritePropertyName("$ref");
                                writer.WriteValue(GetRef(baseType.Namespace, baseType.Name));
                                writer.WriteEndObject();
                                writer.WriteEndArray();
                            }
                        }

                        writer.WritePropertyName("properties");
                        writer.WriteStartObject();

                        foreach (var field in type.Value.Fields)
                        {
                            writer.WritePropertyName(field.Name);
                            writer.WriteStartObject();
                            WriteField(writer, field, types);
                            writer.WriteEndObject();
                        }

                        writer.WriteEndObject();
                    }

                    writer.WriteEndObject();
                }

                if (first)
                {
                    writer.WriteEndObject();
                }
                 
                writer.WriteEndObject();
            }
        }
    }
}
