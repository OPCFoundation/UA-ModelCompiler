// ***START***
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

    /* check for fault */
    if (pResponseType->TypeId == OpcUaId_ServiceFault)
    {
        *a_pResponseHeader = ((OpcUa_ServiceFault*)pResponse)->ResponseHeader;
        OpcUa_ReturnStatusCode;
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

/*============================================================================
 * Asynchronously finishes the _NAME_ service with service specific callback.
 *===========================================================================*/
OpcUa_StatusCode OpcUa_ClientApi_End_NAME_(
    OpcUa_Channel         a_hChannel,
    OpcUa_Void*           a_pResponse,
    OpcUa_EncodeableType* a_pResponseType,
    OpcUa_Void*           a_pCallbackData,
    OpcUa_StatusCode      a_uStatus)
{
    OpcUa_Channel_AsyncClientHandle* pContext = (OpcUa_Channel_AsyncClientHandle*)a_pCallbackData;
    _TYPE_Response* pResponse = (_TYPE_Response*)a_pResponse;

    OpcUa_InitializeStatus(OpcUa_Module_Client, "OpcUa_ClientApi_End_NAME_");

    OpcUa_ReferenceParameter(a_pResponseType);

    ((OpcUa_ClientApi_EndEx_NAME_*)(pContext->fpCallback))(
        a_hChannel,
        a_uStatus,
        // AsyncResponseParameters
        pContext->pCallbackData);

    /* free response */
    OpcUa_Free(a_pResponse);

    /* free context */
    OpcUa_Free(a_pCallbackData);

    OpcUa_ReturnStatusCode;
    OpcUa_BeginErrorHandling;

    /* nothing to do */

    OpcUa_FinishErrorHandling;
}

/*============================================================================
 * Asynchronously calls the _NAME_ service with service specific callback.
 *===========================================================================*/
OPCUA_EXPORT OpcUa_StatusCode OpcUa_ClientApi_BeginEx_NAME_(
    AsyncExArgList)
{
    _TYPE_Request cRequest;
    OpcUa_Channel_AsyncClientHandle* pContext = OpcUa_Null;

    OpcUa_InitializeStatus(OpcUa_Module_Client, "OpcUa_ClientApi_Begin_NAME_");

    _TYPE_Request_Initialize(&cRequest);

    /* validate arguments. */
    // ValidateAsyncArguments

    /* copy parameters into request object. */
    // RequestParameters

    /* create async call context */
    pContext = (OpcUa_Channel_AsyncClientHandle*)OpcUa_Alloc(sizeof(OpcUa_Channel_AsyncClientHandle));
    pContext->fpCallback = (OpcUa_Channel_GenericCallback*)a_pCallback;
    pContext->pCallbackData = a_pCallbackData;

    /* begin invoke service */
    uStatus = OpcUa_Channel_BeginInvokeService(
        a_hChannel, 
        "_NAME_", 
        (OpcUa_Void*)&cRequest, 
        &_TYPE_Request_EncodeableType,
        (OpcUa_Channel_PfnRequestComplete*)OpcUa_ClientApi_End_NAME_,
        (OpcUa_Void*)pContext);

    OpcUa_ReturnStatusCode;
    OpcUa_BeginErrorHandling;

    /* nothing to do */

    OpcUa_FinishErrorHandling;
}
// ***END***