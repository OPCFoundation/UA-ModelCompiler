using System;
using System.Collections.Generic;
using System.Xml;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace _Prefix_
{
// ***START***
#region I_ServiceSet_Endpoint Interface
#if OPCUA_USE_SYNCHRONOUS_ENDPOINTS
/// <summary>
/// The service contract which must be implemented by all UA servers.
/// </summary>
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ServiceContract(Namespace = Namespaces._ServicesNamespace_)]
public interface I_ServiceSet_Endpoint : IEndpointBase
{
    // _OPERATIONLIST_
}
#else
/// <summary>
/// The asynchronous service contract which must be implemented by UA servers.
/// </summary>
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
#if (!NET_STANDARD)
[ServiceContract(Namespace = Namespaces._ServicesNamespace_)]
#endif
public interface I_ServiceSet_Endpoint : IEndpointBase
{
    // _ASYNCENDPOINTOPERATIONLIST_
}
#endif
#endregion

#region I_ServiceSet_Channel Interface
/// <summary>
/// An interface used by by clients to access a UA server.
/// </summary>
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
#if (!NET_STANDARD)
[ServiceContract(Namespace = Namespaces._ServicesNamespace_)]
#endif
public interface I_ServiceSet_Channel : IChannelBase
{
    // _ASYNCOPERATIONLIST_
}
#endregion
// ***END***
}