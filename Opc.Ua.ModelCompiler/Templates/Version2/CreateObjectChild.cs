class _Name_{
// ***START***
/// <summary>
/// Constructs an instance of the _ChildName_ child.
/// </summary>
public static new _ClassName_ Construct_ChildName_(
    ISystemContext context,
    NodeState parent)
{
    _ClassName_ instance = new _ClassName_(parent);

    instance.SymbolicName = "_ChildName_";
    instance.NodeId = Opc.Ua.NodeId.Create(_BrowseNameNamespacePrefix_.Objects._SymbolicId_, _BrowseNameNamespaceUri_, context.NamespaceUris);
    instance.BrowseName = Opc.Ua.QualifiedName.Create(_BrowseNameNamespacePrefix_.BrowseNames._ChildName_, _BrowseNameNamespaceUri_, context.NamespaceUris);
    instance.DisplayName = new LocalizedText(_BrowseNameNamespacePrefix_.BrowseNames._ChildName_, String.Empty, _BrowseNameNamespacePrefix_.BrowseNames._ChildName_);
    instance.Description = null;
    instance.WriteMask = AttributeWriteMask.None;
    instance.UserWriteMask = AttributeWriteMask.None;
    instance.ReferenceTypeId = Opc.Ua.NodeId.Create(_ReferenceTypeNamespacePrefix_.ReferenceTypes._ReferenceType_, _ReferenceTypeNamespaceUri_, context.NamespaceUris);
    instance.TypeDefinitionId = Opc.Ua.NodeId.Create(_NamespacePrefix_.ObjectTypes._TypeName_, _NamespaceUri_, context.NamespaceUris);
    instance.ModellingRuleId = _ModellingRule_;
    instance.NumericId = _BrowseNameNamespacePrefix_.Objects._SymbolicId_;
    instance.EventNotifier = _EventNotifier_;

    return instance;
}
// ***END***
}