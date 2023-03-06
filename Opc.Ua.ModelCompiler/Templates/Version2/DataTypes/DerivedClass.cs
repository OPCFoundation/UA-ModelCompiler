namespace X {
// ***START***
#region _BrowseName_ Class
#if (!OPCUA_EXCLUDE__BrowseName_)
/// <remarks />
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = _XmlNamespaceUri_)]
public partial class _BrowseName_ : _BaseType_
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
        // ListOfFieldInitializers
    }
    #endregion

    #region Public Properties
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
        base.Encode(encoder);

        encoder.PushNamespace(_XmlNamespaceUri_);

        // ListOfEncodedFields

        encoder.PopNamespace();
    }

    /// <summary cref="IEncodeable.Decode(IDecoder)" />
    public override void Decode(IDecoder decoder)
    {
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
    #endregion
}
// CollectionClass
#endif
#endregion
// ***END***
}