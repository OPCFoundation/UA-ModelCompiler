#region _TypeName_State Class
/// <remarks />
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
public partial class _TypeName_State : _BaseType_State<BaseT>
{
    #region Constructors
    /// <remarks />
    public _TypeName_State()
    {
    }

    /// <remarks />
    public new static NodeState Construct(NodeState parent)
    {
        return new _TypeName_State();
    }

    /// <remarks />
    public override void Initialize(ISystemContext context)
    {
        base.Initialize(context);
        System.IO.StringReader reader = new System.IO.StringReader(InitializationString);
        LoadFromXml(context, reader);
    }

    #region Initialization String
    // InitializationStringForType
    #endregion
    #endregion

    #region Public Properties
    // ListOfPropertiesForType
    #endregion

    #region Overridden Methods
    /// <remarks />
    public override BaseInstanceState CreateInstance(NodeState parent)
    {
        return new _ClassName_State(parent);
    }

    // FindChildMethodsForType
    #endregion

    #region Private Fields
    // ListOfFieldsForType
    #endregion
}
#endregion
// ***START***
#region _ClassName_State Class
#if (!OPCUA_EXCLUDE__ClassName_State)
/// <remarks />
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
public partial class _ClassName_State : _BaseClassName_State<BaseT>
{
    #region Constructors
    /// <remarks />
    public _ClassName_State(NodeState parent) : base(parent)
    {
    }

    /// <remarks />
    protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
    {
        return Opc.Ua.NodeId.Create(_NamespacePrefix_.ObjectTypes._TypeName_, _NamespaceUri_, namespaceUris);
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
    protected override void Initialize(ISystemContext context, NodeState source)
    {
        InitializeOptionalChildren(context);
        base.Initialize(context, source);
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

    #region Public Properties
    // ListOfProperties
    #endregion

    #region Overridden Methods
    // FindChildMethods
    #endregion

    #region Private Fields
    // ListOfFields
    #endregion
}
#endif
#endregion
// ***END***
