public partial class _NAME_ : _BASETYPE_
{
// ***START***
#region GetFieldValue
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
// ***END***
}