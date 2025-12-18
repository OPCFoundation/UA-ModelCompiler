class Placeholder
{
// ***START***
#if (!OPCUA_EXCLUDE__NAME_)
/// <summary>
/// Invokes the _NAME_ service.
/// </summary>
#if (NET_STANDARD_OBSOLETE_SYNC && !OPCUA_EXCLUDE__NAME__ASYNC)
[Obsolete("Sync methods are deprecated in this version. Use _NAME_Async instead.")]
#endif
void Interface();

#if (!OPCUA_EXCLUDE__NAME__ASYNC)
/// <summary>
/// Invokes the _NAME_ service using async Task based request.
/// </summary>
void InterfaceAsync();
#endif
#endif
// ***END***
}
