class _Name_{ public void Method(int x) { switch (x) {
// ***START***
case _BrowseNameNamespacePrefix_.BrowseNames._ChildName_:
{
    if (createOrReplace)
    {
        if (_ChildName_ == null)
        {
            if (replacement == null)
            {
                _ChildName_ = new _ClassName_(this);
            }
            else
            {
                _ChildName_ = (_ClassName_)replacement;
            }
        }
    }

    instance = _ChildName_;
    break;
}
// ***END***
} } }