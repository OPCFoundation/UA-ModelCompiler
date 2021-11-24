// ***START***
#ifndef OPCUA_EXCLUDE__NAME_
/*============================================================================
 * Synchronously calls the _NAME_ service.
 *===========================================================================*/
OPCUA_EXPORT OpcUa_StatusCode OpcUa_ClientApi__NAME_(
    SyncArgList)
{
    _TYPE_Request cRequest;
    _TYPE_Response* pResponse = OpcUa_Null;
    OpcUa_EncodeableType* pResponseType = OpcUa_Null;

    OpcUa_InitializeStatus(OpcUa_Module_Client, "OpcUa_ClientApi__NAME_");

    _TYPE_Request_Initialize(&cRequest);

    /* validate arguments. */
    // ValidateArguments

    /* copy parameters into request object. */
    // RequestParameters

    /* invoke service */
    uStatus = OpcUa_Channel_InvokeService(
        a_hChannel,
        "_NAME_",
        (OpcUa_Void*)&cRequest,
        &_TYPE_Request_EncodeableType,
        (OpcUa_Void**)&pResponse,
        &pResponseType);

    OpcUa_GotoErrorIfBad(uStatus);
    OpcUa_GotoErrorIfTrue(pResponse == OpcUa_Null, OpcUa_BadUnexpectedError);
    OpcUa_GotoErrorIfTrue(pResponseType == OpcUa_Null, OpcUa_BadUnexpectedError);

    /* check for fault */
    if (pResponseType->TypeId == OpcUaId_ServiceFault)
    {
        *a_pResponseHeader = ((OpcUa_ServiceFault*)pResponse)->ResponseHeader;
        OpcUa_Free(pResponse);
        OpcUa_ReturnStatusCode;
    }

    /* check response type */
    else if (pResponseType->TypeId != OpcUaId__NAME_Response)
    {
        pResponseType->Clear(pResponse);
        OpcUa_GotoErrorWithStatus(OpcUa_BadUnknownResponse);
    }

    /* copy parameters from response object into return parameters. */
    else
    {
        // ResponseParameters
    }

    /* memory contained in the reponse objects is owned by the caller */
    OpcUa_Free(pResponse);

    OpcUa_ReturnStatusCode;
    OpcUa_BeginErrorHandling;

    OpcUa_Free(pResponse);

    OpcUa_FinishErrorHandling;
}

/*============================================================================
 * Asynchronously calls the _NAME_ service.
 *===========================================================================*/
OPCUA_EXPORT OpcUa_StatusCode OpcUa_ClientApi_Begin_NAME_(
    AsyncArgList)
{
    _TYPE_Request cRequest;

    OpcUa_InitializeStatus(OpcUa_Module_Client, "OpcUa_ClientApi_Begin_NAME_");

    _TYPE_Request_Initialize(&cRequest);

    /* validate arguments. */
    // ValidateAsyncArguments

    /* copy parameters into request object. */
    // RequestParameters

    /* begin invoke service */
    uStatus = OpcUa_Channel_BeginInvokeService(
        a_hChannel,
        "_NAME_",
        (OpcUa_Void*)&cRequest,
        &_TYPE_Request_EncodeableType,
        (OpcUa_Channel_PfnRequestComplete*)a_pCallback,
        a_pCallbackData);

    OpcUa_GotoErrorIfBad(uStatus);

    OpcUa_ReturnStatusCode;
    OpcUa_BeginErrorHandling;

    /* nothing to do */

    OpcUa_FinishErrorHandling;
}
#endif
// ***END***