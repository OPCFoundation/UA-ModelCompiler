// ***START***
#region _ClassName_ Class
#if (!OPCUA_EXCLUDE__ClassName_)
/// <summary>
/// Stores an instance of the _BrowseName_ _NodeClass_.
/// </summary>
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
public partial class _ClassName_ : MethodState
{
    #region Constructors
    /// <summary>
    /// Initializes the type with its default attribute values.
    /// </summary>
    public _ClassName_(NodeState parent) : base(parent)
    {
    }

    /// <summary>
    /// Constructs an instance of a node.
    /// </summary>
    /// <param name="parent">The parent.</param>
    /// <returns>The new node.</returns>
    public new static NodeState Construct(NodeState parent)
    {
        return new _ClassName_(parent);
    }

    #if (!OPCUA_EXCLUDE_InitializationStrings)
    /// <summary>
    /// Initializes the instance.
    /// </summary>
    protected override void Initialize(ISystemContext context)
    {
        Initialize(context, InitializationString);
        InitializeOptionalChildren(context);
    }

    /// <summary>
    /// Initializes the any option children defined for the instance.
    /// </summary>
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
    /// <summary>
    /// Raised when the the method is called.
    /// </summary>
    public _ClassName_MethodCallHandler OnCall;
    #endregion

    #region Public Properties
    // ListOfProperties
    #endregion

    #region Overridden Methods
    /// <summary>
    /// Invokes the method, returns the result and output argument.
    /// </summary>
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

        ServiceResult result = null;
        // ListOfInputArguments
        // ListOfOutputDeclarations

        if (OnCall != null)
        {
            result = OnCall(_context);
        }
        // ListOfOutputArguments

        return result;
    }
    // FindChildMethods
    #endregion

    #region Private Fields
    // ListOfFields
    #endregion
}

/// <summary>
/// Used to receive notifications when the method is called.
/// </summary>
/// <exclude />
public delegate ServiceResult _ClassName_MethodCallHandler(
    _ISystemContext context_);
#endif
#endregion
// ***END***
