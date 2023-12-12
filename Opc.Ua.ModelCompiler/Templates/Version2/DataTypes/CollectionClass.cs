// ***START***
#region _BrowseName_Collection Class
/// <remarks />
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOf_BrowseName_", Namespace = _XmlNamespaceUri_, ItemName = "_BrowseName_")]
public partial class _BrowseName_Collection : List<_BrowseName_>, ICloneable
{
    #region Constructors
    /// <remarks />
    public _BrowseName_Collection() {}

    /// <remarks />
    public _BrowseName_Collection(int capacity) : base(capacity) {}

    /// <remarks />
    public _BrowseName_Collection(IEnumerable<_BrowseName_> collection) : base(collection) {}
    #endregion

    #region Static Operators
    /// <remarks />
    public static implicit operator _BrowseName_Collection(_BrowseName_[] values)
    {
        if (values != null)
        {
            return new _BrowseName_Collection(values);
        }

        return new _BrowseName_Collection();
    }

    /// <remarks />
    public static explicit operator _BrowseName_[](_BrowseName_Collection values)
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
        return (_BrowseName_Collection)this.MemberwiseClone();
    }
    #endregion

    /// <summary cref="Object.MemberwiseClone" />
    public new object MemberwiseClone()
    {
        _BrowseName_Collection clone = new _BrowseName_Collection(this.Count);

        for (int ii = 0; ii < this.Count; ii++)
        {
            clone.Add((_BrowseName_)Utils.Clone(this[ii]));
        }

        return clone;
    }
}
#endregion
// ***END***