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
using Opc.Ua;

namespace DemoModel
{
    #region EnumUnderscoreTest Enumeration
    #if (!OPCUA_EXCLUDE_EnumUnderscoreTest)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = DemoModel.Namespaces.DemoModelXsd)]
    public enum EnumUnderscoreTest
    {
        /// <remarks />
        [EnumMember(Value = "x_x_1")]
        x_x = 1,

        /// <remarks />
        [EnumMember(Value = "_x_2")]
        _x = 2,

        /// <remarks />
        [EnumMember(Value = "x__3")]
        x_ = 3,

        /// <remarks />
        [EnumMember(Value = "__4")]
        _ = 4,
    }

    #region EnumUnderscoreTestCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfEnumUnderscoreTest", Namespace = DemoModel.Namespaces.DemoModelXsd, ItemName = "EnumUnderscoreTest")]
    public partial class EnumUnderscoreTestCollection : List<EnumUnderscoreTest>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public EnumUnderscoreTestCollection() {}

        /// <remarks />
        public EnumUnderscoreTestCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public EnumUnderscoreTestCollection(IEnumerable<EnumUnderscoreTest> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator EnumUnderscoreTestCollection(EnumUnderscoreTest[] values)
        {
            if (values != null)
            {
                return new EnumUnderscoreTestCollection(values);
            }

            return new EnumUnderscoreTestCollection();
        }

        /// <remarks />
        public static explicit operator EnumUnderscoreTest[](EnumUnderscoreTestCollection values)
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
            return (EnumUnderscoreTestCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            EnumUnderscoreTestCollection clone = new EnumUnderscoreTestCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((EnumUnderscoreTest)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region HeaterStatus Enumeration
    #if (!OPCUA_EXCLUDE_HeaterStatus)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = DemoModel.Namespaces.DemoModelXsd)]
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
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfHeaterStatus", Namespace = DemoModel.Namespaces.DemoModelXsd, ItemName = "HeaterStatus")]
    public partial class HeaterStatusCollection : List<HeaterStatus>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public HeaterStatusCollection() {}

        /// <remarks />
        public HeaterStatusCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public HeaterStatusCollection(IEnumerable<HeaterStatus> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator HeaterStatusCollection(HeaterStatus[] values)
        {
            if (values != null)
            {
                return new HeaterStatusCollection(values);
            }

            return new HeaterStatusCollection();
        }

        /// <remarks />
        public static explicit operator HeaterStatus[](HeaterStatusCollection values)
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
            return (HeaterStatusCollection)this.MemberwiseClone();
        }
        #endregion

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
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = DemoModel.Namespaces.DemoModelXsd)]
    public partial class Vector : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public Vector()
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
        public virtual ExpandedNodeId TypeId => DataTypeIds.Vector; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.Vector_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.Vector_Encoding_DefaultXml;
                    
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.Vector_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(DemoModel.Namespaces.DemoModelXsd);

            encoder.WriteDouble("X", X);
            encoder.WriteDouble("Y", Y);
            encoder.WriteDouble("Z", Z);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(DemoModel.Namespaces.DemoModelXsd);

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

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (Vector)this.MemberwiseClone();
        }

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
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfVector", Namespace = DemoModel.Namespaces.DemoModelXsd, ItemName = "Vector")]
    public partial class VectorCollection : List<Vector>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public VectorCollection() {}

