#region _TypeName_State<T> Class
/// <remarks />
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
public class _TypeName_State<T> : _TypeName_State
{
    #region Constructors
    /// <remarks />
    public _TypeName_State()
    {
        Value = default(T);
    }

    /// <remarks />
    protected override void Initialize(ISystemContext context)
    {
        base.Initialize(context);

        Value = default(T);
        DataType = TypeInfo.GetDataTypeId(typeof(T));
        ValueRank = TypeInfo.GetValueRank(typeof(T));
    }
    #endregion

    #region Public Members
    /// <remarks />
    public new T Value
    {
        get { return (T)((BaseVariableState)this).Value; }
        set { ((BaseVariableState)this).Value = value; }
    }
    #endregion

    #region Overridden Methods
    /// <remarks />
    public override BaseInstanceState CreateInstance(NodeState parent)
    {
        return new _ClassName_State<T>(parent);
    }
    #endregion
}
#endregion
// ***START***
#region _ClassName_State<T> Class
/// <remarks />
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
public class _ClassName_State<T> : _ClassName_State
{
    #region Constructors
    /// <remarks />
    public _ClassName_State(NodeState parent) : base(parent)
    {
        Value = default(T);
    }

    /// <remarks />
    protected override void Initialize(ISystemContext context)
    {
        base.Initialize(context);

        Value = default(T);
        DataType = TypeInfo.GetDataTypeId(typeof(T));
        ValueRank = TypeInfo.GetValueRank(typeof(T));
    }

    /// <remarks />
    protected override void Initialize(ISystemContext context, NodeState source)
    {
        InitializeOptionalChildren(context);
        base.Initialize(context, source);
    }
    #endregion

    #region Public Members
    /// <remarks />
    public new T Value
    {
        get
        {
            return CheckTypeBeforeCast<T>(((BaseVariableState)this).Value, true);
        }

        set
        {
            ((BaseVariableState)this).Value = value;
        }
    }
    #endregion
}
#endregion
// ***END***
