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
using System.Text;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;

namespace DemoModel
{
    #region HeaterStatus Enumeration
    #if (!OPCUA_EXCLUDE_HeaterStatus)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = DemoModel.Namespaces.DemoModel)]
    public enum HeaterStatus
    {
        /// <remarks />
        [EnumMember(Value = "Off_0")]
        Off = 0,

        /// <remarks />
        [EnumMember(Value = "Heating_1")]
        Heating = 1,

        /// <remarks />
        [EnumMember(Value = "Cooling_2")]
        Cooling = 2,
    }

    #region HeaterStatusCollection Class
    /// <summary>
    /// A collection of HeaterStatus objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfHeaterStatus", Namespace = DemoModel.Namespaces.DemoModel, ItemName = "HeaterStatus")]
    #if !NET_STANDARD
    public partial class HeaterStatusCollection : List<HeaterStatus>, ICloneable
    #else
    public partial class HeaterStatusCollection : List<HeaterStatus>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public HeaterStatusCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public HeaterStatusCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public HeaterStatusCollection(IEnumerable<HeaterStatus> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator HeaterStatusCollection(HeaterStatus[] values)
        {
            if (values != null)
            {
                return new HeaterStatusCollection(values);
            }

            return new HeaterStatusCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator HeaterStatus[](HeaterStatusCollection values)
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
            return (HeaterStatusCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            HeaterStatusCollection clone = new HeaterStatusCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((HeaterStatus)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region Vector Class
    #if (!OPCUA_EXCLUDE_Vector)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = DemoModel.Namespaces.DemoModel)]
    public partial class Vector : IEncodeable
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public Vector()
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
            m_x = (double)0;
            m_y = (double)0;
            m_z = (double)0;
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "X", IsRequired = false, Order = 1)]
        public double X
        {
            get { return m_x;  }
            set { m_x = value; }
        }

        /// <remarks />
        [DataMember(Name = "Y", IsRequired = false, Order = 2)]
        public double Y
        {
            get { return m_y;  }
            set { m_y = value; }
        }

        /// <remarks />
        [DataMember(Name = "Z", IsRequired = false, Order = 3)]
        public double Z
        {
            get { return m_z;  }
            set { m_z = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId
        {
            get { return DataTypeIds.Vector; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.Vector_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.Vector_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(DemoModel.Namespaces.DemoModel);

            encoder.WriteDouble("X", X);
            encoder.WriteDouble("Y", Y);
            encoder.WriteDouble("Z", Z);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(DemoModel.Namespaces.DemoModel);

            X = decoder.ReadDouble("X");
            Y = decoder.ReadDouble("Y");
            Z = decoder.ReadDouble("Z");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            Vector value = encodeable as Vector;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_x, value.m_x)) return false;
            if (!Utils.IsEqual(m_y, value.m_y)) return false;
            if (!Utils.IsEqual(m_z, value.m_z)) return false;

            return true;
        }

        #if !NET_STANDARD
        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (Vector)this.MemberwiseClone();
        }
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            Vector clone = (Vector)base.MemberwiseClone();

            clone.m_x = (double)Utils.Clone(this.m_x);
            clone.m_y = (double)Utils.Clone(this.m_y);
            clone.m_z = (double)Utils.Clone(this.m_z);

            return clone;
        }
        #endregion

        #region Private Fields
        private double m_x;
        private double m_y;
        private double m_z;
        #endregion
    }

