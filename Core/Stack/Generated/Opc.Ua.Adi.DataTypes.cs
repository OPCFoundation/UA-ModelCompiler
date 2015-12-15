/* ========================================================================
 * Copyright (c) 2005-2011 The OPC Foundation, Inc. All rights reserved.
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
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua.Di;
using Opc.Ua;

namespace Opc.Ua.Adi
{
    #region ExecutionCycleEnumeration Enumeration
    #if (!OPCUA_EXCLUDE_ExecutionCycleEnumeration)
    /// <summary>
    /// A description for the ExecutionCycleEnumeration DataType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Adi.Namespaces.OpcUaAdiXsd)]
    public enum ExecutionCycleEnumeration
    {
        /// <summary>
        /// Idle, no cleaning or acquisition cycle in progress
        /// </summary>
        [EnumMember(Value = "IDLE_0")]
        IDLE = 0,

        /// <summary>
        /// Scquisition cycle collecting data for diagnostic purpose
        /// </summary>
        [EnumMember(Value = "DIAGNOSTIC_1")]
        DIAGNOSTIC = 1,

        /// <summary>
        /// Cleaning cycle
        /// </summary>
        [EnumMember(Value = "CLEANING_2")]
        CLEANING = 2,

        /// <summary>
        /// Calibration acquisition cycle
        /// </summary>
        [EnumMember(Value = "CALIBRATION_4")]
        CALIBRATION = 4,

        /// <summary>
        /// Validation acquisition cycle
        /// </summary>
        [EnumMember(Value = "VALIDATION_8")]
        VALIDATION = 8,

        /// <summary>
        /// Sample acquisition cycle
        /// </summary>
        [EnumMember(Value = "SAMPLING_16")]
        SAMPLING = 16,

        /// <summary>
        /// Scquisition cycle collecting data for diagnostic purpose and sample is extracted from the process to be sent in control lab
        /// </summary>
        [EnumMember(Value = "DIAGNOSTIC_WITH_GRAB_SAMPLE_32769")]
        DIAGNOSTIC_WITH_GRAB_SAMPLE = 32769,

        /// <summary>
        /// Cleaning cycle with or without acquisition and sample is extracted from the process to be sent in control lab
        /// </summary>
        [EnumMember(Value = "CLEANING_WITH_GRAB_SAMPLE_32770")]
        CLEANING_WITH_GRAB_SAMPLE = 32770,

        /// <summary>
        /// Calibration acquisition cycle and sample is extracted from the process to be sent in control lab
        /// </summary>
        [EnumMember(Value = "CALIBRATION_WITH_GRAB_SAMPLE_32772")]
        CALIBRATION_WITH_GRAB_SAMPLE = 32772,

        /// <summary>
        /// Validation acquisition cycle and sample is extracted from the process to be sent in control lab
        /// </summary>
        [EnumMember(Value = "VALIDATION_WITH_GRAB_SAMPLE_32776")]
        VALIDATION_WITH_GRAB_SAMPLE = 32776,

        /// <summary>
        /// Sample acquisition cycle and sample is extracted from the process to be sent in control lab
        /// </summary>
        [EnumMember(Value = "SAMPLING_WITH_GRAB_SAMPLE_32784")]
        SAMPLING_WITH_GRAB_SAMPLE = 32784,
    }

    #region ExecutionCycleEnumerationCollection Class
    /// <summary>
    /// A collection of ExecutionCycleEnumeration objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfExecutionCycleEnumeration", Namespace = Opc.Ua.Adi.Namespaces.OpcUaAdiXsd, ItemName = "ExecutionCycleEnumeration")]
    public partial class ExecutionCycleEnumerationCollection : List<ExecutionCycleEnumeration>, ICloneable
    {
    	#region Constructors
    	/// <summary>
    	/// Initializes the collection with default values.
    	/// </summary>
    	public ExecutionCycleEnumerationCollection() {}
    	
    	/// <summary>
    	/// Initializes the collection with an initial capacity.
    	/// </summary>
    	public ExecutionCycleEnumerationCollection(int capacity) : base(capacity) {}
    	
    	/// <summary>
    	/// Initializes the collection with another collection.
    	/// </summary>
    	public ExecutionCycleEnumerationCollection(IEnumerable<ExecutionCycleEnumeration> collection) : base(collection) {}
    	#endregion
                    
        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator ExecutionCycleEnumerationCollection(ExecutionCycleEnumeration[] values)
        {
            if (values != null)
            {
                return new ExecutionCycleEnumerationCollection(values);
            }

            return new ExecutionCycleEnumerationCollection();
        }
        
        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator ExecutionCycleEnumeration[](ExecutionCycleEnumerationCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            ExecutionCycleEnumerationCollection clone = new ExecutionCycleEnumerationCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((ExecutionCycleEnumeration)Utils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion
    #endif
    #endregion

    #region DiagnosticStatusEnumeration Enumeration
    #if (!OPCUA_EXCLUDE_DiagnosticStatusEnumeration)
    /// <summary>
    /// A description for the DiagnosticStatusEnumeration DataType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Adi.Namespaces.OpcUaAdiXsd)]
    public enum DiagnosticStatusEnumeration
    {
        /// <summary>
        /// This element is working correctly.
        /// </summary>
        [EnumMember(Value = "NORMAL_0")]
        NORMAL = 0,

        /// <summary>
        /// This element is working, but a maintenance operation is required.
        /// </summary>
        [EnumMember(Value = "MAINTENANCE_REQUIRED_1")]
        MAINTENANCE_REQUIRED = 1,

        /// <summary>
        /// This element does not work correctly, an immediate action is required.
        /// </summary>
        [EnumMember(Value = "FAULT_2")]
        FAULT = 2,
    }

    #region DiagnosticStatusEnumerationCollection Class
    /// <summary>
    /// A collection of DiagnosticStatusEnumeration objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfDiagnosticStatusEnumeration", Namespace = Opc.Ua.Adi.Namespaces.OpcUaAdiXsd, ItemName = "DiagnosticStatusEnumeration")]
    public partial class DiagnosticStatusEnumerationCollection : List<DiagnosticStatusEnumeration>, ICloneable
    {
    	#region Constructors
    	/// <summary>
    	/// Initializes the collection with default values.
    	/// </summary>
    	public DiagnosticStatusEnumerationCollection() {}
    	
    	/// <summary>
    	/// Initializes the collection with an initial capacity.
    	/// </summary>
    	public DiagnosticStatusEnumerationCollection(int capacity) : base(capacity) {}
    	
    	/// <summary>
    	/// Initializes the collection with another collection.
    	/// </summary>
    	public DiagnosticStatusEnumerationCollection(IEnumerable<DiagnosticStatusEnumeration> collection) : base(collection) {}
    	#endregion
                    
        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator DiagnosticStatusEnumerationCollection(DiagnosticStatusEnumeration[] values)
        {
            if (values != null)
            {
                return new DiagnosticStatusEnumerationCollection(values);
            }

            return new DiagnosticStatusEnumerationCollection();
        }
        
        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator DiagnosticStatusEnumeration[](DiagnosticStatusEnumerationCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            DiagnosticStatusEnumerationCollection clone = new DiagnosticStatusEnumerationCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((DiagnosticStatusEnumeration)Utils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion
    #endif
    #endregion

    #region AcquisitionResultStatusEnumeration Enumeration
    #if (!OPCUA_EXCLUDE_AcquisitionResultStatusEnumeration)
    /// <summary>
    /// A description for the AcquisitionResultStatusEnumeration DataType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Adi.Namespaces.OpcUaAdiXsd)]
    public enum AcquisitionResultStatusEnumeration
    {
        /// <summary>
        /// The acquisition is in progress, nothing can be said about its quality.
        /// </summary>
        [EnumMember(Value = "IN_PROGRESS_0")]
        IN_PROGRESS = 0,

        /// <summary>
        /// The acquisition has been completed as requested without any error.
        /// </summary>
        [EnumMember(Value = "GOOD_1")]
        GOOD = 1,

        /// <summary>
        /// The acquisition has been completed as requested with error.
        /// </summary>
        [EnumMember(Value = "BAD_2")]
        BAD = 2,

        /// <summary>
        /// The acquisition has been completed but nothing can be said about the quality of the result.
        /// </summary>
        [EnumMember(Value = "UNKNOWN_3")]
        UNKNOWN = 3,

        /// <summary>
        /// The acquisition has been partially completed as requested without any error.
        /// </summary>
        [EnumMember(Value = "PARTIAL_4")]
        PARTIAL = 4,
    }

    #region AcquisitionResultStatusEnumerationCollection Class
    /// <summary>
    /// A collection of AcquisitionResultStatusEnumeration objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfAcquisitionResultStatusEnumeration", Namespace = Opc.Ua.Adi.Namespaces.OpcUaAdiXsd, ItemName = "AcquisitionResultStatusEnumeration")]
    public partial class AcquisitionResultStatusEnumerationCollection : List<AcquisitionResultStatusEnumeration>, ICloneable
    {
    	#region Constructors
    	/// <summary>
    	/// Initializes the collection with default values.
    	/// </summary>
    	public AcquisitionResultStatusEnumerationCollection() {}
    	
    	/// <summary>
    	/// Initializes the collection with an initial capacity.
    	/// </summary>
    	public AcquisitionResultStatusEnumerationCollection(int capacity) : base(capacity) {}
    	
    	/// <summary>
    	/// Initializes the collection with another collection.
    	/// </summary>
    	public AcquisitionResultStatusEnumerationCollection(IEnumerable<AcquisitionResultStatusEnumeration> collection) : base(collection) {}
    	#endregion
                    
        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator AcquisitionResultStatusEnumerationCollection(AcquisitionResultStatusEnumeration[] values)
        {
            if (values != null)
            {
                return new AcquisitionResultStatusEnumerationCollection(values);
            }

            return new AcquisitionResultStatusEnumerationCollection();
        }
        
        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator AcquisitionResultStatusEnumeration[](AcquisitionResultStatusEnumerationCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            AcquisitionResultStatusEnumerationCollection clone = new AcquisitionResultStatusEnumerationCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((AcquisitionResultStatusEnumeration)Utils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion
    #endif
    #endregion

    #region AxisInformation Class
    #if (!OPCUA_EXCLUDE_AxisInformation)
    /// <summary>
    /// Structure defining the information for auxiliary axis for array type variables.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Adi.Namespaces.OpcUaAdiXsd)]
    public partial class AxisInformation : IEncodeable
    {
    	#region Constructors
    	/// <summary>
    	/// The default constructor.
    	/// </summary>
    	public AxisInformation()
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
    		m_engineeringUnits = new EUInformation();
    		m_eURange = new Range();
    		m_title = null;
    		m_axisScaleType = AxisScaleEnumeration.LINEAR;
    		m_axisSteps = new DoubleCollection();
    	}
    	#endregion

    	#region Public Properties
    	/// <summary>
    	/// Holds the information about the engineering units for a given axis.
    	/// </summary>
    	[DataMember(Name = "EngineeringUnits", IsRequired = false, Order = 1)]
    	public EUInformation EngineeringUnits
    	{
    		get 
    	    { 
    	        return m_engineeringUnits;  
    	    }
    		
    	    set 
    	    { 
    	        m_engineeringUnits = value; 

    	        if (value == null)
    	        {
    	            m_engineeringUnits = new EUInformation();
    	        }
    	    }
    	}

    	/// <summary>
    	/// Limits of the range of the axis
    	/// </summary>
    	[DataMember(Name = "EURange", IsRequired = false, Order = 2)]
    	public Range EURange
    	{
    		get 
    	    { 
    	        return m_eURange;  
    	    }
    		
    	    set 
    	    { 
    	        m_eURange = value; 

    	        if (value == null)
    	        {
    	            m_eURange = new Range();
    	        }
    	    }
    	}

    	/// <summary>
    	/// User readable axis title, useful when the units are %, the Title may be “Particle size distribution”
    	/// </summary>
    	[DataMember(Name = "title", IsRequired = false, Order = 3)]
    	public LocalizedText title
    	{
    		get { return m_title;  }
    		set { m_title = value; }
    	}

    	/// <summary>
    	/// Linear, log, ln, defined by AxisSteps
    	/// </summary>
    	[DataMember(Name = "axisScaleType", IsRequired = false, Order = 4)]
    	public AxisScaleEnumeration axisScaleType
    	{
    		get { return m_axisScaleType;  }
    		set { m_axisScaleType = value; }
    	}

    	/// <summary>
    	/// Specific value of each axis steps, may be set to “Null” if not used
    	/// </summary>
    	[DataMember(Name = "axisSteps", IsRequired = false, Order = 5)]
    	public DoubleCollection axisSteps
    	{
    		get 
    	    { 
    	        return m_axisSteps;  
    	    }
    		
    	    set 
    	    { 
    	        m_axisSteps = value; 

    	        if (value == null)
    	        {
    	            m_axisSteps = new DoubleCollection();
    	        }
    	    }
    	}
    	#endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId
        {
            get { return DataTypeIds.AxisInformation; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.AxisInformation_Encoding_DefaultBinary; }
        }
        
        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.AxisInformation_Encoding_DefaultXml; }
        }
        
        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.Adi.Namespaces.OpcUaAdiXsd);

            encoder.WriteEncodeable("EngineeringUnits", EngineeringUnits, typeof(EUInformation));
            encoder.WriteEncodeable("EURange", EURange, typeof(Range));
            encoder.WriteLocalizedText("title", title);
            encoder.WriteEnumerated("axisScaleType", axisScaleType);
            encoder.WriteDoubleArray("axisSteps", axisSteps);

            encoder.PopNamespace();
        }
        
        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.Adi.Namespaces.OpcUaAdiXsd);

            EngineeringUnits = (EUInformation)decoder.ReadEncodeable("EngineeringUnits", typeof(EUInformation));
            EURange = (Range)decoder.ReadEncodeable("EURange", typeof(Range));
            title = decoder.ReadLocalizedText("title");
            axisScaleType = (AxisScaleEnumeration)decoder.ReadEnumerated("axisScaleType", typeof(AxisScaleEnumeration));
            axisSteps = decoder.ReadDoubleArray("axisSteps");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }
            
            AxisInformation value = encodeable as AxisInformation;
            
            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_engineeringUnits, value.m_engineeringUnits)) return false;
            if (!Utils.IsEqual(m_eURange, value.m_eURange)) return false;
            if (!Utils.IsEqual(m_title, value.m_title)) return false;
            if (!Utils.IsEqual(m_axisScaleType, value.m_axisScaleType)) return false;
            if (!Utils.IsEqual(m_axisSteps, value.m_axisSteps)) return false;

            return true;
        }
        
        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            AxisInformation clone = (AxisInformation)this.MemberwiseClone();

            clone.m_engineeringUnits = (EUInformation)Utils.Clone(this.m_engineeringUnits);
            clone.m_eURange = (Range)Utils.Clone(this.m_eURange);
            clone.m_title = (LocalizedText)Utils.Clone(this.m_title);
            clone.m_axisScaleType = (AxisScaleEnumeration)Utils.Clone(this.m_axisScaleType);
            clone.m_axisSteps = (DoubleCollection)Utils.Clone(this.m_axisSteps);

            return clone;
        }
        #endregion
        
    	#region Private Fields
    	private EUInformation m_engineeringUnits;
    	private Range m_eURange;
    	private LocalizedText m_title;
    	private AxisScaleEnumeration m_axisScaleType;
    	private DoubleCollection m_axisSteps;
    	#endregion
    }

    #region AxisInformationCollection Class
    /// <summary>
    /// A collection of AxisInformation objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfAxisInformation", Namespace = Opc.Ua.Adi.Namespaces.OpcUaAdiXsd, ItemName = "AxisInformation")]
    public partial class AxisInformationCollection : List<AxisInformation>, ICloneable
    {
    	#region Constructors
    	/// <summary>
    	/// Initializes the collection with default values.
    	/// </summary>
    	public AxisInformationCollection() {}
    	
    	/// <summary>
    	/// Initializes the collection with an initial capacity.
    	/// </summary>
    	public AxisInformationCollection(int capacity) : base(capacity) {}
    	
    	/// <summary>
    	/// Initializes the collection with another collection.
    	/// </summary>
    	public AxisInformationCollection(IEnumerable<AxisInformation> collection) : base(collection) {}
    	#endregion
                    
        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator AxisInformationCollection(AxisInformation[] values)
        {
            if (values != null)
            {
                return new AxisInformationCollection(values);
            }

            return new AxisInformationCollection();
        }
        
        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator AxisInformation[](AxisInformationCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            AxisInformationCollection clone = new AxisInformationCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((AxisInformation)Utils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion
    #endif
    #endregion

    #region AxisScaleEnumeration Enumeration
    #if (!OPCUA_EXCLUDE_AxisScaleEnumeration)
    /// <summary>
    /// Identify on which type of axis the data shall be displayed.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Adi.Namespaces.OpcUaAdiXsd)]
    public enum AxisScaleEnumeration
    {
        /// <summary>
        /// Linear scale
        /// </summary>
        [EnumMember(Value = "LINEAR_0")]
        LINEAR = 0,

        /// <summary>
        /// Log base 10 scale
        /// </summary>
        [EnumMember(Value = "LOG_1")]
        LOG = 1,

        /// <summary>
        /// Log base e scale
        /// </summary>
        [EnumMember(Value = "LN_2")]
        LN = 2,
    }
    #endif
    #endregion

    #region XVType Class
    #if (!OPCUA_EXCLUDE_XVType)
    /// <summary>
    /// Structure defining XY value like a list of peaks.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Adi.Namespaces.OpcUaAdiXsd)]
    public partial class XVType : IEncodeable
    {
    	#region Constructors
    	/// <summary>
    	/// The default constructor.
    	/// </summary>
    	public XVType()
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
    		m_value = (float)0;
    	}
    	#endregion

    	#region Public Properties
    	/// <summary>
    	/// Position on the X axis this value
    	/// </summary>
    	[DataMember(Name = "x", IsRequired = false, Order = 1)]
    	public double x
    	{
    		get { return m_x;  }
    		set { m_x = value; }
    	}

    	/// <summary>
    	/// The value itself
    	/// </summary>
    	[DataMember(Name = "value", IsRequired = false, Order = 2)]
    	public float value
    	{
    		get { return m_value;  }
    		set { m_value = value; }
    	}
    	#endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId
        {
            get { return DataTypeIds.XVType; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.XVType_Encoding_DefaultBinary; }
        }
        
        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.XVType_Encoding_DefaultXml; }
        }
        
        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.Adi.Namespaces.OpcUaAdiXsd);

            encoder.WriteDouble("x", x);
            encoder.WriteFloat("value", value);

            encoder.PopNamespace();
        }
        
        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.Adi.Namespaces.OpcUaAdiXsd);

            x = decoder.ReadDouble("x");
            value = decoder.ReadFloat("value");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }
            
            XVType value = encodeable as XVType;
            
            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_x, value.m_x)) return false;
            if (!Utils.IsEqual(m_value, value.m_value)) return false;

            return true;
        }
        
        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            XVType clone = (XVType)this.MemberwiseClone();

            clone.m_x = (double)Utils.Clone(this.m_x);
            clone.m_value = (float)Utils.Clone(this.m_value);

            return clone;
        }
        #endregion
        
    	#region Private Fields
    	private double m_x;
    	private float m_value;
    	#endregion
    }

    #region XVTypeCollection Class
    /// <summary>
    /// A collection of XVType objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfXVType", Namespace = Opc.Ua.Adi.Namespaces.OpcUaAdiXsd, ItemName = "XVType")]
    public partial class XVTypeCollection : List<XVType>, ICloneable
    {
    	#region Constructors
    	/// <summary>
    	/// Initializes the collection with default values.
    	/// </summary>
    	public XVTypeCollection() {}
    	
    	/// <summary>
    	/// Initializes the collection with an initial capacity.
    	/// </summary>
    	public XVTypeCollection(int capacity) : base(capacity) {}
    	
    	/// <summary>
    	/// Initializes the collection with another collection.
    	/// </summary>
    	public XVTypeCollection(IEnumerable<XVType> collection) : base(collection) {}
    	#endregion
                    
        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator XVTypeCollection(XVType[] values)
        {
            if (values != null)
            {
                return new XVTypeCollection(values);
            }

            return new XVTypeCollection();
        }
        
        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator XVType[](XVTypeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            XVTypeCollection clone = new XVTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((XVType)Utils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion
    #endif
    #endregion

    #region ComplexType Class
    #if (!OPCUA_EXCLUDE_ComplexType)
    /// <summary>
    /// Structure defining double IEEE 32 bits complex value
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Adi.Namespaces.OpcUaAdiXsd)]
    public partial class ComplexType : IEncodeable
    {
    	#region Constructors
    	/// <summary>
    	/// The default constructor.
    	/// </summary>
    	public ComplexType()
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
    		m_real = (float)0;
    		m_imaginary = (float)0;
    	}
    	#endregion

    	#region Public Properties
    	/// <summary>
    	/// Value real part
    	/// </summary>
    	[DataMember(Name = "Real", IsRequired = false, Order = 1)]
    	public float Real
    	{
    		get { return m_real;  }
    		set { m_real = value; }
    	}

    	/// <summary>
    	/// Value imaginary  part
    	/// </summary>
    	[DataMember(Name = "Imaginary", IsRequired = false, Order = 2)]
    	public float Imaginary
    	{
    		get { return m_imaginary;  }
    		set { m_imaginary = value; }
    	}
    	#endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId
        {
            get { return DataTypeIds.ComplexType; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.ComplexType_Encoding_DefaultBinary; }
        }
        
        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.ComplexType_Encoding_DefaultXml; }
        }
        
        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.Adi.Namespaces.OpcUaAdiXsd);

            encoder.WriteFloat("Real", Real);
            encoder.WriteFloat("Imaginary", Imaginary);

            encoder.PopNamespace();
        }
        
        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.Adi.Namespaces.OpcUaAdiXsd);

            Real = decoder.ReadFloat("Real");
            Imaginary = decoder.ReadFloat("Imaginary");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }
            
            ComplexType value = encodeable as ComplexType;
            
            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_real, value.m_real)) return false;
            if (!Utils.IsEqual(m_imaginary, value.m_imaginary)) return false;

            return true;
        }
        
        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            ComplexType clone = (ComplexType)this.MemberwiseClone();

            clone.m_real = (float)Utils.Clone(this.m_real);
            clone.m_imaginary = (float)Utils.Clone(this.m_imaginary);

            return clone;
        }
        #endregion
        
    	#region Private Fields
    	private float m_real;
    	private float m_imaginary;
    	#endregion
    }

    #region ComplexTypeCollection Class
    /// <summary>
    /// A collection of ComplexType objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfComplexType", Namespace = Opc.Ua.Adi.Namespaces.OpcUaAdiXsd, ItemName = "ComplexType")]
    public partial class ComplexTypeCollection : List<ComplexType>, ICloneable
    {
    	#region Constructors
    	/// <summary>
    	/// Initializes the collection with default values.
    	/// </summary>
    	public ComplexTypeCollection() {}
    	
    	/// <summary>
    	/// Initializes the collection with an initial capacity.
    	/// </summary>
    	public ComplexTypeCollection(int capacity) : base(capacity) {}
    	
    	/// <summary>
    	/// Initializes the collection with another collection.
    	/// </summary>
    	public ComplexTypeCollection(IEnumerable<ComplexType> collection) : base(collection) {}
    	#endregion
                    
        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator ComplexTypeCollection(ComplexType[] values)
        {
            if (values != null)
            {
                return new ComplexTypeCollection(values);
            }

            return new ComplexTypeCollection();
        }
        
        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator ComplexType[](ComplexTypeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            ComplexTypeCollection clone = new ComplexTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((ComplexType)Utils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion
    #endif
    #endregion

    #region DoubleComplexType Class
    #if (!OPCUA_EXCLUDE_DoubleComplexType)
    /// <summary>
    /// Structure defining double IEEE 64 bits complex value
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Opc.Ua.Adi.Namespaces.OpcUaAdiXsd)]
    public partial class DoubleComplexType : IEncodeable
    {
    	#region Constructors
    	/// <summary>
    	/// The default constructor.
    	/// </summary>
    	public DoubleComplexType()
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
    		m_real = (double)0;
    		m_imaginary = (double)0;
    	}
    	#endregion

    	#region Public Properties
    	/// <summary>
    	/// Value real part
    	/// </summary>
    	[DataMember(Name = "Real", IsRequired = false, Order = 1)]
    	public double Real
    	{
    		get { return m_real;  }
    		set { m_real = value; }
    	}

    	/// <summary>
    	/// Value imaginary  part
    	/// </summary>
    	[DataMember(Name = "Imaginary", IsRequired = false, Order = 2)]
    	public double Imaginary
    	{
    		get { return m_imaginary;  }
    		set { m_imaginary = value; }
    	}
    	#endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId
        {
            get { return DataTypeIds.DoubleComplexType; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.DoubleComplexType_Encoding_DefaultBinary; }
        }
        
        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.DoubleComplexType_Encoding_DefaultXml; }
        }
        
        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Opc.Ua.Adi.Namespaces.OpcUaAdiXsd);

            encoder.WriteDouble("Real", Real);
            encoder.WriteDouble("Imaginary", Imaginary);

            encoder.PopNamespace();
        }
        
        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Opc.Ua.Adi.Namespaces.OpcUaAdiXsd);

            Real = decoder.ReadDouble("Real");
            Imaginary = decoder.ReadDouble("Imaginary");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }
            
            DoubleComplexType value = encodeable as DoubleComplexType;
            
            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_real, value.m_real)) return false;
            if (!Utils.IsEqual(m_imaginary, value.m_imaginary)) return false;

            return true;
        }
        
        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            DoubleComplexType clone = (DoubleComplexType)this.MemberwiseClone();

            clone.m_real = (double)Utils.Clone(this.m_real);
            clone.m_imaginary = (double)Utils.Clone(this.m_imaginary);

            return clone;
        }
        #endregion
        
    	#region Private Fields
    	private double m_real;
    	private double m_imaginary;
    	#endregion
    }

    #region DoubleComplexTypeCollection Class
    /// <summary>
    /// A collection of DoubleComplexType objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfDoubleComplexType", Namespace = Opc.Ua.Adi.Namespaces.OpcUaAdiXsd, ItemName = "DoubleComplexType")]
    public partial class DoubleComplexTypeCollection : List<DoubleComplexType>, ICloneable
    {
    	#region Constructors
    	/// <summary>
    	/// Initializes the collection with default values.
    	/// </summary>
    	public DoubleComplexTypeCollection() {}
    	
    	/// <summary>
    	/// Initializes the collection with an initial capacity.
    	/// </summary>
    	public DoubleComplexTypeCollection(int capacity) : base(capacity) {}
    	
    	/// <summary>
    	/// Initializes the collection with another collection.
    	/// </summary>
    	public DoubleComplexTypeCollection(IEnumerable<DoubleComplexType> collection) : base(collection) {}
    	#endregion
                    
        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator DoubleComplexTypeCollection(DoubleComplexType[] values)
        {
            if (values != null)
            {
                return new DoubleComplexTypeCollection(values);
            }

            return new DoubleComplexTypeCollection();
        }
        
        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator DoubleComplexType[](DoubleComplexTypeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            DoubleComplexTypeCollection clone = new DoubleComplexTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((DoubleComplexType)Utils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion
    #endif
    #endregion
}