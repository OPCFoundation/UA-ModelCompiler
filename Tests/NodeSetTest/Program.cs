using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using Microsoft.Net.Http.Headers;
using Opc.Ua;
using Opc.Ua.UANodeSet;

namespace NodeSetTest
{
    public class NodeSetConvertor
    {
        public NodeSetConvertor()
        {
            SystemContext = new SystemContext();
            SystemContext.NamespaceUris = new NamespaceTable();
            SystemContext.ServerUris = new StringTable();
            SystemContext.NamespaceUris.Append(Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

            Aliases = new Dictionary<string, NodeId>();
        }

        public SystemContext SystemContext { get; set; }

        public Dictionary<string, NodeId> Aliases { get; set; }

        private NodeId ImportNodeId(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return null;
            }

            NodeId nodeId = null;

            if (Aliases.TryGetValue(input, out nodeId))
            {
                return nodeId;
            }

            return NodeId.Parse(input);
        }

        private LocalizedTextCollection Import(Opc.Ua.Export.LocalizedText[] input)
        {
            LocalizedTextCollection output = new LocalizedTextCollection();

            if (input != null)
            {
                foreach (var ii in input)
                {
                    output.Add(new LocalizedText(ii.Locale, ii.Value));
                }
            }

            return output;
        }

        private RolePermissionTypeCollection Import(Opc.Ua.Export.RolePermission[] input)
        {
            RolePermissionTypeCollection output = new RolePermissionTypeCollection();

            if (input != null)
            {
                foreach (var ii in input)
                {
                    output.Add(Import(ii));
                }
            }

            return output;
        }

        private RolePermissionType Import(Opc.Ua.Export.RolePermission input)
        {
            var output = new RolePermissionType()
            {
                RoleId = ImportNodeId(input.Value),
                Permissions = input.Permissions
            };

            return output;
        }

        private ModelTableEntry Import(Opc.Ua.Export.ModelTableEntry input)
        {
            var output = new ModelTableEntry()
            {
                ModelUri = input.ModelUri,
                AccessRestrictions = input.AccessRestrictions,
                PublicationDate = (input.PublicationDateSpecified) ? input.PublicationDate : DateTime.MinValue,
                Version = input.Version,
                RolePermissions = Import(input.RolePermissions)
            };

            if (input.RequiredModel != null)
            {
                output.RequiredModels = new ModelTableEntryCollection();

                foreach (var ii in input.RequiredModel)
                {
                    output.RequiredModels.Add(Import(ii));
                }
            }

            return output;
        }

        private UAObject Import(Opc.Ua.Export.UAObject input)
        {
            UAObject output = new UAObject()
            {
                ParentNodeId = ImportNodeId(input.ParentNodeId),
                EventNotifier = input.EventNotifier
            };

            return output;
        }

        private UInt32Collection ParseDimensions(string input)
        {
            var output = new UInt32Collection();
            var fields = input.Split(",");

            foreach (var ii in fields)
            {
                uint dimension = 0;

                if (UInt32.TryParse(ii, out dimension))
                {
                    output.Add(dimension);
                }
                else
                {
                    output.Add(0);
                }
            }

            return output;
        }

        private NamedTranslationTypeCollection Import(Opc.Ua.Export.TranslationType[] input)
        {
            NamedTranslationTypeCollection output = new NamedTranslationTypeCollection();

            NamedTranslationType unnamed = new NamedTranslationType();

            if (input != null)
            {
                foreach (var ii in input)
                {
                    if (ii.Items != null)
                    {
                        foreach (var jj in ii.Items)
                        {
                            var st = jj as Opc.Ua.Export.StructureTranslationType;

                            if (st != null)
                            {
                                output.Add(new NamedTranslationType()
                                {
                                    Name = st.Name,
                                    Text = Import(st.Text)
                                });

                                continue;
                            }

                            var lt = jj as Opc.Ua.Export.LocalizedText;

                            if (lt != null)
                            {
                                unnamed.Text.Add(new LocalizedText(lt.Locale, lt.Value));
                                continue;
                            }
                        }
                    }
                }
            }

            if (unnamed.Text.Count > 0)
            {
                output.Insert(0, unnamed);
            }

            return output;
        }

        private XmlDecoder CreateDecoder(XmlElement input)
        {
            ServiceMessageContext messageContext = new ServiceMessageContext();
            messageContext.NamespaceUris = SystemContext.NamespaceUris;
            messageContext.ServerUris = SystemContext.ServerUris;
            messageContext.Factory = SystemContext.EncodeableFactory;

            XmlDecoder decoder = new XmlDecoder(input, messageContext);
            return decoder;
        }

        private UAVariable Import(Opc.Ua.Export.UAVariable input)
        {
            UAVariable output = new UAVariable()
            {
                ParentNodeId = ImportNodeId(input.ParentNodeId),
                DataType = ImportNodeId(input.DataType),
                ValueRank = input.ValueRank,
                ArrayDimensions = ParseDimensions(input.ArrayDimensions),
                AccessLevel = input.AccessLevel,
                MinimumSamplingInterval = input.MinimumSamplingInterval,
                Historizing = input.Historizing,
                Translations = Import(input.Translation)
            };

            if (input.Value != null)
            {
                using (XmlDecoder decoder = CreateDecoder(input.Value))
                {
                    TypeInfo typeInfo = null;
                    output.Value = new Variant(decoder.ReadVariantContents(out typeInfo));
                    decoder.Close();
                }
            }

            return output;
        }

