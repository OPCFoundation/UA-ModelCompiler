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
    public class WiresharkGenerator : CodeGenerator
    {
        #region Constructors
        /// <summary>
        /// Generates the code from the contents of the address space.
        /// </summary>
        public WiresharkGenerator(
            string inputPath,
            string outputDirectory,
            Dictionary<string,string> knownFiles,
            string resourcePath,
            IList<string> exclusions)
        :
            base(inputPath, outputDirectory, knownFiles, resourcePath, exclusions)
        {
            // load and validate type dictionary.
            m_validator = new TypeDictionaryValidator(knownFiles, resourcePath);
            m_validator.Validate(inputPath, exclusions);

            TargetLanguage = Language.Wireshark;
            m_lstFields = new List<HFEntry>();
            m_hashSimpleTypes = new Hashtable();

            m_hashSimpleTypes.Add("Boolean", null);
            m_hashSimpleTypes.Add("Byte", null);
            m_hashSimpleTypes.Add("SByte", null);
            m_hashSimpleTypes.Add("UInt16", null);
            m_hashSimpleTypes.Add("Int16", null);
            m_hashSimpleTypes.Add("UInt32", null);
            m_hashSimpleTypes.Add("Int32", null);
            m_hashSimpleTypes.Add("UInt64", null);
            m_hashSimpleTypes.Add("Int64", null);
            m_hashSimpleTypes.Add("Float", null);
            m_hashSimpleTypes.Add("Double", null);
            m_hashSimpleTypes.Add("Counter", null);
            m_hashSimpleTypes.Add("IntegerId", null);
            m_hashSimpleTypes.Add("String", null);
            m_hashSimpleTypes.Add("Duration", null);
            m_hashSimpleTypes.Add("DateTime", null);
            m_hashSimpleTypes.Add("UtcTime", null);
            m_hashSimpleTypes.Add("Guid", null);
            m_hashSimpleTypes.Add("StatusCode", null);
            m_hashSimpleTypes.Add("ByteString", null);
            m_hashSimpleTypes.Add("XmlElement", null);

            m_sHeader = "/******************************************************************************\n" +
                        "** $Id$\n" +
                        "**\n" +
                        "** Copyright (C) 2006-2008 ascolab GmbH. All Rights Reserved.\n" +
                        "** Web: http://www.ascolab.com\n" +
                        "** \n" +
                        "** This program is free software; you can redistribute it and/or\n" +
                        "** modify it under the terms of the GNU General Public License\n" +
                        "** as published by the Free Software Foundation; either version 2\n" +
                        "** of the License, or (at your option) any later version.\n" +
                        "** \n" +
                        "** This file is provided AS IS with NO WARRANTY OF ANY KIND, INCLUDING THE\n" +
                        "** WARRANTY OF DESIGN, MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.\n" +
                        "** \n" +
                        "** Project: OpcUa Wireshark Plugin\n" +
                        "**\n" +
                        "** Description: {0}\n" +
                        "**\n" +
                        "** DON'T MODIFY THIS FILE!\n" +
                        "**\n" +
                        "******************************************************************************/\n" +
                        "\n";
        }

        class HFEntry
        {
            public HFEntry(string sFieldName, string sDataTypeName)
            {
                m_sFieldName = sFieldName;
                m_sDataTypeName = sDataTypeName;
            }

            public string FieldName() { return m_sFieldName; }
            public string DataTypeName() { return m_sDataTypeName; }

            private string m_sFieldName;
            private string m_sDataTypeName;
        }

        private List<HFEntry> m_lstFields;
        private Hashtable m_hashSimpleTypes;
        private TypeDictionaryValidator m_validator;
        private string m_sHeader;
        const string WiresharkTemplatePath = "ModelCompiler.StackGenerator.Wireshark.Template.";
        #endregion

        #region Public Methods
        /// <summary>
        /// Generates the datatype files.
        /// </summary>
        public virtual void Generate(string namespacePrefix, string dictionaryName, bool exportAll)
        {
            DictionaryName = dictionaryName;
            m_exportAll = exportAll;

            WriteTemplate_ServicesHeader(namespacePrefix, dictionaryName);
            WriteTemplate_ServicesImplementation(namespacePrefix, dictionaryName);
            WriteTemplate_ComplexTypesHeader(namespacePrefix, dictionaryName);
            WriteTemplate_ComplexTypesImplementation(namespacePrefix, dictionaryName);
            WriteTemplate_EnumsHeader(namespacePrefix, dictionaryName);
            WriteTemplate_EnumsImplementation(namespacePrefix, dictionaryName);
            WriteTemplate_HFIndecesImplementation(namespacePrefix, dictionaryName);
            WriteTemplate_HFIndecesHeader(namespacePrefix, dictionaryName);
        }
        #endregion

        private void WriteTemplate_HFIndecesImplementation(string namespacePrefix, string dictionaryName)
        {
            List<HFEntry> tmp = new List<HFEntry>();

            foreach (HFEntry entry in m_lstFields)
            {
                bool bAdd = true;
                foreach (HFEntry entry2 in tmp)
                {
                    if (entry.FieldName() == entry2.FieldName())
                    {
                        bAdd = false;
                        break;
                    }
                }
                if (bAdd)
                {
                    tmp.Add(entry);
                }
            }
            m_lstFields = tmp;

            string fileName = String.Format(@"{0}\{1}_hfindeces.c", OutputDirectory, namespacePrefix);
            fileName = fileName.ToLower();

            StreamWriter writer = new StreamWriter(fileName, false);
            Template template = new Template(writer, WiresharkTemplatePath + "hfentries.c", Assembly.GetExecutingAssembly());

            template.AddReplacement("_Date_", DateTime.Now.ToString());

            AddTemplate(
                template,
                "// _INDECES_",
                WiresharkTemplatePath + "hfentries.c",
                m_lstFields,
                null,
                new WriteTemplateEventHandler(WriteTemplate_Field));

            AddTemplate(
                template,
                "// _FIELDS_",
                WiresharkTemplatePath + "hfentries.c",
                m_lstFields,
                null,
                new WriteTemplateEventHandler(WriteTemplate_Field));

            template.WriteTemplate(null);

            writer.Close();

        }

        private void WriteTemplate_HFIndecesHeader(string namespacePrefix, string dictionaryName)
        {
            string fileName = String.Format(@"{0}\{1}_hfindeces.h", OutputDirectory, namespacePrefix);
            fileName = fileName.ToLower();

            StreamWriter writer = new StreamWriter(fileName, false);
            Template template = new Template(writer, WiresharkTemplatePath + "hfentries.h", Assembly.GetExecutingAssembly());

            template.AddReplacement("_Date_", DateTime.Now.ToString());

            AddTemplate(
                template,
                "// _EXTERNINDECES_",
                WiresharkTemplatePath + "hfentries.h",
                m_lstFields,
                null,
                new WriteTemplateEventHandler(WriteTemplate_Field));

            template.WriteTemplate(null);

            writer.Close();

        }

        private void WriteTemplate_ServicesHeader(string namespacePrefix, string dictionaryName)
        {
            // get datatypes.
            List<DataType> datatypes = GetDataTypeList(null, m_exportAll, false);

            if (datatypes.Count == 0)
            {
                return;
            }

            // sort types to ensure types are declared in the correct order.
            List<DataType> sortedTypes = new List<DataType>();

            foreach (DataType datatype in datatypes)
            {
                AddDataType(datatype, sortedTypes);
            }

            datatypes = sortedTypes;

            string fileName = String.Format(@"{0}\{1}_serviceparser.h", OutputDirectory, namespacePrefix);
            fileName = fileName.ToLower();

            List<string> list = new List<string>();
            StreamWriter writer = new StreamWriter(fileName, false);
            writer.Write(string.Format(m_sHeader, "OpcUa Service Type Parser", DateTime.Now));
            writer.Write("#ifdef HAVE_CONFIG_H\n" +
                        "# include \"config.h\"\n" +
                        "#endif\n" +
                        "\n" +
                        "#include <gmodule.h>\n" +
                        "#include <epan/packet.h>\n\n");

            try
            {
                foreach (DataType datatype in sortedTypes)
                {
                    ServiceType Service = datatype as ServiceType;

                    if (Service != null)
                    {
                        writer.Write(string.Format("void parse{0}Request(proto_tree *tree, tvbuff_t *tvb, gint *pOffset);\n", Service.Name));
                        writer.Write(string.Format("void parse{0}Response(proto_tree *tree, tvbuff_t *tvb, gint *pOffset);\n", Service.Name));
                    }
                }
            }
            finally
            {
                writer.Write("void registerServiceTypes();\n");
                writer.Close();
            }
        }

        private void WriteTemplate_ServicesImplementation(string namespacePrefix, string dictionaryName)
        {
            // get datatypes.
            List<DataType> datatypes = GetDataTypeList(null, m_exportAll, false);

            if (datatypes.Count == 0)
            {
                return;
            }

            // sort types to ensure types are declared in the correct order.
            List<DataType> sortedTypes = new List<DataType>();

            foreach (DataType datatype in datatypes)
            {
                AddDataType(datatype, sortedTypes);
            }

            datatypes = sortedTypes;

            string fileName = String.Format(@"{0}\{1}_serviceparser.c", OutputDirectory, namespacePrefix);
            fileName = fileName.ToLower();

            List<string> list = new List<string>();
            StreamWriter writer = new StreamWriter(fileName, false);
            writer.Write(string.Format(m_sHeader, "OpcUa Service Type Parser", DateTime.Now));
            writer.Write("#ifdef HAVE_CONFIG_H\n" +
                        "# include \"config.h\"\n" +
                        "#endif\n" +
                        "\n" +
                        "#include <gmodule.h>\n" +
                        "#include <epan/packet.h>\n"+
                        "#include \"opcua_serviceparser.h\"\n"+
                        "#include \"opcua_complextypeparser.h\"\n"+
                        "#include \"opcua_enumparser.h\"\n" +
                        "#include \"opcua_simpletypes.h\"\n" +
                        "#include \"opcua_hfindeces.h\"\n\n");

            try
            {
                foreach (DataType datatype in sortedTypes)
                {
                    ServiceType Service = datatype as ServiceType;

                    if (Service != null)
                    {
                        Template template = new Template(writer, WiresharkTemplatePath + "serviceparserfunction.c", Assembly.GetExecutingAssembly());

                        template.AddReplacement("_NAME_", Service.Name + "Request");
                        list.Add(Service.Name + "Request");

                        AddTemplate(
                            template,
                            "// _FIELDS_",
                            WiresharkTemplatePath + "serviceparserfunction.c",
                            Service.Request,
                            null,
                            new WriteTemplateEventHandler(WriteTemplate_Parser));

                        template.WriteTemplate(null);

                        template = new Template(writer, WiresharkTemplatePath + "serviceparserfunction.c", Assembly.GetExecutingAssembly());

                        template.AddReplacement("_NAME_", Service.Name + "Response");
                        list.Add(Service.Name + "Response");

                        AddTemplate(
                            template,
                            "// _FIELDS_",
                            WiresharkTemplatePath + "serviceparserfunction.c",
                            Service.Response,
                            null,
                            new WriteTemplateEventHandler(WriteTemplate_Parser));

                        template.WriteTemplate(null);
                    }
                }
            }
            finally
            {
                writer.Write("\n/** Setup protocol subtree array */\n" +
                             "static gint *ett[] =\n{\n");

                foreach (string sName in list)
                {
                    writer.Write("  &ett_opcua_" + sName + ",\n");
                }

                writer.Write("};\n\n");
                writer.Write("void registerServiceTypes()\n" +
                             "{\n" +
                             "  proto_register_subtree_array(ett, array_length(ett));\n" +
                             "}\n\n");
                writer.Close();
            }

        }

        private void WriteTemplate_ComplexTypesImplementation(string namespacePrefix, string dictionaryNam)
        {
            // get datatypes.
            List<DataType> datatypes = GetDataTypeList(null, m_exportAll, false);

            if (datatypes.Count == 0)
            {
                return;
            }

            // sort types to ensure types are declared in the correct order.
            List<DataType> sortedTypes = new List<DataType>();

            foreach (DataType datatype in datatypes)
            {
                AddDataType(datatype, sortedTypes);
            }

            datatypes = sortedTypes;

            string fileName = String.Format(@"{0}\{1}_complextypeparser.c", OutputDirectory, namespacePrefix);
            fileName = fileName.ToLower();

            List<string> list = new List<string>();

            StreamWriter writer = new StreamWriter(fileName, false);
            writer.Write(string.Format(m_sHeader, "OpcUa Complex Type Parser", DateTime.Now));
            writer.Write("#ifdef HAVE_CONFIG_H\n" +
                        "# include \"config.h\"\n" +
                        "#endif\n" +
                        "\n" +
                        "#include <gmodule.h>\n" +
                        "#include <epan/packet.h>\n"+
                        "#include \"opcua_complextypeparser.h\"\n" +
                        "#include \"opcua_enumparser.h\"\n" +
                        "#include \"opcua_simpletypes.h\"\n" +
                        "#include \"opcua_hfindeces.h\"\n\n");
            try
            {
                foreach (DataType datatype in sortedTypes)
                {
                    ComplexType complextype = datatype as ComplexType;

                    if (complextype != null)
                    {
                        Template template = new Template(writer, WiresharkTemplatePath + "complexparserfunction.c", Assembly.GetExecutingAssembly());
                        list.Add(complextype.Name);

                        template.AddReplacement("_NAME_", complextype.Name);
                        if (complextype.BaseType == null)
                        {
                            template.AddReplacement("// _BASE_", "");
                        }
                        else
                        {
                            template.AddReplacement("// _BASE_", string.Format("  /* parse base class members */ \n  parse{0}(subtree, tvb, pOffset, \"[{0}]\");\n  /* parse additional members */", complextype.BaseType.Name));
                        }
                        
                        List<FieldType> fields = new List<FieldType>();

                        foreach (var field in complextype.Field)
                        {
                            if (!TypeDictionaryValidator.IsExcluded(Exclusions, field))
                            {
                                fields.Add(field);
                            }
                        }

                        AddTemplate(
                            template,
                            "// _FIELDS_",
                            WiresharkTemplatePath + "complexparserfunction.c",
                            fields,
                            null,
                            new WriteTemplateEventHandler(WriteTemplate_Parser));

                        template.WriteTemplate(null);
                    }
                }
            }
            finally
            {
                writer.Write("\n/** Setup protocol subtree array */\n"+
                             "static gint *ett[] =\n{\n");

                foreach(string sName in list)
                {
                    writer.Write("  &ett_opcua_"+sName+",\n");
                }

                writer.Write("};\n\n");
                writer.Write("void registerComplexTypes()\n" +
                             "{\n" +
                             "  proto_register_subtree_array(ett, array_length(ett));\n" +
                             "}\n\n");

                writer.Close();
            }
        }

        private void WriteTemplate_ComplexTypesHeader(string namespacePrefix, string dictionaryName)
        {
            // get datatypes.
            List<DataType> datatypes = GetDataTypeList(null, m_exportAll, false);

            if (datatypes.Count == 0)
            {
                return;
            }

            // sort types to ensure types are declared in the correct order.
            List<DataType> sortedTypes = new List<DataType>();

            foreach (DataType datatype in datatypes)
            {
                AddDataType(datatype, sortedTypes);
            }

            datatypes = sortedTypes;

            string fileName = String.Format(@"{0}\{1}_complextypeparser.h", OutputDirectory, namespacePrefix);
            fileName = fileName.ToLower();

            List<string> list = new List<string>();
            StreamWriter writer = new StreamWriter(fileName, false);
            writer.Write(string.Format(m_sHeader, "OpcUa Complex Type Parser", DateTime.Now));
            writer.Write("#ifdef HAVE_CONFIG_H\n" +
                        "# include \"config.h\"\n" +
                        "#endif\n" +
                        "\n" +
                        "#include <gmodule.h>\n" +
                        "#include <epan/packet.h>\n\n");

            try
            {
                foreach (DataType datatype in sortedTypes)
                {
                    ComplexType complextype = datatype as ComplexType;

                    if (complextype != null)
                    {
                        writer.Write(string.Format("void parse{0}(proto_tree *tree, tvbuff_t *tvb, gint *pOffset, char *szFieldName);\n", complextype.Name));
                    }
                }
            }
            finally
            {
                writer.Write("void registerComplexTypes();\n");
                writer.Close();
            }

        }

        private void WriteTemplate_EnumsImplementation(string namespacePrefix, string dictionaryNam)
        {
            // get datatypes.
            List<DataType> datatypes = GetDataTypeList(null, m_exportAll, false);

            if (datatypes.Count == 0)
            {
                return;
            }

            // sort types to ensure types are declared in the correct order.
            List<DataType> sortedTypes = new List<DataType>();

            foreach (DataType datatype in datatypes)
            {
                AddDataType(datatype, sortedTypes);
            }

            datatypes = sortedTypes;

            string fileName = String.Format(@"{0}\{1}_enumparser.c", OutputDirectory, namespacePrefix);
            fileName = fileName.ToLower();

            StreamWriter writer = new StreamWriter(fileName, false);
            writer.Write(string.Format(m_sHeader, "OpcUa Enum Type Parser", DateTime.Now));
            writer.Write("#ifdef HAVE_CONFIG_H\n" +
                      "# include \"config.h\"\n" +
                      "#endif\n" +
                      "\n" +
                      "#include <gmodule.h>\n" +
                      "#include <epan/packet.h>\n\n" +
                      "#include \"opcua_enumparser.h\"\n\n");
            try
            {
                foreach (DataType datatype in sortedTypes)
                {
                    EnumeratedType enumtype = datatype as EnumeratedType;

                    if (enumtype != null)
                    {
                        Template template = new Template(writer, WiresharkTemplatePath + "enumparser.c", Assembly.GetExecutingAssembly());

                        template.AddReplacement("_NAME_", enumtype.Name);

                        AddTemplate(
                            template,
                            "// _ENTRY_",
                            WiresharkTemplatePath + "enumparser.c",
                            enumtype.Value,
                            null,
                            new WriteTemplateEventHandler(WriteTemplate_Enum));

                        template.WriteTemplate(null);
                    }
                }

                writer.Write("\n/** header field definitions */\n" +
                             "static hf_register_info hf[] =\n" +
                             "{");
                int index = 0;
                int count = 0;
                // count number of enums
                foreach (DataType datatype in sortedTypes)
                {
                    EnumeratedType enumtype = datatype as EnumeratedType;

                    if (enumtype != null)
                    {
                        count++;
                    }
                }
                // generate code
                foreach (DataType datatype in sortedTypes)
                {
                    EnumeratedType enumtype = datatype as EnumeratedType;

                    if (enumtype != null)
                    {
                        Template template = new Template(writer, WiresharkTemplatePath + "enumregisterinfo.c", Assembly.GetExecutingAssembly());

                        template.AddReplacement("_NAME_", enumtype.Name);
                        template.WriteTemplate(null);
                        if ((index + 1) < count)
                        {
                            writer.Write(",");
                        }
                        index++;
                    }
                }
                writer.Write("\n};\n\n");
                writer.Write("/** Register enum types. */\n");
                writer.Write("void registerEnumTypes(int proto)\n");
                writer.Write("{\n");
                writer.Write("    proto_register_field_array(proto, hf, array_length(hf));\n");
                writer.Write("}\n");

            }
            finally
            {
                writer.Close();
            }
        }

        private void WriteTemplate_EnumsHeader(string namespacePrefix, string dictionaryName)
        {
            // get datatypes.
            List<DataType> datatypes = GetDataTypeList(null, m_exportAll, false);

            if (datatypes.Count == 0)
            {
                return;
            }

            // sort types to ensure types are declared in the correct order.
            List<DataType> sortedTypes = new List<DataType>();

            foreach (DataType datatype in datatypes)
            {
                AddDataType(datatype, sortedTypes);
            }

            datatypes = sortedTypes;

            string fileName = String.Format(@"{0}\{1}_enumparser.h", OutputDirectory, namespacePrefix);
            fileName = fileName.ToLower();

            StreamWriter writer = new StreamWriter(fileName, false);
            writer.Write(string.Format(m_sHeader, "OpcUa Enum Type Parser", DateTime.Now));
            writer.Write("#ifdef HAVE_CONFIG_H\n" +
                      "# include \"config.h\"\n" +
                      "#endif\n" +
                      "\n" +
                      "#include <gmodule.h>\n" +
                      "#include <epan/packet.h>\n\n");
            try
            {
                foreach (DataType datatype in sortedTypes)
                {
                    EnumeratedType enumtype = datatype as EnumeratedType;

                    if (enumtype != null)
                    {
                        writer.Write("void parse{0}(proto_tree *tree, tvbuff_t *tvb, gint *pOffset);\n", enumtype.Name);
                    }
                }

                writer.Write("void registerEnumTypes(int proto);\n\n");
            }
            finally
            {
                writer.Close();
            }
        }

        private bool WriteTemplate_Field(Template template, Context context)
        {
            HFEntry entry = context.Target as HFEntry;

            if (entry != null)
            {
                string sVariableName = "hf_opcua_"+entry.FieldName();
                string sFieldName = entry.FieldName();
                string sDataType = "";
                string sBase = "BASE_NONE";

                context.BlankLine = false;

                switch (entry.DataTypeName())
                {
                    case "Boolean": sDataType = "FT_BOOLEAN"; break;
                    case "Byte": sDataType = "FT_UINT8"; sBase = "BASE_DEC"; break;
                    case "SByte": sDataType = "FT_INT8"; sBase = "BASE_DEC"; break;
                    case "UInt16": sDataType = "FT_UINT16"; sBase = "BASE_DEC"; break;
                    case "Int16": sDataType = "FT_INT16"; sBase = "BASE_DEC"; break;
                    case "UInt32": sDataType = "FT_UINT32"; sBase = "BASE_DEC"; break;
                    case "Int32": sDataType = "FT_INT32"; sBase = "BASE_DEC"; break;
                    case "UInt64": sDataType = "FT_UINT64"; sBase = "BASE_DEC"; break;
                    case "Int64": sDataType = "FT_INT64"; sBase = "BASE_DEC"; break;
                    case "Float": sDataType = "FT_FLOAT"; break;
                    case "Double": sDataType = "FT_DOUBLE"; break;
                    case "Guid": sDataType = "FT_GUID"; break;
                    case "String": sDataType = "FT_STRING"; break;
                    case "StatusCode": sDataType = "FT_UINT32"; sBase = "BASE_HEX"; break;
                    case "ByteString": sDataType = "FT_BYTES"; sBase = "BASE_HEX"; break;
                    case "XmlElement": sDataType = "FT_BYTES"; sBase = "BASE_HEX"; break;
                    case "DateTime": sDataType = "FT_ABSOLUTE_TIME"; break;
                    default:
                        sDataType = "FT_UNKNOWN";
                        break;
                }

                if (sDataType != "FT_UNKNOWN")
                {
                    if (context.Token == "// _INDECES_")
                    {
                        string sFormat = "\nint {0} = -1;";
                        string sEntry = string.Format(sFormat, sVariableName);
                        template.Write(sEntry);
                    }
                    else if (context.Token == "// _EXTERNINDECES_")
                    {
                        string sFormat = "\nextern int {0};";
                        string sEntry = string.Format(sFormat, sVariableName);
                        template.Write(sEntry);
                    }
                    else if (context.Token == "// _FIELDS_")
                    {
                        string sFormat = "\n   {{ &{0}, {{ \"{1}\", \"\", {2}, {3}, NULL, 0x0, \"\", HFILL }} }}";
                        string sEntry = string.Format(sFormat, sVariableName, sFieldName, sDataType, sBase);

                        if (!context.FirstInList)
                        {
                            template.Write(",");
                        }
                        template.Write(sEntry);
                    }
                }
            }

            return true;
        }

        private bool WriteTemplate_Parser(Template template, Context context)
        {
            FieldType field = context.Target as FieldType;

            if (field != null)
            {
                DataType dt = m_validator.ResolveType(field.DataType);
                string sDataTypeName = dt.Name;

                if (field.ValueRank == -1)
                {
                    //if (field.DataType.Namespace == "http://opcfoundation.org/UA/BuiltInTypes/" ||
                    //    field.DataType.Namespace == "http://opcfoundation.org/UA/Core/DataTypes/")
                    if (m_hashSimpleTypes.ContainsKey(sDataTypeName))
                    {
                        m_lstFields.Add(new HFEntry(field.Name, sDataTypeName));
                        template.Write(string.Format("\n  parse{0}(subtree, tvb, pOffset, hf_opcua_{1});", sDataTypeName, field.Name));
                    }
                    else if ((dt as EnumeratedType) != null)
                    {
                        template.Write(string.Format("\n  parse{0}(subtree, tvb, pOffset);", sDataTypeName));
                    }
                    else
                    {
                        template.Write(string.Format("\n  parse{0}(subtree, tvb, pOffset, \"{1}\");", sDataTypeName, field.Name));
                    }
                }
                else
                {
                    //if (field.DataType.Namespace == "http://opcfoundation.org/UA/BuiltInTypes/" ||
                    //    field.DataType.Namespace == "http://opcfoundation.org/UA/Core/DataTypes/")
                    if (m_hashSimpleTypes.ContainsKey(sDataTypeName))
                    {
                        m_lstFields.Add(new HFEntry(field.Name, sDataTypeName));
                        template.Write(string.Format("\n  parseArraySimple(subtree, tvb, pOffset, hf_opcua_{1}, parse{0});", sDataTypeName, field.Name));
                    }
                    else if ((dt as EnumeratedType) != null)
                    {
                        template.Write(string.Format("\n  parseArrayEnum(subtree, tvb, pOffset, parse{0});", sDataTypeName));
                    }
                    else
                    {
                        template.Write(string.Format("\n  parseArrayComplex(subtree, tvb, pOffset, \"{1}\", parse{0});", sDataTypeName, field.Name));
                    }
                }
            }
            return false;
        }

        private bool WriteTemplate_Enum(Template template, Context context)
        {
            EnumeratedValue field = context.Target as EnumeratedValue;

            if (field != null)
            {
                context.BlankLine = false;

                template.Write(string.Format("\n  {{ {0}, \"{1}\" }},", field.Value, field.Name));
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds all datatypes referenced by a datatype to the list first.
        /// </summary>
        private void AddDataType(DataType datatype, List<DataType> sortedTypes)
        {
            if (datatype == null || sortedTypes.Contains(datatype))
            {
                return;
            }

            ComplexType complexType = datatype as ComplexType;

            if (complexType != null)
            {
                if (complexType.BaseType != null)
                {
                    AddDataType(Validator.ResolveType(complexType.BaseType), sortedTypes);
                }

                if (complexType.Field != null)
                {
                    foreach (FieldType field in complexType.Field)
                    {
                        AddDataType(Validator.ResolveType(field.DataType), sortedTypes);
                    }
                }
            }

            ServiceType serviceType = datatype as ServiceType;

            if (serviceType != null)
            {
                if (serviceType.Request != null)
                {
                    foreach (FieldType field in serviceType.Request)
                    {
                        AddDataType(Validator.ResolveType(field.DataType), sortedTypes);
                    }
                }

                if (serviceType.Response != null)
                {
                    foreach (FieldType field in serviceType.Response)
                    {
                        AddDataType(Validator.ResolveType(field.DataType), sortedTypes);
                    }
                }
            }

            if (datatype.QName.Namespace != Namespaces.OpcUaBuiltInTypes)
            {
                sortedTypes.Add(datatype);
            }
        }

        #region Private Fields
        private bool m_exportAll;
        #endregion
    }
}
