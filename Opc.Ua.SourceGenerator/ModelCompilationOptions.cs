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

using Microsoft.CodeAnalysis.Diagnostics;

namespace ModelCompiler
{
    /// <summary>
    /// Model compiler options
    /// </summary>
    internal record class ModelCompilationOptions
    {
        // -version <v104, v105>
        public string Version { get; set; }
        // -useAllowSubtypes
        public bool UseAllowSubtypes { get; set; }
        // -id <start id>
        public uint StartId { get; set; }
        // -exclude <id;id;id>
        public IList<string> Exclude { get; set; }
        // -mv <model version>
        public string ModelVersion { get; set; }
        // -pd <publication date>
        public string ModelPublicationDate { get; set; }
        // -rc
        public bool ReleaseCandidate { get; set; }

        /// <summary>
        /// Get options from options provider
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static ModelCompilationOptions FromProvider(AnalyzerConfigOptionsProvider provider)
        {
            return new ModelCompilationOptions
            {
                Version = provider.GlobalOptions.GetString(nameof(Version)) ?? "v105",
                Exclude = provider.GlobalOptions.GetStrings(nameof(Exclude)),
                UseAllowSubtypes = provider.GlobalOptions.GetBool(nameof(UseAllowSubtypes)),
                StartId = (uint)provider.GlobalOptions.GetInteger(nameof(StartId)),
                ModelVersion = provider.GlobalOptions.GetString(nameof(ModelVersion)),
                ModelPublicationDate = provider.GlobalOptions.GetString(nameof(ModelPublicationDate)),
                ReleaseCandidate = provider.GlobalOptions.GetBool(nameof(ReleaseCandidate))
            };
        }
    }
}
