class Placeholder
{
// ***START***
#region _NAME_ Methods
#if (!OPCUA_EXCLUDE__NAME_)
#if (!NET_STANDARD_NO_SYNC && !NET_STANDARD_NO_APM)
/// <summary>
/// Invokes the _NAME_ service.
/// </summary>
#if (NET_STANDARD_OBSOLETE_SYNC && NET_STANDARD_ASYNC)
[Obsolete("Sync methods are deprecated in this version. Use _NAME_Async instead.")]
#endif
void SyncCall();
#endif

#if (!NET_STANDARD_NO_APM)
/// <summary>
/// Begins an asynchronous invocation of the _NAME_ service.
/// </summary>
#if (NET_STANDARD_OBSOLETE_APM && NET_STANDARD_ASYNC)
[Obsolete("Begin/End methods are deprecated in this version. Use _NAME_Async instead.")]
#endif
void BeginAsyncCall();

/// <summary>
/// Finishes an asynchronous invocation of the _NAME_ service.
/// </summary>
#if (NET_STANDARD_OBSOLETE_APM && NET_STANDARD_ASYNC)
[Obsolete("Begin/End methods are deprecated in this version. Use _NAME_Async instead.")]
#endif
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