        private NamedTranslationTypeCollection Import(Opc.Ua.Export.UAMethodArgument[] input)
        {
            NamedTranslationTypeCollection output = new NamedTranslationTypeCollection();

            if (input != null)
            {
                foreach (var ii in input)
                {
                    output.Add(new NamedTranslationType()
                    {
                        Name = ii.Name,
                        Text = Import(ii.Description)
                    });
                }
            }

            return output;
        }

        private UAMethod Import(Opc.Ua.Export.UAMethod input)
        {
            UAMethod output = new UAMethod()
            {
                ParentNodeId = ImportNodeId(input.ParentNodeId),
                MethodDeclarationId = ImportNodeId(input.MethodDeclarationId),
                Translations = Import(input.ArgumentDescription)
            };

            return output;
        }

        private UAView Import(Opc.Ua.Export.UAView input)
        {
            UAView output = new UAView()
            {
                ParentNodeId = ImportNodeId(input.ParentNodeId),
                ContainsNoLoops = input.ContainsNoLoops,
                EventNotifier = input.EventNotifier
            };

            return output;
        }

        private UAObjectType Import(Opc.Ua.Export.UAObjectType input)
        {
            UAObjectType output = new UAObjectType()
            {
                IsAbstract = input.IsAbstract
            };

            return output;
        }

        private UAVariableType Import(Opc.Ua.Export.UAVariableType input)
        {
            UAVariableType output = new UAVariableType()
            {
                IsAbstract = input.IsAbstract,
                DataType = ImportNodeId(input.DataType),
                ValueRank = input.ValueRank,
                ArrayDimensions = ParseDimensions(input.ArrayDimensions),
            };

            return output;
        }

        private UAReferenceType Import(Opc.Ua.Export.UAReferenceType input)
        {
            UAReferenceType output = new UAReferenceType()
            {
                IsAbstract = input.IsAbstract,
                InverseName = Import(input.InverseName),
                Symmetric = input.Symmetric
            };

            return output;
        }

        private DataTypeDefinition Import(Opc.Ua.Export.DataTypeDefinition input)
        {
            if (input == null)
            {
                return null;
            }

            DataTypeDefinition definition = null;

            if (input.Field != null && input.Field.Length > 0)
            {
                bool isStructure = !input.IsUnion;
                bool isUnion = input.IsUnion;

                if (input.Field[0].Value >= 0)
                {
                    isStructure = false;
                }

                if (isStructure || isUnion)
                {
                    var sd = new StructureDefinition();
                    sd.BaseDataType = ImportNodeId(input.BaseType);
                    sd.StructureType = (isUnion) ? StructureType.Union : StructureType.Structure;
                    sd.Fields = new StructureFieldCollection();

                    foreach (var ii in input.Field)
                    {
                        var field = new StructureField()
                        {
                            Name = ii.Name,
                            DataType = ImportNodeId(ii.DataType),
                            ValueRank = ii.ValueRank,
                            ArrayDimensions = ParseDimensions(ii.ArrayDimensions),
                            IsOptional = ii.IsOptional,
                            MaxStringLength = ii.MaxStringLength
                        };

                        var descriptions = Import(ii.Description);

                        if (descriptions != null && descriptions.Count > 0)
                        {
                            field.Description = descriptions[0];
                        }

                        if (sd.StructureType == StructureType.Structure && ii.IsOptional)
                        {
                            sd.StructureType = StructureType.StructureWithOptionalFields;
                        }

                        sd.Fields.Add(field);
                    }

                    definition = sd;
                }
                else
                {
                    var ed = new EnumDefinition();
                    ed.Fields = new EnumFieldCollection();

                    foreach (var ii in input.Field)
                    {
                        var field = new EnumField()
                        {
                            Name = ii.Name,
                            Value = ii.Value
                        };

                        var displayNames = Import(ii.DisplayName);

                        if (displayNames != null && displayNames.Count > 0)
                        {
                            if (!String.IsNullOrEmpty(displayNames[0].Locale))
                            {
                                if (field.Name != displayNames[0].Text)
                                {
                                    field.DisplayName = displayNames[0];
                                }
                            }
                        }

                        var descriptions = Import(ii.Description);

                        if (descriptions != null && descriptions.Count > 0)
                        {
                            field.Description = descriptions[0];
                        }

                        ed.Fields.Add(field);
                    }

                    definition = ed;
                }
            }

            return definition;
        }

        private UADataType Import(Opc.Ua.Export.UADataType input)
        {
            UADataType output = new UADataType()
            {
                IsAbstract = input.IsAbstract,
            };

            if (input.Definition != null)
            {
                var encodeble = Import(input.Definition);
                output.Definition = new ExtensionObject(encodeble.TypeId, encodeble);
            }

            return output;
        }

