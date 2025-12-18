// ***START***
#region _ClassName_ Class
#if (!OPCUA_EXCLUDE__ClassName_)
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
public partial class _ClassName_ : MethodState
{
    #region Constructors
    public _ClassName_(NodeState parent) : base(parent)
    {
    }

    public new static NodeState Construct(NodeState parent)
    {
        return new _ClassName_(parent);
    }

    #if (!OPCUA_EXCLUDE_InitializationStrings)
    protected override void Initialize(ISystemContext context)
    {
        base.Initialize(context);
        Initialize(context, InitializationString);
        InitializeOptionalChildren(context);
    }

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
    public _ClassName_MethodCallHandler OnCall;

    public _ClassName_MethodAsyncCallHandler OnCallAsync;
    #endregion

    #region Public Properties
    // ListOfProperties
    #endregion

    #region Overridden Methods
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

    #if (OPCUA_INCLUDE_ASYNC)
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

        _ClassName_Result _result = null;
        // ListOfInputArguments

        if (OnCallAsync != null)
        {
            _result = await OnCallAsync(_context);
        }
        else if (OnCall != null)
        {
            return Call(_context, _objectId, _inputArguments, _outputArguments);
        }
        // ListOfOutputArgumentsFromResult

        return _result.ServiceResult;
    }
    #endif

    // FindChildMethods
    #endregion

    #region Private Fields
    // ListOfFields
    #endregion
}

/// <exclude />
public delegate ServiceResult _ClassName_MethodCallHandler(
    _ISystemContext context_);

/// <exclude />
public partial class _ClassName_Result
{
    public ServiceResult ServiceResult { get; set; }
    // ListOfResultProperties
}

/// <exclude />
public delegate ValueTask<_ClassName_Result> _ClassName_MethodAsyncCallHandler(
    _ISystemContext context_, CancellationToken cancellationToken);
#endif
#endregion
// ***END***
