using Opc.Ua;
using ModelCompiler;
using TestModel;
using System.Xml;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Net.Http.Headers;
using Microsoft.Testing.Platform.Extensions.Messages;

namespace SchemaGeneration.Tests
{
    [TestClass]
    public sealed class JsonSchemaReferenceTests
    {
        const string CoreSchemaReference = "https://opcfoundation.org/schemas/OpenApi/opc.ua.services.jsonschema.json";

        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void TestOptionalFields(bool verbose)
        {
            ExtendedWorkOrderType input = new()
            {
                ID = new Uuid(Guid.NewGuid()),
                AssetID = "Asset001",
                StartTime = DateTime.Now,
                StatusComments = [
                    new WorkOrderStatusType() 
                    { 
                        Actor = "Bob", 
                        Comment ="Started work.", 
                        Timestamp = DateTime.Now 
                    } 
                ],
                EncodingMask = (uint)(ExtendedWorkOrderFields.ContactY),
                ContactX = 1234,
                ContactY = new StringCollection() { "Hello", "World" }
            };

            ServiceMessageContext context = new(GlobalSettings.Telemetry);
            context.NamespaceUris.Append(TestModel.Namespaces.TestModel);
            context.Factory.AddEncodeableTypes(typeof(TestStructure).Assembly);

            using BinaryEncoder encoder = new(context);
            input.Encode(encoder);
            byte[] buffer = encoder.CloseAndReturnBuffer();

            using BinaryDecoder decoder = new(buffer, context);
            ExtendedWorkOrderType output = new();
            output.Decode(decoder);
            decoder.Close();

            Assert.IsTrue(input.IsEqual(output));
        }

        [TestMethod]
        [Timeout(600000, CooperativeCancellation=true)]
        [DataRow(true)]
        [DataRow(false)]
        public void GenerateAndTestJsonSchema(bool verbose)
        {
            var folder = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            try
            {
                if (Directory.Exists(folder))
                {
                    Directory.Delete(folder, true);
                }

                var designFile = Path.GetTempFileName();
                File.Copy(Path.Combine("Data", "TestModel.xml"), designFile, true);

                var designFileCsv = Path.GetTempFileName();
                File.Copy(Path.Combine("Data", "TestModel.csv"), designFileCsv, true);

                var outputFolder = Path.Combine(folder, "output");

                string[] args = {
                    "compile",
                    "-d2",
                    designFile + ",TestModel",
                    "-cg",
                    designFileCsv,
                    "-version",
                    "v105",
                    "-exclude",
                    "Draft",
                    "-o2",
                    outputFolder
                };

                ModelCompilerApplication.Run(args).Wait();
                var outputFile = Path.Combine(outputFolder, "TestModel.NodeSet2.xml");
                Assert.IsTrue(File.Exists(outputFile));

                SystemContext context = new(GlobalSettings.Telemetry);
                string namespaceUri = "";

                using (Stream istrm = File.OpenRead(outputFile))
                {
                    Opc.Ua.Export.UANodeSet nodeSet = Opc.Ua.Export.UANodeSet.Read(istrm);
                    NodeStateCollection collection2 = new NodeStateCollection();
                    nodeSet.Import(context, collection2);
                    namespaceUri = nodeSet.NamespaceUris?.FirstOrDefault();
                    istrm.Close();
                }

                var path = Path.Combine("Data", "Opc.Ua.NodeSet2.Services.xml");
                File.Copy(path, Path.Combine(outputFolder, "Opc.Ua.NodeSet2.Services.xml"), true);

                args = new string[] {
                    "compile-nodesets",
                    "-input",
                    outputFolder,
                    "-uri",
                    namespaceUri,
                    "-o2",
                    Path.Combine(outputFolder, "generated")
                };

                ModelCompilerApplication.Run(args).Wait(); ;

                var schemaFile = Path.Combine(outputFolder, "generated", $"uamodel.testmodel.jsonschema{(verbose ? ".verbose" : "")}.json");
                Assert.IsTrue(File.Exists(schemaFile));

                var coreSchemaJson = File.ReadAllText(Path.Combine("Data", $"opc.ua.services.jsonschema{(verbose ? ".verbose" : "")}.json"));
                var coreSchema = JSchema.Parse(coreSchemaJson);

                JSchemaPreloadedResolver resolver = new();
                resolver.Add(new Uri(CoreSchemaReference), coreSchemaJson);

                var testSchemaJson = File.ReadAllText(schemaFile);
                testSchemaJson = testSchemaJson.Trim().TrimEnd('}').Trim();
                testSchemaJson += @",""$ref"": ""#/$defs/TestStructure""}";

                var testSchema = JSchema.Parse(
                    testSchemaJson,
                    new JSchemaReaderSettings() { Resolver = resolver, ResolveSchemaReferences = true });

                var sampleJson = GenerateSampleJson(!verbose);
                var parsedJson = JObject.Parse(sampleJson);
                IList<ValidationError> errors = null;
                Assert.IsTrue(parsedJson.IsValid(testSchema, out errors));
                Assert.HasCount(0, errors);

                sampleJson = sampleJson.Replace("true", @"""----""", StringComparison.InvariantCulture);
                parsedJson = JObject.Parse(sampleJson);
                Assert.IsFalse(parsedJson.IsValid(testSchema, out errors));
                Assert.HasCount(1, errors);
                Assert.HasCount(12, errors.First().ChildErrors);
            }
            finally
            {
                try
                {
                    Directory.Delete(folder, true);
                }
                catch
                {
                    // ignore
                }
            }
        }

