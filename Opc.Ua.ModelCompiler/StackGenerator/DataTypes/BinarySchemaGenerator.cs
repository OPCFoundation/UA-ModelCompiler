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
using Opc.Ua;

namespace CodeGenerator
{
    /// <summary>
    /// Generates files used to describe data types.
    /// </summary>
    public class BinarySchemaGenerator : SchemaGenerator
    {
        #region Constructors
        /// <summary>
        /// Generates the code from the contents of the address space.
        /// </summary>
        public BinarySchemaGenerator(
            string inputPath,
            string outputDirectory,
            Dictionary<string,string> knownFiles,
            string resourcePath) 
        : 
            base (inputPath, outputDirectory, knownFiles, resourcePath)
        {
        }
        #endregion

        #region Public Properties
        const string TemplatePath = "ModelCompiler.StackGenerator.DataTypes.Templates.BinarySchema.";
        #endregion

        #region Public Methods
        /// <summary>
        /// Generates the datatype files.
        /// </summary>
        public virtual void Generate(string fileName, bool exportAll, string targetNamespace)
        {
            TargetNamespace = targetNamespace;
            m_exportAll = exportAll;

            WriteTemplate_BinarySchema(fileName);
        }
        #endregion

        #region WriteTemplate Methods
        /// <summary>
        /// Writes the address space declaration file.
        /// </summary>
        private void WriteTemplate_BinarySchema(string fileName)
        {
            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}.bsd", OutputDirectory, fileName), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "File.xml", Assembly.GetExecutingAssembly());

                template.Replacements.Add("_BuildDate_", Utils.Format("{0:yyyy-MM-dd}", DateTime.UtcNow));
                template.Replacements.Add("_Version_", Utils.Format("{0}.{1}", Utils.GetAssemblySoftwareVersion(), Utils.GetAssemblyBuildNumber()));
                template.Replacements.Add("_DictionaryUri_", TargetNamespace);

                StringBuilder buffer = new StringBuilder();

                buffer.AppendFormat("xmlns=\"{0}\"", NamespaceUris[0]);

                if (!m_exportAll)
                {
                    for (int ii = 1; ii < NamespaceUris.Count; ii++)
                    {
                        buffer.Append(template.NewLine);
                        buffer.Append("  ");
                        buffer.AppendFormat("xmlns:s{0}=\"{1}\"", ii - 1, NamespaceUris[ii]);
                    }
                }

                template.Replacements.Add("xmlns:s0=\"ListOfNamespaces\"", buffer.ToString());

                List<string> imports = new List<string>();
                imports.Add(Namespaces.OpcUaBuiltInTypes);

                if (!m_exportAll)
                {
                    for (int ii = 1; ii < NamespaceUris.Count; ii++)
                    {
                        imports.Add(NamespaceUris[ii]);
                    }
                }

                AddTemplate(
                    template,
                    "<!-- Imports -->",
                    null,
                    imports,
                    new LoadTemplateEventHandler(LoadTemplate_Imports),
                    null);

                AddTemplate(
                    template,
                    "<!-- ListOfTypes -->",
                    TemplatePath + "OpaqueType.xml",
                    GetListOfTypes(m_exportAll),
                    new LoadTemplateEventHandler(LoadTemplate_DataType),
                    new WriteTemplateEventHandler(WriteTemplate_DataType));

                template.WriteTemplate(null);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Creates a schema import statement.
        /// </summary>
        private string GetImportStatment(string uri)
        {
            string location = null;
            string[] elements = uri.Split(new char[] { '/' });

            for (int ii = elements.Length-1; ii >= 0; ii--)
            {
                if (!String.IsNullOrEmpty(elements[ii]))
                {
                    location = elements[ii];
                    break;
                }
            }

            return String.Format("<opc:Import Namespace=\"{0}\" Location=\"{1}.bsd\" />", uri, location);
        }

        /// <summary>
        /// Writes the import statements.
        /// </summary>
        private string LoadTemplate_Imports(Template template, Context context)
        {
            string namespaceUri = context.Target as string;

            if (namespaceUri == null)
            {
                return null;
            }

            if (!m_exportAll)
            {
                template.WriteLine(String.Empty);
                template.Write(context.Prefix);

                if (namespaceUri == Namespaces.OpcUaBuiltInTypes)
                {
                    template.Write("<opc:Import Namespace=\"{0}\" />", Namespaces.OpcUaBuiltInTypes);
                }
                else
                {
                    template.Write(GetImportStatment(namespaceUri));
                }

                return null;
            }

            return TemplatePath + "BuiltInTypes.bsd";
        }

        /// <summary>
        /// Writes the attributes for a node.
        /// </summary>
        private string LoadTemplate_DataType(Template template, Context context)
        {
            // do not publish type declarations in OPC BinarySchema files.
            if (typeof(TypeDeclaration).IsInstanceOfType(context.Target))
            {
                return null;
            }

            if (typeof(ComplexType).IsInstanceOfType(context.Target))
            {
                ComplexType complexType = context.Target as ComplexType;

                // do not publish types with no fields.
                if (complexType.Field == null || complexType.Field.Length == 0)
                {
                    return null;
                }

                return TemplatePath + "ComplexType.xml";
            }

            if (typeof(EnumeratedType).IsInstanceOfType(context.Target))
            {
                return TemplatePath + "EnumeratedType.xml";
            }

            if (typeof(ServiceType).IsInstanceOfType(context.Target))
            {
                return TemplatePath + "ServiceType.xml";
            }

            // do not publish unrecognized sub-types.
            return null;
        }

