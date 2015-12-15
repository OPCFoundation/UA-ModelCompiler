using System;

class Placeholder
{
// ***START***
#if (!OPCUA_EXCLUDE__NAME_)
/// <summary>
/// Invokes the _NAME_ service.
/// </summary>
public _NAME_Response _NAME_(_NAME_Request request)
{    
    BinaryMessageContext context = CreateContext();
    byte[] buffer = BinaryEncoder.EncodeMessage(request, context);

    InvokeServiceResponseMessage response = null;

    try
    {     
        response = Channel.InvokeService(new InvokeServiceMessage(buffer));
    }
    catch (FaultException<ServiceFault> e)
    {
        throw HandleSoapFault(e);
    }
    
    CheckForFault(response);
    
    return (_NAME_Response)BinaryDecoder.DecodeMessage(response.InvokeServiceResponse, typeof(_NAME_Response), context);
}
 
/// <summary>
/// The client side implementation of the _NAME_ service contract.
/// </summary>
_NAME_ResponseMessage I_ServiceSet_Endpoint._NAME_(_NAME_Message request)
{   
    _NAME_Response response = _NAME_(request._NAME_Request);
    return new _NAME_ResponseMessage(response);
}

/// <summary>
/// Invokes the _NAME_ service.
/// </summary>
public IAsyncResult Begin_NAME_(_NAME_Request request, AsyncCallback callback, object asyncState)
{
    byte[] buffer = BinaryEncoder.EncodeMessage(request, CreateContext());
    return Channel.BeginInvokeService(new InvokeServiceMessage(buffer), callback, asyncState);
}

/// <summary>
/// The client side implementation of the Begin_NAME_ service contract.
/// </summary>
IAsyncResult I_ServiceSet_Channel.Begin_NAME_(_NAME_Message request, AsyncCallback callback, object asyncState)
{
    return Begin_NAME_(request._NAME_Request, callback, asyncState);
}
    
/// <summary>
/// The client side implementation of the End_NAME_ service contract.
/// </summary>
_NAME_ResponseMessage I_ServiceSet_Channel.End_NAME_(IAsyncResult result)
{
    _NAME_Response response = End_NAME_(result);
    return new _NAME_ResponseMessage(response);
}

/// <summary>
/// Completes the _NAME_ service.
/// </summary>
public _NAME_Response End_NAME_(IAsyncResult result)
{ 
    InvokeServiceResponseMessage response = null;

    try
    {     
        response = Channel.EndInvokeService(result);
    }
    catch (FaultException<ServiceFault> e)
    {
        throw HandleSoapFault(e);
    }

    CheckForFault(response);
    
    return (_NAME_Response)BinaryDecoder.DecodeMessage(response.InvokeServiceResponse, typeof(_NAME_Response), CreateContext());
}
#endif
// ***END***
}
