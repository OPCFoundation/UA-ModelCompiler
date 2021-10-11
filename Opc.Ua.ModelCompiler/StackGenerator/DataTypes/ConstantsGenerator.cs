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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace CodeGenerator
{
    /// <summary>
    /// Generates code based on a UA Type Dictionary.
    /// </summary>
    public class ConstantsGenerator : CodeGenerator
    {
        #region Constructors
        /// <summary>
        /// Generates the code from the contents of the address space.
        /// </summary>
        public ConstantsGenerator(
            Language                  targetLanguage,
            string                    inputPath,
            string                    outputDirectory,
            Dictionary<string,string> knownFiles,
            string                    resourcePath)
        :
            base(inputPath, outputDirectory, knownFiles, resourcePath)
        {
            TargetLanguage = targetLanguage;
        }
        #endregion

        #region Public Properties
        const string TemplatePath = "ModelCompiler.StackGenerator.DataTypes.Templates.";
        #endregion

        #region Public Methods
        /// <summary>
        /// Generates the datatype files.
        /// </summary>
        public virtual void Generate(string namespacePrefix, string className, string identifierFilePath, bool renumberAll)
        {
            List<DataType> datatypes = GetDataTypeList();

            if (!String.IsNullOrEmpty(identifierFilePath))
            {
                if (renumberAll)
                {
                    File.Delete(identifierFilePath);
                }

                LoadIdentifiersFromFile(identifierFilePath, datatypes);
            }

            WriteTemplate_Constants(namespacePrefix, className, datatypes);
        }
        #endregion

        #region WriteTemplate Methods
        /// <summary>
        /// Writes the address space declaration file.
        /// </summary>
        private void WriteTemplate_Constants(string namespacePrefix, string className, List<DataType> datatypes)
        {
            m_className = className;

            // assign identifiers.
            foreach (DataType datatype in datatypes)
            {
                Constant constant = datatype as Constant;

                if (constant != null)
                {
                    if (constant.Name.StartsWith(Severity.Bad.ToString()))
                    {
                        constant.Severity = Severity.Bad;
                    }

                    if (constant.Name.StartsWith(Severity.Good.ToString()))
                    {
                        constant.Severity = Severity.Good;
                    }

                    if (constant.Name.StartsWith(Severity.Uncertain.ToString()))
                    {
                        constant.Severity = Severity.Uncertain;
                    }
                }
            }

            if (TargetLanguage == Language.CSV)
            {
                datatypes = new List<DataType>(datatypes);

                datatypes.Insert(0, new Constant()
                {
                    Severity = Severity.Bad,
                    Name = "Bad",
                    Identifier = 0,
                    IdentifierSpecified = true,
                    Documentation = new Documentation() { Text = new string[] { "The operation failed." } }
                });

                datatypes.Insert(0, new Constant()
                {
                    Severity = Severity.Uncertain,
                    Name = "Uncertain",
                    Identifier = 0,
                    IdentifierSpecified = true,
                    QName = new XmlQualifiedName("Uncertain", Namespaces.OpcUa),
                    Documentation = new Documentation() { Text = new string[] { "The operation was uncertain." } }
                });

                datatypes.Insert(0, new Constant()
                {
                    Severity = Severity.Good,
                    Name = "Good",
                    Identifier = 0,
                    IdentifierSpecified = true,
                    QName = new XmlQualifiedName("Good", Namespaces.OpcUa),
                    Documentation = new Documentation() { Text = new string[] { "The operation succeeded." } }
                });
            }

            string fileName = null;

            switch (TargetLanguage)
            {
                case Language.DotNet:
                {
                    fileName = String.Format(@"{0}\{1}.{2}.cs", OutputDirectory, namespacePrefix, className);
                    m_templateSuffix = ".cs";
                    break;
                }

                case Language.AnsiC:
                {
                    fileName = String.Format(@"{0}\{1}_{2}.h", OutputDirectory, namespacePrefix, className);
                    fileName = fileName.ToLower();
                    m_templateSuffix = ".h";
                    break;
                }

                case Language.CSV:
                {
                    fileName = String.Format(@"{0}\{1}.{2}.csv", OutputDirectory, namespacePrefix, className);
                    m_templateSuffix = ".csv";
                    break;
                }
            }

            StreamWriter writer = new StreamWriter(fileName, false);

            try
            {
                string templatePath = TemplatePath + "Constants.File" + m_templateSuffix;

                if (className == "Identifiers")
                {
                    templatePath = TemplatePath + "Constants.DataTypes" + m_templateSuffix;
                }

                Template template = new Template(writer, templatePath, Assembly.GetExecutingAssembly());

                template.AddReplacement("_Date_", DateTime.Now);
                template.AddReplacement("_Prefix_", namespacePrefix);
                template.AddReplacement("_ClassName_", className);
                template.AddReplacement("_FileName_", namespacePrefix + '_' + className);

                AddTemplate(
                    template,
                    "// ListOfIdentifiers",
                    TemplatePath + "Constants.Constant" + m_templateSuffix,
                    datatypes,
                    new LoadTemplateEventHandler(LoadTemplate_Constant),
                    new WriteTemplateEventHandler(WriteTemplate_Constant));

                AddTemplate(
                    template,
                    "// ListOfEncodings",
                    TemplatePath + "Constants.Constant" + m_templateSuffix,
                    datatypes,
                    new LoadTemplateEventHandler(LoadTemplate_Constant),
                    new WriteTemplateEventHandler(WriteTemplate_Constant));

                Context context = new Context();
                context.BlankLine = TargetLanguage != Language.CSV;
                template.WriteTemplate(context);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Writes the default value for a field.
        /// </summary>
        private string LoadTemplate_Constant(Template template, Context context)
        {
            DataType datatype = context.Target as DataType;

            if (datatype == null)
            {
                return null;
            }

            if (context.Token == "// ListOfEncodings")
            {
                if (datatype is ComplexType)
                {
                    return TemplatePath + "Constants.Encodings" + m_templateSuffix;
                }

                return null;
            }

            return context.TemplatePath;
        }

        /// <summary>
        /// Writes a constant.
        /// </summary>
        private bool WriteTemplate_Constant(Template template, Context context)
        {
            DataType datatype = context.Target as DataType;

            if (datatype == null)
            {
                return false;
            }

            Constant constant = context.Target as Constant;

            if (constant != null)
            {
                if (!String.IsNullOrEmpty(constant.Value))
                {
                    template.AddReplacement("_IdType_", "string");
                    template.AddReplacement("_Identifier_", String.Format("\"{0}\"", constant.Value));
                    template.AddReplacement("_ClassName_", "_" + m_className);
                }

                else
                {
                    if (constant.Severity != Severity.None)
                    {
                        context.BlankLine = TargetLanguage != Language.CSV;

                        uint id = Convert.ToUInt32(constant.Identifier);
                        id <<= 16;

                        switch (constant.Severity)
                        {
                            case Severity.Bad: { id += 0x80000000; break; }
                            case Severity.Uncertain: { id += 0x40000000; break; }
                        }

                        template.AddReplacement("_IdType_", "uint");
                        template.AddReplacement("_Identifier_", String.Format("0x{0:X8}", id));
                        template.AddReplacement("_ClassName_", String.Empty);
                    }
                    else
                    {
                        template.AddReplacement("_IdType_", "uint");
                        template.AddReplacement("_Identifier_", constant.Identifier);
                        template.AddReplacement("_ClassName_", "_" + m_className);
                    }
                }
            }

            string symbolicId = datatype.Name;

            if (constant != null)
            {
                if (constant.Severity != Severity.None && constant.Identifier != 0)
                {
                    string name = datatype.Name;

                    int index = name.IndexOf('_');

                    if (index != -1)
                    {
                        name = name.Substring(index+1);
                    }

                    symbolicId = String.Format("{0}{1}", constant.Severity, name);
                }
            }
            else
            {
                template.AddReplacement("_IdType_", "uint");
                template.AddReplacement("_Identifier_", datatype.Identifier);
                template.AddReplacement("_ClassName_", "Id");
            }

            template.AddReplacement("_SymbolicId_", symbolicId);

            string description = GetDescription(datatype.Documentation);

            if (String.IsNullOrEmpty(description))
            {
                description = String.Format("The identifier for the {0} datatype.", symbolicId);
            }

            template.AddReplacement("_Description_", description);

            ComplexType complexType = context.Target as ComplexType;

            if (complexType != null)
            {
                template.AddReplacement("_XmlEncodingId_", complexType.XmlEncodingId);
                template.AddReplacement("_BinaryEncodingId_", complexType.BinaryEncodingId);
            }

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Returns the list of datatypes to process.
        /// </summary>
        protected List<DataType> GetDataTypeList()
        {
            // collect datatypes with the specified type.
            List<DataType> datatypes = new List<DataType>();

            // include identifiers from the target dictionary.
            foreach (DataType datatype in Dictionary.Items)
            {
                ServiceType serviceType = datatype as ServiceType;

                if (serviceType == null)
                {
                    datatypes.Add(datatype);
                    continue;
                }

                if (serviceType.Request != null)
                {
                    ComplexType requestType = new ComplexType();

                    requestType.Name = String.Format("{0}Request", serviceType.Name);
                    requestType.QName = new XmlQualifiedName(requestType.Name, serviceType.QName.Namespace);
                    requestType.Field = serviceType.Request;

                    datatypes.Add(requestType);
                }

                if (serviceType.Response != null)
                {
                    ComplexType responseType = new ComplexType();

                    responseType.Name = String.Format("{0}Response", serviceType.Name);
                    responseType.QName = new XmlQualifiedName(responseType.Name, serviceType.QName.Namespace);
                    responseType.Field = serviceType.Response;

                    datatypes.Add(responseType);
                }
            }

            return datatypes;
        }

        /// <summary>
        /// Loads the identifiers from a CSV file.
        /// </summary>
        private void LoadIdentifiersFromFile(string filePath, List<DataType> datatypes)
        {
            Dictionary<string,int> identifiers = new Dictionary<string,int>();
            SortedDictionary<int, string> assignedIdentifiers = new SortedDictionary<int, string>();

            int maxId = 1;

            if (File.Exists(filePath))
            {
                StreamReader reader = new StreamReader(filePath);

                try
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if (String.IsNullOrEmpty(line))
                        {
                            continue;
                        }

                        int index = line.IndexOf(',');

                        if (index == -1)
                        {
                            continue;
                        }

                        // remove the node class if it is present.
                        int lastIndex = line.LastIndexOf(',');

                        if (lastIndex != -1 && index != lastIndex)
                        {
                            line = line.Substring(0, lastIndex);
                        }

                        try
                        {
                            string name = line.Substring(0,index).Trim();

                            int uid = Convert.ToInt32(line.Substring(index+1).Trim());

                            if (maxId <= uid)
                            {
                                maxId = uid+1;
                            }

                            identifiers[name] = uid;
                            assignedIdentifiers[uid] = name;
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
                finally
                {
                    reader.Close();
                }
            }

            SortedDictionary<int,string> uniqueIdentifiers = new SortedDictionary<int,string>();
            Dictionary<string,int> duplicateIdentifiers = new Dictionary<string,int>();

            foreach (DataType datatype in datatypes)
            {
                // using existing id or assign a new one.
                if (!identifiers.ContainsKey(datatype.Name))
                { 
                    int nextId = 200;
                    while (assignedIdentifiers.ContainsKey(nextId)) nextId++;
                    datatype.Identifier = nextId;
                    datatype.IdentifierSpecified = true;
                    assignedIdentifiers.Add(nextId, datatype.Name);
                }
                else
                {
                    datatype.Identifier = (int)identifiers[datatype.Name];
                    datatype.IdentifierSpecified = true;
                }

                // check for duplicates.
                if (uniqueIdentifiers.ContainsKey(datatype.Identifier))
                {
                    duplicateIdentifiers.Add(datatype.Name, datatype.Identifier);
                }
                else
                {
                    uniqueIdentifiers.Add(datatype.Identifier, datatype.Name);
                }

                // find identifiers for data type encodings.
                ComplexType complexType = datatype as ComplexType;

                if (complexType != null)
                {
                    string name = String.Format("{0}_Encoding_DefaultXml", datatype.Name);

                    if (!identifiers.ContainsKey(name))
                    {
                        complexType.XmlEncodingId = maxId++;
                    }
                    else
                    {
                        complexType.XmlEncodingId = (int)identifiers[name];
                    }

                    // check for duplicates.
                    if (uniqueIdentifiers.ContainsKey(complexType.XmlEncodingId))
                    {
                        duplicateIdentifiers.Add(name, complexType.XmlEncodingId);
                    }
                    else
                    {
                        uniqueIdentifiers.Add(complexType.XmlEncodingId, name);
                    }

                    name = String.Format("{0}_Encoding_DefaultBinary", datatype.Name);

                    if (!identifiers.ContainsKey(name))
                    {
                        complexType.BinaryEncodingId = maxId++;
                    }
                    else
                    {
                        complexType.BinaryEncodingId = (int)identifiers[name];
                    }

                    // check for duplicates.
                    if (uniqueIdentifiers.ContainsKey(complexType.BinaryEncodingId))
                    {
                        duplicateIdentifiers.Add(name, complexType.BinaryEncodingId);
                    }
                    else
                    {
                        uniqueIdentifiers.Add(complexType.BinaryEncodingId, name);
                    }
                }
            }

            // check for duplicate datatypes.
            if (duplicateIdentifiers.Count > 0)
            {
                StringBuilder buffer = new StringBuilder();

                buffer.Append("Duplicate identifiers for these datatypes:\r\n");

                foreach (KeyValuePair<string,int> current in duplicateIdentifiers)
                {
                    buffer.AppendFormat("{0},0x{1:X8}\r\n", current.Key, current.Value);
                }

                throw new InvalidOperationException(buffer.ToString());
            }

            // update the CSV file.
            StreamWriter writer = new StreamWriter(filePath, false);

            try
            {
                foreach (var ii in assignedIdentifiers)
                {
                    if (uniqueIdentifiers.ContainsKey(ii.Key))
                    {
                        writer.WriteLine("{0},{1}", ii.Value, ii.Key);
                    }
                    else
                    {
                        writer.WriteLine("{0},{1},Unassigned", ii.Value, ii.Key);
                    }
                }
            }
            finally
            {
                writer.Close();
            }
        }
        #endregion

        #region Private Fields
        private string m_className;
        private string m_templateSuffix;
        #endregion
    }
}
