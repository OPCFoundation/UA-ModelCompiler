using System;
using System.Linq;
using System.Security.AccessControl;

namespace X {
// ***START***
#region _BrowseName_ Class
#if (!OPCUA_EXCLUDE__BrowseName_)
/// <remarks />
/// <exclude />
[Flags]
public enum _ClassName_Fields : uint
{   
    None = 0,
    // ListOfEncodingMaskFields
}

/// <remarks />
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = _XmlNamespaceUri_)]
public partial class _BrowseName_ : _BaseType_
{
    #region Constructors
    
    public _BrowseName_() : this(
        DataTypeIds._BrowseName_, 
        ObjectIds._BrowseName__Encoding_DefaultBinary, 
        ObjectIds._BrowseName__Encoding_DefaultXml, 
        ObjectIds._BrowseName__Encoding_DefaultJson)
    {
    }

    /// <remarks />
    protected _BrowseName_(ExpandedNodeId typeId, ExpandedNodeId binaryEncodingId, ExpandedNodeId xmlEncodingId, ExpandedNodeId jsonEncodingId)
        : base(typeId, binaryEncodingId, xmlEncodingId, jsonEncodingId) 
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
        // ListOfFieldInitializers
    }
    #endregion

    #region Public Properties
    // EncodingMaskProperty
    // ListOfProperties
    #endregion

    #region Overridden Members

    /// <summary cref="_BaseType_.OnWriteEncodingMask(IEncoder)" />
    protected override void OnWriteEncodingMask(IEncoder encoder)
    {
        encoder.WriteUInt32(nameof(EncodingMask), (uint)EncodingMask);
    }
        
    /// <summary cref="_BaseType_.OnEncodeFields(IEncoder)" />
    protected override void OnEncodeFields(IEncoder encoder)
    {
        base.OnEncodeFields(encoder);
        // ListOfEncodedFields
    }

    protected override void OnReadEncodingMask(IDecoder decoder) 
    {
        EncodingMask = decoder.ReadUInt32(nameof(EncodingMask));
    }

    protected override void OnDecodeFields(IDecoder decoder)
    {
        base.OnDecodeFields(decoder);
        // ListOfDecodedFields
    }

    /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
    public override bool IsEqual(IEncodeable encodeable)
    {
        if (Object.ReferenceEquals(this, encodeable))
        {
            return true;
        }

        _BrowseName_ value = encodeable as _BrowseName_;

        if (value == null)
        {
            return false;
        }

        // ListOfComparedFields
        
        return base.IsEqual(encodeable);
    }

    /// <summary cref="ICloneable.Clone" />
    public override object Clone()
    {
        return (_BrowseName_)this.MemberwiseClone();
    }

    /// <summary cref="Object.MemberwiseClone" />
    public new object MemberwiseClone()
    {
        _BrowseName_ clone = (_BrowseName_)base.MemberwiseClone();

        // ListOfClonedFields

        return clone;
    }
    #endregion

    #region Private Fields
    // ListOfFields

    private static readonly string[] m_FieldNames = Enum.GetNames(typeof(_ClassName_Fields)).Where(x => x != nameof(_ClassName_Fields.None)).ToArray();
    #endregion
}
// CollectionClass
#endif
#endregion
// ***END***
}