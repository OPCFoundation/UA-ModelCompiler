public class _ClassName_Value
{
// ***START***
#region _ChildName_ Access Methods
/// <remarks />
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

        var childVariable = m_variable?._ChildPath_;
        if (childVariable != null && StatusCode.IsBad(childVariable.StatusCode))
        {
            value = null;
            statusCode = childVariable.StatusCode;
            return new ServiceResult(statusCode);
        }

        if (m_value != null)
        {
            value = m_value._ChildPath_;
        }

        var result = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);

        if (childVariable != null && ServiceResult.IsNotBad(result))
        {
            timestamp = childVariable.Timestamp;
            if (statusCode != childVariable.StatusCode)
            {
                statusCode = childVariable.StatusCode;
                result = new ServiceResult(statusCode);
            }
        }

        return result;
    }
}

/// <remarks />
private ServiceResult OnWrite__ChildName_(
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
        UpdateChildVariableStatus(m_variable._ChildPath_, ref statusCode, ref timestamp);
        m_value._ChildPath_ = (_ChildDataType_)Write(value);
        UpdateParent(context, ref statusCode, ref timestamp);
    }

    return ServiceResult.Good;
}
#endregion
// ***END***
}
