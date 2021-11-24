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
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Reflection;
using Opc.Ua.Schema;

namespace CodeGenerator
{
    /// <summary>
    /// Generates files used to describe data types.
    /// </summary>
    public class TypeDictionaryValidator : SchemaValidator
    {
        #region Constructors
        /// <summary>
        /// Intializes the object with default values.
        /// </summary>
        public TypeDictionaryValidator(string resourcePath)
        {
            var WellKnownDictionaries = new string[][]
            {
                new string[] { Namespaces.OpcUaBuiltInTypes, $"ModelCompiler.StackGenerator.Validators.BuiltInTypes.xml" }
            };

            SetResourcePaths(WellKnownDictionaries);
        }

        /// <summary>
        /// Intializes the object with a file table.
        /// </summary>
        public TypeDictionaryValidator(Dictionary<string,string> fileTable, string resourcePath) : base(fileTable)
        {
            var WellKnownDictionaries = new string[][]
            {
                new string[] { Namespaces.OpcUaBuiltInTypes, $"ModelCompiler.StackGenerator.Validators.BuiltInTypes.xml" }
            };

            SetResourcePaths(WellKnownDictionaries);
        }
        #endregion

        #region Public Members
        /// <summary>
        /// The dictionary that was validated.
        /// </summary>
        public TypeDictionary Dictionary
        {
            get { return m_dictionary; }
        }

        /// <summary>
        /// The location of the embedded resources.
        /// </summary>
        public string EmbeddedResourcePath { get; set; }

        /// <summary>
        /// Finds the data type with the specified name.
        /// </summary>
        public DataType FindType(XmlQualifiedName typeName)
        {
            DataType dataType = null;

            if (!m_datatypes.TryGetValue(typeName, out dataType))
            {
                return null;
            }

            return dataType;
        }

        /// <summary>
        /// Finds the concrete type identified by the type name (i.e. resolves any type definitions).
        /// </summary>
        public DataType ResolveType(XmlQualifiedName typeName)
        {
            if (IsNull(typeName))
            {
                return null;
            }

            DataType dataType = null;

            if (!m_datatypes.TryGetValue(typeName, out dataType))
            {
                return null;
            }

            TypeDeclaration declaration = dataType as TypeDeclaration;

            if (declaration != null)
            {
                return ResolveTypeDeclaration(declaration);
            }

            return dataType;
        }

