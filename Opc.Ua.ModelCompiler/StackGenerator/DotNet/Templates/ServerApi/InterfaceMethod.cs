class Placeholder
{
// ***START***
#if (!OPCUA_EXCLUDE__NAME_)
/// <summary>
/// Invokes the _NAME_ service.
/// </summary>
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
