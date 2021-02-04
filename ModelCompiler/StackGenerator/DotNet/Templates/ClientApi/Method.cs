class Placeholder
{
// ***START***
#region _NAME_ Methods
#if (!OPCUA_EXCLUDE__NAME_)
#if (!NET_STANDARD)
/// <summary>
/// Invokes the _NAME_ service.
/// </summary>
void SyncCall()
{
    _NAME_Request request = new _NAME_Request();
    _NAME_Response response = null;

    // RequestParameters

    UpdateRequestHeader(request, requestHeader == null, "_NAME_");

    try
    {
        if (UseTransportChannel)
        {
            IServiceResponse genericResponse = TransportChannel.SendRequest(request);

            if (genericResponse == null)
            {
                throw new ServiceResultException(StatusCodes.BadUnknownResponse);
            }

            ValidateResponse(genericResponse.ResponseHeader);
            response = (_NAME_Response)genericResponse;
        }
        else
        {
            _NAME_ResponseMessage responseMessage = InnerChannel._NAME_(new _NAME_Message(request));

            if (responseMessage == null || responseMessage._NAME_Response == null)
            {
                throw new ServiceResultException(StatusCodes.BadUnknownResponse);
            }

            response = responseMessage._NAME_Response;
            ValidateResponse(response.ResponseHeader);
        }

        // ResponseParameters
    }
    finally
    {
        RequestCompleted(request, response, "_NAME_");
    }

    return response.ResponseHeader;
}

/// <summary>
/// Begins an asynchronous invocation of the _NAME_ service.
/// </summary>
void BeginAsyncCall()
{
    _NAME_Request request = new _NAME_Request();

    // RequestParameters

    UpdateRequestHeader(request, requestHeader == null, "_NAME_");

    if (UseTransportChannel)
    {
        return TransportChannel.BeginSendRequest(request, callback, asyncState);
    }

    return InnerChannel.Begin_NAME_(new _NAME_Message(request), callback, asyncState);
}

/// <summary>
/// Finishes an asynchronous invocation of the _NAME_ service.
/// </summary>
void EndAsyncCall()
{
    _NAME_Response response = null;

    try
    {
        if (UseTransportChannel)
        {
            IServiceResponse genericResponse = TransportChannel.EndSendRequest(result);

            if (genericResponse == null)
            {
                throw new ServiceResultException(StatusCodes.BadUnknownResponse);
            }

            ValidateResponse(genericResponse.ResponseHeader);
            response = (_NAME_Response)genericResponse;
        }
        else
        {
            _NAME_ResponseMessage responseMessage = InnerChannel.End_NAME_(result);

            if (responseMessage == null || responseMessage._NAME_Response == null)
            {
                throw new ServiceResultException(StatusCodes.BadUnknownResponse);
            }

            response = responseMessage._NAME_Response;
            ValidateResponse(response.ResponseHeader);
        }

        // ResponseParameters
    }
    finally
    {
        RequestCompleted(null, response, "_NAME_");
    }

    return response.ResponseHeader;
}
#else  // NET_STANDARD
/// <summary>
/// Invokes the _NAME_ service.
/// </summary>
void SyncCall()
{
    _NAME_Request request = new _NAME_Request();
    _NAME_Response response = null;

    // RequestParameters

    UpdateRequestHeader(request, requestHeader == null, "_NAME_");

    try
    {
        IServiceResponse genericResponse = TransportChannel.SendRequest(request);

        if (genericResponse == null)
        {
            throw new ServiceResultException(StatusCodes.BadUnknownResponse);
        }

        ValidateResponse(genericResponse.ResponseHeader);
        response = (_NAME_Response)genericResponse;

        // ResponseParameters
    }
    finally
    {
        RequestCompleted(request, response, "_NAME_");
    }

    return response.ResponseHeader;
}

/// <summary>
/// Begins an asynchronous invocation of the _NAME_ service.
/// </summary>
void BeginAsyncCall()
{
    _NAME_Request request = new _NAME_Request();

    // RequestParameters

    UpdateRequestHeader(request, requestHeader == null, "_NAME_");

    return TransportChannel.BeginSendRequest(request, callback, asyncState);
}

/// <summary>
/// Finishes an asynchronous invocation of the _NAME_ service.
/// </summary>
void EndAsyncCall()
{
    _NAME_Response response = null;

    try
    {
        IServiceResponse genericResponse = TransportChannel.EndSendRequest(result);

        if (genericResponse == null)
        {
            throw new ServiceResultException(StatusCodes.BadUnknownResponse);
        }

        ValidateResponse(genericResponse.ResponseHeader);
        response = (_NAME_Response)genericResponse;

        // ResponseParameters
    }
    finally
    {
        RequestCompleted(null, response, "_NAME_");
    }

    return response.ResponseHeader;
}
#endif

#if (NET_STANDARD_ASYNC)
/// <summary>
/// Invokes the _NAME_ service using async Task based request.
/// </summary>
void AsyncCall()
{
    _NAME_Request request = new _NAME_Request();
    _NAME_Response response = null;

    // RequestParameters

    UpdateRequestHeader(request, requestHeader == null, "_NAME_");

    try
    {
        IServiceResponse genericResponse = await TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(false);

        if (genericResponse == null)
        {
            throw new ServiceResultException(StatusCodes.BadUnknownResponse);
        }

        ValidateResponse(genericResponse.ResponseHeader);
        response = (_NAME_Response)genericResponse;
    }
    finally
    {
        RequestCompleted(request, response, "_NAME_");
    }

    return response;
}
#endif
#endif
#endregion
// ***END***
}
