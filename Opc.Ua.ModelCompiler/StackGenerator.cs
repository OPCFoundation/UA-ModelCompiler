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

using Opc.Ua.Schema.Binary;
using Opc.Ua.Schema.Xml;
using CodeGenerator;

namespace ModelCompiler
{
    class StackGenerator
    {
        public class Files
        {
            public Dictionary<string, string> XmlSchemas;
            public Dictionary<string, string> BinarySchemas;
            public Dictionary<string, string> NodeDictionaries;
            public Dictionary<string, string> TypeDictionaries;

            public Files()
            {
                XmlSchemas = new Dictionary<string, string>();
                BinarySchemas = new Dictionary<string, string>();
                NodeDictionaries = new Dictionary<string, string>();
                TypeDictionaries = new Dictionary<string, string>();
            }
        }

        static void ProcessDictionary(string name, string input, string output, Files files, string specificationVersion)
        {
            var resourcePath = "ModelCompiler.Design";

            if (!String.IsNullOrEmpty(specificationVersion))
            {
                resourcePath = $"ModelCompiler.Design.{specificationVersion}";
            }

            TypeDictionaryValidator validator = new TypeDictionaryValidator(resourcePath);
            validator.Validate(input);

            string basePath = String.Format(@"{0}\{1}", output, name);
            string fileName = String.Format("Opc.Ua{0}", name);

            XmlSchemaGenerator generator1 = new XmlSchemaGenerator(input, output, files.TypeDictionaries, resourcePath);

            generator1.TypesNamespace = "http://opcfoundation.org/UA/2008/02/Types.xsd";
            generator1.ServicesNamespace = "http://opcfoundation.org/UA/2008/02/Services.wsdl";
            generator1.EndpointsNamespace = "http://opcfoundation.org/UA/2008/02/Endpoints.wsdl";

            generator1.Generate(fileName, "Opc.Ua", name, true);
            string filePath = String.Format(@"{0}\Opc.Ua.Types.xsd", output);

            XmlSchemaValidator2 validator1 = new XmlSchemaValidator2(files.XmlSchemas);
            validator1.Validate(filePath);
            files.XmlSchemas[validator1.TargetSchema.TargetNamespace] = filePath;
            System.IO.File.Delete(filePath);

            fileName = "Opc.Ua.Types";
            BinarySchemaGenerator generator2 = new BinarySchemaGenerator(input, output, files.TypeDictionaries, resourcePath);
            generator2.Generate(fileName, true, "http://opcfoundation.org/UA/");
            filePath = String.Format(@"{0}\{1}.bsd", output, fileName);

            BinarySchemaValidator validator2 = new BinarySchemaValidator(files.BinarySchemas);
            validator2.Validate(filePath).Wait();
            files.BinarySchemas[validator2.Dictionary.TargetNamespace] = filePath;
            System.IO.File.Delete(filePath);
        }

        static void GenerateAnsiC(Files files, string modelDir, string csvDir, string outputDir, string specificationVersion)
        {
            ConstantsGenerator generator3 = new ConstantsGenerator(
                Language.AnsiC,
                $"{modelDir}UA Attributes.xml",
                outputDir,
                files.NodeDictionaries,
                null);

            generator3.Generate(
                "OpcUa",
                "Attributes",
                $"{csvDir}UA Attributes.csv",
                false);

            ConstantsGenerator generator4 = new ConstantsGenerator(
                Language.AnsiC,
                $"{modelDir}UA Status Codes.xml",
                outputDir,
                files.NodeDictionaries,
                null);

            generator4.Generate(
                "OpcUa",
                "StatusCodes",
                $"{csvDir}UA Status Codes.csv",
                false);

            AnsiCGenerator generator7 = new AnsiCGenerator(
                $"{modelDir}UA Core Services.xml",
                outputDir,
                files.TypeDictionaries,
                null);

            generator7.Generate("OpcUa", "Core", true);
        }

        static void GenerateDotNet(Files files, string modelDir, string csvDir, string outputDir, string specificationVersion)
        {
            ConstantsGenerator generator7 = new ConstantsGenerator(
                Language.DotNet,
                $"{modelDir}UA Attributes.xml",
                outputDir,
                files.NodeDictionaries,
                null);

            generator7.Generate(
                "Opc.Ua",
                "Attributes",
                $"{csvDir}UA Attributes.csv",
                false);

            ConstantsGenerator generator8 = new ConstantsGenerator(
                Language.DotNet,
                $"{modelDir}UA Status Codes.xml",
                outputDir,
                files.NodeDictionaries,
                null);

            generator8.Generate(
                "Opc.Ua",
                "StatusCodes",
                $"{csvDir}UA Status Codes.csv",
                false);

            ConstantsGenerator generator9 = new ConstantsGenerator(
                Language.CSV,
                $"{modelDir}UA Status Codes.xml",
                outputDir,
                files.NodeDictionaries,
                null);

            generator9.Generate(
                "Opc.Ua",
                "StatusCodes",
                $"{csvDir}UA Status Codes.csv",
                false);

            DotNetGenerator generator10 = new DotNetGenerator(
                $"{modelDir}UA Core Services.xml",
                outputDir,
                files.TypeDictionaries,
                null);

            generator10.Generate("Opc.Ua", "Core", true);
        }

        public static void GenerateDotNet(
            IList<string> designFilePaths,
            string identifierFilePath, 
            string rootDir, 
            string specificationVersion)
        {
            string modelDir = Path.GetDirectoryName(designFilePaths[0]) + "\\";
            string csvDir = Path.GetDirectoryName(identifierFilePath) + "\\";

            Files files = new Files();

            ProcessDictionary(
                "",
                $"{modelDir}UA Core Services.xml",
                rootDir,
                files,
                specificationVersion);

            GenerateDotNet(files, modelDir, csvDir, rootDir, specificationVersion);
        }

        public static void GenerateAnsiC(
            IList<string> designFilePaths,
            string identifierFilePath, 
            string rootDir, 
            string specificationVersion)
        {
            string modelDir = Path.GetDirectoryName(designFilePaths[0]) + "\\";
            string csvDir = Path.GetDirectoryName(identifierFilePath) + "\\";

            Files files = new Files();

            ProcessDictionary(
                "",
                $"{modelDir}UA Core Services.xml",
                rootDir,
                files,
                specificationVersion);

            GenerateAnsiC(files, modelDir, csvDir, rootDir, specificationVersion);
        }
    }
}
