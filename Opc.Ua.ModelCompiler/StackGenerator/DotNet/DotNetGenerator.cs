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
    public class DotNetGenerator : CodeGenerator
    {
        #region Constructors
        /// <summary>
        /// Generates the code from the contents of the address space.
        /// </summary>
        public DotNetGenerator(
            string                    inputPath,
            string                    outputDirectory,
            Dictionary<string,string> knownFiles,
            string                    resourcePath)
        :
            base(inputPath, outputDirectory, knownFiles, resourcePath)
        {
            TargetLanguage = Language.DotNet;
        }
        #endregion

        #region Public Properties
        const string TemplatePath = "ModelCompiler.StackGenerator.DotNet.Templates.";
        #endregion

        #region Public Methods
        /// <summary>
        /// Generates the datatype files.
        /// </summary>
        public virtual void Generate(string namespacePrefix, string dictionaryName, bool exportAll)
        {
            DictionaryName = dictionaryName;

            m_namespaceConstant = "OpcUa";
            m_schemaNamespaceConstant = "OpcUaXsd";
            m_wsdlNamespaceConstant = "OpcUaWsdl";

            m_exportAll = exportAll;

            WriteTemplate_Messages(namespacePrefix, dictionaryName);
            WriteTemplate_Interfaces(namespacePrefix, dictionaryName);
            WriteTemplate_Channels(namespacePrefix, dictionaryName);
            WriteTemplate_ClientApi(namespacePrefix, dictionaryName);
            WriteTemplate_ServerApi(namespacePrefix, dictionaryName);
            WriteTemplate_Endpoints(namespacePrefix, dictionaryName);
        }
        #endregion

        #region WriteTemplate Methods
        /// <summary>
        /// Writes the classes and interaces that implement a UA endpoint.
        /// </summary>
        private void WriteTemplate_Endpoints(string namespacePrefix, string dictionaryName)
        {
            List<ServiceSet> serviceSets = new List<ServiceSet>();

            serviceSets.Add(new ServiceSet("Session", InterfaceType.Discovery, InterfaceType.Session, InterfaceType.Test));
            serviceSets.Add(new ServiceSet("Discovery", InterfaceType.Discovery, InterfaceType.Registration));

            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}.Endpoints.cs", OutputDirectory, namespacePrefix), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "Endpoints.File.cs", Assembly.GetExecutingAssembly());

                template.AddReplacement("_Date_", DateTime.Now);
                template.AddReplacement("_Prefix_", namespacePrefix);
                template.AddReplacement("_Namespace_", m_namespaceConstant);

                AddTemplate(
                    template,
                    "// _SERVICESETS_",
                    TemplatePath + "Endpoints.ServiceSet.cs",
                    serviceSets,
                    null,
                    new WriteTemplateEventHandler(WriteTemplate_EndpointServiceSet));

                template.WriteTemplate(null);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Copies the response paramaters into the request object.
        /// </summary>
        private bool WriteTemplate_EndpointServiceSet(Template template, Context context)
        {
            ServiceSet serviceSet = context.Target as ServiceSet;

            if (serviceSet == null)
            {
                return false;
            }

            // get datatypes.
            IList<ServiceType> datatypes = GetListOfServices(serviceSet.Interfaces);

            if (datatypes.Count == 0)
            {
                return false;
            }

            template.AddReplacement("_ServiceSet_", serviceSet.Name);
            template.AddReplacement("_ServicesNamespace_", m_wsdlNamespaceConstant);

            if (serviceSet.Name == "Session")
            {
                template.AddReplacement("_IEndpoints_", "ISessionEndpoint, IDiscoveryEndpoint");
            }

            if (serviceSet.Name == "Discovery")
            {
                template.AddReplacement("_IEndpoints_", "IDiscoveryEndpoint, IRegistrationEndpoint");
            }

            AddTemplate(
                template,
                "// _MethodList_",
                TemplatePath + "Endpoints.Method.cs",
                datatypes,
                null,
                new WriteTemplateEventHandler(WriteTemplate_EndpointMethod));

            AddTemplate(
                template,
                "// AddKnownType",
                null,
                datatypes,
                new LoadTemplateEventHandler(LoadTemplate_KnownType),
                null);

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Copies the response paramaters into the request object.
        /// </summary>
        private bool WriteTemplate_EndpointMethod(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return false;
            }

            template.AddReplacement("_NAME_", serviceType.Name);

            AddTemplate(
                template,
                "// DeclareResponseParameters",
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_InitializeResponseParameters),
                null);

            AddTemplate(
                template,
                "InvokeService();",
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_InvokeServiceSyncParameters),
                null);

            AddTemplate(
                template,
                "// SetResponseParameters",
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_ResponseParameters),
                null);

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Writes a synchronous method declaration.
        /// </summary>
        private string LoadTemplate_InvokeServiceSyncParameters(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return null;
            }

            // write method declaration.
            template.WriteLine(String.Empty);
            template.Write(context.Prefix);
            template.Write("response.{0} = ServerInstance.{1}(", serviceType.Response[0].Name, serviceType.Name);

            if (serviceType.Request != null || serviceType.Request.Length > 0)
            {
                bool first = true;

                foreach (FieldType field in serviceType.Request)
                {
                    if (first)
                    {
                        first = false;
                        template.WriteLine(String.Empty);
                    }
                    else
                    {
                        template.WriteLine(",");
                    }

                    template.Write(context.Prefix);
                    template.Write("   request.{0}", field.Name);
                }
            }

            if (serviceType.Response != null || serviceType.Response.Length > 0)
            {
                bool first = true;

                foreach (FieldType field in serviceType.Response)
                {
                    if (first)
                    {
                        first = false;
                        continue;
                    }

                    template.WriteLine(",");
                    template.Write(context.Prefix);
                    template.Write("   out {0}", ToLowerCamelCase(field.Name));
                }
            }

            template.WriteLine(");");

            return null;
        }

        /// <summary>
        /// Writes a synchronous method declaration.
        /// </summary>
        private string LoadTemplate_KnownType(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return null;
            }

            // write method declaration.
            template.WriteLine(String.Empty);
            template.Write(context.Prefix);
            template.Write("#if (!OPCUA_EXCLUDE_{0})", serviceType.Name);

            template.WriteLine(String.Empty);
            template.Write(context.Prefix);
            template.Write("SupportedServices.Add(DataTypeIds.{0}Request, new ServiceDefinition(typeof({0}Request), new InvokeServiceEventHandler({0})));", serviceType.Name);

            template.WriteLine(String.Empty);
            template.Write(context.Prefix);
            template.Write("#endif");

            return null;
        }

        /// <summary>
        /// Writes the classes and interaces that implement a UA server.
        /// </summary>
        private void WriteTemplate_ServerApi(string namespacePrefix, string dictionaryName)
        {
            List<ServiceSet> serviceSets = new List<ServiceSet>();

            serviceSets.Add(new ServiceSet("Session", InterfaceType.Discovery, InterfaceType.Session, InterfaceType.Test));
            serviceSets.Add(new ServiceSet("Discovery", InterfaceType.Discovery, InterfaceType.Registration));

            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}.ServerBase.cs", OutputDirectory, namespacePrefix), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "ServerApi.File.cs", Assembly.GetExecutingAssembly());

                template.AddReplacement("_Date_", DateTime.Now);
                template.AddReplacement("_Prefix_", namespacePrefix);
                template.AddReplacement("_Namespace_", m_namespaceConstant);

                AddTemplate(
                    template,
                    "// _SERVICESETS_",
                    TemplatePath + "ServerApi.ServiceSet.cs",
                    serviceSets,
                    null,
                    new WriteTemplateEventHandler(WriteTemplate_ServerApiServiceSet));

                template.WriteTemplate(null);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Copies the response paramaters into the request object.
        /// </summary>
        private bool WriteTemplate_ServerApiServiceSet(Template template, Context context)
        {
            ServiceSet serviceSet = context.Target as ServiceSet;

            if (serviceSet == null)
            {
                return false;
            }

            IList<ServiceType> datatypes = GetListOfServices(serviceSet.Interfaces);

            if (datatypes.Count == 0)
            {
                return false;
            }

            template.AddReplacement("_ServiceSet_", serviceSet.Name);

            AddTemplate(
                template,
                "// _ServerApi_",
                TemplatePath + "ServerApi.InterfaceMethod.cs",
                datatypes,
                null,
                new WriteTemplateEventHandler(WriteTemplate_InterfaceSyncMethod));

            AddTemplate(
                template,
                "// _ServerAsyncApi_",
                TemplatePath + "ServerApi.InterfaceMethod.cs",
                datatypes,
                null,
                new WriteTemplateEventHandler(WriteTemplate_InterfaceAsyncMethod));

            AddTemplate(
                template,
                "// _ServerStubs_",
                TemplatePath + "ServerApi.Method.cs",
                datatypes,
                null,
                new WriteTemplateEventHandler(WriteTemplate_StubMethod));

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Copies the response paramaters into the request object.
        /// </summary>
        private bool WriteTemplate_InterfaceSyncMethod(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return false;
            }

            template.AddReplacement("_NAME_", serviceType.Name);

            AddTemplate(
                template,
                "void Interface();",
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_SyncParameters),
                null);

            bool result = template.WriteTemplate(context);

            return result;
        }

        /// <summary>
        /// Copies the response paramaters into the request object.
        /// </summary>
        private bool WriteTemplate_InterfaceAsyncMethod(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return false;
            }

            template.AddReplacement("_NAME_", serviceType.Name);

            AddTemplate(
                template,
                "void Interface();",
                null,
                new ServiceType[] { serviceType },
                new LoadTemplateEventHandler(LoadTemplate_AsyncParameters),
                null);

            bool result = template.WriteTemplate(context);

            return result;
        }

        /// <summary>
        /// Writes a service.
        /// </summary>
        private bool WriteTemplate_StubMethod(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return false;
            }

            template.AddReplacement("_NAME_", serviceType.Name);
            template.AddReplacement("_Namespace_", m_namespaceConstant);

            AddTemplate(
                template,
                "void Stub()",
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_SyncParameters),
                null);

            AddTemplate(
                template,
                "// ResponseParameters",
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_InitializeResponseParameters),
                null);

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Copies the response paramaters into the request object.
        /// </summary>
        private string LoadTemplate_InitializeResponseParameters(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return null;
            }

            // calculate maximum parameter length.
            if (serviceType.Response != null)
            {
                bool first = true;

                foreach (FieldType field in serviceType.Response)
                {
                    if (first)
                    {
                        first = false;
                        continue;
                    }

                    template.WriteLine(String.Empty);
                    template.Write(context.Prefix);

                    if (context.Token.IndexOf("Declare") != -1)
                    {
                        template.Write("{1} {0} = ", ToLowerCamelCase(field.Name), GetDotNetTypeName(field.DataType, field.ValueRank));
                    }
                    else
                    {
                        template.Write("{0} = ", ToLowerCamelCase(field.Name));
                    }

                    if (IsDotNetReferenceType(field))
                    {
                        template.Write("null;");
                    }
                    else
                    {
                        template.Write("{0};", GetDotNetDefaultValue(field));
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Writes the class that define the service types.
        /// </summary>
        private void WriteTemplate_ClientApi(string namespacePrefix, string dictionaryName)
        {
            IList<ServiceSet> serviceSets = GetServiceSets();

            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}.Client.cs", OutputDirectory, namespacePrefix), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "ClientApi.File.cs", Assembly.GetExecutingAssembly());

                template.AddReplacement("_Date_", DateTime.Now);
                template.AddReplacement("_Prefix_", namespacePrefix);
                template.AddReplacement("_Namespace_", m_namespaceConstant);

                AddTemplate(
                    template,
                    "// _SERVICESETS_",
                    TemplatePath + "ClientApi.ServiceSet.cs",
                    serviceSets,
                    null,
                    new WriteTemplateEventHandler(WriteTemplate_ClientApiServiceSet));

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
        private bool WriteTemplate_ClientApiServiceSet(Template template, Context context)
        {
            ServiceSet serviceSet = context.Target as ServiceSet;

            if (serviceSet == null)
            {
                return false;
            }

            // get datatypes.
            IList<ServiceType> datatypes = GetListOfServices(serviceSet.Interfaces);

            if (datatypes.Count == 0)
            {
                return false;
            }

            template.AddReplacement("_ServiceSet_", serviceSet.Name);

            AddTemplate(
                template,
                "// _ClientApi_",
                TemplatePath + "ClientApi.Method.cs",
                datatypes,
                null,
                new WriteTemplateEventHandler(WriteTemplate_Method));

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Writes a service.
        /// </summary>
        private bool WriteTemplate_Method(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return false;
            }

            template.AddReplacement("_NAME_", serviceType.Name);
            template.AddReplacement("_Namespace_", m_namespaceConstant);

            AddTemplate(
                template,
                "void SyncCall()",
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_SyncParameters),
                null);

            AddTemplate(
                template,
                "void AsyncCall()",
                null,
                new ServiceType[] { serviceType },
                new LoadTemplateEventHandler(LoadTemplate_AsyncParameters),
                null);

            AddTemplate(
                template,
                "void BeginAsyncCall()",
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_BeginAsyncParameters),
                null);

            AddTemplate(
                template,
                "void EndAsyncCall()",
                null,
                new ServiceType[] { serviceType } ,
                new LoadTemplateEventHandler(LoadTemplate_EndAsyncParameters),
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

            return template.WriteTemplate(context);
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

            int length = 0;

            List<string> types = new List<string>();
            List<string> names = new List<string>();

            CollectParameters(serviceType.Request, false, types, names, ref length);
            CollectParameters(serviceType.Response, true, types, names, ref length);

            // write method declaration.
            template.WriteLine(String.Empty);
            template.Write(context.Prefix);

            // write method type if not writing an interface declaration.
            if (context.Token.IndexOf("Interface") == -1)
            {
                template.Write("public virtual ");
            }

            template.Write("{0} {1}(", GetReturnType(serviceType), serviceType.Name);

            WriteParameters(template, context, types, names, length);

            // write closing semicolon for interface.
            if (context.Token.IndexOf("Interface") != -1)
            {
                template.Write(";");
            }

            return null;
        }

        /// <summary>
        /// Writes an asynchronous method declaration.
        /// </summary>
        private string LoadTemplate_AsyncParameters(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return null;
            }

            int length = 0;

            List<string> types = new List<string>();
            List<string> names = new List<string>();

            CollectParameters(serviceType.Request, false, types, names, ref length);

            string tokenType = "CancellationToken";
            if (tokenType.Length > length)
            {
                length = tokenType.Length;
            }
            types.Add(tokenType);
            names.Add("ct");

            // write method declaration.
            template.WriteLine(String.Empty);
            template.Write(context.Prefix);

            // write method type if not writing an interface declaration.
            if (context.Token.IndexOf("Interface") == -1)
            {
                template.Write("public virtual async ");
            }

            template.Write("Task<{0}Response> {1}Async(", serviceType.Name, serviceType.Name);

            WriteParameters(template, context, types, names, length);

            // write closing semicolon for interface.
            if (context.Token.IndexOf("Interface") != -1)
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

            int length = 0;

            List<string> types = new List<string>();
            List<string> names = new List<string>();

            CollectParameters(serviceType.Request, false, types, names, ref length);

            types.Add("AsyncCallback");
            names.Add("callback");

            types.Add("object");
            names.Add("asyncState");

            // write method declaration.
            template.WriteLine(String.Empty);
            template.Write(context.Prefix);
            template.Write("public IAsyncResult Begin{0}(", serviceType.Name);

            WriteParameters(template, context, types, names, length);

            return null;
        }

        /// <summary>
        /// Writes an end asynchronous method declaration.
        /// </summary>
        private string LoadTemplate_EndAsyncParameters(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return null;
            }

            int length = 0;

            List<string> types = new List<string>();
            List<string> names = new List<string>();

            types.Add("IAsyncResult");
            names.Add("result");

            CollectParameters(serviceType.Response, true, types, names, ref length);

            // write method declaration.
            template.WriteLine(String.Empty);
            template.Write(context.Prefix);
            template.Write("public {0} End{1}(", GetReturnType(serviceType), serviceType.Name);

            WriteParameters(template, context, types, names, length);

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

            // calculate maximum parameter length.
            if (serviceType.Request != null)
            {
                int length = 0;

                foreach (FieldType field in serviceType.Request)
                {
                    string fieldName = field.Name;

                    if (fieldName.Length > length)
                    {
                        length = fieldName.Length;
                    }
                }

                foreach (FieldType field in serviceType.Request)
                {
                    string padding = null;

                    if (field.Name.Length < length)
                    {
                        padding = new string(' ', length-field.Name.Length);
                    }

                    template.WriteLine(String.Empty);
                    template.Write(context.Prefix);
                    template.Write("request.{0}{1} = {2};", field.Name, padding, ToLowerCamelCase(field.Name));
                }
            }

            return null;
        }

        /// <summary>
        /// Copies the response paramaters into the request object.
        /// </summary>
        private string LoadTemplate_ResponseParameters(Template template, Context context)
        {
            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return null;
            }

            // calculate maximum parameter length.
            if (serviceType.Response != null)
            {
                int length = 0;
                bool first = true;

                foreach (FieldType field in serviceType.Response)
                {
                    if (first)
                    {
                        first = false;
                        continue;
                    }

                    string fieldName = field.Name;

                    if (fieldName.Length > length)
                    {
                        length = fieldName.Length;
                    }
                }

                first = true;

                foreach (FieldType field in serviceType.Response)
                {
                    if (first)
                    {
                        first = false;
                        continue;
                    }

                    string padding = null;

                    if (field.Name.Length < length)
                    {
                        padding = new string(' ', length-field.Name.Length);
                    }

                    template.WriteLine(String.Empty);
                    template.Write(context.Prefix);

                    if (context.Token.IndexOf("Set") != -1)
                    {
                        template.Write("response.{2}{1} = {0};", ToLowerCamelCase(field.Name), padding, field.Name);
                    }
                    else
                    {
                        template.Write("{0}{1} = response.{2};", ToLowerCamelCase(field.Name), padding, field.Name);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns a list of services filter by their interface type.
        /// </summary>
        private IList<ServiceType> GetListOfServices(params InterfaceType[] interfaceTypes)
        {
            List<DataType> datatypes = GetDataTypeList(typeof(ServiceType), m_exportAll, true);

            List<ServiceType> services = new List<ServiceType>();

            for (int ii = 0; ii < datatypes.Count; ii++)
            {
                ServiceType serviceType = datatypes[ii] as ServiceType;

                if (serviceType != null && interfaceTypes != null)
                {
                    foreach (InterfaceType interfaceType in interfaceTypes)
                    {
                        if (interfaceType == serviceType.InterfaceType)
                        {
                            services.Add(serviceType);
                            break;
                        }
                    }
                }
            }

            return services;
        }

        /// <summary>
        /// A set of services that are grouped into a single interface.
        /// </summary>
        private class ServiceSet
        {
            public ServiceSet(string serviceSet, params InterfaceType[] interfaces)
            {
                Name = serviceSet;
                Interfaces = interfaces;
            }

            public string Name;
            public InterfaceType[] Interfaces;
        }

        /// <summary>
        /// Returns the service sets available.
        /// </summary>
        private IList<ServiceSet> GetServiceSets()
        {
            List<ServiceSet> serviceSets = new List<ServiceSet>();

            serviceSets.Add(new ServiceSet("Session", InterfaceType.Session, InterfaceType.Test));
            serviceSets.Add(new ServiceSet("Discovery", InterfaceType.Discovery));
            serviceSets.Add(new ServiceSet("Registration", InterfaceType.Registration));

            return serviceSets;
        }

        /// <summary>
        /// Writes the interfaces that define the service types.
        /// </summary>
        private void WriteTemplate_Interfaces(string namespacePrefix, string dictionaryName)
        {
            IList<ServiceSet> serviceSets = GetServiceSets();

            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}.Interfaces.cs", OutputDirectory, namespacePrefix), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "Interfaces.File.cs", Assembly.GetExecutingAssembly());

                template.AddReplacement("_Prefix_", namespacePrefix);

                AddTemplate(
                    template,
                    "// _SERVICESETS_",
                    TemplatePath + "Interfaces.ServiceSet.cs",
                    serviceSets,
                    null,
                    new WriteTemplateEventHandler(WriteTemplate_Interface));

                template.WriteTemplate(null);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Writes the interfaces that define the service types.
        /// </summary>
        private bool WriteTemplate_Interface(Template template, Context context)
        {
            ServiceSet serviceSet = context.Target as ServiceSet;

            if (serviceSet == null)
            {
                return false;
            }

            IList<ServiceType> datatypes = GetListOfServices(serviceSet.Interfaces);

            if (datatypes.Count == 0)
            {
                return false;
            }

            template.AddReplacement("_Namespace_", m_namespaceConstant);
            template.AddReplacement("_ServicesNamespace_", m_wsdlNamespaceConstant);
            template.AddReplacement("_ServiceSet_", serviceSet.Name);

            AddTemplate(
                template,
                "// _OPERATIONLIST_",
                TemplatePath + "Interfaces.Operation.cs",
                datatypes,
                null,
                new WriteTemplateEventHandler(WriteTemplate_Service));

            AddTemplate(
                template,
                "// _ASYNCENDPOINTOPERATIONLIST_",
                TemplatePath + "Interfaces.OperationAsyncEndpoint.cs",
                datatypes,
                null,
                new WriteTemplateEventHandler(WriteTemplate_Service));

            AddTemplate(
                template,
                "// _ASYNCOPERATIONLIST_",
                TemplatePath + "Interfaces.OperationAsync.cs",
                datatypes,
                null,
                new WriteTemplateEventHandler(WriteTemplate_Service));

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Writes the class that define the service types.
        /// </summary>
        private void WriteTemplate_Channels(string namespacePrefix, string dictionaryName)
        {
            IList<ServiceSet> serviceSets = GetServiceSets();

            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}.Channels.cs", OutputDirectory, namespacePrefix), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "Channels.File.cs", Assembly.GetExecutingAssembly());

                template.AddReplacement("_Date_", DateTime.Now);
                template.AddReplacement("_Prefix_", namespacePrefix);
                template.AddReplacement("_Namespace_", m_namespaceConstant);

                AddTemplate(
                    template,
                    "// _SERVICESETS_",
                    TemplatePath + "Channels.ServiceSet.cs",
                    serviceSets,
                    null,
                    new WriteTemplateEventHandler(WriteTemplate_ChannelsServiceSet));

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
        private bool WriteTemplate_ChannelsServiceSet(Template template, Context context)
        {
            ServiceSet serviceSet = context.Target as ServiceSet;

            if (serviceSet == null)
            {
                return false;
            }

            // get datatypes.
            IList<ServiceType> datatypes = GetListOfServices(serviceSet.Interfaces);

            if (datatypes.Count == 0)
            {
                return false;
            }

            template.AddReplacement("_ServiceSet_", serviceSet.Name);

            AddTemplate(
                template,
                "// _XmlChannelMethodList_",
                TemplatePath + "Channels.XmlMethod.cs",
                datatypes,
                null,
                new WriteTemplateEventHandler(WriteTemplate_Service));

            AddTemplate(
                template,
                "// _BinaryChannelMethodList_",
                TemplatePath + "Channels.BinaryMethod.cs",
                datatypes,
                null,
                new WriteTemplateEventHandler(WriteTemplate_Service));

            AddTemplate(
                template,
                "// _XmlChannelAsyncMethodList_",
                TemplatePath + "Channels.XmlMethodAsync.cs",
                datatypes,
                null,
                new WriteTemplateEventHandler(WriteTemplate_Service));

            AddTemplate(
                template,
                "// _BinaryChannelAsyncMethodList_",
                TemplatePath + "Channels.BinaryMethodAsync.cs",
                datatypes,
                null,
                new WriteTemplateEventHandler(WriteTemplate_Service));

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Writes a service.
        /// </summary>
        private bool WriteTemplate_Service(Template template, Context context)
        {
            ServiceSet serviceSet = context.Container as ServiceSet;

            if (serviceSet != null)
            {
                template.AddReplacement("_ServiceSet_", serviceSet.Name);
            }

            ServiceType serviceType = context.Target as ServiceType;

            if (serviceType == null)
            {
                return false;
            }

            template.AddReplacement("_NAME_", serviceType.Name);
            template.AddReplacement("_Namespace_", m_namespaceConstant);
            template.AddReplacement("_ServicesNamespace_", m_wsdlNamespaceConstant);
            template.AddReplacement("_TypesNamespace_", m_schemaNamespaceConstant);

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Writes classes that implement the data types.
        /// </summary>
        private void WriteTemplate_Messages(string namespacePrefix, string dictionaryName)
        {
            // get datatypes.
            List<DataType> datatypes = GetDataTypeList(typeof(ServiceType), m_exportAll, false);

            if (datatypes.Count == 0)
            {
                return;
            }

            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}.Messages.cs", OutputDirectory, namespacePrefix), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "Classes.File.cs", Assembly.GetExecutingAssembly());

                template.AddReplacement("_Date_", DateTime.Now);
                template.AddReplacement("_Prefix_", namespacePrefix);

                AddTemplate(
                    template,
                    "// _TypeList_",
                    null,
                    datatypes,
                    new LoadTemplateEventHandler(LoadTemplate_Class),
                    new WriteTemplateEventHandler(WriteTemplate_Class));

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
        private string LoadTemplate_Class(Template template, Context context)
        {
            // do not publish type declarations as classes.
            if (typeof(TypeDeclaration).IsInstanceOfType(context.Target))
            {
                return null;
            }

            if (typeof(ComplexType).IsInstanceOfType(context.Target))
            {
                return TemplatePath + "Classes.Class.cs";
            }

            if (typeof(EnumeratedType).IsInstanceOfType(context.Target))
            {
                return TemplatePath + "Classes.Enumeration.cs";
            }

            if (typeof(ServiceType).IsInstanceOfType(context.Target))
            {
                return TemplatePath + "Classes.Service.cs";
            }

            // do not publish unrecognized sub-types.
            return null;
        }

        /// <summary>
        /// Writes a class.
        /// </summary>
        private bool WriteTemplate_Class(Template template, Context context)
        {
            DataType datatype = context.Target as DataType;

            if (datatype == null)
            {
                return false;
            }

            template.AddReplacement("_NAME_", datatype.Name);
            template.AddReplacement("_Namespace_", m_namespaceConstant);
            template.AddReplacement("_TypesNamespace_", m_schemaNamespaceConstant);
            template.AddReplacement("// _XMLTYPE_", String.Format("[DataContract(Namespace = Namespaces.{0})]", m_schemaNamespaceConstant));

            AddTemplate(
                template,
                "// _COLLECTIONCLASS_",
                TemplatePath + "Classes.ClassCollection.cs",
                new DataType[] { datatype },
                null,
                new WriteTemplateEventHandler(WriteTemplate_Collection));

            AddTemplate(
                template,
                "// _ENUMCOLLECTIONCLASS_",
                TemplatePath + "Classes.EnumerationCollection.cs",
                new DataType[] { datatype },
                null,
                new WriteTemplateEventHandler(WriteTemplate_Collection));

            ComplexType complexType = datatype as ComplexType;

            if (complexType != null)
            {
                string baseTypeName = null;

                if (!IsNull(complexType.BaseType))
                {
                    ComplexType baseType = Validator.ResolveType(complexType.BaseType) as ComplexType;

                    if (baseType != null)
                    {
                        baseTypeName = baseType.Name;
                    }
                }
                else
                {
                    baseTypeName = "IEncodeable";
                }

                if (context.Token == "// _RequestMessage_")
                {
                    baseTypeName += ", IServiceRequest";
                }

                if (context.Token == "// _ResponseMessage_")
                {
                    baseTypeName += ", IServiceResponse";
                }

                template.AddReplacement("_BASETYPE_", baseTypeName);

                AddTemplate(
                    template,
                    "// _DEFAULTLIST_",
                    null,
                    complexType.Field,
                    new LoadTemplateEventHandler(LoadTemplate_DefaultValue),
                    null);

                AddTemplate(
                    template,
                    "// _PROPERTYLIST_",
                    TemplatePath + "Classes.Property.cs",
                    complexType.Field,
                    new LoadTemplateEventHandler(LoadTemplate_Property),
                    new WriteTemplateEventHandler(WriteTemplate_Property));

                AddTemplate(
                    template,
                    "// _MEMBERLIST_",
                    null,
                    complexType.Field,
                    new LoadTemplateEventHandler(LoadTemplate_Member),
                    null);

                AddTemplate(
                    template,
                    "// _ENCODELIST_",
                    null,
                    complexType.Field,
                    new LoadTemplateEventHandler(LoadTemplate_Encode),
                    null);

                AddTemplate(
                    template,
                    "// _DECODELIST_",
                    null,
                    complexType.Field,
                    new LoadTemplateEventHandler(LoadTemplate_Decode),
                    null);

                AddTemplate(
                    template,
                    "// _ISEQUALLIST_",
                    null,
                    complexType.Field,
                    new LoadTemplateEventHandler(LoadTemplate_IsEqual),
                    null);

                AddTemplate(
                    template,
                    "// _CLONELIST_",
                    null,
                    complexType.Field,
                    new LoadTemplateEventHandler(LoadTemplate_Clone),
                    null);

                AddTemplate(
                    template,
                    "// _FIELDNAMES_",
                    null,
                    complexType.Field,
                    new LoadTemplateEventHandler(LoadTemplate_FieldNames),
                    null);

                AddTemplate(
                    template,
                    "// _FIELDNAMESWITCH_",
                    null,
                    complexType.Field,
                    new LoadTemplateEventHandler(LoadTemplate_GetFieldNameSwitch),
                    null);
            }

            EnumeratedType enumeratedType = datatype as EnumeratedType;

            if (enumeratedType != null)
            {
                AddTemplate(
                    template,
                    "// _VALUELIST_",
                    TemplatePath + "Classes.EnumerationValue.cs",
                    enumeratedType.Value,
                    null,
                    new WriteTemplateEventHandler(WriteTemplate_EnumerationValue));
            }

            ServiceType serviceType = datatype as ServiceType;

            if (serviceType != null)
            {
                ComplexType requestType = new ComplexType();

                requestType.Name  = serviceType.Name + "Request";
                requestType.QName = new XmlQualifiedName(requestType.Name, serviceType.QName.Namespace);
                requestType.Field = serviceType.Request;

                AddTemplate(
                    template,
                    "// _RequestMessage_",
                    TemplatePath + "Classes.Class.cs",
                    new DataType[] { requestType },
                    null,
                    new WriteTemplateEventHandler(WriteTemplate_Class));

                ComplexType responseType = new ComplexType();

                responseType.Name  = serviceType.Name + "Response";
                responseType.QName = new XmlQualifiedName(responseType.Name, serviceType.QName.Namespace);
                responseType.Field = serviceType.Response;

                AddTemplate(
                    template,
                    "// _ResponseMessage_",
                    TemplatePath + "Classes.Class.cs",
                    new DataType[] { responseType },
                    null,
                    new WriteTemplateEventHandler(WriteTemplate_Class));
            }

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Writes the default value for a field.
        /// </summary>
        private string LoadTemplate_DefaultValue(Template template, Context context)
        {
            FieldType field = context.Target as FieldType;

            if (field == null)
            {
                return null;
            }

            template.WriteLine(String.Empty);
            template.Write(context.Prefix);
            template.Write("m_{0} = {1};", ToLowerCamelCase(field.Name), GetDotNetDefaultValue(field));

            return null;
        }

        /// <summary>
        /// Loads the template for a property.
        /// </summary>
        private string LoadTemplate_Property(Template template, Context context)
        {
            FieldType field = context.Target as FieldType;

            if (field == null)
            {
                return null;
            }

            if (field.ValueRank >= 0)
            {
                return TemplatePath + "Classes.PropertyArray.cs";
            }

            ComplexType datatype = Validator.ResolveType(field.DataType) as ComplexType;

            if (datatype != null)
            {
                return TemplatePath + "Classes.PropertyArray.cs";
            }

            return TemplatePath + "Classes.Property.cs";
        }

        /// <summary>
        /// Writes a property.
        /// </summary>
        private bool WriteTemplate_Property(Template template, Context context)
        {
            FieldType field = context.Target as FieldType;

            if (field == null)
            {
                return false;
            }

            template.AddReplacement("// _XMLTYPE_", String.Format("[DataMember(Name = \"{0}\", Order = {1}]", field.Name, context.Index + 1));
            template.AddReplacement("_INTERNALNAME_", ToLowerCamelCase(field.Name));
            template.AddReplacement("_EXTERNALNAME_", field.Name);
            template.AddReplacement("_TYPE_", GetDotNetTypeName(field.DataType, field.ValueRank));

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Writes an enumeration value.
        /// </summary>
        private bool WriteTemplate_EnumerationValue(Template template, Context context)
        {
            EnumeratedValue value = context.Target as EnumeratedValue;

            if (value == null)
            {
                return false;
            }

            EnumeratedType enumeratedType = context.Container as EnumeratedType;

            template.AddReplacement("// _XMLTYPE_", String.Format("[EnumMember(Value = \"{0}_{1}\")]", value.Name, value.Value));
            template.AddReplacement("_NAME_", value.Name);

            if (context.Index < enumeratedType.Value.Length - 1)
            {
                template.AddReplacement("_VALUE_", value.Value + ",");
            }
            else
            {
                template.AddReplacement("_VALUE_", value.Value);
            }

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Writes a collection class.
        /// </summary>
        private bool WriteTemplate_Collection(Template template, Context context)
        {
            DataType datatype = context.Target as DataType;

            if (datatype == null || !datatype.AllowArrays)
            {
                return false;
            }

            template.WriteLine(String.Empty);

            template.AddReplacement("_NAME_", datatype.Name);
            template.AddReplacement("// _XMLARRAYTYPE_", String.Format("[CollectionDataContract(Name = \"ListOf{0}\", Namespace = Namespaces.{1}, ItemName=\"{0}\")]", datatype.Name, m_schemaNamespaceConstant));

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Writes the class member for a field.
        /// </summary>
        private string LoadTemplate_FieldNames(Template template, Context context)
        {
            FieldType field = context.Target as FieldType;

            if (field == null)
            {
                return null;
            }

            template.WriteLine(String.Empty);
            template.Write(context.Prefix);
            template.Write("/// <remarks />;");
            template.WriteLine(String.Empty);
            template.Write(context.Prefix);
            template.Write("public const string {0} = \"{0}\";", field.Name);

            return null;
        }

        /// <summary>
        /// Writes the class member for a field.
        /// </summary>
        private string LoadTemplate_GetFieldNameSwitch(Template template, Context context)
        {
            FieldType field = context.Target as FieldType;

            if (field == null)
            {
                return null;
            }

            template.WriteLine(String.Empty);
            template.Write(context.Prefix);
            template.Write("case Names.{0}: return m_{1};", field.Name, ToLowerCamelCase(field.Name));

            return null;
        }


        /// <summary>
        /// Writes the class member for a field.
        /// </summary>
        private string LoadTemplate_Member(Template template, Context context)
        {
            FieldType field = context.Target as FieldType;

            if (field == null)
            {
                return null;
            }

            template.WriteLine(String.Empty);
            template.Write(context.Prefix);
            template.Write("private {1} m_{0};", ToLowerCamelCase(field.Name), GetDotNetTypeName(field.DataType, field.ValueRank));

            return null;
        }

        /// <summary>
        /// Writes the encode function for a field.
        /// </summary>
        private string LoadTemplate_Encode(Template template, Context context)
        {
            FieldType field = context.Target as FieldType;

            if (field == null)
            {
                return null;
            }

            template.WriteLine(String.Empty);
            template.Write(context.Prefix);

            DataType datatype = Validator.ResolveType(field.DataType);

            EnumeratedType enumeratedType = datatype as EnumeratedType;

            if (enumeratedType != null)
            {
                if (field.ValueRank >= 0)
                {
                    template.Write("encoder.WriteEnumeratedArray");
                    template.Write("(\"{0}\", ({1}[]){0}, typeof({1}));", field.Name, enumeratedType.Name);
                }
                else
                {
                    template.Write("encoder.WriteEnumerated");
                    template.Write("(\"{0}\", {0});", field.Name);
                }
            }
            else
            {
                if (datatype.QName.Namespace == Namespaces.OpcUaBuiltInTypes)
                {
                    if (field.ValueRank >= 0)
                    {
                        template.Write("encoder.Write{0}Array", datatype.Name);
                    }
                    else
                    {
                        template.Write("encoder.Write{0}", datatype.Name);
                    }

                    template.Write("(\"{0}\", {0});", field.Name);
                }
                else
                {
                    if (field.ValueRank >= 0)
                    {
                        template.Write("encoder.WriteEncodeableArray");
                        template.Write("(\"{0}\", ({1}[]){0}, typeof({1}));", field.Name, datatype.Name);
                    }
                    else
                    {
                        template.Write("encoder.WriteEncodeable");
                        template.Write("(\"{0}\", {0}, typeof({1}));", field.Name, datatype.Name);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Writes the decode function for a field.
        /// </summary>
        private string LoadTemplate_Decode(Template template, Context context)
        {
            FieldType field = context.Target as FieldType;

            if (field == null)
            {
                return null;
            }

            template.WriteLine(String.Empty);
            template.Write(context.Prefix);

            DataType datatype = Validator.ResolveType(field.DataType);

            EnumeratedType enumeratedType = datatype as EnumeratedType;

            if (enumeratedType != null)
            {
                if (field.ValueRank >= 0)
                {
                    template.Write("{0} = ({1}[])decoder.ReadEnumeratedArray", field.Name, enumeratedType.Name);
                    template.Write("(\"{0}\", typeof({1}));", field.Name, enumeratedType.Name);
                }
                else
                {
                    template.Write("{0} = ({1})decoder.ReadEnumerated", field.Name, enumeratedType.Name);
                    template.Write("(\"{0}\", typeof({1}));", field.Name, enumeratedType.Name);
                }
            }
            else
            {
                if (datatype.QName.Namespace == Namespaces.OpcUaBuiltInTypes)
                {
                    if (field.ValueRank >= 0)
                    {
                        template.Write("{0} = decoder.Read{1}Array(\"{0}\");", field.Name, datatype.Name);
                    }
                    else
                    {
                        template.Write("{0} = decoder.Read{1}(\"{0}\");", field.Name, datatype.Name);
                    }
                }
                else
                {
                    if (field.ValueRank >= 0)
                    {
                        template.Write("{0} = ({1}Collection)decoder.ReadEncodeableArray(\"{0}\", typeof({1}));", field.Name, datatype.Name);
                    }
                    else
                    {
                        template.Write("{0} = ({1})decoder.ReadEncodeable(\"{0}\", typeof({1}));", field.Name, datatype.Name);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Writes the IsEqual statement for a field.
        /// </summary>
        private string LoadTemplate_IsEqual(Template template, Context context)
        {
            FieldType field = context.Target as FieldType;

            if (field == null)
            {
                return null;
            }

            template.WriteLine(String.Empty);
            template.Write(context.Prefix);
            template.Write("if (!Utils.IsEqual(m_{0}, value.m_{0})) return false;", ToLowerCamelCase(field.Name));

            return null;
        }

        /// <summary>
        /// Writes the clone function for a field.
        /// </summary>
        private string LoadTemplate_Clone(Template template, Context context)
        {
            FieldType field = context.Target as FieldType;

            if (field == null)
            {
                return null;
            }

            template.WriteLine(String.Empty);
            template.Write(context.Prefix);
            template.Write("clone.m_{0} = ({1})Utils.Clone(this.m_{0});", ToLowerCamelCase(field.Name), GetDotNetTypeName(field.DataType, field.ValueRank));

            return null;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Collects the parameters to write.
        /// </summary>
        private void CollectParameters(FieldType[] fields, bool output, List<string> types, List<string> names, ref int length)
        {
            if (fields != null)
            {
                bool first = true;

                foreach (FieldType field in fields)
                {
                    // first parameter is the return parameter.
                    if (first && output)
                    {
                        first = false;
                        continue;
                    }

                    DataType datatype = Validator.ResolveType(field.DataType);

                    string typeName = GetDotNetTypeName(datatype.QName, field.ValueRank);

                    // prefix out parameters.
                    if (output)
                    {
                        typeName = "out " + typeName;
                    }

                    if (length < typeName.Length)
                    {
                        length = typeName.Length;
                    }

                    types.Add(typeName);
                    names.Add(ToLowerCamelCase(field.Name));
                }
            }
        }

        /// <summary>
        /// Writes a set of method parameters.
        /// </summary>
        private void WriteParameters(Template template, Context context, List<string> types, List<string> names, int length)
        {
            for (int ii = 0; ii < types.Count; ii++)
            {
                string typeName = types[ii];

                if (typeName.Length < length)
                {
                    typeName += new string(' ', length-typeName.Length);
                }

                template.WriteLine(String.Empty);
                template.Write(context.Prefix);
                template.Write("    {0} {1}", typeName, names[ii]);

                if (ii < types.Count - 1)
                {
                    template.Write(",");
                }
                else
                {
                    template.Write(")");
                }
            }
        }

        /// <summary>
        /// Gets the return type for the service.
        /// </summary>
        private string GetReturnType(ServiceType serviceType)
        {
            string returnType = "void";

            if (serviceType.Response != null && serviceType.Response.Length > 0)
            {
                DataType datatype = Validator.ResolveType(serviceType.Response[0].DataType);

                if (datatype != null)
                {
                    returnType = GetDotNetTypeName(datatype.QName, serviceType.Response[0].ValueRank);
                }
            }

            return returnType;
        }

        /// <summary>
        /// Returns checks if the field is a reference type.
        /// </summary>
        private bool IsDotNetReferenceType(FieldType fieldType)
        {
            DataType datatype = Validator.ResolveType(fieldType.DataType);

            if (datatype == null || String.IsNullOrEmpty(datatype.Name))
            {
                return false;
            }

            if (fieldType.ValueRank >= 0)
            {
                return true;
            }

            EnumeratedType enumeratedType = datatype as EnumeratedType;

            if (enumeratedType != null)
            {
                return false;
            }

            if (datatype.QName.Namespace != Namespaces.OpcUaBuiltInTypes)
            {
                return true;
            }

            switch (datatype.Name)
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
                case "StatusCode":
                case "Variant":
                {
                    return false;
                }

                default:
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Returns the default value for a field.
        /// </summary>
        private string GetDotNetDefaultValue(FieldType fieldType)
        {
            DataType datatype = Validator.ResolveType(fieldType.DataType);

            if (datatype == null || String.IsNullOrEmpty(datatype.Name))
            {
                return "null";
            }

            if (fieldType.ValueRank >= 0)
            {
                switch (datatype.Name)
                {
                    case "Guid":
                    {
                        return "new UuidCollection()";
                    }
                }

                return String.Format("new {0}Collection()", datatype.Name);
            }

            EnumeratedType enumeratedType = datatype as EnumeratedType;

            if (enumeratedType != null)
            {
                return String.Format("{0}.{1}", datatype.Name, enumeratedType.Value[0].Name);
            }

            if (datatype.QName.Namespace != Namespaces.OpcUaBuiltInTypes)
            {
                return String.Format("new {0}()", datatype.Name);
            }

            switch (datatype.Name)
            {
                case "Boolean":
                {
                    return "false";
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
                    return "0";
                }

                case "String":
                case "ByteString":
                case "ExtensionObject":
                case "XmlElement":
                {
                    return "null";
                }

                case "Guid":
                {
                    return "Opc.Ua.Uuid.Empty";
                }

                case "DateTime":
                {
                    return "DateTime.MinValue";
                }

                case "StatusCode":
                {
                    return "Opc.Ua.StatusCodes.Good";
                }

                case "NodeId":
                {
                    return "Opc.Ua.NodeId.Null";
                }

                case "ExpandedNodeId":
                {
                    return "Opc.Ua.ExpandedNodeId.Null";
                }

                case "LocalizedText":
                {
                    return "Opc.Ua.LocalizedText.Null";
                }

                case "QualifiedName":
                {
                    return "Opc.Ua.QualifiedName.Null";
                }

                default:
                {
                    return String.Format("new {0}()", datatype.Name);
                }
            }
        }
        #endregion

        #region Private Fields
        private bool m_exportAll;
        private string m_namespaceConstant;
        private string m_schemaNamespaceConstant;
        private string m_wsdlNamespaceConstant;
        #endregion
    }
}
