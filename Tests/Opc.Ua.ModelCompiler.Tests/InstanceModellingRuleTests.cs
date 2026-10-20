/* ========================================================================
 * Copyright (c) 2005-2026 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Opc.Ua;

namespace ModelCompiler
{
    /// <summary>
    /// Verifies that the InitializationString of a generated class keeps the modelling rules
    /// of its children (the instance declarations), so the stack can decide at runtime which
    /// children to instantiate (see OPCFoundation/UA-.NETStandard#3972).
    /// </summary>
    public class InstanceModellingRuleTests
    {
        private const string TestNamespace = "urn:opcfoundation.org:ModelCompiler:Tests:Issue3972";

        // TestMachineType
        //   Container (FolderType, Mandatory)   -> strongly typed child of the generated class
        //     Extra   (BaseObjectType, Mandatory) -> not known by FolderState, decoded as dynamic child
        private const string NodeSet =
            "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n" +
            "<UANodeSet xmlns=\"http://opcfoundation.org/UA/2011/03/UANodeSet.xsd\">\n" +
            "  <NamespaceUris><Uri>" + TestNamespace + "</Uri></NamespaceUris>\n" +
            "  <Models>\n" +
            "    <Model ModelUri=\"" + TestNamespace + "\" Version=\"1.0.0\" PublicationDate=\"2026-01-01T00:00:00Z\">\n" +
            "      <RequiredModel ModelUri=\"http://opcfoundation.org/UA/\" Version=\"1.05.07\" PublicationDate=\"2026-05-01T00:00:00Z\" />\n" +
            "    </Model>\n" +
            "  </Models>\n" +
            "  <Aliases />\n" +
            "  <UAObjectType NodeId=\"ns=1;i=1001\" BrowseName=\"1:TestMachineType\">\n" +
            "    <DisplayName>TestMachineType</DisplayName>\n" +
            "    <References><Reference ReferenceType=\"i=45\" IsForward=\"false\">i=58</Reference></References>\n" +
            "  </UAObjectType>\n" +
            "  <UAObject NodeId=\"ns=1;i=1002\" BrowseName=\"1:Container\" ParentNodeId=\"ns=1;i=1001\">\n" +
            "    <DisplayName>Container</DisplayName>\n" +
            "    <References>\n" +
            "      <Reference ReferenceType=\"i=37\">i=78</Reference>\n" +
            "      <Reference ReferenceType=\"i=40\">i=61</Reference>\n" +
            "      <Reference ReferenceType=\"i=47\" IsForward=\"false\">ns=1;i=1001</Reference>\n" +
            "    </References>\n" +
            "  </UAObject>\n" +
            "  <UAObject NodeId=\"ns=1;i=1003\" BrowseName=\"1:Extra\" ParentNodeId=\"ns=1;i=1002\">\n" +
            "    <DisplayName>Extra</DisplayName>\n" +
            "    <References>\n" +
            "      <Reference ReferenceType=\"i=37\">i=78</Reference>\n" +
            "      <Reference ReferenceType=\"i=40\">i=58</Reference>\n" +
            "      <Reference ReferenceType=\"i=35\" IsForward=\"false\">ns=1;i=1002</Reference>\n" +
            "    </References>\n" +
            "  </UAObject>\n" +
            "</UANodeSet>\n";

        [Fact]
        public async Task InitializationStringKeepsModellingRulesOfChildren()
        {
            string directory = Path.Combine(Path.GetTempPath(), "ModelCompilerTests", Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(directory);

            try
            {
                string designFile = Path.Combine(directory, "Issue3972.NodeSet2.xml");
                File.WriteAllText(designFile, NodeSet, Encoding.UTF8);

                string outputPath = Path.Combine(directory, "generated");
                Directory.CreateDirectory(outputPath);

                var telemetry = DefaultTelemetry.Create(_ => { });

                var generator = new ModelGenerator2(LocalFileSystem.Instance, telemetry);

                generator.ValidateAndUpdateIds(
                    new List<string> { $"{designFile},Issue3972,Issue3972" },
                    null,
                    1000,
                    "v105",
                    false,
                    null,
                    null,
                    null,
                    false,
                    false);

                await generator.GenerateMultipleFiles(outputPath, true, null, false, 0);

                string classes = File.ReadAllText(Path.Combine(outputPath, "Issue3972.Classes.cs"));

                var context = new SystemContext(telemetry)
                {
                    NamespaceUris = new NamespaceTable(new[] { Namespaces.OpcUa, TestNamespace })
                };

                var instance = new BaseObjectState(null);
                instance.Initialize(context, ExtractInitializationString(classes, "TestMachineTypeState"));

                Assert.True(NodeId.IsNull(instance.ModellingRuleId), "The instance itself must not have a modelling rule.");

                BaseInstanceState container = FindChild(context, instance, "Container");
                Assert.Equal(ObjectIds.ModellingRule_Mandatory, container.ModellingRuleId);

                BaseInstanceState extra = FindChild(context, container, "Extra");
                Assert.Equal(ObjectIds.ModellingRule_Mandatory, extra.ModellingRuleId);
            }
            finally
            {
                try
                {
                    Directory.Delete(directory, true);
                }
                catch (IOException)
                {
                    // ignore cleanup failures.
                }
            }
        }

        private static BaseInstanceState FindChild(ISystemContext context, NodeState parent, string browseName)
        {
            var children = new List<BaseInstanceState>();
            parent.GetChildren(context, children);

            BaseInstanceState? child = children.Find(c => c.BrowseName.Name == browseName);
            Assert.True(child != null, $"Child '{browseName}' not found in InitializationString of '{parent.BrowseName}'.");
            return child!;
        }

        private static string ExtractInitializationString(string source, string className)
        {
            int start = source.IndexOf($"public partial class {className} ", StringComparison.Ordinal);
            Assert.True(start >= 0, $"Class '{className}' not found in generated code.");

            Match match = Regex.Match(
                source.Substring(start),
                @"private const string InitializationString\s*=\s*(?<lits>(?:""(?:[^""\\]|\\.)*""\s*\+?\s*)+);");

            Assert.True(match.Success, $"InitializationString not found for '{className}'.");

            var builder = new StringBuilder();

            foreach (Match literal in Regex.Matches(match.Groups["lits"].Value, @"""(?<v>(?:[^""\\]|\\.)*)"""))
            {
                builder.Append(literal.Groups["v"].Value.Replace("\\\"", "\"").Replace("\\\\", "\\"));
            }

            return builder.ToString();
        }
    }
}
