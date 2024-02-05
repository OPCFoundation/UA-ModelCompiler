using Microsoft.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using Opc.Ua;
using Opc.Ua.Export;

namespace ModelCompiler
{
    internal class OpenApiExporter
    {
        private SystemContext m_context;
        private TypeTable m_typeTable;
        private NodeIdDictionary<DataTypeState> m_index;
        private bool m_useV2encoding;
        private bool m_allServices;

        readonly Dictionary<string, OpenApiSchema> m_builtInTypes = new Dictionary<string, OpenApiSchema>()
        {
            ["Boolean"] = new OpenApiSchema()
            {
                Type = "boolean"
            },
            ["SByte"] = new OpenApiSchema()
            {
                Type = "integer",
                Format = "int8"
            },
            ["Byte"] = new OpenApiSchema()
            {
                Type = "integer",
                Format = "uint8"
            },
            ["Int16"] = new OpenApiSchema()
            {
                Type = "integer",
                Format = "int16"
            },
            ["UInt16"] = new OpenApiSchema()
            {
                Type = "integer",
                Format = "uint16"
            },
            ["Int32"] = new OpenApiSchema()
            {
                Type = "integer",
                Format = "int32"
            },
            ["UInt32"] = new OpenApiSchema()
            {
                Type = "integer",
                Format = "uint32"
            },
            ["Int64"] = new OpenApiSchema()
            {
                Type = "integer",
                Format = "int32"
            },
            ["UInt64"] = new OpenApiSchema()
            {
                Type = "integer",
                Format = "uint64"
            },
            ["Float"] = new OpenApiSchema()
            {
                Type = "number",
                Format = "float"
            },
            ["Double"] = new OpenApiSchema()
            {
                Type = "number",
                Format = "double"
            },
            ["String"] = new OpenApiSchema()
            {
                Type = "string"
            },
            ["DateTime"] = new OpenApiSchema()
            {
                Type = "string",
                Format = "date-time"
            },
            ["NodeId"] = new OpenApiSchema()
            {
                Type = "string",
                Format = "NodeId"
            },
            ["ExpandedNodeId"] = new OpenApiSchema()
            {
                Type = "string",
                Format = "ExpandedNodeId"
            },
            ["StatusCode"] = new OpenApiSchema()
            {
                Type = "integer",
                Format = "StatusCode"
            },
            ["QualifiedName"] = new OpenApiSchema()
            {
                Type = "string",
                Format = "QualifiedName"
            },
            ["LocalizedText"] = new OpenApiSchema()
            {
                Type = "object",
                Properties = new Dictionary<string, OpenApiSchema>()
                {
                    ["Locale"] = new OpenApiSchema()
                    {
                        Type = "string",
                        Format = "rfc3066"
                    },
                    ["Text"] = new OpenApiSchema()
                    {
                        Type = "string"
                    }
                }
            },
            ["LocaleId"] = new OpenApiSchema()
            {
                Type = "string",
                Format = "rfc3066"
            },
            ["Guid"] = new OpenApiSchema()
            {
                Type = "string",
                Format = "uuid"
            },
            ["ByteString"] = new OpenApiSchema()
            {
                Type = "string",
                Format = "byte"
            },
            ["XmlElement"] = new OpenApiSchema()
            {
                Type = "string",
                Format = "xml"
            },
            ["ExtensionObject"] = new OpenApiSchema()
            {
                Type = "object",
                Properties = new Dictionary<string, OpenApiSchema>()
                {
                    ["TypeId"] = new OpenApiSchema()
                    {
                        Type = "string",
                        Format = "NodeId"
                    },
                    ["Encoding"] = new OpenApiSchema()
                    {
                        Type = "integer",
                        Format = "uint8"
                    },
                    ["Body"] = new OpenApiSchema()
                    {
                        Type = "object",
                        AdditionalPropertiesAllowed = true
                    }
                },
            },
            ["Variant"] = new OpenApiSchema()
            {
                Type = "object",
                Properties = new Dictionary<string, OpenApiSchema>()
                {
                    ["Type"] = new OpenApiSchema()
                    {
                        Type = "integer",
                        Format = "uint8"
                    },
                    ["Body"] = new OpenApiSchema()
                    {
                    },
                    ["Dimensions"] = new OpenApiSchema()
                    {
                        Type = "array",
                        Items = new OpenApiSchema()
                        {
                            Type = "integer",
                            Format = "uint32"
                        }
                    },
                }
            },
            ["DataValue"] = new OpenApiSchema()
            {
                Type = "object",
                Properties = new Dictionary<string, OpenApiSchema>()
                {
                    ["Value"] = new OpenApiSchema()
                    {
                        Reference = new OpenApiReference() { Type = ReferenceType.Schema, Id = "Variant" }
                    },
                    ["StatusCode"] = new OpenApiSchema()
                    {
                        Type = "integer",
                        Format = "StatusCode"
                    },
                    ["SourceTimestamp"] = new OpenApiSchema()
                    {
                        Type = "string",
                        Format = "date-time"
                    },
                    ["SourcePicoSeconds"] = new OpenApiSchema()
                    {
                        Type = "integer",
                        Format = "uint16"
                    },
                    ["ServerTimestamp"] = new OpenApiSchema()
                    {
                        Type = "string",
                        Format = "date-time"
                    },
                    ["ServerPicoSeconds"] = new OpenApiSchema()
                    {
                        Type = "integer",
                        Format = "uint16"
                    }
                }
            },
            ["DiagnosticInfo"] = new OpenApiSchema()
            {
                Type = "object",
                Properties = new Dictionary<string, OpenApiSchema>()
                {
                    ["SymbolicId"] = new OpenApiSchema()
                    {
                        Type = "integer",
                        Format = "int32"
                    },
                    ["NamespaceUri"] = new OpenApiSchema()
                    {
                        Type = "integer",
                        Format = "int32"
                    },
                    ["Locale"] = new OpenApiSchema()
                    {
                        Type = "integer",
                        Format = "int32"
                    },
                    ["LocalizedText"] = new OpenApiSchema()
                    {
                        Type = "integer",
                        Format = "int32"
                    },
                    ["AdditionalInfo"] = new OpenApiSchema()
                    {
                        Type = "string"
                    },
                    ["InnerStatusCode"] = new OpenApiSchema()
                    {
                        Type = "integer",
                        Format = "StatusCode"
                    },
                    ["InnerDiagnosticInfo"] = new OpenApiSchema()
                    {
                        Reference = new OpenApiReference() { Type = ReferenceType.Schema, Id = "DiagnosticInfo" }
                    }
                }
            },
            ["Decimal"] = new OpenApiSchema()
            {
                Type = "object",
                Properties = new Dictionary<string, OpenApiSchema>()
                {
                    ["Scale"] = new OpenApiSchema()
                    {
                        Type = "integer",
                        Format = "int16"
                    },
                    ["Value"] = new OpenApiSchema()
                    {
                        Type = "string",
                        Format = "uinteger"
                    }
                }
            },
            ["Number"] = new OpenApiSchema()
            {
                Type = "number"
            },
            ["Integer"] = new OpenApiSchema()
            {
                Type = "integer"
            },
            ["UInteger"] = new OpenApiSchema()
            {
                Type = "integer",
                Minimum = 0
            },
            ["Structure"] = new OpenApiSchema()
            {
                Type = "object"
            },
            ["Union"] = new OpenApiSchema()
            {
                Type = "object",
                Properties = new Dictionary<string, OpenApiSchema>()
                {
                    ["SwitchField"] = new OpenApiSchema()
                    {
                        Type = "integer",
                        Format = "uint32"
                    }
                }
            },
            ["Enumeration"] = new OpenApiSchema()
            {
                Type = "integer",
                Format = "int32"
            },
        };

