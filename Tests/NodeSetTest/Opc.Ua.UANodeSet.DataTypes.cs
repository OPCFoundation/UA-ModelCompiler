/* ========================================================================
 * Copyright (c) 2005-2020 The OPC Foundation, Inc. All rights reserved.
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
using Opc.Ua;

namespace Opc.Ua.UANodeSet
{
    #region ModelTableEntry Class
    #if (!OPCUA_EXCLUDE_ModelTableEntry)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd)]
    public partial class ModelTableEntry : IEncodeable
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public ModelTableEntry()
        {
            Initialize();
        }

        /// <summary>
        /// Called by the .NET framework during deserialization.
        /// </summary>
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_modelUri = null;
            m_version = null;
            m_publicationDate = DateTime.MinValue;
            m_rolePermissions = new RolePermissionTypeCollection();
            m_accessRestrictions = 0;
            m_requiredModels = new ModelTableEntryCollection();
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "ModelUri", IsRequired = false, Order = 1)]
        public string ModelUri
        {
            get { return m_modelUri;  }
            set { m_modelUri = value; }
        }

        /// <remarks />
        [DataMember(Name = "Version", IsRequired = false, Order = 2)]
        public string Version
        {
            get { return m_version;  }
            set { m_version = value; }
        }

        /// <remarks />
        [DataMember(Name = "PublicationDate", IsRequired = false, Order = 3)]
        public DateTime PublicationDate
        {
            get { return m_publicationDate;  }
            set { m_publicationDate = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "RolePermissions", IsRequired = false, Order = 4)]
        public RolePermissionTypeCollection RolePermissions
        {
            get
            {
                return m_rolePermissions;
            }

            set
            {
                m_rolePermissions = value;

                if (value == null)
                {
                    m_rolePermissions = new RolePermissionTypeCollection();
                }
            }
        }

        /// <remarks />
        [DataMember(Name = "AccessRestrictions", IsRequired = false, Order = 5)]
        public ushort AccessRestrictions
        {
            get { return m_accessRestrictions;  }
            set { m_accessRestrictions = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "RequiredModels", IsRequired = false, Order = 6)]
        public ModelTableEntryCollection RequiredModels
        {
            get
            {
                return m_requiredModels;
            }

            set
            {
                m_requiredModels = value;

                if (value == null)
                {
                    m_requiredModels = new ModelTableEntryCollection();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId
        {
            get { return DataTypeIds.ModelTableEntry; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.ModelTableEntry_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.ModelTableEntry_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            encoder.WriteString("ModelUri", ModelUri);
            encoder.WriteString("Version", Version);
            encoder.WriteDateTime("PublicationDate", PublicationDate);
            encoder.WriteEncodeableArray("RolePermissions", RolePermissions.ToArray(), typeof(RolePermissionType));
            encoder.WriteUInt16("AccessRestrictions", AccessRestrictions);
            encoder.WriteEncodeableArray("RequiredModels", RequiredModels.ToArray(), typeof(ModelTableEntry));

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            ModelUri = decoder.ReadString("ModelUri");
            Version = decoder.ReadString("Version");
            PublicationDate = decoder.ReadDateTime("PublicationDate");
            RolePermissions = (RolePermissionTypeCollection)decoder.ReadEncodeableArray("RolePermissions", typeof(RolePermissionType));
            AccessRestrictions = decoder.ReadUInt16("AccessRestrictions");
            RequiredModels = (ModelTableEntryCollection)decoder.ReadEncodeableArray("RequiredModels", typeof(ModelTableEntry));

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            ModelTableEntry value = encodeable as ModelTableEntry;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_modelUri, value.m_modelUri)) return false;
            if (!Utils.IsEqual(m_version, value.m_version)) return false;
            if (!Utils.IsEqual(m_publicationDate, value.m_publicationDate)) return false;
            if (!Utils.IsEqual(m_rolePermissions, value.m_rolePermissions)) return false;
            if (!Utils.IsEqual(m_accessRestrictions, value.m_accessRestrictions)) return false;
            if (!Utils.IsEqual(m_requiredModels, value.m_requiredModels)) return false;

            return true;
        }

        #if !NET_STANDARD
        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (ModelTableEntry)this.MemberwiseClone();
        }
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            ModelTableEntry clone = (ModelTableEntry)base.MemberwiseClone();

            clone.m_modelUri = (string)Utils.Clone(this.m_modelUri);
            clone.m_version = (string)Utils.Clone(this.m_version);
            clone.m_publicationDate = (DateTime)Utils.Clone(this.m_publicationDate);
            clone.m_rolePermissions = (RolePermissionTypeCollection)Utils.Clone(this.m_rolePermissions);
            clone.m_accessRestrictions = (ushort)Utils.Clone(this.m_accessRestrictions);
            clone.m_requiredModels = (ModelTableEntryCollection)Utils.Clone(this.m_requiredModels);

            return clone;
        }
        #endregion

        #region Private Fields
        private string m_modelUri;
        private string m_version;
        private DateTime m_publicationDate;
        private RolePermissionTypeCollection m_rolePermissions;
        private ushort m_accessRestrictions;
        private ModelTableEntryCollection m_requiredModels;
        #endregion
    }

    #region ModelTableEntryCollection Class
    /// <summary>
    /// A collection of ModelTableEntry objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfModelTableEntry", Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd, ItemName = "ModelTableEntry")]
    #if !NET_STANDARD
    public partial class ModelTableEntryCollection : List<ModelTableEntry>, ICloneable
    #else
    public partial class ModelTableEntryCollection : List<ModelTableEntry>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public ModelTableEntryCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public ModelTableEntryCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public ModelTableEntryCollection(IEnumerable<ModelTableEntry> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator ModelTableEntryCollection(ModelTableEntry[] values)
        {
            if (values != null)
            {
                return new ModelTableEntryCollection(values);
            }

            return new ModelTableEntryCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator ModelTableEntry[](ModelTableEntryCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #if !NET_STANDARD
        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            return (ModelTableEntryCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            ModelTableEntryCollection clone = new ModelTableEntryCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((ModelTableEntry)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region UANodeSet Class
    #if (!OPCUA_EXCLUDE_UANodeSet)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd)]
    public partial class UANodeSet : IEncodeable
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public UANodeSet()
        {
            Initialize();
        }

        /// <summary>
        /// Called by the .NET framework during deserialization.
        /// </summary>
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_namespaceUris = new StringCollection();
            m_serverUris = new StringCollection();
            m_models = new ModelTableEntryCollection();
            m_extensions = new KeyValuePairCollection();
            m_lastModified = DateTime.MinValue;
            m_nodes = new ExtensionObjectCollection();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "NamespaceUris", IsRequired = false, Order = 1)]
        public StringCollection NamespaceUris
        {
            get
            {
                return m_namespaceUris;
            }

            set
            {
                m_namespaceUris = value;

                if (value == null)
                {
                    m_namespaceUris = new StringCollection();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "ServerUris", IsRequired = false, Order = 2)]
        public StringCollection ServerUris
        {
            get
            {
                return m_serverUris;
            }

            set
            {
                m_serverUris = value;

                if (value == null)
                {
                    m_serverUris = new StringCollection();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Models", IsRequired = false, Order = 3)]
        public ModelTableEntryCollection Models
        {
            get
            {
                return m_models;
            }

            set
            {
                m_models = value;

                if (value == null)
                {
                    m_models = new ModelTableEntryCollection();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Extensions", IsRequired = false, Order = 4)]
        public KeyValuePairCollection Extensions
        {
            get
            {
                return m_extensions;
            }

            set
            {
                m_extensions = value;

                if (value == null)
                {
                    m_extensions = new KeyValuePairCollection();
                }
            }
        }

        /// <remarks />
        [DataMember(Name = "LastModified", IsRequired = false, Order = 5)]
        public DateTime LastModified
        {
            get { return m_lastModified;  }
            set { m_lastModified = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Nodes", IsRequired = false, Order = 6)]
        public ExtensionObjectCollection Nodes
        {
            get
            {
                return m_nodes;
            }

            set
            {
                m_nodes = value;

                if (value == null)
                {
                    m_nodes = new ExtensionObjectCollection();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId
        {
            get { return DataTypeIds.UANodeSet; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.UANodeSet_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.UANodeSet_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            encoder.WriteStringArray("NamespaceUris", NamespaceUris);
            encoder.WriteStringArray("ServerUris", ServerUris);
            encoder.WriteEncodeableArray("Models", Models.ToArray(), typeof(ModelTableEntry));
            encoder.WriteEncodeableArray("Extensions", Extensions.ToArray(), typeof(KeyValuePair));
            encoder.WriteDateTime("LastModified", LastModified);
            encoder.WriteExtensionObjectArray("Nodes", Nodes);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            NamespaceUris = decoder.ReadStringArray("NamespaceUris");
            ServerUris = decoder.ReadStringArray("ServerUris");
            Models = (ModelTableEntryCollection)decoder.ReadEncodeableArray("Models", typeof(ModelTableEntry));
            Extensions = (KeyValuePairCollection)decoder.ReadEncodeableArray("Extensions", typeof(KeyValuePair));
            LastModified = decoder.ReadDateTime("LastModified");
            Nodes = decoder.ReadExtensionObjectArray("Nodes");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            UANodeSet value = encodeable as UANodeSet;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_namespaceUris, value.m_namespaceUris)) return false;
            if (!Utils.IsEqual(m_serverUris, value.m_serverUris)) return false;
            if (!Utils.IsEqual(m_models, value.m_models)) return false;
            if (!Utils.IsEqual(m_extensions, value.m_extensions)) return false;
            if (!Utils.IsEqual(m_lastModified, value.m_lastModified)) return false;
            if (!Utils.IsEqual(m_nodes, value.m_nodes)) return false;

            return true;
        }

        #if !NET_STANDARD
        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (UANodeSet)this.MemberwiseClone();
        }
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UANodeSet clone = (UANodeSet)base.MemberwiseClone();

            clone.m_namespaceUris = (StringCollection)Utils.Clone(this.m_namespaceUris);
            clone.m_serverUris = (StringCollection)Utils.Clone(this.m_serverUris);
            clone.m_models = (ModelTableEntryCollection)Utils.Clone(this.m_models);
            clone.m_extensions = (KeyValuePairCollection)Utils.Clone(this.m_extensions);
            clone.m_lastModified = (DateTime)Utils.Clone(this.m_lastModified);
            clone.m_nodes = (ExtensionObjectCollection)Utils.Clone(this.m_nodes);

            return clone;
        }
        #endregion

        #region Private Fields
        private StringCollection m_namespaceUris;
        private StringCollection m_serverUris;
        private ModelTableEntryCollection m_models;
        private KeyValuePairCollection m_extensions;
        private DateTime m_lastModified;
        private ExtensionObjectCollection m_nodes;
        #endregion
    }

    #region UANodeSetCollection Class
    /// <summary>
    /// A collection of UANodeSet objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfUANodeSet", Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd, ItemName = "UANodeSet")]
    #if !NET_STANDARD
    public partial class UANodeSetCollection : List<UANodeSet>, ICloneable
    #else
    public partial class UANodeSetCollection : List<UANodeSet>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public UANodeSetCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public UANodeSetCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public UANodeSetCollection(IEnumerable<UANodeSet> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator UANodeSetCollection(UANodeSet[] values)
        {
            if (values != null)
            {
                return new UANodeSetCollection(values);
            }

            return new UANodeSetCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator UANodeSet[](UANodeSetCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #if !NET_STANDARD
        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            return (UANodeSetCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UANodeSetCollection clone = new UANodeSetCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((UANodeSet)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region UAReference Class
    #if (!OPCUA_EXCLUDE_UAReference)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd)]
    public partial class UAReference : IEncodeable
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public UAReference()
        {
            Initialize();
        }

        /// <summary>
        /// Called by the .NET framework during deserialization.
        /// </summary>
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_targetId = null;
            m_referenceTypeId = null;
            m_isForward = true;
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "TargetId", IsRequired = false, Order = 1)]
        public NodeId TargetId
        {
            get { return m_targetId;  }
            set { m_targetId = value; }
        }

        /// <remarks />
        [DataMember(Name = "ReferenceTypeId", IsRequired = false, Order = 2)]
        public NodeId ReferenceTypeId
        {
            get { return m_referenceTypeId;  }
            set { m_referenceTypeId = value; }
        }

        /// <remarks />
        [DataMember(Name = "IsForward", IsRequired = false, Order = 3)]
        public bool IsForward
        {
            get { return m_isForward;  }
            set { m_isForward = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId
        {
            get { return DataTypeIds.UAReference; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.UAReference_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.UAReference_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            encoder.WriteNodeId("TargetId", TargetId);
            encoder.WriteNodeId("ReferenceTypeId", ReferenceTypeId);
            encoder.WriteBoolean("IsForward", IsForward);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            TargetId = decoder.ReadNodeId("TargetId");
            ReferenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
            IsForward = decoder.ReadBoolean("IsForward");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            UAReference value = encodeable as UAReference;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_targetId, value.m_targetId)) return false;
            if (!Utils.IsEqual(m_referenceTypeId, value.m_referenceTypeId)) return false;
            if (!Utils.IsEqual(m_isForward, value.m_isForward)) return false;

            return true;
        }

        #if !NET_STANDARD
        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (UAReference)this.MemberwiseClone();
        }
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UAReference clone = (UAReference)base.MemberwiseClone();

            clone.m_targetId = (NodeId)Utils.Clone(this.m_targetId);
            clone.m_referenceTypeId = (NodeId)Utils.Clone(this.m_referenceTypeId);
            clone.m_isForward = (bool)Utils.Clone(this.m_isForward);

            return clone;
        }
        #endregion

        #region Private Fields
        private NodeId m_targetId;
        private NodeId m_referenceTypeId;
        private bool m_isForward;
        #endregion
    }

    #region UAReferenceCollection Class
    /// <summary>
    /// A collection of UAReference objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfUAReference", Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd, ItemName = "UAReference")]
    #if !NET_STANDARD
    public partial class UAReferenceCollection : List<UAReference>, ICloneable
    #else
    public partial class UAReferenceCollection : List<UAReference>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public UAReferenceCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public UAReferenceCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public UAReferenceCollection(IEnumerable<UAReference> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator UAReferenceCollection(UAReference[] values)
        {
            if (values != null)
            {
                return new UAReferenceCollection(values);
            }

            return new UAReferenceCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator UAReference[](UAReferenceCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #if !NET_STANDARD
        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            return (UAReferenceCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UAReferenceCollection clone = new UAReferenceCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((UAReference)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region ReleaseStatus Enumeration
    #if (!OPCUA_EXCLUDE_ReleaseStatus)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd)]
    public enum ReleaseStatus
    {
        /// <remarks />
        [EnumMember(Value = "Released_1")]
        Released = 1,

        /// <remarks />
        [EnumMember(Value = "Draft_2")]
        Draft = 2,

        /// <remarks />
        [EnumMember(Value = "Deprecated_3")]
        Deprecated = 3,
    }

    #region ReleaseStatusCollection Class
    /// <summary>
    /// A collection of ReleaseStatus objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfReleaseStatus", Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd, ItemName = "ReleaseStatus")]
    #if !NET_STANDARD
    public partial class ReleaseStatusCollection : List<ReleaseStatus>, ICloneable
    #else
    public partial class ReleaseStatusCollection : List<ReleaseStatus>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public ReleaseStatusCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public ReleaseStatusCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public ReleaseStatusCollection(IEnumerable<ReleaseStatus> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator ReleaseStatusCollection(ReleaseStatus[] values)
        {
            if (values != null)
            {
                return new ReleaseStatusCollection(values);
            }

            return new ReleaseStatusCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator ReleaseStatus[](ReleaseStatusCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #if !NET_STANDARD
        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            return (ReleaseStatusCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            ReleaseStatusCollection clone = new ReleaseStatusCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((ReleaseStatus)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region UABaseNode Class
    #if (!OPCUA_EXCLUDE_UABaseNode)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd)]
    public partial class UABaseNode : IEncodeable
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public UABaseNode()
        {
            Initialize();
        }

        /// <summary>
        /// Called by the .NET framework during deserialization.
        /// </summary>
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_nodeId = null;
            m_browseName = null;
            m_symbolicName = null;
            m_displayNames = new LocalizedTextCollection();
            m_descriptions = new LocalizedTextCollection();
            m_documentation = null;
            m_writeMask = 0;
            m_rolePermissions = new RolePermissionTypeCollection();
            m_accessRestrictions = 0;
            m_releaseStatus = ReleaseStatus.Released;
            m_references = new UAReferenceCollection();
            m_extensions = new KeyValuePairCollection();
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "NodeId", IsRequired = false, Order = 1)]
        public NodeId NodeId
        {
            get { return m_nodeId;  }
            set { m_nodeId = value; }
        }

        /// <remarks />
        [DataMember(Name = "BrowseName", IsRequired = false, Order = 2)]
        public QualifiedName BrowseName
        {
            get { return m_browseName;  }
            set { m_browseName = value; }
        }

        /// <remarks />
        [DataMember(Name = "SymbolicName", IsRequired = false, Order = 3)]
        public string SymbolicName
        {
            get { return m_symbolicName;  }
            set { m_symbolicName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "DisplayNames", IsRequired = false, Order = 4)]
        public LocalizedTextCollection DisplayNames
        {
            get
            {
                return m_displayNames;
            }

            set
            {
                m_displayNames = value;

                if (value == null)
                {
                    m_displayNames = new LocalizedTextCollection();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Descriptions", IsRequired = false, Order = 5)]
        public LocalizedTextCollection Descriptions
        {
            get
            {
                return m_descriptions;
            }

            set
            {
                m_descriptions = value;

                if (value == null)
                {
                    m_descriptions = new LocalizedTextCollection();
                }
            }
        }

        /// <remarks />
        [DataMember(Name = "Documentation", IsRequired = false, Order = 6)]
        public string Documentation
        {
            get { return m_documentation;  }
            set { m_documentation = value; }
        }

        /// <remarks />
        [DataMember(Name = "WriteMask", IsRequired = false, Order = 7)]
        public uint WriteMask
        {
            get { return m_writeMask;  }
            set { m_writeMask = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "RolePermissions", IsRequired = false, Order = 8)]
        public RolePermissionTypeCollection RolePermissions
        {
            get
            {
                return m_rolePermissions;
            }

            set
            {
                m_rolePermissions = value;

                if (value == null)
                {
                    m_rolePermissions = new RolePermissionTypeCollection();
                }
            }
        }

        /// <remarks />
        [DataMember(Name = "AccessRestrictions", IsRequired = false, Order = 9)]
        public ushort AccessRestrictions
        {
            get { return m_accessRestrictions;  }
            set { m_accessRestrictions = value; }
        }

        /// <remarks />
        [DataMember(Name = "ReleaseStatus", IsRequired = false, Order = 10)]
        public ReleaseStatus ReleaseStatus
        {
            get { return m_releaseStatus;  }
            set { m_releaseStatus = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "References", IsRequired = false, Order = 11)]
        public UAReferenceCollection References
        {
            get
            {
                return m_references;
            }

            set
            {
                m_references = value;

                if (value == null)
                {
                    m_references = new UAReferenceCollection();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Extensions", IsRequired = false, Order = 12)]
        public KeyValuePairCollection Extensions
        {
            get
            {
                return m_extensions;
            }

            set
            {
                m_extensions = value;

                if (value == null)
                {
                    m_extensions = new KeyValuePairCollection();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId
        {
            get { return DataTypeIds.UABaseNode; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.UABaseNode_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.UABaseNode_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            encoder.WriteNodeId("NodeId", NodeId);
            encoder.WriteQualifiedName("BrowseName", BrowseName);
            encoder.WriteString("SymbolicName", SymbolicName);
            encoder.WriteLocalizedTextArray("DisplayNames", DisplayNames);
            encoder.WriteLocalizedTextArray("Descriptions", Descriptions);
            encoder.WriteString("Documentation", Documentation);
            encoder.WriteUInt32("WriteMask", WriteMask);
            encoder.WriteEncodeableArray("RolePermissions", RolePermissions.ToArray(), typeof(RolePermissionType));
            encoder.WriteUInt16("AccessRestrictions", AccessRestrictions);
            encoder.WriteEnumerated("ReleaseStatus", ReleaseStatus);
            encoder.WriteEncodeableArray("References", References.ToArray(), typeof(UAReference));
            encoder.WriteEncodeableArray("Extensions", Extensions.ToArray(), typeof(KeyValuePair));

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            NodeId = decoder.ReadNodeId("NodeId");
            BrowseName = decoder.ReadQualifiedName("BrowseName");
            SymbolicName = decoder.ReadString("SymbolicName");
            DisplayNames = decoder.ReadLocalizedTextArray("DisplayNames");
            Descriptions = decoder.ReadLocalizedTextArray("Descriptions");
            Documentation = decoder.ReadString("Documentation");
            WriteMask = decoder.ReadUInt32("WriteMask");
            RolePermissions = (RolePermissionTypeCollection)decoder.ReadEncodeableArray("RolePermissions", typeof(RolePermissionType));
            AccessRestrictions = decoder.ReadUInt16("AccessRestrictions");
            ReleaseStatus = (ReleaseStatus)decoder.ReadEnumerated("ReleaseStatus", typeof(ReleaseStatus));
            References = (UAReferenceCollection)decoder.ReadEncodeableArray("References", typeof(UAReference));
            Extensions = (KeyValuePairCollection)decoder.ReadEncodeableArray("Extensions", typeof(KeyValuePair));

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            UABaseNode value = encodeable as UABaseNode;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_nodeId, value.m_nodeId)) return false;
            if (!Utils.IsEqual(m_browseName, value.m_browseName)) return false;
            if (!Utils.IsEqual(m_symbolicName, value.m_symbolicName)) return false;
            if (!Utils.IsEqual(m_displayNames, value.m_displayNames)) return false;
            if (!Utils.IsEqual(m_descriptions, value.m_descriptions)) return false;
            if (!Utils.IsEqual(m_documentation, value.m_documentation)) return false;
            if (!Utils.IsEqual(m_writeMask, value.m_writeMask)) return false;
            if (!Utils.IsEqual(m_rolePermissions, value.m_rolePermissions)) return false;
            if (!Utils.IsEqual(m_accessRestrictions, value.m_accessRestrictions)) return false;
            if (!Utils.IsEqual(m_releaseStatus, value.m_releaseStatus)) return false;
            if (!Utils.IsEqual(m_references, value.m_references)) return false;
            if (!Utils.IsEqual(m_extensions, value.m_extensions)) return false;

            return true;
        }

        #if !NET_STANDARD
        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (UABaseNode)this.MemberwiseClone();
        }
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UABaseNode clone = (UABaseNode)base.MemberwiseClone();

            clone.m_nodeId = (NodeId)Utils.Clone(this.m_nodeId);
            clone.m_browseName = (QualifiedName)Utils.Clone(this.m_browseName);
            clone.m_symbolicName = (string)Utils.Clone(this.m_symbolicName);
            clone.m_displayNames = (LocalizedTextCollection)Utils.Clone(this.m_displayNames);
            clone.m_descriptions = (LocalizedTextCollection)Utils.Clone(this.m_descriptions);
            clone.m_documentation = (string)Utils.Clone(this.m_documentation);
            clone.m_writeMask = (uint)Utils.Clone(this.m_writeMask);
            clone.m_rolePermissions = (RolePermissionTypeCollection)Utils.Clone(this.m_rolePermissions);
            clone.m_accessRestrictions = (ushort)Utils.Clone(this.m_accessRestrictions);
            clone.m_releaseStatus = (ReleaseStatus)Utils.Clone(this.m_releaseStatus);
            clone.m_references = (UAReferenceCollection)Utils.Clone(this.m_references);
            clone.m_extensions = (KeyValuePairCollection)Utils.Clone(this.m_extensions);

            return clone;
        }
        #endregion

        #region Private Fields
        private NodeId m_nodeId;
        private QualifiedName m_browseName;
        private string m_symbolicName;
        private LocalizedTextCollection m_displayNames;
        private LocalizedTextCollection m_descriptions;
        private string m_documentation;
        private uint m_writeMask;
        private RolePermissionTypeCollection m_rolePermissions;
        private ushort m_accessRestrictions;
        private ReleaseStatus m_releaseStatus;
        private UAReferenceCollection m_references;
        private KeyValuePairCollection m_extensions;
        #endregion
    }

    #region UABaseNodeCollection Class
    /// <summary>
    /// A collection of UABaseNode objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfUABaseNode", Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd, ItemName = "UABaseNode")]
    #if !NET_STANDARD
    public partial class UABaseNodeCollection : List<UABaseNode>, ICloneable
    #else
    public partial class UABaseNodeCollection : List<UABaseNode>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public UABaseNodeCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public UABaseNodeCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public UABaseNodeCollection(IEnumerable<UABaseNode> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator UABaseNodeCollection(UABaseNode[] values)
        {
            if (values != null)
            {
                return new UABaseNodeCollection(values);
            }

            return new UABaseNodeCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator UABaseNode[](UABaseNodeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #if !NET_STANDARD
        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            return (UABaseNodeCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UABaseNodeCollection clone = new UABaseNodeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((UABaseNode)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region NamedTranslationType Class
    #if (!OPCUA_EXCLUDE_NamedTranslationType)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd)]
    public partial class NamedTranslationType : IEncodeable
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public NamedTranslationType()
        {
            Initialize();
        }

        /// <summary>
        /// Called by the .NET framework during deserialization.
        /// </summary>
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_name = null;
            m_texts = new LocalizedTextCollection();
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "Name", IsRequired = false, Order = 1)]
        public string Name
        {
            get { return m_name;  }
            set { m_name = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Texts", IsRequired = false, Order = 2)]
        public LocalizedTextCollection Texts
        {
            get
            {
                return m_texts;
            }

            set
            {
                m_texts = value;

                if (value == null)
                {
                    m_texts = new LocalizedTextCollection();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId
        {
            get { return DataTypeIds.NamedTranslationType; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.NamedTranslationType_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.NamedTranslationType_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            encoder.WriteString("Name", Name);
            encoder.WriteLocalizedTextArray("Texts", Texts);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            Name = decoder.ReadString("Name");
            Texts = decoder.ReadLocalizedTextArray("Texts");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            NamedTranslationType value = encodeable as NamedTranslationType;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_name, value.m_name)) return false;
            if (!Utils.IsEqual(m_texts, value.m_texts)) return false;

            return true;
        }

        #if !NET_STANDARD
        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (NamedTranslationType)this.MemberwiseClone();
        }
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            NamedTranslationType clone = (NamedTranslationType)base.MemberwiseClone();

            clone.m_name = (string)Utils.Clone(this.m_name);
            clone.m_texts = (LocalizedTextCollection)Utils.Clone(this.m_texts);

            return clone;
        }
        #endregion

        #region Private Fields
        private string m_name;
        private LocalizedTextCollection m_texts;
        #endregion
    }

    #region NamedTranslationTypeCollection Class
    /// <summary>
    /// A collection of NamedTranslationType objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfNamedTranslationType", Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd, ItemName = "NamedTranslationType")]
    #if !NET_STANDARD
    public partial class NamedTranslationTypeCollection : List<NamedTranslationType>, ICloneable
    #else
    public partial class NamedTranslationTypeCollection : List<NamedTranslationType>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public NamedTranslationTypeCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public NamedTranslationTypeCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public NamedTranslationTypeCollection(IEnumerable<NamedTranslationType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator NamedTranslationTypeCollection(NamedTranslationType[] values)
        {
            if (values != null)
            {
                return new NamedTranslationTypeCollection(values);
            }

            return new NamedTranslationTypeCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator NamedTranslationType[](NamedTranslationTypeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #if !NET_STANDARD
        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            return (NamedTranslationTypeCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            NamedTranslationTypeCollection clone = new NamedTranslationTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((NamedTranslationType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region UAInstance Class
    #if (!OPCUA_EXCLUDE_UAInstance)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd)]
    public partial class UAInstance : UABaseNode
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public UAInstance()
        {
            Initialize();
        }

        /// <summary>
        /// Called by the .NET framework during deserialization.
        /// </summary>
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_parentNodeId = null;
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "ParentNodeId", IsRequired = false, Order = 1)]
        public NodeId ParentNodeId
        {
            get { return m_parentNodeId;  }
            set { m_parentNodeId = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public override ExpandedNodeId TypeId
        {
            get { return DataTypeIds.UAInstance; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.UAInstance_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public override ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.UAInstance_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            encoder.WriteNodeId("ParentNodeId", ParentNodeId);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            ParentNodeId = decoder.ReadNodeId("ParentNodeId");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            UAInstance value = encodeable as UAInstance;

            if (value == null)
            {
                return false;
            }

            if (!base.IsEqual(encodeable)) return false;
            if (!Utils.IsEqual(m_parentNodeId, value.m_parentNodeId)) return false;

            return true;
        }    

        #if !NET_STANDARD
        /// <summary cref="ICloneable.Clone" />
        public override object Clone()
        {
            return (UAInstance)this.MemberwiseClone();
        }
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UAInstance clone = (UAInstance)base.MemberwiseClone();

            clone.m_parentNodeId = (NodeId)Utils.Clone(this.m_parentNodeId);

            return clone;
        }
        #endregion

        #region Private Fields
        private NodeId m_parentNodeId;
        #endregion
    }

    #region UAInstanceCollection Class
    /// <summary>
    /// A collection of UAInstance objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfUAInstance", Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd, ItemName = "UAInstance")]
    #if !NET_STANDARD
    public partial class UAInstanceCollection : List<UAInstance>, ICloneable
    #else
    public partial class UAInstanceCollection : List<UAInstance>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public UAInstanceCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public UAInstanceCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public UAInstanceCollection(IEnumerable<UAInstance> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator UAInstanceCollection(UAInstance[] values)
        {
            if (values != null)
            {
                return new UAInstanceCollection(values);
            }

            return new UAInstanceCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator UAInstance[](UAInstanceCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #if !NET_STANDARD
        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            return (UAInstanceCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UAInstanceCollection clone = new UAInstanceCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((UAInstance)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region UAObject Class
    #if (!OPCUA_EXCLUDE_UAObject)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd)]
    public partial class UAObject : UAInstance
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public UAObject()
        {
            Initialize();
        }

        /// <summary>
        /// Called by the .NET framework during deserialization.
        /// </summary>
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_eventNotifier = 0;
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "EventNotifier", IsRequired = false, Order = 1)]
        public byte EventNotifier
        {
            get { return m_eventNotifier;  }
            set { m_eventNotifier = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public override ExpandedNodeId TypeId
        {
            get { return DataTypeIds.UAObject; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.UAObject_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public override ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.UAObject_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            encoder.WriteByte("EventNotifier", EventNotifier);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            EventNotifier = decoder.ReadByte("EventNotifier");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            UAObject value = encodeable as UAObject;

            if (value == null)
            {
                return false;
            }

            if (!base.IsEqual(encodeable)) return false;
            if (!Utils.IsEqual(m_eventNotifier, value.m_eventNotifier)) return false;

            return true;
        }    

        #if !NET_STANDARD
        /// <summary cref="ICloneable.Clone" />
        public override object Clone()
        {
            return (UAObject)this.MemberwiseClone();
        }
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UAObject clone = (UAObject)base.MemberwiseClone();

            clone.m_eventNotifier = (byte)Utils.Clone(this.m_eventNotifier);

            return clone;
        }
        #endregion

        #region Private Fields
        private byte m_eventNotifier;
        #endregion
    }

    #region UAObjectCollection Class
    /// <summary>
    /// A collection of UAObject objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfUAObject", Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd, ItemName = "UAObject")]
    #if !NET_STANDARD
    public partial class UAObjectCollection : List<UAObject>, ICloneable
    #else
    public partial class UAObjectCollection : List<UAObject>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public UAObjectCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public UAObjectCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public UAObjectCollection(IEnumerable<UAObject> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator UAObjectCollection(UAObject[] values)
        {
            if (values != null)
            {
                return new UAObjectCollection(values);
            }

            return new UAObjectCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator UAObject[](UAObjectCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #if !NET_STANDARD
        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            return (UAObjectCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UAObjectCollection clone = new UAObjectCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((UAObject)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region UAVariable Class
    #if (!OPCUA_EXCLUDE_UAVariable)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd)]
    public partial class UAVariable : UAInstance
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public UAVariable()
        {
            Initialize();
        }

        /// <summary>
        /// Called by the .NET framework during deserialization.
        /// </summary>
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_value = Variant.Null;
            m_dataType = null;
            m_valueRank = (int)0;
            m_arrayDimensions = new UInt32Collection();
            m_accessLevel = 0;
            m_minimumSamplingInterval = (double)0;
            m_historizing = true;
            m_translations = new NamedTranslationTypeCollection();
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "Value", IsRequired = false, Order = 1)]
        public Variant Value
        {
            get { return m_value;  }
            set { m_value = value; }
        }

        /// <remarks />
        [DataMember(Name = "DataType", IsRequired = false, Order = 2)]
        public NodeId DataType
        {
            get { return m_dataType;  }
            set { m_dataType = value; }
        }

        /// <remarks />
        [DataMember(Name = "ValueRank", IsRequired = false, Order = 3)]
        public int ValueRank
        {
            get { return m_valueRank;  }
            set { m_valueRank = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "ArrayDimensions", IsRequired = false, Order = 4)]
        public UInt32Collection ArrayDimensions
        {
            get
            {
                return m_arrayDimensions;
            }

            set
            {
                m_arrayDimensions = value;

                if (value == null)
                {
                    m_arrayDimensions = new UInt32Collection();
                }
            }
        }

        /// <remarks />
        [DataMember(Name = "AccessLevel", IsRequired = false, Order = 5)]
        public uint AccessLevel
        {
            get { return m_accessLevel;  }
            set { m_accessLevel = value; }
        }

        /// <remarks />
        [DataMember(Name = "MinimumSamplingInterval", IsRequired = false, Order = 6)]
        public double MinimumSamplingInterval
        {
            get { return m_minimumSamplingInterval;  }
            set { m_minimumSamplingInterval = value; }
        }

        /// <remarks />
        [DataMember(Name = "Historizing", IsRequired = false, Order = 7)]
        public bool Historizing
        {
            get { return m_historizing;  }
            set { m_historizing = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Translations", IsRequired = false, Order = 8)]
        public NamedTranslationTypeCollection Translations
        {
            get
            {
                return m_translations;
            }

            set
            {
                m_translations = value;

                if (value == null)
                {
                    m_translations = new NamedTranslationTypeCollection();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public override ExpandedNodeId TypeId
        {
            get { return DataTypeIds.UAVariable; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.UAVariable_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public override ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.UAVariable_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            encoder.WriteVariant("Value", Value);
            encoder.WriteNodeId("DataType", DataType);
            encoder.WriteInt32("ValueRank", ValueRank);
            encoder.WriteUInt32Array("ArrayDimensions", ArrayDimensions);
            encoder.WriteUInt32("AccessLevel", AccessLevel);
            encoder.WriteDouble("MinimumSamplingInterval", MinimumSamplingInterval);
            encoder.WriteBoolean("Historizing", Historizing);
            encoder.WriteEncodeableArray("Translations", Translations.ToArray(), typeof(NamedTranslationType));

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            Value = decoder.ReadVariant("Value");
            DataType = decoder.ReadNodeId("DataType");
            ValueRank = decoder.ReadInt32("ValueRank");
            ArrayDimensions = decoder.ReadUInt32Array("ArrayDimensions");
            AccessLevel = decoder.ReadUInt32("AccessLevel");
            MinimumSamplingInterval = decoder.ReadDouble("MinimumSamplingInterval");
            Historizing = decoder.ReadBoolean("Historizing");
            Translations = (NamedTranslationTypeCollection)decoder.ReadEncodeableArray("Translations", typeof(NamedTranslationType));

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            UAVariable value = encodeable as UAVariable;

            if (value == null)
            {
                return false;
            }

            if (!base.IsEqual(encodeable)) return false;
            if (!Utils.IsEqual(m_value, value.m_value)) return false;
            if (!Utils.IsEqual(m_dataType, value.m_dataType)) return false;
            if (!Utils.IsEqual(m_valueRank, value.m_valueRank)) return false;
            if (!Utils.IsEqual(m_arrayDimensions, value.m_arrayDimensions)) return false;
            if (!Utils.IsEqual(m_accessLevel, value.m_accessLevel)) return false;
            if (!Utils.IsEqual(m_minimumSamplingInterval, value.m_minimumSamplingInterval)) return false;
            if (!Utils.IsEqual(m_historizing, value.m_historizing)) return false;
            if (!Utils.IsEqual(m_translations, value.m_translations)) return false;

            return true;
        }    

        #if !NET_STANDARD
        /// <summary cref="ICloneable.Clone" />
        public override object Clone()
        {
            return (UAVariable)this.MemberwiseClone();
        }
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UAVariable clone = (UAVariable)base.MemberwiseClone();

            clone.m_value = (Variant)Utils.Clone(this.m_value);
            clone.m_dataType = (NodeId)Utils.Clone(this.m_dataType);
            clone.m_valueRank = (int)Utils.Clone(this.m_valueRank);
            clone.m_arrayDimensions = (UInt32Collection)Utils.Clone(this.m_arrayDimensions);
            clone.m_accessLevel = (uint)Utils.Clone(this.m_accessLevel);
            clone.m_minimumSamplingInterval = (double)Utils.Clone(this.m_minimumSamplingInterval);
            clone.m_historizing = (bool)Utils.Clone(this.m_historizing);
            clone.m_translations = (NamedTranslationTypeCollection)Utils.Clone(this.m_translations);

            return clone;
        }
        #endregion

        #region Private Fields
        private Variant m_value;
        private NodeId m_dataType;
        private int m_valueRank;
        private UInt32Collection m_arrayDimensions;
        private uint m_accessLevel;
        private double m_minimumSamplingInterval;
        private bool m_historizing;
        private NamedTranslationTypeCollection m_translations;
        #endregion
    }

    #region UAVariableCollection Class
    /// <summary>
    /// A collection of UAVariable objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfUAVariable", Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd, ItemName = "UAVariable")]
    #if !NET_STANDARD
    public partial class UAVariableCollection : List<UAVariable>, ICloneable
    #else
    public partial class UAVariableCollection : List<UAVariable>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public UAVariableCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public UAVariableCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public UAVariableCollection(IEnumerable<UAVariable> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator UAVariableCollection(UAVariable[] values)
        {
            if (values != null)
            {
                return new UAVariableCollection(values);
            }

            return new UAVariableCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator UAVariable[](UAVariableCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #if !NET_STANDARD
        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            return (UAVariableCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UAVariableCollection clone = new UAVariableCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((UAVariable)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region UAMethod Class
    #if (!OPCUA_EXCLUDE_UAMethod)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd)]
    public partial class UAMethod : UAInstance
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public UAMethod()
        {
            Initialize();
        }

        /// <summary>
        /// Called by the .NET framework during deserialization.
        /// </summary>
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_methodDeclarationId = null;
            m_executable = 0;
            m_translations = new NamedTranslationTypeCollection();
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "MethodDeclarationId", IsRequired = false, Order = 1)]
        public NodeId MethodDeclarationId
        {
            get { return m_methodDeclarationId;  }
            set { m_methodDeclarationId = value; }
        }

        /// <remarks />
        [DataMember(Name = "Executable", IsRequired = false, Order = 2)]
        public byte Executable
        {
            get { return m_executable;  }
            set { m_executable = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Translations", IsRequired = false, Order = 3)]
        public NamedTranslationTypeCollection Translations
        {
            get
            {
                return m_translations;
            }

            set
            {
                m_translations = value;

                if (value == null)
                {
                    m_translations = new NamedTranslationTypeCollection();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public override ExpandedNodeId TypeId
        {
            get { return DataTypeIds.UAMethod; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.UAMethod_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public override ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.UAMethod_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            encoder.WriteNodeId("MethodDeclarationId", MethodDeclarationId);
            encoder.WriteByte("Executable", Executable);
            encoder.WriteEncodeableArray("Translations", Translations.ToArray(), typeof(NamedTranslationType));

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            MethodDeclarationId = decoder.ReadNodeId("MethodDeclarationId");
            Executable = decoder.ReadByte("Executable");
            Translations = (NamedTranslationTypeCollection)decoder.ReadEncodeableArray("Translations", typeof(NamedTranslationType));

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            UAMethod value = encodeable as UAMethod;

            if (value == null)
            {
                return false;
            }

            if (!base.IsEqual(encodeable)) return false;
            if (!Utils.IsEqual(m_methodDeclarationId, value.m_methodDeclarationId)) return false;
            if (!Utils.IsEqual(m_executable, value.m_executable)) return false;
            if (!Utils.IsEqual(m_translations, value.m_translations)) return false;

            return true;
        }    

        #if !NET_STANDARD
        /// <summary cref="ICloneable.Clone" />
        public override object Clone()
        {
            return (UAMethod)this.MemberwiseClone();
        }
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UAMethod clone = (UAMethod)base.MemberwiseClone();

            clone.m_methodDeclarationId = (NodeId)Utils.Clone(this.m_methodDeclarationId);
            clone.m_executable = (byte)Utils.Clone(this.m_executable);
            clone.m_translations = (NamedTranslationTypeCollection)Utils.Clone(this.m_translations);

            return clone;
        }
        #endregion

        #region Private Fields
        private NodeId m_methodDeclarationId;
        private byte m_executable;
        private NamedTranslationTypeCollection m_translations;
        #endregion
    }

    #region UAMethodCollection Class
    /// <summary>
    /// A collection of UAMethod objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfUAMethod", Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd, ItemName = "UAMethod")]
    #if !NET_STANDARD
    public partial class UAMethodCollection : List<UAMethod>, ICloneable
    #else
    public partial class UAMethodCollection : List<UAMethod>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public UAMethodCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public UAMethodCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public UAMethodCollection(IEnumerable<UAMethod> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator UAMethodCollection(UAMethod[] values)
        {
            if (values != null)
            {
                return new UAMethodCollection(values);
            }

            return new UAMethodCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator UAMethod[](UAMethodCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #if !NET_STANDARD
        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            return (UAMethodCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UAMethodCollection clone = new UAMethodCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((UAMethod)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region UAView Class
    #if (!OPCUA_EXCLUDE_UAView)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd)]
    public partial class UAView : UAInstance
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public UAView()
        {
            Initialize();
        }

        /// <summary>
        /// Called by the .NET framework during deserialization.
        /// </summary>
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_eventNotifier = 0;
            m_containsNoLoops = true;
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "EventNotifier", IsRequired = false, Order = 1)]
        public byte EventNotifier
        {
            get { return m_eventNotifier;  }
            set { m_eventNotifier = value; }
        }

        /// <remarks />
        [DataMember(Name = "ContainsNoLoops", IsRequired = false, Order = 2)]
        public bool ContainsNoLoops
        {
            get { return m_containsNoLoops;  }
            set { m_containsNoLoops = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public override ExpandedNodeId TypeId
        {
            get { return DataTypeIds.UAView; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.UAView_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public override ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.UAView_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            encoder.WriteByte("EventNotifier", EventNotifier);
            encoder.WriteBoolean("ContainsNoLoops", ContainsNoLoops);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            EventNotifier = decoder.ReadByte("EventNotifier");
            ContainsNoLoops = decoder.ReadBoolean("ContainsNoLoops");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            UAView value = encodeable as UAView;

            if (value == null)
            {
                return false;
            }

            if (!base.IsEqual(encodeable)) return false;
            if (!Utils.IsEqual(m_eventNotifier, value.m_eventNotifier)) return false;
            if (!Utils.IsEqual(m_containsNoLoops, value.m_containsNoLoops)) return false;

            return true;
        }    

        #if !NET_STANDARD
        /// <summary cref="ICloneable.Clone" />
        public override object Clone()
        {
            return (UAView)this.MemberwiseClone();
        }
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UAView clone = (UAView)base.MemberwiseClone();

            clone.m_eventNotifier = (byte)Utils.Clone(this.m_eventNotifier);
            clone.m_containsNoLoops = (bool)Utils.Clone(this.m_containsNoLoops);

            return clone;
        }
        #endregion

        #region Private Fields
        private byte m_eventNotifier;
        private bool m_containsNoLoops;
        #endregion
    }

    #region UAViewCollection Class
    /// <summary>
    /// A collection of UAView objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfUAView", Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd, ItemName = "UAView")]
    #if !NET_STANDARD
    public partial class UAViewCollection : List<UAView>, ICloneable
    #else
    public partial class UAViewCollection : List<UAView>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public UAViewCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public UAViewCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public UAViewCollection(IEnumerable<UAView> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator UAViewCollection(UAView[] values)
        {
            if (values != null)
            {
                return new UAViewCollection(values);
            }

            return new UAViewCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator UAView[](UAViewCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #if !NET_STANDARD
        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            return (UAViewCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UAViewCollection clone = new UAViewCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((UAView)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region UABaseType Class
    #if (!OPCUA_EXCLUDE_UABaseType)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd)]
    public partial class UABaseType : UABaseNode
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public UABaseType()
        {
            Initialize();
        }

        /// <summary>
        /// Called by the .NET framework during deserialization.
        /// </summary>
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_isAbstract = true;
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "IsAbstract", IsRequired = false, Order = 1)]
        public bool IsAbstract
        {
            get { return m_isAbstract;  }
            set { m_isAbstract = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public override ExpandedNodeId TypeId
        {
            get { return DataTypeIds.UABaseType; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.UABaseType_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public override ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.UABaseType_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            encoder.WriteBoolean("IsAbstract", IsAbstract);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            IsAbstract = decoder.ReadBoolean("IsAbstract");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            UABaseType value = encodeable as UABaseType;

            if (value == null)
            {
                return false;
            }

            if (!base.IsEqual(encodeable)) return false;
            if (!Utils.IsEqual(m_isAbstract, value.m_isAbstract)) return false;

            return true;
        }    

        #if !NET_STANDARD
        /// <summary cref="ICloneable.Clone" />
        public override object Clone()
        {
            return (UABaseType)this.MemberwiseClone();
        }
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UABaseType clone = (UABaseType)base.MemberwiseClone();

            clone.m_isAbstract = (bool)Utils.Clone(this.m_isAbstract);

            return clone;
        }
        #endregion

        #region Private Fields
        private bool m_isAbstract;
        #endregion
    }

    #region UABaseTypeCollection Class
    /// <summary>
    /// A collection of UABaseType objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfUABaseType", Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd, ItemName = "UABaseType")]
    #if !NET_STANDARD
    public partial class UABaseTypeCollection : List<UABaseType>, ICloneable
    #else
    public partial class UABaseTypeCollection : List<UABaseType>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public UABaseTypeCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public UABaseTypeCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public UABaseTypeCollection(IEnumerable<UABaseType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator UABaseTypeCollection(UABaseType[] values)
        {
            if (values != null)
            {
                return new UABaseTypeCollection(values);
            }

            return new UABaseTypeCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator UABaseType[](UABaseTypeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #if !NET_STANDARD
        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            return (UABaseTypeCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UABaseTypeCollection clone = new UABaseTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((UABaseType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region UAObjectType Class
    #if (!OPCUA_EXCLUDE_UAObjectType)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd)]
    public partial class UAObjectType : UABaseType
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public UAObjectType()
        {
            Initialize();
        }

        /// <summary>
        /// Called by the .NET framework during deserialization.
        /// </summary>
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
        }
        #endregion

        #region Public Properties
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public override ExpandedNodeId TypeId
        {
            get { return DataTypeIds.UAObjectType; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.UAObjectType_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public override ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.UAObjectType_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);


            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);


            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            UAObjectType value = encodeable as UAObjectType;

            if (value == null)
            {
                return false;
            }


            return true;
        }    

        #if !NET_STANDARD
        /// <summary cref="ICloneable.Clone" />
        public override object Clone()
        {
            return (UAObjectType)this.MemberwiseClone();
        }
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UAObjectType clone = (UAObjectType)base.MemberwiseClone();


            return clone;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    #region UAObjectTypeCollection Class
    /// <summary>
    /// A collection of UAObjectType objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfUAObjectType", Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd, ItemName = "UAObjectType")]
    #if !NET_STANDARD
    public partial class UAObjectTypeCollection : List<UAObjectType>, ICloneable
    #else
    public partial class UAObjectTypeCollection : List<UAObjectType>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public UAObjectTypeCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public UAObjectTypeCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public UAObjectTypeCollection(IEnumerable<UAObjectType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator UAObjectTypeCollection(UAObjectType[] values)
        {
            if (values != null)
            {
                return new UAObjectTypeCollection(values);
            }

            return new UAObjectTypeCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator UAObjectType[](UAObjectTypeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #if !NET_STANDARD
        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            return (UAObjectTypeCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UAObjectTypeCollection clone = new UAObjectTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((UAObjectType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region UAVariableType Class
    #if (!OPCUA_EXCLUDE_UAVariableType)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd)]
    public partial class UAVariableType : UABaseType
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public UAVariableType()
        {
            Initialize();
        }

        /// <summary>
        /// Called by the .NET framework during deserialization.
        /// </summary>
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_value = Variant.Null;
            m_dataType = null;
            m_valueRank = (int)0;
            m_arrayDimensions = new UInt32Collection();
            m_translations = new NamedTranslationTypeCollection();
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "Value", IsRequired = false, Order = 1)]
        public Variant Value
        {
            get { return m_value;  }
            set { m_value = value; }
        }

        /// <remarks />
        [DataMember(Name = "DataType", IsRequired = false, Order = 2)]
        public NodeId DataType
        {
            get { return m_dataType;  }
            set { m_dataType = value; }
        }

        /// <remarks />
        [DataMember(Name = "ValueRank", IsRequired = false, Order = 3)]
        public int ValueRank
        {
            get { return m_valueRank;  }
            set { m_valueRank = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "ArrayDimensions", IsRequired = false, Order = 4)]
        public UInt32Collection ArrayDimensions
        {
            get
            {
                return m_arrayDimensions;
            }

            set
            {
                m_arrayDimensions = value;

                if (value == null)
                {
                    m_arrayDimensions = new UInt32Collection();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Translations", IsRequired = false, Order = 5)]
        public NamedTranslationTypeCollection Translations
        {
            get
            {
                return m_translations;
            }

            set
            {
                m_translations = value;

                if (value == null)
                {
                    m_translations = new NamedTranslationTypeCollection();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public override ExpandedNodeId TypeId
        {
            get { return DataTypeIds.UAVariableType; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.UAVariableType_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public override ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.UAVariableType_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            encoder.WriteVariant("Value", Value);
            encoder.WriteNodeId("DataType", DataType);
            encoder.WriteInt32("ValueRank", ValueRank);
            encoder.WriteUInt32Array("ArrayDimensions", ArrayDimensions);
            encoder.WriteEncodeableArray("Translations", Translations.ToArray(), typeof(NamedTranslationType));

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            Value = decoder.ReadVariant("Value");
            DataType = decoder.ReadNodeId("DataType");
            ValueRank = decoder.ReadInt32("ValueRank");
            ArrayDimensions = decoder.ReadUInt32Array("ArrayDimensions");
            Translations = (NamedTranslationTypeCollection)decoder.ReadEncodeableArray("Translations", typeof(NamedTranslationType));

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            UAVariableType value = encodeable as UAVariableType;

            if (value == null)
            {
                return false;
            }

            if (!base.IsEqual(encodeable)) return false;
            if (!Utils.IsEqual(m_value, value.m_value)) return false;
            if (!Utils.IsEqual(m_dataType, value.m_dataType)) return false;
            if (!Utils.IsEqual(m_valueRank, value.m_valueRank)) return false;
            if (!Utils.IsEqual(m_arrayDimensions, value.m_arrayDimensions)) return false;
            if (!Utils.IsEqual(m_translations, value.m_translations)) return false;

            return true;
        }    

        #if !NET_STANDARD
        /// <summary cref="ICloneable.Clone" />
        public override object Clone()
        {
            return (UAVariableType)this.MemberwiseClone();
        }
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UAVariableType clone = (UAVariableType)base.MemberwiseClone();

            clone.m_value = (Variant)Utils.Clone(this.m_value);
            clone.m_dataType = (NodeId)Utils.Clone(this.m_dataType);
            clone.m_valueRank = (int)Utils.Clone(this.m_valueRank);
            clone.m_arrayDimensions = (UInt32Collection)Utils.Clone(this.m_arrayDimensions);
            clone.m_translations = (NamedTranslationTypeCollection)Utils.Clone(this.m_translations);

            return clone;
        }
        #endregion

        #region Private Fields
        private Variant m_value;
        private NodeId m_dataType;
        private int m_valueRank;
        private UInt32Collection m_arrayDimensions;
        private NamedTranslationTypeCollection m_translations;
        #endregion
    }

    #region UAVariableTypeCollection Class
    /// <summary>
    /// A collection of UAVariableType objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfUAVariableType", Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd, ItemName = "UAVariableType")]
    #if !NET_STANDARD
    public partial class UAVariableTypeCollection : List<UAVariableType>, ICloneable
    #else
    public partial class UAVariableTypeCollection : List<UAVariableType>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public UAVariableTypeCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public UAVariableTypeCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public UAVariableTypeCollection(IEnumerable<UAVariableType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator UAVariableTypeCollection(UAVariableType[] values)
        {
            if (values != null)
            {
                return new UAVariableTypeCollection(values);
            }

            return new UAVariableTypeCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator UAVariableType[](UAVariableTypeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #if !NET_STANDARD
        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            return (UAVariableTypeCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UAVariableTypeCollection clone = new UAVariableTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((UAVariableType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region UADataType Class
    #if (!OPCUA_EXCLUDE_UADataType)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd)]
    public partial class UADataType : UABaseType
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public UADataType()
        {
            Initialize();
        }

        /// <summary>
        /// Called by the .NET framework during deserialization.
        /// </summary>
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_definition = null;
            m_translations = new NamedTranslationTypeCollection();
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "Definition", IsRequired = false, Order = 1)]
        public ExtensionObject Definition
        {
            get { return m_definition;  }
            set { m_definition = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Translations", IsRequired = false, Order = 2)]
        public NamedTranslationTypeCollection Translations
        {
            get
            {
                return m_translations;
            }

            set
            {
                m_translations = value;

                if (value == null)
                {
                    m_translations = new NamedTranslationTypeCollection();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public override ExpandedNodeId TypeId
        {
            get { return DataTypeIds.UADataType; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.UADataType_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public override ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.UADataType_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            encoder.WriteExtensionObject("Definition", Definition);
            encoder.WriteEncodeableArray("Translations", Translations.ToArray(), typeof(NamedTranslationType));

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            Definition = decoder.ReadExtensionObject("Definition");
            Translations = (NamedTranslationTypeCollection)decoder.ReadEncodeableArray("Translations", typeof(NamedTranslationType));

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            UADataType value = encodeable as UADataType;

            if (value == null)
            {
                return false;
            }

            if (!base.IsEqual(encodeable)) return false;
            if (!Utils.IsEqual(m_definition, value.m_definition)) return false;
            if (!Utils.IsEqual(m_translations, value.m_translations)) return false;

            return true;
        }    

        #if !NET_STANDARD
        /// <summary cref="ICloneable.Clone" />
        public override object Clone()
        {
            return (UADataType)this.MemberwiseClone();
        }
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UADataType clone = (UADataType)base.MemberwiseClone();

            clone.m_definition = (ExtensionObject)Utils.Clone(this.m_definition);
            clone.m_translations = (NamedTranslationTypeCollection)Utils.Clone(this.m_translations);

            return clone;
        }
        #endregion

        #region Private Fields
        private ExtensionObject m_definition;
        private NamedTranslationTypeCollection m_translations;
        #endregion
    }

    #region UADataTypeCollection Class
    /// <summary>
    /// A collection of UADataType objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfUADataType", Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd, ItemName = "UADataType")]
    #if !NET_STANDARD
    public partial class UADataTypeCollection : List<UADataType>, ICloneable
    #else
    public partial class UADataTypeCollection : List<UADataType>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public UADataTypeCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public UADataTypeCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public UADataTypeCollection(IEnumerable<UADataType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator UADataTypeCollection(UADataType[] values)
        {
            if (values != null)
            {
                return new UADataTypeCollection(values);
            }

            return new UADataTypeCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator UADataType[](UADataTypeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #if !NET_STANDARD
        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            return (UADataTypeCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UADataTypeCollection clone = new UADataTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((UADataType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region UAReferenceType Class
    #if (!OPCUA_EXCLUDE_UAReferenceType)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd)]
    public partial class UAReferenceType : UABaseType
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public UAReferenceType()
        {
            Initialize();
        }

        /// <summary>
        /// Called by the .NET framework during deserialization.
        /// </summary>
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_symmetric = true;
            m_inverseNames = new LocalizedTextCollection();
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "Symmetric", IsRequired = false, Order = 1)]
        public bool Symmetric
        {
            get { return m_symmetric;  }
            set { m_symmetric = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "InverseNames", IsRequired = false, Order = 2)]
        public LocalizedTextCollection InverseNames
        {
            get
            {
                return m_inverseNames;
            }

            set
            {
                m_inverseNames = value;

                if (value == null)
                {
                    m_inverseNames = new LocalizedTextCollection();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public override ExpandedNodeId TypeId
        {
            get { return DataTypeIds.UAReferenceType; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.UAReferenceType_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public override ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.UAReferenceType_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            encoder.WriteBoolean("Symmetric", Symmetric);
            encoder.WriteLocalizedTextArray("InverseNames", InverseNames);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd);

            Symmetric = decoder.ReadBoolean("Symmetric");
            InverseNames = decoder.ReadLocalizedTextArray("InverseNames");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            UAReferenceType value = encodeable as UAReferenceType;

            if (value == null)
            {
                return false;
            }

            if (!base.IsEqual(encodeable)) return false;
            if (!Utils.IsEqual(m_symmetric, value.m_symmetric)) return false;
            if (!Utils.IsEqual(m_inverseNames, value.m_inverseNames)) return false;

            return true;
        }    

        #if !NET_STANDARD
        /// <summary cref="ICloneable.Clone" />
        public override object Clone()
        {
            return (UAReferenceType)this.MemberwiseClone();
        }
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UAReferenceType clone = (UAReferenceType)base.MemberwiseClone();

            clone.m_symmetric = (bool)Utils.Clone(this.m_symmetric);
            clone.m_inverseNames = (LocalizedTextCollection)Utils.Clone(this.m_inverseNames);

            return clone;
        }
        #endregion

        #region Private Fields
        private bool m_symmetric;
        private LocalizedTextCollection m_inverseNames;
        #endregion
    }

    #region UAReferenceTypeCollection Class
    /// <summary>
    /// A collection of UAReferenceType objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfUAReferenceType", Namespace = Opc.Ua.UANodeSet.Namespaces.OpcUANodeSetXsd, ItemName = "UAReferenceType")]
    #if !NET_STANDARD
    public partial class UAReferenceTypeCollection : List<UAReferenceType>, ICloneable
    #else
    public partial class UAReferenceTypeCollection : List<UAReferenceType>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public UAReferenceTypeCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public UAReferenceTypeCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public UAReferenceTypeCollection(IEnumerable<UAReferenceType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator UAReferenceTypeCollection(UAReferenceType[] values)
        {
            if (values != null)
            {
                return new UAReferenceTypeCollection(values);
            }

            return new UAReferenceTypeCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator UAReferenceType[](UAReferenceTypeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #if !NET_STANDARD
        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            return (UAReferenceTypeCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            UAReferenceTypeCollection clone = new UAReferenceTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((UAReferenceType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion
}
