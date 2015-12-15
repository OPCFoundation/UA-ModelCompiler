class _Name_{
// ***START***
/// <summary>
/// Populates a list with the children that belong to the node.
/// </summary>
/// <param name="context">The context for the system being accessed.</param>
/// <param name="children">The list of children to populate.</param>
public override void GetChildren(
    ISystemContext context,
    IList<BaseInstanceState> children)
{
    // ListOfFindChildren

    base.GetChildren(context, children);
}

/// <summary>
/// Finds the child with the specified browse name.
/// </summary>
protected override BaseInstanceState FindChild(
    ISystemContext context,
    QualifiedName browseName,
    bool createOrReplace,
    BaseInstanceState replacement)
{
    if (QualifiedName.IsNull(browseName))
    {
        return null;
    }

    BaseInstanceState instance = null;

    switch (browseName.Name)
    {
        // ListOfFindChildCase
    }

    if (instance != null)
    {
        return instance;
    }

    return base.FindChild(context, browseName, createOrReplace, replacement);
}
// ***END***
}