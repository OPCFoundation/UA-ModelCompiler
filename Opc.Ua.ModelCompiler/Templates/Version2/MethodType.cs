// ***START***
#region _ClassName_ Class
#if (!OPCUA_EXCLUDE__ClassName_)
/// <remarks />
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
public partial class _ClassName_ : MethodState
{
    #region Constructors
    /// <remarks />
    public _ClassName_(NodeState parent) : base(parent)
    {
    }

    /// <remarks />
    public new static NodeState Construct(NodeState parent)
    {
        return new _ClassName_(parent);
    }

    #if (!OPCUA_EXCLUDE_InitializationStrings)
    /// <remarks />
    protected override void Initialize(ISystemContext context)
    {
        base.Initialize(context);
        Initialize(context, InitializationString);
        InitializeOptionalChildren(context);
    }

    /// <remarks />
    protected override void InitializeOptionalChildren(ISystemContext context)
    {
        base.InitializeOptionalChildren(context);
        // InitializeOptionalChildren
    }

    #region Initialization String
    // InitializationString
    #endregion
    #endif
    #endregion

    #region Event Callbacks
    /// <remarks />
    public _ClassName_MethodCallHandler OnCall;
    #endregion

    #region Public Properties
    // ListOfProperties
    #endregion

    #region Overridden Methods
    /// <remarks />
    protected override ServiceResult Call(
        ISystemContext _context,
        NodeId _objectId,
        IList<object> _inputArguments,
        IList<object> _outputArguments)
    {
        if (OnCall == null)
        {
            return base.Call(_context, _objectId, _inputArguments, _outputArguments);
        }

        ServiceResult _result = null;
        // ListOfInputArguments
        // ListOfOutputDeclarations

        if (OnCall != null)
        {
            _result = OnCall(_context);
        }
        // ListOfOutputArguments

        return _result;
    }
    // FindChildMethods
    #endregion

    #region Private Fields
    // ListOfFields
    #endregion
}

/// <remarks />
/// <exclude />
public delegate ServiceResult _ClassName_MethodCallHandler(
    _ISystemContext context_);
#endif
#endregion
// ***END***
