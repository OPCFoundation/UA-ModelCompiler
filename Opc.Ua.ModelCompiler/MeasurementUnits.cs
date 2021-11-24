using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ModelCompiler
{
    public class MeasurementUnits
    {
        public static bool ProcessCommandLine(IList<string> args)
        {
            if (args == null || !args.Contains("-units"))
            {
                return false;
            }

            int ii = 0;
            List<Unit> units = new List<Unit>();
            string outputFile = null;

            while (ii < args.Count)
            {
                if (args[ii] == "-annex1")
                {
                    ii++;

                    if (ii < args.Count)
                    {
                        Read(args[ii++], false, units);
                    }

                    continue;
                }

                if (args[ii] == "-annex2")
                {
                    ii++;

                    if (ii < args.Count)
                    {
                        Read(args[ii++], true, units);
                    }

                    continue;
                }

                if (args[ii] == "-output")
                {
                    ii++;

                    if (ii < args.Count)
                    {
                        outputFile = args[ii++];
                    }

                    continue;
                }

                ii++;
            }

            if (outputFile != null)
            {
                Write(outputFile, units);
            }

            return true;
        }

        public static void Process(string annex1, string annex2, string output)
        {
            List<Unit> units = new List<Unit>();

            if (String.IsNullOrEmpty(annex1))
            {
                Read(annex1, false, units);
            }

            if (String.IsNullOrEmpty(annex2))
            {
                Read(annex2, false, units);
            }

            if (output != null)
            {
                Write(output, units);
            }
        }

        public static void Read(string filePath, bool isAnnex2, List<Unit> units)
        {
            var lines = File.ReadAllLines(filePath);

            bool quoted = false;
            string lastLine = String.Empty;
            List<string> lines2 = new List<string>();

            foreach (var line in lines)
            {
                for (int jj = 0; jj < line.Length; jj++)
                {
                    if (quoted)
                    {
                        if (jj < line.Length - 1 && line[jj] == '"' && line[jj + 1] == '"')
                        {
                            jj++;
                            continue;
                        }
                    }

                    if (line[jj] == '"')
                    {
                        quoted = !quoted;
                    }
                }

                lastLine += line.Trim();

                if (!quoted)
                {
                    lines2.Add(lastLine);
                    lastLine = String.Empty;
                }
            }

            bool header = true;

            foreach (var row in lines2)
            {
                var columns = ParseRow(row);

                if (header)
                {
                    header = false;
                    continue;
                }

                units.Add(new Unit(columns, isAnnex2));
            }
        }

        public static void Write(string filePath, List<Unit> units)
        {
            Dictionary<string, Unit> index = new Dictionary<string, Unit>();

            foreach (var unit in units)
            {
                if (unit.Status == "X")
                {
                    continue;
                }

                if (String.IsNullOrWhiteSpace(unit.Code) || String.IsNullOrWhiteSpace(unit.Symbol))
                {
                    continue;
                }

                if (!index.ContainsKey(unit.Code))
                {
                    index[unit.Code] = unit;
                }
            }

            using (StreamWriter writer = new StreamWriter(filePath, false, new UTF8Encoding(true)))
            {
                writer.WriteLine("UNECECode,UnitId,DisplayName,Description");

                foreach (var ii in index.Values)
                {
                    writer.Write(ii.Code);
                    writer.Write(",");
                    writer.Write(ii.UnitId);
                    writer.Write(",");
                    writer.Write("\"");
                    writer.Write(ii.Symbol.Trim().Replace("\"", "\"\""));
                    writer.Write("\",");
                    writer.Write("\"");
                    writer.Write(ii.Name.Trim().Replace("\"", "\"\""));
                    writer.Write("\"");
                    writer.WriteLine();
                }
            }
        }

        private static List<string> ParseRow(string row)
        {
            bool quoted = false;
            bool skipToNext = false;
            List<string> columns = new List<string>();
            StringBuilder cell = new StringBuilder();

            for (int ii = 0; ii < row.Length; ii++)
            {
                if (quoted)
                {
                    if (row[ii] == '"')
                    {
                        if (ii < row.Length - 1 && row[ii] == '"' && row[ii + 1] == '"')
                        {
                            cell.Append(row[ii]);
                            ii++;
                            continue;
                        }

                        columns.Add(cell.ToString());
                        cell.Length = 0;
                        quoted = false;
                        skipToNext = true;
                        continue;
                    }

                    if (row[ii] != '\r' && row[ii] != '\n')
                    {
                        cell.Append(row[ii]);
                    }
                    else if (row[ii] == '\n')
                    {
                        cell.Append(' ');
                    }

                    continue;
                }

                if (skipToNext)
                {
                    if (row[ii] == ',')
                    {
                        skipToNext = false;
                    }

                    continue;
                }

                if (cell.Length == 0 && Char.IsWhiteSpace(row[ii]))
                {
                    continue;
                }

                if (row[ii] == '"')
                {
                    quoted = true;
                    continue;
                }

                if (row[ii] == ',')
                {
                    columns.Add(cell.ToString());
                    cell.Length = 0;
                    continue;
                }

                cell.Append(row[ii]);
            }

            columns.Add(cell.ToString());
            cell.Length = 0;

            return columns;
        }
    }

    public class Unit
    {
        public uint UnitId;
        public string Status;
        public string Code;
        public string Name;
        public string Conversion;
        public string Symbol;
        public string Description;

        public Unit(IList<string> columns, bool isAnnex2 = false)
        {
            if (isAnnex2)
            {
                ParseAnnex2(columns);
            }
            else
            {
                ParseAnnex1(columns);
            }

            var bytes = new UTF8Encoding(false).GetBytes(Code);

            UnitId = 0;

            for (int jj = 0; jj < bytes.Length; jj++)
            {
                UnitId <<= 8;
                UnitId += bytes[jj];
            }
        }

        public override string ToString()
        {
            return Name + " [" + Symbol + "]";
        }

        public void ParseAnnex1(IList<string> columns)
        {
            Status = columns[5];
            Code = columns[6];
            Name = columns[7];
            Conversion = columns[8];
            Symbol = columns[9];
            Description = columns[10];
        }

        public void ParseAnnex2(IList<string> columns)
        {
            Status = columns[0];
            Code = columns[1];
            Name = columns[2];
            Description = columns[3];
            Symbol = columns[5];
            Conversion = columns[6];
        }
    }
}
