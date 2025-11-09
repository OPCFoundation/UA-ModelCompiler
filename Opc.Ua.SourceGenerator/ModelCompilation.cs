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
using System.Collections.Immutable;
using System.Text;

namespace ModelCompiler
{
    /// <summary>
    /// Compiles the model. This honors the options of the compile command
    /// of the tool.  However, it does not generate identifier files and
    /// assumes that if identifiers are required they are loaded from a
    /// csv file that is side by side with the design files.  Also, this
    /// does not produce xsd or bsd nor nodeset files, which cannot be
    /// added to a compilation using roslyn source generator (yet).
    /// </summary>
    internal sealed class ModelCompilation
    {
        private readonly SourceProductionContext m_context;
        private readonly ImmutableArray<(AdditionalText, NodesetOptions)> m_input;
        private readonly ImmutableArray<AdditionalText> m_identifierFiles;
        private readonly ModelCompilationOptions m_options;

        /// <summary>
        /// Create compilation
        /// </summary>
        public ModelCompilation(
            SourceProductionContext context,
            ImmutableArray<(AdditionalText, NodesetOptions)> inputFiles,
            ImmutableArray<AdditionalText> identifierFiles,
            ModelCompilationOptions options)
        {
            m_context = context;
            m_input = inputFiles;
            m_identifierFiles = identifierFiles;
            m_options = options;
        }

        /// <summary>
        /// Perform the compilation
        /// </summary>
        public async Task RunAsync()
        {
            using var fileSystem = new VirtualFileSystem();
            try
            {
                ModelGenerator2 generator = new(fileSystem, null);
                generator.LogMessage += Report;

                var identiferFile = m_identifierFiles.Select(i => i.Path).FirstOrDefault();
                if (m_input.Length == 0)
                {
                    // Nothing to do
                    return;
                }

                // Load all available nodeset files from the input.
                var nodesets = new NodesetFileCollection(
                    m_input,
                    m_context,
                    fileSystem);
                if (nodesets.Files.Count > 0)
                {
                    generator.AvailableNodeSets = nodesets.Files;
                    foreach (var modelUri in nodesets.ModelUris)
                    {
                        var designFilesForModel = nodesets.GetDesignFileListForModel(
                            modelUri,
                            out var nodeset);
                        if (designFilesForModel == null || nodeset.Info.Ignore)
                        {
                            continue;
                        }
                        var exclusions = new HashSet<string>(m_options.Exclude)
                        {
                            "Draft"
                        };
                        generator.ValidateAndUpdateIds(
                            designFilesForModel,
                            null,
                            0,
                            "v105",
                            true,
                            [.. exclusions],
                            null,
                            null,
                            true,
                            false);

                        await generator.GenerateMultipleFiles(
                            string.Empty,
                            false,
                            [.. exclusions],
                            false,
                            minimal: true).ConfigureAwait(false);

                        // Reset generator to clear state.
                        generator = new(fileSystem, null);
                        generator.LogMessage += Report;
                    }
                }

                var designFiles = m_input
                    .Where(f => !nodesets.Files.ContainsValue(f.Item1.Path))
                    .Select(f => f.Item1.Path)
                    .ToList();
                if (designFiles.Count > 0)
                {
                    // The rest of the input is processed as design files
                    generator.ValidateAndUpdateIds(
                        designFiles,
                        null, // identifierFile,
                        m_options.StartId,
                        m_options.Version,
                        m_options.UseAllowSubtypes,
                        m_options.Exclude,
                        m_options.ModelVersion,
                        m_options.ModelPublicationDate,
                        m_options.ReleaseCandidate,
                        false);

                    await generator.GenerateMultipleFiles(
                        string.Empty,
                        false,
                        m_options.Exclude,
                        false,
                        minimal: false).ConfigureAwait(false);
                }

                // Collect all generated cs files and produce them into the compilation
                foreach (var file in fileSystem.CreatedFiles
                    .Where(f => f.EndsWith(".cs", StringComparison.OrdinalIgnoreCase)))
                {
                    var content = Encoding.UTF8.GetString(fileSystem.Get(file));
                    m_context.AddSource(file, content);
                }
            }
            catch (Exception ex)
            {
                m_context.ReportDiagnostic(
                    Diagnostic.Create(
                        ModelSourceGenerator._exception,
                        Location.None,
                        ex.Message,
                        ex.StackTrace));
                return;
            }

            Task Report(LogMessageEventArgs e)
            {
                m_context.ReportDiagnostic(
                    Diagnostic.Create(e.Severity > 0 ?
                        ModelSourceGenerator._genericError :
                        ModelSourceGenerator._genericWarning, Location.None, e.Message));
                return Task.CompletedTask;
            }
        }
    }
}
