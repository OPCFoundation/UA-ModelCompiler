using Newtonsoft.Json;
using Opc.Ua;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace NodeSetTests
{
    public class JsonNodeSetSerializer
    {
        public IServiceMessageContext MessageContext;

        public void XmlToJson(string input, string output)
        {
            MessageContext = new ServiceMessageContext();

            Opc.Ua.Export.UANodeSet nodeset = null;

            using (Stream istrm = File.Open(input, FileMode.Open))
            {
                nodeset = Opc.Ua.Export.UANodeSet.Read(istrm);
            }

            var context = new ServiceMessageContext();
            var aliases = new Dictionary<string, string>();

            if (nodeset.NamespaceUris != null)
            {
                foreach (var ii in nodeset.NamespaceUris)
                {
                    context.NamespaceUris.Append(ii);
                    MessageContext.NamespaceUris.Append(ii);
                }
            }

            if (nodeset.ServerUris != null)
            {
                foreach (var ii in nodeset.ServerUris)
                {
                    context.ServerUris.Append(ii);
                    MessageContext.ServerUris.Append(ii);
                }
            }

            if (nodeset.Aliases != null)
            {
                foreach (var ii in nodeset.Aliases)
                {
                    aliases[ii.Alias] = ii.Value;
                }
            }

            List<object> elements = new List<object>();
            elements.Add(GetMetadata(nodeset));

            var nodelist = new JUANodeList();
            CopyNodes(context, aliases, nodeset.Items, nodelist);

            if (nodelist.ReferenceTypes != null)
            {
                elements.Add(new JUANodeList() { ReferenceTypes = nodelist.ReferenceTypes });
            }

            if (nodelist.DataTypes != null)
            {
                elements.Add(new JUANodeList() { DataTypes = nodelist.DataTypes });
            }

            if (nodelist.VariableTypes != null)
            {
                elements.Add(new JUANodeList() { VariableTypes = nodelist.VariableTypes });
            }

            if (nodelist.ObjectTypes != null)
            {
                elements.Add(new JUANodeList() { ObjectTypes = nodelist.ObjectTypes });
            }

            if (nodelist.Variables != null)
            {
                elements.Add(new JUANodeList() { Variables = nodelist.Variables });
            }

            if (nodelist.Methods != null)
            {
                elements.Add(new JUANodeList() { Methods = nodelist.Methods });
            }

            if (nodelist.Objects != null)
            {
                elements.Add(new JUANodeList() { Objects = nodelist.Objects });
            }

            if (nodelist.Views != null)
            {
                elements.Add(new JUANodeList() { Views = nodelist.Views });
            }

            if (nodelist.References != null)
            {
                elements.Add(new JUANodeList() { References = nodelist.References });
            }

            string json = JsonConvert.SerializeObject(
                elements,
                Newtonsoft.Json.Formatting.Indented,
                new JsonSerializerSettings()
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore
                });

            File.WriteAllText(output, json);
        }

        void CopyNodes(
            IServiceMessageContext context,
            IDictionary<string, string> aliases,
            IList<Opc.Ua.Export.UANode> input, 
            JUANodeList output)
        {
            foreach (var ii in input)
            {
                JUANode node = null;

                if (ii is Opc.Ua.Export.UAObject @on)
                {
                    if (output.Objects == null)
                    {
                        output.Objects = new List<JUAObject>();
                    }

                    node = new JUAObject()
                    {
                        EventNotifier = on.EventNotifier
                    };

                    output.Objects.Add(node as JUAObject);
                }
                else if (ii is Opc.Ua.Export.UAVariable @vn)
                {
                    if (output.Variables == null)
                    {
                        output.Variables = new List<JUAVariable>();
                    }

                    JUAVariable variable = new JUAVariable()
                    {
                        DataTypeId = ToNodeId(aliases, vn.DataType),
                        ValueRank = vn.ValueRank,
                        ArrayDimensions = (!String.IsNullOrEmpty(vn.ArrayDimensions)) ? vn.ArrayDimensions : null,
                        MinimumSamplingInterval = vn.MinimumSamplingInterval,
                        Historizing = vn.Historizing,
                        AccessLevel = vn.AccessLevel
                    };

                    node = variable;

                    if (vn.Value != null)
                    {
                        XmlDecoder decoder = CreateDecoder(context, vn.Value);
                        var contents = decoder.ReadVariantContents(out TypeInfo typeInfo);
                        variable.Value = new Variant(contents, typeInfo);
                        decoder.Close();
                    }

                    output.Variables.Add(node as JUAVariable);
                }
                else if (ii is Opc.Ua.Export.UAMethod @mn)
                {
                    if (output.Methods == null)
                    {
                        output.Methods = new List<JUAMethod>();
                    }

                    node = new JUAMethod()
                    {
                        Executable = mn.Executable
                    };

                    output.Methods.Add(node as JUAMethod);
                }
                else if (ii is Opc.Ua.Export.UAView @wn)
                {
                    if (output.Views == null)
                    {
                        output.Views = new List<JUAView>();
                    }

                    node = new JUAView()
                    {
                        EventNotifier = wn.EventNotifier,
                        ContainsNoLoops = wn.ContainsNoLoops
                    };

                    output.Views.Add(node as JUAView);
                }
                else if (ii is Opc.Ua.Export.UAObjectType @ot)
                {
                    if (output.ObjectTypes == null)
                    {
                        output.ObjectTypes = new List<JUAObjectType>();
                    }

                    node = new JUAObjectType()
                    {
                        IsAbstract = ot.IsAbstract
                    };

                    output.ObjectTypes.Add(node as JUAObjectType);
                }
                else if (ii is Opc.Ua.Export.UAVariableType @vt)
                {
                    if (output.VariableTypes == null)
                    {
                        output.VariableTypes = new List<JUAVariableType>();
                    }

                    node = new JUAVariableType()
                    {
                        IsAbstract = vt.IsAbstract,
                        DataTypeId = ToNodeId(aliases, vt.DataType),
                        ValueRank = vt.ValueRank,
                        ArrayDimensions = (!String.IsNullOrEmpty(vt.ArrayDimensions)) ? vt.ArrayDimensions : null,
                    };

                    output.VariableTypes.Add(node as JUAVariableType);
                }
                else if (ii is Opc.Ua.Export.UADataType @dt)
                {
                    if (output.DataTypes == null)
                    {
                        output.DataTypes = new List<JUADataType>();
                    }

                    node = new JUADataType()
                    {
                        IsAbstract = dt.IsAbstract,
                        DataTypeDefinition = null
                    };

                    output.DataTypes.Add(node as JUADataType);
                }
                else if (ii is Opc.Ua.Export.UAReferenceType @rt)
                {
                    if (output.ReferenceTypes == null)
                    {
                        output.ReferenceTypes = new List<JUAReferenceType>();
                    }

                    node = new JUAReferenceType()
                    {
                        IsAbstract = rt.IsAbstract,
                        InverseName = ToLocalizedText(rt.InverseName),
                        Symmetric = rt.Symmetric
                    };

                    output.ReferenceTypes.Add(node as JUAReferenceType);
                }

                node.NodeId = ToNodeId(aliases, ii.NodeId);
                node.BrowseName = ii.BrowseName;
                node.SymbolicName = ii.SymbolicName;

                if (ii.DisplayName != null && ii.DisplayName.Length > 0)
                {
                    if (ii.DisplayName.Length > 1 || !String.IsNullOrEmpty(ii.DisplayName[0].Locale) || ii.DisplayName[0].Value != QualifiedName.Parse(ii.BrowseName).Name)
                    {
                        node.DisplayName = ToLocalizedText(ii.DisplayName);
                    }
                }

                if (ii.Description != null && ii.Description.Length > 0)
                {
                    node.Description = ToLocalizedText(ii.Description);
                }

                node.WriteMask = ii.WriteMask;
                node.Documentation = ii.Documentation;
                node.ConformanceUnits = (ii.Category != null) ? new List<string>(ii.Category) : null;

                if (ii.References != null)
                {
                    if (output.References == null)
                    {
                        output.References = new List<JUAReference>();
                    }

                    foreach (var reference in ii.References)
                    {
                        output.References.Add(new JUAReference()
                        {
                            SourceId = node.NodeId,
                            ReferenceTypeId = ToNodeId(aliases, reference.ReferenceType),
                            IsInverse = !reference.IsForward,
                            TargetId = ToNodeId(aliases, reference.Value)
                        });
                    }
                }
            } 
        }

        private XmlDecoder CreateDecoder(
            IServiceMessageContext context,
            XmlElement source)
        { 
            XmlDecoder decoder = new XmlDecoder(source, context);
            decoder.SetMappingTables(MessageContext.NamespaceUris, MessageContext.ServerUris);
            return decoder;
        }

        static JMetaData GetMetadata(Opc.Ua.Export.UANodeSet input)
        {
            var metadata = new JMetaData()
            {
                NamespaceUris = new Dictionary<string, string>()
            };

            for (int ii = 0; ii < input.NamespaceUris.Length; ii++)
            {
                metadata.NamespaceUris[$"{ii}"] = input.NamespaceUris[ii];
            }

            if (input.ServerUris != null)
            {
                for (int ii = 0; ii < input.ServerUris.Length; ii++)
                {
                    metadata.ServerUris[$"{ii}"] = input.ServerUris[ii];
                }
            }

            var targetModel = input.Models[0];

            metadata.Model = new JTargetModel()
            {
                ModelUri = targetModel.ModelUri,
                PublicationDate = (targetModel.PublicationDateSpecified) ? targetModel.PublicationDate : DateTime.MinValue,
                Version = targetModel.Version
            };

            metadata.Model.RequiredModels = new List<JModel>();

            foreach (var model in targetModel.RequiredModel)
            {
                metadata.Model.RequiredModels.Add(new JModel()
                {
                    ModelUri = model.ModelUri,
                    PublicationDate = (model.PublicationDateSpecified) ? model.PublicationDate : DateTime.MinValue,
                    Version = model.Version
                });
            }

            return metadata;
        }

        static string ToNodeId(IDictionary<string, string> aliases, string input)
        {
            string alias;

            if (aliases.TryGetValue(input, out alias))
            {
                input = alias;
            }

            int start = input.IndexOf("ns=");

            if (start >= 0)
            {
                int end = input.IndexOf(";");

                if (end > 0)
                {
                    return $"{input.Substring(start + 3, end - 3)}:{input.Substring(end + 1)}";
                }
            }

            return $"0:{input}";
        }

        static List<string> ToLocalizedText(IList<Opc.Ua.Export.LocalizedText> input)
        {
            List<string> output = null;

            if (input != null && input.Count > 0)
            {
                output = new List<string>();

                foreach (var ii in input)
                {
                    output.Add($"{ii.Locale}:{ii.Value}");
                }
            }

            return output;
        }
    }

    class JRolePermission
    {
        [JsonProperty("ri")]
        public string RoleId;
        [JsonProperty("pm")]
        public uint Permissions;
    }

    class JAccessRights
    {
        [JsonProperty("ar")]
        public uint AccessRestrictions;
        [JsonProperty("rp")]
        public List<JRolePermission> RolePermissions;
    }

    class JModel
    {
        [JsonProperty("ns")]
        public string ModelUri;
        [JsonProperty("pd")]
        public DateTime PublicationDate;
        [JsonProperty("vn")]
        public string Version;
        [JsonProperty("rm")]
        public List<JModel> RequiredModels;
    }

    class JTargetModel : JModel
    {
        [JsonProperty("ar")]
        public JAccessRights DefaultAccessRules;
    }

    class JMetaData
    {
        [JsonProperty("ns")]
        public Dictionary<string, string> NamespaceUris;
        [JsonProperty("sv")]
        public Dictionary<string, string> ServerUris;
        [JsonProperty("tm")]
        public JTargetModel Model;
    }

    class JUANode
    {
        [JsonProperty("id")]
        public string NodeId;
        [JsonProperty("bn")]
        public string BrowseName;
        [JsonProperty("sn")]
        public string SymbolicName;
        [JsonProperty("dn")]
        public List<string> DisplayName;
        [JsonProperty("ds")]
        public List<string> Description;
        [JsonProperty("wm")]
        public uint WriteMask;
        [JsonProperty("ar")]
        public JAccessRights AccessRules;
        [JsonProperty("do")]
        public string Documentation;
        [JsonProperty("cu")]
        public List<string> ConformanceUnits;
        [JsonProperty("mr")]
        public byte MergeRule;
    }

    class JUAInstance : JUANode
    {
    }

    class JUAObject : JUAInstance
    {
        [JsonProperty("en")]
        public byte EventNotifier;
    }

    class JVariantConvertor : JsonConverter
    {
        public static ServiceMessageContext MessageContext = ServiceMessageContext.GlobalContext;

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Variant? variant = value as Variant?;

            if (variant != null)
            {
                JsonEncoder encoder = new JsonEncoder(MessageContext, true, true);
                // encoder.UseNodeSetEncoding = true;
                encoder.WriteVariant(null, variant.Value);
                var json = encoder.CloseAndReturnText();
                writer.WriteRawValue(json.Substring(1, json.Length - 2));
            }
        }

    }
    class JUAVariable : JUAInstance
    {
        [JsonProperty("va")]
        [JsonConverter(typeof(JVariantConvertor))]
        public Variant Value;
        [JsonProperty("dt")]
        public string DataTypeId;
        [JsonProperty("vr")]
        public int ValueRank;
        [JsonProperty("ad")]
        public string ArrayDimensions;
        [JsonProperty("al")]
        public uint AccessLevel;
        [JsonProperty("ai")]
        public double MinimumSamplingInterval;
        [JsonProperty("hi")]
        public bool Historizing;
    }

    class JUAMethod : JUAInstance
    {
        [JsonProperty("ex")]
        public bool Executable;
    }

    class JUAView : JUAInstance
    {
        [JsonProperty("en")]
        public byte EventNotifier;
        [JsonProperty("nl")]
        public bool ContainsNoLoops;
    }

    class JUAType : JUANode
    {
        [JsonProperty("ia")]
        public bool IsAbstract;
    }

    class JUAObjectType : JUAType
    {
    }

    class JUAVariableType : JUAType
    {
        [JsonProperty("va")]
        [JsonConverter(typeof(JVariantConvertor))]
        public Variant Value;
        [JsonProperty("dt")]
        public string DataTypeId;
        [JsonProperty("vr")]
        public int ValueRank;
        [JsonProperty("ar")]
        public string ArrayDimensions;
    }

    class JUADataType : JUAType
    {
        [JsonProperty("df")]
        public object DataTypeDefinition;
    }

    class JUAReferenceType : JUAType
    {
        [JsonProperty("in")]
        public List<string> InverseName;
        [JsonProperty("sy")]
        public bool Symmetric;
    }

    class JUAReference
    {
        [JsonProperty("sn")]
        public string SourceId;
        [JsonProperty("rt")]
        public string ReferenceTypeId;
        [JsonProperty("in")]
        public bool IsInverse;
        [JsonProperty("tn")]
        public string TargetId;
        [JsonProperty("mr")]
        public byte MergeRule;
    }

    class JUANodeList
    {
        public List<JUAReferenceType> ReferenceTypes;
        public List<JUADataType> DataTypes;
        public List<JUAVariableType> VariableTypes;
        public List<JUAVariable> Variables;
        public List<JUAObjectType> ObjectTypes;
        public List<JUAObject> Objects;
        public List<JUAMethod> Methods;
        public List<JUAView> Views;
        public List<JUAReference> References;
    }

    class JUANodeSet
    {
    }
}