        private void VerifySampleJson(string json, TestStructure original, bool useCompactEncoding)
        {
            ServiceMessageContext context = new(GlobalSettings.Telemetry);
            context.NamespaceUris.Append(TestModel.Namespaces.TestModel);
            context.Factory.AddEncodeableTypes(typeof(TestStructure).Assembly);

            var ns = context.NamespaceUris.GetIndexOrAppend("urn:tempuri.org:2024-01:hello;world");

            var encoding = useCompactEncoding ? JsonEncodingType.Compact : JsonEncodingType.Verbose;
            using var decoder = new JsonDecoder(json, context);

            TestStructure copy = new();
            copy.Decode(decoder);

            Assert.IsTrue(copy.IsEqual(original));
        }

        private string GenerateSampleJson(bool useCompactEncoding)
        {
            ServiceMessageContext context = new(GlobalSettings.Telemetry);
            context.NamespaceUris.Append(TestModel.Namespaces.TestModel);
            context.Factory.AddEncodeableTypes(typeof(TestStructure).Assembly);
            var ns = context.NamespaceUris.GetIndexOrAppend("urn:tempuri.org:2024-01:hello;world");

            var encoding = useCompactEncoding ? JsonEncodingType.Compact : JsonEncodingType.Verbose;
            using var encoder = new JsonEncoder(context, encoding);

            TestModel.TestStructure test = new()
            {
                A = CreateTestScalarStructure(context),
                B = CreateTestArrayStructure(context),
                C = new TestScalarStructure[] { CreateTestScalarStructure(context), CreateTestScalarStructure(context), CreateTestScalarStructure(context) },
                D = new TestArrayStructure[] { CreateTestArrayStructure(context), CreateTestArrayStructure(context), CreateTestArrayStructure(context) }
            };

            test.Encode(encoder);

            var json = encoder.CloseAndReturnText();
            VerifySampleJson(json, test, useCompactEncoding);
            return json;
        }

        private TestScalarStructure CreateTestScalarStructure(IServiceMessageContext context)
        {
            ushort ns = (ushort)(context.NamespaceUris.ToArray().Length - 1);

            var eo = new CurrencyUnitType()
            {
                Currency = "Dollar",
                AlphabeticCode = "USD",
                NumericCode = 840,
                Exponent = 2
            };

            var eo2 = new TestConcreteStructure()
            {
                A = 1,
                B = 2.234,
                C = "apple",
                D = 3,
                E = 3.14,
                F = "banana"
            };

            var eo3 = new TestConcreteStructure()
            {
                A = 3,
                B = 4.234,
                C = "orange",
                D = 4,
                E = 5.14,
                F = "green"
            };

            return new TestScalarStructure()
            {
                A = true,
                B = SByte.MaxValue,
                C = Byte.MaxValue,
                D = Int16.MaxValue,
                E = UInt16.MaxValue,
                F = Int32.MaxValue,
                G = UInt32.MaxValue,
                H = Int64.MaxValue,
                I = UInt64.MaxValue,
                J = Single.MaxValue,
                K = Double.MaxValue,
                L = (Uuid)Guid.NewGuid(),
                M = DateTime.UtcNow,
                N = "Test",
                O = Guid.NewGuid().ToByteArray(),
                P = new NodeId("Hello", ns),
                Q = new ExpandedNodeId("Hello", "urn:tempuri.org:2024-01:good bye;world"),
                R = new QualifiedName("Hello", ns),
                S = new Opc.Ua.LocalizedText("de", "Hello"),
                T = StatusCodes.BadAggregateNotSupported,
                U = null,
                V = new ExtensionObject(eo.TypeId, eo),
                W = new ExtensionObject(eo2.TypeId, eo2),
                X = eo3,
                Y = TestEnumeration.Blue,
                Z = (ulong)(TestOptionSet.A | TestOptionSet.B),
                A1 = new TestUnion() { SwitchField = TestUnionFields.B, B = 3.1415 },
                B1 = new TestOptionalFields()
                {
                    EncodingMask = (uint)(TestOptionalFieldsFields.B | TestOptionalFieldsFields.C),
                    B = 2.4567,
                    C = "Orange"
                },
                C1 = new DataValue()
                {
                    WrappedValue = 123.567,
                    ServerTimestamp = DateTime.UtcNow,
                    SourceTimestamp = DateTime.UtcNow,
                    StatusCode = StatusCodes.Good
                }
            };
        }