        private UANode Import(Opc.Ua.Export.UANode input)
        {
            UANode output = null;

            switch (input.GetType().Name)
            {
                case "UAObject":
                {
                    output = Import((Opc.Ua.Export.UAObject)input);
                    break;
                }

                case "UAVariable":
                {
                    output = Import((Opc.Ua.Export.UAVariable)input);
                    break;
                }

                case "UAMethod":
                {
                    output = Import((Opc.Ua.Export.UAMethod)input);
                    break;
                }

                case "UAView":
                {
                    output = Import((Opc.Ua.Export.UAView)input);
                    break;
                }

                case "UAObjectType":
                {
                    output = Import((Opc.Ua.Export.UAObjectType)input);
                    break;
                }

                case "UAVariableType":
                {
                    output = Import((Opc.Ua.Export.UAVariableType)input);
                    break;
                }

                case "UAReferenceType":
                {
                    output = Import((Opc.Ua.Export.UAReferenceType)input);
                    break;
                }

                case "UADataType":
                {
                    output = Import((Opc.Ua.Export.UADataType)input);
                    break;
                }
            }

            output.NodeId = ImportNodeId(input.NodeId);
            output.SymbolicName = input.SymbolicName;
            output.BrowseName = QualifiedName.Parse(input.BrowseName);
            output.DisplayNames = Import(input.DisplayName);
            output.Descriptions = Import(input.Description);
            output.Documentation = input.Documentation;
            output.WriteMask = input.WriteMask;
            output.RolePermissions = Import(input.RolePermissions);
            output.AccessRestrictions = input.AccessRestrictions;

            if (output.DisplayNames != null && output.DisplayNames.Count == 1)
            {
                if (String.IsNullOrEmpty(output.DisplayNames[0].Locale))
                {
                    if (output.BrowseName.Name == output.DisplayNames[0].Text)
                    {
                        output.DisplayNames = null;
                    }
                }
            }

            if (input.References != null)
            {
                output.References = new UAReferenceCollection();

                foreach (var ii in input.References)
                {
                    output.References.Add(new UAReference()
                    {
                        TargetId = ImportNodeId(ii.Value),
                        ReferenceTypeId = ImportNodeId(ii.ReferenceType),
                        IsForward = ii.IsForward
                    });
                }
            }

            return output;
        }

        public UANodeSet Convert(Opc.Ua.Export.UANodeSet input)
        {
            SystemContext = new SystemContext();
            SystemContext.NamespaceUris = new NamespaceTable();
            SystemContext.ServerUris = new StringTable();
            SystemContext.NamespaceUris.Append(Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

            Aliases = new Dictionary<string, NodeId>();

            if (input.NamespaceUris != null)
            {
                foreach (var ii in input.NamespaceUris)
                {
                    SystemContext.NamespaceUris.GetIndexOrAppend(ii);
                }
            }

            if (input.ServerUris != null)
            {
                foreach (var ii in input.ServerUris)
                {
                    SystemContext.ServerUris.GetIndexOrAppend(ii);
                }
            }

            if (input.Aliases != null)
            {
                foreach (var ii in input.Aliases)
                {
                    Aliases[ii.Alias] = NodeId.Parse(ii.Value);
                }
            }

            var output = new UANodeSet();

            output.NamespaceUris = input.NamespaceUris;
            output.ServerUris = input.ServerUris;
            output.LastModified = input.LastModified;
            output.Models = new ModelTableEntryCollection();

            if (input.Models != null)
            {
                foreach (var ii in input.Models)
                {
                    output.Models.Add(Import(ii));
                }
            }

            output.Nodes = new ExtensionObjectCollection();

            if (input.Items != null)
            {
                foreach (var ii in input.Items)
                {
                    var encodeble = Import(ii);
                    output.Nodes.Add(new ExtensionObject(encodeble.TypeId, encodeble));
                }
            }

            return output;
        }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            NodeSetConvertor convertor = new NodeSetConvertor();

            Opc.Ua.Export.UANodeSet input = null;

            using (Stream istrm = File.Open(@"D:\Work\OPC\nodesets\master\Provisioning\Opc.Ua.Provisioning.NodeSet2.xml", FileMode.Open))
            {
                input = Opc.Ua.Export.UANodeSet.Read(istrm);
            }

            var nodeset = convertor.Convert(input);

            ServiceMessageContext context = new ServiceMessageContext();
            context.NamespaceUris = convertor.SystemContext.NamespaceUris;
            context.ServerUris = convertor.SystemContext.ServerUris;
            context.Factory = convertor.SystemContext.EncodeableFactory;

            using (Stream istrm = File.Open(@"D:\Work\OPC\nodesets\master\Provisioning\Opc.Ua.Provisioning.NodeSet2.json", FileMode.Create))
            {
                using (JsonEncoder encoder = new JsonEncoder(context, false, new StreamWriter(istrm)))
                {
                    encoder.IncludeDefaultValues = false;
                    encoder.IncludeDefaultNumberValues = false;
                    nodeset.Encode(encoder);
                }
            }
        }
    }
}
