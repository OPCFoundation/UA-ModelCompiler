class Placeholder
{
// ***START***
#if (!OPCUA_EXCLUDE__NAME_)
/// <summary>
/// Invokes the _NAME_ service.
/// </summary>
void Stub()
{
    // ResponseParameters

    ValidateRequest(requestHeader);

    // Insert implementation.

    return CreateResponse(requestHeader, StatusCodes.BadServiceUnsupported);
}
#endif
// ***END***
}
