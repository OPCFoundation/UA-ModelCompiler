class Placeholder
{
// ***START***
#region _NAME_ Methods
#if (!OPCUA_EXCLUDE__NAME_)
/// <summary>
/// Invokes the _NAME_ service.
/// </summary>
void SyncCall();

/// <summary>
/// Begins an asynchronous invocation of the _NAME_ service.
/// </summary>
void BeginAsyncCall();

/// <summary>
/// Finishes an asynchronous invocation of the _NAME_ service.
/// </summary>
void EndAsyncCall();

#if (NET_STANDARD_ASYNC)
/// <summary>
/// Invokes the _NAME_ service using async Task based request.
/// </summary>
void AsyncCall();
#endif
#endif
#endregion
// ***END***
}
