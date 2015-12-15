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
    instance.NodeId = Opc.Ua.NodeId.Create(_BrowseNameNamespacePrefix_.Variables._SymbolicId_, _BrowseNameNamespaceUri_, context.NamespaceUris);
    instance.BrowseName = Opc.Ua.QualifiedName.Create(_BrowseNameNamespacePrefix_.BrowseNames._ChildName_, _BrowseNameNamespaceUri_, context.NamespaceUris);
    instance.DisplayName = new LocalizedText(_BrowseNameNamespacePrefix_.BrowseNames._ChildName_, String.Empty, _BrowseNameNamespacePrefix_.BrowseNames._ChildName_);
    instance.Description = null;
    instance.WriteMask = AttributeWriteMask.None;
    instance.UserWriteMask = AttributeWriteMask.None;
    instance.ReferenceTypeId = Opc.Ua.NodeId.Create(_ReferenceTypeNamespacePrefix_.ReferenceTypes._ReferenceType_, _ReferenceTypeNamespaceUri_, context.NamespaceUris);
    instance.TypeDefinitionId = Opc.Ua.NodeId.Create(_NamespacePrefix_.VariableTypes._TypeName_, _NamespaceUri_, context.NamespaceUris);
    instance.ModellingRuleId = _ModellingRule_;
    instance.NumericId = _BrowseNameNamespacePrefix_.Variables._SymbolicId_;
    instance.Value = _DefaultValue_;
    instance.DataType = Opc.Ua.NodeId.Create(_DataTypeNamespacePrefix_.DataTypes._DataType_, _DataTypeNamespaceUri_, context.NamespaceUris);
    instance.ValueRank = _ValueRank_;
    instance.ArrayDimensions = _ArrayDimensions_;
    instance.AccessLevel = _AccessLevel_;
    instance.UserAccessLevel = _AccessLevel_;
    instance.MinimumSamplingInterval = _MinimumSamplingInterval_;
    instance.Historizing = _Historizing_;

    return instance;
}
// ***END***
}