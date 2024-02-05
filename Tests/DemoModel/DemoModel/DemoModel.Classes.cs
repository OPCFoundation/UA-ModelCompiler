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
using Opc.Ua;

namespace DemoModel
{
    #region RestrictedVariableState Class
    #if (!OPCUA_EXCLUDE_RestrictedVariableState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class RestrictedVariableState : BaseDataVariableState<string>
    {
        #region Constructors
        /// <remarks />
        public RestrictedVariableState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DemoModel.VariableTypes.RestrictedVariableType, DemoModel.Namespaces.DemoModel, namespaceUris);
        }

        /// <remarks />
        protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.DataTypes.String, Opc.Ua.Namespaces.OpcUa, namespaceUris);
        }

        /// <remarks />
        protected override int GetDefaultValueRank()
        {
            return ValueRanks.Scalar;
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
           "AgAAACgAAAB0YWc6b3BjLWZvdW5kYXRpb24ub3JnLDIwMjQtMDE6RGVtb01vZGVsHwAAAGh0dHA6Ly9v" +
           "cGNmb3VuZGF0aW9uLm9yZy9VQS9ESS//////FWCBAgIAAAABAB4AAABSZXN0cmljdGVkVmFyaWFibGVU" +
           "eXBlSW5zdGFuY2UBAXoAAQF6AHoAAAAADAEB/////wEAAAAVYIkKAgAAAAEABgAAAFllbGxvdwEBewAA" +
           "LwBEewAAAAAG/////wEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public PropertyState<int> Yellow
        {
            get
            {
                return m_yellow;
            }

            set
            {
                if (!Object.ReferenceEquals(m_yellow, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_yellow = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <remarks />
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_yellow != null)
            {
                children.Add(m_yellow);
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
                case DemoModel.BrowseNames.Yellow:
                {
                    if (createOrReplace)
                    {
                        if (Yellow == null)
                        {
                            if (replacement == null)
                            {
                                Yellow = new PropertyState<int>(this);
                            }
                            else
                            {
                                Yellow = (PropertyState<int>)replacement;
                            }
                        }
                    }

                    instance = Yellow;
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
        private PropertyState<int> m_yellow;
        #endregion
    }
    #endif
    #endregion

    #region RestrictedObjectState Class
    #if (!OPCUA_EXCLUDE_RestrictedObjectState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class RestrictedObjectState : BaseObjectState
    {
        #region Constructors
        /// <remarks />
        public RestrictedObjectState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DemoModel.ObjectTypes.RestrictedObjectType, DemoModel.Namespaces.DemoModel, namespaceUris);
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
           "AgAAACgAAAB0YWc6b3BjLWZvdW5kYXRpb24ub3JnLDIwMjQtMDE6RGVtb01vZGVsHwAAAGh0dHA6Ly9v" +
           "cGNmb3VuZGF0aW9uLm9yZy9VQS9ESS//////BGCAAgEAAAABABwAAABSZXN0cmljdGVkT2JqZWN0VHlw" +
           "ZUluc3RhbmNlAQF8AAEBfAB8AAAA/////wIAAAAVYIkKAgAAAAEAAwAAAFJlZAEBfQAALwEBegB9AAAA" +
           "AAz/////AQH/////AQAAABVgiQoCAAAAAQAGAAAAWWVsbG93AQE5AAAvAEQ5AAAAAAb/////AQH/////" +
           "AAAAAARhggoEAAAAAQAEAAAAQmx1ZQEBfwAALwEBfwB/AAAAAQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public RestrictedVariableState Red
        {
            get
            {
                return m_red;
            }

            set
            {
                if (!Object.ReferenceEquals(m_red, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_red = value;
            }
        }

        /// <remarks />
        public MethodState Blue
        {
            get
            {
                return m_blueMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_blueMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_blueMethod = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <remarks />
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_red != null)
            {
                children.Add(m_red);
            }

            if (m_blueMethod != null)
            {
                children.Add(m_blueMethod);
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
                case DemoModel.BrowseNames.Red:
                {
                    if (createOrReplace)
                    {
                        if (Red == null)
                        {
                            if (replacement == null)
                            {
                                Red = new RestrictedVariableState(this);
                            }
                            else
                            {
                                Red = (RestrictedVariableState)replacement;
                            }
                        }
                    }

                    instance = Red;
                    break;
                }

                case DemoModel.BrowseNames.Blue:
                {
                    if (createOrReplace)
                    {
                        if (Blue == null)
                        {
                            if (replacement == null)
                            {
                                Blue = new MethodState(this);
                            }
                            else
                            {
                                Blue = (MethodState)replacement;
                            }
                        }
                    }

                    instance = Blue;
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
        private RestrictedVariableState m_red;
        private MethodState m_blueMethod;
        #endregion
    }
    #endif
    #endregion

    #region WithTwoDimensionalVariableState Class
    #if (!OPCUA_EXCLUDE_WithTwoDimensionalVariableState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class WithTwoDimensionalVariableState : BaseObjectState
    {
        #region Constructors
        /// <remarks />
        public WithTwoDimensionalVariableState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DemoModel.ObjectTypes.WithTwoDimensionalVariableType, DemoModel.Namespaces.DemoModel, namespaceUris);
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

            if (X != null)
            {
                X.Initialize(context, X_InitializationString);
            }
        }

        #region Initialization String
        private const string X_InitializationString =
           "AgAAACgAAAB0YWc6b3BjLWZvdW5kYXRpb24ub3JnLDIwMjQtMDE6RGVtb01vZGVsHwAAAGh0dHA6Ly9v" +
           "cGNmb3VuZGF0aW9uLm9yZy9VQS9ESS//////F2CJCgIAAAABAAEAAABYAQF5AAAvAD95AAAAAAYCAAAA" +
           "AgAAAAAAAAAAAAAAAQH/////AAAAAA==";

        private const string InitializationString =
           "AgAAACgAAAB0YWc6b3BjLWZvdW5kYXRpb24ub3JnLDIwMjQtMDE6RGVtb01vZGVsHwAAAGh0dHA6Ly9v" +
           "cGNmb3VuZGF0aW9uLm9yZy9VQS9ESS//////BGCAAgEAAAABACYAAABXaXRoVHdvRGltZW5zaW9uYWxW" +
           "YXJpYWJsZVR5cGVJbnN0YW5jZQEBeAABAXgAeAAAAP////8BAAAAF2CJCgIAAAABAAEAAABYAQF5AAAv" +
           "AD95AAAAAAYCAAAAAgAAAAAAAAAAAAAAAQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public BaseDataVariableState X
        {
            get
            {
                return m_x;
            }

            set
            {
                if (!Object.ReferenceEquals(m_x, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_x = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <remarks />
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_x != null)
            {
                children.Add(m_x);
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
                case DemoModel.BrowseNames.X:
                {
                    if (createOrReplace)
                    {
                        if (X == null)
                        {
                            if (replacement == null)
                            {
                                X = new BaseDataVariableState(this);
                            }
                            else
                            {
                                X = (BaseDataVariableState)replacement;
                            }
                        }
                    }

                    instance = X;
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
        private BaseDataVariableState m_x;
        #endregion
    }
    #endif
    #endregion
}
