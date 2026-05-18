using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration.Attributes;
using CsvHelper.Configuration;
using Opc.Ua;
using System.Xml;
using System.Text;
using System.Xml.Serialization;

namespace ModelCompiler
{
    public static class BatteryPassportReader
    {
        public static void Generate(string targetDirectory)
        {
            const string DefaultUri = "http://opcfoundation.org/UA/";
            const string BatteryPassportUri = "http://opcfoundation.org/UA/BatteryPassport/";
            var context = ServiceMessageContext.GlobalContext;
            context.NamespaceUris.Append(BatteryPassportUri);

            ModelDesign design = new ModelDesign();

            design.TargetNamespace = BatteryPassportUri;
            design.TargetVersion = "1.00.00";
            design.TargetPublicationDate = DateTime.UtcNow;
            design.TargetPublicationDateSpecified = true;

            design.Namespaces = [
                new Namespace
                {
                    Name = "BatteryPassport",
                    Prefix = "BatteryPassport",
                    XmlPrefix = "BatteryPassport",
                    Version = "1.00.00",
                    PublicationDate = "2024-04-12T00:00:00Z",
                    Value = BatteryPassportUri
                },
                new Namespace
                {
                    Name = "OpcUa",
                    Prefix = "Opc.Ua",
                    XmlPrefix = "OpcUa",
                    Version = "1.05.02",
                    PublicationDate = "2022-06-28T00:00:00Z",
                    InternalPrefix = "Opc.Ua.Server",
                    XmlNamespace = "http://opcfoundation.org/UA/2008/02/Types.xsd",
                    Value = "http://opcfoundation.org/UA/"
                }
            ];

            var records = Load(Path.Combine(targetDirectory, @"2023_Battery_Passport_Data_Attributes.csv"));

            var nodes = new List<NodeDesign>();

            var od = new ObjectDesign()
            {
                SymbolicName = new XmlQualifiedName("Batteries", BatteryPassportUri),
                TypeDefinition = new XmlQualifiedName("FolderType", DefaultUri),
                References =
                [
                    new Reference()
                    {
                        ReferenceType = new XmlQualifiedName("Organizes", DefaultUri),
                        IsInverse = true,
                        TargetId = new XmlQualifiedName("ObjectsFolder", DefaultUri)
                    }
                ]
            };

            nodes.Add(od);

            var ot = new ObjectTypeDesign()
            {
                SymbolicName = new XmlQualifiedName("BatteryCurrentStateType", BatteryPassportUri),
                BaseType = new XmlQualifiedName("BaseObjectType", DefaultUri),
                IsAbstract = false
            };

            nodes.Add(ot);

            List<InstanceDesign> children = new();

            var vd = new VariableDesign()
            {
                SymbolicName = new XmlQualifiedName("Temperature", BatteryPassportUri),
                TypeDefinition = new XmlQualifiedName("AnalogUnitRangeType", DefaultUri),
                DataType = new XmlQualifiedName("Double", DefaultUri),
                ValueRank = ModelCompiler.ValueRank.Scalar,
                ValueRankSpecified = true,
                ModellingRule = ModellingRule.Mandatory,
                ModellingRuleSpecified = true
            };

            children.Add(vd);
            
            vd = new VariableDesign()
            {
                SymbolicName = new XmlQualifiedName("Voltage", BatteryPassportUri),
                TypeDefinition = new XmlQualifiedName("AnalogUnitRangeType", DefaultUri),
                DataType = new XmlQualifiedName("Double", DefaultUri),
                ValueRank = ModelCompiler.ValueRank.Scalar,
                ValueRankSpecified = true,
                ModellingRule = ModellingRule.Mandatory,
                ModellingRuleSpecified = true
            };

            children.Add(vd);

            vd = new VariableDesign()
            {
                SymbolicName = new XmlQualifiedName("ChargeRemaining", BatteryPassportUri),
                TypeDefinition = new XmlQualifiedName("AnalogUnitRangeType", DefaultUri),
                DataType = new XmlQualifiedName("Double", DefaultUri),
                ValueRank = ModelCompiler.ValueRank.Scalar,
                ValueRankSpecified = true,
                ModellingRule = ModellingRule.Mandatory,
                ModellingRuleSpecified = true
            };

            children.Add(vd);

            vd = new VariableDesign()
            {
                SymbolicName = new XmlQualifiedName("TimeRemaining", BatteryPassportUri),
                TypeDefinition = new XmlQualifiedName("AnalogItemType", DefaultUri),
                DataType = new XmlQualifiedName("Double", DefaultUri),
                ValueRank = ModelCompiler.ValueRank.Scalar,
                ValueRankSpecified = true,
                ModellingRule = ModellingRule.Mandatory,
                ModellingRuleSpecified = true
            };

            children.Add(vd);

            vd = new VariableDesign()
            {
                SymbolicName = new XmlQualifiedName("PowerOut", BatteryPassportUri),
                TypeDefinition = new XmlQualifiedName("AnalogUnitRangeType", DefaultUri),
                DataType = new XmlQualifiedName("Double", DefaultUri),
                ValueRank = ModelCompiler.ValueRank.Scalar,
                ValueRankSpecified = true,
                ModellingRule = ModellingRule.Mandatory,
                ModellingRuleSpecified = true
            };

            children.Add(vd);

            vd = new VariableDesign()
            {
                SymbolicName = new XmlQualifiedName("PowerIn", BatteryPassportUri),
                TypeDefinition = new XmlQualifiedName("AnalogUnitRangeType", DefaultUri),
                DataType = new XmlQualifiedName("Double", DefaultUri),
                ValueRank = ModelCompiler.ValueRank.Scalar,
                ValueRankSpecified = true,
                ModellingRule = ModellingRule.Mandatory,
                ModellingRuleSpecified = true
            };

            children.Add(vd);

            ot.Children = new ListOfChildren() { Items = children.ToArray() };

            ot = new ObjectTypeDesign()
            {
                SymbolicName = new XmlQualifiedName("BatteryType", BatteryPassportUri),
                BaseType = new XmlQualifiedName("BaseObjectType", DefaultUri),
                IsAbstract = false
            };
            
            nodes.Add(ot);
            children = new();

            od = new ObjectDesign()
            {
                SymbolicName = new XmlQualifiedName("Package", BatteryPassportUri),
                TypeDefinition = new XmlQualifiedName("FileType", DefaultUri),
                ModellingRule = ModellingRule.Mandatory,
                ModellingRuleSpecified = true
            };

            children.Add(od);

            od = new ObjectDesign()
            {
                SymbolicName = new XmlQualifiedName("CurrentState", BatteryPassportUri),
                TypeDefinition = new XmlQualifiedName("BatteryCurrentStateType", BatteryPassportUri),
                ModellingRule = ModellingRule.Mandatory,
                ModellingRuleSpecified = true
            };

            children.Add(od);

            od = new ObjectDesign()
            {
                SymbolicName = new XmlQualifiedName("Passport", BatteryPassportUri),
                TypeDefinition = new XmlQualifiedName("BatteryPassportType", BatteryPassportUri),
                ModellingRule = ModellingRule.Mandatory,
                ModellingRuleSpecified = true
            };

            children.Add(od);
            ot.Children = new ListOfChildren() { Items = children.ToArray() };

            ot = new ObjectTypeDesign()
            {
                SymbolicName = new XmlQualifiedName("SubmodelType", BatteryPassportUri),
                BaseType = new XmlQualifiedName("BaseObjectType", DefaultUri),
                IsAbstract = true
            };

            nodes.Add(ot);

            var vt = new VariableTypeDesign()
            {
                SymbolicName = new XmlQualifiedName("SubmodelPropertyType", BatteryPassportUri),
                BaseType = new XmlQualifiedName("BaseDataVariableType", DefaultUri)
            };

            nodes.Add(vt);

            Dictionary<string, VariableDesign> properties = new()
            {
                ["Id"] = new VariableDesign()
                {
                    SymbolicName = new XmlQualifiedName("Id", BatteryPassportUri),
                    TypeDefinition = new XmlQualifiedName("PropertyType", DefaultUri),
                    DataType = new XmlQualifiedName("UInt32", DefaultUri),
                    ValueRank = ModelCompiler.ValueRank.Scalar,
                    ValueRankSpecified = true,
                    ModellingRule = ModellingRule.Optional,
                    ModellingRuleSpecified = true
                },
                ["SubCategory"] = new VariableDesign()
                {
                    SymbolicName = new XmlQualifiedName("SubCategory", BatteryPassportUri),
                    TypeDefinition = new XmlQualifiedName("PropertyType", DefaultUri),
                    DataType = new XmlQualifiedName("String", DefaultUri),
                    ValueRank = ModelCompiler.ValueRank.Scalar,
                    ValueRankSpecified = true,
                    ModellingRule = ModellingRule.Optional,
                    ModellingRuleSpecified = true
                },
                ["Definition"] = new VariableDesign()
                {
                    SymbolicName = new XmlQualifiedName("Definition", BatteryPassportUri),
                    TypeDefinition = new XmlQualifiedName("PropertyType", DefaultUri),
                    DataType = new XmlQualifiedName("LocalizedText", DefaultUri),
                    ValueRank = ModelCompiler.ValueRank.Scalar,
                    ValueRankSpecified = true,
                    ModellingRule = ModellingRule.Optional,
                    ModellingRuleSpecified = true
                },
                ["Requirements"] = new VariableDesign()
                {
                    SymbolicName = new XmlQualifiedName("Requirements", BatteryPassportUri),
                    TypeDefinition = new XmlQualifiedName("PropertyType", DefaultUri),
                    DataType = new XmlQualifiedName("LocalizedText", DefaultUri),
                    ValueRank = ModelCompiler.ValueRank.Scalar,
                    ValueRankSpecified = true,
                    ModellingRule = ModellingRule.Optional,
                    ModellingRuleSpecified = true
                },
                ["Regulations"] = new VariableDesign()
                {
                    SymbolicName = new XmlQualifiedName("Regulations", BatteryPassportUri),
                    TypeDefinition = new XmlQualifiedName("PropertyType", DefaultUri),
                    DataType = new XmlQualifiedName("LocalizedText", DefaultUri),
                    ValueRank = ModelCompiler.ValueRank.Scalar,
                    ValueRankSpecified = true,
                    ModellingRule = ModellingRule.Optional,
                    ModellingRuleSpecified = true
                },
                ["AccessRights"] = new VariableDesign()
                {
                    SymbolicName = new XmlQualifiedName("AccessRights", BatteryPassportUri),
                    TypeDefinition = new XmlQualifiedName("PropertyType", DefaultUri),
                    DataType = new XmlQualifiedName("String", DefaultUri),
                    ValueRank = ModelCompiler.ValueRank.Scalar,
                    ValueRankSpecified = true,
                    ModellingRule = ModellingRule.Optional,
                    ModellingRuleSpecified = true
                },
                ["Behaviour"] = new VariableDesign()
                {
                    SymbolicName = new XmlQualifiedName("Behaviour", BatteryPassportUri),
                    TypeDefinition = new XmlQualifiedName("PropertyType", DefaultUri),
                    DataType = new XmlQualifiedName("String", DefaultUri),
                    ValueRank = ModelCompiler.ValueRank.Scalar,
                    ValueRankSpecified = true,
                    ModellingRule = ModellingRule.Optional,
                    ModellingRuleSpecified = true
                },
                ["Granularity"] = new VariableDesign()
                {
                    SymbolicName = new XmlQualifiedName("Granularity", BatteryPassportUri),
                    TypeDefinition = new XmlQualifiedName("PropertyType", DefaultUri),
                    DataType = new XmlQualifiedName("String", DefaultUri),
                    ValueRank = ModelCompiler.ValueRank.Scalar,
                    ValueRankSpecified = true,
                    ModellingRule = ModellingRule.Optional,
                    ModellingRuleSpecified = true
                },
                ["Pack"] = new VariableDesign()
                {
                    SymbolicName = new XmlQualifiedName("Pack", BatteryPassportUri),
                    TypeDefinition = new XmlQualifiedName("PropertyType", DefaultUri),
                    DataType = new XmlQualifiedName("Boolean", DefaultUri),
                    ValueRank = ModelCompiler.ValueRank.Scalar,
                    ValueRankSpecified = true,
                    ModellingRule = ModellingRule.Optional,
                    ModellingRuleSpecified = true
                },
                ["Module"] = new VariableDesign()
                {
                    SymbolicName = new XmlQualifiedName("Module", BatteryPassportUri),
                    TypeDefinition = new XmlQualifiedName("PropertyType", DefaultUri),
                    DataType = new XmlQualifiedName("Boolean", DefaultUri),
                    ValueRank = ModelCompiler.ValueRank.Scalar,
                    ValueRankSpecified = true,
                    ModellingRule = ModellingRule.Optional,
                    ModellingRuleSpecified = true
                },
                ["Cell"] = new VariableDesign()
                {
                    SymbolicName = new XmlQualifiedName("Cell", BatteryPassportUri),
                    TypeDefinition = new XmlQualifiedName("PropertyType", DefaultUri),
                    DataType = new XmlQualifiedName("Boolean", DefaultUri),
                    ValueRank = ModelCompiler.ValueRank.Scalar,
                    ValueRankSpecified = true,
                    ModellingRule = ModellingRule.Optional,
                    ModellingRuleSpecified = true
                },
                ["Unit"] = new VariableDesign()
                {
                    SymbolicName = new XmlQualifiedName("EngineeringUnits", DefaultUri),
                    TypeDefinition = new XmlQualifiedName("PropertyType", DefaultUri),
                    DataType = new XmlQualifiedName("EUInformation", DefaultUri),
                    ValueRank = ModelCompiler.ValueRank.Scalar,
                    ValueRankSpecified = true,
                    ModellingRule = ModellingRule.Optional,
                    ModellingRuleSpecified = true
                }
            };

            vt.Children = new ListOfChildren() { Items = properties.Values.ToArray() };

            var bpot = new ObjectTypeDesign()
            {
                SymbolicName = new XmlQualifiedName("BatteryPassportType", BatteryPassportUri),
                BaseType = new XmlQualifiedName("SubmodelType", BatteryPassportUri),
                IsAbstract = false
            };

            nodes.Add(bpot);

            var bpdt = new DataTypeDesign()
            {
                SymbolicName = new XmlQualifiedName("BatteryPassportDataType", BatteryPassportUri),
                BaseType = new XmlQualifiedName("Structure", DefaultUri),
                IsAbstract = false
            };

            nodes.Add(bpdt);

            List<InstanceDesign> bpotChildren = new();
            List<Parameter> bpdtFields = new();

            foreach (var category in records.Select(x => x.Category).OrderBy(x => x).Distinct())
            {
                var symbol = ToSymbol(category);

                ot = new ObjectTypeDesign()
                {
                    SymbolicName = new XmlQualifiedName($"{symbol}Type", BatteryPassportUri),
                    BaseType = new XmlQualifiedName("SubmodelType", BatteryPassportUri),
                    IsAbstract = false
                };

                nodes.Add(ot);
                children = new();

                var bpotChild = new ObjectDesign()
                {
                    SymbolicName = new XmlQualifiedName($"{symbol}", BatteryPassportUri),
                    TypeDefinition = ot.SymbolicName
                };

                bpotChildren.Add(bpotChild);

                var bpdtField = new Parameter()
                {
                    Name = symbol,
                    DisplayName = new LocalizedText() { Value = category },
                    DataType = new XmlQualifiedName($"{symbol}DataType", BatteryPassportUri),
                    ValueRank = ModelCompiler.ValueRank.Scalar,
                };

                bpdtFields.Add(bpdtField);

                DataTypeDesign dt = new DataTypeDesign()
                {
                    SymbolicName = new XmlQualifiedName($"{symbol}DataType", BatteryPassportUri),
                    BaseType = new XmlQualifiedName("Structure", DefaultUri),
                    IsAbstract = false
                };

                nodes.Add(dt);
                List<Parameter> fields = new();

                foreach (var ii in records.Where(x => x.Category == category).OrderBy(x => x.Id))
                {
                    symbol = ToSymbol(ii.Name);

                    vd = new VariableDesign()
                    {
                        SymbolicName = new XmlQualifiedName(symbol, BatteryPassportUri),
                        DisplayName = new LocalizedText() { Value = ii.Name },
                        TypeDefinition = new XmlQualifiedName("SubmodelPropertyType", BatteryPassportUri),
                        DataType = ToDataType(ii.DataFormat),
                        ValueRank = ModelCompiler.ValueRank.Scalar,
                        ValueRankSpecified = true,
                        ModellingRule = ModellingRule.Mandatory,
                        ModellingRuleSpecified = true
                    };

                    children.Add(vd);

                    List<InstanceDesign> grandchildren = new();

                    foreach (var property in properties)
                    {
                        var value = ii.GetType().GetField(property.Key).GetValue(ii);

                        if (property.Key == "Unit")
                        {
                            if (ii.Unit == "-")
                            {
                                continue;
                            }

                            value = new EUInformation()
                            {
                                DisplayName = new Opc.Ua.LocalizedText(ii.Unit),
                                NamespaceUri = BatteryPassportUri,
                                UnitId = ii.Unit.GetHashCode(),
                            };
                        }
            
                        var pv = new VariableDesign()
                        {
                            SymbolicName = property.Value.SymbolicName,
                            TypeDefinition = property.Value.TypeDefinition,
                            DataType = property.Value.DataType,
                            ValueRank = property.Value.ValueRank,
                            ValueRankSpecified = true,
                            ModellingRule = ModellingRule.Mandatory,
                            ModellingRuleSpecified = true
                        };

                        if (pv.DataType == new XmlQualifiedName("LocalizedText", DefaultUri))
                        {
                            value = new Opc.Ua.LocalizedText(value as string);
                        }
                        else if (pv.DataType == new XmlQualifiedName("UInt32", DefaultUri))
                        {
                            value = UInt32.Parse(value as string);
                        }
                        else if (pv.DataType == new XmlQualifiedName("Int64", DefaultUri))
                        {
                            value = Int64.Parse(value as string);
                        }
                        else if (pv.DataType == new XmlQualifiedName("Double", DefaultUri))
                        {
                            value = Double.Parse(value as string);
                        }
                        else if (pv.DataType == new XmlQualifiedName("Boolean", DefaultUri))
                        {
                            value = String.IsNullOrEmpty(value as string) ? false : true;
                        }

                        pv.DefaultValue = EncodeValue(context, new Variant(value));
                        grandchildren.Add(pv);
                    }

                    vd.Children = new ListOfChildren() { Items = grandchildren.ToArray() };
                }

                ot.Children = new ListOfChildren() { Items = children.ToArray() };

                foreach (var ii in records.Where(x => x.Category == category).OrderBy(x => x.Id))
                {
                    symbol = ToSymbol(ii.Name);

                    var field = new Parameter()
                    {
                        Name = symbol,
                        DisplayName = new LocalizedText() { Value = ii.Name },
                        DataType = ToDataType(ii.DataFormat),
                        ValueRank = ModelCompiler.ValueRank.Scalar,
                    };

                    fields.Add(field);
                }

                dt.Fields = fields.ToArray();
            }

            bpot.Children = new ListOfChildren() { Items = bpotChildren.ToArray() };
            bpdt.Fields = bpdtFields.ToArray();

            design.Items = nodes.ToArray();

            using (var ostrm = File.Create(Path.Combine(targetDirectory, "BatteryPassport.xml")))
            {
                Save(ostrm, design, BatteryPassportUri);
            }
        }

