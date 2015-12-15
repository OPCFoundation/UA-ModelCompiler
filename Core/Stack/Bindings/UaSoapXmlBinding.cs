/* ========================================================================
 * Copyright (c) 2005-2011 The OPC Foundation, Inc. All rights reserved.
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
using System.ServiceModel.Security;
using System.Text;

namespace Opc.Ua.Bindings
{
    /// <summary>
    /// The binding for the UA TCP protocol
    /// </summary>
    public class UaSoapXmlBinding : BaseBinding
    {
        #region Constructors
        /// <summary>
        /// Initializes the binding.
        /// </summary>
        /// <param name="namespaceUris">The namespace uris.</param>
        /// <param name="factory">The factory.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="description">The description.</param>
        public UaSoapXmlBinding(
            NamespaceTable        namespaceUris,
            EncodeableFactory     factory,
            EndpointConfiguration configuration,
            EndpointDescription   description)
        :
            base(namespaceUris, factory, configuration)
        {
            if (description != null && description.SecurityMode != MessageSecurityMode.None)
            {
                SymmetricSecurityBindingElement bootstrap = (SymmetricSecurityBindingElement)SecurityBindingElement.CreateMutualCertificateBindingElement();

                bootstrap.MessageProtectionOrder       = MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature;
                bootstrap.DefaultAlgorithmSuite        = SecurityPolicies.ToSecurityAlgorithmSuite(description.SecurityPolicyUri);
                bootstrap.IncludeTimestamp             = true;
                bootstrap.MessageSecurityVersion       = MessageSecurityVersion.WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10;
                bootstrap.RequireSignatureConfirmation = false;
                bootstrap.SecurityHeaderLayout         = SecurityHeaderLayout.Strict;

                bootstrap.SetKeyDerivation(true);

                m_security = (SymmetricSecurityBindingElement)SecurityBindingElement.CreateSecureConversationBindingElement(bootstrap, true);

                m_security.MessageProtectionOrder       = MessageProtectionOrder.EncryptBeforeSign;
                m_security.DefaultAlgorithmSuite        = SecurityPolicies.ToSecurityAlgorithmSuite(description.SecurityPolicyUri);
                m_security.IncludeTimestamp             = true;
                m_security.KeyEntropyMode               = SecurityKeyEntropyMode.CombinedEntropy;
                m_security.MessageSecurityVersion       = MessageSecurityVersion.WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10;
                m_security.RequireSignatureConfirmation = false;
                m_security.SecurityHeaderLayout         = SecurityHeaderLayout.Strict;

                m_security.SetKeyDerivation(true);
            }

            m_encoding  = new TextMessageEncodingBindingElement(MessageVersion.Soap12WSAddressing10, Encoding.UTF8);

            // WCF does not distinguish between arrays and byte string.
            int maxArrayLength = configuration.MaxArrayLength;

            if (configuration.MaxArrayLength < configuration.MaxByteStringLength)
            {
                maxArrayLength = configuration.MaxByteStringLength;
            }

            m_encoding.ReaderQuotas.MaxArrayLength         = maxArrayLength;
            m_encoding.ReaderQuotas.MaxStringContentLength = configuration.MaxStringLength;
            m_encoding.ReaderQuotas.MaxBytesPerRead        = Int32.MaxValue;
            m_encoding.ReaderQuotas.MaxDepth               = Int32.MaxValue;
            m_encoding.ReaderQuotas.MaxNameTableCharCount  = Int32.MaxValue;

            m_transport = new HttpTransportBindingElement();

            m_transport.AllowCookies           = false;
            m_transport.AuthenticationScheme   = System.Net.AuthenticationSchemes.Anonymous;
            m_transport.BypassProxyOnLocal     = true;
            m_transport.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            m_transport.KeepAliveEnabled       = true;
            m_transport.ManualAddressing       = false;
            m_transport.MaxBufferPoolSize      = Int32.MaxValue;
            m_transport.MaxBufferSize          = configuration.MaxMessageSize;
            m_transport.MaxReceivedMessageSize = configuration.MaxMessageSize;
            m_transport.TransferMode           = TransferMode.Buffered;
            m_transport.UseDefaultWebProxy     = false;
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// The URL scheme for the UA TCP protocol.
        /// </summary>
        /// <value></value>
        /// <returns>The URI scheme that is used by the channels or listeners that are created by the factories built by the current binding.</returns>
        public override string Scheme
        {
            get { return Utils.UriSchemeHttp; }
        }

        /// <summary>
        /// Create the set of binding elements that make up this binding.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.ICollection`1"/> object of type <see cref="T:System.ServiceModel.Channels.BindingElement"/> that contains the binding elements from the current binding object in the correct order.
        /// </returns>
        public override BindingElementCollection CreateBindingElements()
        {
            BindingElementCollection elements = new BindingElementCollection();

            if (m_security != null)
            {
                elements.Add(m_security);
            }

            elements.Add(m_encoding);
            elements.Add(m_transport);

            return elements.Clone();
        }
        #endregion

        #region Private Fields
        private SymmetricSecurityBindingElement m_security;
        private TextMessageEncodingBindingElement m_encoding;
        private HttpTransportBindingElement m_transport;
        #endregion
    }
}
