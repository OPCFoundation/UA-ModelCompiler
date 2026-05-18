/* ========================================================================
 * Copyright (c) 2005-2026 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00 — see other files in the repo for the
 * full text. This file is an audit harness for the InitializationString /
 * PredefinedNodes pipeline; it is not a behavioural test.
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Opc.Ua;
using Opc.Ua.Export;
using Xunit.Abstractions;

namespace ModelCompiler
{
    /// <summary>
    /// Audit (not assertion) harness that walks the checked-in generated outputs
    /// for each known model and reports per-type whether MandatoryPlaceholder /
    /// OptionalPlaceholder / ExposesItsArray children are present in:
    ///
    ///   1. The PredefinedNodes XML, nested under the type element.
    ///   2. The InitializationString embedded in the per-type C# class
    ///      (decoded as binary or XML).
    ///
    /// "Expected" placeholder set per type = own placeholder children
    /// + recursively inherited placeholder children from base types via HasSubtype.
    ///
    /// The harness writes a markdown-ish report to xunit's test output. It
    /// asserts at the end only that the harness itself ran cleanly — any
    /// missing placeholder is logged, never assert-failed, so the inventory
    /// is the artifact, not pass/fail.
    /// </summary>
    public class PlaceholderAuditTests
    {
        private static readonly HashSet<NodeId> s_placeholderRules = new()
        {
            ObjectIds.ModellingRule_OptionalPlaceholder,
            ObjectIds.ModellingRule_MandatoryPlaceholder,
            ObjectIds.ModellingRule_ExposesItsArray,
        };

        private readonly ITestOutputHelper _out;

        public PlaceholderAuditTests(ITestOutputHelper output) => _out = output;

        // ---- targets ------------------------------------------------------

        public sealed record AuditTarget(
            string Label,
            string PredefinedXmlPath,
            string ClassesCsPath,
            string[] DependencyPredefinedXml);

        public static IEnumerable<object[]> Targets()
        {
            string root = LocateRepoRoot();

            string standardPredefined = Path.Combine(root, "Stack", "Stack", "Opc.Ua.Core", "Stack", "Generated", "Opc.Ua.PredefinedNodes.xml");

            // Standard core: self-contained, no dependencies.
            yield return new object[] { new AuditTarget(
                Label: "Opc.Ua (standard core)",
                PredefinedXmlPath: standardPredefined,
                ClassesCsPath:     Path.Combine(root, "Stack", "Stack", "Opc.Ua.Core", "Stack", "Generated", "Opc.Ua.Classes.cs"),
                DependencyPredefinedXml: Array.Empty<string>()) };

            // GDS depends on standard.
            yield return new object[] { new AuditTarget(
                Label: "Opc.Ua.Gds",
                PredefinedXmlPath: Path.Combine(root, "Stack", "Libraries", "Opc.Ua.Gds.Server.Common", "Model", "Opc.Ua.Gds.PredefinedNodes.xml"),
                ClassesCsPath:     Path.Combine(root, "Stack", "Libraries", "Opc.Ua.Gds.Server.Common", "Model", "Opc.Ua.Gds.Classes.cs"),
                DependencyPredefinedXml: new[] { standardPredefined }) };

            // DemoModel and TestModel test fixtures.
            yield return new object[] { new AuditTarget(
                Label: "DemoModel",
                PredefinedXmlPath: Path.Combine(root, "Tests", "DemoModel", "DemoModel", "DemoModel.PredefinedNodes.xml"),
                ClassesCsPath:     Path.Combine(root, "Tests", "DemoModel", "DemoModel", "DemoModel.Classes.cs"),
                DependencyPredefinedXml: new[] { standardPredefined }) };

            yield return new object[] { new AuditTarget(
                Label: "TestModel",
                PredefinedXmlPath: Path.Combine(root, "Tests", "DemoModel", "TestModel", "TestModel.PredefinedNodes.xml"),
                ClassesCsPath:     Path.Combine(root, "Tests", "DemoModel", "TestModel", "TestModel.Classes.cs"),
                DependencyPredefinedXml: new[] { standardPredefined }) };

            // Quickstart server example models.
            yield return new object[] { new AuditTarget(
                Label: "Quickstarts.Boiler",
                PredefinedXmlPath: Path.Combine(root, "Stack", "Applications", "Quickstarts.Servers", "Boiler", "Generated", "Boiler.PredefinedNodes.xml"),
                ClassesCsPath:     Path.Combine(root, "Stack", "Applications", "Quickstarts.Servers", "Boiler", "Generated", "Boiler.Classes.cs"),
                DependencyPredefinedXml: new[] { standardPredefined }) };

            yield return new object[] { new AuditTarget(
                Label: "Quickstarts.MemoryBuffer",
                PredefinedXmlPath: Path.Combine(root, "Stack", "Applications", "Quickstarts.Servers", "MemoryBuffer", "Generated", "MemoryBuffer.PredefinedNodes.xml"),
                ClassesCsPath:     Path.Combine(root, "Stack", "Applications", "Quickstarts.Servers", "MemoryBuffer", "Generated", "MemoryBuffer.Classes.cs"),
                DependencyPredefinedXml: new[] { standardPredefined }) };

            yield return new object[] { new AuditTarget(
                Label: "Quickstarts.TestData",
                PredefinedXmlPath: Path.Combine(root, "Stack", "Applications", "Quickstarts.Servers", "TestData", "Generated", "TestData.PredefinedNodes.xml"),
                ClassesCsPath:     Path.Combine(root, "Stack", "Applications", "Quickstarts.Servers", "TestData", "Generated", "TestData.Classes.cs"),
                DependencyPredefinedXml: new[] { standardPredefined }) };
        }

        // ---- the audit ----------------------------------------------------

        [Theory]
        [MemberData(nameof(Targets))]
        public void Inventory(AuditTarget target)
        {
            _out.WriteLine($"# Placeholder audit: {target.Label}");
            _out.WriteLine("");

            foreach (var path in new[] { target.PredefinedXmlPath, target.ClassesCsPath })
            {
                if (!File.Exists(path))
                {
                    _out.WriteLine($"  SKIP — missing file: {path}");
                    return;
                }
            }
            foreach (var dep in target.DependencyPredefinedXml)
            {
                if (!File.Exists(dep))
                {
                    _out.WriteLine($"  SKIP — missing dependency: {dep}");
                    return;
                }
            }

            // 1. Load the model's PredefinedNodes XML AND each dependency's
            //    PredefinedNodes XML into one combined collection. The
            //    PredefinedNodes XML format keeps instance-declaration children
            //    nested under their parent type, which means GetChildren walks
            //    the slot tree directly.
            var ctx = new SystemContext(DefaultTelemetry.Create(_ => { }))
            {
                NamespaceUris = new NamespaceTable(new[] { Namespaces.OpcUa }),
                ServerUris = new StringTable(),
            };

            var combined = new NodeStateCollection();
            foreach (var dep in target.DependencyPredefinedXml)
            {
                LoadPredefined(ctx, dep, combined);
            }
            int firstModelIndex = combined.Count;
            LoadPredefined(ctx, target.PredefinedXmlPath, combined);

            var byNodeId = IndexAllStates(ctx, combined);

            // 2. Take only the types contributed by the current model
            //    (everything appended after dependencies were loaded).
            var modelTypes = combined.Skip(firstModelIndex).OfType<BaseTypeState>().ToList();

            var expected = new SortedDictionary<string, List<PlaceholderSlot>>(StringComparer.Ordinal);
            foreach (var typeState in modelTypes)
            {
                var slots = ExpectedPlaceholdersForType(ctx, typeState, byNodeId);
                if (slots.Count == 0) continue;
                expected[FormatId(typeState)] = slots;
            }

            if (expected.Count == 0)
            {
                _out.WriteLine("  No types in this model expose placeholder children. Nothing to audit.");
                return;
            }

            // The "predefined" view for the current model is the same combined
            // collection; we already indexed it above.
            var predefinedByNodeId = byNodeId;

            // 4. Parse the Classes.cs source into (className -> InitializationString).
            string classesCsSource = File.ReadAllText(target.ClassesCsPath);
            var initStrings = ExtractInitializationStrings(classesCsSource);

            // 5. Walk and report.
            int totalExpected = 0;
            int missingFromPredefined = 0;
            int missingFromInitString = 0;
            int initStringNotFound = 0;
            int initStringDecodeFailed = 0;

            _out.WriteLine($"| Type | Slot | In PredefinedNodes.xml | In InitializationString |");
            _out.WriteLine($"|------|------|------------------------|-------------------------|");

            foreach (var (typeKey, slots) in expected)
            {
                // The actual type state we want to inspect against PredefinedNodes is keyed by typeKey -> NodeId.
                var typeNodeId = ParseFormattedId(typeKey, ctx);

                bool hasTypeInPredefined = predefinedByNodeId.TryGetValue(typeNodeId, out var typeInPredefined);

                // Per-class init string lookup: try a few naming conventions.
                string? initStringForType = LookupInitString(initStrings, typeKey);
                bool initStringFound = initStringForType != null;

                NodeState? initStringRoot = null;
                if (initStringFound)
                {
                    NodeState typeState = predefinedByNodeId.TryGetValue(typeNodeId, out var ts) ? ts : null!;
                    try
                    {
                        initStringRoot = LoadInitializationString(ctx, initStringForType!, typeState);
                    }
                    catch (Exception ex)
                    {
                        initStringDecodeFailed++;
                        _out.WriteLine($"  (decode failed for `{typeKey}`: {ex.GetType().Name}: {ex.Message})");
                    }
                }
                else
                {
                    initStringNotFound++;
                }

                foreach (var slot in slots)
                {
                    totalExpected++;

                    bool inPredefined = hasTypeInPredefined && ChildBrowseNamesOf(ctx, typeInPredefined!).Contains(slot.BrowseName);
                    bool inInitString = initStringRoot != null && ChildBrowseNamesOf(ctx, initStringRoot).Contains(slot.BrowseName);

                    if (!inPredefined) missingFromPredefined++;
                    if (initStringFound && initStringRoot != null && !inInitString) missingFromInitString++;

                    string predefinedMark = inPredefined ? "✓" : "✗";
                    string initMark = !initStringFound ? "n/a"
                                    : initStringRoot == null ? "decode-fail"
                                    : inInitString ? "✓" : "✗";

                    string origin = slot.IsInherited ? $" (inherited from {FormatId(slot.DeclaringTypeId, ctx)})" : "";
                    _out.WriteLine($"| {typeKey} | {slot.BrowseName} {RuleSuffix(slot.ModellingRule)}{origin} | {predefinedMark} | {initMark} |");
                }
            }

            _out.WriteLine("");
            _out.WriteLine($"## Summary for {target.Label}");
            _out.WriteLine($"- Types with placeholder slots: {expected.Count}");
            _out.WriteLine($"- Total expected slots:         {totalExpected}");
            _out.WriteLine($"- Missing from PredefinedNodes: {missingFromPredefined}");
            _out.WriteLine($"- Missing from InitString:      {missingFromInitString}");
            _out.WriteLine($"- Types with no per-class init string in source: {initStringNotFound}");
            _out.WriteLine($"- Init strings that failed to decode: {initStringDecodeFailed}");
            _out.WriteLine("");
        }

        // ---- placeholder-slot model ---------------------------------------

        private sealed record PlaceholderSlot(
            QualifiedName BrowseName,
            NodeId ModellingRule,
            NodeId DeclaringTypeId,
            bool IsInherited);

        private static string RuleSuffix(NodeId rule)
        {
            if (rule == ObjectIds.ModellingRule_OptionalPlaceholder) return "[OptPH]";
            if (rule == ObjectIds.ModellingRule_MandatoryPlaceholder) return "[ManPH]";
            if (rule == ObjectIds.ModellingRule_ExposesItsArray) return "[Array]";
            return "";
        }

        // ---- traversal ----------------------------------------------------

        /// <summary>
        /// Returns the set of placeholder slots a type should expose: own ones
        /// plus recursively inherited from base types through HasSubtype.
        /// </summary>
        private static List<PlaceholderSlot> ExpectedPlaceholdersForType(
            ISystemContext ctx,
            NodeState typeState,
            IReadOnlyDictionary<NodeId, NodeState> byNodeId)
        {
            var slots = new List<PlaceholderSlot>();
            var seenBrowseNames = new HashSet<QualifiedName>();

            void CollectFrom(NodeState t, bool isInherited)
            {
                // Type's own children
                var children = new List<BaseInstanceState>();
                t.GetChildren(ctx, children);
                foreach (var child in children)
                {
                    if (child.ModellingRuleId == null) continue;
                    if (!s_placeholderRules.Contains(child.ModellingRuleId)) continue;
                    if (!seenBrowseNames.Add(child.BrowseName)) continue;
                    slots.Add(new PlaceholderSlot(child.BrowseName, child.ModellingRuleId, t.NodeId, isInherited));
                }

                // Base type (HasSubtype, inverse)
                var refs = new List<IReference>();
                t.GetReferences(ctx, refs, ReferenceTypeIds.HasSubtype, isInverse: true);
                foreach (var r in refs)
                {
                    var baseId = ExpandedNodeId.ToNodeId(r.TargetId, ctx.NamespaceUris);
                    if (baseId != null && byNodeId.TryGetValue(baseId, out var baseState))
                    {
                        CollectFrom(baseState, isInherited: true);
                    }
                }
            }

            CollectFrom(typeState, isInherited: false);
            return slots;
        }

        /// <summary>
        /// Returns BrowseNames of direct children of <paramref name="state"/>.
        /// </summary>
        private static HashSet<QualifiedName> ChildBrowseNamesOf(ISystemContext ctx, NodeState state)
        {
            var children = new List<BaseInstanceState>();
            state.GetChildren(ctx, children);
            return new HashSet<QualifiedName>(children.Select(c => c.BrowseName));
        }

        // ---- nodeset / state-collection plumbing --------------------------

        private static void LoadPredefined(ISystemContext ctx, string path, NodeStateCollection into)
        {
            using var s = File.OpenRead(path);
            into.LoadFromXml(ctx, s, true);
        }

        private static IReadOnlyDictionary<NodeId, NodeState> IndexAllStates(
            ISystemContext ctx,
            NodeStateCollection collection)
        {
            var map = new Dictionary<NodeId, NodeState>();
            void Walk(NodeState n)
            {
                if (!NodeId.IsNull(n.NodeId)) map[n.NodeId] = n;
                var ch = new List<BaseInstanceState>();
                n.GetChildren(ctx, ch);
                foreach (var c in ch) Walk(c);
            }
            foreach (var n in collection) Walk(n);
            return map;
        }

        // ---- formatting helpers -------------------------------------------

        private static string FormatId(NodeState state)
            => $"{state.SymbolicName ?? state.BrowseName.Name} (ns={state.NodeId.NamespaceIndex},id={state.NodeId.Identifier})";

        private static string FormatId(NodeId id, ISystemContext ctx)
            => $"(ns={id.NamespaceIndex},id={id.Identifier})";

        private static NodeId ParseFormattedId(string formatted, ISystemContext ctx)
        {
            // formatted: "Name (ns=N,id=I)" — quick parse.
            var m = Regex.Match(formatted, @"\(ns=(\d+),id=(.+?)\)\s*$");
            if (!m.Success) return NodeId.Null;
            ushort ns = ushort.Parse(m.Groups[1].Value);
            string idStr = m.Groups[2].Value;
            if (uint.TryParse(idStr, out uint num)) return new NodeId(num, ns);
            return new NodeId(idStr, ns);
        }

        // ---- Classes.cs parsing -------------------------------------------

        private static readonly Regex s_classRegex =
            new(@"public partial class (?<name>\w+State)(?:<[^>]*>)?\s*:\s*(?<base>[^{\r\n]+)",
                RegexOptions.Compiled);

        private static readonly Regex s_initStringRegex =
            new(@"private const string InitializationString\s*=\s*(?<lits>(?:""(?:[^""\\]|\\.)*""\s*\+?\s*)+)\s*;",
                RegexOptions.Compiled);

        private static readonly Regex s_literalRegex =
            new(@"""(?<v>(?:[^""\\]|\\.)*)""", RegexOptions.Compiled);

        /// <summary>
        /// Returns map of class-name -> raw concatenated InitializationString
        /// (the string contents — base64 or XML — exactly as they would be at runtime).
        /// </summary>
        private static IReadOnlyDictionary<string, string> ExtractInitializationStrings(string source)
        {
            var result = new Dictionary<string, string>(StringComparer.Ordinal);

            // Find each class header, then within its body (matched by simple
            // brace counting starting after the header) look for the init string.
            foreach (Match m in s_classRegex.Matches(source))
            {
                string className = m.Groups["name"].Value;
                int bodyStart = source.IndexOf('{', m.Index + m.Length);
                if (bodyStart < 0) continue;
                int bodyEnd = FindMatchingBrace(source, bodyStart);
                if (bodyEnd < 0) continue;

                string body = source.Substring(bodyStart, bodyEnd - bodyStart);
                var im = s_initStringRegex.Match(body);
                if (!im.Success) continue;

                var sb = new StringBuilder();
                foreach (Match lit in s_literalRegex.Matches(im.Groups["lits"].Value))
                {
                    sb.Append(UnescapeCSharpStringLiteral(lit.Groups["v"].Value));
                }
                // Latest occurrence wins if there are partial-class duplicates.
                result[className] = sb.ToString();
            }

            return result;
        }

        private static string UnescapeCSharpStringLiteral(string s)
        {
            // Init strings only ever contain printable ASCII (base64) or XML —
            // the escape we care about is \" and \\.
            return s.Replace("\\\"", "\"").Replace("\\\\", "\\");
        }

        private static int FindMatchingBrace(string source, int openIndex)
        {
            int depth = 0;
            bool inString = false;
            bool inChar = false;
            bool inLineComment = false;
            bool inBlockComment = false;
            for (int i = openIndex; i < source.Length; i++)
            {
                char c = source[i];
                char next = i + 1 < source.Length ? source[i + 1] : '\0';

                if (inLineComment) { if (c == '\n') inLineComment = false; continue; }
                if (inBlockComment) { if (c == '*' && next == '/') { inBlockComment = false; i++; } continue; }
                if (inString) {
                    if (c == '\\') { i++; continue; }
                    if (c == '"') inString = false;
                    continue;
                }
                if (inChar) {
                    if (c == '\\') { i++; continue; }
                    if (c == '\'') inChar = false;
                    continue;
                }

                if (c == '/' && next == '/') { inLineComment = true; i++; continue; }
                if (c == '/' && next == '*') { inBlockComment = true; i++; continue; }
                if (c == '"') { inString = true; continue; }
                if (c == '\'') { inChar = true; continue; }
                if (c == '{') depth++;
                else if (c == '}') { depth--; if (depth == 0) return i + 1; }
            }
            return -1;
        }

        /// <summary>
        /// Try a few class-naming conventions to match a type's symbolic name to
        /// its generated `*State` class.
        /// </summary>
        private static string? LookupInitString(IReadOnlyDictionary<string, string> map, string typeKey)
        {
            // typeKey looks like "RestrictedObjectType (ns=1,id=...)".
            // Generated class drops the "Type" suffix: RestrictedObjectType -> RestrictedObjectState.
            string symbolic = typeKey.Split(' ')[0];

            string asInstance = symbolic.EndsWith("Type", StringComparison.Ordinal)
                ? symbolic[..^"Type".Length] + "State"
                : symbolic + "State";

            string asTypeState = symbolic + "State";

            if (map.TryGetValue(asInstance, out var v1)) return v1;
            if (map.TryGetValue(asTypeState, out var v2)) return v2;
            return null;
        }

        /// <summary>
        /// Decode an InitializationString (binary base64 OR raw XML) into a
        /// loose NodeState whose children we can enumerate. The probe NodeState
        /// must match the original encoded NodeClass (Object vs Variable),
        /// otherwise the binary decoder misaligns.
        /// </summary>
        private static NodeState LoadInitializationString(ISystemContext ctx, string raw, NodeState? typeState)
        {
            BaseInstanceState probe = ProbeFor(typeState);
            probe.Initialize(ctx, raw);
            return probe;
        }

        private static BaseInstanceState ProbeFor(NodeState? typeState)
        {
            // ObjectType -> BaseObjectState. VariableType (any flavour) ->
            // BaseDataVariableState. Anything else -> BaseObjectState as a
            // best-effort default.
            switch (typeState)
            {
                case BaseVariableTypeState:  return new BaseDataVariableState(null);
                case BaseObjectTypeState:    return new BaseObjectState(null);
                default:                     return new BaseObjectState(null);
            }
        }

        // ---- repo root ----------------------------------------------------

        private static string LocateRepoRoot()
        {
            var dir = new DirectoryInfo(AppContext.BaseDirectory);
            while (dir != null)
            {
                if (File.Exists(Path.Combine(dir.FullName, "ModelCompiler.slnx"))
                 || File.Exists(Path.Combine(dir.FullName, "ModelCompiler.sln")))
                {
                    return dir.FullName;
                }
                dir = dir.Parent;
            }
            throw new DirectoryNotFoundException(
                "Could not locate repo root from " + AppContext.BaseDirectory);
        }
    }
}
