/* ========================================================================
 * Copyright (c) 2005-2024 The OPC Foundation, Inc. All rights reserved.
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
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua.Gds;
using Opc.Ua;

namespace Opc.Ua.Onboarding
{
    #region CertificateAuthorityType Class
    #if (!OPCUA_EXCLUDE_CertificateAuthorityType)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd)]
    public partial class CertificateAuthorityType : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public CertificateAuthorityType()
        {
            Initialize();
        }
            
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }
            
        private void Initialize()
        {
            m_authorityCertificate = null;
            m_issuerCertificates = new ByteStringCollection();
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "AuthorityCertificate", IsRequired = false, Order = 1)]
        public byte[] AuthorityCertificate
        {
            get { return m_authorityCertificate;  }
            set { m_authorityCertificate = value; }
        }

        /// <remarks />
        [DataMember(Name = "IssuerCertificates", IsRequired = false, Order = 2)]
        public ByteStringCollection IssuerCertificates
        {
            get
            {
                return m_issuerCertificates;
            }

            set
            {
                m_issuerCertificates = value;

                if (value == null)
                {
                    m_issuerCertificates = new ByteStringCollection();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId => DataTypeIds.CertificateAuthorityType; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.CertificateAuthorityType_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.CertificateAuthorityType_Encoding_DefaultXml;
                    
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.CertificateAuthorityType_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd);

            encoder.WriteByteString("AuthorityCertificate", AuthorityCertificate);
            encoder.WriteByteStringArray("IssuerCertificates", IssuerCertificates);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd);

            AuthorityCertificate = decoder.ReadByteString("AuthorityCertificate");
            IssuerCertificates = decoder.ReadByteStringArray("IssuerCertificates");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            CertificateAuthorityType value = encodeable as CertificateAuthorityType;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_authorityCertificate, value.m_authorityCertificate)) return false;
            if (!Utils.IsEqual(m_issuerCertificates, value.m_issuerCertificates)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (CertificateAuthorityType)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            CertificateAuthorityType clone = (CertificateAuthorityType)base.MemberwiseClone();

            clone.m_authorityCertificate = (byte[])Utils.Clone(this.m_authorityCertificate);
            clone.m_issuerCertificates = (ByteStringCollection)Utils.Clone(this.m_issuerCertificates);

            return clone;
        }
        #endregion

        #region Private Fields
        private byte[] m_authorityCertificate;
        private ByteStringCollection m_issuerCertificates;
        #endregion
    }

    #region CertificateAuthorityTypeCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfCertificateAuthorityType", Namespace = Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd, ItemName = "CertificateAuthorityType")]
    public partial class CertificateAuthorityTypeCollection : List<CertificateAuthorityType>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public CertificateAuthorityTypeCollection() {}

        /// <remarks />
        public CertificateAuthorityTypeCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public CertificateAuthorityTypeCollection(IEnumerable<CertificateAuthorityType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator CertificateAuthorityTypeCollection(CertificateAuthorityType[] values)
        {
            if (values != null)
            {
                return new CertificateAuthorityTypeCollection(values);
            }

            return new CertificateAuthorityTypeCollection();
        }

        /// <remarks />
        public static explicit operator CertificateAuthorityType[](CertificateAuthorityTypeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <remarks />
        public object Clone()
        {
            return (CertificateAuthorityTypeCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            CertificateAuthorityTypeCollection clone = new CertificateAuthorityTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((CertificateAuthorityType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region BaseTicketType Class
    #if (!OPCUA_EXCLUDE_BaseTicketType)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd)]
    public partial class BaseTicketType : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public BaseTicketType()
        {
            Initialize();
        }
            
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }
            
        private void Initialize()
        {
            m_manufacturerName = null;
            m_modelName = null;
            m_modelVersion = null;
            m_hardwareRevision = null;
            m_softwareRevision = null;
            m_serialNumber = null;
            m_manufactureDate = DateTime.MinValue;
            m_authorities = new CertificateAuthorityTypeCollection();
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "ManufacturerName", IsRequired = false, Order = 1)]
        public string ManufacturerName
        {
            get { return m_manufacturerName;  }
            set { m_manufacturerName = value; }
        }

        /// <remarks />
        [DataMember(Name = "ModelName", IsRequired = false, Order = 2)]
        public string ModelName
        {
            get { return m_modelName;  }
            set { m_modelName = value; }
        }

        /// <remarks />
        [DataMember(Name = "ModelVersion", IsRequired = false, Order = 3)]
        public string ModelVersion
        {
            get { return m_modelVersion;  }
            set { m_modelVersion = value; }
        }

        /// <remarks />
        [DataMember(Name = "HardwareRevision", IsRequired = false, Order = 4)]
        public string HardwareRevision
        {
            get { return m_hardwareRevision;  }
            set { m_hardwareRevision = value; }
        }

        /// <remarks />
        [DataMember(Name = "SoftwareRevision", IsRequired = false, Order = 5)]
        public string SoftwareRevision
        {
            get { return m_softwareRevision;  }
            set { m_softwareRevision = value; }
        }

        /// <remarks />
        [DataMember(Name = "SerialNumber", IsRequired = false, Order = 6)]
        public string SerialNumber
        {
            get { return m_serialNumber;  }
            set { m_serialNumber = value; }
        }

        /// <remarks />
        [DataMember(Name = "ManufactureDate", IsRequired = false, Order = 7)]
        public DateTime ManufactureDate
        {
            get { return m_manufactureDate;  }
            set { m_manufactureDate = value; }
        }

        /// <remarks />
        [DataMember(Name = "Authorities", IsRequired = false, Order = 8)]
        public CertificateAuthorityTypeCollection Authorities
        {
            get
            {
                return m_authorities;
            }

            set
            {
                m_authorities = value;

                if (value == null)
                {
                    m_authorities = new CertificateAuthorityTypeCollection();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId => DataTypeIds.BaseTicketType; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.BaseTicketType_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.BaseTicketType_Encoding_DefaultXml;
                    
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.BaseTicketType_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd);

            encoder.WriteString("ManufacturerName", ManufacturerName);
            encoder.WriteString("ModelName", ModelName);
            encoder.WriteString("ModelVersion", ModelVersion);
            encoder.WriteString("HardwareRevision", HardwareRevision);
            encoder.WriteString("SoftwareRevision", SoftwareRevision);
            encoder.WriteString("SerialNumber", SerialNumber);
            encoder.WriteDateTime("ManufactureDate", ManufactureDate);
            encoder.WriteEncodeableArray("Authorities", Authorities.ToArray(), typeof(CertificateAuthorityType));

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd);

            ManufacturerName = decoder.ReadString("ManufacturerName");
            ModelName = decoder.ReadString("ModelName");
            ModelVersion = decoder.ReadString("ModelVersion");
            HardwareRevision = decoder.ReadString("HardwareRevision");
            SoftwareRevision = decoder.ReadString("SoftwareRevision");
            SerialNumber = decoder.ReadString("SerialNumber");
            ManufactureDate = decoder.ReadDateTime("ManufactureDate");
            Authorities = (CertificateAuthorityTypeCollection)decoder.ReadEncodeableArray("Authorities", typeof(CertificateAuthorityType));

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            BaseTicketType value = encodeable as BaseTicketType;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_manufacturerName, value.m_manufacturerName)) return false;
            if (!Utils.IsEqual(m_modelName, value.m_modelName)) return false;
            if (!Utils.IsEqual(m_modelVersion, value.m_modelVersion)) return false;
            if (!Utils.IsEqual(m_hardwareRevision, value.m_hardwareRevision)) return false;
            if (!Utils.IsEqual(m_softwareRevision, value.m_softwareRevision)) return false;
            if (!Utils.IsEqual(m_serialNumber, value.m_serialNumber)) return false;
            if (!Utils.IsEqual(m_manufactureDate, value.m_manufactureDate)) return false;
            if (!Utils.IsEqual(m_authorities, value.m_authorities)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (BaseTicketType)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            BaseTicketType clone = (BaseTicketType)base.MemberwiseClone();

            clone.m_manufacturerName = (string)Utils.Clone(this.m_manufacturerName);
            clone.m_modelName = (string)Utils.Clone(this.m_modelName);
            clone.m_modelVersion = (string)Utils.Clone(this.m_modelVersion);
            clone.m_hardwareRevision = (string)Utils.Clone(this.m_hardwareRevision);
            clone.m_softwareRevision = (string)Utils.Clone(this.m_softwareRevision);
            clone.m_serialNumber = (string)Utils.Clone(this.m_serialNumber);
            clone.m_manufactureDate = (DateTime)Utils.Clone(this.m_manufactureDate);
            clone.m_authorities = (CertificateAuthorityTypeCollection)Utils.Clone(this.m_authorities);

            return clone;
        }
        #endregion

        #region Private Fields
        private string m_manufacturerName;
        private string m_modelName;
        private string m_modelVersion;
        private string m_hardwareRevision;
        private string m_softwareRevision;
        private string m_serialNumber;
        private DateTime m_manufactureDate;
        private CertificateAuthorityTypeCollection m_authorities;
        #endregion
    }

    #region BaseTicketTypeCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfBaseTicketType", Namespace = Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd, ItemName = "BaseTicketType")]
    public partial class BaseTicketTypeCollection : List<BaseTicketType>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public BaseTicketTypeCollection() {}

        /// <remarks />
        public BaseTicketTypeCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public BaseTicketTypeCollection(IEnumerable<BaseTicketType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator BaseTicketTypeCollection(BaseTicketType[] values)
        {
            if (values != null)
            {
                return new BaseTicketTypeCollection(values);
            }

            return new BaseTicketTypeCollection();
        }

        /// <remarks />
        public static explicit operator BaseTicketType[](BaseTicketTypeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <remarks />
        public object Clone()
        {
            return (BaseTicketTypeCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            BaseTicketTypeCollection clone = new BaseTicketTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((BaseTicketType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region DeviceIdentityTicketType Class
    #if (!OPCUA_EXCLUDE_DeviceIdentityTicketType)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd)]
    public partial class DeviceIdentityTicketType : Opc.Ua.Onboarding.BaseTicketType
    {
        #region Constructors
        /// <remarks />
        public DeviceIdentityTicketType()
        {
            Initialize();
        }

        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        private void Initialize()
        {
            m_productInstanceUri = null;
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "ProductInstanceUri", IsRequired = false, Order = 1)]
        public string ProductInstanceUri
        {
            get { return m_productInstanceUri;  }
            set { m_productInstanceUri = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public override ExpandedNodeId TypeId => DataTypeIds.DeviceIdentityTicketType; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public override ExpandedNodeId BinaryEncodingId => ObjectIds.DeviceIdentityTicketType_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public override ExpandedNodeId XmlEncodingId => ObjectIds.DeviceIdentityTicketType_Encoding_DefaultXml;
            
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public override ExpandedNodeId JsonEncodingId => ObjectIds.DeviceIdentityTicketType_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd);

            encoder.WriteString("ProductInstanceUri", ProductInstanceUri);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd);

            ProductInstanceUri = decoder.ReadString("ProductInstanceUri");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            DeviceIdentityTicketType value = encodeable as DeviceIdentityTicketType;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_productInstanceUri, value.m_productInstanceUri)) return false;

            return base.IsEqual(encodeable);
        }    

        /// <summary cref="ICloneable.Clone" />
        public override object Clone()
        {
            return (DeviceIdentityTicketType)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            DeviceIdentityTicketType clone = (DeviceIdentityTicketType)base.MemberwiseClone();

            clone.m_productInstanceUri = (string)Utils.Clone(this.m_productInstanceUri);

            return clone;
        }
        #endregion

        #region Private Fields
        private string m_productInstanceUri;
        #endregion
    }

    #region DeviceIdentityTicketTypeCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfDeviceIdentityTicketType", Namespace = Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd, ItemName = "DeviceIdentityTicketType")]
    public partial class DeviceIdentityTicketTypeCollection : List<DeviceIdentityTicketType>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public DeviceIdentityTicketTypeCollection() {}

        /// <remarks />
        public DeviceIdentityTicketTypeCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public DeviceIdentityTicketTypeCollection(IEnumerable<DeviceIdentityTicketType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator DeviceIdentityTicketTypeCollection(DeviceIdentityTicketType[] values)
        {
            if (values != null)
            {
                return new DeviceIdentityTicketTypeCollection(values);
            }

            return new DeviceIdentityTicketTypeCollection();
        }

        /// <remarks />
        public static explicit operator DeviceIdentityTicketType[](DeviceIdentityTicketTypeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <remarks />
        public object Clone()
        {
            return (DeviceIdentityTicketTypeCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            DeviceIdentityTicketTypeCollection clone = new DeviceIdentityTicketTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((DeviceIdentityTicketType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region CompositeIdentityTicketType Class
    #if (!OPCUA_EXCLUDE_CompositeIdentityTicketType)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd)]
    public partial class CompositeIdentityTicketType : Opc.Ua.Onboarding.BaseTicketType
    {
        #region Constructors
        /// <remarks />
        public CompositeIdentityTicketType()
        {
            Initialize();
        }

        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        private void Initialize()
        {
            m_compositeInstanceUri = null;
            m_devices = new StringCollection();
            m_composites = new StringCollection();
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "CompositeInstanceUri", IsRequired = false, Order = 1)]
        public string CompositeInstanceUri
        {
            get { return m_compositeInstanceUri;  }
            set { m_compositeInstanceUri = value; }
        }

        /// <remarks />
        [DataMember(Name = "Devices", IsRequired = false, Order = 2)]
        public StringCollection Devices
        {
            get
            {
                return m_devices;
            }

            set
            {
                m_devices = value;

                if (value == null)
                {
                    m_devices = new StringCollection();
                }
            }
        }

        /// <remarks />
        [DataMember(Name = "Composites", IsRequired = false, Order = 3)]
        public StringCollection Composites
        {
            get
            {
                return m_composites;
            }

            set
            {
                m_composites = value;

                if (value == null)
                {
                    m_composites = new StringCollection();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public override ExpandedNodeId TypeId => DataTypeIds.CompositeIdentityTicketType; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public override ExpandedNodeId BinaryEncodingId => ObjectIds.CompositeIdentityTicketType_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public override ExpandedNodeId XmlEncodingId => ObjectIds.CompositeIdentityTicketType_Encoding_DefaultXml;
            
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public override ExpandedNodeId JsonEncodingId => ObjectIds.CompositeIdentityTicketType_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd);

            encoder.WriteString("CompositeInstanceUri", CompositeInstanceUri);
            encoder.WriteStringArray("Devices", Devices);
            encoder.WriteStringArray("Composites", Composites);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd);

            CompositeInstanceUri = decoder.ReadString("CompositeInstanceUri");
            Devices = decoder.ReadStringArray("Devices");
            Composites = decoder.ReadStringArray("Composites");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            CompositeIdentityTicketType value = encodeable as CompositeIdentityTicketType;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_compositeInstanceUri, value.m_compositeInstanceUri)) return false;
            if (!Utils.IsEqual(m_devices, value.m_devices)) return false;
            if (!Utils.IsEqual(m_composites, value.m_composites)) return false;

            return base.IsEqual(encodeable);
        }    

        /// <summary cref="ICloneable.Clone" />
        public override object Clone()
        {
            return (CompositeIdentityTicketType)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            CompositeIdentityTicketType clone = (CompositeIdentityTicketType)base.MemberwiseClone();

            clone.m_compositeInstanceUri = (string)Utils.Clone(this.m_compositeInstanceUri);
            clone.m_devices = (StringCollection)Utils.Clone(this.m_devices);
            clone.m_composites = (StringCollection)Utils.Clone(this.m_composites);

            return clone;
        }
        #endregion

        #region Private Fields
        private string m_compositeInstanceUri;
        private StringCollection m_devices;
        private StringCollection m_composites;
        #endregion
    }

    #region CompositeIdentityTicketTypeCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfCompositeIdentityTicketType", Namespace = Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd, ItemName = "CompositeIdentityTicketType")]
    public partial class CompositeIdentityTicketTypeCollection : List<CompositeIdentityTicketType>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public CompositeIdentityTicketTypeCollection() {}

        /// <remarks />
        public CompositeIdentityTicketTypeCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public CompositeIdentityTicketTypeCollection(IEnumerable<CompositeIdentityTicketType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator CompositeIdentityTicketTypeCollection(CompositeIdentityTicketType[] values)
        {
            if (values != null)
            {
                return new CompositeIdentityTicketTypeCollection(values);
            }

            return new CompositeIdentityTicketTypeCollection();
        }

        /// <remarks />
        public static explicit operator CompositeIdentityTicketType[](CompositeIdentityTicketTypeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <remarks />
        public object Clone()
        {
            return (CompositeIdentityTicketTypeCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            CompositeIdentityTicketTypeCollection clone = new CompositeIdentityTicketTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((CompositeIdentityTicketType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region TicketListType Class
    #if (!OPCUA_EXCLUDE_TicketListType)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd)]
    public partial class TicketListType : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public TicketListType()
        {
            Initialize();
        }
            
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }
            
        private void Initialize()
        {
            m_devices = new StringCollection();
            m_composites = new StringCollection();
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "Devices", IsRequired = false, Order = 1)]
        public StringCollection Devices
        {
            get
            {
                return m_devices;
            }

            set
            {
                m_devices = value;

                if (value == null)
                {
                    m_devices = new StringCollection();
                }
            }
        }

        /// <remarks />
        [DataMember(Name = "Composites", IsRequired = false, Order = 2)]
        public StringCollection Composites
        {
            get
            {
                return m_composites;
            }

            set
            {
                m_composites = value;

                if (value == null)
                {
                    m_composites = new StringCollection();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId => DataTypeIds.TicketListType; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.TicketListType_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.TicketListType_Encoding_DefaultXml;
                    
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.TicketListType_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd);

            encoder.WriteStringArray("Devices", Devices);
            encoder.WriteStringArray("Composites", Composites);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd);

            Devices = decoder.ReadStringArray("Devices");
            Composites = decoder.ReadStringArray("Composites");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            TicketListType value = encodeable as TicketListType;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_devices, value.m_devices)) return false;
            if (!Utils.IsEqual(m_composites, value.m_composites)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (TicketListType)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            TicketListType clone = (TicketListType)base.MemberwiseClone();

            clone.m_devices = (StringCollection)Utils.Clone(this.m_devices);
            clone.m_composites = (StringCollection)Utils.Clone(this.m_composites);

            return clone;
        }
        #endregion

        #region Private Fields
        private StringCollection m_devices;
        private StringCollection m_composites;
        #endregion
    }

    #region TicketListTypeCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfTicketListType", Namespace = Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd, ItemName = "TicketListType")]
    public partial class TicketListTypeCollection : List<TicketListType>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public TicketListTypeCollection() {}

        /// <remarks />
        public TicketListTypeCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public TicketListTypeCollection(IEnumerable<TicketListType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator TicketListTypeCollection(TicketListType[] values)
        {
            if (values != null)
            {
                return new TicketListTypeCollection(values);
            }

            return new TicketListTypeCollection();
        }

        /// <remarks />
        public static explicit operator TicketListType[](TicketListTypeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <remarks />
        public object Clone()
        {
            return (TicketListTypeCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            TicketListTypeCollection clone = new TicketListTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((TicketListType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region ManagerDescription Class
    #if (!OPCUA_EXCLUDE_ManagerDescription)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd)]
    public partial class ManagerDescription : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public ManagerDescription()
        {
            Initialize();
        }
            
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }
            
        private void Initialize()
        {
            m_name = null;
            m_isRequired = true;
            m_purposeUri = null;
            m_protocolUri = null;
            m_endpointUrls = new StringCollection();
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "Name", IsRequired = false, Order = 1)]
        public LocalizedText Name
        {
            get { return m_name;  }
            set { m_name = value; }
        }

        /// <remarks />
        [DataMember(Name = "IsRequired", IsRequired = false, Order = 2)]
        public bool IsRequired
        {
            get { return m_isRequired;  }
            set { m_isRequired = value; }
        }

        /// <remarks />
        [DataMember(Name = "PurposeUri", IsRequired = false, Order = 3)]
        public string PurposeUri
        {
            get { return m_purposeUri;  }
            set { m_purposeUri = value; }
        }

        /// <remarks />
        [DataMember(Name = "ProtocolUri", IsRequired = false, Order = 4)]
        public string ProtocolUri
        {
            get { return m_protocolUri;  }
            set { m_protocolUri = value; }
        }

        /// <remarks />
        [DataMember(Name = "EndpointUrls", IsRequired = false, Order = 5)]
        public StringCollection EndpointUrls
        {
            get
            {
                return m_endpointUrls;
            }

            set
            {
                m_endpointUrls = value;

                if (value == null)
                {
                    m_endpointUrls = new StringCollection();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId => DataTypeIds.ManagerDescription; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ManagerDescription_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ManagerDescription_Encoding_DefaultXml;
                    
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ManagerDescription_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd);

            encoder.WriteLocalizedText("Name", Name);
            encoder.WriteBoolean("IsRequired", IsRequired);
            encoder.WriteString("PurposeUri", PurposeUri);
            encoder.WriteString("ProtocolUri", ProtocolUri);
            encoder.WriteStringArray("EndpointUrls", EndpointUrls);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd);

            Name = decoder.ReadLocalizedText("Name");
            IsRequired = decoder.ReadBoolean("IsRequired");
            PurposeUri = decoder.ReadString("PurposeUri");
            ProtocolUri = decoder.ReadString("ProtocolUri");
            EndpointUrls = decoder.ReadStringArray("EndpointUrls");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            ManagerDescription value = encodeable as ManagerDescription;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_name, value.m_name)) return false;
            if (!Utils.IsEqual(m_isRequired, value.m_isRequired)) return false;
            if (!Utils.IsEqual(m_purposeUri, value.m_purposeUri)) return false;
            if (!Utils.IsEqual(m_protocolUri, value.m_protocolUri)) return false;
            if (!Utils.IsEqual(m_endpointUrls, value.m_endpointUrls)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (ManagerDescription)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            ManagerDescription clone = (ManagerDescription)base.MemberwiseClone();

            clone.m_name = (LocalizedText)Utils.Clone(this.m_name);
            clone.m_isRequired = (bool)Utils.Clone(this.m_isRequired);
            clone.m_purposeUri = (string)Utils.Clone(this.m_purposeUri);
            clone.m_protocolUri = (string)Utils.Clone(this.m_protocolUri);
            clone.m_endpointUrls = (StringCollection)Utils.Clone(this.m_endpointUrls);

            return clone;
        }
        #endregion

        #region Private Fields
        private LocalizedText m_name;
        private bool m_isRequired;
        private string m_purposeUri;
        private string m_protocolUri;
        private StringCollection m_endpointUrls;
        #endregion
    }

    #region ManagerDescriptionCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfManagerDescription", Namespace = Opc.Ua.Onboarding.Namespaces.OpcUaOnboardingXsd, ItemName = "ManagerDescription")]
    public partial class ManagerDescriptionCollection : List<ManagerDescription>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public ManagerDescriptionCollection() {}

        /// <remarks />
        public ManagerDescriptionCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public ManagerDescriptionCollection(IEnumerable<ManagerDescription> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator ManagerDescriptionCollection(ManagerDescription[] values)
        {
            if (values != null)
            {
                return new ManagerDescriptionCollection(values);
            }

            return new ManagerDescriptionCollection();
        }

        /// <remarks />
        public static explicit operator ManagerDescription[](ManagerDescriptionCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <remarks />
        public object Clone()
        {
            return (ManagerDescriptionCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            ManagerDescriptionCollection clone = new ManagerDescriptionCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((ManagerDescription)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion
}