        public static bool IsExcluded(IList<string> exclusions, DataType datatype)
        {
            if (exclusions != null)
            {
                foreach (var jj in exclusions)
                {
                    if (jj == datatype.ReleaseStatus.ToString())
                    {
                        return true;
                    }

                    if (jj == datatype.Purpose.ToString())
                    {
                        return true;
                    }

                    if (datatype.Category != null && datatype.Category.Contains(jj))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool IsExcluded(IList<string> exclusions, EnumeratedValue value)
        {
            if (exclusions != null)
            {
                foreach (var jj in exclusions)
                {
                    if (jj == value.ReleaseStatus.ToString())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool IsExcluded(IList<string> exclusions, FieldType field)
        {
            if (exclusions != null)
            {
                foreach (var jj in exclusions)
                {
                    if (jj == field.ReleaseStatus.ToString())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Generates the code from the contents of the address space.
        /// </summary>
        public void Validate(string inputPath, IList<string> exclusions)
        {
            using (Stream stream = File.OpenRead(inputPath))
            {
                Validate(stream, exclusions);
            }
        }

        /// <summary>
        /// Generates the code from the contents of the address space.
        /// </summary>
        public void Validate(Stream stream, IList<string> exclusions)
        {
            m_dictionary = (TypeDictionary)LoadInput(typeof(TypeDictionary), stream);
            m_datatypes = new Dictionary<XmlQualifiedName,DataType>();

            // import types from referenced dictionaries.
            if (m_dictionary.Import != null)
            {
                foreach (ImportDirective directive in m_dictionary.Import)
                {
                    Import(directive);
                }
            }

            // import types from target dictionary.
            foreach (DataType datatype in m_dictionary.Items)
            {
                ImportDataType(datatype, m_dictionary.TargetNamespace);
            }

            // validate types in target dictionary.
            foreach (DataType datatype in m_dictionary.Items)
            {
                ValidateDataType(datatype);
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Imports a dictionary identified by an import directive.
        /// </summary>
        private void Import(ImportDirective directive)
        {
            // check if already loaded.
            if (LoadedFiles.ContainsKey(directive.Namespace))
            {
                return;
            }

            TypeDictionary dictionary = (TypeDictionary)Load(
                typeof(TypeDictionary), 
                directive.Namespace, 
                directive.Location,
                Assembly.GetExecutingAssembly());

            // verify namespace.
            if (!String.IsNullOrEmpty(dictionary.TargetNamespace) && directive.Namespace != dictionary.TargetNamespace)
            {
                throw Exception("Imported dictionary '{0}' does not match uri specified: '{1}'.", dictionary.TargetNamespace, directive.Namespace);
            }

            // save file.
            LoadedFiles.Add(dictionary.TargetNamespace, dictionary);

            // import nested dictionaries.
            if (dictionary.Import != null)
            {
                for (int ii = 0; ii < dictionary.Import.Length; ii++)
                {
                    Import(dictionary.Import[ii]);
                }
            }

            // import types.
            if (dictionary.Items != null)
            {
                foreach (DataType datatype in dictionary.Items)
                {
                    ImportDataType(datatype, dictionary.TargetNamespace);
                }
            }
        }

        /// <summary>
        /// Checks if a string is a valid part of a qname.
        /// </summary>
        private static bool IsValidName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return false;
            }

            if (!Char.IsLetter(name[0]) && name[0] != '_')
            {
                return false;
            }

            for (int ii = 1; ii < name.Length; ii++)
            {
                if (Char.IsLetter(name[ii]) || Char.IsDigit(name[ii]))
                {
                    continue;
                }

                if (name[ii] == '.' || name[ii] == '-' || name[ii] == '_')
                {
                    continue;
                }

                return false;
            }

            return true;
        }

        /// <summary>
        /// Imports a datatype.
        /// </summary>
        private void ImportDataType(DataType datatype, string targetNamespace)
        {
            if (datatype == null)
            {
                return;
            }

            if (!IsValidName(datatype.Name))
            {
                throw Exception("'{0}' is not a valid datatype name.", datatype.Name);
            }

            datatype.QName = new XmlQualifiedName(datatype.Name, targetNamespace);

            if (m_datatypes.ContainsKey(datatype.QName))
            {
                throw Exception("The datatype name '{0}' already used by another datatype.", datatype.Name);
            }

            ComplexType complexType = datatype as ComplexType;

            if (complexType != null)
            {
                if (complexType.Field != null)
                {
                    foreach (FieldType fieldType in complexType.Field)
                    {
                        if (fieldType.ComplexType != null)
                        {
                            ImportDataType(fieldType.ComplexType, targetNamespace);
                        }
                    }
                }
            }

            ServiceType serviceType = datatype as ServiceType;

            if (serviceType != null)
            {
                if (serviceType.Request != null)
                {
                    foreach (FieldType fieldType in serviceType.Request)
                    {
                        if (fieldType.ComplexType != null)
                        {
                            ImportDataType(fieldType.ComplexType, targetNamespace);
                        }
                    }
                }

                if (serviceType.Response != null)
                {
                    foreach (FieldType fieldType in serviceType.Response)
                    {
                        if (fieldType.ComplexType != null)
                        {
                            ImportDataType(fieldType.ComplexType, targetNamespace);
                        }
                    }
                }
            }

            m_datatypes.Add(datatype.QName, datatype);
        }

        /// <summary>
        /// Validates a datatype.
        /// </summary>
        private void ValidateDataType(DataType datatype)
        {
            TypeDeclaration typeDeclaration = datatype as TypeDeclaration;

            if (typeDeclaration != null)
            {
                ResolveTypeDeclaration(typeDeclaration);
                return;
            }

            EnumeratedType enumeratedType = datatype as EnumeratedType;

            if (enumeratedType != null)
            {
                ValidateEnumeratedType(enumeratedType);
                return;
            }

            ComplexType complexType = datatype as ComplexType;

            if (complexType != null)
            {
                ValidateComplexType(complexType);
                return;
            }

            ServiceType serviceType = datatype as ServiceType;

            if (serviceType != null)
            {
                ValidateServiceType(serviceType);
                return;
            }
        }

        /// <summary>
        /// Validates the base type of a complex type.
        /// </summary>
        private void ValidateBaseType(ComplexType complexType, XmlQualifiedName baseType, Dictionary<string,FieldType> fields)
        {
            if (IsNull(baseType))
            {
                return;
            }

            ComplexType parentType = ResolveType(baseType) as ComplexType;

            if (parentType == null)
            {
                throw Exception("The base type '{1}' for complex type '{0}' is not a complex type.", complexType.Name, baseType);
            }

            ValidateBaseType(complexType, parentType.BaseType, fields);

            for (int ii = 0; ii < parentType.Field.Length; ii++)
            {
                fields.Add(parentType.Field[ii].Name, parentType.Field[ii]);
            }
        }

        /// <summary>
        /// Finds the source for a type declaration.
        /// </summary>
        private DataType ResolveTypeDeclaration(TypeDeclaration declaration)
        {
            if (IsNull(declaration.SourceType))
            {
                throw Exception("The type declaration '{0}'does not have a source type.", declaration.Name);
            }

            DataType dataType = null;

            if (!m_datatypes.TryGetValue(declaration.SourceType, out dataType))
            {
                throw Exception("Cannot find a concrete source type '{1}' for the type declaration '{0}'", declaration.Name, declaration.SourceType);
            }

            TypeDeclaration typeDeclaration = dataType as TypeDeclaration;

            if (typeDeclaration != null)
            {
                return ResolveTypeDeclaration(typeDeclaration);
            }

            return dataType;
        }

        /// <summary>
        /// Validates a complex type.
        /// </summary>
        private void ValidateComplexType(ComplexType complexType)
        {
            if (complexType.Field == null)
            {
                complexType.Field = new FieldType[0];
            }

            Dictionary<string,FieldType> fields = new Dictionary<string,FieldType>();

            ValidateBaseType(complexType, complexType.BaseType, fields);

            for (int ii = 0; ii < complexType.Field.Length; ii++)
            {
                ValidateFieldType(complexType, fields, complexType.Field[ii]);
            }
        }

        /// <summary>
        /// Validates a service type.
        /// </summary>
        private void ValidateServiceType(ServiceType serviceType)
        {
            Dictionary<string,FieldType> fields = new Dictionary<string,FieldType>();

            if (serviceType.Request != null && serviceType.Request.Length > 0)
            {
                for (int ii = 0; ii < serviceType.Request.Length; ii++)
                {
                    ValidateFieldType(serviceType, fields, serviceType.Request[ii]);
                }
            }

            if (serviceType.Response != null && serviceType.Response.Length > 0)
            {
                for (int ii = 0; ii < serviceType.Response.Length; ii++)
                {
                    ValidateFieldType(serviceType, fields, serviceType.Response[ii]);
                }
            }
        }

        /// <summary>
        /// Validates a field type.
        /// </summary>
        private void ValidateFieldType(DataType datatype, Dictionary<string,FieldType> fields, FieldType field)
        {
            if (fields.ContainsKey(field.Name))
            {
                throw Exception("The field '{1}' in complex type '{0}' already exists", datatype.Name, field.Name);
            }

            if (IsNull(field.DataType))
            {
                if (field.ComplexType == null)
                {
                    throw Exception("The field '{1}' in complex type '{0}' has no data type.", datatype.Name, field.Name);
                }

                ValidateDataType(field.ComplexType);

                // ensure that datatype field always has a valid value.
                field.DataType = field.ComplexType.QName;
            }
            else
            {
                if (field.ComplexType != null)
                {
                    throw Exception("The field '{1}' in complex type '{0}' has an ambiguous data type.", datatype.Name, field.Name);
                }

                if (ResolveType(field.DataType) == null)
                {
                    throw Exception("The field '{1}' in complex type '{0}' has an unrecognized data type '{2}'.", datatype.Name, field.Name, field.DataType);
                }
            }

            fields.Add(field.Name, field);
        }

        /// <summary>
        /// Validates an enumerated type.
        /// </summary>
        private static void ValidateEnumeratedType(EnumeratedType enumeratedType)
        {
            if (enumeratedType.Value == null || enumeratedType.Value.Length == 0)
            {
                throw Exception("The enumerated type '{0}' does not have any values specified.", enumeratedType.Name);
            }

            int nextIndex = 0;
            Dictionary<string,EnumeratedValue> values = new Dictionary<string,EnumeratedValue>();

            for (int ii = 0; ii < enumeratedType.Value.Length; ii++)
            {
                EnumeratedValue value = enumeratedType.Value[ii];

                if (values.ContainsKey(value.Name))
                {
                    throw Exception("The enumerated type '{0}' has a duplicate value '{1}'.", enumeratedType.Name, value.Value);
                }

                if (!value.ValueSpecified)
                {
                    value.Value = nextIndex;
                    value.ValueSpecified = true;
                }
                else
                {
                    nextIndex = value.Value+1;
                }

                values.Add(value.Name, value);
            }
        }
        #endregion

        #region Private Fields
        private TypeDictionary m_dictionary;
        private Dictionary<XmlQualifiedName,DataType> m_datatypes;
        #endregion
    }
}
