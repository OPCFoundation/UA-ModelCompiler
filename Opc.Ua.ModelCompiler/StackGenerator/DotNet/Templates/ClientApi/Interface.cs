class Placeholder
{
// ***START***
#region _NAME_ Methods
#if (!OPCUA_EXCLUDE__NAME_)
#if (!NET_STANDARD_NO_SYNC)
/// <summary>
/// Invokes the _NAME_ service.
/// </summary>
void SyncCall();
#endif

#if (!NET_STANDARD_NO_APM)
/// <summary>
/// Begins an asynchronous invocation of the _NAME_ service.
/// </summary>
void BeginAsyncCall();

/// <summary>
/// Finishes an asynchronous invocation of the _NAME_ service.
/// </summary>
void EndAsyncCall();
#endif

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
