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
using System.Globalization;
using Opc.Ua;
using Export = Opc.Ua.Export;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Diagnostics;

namespace ModelCompiler
{
    /// <summary>
    /// Generates files used to describe data types.
    /// </summary>
    public partial class ModelCompilerValidator : Opc.Ua.Schema.SchemaValidator
    {

        #region Private Fields
        private ModelDesign m_dictionary;
        private Dictionary<XmlQualifiedName, NodeDesign> m_nodes;
        private Dictionary<NodeId, NodeDesign> m_nodesByNodeId;
        private Dictionary<uint, NodeDesign> m_identifiers;
        private string DefaultNamespace = Namespaces.OpcUa;
        private ServiceMessageContext m_context;
        private uint m_startId;
        private IList<string> m_exclusions;
        private Dictionary<XmlQualifiedName, string> m_browseNames = new Dictionary<XmlQualifiedName, string>();
        private Dictionary<string, string> m_designLocations = new Dictionary<string, string>();
        #endregion

        #region Constructors
        /// <summary>
        /// Intializes the object with default values.
        /// </summary>
        public ModelCompilerValidator(uint startId, IList<string> exclusions)
        {
            m_context = ServiceMessageContext.GlobalContext;
            m_startId = startId;
            m_exclusions = exclusions;
            EmbeddedModelDesignPath = "ModelCompiler.Design";
            EmbeddedCsvPath = "ModelCompiler.CSVs";
        }
        #endregion

        #region Public Members
        /// <summary>
        /// The dictionary that was validated.
        /// </summary>
        public ModelDesign Dictionary
        {
            get { return m_dictionary; }
        }

        /// <summary>
        /// The dictionary that was validated.
        /// </summary>
        public IEnumerable<NodeDesign> Nodes
        {
            get { return m_nodes.Values; }
        }

        /// <summary>
        /// The location of the embedded resources.
        /// </summary>
        public string EmbeddedModelDesignPath { get; set; }

        /// <summary>
        /// The location of the embedded CSVs.
        /// </summary>
        public string EmbeddedCsvPath { get; set; }

        /// <summary>
        /// Use the true type instead of ExtensionObject when subtypes are allowed.
        /// </summary>
        public bool UseAllowSubtypes { get; set; }

        public bool ReleaseCandidate { get; set; }

        /// <summary>
        /// ModelVersion
        /// </summary>
        public string ModelVersion { get; set; }

        /// <summary>
        /// ModelPublicationDate
        /// </summary>
        public string ModelPublicationDate { get; set; }

        /// <summary>
        /// Finds the data type with the specified name.
        /// </summary>
        public NodeDesign FindType(XmlQualifiedName typeName)
        {
            NodeDesign node = null;

            if (!m_nodes.TryGetValue(typeName, out node))
            {
                return null;
            }

            return node;
        }

        /// <summary>
        /// Loads built in types from a resource.
        /// </summary>
        public void LoadBuiltInTypes()
        {
            m_dictionary = LoadBuiltInModel();

            UpdateNamespaceTables(m_dictionary);

            // import types from target dictionary.
            List<NodeDesign> nodes = new List<NodeDesign>();

            foreach (NodeDesign node in m_dictionary.Items)
            {
                if (Import(node, null))
                {
                    nodes.Add(node);
                }
            }

            m_dictionary.Items = nodes.ToArray();

            // validate node in target dictionary.
            ValidateDictionary(m_dictionary);

            // build hierarchy.
            foreach (NodeDesign node in m_dictionary.Items)
            {
                node.Hierarchy = BuildInstanceHierarchy2(m_dictionary, node);
            }

            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{EmbeddedCsvPath}.StandardTypes.csv");

            using (stream)
            {
                LoadIdentifiersFromStream2(m_dictionary, stream);
            }

            // flag built-in types as declarations.
            foreach (NodeDesign node in m_dictionary.Items)
            {
                node.IsDeclaration = true;
            }
        }

        /// <summary>
        /// Saves an object to a file.
        /// </summary>
        private static void SaveDesignFile(string path, ModelDesign value)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;

            XmlDocument document = new XmlDocument();

            XmlAttribute attribute1 = document.CreateAttribute("tns:ns", value.TargetNamespace);
            attribute1.Value = value.TargetNamespace;
            XmlAttribute attribute2 = document.CreateAttribute("uax:ns", Namespaces.OpcUaXsd);
            attribute2.Value = Namespaces.OpcUaXsd;

            value.AnyAttr = new XmlAttribute[] { attribute1, attribute2 };