    #region VectorCollection Class
    /// <summary>
    /// A collection of Vector objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfVector", Namespace = DemoModel.Namespaces.DemoModel, ItemName = "Vector")]
    #if !NET_STANDARD
    public partial class VectorCollection : List<Vector>, ICloneable
    #else
    public partial class VectorCollection : List<Vector>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public VectorCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public VectorCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public VectorCollection(IEnumerable<Vector> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator VectorCollection(Vector[] values)
        {
            if (values != null)
            {
                return new VectorCollection(values);
            }

            return new VectorCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator Vector[](VectorCollection values)
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
            return (VectorCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            VectorCollection clone = new VectorCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((Vector)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region WorkOrderStatusType Class
    #if (!OPCUA_EXCLUDE_WorkOrderStatusType)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = DemoModel.Namespaces.DemoModel)]
    public partial class WorkOrderStatusType : IEncodeable
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public WorkOrderStatusType()
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
            m_actor = null;
            m_timestamp = DateTime.MinValue;
            m_comment = null;
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "Actor", IsRequired = false, Order = 1)]
        public string Actor
        {
            get { return m_actor;  }
            set { m_actor = value; }
        }

        /// <remarks />
        [DataMember(Name = "Timestamp", IsRequired = false, Order = 2)]
        public DateTime Timestamp
        {
            get { return m_timestamp;  }
            set { m_timestamp = value; }
        }

        /// <remarks />
        [DataMember(Name = "Comment", IsRequired = false, Order = 3)]
        public LocalizedText Comment
        {
            get { return m_comment;  }
            set { m_comment = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId
        {
            get { return DataTypeIds.WorkOrderStatusType; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.WorkOrderStatusType_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.WorkOrderStatusType_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(DemoModel.Namespaces.DemoModel);

            encoder.WriteString("Actor", Actor);
            encoder.WriteDateTime("Timestamp", Timestamp);
            encoder.WriteLocalizedText("Comment", Comment);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(DemoModel.Namespaces.DemoModel);

            Actor = decoder.ReadString("Actor");
            Timestamp = decoder.ReadDateTime("Timestamp");
            Comment = decoder.ReadLocalizedText("Comment");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            WorkOrderStatusType value = encodeable as WorkOrderStatusType;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_actor, value.m_actor)) return false;
            if (!Utils.IsEqual(m_timestamp, value.m_timestamp)) return false;
            if (!Utils.IsEqual(m_comment, value.m_comment)) return false;

            return true;
        }

        #if !NET_STANDARD
        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (WorkOrderStatusType)this.MemberwiseClone();
        }
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            WorkOrderStatusType clone = (WorkOrderStatusType)base.MemberwiseClone();

            clone.m_actor = (string)Utils.Clone(this.m_actor);
            clone.m_timestamp = (DateTime)Utils.Clone(this.m_timestamp);
            clone.m_comment = (LocalizedText)Utils.Clone(this.m_comment);

            return clone;
        }
        #endregion

        #region Private Fields
        private string m_actor;
        private DateTime m_timestamp;
        private LocalizedText m_comment;
        #endregion
    }

