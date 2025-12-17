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

using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration.Attributes;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Text;

namespace ModelCompiler
{
    public class NodeDocumentationRow
    {
        [Name("Id")]
        public uint Id;
        [Name("Name")]
        public string Name;
        [Name("Link")]
        public string Link;
        [Name("ConformanceUnits")]
        public IList<string> ConformanceUnits;
    }

    public class ArrayConverter<T> : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            List<string> array = new ();

            if (!String.IsNullOrEmpty(text))
            {
                var split = text.Split(';');

                foreach (var ii in split)
                {
                    var element = ii.Trim();

                    if (!String.IsNullOrEmpty(element))
                    {
                        array.Add(element);
                    }
                }
            }

            return array;
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            var builder = new StringBuilder();

            if (value is IList<string> list)
            {
                foreach (var ii in list)
                {
                    var element = ii.Trim();

                    if (!String.IsNullOrEmpty(element))
                    {
                        if (builder.Length > 0)
                        {
                            builder.Append(';');
                        }

                        builder.Append(element);
                    }
                }
            }

            return builder.ToString();
        }
    }

    public sealed class NodeDocumentationMap : ClassMap<NodeDocumentationRow>
    {
        public NodeDocumentationMap()
        {
            Map(m => m.Id).Name("Id");
            Map(m => m.Name).Name("Name");
            Map(m => m.Link).Name("Link");
            Map(m => m.ConformanceUnits).Name("ConformanceUnits").TypeConverter<ArrayConverter<NodeDocumentationRow>>();
        }
    }

    public static class NodeDocumentationReader
    {
        private static void Append(string filepath, IList<NodeDocumentationRow> results)
        {
            using (var istrm = new StreamReader(filepath))
            {
                CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    MissingFieldFound = (args) => {}
                };

                using (var csv = new CsvReader(istrm, configuration))
                {
                    csv.Context.RegisterClassMap<NodeDocumentationMap>();
                    var records = csv.GetRecords<NodeDocumentationRow>().ToList();

                    foreach (var ii in records)
                    {
                        ii.Link = ii.Link.Trim();
                        results.Add(ii);
                    }
                }
            }
        }

        public static List<NodeDocumentationRow> Load(params string[] filepaths)
        {
            var records = new List<NodeDocumentationRow>();

            foreach (var filepath in filepaths)
            {
                Append(filepath, records);
            }

            return records;
        }
    }
}
