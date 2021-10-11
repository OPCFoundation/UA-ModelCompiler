// ***START***
#ifndef OPCUA_EXCLUDE__NAME_
/*============================================================================
 * A pointer to a function that implements the _NAME_ service.
 *===========================================================================*/
typedef OpcUa_StatusCode (OpcUa_ServerApi_Pfn_NAME_)(
    ServerPointerArgList);

/*============================================================================
 * A stub method which implements the _NAME_ service.
 *===========================================================================*/
OpcUa_StatusCode OpcUa_ServerApi__NAME_(
    ServerSyncArgList)
{
    OpcUa_InitializeStatus(OpcUa_Module_Server, "OpcUa_ServerApi__NAME_");

    /* validate arguments. */
    OpcUa_ReturnErrorIfArgumentNull(a_hEndpoint);
    OpcUa_ReturnErrorIfArgumentNull(a_hContext);
    // ValidateArguments

    uStatus = OpcUa_BadNotImplemented;

    OpcUa_ReturnStatusCode;
    OpcUa_BeginErrorHandling;

    /* nothing to do */

    OpcUa_FinishErrorHandling;
}

/*============================================================================
 * Begins processing of a _NAME_ service request.
 *===========================================================================*/
OpcUa_StatusCode OpcUa_Server_Begin_NAME_(
    OpcUa_Endpoint        a_hEndpoint,
    OpcUa_Handle          a_hContext,
    OpcUa_Void**          a_ppRequest,
    OpcUa_EncodeableType* a_pRequestType)
{
    _TYPE_Request* pRequest = OpcUa_Null;
    _TYPE_Response* pResponse = OpcUa_Null;
    OpcUa_EncodeableType* pResponseType = OpcUa_Null;
    OpcUa_ServerApi_Pfn_NAME_* pfnInvoke = OpcUa_Null;

    OpcUa_InitializeStatus(OpcUa_Module_Server, "OpcUa_Server_Begin_NAME_");

    OpcUa_ReturnErrorIfArgumentNull(a_hEndpoint);
    OpcUa_ReturnErrorIfArgumentNull(a_hContext);
    OpcUa_ReturnErrorIfArgumentNull(a_ppRequest);
    OpcUa_ReturnErrorIfArgumentNull(*a_ppRequest);
    OpcUa_ReturnErrorIfArgumentNull(a_pRequestType);

    OpcUa_ReturnErrorIfTrue(a_pRequestType->TypeId != OpcUaId__NAME_Request, OpcUa_BadInvalidArgument);

    pRequest = (_TYPE_Request*)*a_ppRequest;

    /* create a context to use for sending a response */
    uStatus = OpcUa_Endpoint_BeginSendResponse(a_hEndpoint, a_hContext, (OpcUa_Void**)&pResponse, &pResponseType);
    OpcUa_GotoErrorIfBad(uStatus);

    /* get the function that implements the service call. */
    uStatus = OpcUa_Endpoint_GetServiceFunction(a_hEndpoint, a_hContext, (OpcUa_PfnInvokeService**)&pfnInvoke);
    OpcUa_GotoErrorIfBad(uStatus);

    /* invoke the service */
    uStatus = pfnInvoke(
        InvokeArgList);

    if (OpcUa_IsBad(uStatus))
    {
        OpcUa_Void* pFault = OpcUa_Null;
        OpcUa_EncodeableType* pFaultType = OpcUa_Null;

        /* create a fault */
        uStatus = OpcUa_ServerApi_CreateFault(
            &pRequest->RequestHeader,
            uStatus,
            &pResponse->ResponseHeader.ServiceDiagnostics,
            &pResponse->ResponseHeader.NoOfStringTable,
            &pResponse->ResponseHeader.StringTable,
            &pFault,
            &pFaultType);

        OpcUa_GotoErrorIfBad(uStatus);

        /* free the response */
        OpcUa_EncodeableObject_Delete(pResponseType, (OpcUa_Void**)&pResponse);

        /* make the response the fault */
        pResponse = (_TYPE_Response*)pFault;
        pResponseType = pFaultType;
    }

    /* send the response */
    uStatus = OpcUa_Endpoint_EndSendResponse(a_hEndpoint, &a_hContext, OpcUa_Good, pResponse, pResponseType);
    OpcUa_GotoErrorIfBad(uStatus);

    OpcUa_EncodeableObject_Delete(pResponseType, (OpcUa_Void**)&pResponse);

    OpcUa_ReturnStatusCode;
    OpcUa_BeginErrorHandling;

    /* send an error response */
    OpcUa_Endpoint_EndSendResponse(a_hEndpoint, &a_hContext, uStatus, OpcUa_Null, OpcUa_Null);

    OpcUa_EncodeableObject_Delete(pResponseType, (OpcUa_Void**)&pResponse);

    OpcUa_FinishErrorHandling;
}

/*============================================================================
 * The service dispatch information _NAME_ service.
 *===========================================================================*/
struct _OpcUa_ServiceType _TYPE__ServiceType =
{
    OpcUaId__NAME_Request,
    &_TYPE_Response_EncodeableType,
    OpcUa_Server_Begin_NAME_,
    (OpcUa_PfnInvokeService*)OpcUa_ServerApi__NAME_
};
#endif
// ***END***