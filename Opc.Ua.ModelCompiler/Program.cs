/* ========================================================================
 * Copyright (c) 2005-2021 The OPC Foundation, Inc. All rights reserved.
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
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Extensions.CommandLineUtils;
using Opc.Ua;

namespace ModelCompiler
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ModelCompilerApplication.Run(args);
            }
            catch (CommandParsingException e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[{e.GetType().Name}] {e.Message} ({e.Command})");
                Environment.Exit(3);
            }
            catch (AggregateException e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[{e.GetType().Name}] {e.Message}");

                foreach (var ie in e.InnerExceptions)
                {
                    Console.WriteLine($">>> [{ie.GetType().Name}] {ie.Message}");
                }

                Environment.Exit(3);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[{e.GetType().Name}] {e.Message}");

                Exception ie = e.InnerException;

                while (ie != null)
                {
                    Console.WriteLine($">>> [{ie.GetType().Name}] {ie.Message}");
                    ie = ie.InnerException;
                }

                Console.WriteLine();
                Console.WriteLine($"========================");
                Console.WriteLine($"{e.StackTrace}");
                Console.WriteLine($"========================");
                Console.WriteLine();

                Environment.Exit(3);
            }
        }
    }
}