        private TestArrayStructure CreateTestArrayStructure(IServiceMessageContext context)
        {
            ushort ns = (ushort)(context.NamespaceUris.ToArray().Length - 1);

            var eo = new CurrencyUnitType()
            {
                Currency = "Dollar",
                AlphabeticCode = "USD",
                NumericCode = 840,
                Exponent = 2
            };

            var eo2 = new TestConcreteStructure()
            {
                A = 1,
                B = 2.234,
                C = "apple",
                D = 3,
                E = 3.14,
                F = "banana"
            };

            var eo3 = new TestConcreteStructure()
            {
                A = 3,
                B = 4.234,
                C = "orange",
                D = 4,
                E = 5.14,
                F = "green"
            };

            return new TestArrayStructure()
            {
                A = new Boolean[] { true, false, true },
                B = new SByte[] { SByte.MinValue, 0, SByte.MaxValue },
                C = new Byte[] { Byte.MinValue, (Byte)SByte.MaxValue, Byte.MaxValue },
                D = new Int16[] { Int16.MinValue, 0, Int16.MaxValue },
                E = new UInt16[] { UInt16.MinValue, (UInt16)Int16.MaxValue, UInt16.MaxValue },
                F = new Int32[] { Int32.MinValue, 0, Int32.MaxValue },
                G = new UInt32[] { UInt32.MinValue, (UInt32)SByte.MaxValue, UInt32.MaxValue },
                H = new Int64[] { Int64.MinValue, 0, Int64.MaxValue },
                I = new UInt64[] { UInt64.MinValue, (UInt64)Int64.MaxValue, UInt64.MaxValue },
                J = new Single[] { Single.MinValue, Single.Pi, Single.MaxValue },
                K = new Double[] { Double.MinValue, Double.Pi, Double.MaxValue },
                L = new Uuid[] { (Uuid)Guid.NewGuid(), (Uuid)Guid.NewGuid(), (Uuid)Guid.NewGuid() },
                M = new DateTime[] { DateTime.UtcNow, new DateTime(DateTime.Now.Ticks, DateTimeKind.Utc), DateTime.MaxValue },
                N = new String[] { "Red", "Yellow", "Green" },
                O = new byte[][] { Guid.NewGuid().ToByteArray(), Guid.NewGuid().ToByteArray(), Guid.NewGuid().ToByteArray() },
                P = new NodeId[] { new NodeId(1234U, ns), new NodeId("Hello", ns), new NodeId(Guid.NewGuid(), ns) },
                Q = new ExpandedNodeId[] { new ExpandedNodeId(1234U, 1), new ExpandedNodeId("Hello", "urn:tempuri.org:2024-01:good bye;world"), new ExpandedNodeId(Guid.NewGuid(), "urn:tempuri.org:2024-01:goodbye:world") },
                R = new QualifiedName[] { new QualifiedName("Red", ns), new QualifiedName("Yellow", ns), new QualifiedName("Green", ns) },
                S = new Opc.Ua.LocalizedText[] { new Opc.Ua.LocalizedText("en", "Red"), new Opc.Ua.LocalizedText("de", "Yellow"), new Opc.Ua.LocalizedText("jp", "Green") },
                T = new StatusCode[] { StatusCodes.BadAggregateInvalidInputs, StatusCodes.BadCertificateTimeInvalid, StatusCodes.BadAggregateNotSupported },
                U = new XmlElement[0],
                V = new Variant[] {
                    new ExtensionObject(eo.TypeId, new CurrencyUnitType()
                    {
                        Currency = "Dollar",
                        AlphabeticCode = "USD",
                        NumericCode = 840,
                        Exponent = 2
                    }),
                    new Variant(new Matrix(
                        new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2 },
                        BuiltInType.Int32,
                        new int[] { 2, 3, 2 }
                    )),
                    new Variant(new Matrix(
                        new ExtensionObject[] {
                            new ExtensionObject(eo.TypeId, new CurrencyUnitType()
                            {
                                Currency = "Euro",
                                AlphabeticCode = "EUR",
                                NumericCode = 654,
                                Exponent = 1
                            }),
                            new ExtensionObject(eo.TypeId, new CurrencyUnitType()
                            {
                                Currency = "Japanese Yen",
                                AlphabeticCode = "JPY",
                                NumericCode = 123,
                                Exponent = 0
                            })},
                        BuiltInType.ExtensionObject,
                        new int[] { 1, 2 }
                    ))
                },
                W = new ExtensionObjectCollection()
                {
                    new ExtensionObject(eo2.TypeId, eo2),
                    new ExtensionObject(eo2.TypeId, new TestConcreteStructure()
                    {
                        A = 1,
                        B = 2.234,
                        C = "red",
                        D = 3,
                        E = 3.14,
                        F = "blue"
                    }),
                    new ExtensionObject(eo2.TypeId, new TestConcreteStructure()
                    {
                        A = 1,
                        B = 2.234,
                        C = "dog",
                        D = 3,
                        E = 3.14,
                        F = "cat"
                    })
                },
                X = new(new TestConcreteStructure[]
                {
                    eo2,
                    eo3,
                    new TestConcreteStructure()
                    {
                        A = 1,
                        B = 2.234,
                        C = "dog",
                        D = 3,
                        E = 3.14,
                        F = "cat"
                    }
                }),
                Y = new TestEnumeration[] { TestEnumeration.Red, TestEnumeration.Green, TestEnumeration.Blue },
                Z = [(ulong)TestOptionSet.C, (ulong)(TestOptionSet.A | TestOptionSet.B), (ulong)0],
                A1 = [new TestUnion() { SwitchField = TestUnionFields.A, A = 1234 }, new TestUnion() { SwitchField = TestUnionFields.C, C = "Grape" }, new TestUnion() { SwitchField = TestUnionFields.B, B = 3.1415 }],
                B1 = [
                    new TestOptionalFields()
                    {
                        EncodingMask = (uint)(TestOptionalFieldsFields.A),
                        A = 12345
                    },
                    new TestOptionalFields()
                    {
                        EncodingMask = (uint)(TestOptionalFieldsFields.B | TestOptionalFieldsFields.C),
                        B = 2.4567,
                        C = "Orange"
                    },
                    new TestOptionalFields()
                    {
                        EncodingMask = (uint)(TestOptionalFieldsFields.A | TestOptionalFieldsFields.C),
                        A = 12345,
                        C = "Grape"
                    }
                ],
                C1 = new DataValue[]
                {
                    new DataValue()
                    {
                        WrappedValue = 123,
                        ServerTimestamp = DateTime.UtcNow,
                        StatusCode = StatusCodes.UncertainDataSubNormal
                    },
                    new DataValue()
                    {
                        WrappedValue = "unicorn",
                        SourceTimestamp = DateTime.UtcNow,
                        SourcePicoseconds = 1234,
                        StatusCode = StatusCodes.GoodCallAgain
                    },
                    new DataValue() {
                        WrappedValue = new ExtensionObject(TestModel.DataTypeIds.TestConcreteStructure, new TestConcreteStructure()
                        {
                            A = 6,
                            B = 10.234,
                            C = "rat",
                            D = 9,
                            E = 8.78,
                            F = "pop"
                        }),
                        StatusCode = StatusCodes.UncertainEngineeringUnitsExceeded,

                    },
                    new DataValue() {
                        WrappedValue = new Variant(new Matrix(
                            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2 },
                            BuiltInType.Int32,
                            new int[] { 2, 3, 2 }
                        )),
                        StatusCode = StatusCodes.UncertainDataSubNormal
                    }
                }
            };
        }
    }
}
