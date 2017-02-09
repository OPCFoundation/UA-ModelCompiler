#region _TypeName_State<T> Class
/// <summary>
/// A typed version of the _BrowseName_ variable type.
/// </summary>
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
public class _TypeName_State<T> : _TypeName_State
{
    #region Constructors
    /// <summary>
    /// Initializes the instance with its defalt attribute values.
    /// </summary>
    public _TypeName_State()
    {
        Value = default(T);
    }

    /// <summary>
    /// Initializes the instance with the default values.
    /// </summary>
    protected override void Initialize(ISystemContext context)
    {
        base.Initialize(context);

        Value = default(T);
        DataType = TypeInfo.GetDataTypeId(typeof(T));
        ValueRank = TypeInfo.GetValueRank(typeof(T));
    }
    #endregion

    #region Public Members
    /// <summary>
    /// The value of the variable.
    /// </summary>
    public new T Value
    {
        get { return (T)base.Value; }
        set { base.Value = value; }
    }
    #endregion

    #region Overridden Methods
    /// <summary>
    /// Constructs a instance of the type.
    /// </summary>
    public override BaseInstanceState CreateInstance(NodeState parent)
    {
        return new _ClassName_State<T>(parent);
    }
    #endregion
}
#endregion
// ***START***
#region _ClassName_State<T> Class
/// <summary>
/// A typed version of the _BrowseName_ variable.
/// </summary>
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
public class _ClassName_State<T> : _ClassName_State
{
    #region Constructors
    /// <summary>
    /// Initializes the instance with its defalt attribute values.
    /// </summary>
    public _ClassName_State(NodeState parent) : base(parent)
    {
        Value = default(T);
    }

    /// <summary>
    /// Initializes the instance with the default values.
    /// </summary>
    protected override void Initialize(ISystemContext context)
    {
        base.Initialize(context);

        Value = default(T);
        DataType = TypeInfo.GetDataTypeId(typeof(T));
        ValueRank = TypeInfo.GetValueRank(typeof(T));
    }

    /// <summary>
    /// Initializes the instance with a node.
    /// </summary>
    protected override void Initialize(ISystemContext context, NodeState source)
    {
        InitializeOptionalChildren(context);
        base.Initialize(context, source);
    }
    #endregion

    #region Public Members
    /// <summary>
    /// The value of the variable.
    /// </summary>
    public new T Value
    {
        get
        {
            return CheckTypeBeforeCast<T>(base.Value, true);
        }

        set
        {
            base.Value = value;
        }
    }
    #endregion
}
#endregion
// ***END***
