/* ========================================================================
 * Copyright (c) 2005-2024 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua.Gds;
using Opc.Ua;

namespace Opc.Ua.Onboarding
{
    #region RegisterTicketsMethodState Class
    #if (!OPCUA_EXCLUDE_RegisterTicketsMethodState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class RegisterTicketsMethodState : MethodState
    {
        #region Constructors
        /// <remarks />
        public RegisterTicketsMethodState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        public new static NodeState Construct(NodeState parent)
        {
            return new RegisterTicketsMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAACcAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvT25ib2FyZGluZy8gAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0dEUy//////BGGCCgQAAAABABkAAABSZWdpc3RlclRpY2tldHNNZXRo" +
           "b2RUeXBlAQGRBAAvAQGRBJEEAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEB" +
           "kgQALgBEkgQAAJYBAAAAAQAqAQEcAAAABwAAAFRpY2tldHMBAH5kAQAAAAEAAAAAAAAAAAEAKAEBAAAA" +
           "AQAAAAEAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAZMEAC4ARJMEAACW" +
           "AQAAAAEAKgEBGgAAAAcAAABSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAQAAAAEB////" +
           "/wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <remarks />
        public RegisterTicketsMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <remarks />
        protected override ServiceResult Call(
            ISystemContext _context,
            NodeId _objectId,
            IList<object> _inputArguments,
            IList<object> _outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(_context, _objectId, _inputArguments, _outputArguments);
            }

            ServiceResult _result = null;

            string[] tickets = (string[])_inputArguments[0];

            StatusCode[] results = (StatusCode[])_outputArguments[0];

            if (OnCall != null)
            {
                _result = OnCall(
                    _context,
                    this,
                    _objectId,
                    tickets,
                    ref results);
            }

            _outputArguments[0] = results;

            return _result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <remarks />
    /// <exclude />
    public delegate ServiceResult RegisterTicketsMethodStateMethodCallHandler(
        ISystemContext _context,
        MethodState _method,
        NodeId _objectId,
        string[] tickets,
        ref StatusCode[] results);
    #endif
    #endregion

    #region UnregisterTicketsMethodState Class
    #if (!OPCUA_EXCLUDE_UnregisterTicketsMethodState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class UnregisterTicketsMethodState : MethodState
    {
        #region Constructors
        /// <remarks />
        public UnregisterTicketsMethodState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        public new static NodeState Construct(NodeState parent)
        {
            return new UnregisterTicketsMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAACcAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvT25ib2FyZGluZy8gAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0dEUy//////BGGCCgQAAAABABsAAABVbnJlZ2lzdGVyVGlja2V0c01l" +
           "dGhvZFR5cGUBAZQEAC8BAZQElAQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRz" +
           "AQGVBAAuAESVBAAAlgEAAAABACoBARwAAAAHAAAAVGlja2V0cwEAfmQBAAAAAQAAAAAAAAAAAQAoAQEA" +
           "AAABAAAAAQAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEBlgQALgBElgQA" +
           "AJYBAAAAAQAqAQEaAAAABwAAAFJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAABAAAAAQH/" +
           "////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <remarks />
        public UnregisterTicketsMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <remarks />
        protected override ServiceResult Call(
            ISystemContext _context,
            NodeId _objectId,
            IList<object> _inputArguments,
            IList<object> _outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(_context, _objectId, _inputArguments, _outputArguments);
            }

            ServiceResult _result = null;

            string[] tickets = (string[])_inputArguments[0];

            StatusCode[] results = (StatusCode[])_outputArguments[0];

            if (OnCall != null)
            {
                _result = OnCall(
                    _context,
                    this,
                    _objectId,
                    tickets,
                    ref results);
            }

            _outputArguments[0] = results;

            return _result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <remarks />
    /// <exclude />
    public delegate ServiceResult UnregisterTicketsMethodStateMethodCallHandler(
        ISystemContext _context,
        MethodState _method,
        NodeId _objectId,
        string[] tickets,
        ref StatusCode[] results);
    #endif
    #endregion

    #region DeviceRegistrarAdminState Class
    #if (!OPCUA_EXCLUDE_DeviceRegistrarAdminState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class DeviceRegistrarAdminState : BaseObjectState
    {
        #region Constructors
        /// <remarks />
        public DeviceRegistrarAdminState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Onboarding.ObjectTypes.DeviceRegistrarAdminType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAACcAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvT25ib2FyZGluZy8gAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0dEUy//////BGCAAgEAAAABACAAAABEZXZpY2VSZWdpc3RyYXJBZG1p" +
           "blR5cGVJbnN0YW5jZQEBlwQBAZcElwQAAP////8EAAAABGGCCgQAAAABAA8AAABSZWdpc3RlclRpY2tl" +
           "dHMBAZgEAC8BAZgEmAQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQGZBAAu" +
           "AESZBAAAlgEAAAABACoBARwAAAAHAAAAVGlja2V0cwEAfmQBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAA" +
           "AQAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEBmgQALgBEmgQAAJYBAAAA" +
           "AQAqAQEaAAAABwAAAFJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAA" +
           "AARhggoEAAAAAQARAAAAVW5yZWdpc3RlclRpY2tldHMBAZsEAC8BAZsEmwQAAAEB/////wIAAAAXYKkK" +
           "AgAAAAAADgAAAElucHV0QXJndW1lbnRzAQGcBAAuAEScBAAAlgEAAAABACoBARwAAAAHAAAAVGlja2V0" +
           "cwEAfmQBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAQAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91" +
           "dHB1dEFyZ3VtZW50cwEBnQQALgBEnQQAAJYBAAAAAQAqAQEaAAAABwAAAFJlc3VsdHMAEwEAAAABAAAA" +
           "AAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAAARggAoBAAAAAQARAAAAVGlja2V0QXV0aG9yaXRp" +
           "ZXMBAZ4EAC8BAOowngQAAP////8PAAAAFWCJCgIAAAAAAAQAAABTaXplAQGfBAAuAESfBAAAAAn/////" +
           "AQH/////AAAAABVgiQoCAAAAAAAIAAAAV3JpdGFibGUBAaAEAC4ARKAEAAAAAf////8BAf////8AAAAA" +
           "FWCJCgIAAAAAAAwAAABVc2VyV3JpdGFibGUBAaEEAC4ARKEEAAAAAf////8BAf////8AAAAAFWCJCgIA" +
           "AAAAAAkAAABPcGVuQ291bnQBAaIEAC4ARKIEAAAABf////8BAf////8AAAAABGGCCgQAAAAAAAQAAABP" +
           "cGVuAQGmBAAvAQA8LaYEAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBpwQA" +
           "LgBEpwQAAJYBAAAAAQAqAQETAAAABAAAAE1vZGUAA/////8AAAAAAAEAKAEBAAAAAQAAAAEAAAABAf//" +
           "//8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAagEAC4ARKgEAACWAQAAAAEAKgEBGQAA" +
           "AAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAAARhggoEAAAA" +
           "AAAFAAAAQ2xvc2UBAakEAC8BAD8tqQQAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1l" +
           "bnRzAQGqBAAuAESqBAAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEA" +
           "AAABAAAAAQAAAAEB/////wAAAAAEYYIKBAAAAAAABAAAAFJlYWQBAasEAC8BAEEtqwQAAAEB/////wIA" +
           "AAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQGsBAAuAESsBAAAlgIAAAABACoBARkAAAAKAAAA" +
           "RmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQEVAAAABgAAAExlbmd0aAAG/////wAAAAAAAQAoAQEAAAAB" +
           "AAAAAgAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEBrQQALgBErQQAAJYB" +
           "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" +
           "AACWAgAAAAEAKgEBGQAAAAoAAABUaHVtYnByaW50AAz/////AAAAAAABACoBASMAAAAUAAAASXNUcnVz" +
           "dGVkQ2VydGlmaWNhdGUAAf////8AAAAAAAEAKAEBAAAAAQAAAAIAAAABAf////8AAAAABGCACgEAAAAB" +
           "ABkAAABEZXZpY2VJZGVudGl0eUF1dGhvcml0aWVzAQHCBAAvAQDqMMIEAAD/////DwAAABVgiQoCAAAA" +
           "AAAEAAAAU2l6ZQEBwwQALgBEwwQAAAAJ/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFdyaXRhYmxl" +
           "AQHEBAAuAETEBAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAVXNlcldyaXRhYmxlAQHFBAAu" +
           "AETFBAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAT3BlbkNvdW50AQHGBAAuAETGBAAAAAX/" +
           "////AQH/////AAAAAARhggoEAAAAAAAEAAAAT3BlbgEBygQALwEAPC3KBAAAAQH/////AgAAABdgqQoC" +
           "AAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAcsEAC4ARMsEAACWAQAAAAEAKgEBEwAAAAQAAABNb2RlAAP/" +
           "////AAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1l" +
           "bnRzAQHMBAAuAETMBAAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEA" +
           "AAABAAAAAQAAAAEB/////wAAAAAEYYIKBAAAAAAABQAAAENsb3NlAQHNBAAvAQA/Lc0EAAABAf////8B" +
           "AAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBzgQALgBEzgQAAJYBAAAAAQAqAQEZAAAACgAA" +
           "AEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAEAAAABAf////8AAAAABGGCCgQAAAAAAAQA" +
           "AABSZWFkAQHPBAAvAQBBLc8EAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEB" +
           "0AQALgBE0AQAAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBFQAAAAYA" +
           "AABMZW5ndGgABv////8AAAAAAAEAKAEBAAAAAQAAAAIAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABP" +
           "dXRwdXRBcmd1bWVudHMBAdEEAC4ARNEEAACWAQAAAAEAKgEBEwAAAAQAAABEYXRhAA//////AAAAAAAB" +
           "ACgBAQAAAAEAAAABAAAAAQH/////AAAAAARhggoEAAAAAAAFAAAAV3JpdGUBAdIEAC8BAEQt0gQAAAEB" +
           "/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQHTBAAuAETTBAAAlgIAAAABACoBARkA" +
           "AAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQETAAAABAAAAERhdGEAD/////8AAAAAAAEAKAEB" +
           "AAAAAQAAAAIAAAABAf////8AAAAABGGCCgQAAAAAAAsAAABHZXRQb3NpdGlvbgEB1AQALwEARi3UBAAA" +
           "AQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAdUEAC4ARNUEAACWAQAAAAEAKgEB" +
           "GQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAABdgqQoC" +
           "AAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQHWBAAuAETWBAAAlgEAAAABACoBARcAAAAIAAAAUG9zaXRp" +
           "b24ACf////8AAAAAAAEAKAEBAAAAAQAAAAEAAAABAf////8AAAAABGGCCgQAAAAAAAsAAABTZXRQb3Np" +
           "dGlvbgEB1wQALwEASS3XBAAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAdgE" +
           "AC4ARNgEAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARcAAAAIAAAA" +
           "UG9zaXRpb24ACf////8AAAAAAAEAKAEBAAAAAQAAAAIAAAABAf////8AAAAAFWCJCgIAAAAAAA4AAABM" +
           "YXN0VXBkYXRlVGltZQEB2QQALgBE2QQAAAEAJgH/////AQH/////AAAAAARhggoEAAAAAAANAAAAT3Bl" +
           "bldpdGhNYXNrcwEB3AQALwEA/zDcBAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVu" +
           "dHMBAd0EAC4ARN0EAACWAQAAAAEAKgEBFAAAAAUAAABNYXNrcwAH/////wAAAAAAAQAoAQEAAAABAAAA" +
           "AQAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEB3gQALgBE3gQAAJYBAAAA" +
           "AQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAEAAAABAf////8AAAAA" +
           "BGGCCgQAAAAAAA4AAABDbG9zZUFuZFVwZGF0ZQEB3wQALwEAAjHfBAAAAQH/////AgAAABdgqQoCAAAA" +
           "AAAOAAAASW5wdXRBcmd1bWVudHMBAeAEAC4AROAEAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxl" +
           "AAf/////AAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJn" +
           "dW1lbnRzAQHhBAAuAEThBAAAlgEAAAABACoBASMAAAAUAAAAQXBwbHlDaGFuZ2VzUmVxdWlyZWQAAf//" +
           "//8AAAAAAAEAKAEBAAAAAQAAAAEAAAABAf////8AAAAABGGCCgQAAAAAAA4AAABBZGRDZXJ0aWZpY2F0" +
           "ZQEB4gQALwEABDHiBAAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAeMEAC4A" +
           "ROMEAACWAgAAAAEAKgEBGgAAAAsAAABDZXJ0aWZpY2F0ZQAP/////wAAAAAAAQAqAQEjAAAAFAAAAElz" +
           "VHJ1c3RlZENlcnRpZmljYXRlAAH/////AAAAAAABACgBAQAAAAEAAAACAAAAAQH/////AAAAAARhggoE" +
           "AAAAAAARAAAAUmVtb3ZlQ2VydGlmaWNhdGUBAeQEAC8BAAYx5AQAAAEB/////wEAAAAXYKkKAgAAAAAA" +
           "DgAAAElucHV0QXJndW1lbnRzAQHlBAAuAETlBAAAlgIAAAABACoBARkAAAAKAAAAVGh1bWJwcmludAAM" +
           "/////wAAAAAAAQAqAQEjAAAAFAAAAElzVHJ1c3RlZENlcnRpZmljYXRlAAH/////AAAAAAABACgBAQAA" +
           "AAEAAAACAAAAAQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public RegisterTicketsMethodState RegisterTickets
        {
            get
            {
                return m_registerTicketsMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_registerTicketsMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_registerTicketsMethod = value;
            }
        }

        /// <remarks />
        public UnregisterTicketsMethodState UnregisterTickets
        {
            get
            {
                return m_unregisterTicketsMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_unregisterTicketsMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_unregisterTicketsMethod = value;
            }
        }

        /// <remarks />
        public TrustListState TicketAuthorities
        {
            get
            {
                return m_ticketAuthorities;
            }

            set
            {
                if (!Object.ReferenceEquals(m_ticketAuthorities, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_ticketAuthorities = value;
            }
        }

        /// <remarks />
        public TrustListState DeviceIdentityAuthorities
        {
            get
            {
                return m_deviceIdentityAuthorities;
            }

            set
            {
                if (!Object.ReferenceEquals(m_deviceIdentityAuthorities, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_deviceIdentityAuthorities = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <remarks />
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_registerTicketsMethod != null)
            {
                children.Add(m_registerTicketsMethod);
            }

            if (m_unregisterTicketsMethod != null)
            {
                children.Add(m_unregisterTicketsMethod);
            }

            if (m_ticketAuthorities != null)
            {
                children.Add(m_ticketAuthorities);
            }

            if (m_deviceIdentityAuthorities != null)
            {
                children.Add(m_deviceIdentityAuthorities);
            }

            base.GetChildren(context, children);
        }
            
        /// <remarks />
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Onboarding.BrowseNames.RegisterTickets:
                {
                    if (createOrReplace)
                    {
                        if (RegisterTickets == null)
                        {
                            if (replacement == null)
                            {
                                RegisterTickets = new RegisterTicketsMethodState(this);
                            }
                            else
                            {
                                RegisterTickets = (RegisterTicketsMethodState)replacement;
                            }
                        }
                    }

                    instance = RegisterTickets;
                    break;
                }

                case Opc.Ua.Onboarding.BrowseNames.UnregisterTickets:
                {
                    if (createOrReplace)
                    {
                        if (UnregisterTickets == null)
                        {
                            if (replacement == null)
                            {
                                UnregisterTickets = new UnregisterTicketsMethodState(this);
                            }
                            else
                            {
                                UnregisterTickets = (UnregisterTicketsMethodState)replacement;
                            }
                        }
                    }

                    instance = UnregisterTickets;
                    break;
                }

                case Opc.Ua.Onboarding.BrowseNames.TicketAuthorities:
                {
                    if (createOrReplace)
                    {
                        if (TicketAuthorities == null)
                        {
                            if (replacement == null)
                            {
                                TicketAuthorities = new TrustListState(this);
                            }
                            else
                            {
                                TicketAuthorities = (TrustListState)replacement;
                            }
                        }
                    }

                    instance = TicketAuthorities;
                    break;
                }

                case Opc.Ua.Onboarding.BrowseNames.DeviceIdentityAuthorities:
                {
                    if (createOrReplace)
                    {
                        if (DeviceIdentityAuthorities == null)
                        {
                            if (replacement == null)
                            {
                                DeviceIdentityAuthorities = new TrustListState(this);
                            }
                            else
                            {
                                DeviceIdentityAuthorities = (TrustListState)replacement;
                            }
                        }
                    }

                    instance = DeviceIdentityAuthorities;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private RegisterTicketsMethodState m_registerTicketsMethod;
        private UnregisterTicketsMethodState m_unregisterTicketsMethod;
        private TrustListState m_ticketAuthorities;
        private TrustListState m_deviceIdentityAuthorities;
        #endregion
    }
    #endif
    #endregion

    #region ProvideIdentitiesMethodState Class
    #if (!OPCUA_EXCLUDE_ProvideIdentitiesMethodState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ProvideIdentitiesMethodState : MethodState
    {
        #region Constructors
        /// <remarks />
        public ProvideIdentitiesMethodState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        public new static NodeState Construct(NodeState parent)
        {
            return new ProvideIdentitiesMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAACcAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvT25ib2FyZGluZy8gAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0dEUy//////BGGCCgQAAAABABsAAABQcm92aWRlSWRlbnRpdGllc01l" +
           "dGhvZFR5cGUBAeYEAC8BAeYE5gQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRz" +
           "AQHnBAAuAETnBAAAlgMAAAABACoBAR0AAAAKAAAASWRlbnRpdGllcwAPAQAAAAEAAAAAAAAAAAEAKgEB" +
           "GgAAAAcAAABJc3N1ZXJzAA8BAAAAAQAAAAAAAAAAAQAqAQEcAAAABwAAAFRpY2tldHMBAH5kAQAAAAEA" +
           "AAAAAAAAAAEAKAEBAAAAAQAAAAMAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVu" +
           "dHMBAegEAC4AROgEAACWBAAAAAEAKgEBHwAAABAAAABTZWxlY3RlZElkZW50aXR5AA//////AAAAAAAB" +
           "ACoBAR8AAAAOAAAATWF0Y2hpbmdUaWNrZXQBAY0E/////wAAAAAAAQAqAQEcAAAADQAAAEFwcGxpY2F0" +
           "aW9uSWQAEf////8AAAAAAAEAKgEBJgAAABUAAABTb2Z0d2FyZVVwZGF0ZU1hbmFnZXIBAdcF/////wAA" +
           "AAAAAQAoAQEAAAABAAAABAAAAAEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <remarks />
        public ProvideIdentitiesMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <remarks />
        protected override ServiceResult Call(
            ISystemContext _context,
            NodeId _objectId,
            IList<object> _inputArguments,
            IList<object> _outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(_context, _objectId, _inputArguments, _outputArguments);
            }

            ServiceResult _result = null;

            byte[][] identities = (byte[][])_inputArguments[0];
            byte[][] issuers = (byte[][])_inputArguments[1];
            string[] tickets = (string[])_inputArguments[2];

            byte[] selectedIdentity = (byte[])_outputArguments[0];
            BaseTicketType matchingTicket = (BaseTicketType)_outputArguments[1];
            NodeId applicationId = (NodeId)_outputArguments[2];
            ManagerDescription softwareUpdateManager = (ManagerDescription)_outputArguments[3];

            if (OnCall != null)
            {
                _result = OnCall(
                    _context,
                    this,
                    _objectId,
                    identities,
                    issuers,
                    tickets,
                    ref selectedIdentity,
                    ref matchingTicket,
                    ref applicationId,
                    ref softwareUpdateManager);
            }

            _outputArguments[0] = selectedIdentity;
            _outputArguments[1] = matchingTicket;
            _outputArguments[2] = applicationId;
            _outputArguments[3] = softwareUpdateManager;

            return _result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <remarks />
    /// <exclude />
    public delegate ServiceResult ProvideIdentitiesMethodStateMethodCallHandler(
        ISystemContext _context,
        MethodState _method,
        NodeId _objectId,
        byte[][] identities,
        byte[][] issuers,
        string[] tickets,
        ref byte[] selectedIdentity,
        ref BaseTicketType matchingTicket,
        ref NodeId applicationId,
        ref ManagerDescription softwareUpdateManager);
    #endif
    #endregion

    #region UpdateSoftwareStatusMethodState Class
    #if (!OPCUA_EXCLUDE_UpdateSoftwareStatusMethodState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class UpdateSoftwareStatusMethodState : MethodState
    {
        #region Constructors
        /// <remarks />
        public UpdateSoftwareStatusMethodState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        public new static NodeState Construct(NodeState parent)
        {
            return new UpdateSoftwareStatusMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAACcAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvT25ib2FyZGluZy8gAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0dEUy//////BGGCCgQAAAABAB4AAABVcGRhdGVTb2Z0d2FyZVN0YXR1" +
           "c01ldGhvZFR5cGUBAdgFAC8BAdgF2AUAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1l" +
           "bnRzAQHZBQAuAETZBQAAlgMAAAABACoBASEAAAASAAAAUHJvZHVjdEluc3RhbmNlVXJpAAz/////AAAA" +
           "AAABACoBARUAAAAGAAAAU3RhdHVzAAH/////AAAAAAABACoBAR8AAAAQAAAAU29mdHdhcmVSZXZpc2lv" +
           "bgAM/////wAAAAAAAQAoAQEAAAABAAAAAwAAAAEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <remarks />
        public UpdateSoftwareStatusMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <remarks />
        protected override ServiceResult Call(
            ISystemContext _context,
            NodeId _objectId,
            IList<object> _inputArguments,
            IList<object> _outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(_context, _objectId, _inputArguments, _outputArguments);
            }

            ServiceResult _result = null;

            string productInstanceUri = (string)_inputArguments[0];
            bool status = (bool)_inputArguments[1];
            string softwareRevision = (string)_inputArguments[2];

            if (OnCall != null)
            {
                _result = OnCall(
                    _context,
                    this,
                    _objectId,
                    productInstanceUri,
                    status,
                    softwareRevision);
            }

            return _result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <remarks />
    /// <exclude />
    public delegate ServiceResult UpdateSoftwareStatusMethodStateMethodCallHandler(
        ISystemContext _context,
        MethodState _method,
        NodeId _objectId,
        string productInstanceUri,
        bool status,
        string softwareRevision);
    #endif
    #endregion

    #region RegisterDeviceEndpointMethodState Class
    #if (!OPCUA_EXCLUDE_RegisterDeviceEndpointMethodState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class RegisterDeviceEndpointMethodState : MethodState
    {
        #region Constructors
        /// <remarks />
        public RegisterDeviceEndpointMethodState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        public new static NodeState Construct(NodeState parent)
        {
            return new RegisterDeviceEndpointMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAACcAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvT25ib2FyZGluZy8gAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0dEUy//////BGGCCgQAAAABACAAAABSZWdpc3RlckRldmljZUVuZHBv" +
           "aW50TWV0aG9kVHlwZQEB6QQALwEB6QTpBAAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1" +
           "bWVudHMBAeoEAC4AROoEAACWAQAAAAEAKgEBHAAAAAsAAABBcHBsaWNhdGlvbgEANAH/////AAAAAAAB" +
           "ACgBAQAAAAEAAAABAAAAAQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <remarks />
        public RegisterDeviceEndpointMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <remarks />
        protected override ServiceResult Call(
            ISystemContext _context,
            NodeId _objectId,
            IList<object> _inputArguments,
            IList<object> _outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(_context, _objectId, _inputArguments, _outputArguments);
            }

            ServiceResult _result = null;

            Opc.Ua.ApplicationDescription application = (Opc.Ua.ApplicationDescription)ExtensionObject.ToEncodeable((ExtensionObject)_inputArguments[0]);

            if (OnCall != null)
            {
                _result = OnCall(
                    _context,
                    this,
                    _objectId,
                    application);
            }

            return _result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <remarks />
    /// <exclude />
    public delegate ServiceResult RegisterDeviceEndpointMethodStateMethodCallHandler(
        ISystemContext _context,
        MethodState _method,
        NodeId _objectId,
        Opc.Ua.ApplicationDescription application);
    #endif
    #endregion

    #region GetManagersMethodState Class
    #if (!OPCUA_EXCLUDE_GetManagersMethodState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GetManagersMethodState : MethodState
    {
        #region Constructors
        /// <remarks />
        public GetManagersMethodState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        public new static NodeState Construct(NodeState parent)
        {
            return new GetManagersMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAACcAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvT25ib2FyZGluZy8gAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0dEUy//////BGGCCgQAAAABABUAAABHZXRNYW5hZ2Vyc01ldGhvZFR5" +
           "cGUBAdoFAC8BAdoF2gUAAAEB/////wEAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEB2wUA" +
           "LgBE2wUAAJYBAAAAAQAqAQEdAAAACAAAAE1hbmFnZXJzAQHXBQEAAAABAAAAAAAAAAABACgBAQAAAAEA" +
           "AAABAAAAAQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <remarks />
        public GetManagersMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <remarks />
        protected override ServiceResult Call(
            ISystemContext _context,
            NodeId _objectId,
            IList<object> _inputArguments,
            IList<object> _outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(_context, _objectId, _inputArguments, _outputArguments);
            }

            ServiceResult _result = null;

            ManagerDescription[] managers = (ManagerDescription[])_outputArguments[0];

            if (OnCall != null)
            {
                _result = OnCall(
                    _context,
                    this,
                    _objectId,
                    ref managers);
            }

            _outputArguments[0] = managers;

            return _result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <remarks />
    /// <exclude />
    public delegate ServiceResult GetManagersMethodStateMethodCallHandler(
        ISystemContext _context,
        MethodState _method,
        NodeId _objectId,
        ref ManagerDescription[] managers);
    #endif
    #endregion

    #region RegisterManagedApplicationMethodState Class
    #if (!OPCUA_EXCLUDE_RegisterManagedApplicationMethodState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class RegisterManagedApplicationMethodState : MethodState
    {
        #region Constructors
        /// <remarks />
        public RegisterManagedApplicationMethodState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        public new static NodeState Construct(NodeState parent)
        {
            return new RegisterManagedApplicationMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAACcAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvT25ib2FyZGluZy8gAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0dEUy//////BGGCCgQAAAABACQAAABSZWdpc3Rlck1hbmFnZWRBcHBs" +
           "aWNhdGlvbk1ldGhvZFR5cGUBAdwFAC8BAdwF3AUAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0" +
           "QXJndW1lbnRzAQHdBQAuAETdBQAAlgIAAAABACoBARwAAAALAAAAQXBwbGljYXRpb24BAgEA/////wAA" +
           "AAAAAQAqAQEcAAAACwAAAFByb3RvY29sVXJpAQDHXP////8AAAAAAAEAKAEBAAAAAQAAAAIAAAABAf//" +
           "//8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAd4FAC4ARN4FAACWAQAAAAEAKgEBHAAA" +
           "AA0AAABBcHBsaWNhdGlvbklkABH/////AAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <remarks />
        public RegisterManagedApplicationMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <remarks />
        protected override ServiceResult Call(
            ISystemContext _context,
            NodeId _objectId,
            IList<object> _inputArguments,
            IList<object> _outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(_context, _objectId, _inputArguments, _outputArguments);
            }

            ServiceResult _result = null;

            Opc.Ua.Gds.ApplicationRecordDataType application = (Opc.Ua.Gds.ApplicationRecordDataType)ExtensionObject.ToEncodeable((ExtensionObject)_inputArguments[0]);
            string protocolUri = (string)_inputArguments[1];

            NodeId applicationId = (NodeId)_outputArguments[0];

            if (OnCall != null)
            {
                _result = OnCall(
                    _context,
                    this,
                    _objectId,
                    application,
                    protocolUri,
                    ref applicationId);
            }

            _outputArguments[0] = applicationId;

            return _result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <remarks />
    /// <exclude />
    public delegate ServiceResult RegisterManagedApplicationMethodStateMethodCallHandler(
        ISystemContext _context,
        MethodState _method,
        NodeId _objectId,
        Opc.Ua.Gds.ApplicationRecordDataType application,
        string protocolUri,
        ref NodeId applicationId);
    #endif
    #endregion

    #region DeviceRegistrarState Class
    #if (!OPCUA_EXCLUDE_DeviceRegistrarState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class DeviceRegistrarState : BaseObjectState
    {
        #region Constructors
        /// <remarks />
        public DeviceRegistrarState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Onboarding.ObjectTypes.DeviceRegistrarType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);

            if (Administration != null)
            {
                Administration.Initialize(context, Administration_InitializationString);
            }
        }

        #region Initialization String
        private const string Administration_InitializationString =
           "AgAAACcAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvT25ib2FyZGluZy8gAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0dEUy//////BGCACgEAAAABAA4AAABBZG1pbmlzdHJhdGlvbgEB8QQA" +
           "LwEBlwTxBAAA/////wQAAAAEYYIKBAAAAAEADwAAAFJlZ2lzdGVyVGlja2V0cwEB8gQALwEBmATyBAAA" +
           "AQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAfMEAC4ARPMEAACWAQAAAAEAKgEB" +
           "HAAAAAcAAABUaWNrZXRzAQB+ZAEAAAABAAAAAAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAABdg" +
           "qQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQH0BAAuAET0BAAAlgEAAAABACoBARoAAAAHAAAAUmVz" +
           "dWx0cwATAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAEAAAABAf////8AAAAABGGCCgQAAAABABEAAABV" +
           "bnJlZ2lzdGVyVGlja2V0cwEB9QQALwEBmwT1BAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRB" +
           "cmd1bWVudHMBAfYEAC4ARPYEAACWAQAAAAEAKgEBHAAAAAcAAABUaWNrZXRzAQB+ZAEAAAABAAAAAAAA" +
           "AAABACgBAQAAAAEAAAABAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQH3" +
           "BAAuAET3BAAAlgEAAAABACoBARoAAAAHAAAAUmVzdWx0cwATAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAA" +
           "AAEAAAABAf////8AAAAABGCACgEAAAABABEAAABUaWNrZXRBdXRob3JpdGllcwEB+AQALwEA6jD4BAAA" +
           "/////w8AAAAVYIkKAgAAAAAABAAAAFNpemUBAfkEAC4ARPkEAAAACf////8BAf////8AAAAAFWCJCgIA" +
           "AAAAAAgAAABXcml0YWJsZQEB+gQALgBE+gQAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFVz" +
           "ZXJXcml0YWJsZQEB+wQALgBE+wQAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAE9wZW5Db3Vu" +
           "dAEB/AQALgBE/AQAAAAF/////wEB/////wAAAAAEYYIKBAAAAAAABAAAAE9wZW4BAQAFAC8BADwtAAUA" +
           "AAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQEBBQAuAEQBBQAAlgEAAAABACoB" +
           "ARMAAAAEAAAATW9kZQAD/////wAAAAAAAQAoAQEAAAABAAAAAQAAAAEB/////wAAAAAXYKkKAgAAAAAA" +
           "DwAAAE91dHB1dEFyZ3VtZW50cwEBAgUALgBEAgUAAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUA" +
           "B/////8AAAAAAAEAKAEBAAAAAQAAAAEAAAABAf////8AAAAABGGCCgQAAAAAAAUAAABDbG9zZQEBAwUA" +
           "LwEAPy0DBQAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAQQFAC4ARAQFAACW" +
           "AQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAABAAAAAQH/////" +
           "AAAAAARhggoEAAAAAAAEAAAAUmVhZAEBBQUALwEAQS0FBQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAA" +
           "SW5wdXRBcmd1bWVudHMBAQYFAC4ARAYFAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////" +
           "AAAAAAABACoBARUAAAAGAAAATGVuZ3RoAAb/////AAAAAAABACgBAQAAAAEAAAACAAAAAQH/////AAAA" +
           "ABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQEHBQAuAEQHBQAAlgEAAAABACoBARMAAAAEAAAA" +
           "RGF0YQAP/////wAAAAAAAQAoAQEAAAABAAAAAQAAAAEB/////wAAAAAEYYIKBAAAAAAABQAAAFdyaXRl" +
           "AQEIBQAvAQBELQgFAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBCQUALgBE" +
           "CQUAAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBEwAAAAQAAABEYXRh" +
           "AA//////AAAAAAABACgBAQAAAAEAAAACAAAAAQH/////AAAAAARhggoEAAAAAAALAAAAR2V0UG9zaXRp" +
           "b24BAQoFAC8BAEYtCgUAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQELBQAu" +
           "AEQLBQAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAQAA" +
           "AAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEBDAUALgBEDAUAAJYBAAAAAQAq" +
           "AQEXAAAACAAAAFBvc2l0aW9uAAn/////AAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAAARhggoE" +
           "AAAAAAALAAAAU2V0UG9zaXRpb24BAQ0FAC8BAEktDQUAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElu" +
           "cHV0QXJndW1lbnRzAQEOBQAuAEQOBQAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAA" +
           "AAAAAQAqAQEXAAAACAAAAFBvc2l0aW9uAAn/////AAAAAAABACgBAQAAAAEAAAACAAAAAQH/////AAAA" +
           "ABVgiQoCAAAAAAAOAAAATGFzdFVwZGF0ZVRpbWUBAQ8FAC4ARA8FAAABACYB/////wEB/////wAAAAAE" +
           "YYIKBAAAAAAADQAAAE9wZW5XaXRoTWFza3MBARIFAC8BAP8wEgUAAAEB/////wIAAAAXYKkKAgAAAAAA" +
           "DgAAAElucHV0QXJndW1lbnRzAQETBQAuAEQTBQAAlgEAAAABACoBARQAAAAFAAAATWFza3MAB/////8A" +
           "AAAAAAEAKAEBAAAAAQAAAAEAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMB" +
           "ARQFAC4ARBQFAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEA" +
           "AAABAAAAAQH/////AAAAAARhggoEAAAAAAAOAAAAQ2xvc2VBbmRVcGRhdGUBARUFAC8BAAIxFQUAAAEB" +
           "/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQEWBQAuAEQWBQAAlgEAAAABACoBARkA" +
           "AAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAQAAAAEB/////wAAAAAXYKkKAgAA" +
           "AAAADwAAAE91dHB1dEFyZ3VtZW50cwEBFwUALgBEFwUAAJYBAAAAAQAqAQEjAAAAFAAAAEFwcGx5Q2hh" +
           "bmdlc1JlcXVpcmVkAAH/////AAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAAARhggoEAAAAAAAO" +
           "AAAAQWRkQ2VydGlmaWNhdGUBARgFAC8BAAQxGAUAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0" +
           "QXJndW1lbnRzAQEZBQAuAEQZBQAAlgIAAAABACoBARoAAAALAAAAQ2VydGlmaWNhdGUAD/////8AAAAA" +
           "AAEAKgEBIwAAABQAAABJc1RydXN0ZWRDZXJ0aWZpY2F0ZQAB/////wAAAAAAAQAoAQEAAAABAAAAAgAA" +
           "AAEB/////wAAAAAEYYIKBAAAAAAAEQAAAFJlbW92ZUNlcnRpZmljYXRlAQEaBQAvAQAGMRoFAAABAf//" +
           "//8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBGwUALgBEGwUAAJYCAAAAAQAqAQEZAAAA" +
           "CgAAAFRodW1icHJpbnQADP////8AAAAAAAEAKgEBIwAAABQAAABJc1RydXN0ZWRDZXJ0aWZpY2F0ZQAB" +
           "/////wAAAAAAAQAoAQEAAAABAAAAAgAAAAEB/////wAAAAAEYIAKAQAAAAEAGQAAAERldmljZUlkZW50" +
           "aXR5QXV0aG9yaXRpZXMBARwFAC8BAOowHAUAAP////8PAAAAFWCJCgIAAAAAAAQAAABTaXplAQEdBQAu" +
           "AEQdBQAAAAn/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAV3JpdGFibGUBAR4FAC4ARB4FAAAAAf//" +
           "//8BAf////8AAAAAFWCJCgIAAAAAAAwAAABVc2VyV3JpdGFibGUBAR8FAC4ARB8FAAAAAf////8BAf//" +
           "//8AAAAAFWCJCgIAAAAAAAkAAABPcGVuQ291bnQBASAFAC4ARCAFAAAABf////8BAf////8AAAAABGGC" +
           "CgQAAAAAAAQAAABPcGVuAQEkBQAvAQA8LSQFAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFy" +
           "Z3VtZW50cwEBJQUALgBEJQUAAJYBAAAAAQAqAQETAAAABAAAAE1vZGUAA/////8AAAAAAAEAKAEBAAAA" +
           "AQAAAAEAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBASYFAC4ARCYFAACW" +
           "AQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAABAAAAAQH/////" +
           "AAAAAARhggoEAAAAAAAFAAAAQ2xvc2UBAScFAC8BAD8tJwUAAAEB/////wEAAAAXYKkKAgAAAAAADgAA" +
           "AElucHV0QXJndW1lbnRzAQEoBQAuAEQoBQAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH////" +
           "/wAAAAAAAQAoAQEAAAABAAAAAQAAAAEB/////wAAAAAEYYIKBAAAAAAABAAAAFJlYWQBASkFAC8BAEEt" +
           "KQUAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQEqBQAuAEQqBQAAlgIAAAAB" +
           "ACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQEVAAAABgAAAExlbmd0aAAG/////wAA" +
           "AAAAAQAoAQEAAAABAAAAAgAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEB" +
           "KwUALgBEKwUAAJYBAAAAAQAqAQETAAAABAAAAERhdGEAD/////8AAAAAAAEAKAEBAAAAAQAAAAEAAAAB" +
           "Af////8AAAAABGGCCgQAAAAAAAUAAABXcml0ZQEBLAUALwEARC0sBQAAAQH/////AQAAABdgqQoCAAAA" +
           "AAAOAAAASW5wdXRBcmd1bWVudHMBAS0FAC4ARC0FAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxl" +
           "AAf/////AAAAAAABACoBARMAAAAEAAAARGF0YQAP/////wAAAAAAAQAoAQEAAAABAAAAAgAAAAEB////" +
           "/wAAAAAEYYIKBAAAAAAACwAAAEdldFBvc2l0aW9uAQEuBQAvAQBGLS4FAAABAf////8CAAAAF2CpCgIA" +
           "AAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBLwUALgBELwUAAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5k" +
           "bGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAEAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRB" +
           "cmd1bWVudHMBATAFAC4ARDAFAACWAQAAAAEAKgEBFwAAAAgAAABQb3NpdGlvbgAJ/////wAAAAAAAQAo" +
           "AQEAAAABAAAAAQAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAFNldFBvc2l0aW9uAQExBQAvAQBJLTEF" +
           "AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBMgUALgBEMgUAAJYCAAAAAQAq" +
           "AQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBFwAAAAgAAABQb3NpdGlvbgAJ/////wAA" +
           "AAAAAQAoAQEAAAABAAAAAgAAAAEB/////wAAAAAVYIkKAgAAAAAADgAAAExhc3RVcGRhdGVUaW1lAQEz" +
           "BQAuAEQzBQAAAQAmAf////8BAf////8AAAAABGGCCgQAAAAAAA0AAABPcGVuV2l0aE1hc2tzAQE2BQAv" +
           "AQD/MDYFAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBNwUALgBENwUAAJYB" +
           "AAAAAQAqAQEUAAAABQAAAE1hc2tzAAf/////AAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAABdg" +
           "qQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQE4BQAuAEQ4BQAAlgEAAAABACoBARkAAAAKAAAARmls" +
           "ZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAQAAAAEB/////wAAAAAEYYIKBAAAAAAADgAAAENs" +
           "b3NlQW5kVXBkYXRlAQE5BQAvAQACMTkFAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3Vt" +
           "ZW50cwEBOgUALgBEOgUAAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEB" +
           "AAAAAQAAAAEAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBATsFAC4ARDsF" +
           "AACWAQAAAAEAKgEBIwAAABQAAABBcHBseUNoYW5nZXNSZXF1aXJlZAAB/////wAAAAAAAQAoAQEAAAAB" +
           "AAAAAQAAAAEB/////wAAAAAEYYIKBAAAAAAADgAAAEFkZENlcnRpZmljYXRlAQE8BQAvAQAEMTwFAAAB" +
           "Af////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBPQUALgBEPQUAAJYCAAAAAQAqAQEa" +
           "AAAACwAAAENlcnRpZmljYXRlAA//////AAAAAAABACoBASMAAAAUAAAASXNUcnVzdGVkQ2VydGlmaWNh" +
           "dGUAAf////8AAAAAAAEAKAEBAAAAAQAAAAIAAAABAf////8AAAAABGGCCgQAAAAAABEAAABSZW1vdmVD" +
           "ZXJ0aWZpY2F0ZQEBPgUALwEABjE+BQAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVu" +
           "dHMBAT8FAC4ARD8FAACWAgAAAAEAKgEBGQAAAAoAAABUaHVtYnByaW50AAz/////AAAAAAABACoBASMA" +
           "AAAUAAAASXNUcnVzdGVkQ2VydGlmaWNhdGUAAf////8AAAAAAAEAKAEBAAAAAQAAAAIAAAABAf////8A" +
           "AAAA";

        private const string InitializationString =
           "AgAAACcAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvT25ib2FyZGluZy8gAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0dEUy//////BGCAAgEAAAABABsAAABEZXZpY2VSZWdpc3RyYXJUeXBl" +
           "SW5zdGFuY2UBAesEAQHrBOsEAAD/////BgAAAARhggoEAAAAAQARAAAAUHJvdmlkZUlkZW50aXRpZXMB" +
           "AewEAC8BAewE7AQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQHtBAAuAETt" +
           "BAAAlgMAAAABACoBAR0AAAAKAAAASWRlbnRpdGllcwAPAQAAAAEAAAAAAAAAAAEAKgEBGgAAAAcAAABJ" +
           "c3N1ZXJzAA8BAAAAAQAAAAAAAAAAAQAqAQEcAAAABwAAAFRpY2tldHMBAH5kAQAAAAEAAAAAAAAAAAEA" +
           "KAEBAAAAAQAAAAMAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAe4EAC4A" +
           "RO4EAACWBAAAAAEAKgEBHwAAABAAAABTZWxlY3RlZElkZW50aXR5AA//////AAAAAAABACoBAR8AAAAO" +
           "AAAATWF0Y2hpbmdUaWNrZXQBAY0E/////wAAAAAAAQAqAQEcAAAADQAAAEFwcGxpY2F0aW9uSWQAEf//" +
           "//8AAAAAAAEAKgEBJgAAABUAAABTb2Z0d2FyZVVwZGF0ZU1hbmFnZXIBAdcF/////wAAAAAAAQAoAQEA" +
           "AAABAAAABAAAAAEB/////wAAAAAEYYIKBAAAAAEAFAAAAFVwZGF0ZVNvZnR3YXJlU3RhdHVzAQHfBQAv" +
           "AQHfBd8FAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEB4AUALgBE4AUAAJYD" +
           "AAAAAQAqAQEhAAAAEgAAAFByb2R1Y3RJbnN0YW5jZVVyaQAM/////wAAAAAAAQAqAQEVAAAABgAAAFN0" +
           "YXR1cwAB/////wAAAAAAAQAqAQEfAAAAEAAAAFNvZnR3YXJlUmV2aXNpb24ADP////8AAAAAAAEAKAEB" +
           "AAAAAQAAAAMAAAABAf////8AAAAABGGCCgQAAAABABYAAABSZWdpc3RlckRldmljZUVuZHBvaW50AQHv" +
           "BAAvAQHvBO8EAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEB8AQALgBE8AQA" +
           "AJYBAAAAAQAqAQEcAAAACwAAAEFwcGxpY2F0aW9uAQA0Af////8AAAAAAAEAKAEBAAAAAQAAAAEAAAAB" +
           "Af////8AAAAABGGCCgQAAAABAAsAAABHZXRNYW5hZ2VycwEB4QUALwEB4QXhBQAAAQH/////AQAAABdg" +
           "qQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQHiBQAuAETiBQAAlgEAAAABACoBAR0AAAAIAAAATWFu" +
           "YWdlcnMBAdcFAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAEAAAABAf////8AAAAABGGCCgQAAAABABoA" +
           "AABSZWdpc3Rlck1hbmFnZWRBcHBsaWNhdGlvbgEB4wUALwEB4wXjBQAAAQH/////AgAAABdgqQoCAAAA" +
           "AAAOAAAASW5wdXRBcmd1bWVudHMBAeQFAC4AROQFAACWAgAAAAEAKgEBHAAAAAsAAABBcHBsaWNhdGlv" +
           "bgECAQD/////AAAAAAABACoBARwAAAALAAAAUHJvdG9jb2xVcmkBAMdc/////wAAAAAAAQAoAQEAAAAB" +
           "AAAAAgAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEB5QUALgBE5QUAAJYB" +
           "AAAAAQAqAQEcAAAADQAAAEFwcGxpY2F0aW9uSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAEAAAABAf//" +
           "//8AAAAABGCACgEAAAABAA4AAABBZG1pbmlzdHJhdGlvbgEB8QQALwEBlwTxBAAA/////wQAAAAEYYIK" +
           "BAAAAAEADwAAAFJlZ2lzdGVyVGlja2V0cwEB8gQALwEBmATyBAAAAQH/////AgAAABdgqQoCAAAAAAAO" +
           "AAAASW5wdXRBcmd1bWVudHMBAfMEAC4ARPMEAACWAQAAAAEAKgEBHAAAAAcAAABUaWNrZXRzAQB+ZAEA" +
           "AAABAAAAAAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJn" +
           "dW1lbnRzAQH0BAAuAET0BAAAlgEAAAABACoBARoAAAAHAAAAUmVzdWx0cwATAQAAAAEAAAAAAAAAAAEA" +
           "KAEBAAAAAQAAAAEAAAABAf////8AAAAABGGCCgQAAAABABEAAABVbnJlZ2lzdGVyVGlja2V0cwEB9QQA" +
           "LwEBmwT1BAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAfYEAC4ARPYEAACW" +
           "AQAAAAEAKgEBHAAAAAcAAABUaWNrZXRzAQB+ZAEAAAABAAAAAAAAAAABACgBAQAAAAEAAAABAAAAAQH/" +
           "////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQH3BAAuAET3BAAAlgEAAAABACoBARoA" +
           "AAAHAAAAUmVzdWx0cwATAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAEAAAABAf////8AAAAABGCACgEA" +
           "AAABABEAAABUaWNrZXRBdXRob3JpdGllcwEB+AQALwEA6jD4BAAA/////w8AAAAVYIkKAgAAAAAABAAA" +
           "AFNpemUBAfkEAC4ARPkEAAAACf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABXcml0YWJsZQEB+gQA" +
           "LgBE+gQAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFVzZXJXcml0YWJsZQEB+wQALgBE+wQA" +
           "AAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAE9wZW5Db3VudAEB/AQALgBE/AQAAAAF/////wEB" +
           "/////wAAAAAEYYIKBAAAAAAABAAAAE9wZW4BAQAFAC8BADwtAAUAAAEB/////wIAAAAXYKkKAgAAAAAA" +
           "DgAAAElucHV0QXJndW1lbnRzAQEBBQAuAEQBBQAAlgEAAAABACoBARMAAAAEAAAATW9kZQAD/////wAA" +
           "AAAAAQAoAQEAAAABAAAAAQAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEB" +
           "AgUALgBEAgUAAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAA" +
           "AAEAAAABAf////8AAAAABGGCCgQAAAAAAAUAAABDbG9zZQEBAwUALwEAPy0DBQAAAQH/////AQAAABdg" +
           "qQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAQQFAC4ARAQFAACWAQAAAAEAKgEBGQAAAAoAAABGaWxl" +
           "SGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAAARhggoEAAAAAAAEAAAAUmVh" +
           "ZAEBBQUALwEAQS0FBQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAQYFAC4A" +
           "RAYFAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARUAAAAGAAAATGVu" +
           "Z3RoAAb/////AAAAAAABACgBAQAAAAEAAAACAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0" +
           "QXJndW1lbnRzAQEHBQAuAEQHBQAAlgEAAAABACoBARMAAAAEAAAARGF0YQAP/////wAAAAAAAQAoAQEA" +
           "AAABAAAAAQAAAAEB/////wAAAAAEYYIKBAAAAAAABQAAAFdyaXRlAQEIBQAvAQBELQgFAAABAf////8B" +
           "AAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBCQUALgBECQUAAJYCAAAAAQAqAQEZAAAACgAA" +
           "AEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBEwAAAAQAAABEYXRhAA//////AAAAAAABACgBAQAAAAEA" +
           "AAACAAAAAQH/////AAAAAARhggoEAAAAAAALAAAAR2V0UG9zaXRpb24BAQoFAC8BAEYtCgUAAAEB////" +
           "/wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQELBQAuAEQLBQAAlgEAAAABACoBARkAAAAK" +
           "AAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAQAAAAEB/////wAAAAAXYKkKAgAAAAAA" +
           "DwAAAE91dHB1dEFyZ3VtZW50cwEBDAUALgBEDAUAAJYBAAAAAQAqAQEXAAAACAAAAFBvc2l0aW9uAAn/" +
           "////AAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAAARhggoEAAAAAAALAAAAU2V0UG9zaXRpb24B" +
           "AQ0FAC8BAEktDQUAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQEOBQAuAEQO" +
           "BQAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQEXAAAACAAAAFBvc2l0" +
           "aW9uAAn/////AAAAAAABACgBAQAAAAEAAAACAAAAAQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdFVw" +
           "ZGF0ZVRpbWUBAQ8FAC4ARA8FAAABACYB/////wEB/////wAAAAAEYYIKBAAAAAAADQAAAE9wZW5XaXRo" +
           "TWFza3MBARIFAC8BAP8wEgUAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQET" +
           "BQAuAEQTBQAAlgEAAAABACoBARQAAAAFAAAATWFza3MAB/////8AAAAAAAEAKAEBAAAAAQAAAAEAAAAB" +
           "Af////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBARQFAC4ARBQFAACWAQAAAAEAKgEB" +
           "GQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAAARhggoE" +
           "AAAAAAAOAAAAQ2xvc2VBbmRVcGRhdGUBARUFAC8BAAIxFQUAAAEB/////wIAAAAXYKkKAgAAAAAADgAA" +
           "AElucHV0QXJndW1lbnRzAQEWBQAuAEQWBQAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH////" +
           "/wAAAAAAAQAoAQEAAAABAAAAAQAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50" +
           "cwEBFwUALgBEFwUAAJYBAAAAAQAqAQEjAAAAFAAAAEFwcGx5Q2hhbmdlc1JlcXVpcmVkAAH/////AAAA" +
           "AAABACgBAQAAAAEAAAABAAAAAQH/////AAAAAARhggoEAAAAAAAOAAAAQWRkQ2VydGlmaWNhdGUBARgF" +
           "AC8BAAQxGAUAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQEZBQAuAEQZBQAA" +
           "lgIAAAABACoBARoAAAALAAAAQ2VydGlmaWNhdGUAD/////8AAAAAAAEAKgEBIwAAABQAAABJc1RydXN0" +
           "ZWRDZXJ0aWZpY2F0ZQAB/////wAAAAAAAQAoAQEAAAABAAAAAgAAAAEB/////wAAAAAEYYIKBAAAAAAA" +
           "EQAAAFJlbW92ZUNlcnRpZmljYXRlAQEaBQAvAQAGMRoFAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJ" +
           "bnB1dEFyZ3VtZW50cwEBGwUALgBEGwUAAJYCAAAAAQAqAQEZAAAACgAAAFRodW1icHJpbnQADP////8A" +
           "AAAAAAEAKgEBIwAAABQAAABJc1RydXN0ZWRDZXJ0aWZpY2F0ZQAB/////wAAAAAAAQAoAQEAAAABAAAA" +
           "AgAAAAEB/////wAAAAAEYIAKAQAAAAEAGQAAAERldmljZUlkZW50aXR5QXV0aG9yaXRpZXMBARwFAC8B" +
           "AOowHAUAAP////8PAAAAFWCJCgIAAAAAAAQAAABTaXplAQEdBQAuAEQdBQAAAAn/////AQH/////AAAA" +
           "ABVgiQoCAAAAAAAIAAAAV3JpdGFibGUBAR4FAC4ARB4FAAAAAf////8BAf////8AAAAAFWCJCgIAAAAA" +
           "AAwAAABVc2VyV3JpdGFibGUBAR8FAC4ARB8FAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABP" +
           "cGVuQ291bnQBASAFAC4ARCAFAAAABf////8BAf////8AAAAABGGCCgQAAAAAAAQAAABPcGVuAQEkBQAv" +
           "AQA8LSQFAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBJQUALgBEJQUAAJYB" +
           "AAAAAQAqAQETAAAABAAAAE1vZGUAA/////8AAAAAAAEAKAEBAAAAAQAAAAEAAAABAf////8AAAAAF2Cp" +
           "CgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBASYFAC4ARCYFAACWAQAAAAEAKgEBGQAAAAoAAABGaWxl" +
           "SGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAAARhggoEAAAAAAAFAAAAQ2xv" +
           "c2UBAScFAC8BAD8tJwUAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQEoBQAu" +
           "AEQoBQAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAQAA" +
           "AAEB/////wAAAAAEYYIKBAAAAAAABAAAAFJlYWQBASkFAC8BAEEtKQUAAAEB/////wIAAAAXYKkKAgAA" +
           "AAAADgAAAElucHV0QXJndW1lbnRzAQEqBQAuAEQqBQAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRs" +
           "ZQAH/////wAAAAAAAQAqAQEVAAAABgAAAExlbmd0aAAG/////wAAAAAAAQAoAQEAAAABAAAAAgAAAAEB" +
           "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";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public ProvideIdentitiesMethodState ProvideIdentities
        {
            get
            {
                return m_provideIdentitiesMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_provideIdentitiesMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_provideIdentitiesMethod = value;
            }
        }

        /// <remarks />
        public UpdateSoftwareStatusMethodState UpdateSoftwareStatus
        {
            get
            {
                return m_updateSoftwareStatusMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_updateSoftwareStatusMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_updateSoftwareStatusMethod = value;
            }
        }

        /// <remarks />
        public RegisterDeviceEndpointMethodState RegisterDeviceEndpoint
        {
            get
            {
                return m_registerDeviceEndpointMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_registerDeviceEndpointMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_registerDeviceEndpointMethod = value;
            }
        }

        /// <remarks />
        public GetManagersMethodState GetManagers
        {
            get
            {
                return m_getManagersMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_getManagersMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_getManagersMethod = value;
            }
        }

        /// <remarks />
        public RegisterManagedApplicationMethodState RegisterManagedApplication
        {
            get
            {
                return m_registerManagedApplicationMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_registerManagedApplicationMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_registerManagedApplicationMethod = value;
            }
        }

        /// <remarks />
        public DeviceRegistrarAdminState Administration
        {
            get
            {
                return m_administration;
            }

            set
            {
                if (!Object.ReferenceEquals(m_administration, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_administration = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <remarks />
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_provideIdentitiesMethod != null)
            {
                children.Add(m_provideIdentitiesMethod);
            }

            if (m_updateSoftwareStatusMethod != null)
            {
                children.Add(m_updateSoftwareStatusMethod);
            }

            if (m_registerDeviceEndpointMethod != null)
            {
                children.Add(m_registerDeviceEndpointMethod);
            }

            if (m_getManagersMethod != null)
            {
                children.Add(m_getManagersMethod);
            }

            if (m_registerManagedApplicationMethod != null)
            {
                children.Add(m_registerManagedApplicationMethod);
            }

            if (m_administration != null)
            {
                children.Add(m_administration);
            }

            base.GetChildren(context, children);
        }
            
        /// <remarks />
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Onboarding.BrowseNames.ProvideIdentities:
                {
                    if (createOrReplace)
                    {
                        if (ProvideIdentities == null)
                        {
                            if (replacement == null)
                            {
                                ProvideIdentities = new ProvideIdentitiesMethodState(this);
                            }
                            else
                            {
                                ProvideIdentities = (ProvideIdentitiesMethodState)replacement;
                            }
                        }
                    }

                    instance = ProvideIdentities;
                    break;
                }

                case Opc.Ua.Onboarding.BrowseNames.UpdateSoftwareStatus:
                {
                    if (createOrReplace)
                    {
                        if (UpdateSoftwareStatus == null)
                        {
                            if (replacement == null)
                            {
                                UpdateSoftwareStatus = new UpdateSoftwareStatusMethodState(this);
                            }
                            else
                            {
                                UpdateSoftwareStatus = (UpdateSoftwareStatusMethodState)replacement;
                            }
                        }
                    }

                    instance = UpdateSoftwareStatus;
                    break;
                }

                case Opc.Ua.Onboarding.BrowseNames.RegisterDeviceEndpoint:
                {
                    if (createOrReplace)
                    {
                        if (RegisterDeviceEndpoint == null)
                        {
                            if (replacement == null)
                            {
                                RegisterDeviceEndpoint = new RegisterDeviceEndpointMethodState(this);
                            }
                            else
                            {
                                RegisterDeviceEndpoint = (RegisterDeviceEndpointMethodState)replacement;
                            }
                        }
                    }

                    instance = RegisterDeviceEndpoint;
                    break;
                }

                case Opc.Ua.Onboarding.BrowseNames.GetManagers:
                {
                    if (createOrReplace)
                    {
                        if (GetManagers == null)
                        {
                            if (replacement == null)
                            {
                                GetManagers = new GetManagersMethodState(this);
                            }
                            else
                            {
                                GetManagers = (GetManagersMethodState)replacement;
                            }
                        }
                    }

                    instance = GetManagers;
                    break;
                }

                case Opc.Ua.Onboarding.BrowseNames.RegisterManagedApplication:
                {
                    if (createOrReplace)
                    {
                        if (RegisterManagedApplication == null)
                        {
                            if (replacement == null)
                            {
                                RegisterManagedApplication = new RegisterManagedApplicationMethodState(this);
                            }
                            else
                            {
                                RegisterManagedApplication = (RegisterManagedApplicationMethodState)replacement;
                            }
                        }
                    }

                    instance = RegisterManagedApplication;
                    break;
                }

                case Opc.Ua.Onboarding.BrowseNames.Administration:
                {
                    if (createOrReplace)
                    {
                        if (Administration == null)
                        {
                            if (replacement == null)
                            {
                                Administration = new DeviceRegistrarAdminState(this);
                            }
                            else
                            {
                                Administration = (DeviceRegistrarAdminState)replacement;
                            }
                        }
                    }

                    instance = Administration;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private ProvideIdentitiesMethodState m_provideIdentitiesMethod;
        private UpdateSoftwareStatusMethodState m_updateSoftwareStatusMethod;
        private RegisterDeviceEndpointMethodState m_registerDeviceEndpointMethod;
        private GetManagersMethodState m_getManagersMethod;
        private RegisterManagedApplicationMethodState m_registerManagedApplicationMethod;
        private DeviceRegistrarAdminState m_administration;
        #endregion
    }
    #endif
    #endregion

    #region RequestTicketsMethodState Class
    #if (!OPCUA_EXCLUDE_RequestTicketsMethodState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class RequestTicketsMethodState : MethodState
    {
        #region Constructors
        /// <remarks />
        public RequestTicketsMethodState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        public new static NodeState Construct(NodeState parent)
        {
            return new RequestTicketsMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAACcAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvT25ib2FyZGluZy8gAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0dEUy//////BGGCCgQAAAABABgAAABSZXF1ZXN0VGlja2V0c01ldGhv" +
           "ZFR5cGUBAZUFAC8BAZUFlQUAAAEB/////wEAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEB" +
           "lgUALgBElgUAAJYBAAAAAQAqAQEcAAAABwAAAFRpY2tldHMBAH5kAQAAAAEAAAAAAAAAAAEAKAEBAAAA" +
           "AQAAAAEAAAABAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <remarks />
        public RequestTicketsMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <remarks />
        protected override ServiceResult Call(
            ISystemContext _context,
            NodeId _objectId,
            IList<object> _inputArguments,
            IList<object> _outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(_context, _objectId, _inputArguments, _outputArguments);
            }

            ServiceResult _result = null;

            string[] tickets = (string[])_outputArguments[0];

            if (OnCall != null)
            {
                _result = OnCall(
                    _context,
                    this,
                    _objectId,
                    ref tickets);
            }

            _outputArguments[0] = tickets;

            return _result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <remarks />
    /// <exclude />
    public delegate ServiceResult RequestTicketsMethodStateMethodCallHandler(
        ISystemContext _context,
        MethodState _method,
        NodeId _objectId,
        ref string[] tickets);
    #endif
    #endregion

    #region SetRegistrarEndpointsMethodState Class
    #if (!OPCUA_EXCLUDE_SetRegistrarEndpointsMethodState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class SetRegistrarEndpointsMethodState : MethodState
    {
        #region Constructors
        /// <remarks />
        public SetRegistrarEndpointsMethodState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        public new static NodeState Construct(NodeState parent)
        {
            return new SetRegistrarEndpointsMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAACcAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvT25ib2FyZGluZy8gAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0dEUy//////BGGCCgQAAAABAB8AAABTZXRSZWdpc3RyYXJFbmRwb2lu" +
           "dHNNZXRob2RUeXBlAQGXBQAvAQGXBZcFAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3Vt" +
           "ZW50cwEBmAUALgBEmAUAAJYBAAAAAQAqAQEfAAAACgAAAFJlZ2lzdHJhcnMBADQBAQAAAAEAAAAAAAAA" +
           "AAEAKAEBAAAAAQAAAAEAAAABAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <remarks />
        public SetRegistrarEndpointsMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <remarks />
        protected override ServiceResult Call(
            ISystemContext _context,
            NodeId _objectId,
            IList<object> _inputArguments,
            IList<object> _outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(_context, _objectId, _inputArguments, _outputArguments);
            }

            ServiceResult _result = null;

            Opc.Ua.ApplicationDescription[] registrars = (Opc.Ua.ApplicationDescription[])ExtensionObject.ToArray(_inputArguments[0], typeof(Opc.Ua.ApplicationDescription));

            if (OnCall != null)
            {
                _result = OnCall(
                    _context,
                    this,
                    _objectId,
                    registrars);
            }

            return _result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <remarks />
    /// <exclude />
    public delegate ServiceResult SetRegistrarEndpointsMethodStateMethodCallHandler(
        ISystemContext _context,
        MethodState _method,
        NodeId _objectId,
        Opc.Ua.ApplicationDescription[] registrars);
    #endif
    #endregion

    #region DeviceRegistrationAuditEventState Class
    #if (!OPCUA_EXCLUDE_DeviceRegistrationAuditEventState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class DeviceRegistrationAuditEventState : AuditEventState
    {
        #region Constructors
        /// <remarks />
        public DeviceRegistrationAuditEventState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Onboarding.ObjectTypes.DeviceRegistrationAuditEventType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAACcAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvT25ib2FyZGluZy8gAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0dEUy//////BGCAAgEAAAABACgAAABEZXZpY2VSZWdpc3RyYXRpb25B" +
           "dWRpdEV2ZW50VHlwZUluc3RhbmNlAQHtBQEB7QXtBQAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50" +
           "SWQCAQBBQg8AAC4AREFCDwAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUCAQBC" +
           "Qg8AAC4AREJCDwAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAgEAQ0IPAAAu" +
           "AERDQg8AABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQIBAERCDwAALgBEREIP" +
           "AAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUCAQBFQg8AAC4AREVCDwABACYB/////wEB" +
           "/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAgEARkIPAAAuAERGQg8AAQAmAf////8BAf//" +
           "//8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAgEASEIPAAAuAERIQg8AABX/////AQH/////AAAAABVg" +
           "iQoCAAAAAAAIAAAAU2V2ZXJpdHkCAQBJQg8AAC4ARElCDwAABf////8BAf////8AAAAAFWCJCgIAAAAA" +
           "AA8AAABBY3Rpb25UaW1lU3RhbXACAQBOQg8AAC4ARE5CDwABACYB/////wEB/////wAAAAAVYIkKAgAA" +
           "AAAABgAAAFN0YXR1cwIBAE9CDwAALgBET0IPAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNl" +
           "cnZlcklkAgEAUEIPAAAuAERQQg8AAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVk" +
           "aXRFbnRyeUlkAgEAUUIPAAAuAERRQg8AAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50" +
           "VXNlcklkAgEAUkIPAAAuAERSQg8AAAz/////AQH/////AAAAABVgiQoCAAAAAQASAAAAUHJvZHVjdElu" +
           "c3RhbmNlVXJpAQH8BQAuAET8BQAAAQDHXP////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public PropertyState<string> ProductInstanceUri
        {
            get
            {
                return m_productInstanceUri;
            }

            set
            {
                if (!Object.ReferenceEquals(m_productInstanceUri, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_productInstanceUri = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <remarks />
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_productInstanceUri != null)
            {
                children.Add(m_productInstanceUri);
            }

            base.GetChildren(context, children);
        }
            
        /// <remarks />
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Onboarding.BrowseNames.ProductInstanceUri:
                {
                    if (createOrReplace)
                    {
                        if (ProductInstanceUri == null)
                        {
                            if (replacement == null)
                            {
                                ProductInstanceUri = new PropertyState<string>(this);
                            }
                            else
                            {
                                ProductInstanceUri = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = ProductInstanceUri;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<string> m_productInstanceUri;
        #endregion
    }
    #endif
    #endregion

    #region DeviceIdentityAcceptedAuditEventState Class
    #if (!OPCUA_EXCLUDE_DeviceIdentityAcceptedAuditEventState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class DeviceIdentityAcceptedAuditEventState : DeviceRegistrationAuditEventState
    {
        #region Constructors
        /// <remarks />
        public DeviceIdentityAcceptedAuditEventState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Onboarding.ObjectTypes.DeviceIdentityAcceptedAuditEventType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAACcAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvT25ib2FyZGluZy8gAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0dEUy//////BGCAAgEAAAABACwAAABEZXZpY2VJZGVudGl0eUFjY2Vw" +
           "dGVkQXVkaXRFdmVudFR5cGVJbnN0YW5jZQEB/QUBAf0F/QUAAP////8RAAAAFWCJCgIAAAAAAAcAAABF" +
           "dmVudElkAgEAU0IPAAAuAERTQg8AAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBl" +
           "AgEAVEIPAAAuAERUQg8AABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQIBAFVC" +
           "DwAALgBEVUIPAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUCAQBWQg8AAC4A" +
           "RFZCDwAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAgEAV0IPAAAuAERXQg8AAQAmAf//" +
           "//8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQIBAFhCDwAALgBEWEIPAAEAJgH/////" +
           "AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQIBAFpCDwAALgBEWkIPAAAV/////wEB/////wAA" +
           "AAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AgEAW0IPAAAuAERbQg8AAAX/////AQH/////AAAAABVgiQoC" +
           "AAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAgEAYEIPAAAuAERgQg8AAQAmAf////8BAf////8AAAAAFWCJ" +
           "CgIAAAAAAAYAAABTdGF0dXMCAQBhQg8AAC4ARGFCDwAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgA" +
           "AABTZXJ2ZXJJZAIBAGJCDwAALgBEYkIPAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVu" +
           "dEF1ZGl0RW50cnlJZAIBAGNCDwAALgBEY0IPAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENs" +
           "aWVudFVzZXJJZAIBAGRCDwAALgBEZEIPAAAM/////wEB/////wAAAAAVYIkKAgAAAAEAEgAAAFByb2R1" +
           "Y3RJbnN0YW5jZVVyaQIBAGVCDwAALgBEZUIPAAEAx1z/////AQH/////AAAAABVgiQoCAAAAAQALAAAA" +
           "Q2VydGlmaWNhdGUBAQ0GAC4ARA0GAAAAD/////8BAf////8AAAAAFWCJCgIAAAABAAYAAABUaWNrZXQB" +
           "AQ4GAC4ARA4GAAABAH5k/////wEB/////wAAAAAVYIkKAgAAAAEACQAAAENvbXBvc2l0ZQEBDwYALgBE" +
           "DwYAAAEAfmT/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public PropertyState<byte[]> Certificate
        {
            get
            {
                return m_certificate;
            }

            set
            {
                if (!Object.ReferenceEquals(m_certificate, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_certificate = value;
            }
        }

        /// <remarks />
        public PropertyState<string> Ticket
        {
            get
            {
                return m_ticket;
            }

            set
            {
                if (!Object.ReferenceEquals(m_ticket, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_ticket = value;
            }
        }

        /// <remarks />
        public PropertyState<string> Composite
        {
            get
            {
                return m_composite;
            }

            set
            {
                if (!Object.ReferenceEquals(m_composite, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_composite = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <remarks />
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_certificate != null)
            {
                children.Add(m_certificate);
            }

            if (m_ticket != null)
            {
                children.Add(m_ticket);
            }

            if (m_composite != null)
            {
                children.Add(m_composite);
            }

            base.GetChildren(context, children);
        }
            
        /// <remarks />
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Onboarding.BrowseNames.Certificate:
                {
                    if (createOrReplace)
                    {
                        if (Certificate == null)
                        {
                            if (replacement == null)
                            {
                                Certificate = new PropertyState<byte[]>(this);
                            }
                            else
                            {
                                Certificate = (PropertyState<byte[]>)replacement;
                            }
                        }
                    }

                    instance = Certificate;
                    break;
                }

                case Opc.Ua.Onboarding.BrowseNames.Ticket:
                {
                    if (createOrReplace)
                    {
                        if (Ticket == null)
                        {
                            if (replacement == null)
                            {
                                Ticket = new PropertyState<string>(this);
                            }
                            else
                            {
                                Ticket = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Ticket;
                    break;
                }

                case Opc.Ua.Onboarding.BrowseNames.Composite:
                {
                    if (createOrReplace)
                    {
                        if (Composite == null)
                        {
                            if (replacement == null)
                            {
                                Composite = new PropertyState<string>(this);
                            }
                            else
                            {
                                Composite = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Composite;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<byte[]> m_certificate;
        private PropertyState<string> m_ticket;
        private PropertyState<string> m_composite;
        #endregion
    }
    #endif
    #endregion

    #region DeviceSoftwareUpdatedAuditEventState Class
    #if (!OPCUA_EXCLUDE_DeviceSoftwareUpdatedAuditEventState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class DeviceSoftwareUpdatedAuditEventState : DeviceRegistrationAuditEventState
    {
        #region Constructors
        /// <remarks />
        public DeviceSoftwareUpdatedAuditEventState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Onboarding.ObjectTypes.DeviceSoftwareUpdatedAuditEventType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAACcAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvT25ib2FyZGluZy8gAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0dEUy//////BGCAAgEAAAABACsAAABEZXZpY2VTb2Z0d2FyZVVwZGF0" +
           "ZWRBdWRpdEV2ZW50VHlwZUluc3RhbmNlAQEQBgEBEAYQBgAA/////w8AAAAVYIkKAgAAAAAABwAAAEV2" +
           "ZW50SWQCAQBmQg8AAC4ARGZCDwAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUC" +
           "AQBnQg8AAC4ARGdCDwAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAgEAaEIP" +
           "AAAuAERoQg8AABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQIBAGlCDwAALgBE" +
           "aUIPAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUCAQBqQg8AAC4ARGpCDwABACYB////" +
           "/wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAgEAa0IPAAAuAERrQg8AAQAmAf////8B" +
           "Af////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAgEAbUIPAAAuAERtQg8AABX/////AQH/////AAAA" +
           "ABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkCAQBuQg8AAC4ARG5CDwAABf////8BAf////8AAAAAFWCJCgIA" +
           "AAAAAA8AAABBY3Rpb25UaW1lU3RhbXACAQBzQg8AAC4ARHNCDwABACYB/////wEB/////wAAAAAVYIkK" +
           "AgAAAAEABgAAAFN0YXR1cwEBGwYALgBEGwYAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNl" +
           "cnZlcklkAgEAdEIPAAAuAER0Qg8AAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVk" +
           "aXRFbnRyeUlkAgEAdUIPAAAuAER1Qg8AAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50" +
           "VXNlcklkAgEAdkIPAAAuAER2Qg8AAAz/////AQH/////AAAAABVgiQoCAAAAAQASAAAAUHJvZHVjdElu" +
           "c3RhbmNlVXJpAgEAd0IPAAAuAER3Qg8AAQDHXP////8BAf////8AAAAAFWCJCgIAAAABABAAAABTb2Z0" +
           "d2FyZVJldmlzaW9uAQEgBgAuAEQgBgAAAAz/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public PropertyState<string> SoftwareRevision
        {
            get
            {
                return m_softwareRevision;
            }

            set
            {
                if (!Object.ReferenceEquals(m_softwareRevision, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_softwareRevision = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <remarks />
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_softwareRevision != null)
            {
                children.Add(m_softwareRevision);
            }

            base.GetChildren(context, children);
        }
            
        /// <remarks />
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Onboarding.BrowseNames.SoftwareRevision:
                {
                    if (createOrReplace)
                    {
                        if (SoftwareRevision == null)
                        {
                            if (replacement == null)
                            {
                                SoftwareRevision = new PropertyState<string>(this);
                            }
                            else
                            {
                                SoftwareRevision = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = SoftwareRevision;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<string> m_softwareRevision;
        #endregion
    }
    #endif
    #endregion
}
