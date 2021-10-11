// ***START***
/*============================================================================
 * Synchronously calls the _NAME_ service.
 *===========================================================================*/
OPCUA_EXPORT OpcUa_StatusCode OpcUa_ClientApi__NAME_(
    SyncArgList);

/*============================================================================
 * Asynchronously calls the _NAME_ service.
 *===========================================================================*/
OPCUA_EXPORT OpcUa_StatusCode OpcUa_ClientApi_Begin_NAME_(
    AsyncArgList);

/*============================================================================
 * Service specific callback of the OpcUa_ClientApi_BeginEx_NAME_ service.
 *===========================================================================*/
typedef OpcUa_StatusCode (OpcUa_ClientApi_EndEx_NAME_)(
    AsyncRspList);

/*============================================================================
 * Asynchronously calls the _NAME_ service with service specific callback.
 *===========================================================================*/
OPCUA_EXPORT OpcUa_StatusCode OpcUa_ClientApi_BeginEx_NAME_(
    AsyncExArgList);
// ***END***