#region _TypeName_State Class
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
public partial class _TypeName_State : _BaseType_State<BaseT>
{
    #region Constructors
    public _TypeName_State()
    {
    }

    public new static NodeState Construct(NodeState parent)
    {
        return new _TypeName_State();
    }

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
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
public partial class _ClassName_State : _BaseClassName_State<BaseT>
{
    #region Constructors
    public _ClassName_State(NodeState parent) : base(parent)
    {
    }

    protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
    {
        return Opc.Ua.NodeId.Create(_NamespacePrefix_.ObjectTypes._TypeName_, _NamespaceUri_, namespaceUris);
    }

    #if (!OPCUA_EXCLUDE_InitializationStrings)
    protected override void Initialize(ISystemContext context)
    {
        base.Initialize(context);
        Initialize(context, InitializationString);
        InitializeOptionalChildren(context);
    }

    protected override void Initialize(ISystemContext context, NodeState source)
    {
        InitializeOptionalChildren(context);
        base.Initialize(context, source);
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
