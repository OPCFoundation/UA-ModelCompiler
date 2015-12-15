/* ========================================================================
 * Copyright (c) 2005-2009 The OPC Foundation, Inc. All rights reserved.
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
    /// Generates files used to describe data types.
    /// </summary>
    public class NodeDictionaryGenerator : SchemaGenerator
    {       
        #region Constructors
		/// <summary>
		/// Generates the code from the contents of the address space.
		/// </summary>
		public NodeDictionaryGenerator(string inputPath, string outputDirectory, Dictionary<string,string> knownFiles) : base (inputPath, outputDirectory, knownFiles)
		{
		}
        #endregion      
        
        #region Public Properties
        const string TemplatePath = "Opc.Ua.CodeGenerator.DataTypes.Templates.Nodes.";
        #endregion
 
        #region Public Methods
        /// <summary>
        /// Generates the datatype files.
        /// </summary>        
        public virtual void Generate(
            string fileName,
            string dictionaryName,
            string targetNamespace)
        {
            m_dictionaryName = dictionaryName;
            m_exportAll = true;

            WriteTemplate_DataTypeDesign(fileName, targetNamespace);
        }
        #endregion
        
        #region WriteTemplate Methods
        /// <summary>
        /// Writes the address space declaration file.
        /// </summary>
        private void WriteTemplate_DataTypeDesign(string fileName, string targetNamespace)
        {
			StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}.xml", OutputDirectory, fileName), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "File.xml", Assembly.GetExecutingAssembly());
                
                template.AddReplacement("_Date_", DateTime.Now.ToString());
                template.AddReplacement("_TargetNamespace_", targetNamespace);
                
                AddTemplate(
                    template,
                    "<!-- ListOfDataTypes -->",
                    TemplatePath + "DataType.xml",
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
        /// Chooses the template for the data type.
        /// </summary>
        private string LoadTemplate_DataType(Template template, Context context)
        {
            DataType datatype = context.Target as DataType;

            if (datatype == null)
            {
                return null;
            }
            
            if (datatype is ServiceType)
            {
                return TemplatePath + "ServiceType.xml";
            }
            
            if (datatype is TypeDeclaration)
            {
                return TemplatePath + "TypeDeclaration.xml";
            }
            
            ComplexType complexType = context.Target as ComplexType;

            if (complexType != null && (complexType.Field == null || complexType.Field.Length == 0))
            {
                return TemplatePath + "TypeDeclaration.xml";
            }
         
            return TemplatePath + "DataType.xml";
        }
        
        /// <summary>
        /// Writes the nodes that describe a data type or method.
        /// </summary>
        private bool WriteTemplate_DataType(Template template, Context context)
        {
            DataType datatype = context.Target as DataType;

            if (datatype == null)
            {
                return false;
            }

            template.AddReplacement("_TypeName_", datatype.QName.Name);       
            template.AddReplacement("_DictionaryName_", m_dictionaryName);  
                          
            if (datatype.NotInAddressSpace)
            {
                template.AddReplacement(" NotInAddressSpace=\"false\"", " NotInAddressSpace=\"true\"");  
            }
            else
            {
                template.AddReplacement(" NotInAddressSpace=\"false\"", "");  
            }    
            
            if (!datatype.AllowArrays)
            {
                template.AddReplacement(" NoArraysAllowed=\"false\"", " NoArraysAllowed=\"true\"");  
            }
            else
            {
                template.AddReplacement(" NoArraysAllowed=\"false\"", "");  
            }    

            TypeDeclaration declaration = datatype as TypeDeclaration;

            if (declaration != null)
            {
                DataType sourceType = Validator.ResolveType(declaration.SourceType);

                if (sourceType != null)
                {
                    template.AddReplacement("_BaseType_", GetPrefixedName(sourceType.QName));
                }
            }
            
            ComplexType complexType = datatype as ComplexType;

            if (complexType != null)
            {
                if (!IsNull(complexType.BaseType))
                {
                    template.AddReplacement("_BaseType_", GetPrefixedName(complexType.BaseType));
                }
                else
                {
                    template.AddReplacement("_BaseType_", "ua:Structure");
                }            

                AddTemplate(
                    template,
                    "<!-- ListOfFields -->",
                    TemplatePath + "DataType.xml",
                    new ComplexType[] { complexType },
                    new LoadTemplateEventHandler(LoadTemplate_ComplexTypeFields),
                    null);
            }
            
            EnumeratedType enumeratedType = datatype as EnumeratedType;

            if (enumeratedType != null)
            {
                if (enumeratedType != null)
                {
                    template.AddReplacement("_BaseType_", "ua:Enumeration");
                }
                else
                {
                    template.AddReplacement("_BaseType_", "ua:BaseDataType");
                }       
                
                AddTemplate(
                    template,
                    "<!-- ListOfFields -->",
                    TemplatePath + "DataType.xml",
                    new EnumeratedType[] { enumeratedType },
                    new LoadTemplateEventHandler(LoadTemplate_EnumeratedTypeValues),
                    null);       
            }
            
            ServiceType serviceType = datatype as ServiceType;

            if (serviceType != null)
            {                
                ComplexType requestType = new ComplexType();

                requestType.Name = String.Format("{0}Request", serviceType.Name);
                requestType.QName = new XmlQualifiedName(requestType.Name, serviceType.QName.Namespace);
                requestType.Field = serviceType.Request;
                requestType.NotInAddressSpace = true;

                AddTemplate(
                    template,
                    "<!-- Request -->",
                    TemplatePath + "DataType.xml",
                    new ComplexType[] { requestType },
                    new LoadTemplateEventHandler(LoadTemplate_DataType),
                    new WriteTemplateEventHandler(WriteTemplate_DataType));

                ComplexType responseType = new ComplexType();

                responseType.Name = String.Format("{0}Response", serviceType.Name);
                responseType.QName = new XmlQualifiedName(responseType.Name, serviceType.QName.Namespace);
                responseType.Field = serviceType.Response;
                responseType.NotInAddressSpace = true;

                AddTemplate(
                    template,
                    "<!-- Response -->",
                    TemplatePath + "DataType.xml",
                    new ComplexType[] { responseType },
                    new LoadTemplateEventHandler(LoadTemplate_DataType),
                    new WriteTemplateEventHandler(WriteTemplate_DataType));
            }

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Chooses the template for the data type.
        /// </summary>
        private string LoadTemplate_ComplexTypeFields(Template template, Context context)
        {
            ComplexType complexType = context.Target as ComplexType;

            if (complexType == null)
            {
                return null;
            }
                  
            foreach (FieldType field in complexType.Field)
            {
                template.WriteLine(String.Empty);
                template.Write(context.Prefix);        
                template.Write("<opc:Field Name=\"{0}\" DataType=\"{1}\"", field.Name, GetPrefixedName(field.DataType));
        
                if (field.ValueRank >= 0)
                {
                    template.Write(" ValueRank=\"Array\"");
                }
                
                template.Write(" />");
            }
                                        
            return null;
        }

        /// <summary>
        /// Chooses the template for the data type.
        /// </summary>
        private string LoadTemplate_EnumeratedTypeValues(Template template, Context context)
        {
            EnumeratedType enumeratedType = context.Target as EnumeratedType;

            if (enumeratedType == null)
            {
                return null;
            }
                  
            foreach (EnumeratedValue value in enumeratedType.Value)
            {
                template.WriteLine(String.Empty);
                template.Write(context.Prefix);        
                template.Write("<opc:Field Name=\"{0}\" Identifier=\"{1}\" />", value.Name, value.Value);
            }
                                        
            return null;
        }

        /// <summary>
        /// Substitutes input namespaces for output namespaces.
        /// </summary>
        private new string GetPrefixedName(XmlQualifiedName qname)
        {
            string name = base.GetPrefixedName(qname);

            if (m_exportAll)
            {
                name = qname.Name;
            }
            
            if (name == "Variant")
            {
                return "BaseDataType";
            }
            
            if (name == "ExtensionObject")
            {
                return "Structure";
            }

            return name;
        }
        #endregion

        #region Private Fields
        private string m_dictionaryName;
        private bool m_exportAll;
        #endregion
    }
}