        /// <remarks />
        public VectorCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public VectorCollection(IEnumerable<Vector> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator VectorCollection(Vector[] values)
        {
            if (values != null)
            {
                return new VectorCollection(values);
            }

            return new VectorCollection();
        }

        /// <remarks />
        public static explicit operator Vector[](VectorCollection values)
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
            return (VectorCollection)this.MemberwiseClone();
        }
        #endregion

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
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = DemoModel.Namespaces.DemoModelXsd)]
    public partial class WorkOrderStatusType : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public WorkOrderStatusType()
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
        public virtual ExpandedNodeId TypeId => DataTypeIds.WorkOrderStatusType; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.WorkOrderStatusType_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.WorkOrderStatusType_Encoding_DefaultXml;
                    
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.WorkOrderStatusType_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(DemoModel.Namespaces.DemoModelXsd);

            encoder.WriteString("Actor", Actor);
            encoder.WriteDateTime("Timestamp", Timestamp);
            encoder.WriteLocalizedText("Comment", Comment);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(DemoModel.Namespaces.DemoModelXsd);

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

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (WorkOrderStatusType)this.MemberwiseClone();
        }

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
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfWorkOrderStatusType", Namespace = DemoModel.Namespaces.DemoModelXsd, ItemName = "WorkOrderStatusType")]
    public partial class WorkOrderStatusTypeCollection : List<WorkOrderStatusType>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public WorkOrderStatusTypeCollection() {}

        /// <remarks />
        public WorkOrderStatusTypeCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public WorkOrderStatusTypeCollection(IEnumerable<WorkOrderStatusType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator WorkOrderStatusTypeCollection(WorkOrderStatusType[] values)
        {
            if (values != null)
            {
                return new WorkOrderStatusTypeCollection(values);
            }

            return new WorkOrderStatusTypeCollection();
        }

        /// <remarks />
        public static explicit operator WorkOrderStatusType[](WorkOrderStatusTypeCollection values)
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
            return (WorkOrderStatusTypeCollection)this.MemberwiseClone();
        }
        #endregion

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
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = DemoModel.Namespaces.DemoModelXsd)]
    public partial class WorkOrderType : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public WorkOrderType()
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

        /// <remarks />
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
        public virtual ExpandedNodeId TypeId => DataTypeIds.WorkOrderType; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.WorkOrderType_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.WorkOrderType_Encoding_DefaultXml;
                    
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.WorkOrderType_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(DemoModel.Namespaces.DemoModelXsd);

            encoder.WriteGuid("ID", ID);
            encoder.WriteString("AssetID", AssetID);
            encoder.WriteDateTime("StartTime", StartTime);
            encoder.WriteEncodeableArray("StatusComments", StatusComments.ToArray(), typeof(WorkOrderStatusType));

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(DemoModel.Namespaces.DemoModelXsd);

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

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (WorkOrderType)this.MemberwiseClone();
        }

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
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfWorkOrderType", Namespace = DemoModel.Namespaces.DemoModelXsd, ItemName = "WorkOrderType")]
    public partial class WorkOrderTypeCollection : List<WorkOrderType>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public WorkOrderTypeCollection() {}

        /// <remarks />
        public WorkOrderTypeCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public WorkOrderTypeCollection(IEnumerable<WorkOrderType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator WorkOrderTypeCollection(WorkOrderType[] values)
        {
            if (values != null)
            {
                return new WorkOrderTypeCollection(values);
            }

            return new WorkOrderTypeCollection();
        }

        /// <remarks />
        public static explicit operator WorkOrderType[](WorkOrderTypeCollection values)
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
            return (WorkOrderTypeCollection)this.MemberwiseClone();
        }
        #endregion

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

    #region SampleUnion Class
    #if (!OPCUA_EXCLUDE_SampleUnion)
    /// <remarks />
    /// <exclude />
    public enum SampleUnionFields : uint
    {
        /// <remarks />
        None = 0,
        /// <remarks />
        FieldX = 1,
        /// <remarks />
        FieldY = 2,
        /// <remarks />
        FieldZ = 3
    }

    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = DemoModel.Namespaces.DemoModelXsd)]
    public partial class SampleUnion : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public SampleUnion()
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
            SwitchField = SampleUnionFields.None;
            m_fieldX = (uint)0;
            m_fieldY = new StringCollection();
            m_fieldZ = null;
        }
        #endregion

        #region Public Properties
        // <remarks />
        [DataMember(Name = "SwitchField", IsRequired = true, Order = 0)]
        public SampleUnionFields SwitchField { get; set; }

        /// <remarks />
        [DataMember(Name = "FieldX", IsRequired = false, Order = 1)]
        public uint FieldX
        {
            get { return m_fieldX;  }
            set { m_fieldX = value; }
        }

        /// <remarks />
        [DataMember(Name = "FieldY", IsRequired = false, Order = 2)]
        public StringCollection FieldY
        {
            get
            {
                return m_fieldY;
            }

            set
            {
                m_fieldY = value;

                if (value == null)
                {
                    m_fieldY = new StringCollection();
                }
            }
        }

        /// <remarks />
        [DataMember(Name = "FieldZ", IsRequired = false, Order = 3)]
        public byte[] FieldZ
        {
            get { return m_fieldZ;  }
            set { m_fieldZ = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId => DataTypeIds.SampleUnion; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.SampleUnion_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.SampleUnion_Encoding_DefaultXml;

        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.SampleUnion_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(DemoModel.Namespaces.DemoModelXsd);
            encoder.WriteUInt32(nameof(SwitchField), (uint)SwitchField);

            switch (SwitchField)
            {
                default: { break; }
                case SampleUnionFields.FieldX: { encoder.WriteUInt32("FieldX", FieldX); break; }
                case SampleUnionFields.FieldY: { encoder.WriteStringArray("FieldY", FieldY); break; }
                case SampleUnionFields.FieldZ: { encoder.WriteByteString("FieldZ", FieldZ); break; }
            }
            
            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(DemoModel.Namespaces.DemoModelXsd);

            SwitchField = (SampleUnionFields)decoder.ReadUInt32(nameof(SwitchField));
                
            switch (SwitchField)
            {
                default: { break; }
                case SampleUnionFields.FieldX: { FieldX = decoder.ReadUInt32("FieldX"); break; }
                case SampleUnionFields.FieldY: { FieldY = decoder.ReadStringArray("FieldY"); break; }
                case SampleUnionFields.FieldZ: { FieldZ = decoder.ReadByteString("FieldZ"); break; }
            }

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            SampleUnion value = encodeable as SampleUnion;

            if (value == null)
            {
                return false;
            }

            if (value.SwitchField != this.SwitchField) return false;

            switch (SwitchField)
            {
                default: { break; }
                case SampleUnionFields.FieldX: { if (!Utils.IsEqual(m_fieldX, value.m_fieldX)) return false; break; }
                case SampleUnionFields.FieldY: { if (!Utils.IsEqual(m_fieldY, value.m_fieldY)) return false; break; }
                case SampleUnionFields.FieldZ: { if (!Utils.IsEqual(m_fieldZ, value.m_fieldZ)) return false; break; }
            }

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (SampleUnion)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            SampleUnion clone = (SampleUnion)base.MemberwiseClone();

            clone.SwitchField = this.SwitchField;

            switch (SwitchField)
            {
                default: { break; }
                case SampleUnionFields.FieldX: { clone.m_fieldX = (uint)Utils.Clone(this.m_fieldX); break; }
                case SampleUnionFields.FieldY: { clone.m_fieldY = (StringCollection)Utils.Clone(this.m_fieldY); break; }
                case SampleUnionFields.FieldZ: { clone.m_fieldZ = (byte[])Utils.Clone(this.m_fieldZ); break; }
            }

            return clone;
        }
        #endregion

        #region Private Fields
        private uint m_fieldX;
        private StringCollection m_fieldY;
        private byte[] m_fieldZ;
        #endregion
    }

    #region SampleUnionCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfSampleUnion", Namespace = DemoModel.Namespaces.DemoModelXsd, ItemName = "SampleUnion")]
    public partial class SampleUnionCollection : List<SampleUnion>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public SampleUnionCollection() {}

        /// <remarks />
        public SampleUnionCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public SampleUnionCollection(IEnumerable<SampleUnion> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator SampleUnionCollection(SampleUnion[] values)
        {
            if (values != null)
            {
                return new SampleUnionCollection(values);
            }

            return new SampleUnionCollection();
        }

        /// <remarks />
        public static explicit operator SampleUnion[](SampleUnionCollection values)
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
            return (SampleUnionCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            SampleUnionCollection clone = new SampleUnionCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((SampleUnion)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region SampleStructureWithOptionalFields Class
    #if (!OPCUA_EXCLUDE_SampleStructureWithOptionalFields)
    /// <remarks />
    /// <exclude />
    
    public enum SampleStructureWithOptionalFieldsFields : uint
    {   
        None = 0,
        /// <remarks />
        FieldY = 0x1,
        /// <remarks />
        FieldZ = 0x2
    }
        
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = DemoModel.Namespaces.DemoModelXsd)]
    public partial class SampleStructureWithOptionalFields : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public SampleStructureWithOptionalFields()
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
            EncodingMask = SampleStructureWithOptionalFieldsFields.None;
            m_fieldX = (uint)0;
            m_fieldY = new StringCollection();
            m_fieldZ = null;
        }
        #endregion

        #region Public Properties
        // <remarks />
        [DataMember(Name = "EncodingMask", IsRequired = true, Order = 0)]
        public SampleStructureWithOptionalFieldsFields EncodingMask { get; set; }

        /// <remarks />
        [DataMember(Name = "FieldX", IsRequired = false, Order = 1)]
        public uint FieldX
        {
            get { return m_fieldX;  }
            set { m_fieldX = value; }
        }

        /// <remarks />
        [DataMember(Name = "FieldY", IsRequired = false, Order = 2)]
        public StringCollection FieldY
        {
            get
            {
                return m_fieldY;
            }

            set
            {
                m_fieldY = value;

                if (value == null)
                {
                    m_fieldY = new StringCollection();
                }
            }
        }

        /// <remarks />
        [DataMember(Name = "FieldZ", IsRequired = false, Order = 3)]
        public byte[] FieldZ
        {
            get { return m_fieldZ;  }
            set { m_fieldZ = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId => DataTypeIds.SampleStructureWithOptionalFields; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.SampleStructureWithOptionalFields_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.SampleStructureWithOptionalFields_Encoding_DefaultXml;
            
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.SampleStructureWithOptionalFields_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(DemoModel.Namespaces.DemoModelXsd);
            encoder.WriteUInt32(nameof(EncodingMask), (uint)EncodingMask);

            encoder.WriteUInt32("FieldX", FieldX);
            if ((EncodingMask & SampleStructureWithOptionalFieldsFields.FieldY) != 0) encoder.WriteStringArray("FieldY", FieldY);
            if ((EncodingMask & SampleStructureWithOptionalFieldsFields.FieldZ) != 0) encoder.WriteByteString("FieldZ", FieldZ);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(DemoModel.Namespaces.DemoModelXsd);

            EncodingMask = (SampleStructureWithOptionalFieldsFields)decoder.ReadUInt32(nameof(EncodingMask));

            FieldX = decoder.ReadUInt32("FieldX");
            if ((EncodingMask & SampleStructureWithOptionalFieldsFields.FieldY) != 0) FieldY = decoder.ReadStringArray("FieldY");
            if ((EncodingMask & SampleStructureWithOptionalFieldsFields.FieldZ) != 0) FieldZ = decoder.ReadByteString("FieldZ");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            SampleStructureWithOptionalFields value = encodeable as SampleStructureWithOptionalFields;

            if (value == null)
            {
                return false;
            }

            if (value.EncodingMask != this.EncodingMask) return false;

            if (!Utils.IsEqual(m_fieldX, value.m_fieldX)) return false;
            if ((EncodingMask & SampleStructureWithOptionalFieldsFields.FieldY) != 0) if (!Utils.IsEqual(m_fieldY, value.m_fieldY)) return false;
            if ((EncodingMask & SampleStructureWithOptionalFieldsFields.FieldZ) != 0) if (!Utils.IsEqual(m_fieldZ, value.m_fieldZ)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (SampleStructureWithOptionalFields)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            SampleStructureWithOptionalFields clone = (SampleStructureWithOptionalFields)base.MemberwiseClone();

            clone.EncodingMask = this.EncodingMask;

            clone.m_fieldX = (uint)Utils.Clone(this.m_fieldX);
            if ((EncodingMask & SampleStructureWithOptionalFieldsFields.FieldY) != 0) clone.m_fieldY = (StringCollection)Utils.Clone(this.m_fieldY);
            if ((EncodingMask & SampleStructureWithOptionalFieldsFields.FieldZ) != 0) clone.m_fieldZ = (byte[])Utils.Clone(this.m_fieldZ);

            return clone;
        }
        #endregion

        #region Private Fields
        private uint m_fieldX;
        private StringCollection m_fieldY;
        private byte[] m_fieldZ;
        #endregion
    }

    #region SampleStructureWithOptionalFieldsCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfSampleStructureWithOptionalFields", Namespace = DemoModel.Namespaces.DemoModelXsd, ItemName = "SampleStructureWithOptionalFields")]
    public partial class SampleStructureWithOptionalFieldsCollection : List<SampleStructureWithOptionalFields>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public SampleStructureWithOptionalFieldsCollection() {}

        /// <remarks />
        public SampleStructureWithOptionalFieldsCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public SampleStructureWithOptionalFieldsCollection(IEnumerable<SampleStructureWithOptionalFields> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator SampleStructureWithOptionalFieldsCollection(SampleStructureWithOptionalFields[] values)
        {
            if (values != null)
            {
                return new SampleStructureWithOptionalFieldsCollection(values);
            }

            return new SampleStructureWithOptionalFieldsCollection();
        }

        /// <remarks />
        public static explicit operator SampleStructureWithOptionalFields[](SampleStructureWithOptionalFieldsCollection values)
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
            return (SampleStructureWithOptionalFieldsCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            SampleStructureWithOptionalFieldsCollection clone = new SampleStructureWithOptionalFieldsCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((SampleStructureWithOptionalFields)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region SampleUnionAllowSubtypes Class
    #if (!OPCUA_EXCLUDE_SampleUnionAllowSubtypes)
    /// <remarks />
    /// <exclude />
    public enum SampleUnionAllowSubtypesFields : uint
    {
        /// <remarks />
        None = 0,
        /// <remarks />
        FieldX = 1,
        /// <remarks />
        FieldY = 2
    }

    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = DemoModel.Namespaces.DemoModelXsd)]
    public partial class SampleUnionAllowSubtypes : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public SampleUnionAllowSubtypes()
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
            SwitchField = SampleUnionAllowSubtypesFields.None;
            m_fieldX = null;
            m_fieldY = new WorkOrderStatusType();
        }
        #endregion

        #region Public Properties
        // <remarks />
        [DataMember(Name = "SwitchField", IsRequired = true, Order = 0)]
        public SampleUnionAllowSubtypesFields SwitchField { get; set; }

        /// <remarks />
        [DataMember(Name = "FieldX", IsRequired = false, Order = 1)]
        public ExtensionObject FieldX
        {
            get { return m_fieldX;  }
            set { m_fieldX = value; }
        }

        /// <remarks />
        [DataMember(Name = "FieldY", IsRequired = false, Order = 2)]
        public WorkOrderStatusType FieldY
        {
            get
            {
                return m_fieldY;
            }

            set
            {
                m_fieldY = value;

                if (value == null)
                {
                    m_fieldY = new WorkOrderStatusType();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId => DataTypeIds.SampleUnionAllowSubtypes; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.SampleUnionAllowSubtypes_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.SampleUnionAllowSubtypes_Encoding_DefaultXml;

        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.SampleUnionAllowSubtypes_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(DemoModel.Namespaces.DemoModelXsd);
            encoder.WriteUInt32(nameof(SwitchField), (uint)SwitchField);

            switch (SwitchField)
            {
                default: { break; }
                case SampleUnionAllowSubtypesFields.FieldX: { encoder.WriteExtensionObject("FieldX", FieldX); break; }
                case SampleUnionAllowSubtypesFields.FieldY: { encoder.WriteEncodeable("FieldY", FieldY, typeof(WorkOrderStatusType)); break; }
            }
            
            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(DemoModel.Namespaces.DemoModelXsd);

            SwitchField = (SampleUnionAllowSubtypesFields)decoder.ReadUInt32(nameof(SwitchField));
                
            switch (SwitchField)
            {
                default: { break; }
                case SampleUnionAllowSubtypesFields.FieldX: { FieldX = decoder.ReadExtensionObject("FieldX"); break; }
                case SampleUnionAllowSubtypesFields.FieldY: { FieldY = (WorkOrderStatusType)decoder.ReadEncodeable("FieldY", typeof(WorkOrderStatusType)); break; }
            }

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            SampleUnionAllowSubtypes value = encodeable as SampleUnionAllowSubtypes;

            if (value == null)
            {
                return false;
            }

            if (value.SwitchField != this.SwitchField) return false;

            switch (SwitchField)
            {
                default: { break; }
                case SampleUnionAllowSubtypesFields.FieldX: { if (!Utils.IsEqual(m_fieldX, value.m_fieldX)) return false; break; }
                case SampleUnionAllowSubtypesFields.FieldY: { if (!Utils.IsEqual(m_fieldY, value.m_fieldY)) return false; break; }
            }

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (SampleUnionAllowSubtypes)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            SampleUnionAllowSubtypes clone = (SampleUnionAllowSubtypes)base.MemberwiseClone();

            clone.SwitchField = this.SwitchField;

            switch (SwitchField)
            {
                default: { break; }
                case SampleUnionAllowSubtypesFields.FieldX: { clone.m_fieldX = (ExtensionObject)Utils.Clone(this.m_fieldX); break; }
                case SampleUnionAllowSubtypesFields.FieldY: { clone.m_fieldY = (WorkOrderStatusType)Utils.Clone(this.m_fieldY); break; }
            }

            return clone;
        }
        #endregion

        #region Private Fields
        private ExtensionObject m_fieldX;
        private WorkOrderStatusType m_fieldY;
        #endregion
    }

    #region SampleUnionAllowSubtypesCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfSampleUnionAllowSubtypes", Namespace = DemoModel.Namespaces.DemoModelXsd, ItemName = "SampleUnionAllowSubtypes")]
    public partial class SampleUnionAllowSubtypesCollection : List<SampleUnionAllowSubtypes>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public SampleUnionAllowSubtypesCollection() {}

        /// <remarks />
        public SampleUnionAllowSubtypesCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public SampleUnionAllowSubtypesCollection(IEnumerable<SampleUnionAllowSubtypes> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator SampleUnionAllowSubtypesCollection(SampleUnionAllowSubtypes[] values)
        {
            if (values != null)
            {
                return new SampleUnionAllowSubtypesCollection(values);
            }

            return new SampleUnionAllowSubtypesCollection();
        }

        /// <remarks />
        public static explicit operator SampleUnionAllowSubtypes[](SampleUnionAllowSubtypesCollection values)
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
            return (SampleUnionAllowSubtypesCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            SampleUnionAllowSubtypesCollection clone = new SampleUnionAllowSubtypesCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((SampleUnionAllowSubtypes)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region SampleStructureAllowSubtypes Class
    #if (!OPCUA_EXCLUDE_SampleStructureAllowSubtypes)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = DemoModel.Namespaces.DemoModelXsd)]
    public partial class SampleStructureAllowSubtypes : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public SampleStructureAllowSubtypes()
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
            m_fieldX = null;
            m_fieldY = new ExtensionObjectCollection();
            m_fieldZ = Variant.Null;
            m_fieldW = new WorkOrderStatusType();
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "FieldX", IsRequired = false, Order = 1)]
        public ExtensionObject FieldX
        {
            get { return m_fieldX;  }
            set { m_fieldX = value; }
        }

        /// <remarks />
        [DataMember(Name = "FieldY", IsRequired = false, Order = 2)]
        public ExtensionObjectCollection FieldY
        {
            get { return m_fieldY;  }
            set { m_fieldY = value; }
        }

        /// <remarks />
        [DataMember(Name = "FieldZ", IsRequired = false, Order = 3)]
        public Variant FieldZ
        {
            get { return m_fieldZ;  }
            set { m_fieldZ = value; }
        }

        /// <remarks />
        [DataMember(Name = "FieldW", IsRequired = false, Order = 4)]
        public WorkOrderStatusType FieldW
        {
            get
            {
                return m_fieldW;
            }

            set
            {
                m_fieldW = value;

                if (value == null)
                {
                    m_fieldW = new WorkOrderStatusType();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId => DataTypeIds.SampleStructureAllowSubtypes; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.SampleStructureAllowSubtypes_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.SampleStructureAllowSubtypes_Encoding_DefaultXml;
                    
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.SampleStructureAllowSubtypes_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(DemoModel.Namespaces.DemoModelXsd);

            encoder.WriteExtensionObject("FieldX", FieldX);
            encoder.WriteExtensionObjectArray("FieldY", FieldY);
            encoder.WriteVariant("FieldZ", FieldZ);
            encoder.WriteEncodeable("FieldW", FieldW, typeof(WorkOrderStatusType));

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(DemoModel.Namespaces.DemoModelXsd);

            FieldX = decoder.ReadExtensionObject("FieldX");
            FieldY = decoder.ReadExtensionObjectArray("FieldY");
            FieldZ = decoder.ReadVariant("FieldZ");
            FieldW = (WorkOrderStatusType)decoder.ReadEncodeable("FieldW", typeof(WorkOrderStatusType));

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            SampleStructureAllowSubtypes value = encodeable as SampleStructureAllowSubtypes;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_fieldX, value.m_fieldX)) return false;
            if (!Utils.IsEqual(m_fieldY, value.m_fieldY)) return false;
            if (!Utils.IsEqual(m_fieldZ, value.m_fieldZ)) return false;
            if (!Utils.IsEqual(m_fieldW, value.m_fieldW)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (SampleStructureAllowSubtypes)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            SampleStructureAllowSubtypes clone = (SampleStructureAllowSubtypes)base.MemberwiseClone();

            clone.m_fieldX = (ExtensionObject)Utils.Clone(this.m_fieldX);
            clone.m_fieldY = (ExtensionObjectCollection)Utils.Clone(this.m_fieldY);
            clone.m_fieldZ = (Variant)Utils.Clone(this.m_fieldZ);
            clone.m_fieldW = (WorkOrderStatusType)Utils.Clone(this.m_fieldW);

            return clone;
        }
        #endregion

        #region Private Fields
        private ExtensionObject m_fieldX;
        private ExtensionObjectCollection m_fieldY;
        private Variant m_fieldZ;
        private WorkOrderStatusType m_fieldW;
        #endregion
    }

    #region SampleStructureAllowSubtypesCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfSampleStructureAllowSubtypes", Namespace = DemoModel.Namespaces.DemoModelXsd, ItemName = "SampleStructureAllowSubtypes")]
    public partial class SampleStructureAllowSubtypesCollection : List<SampleStructureAllowSubtypes>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public SampleStructureAllowSubtypesCollection() {}

        /// <remarks />
        public SampleStructureAllowSubtypesCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public SampleStructureAllowSubtypesCollection(IEnumerable<SampleStructureAllowSubtypes> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator SampleStructureAllowSubtypesCollection(SampleStructureAllowSubtypes[] values)
        {
            if (values != null)
            {
                return new SampleStructureAllowSubtypesCollection(values);
            }

            return new SampleStructureAllowSubtypesCollection();
        }

        /// <remarks />
        public static explicit operator SampleStructureAllowSubtypes[](SampleStructureAllowSubtypesCollection values)
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
            return (SampleStructureAllowSubtypesCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            SampleStructureAllowSubtypesCollection clone = new SampleStructureAllowSubtypesCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((SampleStructureAllowSubtypes)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion
}
