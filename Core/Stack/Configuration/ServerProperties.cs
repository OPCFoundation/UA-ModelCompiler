/* ========================================================================
 * Copyright (c) 2005-2019 The OPC Foundation, Inc. All rights reserved.
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
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua
{
    /// <summary>
	/// The properties of the current server instance.
	/// </summary>
	public class ServerProperties
	{
		#region Constructors
		/// <summary>
		/// The default constructor.
		/// </summary>
		public ServerProperties()
		{
			Initialize();

            // assume calling assembly is the main assembly for the product.
            Assembly assembly = Assembly.GetCallingAssembly();

            if (assembly != null)
            {
                Initialize(assembly);
            }
		}

		/// <summary>
		/// Sets private members to default values.
		/// </summary>
		private void Initialize()
		{
		    m_productUri = null;
		    m_manufacturerName = null;
		    m_productName = null;
		    m_softwareVersion = null;
		    m_buildNumber = null;
		    m_buildDate = DateTime.MinValue;
            m_datatypeAssemblies = new StringCollection();
            m_softwareCertificates = new SignedSoftwareCertificateCollection();
		}

        /// <summary>
        /// Initializes the server properties from the assembly properties.
        /// </summary>
        private void Initialize(Assembly assembly)
        {
            m_productUri = assembly.FullName;

            AssemblyTitleAttribute attribute1 = Attribute.GetCustomAttribute(assembly, typeof(AssemblyTitleAttribute)) as AssemblyTitleAttribute;

            if (attribute1 != null)
            {
                m_productName = attribute1.Title;
            }

            AssemblyCompanyAttribute attribute2 = Attribute.GetCustomAttribute(assembly, typeof(AssemblyCompanyAttribute)) as AssemblyCompanyAttribute;

            if (attribute2 != null)
            {
                m_manufacturerName = attribute2.Company;
            }

            Version version = assembly.GetName().Version;

            m_softwareVersion = Utils.Format("{0}.{1}", version.Major, version.Minor);
            m_buildNumber     = Utils.Format("{0}.{1}", version.Revision, version.Build);
            m_buildDate       = new FileInfo(assembly.Location).CreationTimeUtc;
        }
		#endregion

		#region Public Properties
		/// <summary>
		/// The unique identifier for the product.
		/// </summary>
		public string ProductUri
		{
			get { return m_productUri;  }
			set { m_productUri = value; }
		}

		/// <summary>
		/// The name of the product
		/// </summary>
		public string ProductName
		{
			get { return m_productName;  }
			set { m_productName = value; }
		}

		/// <summary>
		/// The name of the manufacturer
		/// </summary>
		public string ManufacturerName
		{
			get { return m_manufacturerName;  }
			set { m_manufacturerName = value; }
		}

		/// <summary>
		/// The software version for the application
		/// </summary>
		public string SoftwareVersion
		{
			get { return m_softwareVersion;  }
			set { m_softwareVersion = value; }
		}

		/// <summary>
		/// The build number for the application
		/// </summary>
		public string BuildNumber
		{
			get { return m_buildNumber;  }
			set { m_buildNumber = value; }
		}

		/// <summary>
		/// When the application was built.
        /// </summary>
		public DateTime BuildDate
		{
			get { return m_buildDate;  }
			set { m_buildDate = value; }
		}

		/// <summary>
		/// The assemblies that contain encodeable types that could be uses a variable values.
		/// </summary>
		public StringCollection DatatypeAssemblies
		{
			get { return m_datatypeAssemblies; }
		}

        /// <summary>
        /// The software certificates granted to the server.
        /// </summary>
        public SignedSoftwareCertificateCollection SoftwareCertificates
        {
            get { return m_softwareCertificates; }
        }
		#endregion

		#region Private Members
		private string m_productUri;
		private string m_productName;
		private string m_manufacturerName;
		private string m_softwareVersion;
		private string m_buildNumber;
		private DateTime m_buildDate;
        private StringCollection m_datatypeAssemblies;
        private SignedSoftwareCertificateCollection m_softwareCertificates;
		#endregion
	}
}
