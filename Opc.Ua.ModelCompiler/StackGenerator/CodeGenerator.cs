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
    public class CodeGenerator
    {
        #region Constructors
        /// <summary>
        /// Generates the code from the contents of the address space.
        /// </summary>
        public CodeGenerator()
        {
        }

        /// <summary>
        /// Generates the code from the contents of the address space.
        /// </summary>
        public CodeGenerator(string inputPath, string outputDirectory, Dictionary<string,string> knownFiles, string resourcePath)
        {
            // load and validate type dictionary.
            m_validator = new TypeDictionaryValidator(knownFiles, resourcePath);
            m_validator.Validate(inputPath);

            // save output directory.
            m_outputDirectory = outputDirectory;
            m_dictionariesToExport = new List<string>();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The dictionaries that should be exported in addition to the target dictionary.
        /// </summary>
        public List<string> DictionariesToExport
        {
            get { return m_dictionariesToExport; }
        }
        #endregion

        #region Protected Properties
        /// <summary>
        /// The validator used to verify the type dictionary.
        /// </summary>
        protected TypeDictionaryValidator Validator
        {
            get { return m_validator; }
        }

        /// <summary>
        /// The dictionary being processed.
        /// </summary>
        protected TypeDictionary Dictionary
        {
            get { return m_validator.Dictionary; }
        }

        /// <summary>
        /// The name of the dictionary being processed.
        /// </summary>
        protected string DictionaryName
        {
            get { return m_dictionaryName;  }
            set { m_dictionaryName = value; }
        }

        /// <summary>
        /// The directory used to place any output files.
        /// </summary>
        protected string OutputDirectory
        {
            get { return m_outputDirectory; }
        }

        /// <summary>
        /// The target language to use for the output.
        /// </summary>
        protected Language TargetLanguage
        {
            get { return m_targetLanguage;  }
            set { m_targetLanguage = value; }
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Checks for a null qualified name.
        /// </summary>
        protected bool IsNull(XmlQualifiedName qname)
        {
            if (qname == null)
            {
                return true;
            }

            if (String.IsNullOrEmpty(qname.Name))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Ensures the first character is lower case.
        /// </summary>
        protected string ToLowerCamelCase(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return name;
            }

            if (Char.IsLower(name[0]))
            {
                return name;
            }

            return String.Format("{0}{1}", Char.ToLower(name[0]), name.Substring(1));
        }

        /// <summary>
        /// Initializes a template to use for substitution.
        /// </summary>
        protected void AddTemplate(
            Template                  template,
            string                    replacement,
            string                    templatePath,
            IEnumerable               targets,
            LoadTemplateEventHandler  onLoad,
            WriteTemplateEventHandler onWrite)
        {
            template.Replacements.Add(replacement, null);

            // create a collection of targets.
            ArrayList targetList = new ArrayList();

            if (targets != null)
            {
                foreach (object target in targets)
                {
                    targetList.Add(target);
                }
            }

            TemplateDefinition definition = new TemplateDefinition();

            definition.TemplatePath = templatePath;
            definition.Targets      = targetList;

            if (onLoad != null)
            {
                definition.LoadTemplate += onLoad;
            }

            if (onWrite != null)
            {
                definition.WriteTemplate += onWrite;
            }

            template.Templates.Add(replacement, definition);
        }

        /// <summary>
        /// Returns the list of datatypes to process.
        /// </summary>
        protected List<DataType> GetDataTypeList(Type type, bool exportAll, bool exportApi)
        {
            // collect datatypes with the specified type.
            List<DataType> datatypes = new List<DataType>();

            foreach (TypeDictionary dictionary in m_validator.LoadedFiles.Values)
            {
                if (dictionary.TargetNamespace != Namespaces.OpcUaBuiltInTypes)
                {
                    if (exportAll || m_dictionariesToExport.Contains(dictionary.TargetNamespace))
                    {
                        CollectDatatypes(dictionary, type, datatypes, exportApi);
                    }
                }
            }

            // include identifiers from the target dictionary.
            CollectDatatypes(m_validator.Dictionary, type, datatypes, exportApi);

            return datatypes;
        }

        /// <summary>
        /// Returns the list of datatypes to process.
        /// </summary>
        protected void CollectDatatypes(TypeDictionary dictionary, Type type, List<DataType> datatypes, bool exportApi)
        {
            // include identifiers from the target dictionary.
            foreach (DataType datatype in dictionary.Items)
            {
                if (type == null || type.IsInstanceOfType(datatype))
                {
                    ComplexType complexType = datatype as ComplexType;

                    if (complexType != null)
                    {
                        GetDataTypeList(type, complexType.Field, datatypes);
                    }

                    ServiceType serviceType = datatype as ServiceType;

                    if (serviceType != null)
                    {
                        if (exportApi && serviceType.InterfaceType == InterfaceType.SecureChannel)
                        {
                            continue;
                        }

                        GetDataTypeList(type, serviceType.Request, datatypes);
                        GetDataTypeList(type, serviceType.Response, datatypes);
                    }

                    datatypes.Add(datatype);
                }
            }
        }

        /// <summary>
        /// Creates a description from a documentation element.
        /// </summary>
        protected string GetDescription(Documentation documentation)
        {
            if (documentation == null || documentation.Text == null)
            {
                return null;
            }

            StringBuilder buffer = new StringBuilder();

            for (int ii = 0; ii < documentation.Text.Length; ii++)
            {
                if (buffer.Length > 0)
                {
                    buffer.Append(' ');
                }

                buffer.Append(documentation.Text[ii]);
            }

            return buffer.ToString();
        }

        /// <summary>
        /// Returns a name qualified with a namespace prefix.
        /// </summary>
        protected string GetDotNetTypeName(XmlQualifiedName qname, int valueRank)
        {
            if (IsNull(qname))
            {
                return String.Empty;
            }

            DataType datatype = Validator.ResolveType(qname);

            if (datatype != null)
            {
                qname = datatype.QName;
            }

            string type = qname.Name;

            if (qname.Namespace == Namespaces.OpcUaBuiltInTypes)
            {
                // translate built-in types to .NET types.
                if (valueRank < 0)
                {
                    switch (qname.Name)
                    {
                        case "Boolean":    { type = "bool";       break; }
                        case "SByte":      { type = "sbyte";      break; }
                        case "Byte":       { type = "byte";       break; }
                        case "Int16":      { type = "short";      break; }
                        case "UInt16":     { type = "ushort";     break; }
                        case "Int32":      { type = "int";        break; }
                        case "UInt32":     { type = "uint";       break; }
                        case "Int64":      { type = "long";       break; }
                        case "UInt64":     { type = "ulong";      break; }
                        case "Float":      { type = "float";      break; }
                        case "Double":     { type = "double";     break; }
                        case "String":     { type = "string";     break; }
                        case "DateTime":   { type = "DateTime";   break; }
                        case "Guid":       { type = "Uuid";       break; }
                        case "ByteString": { type = "byte[]";     break; }
                    }
                }
                else
                {
                    switch (qname.Name)
                    {
                        case "Guid": { type = "Uuid"; break; }
                    }
                }
            }

            if (valueRank >= 0)
            {
                return String.Format("{0}Collection", type);
            }

            return type;
        }

        /// <summary>
        /// Returns a name qualified with a namespace prefix.
        /// </summary>
        protected string GetAnsiCTypeName(XmlQualifiedName qname, int valueRank, string prefix)
        {
            if (IsNull(qname))
            {
                return String.Empty;
            }

            string type = qname.Name;

            DataType datatype = Validator.ResolveType(qname);

            if (datatype != null)
            {
                type = datatype.Name;
            }

            if (qname.Namespace == Namespaces.OpcUaBuiltInTypes)
            {
                type = String.Format("OpcUa_{0}", type);
            }
            else
            {
                type = String.Format("{1}_{0}", type, prefix);
            }

            if (valueRank >= 0)
            {
                return String.Format("{0}*", type);
            }

            return type;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Returns the list of datatypes to process.
        /// </summary>
        private void GetDataTypeList(Type type, FieldType[] fields, List<DataType> datatypes)
        {
            if (fields != null)
            {
                foreach (FieldType field in fields)
                {
                    if (field.ComplexType != null)
                    {
                        if (type == null || type.IsInstanceOfType(field.ComplexType))
                        {
                            datatypes.Add(field.ComplexType);
                            GetDataTypeList(type, field.ComplexType.Field, datatypes);
                        }
                    }
                }
            }
        }
        #endregion

        #region Private Fields
        private string m_outputDirectory;
        private TypeDictionaryValidator m_validator;
        private string m_dictionaryName;
        private Language m_targetLanguage;
        private List<string> m_dictionariesToExport;
        #endregion
    }

    /// <summary>
    /// The target programming language.
    /// </summary>
    public enum Language
    {
        /// <summary>
        /// .NET 3.0
        /// </summary>
        DotNet,

        /// <summary>
        /// Ansi C
        /// </summary>
        AnsiC,

        /// <summary>
        /// Ansi C Wireshark Parsing Code
        /// </summary>
        Wireshark,

        /// <summary>
        /// CSV
        /// </summary>
        CSV
    }
}
