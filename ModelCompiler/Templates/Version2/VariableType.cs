#region _TypeName_State Class
/// <summary>
/// Stores the _BrowseName_ _NodeClass_.
/// </summary>
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
public partial class _TypeName_State : _BaseType_State<BaseT>
{
    #region Constructors
    /// <summary>
    /// Initializes the type with its default attribute values.
    /// </summary>
    public _TypeName_State()
    {
    }

    /// <summary>
    /// Constructs an instance of a node.
    /// </summary>
    /// <param name="parent">The parent.</param>
    /// <returns>The new node.</returns>
    public new static NodeState Construct(NodeState parent)
    {
        return new _TypeName_State();
    }

    /// <summary>
    /// Initializes the type.
    /// </summary>
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
    /// <summary>
    /// Constructs a instance of the type.
    /// </summary>
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
/// <summary>
/// Stores an instance of the _BrowseName_ _NodeClass_.
/// </summary>
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
public partial class _ClassName_State : _BaseClassName_State<BaseT>
{
    #region Constructors
    /// <summary>
    /// Initializes the type with its default attribute values.
    /// </summary>
    public _ClassName_State(NodeState parent) : base(parent)
    {
    }

    /// <summary>
    /// Returns the id of the default type definition node for the instance.
    /// </summary>
    protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
    {
        return Opc.Ua.NodeId.Create(_NamespacePrefix_.VariableTypes._TypeName_, _NamespaceUri_, namespaceUris);
    }

    /// <summary>
    /// Returns the id of the default data type node for the instance.
    /// </summary>
    protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
    {
        return Opc.Ua.NodeId.Create(_DataTypeNamespacePrefix_.DataTypes._DataType_, _DataTypeNamespaceUri_, namespaceUris);
    }

    /// <summary>
    /// Returns the id of the default value rank for the instance.
    /// </summary>
    protected override int GetDefaultValueRank()
    {
        return _ValueRank_;
    }

    #if (!OPCUA_EXCLUDE_InitializationStrings)
    /// <summary>
    /// Initializes the instance.
    /// </summary>
    protected override void Initialize(ISystemContext context)
    {
        base.Initialize(context);
        Initialize(context, InitializationString);
        InitializeOptionalChildren(context);
    }

    /// <summary>
    /// Initializes the instance with a node.
    /// </summary>
    protected override void Initialize(ISystemContext context, NodeState source)
    {
        InitializeOptionalChildren(context);
        base.Initialize(context, source);
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
// TypedVariableType
// VariableTypeValue
#endif
#endregion
// ***END***
