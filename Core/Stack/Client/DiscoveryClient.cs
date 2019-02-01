/* ========================================================================
 * Copyright (c) 2005-2019 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Reciprocal Community License ("RCL") Version 1.00
 *
 * Unless explicitly acquired and licensed from Licensor under another
 * license, the contents of this file are subject to the Reciprocal
 * Community License ("RCL") Version 1.00, or subsequent versions
 * as allowed by the RCL, and You may not copy or use this file in either
 * source code or executable form, except in compliance with the terms and
 * conditions of the RCL.
 *
 * All software distributed under the RCL is provided strictly on an
 * "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED,
 * AND LICENSOR HEREBY DISCLAIMS ALL SUCH WARRANTIES, INCLUDING WITHOUT
 * LIMITATION, ANY WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 * PURPOSE, QUIET ENJOYMENT, OR NON-INFRINGEMENT. See the RCL for specific
 * language governing rights and limitations under the RCL.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/RCL/1.00/
 * ======================================================================*/

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

using Opc.Ua.Bindings;

namespace Opc.Ua
{
    /// <summary>
    /// An object used by clients to access a UA discovery service.
    /// </summary>
    public partial class DiscoveryClient
    {
        #region Constructors
        /// <summary>
        /// Creates a binding for to use for discovering servers.
        /// </summary>
        /// <param name="discoveryUrl">The discovery URL.</param>
        /// <returns></returns>
        public static DiscoveryClient Create(Uri discoveryUrl)
        {
            EndpointConfiguration configuration = EndpointConfiguration.Create();
            ITransportChannel channel = DiscoveryChannel.Create(discoveryUrl, configuration, new ServiceMessageContext());
            return new DiscoveryClient(channel);
        }

        /// <summary>
        /// Creates a binding for to use for discovering servers.
        /// </summary>
        /// <param name="discoveryUrl">The discovery URL.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static DiscoveryClient Create(Uri discoveryUrl, EndpointConfiguration configuration)
        {
            if (configuration == null)
            {
                configuration = EndpointConfiguration.Create();
            }

            ITransportChannel channel = DiscoveryChannel.Create(discoveryUrl, configuration, new ServiceMessageContext());
            return new DiscoveryClient(channel);
        }

        #if !SILVERLIGHT
        /// <summary>
        /// Creates a binding for to use for discovering servers.
        /// </summary>
        /// <param name="discoveryUrl">The discovery URL.</param>
        /// <param name="bindingFactory">The binding factory.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static DiscoveryClient Create(Uri discoveryUrl, BindingFactory bindingFactory, EndpointConfiguration configuration)
        {
            if (discoveryUrl == null) throw new ArgumentNullException("discoveryUrl");

            if (bindingFactory == null)
            {
                bindingFactory = BindingFactory.Default;
            }

            if (configuration == null)
            {
                configuration = EndpointConfiguration.Create();
            }

            ITransportChannel channel = DiscoveryChannel.Create(discoveryUrl, bindingFactory, configuration, new ServiceMessageContext());
            return new DiscoveryClient(channel);
        }
        #endif
        #endregion

        #region Public Methods
        /// <summary>
        /// Invokes the GetEndpoints service.
        /// </summary>
        /// <param name="profileUris">The collection of profile URIs.</param>
        /// <returns></returns>
        public virtual EndpointDescriptionCollection GetEndpoints(StringCollection profileUris)
        {
            EndpointDescriptionCollection endpoints = null;

            GetEndpoints(
                null,
                this.Endpoint.EndpointUrl,
                null,
                profileUris,
                out endpoints);

            return endpoints;
        }

        /// <summary>
        /// Invokes the FindServers service.
        /// </summary>
        /// <param name="serverUris">The collection of server URIs.</param>
        /// <returns></returns>
        public virtual ApplicationDescriptionCollection FindServers(StringCollection serverUris)
        {
            ApplicationDescriptionCollection servers = null;

            FindServers(
                null,
                this.Endpoint.EndpointUrl,
                null,
                serverUris,
                out servers);

            return servers;
        }
        #endregion
    }

    /// <summary>
    /// A channel object used by clients to access a UA discovery service.
    /// </summary>
    public partial class DiscoveryChannel
    {
        #region Constructors
        /// <summary>
        /// Creates a new transport channel that supports the ISessionChannel service contract.
        /// </summary>
        /// <param name="discoveryUrl">The discovery url.</param>
        /// <param name="endpointConfiguration">The configuration to use with the endpoint.</param>
        /// <param name="messageContext">The message context to use when serializing the messages.</param>
        /// <returns></returns>
        public static ITransportChannel Create(
            Uri discoveryUrl,
            EndpointConfiguration endpointConfiguration,
            ServiceMessageContext messageContext)
        {
            // create a dummy description.
            EndpointDescription endpoint = new EndpointDescription();

            endpoint.EndpointUrl = discoveryUrl.ToString();
            endpoint.SecurityMode = MessageSecurityMode.None;
            endpoint.SecurityPolicyUri = SecurityPolicies.None;
            endpoint.Server.ApplicationUri = endpoint.EndpointUrl;
            endpoint.Server.ApplicationType = ApplicationType.DiscoveryServer;

            ITransportChannel channel = CreateUaBinaryChannel(
                null,
                endpoint,
                endpointConfiguration,
                null,
                messageContext);

            return channel;
        }