        /// <summary>
        /// Writes the
        /// </summary>
        private bool WriteTemplate_DataType(Template template, Context context)
        {
            DataType datatype = context.Target as DataType;

            if (datatype == null)
            {
                return false;
            }

            template.AddReplacement("_TypeName_", datatype.QName.Name);
            CreateDescription(template, "_Description_", datatype.Documentation);

            ComplexType complexType = datatype as ComplexType;

            if (complexType != null)
            {
                List<FieldType> fields = new List<FieldType>();
                GetFields(complexType, fields);

                AddTemplate(
                    template,
                    "<!-- ListOfFields -->",
                    TemplatePath + "Field.xml",
                    fields,
                    new LoadTemplateEventHandler(LoadTemplate_Field),
                    null);
            }

            EnumeratedType enumeratedType = datatype as EnumeratedType;

            if (enumeratedType != null)
            {
                uint lengthInBits = 32;
                bool isOptionSet = false;
                List<EnumeratedValue> values = new List<EnumeratedValue>(enumeratedType.Value);

                if (enumeratedType.IsOptionSet)
                {
                    isOptionSet = true;

                    var baseType = Validator.ResolveType(enumeratedType.BaseType);

                    if (baseType != null)
                    {
                        switch (baseType.Name)
                        {
                            case "SByte": { lengthInBits = 8; break; }
                            case "Byte": { lengthInBits = 8; break; }
                            case "Int16": { lengthInBits = 16; break; }
                            case "UInt16": { lengthInBits = 16; break; }
                            case "Int32": { lengthInBits = 32; break; }
                            case "UInt32": { lengthInBits = 32; break; }
                            case "Int64": { lengthInBits = 64; break; }
                            case "UInt64": { lengthInBits = 64; break; }
                        }
                    }

                    values.Add(new EnumeratedValue()
                    {
                        Name = "None",
                        Value = 0,
                        ValueSpecified = true
                    });
                }

                template.AddReplacement("_LengthInBits_", lengthInBits);
                template.AddReplacement("_IsOptionSet_", (isOptionSet) ? " IsOptionSet=\"true\"" : "");

                AddTemplate(
                    template,
                    "<!-- ListOfValues -->",
                    TemplatePath + "EnumeratedValue.xml",
                    values,
                    new LoadTemplateEventHandler(LoadTemplate_EnumeratedValue),
                    null);
            }

            ServiceType serviceType = datatype as ServiceType;

            if (serviceType != null)
            {
                AddTemplate(
                    template,
                    "<!-- ListOfRequestParameters -->",
                    TemplatePath + "Field.xml",
                    serviceType.Request,
                    new LoadTemplateEventHandler(LoadTemplate_Field),
                    null);

                AddTemplate(
                    template,
                    "<!-- ListOfResponseParameters -->",
                    TemplatePath + "Field.xml",
                    serviceType.Response,
                    new LoadTemplateEventHandler(LoadTemplate_Field),
                    null);
            }

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Writes a field in an OPCBinary schema.
        /// </summary>
        private string LoadTemplate_Field(Template template, Context context)
        {
            FieldType fieldType = context.Target as FieldType;

            if (fieldType == null)
            {
                return null;
            }

            // resolve any type definitions.
            DataType datatype = Validator.ResolveType(fieldType.DataType);

            if (datatype == null)
            {
                throw new ApplicationException(String.Format("Could not find datatype '{0}' for field '{1}'.", fieldType.DataType, fieldType.Name));
            }

            template.WriteLine(String.Empty);
            template.Write(context.Prefix);

            if (fieldType.ValueRank == 0)
            {
                template.WriteLine("<opc:Field Name=\"NoOf{0}\" TypeName=\"opc:Int32\" />", fieldType.Name);
                template.Write(context.Prefix);
            }

            template.Write("<opc:Field Name=\"{0}\"", fieldType.Name);
            template.Write(" TypeName=\"{0}\"", GetBinarySchemaTypeName(datatype.QName));

            if (fieldType.ValueRank == 0)
            {
                template.Write(" LengthField=\"NoOf{0}\"", fieldType.Name);
            }

            template.Write(" />");

            return null;
        }

        /// <summary>
        /// Writes an enumerated value in an OPCBinary schema.
        /// </summary>
        private string LoadTemplate_EnumeratedValue(Template template, Context context)
        {
            EnumeratedValue valueType = context.Target as EnumeratedValue;

            if (valueType == null)
            {
                return null;
            }

            template.WriteLine(String.Empty);
            template.Write(context.Prefix);
            template.Write("<opc:EnumeratedValue Name=\"{0}\" Value=\"{1}\" />", valueType.Name, valueType.Value);

            return null;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Returns a name qualified with a namespace prefix.
        /// </summary>
        private string GetBinarySchemaTypeName(XmlQualifiedName qname)
        {
            if (IsNull(qname))
            {
                return String.Empty;
            }

            if (qname.Namespace == Namespaces.OpcUaBuiltInTypes)
            {
                // translate built-in types to OPC Binary Schema types.
                switch (qname.Name)
                {
                    case "Boolean":
                    case "SByte":
                    case "Byte":
                    case "Int16":
                    case "UInt16":
                    case "Int32":
                    case "UInt32":
                    case "Int64":
                    case "UInt64":
                    case "Float":
                    case "Double":
                    case "Guid":
                    case "DateTime":
                    case "ByteString":
                    {
                        return String.Format("opc:{0}", qname.Name);
                    }

                    case "String":
                    {
                        return "opc:CharArray";
                    }
                }
            }

            if (!m_exportAll)
            {
                return GetPrefixedName(qname);
            }

            return qname.Name;
        }
        #endregion

        #region Private Fields
        private bool m_exportAll;
        #endregion
    }
}
