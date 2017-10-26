/* ========================================================================
 * Copyright (c) 2005-2016 The OPC Foundation, Inc. All rights reserved.
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
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Text;

namespace Opc.Ua.ModelCompiler
{
    static class Program
    {
        private const string consoleOutputCommandLineArgument = "-console";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //ProcessEngineeringUnitFile(@".\rec20_latest.csv", @".\UNECE_to_OPCUA.csv");
                //return;

                if (!ProcessCommandLine())
                {
                    StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Opc.Ua.ModelCompiler.HelpFile.txt"));
                    MessageBox.Show(reader.ReadToEnd(), "Opc.Ua.ModelCompiler");
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                if (Environment.CommandLine.Contains(consoleOutputCommandLineArgument))
                {
                    System.Console.Error.WriteLine(e.Message);
                    System.Console.Error.WriteLine(e.StackTrace);
                }
                else
                {
                    Application.Run(new ExceptionDlg(e));
                }
            }
        }

        static List<string> ParseRow(string[] columns, ref bool quoted)
        {
            var row = new List<string>();
            StringBuilder column = new StringBuilder();

            for (int ii = 0; ii < columns.Length; ii++)
            {
                if (!quoted && columns[ii].TrimStart().StartsWith("\""))
                {
                    if (columns[ii].TrimEnd().EndsWith("\""))
                    {
                        var text = columns[ii].Trim().Replace("\"\"", "\"");
                        row.Add(text.Substring(1, text.Length - 2));
                        continue;
                    }

                    column.Append(columns[ii].TrimStart().Substring(1));
                    quoted = true;
                    continue;
                }

                if (quoted)
                {
                    if (columns[ii].TrimEnd().EndsWith("\""))
                    {
                        column.Append(",");
                        var text = columns[ii].TrimEnd().Replace("\"\"", "\"");
                        column.Append(text.Substring(0, text.Length - 1));
                        quoted = false;
                        row.Add(column.ToString());
                        column.Length = 0;
                        continue;
                    }

                    column.Append(",");
                    column.Append(columns[ii].Replace("\"\"", "\""));
                    continue;
                }

                row.Add(columns[ii].Trim());
            }

            return row;
        }

        static void ProcessEngineeringUnitFile(string input, string output)
        {
            Dictionary<string, int> headers = null;
            var table = new List<List<string>>();
            Dictionary<string, int> uniqueRows = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader(input, new UTF8Encoding(false)))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    line = line.Trim();

                    if (String.IsNullOrEmpty(line) || line.StartsWith("\","))
                    {
                        line = reader.ReadLine();
                        continue;
                    }

                    var columns = line.Split(',');

                    if (headers == null)
                    {
                        headers = new Dictionary<string, int>();

                        for (int ii = 0; ii < columns.Length; ii++)
                        {
                            headers[columns[ii]] = ii;
                        }
                    }
                    else
                    {
                        bool quoted = false;
                        var row = ParseRow(columns, ref quoted);

                        while (quoted)
                        {
                            var next = reader.ReadLine();

                            if (next == null)
                            {
                                break;
                            }

                            line += next;
                            columns = line.Split(',');
                            quoted = false;
                            row = ParseRow(columns, ref quoted);
                        }

                        int code = headers["Common Code"];

                        int index = 0;

                        if (uniqueRows.TryGetValue(row[code], out index))
                        {
                            table[index] = row;
                        }
                        else
                        {
                            uniqueRows[row[code]] = table.Count;
                            table.Add(row);
                        }
                    }

                    line = reader.ReadLine();
                }
            }


            using (StreamWriter writer = new StreamWriter(output, false, new UTF8Encoding(true)))
            {
                writer.WriteLine("UNECECode,UnitId,DisplayName,Description");

                int code = headers["Common Code"];
                int name = headers["Symbol"];
                int text = headers["Name"];

                for (int ii = 0; ii < table.Count; ii++)
                {
                    if (table[ii].Count < 12)
                    {
                        continue;
                    }

                    var column = table[ii][code].Trim();

                    if (String.IsNullOrEmpty(column))
                    {
                        continue;
                    }

                    var bytes = new UTF8Encoding(false).GetBytes(column);

                    uint unitId = 0;

                    for (int jj = 0; jj < bytes.Length; jj++)
                    {
                        unitId <<= 8;
                        unitId += bytes[jj];
                    }

                    writer.Write(column);
                    writer.Write(",");
                    writer.Write(unitId);
                    writer.Write(",");
                    writer.Write("\"");
                    writer.Write(table[ii][name].Trim().Replace("\"", "\"\""));
                    writer.Write("\",");
                    writer.Write("\"");
                    writer.Write(table[ii][text].Trim().Replace("\"", "\"\""));
                    writer.Write("\"");
                    writer.WriteLine();
                }
            }
        }

        /// <summary>
        /// Extracts the tokens from the command line.
        /// </summary>
        private static List<string> GetTokens(string commandLine)
        {
            List<string> tokens = new List<string>();

            bool quotedToken = false;
            StringBuilder token = new StringBuilder();

            for (int ii = 0; ii < commandLine.Length; ii++)
            {
                char ch = commandLine[ii];

                if (quotedToken)
                {
                    if (ch == '"')
                    {
                        if (token.Length > 0)
                        {
                            tokens.Add(token.ToString());
                            token = new StringBuilder();
                        }

                        quotedToken = false;
                        continue;
                    }

                    token.Append(ch);
                }
                else
                {
                    if (token.Length == 0)
                    {
                        if (ch == '"')
                        {
                            quotedToken = true;
                            continue;
                        }
                    }

                    if (Char.IsWhiteSpace(ch))
                    {
                        if (token.Length > 0)
                        {
                            tokens.Add(token.ToString());
                            token = new StringBuilder();
                        }

                        continue;
                    }

                    token.Append(ch);
                }
            }

            if (token.Length > 0)
            {
                tokens.Add(token.ToString());
            }

            return tokens;
        }

        /// <summary>
        /// Processes the command line arguments.
        /// </summary>
        private static bool ProcessCommandLine()
        {
            string commandLine = Environment.CommandLine;

            if (commandLine.IndexOf("-?") != -1)
            {
                StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Opc.Ua.ModelCompiler.HelpFile.txt"));
                MessageBox.Show(reader.ReadToEnd(), "Opc.Ua.ModelCompiler");
                reader.Close();
                return true;
            }

            List<string> tokens = GetTokens(commandLine);

            // launch gui if no arguments provided.
            if (tokens.Count == 1)
            {
                return false;
            }

            return ProcessCommandLine2(tokens);
        }

        /// <summary>
        /// Processes the command line arguments.
        /// </summary>
        private static bool ProcessCommandLine2(List<string> tokens)
        {
            try
            {
                List<string> designFiles = new List<string>();
                string identifierFile = null;
                string outputDir = null;
                bool generateIds = false;
                uint startId = 1;
                string stackRootDir = null;
                string ansicRootDir = null;
                bool generateMultiFile = false;
                bool useXmlInitializers = false;

                bool updateHeaders = false;
                string inputDirectory = ".";
                string filePattern = "*.xml";
                var licenseType = HeaderUpdateTool.LicenseType.MITXML;
                bool silent = false;

                for (int ii = 1; ii < tokens.Count; ii++)
                {
                    if (tokens[ii] == "-input")
                    {
                        if (ii >= tokens.Count - 1)
                        {
                            throw new ArgumentException("Incorrect number of parameters specified with the -input option.");
                        }

                        inputDirectory = tokens[++ii];
                        continue;
                    }

                    if (tokens[ii] == "-pattern")
                    {
                        if (ii >= tokens.Count - 1)
                        {
                            throw new ArgumentException("Incorrect number of parameters specified with the -pattern option.");
                        }

                        filePattern = tokens[++ii];
                        continue;
                    }

                    if (tokens[ii] == "-silent")
                    {
                        silent = true;
                        continue;
                    }

                    if (tokens[ii] == "-license")
                    {
                        if (ii >= tokens.Count - 1)
                        {
                            throw new ArgumentException("Incorrect number of parameters specified with the -license option.");
                        }

                        updateHeaders = true;
                        licenseType = (HeaderUpdateTool.LicenseType)Enum.Parse(typeof(HeaderUpdateTool.LicenseType), tokens[++ii]);
                        continue;
                    }

                    if (tokens[ii] == "-d2")
                    {
                        if (ii >= tokens.Count - 1)
                        {
                            throw new ArgumentException("Incorrect number of parameters specified with the -d2 option.");
                        }

                        designFiles.Add(tokens[++ii]);
                        continue;
                    }

                    if (tokens[ii] == "-d2")
                    {
                        if (ii >= tokens.Count - 1)
                        {
                            throw new ArgumentException("Incorrect number of parameters specified with the -d2 option.");
                        }

                        designFiles.Add(tokens[++ii]);
                        continue;
                    }

                    if (tokens[ii] == "-d2")
                    {
                        if (ii >= tokens.Count - 1)
                        {
                            throw new ArgumentException("Incorrect number of parameters specified with the -d2 option.");
                        }

                        designFiles.Add(tokens[++ii]);
                        continue;
                    }

                    if (tokens[ii] == "-c" || tokens[ii] == "-cg")
                    {
                        if (ii >= tokens.Count - 1)
                        {
                            throw new ArgumentException("Incorrect number of parameters specified with the -c or -cg option.");
                        }

                        generateIds = tokens[ii] == "-cg";
                        identifierFile = tokens[++ii];
                        continue;
                    }

                    if (tokens[ii] == "-o")
                    {
                        if (ii >= tokens.Count - 1)
                        {
                            throw new ArgumentException("Incorrect number of parameters specified with the -o option.");
                        }

                        outputDir = tokens[++ii];
                        continue;
                    }

                    if (tokens[ii] == "-o2")
                    {
                        if (ii >= tokens.Count - 1)
                        {
                            throw new ArgumentException("Incorrect number of parameters specified with the -o option.");
                        }

                        outputDir = tokens[++ii];
                        generateMultiFile = true;
                        continue;
                    }

                    if (tokens[ii] == "-id")
                    {
                        startId = Convert.ToUInt32(tokens[++ii]);
                        continue;
                    }

                    if (tokens[ii] == "-ansic")
                    {
                        if (ii >= tokens.Count - 1)
                        {
                            throw new ArgumentException("Incorrect number of parameters specified with the -stack option.");
                        }

                        ansicRootDir = tokens[++ii];
                        continue;
                    }

                    if (tokens[ii] == "-useXmlInitializers")
                    {
                        useXmlInitializers = true;
                        continue;
                    }

                    if (tokens[ii] == "-stack")
                    {
                        if (ii >= tokens.Count - 1)
                        {
                            throw new ArgumentException("Incorrect number of parameters specified with the -stack option.");
                        }

                        stackRootDir = tokens[++ii];
                        continue;
                    }
                }

                if (updateHeaders)
                {
                    HeaderUpdateTool.ProcessDirectory(inputDirectory, filePattern, licenseType, silent);
                    return true;
                }

                ModelGenerator2 generator = new ModelGenerator2();

                for (int ii = 0; ii < designFiles.Count; ii++)
                {
                    if (String.IsNullOrEmpty(designFiles[ii]))
                    {
                        throw new ArgumentException("No design file specified.");
                    }

                    if (!new FileInfo(designFiles[ii]).Exists)
                    {
                        throw new ArgumentException("The design file does not exist: " + designFiles[ii]);
                    }
                }

                if (String.IsNullOrEmpty(identifierFile))
                {
                    throw new ArgumentException("No identifier file specified.");
                }

                if (!new FileInfo(identifierFile).Exists)
                {
                    if (!generateIds)
                    {
                        throw new ArgumentException("The identifier file does not exist: " + identifierFile);
                    }

                    File.Create(identifierFile).Close();
                }

                generator.ValidateAndUpdateIds(designFiles, identifierFile, startId);

                if (!String.IsNullOrEmpty(stackRootDir))
                {
                    if (!new DirectoryInfo(stackRootDir).Exists)
                    {
                        throw new ArgumentException("The directory does not exist: " + stackRootDir);
                    }

                    StackGenerator.GenerateDotNet(stackRootDir);
                }

                if (!String.IsNullOrEmpty(ansicRootDir))
                {
                    if (!new DirectoryInfo(ansicRootDir).Exists)
                    {
                        throw new ArgumentException("The directory does not exist: " + stackRootDir);
                    }

                    StackGenerator.GenerateAnsiC(ansicRootDir);
                    generator.GenerateIdentifiersAndNamesForAnsiC(ansicRootDir);
                }

                if (!String.IsNullOrEmpty(outputDir))
                {
                    if (generateMultiFile)
                    {
                        generator.GenerateMultipleFiles(outputDir, useXmlInitializers);
                    }
                    else
                    {
                        generator.GenerateInternalSingleFile(outputDir, useXmlInitializers);
                    }
                }
            }
            catch (Exception e)
            {
                if (Environment.CommandLine.Contains(consoleOutputCommandLineArgument))
                {
                    System.Console.Error.WriteLine(e.Message);
                    System.Console.Error.WriteLine(e.StackTrace);
                }
                else
                {
                    new ExceptionDlg(e).ShowDialog();
                }

                return true;
            }

            return true;
        }
    }
}