        private static void Save<T>(Stream stream, T input, string defaultNs)
        {
            var settings = new XmlWriterSettings()
            {
                IndentChars = "  ",
                Indent = true,
                Encoding = System.Text.Encoding.UTF8,
                CloseOutput = true,
                NamespaceHandling = NamespaceHandling.OmitDuplicates
            };

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(
                    writer, 
                    input, 
                    new XmlSerializerNamespaces(
                    [
                        new XmlQualifiedName("", defaultNs),
                        new XmlQualifiedName("ua", "http://opcfoundation.org/UA/"),
                        new XmlQualifiedName("opc", "http://opcfoundation.org/UA/ModelDesign.xsd"),
                        new XmlQualifiedName("uax", "http://opcfoundation.org/UA/2008/02/Types.xsd")
                    ]));
            }
        }

        private static XmlQualifiedName ToDataType(string text)
        {
            text = text?.Trim();

            if (String.IsNullOrEmpty(text))
            {
                return new XmlQualifiedName("BaseDataType", Opc.Ua.Namespaces.OpcUa);
            }

            switch (text)
            {
                case "ID":
                case "Representation to document":
                case "Representation to document (and string)":
                case "Representation to image":
                case "Representation to file":
                    return new XmlQualifiedName("UriString", Opc.Ua.Namespaces.OpcUa);
                case "Date time":
                    return new XmlQualifiedName("DateTime", Opc.Ua.Namespaces.OpcUa);
                case "Text":
                case "String":
                case "String or ID":
                case "String and/or integer":
                    return new XmlQualifiedName("String", Opc.Ua.Namespaces.OpcUa);
                case "Decimal":
                    return new XmlQualifiedName("Double", Opc.Ua.Namespaces.OpcUa);
                case "Integer":
                    return new XmlQualifiedName("Int64", Opc.Ua.Namespaces.OpcUa);
                default:
                    return new XmlQualifiedName("BaseDataType", Opc.Ua.Namespaces.OpcUa);
            }
        }

