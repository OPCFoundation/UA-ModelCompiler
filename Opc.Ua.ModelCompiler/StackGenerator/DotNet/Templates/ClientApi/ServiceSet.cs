using System;
using System.Collections.Generic;

namespace _Prefix_
{
// ***START***
/// <summary>
/// The client side interface for a UA server.
/// </summary>
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
public partial class _ServiceSet_Client : ClientBase
{
    #region Constructors
    /// <summary>
    /// Intializes the object with a channel and a message context.
    /// </summary>
    public _ServiceSet_Client(ITransportChannel channel)
    :
        base(channel)
    {
    }
    #endregion

    #region Public Properties
    /// <summary>
    /// The component  contains classes  object use to communicate with the server.
    /// </summary>
    public new I_ServiceSet_Channel InnerChannel
    {
        get { return (I_ServiceSet_Channel)base.InnerChannel; }
    }
    #endregion

    #region Client API
    // _ClientApi_
    #endregion
}
// ***END***
}