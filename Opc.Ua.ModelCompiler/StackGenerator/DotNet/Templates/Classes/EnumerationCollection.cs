// ***START***

#region _NAME_Collection Class
/// <summary>
/// A collection of _NAME_ objects.
/// </summary>
/// <exclude />
// _XMLARRAYTYPE_
public partial class _NAME_Collection : List<_NAME_>, ICloneable
{
    #region Constructors
    /// <summary>
    /// Initializes the collection with default values.
    /// </summary>
    public _NAME_Collection() {}

    /// <summary>
    /// Initializes the collection with an initial capacity.
    /// </summary>
    public _NAME_Collection(int capacity) : base(capacity) {}

    /// <summary>
    /// Initializes the collection with another collection.
    /// </summary>
    public _NAME_Collection(IEnumerable<_NAME_> collection) : base(collection) {}
    #endregion

    #region Static Operators
    /// <summary>
    /// Converts an array to a collection.
    /// </summary>
    public static implicit operator _NAME_Collection(_NAME_[] values)
    {
        if (values != null)
        {
            return new _NAME_Collection(values);
        }

        return new _NAME_Collection();
    }

    /// <summary>
    /// Converts an array to a collection.
    /// </summary>
    public static _NAME_Collection To_NAME_Collection(_NAME_[] values)
    {
        if (values != null)
        {
            return new _NAME_Collection(values);
        }

        return new _NAME_Collection();
    }

    /// <summary>
    /// Converts a collection to an array.
    /// </summary>
    public static explicit operator _NAME_[](_NAME_Collection values)
    {
        if (values != null)
        {
            return values.ToArray();
        }

        return null;
    }

    /// <summary>
    /// Converts a collection to an array.
    /// </summary>
    public static _NAME_[] From_NAME_Collection(_NAME_Collection values)
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
        return new _NAME_Collection(this);
    }
    #endregion
}
#endregion
// ***END***