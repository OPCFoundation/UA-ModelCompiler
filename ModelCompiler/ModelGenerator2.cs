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
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using Opc.Ua.CodeGenerator;

namespace Opc.Ua.ModelCompiler
{
    public partial class ModelGenerator2 : Opc.Ua.CodeGenerator.CodeGenerator
    {
        #region Constructors
        /// <summary>
        /// Loads the model design from the specified file and validates it.
        /// </summary>
        public ModelGenerator2()
        {
        }
        #endregion

        #region Public Properties
        const string TemplatePath = "Opc.Ua.ModelCompiler.Templates.";
        const string DefaultNamespace = "http://opcfoundation.org/UA/";
        #endregion

        #region Private Fields
        private ModelCompilerValidator m_validator;
        private ModelDesign m_model;
        private bool m_useXmlInitializers;
        #endregion

        /// <summary>
        /// Whether the XML version of the initialization strings.
        /// </summary>
        public bool UseXmlInitializers
        {
            get { return m_useXmlInitializers; }
        }

        /// <summary>
        /// Generates the source code files.
        /// </summary>
        public virtual void ValidateAndUpdateIds(IList<string> designFilePaths, string identifierFilePath, uint startId)
        {
            m_validator = new ModelCompilerValidator(startId);
            m_validator.Validate2(designFilePaths, identifierFilePath, false);
            m_model = m_validator.Dictionary;
        }

        /// <summary>
        /// Generates a single file containing all of the classes.
        /// </summary>
        public virtual void GenerateInternalSingleFile(string filePath, bool useXmlInitializers)
        {
            m_useXmlInitializers = useXmlInitializers;

            // write type and object definitions.
            List<NodeDesign> nodes = GetNodeList();

            WriteTemplate_InternalSingleFile(filePath, nodes);
            WriteTemplate_XmlExport(filePath);
            WriteTemplate_XmlSchema(filePath, nodes);
            WriteTemplate_BinarySchema(filePath, nodes);
        }

        /// <summary>
        /// Generates a single file containing all of the classes.
        /// </summary>
        public virtual void GenerateMultipleFiles(string filePath, bool useXmlInitializers)
        {
            m_useXmlInitializers = useXmlInitializers;

            // write type and object definitions.
            List<NodeDesign> nodes = GetNodeList();

            WriteTemplate_ConstantsSingleFile(filePath, nodes);
            WriteTemplate_DataTypesSingleFile(filePath, nodes);
            WriteTemplate_NonDataTypesSingleFile(filePath, nodes);
            WriteTemplate_XmlSchema(filePath, nodes);
            WriteTemplate_BinarySchema(filePath, nodes);
            WriteTemplate_XmlExport(filePath);
        }

        /// <summary>
        /// Generates the ANSI C identifiers.
        /// </summary>
        public virtual void GenerateIdentifiersAndNamesForAnsiC(string filePath)
        {
            List<NodeDesign> nodes = GetNodeList();

            WriteTemplate_IdentifiersAnsiC(filePath, nodes);
            WriteTemplate_NamesAnsiC(filePath, nodes);
            WriteTemplate_ExclusionsAnsiC(filePath, nodes);
        }

        /// <summary>
        /// Writes the schema information to a static XML export file.
        /// </summary>
        private void WriteTemplate_XmlExport(string filePath)
        {
            SystemContext context = new SystemContext();
            context.NamespaceUris = m_model.NamespaceUris;

            // collect the nodes to write.
            NodeStateCollection collection = new NodeStateCollection();
            Dictionary<uint, NodeStateCollection> subsets = new Dictionary<uint, NodeStateCollection>();

            for (int ii = 0; ii < m_model.Items.Length; ii++)
            {
                DataTypeDesign design = m_model.Items[ii] as DataTypeDesign;

                if (design != null)
                {
                    if (design.NotInAddressSpace)
                    {
                        continue;
                    }
                }

                InstanceDesign design2 = m_model.Items[ii] as InstanceDesign;

                if (design2 != null)
                {
                    if (design2.NotInAddressSpace)
                    {
                        continue;
                    }
                }

                MethodDesign design3 = m_model.Items[ii] as MethodDesign;

                if (design3 != null)
                {
                    if (design3.NotInAddressSpace || design3.SymbolicName.Name.EndsWith("MethodType"))
                    {
                        continue;
                    }
                }

                NodeState state = m_model.Items[ii].State;

                if (state != null)
                {
                    collection.Add(state);

                    if (m_model.Items[ii].PartNo != 0)
                    {
                        NodeStateCollection subset = null;

                        if (!subsets.TryGetValue(m_model.Items[ii].PartNo, out subset))
                        {
                            subsets[m_model.Items[ii].PartNo] = subset = new NodeStateCollection();
                        }

                        subset.Add(state);
                    }

                    BaseVariableState variable = state as BaseVariableState;

                    if (variable != null && variable.TypeDefinitionId == Opc.Ua.VariableTypeIds.DataTypeDictionaryType)
                    {
                        List<IReference> references = new List<IReference>();
                        variable.GetReferences(context, references, Opc.Ua.ReferenceTypeIds.HasComponent, true);

                        string file = null;

                        if (references.Count > 0 && references[0].TargetId == Opc.Ua.ObjectIds.XmlSchema_TypeSystem)
                        {
                            file = String.Format(@"{0}\{1}.Types.xsd", filePath, m_model.TargetNamespaceInfo.Prefix);
                        }

                        if (references.Count > 0 && references[0].TargetId == Opc.Ua.ObjectIds.OPCBinarySchema_TypeSystem)
                        {
                            file = String.Format(@"{0}\{1}.Types.bsd", filePath, m_model.TargetNamespaceInfo.Prefix);
                        }

                        if (file != null)
                        {
                            try
                            {
                                variable.Value = File.ReadAllBytes(file);
                            }
                            catch
                            {
                                variable.Value = null;
                            }
                        }
                    }
                }
            }

            // save the subsets.
            foreach (KeyValuePair<uint,NodeStateCollection> entry in subsets)
            {
                string file = String.Format(@"{0}\{1}.NodeSet2.Part{2}.xml", filePath, m_model.TargetNamespaceInfo.Prefix, entry.Key);

                using (Stream ostrm = File.Open(file, FileMode.Create))
                {
                    entry.Value.SaveAsNodeSet2(
                        context, 
                        ostrm, 
                        new Export.ModelTableEntry() 
                        { 
                            ModelUri = Namespaces.OpcUa,
                            Version = "1.02",
                            PublicationDate = m_model.TargetPublicationDate,
                            PublicationDateSpecified = m_model.TargetPublicationDateSpecified
                        },
                        (m_model.TargetPublicationDate != DateTime.UtcNow)? m_model.TargetPublicationDate:DateTime.MinValue);
                }
            }

            // open the output file.
            string outputFile = String.Format(@"{0}\{1}.PredefinedNodes.xml", filePath, m_model.TargetNamespaceInfo.Prefix);

            // save the xml.
            using (Stream ostrm = File.Open(outputFile, FileMode.Create))
            {
                collection.SaveAsXml(context, ostrm);
            }

            // load from xml.
            NodeStateCollection collection2 = new NodeStateCollection();

            using (Stream istrm = File.Open(outputFile, FileMode.Open))
            {
                collection2.LoadFromXml(context, istrm, true);
            }

            // save as nodeset.
            string outputFile2 = String.Format(@"{0}\{1}.NodeSet.xml", filePath, m_model.TargetNamespaceInfo.Prefix);

            using (Stream ostrm = File.Open(outputFile2, FileMode.Create))
            {
                collection.SaveAsNodeSet(context, ostrm);
            }

            // load as node set.
            using (Stream istrm = File.Open(outputFile2, FileMode.Open))
            {
                Opc.Ua.NodeSet nodeSet = Opc.Ua.NodeSet.Read(istrm);
            }

            // save as nodeset.
            string outputFile3 = String.Format(@"{0}\{1}.NodeSet2.xml", filePath, m_model.TargetNamespaceInfo.Prefix);

            using (Stream ostrm = File.Open(outputFile3, FileMode.Create))
            {
                var model = new Export.ModelTableEntry() 
                { 
                    ModelUri = m_model.TargetNamespace,
                    Version = m_model.TargetVersion,
                    PublicationDate = m_model.TargetPublicationDate,
                    PublicationDateSpecified = m_model.TargetPublicationDateSpecified,
                };

                if (m_model.Dependencies != null)
                {
                    model.RequiredModel = new List<Export.ModelTableEntry>(m_model.Dependencies.Values).ToArray();
                }

                collection.SaveAsNodeSet2(context, ostrm, model, (m_model.TargetPublicationDate != DateTime.MinValue)? m_model.TargetPublicationDate:DateTime.MinValue);
            }

            // load as node set.
            using (Stream istrm = File.Open(outputFile3, FileMode.Open))
            {
                Opc.Ua.Export.UANodeSet nodeSet = Opc.Ua.Export.UANodeSet.Read(istrm);
                collection2 = new NodeStateCollection();
                nodeSet.Import(context, collection2);
            }

            // open the output file.
            string outputFile4 = String.Format(@"{0}\{1}.PredefinedNodes.uanodes", filePath, m_model.TargetNamespaceInfo.Prefix);

            // save the xml.
            using (Stream ostrm = File.Open(outputFile4, FileMode.Create))
            {
                collection.SaveAsBinary(context, ostrm);
            }
        }

        /// <summary>
        /// Creates a class that defines all types in the namespace.
        /// </summary>
        private void WriteTemplate_IdentifiersAnsiC(string filePath, List<NodeDesign> nodes)
        {
            string prefix = m_model.TargetNamespaceInfo.Name;

            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}_identifiers.h", filePath, prefix.ToLower()), false);

            try
            {
                string templateName = "Types.Identifiers.h";

                Template template = new Template(writer, TemplatePath + templateName, Assembly.GetExecutingAssembly());

                SortedDictionary<string,List<NodeDesign>> identifiers = GetIdentifiers(nodes);

                template.AddReplacement("_Date_", DateTime.Now.ToShortDateString());
                template.AddReplacement("_FileName_", String.Format("{0}_Identifiers", prefix));

                AddTemplate(
                    template,
                    "// ListOfIdentifiers",
                    null,
                    identifiers,
                    new LoadTemplateEventHandler(LoadTemplate_TypeIdAnsiC),
                    null);

                Context context = new Context();
                context.BlankLine = true;
                template.WriteTemplate(context);
                template.WriteNextLine(String.Empty);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Creates a class that defines all types in the namespace.
        /// </summary>
        private void WriteTemplate_ExclusionsAnsiC(string filePath, List<NodeDesign> nodes)
        {
            string prefix = m_model.TargetNamespaceInfo.Name;

            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}_exclusions.h", filePath, prefix.ToLower()), false);

            try
            {
                string templateName = "Types.Identifiers.h";

                Template template = new Template(writer, TemplatePath + templateName, Assembly.GetExecutingAssembly());

                var identifiers = new Dictionary<string, List<string>>();

                List<string> serviceNames = new List<string>();
                List<string> datatypeNames = new List<string>();

                for (int ii = 0; ii < nodes.Count; ii++)
                {
                    if (ii < nodes.Count - 1 && nodes[ii].SymbolicName.Name.EndsWith("Request") && nodes[ii+1].SymbolicName.Name.EndsWith("Response"))
                    {
                        serviceNames.Add(nodes[ii].SymbolicName.Name.Replace("Request", ""));
                        continue;
                    }

                    if (ii > 0 && nodes[ii-1].SymbolicName.Name.EndsWith("Request") && nodes[ii].SymbolicName.Name.EndsWith("Response"))
                    {
                        continue;
                    }

                    var dt = nodes[ii] as DataTypeDesign;

                    if (dt != null && dt.BasicDataType == BasicDataType.UserDefined)
                    {
                        datatypeNames.Add(dt.SymbolicName.Name);
                    }
                }

                identifiers["Service"] = serviceNames;
                identifiers["DataType"] = datatypeNames;

                template.AddReplacement("_Date_", DateTime.Now.ToShortDateString());
                template.AddReplacement("_FileName_", String.Format("{0}_Exclusions", prefix));

                AddTemplate(
                    template,
                    "// ListOfIdentifiers",
                    null,
                    identifiers,
                    new LoadTemplateEventHandler(LoadTemplate_ExclusionsAnsiC),
                    null);

                Context context = new Context();
                context.BlankLine = true;
                template.WriteTemplate(context);
                template.WriteNextLine(String.Empty);
            }
            finally
            {
                writer.Close();
            }
        }

        #region ANSI C Identifier Generation
        /// <summary>
        /// Writes the code to define a exclusion macro for a type.
        /// </summary>
        private string LoadTemplate_ExclusionsAnsiC(Template template, Context context)
        {
            KeyValuePair<string, List<string>>? entry = context.Target as KeyValuePair<string, List<string>>?;

            if (entry == null)
            {
                return null;
            }

            template.WriteNextLine(context.Prefix);
            template.WriteNextLine(context.Prefix);
            template.Write("/*============================================================================");
            template.WriteNextLine(context.Prefix);
            template.Write("* {0} Exclusions", entry.Value.Key);
            template.WriteNextLine(context.Prefix);
            template.Write(" *===========================================================================*/");

            for (int ii = 0; ii < entry.Value.Value.Count; ii++)
            {
                template.WriteNextLine(context.Prefix);
                template.Write("/* #define OPCUA_EXCLUDE_{0} */", entry.Value.Value[ii]);
            }

            return null;
        }

        /// <summary>
        /// Writes the code to defined a identifier for a type.
        /// </summary>
        private string LoadTemplate_TypeIdAnsiC(Template template, Context context)
        {
            KeyValuePair<string,List<NodeDesign>>? entry = context.Target as KeyValuePair<string,List<NodeDesign>>?;

            if (entry == null)
            {
                return null;
            }

            template.WriteNextLine(context.Prefix);
            template.WriteNextLine(context.Prefix);
            template.Write("/*============================================================================");
            template.WriteNextLine(context.Prefix);
            template.Write("* {0} Identifiers", entry.Value.Key);
            template.WriteNextLine(context.Prefix);
            template.Write(" *===========================================================================*/", entry.Value.Key);

            for (int ii = 0; ii < entry.Value.Value.Count; ii++)
            {
                NodeDesign node = entry.Value.Value[ii];
                template.WriteNextLine(context.Prefix);
                template.Write("#define OpcUaId_{0}", node.SymbolicId.Name);
                template.Write(" {0}", node.NumericId);
            }

            return null;
        }

        /// <summary>
        /// Creates a class that defines all types in the namespace.
        /// </summary>
        private void WriteTemplate_NamesAnsiC(string filePath, List<NodeDesign> nodes)
        {
            string prefix = m_model.TargetNamespaceInfo.Name;

            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}_browsenames.h", filePath, prefix.ToLower()), false);

            try
            {
                string templateName = "Types.Identifiers.h";

                Template template = new Template(writer, TemplatePath + templateName, Assembly.GetExecutingAssembly());

                template.AddReplacement("_Date_", DateTime.Now.ToShortDateString());
                template.AddReplacement("_FileName_", String.Format("{0}_BrowseNames", prefix));

                SortedDictionary<string, string> browseNames = GetBrowseNames(nodes);

                AddTemplate(
                    template,
                    "// ListOfIdentifiers",
                    null,
                    browseNames,
                    new LoadTemplateEventHandler(LoadTemplate_NameAnsiC),
                    null);

                template.WriteTemplate(null);
                template.WriteNextLine(String.Empty);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Writes the code to defined a identifier for a type.
        /// </summary>
        private string LoadTemplate_NameAnsiC(Template template, Context context)
        {
            KeyValuePair<string, string>? browseName = context.Target as KeyValuePair<string, string>?;

            if (browseName == null)
            {
                return null;
            }

            template.WriteNextLine(context.Prefix);
            template.Write("#define OpcUa_BrowseName_{0}", browseName.Value.Key);
            template.Write(" \"{0}\"", browseName.Value.Value);

            return null;
        }
        #endregion

        #region XmlSchema Class Generation
        /// <summary>
        /// Creates a class that defines all types in the namespace.
        /// </summary>
        private void WriteTemplate_XmlSchema(string filePath, List<NodeDesign> nodes)
        {
            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}.Types.xsd", filePath, m_model.TargetNamespaceInfo.Prefix), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "XmlSchema.File.xml", Assembly.GetExecutingAssembly());

                if (!String.IsNullOrEmpty(m_model.TargetNamespaceInfo.XmlNamespace))
                {
                    template.AddReplacement("_Namespace_", m_model.TargetNamespaceInfo.XmlNamespace);
                }
                else
                {
                    template.AddReplacement("_Namespace_", m_model.TargetNamespaceInfo.Value);
                }

                AddTemplate(
                    template,
                    "xmlns:s0=\"ListOfNamespaces\"",
                    null,
                    m_model.Namespaces,
                    new LoadTemplateEventHandler(LoadTemplate_XmlNamespaceImports),
                    null);

                AddTemplate(
                    template,
                    "<!-- Imports -->",
                    null,
                    m_model.Namespaces,
                    new LoadTemplateEventHandler(LoadTemplate_XmlNamespaceImports),
                    null);

                AddTemplate(
                    template,
                    "<!-- BuiltInTypes -->",
                    "Opc.Ua.ModelCompiler.StackGenerator.DataTypes.Templates.XmlSchema.BuiltInTypes.xsd",
                    new ModelDesign[] { m_model },
                    new LoadTemplateEventHandler(LoadTemplate_XmlType),
                    new WriteTemplateEventHandler(WriteTemplate_XmlType));

                AddTemplate(
                    template,
                    "<!-- ListOfTypes -->",
                    null,
                    nodes,
                    new LoadTemplateEventHandler(LoadTemplate_XmlType),
                    new WriteTemplateEventHandler(WriteTemplate_XmlType));

                template.WriteTemplate(null);
            }
            finally
            {
                writer.Close();
            }
        }

