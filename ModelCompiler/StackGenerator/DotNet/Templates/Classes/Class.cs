// ***START***
#region _NAME_ Class
#if (!OPCUA_EXCLUDE__NAME_)
/// <summary>
/// The _NAME_ class.
/// </summary>
/// <exclude />
// _XMLTYPE_
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
public partial class _NAME_ : _BASETYPE_
{
    #region Constructors
    /// <summary>
    /// The default constructor.
    /// </summary>
    public _NAME_()
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
        // _DEFAULTLIST_
    }
    #endregion

    #region Public Properties
    // _PROPERTYLIST_
    #endregion

    #region IEncodeable Members
    /// <summary cref="IEncodeable.TypeId" />
    public override ExpandedNodeId TypeId
    {
        get { return m_TypeId; }
    }

    private static ExpandedNodeId m_TypeId = new ExpandedNodeId(DataTypes._NAME_);

    /// <summary cref="IEncodeable.BinaryEncodingId" />
    public override ExpandedNodeId BinaryEncodingId
    {
        get { return m_BinaryEncodingId; }
    }

    private static ExpandedNodeId m_BinaryEncodingId = new ExpandedNodeId(Objects._NAME__Encoding_DefaultBinary);

    /// <summary cref="IEncodeable.XmlEncodingId" />
    public override ExpandedNodeId XmlEncodingId
    {
        get { return m_XmlEncodingId; }
    }

    private static ExpandedNodeId m_XmlEncodingId = new ExpandedNodeId(Objects._NAME__Encoding_DefaultXml);

    /// <summary cref="IEncodeable.Encode(IEncoder)" />
    public override void Encode(IEncoder encoder)
    {
        base.Encode(encoder);

        encoder.PushNamespace(Namespaces._TypesNamespace_);
        // _ENCODELIST_
        encoder.PopNamespace();
    }

    /// <summary cref="IEncodeable.Decode(IDecoder)" />
    public override void Decode(IDecoder decoder)
    {
        base.Decode(decoder);

        decoder.PushNamespace(Namespaces._TypesNamespace_);
        // _DECODELIST_
        decoder.PopNamespace();
    }

    /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
    public override bool IsEqual(IEncodeable encodeable)
    {
        if (Object.ReferenceEquals(this, encodeable))
        {
            return true;
        }

        _NAME_ value = encodeable as _NAME_;

        if (value == null)
        {
            return false;
        }

        if (typeof(_NAME_).BaseType != typeof(object))
        {
            if (!base.IsEqual(encodeable))
            {
                return false;
            }
        }

        // _ISEQUALLIST_

        return true;
    }

    /// <summary cref="ICloneable.Clone" />
    public override object Clone()
    {
        _NAME_ clone = (_NAME_)base.Clone();
        // _CLONELIST_
        return clone;
    }
    #endregion

    #region Private Fields
    // _MEMBERLIST_
    #endregion
}
// _COLLECTIONCLASS_
#endif
#endregion
// ***END***