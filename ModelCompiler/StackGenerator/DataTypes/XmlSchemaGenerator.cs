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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace Opc.Ua.CodeGenerator
{
    /// <summary>
    /// Generates an XML Schema based on a UA Type Dictionary.
    /// </summary>
    public class XmlSchemaGenerator : SchemaGenerator
    {
        #region Constructors
        /// <summary>
        /// Generates the code from the contents of the address space.
        /// </summary>
        public XmlSchemaGenerator(string inputPath, string outputDirectory, Dictionary<string,string> knownFiles) : base (inputPath, outputDirectory, knownFiles)
        {
        }
        #endregion

        #region Public Properties
        const string TemplatePath = "Opc.Ua.ModelCompiler.StackGenerator.DataTypes.Templates.XmlSchema.";
        public string TypesNamespace = "http://opcfoundation.org/UA/2008/02/Types.xsd";
        public string ServicesNamespace = "http://opcfoundation.org/UA/2008/02/Services.xsd";
        public string EndpointsNamespace = "http://opcfoundation.org/UA/2008/02/Endpoints.xsd";
        #endregion

        #region Public Methods
        /// <summary>
        /// Generates the datatype files.
        /// </summary>
        public virtual void Generate(string fileName, string namespacePrefix, string dictionaryName, bool exportAll)
        {
            TargetNamespace = TypesNamespace;
            m_exportAll = exportAll;

            WriteTemplate_XmlSchema(fileName, dictionaryName);

            // only write WSDL is services exist.
            foreach (DataType datatype in Dictionary.Items)
            {
                if (datatype is ServiceType)
                {
                    WriteTemplate_ServicesWsdl(fileName, namespacePrefix, dictionaryName);
                    WriteTemplate_EndpointWsdl(fileName, namespacePrefix, dictionaryName);
                    break;
                }
            }
        }
        #endregion

        #region WriteTemplate Methods
        /// <summary>
        /// Writes the address space declaration file.
        /// </summary>
        private void WriteTemplate_EndpointWsdl(string fileName, string namespacePrefix, string dictionaryName)
        {
            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}.Endpoints.wsdl", OutputDirectory, namespacePrefix, fileName), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "Endpoint.wsdl", Assembly.GetExecutingAssembly());

                template.Replacements.Add("_BuildDate_", Utils.Format("{0:yyyy-MM-dd}", DateTime.UtcNow));
                template.Replacements.Add("_Version_", Utils.Format("{0}.{1}", Utils.GetAssemblySoftwareVersion(), Utils.GetAssemblyBuildNumber()));
                template.Replacements.Add("_Namespace_", TargetNamespace);
                template.Replacements.Add("_NamespacePrefix_", fileName);
                template.Replacements.Add("_EndpointsNamespace_", EndpointsNamespace);
                template.Replacements.Add("_ServicesNamespace_", ServicesNamespace);
                template.Replacements.Add("_TypesNamespace_", TypesNamespace);

               AddTemplate(
                    template,
                    "<!-- Session Binding List -->",
                    TemplatePath + "Binding.wsdl",
                    GetListOfServices(InterfaceType.Session),
                    null,
                    new WriteTemplateEventHandler(WriteTemplate_Message));

               AddTemplate(
                    template,
                    "<!-- Discovery Binding List -->",
                    TemplatePath + "Binding.wsdl",
                    GetListOfServices(InterfaceType.Discovery),
                    null,
                    new WriteTemplateEventHandler(WriteTemplate_Message));


               AddTemplate(
                    template,
                    "<!-- Registration Binding List -->",
                    TemplatePath + "Binding.wsdl",
                    GetListOfServices(InterfaceType.Registration),
                    null,
                    new WriteTemplateEventHandler(WriteTemplate_Message));


                template.WriteTemplate(null);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Writes the address space declaration file.
        /// </summary>
        private void WriteTemplate_ServicesWsdl(string fileName, string namespacePrefix, string dictionaryName)
        {
            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}.Services.wsdl", OutputDirectory, namespacePrefix, fileName), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "Services.wsdl", Assembly.GetExecutingAssembly());

                template.Replacements.Add("_BuildDate_", Utils.Format("{0:yyyy-MM-dd}", DateTime.UtcNow));
                template.Replacements.Add("_Version_", Utils.Format("{0}.{1}", Utils.GetAssemblySoftwareVersion(), Utils.GetAssemblyBuildNumber()));
                template.Replacements.Add("_Namespace_", TargetNamespace);
                template.Replacements.Add("_NamespacePrefix_", fileName);
                template.Replacements.Add("_ServicesNamespace_", ServicesNamespace);
                template.Replacements.Add("_TypesNamespace_", TypesNamespace);

               AddTemplate(
                    template,
                    "<!-- Message List -->",
                    TemplatePath + "Message.wsdl",
                    GetListOfTypes(typeof(ServiceType), m_exportAll, true),
                    null,
                    new WriteTemplateEventHandler(WriteTemplate_Message));

               AddTemplate(
                    template,
                    "<!-- Session Operation List -->",
                    TemplatePath + "PortType.wsdl",
                    GetListOfServices(InterfaceType.Session),
                    null,
                    new WriteTemplateEventHandler(WriteTemplate_Message));

               AddTemplate(
                    template,
                    "<!-- Discovery Operation List -->",
                    TemplatePath + "PortType.wsdl",
                    GetListOfServices(InterfaceType.Discovery),
                    null,
                    new WriteTemplateEventHandler(WriteTemplate_Message));

               AddTemplate(
                    template,
                    "<!-- Registration Operation List -->",
                    TemplatePath + "PortType.wsdl",
                    GetListOfServices(InterfaceType.Registration),
                    null,
                    new WriteTemplateEventHandler(WriteTemplate_Message));

                template.WriteTemplate(null);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Returns a list of services filter by their interface type.
        /// </summary>
        private IList<ServiceType> GetListOfServices(InterfaceType interfaceType)
        {
            List<DataType> datatypes = GetListOfTypes(typeof(ServiceType), m_exportAll, true);

            List<ServiceType> services = new List<ServiceType>();

            for (int ii = 0; ii < datatypes.Count; ii++)
            {
                ServiceType serviceType = datatypes[ii] as ServiceType;

                if (serviceType != null && serviceType.InterfaceType == interfaceType)
                {
                    services.Add(serviceType);
                }
            }

            return services;
        }

        /// <summary>
        /// Writes an array declaration to the stream.
        /// </summary>
        private bool WriteTemplate_Message(Template template, Context context)
        {
            ServiceType datatype = context.Target as ServiceType;

            if (datatype == null)
            {
                return false;
            }

            template.AddReplacement("_Namespace_", TargetNamespace);
            template.AddReplacement("_ServicesNamespace_", ServicesNamespace);
            template.AddReplacement("_TypesNamespace_", TypesNamespace);
            template.AddReplacement("_NAME_", datatype.QName.Name);

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Writes the address space declaration file.
        /// </summary>
        private void WriteTemplate_XmlSchema(string fileName, string dictionaryName)
        {
            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}.Types.xsd", OutputDirectory, fileName, dictionaryName), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "File.xml", Assembly.GetExecutingAssembly());

                template.Replacements.Add("_BuildDate_", Utils.Format("{0:yyyy-MM-dd}", DateTime.UtcNow));
                template.Replacements.Add("_Version_", Utils.Format("{0}.{1}", Utils.GetAssemblySoftwareVersion(), Utils.GetAssemblyBuildNumber()));
                template.Replacements.Add("_Namespace_", TargetNamespace);

                StringBuilder buffer = new StringBuilder();
                buffer.AppendFormat("xmlns:tns=\"{0}\"", TargetNamespace);

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

            return String.Format("<xs:import namespace=\"{0}\" schemaLocation=\"{1}.xsd\" />", uri, location);
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
                    template.Write("<xs:import namespace=\"{0}\" schemaLocation=\"BuiltInTypes.xsd\" />", Namespaces.OpcUaBuiltInTypes);
                }
                else
                {
                    template.Write(GetImportStatment(namespaceUri));
                }

                return null;
            }

            return TemplatePath + "BuiltInTypes.xsd";
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
                if (!IsNull(((ComplexType)context.Target).BaseType))
                {
                    return TemplatePath + "DerivedType.xml";
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
        /// Writes a datatype to the stream.
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

            AddTemplate(
                template,
                "<!-- ArrayDeclaration -->",
                TemplatePath + "Array.xml",
                new DataType[] { datatype },
                null,
                new WriteTemplateEventHandler(WriteTemplate_Array));

            ComplexType complexType = datatype as ComplexType;

            if (complexType != null)
            {
                if (!IsNull(complexType.BaseType))
                {
                    DataType basetype = Validator.ResolveType(complexType.BaseType);

                    if (basetype == null)
                    {
                        throw new ApplicationException(String.Format("Could not find base type '{0}' for complex type '{1}'.", complexType.BaseType, complexType.QName));
                    }

                    template.AddReplacement("_BaseType_", GetXmlSchemaTypeName(basetype.QName, -1));
                }

                AddTemplate(
                    template,
                    "<!-- ListOfFields -->",
                    TemplatePath + "Field.xml",
                    complexType.Field,
                    new LoadTemplateEventHandler(LoadTemplate_Field),
                    null);
            }

            EnumeratedType enumeratedType = datatype as EnumeratedType;

            if (enumeratedType != null)
            {

                AddTemplate(
                    template,
                    "<!-- ListOfValues -->",
                    TemplatePath + "EnumeratedValue.xml",
                    enumeratedType.Value,
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
        /// Writes an array declaration to the stream.
        /// </summary>
        private bool WriteTemplate_Array(Template template, Context context)
        {
            DataType datatype = context.Target as DataType;

            if (datatype == null)
            {
                return false;
            }

            if (!datatype.AllowArrays)
            {
                return false;
            }

            template.WriteLine(String.Empty);
            template.AddReplacement("_TypeName_", datatype.QName.Name);

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
            template.Write("<xs:element name=\"{0}\"", fieldType.Name);

            if (datatype.Name == "XmlElement" && fieldType.ValueRank < 0)
            {
                template.WriteLine(">");
                template.WriteLine("{0}  <xs:complexType>", context.Prefix);
                template.WriteLine("{0}    <xs:sequence>", context.Prefix);
                template.WriteLine("{0}      <xs:any minOccurs=\"0\" processContents=\"lax\" />", context.Prefix);
                template.WriteLine("{0}    </xs:sequence>", context.Prefix);
                template.WriteLine("{0}  </xs:complexType>", context.Prefix);

                template.Write("{0}</xs:element>", context.Prefix);
            }
            else
            {
                template.Write(" type=\"{0}\" minOccurs=\"0\"", GetXmlSchemaTypeName(datatype.QName, fieldType.ValueRank));

                if (datatype.Name == "String" || datatype.Name == "ByteString")
                {
                    template.Write(" nillable=\"true\"");
                }

                template.Write(" />");
            }

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
            template.Write("<xs:enumeration value=\"{0}_{1}\" />", valueType.Name, valueType.Value);

            /*
            if (valueType.Value != 1)
            {
                template.WriteLine(">");
                template.WriteLine("{0}  <xs:annotation>", context.Prefix);
                template.WriteLine("{0}    <xs:appinfo>", context.Prefix);
                template.WriteLine("{0}      <EnumerationValue xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">{1}</EnumerationValue>", context.Prefix, valueType.Value);
                template.WriteLine("{0}    </xs:appinfo>", context.Prefix);
                template.WriteLine("{0}  </xs:annotation>", context.Prefix);
                template.WriteLine("{0}</xs:enumeration>", context.Prefix);
            }
            else
            {
                template.Write(" />");
            }
            */

            return null;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Returns a name qualified with a namespace prefix.
        /// </summary>
        private string GetXmlSchemaTypeName(XmlQualifiedName qname, int valueRank)
        {
            if (IsNull(qname))
            {
                return String.Empty;
            }

            if (qname.Namespace == Namespaces.OpcUaBuiltInTypes)
            {
                // translate built-in types to XML Schema types.
                if (valueRank < 0)
                {
                    switch (qname.Name)
                    {
                        case "Boolean":    { return "xs:boolean";       }
                        case "SByte":      { return "xs:byte";          }
                        case "Byte":       { return "xs:unsignedByte";  }
                        case "Int16":      { return "xs:short";         }
                        case "UInt16":     { return "xs:unsignedShort"; }
                        case "Int32":      { return "xs:int";           }
                        case "UInt32":     { return "xs:unsignedInt";   }
                        case "Int64":      { return "xs:long";          }
                        case "UInt64":     { return "xs:unsignedLong";  }
                        case "Float":      { return "xs:float";         }
                        case "Double":     { return "xs:double";        }
                        case "String":     { return "xs:string";        }
                        case "DateTime":   { return "xs:dateTime";      }
                        case "ByteString": { return "xs:base64Binary";  }
                    }
                }
            }

            string typeName = qname.Name;

            if (!m_exportAll)
            {
                typeName = GetPrefixedName(qname);
            }

            int index = typeName.IndexOf(':');

            // convert to an array element.
            if (valueRank >= 0)
            {
                string prefix = String.Empty;

                if (index != -1)
                {
                    prefix = typeName.Substring(0, index + 1);
                    typeName = typeName.Substring(index + 1);
                }
                else
                {
                    prefix = "tns:";
                }

                typeName = String.Format("{0}ListOf{1}", prefix, typeName);
            }
            else
            {
                if (index == -1)
                {
                    typeName = "tns:" + typeName;
                }
            }

            return typeName;
        }
        #endregion

        #region Private Fields
        private bool m_exportAll;
        #endregion
    }
}