        public static XmlElement EncodeValue(IServiceMessageContext context, Variant value)
        {
            using (XmlEncoder encoder = new XmlEncoder(context))
            {
                encoder.WriteVariantContents(value.Value, value.TypeInfo);
                XmlDocument document = new XmlDocument();
                document.LoadInnerXml(encoder.CloseAndReturnText());
                return document.DocumentElement;
            }
        }

        internal static string ToSymbol(string text)
        {
            StringBuilder sb = new StringBuilder();

            bool first = true;

            foreach (var c in text)
            {
                if (Char.IsLetterOrDigit(c))
                {
                    if (first)
                    {
                        sb.Append(Char.ToUpperInvariant(c));
                        first = false;
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                else if (c == '\'' || c == '’')
                {
                    first = false;
                }
                else if (Char.IsWhiteSpace(c))
                {
                    first = true;
                }
                else
                {
                    sb.Append('_');
                    first = true;
                }
            }

            return sb.ToString().Trim('_');
        }

        private static void Append(string filepath, IList<Attribute> results)
        {
            using (var istrm = new StreamReader(filepath))
            {
                using (var csv = new CsvReader(istrm, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<AttributeMap>();
                    var records = csv.GetRecords<Attribute>().ToList();

                    foreach (var ii in records)
                    {
                        results.Add(ii);
                    }
                }
            }
        }

        public static IList<Attribute> Load(params string[] filepaths)
        {
            IList<Attribute> records = new List<Attribute>();

            foreach (var filepath in filepaths)
            {
                Append(filepath, records);
            }

            return records;
        }
    }




    public class Attribute
    {
        [Name("ID")]
        public string Id;
        [Name("EV")]
        public string Ev;
        [Name("LMT")]
        public string Lmt;
        [Name("Industrial")]
        public string Industrial;
        [Name("Stationary")]
        public string Stationary;
        [Name("Category")]
        public string Category;
        [Name("SubCategory")]
        public string SubCategory;
        [Name("Attribute")]
        public string Name;
        [Name("Definition")]
        public string Definition;
        [Name("Requirements")]
        public string Requirements;
        [Name("Regulations")]
        public string Regulations;
        [Name("Unit")]
        public string Unit;
        [Name("DataFormat")]
        public string DataFormat;
        [Name("AccessRights")]
        public string AccessRights;
        [Name("Behaviour")]
        public string Behaviour;
        [Name("Granularity")]
        public string Granularity;
        [Name("Pack")]
        public string Pack;
        [Name("Module")]
        public string Module;
        [Name("Cell")]
        public string Cell;
    }

    public sealed class AttributeMap : ClassMap<Attribute>
    {
        public AttributeMap()
        {
            Map(m => m.Id).Name("ID");
            Map(m => m.Name).Name("Attribute");
            Map(m => m.Category).Name("Category");
            Map(m => m.SubCategory).Name("SubCategory");
            Map(m => m.Ev).Name("EV");
            Map(m => m.Lmt).Name("LMT");
            Map(m => m.Industrial).Name("Industrial");
            Map(m => m.Stationary).Name("Stationary");
            Map(m => m.Definition).Name("Definition");
            Map(m => m.Requirements).Name("Requirements");
            Map(m => m.Regulations).Name("Regulations");
            Map(m => m.Unit).Name("Unit");
            Map(m => m.DataFormat).Name("DataFormat");
            Map(m => m.AccessRights).Name("AccessRights");
            Map(m => m.Behaviour).Name("Behaviour");
            Map(m => m.Granularity).Name("Granularity");
            Map(m => m.Pack).Name("Pack");
            Map(m => m.Module).Name("Module");
            Map(m => m.Cell).Name("Cell");
        }
    }
}
