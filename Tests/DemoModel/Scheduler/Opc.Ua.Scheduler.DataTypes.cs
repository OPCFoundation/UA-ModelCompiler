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

namespace Opc.Ua.Scheduler
{
    #region SpecialEventType Class
    #if (!OPCUA_EXCLUDE_SpecialEventType)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd)]
    public partial class SpecialEventType : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public SpecialEventType()
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
            m_period = new SpecialEventPeriodType();
            m_listOfTimeActions = new TimeActionsTypeCollection();
            m_eventPriority = (byte)0;
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "Period", IsRequired = false, Order = 1)]
        public SpecialEventPeriodType Period
        {
            get
            {
                return m_period;
            }

            set
            {
                m_period = value;

                if (value == null)
                {
                    m_period = new SpecialEventPeriodType();
                }
            }
        }

        /// <remarks />
        [DataMember(Name = "ListOfTimeActions", IsRequired = false, Order = 2)]
        public TimeActionsTypeCollection ListOfTimeActions
        {
            get
            {
                return m_listOfTimeActions;
            }

            set
            {
                m_listOfTimeActions = value;

                if (value == null)
                {
                    m_listOfTimeActions = new TimeActionsTypeCollection();
                }
            }
        }

        /// <remarks />
        [DataMember(Name = "EventPriority", IsRequired = false, Order = 3)]
        public byte EventPriority
        {
            get { return m_eventPriority;  }
            set { m_eventPriority = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId => DataTypeIds.SpecialEventType; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.SpecialEventType_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.SpecialEventType_Encoding_DefaultXml;
                    
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.SpecialEventType_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            encoder.WriteEncodeable("Period", Period, typeof(SpecialEventPeriodType));
            encoder.WriteEncodeableArray("ListOfTimeActions", ListOfTimeActions.ToArray(), typeof(TimeActionsType));
            encoder.WriteByte("EventPriority", EventPriority);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            Period = (SpecialEventPeriodType)decoder.ReadEncodeable("Period", typeof(SpecialEventPeriodType));
            ListOfTimeActions = (TimeActionsTypeCollection)decoder.ReadEncodeableArray("ListOfTimeActions", typeof(TimeActionsType));
            EventPriority = decoder.ReadByte("EventPriority");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            SpecialEventType value = encodeable as SpecialEventType;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_period, value.m_period)) return false;
            if (!Utils.IsEqual(m_listOfTimeActions, value.m_listOfTimeActions)) return false;
            if (!Utils.IsEqual(m_eventPriority, value.m_eventPriority)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (SpecialEventType)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            SpecialEventType clone = (SpecialEventType)base.MemberwiseClone();

            clone.m_period = (SpecialEventPeriodType)Utils.Clone(this.m_period);
            clone.m_listOfTimeActions = (TimeActionsTypeCollection)Utils.Clone(this.m_listOfTimeActions);
            clone.m_eventPriority = (byte)Utils.Clone(this.m_eventPriority);

            return clone;
        }
        #endregion

        #region Private Fields
        private SpecialEventPeriodType m_period;
        private TimeActionsTypeCollection m_listOfTimeActions;
        private byte m_eventPriority;
        #endregion
    }

    #region SpecialEventTypeCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfSpecialEventType", Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd, ItemName = "SpecialEventType")]
    public partial class SpecialEventTypeCollection : List<SpecialEventType>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public SpecialEventTypeCollection() {}

        /// <remarks />
        public SpecialEventTypeCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public SpecialEventTypeCollection(IEnumerable<SpecialEventType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator SpecialEventTypeCollection(SpecialEventType[] values)
        {
            if (values != null)
            {
                return new SpecialEventTypeCollection(values);
            }

            return new SpecialEventTypeCollection();
        }

        /// <remarks />
        public static explicit operator SpecialEventType[](SpecialEventTypeCollection values)
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
            return (SpecialEventTypeCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            SpecialEventTypeCollection clone = new SpecialEventTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((SpecialEventType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region SpecialEventPeriodType Class
    #if (!OPCUA_EXCLUDE_SpecialEventPeriodType)
    /// <remarks />
    /// <exclude />
    public enum SpecialEventPeriodFields : uint
    {
        /// <remarks />
        None = 0,
        /// <remarks />
        CalendarEntry = 1,
        /// <remarks />
        CalendarReference = 2
    }

    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd)]
    public partial class SpecialEventPeriodType : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public SpecialEventPeriodType()
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
            SwitchField = SpecialEventPeriodFields.None;
            m_calendarEntry = new CalendarEntryType();
            m_calendarReference = null;
        }
        #endregion

        #region Public Properties
        // <remarks />
        [DataMember(Name = "SwitchField", IsRequired = true, Order = 0)]
        public SpecialEventPeriodFields SwitchField { get; set; }

        /// <remarks />
        [DataMember(Name = "CalendarEntry", IsRequired = false, Order = 1)]
        public CalendarEntryType CalendarEntry
        {
            get
            {
                return m_calendarEntry;
            }

            set
            {
                m_calendarEntry = value;

                if (value == null)
                {
                    m_calendarEntry = new CalendarEntryType();
                }
            }
        }

        /// <remarks />
        [DataMember(Name = "CalendarReference", IsRequired = false, Order = 2)]
        public NodeId CalendarReference
        {
            get { return m_calendarReference;  }
            set { m_calendarReference = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId => DataTypeIds.SpecialEventPeriodType; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.SpecialEventPeriodType_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.SpecialEventPeriodType_Encoding_DefaultXml;

        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.SpecialEventPeriodType_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);
            encoder.WriteUInt32(nameof(SwitchField), (uint)SwitchField);

            switch (SwitchField)
            {
                default: { break; }
                case SpecialEventPeriodFields.CalendarEntry: { encoder.WriteEncodeable("CalendarEntry", CalendarEntry, typeof(CalendarEntryType)); break; }
                case SpecialEventPeriodFields.CalendarReference: { encoder.WriteNodeId("CalendarReference", CalendarReference); break; }
            }
            
            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            SwitchField = (SpecialEventPeriodFields)decoder.ReadUInt32(nameof(SwitchField));
                
            switch (SwitchField)
            {
                default: { break; }
                case SpecialEventPeriodFields.CalendarEntry: { CalendarEntry = (CalendarEntryType)decoder.ReadEncodeable("CalendarEntry", typeof(CalendarEntryType)); break; }
                case SpecialEventPeriodFields.CalendarReference: { CalendarReference = decoder.ReadNodeId("CalendarReference"); break; }
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

            SpecialEventPeriodType value = encodeable as SpecialEventPeriodType;

            if (value == null)
            {
                return false;
            }

            if (value.SwitchField != this.SwitchField) return false;

            switch (SwitchField)
            {
                default: { break; }
                case SpecialEventPeriodFields.CalendarEntry: { if (!Utils.IsEqual(m_calendarEntry, value.m_calendarEntry)) return false; break; }
                case SpecialEventPeriodFields.CalendarReference: { if (!Utils.IsEqual(m_calendarReference, value.m_calendarReference)) return false; break; }
            }

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (SpecialEventPeriodType)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            SpecialEventPeriodType clone = (SpecialEventPeriodType)base.MemberwiseClone();

            clone.SwitchField = this.SwitchField;

            switch (SwitchField)
            {
                default: { break; }
                case SpecialEventPeriodFields.CalendarEntry: { clone.m_calendarEntry = (CalendarEntryType)Utils.Clone(this.m_calendarEntry); break; }
                case SpecialEventPeriodFields.CalendarReference: { clone.m_calendarReference = (NodeId)Utils.Clone(this.m_calendarReference); break; }
            }

            return clone;
        }
        #endregion

        #region Private Fields
        private CalendarEntryType m_calendarEntry;
        private NodeId m_calendarReference;
        #endregion
    }

    #region SpecialEventPeriodTypeCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfSpecialEventPeriodType", Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd, ItemName = "SpecialEventPeriodType")]
    public partial class SpecialEventPeriodTypeCollection : List<SpecialEventPeriodType>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public SpecialEventPeriodTypeCollection() {}

        /// <remarks />
        public SpecialEventPeriodTypeCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public SpecialEventPeriodTypeCollection(IEnumerable<SpecialEventPeriodType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator SpecialEventPeriodTypeCollection(SpecialEventPeriodType[] values)
        {
            if (values != null)
            {
                return new SpecialEventPeriodTypeCollection(values);
            }

            return new SpecialEventPeriodTypeCollection();
        }

        /// <remarks />
        public static explicit operator SpecialEventPeriodType[](SpecialEventPeriodTypeCollection values)
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
            return (SpecialEventPeriodTypeCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            SpecialEventPeriodTypeCollection clone = new SpecialEventPeriodTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((SpecialEventPeriodType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region CalendarEntryType Class
    #if (!OPCUA_EXCLUDE_CalendarEntryType)
    /// <remarks />
    /// <exclude />
    public enum CalendarEntryFields : uint
    {
        /// <remarks />
        None = 0,
        /// <remarks />
        Date = 1,
        /// <remarks />
        DateRange = 2
    }

    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd)]
    public partial class CalendarEntryType : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public CalendarEntryType()
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
            SwitchField = CalendarEntryFields.None;
            m_date = new DateType();
            m_dateRange = new DateRangeType();
        }
        #endregion

        #region Public Properties
        // <remarks />
        [DataMember(Name = "SwitchField", IsRequired = true, Order = 0)]
        public CalendarEntryFields SwitchField { get; set; }

        /// <remarks />
        [DataMember(Name = "Date", IsRequired = false, Order = 1)]
        public DateType Date
        {
            get
            {
                return m_date;
            }

            set
            {
                m_date = value;

                if (value == null)
                {
                    m_date = new DateType();
                }
            }
        }

        /// <remarks />
        [DataMember(Name = "DateRange", IsRequired = false, Order = 2)]
        public DateRangeType DateRange
        {
            get
            {
                return m_dateRange;
            }

            set
            {
                m_dateRange = value;

                if (value == null)
                {
                    m_dateRange = new DateRangeType();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId => DataTypeIds.CalendarEntryType; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.CalendarEntryType_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.CalendarEntryType_Encoding_DefaultXml;

        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.CalendarEntryType_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);
            encoder.WriteUInt32(nameof(SwitchField), (uint)SwitchField);

            switch (SwitchField)
            {
                default: { break; }
                case CalendarEntryFields.Date: { encoder.WriteEncodeable("Date", Date, typeof(DateType)); break; }
                case CalendarEntryFields.DateRange: { encoder.WriteEncodeable("DateRange", DateRange, typeof(DateRangeType)); break; }
            }
            
            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            SwitchField = (CalendarEntryFields)decoder.ReadUInt32(nameof(SwitchField));
                
            switch (SwitchField)
            {
                default: { break; }
                case CalendarEntryFields.Date: { Date = (DateType)decoder.ReadEncodeable("Date", typeof(DateType)); break; }
                case CalendarEntryFields.DateRange: { DateRange = (DateRangeType)decoder.ReadEncodeable("DateRange", typeof(DateRangeType)); break; }
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

            CalendarEntryType value = encodeable as CalendarEntryType;

            if (value == null)
            {
                return false;
            }

            if (value.SwitchField != this.SwitchField) return false;

            switch (SwitchField)
            {
                default: { break; }
                case CalendarEntryFields.Date: { if (!Utils.IsEqual(m_date, value.m_date)) return false; break; }
                case CalendarEntryFields.DateRange: { if (!Utils.IsEqual(m_dateRange, value.m_dateRange)) return false; break; }
            }

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (CalendarEntryType)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            CalendarEntryType clone = (CalendarEntryType)base.MemberwiseClone();

            clone.SwitchField = this.SwitchField;

            switch (SwitchField)
            {
                default: { break; }
                case CalendarEntryFields.Date: { clone.m_date = (DateType)Utils.Clone(this.m_date); break; }
                case CalendarEntryFields.DateRange: { clone.m_dateRange = (DateRangeType)Utils.Clone(this.m_dateRange); break; }
            }

            return clone;
        }
        #endregion

        #region Private Fields
        private DateType m_date;
        private DateRangeType m_dateRange;
        #endregion
    }

    #region CalendarEntryTypeCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfCalendarEntryType", Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd, ItemName = "CalendarEntryType")]
    public partial class CalendarEntryTypeCollection : List<CalendarEntryType>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public CalendarEntryTypeCollection() {}

        /// <remarks />
        public CalendarEntryTypeCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public CalendarEntryTypeCollection(IEnumerable<CalendarEntryType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator CalendarEntryTypeCollection(CalendarEntryType[] values)
        {
            if (values != null)
            {
                return new CalendarEntryTypeCollection(values);
            }

            return new CalendarEntryTypeCollection();
        }

        /// <remarks />
        public static explicit operator CalendarEntryType[](CalendarEntryTypeCollection values)
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
            return (CalendarEntryTypeCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            CalendarEntryTypeCollection clone = new CalendarEntryTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((CalendarEntryType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region DateType Class
    #if (!OPCUA_EXCLUDE_DateType)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd)]
    public partial class DateType : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public DateType()
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
            m_year = (ushort)0;
            m_month = Month.Unspecified;
            m_dayOfMonth = DayOfMonth.Unspecified;
            m_dayOfWeek = DayOfWeek.Unspecified;
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "Year", IsRequired = false, Order = 1)]
        public ushort Year
        {
            get { return m_year;  }
            set { m_year = value; }
        }

        /// <remarks />
        [DataMember(Name = "Month", IsRequired = false, Order = 2)]
        public Month Month
        {
            get { return m_month;  }
            set { m_month = value; }
        }

        /// <remarks />
        [DataMember(Name = "DayOfMonth", IsRequired = false, Order = 3)]
        public DayOfMonth DayOfMonth
        {
            get { return m_dayOfMonth;  }
            set { m_dayOfMonth = value; }
        }

        /// <remarks />
        [DataMember(Name = "DayOfWeek", IsRequired = false, Order = 4)]
        public DayOfWeek DayOfWeek
        {
            get { return m_dayOfWeek;  }
            set { m_dayOfWeek = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId => DataTypeIds.DateType; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.DateType_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.DateType_Encoding_DefaultXml;
                    
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.DateType_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            encoder.WriteUInt16("Year", Year);
            encoder.WriteEnumerated("Month", Month);
            encoder.WriteEnumerated("DayOfMonth", DayOfMonth);
            encoder.WriteEnumerated("DayOfWeek", DayOfWeek);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            Year = decoder.ReadUInt16("Year");
            Month = (Month)decoder.ReadEnumerated("Month", typeof(Month));
            DayOfMonth = (DayOfMonth)decoder.ReadEnumerated("DayOfMonth", typeof(DayOfMonth));
            DayOfWeek = (DayOfWeek)decoder.ReadEnumerated("DayOfWeek", typeof(DayOfWeek));

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            DateType value = encodeable as DateType;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_year, value.m_year)) return false;
            if (!Utils.IsEqual(m_month, value.m_month)) return false;
            if (!Utils.IsEqual(m_dayOfMonth, value.m_dayOfMonth)) return false;
            if (!Utils.IsEqual(m_dayOfWeek, value.m_dayOfWeek)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (DateType)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            DateType clone = (DateType)base.MemberwiseClone();

            clone.m_year = (ushort)Utils.Clone(this.m_year);
            clone.m_month = (Month)Utils.Clone(this.m_month);
            clone.m_dayOfMonth = (DayOfMonth)Utils.Clone(this.m_dayOfMonth);
            clone.m_dayOfWeek = (DayOfWeek)Utils.Clone(this.m_dayOfWeek);

            return clone;
        }
        #endregion

        #region Private Fields
        private ushort m_year;
        private Month m_month;
        private DayOfMonth m_dayOfMonth;
        private DayOfWeek m_dayOfWeek;
        #endregion
    }

    #region DateTypeCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfDateType", Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd, ItemName = "DateType")]
    public partial class DateTypeCollection : List<DateType>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public DateTypeCollection() {}

        /// <remarks />
        public DateTypeCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public DateTypeCollection(IEnumerable<DateType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator DateTypeCollection(DateType[] values)
        {
            if (values != null)
            {
                return new DateTypeCollection(values);
            }

            return new DateTypeCollection();
        }

        /// <remarks />
        public static explicit operator DateType[](DateTypeCollection values)
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
            return (DateTypeCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            DateTypeCollection clone = new DateTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((DateType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region Month Enumeration
    #if (!OPCUA_EXCLUDE_Month)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd)]
    public enum Month
    {
        /// <remarks />
        [EnumMember(Value = "Unspecified_0")]
        Unspecified = 0,

        /// <remarks />
        [EnumMember(Value = "January_1")]
        January = 1,

        /// <remarks />
        [EnumMember(Value = "February_2")]
        February = 2,

        /// <remarks />
        [EnumMember(Value = "March_3")]
        March = 3,

        /// <remarks />
        [EnumMember(Value = "April_4")]
        April = 4,

        /// <remarks />
        [EnumMember(Value = "May_5")]
        May = 5,

        /// <remarks />
        [EnumMember(Value = "June_6")]
        June = 6,

        /// <remarks />
        [EnumMember(Value = "July_7")]
        July = 7,

        /// <remarks />
        [EnumMember(Value = "August_8")]
        August = 8,

        /// <remarks />
        [EnumMember(Value = "September_9")]
        September = 9,

        /// <remarks />
        [EnumMember(Value = "October_10")]
        October = 10,

        /// <remarks />
        [EnumMember(Value = "November_11")]
        November = 11,

        /// <remarks />
        [EnumMember(Value = "December_12")]
        December = 12,

        /// <remarks />
        [EnumMember(Value = "Odd_13")]
        Odd = 13,

        /// <remarks />
        [EnumMember(Value = "Even_14")]
        Even = 14,
    }

    #region MonthCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfMonth", Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd, ItemName = "Month")]
    public partial class MonthCollection : List<Month>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public MonthCollection() {}

        /// <remarks />
        public MonthCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public MonthCollection(IEnumerable<Month> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator MonthCollection(Month[] values)
        {
            if (values != null)
            {
                return new MonthCollection(values);
            }

            return new MonthCollection();
        }

        /// <remarks />
        public static explicit operator Month[](MonthCollection values)
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
            return (MonthCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            MonthCollection clone = new MonthCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((Month)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region DayOfMonth Enumeration
    #if (!OPCUA_EXCLUDE_DayOfMonth)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd)]
    public enum DayOfMonth
    {
        /// <remarks />
        [EnumMember(Value = "Unspecified_0")]
        Unspecified = 0,

        /// <remarks />
        [EnumMember(Value = "Day1_1")]
        Day1 = 1,

        /// <remarks />
        [EnumMember(Value = "Day2_2")]
        Day2 = 2,

        /// <remarks />
        [EnumMember(Value = "Day3_3")]
        Day3 = 3,

        /// <remarks />
        [EnumMember(Value = "Day4_4")]
        Day4 = 4,

        /// <remarks />
        [EnumMember(Value = "Day5_5")]
        Day5 = 5,

        /// <remarks />
        [EnumMember(Value = "Day6_6")]
        Day6 = 6,

        /// <remarks />
        [EnumMember(Value = "Day7_7")]
        Day7 = 7,

        /// <remarks />
        [EnumMember(Value = "Day8_8")]
        Day8 = 8,

        /// <remarks />
        [EnumMember(Value = "Day9_9")]
        Day9 = 9,

        /// <remarks />
        [EnumMember(Value = "Day10_10")]
        Day10 = 10,

        /// <remarks />
        [EnumMember(Value = "Day11_11")]
        Day11 = 11,

        /// <remarks />
        [EnumMember(Value = "Day12_12")]
        Day12 = 12,

        /// <remarks />
        [EnumMember(Value = "Day13_13")]
        Day13 = 13,

        /// <remarks />
        [EnumMember(Value = "Day14_14")]
        Day14 = 14,

        /// <remarks />
        [EnumMember(Value = "Day15_15")]
        Day15 = 15,

        /// <remarks />
        [EnumMember(Value = "Day16_16")]
        Day16 = 16,

        /// <remarks />
        [EnumMember(Value = "Day17_17")]
        Day17 = 17,

        /// <remarks />
        [EnumMember(Value = "Day18_18")]
        Day18 = 18,

        /// <remarks />
        [EnumMember(Value = "Day19_19")]
        Day19 = 19,

        /// <remarks />
        [EnumMember(Value = "Day20_20")]
        Day20 = 20,

        /// <remarks />
        [EnumMember(Value = "Day21_21")]
        Day21 = 21,

        /// <remarks />
        [EnumMember(Value = "Day22_22")]
        Day22 = 22,

        /// <remarks />
        [EnumMember(Value = "Day23_23")]
        Day23 = 23,

        /// <remarks />
        [EnumMember(Value = "Day24_24")]
        Day24 = 24,

        /// <remarks />
        [EnumMember(Value = "Day25_25")]
        Day25 = 25,

        /// <remarks />
        [EnumMember(Value = "Day26_26")]
        Day26 = 26,

        /// <remarks />
        [EnumMember(Value = "Day27_27")]
        Day27 = 27,

        /// <remarks />
        [EnumMember(Value = "Day28_28")]
        Day28 = 28,

        /// <remarks />
        [EnumMember(Value = "Day29_29")]
        Day29 = 29,

        /// <remarks />
        [EnumMember(Value = "Day30_30")]
        Day30 = 30,

        /// <remarks />
        [EnumMember(Value = "Day31_31")]
        Day31 = 31,

        /// <remarks />
        [EnumMember(Value = "LastDayOfMonth_32")]
        LastDayOfMonth = 32,

        /// <remarks />
        [EnumMember(Value = "OddDayOfMonth_33")]
        OddDayOfMonth = 33,

        /// <remarks />
        [EnumMember(Value = "EvenDayOfMonth_34")]
        EvenDayOfMonth = 34,
    }

    #region DayOfMonthCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfDayOfMonth", Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd, ItemName = "DayOfMonth")]
    public partial class DayOfMonthCollection : List<DayOfMonth>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public DayOfMonthCollection() {}

        /// <remarks />
        public DayOfMonthCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public DayOfMonthCollection(IEnumerable<DayOfMonth> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator DayOfMonthCollection(DayOfMonth[] values)
        {
            if (values != null)
            {
                return new DayOfMonthCollection(values);
            }

            return new DayOfMonthCollection();
        }

        /// <remarks />
        public static explicit operator DayOfMonth[](DayOfMonthCollection values)
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
            return (DayOfMonthCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            DayOfMonthCollection clone = new DayOfMonthCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((DayOfMonth)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region DayOfWeek Enumeration
    #if (!OPCUA_EXCLUDE_DayOfWeek)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd)]
    public enum DayOfWeek
    {
        /// <remarks />
        [EnumMember(Value = "Unspecified_0")]
        Unspecified = 0,

        /// <remarks />
        [EnumMember(Value = "Monday_1")]
        Monday = 1,

        /// <remarks />
        [EnumMember(Value = "Tuesday_2")]
        Tuesday = 2,

        /// <remarks />
        [EnumMember(Value = "Wednesday_3")]
        Wednesday = 3,

        /// <remarks />
        [EnumMember(Value = "Thursday_4")]
        Thursday = 4,

        /// <remarks />
        [EnumMember(Value = "Friday_5")]
        Friday = 5,

        /// <remarks />
        [EnumMember(Value = "Saturday_6")]
        Saturday = 6,

        /// <remarks />
        [EnumMember(Value = "Sunday_7")]
        Sunday = 7,
    }

    #region DayOfWeekCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfDayOfWeek", Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd, ItemName = "DayOfWeek")]
    public partial class DayOfWeekCollection : List<DayOfWeek>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public DayOfWeekCollection() {}

        /// <remarks />
        public DayOfWeekCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public DayOfWeekCollection(IEnumerable<DayOfWeek> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator DayOfWeekCollection(DayOfWeek[] values)
        {
            if (values != null)
            {
                return new DayOfWeekCollection(values);
            }

            return new DayOfWeekCollection();
        }

        /// <remarks />
        public static explicit operator DayOfWeek[](DayOfWeekCollection values)
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
            return (DayOfWeekCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            DayOfWeekCollection clone = new DayOfWeekCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((DayOfWeek)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region DateRangeType Class
    #if (!OPCUA_EXCLUDE_DateRangeType)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd)]
    public partial class DateRangeType : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public DateRangeType()
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
            m_startDate = new DateType();
            m_endDate = new DateType();
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "StartDate", IsRequired = false, Order = 1)]
        public DateType StartDate
        {
            get
            {
                return m_startDate;
            }

            set
            {
                m_startDate = value;

                if (value == null)
                {
                    m_startDate = new DateType();
                }
            }
        }

        /// <remarks />
        [DataMember(Name = "EndDate", IsRequired = false, Order = 2)]
        public DateType EndDate
        {
            get
            {
                return m_endDate;
            }

            set
            {
                m_endDate = value;

                if (value == null)
                {
                    m_endDate = new DateType();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId => DataTypeIds.DateRangeType; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.DateRangeType_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.DateRangeType_Encoding_DefaultXml;
                    
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.DateRangeType_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            encoder.WriteEncodeable("StartDate", StartDate, typeof(DateType));
            encoder.WriteEncodeable("EndDate", EndDate, typeof(DateType));

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            StartDate = (DateType)decoder.ReadEncodeable("StartDate", typeof(DateType));
            EndDate = (DateType)decoder.ReadEncodeable("EndDate", typeof(DateType));

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            DateRangeType value = encodeable as DateRangeType;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_startDate, value.m_startDate)) return false;
            if (!Utils.IsEqual(m_endDate, value.m_endDate)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (DateRangeType)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            DateRangeType clone = (DateRangeType)base.MemberwiseClone();

            clone.m_startDate = (DateType)Utils.Clone(this.m_startDate);
            clone.m_endDate = (DateType)Utils.Clone(this.m_endDate);

            return clone;
        }
        #endregion

        #region Private Fields
        private DateType m_startDate;
        private DateType m_endDate;
        #endregion
    }

    #region DateRangeTypeCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfDateRangeType", Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd, ItemName = "DateRangeType")]
    public partial class DateRangeTypeCollection : List<DateRangeType>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public DateRangeTypeCollection() {}

        /// <remarks />
        public DateRangeTypeCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public DateRangeTypeCollection(IEnumerable<DateRangeType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator DateRangeTypeCollection(DateRangeType[] values)
        {
            if (values != null)
            {
                return new DateRangeTypeCollection(values);
            }

            return new DateRangeTypeCollection();
        }

        /// <remarks />
        public static explicit operator DateRangeType[](DateRangeTypeCollection values)
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
            return (DateRangeTypeCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            DateRangeTypeCollection clone = new DateRangeTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((DateRangeType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region TimeActionsType Class
    #if (!OPCUA_EXCLUDE_TimeActionsType)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd)]
    public partial class TimeActionsType : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public TimeActionsType()
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
            m_time = new TimeType();
            m_actions = new ExtensionObjectCollection();
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "Time", IsRequired = false, Order = 1)]
        public TimeType Time
        {
            get
            {
                return m_time;
            }

            set
            {
                m_time = value;

                if (value == null)
                {
                    m_time = new TimeType();
                }
            }
        }

        /// <remarks />
        [DataMember(Name = "Actions", IsRequired = false, Order = 2)]
        public ExtensionObjectCollection Actions
        {
            get { return m_actions;  }
            set { m_actions = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId => DataTypeIds.TimeActionsType; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.TimeActionsType_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.TimeActionsType_Encoding_DefaultXml;
                    
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.TimeActionsType_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            encoder.WriteEncodeable("Time", Time, typeof(TimeType));
            encoder.WriteExtensionObjectArray("Actions", Actions);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            Time = (TimeType)decoder.ReadEncodeable("Time", typeof(TimeType));
            Actions = decoder.ReadExtensionObjectArray("Actions");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            TimeActionsType value = encodeable as TimeActionsType;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_time, value.m_time)) return false;
            if (!Utils.IsEqual(m_actions, value.m_actions)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (TimeActionsType)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            TimeActionsType clone = (TimeActionsType)base.MemberwiseClone();

            clone.m_time = (TimeType)Utils.Clone(this.m_time);
            clone.m_actions = (ExtensionObjectCollection)Utils.Clone(this.m_actions);

            return clone;
        }
        #endregion

        #region Private Fields
        private TimeType m_time;
        private ExtensionObjectCollection m_actions;
        #endregion
    }

    #region TimeActionsTypeCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfTimeActionsType", Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd, ItemName = "TimeActionsType")]
    public partial class TimeActionsTypeCollection : List<TimeActionsType>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public TimeActionsTypeCollection() {}

        /// <remarks />
        public TimeActionsTypeCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public TimeActionsTypeCollection(IEnumerable<TimeActionsType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator TimeActionsTypeCollection(TimeActionsType[] values)
        {
            if (values != null)
            {
                return new TimeActionsTypeCollection(values);
            }

            return new TimeActionsTypeCollection();
        }

        /// <remarks />
        public static explicit operator TimeActionsType[](TimeActionsTypeCollection values)
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
            return (TimeActionsTypeCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            TimeActionsTypeCollection clone = new TimeActionsTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((TimeActionsType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region BaseActionType Class
    #if (!OPCUA_EXCLUDE_BaseActionType)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd)]
    public partial class BaseActionType : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public BaseActionType()
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
            m_lastActionResult = StatusCodes.Good;
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "LastActionResult", IsRequired = false, Order = 1)]
        public StatusCode LastActionResult
        {
            get { return m_lastActionResult;  }
            set { m_lastActionResult = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId => DataTypeIds.BaseActionType; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.BaseActionType_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.BaseActionType_Encoding_DefaultXml;
                    
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.BaseActionType_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            encoder.WriteStatusCode("LastActionResult", LastActionResult);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            LastActionResult = decoder.ReadStatusCode("LastActionResult");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            BaseActionType value = encodeable as BaseActionType;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_lastActionResult, value.m_lastActionResult)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (BaseActionType)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            BaseActionType clone = (BaseActionType)base.MemberwiseClone();

            clone.m_lastActionResult = (StatusCode)Utils.Clone(this.m_lastActionResult);

            return clone;
        }
        #endregion

        #region Private Fields
        private StatusCode m_lastActionResult;
        #endregion
    }

    #region BaseActionTypeCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfBaseActionType", Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd, ItemName = "BaseActionType")]
    public partial class BaseActionTypeCollection : List<BaseActionType>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public BaseActionTypeCollection() {}

        /// <remarks />
        public BaseActionTypeCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public BaseActionTypeCollection(IEnumerable<BaseActionType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator BaseActionTypeCollection(BaseActionType[] values)
        {
            if (values != null)
            {
                return new BaseActionTypeCollection(values);
            }

            return new BaseActionTypeCollection();
        }

        /// <remarks />
        public static explicit operator BaseActionType[](BaseActionTypeCollection values)
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
            return (BaseActionTypeCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            BaseActionTypeCollection clone = new BaseActionTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((BaseActionType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region WriteLocalVariableActionType Class
    #if (!OPCUA_EXCLUDE_WriteLocalVariableActionType)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd)]
    public partial class WriteLocalVariableActionType : Opc.Ua.Scheduler.BaseActionType
    {
        #region Constructors
        /// <remarks />
        public WriteLocalVariableActionType()
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
            m_variable = null;
            m_value = Variant.Null;
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "Variable", IsRequired = false, Order = 1)]
        public NodeId Variable
        {
            get { return m_variable;  }
            set { m_variable = value; }
        }

        /// <remarks />
        [DataMember(Name = "Value", IsRequired = false, Order = 2)]
        public Variant Value
        {
            get { return m_value;  }
            set { m_value = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public override ExpandedNodeId TypeId => DataTypeIds.WriteLocalVariableActionType; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public override ExpandedNodeId BinaryEncodingId => ObjectIds.WriteLocalVariableActionType_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public override ExpandedNodeId XmlEncodingId => ObjectIds.WriteLocalVariableActionType_Encoding_DefaultXml;
            
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public override ExpandedNodeId JsonEncodingId => ObjectIds.WriteLocalVariableActionType_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            encoder.WriteNodeId("Variable", Variable);
            encoder.WriteVariant("Value", Value);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            Variable = decoder.ReadNodeId("Variable");
            Value = decoder.ReadVariant("Value");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            WriteLocalVariableActionType value = encodeable as WriteLocalVariableActionType;

            if (value == null)
            {
                return false;
            }

            if (!base.IsEqual(encodeable)) return false;
            if (!Utils.IsEqual(m_variable, value.m_variable)) return false;
            if (!Utils.IsEqual(m_value, value.m_value)) return false;

            return base.IsEqual(encodeable);
        }    

        /// <summary cref="ICloneable.Clone" />
        public override object Clone()
        {
            return (WriteLocalVariableActionType)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            WriteLocalVariableActionType clone = (WriteLocalVariableActionType)base.MemberwiseClone();

            clone.m_variable = (NodeId)Utils.Clone(this.m_variable);
            clone.m_value = (Variant)Utils.Clone(this.m_value);

            return clone;
        }
        #endregion

        #region Private Fields
        private NodeId m_variable;
        private Variant m_value;
        #endregion
    }

    #region WriteLocalVariableActionTypeCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfWriteLocalVariableActionType", Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd, ItemName = "WriteLocalVariableActionType")]
    public partial class WriteLocalVariableActionTypeCollection : List<WriteLocalVariableActionType>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public WriteLocalVariableActionTypeCollection() {}

        /// <remarks />
        public WriteLocalVariableActionTypeCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public WriteLocalVariableActionTypeCollection(IEnumerable<WriteLocalVariableActionType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator WriteLocalVariableActionTypeCollection(WriteLocalVariableActionType[] values)
        {
            if (values != null)
            {
                return new WriteLocalVariableActionTypeCollection(values);
            }

            return new WriteLocalVariableActionTypeCollection();
        }

        /// <remarks />
        public static explicit operator WriteLocalVariableActionType[](WriteLocalVariableActionTypeCollection values)
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
            return (WriteLocalVariableActionTypeCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            WriteLocalVariableActionTypeCollection clone = new WriteLocalVariableActionTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((WriteLocalVariableActionType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region CallLocalMethodActionType Class
    #if (!OPCUA_EXCLUDE_CallLocalMethodActionType)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd)]
    public partial class CallLocalMethodActionType : Opc.Ua.Scheduler.BaseActionType
    {
        #region Constructors
        /// <remarks />
        public CallLocalMethodActionType()
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
            m_objectId = null;
            m_methodId = null;
            m_inputValues = new VariantCollection();
            m_lastOutputValues = new VariantCollection();
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "ObjectId", IsRequired = false, Order = 1)]
        public NodeId ObjectId
        {
            get { return m_objectId;  }
            set { m_objectId = value; }
        }

        /// <remarks />
        [DataMember(Name = "MethodId", IsRequired = false, Order = 2)]
        public NodeId MethodId
        {
            get { return m_methodId;  }
            set { m_methodId = value; }
        }

        /// <remarks />
        [DataMember(Name = "InputValues", IsRequired = false, Order = 3)]
        public VariantCollection InputValues
        {
            get
            {
                return m_inputValues;
            }

            set
            {
                m_inputValues = value;

                if (value == null)
                {
                    m_inputValues = new VariantCollection();
                }
            }
        }

        /// <remarks />
        [DataMember(Name = "LastOutputValues", IsRequired = false, Order = 4)]
        public VariantCollection LastOutputValues
        {
            get
            {
                return m_lastOutputValues;
            }

            set
            {
                m_lastOutputValues = value;

                if (value == null)
                {
                    m_lastOutputValues = new VariantCollection();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public override ExpandedNodeId TypeId => DataTypeIds.CallLocalMethodActionType; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public override ExpandedNodeId BinaryEncodingId => ObjectIds.CallLocalMethodActionType_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public override ExpandedNodeId XmlEncodingId => ObjectIds.CallLocalMethodActionType_Encoding_DefaultXml;
            
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public override ExpandedNodeId JsonEncodingId => ObjectIds.CallLocalMethodActionType_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            encoder.WriteNodeId("ObjectId", ObjectId);
            encoder.WriteNodeId("MethodId", MethodId);
            encoder.WriteVariantArray("InputValues", InputValues);
            encoder.WriteVariantArray("LastOutputValues", LastOutputValues);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            ObjectId = decoder.ReadNodeId("ObjectId");
            MethodId = decoder.ReadNodeId("MethodId");
            InputValues = decoder.ReadVariantArray("InputValues");
            LastOutputValues = decoder.ReadVariantArray("LastOutputValues");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            CallLocalMethodActionType value = encodeable as CallLocalMethodActionType;

            if (value == null)
            {
                return false;
            }

            if (!base.IsEqual(encodeable)) return false;
            if (!Utils.IsEqual(m_objectId, value.m_objectId)) return false;
            if (!Utils.IsEqual(m_methodId, value.m_methodId)) return false;
            if (!Utils.IsEqual(m_inputValues, value.m_inputValues)) return false;
            if (!Utils.IsEqual(m_lastOutputValues, value.m_lastOutputValues)) return false;

            return base.IsEqual(encodeable);
        }    

        /// <summary cref="ICloneable.Clone" />
        public override object Clone()
        {
            return (CallLocalMethodActionType)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            CallLocalMethodActionType clone = (CallLocalMethodActionType)base.MemberwiseClone();

            clone.m_objectId = (NodeId)Utils.Clone(this.m_objectId);
            clone.m_methodId = (NodeId)Utils.Clone(this.m_methodId);
            clone.m_inputValues = (VariantCollection)Utils.Clone(this.m_inputValues);
            clone.m_lastOutputValues = (VariantCollection)Utils.Clone(this.m_lastOutputValues);

            return clone;
        }
        #endregion

        #region Private Fields
        private NodeId m_objectId;
        private NodeId m_methodId;
        private VariantCollection m_inputValues;
        private VariantCollection m_lastOutputValues;
        #endregion
    }

    #region CallLocalMethodActionTypeCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfCallLocalMethodActionType", Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd, ItemName = "CallLocalMethodActionType")]
    public partial class CallLocalMethodActionTypeCollection : List<CallLocalMethodActionType>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public CallLocalMethodActionTypeCollection() {}

        /// <remarks />
        public CallLocalMethodActionTypeCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public CallLocalMethodActionTypeCollection(IEnumerable<CallLocalMethodActionType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator CallLocalMethodActionTypeCollection(CallLocalMethodActionType[] values)
        {
            if (values != null)
            {
                return new CallLocalMethodActionTypeCollection(values);
            }

            return new CallLocalMethodActionTypeCollection();
        }

        /// <remarks />
        public static explicit operator CallLocalMethodActionType[](CallLocalMethodActionTypeCollection values)
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
            return (CallLocalMethodActionTypeCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            CallLocalMethodActionTypeCollection clone = new CallLocalMethodActionTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((CallLocalMethodActionType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region TimeType Class
    #if (!OPCUA_EXCLUDE_TimeType)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd)]
    public partial class TimeType : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public TimeType()
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
            m_hour = (byte)0;
            m_minute = (byte)0;
            m_second = (byte)0;
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "Hour", IsRequired = false, Order = 1)]
        public byte Hour
        {
            get { return m_hour;  }
            set { m_hour = value; }
        }

        /// <remarks />
        [DataMember(Name = "Minute", IsRequired = false, Order = 2)]
        public byte Minute
        {
            get { return m_minute;  }
            set { m_minute = value; }
        }

        /// <remarks />
        [DataMember(Name = "Second", IsRequired = false, Order = 3)]
        public byte Second
        {
            get { return m_second;  }
            set { m_second = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId => DataTypeIds.TimeType; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.TimeType_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.TimeType_Encoding_DefaultXml;
                    
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.TimeType_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            encoder.WriteByte("Hour", Hour);
            encoder.WriteByte("Minute", Minute);
            encoder.WriteByte("Second", Second);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            Hour = decoder.ReadByte("Hour");
            Minute = decoder.ReadByte("Minute");
            Second = decoder.ReadByte("Second");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            TimeType value = encodeable as TimeType;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_hour, value.m_hour)) return false;
            if (!Utils.IsEqual(m_minute, value.m_minute)) return false;
            if (!Utils.IsEqual(m_second, value.m_second)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (TimeType)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            TimeType clone = (TimeType)base.MemberwiseClone();

            clone.m_hour = (byte)Utils.Clone(this.m_hour);
            clone.m_minute = (byte)Utils.Clone(this.m_minute);
            clone.m_second = (byte)Utils.Clone(this.m_second);

            return clone;
        }
        #endregion

        #region Private Fields
        private byte m_hour;
        private byte m_minute;
        private byte m_second;
        #endregion
    }

    #region TimeTypeCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfTimeType", Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd, ItemName = "TimeType")]
    public partial class TimeTypeCollection : List<TimeType>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public TimeTypeCollection() {}

        /// <remarks />
        public TimeTypeCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public TimeTypeCollection(IEnumerable<TimeType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator TimeTypeCollection(TimeType[] values)
        {
            if (values != null)
            {
                return new TimeTypeCollection(values);
            }

            return new TimeTypeCollection();
        }

        /// <remarks />
        public static explicit operator TimeType[](TimeTypeCollection values)
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
            return (TimeTypeCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            TimeTypeCollection clone = new TimeTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((TimeType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion

    #region DailyScheduleType Class
    #if (!OPCUA_EXCLUDE_DailyScheduleType)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd)]
    public partial class DailyScheduleType : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public DailyScheduleType()
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
            m_daySchedule = new TimeActionsTypeCollection();
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "DaySchedule", IsRequired = false, Order = 1)]
        public TimeActionsTypeCollection DaySchedule
        {
            get
            {
                return m_daySchedule;
            }

            set
            {
                m_daySchedule = value;

                if (value == null)
                {
                    m_daySchedule = new TimeActionsTypeCollection();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId => DataTypeIds.DailyScheduleType; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.DailyScheduleType_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.DailyScheduleType_Encoding_DefaultXml;
                    
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => ObjectIds.DailyScheduleType_Encoding_DefaultJson; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            encoder.WriteEncodeableArray("DaySchedule", DaySchedule.ToArray(), typeof(TimeActionsType));

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd);

            DaySchedule = (TimeActionsTypeCollection)decoder.ReadEncodeableArray("DaySchedule", typeof(TimeActionsType));

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            DailyScheduleType value = encodeable as DailyScheduleType;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_daySchedule, value.m_daySchedule)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (DailyScheduleType)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            DailyScheduleType clone = (DailyScheduleType)base.MemberwiseClone();

            clone.m_daySchedule = (TimeActionsTypeCollection)Utils.Clone(this.m_daySchedule);

            return clone;
        }
        #endregion

        #region Private Fields
        private TimeActionsTypeCollection m_daySchedule;
        #endregion
    }

    #region DailyScheduleTypeCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfDailyScheduleType", Namespace = Opc.Ua.Scheduler.Namespaces.OpcUaSchedulerXsd, ItemName = "DailyScheduleType")]
    public partial class DailyScheduleTypeCollection : List<DailyScheduleType>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public DailyScheduleTypeCollection() {}

        /// <remarks />
        public DailyScheduleTypeCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public DailyScheduleTypeCollection(IEnumerable<DailyScheduleType> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator DailyScheduleTypeCollection(DailyScheduleType[] values)
        {
            if (values != null)
            {
                return new DailyScheduleTypeCollection(values);
            }

            return new DailyScheduleTypeCollection();
        }

        /// <remarks />
        public static explicit operator DailyScheduleType[](DailyScheduleTypeCollection values)
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
            return (DailyScheduleTypeCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            DailyScheduleTypeCollection clone = new DailyScheduleTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((DailyScheduleType)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion
}