        #region "xmlns:s0="ListOfNamespaces" and "<!-- Imports -->"
        /// <summary>
        /// Returns the XML prefix for the specified namespace.
        /// </summary>
        private string GetXmlNamespacePrefix(string namespaceUri)
        {
            if (namespaceUri == null)
            {
                return null;
            }

            if (m_model.Namespaces != null)
            {
                for (int ii = 0; ii < m_model.Namespaces.Length; ii++)
                {
                    if (m_model.Namespaces[ii].Value == namespaceUri)
                    {
                        if (String.IsNullOrEmpty(m_model.Namespaces[ii].XmlPrefix))
                        {
                            return String.Format("s{0}", ii);
                        }

                        return m_model.Namespaces[ii].XmlPrefix;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Writes the code to defined a identifier for a type.
        /// </summary>
        private string LoadTemplate_XmlNamespaceImports(Template template, Context context)
        {
            Namespace ns = context.Target as Namespace;

            if (ns == null)
            {
                return null;
            }

            if (ns.Value == m_model.TargetNamespace)
            {
                return null;
            }

            string uri = ns.Value;

            if (!String.IsNullOrEmpty(ns.XmlNamespace))
            {
                uri = ns.XmlNamespace;
            }

            if (context.Token.Contains("xmlns:s0"))
            {
                if (ns.Value == DefaultNamespace)
                {
                    return null;
                }

                template.WriteNextLine(context.Prefix);
                template.Write("xmlns:{0}=\"{1}\"", GetXmlNamespacePrefix(ns.Value), uri);

                return null;
            }

            template.WriteNextLine(context.Prefix);
            template.Write("<xs:import namespace=\"{0}\" />", uri);

            return null;
        }

        /// <summary>
        /// Returns a qualifier for the namespace to use in code.
        /// </summary>
        private int GetNamespaceIndex(string namespaceUri)
        {
            if (m_model.Namespaces != null)
            {
                for (int ii = 0; ii < m_model.Namespaces.Length; ii++)
                {
                    if (m_model.Namespaces[ii].Value == namespaceUri)
                    {
                        return ii;
                    }
                }
            }

            return 0;
        }
        #endregion

        #region "<!-- BuiltInTypes -->" and "<!-- ListOfTypes -->"
        /// <summary>
        /// Writes the code to defined a identifier for a type.
        /// </summary>
        private string LoadTemplate_XmlType(Template template, Context context)
        {
            ModelDesign model = context.Target as ModelDesign;

            if (model != null)
            {
                if (m_model.TargetNamespace == DefaultNamespace)
                {
                    return context.TemplatePath;
                }

                return null;
            }

            DataTypeDesign dataType = context.Target as DataTypeDesign;

            if (dataType == null)
            {
                return null;
            }

            // don't write built-in types.
            if (dataType.NumericId < 256 && dataType.SymbolicId.Namespace == DefaultNamespace)
            {
                switch (dataType.NumericId)
                {
                    case DataTypes.RolePermissionType:
                    case DataTypes.StructureDefinition:
                    case DataTypes.StructureField:
                    case DataTypes.StructureType:
                    case DataTypes.EnumDefinition:
                    case DataTypes.EnumField:
                    {
                        break;
                    }

                    default:
                    {
                        return null;
                    }
                }
            }

            BasicDataType basicType = dataType.BasicDataType;

            if (basicType == BasicDataType.Enumeration)
            {
                return TemplatePath + "XmlSchema.EnumeratedType.xml";
            }

            else if (basicType == BasicDataType.UserDefined)
            {
                if (dataType.BaseTypeNode.SymbolicName.Name == "Structure")
                {
                    return TemplatePath + "XmlSchema.ComplexType.xml";
                }
                else
                {
                    return TemplatePath + "XmlSchema.DerivedType.xml";
                }
            }

            return TemplatePath + "XmlSchema.SimpleType.xml";
        }

        /// <summary>
        /// Writes the code to defined a identifier for a type.
        /// </summary>
        private bool WriteTemplate_XmlType(Template template, Context context)
        {
            ModelDesign model = context.Target as ModelDesign;

            if (model != null)
            {
                if (m_model.TargetNamespace == DefaultNamespace)
                {
                    return template.WriteTemplate(context);
                }

                return false;
            }

            DataTypeDesign dataType = context.Target as DataTypeDesign;

            if (dataType == null)
            {
                return false;
            }

            if (context.FirstInList)
            {
                template.WriteNextLine(String.Empty);
            }

            DataTypeDesign baseType = dataType.BaseTypeNode as DataTypeDesign;

            if (baseType != null)
            {
                template.AddReplacement("_BaseType_", GetXmlDataType(baseType, ValueRank.Scalar));
            }

            template.AddReplacement("_TypeName_", dataType.SymbolicName.Name);

            AddTemplate(
                template,
                "<!-- Documentation -->",
                TemplatePath + "XmlSchema.Documentation.xml",
                new DataTypeDesign[] { dataType },
                new LoadTemplateEventHandler(LoadTemplate_XmlDocumentation),
                new WriteTemplateEventHandler(WriteTemplate_XmlDocumentation));

            AddTemplate(
                template,
                "<!-- CollectionType -->",
                TemplatePath + "XmlSchema.CollectionType.xml",
                new DataTypeDesign[] { dataType },
                new LoadTemplateEventHandler(LoadTemplate_XmlCollectionType),
                new WriteTemplateEventHandler(WriteTemplate_XmlCollectionType));

            AddTemplate(
                template,
                "<!-- ListOfFields -->",
                null,
                dataType.Fields,
                new LoadTemplateEventHandler(LoadTemplate_XmlTypeFields),
                null);

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Returns the data type to use for the value of a variable or the argument of a method.
        /// </summary>
        private string GetXmlDataType(DataTypeDesign dataType, ValueRank valueRank)
        {
            if (valueRank != ValueRank.Scalar)
            {
                switch (dataType.BasicDataType)
                {
                    case BasicDataType.Boolean: { return "ua:ListOfBoolean"; }
                    case BasicDataType.SByte: { return "ua:ListOfSByte"; }
                    case BasicDataType.Int16: { return "ua:ListOfInt16"; }
                    case BasicDataType.UInt16: { return "ua:ListOfUInt16"; }
                    case BasicDataType.Int32: { return "ua:ListOfInt32"; }
                    case BasicDataType.UInt32: { return "ua:ListOfUInt32"; }
                    case BasicDataType.Int64: { return "ua:ListOfInt64"; }
                    case BasicDataType.UInt64: { return "ua:ListOfUInt64"; }
                    case BasicDataType.Float: { return "ua:ListOfFloat"; }
                    case BasicDataType.Double: { return "ua:ListOfDouble"; }
                    case BasicDataType.String: { return "ua:ListOfString"; }
                    case BasicDataType.DateTime: { return "ua:ListOfDateTime"; }
                    case BasicDataType.Guid: { return "ua:ListOfGuid"; }
                    case BasicDataType.ByteString: { return "ua:ListOfByteString"; }
                    case BasicDataType.XmlElement: { return "ua:ListOfXmlElement"; }
                    case BasicDataType.NodeId: { return "ua:ListOfNodeId"; }
                    case BasicDataType.ExpandedNodeId: { return "ua:ListOfExpandedNodeId"; }
                    case BasicDataType.StatusCode: { return "ua:ListOfStatusCode"; }
                    case BasicDataType.DiagnosticInfo: { return "ua:ListOfDiagnosticInfo"; }
                    case BasicDataType.QualifiedName: { return "ua:ListOfQualifiedName"; }
                    case BasicDataType.LocalizedText: { return "ua:ListOfLocalizedText"; }
                    case BasicDataType.DataValue: { return "ua:ListOfDataValue"; }
                    case BasicDataType.Number: { return "ua:ListOfVariant"; }
                    case BasicDataType.Integer: { return "ua:ListOfVariant"; }
                    case BasicDataType.UInteger: { return "ua:ListOfVariant"; }
                    case BasicDataType.BaseDataType: { return "ua:ListOfVariant"; }

                    default:
                    case BasicDataType.Enumeration:
                    case BasicDataType.Structure:
                    {
                        if (dataType.SymbolicName == new XmlQualifiedName("Structure", DefaultNamespace))
                        {
                            return String.Format("ua:ListOfExtensionObject");
                        }

                        if (dataType.SymbolicName == new XmlQualifiedName("Enumeration", DefaultNamespace))
                        {
                            if (dataType.IsOptionSet)
                            {
                                return GetXmlDataType((DataTypeDesign)dataType.BaseTypeNode, valueRank);
                            }

                            return String.Format("ua:ListOfInt32");
                        }

                        string prefix = "tns";

                        if (dataType.SymbolicName.Namespace != m_model.TargetNamespace)
                        {
                            if (dataType.SymbolicName.Namespace == DefaultNamespace)
                            {
                                if (dataType.SymbolicName.Name == "Enumeration")
                                {
                                    if (dataType.IsOptionSet)
                                    {
                                        return GetXmlDataType((DataTypeDesign)dataType.BaseTypeNode, valueRank);
                                    }

                                    return String.Format("ua:ListOfInt32");
                                }

                                prefix = "ua";
                            }
                            else
                            {
                                prefix = GetXmlNamespacePrefix(dataType.SymbolicName.Namespace);
                            }
                        }

                        return String.Format("{0}:ListOf{1}", prefix, dataType.SymbolicName.Name);
                    }
                }
            }

            switch (dataType.BasicDataType)
            {
                case BasicDataType.Boolean: { return "xs:boolean"; }
                case BasicDataType.SByte: { return "xs:byte"; }
                case BasicDataType.Byte: { return "xs:unsignedByte"; }
                case BasicDataType.Int16: { return "xs:short"; }
                case BasicDataType.UInt16: { return "xs:unsignedShort"; }
                case BasicDataType.Int32: { return "xs:int"; }
                case BasicDataType.UInt32: { return "xs:unsignedInt"; }
                case BasicDataType.Int64: { return "xs:long"; }
                case BasicDataType.UInt64: { return "xs:unsignedLong"; }
                case BasicDataType.Float: { return "xs:float"; }
                case BasicDataType.Double: { return "xs:double"; }
                case BasicDataType.String: { return "xs:string"; }
                case BasicDataType.DateTime: { return "xs:dateTime"; }
                case BasicDataType.Guid: { return "ua:Guid"; }
                case BasicDataType.ByteString: { return "xs:base64Binary"; }
                case BasicDataType.XmlElement: { return "ua:XmlElement"; }
                case BasicDataType.NodeId: { return "ua:NodeId"; }
                case BasicDataType.ExpandedNodeId: { return "ua:ExpandedNodeId"; }
                case BasicDataType.StatusCode: { return "ua:StatusCode"; }
                case BasicDataType.DiagnosticInfo: { return "ua:DiagnosticInfo"; }
                case BasicDataType.QualifiedName: { return "ua:QualifiedName"; }
                case BasicDataType.LocalizedText: { return "ua:LocalizedText"; }
                case BasicDataType.DataValue: { return "ua:DataValue"; }
                case BasicDataType.Number: { return "ua:Variant"; }
                case BasicDataType.Integer: { return "ua:Variant"; }
                case BasicDataType.UInteger: { return "ua:Variant"; }
                case BasicDataType.BaseDataType: { return "ua:Variant"; }

                default:
                case BasicDataType.Enumeration:
                case BasicDataType.Structure:
                {
                    if (dataType.SymbolicName == new XmlQualifiedName("Structure", DefaultNamespace))
                    {
                        return String.Format("ua:ExtensionObject");
                    }

                    if (dataType.SymbolicName == new XmlQualifiedName("Enumeration", DefaultNamespace))
                    {
                        if (dataType.IsOptionSet)
                        {
                             return GetXmlDataType((DataTypeDesign)dataType.BaseTypeNode, valueRank);
                        }

                        return String.Format("ua:Int32");
                    }

                    string prefix = "tns";

                    if (dataType.SymbolicName.Namespace != m_model.TargetNamespace)
                    {
                        if (dataType.SymbolicName.Namespace == DefaultNamespace)
                        {
                            if (dataType.SymbolicName.Name == "Enumeration")
                            {
                                if (dataType.IsOptionSet)
                                {
                                    return GetXmlDataType((DataTypeDesign)dataType.BaseTypeNode, valueRank);
                                }

                                return String.Format("ua:Int32");
                            }

                            prefix = "ua";
                        }
                        else
                        {
                            prefix = GetXmlNamespacePrefix(dataType.SymbolicName.Namespace);
                        }
                    }

                    return String.Format("{0}:{1}", prefix, dataType.SymbolicName.Name);
                }
            }
        }
        #endregion

        #region "<!-- ListOfFields -->"
        /// <summary>
        /// Writes the code to defined a identifier for a type.
        /// </summary>
        private string LoadTemplate_XmlTypeFields(Template template, Context context)
        {
            Parameter field = context.Target as Parameter;

            if (field == null)
            {
                return null;
            }

            DataTypeDesign dataType = field.Parent as DataTypeDesign;

            if (dataType == null)
            {
                return null;
            }

            BasicDataType basicType = dataType.BasicDataType;

            if (basicType == BasicDataType.Enumeration)
            {
                if (!dataType.IsOptionSet)
                {
                    template.WriteNextLine(context.Prefix);

                    if (field.IdentifierInName)
                    {
                        template.Write("<xs:enumeration value=\"{0}\" />", field.Name);
                        return null;
                    }

                    template.Write("<xs:enumeration value=\"{0}_{1}\" />", field.Name, field.Identifier);
                    return null;
                }

                basicType = ((DataTypeDesign)dataType.BaseTypeNode).BasicDataType;
            }

            basicType = field.DataTypeNode.BasicDataType;

            if (basicType == BasicDataType.XmlElement && field.ValueRank == ValueRank.Scalar)
            {
                template.WriteNextLine(context.Prefix);
                template.Write("<xs:element name=\"{0}\" minOccurs=\"0\" nillable=\"true\">", field.Name);
                template.WriteNextLine(context.Prefix);
                template.Write("  <xs:complexType>");
                template.WriteNextLine(context.Prefix);
                template.Write("    <xs:sequence>");
                template.WriteNextLine(context.Prefix);
                template.Write("      <xs:any minOccurs=\"0\" processContents=\"lax\" />");
                template.WriteNextLine(context.Prefix);
                template.Write("    </xs:sequence>");
                template.WriteNextLine(context.Prefix);
                template.Write("  </xs:complexType>");
                template.WriteNextLine(context.Prefix);
                template.Write("</xs:element>");
                return null;
            }

            template.WriteNextLine(context.Prefix);

            if (field.ValueRank != ValueRank.Scalar)
            {
                template.Write("<xs:element name=\"{0}\" type=\"{1}\" minOccurs=\"0\" nillable=\"true\" />", field.Name, GetXmlDataType(field.DataTypeNode, field.ValueRank));
            }
            else
            {
                switch (basicType)
                {
                    case BasicDataType.String:
                    case BasicDataType.ByteString:
                    case BasicDataType.DiagnosticInfo:
                    case BasicDataType.ExpandedNodeId:
                    case BasicDataType.LocalizedText:
                    case BasicDataType.NodeId:
                    case BasicDataType.QualifiedName:
                    case BasicDataType.Structure:
                    case BasicDataType.DataValue:
                    {
                        template.Write("<xs:element name=\"{0}\" type=\"{1}\" minOccurs=\"0\" nillable=\"true\" />", field.Name, GetXmlDataType(field.DataTypeNode, field.ValueRank));
                        break;
                    }

                    case BasicDataType.Guid:
                    case BasicDataType.StatusCode:
                    {
                        template.Write("<xs:element name=\"{0}\" type=\"{1}\" minOccurs=\"0\" />", field.Name, GetXmlDataType(field.DataTypeNode, field.ValueRank));
                        break;
                    }

                    case BasicDataType.UserDefined:
                    {
                        template.Write("<xs:element name=\"{0}\" type=\"{1}\" minOccurs=\"0\" nillable=\"true\" />", field.Name, GetXmlDataType(field.DataTypeNode, field.ValueRank));
                        break;
                    }

                    default:
                    {
                        template.Write("<xs:element name=\"{0}\" type=\"{1}\" minOccurs=\"0\" />", field.Name, GetXmlDataType(field.DataTypeNode, field.ValueRank));
                        break;
                    }
                }
            }

            return null;
        }
        #endregion

        #region "<!-- Documentation -->"
        private string LoadTemplate_XmlDocumentation(Template template, Context context)
        {
            DataTypeDesign dataType = context.Target as DataTypeDesign;

            if (dataType == null)
            {
                return null;
            }

            if (dataType.Description.IsAutogenerated)
            {
                return null;
            }

            return context.TemplatePath;
        }

        private bool WriteTemplate_XmlDocumentation(Template template, Context context)
        {
            DataTypeDesign dataType = context.Target as DataTypeDesign;

            if (dataType == null)
            {
                return false;
            }

            template.AddReplacement("_Description_", dataType.Description.Value);

            return template.WriteTemplate(context);
        }
        #endregion

        #region "<!-- CollectionType -->"
        private string LoadTemplate_XmlCollectionType(Template template, Context context)
        {
            DataTypeDesign dataType = context.Target as DataTypeDesign;

            if (dataType == null)
            {
                return null;
            }

            if (dataType.NoArraysAllowed)
            {
                return null;
            }

            return context.TemplatePath;
        }

        private bool WriteTemplate_XmlCollectionType(Template template, Context context)
        {
            DataTypeDesign dataType = context.Target as DataTypeDesign;

            if (dataType == null)
            {
                return false;
            }

            template.WriteLine(String.Empty);
            template.AddReplacement("_TypeName_", dataType.SymbolicName.Name);
            template.AddReplacement("_Nillable_", (dataType.BasicDataType == BasicDataType.Enumeration)?"":"nillable=\"true\" ");

            return template.WriteTemplate(context);
        }
        #endregion
        #endregion

        #region BinarySchema Class Generation
        /// <summary>
        /// Creates a class that defines all types in the namespace.
        /// </summary>
        private void WriteTemplate_BinarySchema(string filePath, List<NodeDesign> nodes)
        {
            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}.Types.bsd", filePath, m_model.TargetNamespaceInfo.Prefix), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "BinarySchema.File.xml", Assembly.GetExecutingAssembly());

                template.AddReplacement("_DictionaryUri_", m_model.TargetNamespace);
                template.Replacements.Add("_BuildDate_", Utils.Format("{0:yyyy-MM-dd}", DateTime.UtcNow));
                template.Replacements.Add("_Version_", Utils.Format("{0}.{1}", Utils.GetAssemblySoftwareVersion(), Utils.GetAssemblyBuildNumber()));

                AddTemplate(
                    template,
                    "xmlns:s0=\"ListOfNamespaces\"",
                    null,
                    m_model.Namespaces,
                    new LoadTemplateEventHandler(LoadTemplate_BinaryNamespaceImports),
                    null);

                AddTemplate(
                    template,
                    "<!-- Imports -->",
                    null,
                    m_model.Namespaces,
                    new LoadTemplateEventHandler(LoadTemplate_BinaryNamespaceImports),
                    null);

                AddTemplate(
                    template,
                    "<!-- BuiltInTypes -->",
                    TemplatePath + "BinarySchema.BuiltInTypes.bsd",
                    new ModelDesign[] { m_model },
                    new LoadTemplateEventHandler(LoadTemplate_BinaryType),
                    new WriteTemplateEventHandler(WriteTemplate_BinaryType));

                AddTemplate(
                    template,
                    "<!-- ListOfTypes -->",
                    null,
                    nodes,
                    new LoadTemplateEventHandler(LoadTemplate_BinaryType),
                    new WriteTemplateEventHandler(WriteTemplate_BinaryType));

                template.WriteTemplate(null);
            }
            finally
            {
                writer.Close();
            }
        }

        #region "xmlns:s0="ListOfNamespaces" and "<!-- Imports -->"
        /// <summary>
        /// Writes the code to defined a identifier for a type.
        /// </summary>
        private string LoadTemplate_BinaryNamespaceImports(Template template, Context context)
        {
            Namespace ns = context.Target as Namespace;

            if (ns == null)
            {
                return null;
            }

            if (ns.Value == m_model.TargetNamespace)
            {
                return null;
            }

            if (context.Token.Contains("xmlns:s0"))
            {
                if (ns.Value == DefaultNamespace)
                {
                    return null;
                }

                template.WriteNextLine(context.Prefix);
                template.Write("xmlns:{0}=\"{1}\"", GetXmlNamespacePrefix(ns.Value), ns.Value);
                return null;
            }

            template.WriteNextLine(context.Prefix);
            template.Write("<opc:Import Namespace=\"{0}\" Location=\"{1}.BinarySchema.bsd\"/>", ns.Value, GetNamespacePrefix(ns.Value));

            return null;
        }
        #endregion

        #region "<!-- BuiltInTypes -->" and "<!-- ListOfTypes -->"
        /// <summary>
        /// Writes the code to defined a identifier for a type.
        /// </summary>
        private string LoadTemplate_BinaryType(Template template, Context context)
        {
            ModelDesign model = context.Target as ModelDesign;

            if (model != null)
            {
                if (m_model.TargetNamespace == DefaultNamespace)
                {
                    return context.TemplatePath;
                }

                return null;
            }

            DataTypeDesign dataType = context.Target as DataTypeDesign;

            if (dataType == null)
            {
                return null;
            }

            // don't write built-in types.
            if (dataType.NumericId < 256 && dataType.SymbolicId.Namespace == DefaultNamespace)
            {
                switch (dataType.NumericId)
                {
                    case DataTypes.RolePermissionType:
                    case DataTypes.StructureDefinition:
                    case DataTypes.StructureField:
                    case DataTypes.StructureType:
                    case DataTypes.EnumDefinition:
                    case DataTypes.EnumField:
                    {
                        break;
                    }

                    default:
                    {
                        return null;
                    }
                }
            }

            BasicDataType basicType = dataType.BasicDataType;

            if (basicType == BasicDataType.Enumeration)
            {
                return TemplatePath + "BinarySchema.EnumeratedType.xml";
            }

            else if (basicType == BasicDataType.UserDefined)
            {
                return TemplatePath + "BinarySchema.ComplexType.xml";
            }

            return TemplatePath + "BinarySchema.OpaqueType.xml";
        }

        /// <summary>
        /// Writes the code to defined a identifier for a type.
        /// </summary>
        private bool WriteTemplate_BinaryType(Template template, Context context)
        {
            ModelDesign model = context.Target as ModelDesign;

            if (model != null)
            {
                if (m_model.TargetNamespace == DefaultNamespace)
                {
                    template.WriteNextLine(String.Empty);
                    return template.WriteTemplate(context);
                }

                return false;
            }

            DataTypeDesign dataType = context.Target as DataTypeDesign;

            if (dataType == null)
            {
                return false;
            }

            if (context.FirstInList)
            {
                template.WriteNextLine(String.Empty);
            }

            template.AddReplacement("_TypeName_", dataType.SymbolicName.Name);

            if (dataType.BasicDataType == BasicDataType.UserDefined)
            {
                template.AddReplacement("_BaseType_", GetBinaryDataType(dataType.BaseTypeNode as DataTypeDesign));
            }

            List<Parameter> fields = new List<Parameter>();
            Stack<DataTypeDesign> parents = new Stack<DataTypeDesign>();

            for (DataTypeDesign parent = dataType as DataTypeDesign; parent != null; parent = parent.BaseTypeNode as DataTypeDesign)
            {
                if (parent.Fields != null)
                {
                    parents.Push(parent);
                }
            }

            while (parents.Count > 0)
            {
                DataTypeDesign parent = parents.Pop();

                foreach (Parameter field in parent.Fields)
                {
                    if (Object.ReferenceEquals(dataType, parent))
                    {
                        fields.Add(field);
                        continue;
                    }

                    fields.Add(new Parameter()
                    {
                        DataType = field.DataType,
                        DataTypeNode = field.DataTypeNode,
                        Description = field.Description,
                        Identifier = field.Identifier,
                        IdentifierInName = field.IdentifierInName,
                        IdentifierSpecified = field.IdentifierSpecified,
                        IsInherited = true,
                        Name = field.Name,
                        Parent = field.Parent,
                        ValueRank = field.ValueRank
                    });
                }
            }

            AddTemplate(
                template,
                "<!-- Documentation -->",
                null,
                new DataTypeDesign[] { dataType },
                new LoadTemplateEventHandler(LoadTemplate_BinaryDocumentation),
                null);

            AddTemplate(
                template,
                "<!-- ListOfFields -->",
                null,
                fields,
                new LoadTemplateEventHandler(LoadTemplate_BinaryTypeFields),
                null);

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Returns the data type to use for the value of a variable or the argument of a method.
        /// </summary>
        private string GetBinaryDataType(DataTypeDesign dataType)
        {
            switch (dataType.BasicDataType)
            {
                case BasicDataType.Boolean: { return "opc:Boolean"; }
                case BasicDataType.SByte: { return "opc:SByte"; }
                case BasicDataType.Byte: { return "opc:Byte"; }
                case BasicDataType.Int16: { return "opc:Int16"; }
                case BasicDataType.UInt16: { return "opc:UInt16"; }
                case BasicDataType.Int32: { return "opc:Int32"; }
                case BasicDataType.UInt32: { return "opc:UInt32"; }
                case BasicDataType.Int64: { return "opc:Int64"; }
                case BasicDataType.UInt64: { return "opc:UInt64"; }
                case BasicDataType.Float: { return "opc:Float"; }
                case BasicDataType.Double: { return "opc:Double"; }
                case BasicDataType.String: { return "opc:String"; }
                case BasicDataType.DateTime: { return "opc:DateTime"; }
                case BasicDataType.Guid: { return "opc:Guid"; }
                case BasicDataType.ByteString: { return "opc:ByteString"; }
                case BasicDataType.XmlElement: { return "ua:XmlElement"; }
                case BasicDataType.NodeId: { return "ua:NodeId"; }
                case BasicDataType.ExpandedNodeId: { return "ua:ExpandedNodeId"; }
                case BasicDataType.StatusCode: { return "ua:StatusCode"; }
                case BasicDataType.DiagnosticInfo: { return "ua:DiagnosticInfo"; }
                case BasicDataType.QualifiedName: { return "ua:QualifiedName"; }
                case BasicDataType.LocalizedText: { return "ua:LocalizedText"; }
                case BasicDataType.DataValue: { return "ua:DataValue"; }
                case BasicDataType.Number: { return "ua:Variant"; }
                case BasicDataType.Integer: { return "ua:Variant"; }
                case BasicDataType.UInteger: { return "ua:Variant"; }
                case BasicDataType.BaseDataType: { return "ua:Variant"; }

                default:
                case BasicDataType.Enumeration:
                case BasicDataType.Structure:
                {
                    if (dataType.SymbolicName == new XmlQualifiedName("Structure", DefaultNamespace))
                    {
                        return String.Format("ua:ExtensionObject");
                    }

                    if (dataType.SymbolicName == new XmlQualifiedName("Enumeration", DefaultNamespace))
                    {
                        if (dataType.IsOptionSet)
                        {
                            return GetBinaryDataType((DataTypeDesign)dataType.BaseTypeNode);
                        }

                        return String.Format("ua:Int32");
                    }

                    string prefix = "tns";

                    if (dataType.SymbolicName.Namespace != m_model.TargetNamespace)
                    {
                        if (dataType.SymbolicName.Namespace == DefaultNamespace)
                        {
                            prefix = "ua";
                        }
                        else
                        {
                            prefix = GetXmlNamespacePrefix(dataType.SymbolicName.Namespace);
                        }
                    }

                    return String.Format("{0}:{1}", prefix, dataType.SymbolicName.Name);
                }
            }
        }
        #endregion

        #region "<!-- ListOfFields -->"
        /// <summary>
        /// Writes the code to defined a identifier for a type.
        /// </summary>
        private string LoadTemplate_BinaryTypeFields(Template template, Context context)
        {
            Parameter field = context.Target as Parameter;

            if (field == null)
            {
                return null;
            }

            DataTypeDesign dataType = field.Parent as DataTypeDesign;

            if (dataType == null)
            {
                return null;
            }

            BasicDataType basicType = dataType.BasicDataType;

            if (basicType == BasicDataType.Enumeration)
            {
                template.WriteNextLine(context.Prefix);
                template.Write("<opc:EnumeratedValue Name=\"{0}\" Value=\"{1}\" />", field.Name, field.Identifier);
                return null;
            }

            if (field.ValueRank != ValueRank.Scalar)
            {
                template.WriteNextLine(context.Prefix);
                template.Write("<opc:Field Name=\"NoOf{0}\" TypeName=\"opc:Int32\" />", field.Name);
                template.WriteNextLine(context.Prefix);
                template.Write("<opc:Field Name=\"{0}\" TypeName=\"{1}\" LengthField=\"NoOf{0}\" />", field.Name, GetBinaryDataType(field.DataTypeNode));
                return null;
            }

            template.WriteNextLine(context.Prefix);

            if (field.IsInherited)
            {
                template.Write("<opc:Field Name=\"{0}\" TypeName=\"{1}\" SourceType=\"{2}\" />", field.Name, GetBinaryDataType(field.DataTypeNode), GetBinaryDataType(field.Parent as DataTypeDesign));
            }
            else
            {
                template.Write("<opc:Field Name=\"{0}\" TypeName=\"{1}\" />", field.Name, GetBinaryDataType(field.DataTypeNode));
            }
            return null;
        }
        #endregion

        #region "<!-- Documentation -->"
        private string LoadTemplate_BinaryDocumentation(Template template, Context context)
        {
            DataTypeDesign dataType = context.Target as DataTypeDesign;

            if (dataType == null)
            {
                return null;
            }

            if (dataType.Description == null || dataType.Description.IsAutogenerated)
            {
                return null;
            }

            template.WriteNextLine(context.Prefix);
            template.Write("<opc:Documentation>{0}</opc:Documentation>", dataType.Description.Value);

            return context.TemplatePath;
        }
        #endregion
        #endregion

        /// <summary>
        /// Creates a class that defines all types in the namespace.
        /// </summary>
        private void WriteTemplate_InternalSingleFile(string filePath, List<NodeDesign> nodes)
        {
            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}.Classes.cs", filePath, m_model.TargetNamespaceInfo.Prefix), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "Version2.File.cs", Assembly.GetExecutingAssembly());

                template.AddReplacement("_Namespace_", GetNamespacePrefix(m_model.TargetNamespace));
                template.AddReplacement("_NamespaceUri_", GetConstantForNamespace(m_model.TargetNamespace));


                AddTemplate(
                    template,
                    "// ListOfImports",
                    null,
                    m_model.Namespaces,
                    new LoadTemplateEventHandler(LoadTemplate_NamespaceImports),
                    null);

                List<string> namespaces = new List<string>();

                for (int ii = 0; ii < m_model.Namespaces.Length; ii++)
                {
                    namespaces.Add(m_model.Namespaces[ii].Value);

                    if (!String.IsNullOrEmpty(m_model.Namespaces[ii].XmlNamespace))
                    {
                        namespaces.Add(m_model.Namespaces[ii].XmlNamespace);
                    }
                }

                AddTemplate(
                  template,
                  "// ListOfNamespaceUris",
                  TemplatePath + "Version2.NamespaceUri.cs",
                  namespaces,
                  null,
                  new WriteTemplateEventHandler(WriteTemplate_CodeNamespaceUri));

                SortedDictionary<string, string> browseNames = GetBrowseNames(nodes);

                AddTemplate(
                    template,
                    "// ListOfBrowseNames",
                    TemplatePath + "Version2.BrowseName.cs",
                    browseNames,
                    new LoadTemplateEventHandler(LoadTemplate_BrowseNames),
                    new WriteTemplateEventHandler(WriteTemplate_BrowseNames));

                SortedDictionary<string, List<NodeDesign>> identifiers = GetIdentifiers(nodes);

                AddTemplate(
                    template,
                    "// ListOfIdentifiers",
                    TemplatePath + "Version2.IdClass.cs",
                    identifiers,
                    new LoadTemplateEventHandler(LoadTemplate_IdClass),
                    new WriteTemplateEventHandler(WriteTemplate_IdClass));

                AddTemplate(
                    template,
                    "// ListOfNodeIds",
                    TemplatePath + "Version2.NodeIdClass.cs",
                    identifiers,
                    new LoadTemplateEventHandler(LoadTemplate_IdClass),
                    new WriteTemplateEventHandler(WriteTemplate_IdClass));

                AddTemplate(
                    template,
                    "// ListOfTypes",
                    TemplatePath + "Version2.Type.cs",
                    nodes,
                    new LoadTemplateEventHandler(LoadTemplate_ListOfTypes),
                    new WriteTemplateEventHandler(WriteTemplate_ListOfTypes));

                Context context = new Context();
                context.Target = nodes;
                template.WriteTemplate(context);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Writes a file that contains all constant classes.
        /// </summary>
        private void WriteTemplate_ConstantsSingleFile(string filePath, List<NodeDesign> nodes)
        {
            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}.Constants.cs", filePath, m_model.TargetNamespaceInfo.Prefix), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "Version2.ConstantsFile.cs", Assembly.GetExecutingAssembly());

                template.AddReplacement("_Namespace_", GetNamespacePrefix(m_model.TargetNamespace));
                template.AddReplacement("_NamespaceUri_", GetConstantForNamespace(m_model.TargetNamespace));

                AddTemplate(
                    template,
                    "// ListOfImports",
                    null,
                    m_model.Namespaces,
                    new LoadTemplateEventHandler(LoadTemplate_NamespaceImports),
                    null);

                List<string> namespaces = new List<string>();

                for (int ii = 0; ii < m_model.Namespaces.Length; ii++)
                {
                    namespaces.Add(m_model.Namespaces[ii].Value);

                    if (!String.IsNullOrEmpty(m_model.Namespaces[ii].XmlNamespace))
                    {
                        namespaces.Add(m_model.Namespaces[ii].XmlNamespace);
                    }
                }

                AddTemplate(
                  template,
                  "// ListOfNamespaceUris",
                  TemplatePath + "Version2.NamespaceUri.cs",
                  namespaces,
                  null,
                  new WriteTemplateEventHandler(WriteTemplate_CodeNamespaceUri));

                SortedDictionary<string, string> browseNames = GetBrowseNames(nodes);

                AddTemplate(
                    template,
                    "// ListOfBrowseNames",
                    TemplatePath + "Version2.BrowseName.cs",
                    browseNames,
                    new LoadTemplateEventHandler(LoadTemplate_BrowseNames),
                    new WriteTemplateEventHandler(WriteTemplate_BrowseNames));

                SortedDictionary<string, List<NodeDesign>> identifiers = GetIdentifiers(nodes);

                AddTemplate(
                    template,
                    "// ListOfIdentifiers",
                    TemplatePath + "Version2.IdClass.cs",
                    identifiers,
                    new LoadTemplateEventHandler(LoadTemplate_IdClass),
                    new WriteTemplateEventHandler(WriteTemplate_IdClass));

                AddTemplate(
                    template,
                    "// ListOfNodeIds",
                    TemplatePath + "Version2.NodeIdClass.cs",
                    identifiers,
                    new LoadTemplateEventHandler(LoadTemplate_IdClass),
                    new WriteTemplateEventHandler(WriteTemplate_IdClass));

                Context context = new Context();
                context.Target = nodes;
                template.WriteTemplate(context);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Writes a file that contains all data type classes.
        /// </summary>
        private void WriteTemplate_DataTypesSingleFile(string filePath, List<NodeDesign> nodes)
        {
            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}.DataTypes.cs", filePath, m_model.TargetNamespaceInfo.Prefix), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "Version2.TypesFile.cs", Assembly.GetExecutingAssembly());

                template.AddReplacement("_Namespace_", GetNamespacePrefix(m_model.TargetNamespace));
                template.AddReplacement("_NamespaceUri_", GetConstantForNamespace(m_model.TargetNamespace));

                AddTemplate(
                    template,
                    "// ListOfImports",
                    null,
                    m_model.Namespaces,
                    new LoadTemplateEventHandler(LoadTemplate_NamespaceImports),
                    null);

                List<string> namespaces = new List<string>();

                for (int ii = 0; ii < m_model.Namespaces.Length; ii++)
                {
                    namespaces.Add(m_model.Namespaces[ii].Value);

                    if (!String.IsNullOrEmpty(m_model.Namespaces[ii].XmlNamespace))
                    {
                        namespaces.Add(m_model.Namespaces[ii].XmlNamespace);
                    }
                }

                List<DataTypeDesign> datatypes = new List<DataTypeDesign>();

                for (int ii = 0; ii < nodes.Count; ii++)
                {
                    if (nodes[ii] is DataTypeDesign)
                    {
                        datatypes.Add((DataTypeDesign)nodes[ii]);
                    }
                }

                AddTemplate(
                    template,
                    "// ListOfTypes",
                    TemplatePath + "Version2.Type.cs",
                    datatypes,
                    new LoadTemplateEventHandler(LoadTemplate_ListOfTypes),
                    new WriteTemplateEventHandler(WriteTemplate_ListOfTypes));

                Context context = new Context();
                context.Target = nodes;
                template.WriteTemplate(context);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Writes a file that contains all non-data type classes.
        /// </summary>
        private void WriteTemplate_NonDataTypesSingleFile(string filePath, List<NodeDesign> nodes)
        {
            StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}.Classes.cs", filePath, m_model.TargetNamespaceInfo.Prefix), false);

            try
            {
                Template template = new Template(writer, TemplatePath + "Version2.TypesFile.cs", Assembly.GetExecutingAssembly());

                template.AddReplacement("_Namespace_", GetNamespacePrefix(m_model.TargetNamespace));
                template.AddReplacement("_NamespaceUri_", GetConstantForNamespace(m_model.TargetNamespace));

                AddTemplate(
                    template,
                    "// ListOfImports",
                    null,
                    m_model.Namespaces,
                    new LoadTemplateEventHandler(LoadTemplate_NamespaceImports),
                    null);

                List<string> namespaces = new List<string>();

                for (int ii = 0; ii < m_model.Namespaces.Length; ii++)
                {
                    namespaces.Add(m_model.Namespaces[ii].Value);

                    if (!String.IsNullOrEmpty(m_model.Namespaces[ii].XmlNamespace))
                    {
                        namespaces.Add(m_model.Namespaces[ii].XmlNamespace);
                    }
                }

                List<NodeDesign> nonDataTypes = new List<NodeDesign>();

                for (int ii = 0; ii < nodes.Count; ii++)
                {
                    if (!(nodes[ii] is DataTypeDesign))
                    {
                        nonDataTypes.Add(nodes[ii]);
                    }
                }

                AddTemplate(
                    template,
                    "// ListOfTypes",
                    TemplatePath + "Version2.Type.cs",
                    nonDataTypes,
                    new LoadTemplateEventHandler(LoadTemplate_ListOfTypes),
                    new WriteTemplateEventHandler(WriteTemplate_ListOfTypes));

                Context context = new Context();
                context.Target = nodes;
                template.WriteTemplate(context);
            }
            finally
            {
                writer.Close();
            }
        }

        #region "// ListOfIdentifiers"
        /// <summary>
        /// Loads the template for a C# implementation of a type.
        /// </summary>
        private string LoadTemplate_IdClass(Template template, Context context)
        {
            KeyValuePair<string, List<NodeDesign>>? nodes = context.Target as KeyValuePair<string, List<NodeDesign>>?;

            if (nodes == null)
            {
                return null;
            }

            if (nodes.Value.Value.Count == 0)
            {
                return null;
            }

            return context.TemplatePath;
        }

        /// <summary>
        /// Writes the code for a C# implementation of a type.
        /// </summary>
        private bool WriteTemplate_IdClass(Template template, Context context)
        {
            KeyValuePair<string, List<NodeDesign>>? nodes = context.Target as KeyValuePair<string, List<NodeDesign>>?;

            if (nodes == null)
            {
                return false;
            }

            template.AddReplacement("_NodeClass_", nodes.Value.Key);
            template.AddReplacement("_NamespacePrefix_", GetNamespacePrefix(this.m_model.TargetNamespace));

            string templatePath = TemplatePath + "Version2.IdDeclaration.cs";

            if (context.TemplatePath.EndsWith("NodeIdClass.cs"))
            {
                if (this.m_model.TargetNamespace != DefaultNamespace)
                {
                    templatePath = TemplatePath + "Version2.NodeIdDeclarationAbsolute.cs";
                }
                else
                {
                    templatePath = TemplatePath + "Version2.NodeIdDeclaration.cs";
                }
            }
            else if (context.TemplatePath.EndsWith(".html"))
            {
                templatePath = TemplatePath + "Version2.IdDeclaration.html";
            }

            AddTemplate(
                template,
                "// ListOfIdentifiers",
                templatePath,
                nodes.Value.Value,
                null,
                new WriteTemplateEventHandler(WriteTemplate_IdDeclaration));

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Writes the code for the child of a type.
        /// </summary>
        private bool WriteTemplate_IdDeclaration(Template template, Context context)
        {
            NodeDesign node = context.Target as NodeDesign;

            if (node == null)
            {
                return false;
            }

            template.AddReplacement("_NodeClass_", GetNodeClass(node));
            template.AddReplacement("_SymbolicName_", node.SymbolicId.Name);
            template.AddReplacement("_Identifier_", node.NumericId);
            template.AddReplacement("_NamespaceUri_", GetConstantForNamespace(node.SymbolicId.Namespace));
            template.AddReplacement("_NamespacePrefix_", GetNamespacePrefix(node.SymbolicId.Namespace));

            return template.WriteTemplate(context);
        }

        /// <summary>
        /// Returns the identifiers for the nodes defined.
        /// </summary>
        private SortedDictionary<string, List<NodeDesign>> GetIdentifiers(IList<NodeDesign> nodes)
        {
            SortedDictionary<string, List<NodeDesign>> identifiers = new SortedDictionary<string, List<NodeDesign>>();

            for (int ii = 0; ii < m_model.Items.Length; ii++)
            {
                NodeDesign node = m_model.Items[ii];

                if (IsMethodTypeNode(node))
                {
                    continue;
                }

                string nodeClass = GetNodeClass(node);

                if (nodeClass == "EventType")
                {
                    nodeClass = "ObjectType";
                }

                List<NodeDesign> nodesWithinClass = null;

                if (!identifiers.TryGetValue(nodeClass, out nodesWithinClass))
                {
                    identifiers[nodeClass] = nodesWithinClass = new List<NodeDesign>();
                }

                if (!nodesWithinClass.Contains(node))
                {
                    nodesWithinClass.Add(node);
                }

                if (node.Hierarchy == null)
                {
                    continue;
                }

                foreach (KeyValuePair<string, HierarchyNode> current in node.Hierarchy.Nodes)
                {
                    if (String.IsNullOrEmpty(current.Key))
                    {
                        continue;
                    }

                    if (node is TypeDesign)
                    {
                        if (!current.Value.ExplicitlyDefined)
                        {
                            if (current.Value.Inherited && (current.Value.Instance == null || current.Value.Instance.BrowseName == current.Value.RelativePath))
                            {
                                continue;
                            }

                            InstanceDesign child = current.Value.Instance as InstanceDesign;

                            if (child != null)
                            {
                                if (child.ModellingRule != ModellingRule.Mandatory)
                                {
                                    continue;
                                }
                            }
                        }
                    }

                    if (node is InstanceDesign)
                    {
                        InstanceDesign child = current.Value.Instance as InstanceDesign;

                        if (child == null)
                        {
                            continue;
                        }

                        if (child.ModellingRule != ModellingRule.Mandatory)
                        {
                            continue;
                        }
                    }

                    nodeClass = GetNodeClass(current.Value.Instance);

                    if (!identifiers.TryGetValue(nodeClass, out nodesWithinClass))
                    {
                        identifiers[nodeClass] = nodesWithinClass = new List<NodeDesign>();
                    }

                    nodesWithinClass.Add(current.Value.Instance);
                }
            }

            return identifiers;
        }
        #endregion

        #region "// ListOfBrowseNames"
        /// <summary>
        /// Loads the template for a C# class that delclares the browse names.
        /// </summary>
        private string LoadTemplate_BrowseNames(Template template, Context context)
        {
            KeyValuePair<string, string>? browseName = context.Target as KeyValuePair<string, string>?;

            if (browseName == null)
            {
                return null;
            }

            return context.TemplatePath;
        }

        /// <summary>
        /// Writes the code for a C# class that declares the browse names.
        /// </summary>
        private bool WriteTemplate_BrowseNames(Template template, Context context)
        {
            KeyValuePair<string, string>? browseName = context.Target as KeyValuePair<string, string>?;

            if (browseName == null)
            {
                return false;
            }

            template.AddReplacement("_SymbolicName_", browseName.Value.Key);
            template.AddReplacement("_BrowseName_", browseName.Value.Value);

            return template.WriteTemplate(context);
        }

        private bool IsMethodTypeNode(NodeDesign node)
        {
            if (node == null)
            {
                return false;
            }

            string symbol = node.SymbolicId.Name;

            int index = symbol.IndexOf("_");

            if (index > 0)
            {
                symbol = symbol.Substring(0, index);
            }

            if (symbol.EndsWith("MethodType"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the browse names for the nodes defined.
        /// </summary>
        private SortedDictionary<string, string> GetBrowseNames(IList<NodeDesign> nodes)
        {
            SortedDictionary<string, string> browseNames = new SortedDictionary<string, string>();

            foreach (NodeDesign node in nodes)
            {
                if (IsMethodTypeNode(node))
                {
                    continue;
                }

                if (node.SymbolicName.Namespace == m_model.TargetNamespace)
                {
                    browseNames[node.SymbolicName.Name] = node.BrowseName;
                }

                if (!node.HasChildren)
                {
                    continue;
                }

                foreach (NodeDesign child in node.Children.Items)
                {
                    if (child.SymbolicName.Namespace == m_model.TargetNamespace)
                    {
                        string browseName = null;

                        if (browseNames.TryGetValue(child.SymbolicName.Name, out browseName))
                        {
                            if (browseName != child.BrowseName)
                            {
                                throw ServiceResultException.Create(
                                    StatusCodes.BadTypeMismatch,
                                    "Two nodes with the same symbolic name have different browse names: {0} != {1}.",
                                    browseName,
                                    child.BrowseName);
                            }

                            continue;
                        }

                        browseNames[child.SymbolicName.Name] = child.BrowseName;
                    }
                }
            }

            return browseNames;
        }
        #endregion

        #region "// ListOfNamespaceUris"
        /// <summary>
        /// Writes the code define a constant for a namespace uri.
        /// </summary>
        private bool WriteTemplate_CodeNamespaceUri(Template template, Context context)
        {
            string uri = context.Target as string;

            if (uri == null)
            {
                return false;
            }

            for (int ii = 0; ii < m_model.Namespaces.Length; ii++)
            {
                Namespace ns = m_model.Namespaces[ii];

                if (uri != ns.Value && uri != ns.XmlNamespace)
                {
                    continue;
                }

                template.AddReplacement("_NamespaceUri_", uri);
                template.AddReplacement("_CodeName_", ns.Prefix);

                if (uri != ns.XmlNamespace)
                {
                    template.AddReplacement("_Name_", ns.Name);
                }
                else
                {
                    template.AddReplacement("_Name_", ns.Name + "Xsd");
                }
            }

            return template.WriteTemplate(context);
        }
        #endregion

        #region "// ListOfImports"
        /// <summary>
        /// Writes the code to defined a identifier for a type.
        /// </summary>
        private string LoadTemplate_NamespaceImports(Template template, Context context)
        {
            Namespace ns = context.Target as Namespace;

            if (ns == null)
            {
                return null;
            }

            if (ns.Value == m_model.TargetNamespace)
            {
                return null;
            }

            string externalPrefix = GetNamespacePrefix(ns.Value);

            template.WriteNextLine(context.Prefix);
            template.Write("using {0};", externalPrefix);

            return null;
        }
        #endregion

        #region "// ListOfTypes"
        /// <summary>
        /// Loads the template for a C# implementation of a type.
        /// </summary>
        private string LoadTemplate_ListOfTypes(Template template, Context context)
        {
            NodeDesign node = context.Target as NodeDesign;

            DataTypeDesign datatype = context.Target as DataTypeDesign;

            if (datatype != null)
            {
                switch (datatype.BasicDataType)
                {
                    case BasicDataType.Structure:
                    {
                        return null;
                    }

                    case BasicDataType.UserDefined:
                    {
                        if (GetBaseClassName(datatype) == "IEncodeable")
                        {
                            return TemplatePath + "Version2.DataTypes.Class.cs";
                        }

                        return TemplatePath + "Version2.DataTypes.DerivedClass.cs";
                    }

                    case BasicDataType.Enumeration:
                    {
                        return TemplatePath + "Version2.DataTypes.Enumeration.cs";
                    }

                    default:
                    {
                        if (datatype.IsOptionSet)
                        {
                            return TemplatePath + "Version2.DataTypes.Enumeration.cs";
                        }

                        return null;
                    }
                }
            }

            // do not produce built in types.
            if (node.NumericId < 256 && node.SymbolicId.Namespace == DefaultNamespace)
            {
                return null;
            }

            ObjectTypeDesign objectType = context.Target as ObjectTypeDesign;

            if (objectType != null)
            {
                return TemplatePath + "Version2.ObjectType.cs";
            }

            VariableTypeDesign variableType = context.Target as VariableTypeDesign;

            if (variableType != null)
            {
                return TemplatePath + "Version2.VariableType.cs";
            }

            MethodDesign method = context.Target as MethodDesign;

            if (method != null && method.HasArguments)
            {
                return TemplatePath + "Version2.MethodType.cs";
            }

            return null;
        }

        /// <summary>
        /// Writes the code for a C# implementation of a type.
        /// </summary>
        private bool WriteTemplate_ListOfTypes(Template template, Context context)
        {
            // handle object or variable type.
            NodeDesign node = context.Target as NodeDesign;

            if (node == null)
            {
                return false;
            }

            Array children = GetFields(node);

            template.AddReplacement("_NodeClass_", GetNodeClass(node));
            template.AddReplacement("_Description_", node.Description.Value);

            template.AddReplacement("_TypeName_", node.SymbolicName.Name);
            template.AddReplacement("_NamespaceUri_", GetConstantForNamespace(node.SymbolicName.Namespace));
            template.AddReplacement("_NamespacePrefix_", GetNamespacePrefix(node.SymbolicId.Namespace));
            template.AddReplacement("_XmlNamespaceUri_", GetConstantForXmlNamespace(node.SymbolicId.Namespace));

            template.AddReplacement("_BrowseName_", node.SymbolicName.Name);
            template.AddReplacement("_BrowseNameNamespacePrefix_", GetNamespacePrefix(node.SymbolicName.Namespace));
            template.AddReplacement("_BrowseNameNamespaceUri_", GetConstantForNamespace(node.SymbolicName.Namespace));

            TypeDesign type = context.Target as TypeDesign;

            if (type != null)
            {
                template.AddReplacement("_ClassName_", type.ClassName);
                template.AddReplacement("_BaseType_", GetBaseClassName(type));
                template.AddReplacement("_BaseTypeNamespacePrefix_", GetNamespacePrefix(type.BaseTypeNode.SymbolicId.Namespace));
                template.AddReplacement("_BaseTypeNamespaceUri_", GetConstantForNamespace(type.BaseTypeNode.SymbolicId.Namespace));
                template.AddReplacement("_BaseClassName_", FixClassName(type.BaseTypeNode));
            }

            MethodDesign method = context.Target as MethodDesign;

            if (method != null)
            {
                template.AddReplacement("_ClassName_", GetClassName(method));

                AddTemplate(
                    template,
                    "// ListOfInputArguments",
                    null,
                    method.InputArguments,
                    new LoadTemplateEventHandler(LoadTemplate_ListOfInputArguments),
                    null);

                AddTemplate(
                    template,
                    "_ISystemContext context_);",
                    null,
                    new MethodDesign[] { method },
                    new LoadTemplateEventHandler(LoadTemplate_OnCallDeclaration),
                    null);

                AddTemplate(
                    template,
                    "result = OnCall(context);",
                    null,
                    new MethodDesign[] { method },
                    new LoadTemplateEventHandler(LoadTemplate_OnCallImplementation),
                    null);

                AddTemplate(
                    template,
                    "// ListOfOutputDeclarations",
                    null,
                    method.OutputArguments,
                    new LoadTemplateEventHandler(LoadTemplate_ListOfOutputDeclarations),
                    null);

                AddTemplate(
                    template,
                    "// ListOfOutputArguments",
                    null,
                    method.OutputArguments,
                    new LoadTemplateEventHandler(LoadTemplate_ListOfOutputArguments),
                    null);
            }

            DataTypeDesign dataType = context.Target as DataTypeDesign;

            if (dataType != null)
            {
                if (!dataType.IsOptionSet)
                {
                    template.AddReplacement("[Flags]", String.Empty);
                }

                AddTemplate(
                    template,
                    "// ListOfEncodedFields",
                    null,
                    children,
                    new LoadTemplateEventHandler(LoadTemplate_ListOfEncodedFields),
                    null);

                AddTemplate(
                    template,
                    "// ListOfDecodedFields",
                    null,
                    children,
                    new LoadTemplateEventHandler(LoadTemplate_ListOfDecodedFields),
                    null);

                AddTemplate(
                    template,
                    "// ListOfComparedFields",
                    null,
                    children,
                    new LoadTemplateEventHandler(LoadTemplate_ListOfComparedFields),
                    null);

                AddTemplate(
                    template,
                    "// ListOfClonedFields",
                    null,
                    children,
                    new LoadTemplateEventHandler(LoadTemplate_ListOfClonedFields),
                    null);

                AddTemplate(
                    template,
                    "// CollectionClass",
                    TemplatePath + "Version2.DataTypes.CollectionClass.cs",
                    new DataTypeDesign[] { dataType },
                    new LoadTemplateEventHandler(LoadTemplate_CollectionClass),
                    new WriteTemplateEventHandler(WriteTemplate_CollectionClass));
            }

            ObjectTypeDesign objectType = context.Target as ObjectTypeDesign;

            if (objectType != null)
            {
                template.AddReplacement("<BaseT>", String.Empty);
                template.AddReplacement("_IsAbstract_", GetBooleanValue(objectType.IsAbstract));
                template.AddReplacement("_EventNotifier_", GetEventNotifier(objectType.SupportsEvents));
            }

            VariableTypeDesign variableType = context.Target as VariableTypeDesign;

            if (variableType != null)
            {
                BasicDataType basicType = variableType.DataTypeNode.BasicDataType;

                if (!TemplateParameterRequired(variableType.DataTypeNode, variableType.ValueRank))
                {
                    template.AddReplacement("<BaseT>", String.Empty);
                }
                else
                {
                    template.AddReplacement("<BaseT>", GetTemplateParameter1(variableType));
                }

                template.AddReplacement("_DefaultValue_", GetDefaultValue(variableType.DataTypeNode, variableType.ValueRank, variableType.DefaultValue, variableType.DecodedValue, false));
                template.AddReplacement("_ValueRank_", GetValueRank(variableType.ValueRank, variableType.ArrayDimensions));
                template.AddReplacement("_ArrayDimensions_", GetArrayDimensions(variableType.ValueRank, variableType.ArrayDimensions));
                template.AddReplacement("_IsAbstract_", GetBooleanValue(variableType.IsAbstract));
                template.AddReplacement("_AccessLevel_", GetAccessLevel(variableType.AccessLevel));
                template.AddReplacement("_MinimumSamplingInterval_", GetMinimumSamplingInterval(variableType.MinimumSamplingInterval));
                template.AddReplacement("_Historizing_", GetBooleanValue(variableType.Historizing));

                template.AddReplacement("_DataType_", variableType.DataTypeNode.SymbolicName.Name);
                template.AddReplacement("_DataTypeNamespacePrefix_", GetNamespacePrefix(variableType.DataTypeNode.SymbolicId.Namespace));
                template.AddReplacement("_DataTypeNamespaceUri_", GetConstantForNamespace(variableType.DataTypeNode.SymbolicId.Namespace));

                AddTemplate(
                    template,
                    "// TypedVariableType",
                    TemplatePath + "Version2.TypedVariableType.cs",
                    new VariableTypeDesign[] { variableType },
                    new LoadTemplateEventHandler(LoadTemplate_TypedVariableType),
                    new WriteTemplateEventHandler(WriteTemplate_TypedVariableType));

                AddTemplate(
                    template,
                    "// VariableTypeValue",
                    TemplatePath + "Version2.VariableTypeValue.cs",
                    new VariableTypeDesign[] { variableType },
                    new LoadTemplateEventHandler(LoadTemplate_VariableTypeValue),
                    new WriteTemplateEventHandler(WriteTemplate_VariableTypeValue));
            }

            AddTemplate(
                template,
                "// InitializationStringForType",
                null,
                new NodeDesign[] { node },
                new LoadTemplateEventHandler(LoadTemplate_InitializationString),
                null);

            AddTemplate(
                template,
                "// InitializeOptionalChildren",
                TemplatePath + "Version2.InitializeOptionalChild.cs",
                children,
                new LoadTemplateEventHandler(LoadTemplate_InitializeOptionalChildren),
                new WriteTemplateEventHandler(WriteTemplate_InitializeOptionalChildren));

            AddTemplate(
                template,
                "// InitializationString",
                null,
                new NodeDesign[] { node },
                new LoadTemplateEventHandler(LoadTemplate_InitializationString),
                null);

            AddTemplate(
                template,
                "// ListOfFieldsForType",
                null,
                children,
                new LoadTemplateEventHandler(LoadTemplate_ListOfFieldsForType),
                null);

            AddTemplate(
                template,
                "// ListOfFieldInitializers",
                null,
                children,
                new LoadTemplateEventHandler(LoadTemplate_ListOfFieldInitializers),
                null);

            AddTemplate(
                template,
                "// ListOfFields",
                null,
                children,
                new LoadTemplateEventHandler(LoadTemplate_ListOfFieldsForType),
                null);

            AddTemplate(
                template,
                "// ListOfPropertiesForType",
                TemplatePath + "Version2.Property.cs",
                children,
                new LoadTemplateEventHandler(LoadTemplate_ListOfPropertiesForType),
                new WriteTemplateEventHandler(WriteTemplate_ListOfPropertiesForType));

            AddTemplate(
                template,
                "// ListOfProperties",
                TemplatePath + "Version2.Property.cs",
                children,
                new LoadTemplateEventHandler(LoadTemplate_ListOfPropertiesForType),
                new WriteTemplateEventHandler(WriteTemplate_ListOfPropertiesForType));

            AddTemplate(
                template,
                "// FindChildMethodsForType",
                TemplatePath + "Version2.FindChildMethods.cs",
                new NodeDesign[] { type },
                new LoadTemplateEventHandler(LoadTemplate_FindChildMethods),
                new WriteTemplateEventHandler(WriteTemplate_FindChildMethods));

            AddTemplate(
                template,
                "// FindChildMethods",
                TemplatePath + "Version2.FindChildMethods.cs",
                new NodeDesign[] { type },
                new LoadTemplateEventHandler(LoadTemplate_FindChildMethods),
                new WriteTemplateEventHandler(WriteTemplate_FindChildMethods));

            return template.WriteTemplate(context);
        }
        #endregion

        #region "// InitializationString"
        private string LoadTemplate_InitializationString(Template template, Context context)
        {
            string xml = null;
            TypeDesign type = context.Target as TypeDesign;

            if (type != null)
            {
                xml = ConstructInitializer(type, !context.Token.EndsWith("ForType"));

                // output initializers for optional components.
                if (type.Children != null && type.Children.Items != null)
                {
                    for (int ii = 0; ii < type.Children.Items.Length; ii++)
                    {
                        InstanceDesign instance = type.Children.Items[ii];

                        if (instance.ModellingRule != ModellingRule.Optional)
                        {
                            continue;
                        }

                        foreach (HierarchyNode current in type.Hierarchy.NodeList)
                        {
                            if (current.RelativePath != instance.SymbolicName.Name)
                            {
                                continue;
                            }

                            template.WriteNextLine(context.Prefix);
                            template.Write("private const string {0}_InitializationString =", current.Instance.SymbolicName.Name);
                            string childXml = ConstructInitializer(current.Instance, false);
                            WriteInitializationString(template, context, childXml);
                            template.Write(";");
                            template.WriteNextLine(String.Empty);
                            break;
                        }
                    }
                }
            }

            MethodDesign method = context.Target as MethodDesign;

            if (method != null)
            {
                xml = ConstructInitializer(method, false);
            }

            if (xml == null)
            {
                return null;
            }

            template.WriteNextLine(context.Prefix);
            template.Write("private const string InitializationString =");
            WriteInitializationString(template, context, xml);
            template.Write(";");

            return context.TemplatePath;
        }

        /// <summary>
        /// Writes the initalization string.
        /// </summary>
        private void WriteInitializationString(Template template, Context context, string xml)
        {
            if (xml == null)
            {
                WriteInitializationStringLine(template, context, String.Empty);
                return;
            }

            if (!UseXmlInitializers)
            {
                for (int ii = 0; ii < xml.Length; ii += 80)
                {
                    if (ii > 0)
                    {
                        template.Write(" +");
                    }

                    if (ii + 80 >= xml.Length)
                    {
                        WriteInitializationStringLine(template, context, xml.Substring(ii));
                    }
                    else
                    {
                        WriteInitializationStringLine(template, context, xml.Substring(ii, 80));
                    }
                }

                return;
            }

            bool first = true;

            using (StringReader reader = new StringReader(xml))
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    line = line.Trim();

                    if (String.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    if (line.StartsWith("<?xml"))
                    {
                        continue;
                    }

                    if (!first)
                    {
                        template.Write(" +");
                    }

                    WriteInitializationStringLine(template, context, line);
                    first = false;
                }
            }
        }

        /// <summary>
        /// Writes the initalization string line.
        /// </summary>
        private void WriteInitializationStringLine(Template template, Context context, string line)
        {
            template.WriteNextLine(context.Prefix);
            template.Write(template.Indent);
            template.Write("   \"");

            for (int ii = 0; ii < line.Length; ii++)
            {
                if (line[ii] == '"')
                {
                    template.Write("\\\"");
                    continue;
                }

                if (line[ii] == '\\')
                {
                    template.Write("\\\\");
                    continue;
                }

                template.Write(line[ii]);
            }

            template.Write("\"");
        }
        #endregion

        #region "// TypedVariableType"
        private string LoadTemplate_TypedVariableType(Template template, Context context)
        {
            VariableTypeDesign variableType = context.Target as VariableTypeDesign;

            if (variableType == null)
            {
                return null;
            }

            if (TemplateParameterRequired(variableType.DataTypeNode, variableType.ValueRank))
            {
                return null;
            }

            return context.TemplatePath;
        }

        private bool WriteTemplate_TypedVariableType(Template template, Context context)
        {
            VariableTypeDesign type = context.Target as VariableTypeDesign;

            if (type == null)
            {
                return false;
            }

            template.WriteLine(String.Empty);

            template.AddReplacement("_NodeClass_", GetNodeClass(type));
            template.AddReplacement("_ClassName_", type.ClassName);
            template.AddReplacement("_TypeName_", type.SymbolicName.Name);
            template.AddReplacement("_BrowseName_", type.SymbolicName.Name);

            return template.WriteTemplate(context);
        }
        #endregion

        #region "// VariableTypeValue"
        private string LoadTemplate_VariableTypeValue(Template template, Context context)
        {
            VariableTypeDesign variableType = context.Target as VariableTypeDesign;

            if (variableType == null)
            {
                return null;
            }

            Dictionary<string,Parameter> fields = new Dictionary<string,Parameter>();
            CollectMatchingFields(variableType, fields);

            if (fields.Count == 0)
            {
                return null;
            }

            return context.TemplatePath;
        }

        private void CollectMatchingFields(VariableTypeDesign variableType, Dictionary<string, Parameter> fields)
        {
            CollectFields(variableType.DataTypeNode, variableType.ValueRank, String.Empty, fields);

            List<string> availablePaths = new List<string>(fields.Keys);

            for (int ii = 0; ii < availablePaths.Count; ii++)
            {
                if (!variableType.Hierarchy.Nodes.ContainsKey(availablePaths[ii]))
                {
                    fields.Remove(availablePaths[ii]);
                }
            }
        }

        private void CollectFields(DataTypeDesign dataType, ValueRank valueRank, string basePath, Dictionary<string, Parameter> fields)
        {
            if (dataType.BasicDataType != BasicDataType.UserDefined || valueRank != ValueRank.Scalar)
            {
                return;
            }

            for (DataTypeDesign parent = dataType; parent != null; parent = parent.BaseTypeNode as DataTypeDesign)
            {
                if (parent.Fields != null)
                {
                    for (int ii = 0; ii < parent.Fields.Length; ii++)
                    {
                        Parameter parameter = parent.Fields[ii];
                        string fieldPath = parameter.Name;

                        if (!String.IsNullOrEmpty(basePath))
                        {
                            fieldPath = Utils.Format("{0}_{1}", basePath, parameter.Name);
                        }

                        fields[fieldPath] = parameter;
                        CollectFields(parameter.DataTypeNode, parameter.ValueRank, fieldPath, fields);
                    }
                }
            }
        }

        private bool WriteTemplate_VariableTypeValue(Template template, Context context)
        {
            VariableTypeDesign type = context.Target as VariableTypeDesign;

            if (type == null)
            {
                return false;
            }

            Dictionary<string, Parameter> fields = new Dictionary<string, Parameter>();
            CollectMatchingFields(type, fields);

            if (fields.Count == 0)
            {
                return false;
            }

            template.WriteLine(String.Empty);

            template.AddReplacement("_ClassName_", type.ClassName);
            template.AddReplacement("_DataType_", GetSystemTypeName(type.DataTypeNode, ValueRank.Scalar));

            AddTemplate(
                template,
                "// ListOfChildInitializers",
                null,
                fields,
                new LoadTemplateEventHandler(WriteTemplate_VariableTypeValueInitializers),
                null);

            AddTemplate(
                template,
                "// ListOfChildMethods",
                TemplatePath + "Version2.VariableTypeValueField.cs",
                fields,
                null,
                new WriteTemplateEventHandler(WriteTemplate_VariableTypeValueField));

            return template.WriteTemplate(context);
        }

        #region "// ListOfChildInitializers"
        private string WriteTemplate_VariableTypeValueInitializers(Template template, Context context)
        {
            KeyValuePair<string, Parameter>? field = context.Target as KeyValuePair<string, Parameter>?;

            if (field == null)
            {
                return null;
            }

            if (!context.FirstInList)
            {
                template.WriteNextLine(context.Prefix);
            }

            string name = field.Value.Key;
            string path = field.Value.Key.Replace('_', '.');

            template.WriteNextLine(context.Prefix);
            template.Write("instance = m_variable.{0};", path);

            template.WriteNextLine(context.Prefix);
            template.Write("instance.OnReadValue = OnRead_{0};", name);

            template.WriteNextLine(context.Prefix);
            template.Write("instance.OnSimpleWriteValue = OnWrite_{0};", name);

            template.WriteNextLine(context.Prefix);
            template.Write("updateList.Add(instance);");

            return context.TemplatePath;
        }
        #endregion

        #region "// ListOfChildMethods"
        private bool WriteTemplate_VariableTypeValueField(Template template, Context context)
        {
            KeyValuePair<string,Parameter>? field = context.Target as KeyValuePair<string,Parameter>?;

            if (field == null)
            {
                return false;
            }

            template.AddReplacement("_ChildName_", field.Value.Key);
            template.AddReplacement("_ChildPath_", field.Value.Key.Replace('_', '.'));
            template.AddReplacement("_ChildDataType_", GetSystemTypeName(field.Value.Value.DataTypeNode, field.Value.Value.ValueRank));

            return template.WriteTemplate(context);
        }
        #endregion
        #endregion

        #region "// CollectionClass"
        private string LoadTemplate_CollectionClass(Template template, Context context)
        {
            DataTypeDesign dataType = context.Target as DataTypeDesign;

            if (dataType == null)
            {
                return null;
            }

            if (dataType.NoArraysAllowed)
            {
                return null;
            }

            return context.TemplatePath;
        }

        private bool WriteTemplate_CollectionClass(Template template, Context context)
        {
            DataTypeDesign dataType = context.Target as DataTypeDesign;

            if (dataType == null)
            {
                return false;
            }

            template.WriteLine(String.Empty);
            template.AddReplacement("_XmlNamespaceUri_", GetConstantForXmlNamespace(dataType.SymbolicId.Namespace));
            template.AddReplacement("_BrowseName_", dataType.SymbolicName.Name);

            return template.WriteTemplate(context);
        }
        #endregion

        #region "// ListOfFieldsForType and // ListOfFields"
        /// <summary>
        /// Loads the template for a C# field declaration.
        /// </summary>
        private string LoadTemplate_ListOfFieldsForType(Template template, Context context)
        {
            InstanceDesign instance = context.Target as InstanceDesign;

            if (instance == null)
            {
                Parameter field = context.Target as Parameter;

                if (field == null)
                {
                    return null;
                }

                template.WriteNextLine(context.Prefix);
                template.Write("private {0} {1};", GetSystemTypeName(field.DataTypeNode, field.ValueRank), GetChildFieldName(field));

                return context.TemplatePath;
            }

            if (IsOverridden(instance))
            {
                return null;
            }

            if (instance.ModellingRule == ModellingRule.ExposesItsArray || instance.ModellingRule == ModellingRule.MandatoryPlaceholder || instance.ModellingRule == ModellingRule.OptionalPlaceholder)
            {
                return null;
            }

            MethodDesign method = instance as MethodDesign;

            if (!context.Token.EndsWith("ForType"))
            {
                if (instance.ModellingRule == ModellingRule.None)
                {
                    return null;
                }

                if (method != null && method.ModellingRule != ModellingRule.Mandatory && method.ModellingRule != ModellingRule.Optional)
                {
                    return null;
                }
            }

            if (IsBuiltInProperty(instance))
            {
                return null;
            }

            template.WriteNextLine(context.Prefix);
            template.Write("private {0} {1};", GetClassName(instance), GetChildFieldName(instance));

            return context.TemplatePath;
        }
        #endregion

        #region "// ListOfEncodedFields"
        private string LoadTemplate_ListOfEncodedFields(Template template, Context context)
        {
            Parameter field = context.Target as Parameter;

            if (field == null)
            {
                return null;
            }

            template.WriteNextLine(context.Prefix);

            string functionName = field.DataTypeNode.BasicDataType.ToString();
            string valueName = field.Name;
            string elementName = null;

            switch (field.DataTypeNode.BasicDataType)
            {
                case BasicDataType.Number:
                case BasicDataType.Integer:
                case BasicDataType.UInteger:
                case BasicDataType.BaseDataType:
                {
                    functionName = "Variant";
                    break;
                }

                case BasicDataType.Structure:
                {
                    functionName = "ExtensionObject";
                    break;
                }

                case BasicDataType.Enumeration:
                {
                    if (field.DataType == new XmlQualifiedName("Enumeration", DefaultNamespace))
                    {
                        functionName = "Int32";
                        break;
                    }

                    functionName = "Enumerated";

                    if (field.ValueRank == ValueRank.Array)
                    {
                        elementName = GetSystemTypeName(field.DataTypeNode, ValueRank.Scalar);
                        template.Write("encoder.WriteEnumeratedArray(\"{0}\", {0}.ToArray(), typeof({1}));", field.Name, elementName);
                        return context.TemplatePath;
                    }

                    break;
                }

                case BasicDataType.UserDefined:
                {
                    functionName = "Encodeable";
                    elementName = GetSystemTypeName(field.DataTypeNode, ValueRank.Scalar);

                    if (field.ValueRank == ValueRank.Array)
                    {
                        template.Write("encoder.WriteEncodeableArray(\"{0}\", {0}.ToArray(), typeof({1}));", field.Name, elementName);
                        return context.TemplatePath;
                    }

                    break;
                }
            }

            if (field.ValueRank == ValueRank.Array)
            {
                functionName += "Array";
            }
            else if (field.ValueRank != ValueRank.Scalar)
            {
                functionName = "Variant";
                elementName = null;
            }

            template.Write("encoder.Write{0}(\"{1}\", {2}", functionName, field.Name, valueName);

            if (elementName != null)
            {
                template.Write(", typeof({0})", elementName);
            }

            template.Write(");");

            return context.TemplatePath;
        }
        #endregion

        #region "// ListOfDecodedFields"
        private string LoadTemplate_ListOfDecodedFields(Template template, Context context)
        {
            Parameter field = context.Target as Parameter;

            if (field == null)
            {
                return null;
            }

            template.WriteNextLine(context.Prefix);

            string functionName = field.DataTypeNode.BasicDataType.ToString();
            string valueName = field.Name;
            string elementName = null;

            switch (field.DataTypeNode.BasicDataType)
            {
                case BasicDataType.Number:
                case BasicDataType.Integer:
                case BasicDataType.UInteger:
                case BasicDataType.BaseDataType:
                {
                    functionName = "Variant";
                    break;
                }

                case BasicDataType.Structure:
                {
                    functionName = "ExtensionObject";
                    break;
                }

                case BasicDataType.Enumeration:
                {
                    if (field.DataType == new XmlQualifiedName("Enumeration", DefaultNamespace))
                    {
                        functionName = "Int32";
                        break;
                    }

                    functionName = "Enumerated";
                    elementName = GetSystemTypeName(field.DataTypeNode, ValueRank.Scalar);
                    break;
                }

                case BasicDataType.UserDefined:
                {
                    functionName = "Encodeable";
                    elementName = GetSystemTypeName(field.DataTypeNode, ValueRank.Scalar);
                    break;
                }
            }

            if (field.ValueRank == ValueRank.Array)
            {
                functionName += "Array";
            }
            else if (field.ValueRank != ValueRank.Scalar)
            {
                functionName = "Variant";
                elementName = null;
            }

            template.Write("{0} = ", valueName);

            if (elementName != null)
            {
                if (field.ValueRank == ValueRank.Array)
                {
                    template.Write("({0}Collection)", elementName);
                }
                else
                {
                    template.Write("({0})", elementName);
                }

                template.Write("decoder.Read{0}(\"{1}\", typeof({2}));", functionName, field.Name, elementName);
            }
            else
            {
                template.Write("decoder.Read{0}(\"{1}\");", functionName, field.Name);
            }

            return context.TemplatePath;
        }
        #endregion

        #region "// ListOfComparedFields"
        private string LoadTemplate_ListOfComparedFields(Template template, Context context)
        {
            Parameter field = context.Target as Parameter;

            if (field == null)
            {
                return null;
            }

            if (context.Index == 0)
            {
                DataTypeDesign dataType = field.Parent as DataTypeDesign;

                if (dataType != null && dataType.BaseType != new XmlQualifiedName("Structure", DefaultNamespace))
                {
                    template.WriteNextLine(context.Prefix);
                    template.Write("if (!base.IsEqual(encodeable)) return false;");
                }
            }


            template.WriteNextLine(context.Prefix);
            template.Write("if (!Utils.IsEqual({0}, value.{0})) return false;", GetChildFieldName(field));

            return context.TemplatePath;
        }
        #endregion

        #region "// ListOfClonedFields"
        private string LoadTemplate_ListOfClonedFields(Template template, Context context)
        {
            Parameter field = context.Target as Parameter;

            if (field == null)
            {
                return null;
            }

            template.WriteNextLine(context.Prefix);
            template.Write("clone.{0} = ({1})Utils.Clone(this.{0});", GetChildFieldName(field), GetSystemTypeName(field.DataTypeNode, field.ValueRank));

            return context.TemplatePath;
        }
        #endregion

        #region "// ListOfInputArguments"
        private string LoadTemplate_ListOfInputArguments(Template template, Context context)
        {
            Parameter field = context.Target as Parameter;

            if (field == null)
            {
                return null;
            }

            if (context.Index == 0)
            {
                template.WriteNextLine(String.Empty);
            }

            template.WriteNextLine(context.Prefix);

            string format = "{1} {0} = ({1})inputArguments[{2}];";

            if (field.DataTypeNode.BasicDataType == BasicDataType.UserDefined)
            {
                if (field.ValueRank == ValueRank.Scalar)
                {
                    format = "{1} {0} = ({1})ExtensionObject.ToEncodeable((ExtensionObject)inputArguments[{2}]);";
                }
                else
                {
                    format = "{1} {0} = ({1})ExtensionObject.ToArray(inputArguments[{2}], typeof(" + GetMethodArgumentType(field.DataTypeNode, ValueRank.Scalar) + "));";
                }
            }

            template.Write(
                format,
                GetChildFieldName(field).Substring(2),
                GetMethodArgumentType(field.DataTypeNode, field.ValueRank),
                context.Index);

            return context.TemplatePath;
        }
        #endregion

        #region "// ListOfOutputDeclarations"
        private string LoadTemplate_ListOfOutputDeclarations(Template template, Context context)
        {
            Parameter field = context.Target as Parameter;

            if (field == null)
            {
                return null;
            }

            if (context.Index == 0)
            {
                template.WriteNextLine(String.Empty);
            }

            template.WriteNextLine(context.Prefix);

            template.Write(
                "{1} {0} = ({1})outputArguments[{2}];",
                GetChildFieldName(field).Substring(2),
                GetMethodArgumentType(field.DataTypeNode, field.ValueRank),
                context.Index);

            return context.TemplatePath;
        }
        #endregion

        #region "// ListOfOutputArguments"
        private string LoadTemplate_ListOfOutputArguments(Template template, Context context)
        {
            Parameter field = context.Target as Parameter;

            if (field == null)
            {
                return null;
            }

            if (context.Index == 0)
            {
                template.WriteNextLine(String.Empty);
            }

            template.WriteNextLine(context.Prefix);

            template.Write(
                "outputArguments[{1}] = {0};",
                GetChildFieldName(field).Substring(2),
                context.Index);

            return context.TemplatePath;
        }
        #endregion

        #region "_ISystemContext context_);"
        private string LoadTemplate_OnCallDeclaration(Template template, Context context)
        {
            MethodDesign method = context.Target as MethodDesign;

            if (method == null)
            {
                return null;
            }

            template.WriteNextLine(context.Prefix);
            template.Write("ISystemContext context,");

            template.WriteNextLine(context.Prefix);
            template.Write("MethodState method,");

            template.WriteNextLine(context.Prefix);
            template.Write("NodeId objectId");

            if (method.InputArguments != null)
            {
                for (int ii = 0; ii < method.InputArguments.Length; ii++)
                {
                    Parameter argument = method.InputArguments[ii];

                    template.Write(",");
                    template.WriteNextLine(context.Prefix);
                    template.Write("{1} {0}", GetChildFieldName(argument).Substring(2), GetMethodArgumentType(argument.DataTypeNode, argument.ValueRank));
                }
            }

            if (method.OutputArguments != null)
            {
                for (int ii = 0; ii < method.OutputArguments.Length; ii++)
                {
                    Parameter argument = method.OutputArguments[ii];

                    template.Write(",");
                    template.WriteNextLine(context.Prefix);
                    template.Write("ref {1} {0}", GetChildFieldName(argument).Substring(2), GetMethodArgumentType(argument.DataTypeNode, argument.ValueRank));
                }
            }

            template.Write(");");

            return context.TemplatePath;
        }
        #endregion

        #region "result = OnCall(context);"
        private string LoadTemplate_OnCallImplementation(Template template, Context context)
        {
            MethodDesign method = context.Target as MethodDesign;

            if (method == null)
            {
                return null;
            }

            template.WriteNextLine(context.Prefix);
            template.Write("result = OnCall(");

            template.WriteNextLine(context.Prefix);
            template.Write("    context,");

            template.WriteNextLine(context.Prefix);
            template.Write("    this,");

            template.WriteNextLine(context.Prefix);
            template.Write("    objectId");

            if (method.InputArguments != null)
            {
                for (int ii = 0; ii < method.InputArguments.Length; ii++)
                {
                    template.Write(",");
                    template.WriteNextLine(context.Prefix);
                    template.Write("    {0}", GetChildFieldName(method.InputArguments[ii]).Substring(2));
                }
            }

            if (method.OutputArguments != null)
            {
                for (int ii = 0; ii < method.OutputArguments.Length; ii++)
                {
                    template.Write(",");
                    template.WriteNextLine(context.Prefix);
                    template.Write("    ref {0}", GetChildFieldName(method.OutputArguments[ii]).Substring(2));
                }
            }

            template.Write(");");

            return context.TemplatePath;
        }
        #endregion

        #region "// ListOfFieldInitializers"
        private string LoadTemplate_ListOfFieldInitializers(Template template, Context context)
        {
            Parameter field = context.Target as Parameter;

            if (field == null)
            {
                return null;
            }

            template.WriteNextLine(context.Prefix);
            template.Write("{0} = {1};", GetChildFieldName(field), GetDefaultValue(field.DataTypeNode, field.ValueRank, null, null, true));

            return context.TemplatePath;
        }
        #endregion

        #region "// InitializeOptionalChildren"
        private string LoadTemplate_InitializeOptionalChildren(Template template, Context context)
        {
            InstanceDesign instance = context.Target as InstanceDesign;

            if (instance == null)
            {
                return null;
            }

            if (instance.ModellingRule != ModellingRule.Optional)
            {
                return null;
            }

            if (IsBuiltInProperty(instance))
            {
                return null;
            }

            return context.TemplatePath;
        }

        private bool WriteTemplate_InitializeOptionalChildren(Template template, Context context)
        {
            InstanceDesign instance = context.Target as InstanceDesign;

            if (instance == null)
            {
                return template.WriteTemplate(context);
            }

            if (context.FirstInList)
            {
                template.WriteNextLine(String.Empty);
            }

            template.AddReplacement("_ChildName_", instance.SymbolicName.Name);

            return template.WriteTemplate(context);
        }
        #endregion

        #region "// ListOfPropertiesForType and // ListOfProperties"
        private string LoadTemplate_ListOfPropertiesForType(Template template, Context context)
        {
            InstanceDesign instance = context.Target as InstanceDesign;

            if (instance == null)
            {
                Parameter field = context.Target as Parameter;

                if (field != null)
                {
                    DataTypeDesign dataType = field.Parent as DataTypeDesign;

                    if (dataType.BasicDataType != BasicDataType.Enumeration)
                    {
                        if (field.DataTypeNode.BasicDataType == BasicDataType.UserDefined || field.ValueRank == ValueRank.Array)
                        {
                            return TemplatePath + "Version2.DataTypes.ArrayProperty.cs";
                        }

                        return TemplatePath + "Version2.DataTypes.Property.cs";
                    }

                    return TemplatePath + "Version2.DataTypes.EnumerationValue.cs";
                }

                return null;
            }

            if (instance.ModellingRule == ModellingRule.ExposesItsArray || instance.ModellingRule == ModellingRule.MandatoryPlaceholder || instance.ModellingRule == ModellingRule.OptionalPlaceholder)
            {
                return null;
            }

            MethodDesign method = instance as MethodDesign;

            if (!context.Token.EndsWith("ForType"))
            {
                if (instance.ModellingRule == ModellingRule.None)
                {
                    return null;
                }

                if (method != null && method.ModellingRule != ModellingRule.Mandatory && method.ModellingRule != ModellingRule.Optional)
                {
                    return null;
                }
            }

            if (IsOverridden(instance))
            {
                if (IsOverriddenWithSameClass(instance))
                {
                    return null;
                }

                return TemplatePath + "Version2.PropertyOverride.cs";
            }

            if (IsBuiltInProperty(instance))
            {
                return null;
            }

            return context.TemplatePath;
        }

        private bool IsOverridden(InstanceDesign instance)
        {
            if (instance.OveriddenNode != null && instance.ModellingRule != ModellingRule.None && instance.ModellingRule != ModellingRule.ExposesItsArray && instance.ModellingRule != ModellingRule.MandatoryPlaceholder && instance.ModellingRule != ModellingRule.OptionalPlaceholder)
            {
                return true;
            }

            return false;
        }

        private bool IsOverriddenWithSameClass(InstanceDesign instance)
        {
            if (!IsOverridden(instance))
            {
                return false;
            }

            string x = GetClassName(GetMergedInstance(instance));
            string y = GetClassName(instance.OveriddenNode);

            return x == y;
        }

        /// <summary>
        /// Returns the merged instance for an overriden node.
        /// </summary>
        private InstanceDesign GetMergedInstance(InstanceDesign instance)
        {
            for (NodeDesign parent = instance.Parent; parent != null; parent = parent.Parent)
            {
                if (parent.Parent == null && parent.Hierarchy != null)
                {
                    string relativePath = instance.SymbolicId.Name;

                    int index = relativePath.IndexOf('_');

                    if (index != -1)
                    {
                        relativePath = relativePath.Substring(index + 1);
                    }

                    HierarchyNode hierarchyNode = null;

                    if (parent.Hierarchy.Nodes.TryGetValue(relativePath, out hierarchyNode))
                    {
                        if (hierarchyNode.Instance is InstanceDesign)
                        {
                            return (InstanceDesign)hierarchyNode.Instance;
                        }
                    }

                    break;
                }
            }

            return instance;
        }

        private bool WriteTemplate_ListOfPropertiesForType(Template template, Context context)
        {
            InstanceDesign instance = context.Target as InstanceDesign;

            if (instance == null)
            {
                Parameter field = context.Target as Parameter;

                if (field == null)
                {
                    return false;
                }

                bool valueType = false;

                switch (field.DataTypeNode.BasicDataType)
                {
                    case BasicDataType.String:
                    case BasicDataType.ByteString:
                    case BasicDataType.DiagnosticInfo:
                    case BasicDataType.ExpandedNodeId:
                    case BasicDataType.LocalizedText:
                    case BasicDataType.NodeId:
                    case BasicDataType.QualifiedName:
                    case BasicDataType.Guid:
                    case BasicDataType.XmlElement:
                    case BasicDataType.StatusCode:
                    case BasicDataType.Structure:
                    case BasicDataType.UserDefined:
                    case BasicDataType.DataValue:
                    {
                        valueType = false;
                        break;
                    }

                    default:
                    {
                        if (field.ValueRank != ValueRank.Scalar)
                        {
                            valueType = false;
                        }

                        break;
                    }
                }

                bool emitDefaultValue = true;

                template.AddReplacement("_Description_", field.Description.Value);
                template.AddReplacement("_BrowseName_", field.Name);
                template.AddReplacement("_TypeName_", GetSystemTypeName(field.DataTypeNode, field.ValueRank));
                template.AddReplacement("_FieldName_", GetChildFieldName(field));
                template.AddReplacement("_IsRequired_", (valueType) ? "true" : "false");
                template.AddReplacement(", EmitDefaultValue = _EmitDefaultValue_", (emitDefaultValue) ? "" : ", EmitDefaultValue = false");
                template.AddReplacement("_FieldIndex_", Utils.Format("{0}", context.Index + 1));
                template.AddReplacement("_DefaultValue_", GetDefaultValue(field.DataTypeNode, field.ValueRank, null, null, true));
                template.AddReplacement("_Identifier_", field.Identifier.ToString());

                if (field.IdentifierInName)
                {
                    template.AddReplacement("_XmlIdentifier_", field.Name);
                }
                else
                {
                    template.AddReplacement("_XmlIdentifier_", String.Format("{0}_{1}", field.Name, field.Identifier));
                }

                return template.WriteTemplate(context);
            }

            if (!IsOverridden(instance))
            {
                template.AddReplacement("public new", "public");
            }
            else
            {
                instance = GetMergedInstance(instance);
            }

            template.AddReplacement("_Description_", instance.Description.Value);
            template.AddReplacement("_ClassName_", GetClassName(instance));
            template.AddReplacement("_ChildName_", instance.SymbolicName.Name);
            template.AddReplacement("_FieldName_", GetChildFieldName(instance));

            return template.WriteTemplate(context);
        }
        #endregion

        #region "// FindChildMethods"
        private string LoadTemplate_FindChildMethods(Template template, Context context)
        {
            TypeDesign type = context.Target as TypeDesign;

            if (type == null)
            {
                return null;
            }

            if (type is DataTypeDesign)
            {
                return null;
            }

            Array children = GetChildren1(type.Children);

            if (children.Length == 0)
            {
                return null;
            }

            int count = 0;

            for (int ii = 0; ii < children.Length; ii++)
            {
                InstanceDesign instance = (InstanceDesign)children.GetValue(ii);

                if (instance.ModellingRule == ModellingRule.ExposesItsArray || instance.ModellingRule == ModellingRule.MandatoryPlaceholder || instance.ModellingRule == ModellingRule.OptionalPlaceholder)
                {
                    continue;
                }

                if (!context.Token.EndsWith("ForType"))
                {
                    if (instance.ModellingRule == ModellingRule.None)
                    {
                        continue;
                    }
                }

                if (IsOverriddenWithSameClass(instance))
                {
                    continue;
                }

                count++;
            }

            if (count == 0)
            {
                return null;
            }

            return context.TemplatePath;
        }

        private bool WriteTemplate_FindChildMethods(Template template, Context context)
        {
            TypeDesign type = context.Target as TypeDesign;

            if (type == null)
            {
                return false;
            }

            Array children = GetChildren1(type.Children);

            List<InstanceDesign> childrenToUse = new List<InstanceDesign>();

            for (int ii = 0; ii < children.Length; ii++)
            {
                InstanceDesign instance = (InstanceDesign)children.GetValue(ii);

                if (context.Token.EndsWith("ForType"))
                {
                    childrenToUse.Add(instance);
                    continue;
                }

                if (instance.ModellingRule != ModellingRule.Mandatory && instance.ModellingRule != ModellingRule.Optional)
                {
                    continue;
                }

                if (IsOverriddenWithSameClass(instance))
                {
                    continue;
                }

                childrenToUse.Add(instance);
            }

            AddTemplate(
                template,
                "// ListOfFindChildCase",
                TemplatePath + "Version2.FindChildCase.cs",
                childrenToUse,
                new LoadTemplateEventHandler(LoadTemplate_ListOfFindChildCase),
                new WriteTemplateEventHandler(WriteTemplate_ListOfFindChildCase));

            childrenToUse = new List<InstanceDesign>();

            for (int ii = 0; ii < children.Length; ii++)
            {
                InstanceDesign instance = (InstanceDesign)children.GetValue(ii);

                if (instance.ModellingRule != ModellingRule.Mandatory && instance.ModellingRule != ModellingRule.Optional)
                {
                    continue;
                }

                if (IsOverridden(instance))
                {
                    continue;
                }

                if (context.Token.EndsWith("ForType"))
                {
                    childrenToUse.Add(instance);
                    continue;
                }

                childrenToUse.Add(instance);
            }

            AddTemplate(
                template,
                "// ListOfFindChildren",
                TemplatePath + "Version2.FindChildren.cs",
                childrenToUse,
                new LoadTemplateEventHandler(LoadTemplate_ListOfFindChildCase),
                new WriteTemplateEventHandler(WriteTemplate_ListOfFindChildCase));

            return template.WriteTemplate(context);
        }
        #endregion

        #region "// ListOfFindChildCase"
        private string LoadTemplate_ListOfFindChildCase(Template template, Context context)
        {
            InstanceDesign instance = context.Target as InstanceDesign;

            if (instance == null)
            {
                return null;
            }

            return context.TemplatePath;
        }

        private bool WriteTemplate_ListOfFindChildCase(Template template, Context context)
        {
            InstanceDesign instance = context.Target as InstanceDesign;

            if (instance == null)
            {
                return false;
            }

            TypeDesign type = instance.Parent as TypeDesign;

            if (type != null)
            {
                template.AddReplacement("_TypeName_", type.SymbolicName.Name);
            }

            template.AddReplacement("_ClassName_", GetClassName(instance));
            template.AddReplacement("_ChildName_", instance.SymbolicName.Name);
            template.AddReplacement("_FieldName_", GetChildFieldName(instance));
            template.AddReplacement("_NodeClass_", GetNodeClass(instance));

            template.AddReplacement("_BrowseName_", instance.SymbolicName.Name);
            template.AddReplacement("_BrowseNameNamespacePrefix_", GetNamespacePrefix(instance.SymbolicName.Namespace));
            template.AddReplacement("_BrowseNameNamespaceUri_", GetConstantForNamespace(instance.SymbolicName.Namespace));

            return template.WriteTemplate(context);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Checks if the instance is a built in property that should not be generatd.
        /// </summary>
        private bool IsBuiltInProperty(InstanceDesign instance)
        {
            if (instance == null)
            {
                return true;
            }

            MethodDesign method = instance.Parent as MethodDesign;

            if (method != null)
            {
                if (instance.SymbolicName == new XmlQualifiedName("InputArguments", DefaultNamespace))
                {
                    return true;
                }

                if (instance.SymbolicName == new XmlQualifiedName("OutputArguments", DefaultNamespace))
                {
                    return true;
                }
            }

            VariableDesign variable = instance.Parent as VariableDesign;

            if (variable != null)
            {
                if (instance.SymbolicName == new XmlQualifiedName("EnumStrings", DefaultNamespace))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns the children for the type.
        /// </summary>
        private Array GetFields(NodeDesign node)
        {
            DataTypeDesign dataType = node as DataTypeDesign;

            if (dataType != null)
            {
                List<Parameter> fields = new List<Parameter>();

                if (dataType.Fields == null)
                {
                    return fields.ToArray();
                }

                foreach (Parameter child in dataType.Fields)
                {
                    fields.Add(child);
                }

                return fields.ToArray();
            }

            return GetChildren1(node.Children);
        }

        /// <summary>
        /// Returns the children for the type.
        /// </summary>
        private Array GetChildren1(ListOfChildren children)
        {
            List<InstanceDesign> selectedChildren = new List<InstanceDesign>();

            if (children == null)
            {
                return selectedChildren.ToArray();
            }

            if (children.Items != null)
            {
                foreach (InstanceDesign child in children.Items)
                {
                    selectedChildren.Add(child);
                }
            }

            return selectedChildren.ToArray();
        }

        /// <summary>
        /// Returns the class name to use when creating an instance of the type.
        /// </summary>
        private string GetClassName(InstanceDesign instance)
        {
            MethodDesign method = instance as MethodDesign;

            if (method != null)
            {
                string className = method.SymbolicName.Name;

                if (method.TypeDefinition != null)
                {
                    className = method.TypeDefinition.Name;
                }

                if (className.EndsWith("MethodType"))
                {
                    className = className.Substring(0, className.Length - "MethodType".Length);
                }

                if (className.EndsWith("Type"))
                {
                    className = className.Substring(0, className.Length - "Type".Length);
                }

                if (method.HasArguments)
                {
                    return String.Format("{0}MethodState", className);
                }

                return "MethodState";
            }

            VariableDesign variable = instance as VariableDesign;

            if (variable == null)
            {
                return String.Format("{0}State", FixClassName(instance.TypeDefinitionNode));
            }

            VariableTypeDesign variableType = instance.TypeDefinitionNode as VariableTypeDesign;

            // check if the variable type restricted the datatype to eliminate the need for a template parameter.
            if (TemplateParameterRequired(variableType.DataTypeNode, variableType.ValueRank))
            {
                return String.Format("{0}State", FixClassName(variableType));
            }

            // check if the variable instance did not restrict the datatype.
            if (!TemplateParameterRequired(variable.DataTypeNode, variable.ValueRank))
            {
                return String.Format("{0}State", FixClassName(variableType));
            }

            // instance restricted the datatype but the type did not not.
            BasicDataType basicType = variable.DataTypeNode.BasicDataType;

            string scalarName = null;

            switch (basicType)
            {
                case BasicDataType.UserDefined:
                {
                    scalarName = FixClassName(variable.DataTypeNode);
                    break;
                }

                case BasicDataType.Structure:
                {
                    scalarName = "ExtensionObject";
                    break;
                }

                default:
                {
                    scalarName = GetSystemTypeName(variable.DataTypeNode);
                    break;
                }
            }

            if (variable.ValueRank == ValueRank.Array)
            {
                return String.Format("{0}State<{1}[]>", FixClassName(variableType), scalarName);
            }

            return String.Format("{0}State<{1}>", FixClassName(variableType), scalarName);
        }

        /// <summary>
        /// Returns the class name to use when creating an instance of the type.
        /// </summary>
        private string GetBaseClassName(TypeDesign type)
        {
            DataTypeDesign dataType = type as DataTypeDesign;

            if (dataType == null || type.BaseTypeNode == null)
            {
                return type.BaseTypeNode.SymbolicName.Name;
            }

            if (((DataTypeDesign)dataType.BaseTypeNode).BasicDataType == BasicDataType.Structure)
            {
                return "IEncodeable";
            }

            return type.BaseTypeNode.SymbolicName.Name;
        }

        /// <summary>
        /// Returns the field name of a child node.
        /// </summary>
        private string GetChildName(InstanceDesign instance)
        {
            if (instance == null)
            {
                return String.Empty;
            }

            MethodDesign method = instance as MethodDesign;

            if (method != null)
            {
                return String.Format("{0}Method", instance.SymbolicName.Name);
            }

            return instance.SymbolicName.Name;
        }


        /// <summary>
        /// Returns the field name of a child node.
        /// </summary>
        private string GetChildFieldName(Parameter field)
        {
            if (field == null)
            {
                return String.Empty;
            }

            string name = String.Format("m_{0}{1}", field.Name.Substring(0, 1).ToLower(), field.Name.Substring(1));

            return name;
        }

        /// <summary>
        /// Returns the field name of a child node.
        /// </summary>
        private string GetChildFieldName(InstanceDesign instance)
        {
            if (instance == null)
            {
                return String.Empty;
            }

            string name = String.Format("m_{0}{1}", instance.SymbolicName.Name.Substring(0, 1).ToLower(), instance.SymbolicName.Name.Substring(1));

            MethodDesign method = instance as MethodDesign;

            if (method != null)
            {
                return String.Format("{0}Method", name);
            }

            return name;
        }

        /// <summary>
        /// Returns the template parameter for the type source declaration.
        /// </summary>
        private string GetTypeSourceTemplateParameter(TypeDesign type)
        {
            VariableTypeDesign variableType = type as VariableTypeDesign;

            if (variableType == null)
            {
                return String.Empty;
            }

            string parameter = GetTemplateParameter1(type);

            if (String.IsNullOrEmpty(parameter))
            {
                parameter = GetTemplateParameter1(type.BaseTypeNode);
            }

            return parameter;
        }

        /// <summary>
        /// Returns the template parameter to use with the type.
        /// </summary>
        private string GetTemplateParameter1(TypeDesign type)
        {
            VariableTypeDesign variableType = type as VariableTypeDesign;

            if (variableType == null)
            {
                return String.Empty;
            }

            if (type.BaseTypeNode == null)
            {
                return String.Format("<T>");
            }

            if (GetTemplateParameter1(type.BaseTypeNode) != "<T>")
            {
                return String.Empty;
            }

            BasicDataType basicType = variableType.DataTypeNode.BasicDataType;

            if (basicType == BasicDataType.BaseDataType)
            {
                return String.Format("<T>");
            }

            string scalarName = null;

            switch (basicType)
            {
                case BasicDataType.UserDefined:
                {
                    scalarName = FixClassName(variableType.DataTypeNode);
                    break;
                }

                case BasicDataType.Structure:
                {
                    scalarName = "ExtensionObject";
                    break;
                }

                default:
                {
                    scalarName = GetSystemTypeName(variableType.DataTypeNode);
                    break;
                }
            }

            if (variableType.ValueRank != ValueRank.Scalar)
            {
                return String.Format("<{0}[]>", scalarName);
            }

            return String.Format("<{0}>", scalarName);
        }

        /// <summary>
        /// Returns the prefix for the declaration of a method.
        /// </summary>
        private string GetMethodClassPrefix(MethodDesign method)
        {
            NodeDesign parent = method.MethodType;

            if (parent != null)
            {
                return String.Format("{0}", parent.SymbolicName.Name);
            }

            parent = method.Parent;

            while (parent is InstanceDesign)
            {
                parent = parent.Parent;
            }

            TypeDesign parentType = parent as TypeDesign;

            if (parentType != null)
            {
                return String.Format("{0}.{1}", parentType.SymbolicName.Name, method.SymbolicName.Name);
            }

            return String.Format("{0}", method.SymbolicName.Name);
        }

        /// <summary>
        /// Returns the default value for a child node.
        /// </summary>
        private string GetTypeClassName1(TypeDesign type)
        {
            if (type == null)
            {
                return "NodeState";
            }

            VariableTypeDesign variableType = type as VariableTypeDesign;

            if (variableType != null)
            {
                VariableTypeDesign baseType = variableType.BaseTypeNode as VariableTypeDesign;

                // check if a template parameter is required.
                if (baseType.DataTypeNode.BasicDataType == BasicDataType.BaseDataType)
                {
                    return String.Format("{0}{1}", FixClassName(variableType), GetTemplateParameter1(type));
                }
            }

            return String.Format("{0}", FixClassName(type));
        }

        /// <summary>
        /// Fixes class names for nodes.
        /// </summary>
        private string FixClassName(TypeDesign node)
        {
            if (node is DataTypeDesign)
            {
                return node.SymbolicId.Name;
            }

            ObjectTypeDesign objectType = node as ObjectTypeDesign;

            if (objectType != null && objectType.ClassName == "ObjectSource")
            {
                return "BaseObject";
            }

            VariableTypeDesign variableType = node as VariableTypeDesign;

            if (variableType != null && variableType.ClassName == "DataVariable")
            {
                return "BaseDataVariable";
            }

            return node.ClassName;
        }

        /// <summary>
        /// Returns the NodeClass of a Node
        /// </summary>
        private string GetNodeClass(NodeDesign node)
        {
            if (node is VariableDesign)
            {
                return "Variable";
            }

            if (node is VariableTypeDesign)
            {
                return "VariableType";
            }

            if (node is ObjectDesign)
            {
                return "Object";
            }

            if (node is ObjectTypeDesign)
            {
                return "ObjectType";
            }

            if (node is ReferenceTypeDesign)
            {
                return "ReferenceType";
            }

            if (node is DataTypeDesign)
            {
                return "DataType";
            }

            if (node is MethodDesign)
            {
                return "Method";
            }

            if (node is ViewDesign)
            {
                return "View";
            }

            return "Node";
        }

        /// <summary>
        /// Returns a boolean value as text.
        /// </summary>
        private string GetBooleanValue(bool value)
        {
            return (value) ? "true" : "false";
        }

        /// <summary>
        /// Maps the event notifier flag onto a string.
        /// </summary>
        private string GetEventNotifier(bool supportsEvents)
        {
            if (supportsEvents)
            {
                return "EventNotifiers.SubscribeToEvents";
            }

            return "EventNotifiers.None";
        }

        /// <summary>
        /// Maps the access level enumeration onto a string.
        /// </summary>
        private string GetAccessLevel(AccessLevel accessLevel)
        {
            switch (accessLevel)
            {
                case AccessLevel.Read: return "AccessLevels.CurrentRead";
                case AccessLevel.Write: return "AccessLevels.CurrentWrite";
                case AccessLevel.ReadWrite: return "AccessLevels.CurrentReadOrWrite";
            }

            return "AccessLevels.None";
        }

        /// <summary>
        /// Maps the modelling rule enumeration onto a string.
        /// </summary>
        private string GetModellingRule(ModellingRule modellingRule)
        {
            switch (modellingRule)
            {
                case ModellingRule.Mandatory: return "Opc.Ua.Objects.ModellingRule_Mandatory";
                case ModellingRule.MandatoryShared: return "Opc.Ua.Objects.ModellingRule_MandatoryShared";
                case ModellingRule.Optional: return "Opc.Ua.Objects.ModellingRule_Optional";
                case ModellingRule.OptionalPlaceholder: return "Opc.Ua.Objects.ModellingRule_OptionalPlaceholder";
                case ModellingRule.MandatoryPlaceholder: return "Opc.Ua.Objects.ModellingRule_MandatoryPlaceholder";
            }

            return "null";
        }

        /// <summary>
        /// Maps the value rank enumeration onto a string.
        /// </summary>
        private string GetValueRank(ValueRank valueRank, string arrayDimensions)
        {
            switch (valueRank)
            {
                case ValueRank.Array: return "ValueRanks.OneDimension";
                case ValueRank.Scalar: return "ValueRanks.Scalar";
                case ValueRank.ScalarOrArray: return "ValueRanks.Any";

                case ValueRank.OneOrMoreDimensions:
                {
                    if (String.IsNullOrEmpty(arrayDimensions))
                    {
                        return "ValueRanks.OneOrMoreDimensions";
                    }

                    string[] dimensions = arrayDimensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (dimensions.Length == 1)
                    {
                        return "ValueRanks.TwoDimensions";
                    }

                    return String.Format("{0}", dimensions.Length+1);
                }
            }

            return "ValueRanks.Any";
        }

        /// <summary>
        /// Maps the array dimensions onto a constant declaration..
        /// </summary>
        private string GetArrayDimensions(ValueRank valueRank, string arrayDimensions)
        {
            if (valueRank != ValueRank.OneOrMoreDimensions)
            {
                return "null";
            }

            return String.Format("new uint[] {{{0}}}", arrayDimensions);
        }

        /// <summary>
        /// Maps the MinimumSamplingInterval onto a constant.
        /// </summary>
        private string GetMinimumSamplingInterval(int minimumSamplingInterval)
        {
            switch (minimumSamplingInterval)
            {
                case -1: return "MinimumSamplingIntervals.Indeterminate";
                case 0: return "MinimumSamplingIntervals.Continuous";
            }

            return minimumSamplingInterval.ToString();
        }

        /// <summary>
        /// Whether a template parameter is required.
        /// </summary>
        private string GetDefaultValue(
            DataTypeDesign dataType,
            ValueRank valueRank,
            XmlElement defaultValue,
            object decodedValue,
            bool useVariantForObject)
        {
            if (valueRank == ValueRank.Array)
            {
                if (!useVariantForObject)
                {
                    return "null";
                }

                return Utils.Format("new {0}()", GetSystemTypeName(dataType, valueRank));
            }

            if (dataType.BasicDataType == BasicDataType.BaseDataType || valueRank != ValueRank.Scalar)
            {
                if (useVariantForObject)
                {
                    return "Variant.Null";
                }

                return "null";
            }

            switch (dataType.BasicDataType)
            {
                case BasicDataType.Boolean:
                {
                    bool? value = decodedValue as bool?;

                    if (value == null)
                    {
                        value = false;
                    }

                    if (value.Value)
                    {
                        return "false";
                    }

                    return "true";
                }

                case BasicDataType.SByte:
                {
                    sbyte? value = decodedValue as sbyte?;

                    if (value == null)
                    {
                        value = 0;
                    }

                    return Utils.Format("(sbyte){0}", value.Value);
                }

                case BasicDataType.Byte:
                {
                    byte? value = decodedValue as byte?;

                    if (value == null)
                    {
                        value = 0;
                    }

                    return Utils.Format("(byte){0}", value.Value);
                }

                case BasicDataType.Int16:
                {
                    short? value = decodedValue as short?;

                    if (value == null)
                    {
                        value = 0;
                    }

                    return Utils.Format("(short){0}", value.Value);
                }

                case BasicDataType.UInt16:
                {
                    ushort? value = decodedValue as ushort?;

                    if (value == null)
                    {
                        value = 0;
                    }

                    return Utils.Format("(ushort){0}", value.Value);
                }

                case BasicDataType.Int32:
                {
                    int? value = decodedValue as int?;

                    if (value == null)
                    {
                        value = 0;
                    }

                    return Utils.Format("(int){0}", value.Value);
                }

                case BasicDataType.UInt32:
                {
                    uint? value = decodedValue as uint?;

                    if (value == null)
                    {
                        value = 0;
                    }

                    return Utils.Format("(uint){0}", value.Value);
                }

                case BasicDataType.Integer:
                case BasicDataType.Int64:
                {
                    long? value = decodedValue as long?;

                    if (value == null)
                    {
                        value = 0;
                    }

                    return Utils.Format("(long){0}", value.Value);
                }

                case BasicDataType.UInteger:
                case BasicDataType.UInt64:
                {
                    ulong? value = decodedValue as ulong?;

                    if (value == null)
                    {
                        value = 0;
                    }

                    return Utils.Format("(ulong){0}", value.Value);
                }

                case BasicDataType.Float:
                {
                    float? value = decodedValue as float?;

                    if (value == null)
                    {
                        value = 0;
                    }

                    return Utils.Format("(float){0}", value.Value);
                }

                case BasicDataType.Number:
                case BasicDataType.Double:
                {
                    double? value = decodedValue as double?;

                    if (value == null)
                    {
                        value = 0;
                    }

                    return Utils.Format("(double){0}", value.Value);
                }

                case BasicDataType.String:
                {
                    string value = decodedValue as string;

                    if (value == null)
                    {
                        return "null";
                    }

                    return Utils.Format("\"{0}\"", value);
                }

                case BasicDataType.DateTime:
                {
                    DateTime? value = decodedValue as DateTime?;

                    if (value == null)
                    {
                        return "DateTime.MinValue";
                    }

                    return Utils.Format("DateTime.ParseExact(\"{0:yyyy-MM-dd HH:mm:ss}\", \"yyyy-MM-dd HH:mm:ss\", System.Globalization.CultureInfo.InvariantCulture)", value);
                }

                case BasicDataType.Guid:
                {
                    Uuid? value = decodedValue as Uuid?;

                    if (value == null)
                    {
                        return "Uuid.Empty";
                    }

                    return Utils.Format("new Uuid(\"{0}\")", value.Value);
                }

                case BasicDataType.ByteString:
                {
                    byte[] value = decodedValue as byte[];

                    if (value == null)
                    {
                        return "null";
                    }

                    return Utils.Format("Utils.FromHexString(\"{0}\")", Utils.ToHexString(value));
                }

                case BasicDataType.NodeId:
                {
                    NodeId value = decodedValue as NodeId;

                    if (value == null)
                    {
                        return "null";
                    }

                    if (value.NamespaceIndex == 0 || value.NamespaceIndex >= m_model.Namespaces.Length)
                    {
                        return Utils.Format("NodeId.Parse(\"{0}\")", value);
                    }

                    ExpandedNodeId absoluteId = new ExpandedNodeId(value, m_model.Namespaces[value.NamespaceIndex].Value);

                    return Utils.Format("ExpandedNodeId.Parse(\"{0}\", context.NamespaceUris)", absoluteId);
                }

                case BasicDataType.ExpandedNodeId:
                {
                    ExpandedNodeId value = decodedValue as ExpandedNodeId;

                    if (value == null)
                    {
                        return "null";
                    }

                    return Utils.Format("ExpandedNodeId.Parse(\"{0}\")", value);
                }

                case BasicDataType.QualifiedName:
                {
                    QualifiedName value = decodedValue as QualifiedName;

                    if (value == null)
                    {
                        return "null";
                    }

                    return Utils.Format("QualifiedName.Parse(\"{0}\")", value);
                }

                case BasicDataType.LocalizedText:
                {
                    Opc.Ua.LocalizedText value = decodedValue as Opc.Ua.LocalizedText;

                    if (value == null)
                    {
                        return "null";
                    }

                    return Utils.Format("new LocalizedText(\"{0}\", \"{1}\")", value.Locale, value.Text);
                }

                case BasicDataType.StatusCode:
                {
                    Opc.Ua.StatusCode? value = decodedValue as Opc.Ua.StatusCode?;

                    if (value == null)
                    {
                        return "StatusCodes.Good";
                    }

                    return Utils.Format("(StatusCode){0}", value.Value.Code);
                }

                case BasicDataType.Enumeration:
                {
                    if (dataType.SymbolicId == new XmlQualifiedName("Enumeration", DefaultNamespace))
                    {
                        return "0";
                    }

                    return Utils.Format("{0}.{1}", dataType.SymbolicName.Name, dataType.Fields[0].Name);
                }

                case BasicDataType.DataValue:
                {
                    return "new DataValue()";
                }

                case BasicDataType.Structure:
                case BasicDataType.XmlElement:
                {
                    return "null";
                }

                case BasicDataType.UserDefined:
                {
                    if (useVariantForObject)
                    {
                        return Utils.Format("new {0}()", GetSystemTypeName(dataType, ValueRank.Scalar));
                    }

                    return "null";
                }
            }

            return "null";
        }

        /// <summary>
        /// Whether a template parameter is required.
        /// </summary>
        private bool TemplateParameterRequired(DataTypeDesign dataType, ValueRank valueRank)
        {
            if (dataType.BasicDataType != BasicDataType.BaseDataType && dataType.BasicDataType != BasicDataType.Number && dataType.BasicDataType != BasicDataType.UInteger && dataType.BasicDataType != BasicDataType.Integer)
            {
                return true;
            }

            if (valueRank == ValueRank.Array)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the data type for a method argument.
        /// </summary>
        private string GetMethodArgumentType(DataTypeDesign datatype, ValueRank valueRank)
        {
            string typeName = GetSystemTypeName(datatype);

            if (typeName == "Guid")
            {
                typeName = "Uuid";
            }
            else if (typeName == "IEncodeable")
            {
                typeName = "ExtensionObject";
            }

            if (valueRank == ValueRank.Array)
            {
                if (typeName == "object")
                {
                    typeName = "Variant";
                }

                return typeName + "[]";
            }

            if (valueRank == ValueRank.Scalar)
            {
                return typeName;
            }

            return "object";
        }

        /// <summary>
        /// Returns system type for a basic data type.
        /// </summary>
        private string GetSystemTypeName(DataTypeDesign datatype)
        {
            switch (datatype.BasicDataType)
            {
                case BasicDataType.Boolean: { return "bool"; }
                case BasicDataType.SByte: { return "sbyte"; }
                case BasicDataType.Byte: { return "byte"; }
                case BasicDataType.Int16: { return "short"; }
                case BasicDataType.UInt16: { return "ushort"; }
                case BasicDataType.Int32: { return "int"; }
                case BasicDataType.UInt32: { return "uint"; }
                case BasicDataType.Int64: { return "long"; }
                case BasicDataType.UInt64: { return "ulong"; }
                case BasicDataType.Float: { return "float"; }
                case BasicDataType.Double: { return "double"; }
                case BasicDataType.String: { return "string"; }
                case BasicDataType.DateTime: { return "DateTime"; }
                case BasicDataType.Guid: { return "Guid"; }
                case BasicDataType.ByteString: { return "byte[]"; }
                case BasicDataType.XmlElement: { return "XmlElement"; }
                case BasicDataType.NodeId: { return "NodeId"; }
                case BasicDataType.ExpandedNodeId: { return "ExpandedNodeId"; }
                case BasicDataType.StatusCode: { return "StatusCode"; }
                case BasicDataType.DiagnosticInfo: { return "DiagnosticInfo"; }
                case BasicDataType.QualifiedName: { return "QualifiedName"; }
                case BasicDataType.LocalizedText: { return "LocalizedText"; }
                case BasicDataType.DataValue: { return "DataValue"; }

                case BasicDataType.Number:
                case BasicDataType.Integer:
                case BasicDataType.UInteger:
                case BasicDataType.BaseDataType:
                {
                    return "object";
                }

                case BasicDataType.Structure:
                {
                    return "ExtensionObject";
                }

                case BasicDataType.Enumeration:
                {
                    if (datatype.SymbolicId == new XmlQualifiedName("Enumeration", DefaultNamespace))
                    {
                        return "int";
                    }

                    return datatype.SymbolicName.Name;
                }

                case BasicDataType.UserDefined:
                {
                    return datatype.SymbolicName.Name;
                }
            }

            return "object";
        }

        /// <summary>
        /// Returns system type for a basic data type.
        /// </summary>
        private string GetSystemTypeName(DataTypeDesign datatype, ValueRank valueRank)
        {
            if (valueRank == ValueRank.Scalar)
            {
                string typeName = GetSystemTypeName(datatype);

                if (typeName == "Guid")
                {
                    return "Uuid";
                }

                if (typeName == "object")
                {
                    return "Variant";
                }

                if (typeName == "IEncodeable")
                {
                    return "ExtensionObject";
                }

                return typeName;
            }

            if (valueRank == ValueRank.Array)
            {
                switch (datatype.BasicDataType)
                {
                    case BasicDataType.Boolean: { return "BooleanCollection"; }
                    case BasicDataType.SByte: { return "SByteCollection"; }
                    case BasicDataType.Byte: { return "ByteCollection"; }
                    case BasicDataType.Int16: { return "Int16Collection"; }
                    case BasicDataType.UInt16: { return "UInt16Collection"; }
                    case BasicDataType.Int32: { return "Int32Collection"; }
                    case BasicDataType.UInt32: { return "UInt32Collection"; }
                    case BasicDataType.Int64: { return "Int64Collection"; }
                    case BasicDataType.UInt64: { return "UInt64Collection"; }
                    case BasicDataType.Float: { return "FloatCollection"; }
                    case BasicDataType.Double: { return "DoubleCollection"; }
                    case BasicDataType.String: { return "StringCollection"; }
                    case BasicDataType.DateTime: { return "DateTimeCollection"; }
                    case BasicDataType.Guid: { return "UuidCollection"; }
                    case BasicDataType.ByteString: { return "ByteStringCollection"; }
                    case BasicDataType.XmlElement: { return "XmlElementCollection"; }
                    case BasicDataType.NodeId: { return "NodeIdCollection"; }
                    case BasicDataType.ExpandedNodeId: { return "ExpandedNodeIdCollection"; }
                    case BasicDataType.StatusCode: { return "StatusCodeCollection"; }
                    case BasicDataType.DiagnosticInfo: { return "DiagnosticInfoCollection"; }
                    case BasicDataType.QualifiedName: { return "QualifiedNameCollection"; }
                    case BasicDataType.LocalizedText: { return "LocalizedTextCollection"; }
                    case BasicDataType.DataValue: { return "DataValueCollection"; }

                    case BasicDataType.Number:
                    case BasicDataType.Integer:
                    case BasicDataType.UInteger:
                    case BasicDataType.BaseDataType:
                    {
                        return "VariantCollection";
                    }

                    case BasicDataType.Structure:
                    {
                        return "ExtensionObjectCollection";
                    }

                    case BasicDataType.Enumeration:
                    {
                        if (datatype.SymbolicId == new XmlQualifiedName("Enumeration", DefaultNamespace))
                        {
                            return "Int32Collection";
                        }

                        return datatype.SymbolicName.Name + "Collection";
                    }

                    case BasicDataType.UserDefined:
                    {
                        return datatype.SymbolicName.Name + "Collection";
                    }
                }
            }

            return "Variant";
        }

        /// <summary>
        /// Returns a qualifier for the namespace to use in code.
        /// </summary>
        private string GetNamespacePrefix(string namespaceUri)
        {
            if (m_model.Namespaces != null)
            {
                foreach (Namespace ns in m_model.Namespaces)
                {
                    if (ns.Value == namespaceUri)
                    {
                        return String.Format("{0}", ns.Prefix);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns a constant for the namespace uri.
        /// </summary>
        private string GetConstantForNamespace(string namespaceUri)
        {
            if (m_model.Namespaces != null)
            {
                foreach (Namespace ns in m_model.Namespaces)
                {
                    if (ns.Value == namespaceUri)
                    {
                        return String.Format("{1}.Namespaces.{0}", ns.Name, ns.Prefix);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns a constant for the namespace uri.
        /// </summary>
        private string GetConstantForXmlNamespace(string namespaceUri)
        {
            if (m_model.Namespaces != null)
            {
                foreach (Namespace ns in m_model.Namespaces)
                {
                    if (ns.Value == namespaceUri)
                    {
                        if (!String.IsNullOrEmpty(ns.XmlNamespace))
                        {
                            return String.Format("{1}.Namespaces.{0}Xsd", ns.Name, ns.Prefix);
                        }

                        return String.Format("{1}.Namespaces.{0}", ns.Name, ns.Prefix);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns a list of nodes to process.
        /// </summary>
        private List<NodeDesign> GetNodeList()
        {
            List<NodeDesign> nodes = new List<NodeDesign>();

            foreach (NodeDesign node in m_model.Items)
            {
                if (!node.IsDeclaration)
                {
                    nodes.Add(node);
                }
            }

            return nodes;
        }

        /// <summary>
        /// Returns the browse path to the instance.
        /// </summary>
        private string GetBrowsePath(string basePath, InstanceDesign instance)
        {
            return NodeDesign.CreateSymbolicId(basePath, instance.SymbolicName.Name);
        }

        /// <summary>
        /// Constructs the initializer for a object type.
        /// </summary>
        private string ConstructInitializer(NodeDesign node, bool forInstance)
        {
            SystemContext context = new SystemContext();
            context.NamespaceUris = m_model.NamespaceUris;

            NodeState state = node.State;

            if (forInstance)
            {
                state = node.InstanceState;
            }

            if (state == null)
            {
                return null;
            }

            if (UseXmlInitializers)
            {
                MemoryStream ostrm = new MemoryStream();
                state.SaveAsXml(context, ostrm);
                string xml = new UTF8Encoding().GetString(ostrm.ToArray());
                return xml;
            }
            else
            {
                MemoryStream ostrm = new MemoryStream();
                state.SaveAsBinary(context, ostrm);
                ostrm.Close();
                return Convert.ToBase64String(ostrm.ToArray());
            }
        }
        #endregion
    }
}
