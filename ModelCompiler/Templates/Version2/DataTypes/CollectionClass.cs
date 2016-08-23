// ***START***
#region _BrowseName_Collection Class
/// <summary>
/// A collection of _BrowseName_ objects.
/// </summary>
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOf_BrowseName_", Namespace = _XmlNamespaceUri_, ItemName = "_BrowseName_")]
#if !NET_STANDARD
public partial class _BrowseName_Collection : List<_BrowseName_>, ICloneable
#else
public partial class _BrowseName_Collection : List<_BrowseName_>
#endif
{
    #region Constructors
    /// <summary>
    /// Initializes the collection with default values.
    /// </summary>
    public _BrowseName_Collection() {}

    /// <summary>
    /// Initializes the collection with an initial capacity.
    /// </summary>
    public _BrowseName_Collection(int capacity) : base(capacity) {}

    /// <summary>
    /// Initializes the collection with another collection.
    /// </summary>
    public _BrowseName_Collection(IEnumerable<_BrowseName_> collection) : base(collection) {}
    #endregion

    #region Static Operators
    /// <summary>
    /// Converts an array to a collection.
    /// </summary>
    public static implicit operator _BrowseName_Collection(_BrowseName_[] values)
    {
        if (values != null)
        {
            return new _BrowseName_Collection(values);
        }

        return new _BrowseName_Collection();
    }

    /// <summary>
    /// Converts a collection to an array.
    /// </summary>
    public static explicit operator _BrowseName_[](_BrowseName_Collection values)
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
        return (_BrowseName_Collection)this.MemberwiseClone();
    }
    #endregion
    #endif

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