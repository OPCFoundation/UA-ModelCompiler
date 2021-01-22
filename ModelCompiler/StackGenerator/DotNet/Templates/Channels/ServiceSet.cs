namespace _Prefix_
{
// ***START***
#region _ServiceSet_Channel Class
/// <summary>
/// A channel object used by clients to access a UA service.
/// </summary>
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
#if (!NET_STANDARD)
public partial class _ServiceSet_Channel : WcfChannelBase<I_ServiceSet_Channel>, I_ServiceSet_Channel
#else
public partial class _ServiceSet_Channel : UaChannelBase<I_ServiceSet_Channel>, I_ServiceSet_Channel
#endif
{
    /// <summary>
    /// Initializes the object with the endpoint address.
    /// </summary>
    internal _ServiceSet_Channel()
    {
    }

    // _XmlChannelAsyncMethodList_
}
#endregion
// ***END***
}