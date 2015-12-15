public class _ClassName_Value {
// ***START***
#region _ChildName_ Access Methods
/// <summary>
/// Reads the value of the variable child.
/// </summary>
private ServiceResult OnRead__ChildName_(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
{
    lock (Lock)
    {
        DoBeforeReadProcessing(context, node);

        if (m_value != null)
        {
            value = m_value._ChildPath_;
        }

        return Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
    }
}

/// <summary>
/// Writes the value of the variable child.
/// </summary>
private ServiceResult OnWrite__ChildName_(ISystemContext context, NodeState node, ref object value)
{
    lock (Lock)
    {
        m_value._ChildPath_ = (_ChildDataType_)Write(value);
    }

    return ServiceResult.Good;
}
#endregion
// ***END***
}
