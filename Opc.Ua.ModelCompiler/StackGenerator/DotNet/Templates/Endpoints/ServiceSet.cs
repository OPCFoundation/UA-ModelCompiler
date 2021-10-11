namespace _Prefix_
{
// ***START***
#region _ServiceSet_Endpoint Class
/// <summary>
/// A endpoint object used by clients to access a UA service.
/// </summary>
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
#if (!NET_STANDARD)
[ServiceMessageContextBehavior()]
[ServiceBehavior(Namespace = Namespaces._ServicesNamespace_, InstanceContextMode=InstanceContextMode.PerSession, ConcurrencyMode=ConcurrencyMode.Multiple)]
#endif
public partial class _ServiceSet_Endpoint : EndpointBase, _IEndpoints_
{
    #region Constructors
    /// <summary>
    /// Initializes the object when it is created by the WCF framework.
    /// </summary>
    public _ServiceSet_Endpoint()
    {
        this.CreateKnownTypes();
    }

    /// <summary>
    /// Initializes the when it is created directly.
    /// </summary>
    public _ServiceSet_Endpoint(IServiceHostBase host) : base(host)
    {
        this.CreateKnownTypes();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="_ServiceSet_Endpoint"/> class.
    /// </summary>
    /// <param name="server">The server.</param>
    public _ServiceSet_Endpoint(ServerBase server) : base(server)
    {
        this.CreateKnownTypes();
    }
    #endregion

    #region Public Members
    /// <summary>
    /// The UA server instance that the endpoint is connected to.
    /// </summary>
    protected I_ServiceSet_Server ServerInstance
    {
        get
        {
            if (ServiceResult.IsBad(ServerError))
            {
                throw new ServiceResultException(ServerError);
            }

            return ServerForContext as I_ServiceSet_Server;
         }
    }
    #endregion

    #region I_ServiceSet_Endpoint Members
    // _MethodList_
    #endregion

    #region Protected Members
    /// <summary>
    /// Populates the known types table.
    /// </summary>
    protected virtual void CreateKnownTypes()
    {
        // AddKnownType
    }
    #endregion
}
#endregion
// ***END***
}