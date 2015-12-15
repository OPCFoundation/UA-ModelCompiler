// ***START***
#region _NAME_ Service Messages
#if (!OPCUA_EXCLUDE__NAME_)
public partial class _NAME_Request : IServiceRequest
{
}

public partial class _NAME_Response : IServiceResponse
{
}

/// <summary>
/// The message contract for the _NAME_ service.
/// </summary>
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.CodeGenerator", "1.0.0.0")]
[MessageContract(IsWrapped=false)]
public class _NAME_Message : IServiceMessage
{
    /// <summary>
    /// The body of the message.
    /// </summary>
    [MessageBodyMember(Namespace = Namespaces._TypesNamespace_, Order = 0)]
    public _NAME_Request _NAME_Request;

    /// <summary>
    /// Initializes an empty message.
    /// </summary>
    public _NAME_Message()
    {
    }

    /// <summary>
    /// Initializes the message with the body.
    /// </summary>
    public _NAME_Message(_NAME_Request _NAME_Request)
    {
        this._NAME_Request = _NAME_Request;
    }

    #region IServiceMessage Members
    /// <summary cref="IServiceMessage.GetRequest" />
    public IServiceRequest GetRequest()
    {
        return _NAME_Request;
    }

    /// <summary cref="IServiceMessage.CreateResponse" />
    public object CreateResponse(IServiceResponse response)
    {
        _NAME_Response body = response as _NAME_Response;

        if (body == null)
        {
            body = new _NAME_Response();
            body.ResponseHeader = ((ServiceFault)response).ResponseHeader;
        }

        return new _NAME_ResponseMessage(body);
    }
    #endregion
}

/// <summary>
/// The message contract for the _NAME_ service response.
/// </summary>
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.CodeGenerator", "1.0.0.0")]
[MessageContract(IsWrapped=false)]
public class _NAME_ResponseMessage
{
    /// <summary>
    /// The body of the message.
    /// </summary>
    [MessageBodyMember(Namespace=Namespaces._TypesNamespace_, Order=0)]
    public _NAME_Response _NAME_Response;

    /// <summary>
    /// Initializes an empty message.
    /// </summary>
    public _NAME_ResponseMessage()
    {
    }

    /// <summary>
    /// Initializes the message with the body.
    /// </summary>
    public _NAME_ResponseMessage(_NAME_Response _NAME_Response)
    {
        this._NAME_Response = _NAME_Response;
    }

    /// <summary>
    /// Initializes the message with a service fault.
    /// </summary>
    public _NAME_ResponseMessage(ServiceFault ServiceFault)
    {
        this._NAME_Response = new _NAME_Response();

        if (ServiceFault != null)
        {
            this._NAME_Response.ResponseHeader = ServiceFault.ResponseHeader;
        }
    }
}
#endif
#endregion
// ***END***