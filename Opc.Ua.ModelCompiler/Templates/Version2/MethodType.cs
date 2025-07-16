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

    /// <remarks />
    public _ClassName_MethodAsyncCallHandler OnCallAsync;
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

    /// <remarks />
    protected override async ValueTask<ServiceResult> CallAsync(
        ISystemContext _context,
        NodeId _objectId,
        IList<object> _inputArguments,
        IList<object> _outputArguments,
        CancellationToken cancellationToken = default)
    {
        if (OnCall == null && OnCallAsync == null)
        {
            return await base.CallAsync(_context, _objectId, _inputArguments, _outputArguments, cancellationToken).ConfigureAwait(false);
        }

        if (OnCallAsync != null)
        {
            _ClassName_Result _result = null;
            // ListOfInputArguments

            _result = await OnCallAsync(_context);

            // ListOfOutputArgumentsFromResult

            return _result.ServiceResult;
        }

        if (OnCall != null)
        {
            return Call(_context, _objectId, _inputArguments, _outputArguments);
        }
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

/// <remarks />
/// <exclude />
public partial class _ClassName_Result
{
    /// <remarks />
    public ServiceResult ServiceResult { get; set; }
    // ListOfResultProperties
}


/// <remarks />
/// <exclude />
public delegate ValueTask<_ClassName_Result> _ClassName_MethodAsyncCallHandler(
    _ISystemContext context_, CancellationToken cancellationToken);
#endif
#endregion
// ***END***
