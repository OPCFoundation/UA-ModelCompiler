class Placeholder
{
    // ***START***
#if (!OPCUA_EXCLUDE__NAME_)
    /// <summary>
    /// The operation contract for the _NAME_ service.
    /// </summary>
#if (!NET_STANDARD)
[OperationContract(Action = Namespaces._ServicesNamespace_ + "/_NAME_", ReplyAction = Namespaces._ServicesNamespace_ + "/_NAME_Response")]
[FaultContract(typeof(ServiceFault), Action = Namespaces._ServicesNamespace_ + "/_NAME_Fault", Name="ServiceFault", Namespace=Namespaces._TypesNamespace_)]
#endif
_NAME_ResponseMessage _NAME_(_NAME_Message request);

/// <summary>
/// The operation contract for the _NAME_ service.
/// </summary>
#if (!NET_STANDARD)
[OperationContractAttribute(AsyncPattern=true, Action=Namespaces._ServicesNamespace_ + "/_NAME_", ReplyAction = Namespaces._ServicesNamespace_ + "/_NAME_Response")]
#endif
IAsyncResult Begin_NAME_(_NAME_Message request, AsyncCallback callback, object asyncState);

/// <summary>
/// The method used to retrieve the results of a _NAME_ service request.
/// </summary>
_NAME_ResponseMessage End_NAME_(IAsyncResult result);

#if (NET_STANDARD_ASYNC)
/// <summary>
/// The async operation contract for the _NAME_ service.
/// </summary>
Task<_NAME_ResponseMessage> _NAME_Async(_NAME_Message request);
#endif
#endif
// ***END***
}
