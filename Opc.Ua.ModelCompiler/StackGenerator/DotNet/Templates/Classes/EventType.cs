// ***START***
#region _NAME_ Class
/// <summary>
/// The _NAME_ class.
/// </summary>
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
public partial class _NAME_ : _BASETYPE_
{
    #region Constructors
    /// <summary>
    /// The default constructor.
    /// </summary>
    public _NAME_()
    {
        Initialize();
    }

    /// <summary>
    /// Sets private members to default values.
    /// </summary>
    private void Initialize()
    {
        // _DEFAULTLIST_
    }
    #endregion

    #region Public Properties
    /// <summary>
    /// The identier for the EventType.
    /// </summary>
    public override ExpandedNodeId TypeId
    {
        get { return m_TypeId; }
    }

    private static ExpandedNodeId m_TypeId = new ExpandedNodeId(ObjectTypes._NAME_Type, Namespaces._Namespace_);

    // _PROPERTYLIST_
    #endregion

    #region Overridden Methods
    /// <summary>
    /// Returns the valid of the field identified by the QualifiedName.
    /// </summary>
    public override object GetFieldValue(
        NamespaceTable namespaceUris,
        QualifiedName  propertyName)
    {
        if (QualifiedName.IsNull(propertyName))
        {
            return null;
        }

        // The namespace qualifying the property name must be the same namespace used for the TypeId.
        NodeId typeId = ExpandedNodeId.ToNodeId(_NAME_.m_TypeId, namespaceUris);

        // select the value.
        if (propertyName.NamespaceIndex == typeId.NamespaceIndex)
        {
            switch (propertyName.Name)
            {
                // _FIELDNAMESWITCH_
            }
        }

        return base.GetFieldValue(namespaceUris, propertyName);
    }

    /// <summary>
    /// The BrowseNames for the fields defined by the type.
    /// </summary>
    public static new class Names
    {
         // _FIELDNAMES_
    }
    #endregion

    #region Private Fields
    // _MEMBERLIST_
    #endregion
}
#endregion
// ***END***