    #region WorkOrderStatusTypeCollection Class
    /// <summary>
    /// A collection of WorkOrderStatusType objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfWorkOrderStatusType", Namespace = DemoModel.Namespaces.DemoModel, ItemName = "WorkOrderStatusType")]
    #if !NET_STANDARD
    public partial class WorkOrderStatusTypeCollection : List<WorkOrderStatusType>, ICloneable
    #else
    public partial class WorkOrderStatusTypeCollection : List<WorkOrderStatusType>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public WorkOrderStatusTypeCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public WorkOrderStatusTypeCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public WorkOrderStatusTypeCollection(IEnumerable<WorkOrderStatusType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator WorkOrderStatusTypeCollection(WorkOrderStatusType[] values)
        {
            if (values != null)
            {
                return new WorkOrderStatusTypeCollection(values);
            }

            return new WorkOrderStatusTypeCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator WorkOrderStatusType[](WorkOrderStatusTypeCollection values)
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
            return (WorkOrderStatusTypeCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            WorkOrderStatusTypeCollection clone = new WorkOrderStatusTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((WorkOrderStatusType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region WorkOrderType Class
    #if (!OPCUA_EXCLUDE_WorkOrderType)
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = DemoModel.Namespaces.DemoModel)]
    public partial class WorkOrderType : IEncodeable
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public WorkOrderType()
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
            m_iD = Uuid.Empty;
            m_assetID = null;
            m_startTime = DateTime.MinValue;
            m_statusComments = new WorkOrderStatusTypeCollection();
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "ID", IsRequired = false, Order = 1)]
        public Uuid ID
        {
            get { return m_iD;  }
            set { m_iD = value; }
        }

        /// <remarks />
        [DataMember(Name = "AssetID", IsRequired = false, Order = 2)]
        public string AssetID
        {
            get { return m_assetID;  }
            set { m_assetID = value; }
        }

        /// <remarks />
        [DataMember(Name = "StartTime", IsRequired = false, Order = 3)]
        public DateTime StartTime
        {
            get { return m_startTime;  }
            set { m_startTime = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "StatusComments", IsRequired = false, Order = 4)]
        public WorkOrderStatusTypeCollection StatusComments
        {
            get
            {
                return m_statusComments;
            }

            set
            {
                m_statusComments = value;

                if (value == null)
                {
                    m_statusComments = new WorkOrderStatusTypeCollection();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId
        {
            get { return DataTypeIds.WorkOrderType; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.WorkOrderType_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.WorkOrderType_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(DemoModel.Namespaces.DemoModel);

            encoder.WriteGuid("ID", ID);
            encoder.WriteString("AssetID", AssetID);
            encoder.WriteDateTime("StartTime", StartTime);
            encoder.WriteEncodeableArray("StatusComments", StatusComments.ToArray(), typeof(WorkOrderStatusType));

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(DemoModel.Namespaces.DemoModel);

            ID = decoder.ReadGuid("ID");
            AssetID = decoder.ReadString("AssetID");
            StartTime = decoder.ReadDateTime("StartTime");
            StatusComments = (WorkOrderStatusTypeCollection)decoder.ReadEncodeableArray("StatusComments", typeof(WorkOrderStatusType));

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            WorkOrderType value = encodeable as WorkOrderType;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_iD, value.m_iD)) return false;
            if (!Utils.IsEqual(m_assetID, value.m_assetID)) return false;
            if (!Utils.IsEqual(m_startTime, value.m_startTime)) return false;
            if (!Utils.IsEqual(m_statusComments, value.m_statusComments)) return false;

            return true;
        }

        #if !NET_STANDARD
        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (WorkOrderType)this.MemberwiseClone();
        }
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            WorkOrderType clone = (WorkOrderType)base.MemberwiseClone();

            clone.m_iD = (Uuid)Utils.Clone(this.m_iD);
            clone.m_assetID = (string)Utils.Clone(this.m_assetID);
            clone.m_startTime = (DateTime)Utils.Clone(this.m_startTime);
            clone.m_statusComments = (WorkOrderStatusTypeCollection)Utils.Clone(this.m_statusComments);

            return clone;
        }
        #endregion

        #region Private Fields
        private Uuid m_iD;
        private string m_assetID;
        private DateTime m_startTime;
        private WorkOrderStatusTypeCollection m_statusComments;
        #endregion
    }

    #region WorkOrderTypeCollection Class
    /// <summary>
    /// A collection of WorkOrderType objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfWorkOrderType", Namespace = DemoModel.Namespaces.DemoModel, ItemName = "WorkOrderType")]
    #if !NET_STANDARD
    public partial class WorkOrderTypeCollection : List<WorkOrderType>, ICloneable
    #else
    public partial class WorkOrderTypeCollection : List<WorkOrderType>
    #endif
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public WorkOrderTypeCollection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public WorkOrderTypeCollection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public WorkOrderTypeCollection(IEnumerable<WorkOrderType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator WorkOrderTypeCollection(WorkOrderType[] values)
        {
            if (values != null)
            {
                return new WorkOrderTypeCollection(values);
            }

            return new WorkOrderTypeCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator WorkOrderType[](WorkOrderTypeCollection values)
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
            return (WorkOrderTypeCollection)this.MemberwiseClone();
        }
        #endregion
        #endif

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            WorkOrderTypeCollection clone = new WorkOrderTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((WorkOrderType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion
}