        public OpenApiExporter(bool useV2encoding, bool allServices)
        {
            m_context = new SystemContext();
            m_context.NamespaceUris = new NamespaceTable();
            m_context.ServerUris = new StringTable();

            m_typeTable = new TypeTable(m_context.NamespaceUris);
            m_context.TypeTable = m_typeTable;
            m_useV2encoding = useV2encoding;
            m_allServices = allServices;

            if (!useV2encoding)
            {
                m_builtInTypes["NodeId"] = new OpenApiSchema()
                {
                    Type = "object",
                    Properties = new Dictionary<string, OpenApiSchema>()
                    {
                        ["IdType"] = new OpenApiSchema()
                        {
                            Type = "number"
                        },
                        ["Id"] = new OpenApiSchema()
                        {
                        },
                        ["Namespace"] = new OpenApiSchema()
                        {
                            Type = "number"
                        }
                    }
                };

                m_builtInTypes["ExpandedNodeId"] = new OpenApiSchema()
                {
                    Type = "object",
                    Properties = new Dictionary<string, OpenApiSchema>()
                    {
                        ["IdType"] = new OpenApiSchema()
                        {
                            Type = "number"
                        },
                        ["Id"] = new OpenApiSchema()
                        {
                        },
                        ["Namespace"] = new OpenApiSchema()
                        {
                        },
                        ["ServerUri"] = new OpenApiSchema()
                        {
                            Type = "number"
                        }
                    }
                };

                m_builtInTypes["QualifiedName"] = new OpenApiSchema()
                {
                    Type = "object",
                    Properties = new Dictionary<string, OpenApiSchema>()
                    {
                        ["Name"] = new OpenApiSchema()
                        {
                            Type = "string"
                        },
                        ["Uri"] = new OpenApiSchema()
                        {
                        }
                    }
                };

                m_builtInTypes["ExtensionObject"] = new OpenApiSchema()
                {
                    Type = "object",
                    Properties = new Dictionary<string, OpenApiSchema>()
                    {
                        ["TypeId"] = new OpenApiSchema()
                        {
                            Reference = new OpenApiReference() { Type = ReferenceType.Schema, Id = "NodeId" }
                        },
                        ["Encoding"] = new OpenApiSchema()
                        {
                            Type = "integer",
                            Format = "uint8"
                        },
                        ["Body"] = new OpenApiSchema()
                        {
                            Type = "object",
                            AdditionalPropertiesAllowed = true
                        }
                    },
                };
            }

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

        private OpenApiPathItem GetPathItem(string serviceName)
        {
            return new OpenApiPathItem
            { 
                Operations = new Dictionary<OperationType, OpenApiOperation>()
                {
                    [OperationType.Post] = new OpenApiOperation
                    {
                        OperationId = serviceName,
                        RequestBody = new OpenApiRequestBody()
                        {
                            Description = $"{serviceName}RequestMessage",
                            Content = new Dictionary<string, OpenApiMediaType>()
                            {
                                ["application/json"] = new OpenApiMediaType()
                                {
                                    Schema = new OpenApiSchema()
                                    {
                                        Title = $"{serviceName}RequestMessage",
                                        Properties = new Dictionary<string, OpenApiSchema>()
                                        {
                                            ["NamespaceUris"] = new OpenApiSchema()
                                            {
                                                Type = "array",
                                                Items = new OpenApiSchema()
                                                {
                                                    Type = "string"
                                                }
                                            },
                                            ["ServerUris"] = new OpenApiSchema()
                                            {
                                                Type = "array",
                                                Items = new OpenApiSchema()
                                                {
                                                    Type = "string"
                                                }
                                            },
                                            ["LocaleIds"] = new OpenApiSchema()
                                            {
                                                Type = "array",
                                                Items = new OpenApiSchema()
                                                {
                                                    Type = "string"
                                                }
                                            },
                                            ["ServiceId"] = new OpenApiSchema()
                                            {
                                                Type = "integer",
                                                Format = "uint32"
                                            },
                                            ["Body"] = new OpenApiSchema()
                                            {
                                                Reference = new OpenApiReference()
                                                {
                                                    Type = ReferenceType.Schema,
                                                    Id = $"{serviceName}Request"
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        Responses = new OpenApiResponses()
                        {
                            ["200"] = new OpenApiResponse()
                            {
                                Description = $"{serviceName}ResponseMessage",
                                Content = new Dictionary<string, OpenApiMediaType>()
                                {
                                    ["application/json"] = new OpenApiMediaType()
                                    {
                                        Schema = new OpenApiSchema()
                                        {
                                            Title = $"{serviceName}ResponseMessage",
                                            Properties = new Dictionary<string, OpenApiSchema>()
                                            {
                                                ["NamespaceUris"] = new OpenApiSchema()
                                                {
                                                    Type = "array",
                                                    Items = new OpenApiSchema()
                                                    {
                                                        Type = "string"
                                                    }
                                                },
                                                ["ServerUris"] = new OpenApiSchema()
                                                {
                                                    Type = "array",
                                                    Items = new OpenApiSchema()
                                                    {
                                                        Type = "string"
                                                    }
                                                },
                                                ["ServiceId"] = new OpenApiSchema()
                                                {
                                                    Type = "integer",
                                                    Format = "uint32"
                                                },
                                                ["Body"] = new OpenApiSchema()
                                                {
                                                    Reference = new OpenApiReference()
                                                    {
                                                        Type = ReferenceType.Schema,
                                                        Id = $"{serviceName}Response"
                                                    }
                                                }
                                            }
                                        }
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
                return new OpenApiSchema() { Type = "object" };
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
                        Reference = new OpenApiReference()
                        {
                            Type = ReferenceType.Schema,
                            Id = "ExtensionObject"
                        }
                    };
                }

                return new OpenApiSchema()
                {
                    Reference = new OpenApiReference()
                    {
                        Type = ReferenceType.Schema,
                        Id = fieldType.SymbolicName
                    }
                };
            }

            if (bit.NodeId == Opc.Ua.DataTypes.BaseDataType)
            {
                return new OpenApiSchema()
                {
                    Reference = new OpenApiReference()
                    {
                        Type = ReferenceType.Schema,
                        Id = "Variant"
                    }
                };
            }

            if (bit.NodeId == Opc.Ua.DataTypes.Enumeration)
            {
                return new OpenApiSchema()
                {
                    Type = "integer",
                    Format = fieldType.SymbolicName
                };
            }

            if (m_builtInTypes.TryGetValue(bit.SymbolicName, out var schema))
            {
                if (schema.Type != "object")
                {
                    return new OpenApiSchema()
                    {
                        Type = schema.Type,
                        Format = schema.Format,
                        Maximum = schema.Maximum,
                        Minimum = schema.Minimum
                    };
                }
            }

            return new OpenApiSchema()
            {
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.Schema,
                    Id = bit.SymbolicName
                }
            };
        }

        public void Generate(Stream ostrm, bool generateYaml = false)
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
                    Title = "OPC UA REST API",
                    Version = "0.0.1",
                    Description = "This API provides simple REST based access to an OPC UA server.",
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
                Components = new OpenApiComponents(),
                Paths = new OpenApiPaths
                {
                    ["/read"] = GetPathItem("Read"),
                    ["/write"] = GetPathItem("Write"),
                    ["/call"] = GetPathItem("Call"),
                    ["/historyread"] = GetPathItem("HistoryRead"),
                    ["/historyupdate"] = GetPathItem("HistoryUpdate"),
                    ["/browse"] = GetPathItem("Browse"),
                    ["/browsenext"] = GetPathItem("BrowseNext"),
                    ["/translate"] = GetPathItem("TranslateBrowsePathsToNodeIds")
                }
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
                Opc.Ua.BrowseNames.StatusCode,
                Opc.Ua.BrowseNames.LocaleId,
                Opc.Ua.BrowseNames.Number,
                Opc.Ua.BrowseNames.Integer,
                Opc.Ua.BrowseNames.UInteger,
                Opc.Ua.BrowseNames.Enumeration,
                Opc.Ua.BrowseNames.Structure,
                Opc.Ua.BrowseNames.Union,
                Opc.Ua.BrowseNames.XmlElement,
                Opc.Ua.BrowseNames.Enumeration,
                Opc.Ua.BrowseNames.Index
            };

            if (m_useV2encoding)
            {
                excluded.Add(Opc.Ua.BrowseNames.NodeId);
                excluded.Add(Opc.Ua.BrowseNames.ExpandedNodeId);
                excluded.Add(Opc.Ua.BrowseNames.QualifiedName);
            }

            var schemas = new Dictionary<string, OpenApiSchema>();

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
                        OpenApiSchema schema = new OpenApiSchema();

                        schema.Description = dt.Description?.Text;
                        schema.Type = "object";
                        schema.Properties = new Dictionary<string, OpenApiSchema>();

                        foreach (var field in st.Fields)
                        {
                            if (field.DataType == null || !m_index.TryGetValue(field.DataType, out var fieldType))
                            {
                                fieldType = m_index[Opc.Ua.DataTypes.BaseDataType];
                            }

                            var fieldSchema = FindFieldSchema(st, field, fieldType);

                            if (field.ValueRank == ValueRanks.Scalar)
                            {
                                schema.Properties.Add(field.Name, fieldSchema);
                                continue;
                            }

                            schema.Properties.Add(field.Name, new OpenApiSchema()
                            {
                                Type = "array",
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
                                    schema.AllOf = new List<OpenApiSchema>()
                                    {
                                        new OpenApiSchema() {
                                            Reference = new OpenApiReference()
                                            {
                                                Type = ReferenceType.Schema,
                                                Id = superType.SymbolicName
                                            }
                                        }
                                    };
                                }
                            }
                        }

                        schemas.Add(dt.SymbolicName, schema);
                    }

                    else if (definition is EnumDefinition et)
                    {
                        OpenApiSchema schema = new OpenApiSchema();

                        if (!et.IsOptionSet)
                        {
                            schema.Type = "integer";

                            OpenApiArray names = new();
                            List<IOpenApiAny> values = new();

                            foreach (var field in et.Fields.OrderBy(x => x.Value))
                            {
                                names.Add(new OpenApiString(field.Name));
                                values.Add(new OpenApiInteger((int)field.Value));
                            }

                            schema.Enum = values;
                            schema.AddExtension("x-enum-varnames", names);
                            schema.Format = "int32";
                        }
                        else
                        {
                            schema.Type = "integer";
                            schema.Description = String.Join(", ", et.Fields.OrderBy(x => x.Value).Select(x => $"{x.Name}={x.Value:X4}"));
                            schema.Format = "uint32";
                        }

                        schemas.Add(dt.SymbolicName, schema);
                    }

                    else
                    {
                        OpenApiSchema schema = null;

                        var bit = FindBuiltInType(dt.NodeId);

                        if (bit == null || bit.NodeId == Opc.Ua.DataTypes.BaseDataType)
                        {
                            schema = new OpenApiSchema()
                            {
                                Reference = new OpenApiReference()
                                {
                                    Type = ReferenceType.Schema,
                                    Id = "Variant"
                                }
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

            document.Components.Schemas = schemas;
            var errors = document.Validate(Microsoft.OpenApi.Validations.ValidationRuleSet.GetDefaultRuleSet());

            foreach (var error in errors)
            {
                Console.WriteLine(error.Message);
            }

            document.Serialize(
                ostrm,
                OpenApiSpecVersion.OpenApi3_0,
                (generateYaml) ? OpenApiFormat.Yaml : OpenApiFormat.Json);

        }

        private void CollectIncludedTypes(HashSet<NodeId> included, NodeId target)
        {
            if (included.Contains(target))
            {
                return;
            }

            included.Add(target);

            if (m_index.TryGetValue(target, out var root))
            {
                StructureDefinition definition = ExtensionObject.ToEncodeable(root.DataTypeDefinition) as StructureDefinition; ;

                if (definition != null)
                {
                    foreach (var field in definition.Fields)
                    {
                        CollectIncludedTypes(included, field.DataType);
                    }
                }
            }

            var superTypeId = m_typeTable.FindSuperType(target);

            while (!NodeId.IsNull(superTypeId))
            {
                CollectIncludedTypes(included, superTypeId);
                superTypeId = m_typeTable.FindSuperType(superTypeId);
            }
        }

        public static bool Verify(Stream ostrm)
        {
            var document = new OpenApiStreamReader().Read(ostrm, out var diagnostic);

            if (diagnostic.Errors.Count > 0)
            {
                foreach (var error in diagnostic.Errors)
                {
                    Console.WriteLine(error.Message);
                }

                return false;
            }

            return true;
        }
    }
}
