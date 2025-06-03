using System;
using System.Collections.Generic;

namespace _Prefix_
{
// ***START***
#region I_ServiceSet_Server Interface
/// <summary>
/// An interface to a UA server implementation.
/// </summary>
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
public interface I_ServiceSet_Server : IServerBase
{
    // _ServerApi_
}
#endregion

#region I_ServiceSet_ServerAsync Interface
/// <summary>
/// An interface to a UA server implementation using async Task based requests.
/// </summary>
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
public interface I_ServiceSet_ServerAsync : IServerBase, I_ServiceSet_Server
{
    // _ServerAsyncApi_
}
#endregion

#region _ServiceSet_ServerBase Class
/// <summary>
/// A basic implementation of the UA server.
/// </summary>
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
public partial class _ServiceSet_ServerBase : ServerBase, I_ServiceSet_Server, I_ServiceSet_ServerAsync
{
    // _ServerStubs_
}
#endregion
// ***END***
}
