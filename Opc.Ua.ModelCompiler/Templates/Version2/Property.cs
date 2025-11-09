class _Name_{
// ***START***
public new _ClassName_ _ChildName_
{
    get => _FieldName_;

    set
    {
        if (!Object.ReferenceEquals(_FieldName_, value))
        {
            ChangeMasks |= NodeStateChangeMasks.Children;
        }

        _FieldName_ = value;
    }
}
// ***END***
}