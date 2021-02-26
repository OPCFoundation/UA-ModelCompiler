/* ========================================================================
 * Copyright (c) 2005-2021 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Reciprocal Community License ("RCL") Version 1.00
 *
 * Unless explicitly acquired and licensed from Licensor under another
 * license, the contents of this file are subject to the Reciprocal
 * Community License ("RCL") Version 1.00, or subsequent versions
 * as allowed by the RCL, and You may not copy or use this file in either
 * source code or executable form, except in compliance with the terms and
 * conditions of the RCL.
 *
 * All software distributed under the RCL is provided strictly on an
 * "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED,
 * AND LICENSOR HEREBY DISCLAIMS ALL SUCH WARRANTIES, INCLUDING WITHOUT
 * LIMITATION, ANY WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 * PURPOSE, QUIET ENJOYMENT, OR NON-INFRINGEMENT. See the RCL for specific
 * language governing rights and limitations under the RCL.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/RCL/1.00/
 * ======================================================================*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using System.Xml.Schema;

namespace Opc.Ua.Schema.Xml
{
    /// <summary>
    /// Generates files used to describe data types.
    /// </summary>
    public class XmlSchemaValidator2 : SchemaValidator
    {
        #region Constructors
		/// <summary>
		/// Intializes the object with default values.
		/// </summary>
		public XmlSchemaValidator2()
		{
            SetResourcePaths(WellKnownDictionaries);
		}

		/// <summary>
		/// Intializes the object with a file table.
		/// </summary>
		public XmlSchemaValidator2(Dictionary<string,string> fileTable) : base(fileTable)
		{
            SetResourcePaths(WellKnownDictionaries);
		}
        #endregion

        #region Public Members
        /// <summary>
        /// The schema set that was validated.
        /// </summary>
        public XmlSchemaSet SchemaSet
        {
            get { return m_schemaSet; }
        }
        /// <summary>
        /// The schema that was validated.
        /// </summary>
        public XmlSchema TargetSchema
        {
            get { return m_schema; }
        }

		/// <summary>
		/// Generates the code from the contents of the address space.
		/// </summary>
		public void Validate(string inputPath)
		{
            using (Stream istrm = File.OpenRead(inputPath))
            {
                Validate(istrm);
            }
        }

		/// <summary>
		/// Generates the code from the contents of the address space.
		/// </summary>
		public void Validate(Stream stream)
		{
            m_schema = XmlSchema.Read(stream, new ValidationEventHandler(OnValidate));

            foreach (XmlSchemaImport import in m_schema.Includes)
            {
                if (import.Namespace == Namespaces.OpcUa)
                {
                    StreamReader strm = new StreamReader(Assembly.Load("Opc.Ua.Core").GetManifestResourceStream("Opc.Ua.Model.Opc.Ua.Types.xsd"));
                    import.Schema = XmlSchema.Read(strm, new ValidationEventHandler(OnValidate));
                    continue;
                }

                string location = null;

                if (!KnownFiles.TryGetValue(import.Namespace, out location))
                {
                    location = import.SchemaLocation;
                }

                FileInfo fileInfo = new FileInfo(location);

                if (!fileInfo.Exists)
                {
                    StreamReader strm = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(location));
                    import.Schema = XmlSchema.Read(strm, new ValidationEventHandler(OnValidate));
                }
                else
                {
                    Stream strm = File.OpenRead(location);
                    import.Schema = XmlSchema.Read(strm, new ValidationEventHandler(OnValidate));
                }
            }

            m_schemaSet = new XmlSchemaSet();
            m_schemaSet.Add(m_schema);
            m_schemaSet.Compile();
		}

        /// <summary>
        /// Returns the schema for the specified type (returns the entire schema if null).
        /// </summary>
        public override string GetSchema(string typeName)
        {
            XmlWriterSettings settings = new XmlWriterSettings();

            settings.Encoding    = Encoding.UTF8;
            settings.Indent      = true;
            settings.IndentChars = "    ";

            MemoryStream ostrm = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(ostrm, settings);

            try
            {
                if (typeName == null || m_schema.Elements.Values.Count == 0)
                {
                    m_schema.Write(writer);
                }
                else
                {
                    foreach (XmlSchemaObject current in m_schema.Elements.Values)
                    {
                        XmlSchemaElement element = current as XmlSchemaElement;

                        if (element != null)
                        {
                            if (element.Name == typeName)
                            {
                                XmlSchema schema = new XmlSchema();
                                schema.Items.Add(element.ElementSchemaType);
                                schema.Items.Add(element);
                                schema.Write(writer);
                                break;
                            }
                        }
                    }
                }
            }
            finally
            {
                writer.Close();
            }

            return new UTF8Encoding().GetString(ostrm.ToArray());
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Handles a valdiation error.
        /// </summary>
        static void OnValidate(object sender, ValidationEventArgs args)
        {
            throw new InvalidOperationException(args.Message, args.Exception);
        }
        #endregion

        #region Private Fields
        private readonly string[][] WellKnownDictionaries = new string[][]
        {
            new string[] {  Namespaces.OpcUaBuiltInTypes, "Opc.Ua.Types.Schemas.BuiltInTypes.xsd" }
        };

        private XmlSchema m_schema;
        private XmlSchemaSet m_schemaSet;
        #endregion
    }
}
