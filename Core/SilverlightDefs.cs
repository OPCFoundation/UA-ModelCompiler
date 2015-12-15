/* ========================================================================
 * Copyright (c) 2005-2011 The OPC Foundation, Inc. All rights reserved.
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

#if SILVERLIGHT
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace System
{
    public class SerializableAttribute : Attribute
    {
    }
}

namespace System.ComponentModel
{
    public class DesignerCategoryAttribute : Attribute
    {
        public DesignerCategoryAttribute(string dummy)
        {
        }
    }
}

namespace System.Security
{
    public class SecureString
    {
    }
}

namespace System.IdentityModel.Tokens
{
    public class SecureString
    {
    }

    public class SecurityToken
    {
    }
}

namespace System.IdentityModel.Selectors
{
}

namespace System.Security.Cryptography.X509Certificates
{
    public class X500DistinguishedName
    {
        public string Name { get; set; }
    }

    public class X509Certificate2 : X509Certificate
    {
        public X509Certificate2()
        {
        }

        public X509Certificate2(byte[] bytes)
            : base(bytes)
        {
        }

        public string FriendlyName
        {
            get { return null; }
        }

        public X500DistinguishedName SubjectName
        {
            get { return new X500DistinguishedName(); }
        }

        public string Thumbprint
        {
            get { return GetCertHashString(); }
        }

        public bool HasPrivateKey
        {
            get { return false; }
        }
    }

    public class X509Certificate2Collection : System.Collections.Generic.List<X509Certificate2>
    {
    }

    public class X509CertificateValidator
    {
    }
}

namespace System.Collections.Generic
{
    public class SortedDictionary<K,V> : System.Collections.Generic.Dictionary<K,V>
    {
    }
}

namespace System.Net
{
    public static class Dns
    {
        public static string GetHostName()
        {
            return "localhost";
        }
    }
}

namespace System.Runtime.Serialization
{
    public interface IExtensibleDataObject
    {
    }

    public class ExtensionDataObject
    {
    }
}

namespace System.Xml
{
    public class XmlDocument
    {
        public string InnerXml
        {
            get
            {
                if (DocumentElement != null)
                {
                    return DocumentElement.OuterXml;
                }

                return null;
            }

            set
            {
                if (DocumentElement == null)
                {
                    DocumentElement = new XmlElement();
                }

                DocumentElement.OuterXml = value;
            }
        }

        public XmlElement DocumentElement { get; set; }
    }

    public class XmlElement
    {
        public string NamespaceURI { get; set; }
        public string LocalName { get; set; }
        public string Prefix { get; set; }
        public string Name { get; set; }
        public string OuterXml { get; set; }
    }
}

namespace Opc.Ua
{
    public interface ICloneable
    {
        Object Clone();
    }

    public class SerializationInfo
    {
    }
}
#endif