            using (XmlWriter writer = XmlWriter.Create(path, settings))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ModelDesign));
                serializer.Serialize(writer, value);
            }
        }

        /// <summary>
        /// Loads the types from an included design file.
        /// </summary>
        /// <param name="targetFile">The type file being loaded.</param>
        /// <param name="ns">The namespace being reference.</param>
        private void LoadIncludedDesignFile(ModelDesign parent, FileInfo targetFile, string designFileName, string version, string publicationDate)
        {
            // determine the file location.
            bool isResource = false;

            if (!designFileName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
            {
                designFileName += ".xml";
            }

            string designFilePath = designFileName;

            if (!File.Exists(designFilePath))
            {
                designFilePath = Path.Combine(targetFile.DirectoryName, designFileName);
                Console.WriteLine("Trying file: " + designFilePath);

                if (!File.Exists(designFilePath))
                {
                    designFilePath = Path.Combine(".", "Design");

                    int index = EmbeddedModelDesignPath.IndexOf(".Design");

                    if (index > 0)
                    {
                        designFilePath = Path.Combine(".", EmbeddedModelDesignPath.Substring(index + 1));
                    }

                    designFilePath = Path.Combine(designFilePath, designFileName);
                    Console.WriteLine("Trying file: " + designFilePath);

                    if (!File.Exists(designFilePath))
                    {
                        designFilePath = Utils.Format("ModelCompiler.Design.{0}", designFileName);
                        isResource = true;
                        Console.WriteLine("Trying resource: " + designFilePath);
                    }
                }
            }

            // load the design file.
            ModelDesign dictionary = null;

            if (isResource)
            {
                dictionary = (ModelDesign)LoadResource(typeof(ModelDesign), designFilePath, Assembly.GetExecutingAssembly());
            }
            else
            {
                dictionary = (ModelDesign)LoadFile(typeof(ModelDesign), File.Open(designFilePath, FileMode.Open, FileAccess.Read));
            }

            // check for nothing to do.
            if (dictionary == null || dictionary.Items == null || dictionary.Items.Length == 0)
            {
                return;
            }

            // mark the target namespace as found.
            m_designLocations[dictionary.TargetNamespace] = designFilePath;

            // save the model information.
            Export.ModelTableEntry modelInfo = null;

            if (parent.Dependencies == null)
            {
                parent.Dependencies = new Dictionary<string, Export.ModelTableEntry>();

                modelInfo = new Export.ModelTableEntry()
                {
                    ModelUri = m_dictionary.TargetNamespace,
                    XmlSchemaUri = GetXmlNamespace(m_dictionary.TargetNamespace),
                    Version = m_dictionary.TargetVersion,
                    PublicationDate = m_dictionary.TargetPublicationDate,
                    PublicationDateSpecified = m_dictionary.TargetPublicationDateSpecified
                };

                parent.Dependencies[m_dictionary.TargetNamespace] = modelInfo;
            }

            if (!parent.Dependencies.TryGetValue(dictionary.TargetNamespace, out modelInfo))
            {
                modelInfo = new Export.ModelTableEntry()
                {
                    ModelUri = dictionary.TargetNamespace,
                    XmlSchemaUri = GetXmlNamespace(m_dictionary.TargetNamespace),
                    Version = dictionary.TargetVersion,
                    PublicationDate = dictionary.TargetPublicationDate,
                    PublicationDateSpecified = dictionary.TargetPublicationDateSpecified
                };

                parent.Dependencies[dictionary.TargetNamespace] = modelInfo;
            }
            else
            {
                if (!modelInfo.PublicationDateSpecified)
                {
                    modelInfo.Version = dictionary.TargetVersion;
                    modelInfo.PublicationDate = dictionary.TargetPublicationDate;
                    modelInfo.PublicationDateSpecified = dictionary.TargetPublicationDateSpecified;
                }
            }

            // check for earlier publication date specified in the file.
            if (!String.IsNullOrEmpty(publicationDate))
            {
                modelInfo.Version = version;
                modelInfo.PublicationDate = XmlConvert.ToDateTime(publicationDate, XmlDateTimeSerializationMode.Utc);
                modelInfo.PublicationDateSpecified = true;
            }

            // load any included design files.
            if (dictionary.Namespaces != null)
            {
                for (int ii = 0; ii < dictionary.Namespaces.Length; ii++)
                {
                    Namespace ns = dictionary.Namespaces[ii];

                    if (!String.IsNullOrEmpty(ns.Value))
                    {
                        ns.Value = ns.Value.Trim();
                    }

                    if (m_designLocations.ContainsKey(ns.Value))
                    {
                        continue;
                    }

                    LoadIncludedDesignFile(dictionary, new FileInfo(designFilePath), ns.FilePath, ns.Version, ns.PublicationDate);
                }
            }

            UpdateNamespaceTables(dictionary);

            // import types from target dictionary.
            List<NodeDesign> nodes = new List<NodeDesign>();

            foreach (NodeDesign node in dictionary.Items)
            {
                if (Import(node, null))
                {
                    nodes.Add(node);
                }
            }

            dictionary.Items = nodes.ToArray();

            // validate node in target dictionary.
            ValidateDictionary(dictionary);

            // build hierarchy.
            foreach (NodeDesign node in dictionary.Items)
            {
                node.Hierarchy = BuildInstanceHierarchy2(dictionary, node);
            }

            // load the identifiers
            var identifiersFileName = Path.ChangeExtension(Path.GetFileName(designFileName), ".csv");
            var identifiersFilePath = Path.Combine(Path.GetDirectoryName(designFilePath), identifiersFileName);

            if (!File.Exists(identifiersFilePath))
            {
                identifiersFilePath = identifiersFileName;
            }

            isResource = false;

            if (!File.Exists(identifiersFilePath))
            {
                identifiersFilePath = Path.Combine(identifiersFilePath, identifiersFileName);
                Console.WriteLine("Trying file: " + identifiersFilePath);

                if (!File.Exists(identifiersFilePath))
                {
                    identifiersFilePath = $"{EmbeddedCsvPath}.{identifiersFileName}";
                    Console.WriteLine("Trying resource: " + identifiersFilePath);
                    isResource = true;
                }
            }

            if (isResource)
            {
                LoadIdentifiersFromStream2(dictionary, Assembly.GetExecutingAssembly().GetManifestResourceStream(identifiersFilePath));
            }
            else
            {
                LoadIdentifiersFromStream2(dictionary, File.Open(identifiersFilePath, FileMode.Open, FileAccess.Read));
            }

            // flag built-in types as declarations.
            foreach (NodeDesign node in dictionary.Items)
            {
                node.IsDeclaration = true;
            }
        }

        #region Type Dictionary Import Functions
        private LocalizedText ImportDocumentation(CodeGenerator.Documentation documentation)
        {
            if (documentation != null && documentation.Text != null && documentation.Text.Length > 0)
            {
                LocalizedText description = new LocalizedText();
                description.Value = documentation.Text[0];
                description.IsAutogenerated = false;
                return description;
            }

            return null;
        }

        private Parameter ImportField(CodeGenerator.FieldType field)
        {
            if (field == null)
            {
                return null;
            }

            Parameter parameter = new Parameter();

            parameter.Name = field.Name;
            // parameter.Description = ImportDocumentation(field.Documentation);

            if (field.DataType != null)
            {
                parameter.DataType = ImportTypeName(field.DataType);
            }
            else
            {
                parameter.DataType = new XmlQualifiedName("BaseDataType", DefaultNamespace);
            }

            if (field.ValueRank == 0)
            {
                parameter.ValueRank = ValueRank.Array;
            }
            else
            {
                parameter.ValueRank = ValueRank.Scalar;
            }

            parameter.IsOptional = field.IsOptional;
            parameter.AllowSubTypes = field.AllowSubTypes;
            parameter.DefaultValue = field.DefaultValue;
            parameter.ReleaseStatus = (ReleaseStatus)(int)field.ReleaseStatus;

            return parameter;
        }

        private Parameter ImportEnumeratedValue(CodeGenerator.EnumeratedValue value)
        {
            if (value == null)
            {
                return null;
            }

            Parameter parameter = new Parameter();

            parameter.Name = value.Name;
            parameter.Description = ImportDocumentation(value.Documentation);
            parameter.ReleaseStatus = (ReleaseStatus)(int)value.ReleaseStatus;

            if (value.ValueSpecified)
            {
                parameter.Identifier = value.Value;
                parameter.IdentifierSpecified = true;
            }

            if (!String.IsNullOrEmpty(value.BitMask))
            {
                parameter.BitMask = value.BitMask;
                parameter.IdentifierSpecified = false;
            }

            return parameter;
        }

        private XmlQualifiedName ImportTypeName(XmlQualifiedName typeName)
        {
            if (typeName == null)
            {
                return null;
            }

            switch (typeName.Name)
            {
                case "ExtensionObject": { return new XmlQualifiedName("Structure", DefaultNamespace); }
                case "Variant": { return new XmlQualifiedName("BaseDataType", DefaultNamespace); }
            }

            return new XmlQualifiedName(typeName.Name, DefaultNamespace);
        }

        private void ImportFields(DataTypeDesign design, CodeGenerator.FieldType[] fields)
        {
            if (fields != null && fields.Length > 0)
            {
                List<Parameter> parameters = new List<Parameter>();

                for (int jj = 0; jj < fields.Length; jj++)
                {
                    CodeGenerator.FieldType field = fields[jj];
                    Parameter parameter = ImportField(field);

                    if (!IsExcluded(parameter))
                    {
                        parameters.Add(parameter);
                    }
                }

                design.Fields = parameters.ToArray();
            }
        }

        private ModelDesign ImportTypeDictionary(string filePath, string resourcePath)
        {
            using (Stream stream = File.OpenRead(filePath))
            {
                return ImportTypeDictionary(stream, resourcePath);
            }
        }

        private ModelDesign ImportTypeDictionary(Stream stream, string resourcePath)
        {
            Dictionary<string, string> knownFiles = new Dictionary<string, string>();
            CodeGenerator.TypeDictionaryValidator validator = new CodeGenerator.TypeDictionaryValidator(knownFiles, resourcePath);
            validator.Validate(stream, null);

            string namespaceUri = validator.Dictionary.TargetNamespace;

            if (namespaceUri == "http://opcfoundation.org/UA/Core/")
            {
                namespaceUri = DefaultNamespace;
            }

            List<NodeDesign> nodes = new List<NodeDesign>();

            for (int ii = 0; ii < validator.Dictionary.Items.Length; ii++)
            {
                CodeGenerator.DataType dataType = validator.Dictionary.Items[ii];

                if (IsExcluded(dataType))
                {
                    continue;
                }

                DataTypeDesign design = new DataTypeDesign();

                design.SymbolicId = new XmlQualifiedName(dataType.Name, namespaceUri);
                design.SymbolicName = design.SymbolicId;
                design.BaseType = new XmlQualifiedName("BaseDataType", DefaultNamespace);
                design.NoArraysAllowed = !dataType.AllowArrays;
                design.NoClassGeneration = dataType.NotInAddressSpace;
                design.NotInAddressSpace = dataType.NotInAddressSpace;
                design.IsAbstract = false;
                // design.Description = ImportDocumentation(dataType.Documentation);
                design.PartNo = dataType.PartNo;
                design.Category = dataType.Category;
                design.ReleaseStatus = (ReleaseStatus)(int)dataType.ReleaseStatus;
                design.Purpose = (DataTypePurpose)(int)dataType.Purpose;

                if (design.PartNo == 0)
                {
                    design.PartNo = 4;
                }

                Log("Imported {1}: {0}", design.SymbolicId.Name, design.GetType().Name);

                CodeGenerator.TypeDeclaration simpleType = dataType as CodeGenerator.TypeDeclaration;

                if (simpleType != null)
                {
                    if (simpleType.SourceType != null)
                    {
                        design.BaseType = ImportTypeName(simpleType.SourceType);
                    }

                    nodes.Add(design);
                }

                CodeGenerator.ComplexType complexType = dataType as CodeGenerator.ComplexType;

                if (complexType != null)
                {
                    if (complexType.BaseType != null)
                    {
                        design.BaseType = ImportTypeName(complexType.BaseType);
                    }
                    else
                    {
                        design.BaseType = new XmlQualifiedName("Structure", DefaultNamespace);
                    }

                    ImportFields(design, complexType.Field);
                    design.IsAbstract = complexType.IsAbstract;
                    design.IsUnion = complexType.IsUnion;
                    nodes.Add(design);
                }

                CodeGenerator.ServiceType serviceType = dataType as CodeGenerator.ServiceType;

                if (serviceType != null)
                {
                    design.SymbolicId = new XmlQualifiedName(dataType.Name + "Request", namespaceUri);
                    design.SymbolicName = design.SymbolicId;
                    design.BaseType = new XmlQualifiedName("Structure", DefaultNamespace);
                    design.BasicDataType = GetBasicDataType(design);
                    design.NoArraysAllowed = true;
                    design.NoClassGeneration = false;
                    design.NotInAddressSpace = true;
                    design.IsAbstract = false;
                    // design.Description = ImportDocumentation(dataType.Documentation);
                    design.PartNo = 4;
                    design.Category = dataType.Category;
                    design.ReleaseStatus = (ReleaseStatus)(int)dataType.ReleaseStatus;
                    design.Purpose = DataTypePurpose.ServicesOnly;

                    ImportFields(design, serviceType.Request);

                    nodes.Add(design);

                    DataTypeDesign design2 = new DataTypeDesign();

                    design2.SymbolicId = new XmlQualifiedName(dataType.Name + "Response", namespaceUri);
                    design2.SymbolicName = design2.SymbolicId;
                    design2.BaseType = new XmlQualifiedName("Structure", DefaultNamespace);
                    design2.BasicDataType = GetBasicDataType(design);
                    design2.NoArraysAllowed = true;
                    design2.NoClassGeneration = false;
                    design2.NotInAddressSpace = true;
                    design2.IsAbstract = false;
                    // design2.Description = ImportDocumentation(dataType.Documentation);
                    design2.PartNo = 4;
                    design2.Category = dataType.Category;
                    design2.ReleaseStatus = (ReleaseStatus)(int)dataType.ReleaseStatus;
                    design2.Purpose = DataTypePurpose.ServicesOnly;

                    ImportFields(design2, serviceType.Response);

                    nodes.Add(design2);
                }

                CodeGenerator.EnumeratedType enumeratedType = dataType as CodeGenerator.EnumeratedType;

                if (enumeratedType != null)
                {
                    design.BaseType = new XmlQualifiedName("Enumeration", DefaultNamespace);

                    if (enumeratedType.IsOptionSet)
                    {
                        design.IsOptionSet = true;

                        if (enumeratedType.BaseType != null)
                        {
                            design.BaseType = ImportTypeName(enumeratedType.BaseType);
                        }
                        else
                        {
                            design.BaseType = new XmlQualifiedName("UInt32", DefaultNamespace);
                        }
                    }

                    if (enumeratedType.Value != null && enumeratedType.Value.Length > 0)
                    {
                        List<Parameter> parameters = new List<Parameter>();

                        for (int jj = 0; jj < enumeratedType.Value.Length; jj++)
                        {
                            CodeGenerator.EnumeratedValue value = enumeratedType.Value[jj];
                            Parameter parameter = ImportEnumeratedValue(value);
                            parameters.Add(parameter);
                        }

                        design.Fields = parameters.ToArray();
                    }

                    nodes.Add(design);
                }
            }

            ModelDesign model = new ModelDesign();

            model.Items = nodes.ToArray();
            model.TargetNamespace = DefaultNamespace;
            model.TargetNamespace = validator.Dictionary.TargetVersion;
            model.TargetPublicationDate = validator.Dictionary.TargetPublicationDate;
            model.TargetPublicationDateSpecified = true;

            return model;
        }
        #endregion

        /// <summary>
        /// Loads the built-in model design.
        /// </summary>
        private ModelDesign LoadBuiltInModel()
        {
            List<NodeDesign> nodes = new List<NodeDesign>();

            // load the design files.
            ModelDesign builtin = (ModelDesign)LoadResource(
                typeof(ModelDesign),
                $"{EmbeddedModelDesignPath}.BuiltInTypes.xml",
                Assembly.GetExecutingAssembly());

            nodes.AddRange(builtin.Items);

            string filename = Path.GetTempFileName();

            ModelDesign datatypes = null;

            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{EmbeddedModelDesignPath}.UA Core Services.xml");

            using (stream)
            {
                datatypes = ImportTypeDictionary(stream, EmbeddedModelDesignPath);
            }

            if (datatypes != null)
            {
                nodes.AddRange(datatypes.Items);
            }

            ModelDesign standard = (ModelDesign)LoadResource(
                typeof(ModelDesign),
                $"{EmbeddedModelDesignPath}.StandardTypes.xml",
                Assembly.GetExecutingAssembly());

            nodes.AddRange(standard.Items);

            builtin.Items = nodes.ToArray();

            return builtin;
        }

        /// <summary>
        /// Creates instance nodes out of standard components such as encodings or method args.
        /// </summary>
        private void ValidateDictionary(ModelDesign dictionary)
        {
            bool hasDataTypesDefined = false;
            bool hasMethodsDefined = false;

            foreach (NodeDesign node in dictionary.Items)
            {
                if (node is DataTypeDesign)
                {
                    hasDataTypesDefined = true;
                }

                if (node is MethodDesign)
                {
                    hasMethodsDefined = true;
                }

                Validate(node);
            }

            List<NodeDesign> nodes = new List<NodeDesign>();
            nodes.AddRange(dictionary.Items);

            if (hasDataTypesDefined)
            {
                if (!EmbeddedModelDesignPath.EndsWith("v103"))
                {
                    AddDataTypeDictionary(dictionary, dictionary.TargetNamespaceInfo, EncodingType.Binary, nodes);
                    AddDataTypeDictionary(dictionary, dictionary.TargetNamespaceInfo, EncodingType.Xml, nodes);
                    AddDataTypeDictionary(dictionary, dictionary.TargetNamespaceInfo, EncodingType.Json, nodes);
                }
                else
                {
                    AddDataTypeDictionary(dictionary, dictionary.TargetNamespaceInfo, EncodingType.Xml, nodes);
                    AddDataTypeDictionary(dictionary, dictionary.TargetNamespaceInfo, EncodingType.Binary, nodes);
                }

                foreach (NodeDesign node in dictionary.Items)
                {
                    if (node is DataTypeDesign)
                    {
                        AddEnumStrings((DataTypeDesign)node);
                    }
                }
            }

            AddTypesFolder(dictionary, dictionary.TargetNamespaceInfo, nodes);
            dictionary.Items = nodes.ToArray();

            // validate node in target dictionary.
            if (hasMethodsDefined)
            {
                foreach (NodeDesign node in dictionary.Items)
                {
                    if (node is MethodDesign)
                    {
                        AddMethodArguments((MethodDesign)node);
                    }
                }
            }

            foreach (var node in m_nodes.Values)
            {
                if (ReleaseCandidate && node.ReleaseStatus == ReleaseStatus.RC)
                {
                    node.ReleaseStatus = ReleaseStatus.Released;
                }
            }
        }

        private void UpdateNamespaceObject(ModelDesign dictionary)
        {
            ObjectDesign metadata = null;

            HashSet<uint> dynamicIds = new HashSet<uint>();

            foreach (NodeDesign node in dictionary.Items)
            {
                if (node.IsDynamic)
                {
                    CollectDynamicIds(node, dynamicIds);
                }

                if (metadata == null)
                {
                    metadata = node as ObjectDesign;

                    if (metadata != null && metadata.TypeDefinition != new XmlQualifiedName("NamespaceMetadataType", Namespaces.OpcUa))
                    {
                        metadata = null;
                    }
                }
            }

            if (metadata == null)
            {
                return;
            }


            List<string> ranges = new List<string>();

            int start = 1;
            bool readingStaticRange = true;

            for (uint ii = 1; dynamicIds.Count > 0; ii++)
            {
                if (readingStaticRange)
                {
                    if (dynamicIds.Contains(ii))
                    {
                        readingStaticRange = false;

                        int end = (int)(ii - 1);

                        if (end > start)
                        {
                            ranges.Add(new NumericRange(start, end).ToString());
                        }
                        else
                        {
                            ranges.Add(new NumericRange(start).ToString());
                        }

                        dynamicIds.Remove(ii);

                        if (dynamicIds.Count == 0)
                        {
                            start = (int)ii + 1;
                            break;
                        }
                    }
                }
                else
                {
                    if (!dynamicIds.Contains(ii))
                    {
                        start = (int)ii;
                        readingStaticRange = true;
                    }
                    else
                    {
                        dynamicIds.Remove(ii);

                        if (dynamicIds.Count == 0)
                        {
                            start = (int)ii + 1;
                            break;
                        }
                    }
                }
            }

            ranges.Add(new NumericRange(start, Int32.MaxValue).ToString());
            
            // Fix avoid a null metadata in some cases
            if ((metadata != null) && (metadata.Hierarchy.NodeList != null))
            {
                foreach (var child in metadata.Hierarchy.NodeList)
                {
                    if (child.Instance.BrowseName == "StaticNumericNodeIdRange")
                    {
                        VariableDesign variable = child.Instance as VariableDesign;
                        variable.DecodedValue = ranges.ToArray();
                    }

                    if (m_dictionary.TargetPublicationDateSpecified)
                    {
                        if (child.Instance.BrowseName == BrowseNames.NamespacePublicationDate)
                        {
                            VariableDesign variable = child.Instance as VariableDesign;
                            variable.DecodedValue = m_dictionary.TargetPublicationDate;
                        }
                    }

                    if (!String.IsNullOrEmpty(m_dictionary.TargetVersion))
                    {
                        if (child.Instance.BrowseName == BrowseNames.NamespaceVersion)
                        {
                            VariableDesign variable = child.Instance as VariableDesign;
                            variable.DecodedValue = m_dictionary.TargetVersion;
                        }
                    }
                }
            }
        }

        private void CollectDynamicIds(NodeDesign node, HashSet<uint> dynamicIds)
        {
            dynamicIds.Add(node.NumericId);

            if (node.Hierarchy.NodeList != null)
            {
                foreach (var child in node.Hierarchy.NodeList)
                {
                    if (child.Instance.NumericIdSpecified)
                    {
                        dynamicIds.Add(child.Instance.NumericId);
                    }
                }
            }
        }

        /// <summary>
        /// Updates the target namespace information for the dictionary.
        /// </summary>
        private void UpdateNamespaceTables(ModelDesign dictionary)
        {
            // build table of namespaces.
            Namespace targetNamespace = null;
            NamespaceTable namespaceUris = new NamespaceTable();

            if (dictionary.Namespaces != null)
            {
                for (int ii = 0; ii < dictionary.Namespaces.Length; ii++)
                {
                    Namespace current = dictionary.Namespaces[ii];

                    if (current.Value == dictionary.TargetNamespace)
                    {
                        targetNamespace = current;
                    }

                    if (current.Value != DefaultNamespace)
                    {
                        namespaceUris.Append(dictionary.Namespaces[ii].Value);
                    }
                }
            }

            dictionary.NamespaceUris = namespaceUris;
            dictionary.TargetNamespaceInfo = targetNamespace;
        }

        private void OutputError(string message)
        {
            if (message != null)
            {
                var original = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ForegroundColor = original;
            }
        }

        private void Log(string format, params object[] args)
        {
            //using (StreamWriter writer = new StreamWriter(".\\Log.txt", true))
            //{
            //    writer.WriteLine(format, args);
            //}
        }

        private ModelDesign LoadDesignFile(ModelDesign dictionary, string designFilePath)
        {
            Log("Loading DesignFile: {0}", designFilePath);

            ModelDesign component = null;

            try
            {
                if (NodeSetToModelDesign.IsNodeSet(designFilePath))
                {
                    var reader = new NodeSetToModelDesign(
                        new NodeSetReaderSettings()
                        {
                            NodesByQName = m_nodes,
                            DesignFilePaths = m_designLocations
                        },
                        designFilePath
                     );

                    component = reader.Import();
                }
                else
                {
                    component = (ModelDesign)LoadInput(typeof(ModelDesign), designFilePath);

                    if (component.Items == null)
                    {
                        component.Items = new NodeDesign[0];
                    }
                }
            }
            catch (Exception e)
            {
                try
                {
                    component = ImportTypeDictionary(designFilePath, EmbeddedModelDesignPath);
                }
                catch (Exception e2)
                {
                    throw new AggregateException("Error parsing file " + designFilePath, e, e2);
                }
            }

            if (dictionary != null)
            {
                List<NodeDesign> nodes2 = new List<NodeDesign>();

                // namespaces in primary dictionary replace all namespaces in secondary dictionaries.
                nodes2.AddRange(dictionary.Items);
                nodes2.AddRange(component.Items);

                dictionary.Items = nodes2.ToArray();
                component = dictionary;
            }

            if (component.Dependencies == null && m_dictionary != null)
            {
                component.Dependencies = new Dictionary<string, Export.ModelTableEntry>();

                var modelInfo = new Export.ModelTableEntry()
                {
                    ModelUri = m_dictionary.TargetNamespace,
                    XmlSchemaUri = GetXmlNamespace(m_dictionary.TargetNamespace),
                    Version = m_dictionary.TargetVersion,
                    PublicationDate = m_dictionary.TargetPublicationDate,
                    PublicationDateSpecified = m_dictionary.TargetPublicationDateSpecified
                };

                component.Dependencies[m_dictionary.TargetNamespace] = modelInfo;
            }

            return component;
        }

        /// <summary>
        /// Validates the design in the specified file.
        /// </summary>
        /// <param name="inputPath">The input file containing the design to validate.</param>
        /// <param name="identifierFilePath">The input file containing identifiers for the nodes defined.</param>
        /// <param name="generateIds">if set to <c>true</c> new identifiers are generated for all nodes.</param>
        public void Validate2(IList<string> designFilePaths, string identifierFilePath, bool generateIds)
        {
            if (File.Exists(".\\Log.txt"))
            {
                File.Delete(".\\Log.txt");
            }

            if (designFilePaths == null || designFilePaths.Count == 0)
            {
                throw new ArgumentException("No design files specified", "designFilePaths");
            }

            string inputPath = designFilePaths[0];

            // initialize tables.
            m_identifiers = new Dictionary<uint, NodeDesign>();
            m_nodes = new Dictionary<XmlQualifiedName, NodeDesign>();
            m_nodesByNodeId = new Dictionary<NodeId, NodeDesign>();
            m_browseNames = new Dictionary<XmlQualifiedName, string>();
            m_designLocations = new Dictionary<string, string>();

            // load the built in types (multiple files define the types in the default addresss space).
            if (!inputPath.EndsWith("StandardTypes.xml"))
            {
                Log("Loading BuiltInTypes...");
                LoadBuiltInTypes();
            }

            m_designLocations[this.DefaultNamespace] = String.Empty;

            // load the design files.
            ModelDesign dictionary = null;

            if (inputPath.EndsWith("StandardTypes.xml"))
            {
                Log("Loading StandardTypes...");
                dictionary = (ModelDesign)LoadResource(typeof(ModelDesign), $"{EmbeddedModelDesignPath}.BuiltInTypes.xml", Assembly.GetExecutingAssembly());

                if (dictionary.Items == null)
                {
                    dictionary.Items = new NodeDesign[0];
                }
            }

            for (int ii = 0; ii < designFilePaths.Count; ii++)
            {
                dictionary = LoadDesignFile(dictionary, designFilePaths[ii]);
            }

            // set a default xml namespace.
            if (String.IsNullOrEmpty(dictionary.TargetXmlNamespace))
            {
                dictionary.TargetXmlNamespace = dictionary.TargetNamespace;
                
                if (!String.IsNullOrEmpty(ModelVersion))
                {
                    dictionary.TargetVersion = ModelVersion;
                }

                if (!String.IsNullOrEmpty(ModelPublicationDate))
                {
                    var dt = DateTime.Parse(ModelPublicationDate, null, DateTimeStyles.AssumeUniversal);
                    dictionary.TargetPublicationDate = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, DateTimeKind.Utc);
                    dictionary.TargetPublicationDateSpecified = true;
                }
            }

            // mark the target namespace as found.
            m_designLocations[dictionary.TargetNamespace] = inputPath;

            // load any included design files.
            if (dictionary.Namespaces != null)
            {
                for (int ii = 0; ii < dictionary.Namespaces.Length; ii++)
                {
                    Namespace ns = dictionary.Namespaces[ii];

                    // override the publication date.
                    if (ns.PublicationDate != null || ns.Version != null)
                    {
                        Export.ModelTableEntry modelInfo = null;

                        if (dictionary.Dependencies.TryGetValue(ns.Value, out modelInfo))
                        {
                            if (!String.IsNullOrWhiteSpace(ns.Version))
                            {
                                modelInfo.Version = ns.Version;
                            }

                            if (!String.IsNullOrWhiteSpace(ns.PublicationDate))
                            {
                                modelInfo.PublicationDate = XmlConvert.ToDateTime(ns.PublicationDate, XmlDateTimeSerializationMode.Utc);
                            }
                        }
                    }

                    if (m_designLocations.ContainsKey(ns.Value))
                    {
                        continue;
                    }

                    if (String.IsNullOrEmpty(ns.FilePath))
                    {
                        continue;
                    }

                    LoadIncludedDesignFile(dictionary, new FileInfo(inputPath), ns.FilePath, ns.Version, ns.PublicationDate);
                }
            }

            // merge the the types together.
            if (inputPath.EndsWith("StandardTypes.xml"))
            {
                string mergedFilePath = inputPath.Substring(0, inputPath.Length-"StandardTypes.xml".Length);
                mergedFilePath += "UA Defined Types.xml";
                SaveDesignFile(mergedFilePath, dictionary);
            }

            // save the dictionary in a member variable during processing.
            m_dictionary = dictionary;

            // build table of namespaces.
            UpdateNamespaceTables(m_dictionary);
            m_dictionary.TargetXmlNamespace = GetXmlNamespace(m_dictionary.TargetNamespace);

            // import types from target dictionary.
            List<NodeDesign> nodes = new List<NodeDesign>();

            foreach (NodeDesign node in m_dictionary.Items)
            {
                if (Import(node, null))
                {
                    nodes.Add(node);
                }
            }

            m_dictionary.Items = nodes.ToArray();

            if (m_dictionary.Items == null || m_dictionary.Items.Length == 0)
            {
                Console.WriteLine("Nothing to do because design file has no entries.");
                return;
            }

            // do additional fix up after import.
            ValidateDictionary(m_dictionary);

            // validate node in target dictionary.
            foreach (NodeDesign node in m_dictionary.Items)
            {
                node.Hierarchy = BuildInstanceHierarchy2(dictionary, node);
            }

            // assign unique ids.
            if (generateIds)
            {
                File.Delete(identifierFilePath);
            }

            LoadIdentifiersFromFile2(m_dictionary, identifierFilePath);

            UpdateNamespaceObject(m_dictionary);

            // update the references.
            foreach (NodeDesign node in m_dictionary.Items)
            {
                CreateNodeState(node, m_dictionary.NamespaceUris);
            }
        }
        #endregion

        private string GetXmlNamespace(string modelUri)
        {
            var ns = (
                from x in m_dictionary.Namespaces
                where x.Value == modelUri
                select x.XmlNamespace).FirstOrDefault();

            if (!String.IsNullOrEmpty(ns))
            {
                return ns;
            }

            return null;
        }

        /// <summary>
        /// Adds the method arguments as children.
        /// </summary>
        private void AddMethodArguments(MethodDesign method)
        {
            List<InstanceDesign> children = new List<InstanceDesign>();

            if (method.Children != null && method.Children.Items != null)
            {
                children.AddRange(method.Children.Items);
            }

            if (method.InputArguments != null && method.InputArguments.Length > 0)
            {
                List<Argument> arguments = new List<Argument>();

                for (int ii = 0; ii < method.InputArguments.Length; ii++)
                {
                    Parameter parameter = method.InputArguments[ii];

                    Argument argument = new Argument();

                    argument.Name = parameter.Name;
                    argument.DataType = new NodeId(parameter.DataType.ToString());
                    argument.ValueRank = ConstructValueRank(parameter.ValueRank, parameter.ArrayDimensions);
                    argument.ArrayDimensions = ConstructArrayDimensionsRW(parameter.ValueRank, parameter.ArrayDimensions);
                    argument.Description = null;

                    if (!String.IsNullOrEmpty(parameter.ArrayDimensions))
                    {
                        argument.ArrayDimensions = new UInt32Collection();
                        var range = NumericRange.Parse(parameter.ArrayDimensions);
                        for (int jj = 0; jj < range.Dimensions; jj++)
                        {
                            argument.ArrayDimensions.Add((uint)range.SubRanges[jj].Begin);
                        }
                    }

                    if (parameter.Description != null && !parameter.Description.IsAutogenerated)
                    {
                        argument.Description = new Opc.Ua.LocalizedText(parameter.Description.Key, String.Empty, parameter.Description.Value);
                    }

                    arguments.Add(argument);
                }

                AddProperty(
                    method,
                    new XmlQualifiedName("InputArguments", DefaultNamespace),
                    new XmlQualifiedName("Argument", DefaultNamespace),
                    ValueRank.Array,
                    new uint[] { (uint)arguments.Count },
                    arguments.ToArray(),
                    children);
            }

            if (method.OutputArguments != null && method.OutputArguments.Length > 0)
            {
                List<Argument> arguments = new List<Argument>();

                for (int ii = 0; ii < method.OutputArguments.Length; ii++)
                {
                    Parameter parameter = method.OutputArguments[ii];

                    Argument argument = new Argument();

                    argument.Name = parameter.Name;
                    argument.DataType = new NodeId(parameter.DataType.ToString());
                    argument.ValueRank = ConstructValueRank(parameter.ValueRank, parameter.ArrayDimensions);
                    argument.ArrayDimensions = ConstructArrayDimensionsRW(parameter.ValueRank, parameter.ArrayDimensions);
                    argument.Description = null;

                    if (parameter.Description != null && !parameter.Description.IsAutogenerated)
                    {
                        argument.Description = new Opc.Ua.LocalizedText(parameter.Description.Key, String.Empty, parameter.Description.Value);
                    }

                    arguments.Add(argument);
                }

                AddProperty(
                    method,
                    new XmlQualifiedName("OutputArguments", DefaultNamespace),
                    new XmlQualifiedName("Argument", DefaultNamespace),
                    ValueRank.Array,
                    new uint[] { (uint)arguments.Count },
                    arguments.ToArray(),
                    children);
            }

            method.Children = new ListOfChildren();
            method.Children.Items = children.ToArray();
        }

        /// <summary>
        /// Adds the method arguments as children.
        /// </summary>
        private void AddEnumStrings(DataTypeDesign dataType)
        {
            List<InstanceDesign> children = new List<InstanceDesign>();

            if (dataType.Children != null && dataType.Children.Items != null)
            {
                children.AddRange(dataType.Children.Items);
            }

            if (!dataType.IsEnumeration || dataType.Fields == null || dataType.Fields.Length == 0)
            {
                return;
            }

            if (dataType.IsOptionSet)
            {
                List<Opc.Ua.LocalizedText> values = new List<Opc.Ua.LocalizedText>();

                int last = 0;

                for (int ii = 0; ii < 32; ii++)
                {
                    int hit = (int)1 << ii;

                    foreach (Parameter parameter in dataType.Fields)
                    {
                        if (parameter.Identifier == hit)
                        {
                            while (last++ < ii)
                            {
                                values.Add(new Opc.Ua.LocalizedText(String.Empty, "Reserved"));
                            }

                            values.Add(new Opc.Ua.LocalizedText(String.Empty, parameter.Name));
                            last = ii+1;
                            break;
                        }
                    }
                }

                AddProperty(
                    dataType,
                    new XmlQualifiedName("OptionSetValues", DefaultNamespace),
                    new XmlQualifiedName("LocalizedText", DefaultNamespace),
                    ValueRank.Array,
                    new uint[] { (uint)values.Count },
                    values.ToArray(),
                    children);
            }
            else
            {
                int index = 0;
                bool sequentenial = false;

                if (!dataType.ForceEnumValues)
                {
                    sequentenial = true;

                    foreach (Parameter parameter in dataType.Fields)
                    {
                        if (parameter.Identifier != index)
                        {
                            sequentenial = false;
                            break;
                        }

                        index++;
                    }
                }

                if (sequentenial)
                {
                    List<Opc.Ua.LocalizedText> values = new List<Opc.Ua.LocalizedText>();

                    foreach (Parameter parameter in dataType.Fields)
                    {
                        values.Add(new Opc.Ua.LocalizedText(String.Empty, parameter.Name));
                    }

                    AddProperty(
                        dataType,
                        new XmlQualifiedName("EnumStrings", DefaultNamespace),
                        new XmlQualifiedName("LocalizedText", DefaultNamespace),
                        ValueRank.Array,
                        new uint[] { (uint)values.Count },
                        values.ToArray(),
                        children);
                }

                else
                {
                    List<Opc.Ua.EnumValueType> values = new List<Opc.Ua.EnumValueType>();

                    foreach (Parameter parameter in dataType.Fields)
                    {
                        Opc.Ua.EnumValueType value = new Opc.Ua.EnumValueType();

                        value.DisplayName = new Opc.Ua.LocalizedText(String.Empty, parameter.Name);
                        value.Value = parameter.Identifier;

                        if (parameter.Description != null && !parameter.Description.IsAutogenerated)
                        {
                            value.Description = new Opc.Ua.LocalizedText(parameter.Description.Key, String.Empty, parameter.Description.Value);
                        }

                        values.Add(value);
                    }

                    AddProperty(
                        dataType,
                        new XmlQualifiedName("EnumValues", DefaultNamespace),
                        new XmlQualifiedName("EnumValueType", DefaultNamespace),
                        ValueRank.Array,
                        new uint[] { (uint)values.Count },
                        values.ToArray(),
                        children);
                }
            }

            dataType.Children = new ListOfChildren();
            dataType.Children.Items = children.ToArray();
        }

        /// <summary>
        /// Adds the folders to organize the types used in the namespace.
        /// </summary>
        private void AddTypesFolder(
            ModelDesign nodes,
            Namespace ns,
            IList<NodeDesign> nodesToAdd)
        {
            /*
            foreach (NodeDesign node in nodes.Items)
            {
                ObjectDesign folder = null;

                if (node is ObjectTypeDesign)
                {
                    folder = FindTypeFolder(ns, node, NodeClass.ObjectType, node.PartNo, nodesToAdd);
                }

                if (node is VariableTypeDesign)
                {
                    folder = FindTypeFolder(ns, node, NodeClass.VariableType, node.PartNo, nodesToAdd);
                }

                if (node is DataTypeDesign)
                {
                    folder = FindTypeFolder(ns, node, NodeClass.DataType, node.PartNo, nodesToAdd);
                }

                if (node is ReferenceTypeDesign)
                {
                    folder = FindTypeFolder(ns, node, NodeClass.ReferenceType, node.PartNo, nodesToAdd);
                }

                if (folder != null)
                {
                    List<Reference> references = new List<Reference>();

                    if (node.References != null)
                    {
                        references.AddRange(node.References);
                    }

                    Reference reference = new Reference();

                    reference.ReferenceType = new XmlQualifiedName("Organizes", DefaultNamespace);
                    reference.IsInverse = true;
                    reference.IsOneWay = false;
                    reference.TargetId = folder.SymbolicId;

                    references.Add(reference);

                    node.References = references.ToArray();
                    node.HasReferences = true;
                }
            }
            */
        }

        private void AddDataTypeDictionary(
            ModelDesign nodes,
            Namespace ns,
            EncodingType encodingType,
            IList<NodeDesign> nodesToAdd)
        {
            DictionaryDesign dictionary = null;
            List<InstanceDesign> descriptions = new List<InstanceDesign>();

            if (encodingType != EncodingType.Json)
            {
                dictionary = new DictionaryDesign();

                string namespaceUri = ns.Value;
                bool isXml = encodingType == EncodingType.Xml;

                if (isXml && !String.IsNullOrEmpty(ns.XmlNamespace))
                {
                    namespaceUri = ns.XmlNamespace;
                }

                if (!isXml)
                {
                    dictionary.SymbolicId = new XmlQualifiedName(NodeDesign.CreateSymbolicId(ns.Name, "BinarySchema"), ns.Value);
                }
                else
                {
                    dictionary.SymbolicId = new XmlQualifiedName(NodeDesign.CreateSymbolicId(ns.Name, "XmlSchema"), ns.Value);
                }

                dictionary.SymbolicName = dictionary.SymbolicId;
                dictionary.BrowseName = ns.Prefix;
                dictionary.DisplayName = new LocalizedText();
                dictionary.DisplayName.IsAutogenerated = true;
                dictionary.DisplayName.Value = dictionary.BrowseName;
                // dictionary.Description = new LocalizedText();
                // dictionary.Description.IsAutogenerated = true;
                // dictionary.Description.Value = dictionary.BrowseName;
                dictionary.WriteAccess = 0;
                dictionary.TypeDefinition = new XmlQualifiedName("DataTypeDictionaryType", DefaultNamespace);
                dictionary.TypeDefinitionNode = (VariableTypeDesign)FindNode(dictionary.TypeDefinition, typeof(VariableTypeDesign), dictionary.SymbolicId.Name, "TypeDefinition");
                dictionary.DataType = new XmlQualifiedName("ByteString", DefaultNamespace);
                dictionary.DataTypeNode = (DataTypeDesign)FindNode(dictionary.DataType, typeof(DataTypeDesign), dictionary.SymbolicId.Name, "DataType");
                dictionary.ValueRank = ValueRank.Scalar;
                dictionary.ValueRankSpecified = true;
                dictionary.ArrayDimensions = null;
                dictionary.AccessLevel = AccessLevel.Read;
                dictionary.AccessLevelSpecified = true;
                dictionary.MinimumSamplingInterval = 0;
                dictionary.MinimumSamplingIntervalSpecified = true;
                dictionary.Historizing = false;
                dictionary.HistorizingSpecified = true;

                if (!EmbeddedModelDesignPath.EndsWith("v103"))
                {
                    dictionary.ReleaseStatus = ReleaseStatus.Deprecated;
                }

                if (ns.Value == DefaultNamespace)
                {
                    dictionary.PartNo = 5;
                }

                Reference reference = new Reference();

                reference.ReferenceType = new XmlQualifiedName("HasComponent", DefaultNamespace);
                reference.IsInverse = true;
                reference.IsOneWay = false;

                if (isXml)
                {
                    reference.TargetId = new XmlQualifiedName("XmlSchema_TypeSystem", DefaultNamespace);
                }
                else
                {
                    reference.TargetId = new XmlQualifiedName("OPCBinarySchema_TypeSystem", DefaultNamespace);
                }

                dictionary.References = new Reference[] { reference };

                AddProperty(
                    dictionary,
                    new XmlQualifiedName("NamespaceUri", DefaultNamespace),
                    new XmlQualifiedName("String", DefaultNamespace),
                    ValueRank.Scalar,
                    null,
                    namespaceUri,
                    descriptions);

                if (!EmbeddedModelDesignPath.EndsWith("v103"))
                {
                    AddProperty(
                        dictionary,
                        new XmlQualifiedName("Deprecated", DefaultNamespace),
                        new XmlQualifiedName("Boolean", DefaultNamespace),
                        ValueRank.Scalar,
                        null,
                        true,
                        descriptions);
                }
            }

            foreach (NodeDesign node in nodes.Items)
            {
                DataTypeDesign dataType = node as DataTypeDesign;

                if (dataType == null)
                {
                    continue;
                }

                if (dataType.BasicDataType == BasicDataType.UserDefined)
                {
                    AddDataTypeDescription(dataType, dictionary, descriptions, encodingType, nodesToAdd);
                    continue;
                }
            }

            if (dictionary != null)
            {
                dictionary.Children = new ListOfChildren();
                dictionary.Children.Items = descriptions.ToArray();

                m_nodes[dictionary.SymbolicId] = dictionary;
                Log("Added {1}: {0}", dictionary.SymbolicId.Name, dictionary.GetType().Name);
                nodesToAdd.Add(dictionary);
            }
        }

        private void AddProperty(
            NodeDesign parent,
            XmlQualifiedName propertyName,
            XmlQualifiedName dataType,
            ValueRank valueRank,
            uint[] arrayDimensions,
            object value,
            IList<InstanceDesign> children)
        {
            PropertyDesign property = new PropertyDesign();

            property.Parent = parent;
            property.ReferenceType = new XmlQualifiedName("HasProperty", DefaultNamespace);
            property.ModellingRule = ModellingRule.Mandatory;
            property.ModellingRuleSpecified = true;
            property.SymbolicId = new XmlQualifiedName(NodeDesign.CreateSymbolicId(parent.SymbolicId.Name, propertyName.Name), parent.SymbolicId.Namespace);
            property.SymbolicName = propertyName;
            property.BrowseName = propertyName.Name;
            property.DisplayName = new LocalizedText();
            property.DisplayName.IsAutogenerated = true;
            property.DisplayName.Value = property.BrowseName;
            // property.Description = new LocalizedText();
            // property.Description.IsAutogenerated = true;
            // property.Description.Value = property.BrowseName;
            property.WriteAccess = 0;
            property.TypeDefinition = new XmlQualifiedName("PropertyType", DefaultNamespace);
            property.TypeDefinitionNode = (VariableTypeDesign)FindNode(property.TypeDefinition, typeof(VariableTypeDesign), property.SymbolicId.Name, "TypeDefinition");
            property.DataType = dataType;
            property.DataTypeNode = (DataTypeDesign)FindNode(property.DataType, typeof(DataTypeDesign), property.SymbolicId.Name, "DataType");
            property.ValueRank = valueRank;
            property.ValueRankSpecified = true;
            property.ArrayDimensions = null;
            property.AccessLevel = AccessLevel.Read;
            property.AccessLevelSpecified = true;
            property.MinimumSamplingInterval = 0;
            property.MinimumSamplingIntervalSpecified = true;
            property.Historizing = false;
            property.HistorizingSpecified = true;
            property.DecodedValue = value;
            property.PartNo = parent.PartNo;
            property.Category = parent.Category;
            property.ReleaseStatus = parent.ReleaseStatus;

            if (!EmbeddedModelDesignPath.EndsWith("v104") && !EmbeddedModelDesignPath.EndsWith("v103"))
            {
                if (arrayDimensions != null)
                {
                    property.ArrayDimensions = "";
                    foreach (var ii in arrayDimensions)
                    {
                        if (property.ArrayDimensions.Length > 0)
                        {
                            property.ArrayDimensions += ",";
                        }

                        property.ArrayDimensions += ii.ToString();
                    }
                }
            }

            children.Add(property);

            m_nodes[property.SymbolicId] = property;
            Log("Added {1}: {0}", property.SymbolicId.Name, property.GetType().Name);
        }

        private void AddDataTypeDescription(
            DataTypeDesign dataType,
            DictionaryDesign dictionary,
            IList<InstanceDesign> descriptions,
            EncodingType encodingType,
            IList<NodeDesign> nodesToAdd)
        {
            VariableDesign description = null;

            if (encodingType != EncodingType.Json && !dataType.NotInAddressSpace)
            {
                description = new VariableDesign();

                description.Parent = dictionary;
                description.ReferenceType = new XmlQualifiedName("HasComponent", DefaultNamespace);
                description.ModellingRule = ModellingRule.Mandatory;
                description.ModellingRuleSpecified = true;
                description.SymbolicId = new XmlQualifiedName(NodeDesign.CreateSymbolicId(dictionary.SymbolicId.Name, dataType.SymbolicId.Name), dictionary.SymbolicId.Namespace);
                description.SymbolicName = new XmlQualifiedName(dataType.SymbolicId.Name, description.SymbolicId.Namespace);
                description.BrowseName = dataType.BrowseName;
                description.DisplayName = new LocalizedText();
                description.DisplayName.IsAutogenerated = true;
                description.DisplayName.Value = description.BrowseName;
                // description.Description = new LocalizedText();
                // description.Description.IsAutogenerated = true;
                // description.Description.Value = description.BrowseName;
                description.WriteAccess = 0;
                description.TypeDefinition = new XmlQualifiedName("DataTypeDescriptionType", DefaultNamespace);
                description.TypeDefinitionNode = (VariableTypeDesign)FindNode(description.TypeDefinition, typeof(VariableTypeDesign), description.SymbolicId.Name, "TypeDefinition");
                description.DataType = new XmlQualifiedName("String", DefaultNamespace);
                description.DataTypeNode = (DataTypeDesign)FindNode(description.DataType, typeof(DataTypeDesign), description.SymbolicId.Name, "DataType");
                description.ValueRank = ValueRank.Scalar;
                description.ValueRankSpecified = true;
                description.ArrayDimensions = null;
                description.AccessLevel = AccessLevel.Read;
                description.AccessLevelSpecified = true;
                description.MinimumSamplingInterval = 0;
                description.MinimumSamplingIntervalSpecified = true;
                description.Historizing = false;
                description.HistorizingSpecified = true;
                description.PartNo = dataType.PartNo;
                description.NotInAddressSpace = dataType.NotInAddressSpace;
                description.ReleaseStatus = dataType.ReleaseStatus;
                description.Purpose = dataType.Purpose;
                
                if (encodingType == EncodingType.Xml)
                {
                    description.DecodedValue = Utils.Format("//xs:element[@name='{0}']", dataType.SymbolicName.Name);
                }
                else
                {
                    description.DecodedValue = Utils.Format("{0}", dataType.SymbolicName.Name);
                }

                if (description.ReleaseStatus == ReleaseStatus.Released && !EmbeddedModelDesignPath.EndsWith("v103"))
                {
                    description.ReleaseStatus = ReleaseStatus.Deprecated;
                }

                if (!dataType.NotInAddressSpace)
                {
                    descriptions.Add(description);
                }

                m_nodes[description.SymbolicId] = description;
                Log("Added {1}: {0}", description.SymbolicId.Name, description.GetType().Name);
            }

            if (dataType.BasicDataType == BasicDataType.UserDefined)
            {
                AddDataTypeEncoding(dataType, description, encodingType, nodesToAdd);
            }
        }

        private enum EncodingType
        {
            Binary = 0,
            Xml = 1,
            Json = 2
        }

        private void AddDataTypeEncoding(
            DataTypeDesign dataType,
            VariableDesign description,
            EncodingType encodingType,
            IList<NodeDesign> nodesToAdd)
        {
            ObjectDesign encoding = new ObjectDesign();

            encoding.Parent = null;
            encoding.ReferenceType = null;

            if (encodingType == EncodingType.Xml)
            {
                encoding.SymbolicId = new XmlQualifiedName(dataType.SymbolicId.Name + "_Encoding_DefaultXml", dataType.SymbolicId.Namespace);
                encoding.SymbolicName = new XmlQualifiedName("DefaultXml", DefaultNamespace);
                encoding.BrowseName = "Default XML";
            }
            else if (encodingType == EncodingType.Json)
            {
                encoding.SymbolicId = new XmlQualifiedName(dataType.SymbolicId.Name + "_Encoding_DefaultJson", dataType.SymbolicId.Namespace);
                encoding.SymbolicName = new XmlQualifiedName("DefaultJson", DefaultNamespace);
                encoding.BrowseName = "Default JSON";
            }
            else
            {
                encoding.SymbolicId = new XmlQualifiedName(dataType.SymbolicId.Name + "_Encoding_DefaultBinary", dataType.SymbolicId.Namespace);
                encoding.SymbolicName = new XmlQualifiedName("DefaultBinary", DefaultNamespace);
                encoding.BrowseName = "Default Binary";
            }

            encoding.DisplayName = new LocalizedText();
            encoding.DisplayName.IsAutogenerated = true;
            encoding.DisplayName.Value = encoding.BrowseName;
            // encoding.Description = new LocalizedText();
            // encoding.Description.IsAutogenerated = true;
            // encoding.Description.Value = encoding.BrowseName;
            encoding.WriteAccess = 0;
            encoding.TypeDefinition = new XmlQualifiedName("DataTypeEncodingType", DefaultNamespace);
            encoding.TypeDefinitionNode = (ObjectTypeDesign)FindNode(encoding.TypeDefinition, typeof(ObjectTypeDesign), encoding.SymbolicId.Name, "TypeDefinition");
            encoding.SupportsEvents = false;
            encoding.SupportsEventsSpecified = true;
            encoding.PartNo = dataType.PartNo;
            encoding.NotInAddressSpace = dataType.NotInAddressSpace;
            encoding.Category = dataType.Category;
            encoding.ReleaseStatus = dataType.ReleaseStatus;
            encoding.Purpose = dataType.Purpose;
            encoding.Parent = dataType;

            Reference reference1 = new Reference();

            reference1.ReferenceType = new XmlQualifiedName("HasEncoding", DefaultNamespace);
            reference1.IsInverse = true;
            reference1.IsOneWay = false;
            reference1.TargetId = dataType.SymbolicId;
            reference1.TargetNode = dataType;

            if (description != null && !dataType.NotInAddressSpace)
            {
                Reference reference2 = new Reference();

                reference2.ReferenceType = new XmlQualifiedName("HasDescription", DefaultNamespace);
                reference2.IsInverse = false;
                reference2.IsOneWay = false;
                reference2.TargetId = description.SymbolicId;
                reference2.TargetNode = description;

                encoding.References = new Reference[] { reference1, reference2 };
            }
            else
            {
                encoding.References = new Reference[] { reference1 };
            }

            m_nodes[encoding.SymbolicId] = encoding;
            nodesToAdd.Add(encoding);
            Log("Added {1}: {0}", encoding.SymbolicId.Name, encoding.GetType().Name);
        }

        #region Private Methods
        /// <summary>
        /// Returns true if the node is a declaration.
        /// </summary>
        private bool IsDeclaration(NodeDesign node)
        {
            for (NodeDesign parent = node; parent != null; parent = parent.Parent)
            {
                if (parent.IsDeclaration)
                {
                    return true;
                }
            }

            return false;
        }

        private class IdInfo
        {
            public object Id;
            public string SymbolicId;
            public NodeClass NodeClass;
            public ReleaseStatus ReleaseStatus;
            public string Category;
        }

        private Dictionary<string, object> ParseFile(Stream istrm)
        {
            Dictionary<string, object> identifiers = new Dictionary<string, object>();

            StreamReader reader = new StreamReader(istrm);

            try
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (String.IsNullOrEmpty(line) || line.StartsWith("#"))
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
                        string name = line.Substring(0, index).Trim();
                        string id = line.Substring(index + 1).Trim();
                        Log("Loaded ID: {0}={1}", name, id);

                        if (id.StartsWith("\""))
                        {
                            identifiers[name] = id.Substring(1, id.Length - 2);
                        }
                        else
                        {
                            uint numericId = Convert.ToUInt32(id);
                            identifiers[name] = numericId;
                        }
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

            return identifiers;
        }

        private uint FindUnusedId(HashSet<uint> identifiers, string ns)
        {
            uint id = (uint)((ns == Namespaces.OpcUa) ? 15000 : 0);
            while (identifiers.Contains(++id));
            identifiers.Add(id);
            return id;
        }

        private object AssignIdToNode(
            NodeDesign node,
            Dictionary<string, object> identifiers,
            SortedDictionary<object, IdInfo> uniqueIdentifiers,
            Dictionary<string, object> duplicateIdentifiers,
            HashSet<uint> assignedIds)
        {
            // assign identifier if one has not already been assigned.
            object id = null;

            if (!identifiers.TryGetValue(node.SymbolicId.Name, out id))
            {
                id = FindUnusedId(assignedIds, node.SymbolicId.Namespace);
                identifiers.Add(node.SymbolicId.Name, id);
            }

            // save identifier.
            if (uniqueIdentifiers.ContainsKey(id))
            {
                duplicateIdentifiers.Add(node.SymbolicId.Name, id);
            }
            else
            {
                IdInfo info = new IdInfo();

                info.Id = id;
                info.SymbolicId = node.SymbolicId.Name;
                info.NodeClass = GetNodeClass(node);
                info.ReleaseStatus = node.ReleaseStatus;
                info.Category = node.Category;

                uniqueIdentifiers.Add(id, info);
            }

            // set identifier for node.
            if (id is uint)
            {
                node.NumericId = (uint)id;
                node.NumericIdSpecified = true;
                node.StringId = null;
            }
            else
            {
                node.NumericId = (uint)0;
                node.NumericIdSpecified = false;
                node.StringId = id as string;
            }

            Log("Assigned ID: {0}={1}", node.SymbolicId.Name, id);
            return id;
        }

        /// <summary>
        /// Loads the identifiers from a CSV file.
        /// </summary>
        private IDictionary<object, IdInfo> LoadIdentifiersFromStream2(ModelDesign dictionary, Stream istrm)
        {
            Dictionary<string, object> identifiers = ParseFile(istrm);
            SortedDictionary<object, IdInfo> uniqueIdentifiers = new SortedDictionary<object, IdInfo>();
            Dictionary<string, object> duplicateIdentifiers = new Dictionary<string, object>();
            HashSet<uint> assignedIds = new HashSet<uint>();

            foreach (object existingId in identifiers.Values)
            {
                uint? numericId = existingId as uint?;

                if (numericId != null)
                {
                    assignedIds.Add(numericId.Value);
                }
            }

            // assign identifiers.
            for (int ii = 0; ii < dictionary.Items.Length; ii++)
            {
                NodeDesign node = dictionary.Items[ii];

                // assign identifier if one has not already been assigned.
                object id = AssignIdToNode(node, identifiers, uniqueIdentifiers, duplicateIdentifiers, assignedIds);

                if (node.Hierarchy == null)
                {
                    continue;
                }

                foreach (HierarchyNode current in node.Hierarchy.NodeList)
                {
                    if (String.IsNullOrEmpty(current.RelativePath))
                    {
                        current.Identifier = id;

                        // set identifier for node.
                        if (id is uint)
                        {
                            current.Instance.NumericId = (uint)id;
                            current.Instance.NumericIdSpecified = true;
                            current.Instance.StringId = null;
                        }
                        else
                        {
                            current.Instance.NumericId = (uint)0;
                            current.Instance.NumericIdSpecified = false;
                            current.Instance.StringId = id as string;
                        }

                        Log("Assigned ID: {0}={1}", current.Instance.SymbolicId.Name, id);
                        continue;
                    }

                    current.Identifier = AssignIdToNode(current.Instance, identifiers, uniqueIdentifiers, duplicateIdentifiers, assignedIds);
                }
            }

            // check for duplicate nodes.
            if (duplicateIdentifiers.Count > 0)
            {
                StringBuilder buffer = new StringBuilder();

                buffer.Append("Duplicate identifiers for these nodes:\r\n");

                foreach (KeyValuePair<string, object> current in duplicateIdentifiers)
                {
                    buffer.AppendFormat("{0},{1}\r\n", current.Key, current.Value);
                }

                throw new InvalidOperationException(buffer.ToString());
            }

            foreach (var ii in identifiers)
            {
                if (!uniqueIdentifiers.ContainsKey(ii.Value))
                {
                    uniqueIdentifiers[ii.Value] = new IdInfo()
                    {
                        Id = ii.Value,
                        SymbolicId = ii.Key,
                        NodeClass = NodeClass.Unspecified,
                        ReleaseStatus = ReleaseStatus.Released
                    };
                }
            }

            return uniqueIdentifiers;
        }

        /// <summary>
        /// Loads the identifiers from a CSV file.
        /// </summary>
        private void LoadIdentifiersFromFile2(ModelDesign dictionary, string filePath)
        {
            IDictionary<object, IdInfo> uniqueIdentifiers = LoadIdentifiersFromStream2(dictionary, File.Open(filePath, FileMode.Open));

            // update the CSV file.
            StreamWriter writer = new StreamWriter(filePath, false);

            try
            {
                foreach (KeyValuePair<object, IdInfo> id in uniqueIdentifiers)
                {
                    if (id.Key is string)
                    {
                        writer.WriteLine("{0},\"{1}\",{2}", id.Value.SymbolicId, id.Key, id.Value.NodeClass);
                    }
                    else
                    {
                        writer.WriteLine("{0},{1},{2}", id.Value.SymbolicId, id.Key, id.Value.NodeClass);
                    }
                }
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Loads the identifiers from a CSV file.
        /// </summary>
        private IDictionary<object,object> LoadIdentifiersFromStream(Stream istrm)
        {
            Dictionary<string,object> identifiers = new Dictionary<string,object>();

            StreamReader reader = new StreamReader(istrm);

            HashSet<uint> assignedIds = new HashSet<uint>();

            try
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (String.IsNullOrEmpty(line) || line.StartsWith("#"))
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

                        string id = line.Substring(index+1).Trim();

                        if (id.StartsWith("\""))
                        {
                            identifiers[name] = id.Substring(1, id.Length-2);
                        }
                        else
                        {
                            uint numericId = Convert.ToUInt32(id);
                            assignedIds.Add(numericId);
                            identifiers[name] = numericId;
                        }
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

            // check for predefined ids.
            foreach (NodeDesign node in m_nodes.Values)
            {
                if (IsDeclaration(node))
                {
                    continue;
                }

                if (node.NumericIdSpecified)
                {
                    identifiers[node.SymbolicId.Name] = node.NumericId;
                    assignedIds.Add(node.NumericId);
                }
            }

            var uniqueIdentifiers = new SortedDictionary<object,object>();
            var duplicateIdentifiers = new Dictionary<string,object>();

            foreach (NodeDesign node in m_nodes.Values)
            {
                if (IsDeclaration(node) || !IsPublished(node))
                {
                    continue;
                }

                object id = null;

                if (!identifiers.ContainsKey(node.SymbolicId.Name))
                {
                    id = node.NumericId = FindUnusedId(assignedIds, node.SymbolicId.Namespace);
                    node.NumericIdSpecified = true;
                    identifiers.Add(node.SymbolicId.Name, id);
                }
                else
                {
                    id = identifiers[node.SymbolicId.Name];

                    if (id is uint)
                    {
                        node.NumericId = Convert.ToUInt32(id);
                        node.NumericIdSpecified = true;
                    }
                    else
                    {
                        node.NumericId = 0;
                        node.NumericIdSpecified = false;
                        node.StringId = Convert.ToString(id);
                    }
                }

                if (uniqueIdentifiers.ContainsKey(id))
                {
                    duplicateIdentifiers.Add(node.SymbolicId.Name, id);
                }
                else
                {
                    uniqueIdentifiers.Add(id, node);
                }
            }

            // check for duplicate nodes.
            if (duplicateIdentifiers.Count > 0)
            {
                StringBuilder buffer = new StringBuilder();

                buffer.Append("Duplicate identifiers for these nodes:\r\n");

                foreach (KeyValuePair<string,object> current in duplicateIdentifiers)
                {
                    buffer.AppendFormat("{0},{1}\r\n", current.Key, current.Value);
                }

                throw new InvalidOperationException(buffer.ToString());
            }

            foreach (var ii in identifiers)
            {
                if (!uniqueIdentifiers.ContainsKey(ii.Value))
                {
                    uniqueIdentifiers[ii.Value] = ii.Key;
                }
            }

            return uniqueIdentifiers;
        }

        /// <summary>
        /// Returns true is the node is published.
        /// </summary>
        private bool IsPublished(NodeDesign node)
        {
            // globally declared methods are a special case that do not appear in the address space.
            MethodDesign method = node as MethodDesign;

            if (method != null && method.Parent == null)
            {
                return false;
            }

            return (node != null);
        }

        /// <summary>
        /// Imports a node.
        /// </summary>
        private bool Import(NodeDesign node, NodeDesign parent)
        {
            UpdateNamesAndIdentifiers(node, parent);

            if (node.NumericIdSpecified)
            {
                var ns = m_dictionary.NamespaceUris.GetIndex(node.SymbolicId.Namespace);
                m_nodesByNodeId[new NodeId(node.NumericId, (ushort)ns)] = node;
            }

            if (IsExcluded(node))
            {
                return false;
            }

            // assign default values for various subtypes.
            if (node is TypeDesign)
            {
                ImportType((TypeDesign)node);
            }

            if (node is InstanceDesign)
            {
                ImportInstance((InstanceDesign)node);
            }

            if (node.SymbolicId.Namespace == "http://opcfoundation.org/UA/")
            {
                node.Description = null;
            }

            m_nodes.Add(node.SymbolicId, node);
            Log("Imported {1}: {0}", node.SymbolicId.Name, node.GetType().Name);

            // import children.
            if (node.Children != null && node.Children.Items != null)
            {
                node.HasChildren = true;

                List<InstanceDesign> children = new List<InstanceDesign>();

                foreach (InstanceDesign child in node.Children.Items)
                {
                    if (IsExcluded(child))
                    {
                        continue;
                    }

                    // filter any children with unhandled modelling rules.
                    if (child.ModellingRuleSpecified)
                    {
                        switch (child.ModellingRule)
                        {
                            case ModellingRule.None:
                            case ModellingRule.Mandatory:
                            case ModellingRule.MandatoryShared:
                            case ModellingRule.Optional:
                            case ModellingRule.MandatoryPlaceholder:
                            case ModellingRule.OptionalPlaceholder:
                            case ModellingRule.ExposesItsArray:
                            {
                                break;
                            }

                            default:
                            {
                                continue;
                            }
                        }
                    }

                    if (child.ReleaseStatus == ReleaseStatus.Released)
                    {
                        child.Category = node.Category;
                        child.ReleaseStatus = node.ReleaseStatus;
                    }

                    if (Import(child, node))
                    {
                        children.Add(child);
                    }
                }

                node.Children.Items = children.ToArray();
            }

            // import references
            if (node.References != null)
            {
                node.HasReferences = true;

                foreach (Reference reference in node.References)
                {
                    ImportReference(node, reference);
                }
            }

            return true;
        }

        /// <summary>
        /// Sets the browse name for a node.
        /// </summary>
        private void SetBrowseName(NodeDesign node)
        {
            string browseName = null;

            // use the name to assign a browse name.
            if (String.IsNullOrEmpty(node.BrowseName))
            {
                if (!m_browseNames.TryGetValue(node.SymbolicName, out browseName))
                {
                    m_browseNames[node.SymbolicName] = browseName = node.SymbolicName.Name;
                }

                node.BrowseName = browseName;
            }
            else
            {
                if (!m_browseNames.TryGetValue(node.SymbolicName, out browseName))
                {
                    m_browseNames[node.SymbolicName] = node.BrowseName;
                    return;
                }

                if (browseName != node.BrowseName)
                {
                    throw Exception("The SymbolicName {0} has a BrowseName {1} but expected {2}.", node.SymbolicName.Name, browseName, node.BrowseName);
                }
            }
        }

        /// <summary>
        /// Ensures all the names and ids in the node have valid values.
        /// </summary>
        private void UpdateNamesAndIdentifiers(NodeDesign node, NodeDesign parent)
        {
            if (node == null)
            {
                return;
            }

            // copy the symbolic name and browse name from the declaration if specified.
            InstanceDesign instance = node as InstanceDesign;

            if (instance != null)
            {
                if (!IsNull(instance.Declaration))
                {
                    InstanceDesign declaration = (InstanceDesign)FindNode(
                        instance.Declaration,
                        typeof(InstanceDesign),
                        instance.Declaration.Name,
                        "Declaration");

                    if (declaration != null)
                    {
                        instance.SymbolicName   = declaration.SymbolicName;
                        instance.BrowseName     = declaration.BrowseName;
                        instance.TypeDefinition = declaration.TypeDefinition;
                    }
                }
            }

            // check for missing name.
            if (IsNull(node.SymbolicId) && IsNull(node.SymbolicName) && String.IsNullOrEmpty(node.BrowseName))
            {
                throw Exception("A Node does not have SymbolicId, Name or a BrowseName. Parent={0}", (parent != null)?parent.SymbolicId.Name:"No Parent");
            }

            // use the browse name to assign a name.
            if (IsNull(node.SymbolicName))
            {
                if (String.IsNullOrEmpty(node.BrowseName))
                {
                    throw Exception("A Node does not have SymbolicId, SymbolicName or a BrowseName: {0}.", node.SymbolicId.Name);
                }

                // remove any non-symbol characters.
                StringBuilder name = new StringBuilder();

                for (int ii = 0; ii < node.BrowseName.Length; ii++)
                {
                    if (Char.IsWhiteSpace(node.BrowseName[ii]))
                    {
                        name.Append(NodeDesign.PathChar);
                        continue;
                    }

                    if (Char.IsLetterOrDigit(node.BrowseName[ii]) || node.BrowseName[ii] == NodeDesign.PathChar[0])
                    {
                        name.Append(node.BrowseName[ii]);
                        continue;
                    }
                }

                string ns = m_dictionary.TargetNamespace;

                if (!IsNull(node.SymbolicId))
                {
                    ns = node.SymbolicId.Namespace;
                }

                // create the symbolic name.
                node.SymbolicName = new XmlQualifiedName(name.ToString(), ns);
            }

            // use the name to assign a browse name.
            SetBrowseName(node);

            // use the name to assign a symbolic id.
            if (IsNull(node.SymbolicId))
            {
                string id = NodeDesign.CreateSymbolicId((parent != null)?parent.SymbolicId:null, node.SymbolicName.Name);
                node.SymbolicId = new XmlQualifiedName(id, node.SymbolicName.Namespace);
            }

            // check for duplicates.
            if (m_nodes.ContainsKey(node.SymbolicId))
            {
                throw Exception("The SymbolicId is already used by another node: {0}.", node.SymbolicId.Name);
            }

            // check numeric id.
            if (node.NumericIdSpecified)
            {
                if (m_identifiers.ContainsKey(node.NumericId))
                {
                    throw Exception("The NumericId is already used by another node: {0}.", node.NumericId);
                }

                m_identifiers.Add(node.NumericId, node);
            }

            // add a display name.
            if (node.DisplayName == null)
            {
                node.DisplayName = new LocalizedText();
                node.DisplayName.Value = node.BrowseName;
                node.DisplayName.IsAutogenerated = true;
            }
            else if (node.DisplayName.Value != null)
            {
                node.DisplayName.Value = node.DisplayName.Value.Trim();
            }

            if (String.IsNullOrEmpty(node.DisplayName.Key))
            {
                node.DisplayName.Key = String.Format("{0}_DisplayName", node.SymbolicId.Name);
            }

            // add a decription.
            if (node.Description == null)
            {
                // node.Description = new LocalizedText();
                // node.Description.Value = String.Format("A description for the {0} {1}.", node.BrowseName, GetNodeClassText(node)); ;
                // node.Description.IsAutogenerated = true;
            }
            else if (node.Description.Value != null && node.SymbolicId.Namespace != "http://opcfoundation.org/UA/")
            {
                node.Description.Value = node.Description.Value.Trim();

                if (String.IsNullOrEmpty(node.Description.Key))
                {
                    node.Description.Key = String.Format("{0}_Description", node.SymbolicId.Name);
                }
            }

            // save the relationship to the parent.
            node.Parent = parent;
        }

        /// <summary>
        /// Imports an TypeDesign
        /// </summary>
        private void ImportType(TypeDesign type)
        {
            // assign a class name.
            if (String.IsNullOrEmpty(type.ClassName))
            {
                type.ClassName = type.SymbolicName.Name;

                if (type.ClassName.EndsWith("Type"))
                {
                    type.ClassName = type.ClassName.Substring(0, type.ClassName.Length-4);
                }
            }

            // assign missing fields for object types.
            ObjectTypeDesign objectType = type as ObjectTypeDesign;

            if (objectType != null)
            {
                if (objectType.SymbolicId == new XmlQualifiedName("BaseObjectType", DefaultNamespace))
                {
                    objectType.ClassName = "ObjectSource";
                }
                else if (type.BaseType == null)
                {
                    type.BaseType = new XmlQualifiedName("BaseObjectType", DefaultNamespace);
                }

                if (objectType.SymbolicName != new XmlQualifiedName("BaseObjectType", DefaultNamespace))
                {
                    objectType.BaseTypeNode = (TypeDesign)FindNode(
                        objectType.BaseType,
                        typeof(ObjectTypeDesign),
                        objectType.SymbolicId.Name,
                        "BaseType");
                }

                if (!objectType.SupportsEvents)
                {
                    objectType.SupportsEvents = false;
                }
            }

            // assign missing fields for variable types.
            VariableTypeDesign variableType = type as VariableTypeDesign;

            if (variableType != null)
            {
                if (variableType.SymbolicId == new XmlQualifiedName("BaseDataVariableType", DefaultNamespace))
                {
                    variableType.ClassName = "DataVariable";
                }
                else if (type.BaseType == null)
                {
                    if (type.SymbolicId != new XmlQualifiedName("BaseVariableType", DefaultNamespace))
                    {
                       type.BaseType = new XmlQualifiedName("BaseDataVariableType", DefaultNamespace);
                    }
                }

                if (variableType.SymbolicName != new XmlQualifiedName("BaseVariableType", DefaultNamespace))
                {
                    variableType.BaseTypeNode = (TypeDesign)FindNode(
                        variableType.BaseType,
                        typeof(VariableTypeDesign),
                        variableType.SymbolicId.Name,
                        "BaseType");

                    if (variableType.BaseTypeNode != null)
                    {
                        if (variableType.DataType == null || variableType.DataType == new XmlQualifiedName("BaseDataType", DefaultNamespace))
                        {
                            variableType.DataType = ((VariableTypeDesign)variableType.BaseTypeNode).DataType;

                            ValueRank valueRank = ((VariableTypeDesign)variableType.BaseTypeNode).ValueRank;

                            if (!variableType.ValueRankSpecified && valueRank != ValueRank.ScalarOrArray)
                            {
                                variableType.ValueRank = valueRank;
                                variableType.ValueRankSpecified = true;
                            }
                        }
                    }
                }

                if (variableType.DataType == null)
                {
                    variableType.DataType = new XmlQualifiedName("BaseDataType", DefaultNamespace);
                }

                if (!variableType.ValueRankSpecified)
                {
                    variableType.ValueRank = ValueRank.Scalar;
                }

                if (!variableType.AccessLevelSpecified)
                {
                    variableType.AccessLevel = AccessLevel.Read;
                }

                if (!variableType.HistorizingSpecified)
                {
                    variableType.Historizing = false;
                }

                if (!variableType.MinimumSamplingIntervalSpecified)
                {
                    variableType.MinimumSamplingInterval = 0;
                }
            }

            // assign missing fields for data types.
            DataTypeDesign dataType = type as DataTypeDesign;

            if (dataType != null)
            {
                if (dataType.SymbolicId == new XmlQualifiedName("Structure", DefaultNamespace))
                {
                    dataType.ClassName = "IEncodeable";
                }
                else if (type.BaseType == null)
                {
                    if (dataType.SymbolicId != new XmlQualifiedName("BaseDataType", DefaultNamespace))
                    {
                        type.BaseType = new XmlQualifiedName("BaseDataType", DefaultNamespace);
                    }
                }

                if (dataType.SymbolicName != new XmlQualifiedName("BaseDataType", DefaultNamespace))
                {
                    dataType.BaseTypeNode = (TypeDesign)FindNode(
                        dataType.BaseType,
                        typeof(DataTypeDesign),
                        dataType.SymbolicId.Name,
                        "BaseType");
                }

                dataType.IsStructure = (dataType.BaseType == new XmlQualifiedName("Structure", DefaultNamespace));
                dataType.IsEnumeration = (dataType.BaseType == new XmlQualifiedName("Enumeration", DefaultNamespace) || dataType.IsOptionSet);
                dataType.IsUnion = (dataType.BaseType == new XmlQualifiedName("Union", DefaultNamespace) || dataType.IsUnion);

                Parameter[] parameters = dataType.Fields;
                dataType.HasFields = ImportParameters(dataType, ref parameters, "Field");
                dataType.Fields = parameters;

                dataType.HasEncodings = ImportEncodings(dataType);
            }

            // assign missing fields for reference types.
            ReferenceTypeDesign referenceType = type as ReferenceTypeDesign;

            if (referenceType != null)
            {
                if (referenceType.BaseType == null)
                {
                    if (referenceType.SymbolicId != new XmlQualifiedName("References", DefaultNamespace))
                    {
                        referenceType.BaseType = new XmlQualifiedName("References", DefaultNamespace);
                    }
                }

                // add an inverse name.
                if (referenceType.InverseName == null)
                {
                    referenceType.InverseName = new LocalizedText();
                    referenceType.InverseName.Value = referenceType.DisplayName.Value;
                    referenceType.InverseName.IsAutogenerated = true;
                }

                if (String.IsNullOrEmpty(referenceType.InverseName.Key))
                {
                    referenceType.InverseName.Key = String.Format("{0}_InverseName", referenceType.SymbolicId.Name);
                }

                if (referenceType.SymbolicName != new XmlQualifiedName("References", DefaultNamespace))
                {
                    referenceType.BaseTypeNode = (TypeDesign)FindNode(
                        referenceType.BaseType,
                        typeof(ReferenceTypeDesign),
                        referenceType.SymbolicId.Name,
                        "BaseType");
                }
            }
        }

        /// <summary>
        /// Imports the encodings.
        /// </summary>
        private bool ImportEncodings(DataTypeDesign dataType)
        {
            if (dataType.Encodings == null || dataType.Encodings.Length == 0)
            {
                return false;
            }

            foreach (EncodingDesign encoding in dataType.Encodings)
            {
                if (IsNull(encoding.SymbolicName))
                {
                    throw Exception("Encoding node does not have a name: {0}.", dataType.SymbolicId.Name);
                }

                if (encoding.Children != null && encoding.Children.Items.Length > 0)
                {
                    throw Exception("Encoding nodes cannot have childen", dataType.SymbolicId.Name);
                }

                encoding.SymbolicId  = new XmlQualifiedName(String.Format("{0}_Encoding_{1}", dataType.SymbolicId.Name, encoding.SymbolicName.Name), dataType.SymbolicId.Namespace);
                encoding.BrowseName  = encoding.SymbolicName.Name;

                // add a display name.
                if (encoding.DisplayName == null || String.IsNullOrEmpty(encoding.DisplayName.Value))
                {
                    encoding.DisplayName = new LocalizedText();
                    encoding.DisplayName.Value = encoding.BrowseName;
                    encoding.DisplayName.IsAutogenerated = true;
                }

                // add a description name.
                if (encoding.Description.Value == null || String.IsNullOrEmpty(encoding.Description.Value))
                {
                    //encoding.Description = new LocalizedText();
                    //encoding.Description.Value = String.Format("The {0} Encoding for the {1} data type.", encoding.SymbolicName.Name, dataType.SymbolicName.Name);
                    //encoding.Description.IsAutogenerated = true;
                }

                // add to table.
                m_nodes.Add(encoding.SymbolicId, encoding);
                Log("Imported {1}: {0}", encoding.SymbolicId.Name, encoding.GetType().Name);

                if (encoding.NumericIdSpecified)
                {
                    if (m_identifiers.ContainsKey(encoding.NumericId))
                    {
                        throw Exception("The NumericId is already used by another node: {0}.", encoding.SymbolicId.Name);
                    }

                    m_identifiers.Add(encoding.NumericId, encoding);
                }
            }

            return true;
        }

        /// <summary>
        /// Imports an InstanceDesign
        /// </summary>
        private void ImportInstance(InstanceDesign instance)
        {
            // set the reference type.
            if (instance.ReferenceType == null)
            {
                if (instance is PropertyDesign)
                {
                    instance.ReferenceType = new XmlQualifiedName("HasProperty", DefaultNamespace);
                }
                else
                {
                    instance.ReferenceType = new XmlQualifiedName("HasComponent", DefaultNamespace);
                }
            }

            // set the type definition.
            if (instance.TypeDefinition == null)
            {
                if (instance is PropertyDesign)
                {
                    instance.TypeDefinition = new XmlQualifiedName("PropertyType", DefaultNamespace);
                }
                else if (instance is VariableDesign)
                {
                    instance.TypeDefinition = new XmlQualifiedName("BaseDataVariableType", DefaultNamespace);
                }
                else if (instance is ObjectDesign)
                {
                    instance.TypeDefinition = new XmlQualifiedName("BaseObjectType", DefaultNamespace);
                }
            }

            if (!instance.ModellingRuleSpecified)
            {
                instance.ModellingRule = ModellingRule.Mandatory;
            }

            // assign missing fields for objects.
            ObjectDesign objectd = instance as ObjectDesign;

            if (objectd != null)
            {
                if (!objectd.SupportsEventsSpecified)
                {
                    objectd.SupportsEvents = false;
                }
            }

            // assign missing fields for variables.
            VariableDesign variable = instance as VariableDesign;

            if (variable != null)
            {
                if (variable.DataType == null)
                {
                    variable.DataType = new XmlQualifiedName("BaseDataType", DefaultNamespace);
                }

                if (!variable.ValueRankSpecified)
                {
                    variable.ValueRank = ValueRank.Scalar;
                }

                if (!variable.AccessLevelSpecified)
                {
                    variable.AccessLevel = AccessLevel.Read;
                }

                if (!variable.MinimumSamplingIntervalSpecified)
                {
                    variable.MinimumSamplingInterval = 0;
                }

                if (!variable.HistorizingSpecified)
                {
                    variable.Historizing = false;
                }
            }

            // assign missing fields for variables.
            MethodDesign method = instance as MethodDesign;

            if (method != null)
            {
                method.HasArguments = false;

                if (!method.NonExecutableSpecified)
                {
                    method.NonExecutableSpecified = false;
                }

                Parameter[] parameters = method.InputArguments;

                if (ImportParameters(method, ref parameters, "InputArgument"))
                {
                    method.HasArguments = true;
                }
                
                method.InputArguments = parameters;

                parameters = method.OutputArguments;

                if (ImportParameters(method, ref parameters, "OutputArgument"))
                {
                    method.HasArguments = true;
                }

                method.OutputArguments = parameters;
            }
        }

        /// <summary>
        /// Creates a property placeholder for the arguments of a method.
        /// </summary>
        private PropertyDesign CreateArgumentProperty(MethodDesign method, string type)
        {
            PropertyDesign property = new PropertyDesign();

            property.Parent = method;
            property.ReferenceType = new XmlQualifiedName("HasProperty", DefaultNamespace);
            property.TypeDefinition = new XmlQualifiedName("PropertyType", DefaultNamespace);
            property.SymbolicId = new XmlQualifiedName(NodeDesign.CreateSymbolicId(method.SymbolicId.Name, type), method.SymbolicId.Namespace);
            property.SymbolicName = new XmlQualifiedName(type, DefaultNamespace);

            // use the name to assign a browse name.
            SetBrowseName(property);

            property.AccessLevel = AccessLevel.Read;
            property.ValueRank = ValueRank.Array;
            property.DataType = new XmlQualifiedName("Argument", DefaultNamespace);
            property.DecodedValue = null;
            property.DefaultValue = null;
            //property.Description = new LocalizedText();
            //property.Description.Value  = String.Format("The {1} for the {0} method.", method.SymbolicName.Name, type);
            //property.Description.Key = String.Format("{0}_{1}_Description", property.SymbolicId.Name, type);
            //property.Description.IsAutogenerated = true;
            property.DisplayName = new LocalizedText();
            property.DisplayName.Value = property.BrowseName;
            property.DisplayName.Key = String.Format("{0}_(1)_DisplayName", property.SymbolicId.Name, type);
            property.DisplayName.IsAutogenerated = true;
            property.Historizing = false;
            property.MinimumSamplingInterval = 0;
            property.ModellingRule = ModellingRule.MandatoryShared;
            property.WriteAccess = 0;

            property.DataTypeNode = (DataTypeDesign)FindNode(
                property.DataType,
                typeof(DataTypeDesign),
                method.SymbolicId.Name,
                "DataType");

            property.TypeDefinitionNode = (VariableTypeDesign)FindNode(
                property.TypeDefinition,
                typeof(VariableTypeDesign),
                method.SymbolicId.Name,
                "VariableType");

            m_nodes.Add(property.SymbolicId, property);
            Log("Imported {1}: {0}", property.SymbolicId.Name, property.GetType().Name);

            return property;
        }

        /// <summary>
        /// Imports a list of parameters.
        /// </summary>
        private bool ImportParameters(NodeDesign node, ref Parameter[] parameters, string parameterType)
        {
            if (parameters == null || parameters.Length == 0)
            {
                return false;
            }

            int id = 0;
            List<Parameter> filteredParameters = new List<Parameter>();

            foreach (Parameter parameter in parameters)
            {
                if (IsExcluded(parameter))
                {
                    continue;
                }

                filteredParameters.Add(parameter);

                parameter.Parent = node;

                // check name.
                if (String.IsNullOrEmpty(parameter.Name))
                {
                    throw Exception("The node has a parameter without a name: {0}.", node.SymbolicId.Name);
                }

                string name = parameter.Name;

                // assign an id.
                if (parameter.IdentifierSpecified)
                {
                    id = parameter.Identifier;
                }
                else if (!String.IsNullOrEmpty(parameter.BitMask))
                {
                    ulong mask = 0;

                    if (UInt64.TryParse(parameter.BitMask, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out mask))
                    {
                        var bytes = BitConverter.GetBytes(mask);
                        parameter.Identifier = BitConverter.ToInt32(bytes, 0);
                        parameter.IdentifierSpecified = true;
                    }
                }

                if (!parameter.IdentifierSpecified)
                {
                    parameter.Identifier = ++id;
                    parameter.IdentifierSpecified = true;
                }

                // update id if specified in name.
                int index = name.LastIndexOf(NodeDesign.PathChar[0]);

                if (index != -1)
                {
                    for (int ii = index+1; ii < name.Length; ii++)
                    {
                        if (!Char.IsDigit(name[ii]))
                        {
                            index = -1;
                            break;
                        }
                    }

                    if (index != -1)
                    {
                        id = parameter.Identifier = Convert.ToInt32(name.Substring(index+1));
                        parameter.IdentifierInName = true;
                    }
                }

                // add a description.
                if (parameter.Description == null)
                {
                    //parameter.Description = new LocalizedText();
                    //parameter.Description.Value = String.Format("A description for the {0} {1}.", parameter.Name, parameterType.ToLower());
                    //parameter.Description.IsAutogenerated = true;
                }

                else if (String.IsNullOrEmpty(parameter.Description.Key))
                {
                    parameter.Description.Key = String.Format("{0}_{1}_{2}_Description", node.SymbolicId.Name, parameterType, parameter.Name);
                }

                // add a datatype.
                if (IsNull(parameter.DataType))
                {
                    parameter.DataType = new XmlQualifiedName("BaseDataType", DefaultNamespace);
                }
            }

            parameters = filteredParameters.ToArray();

            if (parameters == null || parameters.Length == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Imports a reference.
        /// </summary>
        private void ImportReference(NodeDesign source, Reference reference)
        {
            reference.SourceNode = source;

            if (IsNull(reference.TargetId))
            {
                throw Exception("The TargetId for a reference is not valid: {0}.", source.SymbolicId.Name);
            }

            Log("Import Reference: {0} => {1} => {2}", reference.SourceNode.SymbolicName.Name, reference.ReferenceType.Name, reference.TargetId.Name);
        }

        /// <summary>
        /// Validates a node.
        /// </summary>
        private void Validate(NodeDesign node)
        {
            if (IsDeclaration(node))
            {
                return;
            }

            if (node is TypeDesign)
            {
                ValidateType((TypeDesign)node);
            }

            if (node is InstanceDesign)
            {
                ValidateInstance((InstanceDesign)node);
            }

            if (node.HasChildren)
            {
                foreach (NodeDesign child in node.Children.Items)
                {
                    Validate(child);
                }
            }

            if (node.HasReferences)
            {
                List<Reference> references = new List<Reference>();

                foreach (var reference in node.References)
                {
                    try
                    {
                        ValidateReference(reference);
                        references.Add(reference);
                    }
                    catch (Exception e)
                    {
                        OutputError($"Ignoring InvalidReference {node.SymbolicId.Name} => {reference.TargetId.Name}. [{e.Message}]");
                    }
                }

                node.References = references.ToArray();
            }
        }

        /// <summary>
        /// Validates the type.
        /// </summary>
        private void ValidateType(TypeDesign type)
        {
            // assign missing fields for object types.
            ObjectTypeDesign objectType = type as ObjectTypeDesign;

            if (objectType != null)
            {
                /*
                if (objectType.SymbolicName != new XmlQualifiedName("BaseObjectType", DefaultNamespace))
                {
                    objectType.BaseTypeNode = (TypeDesign)FindNode(
                        objectType.BaseType,
                        typeof(ObjectTypeDesign),
                        objectType.SymbolicId.Name,
                        "BaseType");
                }
                */
            }

            // assign missing fields for variable types.
            VariableTypeDesign variableType = type as VariableTypeDesign;

            if (variableType != null)
            {
                /*
                if (variableType.SymbolicName != new XmlQualifiedName("BaseVariableType", DefaultNamespace))
                {
                    variableType.BaseTypeNode = (TypeDesign)FindNode(
                        variableType.BaseType,
                        typeof(VariableTypeDesign),
                        variableType.SymbolicId.Name,
                        "BaseType");

                    if (variableType.BaseTypeNode != null)
                    {
                        if (variableType.DataType == null || variableType.DataType == new XmlQualifiedName("BaseDataType", DefaultNamespace))
                        {
                            variableType.DataType = ((VariableTypeDesign)variableType.BaseTypeNode).DataType;

                            ValueRank valueRank = ((VariableTypeDesign)variableType.BaseTypeNode).ValueRank;

                            if (!variableType.ValueRankSpecified && valueRank != ValueRank.ScalarOrArray)
                            {
                                variableType.ValueRank = valueRank;
                                variableType.ValueRankSpecified = true;
                            }
                        }
                    }
                }
                */

                variableType.DataTypeNode = (DataTypeDesign)FindNode(
                    variableType.DataType,
                    typeof(DataTypeDesign),
                    type.SymbolicId.Name,
                    "DataType");

                if (variableType.DefaultValue != null)
                {
                    XmlDecoder decoder = new XmlDecoder(variableType.DefaultValue, m_context);

                    Opc.Ua.TypeInfo typeInfo = null;
                    variableType.DecodedValue = decoder.ReadVariantContents(out typeInfo);

                    if (typeInfo != null)
                    {
                        variableType.ValueRank = (typeInfo.ValueRank == ValueRanks.Scalar)?ValueRank.Scalar:ValueRank.Array;
                        variableType.ValueRankSpecified = true;
                    }

                    decoder.Close();
                }

                if (variableType.BaseTypeNode != null)
                {
                    VariableTypeDesign baseType = variableType.BaseTypeNode as VariableTypeDesign;

                    if (baseType.DataType != new XmlQualifiedName("BaseDataType", DefaultNamespace))
                    {
                        if (variableType.DataType == new XmlQualifiedName("BaseDataType", DefaultNamespace))
                        {
                            variableType.DataType = baseType.DataType;
                            variableType.DataTypeNode = baseType.DataTypeNode;
                        }

                        if (baseType.DataType != variableType.DataType)
                        {
                            var ii = variableType.DataTypeNode.BaseType;

                            if (ii != null && ii != baseType.DataType)
                            {
                                var parent = (DataTypeDesign)FindNode(
                                    ii,
                                    typeof(DataTypeDesign),
                                    variableType.SymbolicId.Name,
                                    "DataType");

                                ii = parent.BaseType;
                            }

                            if (ii != baseType.DataType)
                            {
                                throw Exception("The VariableType subtype cannot redefine the datatype. {0}", type.SymbolicId.Name);
                            }
                        }
                    }
                }
            }

            // assign missing fields for data types.
            DataTypeDesign dataType = type as DataTypeDesign;

            if (dataType != null)
            {
                /*
                if (dataType.SymbolicName != new XmlQualifiedName("BaseDataType", DefaultNamespace))
                {
                    dataType.BaseTypeNode = (TypeDesign)FindNode(
                        dataType.BaseType,
                        typeof(DataTypeDesign),
                        dataType.SymbolicId.Name,
                        "BaseType");
                }
                */

                ValidateParameters(dataType, dataType.Fields);

                dataType.IsStructure   = IsTypeOf(dataType, new XmlQualifiedName("Structure", DefaultNamespace));
                dataType.IsEnumeration = IsTypeOf(dataType, new XmlQualifiedName("Enumeration", DefaultNamespace)) || dataType.IsOptionSet;
                dataType.BasicDataType = GetBasicDataType(dataType);

                if (!dataType.IsStructure)
                {
                    if (dataType.HasEncodings)
                    {
                        throw Exception("The datatype has encodings but does not inherit from a structure: {0}", type.SymbolicId.Name);
                    }

                    if (dataType.IsEnumeration)
                    {
                        if (!dataType.HasFields && !dataType.IsAbstract)
                        {
                            throw Exception("The datatype is an enumeration with no fields: {0}", type.SymbolicId.Name);
                        }
                    }
                    else
                    {
                        if (dataType.HasFields && !dataType.IsOptionSet)
                        {
                            throw Exception("The datatype is a simple type but it has fields defined: {0}", type.SymbolicId.Name);
                        }
                    }
                }
                else
                {
                    // add the default encodings.
                    if (!dataType.HasEncodings)
                    {
                        EncodingDesign xmlEncoding = CreateEncoding(dataType, new XmlQualifiedName("DefaultXml", DefaultNamespace));
                        EncodingDesign binaryEncoding = CreateEncoding(dataType, new XmlQualifiedName("DefaultBinary", DefaultNamespace));

                        if (!EmbeddedModelDesignPath.EndsWith("v103"))
                        {
                            EncodingDesign jsonEncoding = CreateEncoding(dataType, new XmlQualifiedName("DefaultJson", DefaultNamespace));
                            dataType.Encodings = new EncodingDesign[] { xmlEncoding, binaryEncoding, jsonEncoding };
                        }
                        else
                        {
                            dataType.Encodings = new EncodingDesign[] { xmlEncoding, binaryEncoding };
                        }
                        
                        dataType.HasEncodings = true;
                    }

                    // check for duplicates.
                    Dictionary<XmlQualifiedName,EncodingDesign> encodings = new Dictionary<XmlQualifiedName,EncodingDesign>();

                    foreach (EncodingDesign encoding in dataType.Encodings)
                    {
                        if (encodings.ContainsKey(encoding.SymbolicName))
                        {
                            throw Exception("The datatype has a duplicate encoding defined: {0} {1}", dataType.SymbolicId.Name, encoding.SymbolicName.Name);
                        }

                        encodings.Add(encoding.SymbolicName, encoding);
                    }
                }
            }

            // assign missing fields for references types.
            ReferenceTypeDesign referenceType = type as ReferenceTypeDesign;

            if (referenceType != null)
            {
                /*
                if (referenceType.SymbolicName != new XmlQualifiedName("References", DefaultNamespace))
                {
                    referenceType.BaseTypeNode = (TypeDesign)FindNode(
                        referenceType.BaseType,
                        typeof(ReferenceTypeDesign),
                        referenceType.SymbolicId.Name,
                        "BaseType");
                }
                */
            }
        }

        /// <summary>
        /// Imports an InstanceDesign
        /// </summary>
        private void ValidateInstance(InstanceDesign instance)
        {
            // set the reference type.
            if (instance.ReferenceType == null)
            {
                if (instance.Parent != null)
                {
                    ReferenceTypeDesign refernceType = (ReferenceTypeDesign)FindNode(
                        instance.ReferenceType,
                        typeof(ReferenceTypeDesign),
                        instance.SymbolicId.Name,
                        "ReferenceType");
                }
            }

            // assign missing fields for object.
            ObjectDesign objectd = instance as ObjectDesign;

            if (objectd != null)
            {
                objectd.TypeDefinitionNode = (TypeDesign)FindNode(
                    instance.TypeDefinition,
                    typeof(ObjectTypeDesign),
                    instance.SymbolicId.Name,
                    "TypeDefinition");
            }

            // assign missing fields for variables.
            VariableDesign variable = instance as VariableDesign;

            if (variable != null)
            {
                if (variable is PropertyDesign && variable.HasChildren)
                {
                    throw Exception("The Property ({0}) has children defined.", variable.SymbolicId.Name);
                }

                variable.TypeDefinitionNode = (TypeDesign)FindNode(
                    instance.TypeDefinition,
                    typeof(VariableTypeDesign),
                    instance.SymbolicId.Name,
                    "TypeDefinition");

                if (variable.TypeDefinitionNode != null)
                {
                    if (variable.DataType == null || variable.DataType == new XmlQualifiedName("BaseDataType", DefaultNamespace))
                    {
                        variable.DataType = ((VariableTypeDesign)variable.TypeDefinitionNode).DataType;

                        ValueRank valueRank = ((VariableTypeDesign)variable.TypeDefinitionNode).ValueRank;

                        if (!variable.ValueRankSpecified && valueRank != ValueRank.ScalarOrArray)
                        {
                            variable.ValueRank = valueRank;
                            variable.ValueRankSpecified = true;
                        }
                    }
                }

                variable.DataTypeNode = (DataTypeDesign)FindNode(
                    variable.DataType,
                    typeof(DataTypeDesign),
                    instance.SymbolicId.Name,
                    "DataType");

                if (variable.DefaultValue != null)
                {
                    XmlDecoder decoder = new XmlDecoder(variable.DefaultValue, m_context);

                    Opc.Ua.TypeInfo typeInfo = null;
                    variable.DecodedValue = decoder.ReadVariantContents(out typeInfo);

                    if (typeInfo != null)
                    {
                        variable.ValueRank = (typeInfo.ValueRank == ValueRanks.Scalar)?ValueRank.Scalar:ValueRank.Array;
                        variable.ValueRankSpecified = true;
                    }

                    decoder.Close();
                }
            }

            // assign missing fields for methods.
            MethodDesign method = instance as MethodDesign;

            if (method != null)
            {
                if (instance.TypeDefinition != null)
                {
                    method.MethodType = (MethodDesign)FindNode(
                        instance.TypeDefinition,
                        typeof(MethodDesign),
                        instance.SymbolicId.Name,
                        "TypeDefinition");

                    method.Description = method.MethodType.Description;
                    method.InputArguments = method.MethodType.InputArguments;
                    method.OutputArguments = method.MethodType.OutputArguments;
                    method.HasArguments = (method.InputArguments != null && method.InputArguments.Length > 0) || (method.OutputArguments != null && method.OutputArguments.Length > 0);
                }

                ValidateParameters(method, method.InputArguments);
                ValidateParameters(method, method.OutputArguments);

                if (method.Parent != null)
                {
                    List<InstanceDesign> children = new List<InstanceDesign>();

                    if (method.Children != null && method.Children.Items != null)
                    {
                        children.AddRange(method.Children.Items);
                    }

                    if (method.InputArguments != null)
                    {
                        children.Add(CreateArgumentProperty(method, "InputArguments"));
                    }

                    if (method.OutputArguments != null)
                    {
                        children.Add(CreateArgumentProperty(method, "OutputArguments"));
                    }

                    if (children.Count > 0)
                    {
                        method.Children = new ListOfChildren();
                        method.Children.Items = children.ToArray();
                        method.HasChildren = true;
                    }
                }
            }
        }

        /// <summary>
        /// Validates a list of parameters
        /// </summary>
        private void ValidateParameters(NodeDesign node, Parameter[] parameters)
        {
            if (parameters != null)
            {
                foreach (Parameter parameter in parameters)
                {
                    parameter.DataTypeNode = (DataTypeDesign)FindNode(
                        parameter.DataType,
                        typeof(DataTypeDesign),
                        node.SymbolicId.Name,
                        "DataType");

                    if (IsTypeOf(parameter.DataTypeNode, new XmlQualifiedName("Structure", DefaultNamespace)))
                    {
                        if (parameter.AllowSubTypes && !UseAllowSubtypes)
                        {
                            parameter.DataTypeNode = (DataTypeDesign)FindNode(
                                new XmlQualifiedName("Structure", DefaultNamespace),
                                typeof(DataTypeDesign),
                                node.SymbolicId.Name,
                                "DataType");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Validates an Reference.
        /// </summary>
        private void ValidateReference(Reference reference)
        {
            ReferenceTypeDesign referenceType = (ReferenceTypeDesign)FindNode(
                reference.ReferenceType,
                typeof(ReferenceTypeDesign),
                reference.SourceNode.SymbolicId.Name,
                "ReferenceType");

            reference.TargetNode = FindNode(
                reference.TargetId,
                typeof(NodeDesign),
                reference.SourceNode.SymbolicId.Name,
                "TargetId");
        }

        /// <summary>
        /// Finds the node.
        /// </summary>
        private NodeDesign FindNode(XmlQualifiedName symbolicId, Type requiredType, string sourceName, string referenceName)
        {
            if (IsNull(symbolicId))
            {
                throw Exception("The {0} reference for node is missing: {1}.", referenceName, sourceName);
            }

            NodeDesign target = null;

            if (!m_nodes.TryGetValue(symbolicId, out target))
            {
                throw Exception("The {0} reference for node {1} is not valid: {2}.", referenceName, sourceName, symbolicId.Name);
            }

            if (!requiredType.IsInstanceOfType(target))
            {
                throw Exception("The {0} reference for node {1} is not the expected type: {2}.", referenceName, sourceName, requiredType.Name);
            }

            return target;
        }

        /// <summary>
        /// Returns true is the type is a subtype of the specified type.
        /// </summary>
        private bool IsTypeOf(TypeDesign type, XmlQualifiedName superType)
        {
            if (type.SymbolicId == superType)
            {
                return true;
            }

            if (IsNull(type.BaseType))
            {
                return false;
            }

            NodeDesign node = null;

            if (!m_nodes.TryGetValue(type.BaseType, out node))
            {
                return false;
            }

            return IsTypeOf(node as TypeDesign, superType);
        }

        /// <summary>
        /// Creates an encoding object.
        /// </summary>
        private EncodingDesign CreateEncoding(DataTypeDesign dataType, XmlQualifiedName encodingName)
        {
            var symbolicId = new XmlQualifiedName(String.Format("{0}_Encoding_{1}", dataType.SymbolicId.Name, encodingName.Name), dataType.SymbolicId.Namespace);

            EncodingDesign encoding = new EncodingDesign();
            encoding.SymbolicName = encodingName;
            encoding.SymbolicId = symbolicId;
            encoding.ReleaseStatus = dataType.ReleaseStatus;
            encoding.Purpose = dataType.Purpose;

            NodeDesign target = null;

            if (m_nodes.TryGetValue(symbolicId, out target))
            {
                encoding.NumericId = target.NumericId;
                encoding.NumericIdSpecified = target.NumericIdSpecified;
                m_nodes.Remove(symbolicId);
            }

            // use the name to assign a browse name.
            SetBrowseName(encoding);

            encoding.TypeDefinition = new XmlQualifiedName("DataTypeEncodingType", DefaultNamespace);
            encoding.Parent = dataType;

            encoding.TypeDefinitionNode = (ObjectTypeDesign)FindNode(
                encoding.TypeDefinition,
                typeof(ObjectTypeDesign),
                encoding.SymbolicId.Name,
                "DataTypeEncodingType");

            // add a display name.
            if (encoding.DisplayName == null || String.IsNullOrEmpty(encoding.DisplayName.Value))
            {
                encoding.DisplayName = new LocalizedText();
                encoding.DisplayName.Value = encoding.BrowseName;
                encoding.DisplayName.IsAutogenerated = true;
            }

            // add a description name.
            if (encoding.Description == null || String.IsNullOrEmpty(encoding.Description.Value))
            {
                //encoding.Description = new LocalizedText();
                //encoding.Description.Value = String.Format("The {0} Encoding for the {1} data type.", encoding.SymbolicName.Name, dataType.SymbolicName.Name);
                //encoding.Description.IsAutogenerated = true;
            }

            m_nodes.Add(encoding.SymbolicId, encoding);
            Log("Created {1}: {0}", encoding.SymbolicId.Name, encoding.GetType().Name);

            return encoding;
        }

        public bool IsExcluded(NodeDesign node)
        {
            if (m_exclusions != null)
            {
                foreach (var exclusion in m_exclusions)
                {
                    if (exclusion == node.ReleaseStatus.ToString())
                    {
                        return true;
                    }

                    if (exclusion == node.Purpose.ToString())
                    {
                        return true;
                    }

                    if (node.Category != null)
                    {
                        if (node.Category.Contains(exclusion))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool IsExcluded(CodeGenerator.DataType dataType)
        {
            if (m_exclusions != null)
            {
                foreach (var exclusion in m_exclusions)
                {
                    if (exclusion == dataType.ReleaseStatus.ToString())
                    {
                        return true;
                    }

                    if (exclusion == dataType.Purpose.ToString())
                    {
                        return true;
                    }

                    if (dataType.Category != null)
                    {
                        if (dataType.Category.Contains(exclusion))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool IsExcluded(Parameter field)
        {
            if (m_exclusions != null)
            {
                foreach (var exclusion in m_exclusions)
                {
                    if (exclusion == field.ReleaseStatus.ToString())
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        /// <summary>
        /// Returns the NodeClass for the node.
        /// </summary>
        private NodeClass GetNodeClass(NodeDesign node)
        {
            if (node is ObjectDesign) return NodeClass.Object;
            if (node is ObjectTypeDesign) return NodeClass.ObjectType;
            if (node is DataTypeDesign) return NodeClass.DataType;
            if (node is ReferenceTypeDesign) return NodeClass.ReferenceType;
            if (node is MethodDesign) return NodeClass.Method;
            if (node is VariableDesign) return NodeClass.Variable;
            if (node is VariableTypeDesign) return NodeClass.VariableType;
            if (node is ViewDesign) return NodeClass.View;

            return NodeClass.Unspecified;
        }

        /// <summary>
        /// Updates the instance declarations for all nodes.
        /// </summary>
        private void UpdateOverriddenNodes(TypeDesign type)
        {
            if (type == null)
            {
                return;
            }

            UpdateOverriddenNodes(type.BaseTypeNode);

            if (type.HasChildren)
            {
                foreach (InstanceDesign child in type.Children.Items)
                {
                    child.OveriddenNode = FindOverriddenNode(type.BaseTypeNode, child);

                    if (child.OveriddenNode != null)
                    {
                        UpdateFromTemplate(child, child.OveriddenNode);
                    }
                }
            }
        }

        /// <summary>
        /// Updates the instance declarations for all nodes.
        /// </summary>
        private InstanceDesign FindOverriddenNode(TypeDesign type, InstanceDesign node)
        {
            if (type == null)
            {
                return null;
            }

            if (type.HasChildren)
            {
                foreach (InstanceDesign child in type.Children.Items)
                {
                    if (child.BrowseName == node.BrowseName && child.SymbolicName.Namespace == node.SymbolicName.Namespace)
                    {
                        return child;
                    }
                }
            }

            return FindOverriddenNode(type.BaseTypeNode, node);
        }

        /// <summary>
        /// Updates the instance with attributes from its parent.
        /// </summary>
        private void UpdateFromTemplate(InstanceDesign instance, InstanceDesign source)
        {
            if (instance.GetType() != source.GetType())
            {
                throw Exception("The declaration for the node has a different type: {0}.", instance.SymbolicId.Name);
            }

            instance.DisplayName = source.DisplayName;
            instance.Description = source.Description;

            VariableDesign variable = instance as VariableDesign;

            if (variable != null)
            {
                VariableDesign declaration = source as VariableDesign;

                variable.AccessLevel = declaration.AccessLevel;
                variable.MinimumSamplingInterval = declaration.MinimumSamplingInterval;
                variable.Historizing = declaration.Historizing;

                if (variable.ValueRank == ValueRank.ScalarOrArray)
                {
                    variable.ValueRank = declaration.ValueRank;
                }

                if (variable.DataType == new XmlQualifiedName("BaseDataType", DefaultNamespace))
                {
                    variable.DataType = declaration.DataType;
                    variable.DataTypeNode = declaration.DataTypeNode;
                }

                if (!IsTypeOf(variable.TypeDefinitionNode, declaration.TypeDefinition))
                {
                    variable.TypeDefinitionNode = declaration.TypeDefinitionNode;
                    variable.TypeDefinition = declaration.TypeDefinition;
                }
            }

            ObjectDesign objectd = instance as ObjectDesign;

            if (objectd != null)
            {
                ObjectDesign declaration = source as ObjectDesign;

                objectd.SupportsEvents = declaration.SupportsEvents;

                if (!IsTypeOf(objectd.TypeDefinitionNode, declaration.TypeDefinition))
                {
                    objectd.TypeDefinitionNode = declaration.TypeDefinitionNode;
                    objectd.TypeDefinition = declaration.TypeDefinition;
                }
            }
        }

        /// <summary>
        /// Updates the instance declarations for all nodes.
        /// </summary>
        private void UpdateInstanceDefinitions(NodeDesign node, bool instanceDeclarationRequired)
        {
            InstanceDesign instance = node as InstanceDesign;

            if (instance != null)
            {
                instance.InstanceDeclarationNode = FindInstanceDeclaration(instance) as InstanceDesign;

                if (instanceDeclarationRequired && instance.InstanceDeclarationNode == null)
                {
                    throw Exception("Cannot add new children to an instance declaration. Create a new type instead: {0}", instance.SymbolicId.Name);
                }

                if (instance.InstanceDeclarationNode != null)
                {
                    UpdateFromTemplate(instance, instance.InstanceDeclarationNode);
                }
            }

            if (node.HasChildren)
            {
                foreach (NodeDesign child in node.Children.Items)
                {
                    UpdateInstanceDefinitions(child, instanceDeclarationRequired);
                }
            }
        }

        /// <summary>
        /// Finds the instance declaration for a child node.
        /// </summary>
        private NodeDesign FindInstanceDeclaration(NodeDesign node)
        {
            return FindInstanceDeclarationInParent(node, new Stack<NodeDesign>());
        }

        /// <summary>
        /// Follows the parents until a type is found.
        /// </summary>
        private NodeDesign FindInstanceDeclarationInParent(NodeDesign node, Stack<NodeDesign> path)
        {
            if (node.Parent is InstanceDesign)
            {
                path.Push(node);
                return FindInstanceDeclarationInParent(node.Parent, path);
            }

            InstanceDesign instance = node as InstanceDesign;

            if (instance != null && path.Count > 0)
            {
                TypeDesign type = instance.TypeDefinitionNode;

                while (type != null)
                {
                    NodeDesign declaration = FindInstanceDeclarationInType(type, path);

                    if (declaration != null)
                    {
                        return declaration;
                    }

                    type = type.BaseTypeNode;
                }
            }

            // child does not exist anywhere.
            return null;
        }

        /// <summary>
        /// Follows the browse paths until an instance is found.
        /// </summary>
        private NodeDesign FindInstanceDeclarationInType(NodeDesign node, Stack<NodeDesign> path)
        {
            if (path.Count == 0)
            {
                return node;
            }

            NodeDesign next = path.Pop();

            if (node.HasChildren)
            {
                foreach (NodeDesign child in node.Children.Items)
                {
                    if (child.BrowseName == next.BrowseName && child.SymbolicName.Namespace == next.SymbolicName.Namespace)
                    {
                        return FindInstanceDeclarationInType(child, path);
                    }
                }
            }

            path.Push(next);

            // try following the tree under the type definition instead.
            InstanceDesign instance = node as InstanceDesign;

            if (instance != null)
            {
                TypeDesign type = instance.TypeDefinitionNode;

                while (type != null)
                {
                    NodeDesign declaration = FindInstanceDeclarationInType(type, path);

                    if (declaration != null)
                    {
                        return declaration;
                    }

                    type = type.BaseTypeNode;
                }
            }

            // child does not exist anywhere.
            return null;
        }

        /// <summary>
        /// Returns the basic type for a datatype.
        /// </summary>
        private BasicDataType GetBasicDataType(DataTypeDesign dataType)
        {
            if (dataType == null)
            {
                return BasicDataType.BaseDataType;
            }

            // check if it is a built in data type.
            if (dataType.SymbolicName.Namespace == DefaultNamespace)
            {
                foreach (string name in Enum.GetNames(typeof(BasicDataType)))
                {
                    if (name == dataType.SymbolicName.Name)
                    {
                        return (BasicDataType)Enum.Parse(typeof(BasicDataType), dataType.SymbolicName.Name);
                    }
                }
            }

            if (dataType.IsOptionSet)
            {
                return BasicDataType.Enumeration;
            }

            // recursively search hierarchy if conversion to enum fails.
            BasicDataType basicType = GetBasicDataType(dataType.BaseTypeNode as DataTypeDesign);

            // data type is user defined if a sub-type of structure.
            if (basicType == BasicDataType.Structure)
            {
                return BasicDataType.UserDefined;
            }

            return basicType;
        }
        #endregion

        #region Updated Modelling Rules
        /// <summary>
        /// Maps the event notifier flag onto a byte.
        /// </summary>
        private byte ConstructEventNotifier(bool supportsEvents)
        {
            if (supportsEvents)
            {
                return EventNotifiers.SubscribeToEvents;
            }

            return EventNotifiers.None;
        }

        /// <summary>
        /// Maps the access level enumeration onto a byte.
        /// </summary>
        private byte ConstructAccessLevel(AccessLevel accessLevel)
        {
            switch (accessLevel)
            {
                case AccessLevel.Read: return AccessLevels.CurrentRead;
                case AccessLevel.Write: return AccessLevels.CurrentWrite;
                case AccessLevel.ReadWrite: return AccessLevels.CurrentReadOrWrite;
                case AccessLevel.HistoryRead: return AccessLevels.HistoryRead;
                case AccessLevel.HistoryWrite: return AccessLevels.HistoryWrite;
                case AccessLevel.HistoryReadWrite: return AccessLevels.HistoryReadOrWrite;
      }

            return AccessLevels.None;
        }

        /// <summary>
        /// Maps the modelling rule enumeration onto a string.
        /// </summary>
        private NodeId ConstructModellingRule(ModellingRule modellingRule)
        {
            switch (modellingRule)
            {
                case ModellingRule.Mandatory: return Opc.Ua.Objects.ModellingRule_Mandatory;
                case ModellingRule.Optional: return Opc.Ua.Objects.ModellingRule_Optional;
                case ModellingRule.MandatoryPlaceholder: return Opc.Ua.Objects.ModellingRule_MandatoryPlaceholder;
                case ModellingRule.OptionalPlaceholder: return Opc.Ua.Objects.ModellingRule_OptionalPlaceholder;
                case ModellingRule.ExposesItsArray: return Opc.Ua.Objects.ModellingRule_ExposesItsArray;
            }

            return null;
        }

        /// <summary>
        /// Maps the value rank enumeration onto a integer.
        /// </summary>
        private int ConstructValueRank(ValueRank valueRank, string arrayDimensions)
        {
            switch (valueRank)
            {
                case ValueRank.Array: return ValueRanks.OneDimension;
                case ValueRank.Scalar: return ValueRanks.Scalar;
                case ValueRank.ScalarOrArray: return ValueRanks.Any;

                case ValueRank.OneOrMoreDimensions:
                {
                    if (String.IsNullOrEmpty(arrayDimensions))
                    {
                        return ValueRanks.OneOrMoreDimensions;
                    }

                    string[] dimensions = arrayDimensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    return dimensions.Length;
                }
            }

            return ValueRanks.Any;
        }

        /// <summary>
        /// Maps the array dimensions onto a constant declaration..
        /// </summary>
        private UInt32Collection ConstructArrayDimensionsRW(ValueRank valueRank, string arrayDimensions)
        {
            if (valueRank < 0 && valueRank != ValueRank.OneOrMoreDimensions)
            {
                return null;
            }

            if (String.IsNullOrEmpty(arrayDimensions))
            {
                if (valueRank == ValueRank.Array)
                {
                    return new UInt32Collection(new uint[1]);
                }

                return null;
            }

            string[] tokens = arrayDimensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens == null || tokens.Length < 1)
            {
                return null;
            }

            UInt32Collection dimensions = new UInt32Collection();

            for (int ii = 0; ii < tokens.Length; ii++)
            {
                try
                {
                    dimensions.Add(Convert.ToUInt32(tokens[ii]));
                }
                catch
                {
                    dimensions.Add(0);
                }
            }

            return dimensions;
        }

        /// <summary>
        /// Maps the array dimensions onto a constant declaration..
        /// </summary>
        private ReadOnlyList<uint> ConstructArrayDimensions(ValueRank valueRank, string arrayDimensions)
        {
            var dimensions = ConstructArrayDimensionsRW(valueRank, arrayDimensions);

            if (dimensions != null)
            {
                return new ReadOnlyList<uint>(dimensions);
            }

            return null;
        }

        private NodeId ConstructNodeId(NodeDesign node, NamespaceTable namespaceUris)
        {
            if (node == null || node.StringId != null)
            {
                return new NodeId(node.StringId, (ushort)namespaceUris.GetIndex(node.SymbolicId.Namespace));
            }

            if (node.NumericId == 0)
            {
                for (NodeDesign parent = node.Parent; parent != null; parent = parent.Parent)
                {
                    if (parent.Hierarchy != null)
                    {
                        string browsePath = node.SymbolicId.Name;

                        if (browsePath.StartsWith(parent.SymbolicId.Name) && browsePath[parent.SymbolicId.Name.Length] == NodeDesign.PathChar[0])
                        {
                            browsePath = browsePath.Substring(parent.SymbolicId.Name.Length+1);
                        }

                        HierarchyNode instance = null;

                        if (parent.Hierarchy.Nodes.TryGetValue(browsePath, out instance))
                        {
                            node = instance.Instance;
                            break;
                        }
                    }
                }
            }

            return new NodeId(node.NumericId, (ushort)namespaceUris.GetIndex(node.SymbolicId.Namespace));
        }

        private NodeId ConstructNodeId(XmlQualifiedName nodeId, NamespaceTable namespaceUris)
        {
            if (nodeId == null)
            {
                return NodeId.Null;
            }

            NodeDesign node = null;

            if (!m_nodes.TryGetValue(nodeId, out node))
            {
                return NodeId.Null;
            }

            return ConstructNodeId(node, namespaceUris);
        }

        /// <summary>
        /// Returns the browse path to the instance.
        /// </summary>
        private string GetBrowsePath(string basePath, InstanceDesign instance)
        {
            return NodeDesign.CreateSymbolicId(basePath, instance.SymbolicName.Name);
        }

        private TypeDesign MergeTypeHierarchy(TypeDesign type)
        {
            Log("Merging Type: {0}", type.SymbolicId.Name);

            TypeDesign mergedType = null;

            if (type.BaseTypeNode == null)
            {
                mergedType = type.Copy();

                mergedType.NumericId = 0;
                mergedType.NumericIdSpecified = false;
                mergedType.StringId = null;

                return mergedType;
            }

            mergedType = MergeTypeHierarchy(type.BaseTypeNode);
            MergeTypes(mergedType, type);

            return mergedType;
        }

        private void MergeTypes(TypeDesign mergedType, TypeDesign type)
        {
            mergedType.SymbolicId = type.SymbolicId;
            mergedType.SymbolicName = type.SymbolicName;
            mergedType.NumericId = type.NumericId;
            mergedType.NumericIdSpecified = type.NumericIdSpecified;
            mergedType.StringId = type.StringId;
            mergedType.ClassName = type.ClassName;
            mergedType.BrowseName = type.BrowseName;
            mergedType.DisplayName = type.DisplayName;
            mergedType.Description = type.Description;
            mergedType.BaseType = type.BaseType;
            mergedType.BaseTypeNode = type.BaseTypeNode;
            mergedType.IsAbstract = type.IsAbstract;
            mergedType.Children = null;
            mergedType.References = null;
            mergedType.Category = type.Category;
            mergedType.Purpose = type.Purpose;
            mergedType.ReleaseStatus = type.ReleaseStatus;

            VariableTypeDesign variableType = type as VariableTypeDesign;

            if (variableType != null)
            {
                MergeTypes((VariableTypeDesign)mergedType, variableType);
            }

            ObjectTypeDesign objectType = type as ObjectTypeDesign;

            if (objectType != null)
            {
                MergeTypes((ObjectTypeDesign)mergedType, objectType);
            }
        }

        private void MergeTypes(VariableTypeDesign mergedType, VariableTypeDesign variableType)
        {
            if (variableType.DecodedValue != null)
            {
                mergedType.DecodedValue = variableType.DecodedValue;
            }

            if (variableType.DataType != null && variableType.DataType != new XmlQualifiedName("BaseDataType", DefaultNamespace))
            {
                mergedType.DataType = variableType.DataType;
                mergedType.DataTypeNode = variableType.DataTypeNode;
            }

            if (variableType.ValueRankSpecified)
            {
                mergedType.ValueRank = variableType.ValueRank;
                mergedType.ValueRankSpecified = true;
            }

            if (!String.IsNullOrEmpty(variableType.ArrayDimensions))
            {
                mergedType.ArrayDimensions = variableType.ArrayDimensions;
            }

            if (variableType.AccessLevelSpecified)
            {
                mergedType.AccessLevel = variableType.AccessLevel;
                mergedType.AccessLevelSpecified = true;
            }

            if (variableType.MinimumSamplingIntervalSpecified)
            {
                mergedType.MinimumSamplingInterval = variableType.MinimumSamplingInterval;
                mergedType.MinimumSamplingIntervalSpecified = true;
            }

            if (variableType.HistorizingSpecified)
            {
                mergedType.Historizing = variableType.Historizing;
                mergedType.HistorizingSpecified = true;
            }
        }

        private void MergeTypes(ObjectTypeDesign mergedType, ObjectTypeDesign objectType)
        {
            if (objectType.SupportsEventsSpecified)
            {
                mergedType.SupportsEvents = objectType.SupportsEvents;
                mergedType.SupportsEventsSpecified = true;
            }
        }

        private NodeDesign CreateMergedInstance(XmlQualifiedName rootId, string relativePath, NodeDesign source)
        {
            Log("Merging Instance: {0} {1} {2}", rootId.Name, relativePath, source.SymbolicId.Name);

            TypeDesign type = source as TypeDesign;

            if (type != null)
            {
                if (type is ReferenceTypeDesign || type is DataTypeDesign)
                {
                    return type;
                }

                type = MergeTypeHierarchy(type);
            }

            InstanceDesign mergedInstance = null;

            InstanceDesign instance = source as InstanceDesign;

            if (instance != null)
            {
                mergedInstance = instance.Copy();

                MethodDesign method = instance as MethodDesign;

                if (method != null)
                {
                    ((MethodDesign)mergedInstance).MethodDeclarationNode = method;
                }
            }
            else
            {
                VariableTypeDesign variableType = type as VariableTypeDesign;

                if (variableType != null)
                {
                    mergedInstance = CreateMergedInstance(variableType);
                }

                ObjectTypeDesign objectType = type as ObjectTypeDesign;

                if (objectType != null)
                {
                    mergedInstance = CreateMergedInstance(objectType);
                }

                mergedInstance.SymbolicName = rootId;
                mergedInstance.NumericId = source.NumericId;
                mergedInstance.NumericIdSpecified = source.NumericIdSpecified;
                mergedInstance.StringId = source.StringId;
                mergedInstance.BrowseName = rootId.Name;
                mergedInstance.DisplayName.Value = rootId.Name;
                mergedInstance.DisplayName.IsAutogenerated = true;
                mergedInstance.TypeDefinition = source.SymbolicId;
                mergedInstance.TypeDefinitionNode = source as TypeDesign;
            }

            string instanceId = rootId.Name;

            if (!String.IsNullOrEmpty(relativePath))
            {
                instanceId = NodeDesign.CreateSymbolicId(instanceId, relativePath);
            }

            mergedInstance.SymbolicId = new XmlQualifiedName(instanceId, rootId.Namespace);

            mergedInstance.References = null;
            mergedInstance.IdentifierRequired = true;
            mergedInstance.InstanceDeclarationNode = null;
            mergedInstance.InstanceState = null;
            mergedInstance.OveriddenNode = null;
            mergedInstance.Parent = null;
            mergedInstance.Category = source.Category;
            mergedInstance.Purpose = source.Purpose;
            mergedInstance.ReleaseStatus = source.ReleaseStatus;

            Log("Created Merged Instance: {0}", mergedInstance.SymbolicId.Name);
            return mergedInstance;
        }

        private InstanceDesign CreateMergedInstance(ObjectTypeDesign type)
        {
            ObjectDesign objectd = new ObjectDesign();

            objectd.Parent = null;
            objectd.ReferenceType = null;
            objectd.ModellingRule = ModellingRule.Mandatory;
            objectd.ModellingRuleSpecified = true;
            objectd.DisplayName = new LocalizedText();

            //if (!type.Description.IsAutogenerated)
            //{
            //    objectd.Description = type.Description;
            //}

            objectd.WriteAccess = 0;
            objectd.SupportsEvents = type.SupportsEvents;
            objectd.SupportsEventsSpecified = true;
            objectd.Category = type.Category;
            objectd.Purpose = type.Purpose;
            objectd.ReleaseStatus = type.ReleaseStatus;

            return objectd;
        }

        private InstanceDesign CreateMergedInstance(VariableTypeDesign type)
        {
            VariableDesign variable = new VariableDesign();

            variable.Parent = null;
            variable.ReferenceType = null;
            variable.ModellingRule = ModellingRule.Mandatory;
            variable.ModellingRuleSpecified = true;
            variable.DisplayName = new LocalizedText();

            //if (!type.Description.IsAutogenerated)
            //{
            //    variable.Description = type.Description;
            //}

            variable.WriteAccess = 0;
            variable.DecodedValue = type.DecodedValue;
            variable.DefaultValue = type.DefaultValue;
            variable.DataType = type.DataType;
            variable.DataTypeNode = type.DataTypeNode;
            variable.ValueRank = type.ValueRank;
            variable.ValueRankSpecified = type.ValueRankSpecified;
            variable.ArrayDimensions = type.ArrayDimensions;
            variable.AccessLevel = type.AccessLevel;
            variable.AccessLevelSpecified = type.AccessLevelSpecified;
            variable.MinimumSamplingInterval = type.MinimumSamplingInterval;
            variable.MinimumSamplingIntervalSpecified = type.MinimumSamplingIntervalSpecified;
            variable.Historizing = type.Historizing;
            variable.HistorizingSpecified = type.HistorizingSpecified;
            variable.Category = type.Category;
            variable.Purpose = type.Purpose;
            variable.ReleaseStatus = type.ReleaseStatus;

            return variable;
        }

        private void UpdateMergedInstance(InstanceDesign mergedInstance, NodeDesign source)
        {
            Log("Updated Merged Instance: {0} {1}", mergedInstance.SymbolicId.Name, source.SymbolicId.Name);

            if (source.DisplayName != null && !source.DisplayName.IsAutogenerated)
            {
                mergedInstance.DisplayName = source.DisplayName;
            }

            if (source.Description != null && !source.Description.IsAutogenerated)
            {
                mergedInstance.Description = source.Description;
            }

            InstanceDesign instance = source as InstanceDesign;

            if (instance != null)
            {
                if (mergedInstance.SymbolicName != source.SymbolicName)
                {
                    mergedInstance.SymbolicName = source.SymbolicName;
                    mergedInstance.BrowseName = source.BrowseName;
                    mergedInstance.DisplayName = source.DisplayName;
                }

                UpdateMergedInstance(mergedInstance, instance);
            }
            else
            {
                VariableTypeDesign variableType = source as VariableTypeDesign;

                if (variableType != null)
                {
                    UpdateMergedInstance((VariableDesign)mergedInstance, variableType);
                }

                ObjectTypeDesign objectType = source as ObjectTypeDesign;

                if (objectType != null)
                {
                    UpdateMergedInstance((ObjectDesign)mergedInstance, objectType);
                }
            }
        }

        private void UpdateMergedInstance(InstanceDesign mergedInstance, InstanceDesign instance)
        {
            mergedInstance.ReferenceType = instance.ReferenceType;

            if (instance.ModellingRuleSpecified)
            {
                mergedInstance.ModellingRule = instance.ModellingRule;
                mergedInstance.ModellingRuleSpecified = true;
            }

            VariableDesign variable = instance as VariableDesign;

            if (variable != null)
            {
                UpdateMergedInstance((VariableDesign)mergedInstance, variable);
            }

            ObjectDesign objectd = instance as ObjectDesign;

            if (objectd != null)
            {
                UpdateMergedInstance((ObjectDesign)mergedInstance, objectd);
            }

            MethodDesign method = instance as MethodDesign;

            if (method != null)
            {
                UpdateMergedInstance((MethodDesign)mergedInstance, method);
            }
        }

        private void UpdateMergedInstance(VariableDesign mergedVariable, VariableTypeDesign variableType)
        {
            mergedVariable.TypeDefinition = variableType.SymbolicId;
            mergedVariable.TypeDefinitionNode = variableType;

            if (variableType.DecodedValue != null)
            {
                mergedVariable.DecodedValue = variableType.DecodedValue;
            }

            if (variableType.DataType != null && variableType.DataType != new XmlQualifiedName("BaseDataType", DefaultNamespace))
            {
                mergedVariable.DataType = variableType.DataType;
                mergedVariable.DataTypeNode = variableType.DataTypeNode;
            }

            if (variableType.ValueRankSpecified)
            {
                mergedVariable.ValueRank = variableType.ValueRank;
                mergedVariable.ValueRankSpecified = true;
            }

            if (!String.IsNullOrEmpty(variableType.ArrayDimensions))
            {
                mergedVariable.ArrayDimensions = variableType.ArrayDimensions;
            }

            if (variableType.AccessLevelSpecified)
            {
                mergedVariable.AccessLevel = variableType.AccessLevel;
                mergedVariable.AccessLevelSpecified = true;
            }

            if (variableType.MinimumSamplingIntervalSpecified)
            {
                mergedVariable.MinimumSamplingInterval = variableType.MinimumSamplingInterval;
                mergedVariable.MinimumSamplingIntervalSpecified = true;
            }

            if (variableType.HistorizingSpecified)
            {
                mergedVariable.Historizing = variableType.Historizing;
                mergedVariable.HistorizingSpecified = true;
            }
        }

        private void UpdateMergedInstance(VariableDesign mergedVariable, VariableDesign variable)
        {
            if (variable.TypeDefinition != null && variable.TypeDefinition != new XmlQualifiedName("BaseDataVariableType", DefaultNamespace))
            {
                mergedVariable.TypeDefinition = variable.TypeDefinition;
                mergedVariable.TypeDefinitionNode = variable.TypeDefinitionNode;
            }

            if (variable.DecodedValue != null)
            {
                mergedVariable.DecodedValue = variable.DecodedValue;
            }

            if (variable.DataType != null && variable.DataType != new XmlQualifiedName("BaseDataType", DefaultNamespace))
            {
                mergedVariable.DataType = variable.DataType;
                mergedVariable.DataTypeNode = variable.DataTypeNode;
            }

            if (variable.ValueRankSpecified)
            {
                mergedVariable.ValueRank = variable.ValueRank;
                mergedVariable.ValueRankSpecified = true;
            }

            if (!String.IsNullOrEmpty(variable.ArrayDimensions))
            {
                mergedVariable.ArrayDimensions = variable.ArrayDimensions;
            }

            if (variable.AccessLevelSpecified)
            {
                mergedVariable.AccessLevel = variable.AccessLevel;
                mergedVariable.AccessLevelSpecified = true;
            }

            if (variable.MinimumSamplingIntervalSpecified)
            {
                mergedVariable.MinimumSamplingInterval = variable.MinimumSamplingInterval;
                mergedVariable.MinimumSamplingIntervalSpecified = true;
            }

            if (variable.HistorizingSpecified)
            {
                mergedVariable.Historizing = variable.Historizing;
                mergedVariable.HistorizingSpecified = true;
            }
        }

        private void UpdateMergedInstance(ObjectDesign mergedObject, ObjectTypeDesign objectType)
        {
            mergedObject.TypeDefinition = objectType.SymbolicId;
            mergedObject.TypeDefinitionNode = objectType;

            if (objectType.SupportsEventsSpecified)
            {
                mergedObject.SupportsEvents = objectType.SupportsEvents;
                mergedObject.SupportsEventsSpecified = true;
            }
        }

        private void UpdateMergedInstance(MethodDesign mergedMethod, MethodDesign method)
        {
            if (method.NonExecutableSpecified)
            {
                mergedMethod.NonExecutable = method.NonExecutable;
                mergedMethod.NonExecutableSpecified = true;
            }
        }

        private void UpdateMergedInstance(ObjectDesign mergedObject, ObjectDesign objectd)
        {
            if (objectd.TypeDefinition != null && objectd.TypeDefinition != new XmlQualifiedName("BaseObjectType", DefaultNamespace))
            {
                mergedObject.TypeDefinition = objectd.TypeDefinition;
                mergedObject.TypeDefinitionNode = objectd.TypeDefinitionNode;
            }

            if (objectd.SupportsEventsSpecified)
            {
                mergedObject.SupportsEvents = objectd.SupportsEvents;
                mergedObject.SupportsEventsSpecified = true;
            }
        }

        private void SetOverriddenNodes(
            TypeDesign type,
            string basePath,
            Dictionary<string,InstanceDesign> nodes)
        {
            if (type.BaseTypeNode != null)
            {
                SetOverriddenNodes(type.BaseTypeNode, basePath, nodes);
            }

            if (type.Children != null && type.Children.Items != null)
            {
                for (int ii = 0; ii < type.Children.Items.Length; ii++)
                {
                    InstanceDesign instance = type.Children.Items[ii];

                    if (instance.ModellingRule == ModellingRule.ExposesItsArray || instance.ModellingRule == ModellingRule.MandatoryPlaceholder || instance.ModellingRule == ModellingRule.OptionalPlaceholder)
                    {
                        continue;
                    }

                    string browsePath = GetBrowsePath(basePath, instance);

                    SetOverriddenNodes(instance, browsePath, nodes);

                    InstanceDesign overriddenInstance = null;

                    if (nodes.TryGetValue(browsePath, out overriddenInstance))
                    {
                        bool inPath = false;

                        for (InstanceDesign current = overriddenInstance; current != null; current = current.OveriddenNode)
                        {
                            if (current.SymbolicId == instance.SymbolicId)
                            {
                                inPath = true;
                                break;
                            }
                        }

                        if (!inPath)
                        {
                            Log("OveridingInstance: {0} : {1}", instance.SymbolicId.Name, overriddenInstance.SymbolicId.Name);
                            instance.OveriddenNode = overriddenInstance;
                        }
                    }

                    // special handling for built-in properties.
                    XmlQualifiedName propertyName = new XmlQualifiedName("EnumStrings", DefaultNamespace);

                    if (instance is PropertyDesign && instance.SymbolicName == propertyName)
                    {
                        instance.OveriddenNode = (VariableDesign)FindNode(
                            new XmlQualifiedName("EnumStrings", DefaultNamespace),
                            typeof(VariableDesign),
                            instance.SymbolicId.Name,
                            propertyName.Name);
                    }

                    Log("IndexingInstance: {0} : {1}", browsePath, instance.SymbolicId.Name);
                    nodes[browsePath] = instance;
                }
            }
        }

        private void SetOverriddenNodes(
            InstanceDesign parent,
            string basePath,
            Dictionary<string, InstanceDesign> nodes)
        {
            if (parent.TypeDefinitionNode != null)
            {
                SetOverriddenNodes(parent.TypeDefinitionNode, basePath, nodes);
            }

            if (parent.Children != null && parent.Children.Items != null)
            {
                for (int ii = 0; ii < parent.Children.Items.Length; ii++)
                {
                    InstanceDesign instance = parent.Children.Items[ii];

                    string browsePath = GetBrowsePath(basePath, instance);

                    SetOverriddenNodes(instance, browsePath, nodes);

                    InstanceDesign overriddenInstance = null;

                    if (nodes.TryGetValue(browsePath, out overriddenInstance))
                    {
                        bool inPath = false;

                        for (InstanceDesign current = overriddenInstance; current != null; current = current.OveriddenNode)
                        {
                            if (current.SymbolicId == instance.SymbolicId)
                            {
                                inPath = true;
                                break;
                            }
                        }

                        if (!inPath)
                        {
                            instance.OveriddenNode = overriddenInstance;
                        }
                    }

                    nodes[browsePath] = instance;
                }
            }
        }

        /// <summary>
        /// Collects all of children for a node.
        /// </summary>
        private void SetOverriddenNodes(NodeDesign node)
        {
            if (node is ReferenceTypeDesign || node is DataTypeDesign)
            {
                return;
            }

            Dictionary<string, InstanceDesign> nodes = new Dictionary<string, InstanceDesign>();

            TypeDesign type = node as TypeDesign;

            if (type != null)
            {
                SetOverriddenNodes(type, String.Empty, nodes);
                return;
            }

            InstanceDesign instance = node as InstanceDesign;

            if (instance != null)
            {
                SetOverriddenNodes(instance, String.Empty, nodes);
                return;
            }
        }

        /// <summary>
        /// Collects all of children for a type.
        /// </summary>
        private void BuildInstanceHierarchy2(
            TypeDesign type,
            string basePath,
            List<HierarchyNode> nodes,
            List<HierarchyReference> references,
            bool suppressInverseHierarchicalAtTypeLevel,
            bool inherited)
        {
            Log("BuildHierarchy for Type: {0} : {1}", type.SymbolicId.Name, basePath);
            
            if (type.BaseTypeNode != null)
            {
                if (type is VariableTypeDesign || type is ObjectTypeDesign)
                {
                    BuildInstanceHierarchy2(type.BaseTypeNode, basePath, nodes, references, true, true);
                }
            }

            TranslateReferences(basePath, type, references, suppressInverseHierarchicalAtTypeLevel, inherited);

            if (type.Children != null && type.Children.Items != null)
            {
                for (int ii = 0; ii < type.Children.Items.Length; ii++)
                {
                    InstanceDesign instance = type.Children.Items[ii];

                    if (!String.IsNullOrEmpty(basePath) && (instance.ModellingRule == ModellingRule.None || instance.ModellingRule == ModellingRule.ExposesItsArray || instance.ModellingRule == ModellingRule.MandatoryPlaceholder || instance.ModellingRule == ModellingRule.OptionalPlaceholder))
                    {
                        continue;
                    }

                    string browsePath = GetBrowsePath(basePath, instance);

                    HierarchyNode child = new HierarchyNode();

                    child.RelativePath = browsePath;
                    child.Instance = instance;
                    child.Inherited = inherited;

                    nodes.Add(child);

                    BuildInstanceHierarchy2(instance, browsePath, nodes, references, inherited);
                }
            }
        }

        /// <summary>
        /// Collects all of children for an instance.
        /// </summary>
        private void BuildInstanceHierarchy2(
            InstanceDesign parent,
            string basePath,
            List<HierarchyNode> nodes,
            List<HierarchyReference> references,
            bool inherited)
        {
            Log("BuildHierarchy for Instance: {0} : {1}", parent.SymbolicId.Name, basePath);

            if (parent.TypeDefinitionNode != null)
            {
                BuildInstanceHierarchy2(parent.TypeDefinitionNode, basePath, nodes, references, true, inherited);
            }

            if (parent.TypeDefinition != null && parent is MethodDesign)
            {
                MethodDesign methodType = (MethodDesign)FindNode(parent.TypeDefinition, typeof(MethodDesign), parent.SymbolicId.Name, "MethodType");

                if (methodType != null)
                {
                    BuildInstanceHierarchy2(methodType, basePath, nodes, references, inherited);
                }
            }

            TranslateReferences(basePath, parent, references, false, false);

            if (parent.Children != null && parent.Children.Items != null)
            {
                bool isTypeDefinition = (parent.Parent is TypeDesign);
                
                for (int ii = 0; ii < parent.Children.Items.Length; ii++)
                {
                    InstanceDesign instance = parent.Children.Items[ii];

                    string browsePath = GetBrowsePath(basePath, instance);

                    HierarchyNode child = new HierarchyNode();

                    child.RelativePath = browsePath;
                    child.Instance = instance;
                    child.Inherited = inherited;

                    if (isTypeDefinition  && !(parent is MethodDesign) && instance.OveriddenNode == null)
                    {
                        child.AdHocInstance = true;
                    }

                    nodes.Add(child);

                    BuildInstanceHierarchy2(instance, browsePath, nodes, references, inherited);
                }
            }
        }

        private void TranslateReferences(
            string currentPath,
            NodeDesign source,
            List<HierarchyReference> references,
            bool suppressInverseHierarchicalAtTypeLevel,
            bool inherited)
        {
            if (source.References == null || source.References.Length == 0)
            {
                return;
            }

            for (int ii = 0; ii < source.References.Length; ii++)
            {
                if (source.References[ii].ReferenceType == new XmlQualifiedName("HasModelParent", DefaultNamespace))
                {
                    continue;
                }

                // suppress inhierited non-hierarchial references.
                if (inherited)
                {
                    NodeDesign target = null;

                    if (m_nodes.TryGetValue(source.References[ii].ReferenceType, out target))
                    {
                        ReferenceTypeDesign referenceType = target as ReferenceTypeDesign;

                        bool found = false;

                        while (referenceType != null)
                        {
                            if (referenceType.SymbolicName == new XmlQualifiedName("NonHierarchicalReferences", DefaultNamespace))
                            {
                                found = true;
                                break;
                            }

                            referenceType = referenceType.BaseTypeNode as ReferenceTypeDesign;
                        }

                        if (found)
                        {
                            continue;
                        }
                    }
                }

                if (suppressInverseHierarchicalAtTypeLevel && source.References[ii].IsInverse && source.References[ii].ReferenceType == new XmlQualifiedName("Organizes", DefaultNamespace))
                {
                    continue;
                }

                HierarchyReference reference = TranslateReference(
                    currentPath,
                    source.SymbolicId,
                    source.References[ii]);

                references.Add(reference);

                Log("Translated Reference: {0} => {1} => {2}",
                    ((String.IsNullOrEmpty(reference.SourcePath)) ? source.SymbolicId.Name : reference.SourcePath),
                    reference.ReferenceType.Name,
                    ((reference.TargetId != null) ? reference.TargetId.Name : reference.TargetPath));
            }
        }

        private HierarchyReference TranslateReference(
            string currentPath,
            XmlQualifiedName sourceId,
            Reference reference)
        {
            if (currentPath == null)
            {
                currentPath = String.Empty;
            }

            HierarchyReference mergedReference = new HierarchyReference();

            mergedReference.SourcePath = currentPath;
            mergedReference.ReferenceType = reference.ReferenceType;
            mergedReference.IsInverse = reference.IsInverse;
            mergedReference.TargetId = reference.TargetId;

            if (reference.TargetId == null || sourceId.Namespace != reference.TargetId.Namespace)
            {
                return mergedReference;
            }

            string[] currentPathParts = currentPath.Split(new char[] { NodeDesign.PathChar[0] }, StringSplitOptions.RemoveEmptyEntries);
            string[] sourceIdParts = sourceId.Name.Split(new char[] { NodeDesign.PathChar[0] }, StringSplitOptions.RemoveEmptyEntries);
            string[] targetIdParts = reference.TargetId.Name.Split(new char[] { NodeDesign.PathChar[0] }, StringSplitOptions.RemoveEmptyEntries);

            // find the common root in the type declaration.
            string[] targetPath = null;
            string[] sourcePath = null;

            if (sourceIdParts.Length == 0 || targetIdParts.Length == 0 || targetIdParts[0] != sourceIdParts[0])
            {
                return mergedReference;
            }

            for (int ii = 0; ii < sourceIdParts.Length; ii++)
            {
                if (ii >= targetIdParts.Length)
                {
                    sourcePath = new string[sourceIdParts.Length - ii];
                    Array.Copy(sourceIdParts, ii, sourcePath, 0, sourcePath.Length);
                    targetPath = new string[0];
                    break;
                }

                if (targetIdParts[ii] != sourceIdParts[ii])
                {
                    sourcePath = new string[sourceIdParts.Length - ii];
                    Array.Copy(sourceIdParts, ii, sourcePath, 0, sourcePath.Length);
                    targetPath = new string[targetIdParts.Length - ii];
                    Array.Copy(targetIdParts, ii, targetPath, 0, targetPath.Length);
                    break;
                }
            }

            // no common root.
            if (sourcePath == null)
            {
                sourcePath = new string[0];
                targetPath = new string[targetIdParts.Length - sourceIdParts.Length];
                Array.Copy(targetIdParts, sourceIdParts.Length, targetPath, 0, targetPath.Length);
            }

            // find the new root.
            string[] targetRoot = null;

            for (int ii = 1; ii <= sourcePath.Length - 1; ii++)
            {
                if (ii > currentPathParts.Length)
                {
                    return mergedReference;
                }

                if (currentPathParts[currentPathParts.Length - ii] != sourcePath[sourcePath.Length - ii])
                {
                    targetRoot = new string[currentPathParts.Length - ii];
                    Array.Copy(currentPathParts, 0, targetRoot, 0, targetRoot.Length);
                    break;
                }
            }

            // no common root.
            if (targetRoot == null)
            {
                targetRoot = new string[currentPathParts.Length - sourcePath.Length];
                Array.Copy(currentPathParts, 0, targetRoot, 0, targetRoot.Length);
            }

            StringBuilder builder = new StringBuilder();

            if (targetRoot != null)
            {
                for (int ii = 0; ii < targetRoot.Length; ii++)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append(NodeDesign.PathChar);
                    }

                    builder.Append(targetRoot[ii]);
                }
            }

            if (targetPath != null)
            {
                for (int ii = 0; ii < targetPath.Length; ii++)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append(NodeDesign.PathChar);
                    }

                    builder.Append(targetPath[ii]);
                }
            }

            mergedReference.TargetId = null;
            mergedReference.TargetPath = builder.ToString();

            return mergedReference;
        }

        /// <summary>
        /// Collects all of children for a node.
        /// </summary>
        private void BuildInstanceHierarchy2(
            NodeDesign node,
            List<HierarchyNode> nodes,
            List<HierarchyReference> references)
        {
            TypeDesign type = node as TypeDesign;

            if (type != null)
            {
                BuildInstanceHierarchy2(type, String.Empty, nodes, references, false, false);
                return;
            }

            InstanceDesign instance = node as InstanceDesign;

            if (instance != null)
            {
                BuildInstanceHierarchy2(instance, String.Empty, nodes, references, false);
                return;
            }
        }

        private Hierarchy BuildInstanceHierarchy2(ModelDesign dictionary, NodeDesign root)
        {
            Log("Building InstanceHierarchy: {0}", root.SymbolicId.Name);

            SetOverriddenNodes(root);

            // collect all of the nodes that define the hierachy.
            List<HierarchyNode> nodes = new List<HierarchyNode>();
            List<HierarchyReference> references = new List<HierarchyReference>();
            BuildInstanceHierarchy2(root, nodes, references);

            Hierarchy hierarchy = new Hierarchy();
            hierarchy.References = references;

            XmlQualifiedName rootId = root.SymbolicId;

            // add root node.
            InstanceDesign instance = root as InstanceDesign;

            if (instance == null)
            {
                rootId = new XmlQualifiedName(root.SymbolicId.Name + "Instance", root.SymbolicId.Namespace);
            }

            HierarchyNode rootNode = new HierarchyNode();
            rootNode.RelativePath = String.Empty;

            if (instance == null || instance.TypeDefinitionNode == null)
            {
                rootNode.Instance = CreateMergedInstance(rootId, String.Empty, root);
            }
            else
            {
                rootNode.Instance = CreateMergedInstance(rootId, String.Empty, instance.TypeDefinitionNode);

                if (root.SymbolicName == rootNode.Instance.SymbolicName)
                {
                    rootNode.Instance.BrowseName = root.BrowseName;
                    rootNode.Instance.DisplayName = root.DisplayName;
                }

                UpdateMergedInstance((InstanceDesign)rootNode.Instance, root);
            }

            rootNode.ExplicitlyDefined = false;

            hierarchy.Nodes.Add(String.Empty, rootNode);
            hierarchy.NodeList.Add(rootNode);

            // build instance hierachy.
            for (int ii = 0; ii < nodes.Count; ii++)
            {
                HierarchyNode node = nodes[ii];

                bool explicitlyDefined = false;

                for (NodeDesign parent = node.Instance; parent != null; parent = parent.Parent)
                {
                    if (parent.SymbolicId == root.SymbolicId)
                    {
                        explicitlyDefined = true;
                        break;
                    }
                }

                HierarchyNode mergedNode = null;

                if (!hierarchy.Nodes.TryGetValue(node.RelativePath, out mergedNode))
                {
                    mergedNode = new HierarchyNode();
                    mergedNode.RelativePath = node.RelativePath;
                    mergedNode.Instance = CreateMergedInstance(root.SymbolicId, node.RelativePath, node.Instance);
                    mergedNode.ExplicitlyDefined = false;
                    mergedNode.Inherited = node.Inherited;
                    mergedNode.AdHocInstance = node.AdHocInstance;

                    hierarchy.Nodes.Add(node.RelativePath, mergedNode);
                    hierarchy.NodeList.Add(mergedNode);
                }
                else
                {
                    UpdateMergedInstance((InstanceDesign)mergedNode.Instance, node.Instance);
                }

                if (mergedNode.OverriddenNodes == null)
                {
                    mergedNode.OverriddenNodes = new List<NodeDesign>();
                }

                mergedNode.OverriddenNodes.Add(node.Instance);

                if (explicitlyDefined)
                {
                    mergedNode.ExplicitlyDefined = true;
                }
            }

            return hierarchy;
        }

        /// <summary>
        /// Removes the modelling rules for instances.
        /// </summary>
        private void ClearModellingRules(BaseInstanceState root)
        {
            if (root == null)
            {
                return;
            }
            root.ModellingRuleId = null;

            SystemContext context = new SystemContext();
            context.NamespaceUris = this.m_context.NamespaceUris;

            List<BaseInstanceState> children = new List<BaseInstanceState>();
            root.GetChildren(context, children);

            for (int ii = 0; ii < children.Count; ii++)
            {
                ClearModellingRules(children[ii]);
            }
        }

        private Export.ReleaseStatus ToReleaseStatus(ReleaseStatus input)
        {
            switch (input)
            {
                default:
                case ReleaseStatus.Released: { return Export.ReleaseStatus.Released; }
                case ReleaseStatus.Deprecated: { return Export.ReleaseStatus.Deprecated; }
                case ReleaseStatus.RC:
                case ReleaseStatus.Draft: { return Export.ReleaseStatus.Draft; }
            }
        }
        private void CreateNodeState(NodeDesign root, NamespaceTable namespaceUris)
        {
            if (root is InstanceDesign)
            {
                root.State = CreateNodeState(
                    null,
                    String.Empty,
                    root.Hierarchy,
                    root.Hierarchy.NodeList[0].Instance,
                    false,
                    false,
                    namespaceUris);

                ClearModellingRules(root.State as BaseInstanceState);
            }
            else
            {
                root.State = CreateNodeState(
                    null,
                    String.Empty,
                    root.Hierarchy,
                    root,
                    true,
                    true,
                    namespaceUris);

                root.State.Categories = null;
                root.State.ReleaseStatus = ToReleaseStatus(root.ReleaseStatus);

                if (!String.IsNullOrEmpty(root.Category))
                {
                    root.State.Categories = root.Category.Split(new char[] { ',' });
                }

                if (root.PartNo != 0)
                {
                    root.State.Specification = $"Part{root.PartNo}";
                }
            }

            if (root.Hierarchy != null && root is TypeDesign)
            {
                HierarchyNode hierarchyNode = null;

                if (root.Hierarchy.Nodes.TryGetValue(String.Empty, out hierarchyNode))
                {
                    if (hierarchyNode.Identifier != null)
                    {
                        if (hierarchyNode.Identifier is uint)
                        {
                            hierarchyNode.Instance.NumericId = (uint)hierarchyNode.Identifier;
                            hierarchyNode.Instance.NumericIdSpecified = true;
                        }
                        else if (hierarchyNode.Identifier is string)
                        {
                            hierarchyNode.Instance.StringId = (string)hierarchyNode.Identifier;
                        }
                    }

                    root.InstanceState = hierarchyNode.Instance.State = CreateNodeState(
                        null,
                        String.Empty,
                        root.Hierarchy,
                        hierarchyNode.Instance,
                        false,
                        false,
                        namespaceUris);

                    if (root.InstanceState.ReleaseStatus == Export.ReleaseStatus.Released || root.InstanceState.Categories != null)
                    {
                        root.InstanceState.Categories = null;
                        root.InstanceState.ReleaseStatus = ToReleaseStatus(hierarchyNode.Instance.ReleaseStatus);

                        if (!String.IsNullOrEmpty(root.Category))
                        {
                            root.InstanceState.Categories = root.Category.Split(new char[] { ',' });
                        }

                        if (root.PartNo != 0)
                        {
                            root.InstanceState.Specification = $"Part{root.PartNo}";
                        }
                    }

                    ClearModellingRules(hierarchyNode.Instance.State as BaseInstanceState);
                }
            }
        }

        private NodeState CreateNodeState(
            NodeState parent,
            string basePath,
            Hierarchy hierarchy,
            NodeDesign root,
            bool explicitOnly,
            bool isTypeDefinition,
            NamespaceTable namespaceUris)
        {
            Log("Creating NodeState: {0}", root.SymbolicId.Name);

            NodeState state = null;

            if (root is ObjectTypeDesign)
            {
                state = CreateNodeState((ObjectTypeDesign)root, namespaceUris);
            }
            else if (root is VariableTypeDesign)
            {
                state = CreateNodeState((VariableTypeDesign)root, namespaceUris);
            }
            else if (root is ReferenceTypeDesign)
            {
                state = CreateNodeState((ReferenceTypeDesign)root, namespaceUris);
            }
            else if (root is ObjectDesign)
            {
                state = CreateNodeState(parent, (ObjectDesign)root, namespaceUris);
            }
            else if (root is VariableDesign)
            {
                state = CreateNodeState(parent, (VariableDesign)root, namespaceUris);
            }
            else if (root is DataTypeDesign)
            {
                state = CreateNodeState((DataTypeDesign)root, namespaceUris);
            }
            else if (root is MethodDesign)
            {
                state = CreateNodeState(parent, (MethodDesign)root, namespaceUris);
            }
            else if (root is ViewDesign)
            {
                state = CreateNodeState(parent, (ViewDesign)root, namespaceUris);
            }

            state.SymbolicName = root.SymbolicName.Name;
            state.NodeId = ConstructNodeId(root, namespaceUris);
            state.BrowseName = new QualifiedName(root.BrowseName, (ushort)namespaceUris.GetIndex(root.SymbolicName.Namespace));
            state.DisplayName = new Opc.Ua.LocalizedText(root.DisplayName.Key, String.Empty, root.DisplayName.Value);

            if (root.Description != null && !root.Description.IsAutogenerated)
            {
                state.Description = new Opc.Ua.LocalizedText(root.Description.Key, String.Empty, root.Description.Value);
            }

            state.WriteMask = AttributeWriteMask.None;
            state.UserWriteMask = AttributeWriteMask.None;

            MethodState method = state as MethodState;

            if (method != null)
            {
                MethodDesign design = (MethodDesign)root;

                if (design.MethodDeclarationNode != null)
                {
                    method.MethodDeclarationId = ConstructNodeId(design.MethodDeclarationNode, namespaceUris);
                }
            }

            if (hierarchy == null)
            {
                return state;
            }

            for (int ii = 0; ii < hierarchy.References.Count; ii++)
            {
                HierarchyReference reference = hierarchy.References[ii];

                if (reference.SourcePath != basePath && reference.TargetPath != basePath)
                {
                    continue;
                }

                NodeId referenceTypeId = ConstructNodeId(reference.ReferenceType, namespaceUris);
                bool isInverse = reference.IsInverse;

                if (reference.TargetId != null)
                {
                    NodeId targetId = ConstructNodeId(reference.TargetId, namespaceUris);

                    if (!state.ReferenceExists(referenceTypeId, isInverse, targetId))
                    {
                        state.AddReference(referenceTypeId, isInverse, targetId);
                    }

                    continue;
                }

                if (reference.TargetPath == String.Empty)
                {
                    if (parent != null)
                    {
                        if (!state.ReferenceExists(referenceTypeId, isInverse, parent.NodeId))
                        {
                            state.AddReference(referenceTypeId, isInverse, parent.NodeId);
                        }

                        continue;
                    }
                }

                if (reference.SourcePath == basePath)
                {
                    HierarchyNode target = null;

                    if (!hierarchy.Nodes.TryGetValue(reference.TargetPath, out target))
                    {
                        continue;
                    }

                    if (!target.ExplicitlyDefined && isTypeDefinition)
                    {
                        continue;
                    }

                    NodeId targetId = ConstructNodeId(target.Instance, namespaceUris);

                    if (!state.ReferenceExists(referenceTypeId, isInverse, targetId))
                    {
                        state.AddReference(referenceTypeId, isInverse, targetId);
                    }

                    continue;
                }

                HierarchyNode source = null;

                if (!hierarchy.Nodes.TryGetValue(reference.SourcePath, out source))
                {
                    continue;
                }

                if (!source.ExplicitlyDefined && isTypeDefinition)
                {
                    continue;
                }

                NodeId sourceId = ConstructNodeId(source.Instance, namespaceUris);

                if (!state.ReferenceExists(referenceTypeId, !isInverse, sourceId))
                {
                    state.AddReference(referenceTypeId, !isInverse, sourceId);
                }
            }

            for (int ii = 0; ii < hierarchy.NodeList.Count; ii++)
            {
                HierarchyNode current = hierarchy.NodeList[ii];

                if (explicitOnly)
                {
                    if (!current.ExplicitlyDefined)
                    {
                        continue;
                    }
                }

                string childPath = current.RelativePath;

                // only looking for nodes in the current tree.
                if (!childPath.StartsWith(basePath))
                {
                    continue;
                }

                // ignore reference to the current base node.
                if (childPath == basePath)
                {
                    continue;
                }

                // relative should always end in the name of the current instance.
                if (!childPath.EndsWith(current.Instance.SymbolicName.Name))
                {
                    continue;
                }

                // get the parent path.
                if (childPath.Length > current.Instance.SymbolicName.Name.Length)
                {
                    string parentPath = current.RelativePath.Substring(0, childPath.Length - current.Instance.SymbolicName.Name.Length - 1);

                    if (parentPath != basePath)
                    {
                        continue;
                    }
                }
                else
                {
                    if (String.Empty != basePath)
                    {
                        continue;
                    }
                }

                if (!String.IsNullOrEmpty(basePath))
                {
                    childPath = childPath.Substring(basePath.Length + 1);
                    childPath = String.Format("{0}{1}{2}", basePath, NodeDesign.PathChar, childPath);
                }

                if (!explicitOnly)
                {
                    InstanceDesign instance = current.Instance as InstanceDesign;

                    if (instance != null)
                    {
                        if (instance.ModellingRule != ModellingRule.Mandatory && !current.ExplicitlyDefined)
                        {
                            if ((instance.ModellingRule != ModellingRule.None && instance.ModellingRule != ModellingRule.ExposesItsArray && instance.ModellingRule != ModellingRule.OptionalPlaceholder && instance.ModellingRule != ModellingRule.MandatoryPlaceholder) || !isTypeDefinition)
                            {
                                continue;
                            }
                        }
                    }
                }

                if (isTypeDefinition)
                {
                    if (!current.ExplicitlyDefined && current.Inherited && current.AdHocInstance)
                    {
                        // this assumes that ad-hoc instances are not more than one level deep.
                        // i.e. a type defines folder and adds a few instances but does not defined subfolders.
                        // need a better way to identify when to suppress inherited adhoc instances.
                        if (!basePath.Contains(NodeDesign.PathChar))
                        {
                            continue;
                        }
                    }
                }

                current.Instance.State = CreateNodeState(
                    state,
                    childPath,
                    hierarchy,
                    current.Instance,
                    false,
                    isTypeDefinition,
                    namespaceUris);

                BaseInstanceState child = current.Instance.State as BaseInstanceState;

                if (child != null)
                {
                    if (root is DataTypeDesign || root is ViewDesign || root is ReferenceTypeDesign)
                    {
                        child.ModellingRuleId = null;
                        state.AddChild(child);
                    }                   
                    else if (explicitOnly)
                    {
                        if (current.ExplicitlyDefined)
                        {
                            state.AddChild(child);
                        }
                    }
                    else if (isTypeDefinition)
                    {
                        if (child.ModellingRuleId == ObjectIds.ModellingRule_Mandatory)
                        {
                            state.AddChild(child);
                        }
                        else if (current.ExplicitlyDefined && child.ModellingRuleId == ObjectIds.ModellingRule_Optional)
                        {
                            state.AddChild(child);
                        }
                        else if (current.ExplicitlyDefined && (child.ModellingRuleId == ObjectIds.ModellingRule_ExposesItsArray || child.ModellingRuleId == ObjectIds.ModellingRule_OptionalPlaceholder || child.ModellingRuleId == ObjectIds.ModellingRule_MandatoryPlaceholder))
                        {
                            state.AddChild(child);
                        }
                    }
                    else
                    {
                        if (child.ModellingRuleId == ObjectIds.ModellingRule_Mandatory)
                        {
                            state.AddChild(child);
                        }
                        else
                        {
                            if (current.ExplicitlyDefined && child.ModellingRuleId == ObjectIds.ModellingRule_Optional)
                            {
                                state.AddChild(child);
                            }
                        }
                    }
                }
           }

           return state;
        }

        private NodeState CreateNodeState(ObjectTypeDesign root, NamespaceTable namespaceUris)
        {
            BaseObjectTypeState state = new BaseObjectTypeState();
            state.Handle = root;

            if (root.BaseTypeNode != null)
            {
                state.SuperTypeId = ConstructNodeId(root.BaseTypeNode, namespaceUris);
            }
            else
            {
                state.SuperTypeId = null;
            }

            state.IsAbstract = root.IsAbstract;

            return state;
        }

        private NodeId GetDataType(VariableTypeDesign type, NamespaceTable namespaceUris)
        {
            if (!UseAllowSubtypes)
            {
                var dataType = (DataTypeDesign)FindNode(type.DataType, typeof(DataTypeDesign), type.SymbolicId.Name, "DataType"); ;
                return ConstructNodeId(dataType, namespaceUris);
            }

            return ConstructNodeId(type.DataTypeNode, namespaceUris);
        }

        private NodeId GetDataType(Parameter field, NamespaceTable namespaceUris)
        {
            if (!UseAllowSubtypes)
            {
                var dataType = (DataTypeDesign)FindNode(field.DataType, typeof(DataTypeDesign), field.Name, "DataType"); ;
                return ConstructNodeId(dataType, namespaceUris);
            }

            return ConstructNodeId(field.DataTypeNode, namespaceUris);
        }

        private NodeId GetDataType(VariableDesign instance, NamespaceTable namespaceUris)
        {
            if (!UseAllowSubtypes)
            {
                var dataType = (DataTypeDesign)FindNode(instance.DataType, typeof(DataTypeDesign), instance.SymbolicId.Name, "DataType"); ;
                return ConstructNodeId(dataType, namespaceUris);
            }

            return ConstructNodeId(instance.DataTypeNode, namespaceUris);
        }

        private NodeState CreateNodeState(VariableTypeDesign root, NamespaceTable namespaceUris)
        {
            BaseDataVariableTypeState state = new BaseDataVariableTypeState();
            state.Handle = root;

            if (root.BaseTypeNode != null)
            {
                state.SuperTypeId = ConstructNodeId(root.BaseTypeNode, namespaceUris);
            }
            else
            {
                state.SuperTypeId = null;
            }

            VariableDesign mergedInstance = null;

            Hierarchy hierarchy = root.Hierarchy;

            if (hierarchy != null)
            {
                HierarchyNode node = null;

                if (hierarchy.Nodes.TryGetValue(String.Empty, out node))
                {
                    mergedInstance = node.Instance as VariableDesign;
                }
            }

            state.IsAbstract = root.IsAbstract;

            if (mergedInstance != null)
            {
                state.Value = mergedInstance.DecodedValue;
                state.DataType = GetDataType(mergedInstance, namespaceUris);
                state.ValueRank = ConstructValueRank(mergedInstance.ValueRank, mergedInstance.ArrayDimensions);
                state.ArrayDimensions = ConstructArrayDimensions(mergedInstance.ValueRank, mergedInstance.ArrayDimensions);
            }
            else
            {
                state.Value = root.DecodedValue;
                state.DataType = GetDataType(root, namespaceUris);
                state.ValueRank = ConstructValueRank(root.ValueRank, root.ArrayDimensions);
                state.ArrayDimensions = ConstructArrayDimensions(root.ValueRank, root.ArrayDimensions);
            }

            return state;
        }

        private NodeState CreateNodeState(ReferenceTypeDesign root, NamespaceTable namespaceUris)
        {
            ReferenceTypeState state = new ReferenceTypeState();
            state.Handle = root;

            if (root.BaseTypeNode != null)
            {
                state.SuperTypeId = ConstructNodeId(root.BaseTypeNode, namespaceUris);
            }
            else
            {
                state.SuperTypeId = null;
            }

            state.IsAbstract = root.IsAbstract;
            state.Symmetric = root.Symmetric;

            if (state.Symmetric)
            {
                state.InverseName = Opc.Ua.LocalizedText.Null;
            }
            else
            {
                state.InverseName = new Opc.Ua.LocalizedText(root.InverseName.Key, String.Empty, root.InverseName.Value);
            }

            return state;
        }

        private NodeState CreateNodeState(DataTypeDesign root, NamespaceTable namespaceUris)
        {
            DataTypeState state = new DataTypeState();
            state.Handle = root;

            if (root.BaseTypeNode != null)
            {
                state.SuperTypeId = ConstructNodeId(root.BaseTypeNode, namespaceUris);
            }
            else
            {
                state.SuperTypeId = null;
            }

            state.IsAbstract = root.IsAbstract;
            state.Purpose = (Export.DataTypePurpose)(int)root.Purpose;

            if (root.BasicDataType == BasicDataType.Enumeration || root.BasicDataType == BasicDataType.UserDefined)
            {
                if (root.Fields == null)
                {
                    root.Fields = new Parameter[0];
                }

                DataTypeDefinition definition = null;

                if (root.BasicDataType == BasicDataType.UserDefined && root.IsStructure)
                {
                    StructureDefinition sd = new StructureDefinition();

                    DataTypeDesign baseType = root.BaseTypeNode as DataTypeDesign;

                    if (baseType != null)
                    {
                        sd.BaseDataType = ConstructNodeId(baseType, namespaceUris);
                    }

                    sd.StructureType = StructureType.Structure;

                    if (root.IsUnion)
                    {
                        sd.StructureType = StructureType.Union;
                    }

                    foreach (var field in root.Fields)
                    {
                        if (field.IsOptional)
                        {
                            sd.StructureType = StructureType.StructureWithOptionalFields;
                            break;
                        }

                        if (field.AllowSubTypes)
                        {
                            if (root.IsUnion)
                            {
                                sd.StructureType = StructureType.UnionWithSubtypedValues;
                                break;
                            }

                            sd.StructureType = StructureType.StructureWithSubtypedValues;
                            break;
                        }
                    }

                    sd.FirstExplicitFieldIndex = GetStructureDefinitionFields(sd, root, namespaceUris);
                    definition = sd;
                }

                if (root.BasicDataType == BasicDataType.Enumeration && root.IsEnumeration)
                {
                    EnumDefinition ed = new EnumDefinition();
                    ed.IsOptionSet = root.IsOptionSet;

                    List<EnumField> enumFields = new List<EnumField>();

                    if (root.Fields != null && root.Fields.Length > 0)
                    {
                        foreach (var field in root.Fields)
                        {
                            EnumField enumField;

                            if (root.IsOptionSet)
                            {
                                long bit = 1;
                                int value = 0;

                                while (field.Identifier > 0 && bit <= UInt32.MaxValue)
                                {
                                    if ((bit & (long)field.Identifier) != 0)
                                    {
                                        break;
                                    }

                                    bit <<= 1;
                                    value++;
                                }

                                enumField = new EnumField()
                                {
                                    Name = field.Name,
                                    DisplayName = new Opc.Ua.LocalizedText(field.Name),
                                    Value = value
                                };
                            }
                            else
                            {
                                enumField = new EnumField()
                                {
                                    Name = field.Name,
                                    DisplayName = new Opc.Ua.LocalizedText(field.Name),
                                    Value = field.Identifier,
                                };
                            }

                            if (field.Description != null && !field.Description.IsAutogenerated)
                            {
                                enumField.Description = new Opc.Ua.LocalizedText(field.Description.Value);
                            }

                            enumFields.Add(enumField);
                        }

                        ed.Fields = enumFields.ToArray();
                    }

                    definition = ed;
                }

                state.DataTypeDefinition = new ExtensionObject(definition);
            }

            return state;
        }

        private int GetStructureDefinitionFields(StructureDefinition sd, DataTypeDesign dataType, NamespaceTable namespaceUris)
        {
            if (dataType == null || dataType.Fields == null)
            {
                return sd.Fields.Count;
            }

            DataTypeDesign baseType = dataType.BaseTypeNode as DataTypeDesign;

            if (baseType != null)
            {
                GetStructureDefinitionFields(sd, baseType, namespaceUris);
            }

            int start = sd.Fields.Count;

            if (dataType.Fields != null && dataType.Fields.Length > 0)
            {
                foreach (var field in dataType.Fields)
                {
                    StructureField structureField = new StructureField()
                    {
                        Name = field.Name,
                        DataType = GetDataType(field, namespaceUris),
                        ValueRank = ConstructValueRank(field.ValueRank, field.ArrayDimensions),
                        ArrayDimensions = ConstructArrayDimensionsRW(field.ValueRank, field.ArrayDimensions) 
                    };

                    if (sd.StructureType == StructureType.StructureWithOptionalFields)
                    {
                        structureField.IsOptional = field.IsOptional;
                    }
                    else if (sd.StructureType == (StructureType)3 || // StructureType.StructureWithSubtypedValues || 
                             sd.StructureType == (StructureType)4)   // StructureType.UnionWithSubtypedValues)
                    {
                        structureField.IsOptional = field.AllowSubTypes;
                    }

                    if (field.Description != null && !field.Description.IsAutogenerated)
                    {
                        structureField.Description = new Opc.Ua.LocalizedText(field.Description.Value);
                    }

                    sd.Fields.Add(structureField);
                }
            }

            return start;
        }

        private NodeState CreateNodeState(NodeState parent, ObjectDesign root, NamespaceTable namespaceUris)
        {
            BaseObjectState state = new BaseObjectState(parent);
            state.Handle = root;

            state.TypeDefinitionId = ConstructNodeId(root.TypeDefinitionNode, namespaceUris);
            state.ReferenceTypeId = ConstructNodeId(root.ReferenceType, namespaceUris);
            state.ModellingRuleId = ConstructModellingRule(root.ModellingRule);
            state.EventNotifier = ConstructEventNotifier(root.SupportsEvents);
            state.Categories = null;
            state.ReleaseStatus = ToReleaseStatus(root.ReleaseStatus);

            if (!String.IsNullOrEmpty(root.Category))
            {
                root.State.Categories = root.Category.Split(new char[] { ',' });
            }

            if (root.PartNo != 0)
            {
                state.Specification = $"Part{root.PartNo}";
            }

            if (root.NumericIdSpecified)
            {
                state.NumericId = root.NumericId;
            }

            return state;
        }

        private NodeState CreateNodeState(NodeState parent, ViewDesign root, NamespaceTable namespaceUris)
        {
            ViewState state = new ViewState();
            state.Handle = root;
            state.EventNotifier = ConstructEventNotifier(root.SupportsEvents);
            state.ContainsNoLoops = root.ContainsNoLoops;
            state.Categories = null;
            state.ReleaseStatus = ToReleaseStatus(root.ReleaseStatus);

            if (!String.IsNullOrEmpty(root.Category))
            {
                root.State.Categories = root.Category.Split(new char[] { ',' });
            }

            if (root.PartNo != 0)
            {
                state.Specification = $"Part{root.PartNo}";
            }

            return state;
        }

        private NodeState CreateNodeState(NodeState parent, MethodDesign root, NamespaceTable namespaceUris)
        {
            MethodState state = new MethodState(parent);
            state.Handle = root;

            state.ReferenceTypeId = ConstructNodeId(root.ReferenceType, namespaceUris);
            state.ModellingRuleId = ConstructModellingRule(root.ModellingRule);
            state.Executable = state.UserExecutable = !root.NonExecutable;
            state.Categories = null;
            state.ReleaseStatus = ToReleaseStatus(root.ReleaseStatus);
            state.MethodDeclarationId = ConstructNodeId(root.MethodDeclarationNode, namespaceUris);

            if (!String.IsNullOrEmpty(root.Category))
            {
                root.State.Categories = root.Category.Split(new char[] { ',' });
            }

            if (root.PartNo != 0)
            {
                state.Specification = $"Part{root.PartNo}";
            }

            if (root.NumericIdSpecified)
            {
                state.NumericId = root.NumericId;
            }

            return state;
        }

        private void SetTypeId(ExtensionObject e, NamespaceTable namespaceUris)
        {
            XmlQualifiedName qname = null;

            XmlElement element = e.Body as XmlElement;

            if (element != null)
            {
                // determine the data type of the element.
                qname = new XmlQualifiedName(element.LocalName, element.NamespaceURI);

                string prefix = element.GetPrefixOfNamespace(Namespaces.XmlSchemaInstance);
                string xsitype = element.GetAttribute(prefix + ":type");

                if (!String.IsNullOrEmpty(xsitype))
                {
                    int index = xsitype.IndexOf(':');

                    if (index > 0)
                    {
                        qname = new XmlQualifiedName(xsitype.Substring(index + 1), element.GetNamespaceOfPrefix(xsitype.Substring(0, index)));
                    }
                    else
                    {
                        qname = new XmlQualifiedName(xsitype.Substring(index + 1), element.NamespaceURI);
                    }
                }
            }

            else
            {
                IEncodeable encodeable = e.Body as IEncodeable;

                if (encodeable != null)
                {
                    qname = EncodeableFactory.GetXmlName(encodeable.GetType());
                }
            }

            DataTypeDesign dataTypeNode = FindType(qname) as DataTypeDesign;

            if (dataTypeNode != null)
            {
                uint numericId = dataTypeNode.NumericId;
                int namespaceIndex = namespaceUris.GetIndex(qname.Namespace);

                // look up XML encoding id.
                if (dataTypeNode.HasEncodings)
                {
                    foreach (EncodingDesign encoding in dataTypeNode.Encodings)
                    {
                        ObjectDesign encodingNode = (ObjectDesign)FindNode(encoding.SymbolicId, typeof(ObjectDesign), encoding.SymbolicId.Name, "Encoding");

                        if (encodingNode != null && encodingNode.SymbolicName.Name == "DefaultXml")
                        {
                            numericId = encodingNode.NumericId;
                            namespaceIndex = namespaceUris.GetIndex(encodingNode.SymbolicId.Namespace);
                            break;
                        }
                    }
                }

                if (namespaceIndex >= 0)
                {
                    e.TypeId = new NodeId(numericId, (ushort)namespaceIndex);
                }
            }
        }

        private BaseVariableState CreateNodeState(NodeState parent, VariableDesign root, NamespaceTable namespaceUris)
        {
            BaseVariableState state = null;

            if (root is PropertyDesign)
            {
                state = new PropertyState(parent);
            }
            else
            {
                state = new BaseDataVariableState(parent);
            }

            state.Handle = root;
            state.TypeDefinitionId = ConstructNodeId(root.TypeDefinitionNode, namespaceUris);
            state.ReferenceTypeId = ConstructNodeId(root.ReferenceType, namespaceUris);
            state.ModellingRuleId = ConstructModellingRule(root.ModellingRule);
            state.Categories = null;
            state.ReleaseStatus = ToReleaseStatus(root.ReleaseStatus);

            if (!String.IsNullOrEmpty(root.Category))
            {
                root.State.Categories = root.Category.Split(new char[] { ',' });
            }

            if (root.PartNo != 0)
            {
                state.Specification = $"Part{root.PartNo}";
            }

            if (root.NumericIdSpecified)
            {
                state.NumericId = root.NumericId;
            }

            state.Value = root.DecodedValue;
            state.DataType = GetDataType(root, namespaceUris);
            state.ValueRank = ConstructValueRank(root.ValueRank, root.ArrayDimensions);
            state.ArrayDimensions = ConstructArrayDimensions(root.ValueRank, root.ArrayDimensions);
            state.AccessLevel = ConstructAccessLevel(root.AccessLevel);
            state.UserAccessLevel = state.AccessLevel;
            state.MinimumSamplingInterval = root.MinimumSamplingInterval;
            state.Historizing = root.Historizing;

            ExtensionObject e = root.DecodedValue as ExtensionObject;

            if (e != null)
            {
                SetTypeId(e, namespaceUris);
            }

            ExtensionObject[] e2 = root.DecodedValue as ExtensionObject[];

            if (e2 != null)
            {
                foreach (ExtensionObject e3 in e2)
                {
                    SetTypeId(e3, namespaceUris);
                }
            }

            IList<Argument> argument = root.DecodedValue as IList<Argument>;

            if (argument != null)
            {
                for (int ii = 0; ii < argument.Count; ii++)
                {
                    string name = argument[ii].DataType.Identifier as string;
                    string namespaceUri = DefaultNamespace;

                    if (name == null)
                    {
                        continue;
                    }

                    int index = name.LastIndexOf(':');

                    if (index != -1)
                    {
                        namespaceUri = name.Substring(0, index);
                        name = name.Substring(index + 1);
                    }

                    argument[ii].DataType = ConstructNodeId(new XmlQualifiedName(name, namespaceUri), namespaceUris);
                }
            }

            return state;
        }
        #endregion
    }
}
