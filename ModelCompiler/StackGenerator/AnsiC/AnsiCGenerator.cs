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
    /// Generates code based on a UA Type Dictionary.
    /// </summary>
    public class AnsiCGenerator : CodeGenerator
    {
        #region Constructors
        /// <summary>
        /// Generates the code from the contents of the address space.
        /// </summary>
        public AnsiCGenerator(
            string                    inputPath,
            string                    outputDirectory,
            Dictionary<string,string> knownFiles)
        :
            base(inputPath, outputDirectory, knownFiles)
        {
            TargetLanguage = Language.AnsiC;
        }
        #endregion

        #region Public Properties
        const string TemplatePath = "Opc.Ua.ModelCompiler.StackGenerator.AnsiC.Templates.";
        #endregion

        #region Public Methods
        /// <summary>
        /// Generates the datatype files.
        /// </summary>
        public virtual void Generate(string namespacePrefix, string dictionaryName, bool exportAll)
        {
            DictionaryName = dictionaryName;
            m_namespaceConstant = "OpcUa";
            m_exportAll = exportAll;

            WriteTemplate_TypesHeader(namespacePrefix, dictionaryName);
            WriteTemplate_TypesImplementation(namespacePrefix, dictionaryName);
            WriteTemplate_ClientApiHeader(namespacePrefix, dictionaryName);
            WriteTemplate_ClientApiImplementation(namespacePrefix, dictionaryName);
            WriteTemplate_ServerApiHeader(namespacePrefix, dictionaryName);
            WriteTemplate_ServerApiImplementation(namespacePrefix, dictionaryName);
        }
        #endregion

        #region WriteTemplate Methods
        /// <summary>
        /// Writes classes that implement the data types.
        /// </summary>
        private void WriteTemplate_ServerApiHeader(string namespacePrefix, string dictionaryName)
        {
            // get datatypes.
            List<DataType> services = GetDataTypeList(typeof(ServiceType), m_exportAll, false);

            if (services.Count == 0)
            {
                return;
            }

            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}_serverapi.h", OutputDirectory, namespacePrefix).ToLower(), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "ServerApi.File.h", Assembly.GetExecutingAssembly());

                template.AddReplacement("_Date_", DateTime.Now);
                template.AddReplacement("_Prefix_", namespacePrefix);

                AddTemplate(
                    template,
                    "// _Declaration_",
                    TemplatePath + "ServerApi.Service.h",
                    services,
                    new LoadTemplateEventHandler(LoadTemplate_Api),
                    new WriteTemplateEventHandler(WriteTemplate_ServerApi));

                template.WriteTemplate(null);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Writes classes that implement the data types.
        /// </summary>
        private void WriteTemplate_ServerApiImplementation(string namespacePrefix, string dictionaryName)
        {
            // get datatypes.
            List<DataType> services = GetDataTypeList(typeof(ServiceType), m_exportAll, false);

            if (services.Count == 0)
            {
                return;
            }

            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}_serverapi.c", OutputDirectory, namespacePrefix).ToLower(), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "ServerApi.File.c", Assembly.GetExecutingAssembly());

                template.AddReplacement("_Date_", DateTime.Now);
                template.AddReplacement("_Prefix_", namespacePrefix);

                AddTemplate(
                    template,
                    "// _Implementation_",
                    TemplatePath + "ServerApi.Service.c",
                    services,
                    new LoadTemplateEventHandler(LoadTemplate_Api),
                    new WriteTemplateEventHandler(WriteTemplate_ServerApi));

                AddTemplate(
                    template,
                    "// _KnownServiceList_",
                    null,
                    services,
                    new LoadTemplateEventHandler(LoadTemplate_KnownService),
                    null);

                template.WriteTemplate(null);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Writes classes that implement the data types.
        /// </summary>
        private void WriteTemplate_ClientApiHeader(string namespacePrefix, string dictionaryName)
        {
            // get datatypes.
            List<DataType> services = GetDataTypeList(typeof(ServiceType), m_exportAll, false);

            if (services.Count == 0)
            {
                return;
            }

            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}_clientapi.h", OutputDirectory, namespacePrefix).ToLower(), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "ClientApi.File.h", Assembly.GetExecutingAssembly());

                template.AddReplacement("_Date_", DateTime.Now);
                template.AddReplacement("_Prefix_", namespacePrefix);

                AddTemplate(
                    template,
                    "// _Declaration_",
                    TemplatePath + "ClientApi.Service.h",
                    services,
                    new LoadTemplateEventHandler(LoadTemplate_Api),
                    new WriteTemplateEventHandler(WriteTemplate_ClientApi));

                template.WriteTemplate(null);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Writes classes that implement the data types.
        /// </summary>
        private void WriteTemplate_ClientApiImplementation(string namespacePrefix, string dictionaryName)
        {
            // get datatypes.
            List<DataType> services = GetDataTypeList(typeof(ServiceType), m_exportAll, false);

            if (services.Count == 0)
            {
                return;
            }

            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}_clientapi.c", OutputDirectory, namespacePrefix).ToLower(), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "ClientApi.File.c", Assembly.GetExecutingAssembly());

                template.AddReplacement("_Date_", DateTime.Now);
                template.AddReplacement("_Prefix_", namespacePrefix);

                AddTemplate(
                    template,
                    "// _Implementation_",
                    TemplatePath + "ClientApi.Service.c",
                    services,
                    new LoadTemplateEventHandler(LoadTemplate_Api),
                    new WriteTemplateEventHandler(WriteTemplate_ClientApi));

                template.WriteTemplate(null);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Writes a service.
        /// </summary>
        private string LoadTemplate_Api(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null || serviceType.InterfaceType == InterfaceType.SecureChannel)
            {
                return null;
            }

            return context.TemplatePath;
        }

        /// <summary>
        /// Writes a service.
        /// </summary>
        private bool WriteTemplate_ClientApi(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return false;
            }

            bool declaration = context.Token.Contains("Declaration");

            template.AddReplacement("_NAME_", serviceType.Name);
            template.AddReplacement("_TYPE_", m_namespaceConstant + "_" + serviceType.Name);

            AddTemplate(
                template,
                "SyncArgList)" + ((declaration)?";":""),
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_SyncParameters),
                null);

            AddTemplate(
                template,
                "AsyncArgList)" + ((declaration)?";":""),
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_BeginAsyncParameters),
                null);

            AddTemplate(
                template,
                "AsyncExArgList)" + ((declaration) ? ";" : ""),
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_BeginAsyncExParameters),
                null);

            AddTemplate(
                template,
                "AsyncRspList)" + ((declaration) ? ";" : ""),
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_EndAsyncExParameters),
                null);

            AddTemplate(
                template,
                "// ValidateArguments",
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_ValidateParameters),
                null);

            AddTemplate(
                template,
                "// ValidateAsyncArguments",
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_ValidateParameters),
                null);

            AddTemplate(
                template,
                "// RequestParameters",
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_RequestParameters),
                null);

            AddTemplate(
                template,
                "// ResponseParameters",
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_ResponseParameters),
                null);

            AddTemplate(
                template,
                "// AsyncResponseParameters",
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_AsyncResponseParameters),
                null);

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Writes a service.
        /// </summary>
        private bool WriteTemplate_ServerApi(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return false;
            }

            bool declaration = context.Token.Contains("Declaration");

            template.AddReplacement("_NAME_", serviceType.Name);
            template.AddReplacement("_TYPE_", m_namespaceConstant + "_" + serviceType.Name);

            AddTemplate(
                template,
                "ServerSyncArgList)" + ((declaration)?";":""),
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_SyncParameters),
                null);

            AddTemplate(
                template,
                "ServerPointerArgList);",
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_SyncParameters),
                null);

            AddTemplate(
                template,
                "// ValidateArguments",
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_ValidateParameters),
                null);

            AddTemplate(
                template,
                "InvokeArgList);",
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_InvokeService),
                null);

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Writes a synchronous method declaration.
        /// </summary>
        private string LoadTemplate_InvokeService(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return null;
            }

            // write method declaration.
            template.WriteLine(String.Empty);
            template.Write(context.Prefix);
            template.Write("a_hEndpoint,");
            template.Write(context.Prefix);
            template.Write("a_hContext");

            if (serviceType.Request != null)
            {
                foreach (FieldType field in serviceType.Request)
                {
                    template.Write(",");

                    if (field.ValueRank >= 0)
                    {
                        template.WriteLine(String.Empty);
                        template.Write(context.Prefix);
                        template.Write("pRequest->NoOf{0},", field.Name);
                    }

                    template.WriteLine(String.Empty);
                    template.Write(context.Prefix);

                    if (GetAnsiCTypePrefix(field.DataType, field.ValueRank, false) == "p" && field.ValueRank < 0)
                    {
                        template.Write("&");
                    }

                    template.Write("pRequest->{0}", field.Name);
                }
            }

            if (serviceType.Response != null)
            {
                foreach (FieldType field in serviceType.Response)
                {
                    template.Write(",");

                    if (field.ValueRank >= 0)
                    {
                        template.WriteLine(String.Empty);
                        template.Write(context.Prefix);
                        template.Write("&pResponse->NoOf{0},", field.Name);
                    }

                    template.WriteLine(String.Empty);
                    template.Write(context.Prefix);
                    template.Write("&pResponse->{0}", field.Name);
                }
            }

            template.Write(");");

            return null;
        }

        /// <summary>
        /// Writes a synchronous method declaration.
        /// </summary>
        private string LoadTemplate_SyncParameters(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return null;
            }

            context.BlankLine = false;

            bool declaration = context.Token.EndsWith(";");
            bool server      = context.Token.Contains("Server");

            List<string> types = new List<string>();
            List<string> names = new List<string>();

            if (!server)
            {
                types.Add("OpcUa_Channel");
                names.Add(((declaration) ? "" : "a_") + "hChannel");
            }
            else
            {
                types.Add("OpcUa_Endpoint");
                names.Add(((declaration) ? "" : "a_") + "hEndpoint");
                types.Add("OpcUa_Handle");
                names.Add(((declaration) ? "" : "a_") + "hContext");
            }

            CollectParameters(serviceType.Request, false, false, !declaration, false, types, names);
            CollectParameters(serviceType.Response, true, false, !declaration, false, types, names);

            WriteParameters(template, context, types, names, "", ",", ")");

            // terminate with a semicolon if writing declaration.
            if (declaration)
            {
                template.Write(";");
            }

            return null;
        }

        /// <summary>
        /// Writes a begin asynchronous method declaration.
        /// </summary>
        private string LoadTemplate_BeginAsyncParameters(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return null;
            }

            context.BlankLine = false;

            bool declaration = context.Token.EndsWith(";");

            List<string> types = new List<string>();
            List<string> names = new List<string>();

            types.Add("OpcUa_Channel");
            names.Add(((declaration)?"":"a_") + "hChannel");

            CollectParameters(serviceType.Request, false, false, !declaration, false, types, names);

            types.Add("OpcUa_Channel_PfnRequestComplete*");
            names.Add(((declaration)?"":"a_") + "pCallback");

            types.Add("OpcUa_Void*");
            names.Add(((declaration)?"":"a_") + "pCallbackData");

            WriteParameters(template, context, types, names, "", ",", ")");

            // terminate with a semicolon if writing declaration.
            if (declaration)
            {
                template.Write(";");
            }

            return null;
        }

        /// <summary>
        /// Writes a begin extended asynchronous method declaration.
        /// </summary>
        private string LoadTemplate_BeginAsyncExParameters(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return null;
            }

            context.BlankLine = false;

            bool declaration = context.Token.EndsWith(";");

            List<string> types = new List<string>();
            List<string> names = new List<string>();

            types.Add("OpcUa_Channel");
            names.Add(((declaration) ? "" : "a_") + "hChannel");

            CollectParameters(serviceType.Request, false, false, !declaration, false, types, names);

            types.Add("OpcUa_ClientApi_EndEx" + serviceType.Name + "*");
            names.Add(((declaration) ? "" : "a_") + "pCallback");

            types.Add("OpcUa_Void*");
            names.Add(((declaration) ? "" : "a_") + "pCallbackData");

            WriteParameters(template, context, types, names, "", ",", ")");

            // terminate with a semicolon if writing declaration.
            if (declaration)
            {
                template.Write(";");
            }

            return null;
        }

        /// <summary>
        /// Writes a end extended asynchronous method declaration.
        /// </summary>
        private string LoadTemplate_EndAsyncExParameters(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return null;
            }

            context.BlankLine = false;

            bool declaration = context.Token.EndsWith(";");

            List<string> types = new List<string>();
            List<string> names = new List<string>();

            types.Add("OpcUa_Channel");
            names.Add(((declaration) ? "" : "a_") + "hChannel");
            types.Add("OpcUa_StatusCode");
            names.Add(((declaration) ? "" : "a_") + "StatusCode");

            CollectParameters(serviceType.Response, true, false, !declaration, false, types, names);

            types.Add("OpcUa_Void*");
            names.Add(((declaration) ? "" : "a_") + "pCallbackData");

            WriteParameters(template, context, types, names, "", ",", ")");

            // terminate with a semicolon if writing declaration.
            if (declaration)
            {
                template.Write(";");
            }

            return null;
        }

        /// <summary>
        /// Copies the request paramaters into the request object.
        /// </summary>
        private string LoadTemplate_ValidateParameters(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return null;
            }

            int responseStartIndex = 0;
            List<string> types = new List<string>();
            List<string> names = new List<string>();

            CollectParameters(serviceType.Request, false, false, true, false, types, names);
            responseStartIndex = names.Count;

            if (context.Token != "// ValidateAsyncArguments")
            {
                CollectParameters(serviceType.Response, true, false, true, false, types, names);
            }

            bool isArray = false;

            for (int ii = 0; ii < names.Count; ii++)
            {
                if (names[ii].IndexOf("NoOf") != -1)
                {
                    isArray = true;

                    if (ii < responseStartIndex)
                    {
                        continue;
                    }
                }

                template.WriteLine(String.Empty);
                template.Write(context.Prefix);

                if (isArray && ii < responseStartIndex)
                {
                    template.Write("OpcUa_ReturnErrorIfArrayArgumentNull({0}, {1});", names[ii-1].Trim(), names[ii]);
                    isArray = false;
                }
                else if (types[ii].EndsWith("*"))
                {
                    template.Write("OpcUa_ReturnErrorIfArgumentNull({0});", names[ii]);
                }
                else
                {
                    template.Write("OpcUa_ReferenceParameter({0});", names[ii]);
                }
            }

            return null;
        }

        /// <summary>
        /// Copies the request paramaters into the request object.
        /// </summary>
        private string LoadTemplate_RequestParameters(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return null;
            }

            List<string> types = new List<string>();
            List<string> names1 = new List<string>();;
            List<string> names2 = new List<string>();

            CollectParameters(serviceType.Request, false, true, false, false, types, names1);
            CollectParameters(serviceType.Request, false, false, true, true, types, names2);

            // calculate maximum parameter length.
            int length = 0;

            foreach (string name in names1)
            {
                if (name.Length > length)
                {
                    length = name.Length;
                }
            }

            for (int ii = 0; ii < names1.Count; ii++)
            {
                string padding = null;

                if (names1[ii].Length < length)
                {
                    padding = new string(' ', length-names1[ii].Length);
                }

                template.WriteLine(String.Empty);
                template.Write(context.Prefix);

                if (types[ii] == "OpcUa_String")
                {
                    template.Write("cRequest.{0}{1} = {2};", names1[ii], padding, names2[ii]);
                    // template.Write("OpcUa_String_SafeAttachReadOnly(&cRequest.{0}, {1});", names1[ii], names2[ii].Substring(1));
                }
                else if (types[ii].EndsWith("*"))
                {
                    template.Write("cRequest.{0}{1} = ({3}){2};", names1[ii], padding, names2[ii], types[ii]);
                }
                else
                {
                    template.Write("cRequest.{0}{1} = {2};", names1[ii], padding, names2[ii]);
                }
            }

            return null;
        }

        /// <summary>
        /// Copies the request paramaters into the request object.
        /// </summary>
        private string LoadTemplate_ResponseParameters(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return null;
            }

            List<string> types  = new List<string>();
            List<string> names1 = new List<string>();
            List<string> names2 = new List<string>();

            CollectParameters(serviceType.Response, false, true, false, false, types, names1);
            CollectParameters(serviceType.Response, true, false, true, true, types, names2);

            int length = 0;

            foreach (string name in names1)
            {
                if (name.Length > length)
                {
                    length = name.Length;
                }
            }

            for (int ii = 0; ii < names1.Count; ii++)
            {
                string padding = null;

                if (names1[ii].Length < length)
                {
                    padding = new string(' ', length-names1[ii].Length);
                }

                template.WriteLine(String.Empty);
                template.Write(context.Prefix);
                template.Write("{0}{1} = pResponse->{2};", names2[ii], padding, names1[ii]);
            }

            return null;
        }

        /// <summary>
        /// Extracts the ascync response paramaters into the callback signature.
        /// </summary>
        private string LoadTemplate_AsyncResponseParameters(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return null;
            }

            List<string> types = new List<string>();
            List<string> names1 = new List<string>();

            CollectParameters(serviceType.Response, false, true, false, false, types, names1);

            int length = 0;

            foreach (string name in names1)
            {
                if (name.Length > length)
                {
                    length = name.Length;
                }
            }

            for (int ii = 0; ii < names1.Count; ii++)
            {
                template.WriteLine(String.Empty);
                template.Write(context.Prefix);
                template.Write("&pResponse->{0},", names1[ii]);
            }

            return null;
        }

        /// <summary>
        /// Writes classes that implement the data types.
        /// </summary>
        private void WriteTemplate_TypesHeader(string namespacePrefix, string dictionaryName)
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

            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}_types.h", OutputDirectory, namespacePrefix).ToLower(), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "Types.File.h", Assembly.GetExecutingAssembly());

                template.AddReplacement("_Date_", DateTime.Now);
                template.AddReplacement("_Prefix_", namespacePrefix);

                AddTemplate(
                    template,
                    "// _Declaration_",
                    null,
                    datatypes,
                    new LoadTemplateEventHandler(LoadTemplate_TypeDeclaration),
                    new WriteTemplateEventHandler(WriteTemplate_TypeDeclaration));

                template.WriteTemplate(null);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Writes classes that implement the data types.
        /// </summary>
        private void WriteTemplate_TypesImplementation(string namespacePrefix, string dictionaryName)
        {
            // get datatypes.
            List<DataType> datatypes = GetDataTypeList(null, m_exportAll, false);

            if (datatypes.Count == 0)
            {
                return;
            }

            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}_types.c", OutputDirectory, namespacePrefix).ToLower(), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "Types.File.c", Assembly.GetExecutingAssembly());

                template.AddReplacement("_Date_", DateTime.Now);
                template.AddReplacement("_Prefix_", namespacePrefix);

                AddTemplate(
                    template,
                    "// _Implementation_",
                    null,
                    datatypes,
                    new LoadTemplateEventHandler(LoadTemplate_TypeDeclaration),
                    new WriteTemplateEventHandler(WriteTemplate_TypeDeclaration));

                AddTemplate(
                    template,
                    "// _KnownTypeList_",
                    null,
                    datatypes,
                    new LoadTemplateEventHandler(LoadTemplate_KnownType),
                    null);

                template.WriteTemplate(null);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Loads the template
        /// </summary>
        private string LoadTemplate_TypeDeclaration(Template template, Context context)
        {
            string suffix = ".h";

            if (context.Token == "// _Implementation_")
            {
                suffix = ".c";
            }

            // do not publish type declarations as types.
            if (typeof(TypeDeclaration).IsInstanceOfType(context.Target))
            {
                return null;
            }

            if (typeof(ComplexType).IsInstanceOfType(context.Target))
            {
                ComplexType complexType = context.Target as ComplexType;

                // skip types with no fields (must check inhieritance tree as well).
                List<FieldType> fields = new List<FieldType>();
                CollectFields(complexType, fields);

                if (fields.Count == 0)
                {
                    return null;
                }

                return TemplatePath + "Types.ComplexType" + suffix;
            }

            if (typeof(EnumeratedType).IsInstanceOfType(context.Target))
            {
                return TemplatePath + "Types.EnumeratedType" + suffix;
            }

            if (typeof(ServiceType).IsInstanceOfType(context.Target))
            {
                return TemplatePath + "Types.ServiceType" + suffix;
            }

            // do not publish unrecognized sub-types.
            return null;
        }

        /// <summary>
        /// Writes a class.
        /// </summary>
        private bool WriteTemplate_TypeDeclaration(Template template, Context context)
        {
            DataType datatype = context.Target as DataType;

            if (datatype == null)
            {
                return false;
            }

            template.AddReplacement("_NAME_", datatype.Name);
            template.AddReplacement("_TYPE_", String.Format("{0}_{1}", m_namespaceConstant, datatype.Name));

            ComplexType complexType = datatype as ComplexType;

            if (complexType != null)
            {
                AddTemplate(
                    template,
                    "// _FieldList_",
                    null,
                    new DataType[] { complexType },
                    new LoadTemplateEventHandler(LoadTemplate_DeclareFields),
                    null);

                AddTemplate(
                    template,
                    "// _InitializeList_",
                    null,
                    new DataType[] { complexType },
                    new LoadTemplateEventHandler(LoadTemplate_Fields),
                    null);

                AddTemplate(
                    template,
                    "// _ClearList_",
                    null,
                    new DataType[] { complexType },
                    new LoadTemplateEventHandler(LoadTemplate_Fields),
                    null);

                AddTemplate(
                    template,
                    "// _GetSizeList_",
                    null,
                    new DataType[] { complexType },
                    new LoadTemplateEventHandler(LoadTemplate_Fields),
                    null);

                AddTemplate(
                    template,
                    "// _EncodeList_",
                    null,
                    new DataType[] { complexType },
                    new LoadTemplateEventHandler(LoadTemplate_Fields),
                    null);

                AddTemplate(
                    template,
                    "// _DecodeList_",
                    null,
                    new DataType[] { complexType },
                    new LoadTemplateEventHandler(LoadTemplate_Fields),
                    null);
            }

            EnumeratedType enumeratedType = datatype as EnumeratedType;

            if (enumeratedType != null)
            {
                if (enumeratedType.Value != null && enumeratedType.Value.Length > 0)
                {
                    template.AddReplacement("_DEFAULT_", String.Format("OpcUa_{0}_{1}", enumeratedType.Name, enumeratedType.Value[0].Name));
                }

                AddTemplate(
                    template,
                    "// _ValueList_",
                    null,
                    new DataType[] { enumeratedType },
                    new LoadTemplateEventHandler(LoadTemplate_EnumerationValues),
                    null);

                AddTemplate(
                    template,
                    "// _ValueStringList_",
                    TemplatePath + "Types.EnumeratedValue.c",
                    enumeratedType.Value,
                    null,
                    new WriteTemplateEventHandler(WriteTemplate_EnumerationValue));
            }

            ServiceType serviceType = datatype as ServiceType;

            if (serviceType != null)
            {
                string suffix = ".h";

                if (context.Token == "// _Implementation_")
                {
                    suffix = ".c";
                }

                ComplexType requestType = new ComplexType();

                requestType.Name  = serviceType.Name + "Request";
                requestType.QName = new XmlQualifiedName(requestType.Name, serviceType.QName.Namespace);
                requestType.Field = serviceType.Request;

                AddTemplate(
                    template,
                    "// _RequestMessage_",
                    TemplatePath + "Types.ComplexType" + suffix,
                    new DataType[] { requestType },
                    null,
                    new WriteTemplateEventHandler(WriteTemplate_TypeDeclaration));

                ComplexType responseType = new ComplexType();

                responseType.Name  = serviceType.Name + "Response";
                responseType.QName = new XmlQualifiedName(responseType.Name, serviceType.QName.Namespace);
                responseType.Field = serviceType.Response;

                AddTemplate(
                    template,
                    "// _ResponseMessage_",
                    TemplatePath + "Types.ComplexType" + suffix,
                    new DataType[] { responseType },
                    null,
                    new WriteTemplateEventHandler(WriteTemplate_TypeDeclaration));
            }

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Writes a declaration of a known encodeable type.
        /// </summary>
        private string LoadTemplate_KnownType(Template template, Context context)
        {
            DataType datatype = context.Target as DataType;

            if (datatype == null)
            {
                return null;
            }

            ComplexType complexType = datatype as ComplexType;

            if (complexType != null)
            {
                // skip types with no fields (must check inhieritance tree as well).
                List<FieldType> fields = new List<FieldType>();
                CollectFields(complexType, fields);

                if (fields.Count == 0)
                {
                    return null;
                }

                template.WriteLine(String.Empty);
                template.Write(context.Prefix);
                template.Write("#ifndef OPCUA_EXCLUDE_{0}", complexType.QName.Name);

                template.WriteLine(String.Empty);
                template.Write(context.Prefix);
                template.Write("&{0}_EncodeableType,", GetAnsiCTypeName(complexType.QName, -1, m_namespaceConstant));

                template.WriteLine(String.Empty);
                template.Write(context.Prefix);
                template.Write("#endif");
            }

            ServiceType serviceType = datatype as ServiceType;

            if (serviceType != null)
            {
                template.WriteLine(String.Empty);
                template.Write(context.Prefix);
                template.Write("#ifndef OPCUA_EXCLUDE_{0}", serviceType.QName.Name);

                template.WriteLine(String.Empty);
                template.Write(context.Prefix);
                template.Write("&{0}Request_EncodeableType,", GetAnsiCTypeName(serviceType.QName, -1, m_namespaceConstant));

                template.WriteLine(String.Empty);
                template.Write(context.Prefix);
                template.Write("&{0}Response_EncodeableType,", GetAnsiCTypeName(serviceType.QName, -1, m_namespaceConstant));

                template.WriteLine(String.Empty);
                template.Write(context.Prefix);
                template.Write("#endif");
            }

            return null;
        }

        /// <summary>
        /// Writes a declaration of a known service type.
        /// </summary>
        private string LoadTemplate_KnownService(Template template, Context context)
        {
            ServiceType datatype = context.Target as ServiceType;

            if (datatype == null || datatype.InterfaceType == InterfaceType.SecureChannel)
            {
                return null;
            }

            template.WriteLine(String.Empty);
            template.Write(context.Prefix);
            template.Write("#ifndef OPCUA_EXCLUDE_{0}", datatype.QName.Name);

            template.WriteLine(String.Empty);
            template.Write(context.Prefix);
            template.Write("&{0}_ServiceType,", GetAnsiCTypeName(datatype.QName, -1, m_namespaceConstant));

            template.WriteLine(String.Empty);
            template.Write(context.Prefix);
            template.Write("#endif");

            return null;
        }

        /// <summary>
        /// Writes the class member for a field.
        /// </summary>
        private string LoadTemplate_DeclareFields(Template template, Context context)
        {
            ComplexType complexType = context.Target as ComplexType;

            if (complexType == null)
            {
                return null;
            }

            // skip types with no fields (must check inhieritance tree as well).
            List<FieldType> fields = new List<FieldType>();
            CollectFields(complexType, fields);

            if (fields.Count == 0)
            {
                return null;
            }

            List<string> types = new List<string>();
            List<string> names = new List<string>();

            CollectParameters(fields.ToArray(), false, true, false, false, types, names);
            WriteParameters(template, context, types, names, "", ";", ";");

            return null;
        }

        /// <summary>
        /// Writes the class member for a field.
        /// </summary>
        private string LoadTemplate_Fields(Template template, Context context)
        {
            ComplexType complexType = context.Target as ComplexType;

            if (complexType == null)
            {
                return null;
            }

            // skip types with no fields (must check inhieritance tree as well).
            List<FieldType> fields = new List<FieldType>();
            CollectFields(complexType, fields);

            if (fields.Count == 0)
            {
                return null;
            }

            string functionName = null;

            switch (context.Token)
            {
                case "// _InitializeList_": { functionName = "Initialize"; break; }
                case "// _ClearList_":      { functionName = "Clear";      break; }
                case "// _GetSizeList_":    { functionName = "GetSize";    break; }
                case "// _EncodeList_":     { functionName = "Write";      break; }
                case "// _DecodeList_":     { functionName = "Read";       break; }
            }

            WriteFunctions(template, context, fields, functionName);

            return null;
        }

        /// <summary>
        /// Writes the class member for a field.
        /// </summary>
        private string LoadTemplate_EnumerationValues(Template template, Context context)
        {
            EnumeratedType enumeratedType = context.Target as EnumeratedType;

            if (enumeratedType == null)
            {
                return null;
            }

            int length = 0;

            List<string> names  = new List<string>();
            List<string> values = new List<string>();

            string typeName = GetAnsiCTypeName(enumeratedType.QName, -1, m_namespaceConstant);

            if (enumeratedType.Value != null)
            {
                foreach (EnumeratedValue value in enumeratedType.Value)
                {
                    string name = String.Format("{0}_{1}", typeName, value.Name);

                    if (length < name.Length)
                    {
                        length = name.Length;
                    }

                    names.Add(name);

                    if (enumeratedType.IsOptionSet)
                    {
                        if (!String.IsNullOrEmpty(value.BitMask))
                        {
                            ulong mask = 0;
                            
                            if (UInt64.TryParse(value.BitMask, System.Globalization.NumberStyles.AllowHexSpecifier, System.Globalization.CultureInfo.InvariantCulture, out mask))
                            {
                                var bytes = BitConverter.GetBytes(mask);
                                value.Value = BitConverter.ToInt32(bytes, 0);
                                value.ValueSpecified = true;
                            }
                        }
                    }

                    values.Add(String.Format("= {0}", value.Value));
                }
            }

            WriteParameters(template, context, names, values, "", ",", "");

            template.WriteLine(String.Empty);
            template.Write("#if OPCUA_FORCE_INT32_ENUMS");
            template.WriteLine(String.Empty);
            template.Write(context.Prefix);
            template.Write(",_{0}_MaxEnumerationValue = OpcUa_Int32_Max", typeName);
            template.WriteLine(String.Empty);
            template.Write("#endif");

            return null;
        }

        /// <summary>
        /// Writes a class.
        /// </summary>
        private bool WriteTemplate_EnumerationValue(Template template, Context context)
        {
            EnumeratedValue value = context.Target as EnumeratedValue;

            if (value == null)
            {
                return false;
            }

            template.AddReplacement("_Name_", value.Name);
            template.AddReplacement("_Value_", value.Value);

            context.BlankLine = false;
            return template.WriteTemplate(context);
        }
        #endregion

        #region Private Methods
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

        /// <summary>
        /// Collects the parameters to write.
        /// </summary>
        private void CollectFields(ComplexType complexType, List<FieldType> fields)
        {
            // collect base type parameters.
            Stack<ComplexType> baseTypes = new Stack<ComplexType>();
            ComplexType baseType = Validator.ResolveType(complexType.BaseType) as ComplexType;

            while (baseType != null)
            {
                baseTypes.Push(baseType);
                baseType = Validator.ResolveType(baseType.BaseType) as ComplexType;
            }

            while (baseTypes.Count > 0)
            {
                baseType = baseTypes.Pop();

                if (baseType.Field != null)
                {
                    fields.AddRange(baseType.Field);
                }
            }

            fields.AddRange(complexType.Field);
        }

        /// <summary>
        /// Collects the parameters to write.
        /// </summary>
        private void CollectParameters(
            FieldType[]  fields,
            bool         output,
            bool         typeDef,
            bool         argprefix,
            bool         dereference,
            List<string> types,
            List<string> names)
        {
            if (fields != null)
            {
                foreach (FieldType field in fields)
                {
                    string name = String.Empty;

                    // add parameter for array size.
                    if (field.ValueRank >= 0)
                    {
                        if (output)
                        {
                            types.Add("OpcUa_Int32*");
                        }
                        else
                        {
                            types.Add("OpcUa_Int32");
                        }

                        name = String.Empty;

                        if (argprefix)
                        {
                            name += "a_";
                        }

                        if (!typeDef)
                        {
                            if (output)
                            {
                                if (dereference)
                                {
                                    name = "*" + name;
                                }

                                name += "p";
                            }
                            else
                            {
                                name += "n";
                            }
                        }

                        name += "NoOf";
                        name += field.Name;

                        names.Add(name);
                    }

                    // look up type name.
                    DataType datatype = Validator.ResolveType(field.DataType);

                    string typeName = GetAnsiCTypeName(datatype.QName, field.ValueRank, m_namespaceConstant);

                    // look up type prefix.
                    string prefix = GetAnsiCTypePrefix(datatype.QName, field.ValueRank, output);

                    name = String.Empty;

                    if (argprefix)
                    {
                        name += "a_";
                    }

                    if (prefix == "p" && !typeDef && (field.ValueRank < 0 || output))
                    {
                        typeName = typeName + "*";

                        if (dereference)
                        {
                            name = "*" + name;
                        }
                    }

                    if (prefix == "p" && !typeDef && !output)
                    {
                        typeName = String.Format("const {0}", typeName);
                    }

                    types.Add(typeName);

                    if (!typeDef)
                    {
                        name += prefix;
                    }

                    name += field.Name;

                    names.Add(name);
                }
            }
        }

        /// <summary>
        /// Writes a set of method parameters.
        /// </summary>
        private void WriteParameters(
            Template     template,
            Context      context,
            List<string> types,
            List<string> names,
            string       indent,
            string       suffix,
            string       finalSuffix)
        {
            int length = 0;

            for (int ii = 0; ii < types.Count; ii++)
            {
                if (types[ii].Length > length)
                {
                    length = types[ii].Length;
                }
            }

            for (int ii = 0; ii < types.Count; ii++)
            {
                string typeName = types[ii];

                if (typeName.Length < length)
                {
                    typeName += new string(' ', length-typeName.Length);
                }

                template.WriteLine(String.Empty);
                template.Write(context.Prefix);
                template.Write("{0}{1} {2}", indent, typeName, names[ii]);

                if (ii < types.Count - 1)
                {
                    template.Write(suffix);
                }
                else
                {
                    template.Write(finalSuffix);
                }
            }
        }

        /// <summary>
        /// Writes function calls for each field.
        /// </summary>
        private void WriteFunctions(
            Template        template,
            Context         context,
            List<FieldType> fields,
            string          functionName)
        {
            foreach (FieldType field in fields)
            {
                template.WriteLine(String.Empty);
                template.Write(context.Prefix);
                template.Write("OpcUa_Field_{0}", functionName);

                DataType datatype = Validator.ResolveType(field.DataType);

                string typeName = datatype.QName.Name;

                if (datatype.QName.Namespace != Namespaces.OpcUaBuiltInTypes)
                {
                    typeName = GetAnsiCTypeName(datatype.QName, -1, m_namespaceConstant);
                }

                if (datatype is EnumeratedType)
                {
                    template.Write("Enumerated");
                }
                else if (datatype is ComplexType)
                {
                    template.Write("Encodeable");
                }

                if (field.ValueRank >= 0)
                {
                    template.Write("Array");
                }

                template.Write("({0}, {1});", typeName, field.Name);
            }
        }

        /// <summary>
        /// Returns the type prefixe for a data type.
        /// </summary>
        protected string GetAnsiCTypePrefix(XmlQualifiedName qname, int valueRank, bool output)
        {
            if (IsNull(qname))
            {
                return String.Empty;
            }

            if (output || valueRank >= 0)
            {
                return "p";
            }

            string type = qname.Name;

            DataType datatype = Validator.ResolveType(qname);

            if (datatype != null)
            {
                if (datatype is EnumeratedType)
                {
                    return "e";
                }

                if (datatype is ComplexType)
                {
                    return "p";
                }

                qname = datatype.QName;
            }

            if (qname.Namespace == Namespaces.OpcUaBuiltInTypes)
            {
                switch (qname.Name)
                {
                    case "Boolean":
                    {
                        return "b";
                    }

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
                    {
                        return "n";
                    }
                }
            }

            return "p";
        }
        #endregion

        #region Private Fields
        private bool m_exportAll;
        private string m_namespaceConstant;
        #endregion
    }
}
