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

#if (!OPCUA_EXCLUDE__NAME_ && !OPCUA_EXCLUDE__NAME__ASYNC)
/// <summary>
/// Invokes the _NAME_ service using async Task based request.
/// </summary>
void StubAsync()
{
    ValidateRequest(requestHeader);

    // Insert implementation.
    await Task.CompletedTask;

    throw new ServiceResultException(StatusCodes.BadServiceUnsupported);
}
#endif

// ***END***
}
