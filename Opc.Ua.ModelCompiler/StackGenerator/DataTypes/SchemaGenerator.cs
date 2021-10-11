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
    /// Generates a schema based on a UA Type Dictionary.
    /// </summary>
    public class SchemaGenerator
    {
        #region Constructors
        /// <summary>
        /// Loads and validates the type dictionary.
        /// </summary>
        protected SchemaGenerator(string inputPath, string outputDirectory, Dictionary<string,string> knownFiles, string resourcePath)
        {
            // load and validate type dictionary.
            m_validator = new TypeDictionaryValidator(knownFiles, resourcePath);
            m_validator.Validate(inputPath);

            // save output directory.
            m_outputDirectory = outputDirectory;

            // index namespace uris.
            IndexNamespaceUris();
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
        /// The namespace uris referenced by types in the dictionary.
        /// </summary>
        protected IList<string> NamespaceUris
        {
            get { return m_namespaceUris; }
        }

        /// <summary>
        /// The directory used to place any output files.
        /// </summary>
        protected string OutputDirectory
        {
            get { return m_outputDirectory; }
        }

        /// <summary>
        /// The current target namespace.
        /// </summary>
        protected string TargetNamespace
        {
            get
            {
                if (m_namespaceUris.Count > 0)
                {
                    return m_namespaceUris[0];
                }

                return null;
            }

            set
            {
                // ensure the target namespace is the first namespace.
                int index = m_namespaceUris.IndexOf(value);

                if (index != 0)
                {
                    if (index != -1)
                    {
                        m_namespaceUris.RemoveAt(index);
                    }

                    m_namespaceUris.Insert(0, value);
                }
            }
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Returns the datatypes in the dictionary.
        /// </summary>
        protected List<DataType> GetListOfTypes(bool exportAll)
        {
            return GetListOfTypes(null, exportAll, false);
        }

        /// <summary>
        /// Returns the datatypes in the dictionary.
        /// </summary>
        protected List<DataType> GetListOfTypes(Type type, bool exportAll, bool exportApi)
        {
            List<DataType> datatypes = new List<DataType>();

            if (exportAll)
            {
                foreach (TypeDictionary dictionary in Validator.LoadedFiles.Values)
                {
                    if (dictionary.TargetNamespace != Namespaces.OpcUaBuiltInTypes)
                    {
                        CollectDatatypes(dictionary, type, exportApi, datatypes);
                    }
                }
            }

            CollectDatatypes(Validator.Dictionary, type, exportApi, datatypes);

            return datatypes;
        }

        /// <summary>
        /// Returns the datatypes in the dictionary.
        /// </summary>
        protected void CollectDatatypes(TypeDictionary dictionary, Type type,  bool exportApi, List<DataType> datatypes)
        {
            foreach (DataType datatype in dictionary.Items)
            {
                ComplexType complexType = datatype as ComplexType;

                if (complexType != null)
                {
                    AddNestedTypes(type, complexType.Field, datatypes);
                }

                ServiceType serviceType = datatype as ServiceType;

                if (serviceType != null)
                {
                    if (exportApi)
                    {
                        if (serviceType.InterfaceType == InterfaceType.SecureChannel)
                        {
                            continue;
                        }
                    }

                    AddNestedTypes(type, serviceType.Request,  datatypes);
                    AddNestedTypes(type, serviceType.Response, datatypes);
                }

                if (type == null || type.IsInstanceOfType(datatype))
                {
                    datatypes.Add(datatype);
                }
            }
        }

        /// <summary>
        /// Adds any nested complex types.
        /// </summary>
        protected void AddNestedTypes(Type type, FieldType[] fields, List<DataType> dataypes)
        {
            if (fields != null)
            {
                foreach (FieldType fieldType in fields)
                {
                    if (fieldType.ComplexType != null)
                    {
                        // recursively add nested types.
                        AddNestedTypes(type, fieldType.ComplexType.Field, dataypes);

                        if (type == null || type.IsInstanceOfType(fieldType.ComplexType))
                        {
                            dataypes.Add(fieldType.ComplexType);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Returns a name qualified with a namespace prefix.
        /// </summary>
        protected string GetPrefixedName(XmlQualifiedName qname)
        {
            if (IsNull(qname))
            {
                return String.Empty;
            }

            if (qname.Namespace == Namespaces.OpcUaBuiltInTypes)
            {
                return String.Format("ua:{0}", qname.Name);
            }

            int index = m_namespaceUris.IndexOf(qname.Namespace);

            if (index > 0)
            {
                return String.Format("s{0}:{1}", index-1, qname.Name);
            }

            return qname.Name;
        }

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
        /// Returns the display name for a browse name.
        /// </summary>
        protected string GetDisplayName(XmlQualifiedName browseName)
        {
            if (IsNull(browseName))
            {
                return null;
            }

            StringBuilder buffer = new StringBuilder();

            for (int ii = 0; ii < browseName.Name.Length-1; ii++)
            {
                buffer.Append(browseName.Name[ii]);

                if (Char.IsLower(browseName.Name[ii]) && Char.IsUpper(browseName.Name[ii + 1]))
                {
                    buffer.Append(' ');
                }
            }

            buffer.Append(browseName.Name[browseName.Name.Length-1]);

            return buffer.ToString();
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
        /// Creates a description from the documentation element.
        /// </summary>
        protected void CreateDescription(Template template, string token, Documentation documentation)
        {
            StringBuilder buffer = new StringBuilder();

            if (documentation != null)
            {
                if (documentation.Text != null && documentation.Text.Length > 0)
                {
                    for (int ii = 0; ii < documentation.Text.Length; ii++)
                    {
                        if (buffer.Length > 0)
                        {
                            buffer.Append("\r\n");
                        }

                        buffer.Append(documentation.Text[ii]);
                    }
                }
            }

            template.AddReplacement(token, buffer.ToString());
        }

        /// <summary>
        /// Fetches all of the fields for a complex type by following the base type.
        /// </summary>
        protected void GetFields(ComplexType complexType, List<FieldType> fields)
        {
            if (!IsNull(complexType.BaseType))
            {
                ComplexType baseType = m_validator.ResolveType(complexType.BaseType) as ComplexType;

                if (baseType != null)
                {
                    GetFields(baseType, fields);
                }
            }

            if (complexType.Field != null)
            {
                fields.AddRange(complexType.Field);
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Saves a namespace uri.
        /// </summary>
        private void IndexNamespaceUri(string namespaceUri)
        {
            if (!String.IsNullOrEmpty(namespaceUri) && namespaceUri != Namespaces.OpcUaBuiltInTypes)
            {
                if (!m_namespaceUris.Contains(namespaceUri))
                {
                    m_namespaceUris.Add(namespaceUri);
                }
            }
        }

        /// <summary>
        /// Collects namespaces uris referenced by the types in the dictionary.
        /// </summary>
        private void IndexNamespaceUris()
        {
            m_namespaceUris = new List<string>();

            foreach (DataType datatype in Dictionary.Items)
            {
                IndexNamespaceUri(datatype.QName.Namespace);

                TypeDeclaration declaration = datatype as TypeDeclaration;

                if (declaration != null)
                {
                    if (!IsNull(declaration.SourceType))
                    {
                        IndexNamespaceUri(declaration.SourceType.Namespace);
                    }
                }

                ComplexType complexType = datatype as ComplexType;

                if (complexType != null)
                {
                    if (!IsNull(complexType.BaseType))
                    {
                        IndexNamespaceUri(complexType.BaseType.Namespace);
                    }

                    foreach (FieldType fieldType in ((ComplexType)datatype).Field)
                    {
                        IndexNamespaceUri(fieldType.DataType.Namespace);
                    }
                }

                ServiceType serviceType = datatype as ServiceType;

                if (serviceType != null)
                {
                    foreach (FieldType fieldType in serviceType.Request)
                    {
                        IndexNamespaceUri(fieldType.DataType.Namespace);
                    }

                    foreach (FieldType fieldType in serviceType.Response)
                    {
                        IndexNamespaceUri(fieldType.DataType.Namespace);
                    }
                }
            }
        }
        #endregion

        #region Private Fields
        private string m_outputDirectory;
        private TypeDictionaryValidator m_validator;
        private List<string> m_namespaceUris;
        #endregion
    }
}
