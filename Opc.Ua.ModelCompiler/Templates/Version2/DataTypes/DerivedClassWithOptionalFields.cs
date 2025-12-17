using System;
using System.Linq;
using System.Security.AccessControl;

namespace X {
// ***START***
#region _BrowseName_ Class
#if (!OPCUA_EXCLUDE__BrowseName_)
/// <exclude />
[Flags]
public enum _ClassName_Fields : uint
{
    None = 0,
    // ListOfEncodingMaskFields
}

/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
[DataContract(Namespace = _XmlNamespaceUri_)]
public partial class _BrowseName_ : _BaseType_
{
    #region Constructors
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
        // ListOfFieldInitializers
    }
    #endregion

    #region Public Properties
    // EncodingMaskProperty
    // ListOfProperties
    #endregion

    #region IEncodeable Members
    /// <summary cref="IEncodeable.TypeId" />
    public override ExpandedNodeId TypeId => DataTypeIds._BrowseName_;

    /// <summary cref="IEncodeable.BinaryEncodingId" />
    public override ExpandedNodeId BinaryEncodingId => ObjectIds._BrowseName__Encoding_DefaultBinary;

    /// <summary cref="IEncodeable.XmlEncodingId" />
    public override ExpandedNodeId XmlEncodingId => ObjectIds._BrowseName__Encoding_DefaultXml;

    /// <summary cref="IJsonEncodeable.JsonEncodingId" />
    public override ExpandedNodeId JsonEncodingId => ObjectIds._BrowseName__Encoding_DefaultJson;

    /// <summary cref="IEncodeable.Encode(IEncoder)" />
    public override void Encode(IEncoder encoder)
    {
        encoder.PushNamespace(_XmlNamespaceUri_);
        encoder.WriteEncodingMask((uint)EncodingMask);
        encoder.PopNamespace();

        base.Encode(encoder);

        encoder.PushNamespace(_XmlNamespaceUri_);

        // ListOfEncodedFields

        encoder.PopNamespace();
    }

    /// <summary cref="IEncodeable.Decode(IDecoder)" />
    public override void Decode(IDecoder decoder)
    {
        decoder.PushNamespace(_XmlNamespaceUri_);
        EncodingMask = decoder.ReadEncodingMask(m_FieldNames);
        decoder.PopNamespace();
            
        base.Decode(decoder);

        decoder.PushNamespace(_XmlNamespaceUri_);

        // ListOfDecodedFields

        decoder.PopNamespace();
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

        if (value.EncodingMask != this.EncodingMask) return false;

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
            
        clone.EncodingMask = this.EncodingMask;
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