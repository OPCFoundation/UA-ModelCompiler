using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

    public class NodeDocumentationReader
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

        public static IList<NodeDocumentationRow> Load(params string[] filepaths)
        {
            IList<NodeDocumentationRow> records = new List<NodeDocumentationRow>();

            foreach (var filepath in filepaths)
            {
                Append(filepath, records);
            }

            return records;
        }
    }
}
