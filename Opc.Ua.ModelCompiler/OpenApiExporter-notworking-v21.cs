using System.Reflection;
using System.Text.Json.Nodes;
using Microsoft.OpenApi;
using Opc.Ua;
using Opc.Ua.Export;

namespace ModelCompiler
{
    internal class OpenApiExporter
    {
        private SystemContext m_context;
        private TypeTable m_typeTable;
        private NodeIdDictionary<DataTypeState> m_index;
        private bool m_allServices;

        readonly Dictionary<string, OpenApiSchema> m_builtInTypes = new Dictionary<string, OpenApiSchema>()
        {
            ["Boolean"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Boolean,
                Default = JsonValue.Create(false)!,
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.8)."
            },
            ["SByte"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Integer,
                Format = "int32",
                Minimum = "-128",
                Maximum = "127",
                Default = JsonValue.Create(0)!,
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.17)."
            },
            ["Byte"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Integer,
                Format = "int32",
                Minimum = "0",
                Maximum = "255",
                Default = JsonValue.Create(0)!,
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.9)."
            },
            ["Int16"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Integer,
                Format = "int32",
                Minimum = "-32768",
                Maximum = "32767",
                Default = JsonValue.Create(0)!,
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.25)."
            },
            ["UInt16"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Integer,
                Format = "int32",
                Minimum = "0",
                Maximum = "65535",
                Default = JsonValue.Create(0)!,
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.34)."
            },
            ["Int32"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Integer,
                Format = "int32",
                Default = JsonValue.Create(0)!,
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.26)."
            },
            ["UInt32"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Integer,
                Format = "int64",
                Minimum = "0",
                Maximum = "4294967295",
                Default = JsonValue.Create(0)!,
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.35)."
            },
            ["Int64"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Integer,
                Format = "int64",
                Default = JsonValue.Create(0)!,
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.27)."
            },
            ["UInt64"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Number,
                Minimum = "0",
                Maximum = "18446744073709551615",
                Default = JsonValue.Create(0)!,
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.36)."
            },
            ["Float"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Number,
                Format = "float",
                Default = JsonValue.Create(0.0)!,
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.15)."
            },
            ["Double"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Number,
                Format = "double",
                Default = JsonValue.Create(0.0)!,
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.12)."
            },
            ["String"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.String,
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.31)."
            },
            ["DateTime"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.String,
                Format = "date-time",
                Default = JsonValue.Create(DateTimeOffset.MinValue)!,
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.11)."
            },
            ["NodeId"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.String,
                Format = "UaNodeId",
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.2)."
            },
            ["ExpandedNodeId"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.String,
                Format = "UaExpandedNodeId",
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part4/v105/docs/7.16)."
            },
            ["StatusCode"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Object,
                AdditionalPropertiesAllowed = false,
                Properties = new Dictionary<string, IOpenApiSchema>()
                {
                    ["Code"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.Integer,
                        Format = "int64",
                        Minimum = "0",
                        Maximum = "4294967295"
                    },
                    ["Symbol"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.String
                    }
                },
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part4/v105/docs/7.39). [Set of defined codes](https://github.com/OPCFoundation/UA-Nodeset/tree/latest/Schema/StatusCode.csv)."
            },
            ["QualifiedName"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.String,
                Format = "UaQualifiedName",
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.3)."
            },
            ["LocalizedText"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Object,
                AdditionalPropertiesAllowed = false,
                Properties = new Dictionary<string, IOpenApiSchema>()
                {
                    ["Locale"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.String,
                        Format = "rfc3066"
                    },
                    ["Text"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.String
                    }
                },
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.5)."
            },
            ["Guid"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.String,
                Format = "uuid",
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.16)."
            },
            ["ByteString"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.String,
                Format = "byte",
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.10)."
            },
            ["XmlElement"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.String,
                Format = "xml",
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.38)."
            },
            ["ExtensionObject"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Object,
                AdditionalPropertiesAllowed = true,
                Properties = new Dictionary<string, IOpenApiSchema>()
                {
                    ["UaTypeId"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.String,
                        Format = "UaNodeId"
                    },
                    ["UaEncoding"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.Integer,
                        Format = "int32",
                        Minimum = "0",
                        Maximum = "255"
                    },
                    ["UaBody"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.String,
                        Format = "byte"
                    }
                },
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part6/v105/docs/5.4.2.16)."
            },
            ["Variant"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Object,
                AdditionalPropertiesAllowed = false,
                Properties = new Dictionary<string, IOpenApiSchema>()
                {
                    ["UaType"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.Integer,
                        Format = "int32",
                        Minimum = "0",
                        Maximum = "255"
                    },
                    ["Value"] = new OpenApiSchema()
                    {
                    },
                    ["Dimensions"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.Array,
                        Items = new OpenApiSchema()
                        {
                            Type = JsonSchemaType.Integer,
                            Format = "int32",
                            Minimum = "0"
                        }
                    }
                },
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part6/v105/docs/5.4.2.17)."
            },
            ["DataValue"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Object,
                AdditionalPropertiesAllowed = false,
                Properties = new Dictionary<string, IOpenApiSchema>()
                {
                    ["UaType"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.Integer,
                        Format = "int32",
                        Minimum = "0",
                        Maximum = "255"
                    },
                    ["Value"] = new OpenApiSchema()
                    {
                    },
                    ["Dimensions"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.Array,
                        Items = new OpenApiSchema()
                        {
                            Type = JsonSchemaType.Integer,
                            Format = "int32",
                            Minimum = "0"
                        }
                    },
                    ["StatusCode"] = new OpenApiSchema()
                    {
                        Schema = new Uri($"#/components/schemas/StatusCode", UriKind.Relative)
                    },
                    ["SourceTimestamp"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.String,
                        Format = "date-time"
                    },
                    ["SourcePicoseconds"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.Integer,
                        Format = "int32",
                        Minimum = "0",
                        Maximum = "65535"
                    },
                    ["ServerTimestamp"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.String,
                        Format = "date-time"
                    },
                    ["ServerPicoseconds"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.Integer,
                        Format = "int32",
                        Minimum = "0",
                        Maximum = "65535"
                    }
                },
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part6/v105/docs/5.4.2.18)."
            },
            ["DiagnosticInfo"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Object,
                AdditionalPropertiesAllowed = false,
                Properties = new Dictionary<string, IOpenApiSchema>()
                {
                    ["SymbolicId"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.Integer,
                        Format = "int32"
                    },
                    ["NamespaceUri"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.Integer,
                        Format = "int32"
                    },
                    ["Locale"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.Integer,
                        Format = "int32"
                    },
                    ["LocalizedText"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.Integer,
                        Format = "int32"
                    },
                    ["AdditionalInfo"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.String
                    },
                    ["InnerStatusCode"] = new OpenApiSchema()
                    {
                        Schema = new Uri($"#/components/schemas/StatusCode", UriKind.Relative)
                    },
                    ["InnerDiagnosticInfo"] = new OpenApiSchema()
                    {
                        Schema = new Uri($"#/components/schemas/DiagnosticInfo", UriKind.Relative)
                    }
                },
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part4/v105/docs/7.12)."
            },
            ["Decimal"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Object,
                AdditionalPropertiesAllowed = false,
                Properties = new Dictionary<string, IOpenApiSchema>()
                {
                    ["Scale"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.Integer,
                        Format = "int32",
                        Minimum = "-32768",
                        Maximum = "32767",
                        Default = JsonValue.Create((int)0)!,
                    },
                    ["Value"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.String,
                        Default = JsonValue.Create("0")
                    }
                },
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part6/v105/docs/5.4.3)."
            },
            ["Matrix"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Object,
                AdditionalPropertiesAllowed = false,
                Properties = new Dictionary<string, IOpenApiSchema>()
                {
                    ["Array"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.Array,
                        Items = new OpenApiSchema()
                        {
                        }
                    },
                    ["Dimensions"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.Array,
                        Items = new OpenApiSchema()
                        {
                            Type = JsonSchemaType.Integer,
                            Format = "int32",
                            Minimum = "0"
                        }
                    }
                },
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part6/v105/docs/5.4.5)."
            },
            ["Number"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Number,
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.30)."
            },
            ["Integer"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Number,
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.24)."
            },
            ["UInteger"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Number,
                Minimum = "0",
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part3/v105/docs/8.33)."
            },
            ["Structure"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Object,
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part6/v105/docs/5.4.6)."
            },
            ["Union"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Object,
                Properties = new Dictionary<string, IOpenApiSchema>()
                {
                    ["SwitchField"] = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.Integer,
                        Format = "int64",
                        Minimum = "0",
                        Maximum = "4294967295",
                        Default = JsonValue.Create((long)0)!
                    }
                },
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part6/v105/docs/5.4.8)."
            },
            ["Enumeration"] = new OpenApiSchema()
            {
                Type = JsonSchemaType.Integer,
                Format = "int32",
                Default = JsonValue.Create((int)0)!,
                Description = "[Link to specification](https://reference.opcfoundation.org/Core/Part6/v105/docs/5.4.4)."
            },
        };

        public OpenApiExporter(bool allServices)
        {
            m_context = new SystemContext();
            m_context.NamespaceUris = new NamespaceTable();
            m_context.ServerUris = new StringTable();

            m_typeTable = new TypeTable(m_context.NamespaceUris);
            m_context.TypeTable = m_typeTable;
            m_allServices = allServices;

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

        private static uint? GetDataTypeId(Type type, string propertyName)
        {
            if (type == null || string.IsNullOrEmpty(propertyName))
            {
                return null;
            }

            // Get the PropertyInfo object for the specified property
            var propertyInfo = type.GetField(propertyName, BindingFlags.Public | BindingFlags.Static);

            if (propertyInfo == null)
            {
                // Property not found
                return null;
            }

            // Get the value of the static property
            return propertyInfo.GetValue(null) as uint?;
        }

        private OpenApiPathItem GetPathItem(string serviceName)
        {
            var requestTypeId = GetDataTypeId(typeof(Opc.Ua.DataTypes), $"{serviceName}Request");
            var responseTypeId = GetDataTypeId(typeof(Opc.Ua.DataTypes), $"{serviceName}Response");

            m_index.TryGetValue(requestTypeId, out var requestType);
            m_index.TryGetValue(responseTypeId, out var responseType);

            var rs = new OpenApiSchema()
            {
                Title = $"{serviceName}RequestMessage",
                Schema = new Uri($"#/components/schemas/{serviceName}Request", UriKind.Relative),
                 
            };

            var qs = new OpenApiSchema()
            {
                Title = $"{serviceName}ResponseMessage",
                Schema = new Uri($"#/components/schemas/{serviceName}Response", UriKind.Relative)
            };

            return new OpenApiPathItem
            {
                Operations = new Dictionary<HttpMethod, OpenApiOperation>()
                {
                    [HttpMethod.Post] = new OpenApiOperation
                    {
                        OperationId = serviceName,
                        RequestBody = new OpenApiRequestBody()
                        {
                            Description = $"[Link to specification]({responseType?.NodeSetDocumentation}).",
                            Content = new Dictionary<string, OpenApiMediaType>()
                            {
                                ["application/json"] = new OpenApiMediaType()
                                {
                                    Schema = rs
                                }
                            }
                        },
                        Responses = new OpenApiResponses()
                        {
                            ["200"] = new OpenApiResponse()
                            {
                                Description = $"[Link to specification]({responseType?.NodeSetDocumentation}).",
                                Content = new Dictionary<string, OpenApiMediaType>()
                                {
                                    ["application/json"] = new OpenApiMediaType()
                                    {
                                        Schema = qs
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        private OpenApiSchema FindFieldSchema(
            StructureDefinition definition,
            StructureField field,
            DataTypeState fieldType)
        {
            var bit = FindBuiltInType(fieldType.NodeId);

            if (bit == null)
            {
                if (fieldType.NodeId == Opc.Ua.DataTypes.BaseDataType)
                {
                    return new OpenApiSchema()
                    {
                        Schema = new Uri($"#/components/schemas/Variant", UriKind.Relative)
                    };
                }

                return new OpenApiSchema() { Type = JsonSchemaType.Object };
            }

            if (bit.NodeId == Opc.Ua.DataTypes.Structure || bit.NodeId == Opc.Ua.DataTypes.Union)
            {
                if (
                    (field.IsOptional && definition.StructureType == StructureType.StructureWithSubtypedValues) ||
                    (field.IsOptional && definition.StructureType == StructureType.UnionWithSubtypedValues) ||
                    fieldType.IsAbstract)
                {
                    return new OpenApiSchema()
                    {
                        Schema = new Uri($"#/components/schemas/ExtensionObject", UriKind.Relative),
                        Description = $"[Link to specification]({fieldType.NodeSetDocumentation})."
                    };
                }

                return new OpenApiSchema()
                {
                    Schema = new Uri($"#/components/schemas/{fieldType.SymbolicName}", UriKind.Relative)
                };
            }

            if (bit.NodeId == Opc.Ua.DataTypes.BaseDataType)
            {
                return new OpenApiSchema()
                {
                    Schema = new Uri($"#/components/schemas/Variant", UriKind.Relative)
                };
            }

            if (bit.NodeId == Opc.Ua.DataTypes.Enumeration)
            {
                return new OpenApiSchema()
                {
                    Type = JsonSchemaType.Integer,
                    Format = fieldType.SymbolicName,
                    Description = $"[Link to specification]({fieldType.NodeSetDocumentation})."
                };
            }

            if (m_builtInTypes.TryGetValue(bit.SymbolicName, out var schema))
            {
                if (schema.Type != JsonSchemaType.Object)
                {
                    return new OpenApiSchema()
                    {
                        Type = schema.Type,
                        Format = schema.Format,
                        Maximum = schema.Maximum,
                        Minimum = schema.Minimum,
                        Default = schema.Default
                    };
                }
            }

            return new OpenApiSchema()
            {
                Schema = new Uri($"#/components/schemas/{bit.SymbolicName}", UriKind.Relative),
                Description = $"[Link to specification]({fieldType.NodeSetDocumentation})."
            };
        }

        public async Task GenerateCore(Stream ostrm, bool generateCore = true, bool generateYaml = false)
        {
            var document = new OpenApiDocument
            {
                Servers = new List<OpenApiServer>()
                {
                    new OpenApiServer()
                    {
                        Url = "http://localhost:4840"
                    }
                },
                Info = new OpenApiInfo
                {
                    Title = "OPC UA Web API",
                    Version = "15.5.0",
                    Description = "Provides simple HTTPS based access to an OPC UA server.",
                    Contact = new OpenApiContact()
                    {
                        Email = "office@opcfoundation.org"
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "OPC Source Deliverable Agreement of Use",
                        Url = new Uri("https://opcfoundation.org/license/source/1.11/")
                    }
                },
                Components = new OpenApiComponents()
            };

            HashSet<string> excluded = new()
            {
                Opc.Ua.BrowseNames.Boolean,
                Opc.Ua.BrowseNames.SByte,
                Opc.Ua.BrowseNames.Byte,
                Opc.Ua.BrowseNames.Int16,
                Opc.Ua.BrowseNames.UInt16,
                Opc.Ua.BrowseNames.Int32,
                Opc.Ua.BrowseNames.UInt32,
                Opc.Ua.BrowseNames.Int64,
                Opc.Ua.BrowseNames.UInt64,
                Opc.Ua.BrowseNames.Float,
                Opc.Ua.BrowseNames.Double,
                Opc.Ua.BrowseNames.String,
                Opc.Ua.BrowseNames.Guid,
                Opc.Ua.BrowseNames.ByteString,
                Opc.Ua.BrowseNames.DateTime,
                Opc.Ua.BrowseNames.LocaleId,
                Opc.Ua.BrowseNames.Number,
                Opc.Ua.BrowseNames.Integer,
                Opc.Ua.BrowseNames.UInteger,
                Opc.Ua.BrowseNames.Enumeration,
                Opc.Ua.BrowseNames.Union,
                Opc.Ua.BrowseNames.XmlElement,
                Opc.Ua.BrowseNames.Enumeration,
                Opc.Ua.BrowseNames.Index,
                Opc.Ua.BrowseNames.NodeId,
                Opc.Ua.BrowseNames.ExpandedNodeId,
                Opc.Ua.BrowseNames.QualifiedName
            };

            var schemas = new Dictionary<string, IOpenApiSchema>();

            foreach (var type in m_builtInTypes)
            {
                if (!excluded.Contains(type.Key))
                {
                    schemas.Add(type.Key, type.Value);
                }
            }

            HashSet<NodeId> included = new();
            CollectIncludedTypes(included, Opc.Ua.DataTypes.ReadRequest);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.ReadResponse);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.WriteRequest);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.WriteResponse);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.CallRequest);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.CallResponse);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.BrowseRequest);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.BrowseResponse);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.BrowseNextRequest);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.BrowseNextResponse);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.TranslateBrowsePathsToNodeIdsRequest);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.TranslateBrowsePathsToNodeIdsResponse);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.HistoryReadRequest);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.HistoryReadResponse);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.HistoryUpdateRequest);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.HistoryUpdateResponse);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.HistoryData);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.HistoryModifiedData);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.HistoryReadDetails);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.ReadRawModifiedDetails);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.ReadAtTimeDetails);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.ReadProcessedDetails);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.ReadAnnotationDataDetails);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.HistoryEvent);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.ReadEventDetails);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.ReadEventDetails2);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.UpdateDataDetails);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.UpdateEventDetails);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.UpdateStructureDataDetails);

            if (m_allServices)
            {
                CollectIncludedTypes(included, Opc.Ua.DataTypes.FindServersRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.FindServersResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.GetEndpointsRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.GetEndpointsResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.CreateSessionRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.CreateSessionResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.ActivateSessionRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.ActivateSessionResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.CloseSessionRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.CloseSessionResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.CancelRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.CancelResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.RegisterNodesRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.RegisterNodesResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.UnregisterNodesRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.UnregisterNodesResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.CreateMonitoredItemsRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.CreateMonitoredItemsResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.ModifyMonitoredItemsRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.ModifyMonitoredItemsResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.SetMonitoringModeRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.SetMonitoringModeResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.SetTriggeringRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.SetTriggeringResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.DeleteMonitoredItemsRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.DeleteMonitoredItemsResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.CreateSubscriptionRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.CreateSubscriptionResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.ModifySubscriptionRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.ModifySubscriptionResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.SetPublishingModeRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.SetPublishingModeResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.PublishRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.PublishResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.RepublishRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.RepublishResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.TransferSubscriptionsRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.TransferSubscriptionsResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.DeleteSubscriptionsRequest);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.DeleteSubscriptionsResponse);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.AnonymousIdentityToken);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.UserNameIdentityToken);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.X509IdentityToken);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.IssuedIdentityToken);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.DataChangeNotification);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.EventNotificationList);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.StatusChangeNotification);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.ElementOperand);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.LiteralOperand);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.AttributeOperand);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.SimpleAttributeOperand);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.DataChangeFilter);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.EventFilter);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.AggregateFilter);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.EventFilterResult);
                CollectIncludedTypes(included, Opc.Ua.DataTypes.AggregateFilterResult);
            }

            CollectIncludedTypes(included, Opc.Ua.DataTypes.PubSubConfiguration2DataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.PubSubConnectionDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.PubSubGroupDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.WriterGroupDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.WriterGroupMessageDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.WriterGroupTransportDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.ReaderGroupDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.ReaderGroupMessageDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.ReaderGroupTransportDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.DataSetReaderDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.DataSetReaderMessageDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.DataSetReaderTransportDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.DataSetWriterDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.DataSetWriterMessageDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.DataSetWriterTransportDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.DataTypeDescription);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.StructureDescription);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.EnumDescription);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.JsonWriterGroupMessageDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.JsonDataSetWriterMessageDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.JsonDataSetReaderMessageDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.BrokerConnectionTransportDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.BrokerDataSetReaderTransportDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.BrokerDataSetWriterTransportDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.BrokerWriterGroupTransportDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.PubSubState);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.Argument);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.Range);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.EUInformation);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.NetworkAddressDataType);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.JsonActionMetaDataMessage);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.JsonActionNetworkMessage);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.JsonActionRequestMessage);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.JsonActionResponderMessage);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.JsonActionResponseMessage);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.JsonApplicationDescriptionMessage);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.JsonDataSetMessage);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.JsonDataSetMetaDataMessage);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.JsonNetworkMessage);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.JsonStatusMessage);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.JsonServerEndpointsMessage);
            CollectIncludedTypes(included, Opc.Ua.DataTypes.JsonPubSubConnectionMessage);

            document.Paths = new OpenApiPaths
            {
                ["/read"] = GetPathItem("Read"),
                ["/write"] = GetPathItem("Write"),
                ["/call"] = GetPathItem("Call"),
                ["/historyread"] = GetPathItem("HistoryRead"),
                ["/historyupdate"] = GetPathItem("HistoryUpdate"),
                ["/browse"] = GetPathItem("Browse"),
                ["/browsenext"] = GetPathItem("BrowseNext"),
                ["/translate"] = GetPathItem("TranslateBrowsePathsToNodeIds")
            };

            if (m_allServices)
            {
                document.Paths["/findservers"] = GetPathItem("FindServers");
                document.Paths["/getendpoints"] = GetPathItem("GetEndpoints");
                document.Paths["/createsession"] = GetPathItem("CreateSession");
                document.Paths["/activatesession"] = GetPathItem("ActivateSession");
                document.Paths["/closesession"] = GetPathItem("CloseSession");
                document.Paths["/cancel"] = GetPathItem("Cancel");
                document.Paths["/registernodes"] = GetPathItem("RegisterNodes");
                document.Paths["/unregisternodes"] = GetPathItem("UnregisterNodes");
                document.Paths["/createmonitoreditems"] = GetPathItem("CreateMonitoredItems");
                document.Paths["/modifymonitoreditems"] = GetPathItem("ModifyMonitoredItems");
                document.Paths["/setmonitoringmode"] = GetPathItem("SetMonitoringMode");
                document.Paths["/settriggering"] = GetPathItem("SetTriggering");
                document.Paths["/deletemonitoreditems"] = GetPathItem("DeleteMonitoredItems");
                document.Paths["/createsubscription"] = GetPathItem("CreateSubscription");
                document.Paths["/modifysubscription"] = GetPathItem("ModifySubscription");
                document.Paths["/setpublishingmode"] = GetPathItem("SetPublishingMode");
                document.Paths["/publish"] = GetPathItem("Publish");
                document.Paths["/republish"] = GetPathItem("Republish");
                document.Paths["/transfersubscriptions"] = GetPathItem("TransferSubscriptions");
                document.Paths["/deletesubscriptions"] = GetPathItem("DeleteSubscriptions");
            }

            foreach (var node in m_index.Values)
            {
                if (node is DataTypeState dt)
                {
                    if (m_builtInTypes.ContainsKey(dt.SymbolicName))
                    {
                        continue;
                    }

                    if (!included.Contains(dt.NodeId) || excluded.Contains(dt.SymbolicName))
                    {
                        continue;
                    }

                    var definition = ExtensionObject.ToEncodeable(dt.DataTypeDefinition);

                    if (definition is StructureDefinition st)
                    {
                        var schema = new OpenApiSchema();

                        schema.Description = dt.Description?.Text;
                        schema.Type = JsonSchemaType.Object;
                        schema.Properties = new Dictionary<string, IOpenApiSchema>();
                        schema.Description = $"[Link to specification]({dt.NodeSetDocumentation}).";

                        foreach (var field in st.Fields)
                        {
                            if (field.DataType == null || !m_index.TryGetValue(field.DataType, out var fieldType))
                            {
                                fieldType = m_index[Opc.Ua.DataTypes.BaseDataType];
                            }

                            if (field.IsOptional && (st.StructureType == StructureType.StructureWithSubtypedValues || st.StructureType == StructureType.UnionWithSubtypedValues))
                            {
                                SetStructureAllowSubtypesFieldSchema(schema, field);
                                continue;
                            }

                            var fieldSchema = FindFieldSchema(st, field, fieldType);

                            if (field.ValueRank == ValueRanks.Scalar)
                            {
                                schema.Properties.Add(field.Name, fieldSchema);
                                continue;
                            }

                            schema.Properties.Add(field.Name, new OpenApiSchema()
                            {
                                Type = JsonSchemaType.Array,
                                Items = fieldSchema
                            });
                        }

                        if (dt.SuperTypeId != null)
                        {
                            if (m_index.TryGetValue(dt.SuperTypeId, out var superType))
                            {
                                if (superType.SymbolicName != "Structure" &&
                                    superType.SymbolicName != "Union" &&
                                    superType.SymbolicName != "BaseDataType")
                                {
                                    if (schema.AllOf == null)
                                    {
                                        schema.AllOf = new List<IOpenApiSchema>();
                                    }
                                    schema.AllOf.Add(
                                        new OpenApiSchema()
                                        {
                                            Schema = new Uri($"#/components/schemas/{superType.SymbolicName}", UriKind.Relative)
                                        }
                                    );
                                }
                            }
                        }

                        schemas.Add(dt.SymbolicName, schema);
                    }

                    else if (definition is EnumDefinition et)
                    {
                        SetEnumerationFieldSchema(schemas, dt, et);
                    }

                    else
                    {
                        OpenApiSchema schema = null;

                        var bit = FindBuiltInType(dt.NodeId);

                        if (bit == null || bit.NodeId == Opc.Ua.DataTypes.BaseDataType)
                        {
                            schema = new OpenApiSchema()
                            {
                                Schema = new Uri($"#/components/schemas/Variant", UriKind.Relative)
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

            schemas["JsonMessageType"] = GetJsonMessageTypeSchema();

            document.Components.Schemas = schemas;
            var errors = document.Validate(ValidationRuleSet.GetDefaultRuleSet());

            foreach (var error in errors)
            {
                Console.WriteLine($"OpenApi Validate: '{error.Message}' path={error.Pointer}");
            }

            using var stream = new StreamWriter(ostrm);
            await document.SerializeAsYamlAsync(ostrm, OpenApiSpecVersion.OpenApi3_0);
        }

        static readonly Dictionary<string, string> JsonMessageTypes = new()
        {
            ["Data"] = "ua-data",
            ["DataSetMetadata"] = "ua-metadata",
            ["Application"] = "ua-application",
            ["Endpoints"] = "ua-endpoints",
            ["Status"] = "ua-status",
            ["Connection"] = "ua-connection",
            ["ActionRequest"] = "ua-action-request",
            ["ActionResponse"] = "ua-action-response",
            ["ActionMetadata"] = "ua-action-metadata",
            ["ActionResponder"] = "ua-action-responder",
            ["KeyFrame"] = "ua-keyframe",
            ["DeltaFrame"] = "ua-deltaframe",
            ["Event"] = "ua-event",
            ["KeepAlive"] = "ua-keepalive"
        };

        private class StringArrayOpenApiExtension : IOpenApiExtension
        {
            public IReadOnlyList<string> Values { get; }

            public StringArrayOpenApiExtension(IEnumerable<string> values) => Values = new List<string>(values);

            public void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion)
            {
                writer.WriteStartArray();
                foreach (var value in Values)
                {
                    writer.WriteValue(value);
                }
                writer.WriteEndArray();
            }
        }

        private class RefOpenApiExtension : IOpenApiExtension
        {
            public string Url { get; }

            public RefOpenApiExtension(string url) => Url = url;

            public void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion)
            {
                writer.WriteValue(Url);
            }
        }

        private static OpenApiSchema GetJsonMessageTypeSchema()
        {
            List<string> names = new();
            List<JsonNode> values = new();

            foreach (var field in JsonMessageTypes)
            {
                names.Add(field.Key);
                values.Add(JsonValue.Create(field.Value));
            }

            var schema = new OpenApiSchema()
            {
                Type = JsonSchemaType.String,
                Enum = values
            };

            schema.AddExtension("x-enum-varnames", new StringArrayOpenApiExtension(names));

            return schema;
        }

        private static void SetEnumerationFieldSchema(
            Dictionary<string, IOpenApiSchema> schemas,
            DataTypeState dt,
            EnumDefinition et)
        {
            OpenApiSchema schema = new OpenApiSchema();

            schema.Type = JsonSchemaType.Integer;

            List<string> names = new();
            List<JsonNode> values = new();

            foreach (var field in et.Fields.OrderBy(x => x.Value))
            {
                names.Add(field.Name);
                values.Add(JsonValue.Create((!et.IsOptionSet) ? (int)field.Value : (1 << (int)field.Value)));
            }

            schema.Enum = values;
            schema.AddExtension("x-enum-varnames", new StringArrayOpenApiExtension(names));
            schema.Format = "int32";
            schema.Description = $"[Link to specification]({dt.NodeSetDocumentation}).";

            if (et.IsOptionSet)
            {
                schemas.Add(dt.SymbolicName + "Bits", schema);

                schema = new OpenApiSchema();

                schema.Type = JsonSchemaType.Integer;
                schema.Format = "int64";
                schema.Minimum = "0";
                schema.Maximum = "4294967295";
                schema.Default = JsonValue.Create((long)0)!;
            }

            schemas.Add(dt.SymbolicName, schema);
        }

        static readonly HashSet<NodeId> m_predefined = new()
        {
            Opc.Ua.DataTypes.Boolean,
            Opc.Ua.DataTypes.SByte,
            Opc.Ua.DataTypes.Byte,
            Opc.Ua.DataTypes.Int16,
            Opc.Ua.DataTypes.UInt16,
            Opc.Ua.DataTypes.Int32,
            Opc.Ua.DataTypes.UInt32,
            Opc.Ua.DataTypes.Int64,
            Opc.Ua.DataTypes.UInt64,
            Opc.Ua.DataTypes.Float,
            Opc.Ua.DataTypes.Double,
            Opc.Ua.DataTypes.String,
            Opc.Ua.DataTypes.Guid,
            Opc.Ua.DataTypes.ByteString,
            Opc.Ua.DataTypes.DateTime,
            Opc.Ua.DataTypes.StatusCode,
            Opc.Ua.DataTypes.LocaleId,
            Opc.Ua.DataTypes.Number,
            Opc.Ua.DataTypes.Integer,
            Opc.Ua.DataTypes.UInteger,
            Opc.Ua.DataTypes.Enumeration,
            Opc.Ua.DataTypes.Structure,
            Opc.Ua.DataTypes.Union,
            Opc.Ua.DataTypes.XmlElement,
            Opc.Ua.DataTypes.Enumeration,
            Opc.Ua.DataTypes.Index,
            Opc.Ua.DataTypes.NodeId,
            Opc.Ua.DataTypes.ExpandedNodeId,
            Opc.Ua.DataTypes.QualifiedName
        };

        public async Task GenerateModel(Stream ostrm, string modelName, string modelVersion, string modelUri, bool generateYaml = false)
        {
            var ns = m_context.NamespaceUris.GetIndexOrAppend(modelUri);
            var schemas = new Dictionary<string, IOpenApiSchema>();

            HashSet<NodeId> included = new();

            OpenApiSchema response = new OpenApiSchema();

            response.Title = "Response";
            response.Properties = new Dictionary<string, IOpenApiSchema>();
            response.OneOf = new List<IOpenApiSchema>();

            foreach (var node in m_index.Values.Where(x => x.NodeId.NamespaceIndex == ns))
            {
                CollectIncludedTypes(included, node.NodeId);

                response.Properties[node.SymbolicName] = new OpenApiSchema()
                {
                    Schema = new Uri($"#/components/schemas/{node.SymbolicName}", UriKind.Relative)
                };
            }

            var document = new OpenApiDocument
            {
                Servers = new List<OpenApiServer>()
                {
                    new OpenApiServer()
                    {
                        Url = "http://localhost:4840"
                    }
                },
                Info = new OpenApiInfo
                {
                    Title = modelName,
                    Version = modelVersion,
                    Description = "A placeholder API that allows OpenAPI tools to be used to generate code for a companion specification.",
                },
                Components = new OpenApiComponents(),
                Paths = new OpenApiPaths
                {
                    ["/get"] = new OpenApiPathItem
                    {
                        Operations = new Dictionary<HttpMethod, OpenApiOperation>()
                        {
                            [HttpMethod.Get] = new OpenApiOperation
                            {
                                OperationId = "Get",
                                Responses = new OpenApiResponses()
                                {
                                    ["200"] = new OpenApiResponse()
                                    {
                                        Description = $"ModelDataTypes",
                                        Content = new Dictionary<string, OpenApiMediaType>()
                                        {
                                            ["application/json"] = new OpenApiMediaType()
                                            {
                                                Schema = response
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            foreach (var node in included.OrderBy(x => x))
            {
                if (!m_index.TryGetValue(node, out var dt))
                {
                    continue;
                }

                var name = dt.SymbolicName;

                switch (name)
                {
                    case BrowseNames.Structure: name = "ExtensionObject"; break;
                    case BrowseNames.BaseObjectType: name = "Variant"; break;
                }

                if (m_builtInTypes.TryGetValue(name, out var bitSchema))
                {
                    schemas.Add(name, bitSchema);
                    continue;
                }

                OpenApiSchema schema = null;
                var definition = ExtensionObject.ToEncodeable(dt.DataTypeDefinition);

                if (definition is StructureDefinition st)
                {
                    schema = new OpenApiSchema()
                    {
                        Description = dt.Description?.Text,
                        Type = JsonSchemaType.Object,
                        Properties = new Dictionary<string, IOpenApiSchema>()
                    };

                    if (st.StructureType == StructureType.Union || st.StructureType == StructureType.UnionWithSubtypedValues)
                    {
                        schema.Properties["SwitchField"] = new OpenApiSchema()
                        {
                            Type = JsonSchemaType.Integer,
                            Format = "int32",
                            Minimum = "0",
                            Maximum = "65535",
                            Default = JsonValue.Create((int)0)!,
                        };
                    }

                    if (st.StructureType == StructureType.StructureWithOptionalFields)
                    {
                        schema.Properties["EncodingMask"] = new OpenApiSchema()
                        {
                            Type = JsonSchemaType.Integer,
                            Format = "int64",
                            Minimum = "0",
                            Maximum = "4294967295",
                            Default = JsonValue.Create((int)0)!,
                        };
                    }

                    foreach (var field in st.Fields)
                    {
                        if (field.DataType == null || !m_index.TryGetValue(field.DataType, out var fieldType))
                        {
                            fieldType = m_index[Opc.Ua.DataTypes.BaseDataType];
                        }

                        if (field.IsOptional && (st.StructureType == StructureType.StructureWithSubtypedValues || st.StructureType == StructureType.UnionWithSubtypedValues))
                        {
                            SetStructureAllowSubtypesFieldSchema(schema, field);
                            continue;
                        }

                        var fieldSchema = FindFieldSchema(st, field, fieldType);

                        if (field.ValueRank == ValueRanks.Scalar)
                        {
                            schema.Properties.Add(field.Name, fieldSchema);
                            continue;
                        }

                        schema.Properties.Add(field.Name, new OpenApiSchema()
                        {
                            Type = JsonSchemaType.Array,
                            Items = fieldSchema
                        });
                    }

                    if (dt.SuperTypeId != null)
                    {
                        if (m_index.TryGetValue(dt.SuperTypeId, out var superType))
                        {
                            if (superType.SymbolicName != "Structure" &&
                                superType.SymbolicName != "Union" &&
                                superType.SymbolicName != "BaseDataType")
                            {
                                if (schema.AllOf == null)
                                {
                                    schema.AllOf = new List<IOpenApiSchema>();
                                }
                                schema.AllOf.Add(
                                    new OpenApiSchema()
                                    {
                                        Schema = new Uri($"#/components/schemas/{superType.SymbolicName}", UriKind.Relative),

                                       
                                    }
                                );
                            }
                        }
                    }

                    schemas.Add(dt.SymbolicName, schema);
                }

                else if (definition is EnumDefinition et)
                {
                    SetEnumerationFieldSchema(schemas, dt, et);
                }

                else
                {
                    var bit = FindBuiltInType(dt.NodeId);

                    if (bit == null || bit.NodeId == Opc.Ua.DataTypes.BaseDataType)
                    {
                        schema = new OpenApiSchema()
                        {
                            Schema = new Uri($"#/components/schemas/Variant", UriKind.Relative)
                        };
                    }
                    else
                    {
                        m_builtInTypes.TryGetValue(bit.SymbolicName, out schema);
                    }

                    schemas.Add(dt.SymbolicName, schema);
                }
            }

            document.Components.Schemas = schemas;
            var errors = document.Validate(ValidationRuleSet.GetDefaultRuleSet());

            foreach (var error in errors)
            {
                Console.WriteLine($"OpenApi Validate: '{error.Message}' path={error.Pointer}");
            }

            using var stream = new StreamWriter(ostrm);
            await document.SerializeAsYamlAsync(ostrm, OpenApiSpecVersion.OpenApi3_0);
        }

        private void SetStructureAllowSubtypesFieldSchema(IOpenApiSchema schema, StructureField field)
        {
            if (field.ValueRank == ValueRanks.Scalar)
            {
                schema.Properties.Add(field.Name, new OpenApiSchema()
                {
                    Type = JsonSchemaType.Object
                });
            }
            else if (field.ValueRank > ValueRanks.Scalar)
            {
                schema.Properties.Add(field.Name, new OpenApiSchema()
                {
                    Type = JsonSchemaType.Array,
                    Items = new OpenApiSchema()
                    {
                        Type = JsonSchemaType.Object
                    }
                });
            }
            else
            {
                schema.Properties.Add(field.Name, new OpenApiSchema()
                {
                });
            }
        }

        private void CollectIncludedTypes(HashSet<NodeId> included, NodeId target)
        {
            if (included.Contains(target) || m_predefined.Contains(target))
            {
                return;
            }

            included.Add(target);

            if (m_index.TryGetValue(target, out var root))
            {
                StructureDefinition definition = ExtensionObject.ToEncodeable(root.DataTypeDefinition) as StructureDefinition;

                if (definition != null)
                {
                    foreach (var field in definition.Fields)
                    {
                        if (definition.StructureType == StructureType.StructureWithSubtypedValues || definition.StructureType == StructureType.UnionWithSubtypedValues)
                        {
                            if (field.IsOptional)
                            {
                                if (m_typeTable.IsTypeOf(field.DataType, DataTypeIds.Structure))
                                {
                                    included.Add(Opc.Ua.DataTypeIds.Structure);
                                    continue;
                                }
                                else if (
                                    field.DataType == DataTypeIds.BaseDataType ||
                                    field.DataType == DataTypeIds.Number ||
                                    field.DataType == DataTypeIds.Integer ||
                                    field.DataType == DataTypeIds.UInteger
                                )
                                {
                                    included.Add(Opc.Ua.DataTypeIds.BaseDataType);
                                    continue;
                                }
                            }
                        }

                        CollectIncludedTypes(included, field.DataType);
                    }
                }
            }

            var superTypeId = m_typeTable.FindSuperType(target);

            while (!NodeId.IsNull(superTypeId))
            {
                if (superTypeId == DataTypeIds.BaseDataType ||
                    superTypeId == DataTypeIds.Structure ||
                    superTypeId == DataTypeIds.Union ||
                    superTypeId == DataTypeIds.Enumeration)
                {
                    break;
                }

                CollectIncludedTypes(included, superTypeId);
                superTypeId = m_typeTable.FindSuperType(superTypeId);
            }
        }

        public static bool Verify(Stream ostrm)
        {
            //var reader = new OpenApiStreamReader();
            //var result = await reader.ReadAsync(ostrm);

            //var diagnostics = result.OpenApiDiagnostic;

            //var x = diagnostics.Errors.Count;


            //if (diagnostics.Errors.Count > 0)
            //{
            //    foreach (var error in diagnostic.Errors)
            //    {
            //        Console.WriteLine($"OpenApi Validate: '{error.Message}' path={error.Pointer}");
            //    }

            //    return false;
            //}

            return true;
        }
    }
}
