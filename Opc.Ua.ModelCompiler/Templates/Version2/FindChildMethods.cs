class _Name_{
// ***START***
/// <remarks />
public override void GetChildren(
    ISystemContext context,
    IList<BaseInstanceState> children)
{
    // ListOfFindChildren

    base.GetChildren(context, children);
}
    
/// <remarks />
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