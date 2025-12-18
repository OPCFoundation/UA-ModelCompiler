class Placeholder
{
// ***START***
#if (!OPCUA_EXCLUDE__NAME_)
#if (!NET_STANDARD_NO_APM)
/// <summary>
/// The operation contract for the _NAME_ service.
/// </summary>
#if (!NET_STANDARD)
[OperationContractAttribute(AsyncPattern=true, Action=Namespaces._ServicesNamespace_ + "/_NAME_", ReplyAction = Namespaces._ServicesNamespace_ + "/_NAME_Response")]
[FaultContract(typeof(ServiceFault), Action = Namespaces._ServicesNamespace_ + "/_NAME_Fault", Name = "ServiceFault", Namespace = Namespaces._TypesNamespace_)]
#endif
#if (NET_STANDARD_OBSOLETE_APM && NET_STANDARD_ASYNC)
[Obsolete("Begin/End methods are deprecated in this version. Use _NAME_Async instead.")]
#endif
IAsyncResult Begin_NAME_(_NAME_Message request, AsyncCallback callback, object asyncState);

/// <summary>
/// The method used to retrieve the results of a _NAME_ service request.
/// </summary>
#if (NET_STANDARD_OBSOLETE_APM && NET_STANDARD_ASYNC)
[Obsolete("Begin/End methods are deprecated in this version. Use _NAME_Async instead.")]
#endif
_NAME_ResponseMessage End_NAME_(IAsyncResult result);
#endif

#if (NET_STANDARD_ASYNC && !OPCUA_EXCLUDE__NAME__ASYNC)
/// <summary>
/// The async operation contract for the _NAME_ service.
/// </summary>
Task<IServiceResponse> _NAME_Async(IServiceRequest incoming, SecureChannelContext secureChannelContext, CancellationToken cancellationToken = default);
#endif
#endif
// ***END***
}
