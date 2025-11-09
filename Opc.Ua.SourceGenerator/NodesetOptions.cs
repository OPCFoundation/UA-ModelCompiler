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
    /// Nodeset information
    /// </summary>
    internal record class NodesetOptions
    {
        public string ModelUri { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public bool Ignore { get; set; }
        public string Version { get; set; }

        /// <summary>
        /// Get options from file options
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static NodesetOptions From(AnalyzerConfigOptions options)
        {
            if (options == null)
            {
                return null;
            }
            return new NodesetOptions
            {
                Ignore = options.GetBool(nameof(Ignore), false),
                Prefix = options.GetString(nameof(Prefix), false),
                Version = options.GetString(nameof(Version), false),
                Name = options.GetString(nameof(Name), false),
                ModelUri = options.GetString(nameof(ModelUri), false)
            };
        }
    }
}
