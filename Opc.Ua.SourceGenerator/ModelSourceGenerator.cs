/* ========================================================================
 * Copyright (c) 2005-2024 The OPC Foundation, Inc. All rights reserved.
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

using Microsoft.CodeAnalysis;

namespace ModelCompiler
{
    /// <summary>
    /// Generates server and client models using the model generator library
    /// </summary>
    [Generator]
    public class ModelSourceGenerator : IIncrementalGenerator
    {
        internal const string Name = "ModelCompiler";

#pragma warning disable RS1007 // Provide localizable arguments to diagnostic descriptor constructor
        internal static readonly DiagnosticDescriptor _genericError = new(
            id: "MODELGEN001",
            title: "Error",
            messageFormat: "Error during model generation '{0}'",
            category: Name,
            DiagnosticSeverity.Error,
            isEnabledByDefault: true,
            helpLinkUri: "www.opcfoundation.org",
            customTags: ["opcua"]);
#pragma warning restore RS1007 // Provide localizable arguments to diagnostic descriptor constructor

#pragma warning disable RS1007 // Provide localizable arguments to diagnostic descriptor constructor
        internal static readonly DiagnosticDescriptor _genericWarning = new(
            id: "MODELGEN002",
            title: "Warning",
            messageFormat: "Warning during model generation '{0}'",
            category: Name,
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            helpLinkUri: "www.opcfoundation.org",
            customTags: ["opcua"]);
#pragma warning restore RS1007 // Provide localizable arguments to diagnostic descriptor constructor

#pragma warning disable RS1007 // Provide localizable arguments to diagnostic descriptor constructor
        internal static readonly DiagnosticDescriptor _exception = new(
            id: "MODELGEN003",
            title: "Exception",
            messageFormat: "Exception during model generation '{0}': {1}",
            category: Name,
            DiagnosticSeverity.Error,
            isEnabledByDefault: true,
            helpLinkUri: "www.opcfoundation.org",
            customTags: ["opcua"]);
#pragma warning restore RS1007 // Provide localizable arguments to diagnostic descriptor constructor

        /// <summary>
        /// Initialize the generator
        /// </summary>
        /// <param name="context"></param>
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
#if DEBUGX
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                System.Diagnostics.Debugger.Launch();
            }
#endif
            var inputFiles = context.AdditionalTextsProvider
                .Where(f => f.IsDesignOrNodeset2File())
                .Combine(context.AnalyzerConfigOptionsProvider)
                .Select((pair, _) => (
                    pair.Left,
                    NodesetOptions.From(pair.Right.GetOptions(pair.Left))))
                .Collect();
            var identiferFile = context.AdditionalTextsProvider
                .Where(f => f.IsIdentifierFile())
                .Collect();
            var options = context.AnalyzerConfigOptionsProvider
                .Select((p, _) => ModelCompilationOptions.FromProvider(p));
            var settings = context.CompilationProvider
                .Select((c, _) => CompilationOptions.From(c));

            context.RegisterImplementationSourceOutput(
                inputFiles
                    .Combine(identiferFile)
                    .Combine(options),
                (context, combination) =>
                {
                    new ModelCompilation(
                        context,
                        combination.Left.Left,
                        combination.Left.Right,
                        combination.Right).RunAsync().GetAwaiter().GetResult();
                });
        }
    }
}
