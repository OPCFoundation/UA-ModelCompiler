/* ========================================================================
 * Copyright (c) 2005-2011 The OPC Foundation, Inc. All rights reserved.
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

                for (int ii = 1; ii < tokens.Count; ii++)
                {
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
                            throw new ArgumentException("Incorrect number of parameters specified with the -ansic option.");
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
                        throw new ArgumentException("The directory does not exist: " + ansicRootDir);
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