        #if !SILVERLIGHT
        /// <summary>
        /// Creates a new transport channel that supports the IDiscoveryChannel service contract.
        /// </summary>
        /// <param name="discoveryUrl">The discovery URL.</param>
        /// <param name="bindingFactory">The binding factory.</param>
        /// <param name="endpointConfiguration">The endpoint configuration.</param>
        /// <param name="messageContext">The message context.</param>
        /// <returns></returns>
        public static ITransportChannel Create(
            Uri discoveryUrl,
            BindingFactory bindingFactory,
            EndpointConfiguration endpointConfiguration,
            ServiceMessageContext messageContext)
        {
            // create a dummy description.
            EndpointDescription endpoint = new EndpointDescription();

            endpoint.EndpointUrl = discoveryUrl.ToString();
            endpoint.SecurityMode = MessageSecurityMode.None;
            endpoint.SecurityPolicyUri = SecurityPolicies.None;
            endpoint.Server.ApplicationUri = endpoint.EndpointUrl;
            endpoint.Server.ApplicationType = ApplicationType.DiscoveryServer;

            ITransportChannel channel = CreateUaBinaryChannel(
                null,
                endpoint,
                endpointConfiguration,
                null,
                messageContext);

            // create a WCF XML channel.
            if (channel == null)
            {
                Binding binding = bindingFactory.Create(discoveryUrl.Scheme, endpointConfiguration);

                DiscoveryChannel wcfXmlChannel = new DiscoveryChannel();

                wcfXmlChannel.Initialize(
                    endpoint,
                    endpointConfiguration,
                    binding,
                    null);

                channel = wcfXmlChannel;
            }

            return channel;
        }

        /// <summary>
        /// Creates a discovery channel using the default binding.
        /// </summary>
        /// <param name="discoveryUrl">The discovery URL.</param>
        /// <param name="configurationName">Name of the configuration.</param>
        /// <returns></returns>
        [Obsolete("Should call DiscoveryClient.Create methods.")]
        public static DiscoveryChannel Create(Uri discoveryUrl, string configurationName)
        {
            return Create(discoveryUrl, EndpointConfiguration.Create(), BindingFactory.Default, configurationName);
        }

        /// <summary>
        /// Creates a discovery channel that uses the specified endpoint configuration.
        /// </summary>
        /// <param name="discoveryUrl">The discovery URL.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        [Obsolete("Should call DiscoveryClient.Create methods.")]
        public static DiscoveryChannel Create(Uri discoveryUrl, EndpointConfiguration configuration)
        {
            return Create(discoveryUrl, configuration, BindingFactory.Default, null);
        }

        /// <summary>
        /// Creates a discovery channel that uses the specified endpoint configuration.
        /// </summary>
        /// <param name="discoveryUrl">The discovery URL.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="bindingFactory">The binding factory.</param>
        /// <param name="configurationName">Name of the configuration.</param>
        /// <returns></returns>
        [Obsolete("Should call DiscoveryClient.Create methods.")]
        public static DiscoveryChannel Create(
            Uri                   discoveryUrl,
            EndpointConfiguration configuration,
            BindingFactory        bindingFactory,
            string                configurationName)
        {
            return Create(discoveryUrl, configuration, bindingFactory.Create(discoveryUrl.Scheme, configuration), configurationName);
        }

        /// <summary>
        /// Creates a discovery channel that uses the specified binding.
        /// </summary>
        /// <param name="discoveryUrl">The discovery URL.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="binding">The binding.</param>
        /// <param name="configurationName">Name of the configuration.</param>
        /// <returns></returns>
        [Obsolete("Should call DiscoveryClient.Create methods.")]
        public static DiscoveryChannel Create(
            Uri                   discoveryUrl,
            EndpointConfiguration configuration,
            Binding               binding,
            string                configurationName)
        {
            // create a dummy description.
            EndpointDescription endpoint = new EndpointDescription();

            endpoint.EndpointUrl = discoveryUrl.ToString();
            endpoint.SecurityMode = MessageSecurityMode.None;
            endpoint.SecurityPolicyUri = SecurityPolicies.None;
            endpoint.Server.ApplicationUri = endpoint.EndpointUrl;
            endpoint.Server.ApplicationType = ApplicationType.DiscoveryServer;

            DiscoveryChannel channel = new DiscoveryChannel();

            channel.Initialize(
                endpoint,
                configuration,
                binding,
                configurationName);

            return channel;
        }
        #endif
        #endregion
    }
}
