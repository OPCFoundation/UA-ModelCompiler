using System;
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
public partial class _BrowseName_ : IEncodeable, IJsonEncodeable
{
    #region Constructors
    /// <remarks />
    public _BrowseName_()
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
        EncodingMask = _ClassName_Fields.None;
        // ListOfFieldInitializers
    }
    #endregion

    #region Public Properties
    // <remarks />
    [DataMember(Name = "EncodingMask", IsRequired = true, Order = 0)]
    public _ClassName_Fields EncodingMask { get; set; }

    // ListOfProperties
    #endregion

    #region IEncodeable Members
    /// <summary cref="IEncodeable.TypeId" />
    public virtual ExpandedNodeId TypeId => DataTypeIds._BrowseName_; 

    /// <summary cref="IEncodeable.BinaryEncodingId" />
    public virtual ExpandedNodeId BinaryEncodingId => ObjectIds._BrowseName__Encoding_DefaultBinary;

    /// <summary cref="IEncodeable.XmlEncodingId" />
    public virtual ExpandedNodeId XmlEncodingId => ObjectIds._BrowseName__Encoding_DefaultXml;
        
    /// <summary cref="IJsonEncodeable.JsonEncodingId" />
    public virtual ExpandedNodeId JsonEncodingId => ObjectIds._BrowseName__Encoding_DefaultJson; 

    /// <summary cref="IEncodeable.Encode(IEncoder)" />
    public virtual void Encode(IEncoder encoder)
    {
        encoder.PushNamespace(_XmlNamespaceUri_);
        encoder.WriteUInt32(nameof(EncodingMask), (uint)EncodingMask);

        // ListOfEncodedFields

        encoder.PopNamespace();
    }

    /// <summary cref="IEncodeable.Decode(IDecoder)" />
    public virtual void Decode(IDecoder decoder)
    {
        decoder.PushNamespace(_XmlNamespaceUri_);

        EncodingMask = (_ClassName_Fields)decoder.ReadUInt32(nameof(EncodingMask));

        // ListOfDecodedFields

        decoder.PopNamespace();
    }

    /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
    public virtual bool IsEqual(IEncodeable encodeable)
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

        if (value.EncodingMask != this.EncodingMask) return false;

        // ListOfComparedFields

        return true;
    }

    /// <summary cref="ICloneable.Clone" />
    public virtual object Clone()
    {
        return (_BrowseName_)this.MemberwiseClone();
    }

    /// <summary cref="Object.MemberwiseClone" />
    public new object MemberwiseClone()
    {
        _BrowseName_ clone = (_BrowseName_)base.MemberwiseClone();

        clone.EncodingMask = this.EncodingMask;

        // ListOfClonedFields

        return clone;
    }
    #endregion

    #region Private Fields
    // ListOfFields
    #endregion
}
// CollectionClass
#endif
#endregion
// ***END***
}