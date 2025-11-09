using Newtonsoft.Json;
using Opc.Ua;
using System.Diagnostics;

namespace ModelCompiler
{
    internal class JsonSchemaExporter : BaseSchemaExporter
    {
        public JsonSchemaExporter(IFileSystem fileSystem, bool useCompactEncoding, ITelemetryContext telemetry) : base(fileSystem, telemetry)
        {
            m_useCompactEncoding = useCompactEncoding;

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
                    ExportType = "string",
                    ExportSubType = "int32"
                },
                ["UInt64"] = new BaseSchemaElement()
                {
                    ExportType = "string",
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
                    ExportType = @"[string,null]"
                },
                ["DateTime"] = new BaseSchemaElement()
                {
                    ExportType = "string",
                    ExportSubType = "date-time"
                },
                ["NodeId"] = new BaseSchemaElement()
                {
                    ExportType = "string",
                    ExportSubType = "UaNodeId"
                },
                ["ExpandedNodeId"] = new BaseSchemaElement()
                {
                    ExportType = "string",
                    ExportSubType = "UaNodeId"
                },
                ["StatusCode"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Structure,
                    ExportType = "object",
                    Sealed = true,
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
                },
                ["QualifiedName"] = new BaseSchemaElement()
                {
                    ExportType = "string",
                    ExportSubType = "UaQualifiedName"
                },
                ["LocalizedText"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Structure,
                    ExportType = "object",
                    Sealed = true,
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
                ["Guid"] = new BaseSchemaElement()
                {
                    ExportType = "string",
                    ExportSubType = "uuid"
                },
                ["ByteString"] = new BaseSchemaElement()
                {
                    ExportType = @"[string,null]",
                    ExportSubType = "byte"
                },
                ["XmlElement"] = new BaseSchemaElement()
                {
                    ExportType = @"[string,null]",
                    ExportSubType = "xml"
                },
                ["ExtensionObject"] = new BaseSchemaElement()
                {
                    Name = "ExtensionObject",
                    Type = SchemaElementType.Structure,
                    ExportType = "object",
                    Sealed = false,
                    Fields = new List<BaseSchemaField>()
                    {
                        new BaseSchemaField()
                        {
                            Name = "UaTypeId",
                            ExportType = "string",
                            ExportSubType = "UaNodeId"
                        },
                        new BaseSchemaField()
                        {
                            Name = "UaEncoding",
                            ExportType = "number",
                            ExportSubType = "uint8"
                        },
                        new BaseSchemaField()
                        {
                            Name = "UaBody",
                            ExportType = "string",
                            ExportSubType = "byte"
                        }
                    },
                },
                ["Matrix"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Structure,
                    ExportType = "object",
                    Sealed = true,
                    Fields = new List<BaseSchemaField>()
                    {
                        new BaseSchemaField()
                        {
                            Name = "Array",
                            ExportType = "array"
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
                ["BaseDataType"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Structure,
                    ExportType = "object",
                    Sealed = true,
                    Fields = new List<BaseSchemaField>()
                    {
                        new BaseSchemaField()
                        {
                            Name = "UaType",
                            ExportType = "integer",
                            ExportSubType = "uint8"
                        },
                        new BaseSchemaField()
                        {
                            Name = "Value",
                            ExportType = @"[object,string,boolean,array,number,null]"
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
                    Sealed = true,
                    Fields = new List<BaseSchemaField>()
                    {
                        new BaseSchemaField()
                        {
                            Name = "UaType",
                            ExportType = "integer",
                            ExportSubType = "uint8"
                        },
                        new BaseSchemaField()
                        {
                            Name = "Value",
                            ExportType = @"[object,string,boolean,array,number,null]"
                        },
                        new BaseSchemaField()
                        {
                            Name = "Dimensions",
                            ExportType = "integer",
                            ExportSubType = "uint32",
                            IsArray = true
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
                            Name = "SourcePicoseconds",
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
                            Name = "ServerPicoseconds",
                            ExportType = "integer",
                            ExportSubType = "uint16"
                        }
                    }
                },
                ["DiagnosticInfo"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Structure,
                    ExportType = "object",
                    Sealed = true,
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
                    Sealed = true,
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
        }

        private void WriteExportType(JsonWriter writer, string exportType)
        {
            if (exportType.StartsWith('['))
            {
                writer.WriteStartArray();

                foreach (var type in exportType.Substring(1, exportType.Length - 2).Split(','))
                {
                    writer.WriteValue(type);
                }

                writer.WriteEndArray();
            }
            else
            {
                writer.WriteValue(exportType);
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
                WriteExportType(writer, field.ExportType);
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

        public void Generate(string fileName, Stream ostrm)
        {
            if (!m_useCompactEncoding)
            {
                m_builtInTypes["StatusCode"] = new BaseSchemaElement()
                {
                    Type = SchemaElementType.Structure,
                    ExportType = "object",
                    Sealed = true,
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
            }

            var types = GetTypesToExport(m_modelUri);

            using (JsonWriter writer = new JsonTextWriter(new StreamWriter(ostrm)))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("$schema");
                writer.WriteValue("https://json-schema.org/draft/2020-12/schema");
                //writer.WritePropertyName("$id");
                //writer.WriteValue($"{m_modelUri}{((m_modelUri.EndsWith('/')) ? "" : "/")}{fileName}");
                //writer.WritePropertyName("type");
                //writer.WriteValue("object");

                bool first = false;

                foreach (var type in types.OrderBy(x => x.Value.DataTypeId))
                {
                    if ((type.Value.Namespace != null && m_modelUri != type.Value.Namespace) || (type.Value.Namespace == null && m_modelUri != Namespaces.OpcUa))
                    {
                        continue;
                    }

                    var name = (type.Value.Name != null) ? type.Value.Name : type.Key;

                    if (!first)
                    {
                        //writer.WritePropertyName("$ref");
                        //writer.WriteValue(GetRef(m_modelUri, (m_modelUri == Opc.Ua.Namespaces.OpcUa) ? BrowseNames.BaseDataType : name));
                        writer.WritePropertyName("$defs");
                        writer.WriteStartObject();
                        first = true;
                    }

                    writer.WritePropertyName(name);
                    writer.WriteStartObject();
                    //writer.WritePropertyName("$id");
                    //writer.WriteValue("/" + name.ToLowerInvariant());

                    if (type.Value.Type == SchemaElementType.Simple)
                    {
                        if (type.Value.DataTypeId == null)
                        {
                            if (type.Value.ExportType != null && types.TryGetValue(type.Value.ExportType, out var refType))
                            {
                                writer.WritePropertyName("$ref");
                                writer.WriteValue(GetRef(refType.Namespace, refType.Name ?? refType.ExportType));
                            }
                            else
                            {
                                writer.WritePropertyName("type");
                                WriteExportType(writer, type.Value.ExportType);

                                if (type.Value.ExportSubType != null)
                                {
                                    writer.WritePropertyName("format");
                                    writer.WriteValue(type.Value.ExportSubType);
                                }
                            }
                        }
                        else
                        {
                            var dataTypeId = type.Value.DataTypeId;
                            var builtInType = TypeInfo.GetBuiltInType(dataTypeId);

                            while (builtInType == BuiltInType.Null)
                            {
                                var dataType = FindDataType(type.Value.DataTypeId);

                                if (dataType?.SuperTypeId == null)
                                {
                                    break;
                                }

                                dataTypeId = dataType?.SuperTypeId;
                                builtInType = TypeInfo.GetBuiltInType(dataTypeId);
                            }

                            if (builtInType != BuiltInType.Null)
                            {
                                var builtInTypeName = (builtInType == BuiltInType.Variant) ? "BaseDataType" : builtInType.ToString();

                                if (!types.TryGetValue(builtInTypeName, out var resolvedType))
                                {
                                    writer.WritePropertyName("type");
                                    WriteExportType(writer, resolvedType.ExportType);

                                    if (resolvedType.ExportSubType != null)
                                    {
                                        writer.WritePropertyName("format");
                                        writer.WriteValue(resolvedType.ExportSubType);
                                    }
                                }
                            }
                            else
                            {
                                Debug.Assert(false, "Could not resolve built-in type.");
                            }
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

                            if (m_useCompactEncoding)
                            {
                                writer.WriteValue(field.Value);
                            }
                            else
                            {
                                writer.WriteValue($"{field.Name}_{field.Value}");
                            }

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

                        writer.WriteEndObject();
                        writer.WritePropertyName(name + "Masks");
                        writer.WriteStartObject();
                        //writer.WritePropertyName("$id");
                        //writer.WriteValue("/" + name.ToLowerInvariant() + "masks");

                        writer.WritePropertyName("anyOf");
                        writer.WriteStartArray();

                        foreach (var field in type.Value.Fields)
                        {
                            writer.WriteStartObject();
                            writer.WritePropertyName("const");
                            writer.WriteValue(1L<<(int)field.Value);
                            writer.WritePropertyName("title");
                            writer.WriteValue(field.Name);
                            writer.WriteEndObject();
                        }

                        writer.WriteEndArray();
                    }
                    else if (type.Value.Type == SchemaElementType.Union)
                    {
                        writer.WritePropertyName("oneOf");
                        writer.WriteStartArray();

                        foreach (var field in type.Value.Fields)
                        {
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

                        if (type.Value.DataTypeId != null)
                        {
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

                    if (type.Value.Sealed)
                    {
                        writer.WritePropertyName("additionalProperties");
                        writer.WriteValue(false);
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
