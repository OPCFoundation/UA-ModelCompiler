/* ========================================================================
 * Copyright (c) 2005-2025 The OPC Foundation, Inc. All rights reserved.
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
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Threading;
using Opc.Ua;

#pragma warning disable 1591

namespace DemoModel
{
    #region RestrictedVariableState Class
    #if (!OPCUA_EXCLUDE_RestrictedVariableState)
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public partial class RestrictedVariableState : BaseDataVariableState
    {
        #region Constructors
        public RestrictedVariableState(NodeState parent) : base(parent)
        {
        }

        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DemoModel.VariableTypes.RestrictedVariableType, DemoModel.Namespaces.DemoModel, namespaceUris);
        }

        protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.DataTypes.String, Opc.Ua.Namespaces.OpcUa, namespaceUris);
        }

        protected override int GetDefaultValueRank()
        {
            return ValueRanks.Any;
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAACcAAAB1cm46b3BjZm91bmRhdGlvbi5vcmc6MjAyNC0wMTpEZW1vTW9kZWwfAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0RJL/////8VYIECAgAAAAEAHgAAAFJlc3RyaWN0ZWRWYXJpYWJsZVR5" +
           "cGVJbnN0YW5jZQEBegABAXoAegAAAAAMAQH/////BAAAABVgiQoCAAAAAQAGAAAAWWVsbG93AQF7AAAv" +
           "AER7AAAAAAb/////AQH/////AAAAABVgiQoCAAAAAQABAAAAWAEB0gAALwBE0gAAAAAG/////wEB////" +
           "/wAAAAAVYIkKAgAAAAEAAQAAAFkBAdMAAC8ARNMAAAAABv////8BAf////8AAAAAFWCJCgIAAAABAAEA" +
           "AABaAQHUAAAvAETUAAAAAAb/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        public PropertyState<int> Yellow
        {
            get => m_yellow;

            set
            {
                if (!Object.ReferenceEquals(m_yellow, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_yellow = value;
            }
        }

        public PropertyState<int> X
        {
            get => m_x;

            set
            {
                if (!Object.ReferenceEquals(m_x, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_x = value;
            }
        }

        public PropertyState<int> Y
        {
            get => m_y;

            set
            {
                if (!Object.ReferenceEquals(m_y, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_y = value;
            }
        }

        public PropertyState<int> Z
        {
            get => m_z;

            set
            {
                if (!Object.ReferenceEquals(m_z, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_z = value;
            }
        }
        #endregion

        #region Overridden Methods
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_yellow != null)
            {
                children.Add(m_yellow);
            }

            if (m_x != null)
            {
                children.Add(m_x);
            }

            if (m_y != null)
            {
                children.Add(m_y);
            }

            if (m_z != null)
            {
                children.Add(m_z);
            }

            base.GetChildren(context, children);
        }
            
        protected override void RemoveExplicitlyDefinedChild(BaseInstanceState child)
        {
            if (Object.ReferenceEquals(m_yellow, child))
            {
                m_yellow = null;
                return;
            }

            if (Object.ReferenceEquals(m_x, child))
            {
                m_x = null;
                return;
            }

            if (Object.ReferenceEquals(m_y, child))
            {
                m_y = null;
                return;
            }

            if (Object.ReferenceEquals(m_z, child))
            {
                m_z = null;
                return;
            }

            base.RemoveExplicitlyDefinedChild(child);
        }

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

                case DemoModel.BrowseNames.X:
                {
                    if (createOrReplace)
                    {
                        if (X == null)
                        {
                            if (replacement == null)
                            {
                                X = new PropertyState<int>(this);
                            }
                            else
                            {
                                X = (PropertyState<int>)replacement;
                            }
                        }
                    }

                    instance = X;
                    break;
                }

                case DemoModel.BrowseNames.Y:
                {
                    if (createOrReplace)
                    {
                        if (Y == null)
                        {
                            if (replacement == null)
                            {
                                Y = new PropertyState<int>(this);
                            }
                            else
                            {
                                Y = (PropertyState<int>)replacement;
                            }
                        }
                    }

                    instance = Y;
                    break;
                }

                case DemoModel.BrowseNames.Z:
                {
                    if (createOrReplace)
                    {
                        if (Z == null)
                        {
                            if (replacement == null)
                            {
                                Z = new PropertyState<int>(this);
                            }
                            else
                            {
                                Z = (PropertyState<int>)replacement;
                            }
                        }
                    }

                    instance = Z;
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
        private PropertyState<int> m_x;
        private PropertyState<int> m_y;
        private PropertyState<int> m_z;
        #endregion
    }

    #region RestrictedVariableState<T> Class
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public class RestrictedVariableState<T> : RestrictedVariableState
    {
        #region Constructors
        public RestrictedVariableState(NodeState parent) : base(parent)
        {
            Value = default(T);
        }

        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);

            Value = default(T);
            DataType = TypeInfo.GetDataTypeId(typeof(T));
            ValueRank = TypeInfo.GetValueRank(typeof(T));
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }
        #endregion

        #region Public Members
        public new T Value
        {
            get
            {
                return CheckTypeBeforeCast<T>(((BaseVariableState)this).Value, true);
            }

            set
            {
                ((BaseVariableState)this).Value = value;
            }
        }
        #endregion
    }
    #endregion
    #endif
    #endregion

    #region RestrictedObjectState Class
    #if (!OPCUA_EXCLUDE_RestrictedObjectState)
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public partial class RestrictedObjectState : BaseObjectState
    {
        #region Constructors
        public RestrictedObjectState(NodeState parent) : base(parent)
        {
        }

        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DemoModel.ObjectTypes.RestrictedObjectType, DemoModel.Namespaces.DemoModel, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAACcAAAB1cm46b3BjZm91bmRhdGlvbi5vcmc6MjAyNC0wMTpEZW1vTW9kZWwfAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0RJL/////8EYIACAQAAAAEAHAAAAFJlc3RyaWN0ZWRPYmplY3RUeXBl" +
           "SW5zdGFuY2UBAXwAAQF8AHwAAAD/////AwAAABVgiQoCAAAAAQADAAAAUmVkAQF9AAAvAQF6AH0AAAAA" +
           "DP////8BAf////8EAAAAFWCJCgIAAAABAAYAAABZZWxsb3cBATkAAC8ARDkAAAAABv////8BAf////8A" +
           "AAAAFWCJCgIAAAABAAEAAABYAQHVAAAvAETVAAAAAAb/////AQH/////AAAAABVgiQoCAAAAAQABAAAA" +
           "WQEB1gAALwBE1gAAAAAG/////wEB/////wAAAAAVYIkKAgAAAAEAAQAAAFoBAdcAAC8ARNcAAAAABv//" +
           "//8BAf////8AAAAAFWDJCgIAAAAQAAAAUGlua19QbGFjZWhvbGRlcgEABgAAADxQaW5rPgEBhAAALwEB" +
           "egCEAAAAAAz/////AQH/////BAAAABVgiQoCAAAAAQAGAAAAWWVsbG93AQE6AAAvAEQ6AAAAAAb/////" +
           "AQH/////AAAAABVgiQoCAAAAAQABAAAAWAEB2AAALwBE2AAAAAAG/////wEB/////wAAAAAVYIkKAgAA" +
           "AAEAAQAAAFkBAdkAAC8ARNkAAAAABv////8BAf////8AAAAAFWCJCgIAAAABAAEAAABaAQHaAAAvAETa" +
           "AAAAAAb/////AQH/////AAAAAARhggoEAAAAAQAIAAAAQmx1ZVR5cGUBAVYBAC8BAVYBVgEAAAEB////" +
           "/wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        public RestrictedVariableState<string> Red
        {
            get => m_red;

            set
            {
                if (!Object.ReferenceEquals(m_red, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_red = value;
            }
        }

        public MethodState BlueType
        {
            get => m_blueTypeMethod;

            set
            {
                if (!Object.ReferenceEquals(m_blueTypeMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_blueTypeMethod = value;
            }
        }
        #endregion

        #region Overridden Methods
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_red != null)
            {
                children.Add(m_red);
            }

            if (m_blueTypeMethod != null)
            {
                children.Add(m_blueTypeMethod);
            }

            base.GetChildren(context, children);
        }
            
        protected override void RemoveExplicitlyDefinedChild(BaseInstanceState child)
        {
            if (Object.ReferenceEquals(m_red, child))
            {
                m_red = null;
                return;
            }

            if (Object.ReferenceEquals(m_blueTypeMethod, child))
            {
                m_blueTypeMethod = null;
                return;
            }

            base.RemoveExplicitlyDefinedChild(child);
        }

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
                                Red = new RestrictedVariableState<string>(this);
                            }
                            else
                            {
                                Red = (RestrictedVariableState<string>)replacement;
                            }
                        }
                    }

                    instance = Red;
                    break;
                }

                case DemoModel.BrowseNames.BlueType:
                {
                    if (createOrReplace)
                    {
                        if (BlueType == null)
                        {
                            if (replacement == null)
                            {
                                BlueType = new MethodState(this);
                            }
                            else
                            {
                                BlueType = (MethodState)replacement;
                            }
                        }
                    }

                    instance = BlueType;
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
        private RestrictedVariableState<string> m_red;
        private MethodState m_blueTypeMethod;
        #endregion
    }
    #endif
    #endregion

    #region YellowState Class
    #if (!OPCUA_EXCLUDE_YellowState)
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public partial class YellowState : BaseDataVariableState
    {
        #region Constructors
        public YellowState(NodeState parent) : base(parent)
        {
        }

        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DemoModel.VariableTypes.YellowType, DemoModel.Namespaces.DemoModel, namespaceUris);
        }

        protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.DataTypes.String, Opc.Ua.Namespaces.OpcUa, namespaceUris);
        }

        protected override int GetDefaultValueRank()
        {
            return ValueRanks.Any;
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAACcAAAB1cm46b3BjZm91bmRhdGlvbi5vcmc6MjAyNC0wMTpEZW1vTW9kZWwfAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0RJL/////8VYIECAgAAAAEAEgAAAFllbGxvd1R5cGVJbnN0YW5jZQEB" +
           "WQEBAVkBWQEAAAAMAQH/////AgAAABVgqQoCAAAAAQAFAAAAU2hhZGUBAVoBAC4ARFoBAAAMBAAAAFBh" +
           "bGUADP////8BAf////8AAAAAFWCpCgIAAAAAABkAAABEZWZhdWx0SW5zdGFuY2VCcm93c2VOYW1lAQFb" +
           "AQAuAERbAQAAFAEACwAAAFllbGxvd1RoaW5nABT/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        public PropertyState<string> Shade
        {
            get => m_shade;

            set
            {
                if (!Object.ReferenceEquals(m_shade, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_shade = value;
            }
        }
        #endregion

        #region Overridden Methods
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_shade != null)
            {
                children.Add(m_shade);
            }

            base.GetChildren(context, children);
        }
            
        protected override void RemoveExplicitlyDefinedChild(BaseInstanceState child)
        {
            if (Object.ReferenceEquals(m_shade, child))
            {
                m_shade = null;
                return;
            }

            base.RemoveExplicitlyDefinedChild(child);
        }

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
                case DemoModel.BrowseNames.Shade:
                {
                    if (createOrReplace)
                    {
                        if (Shade == null)
                        {
                            if (replacement == null)
                            {
                                Shade = new PropertyState<string>(this);
                            }
                            else
                            {
                                Shade = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Shade;
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
        private PropertyState<string> m_shade;
        #endregion
    }

    #region YellowState<T> Class
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public class YellowState<T> : YellowState
    {
        #region Constructors
        public YellowState(NodeState parent) : base(parent)
        {
            Value = default(T);
        }

        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);

            Value = default(T);
            DataType = TypeInfo.GetDataTypeId(typeof(T));
            ValueRank = TypeInfo.GetValueRank(typeof(T));
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }
        #endregion

        #region Public Members
        public new T Value
        {
            get
            {
                return CheckTypeBeforeCast<T>(((BaseVariableState)this).Value, true);
            }

            set
            {
                ((BaseVariableState)this).Value = value;
            }
        }
        #endregion
    }
    #endregion
    #endif
    #endregion

    #region PictureState Class
    #if (!OPCUA_EXCLUDE_PictureState)
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public partial class PictureState : BaseObjectState
    {
        #region Constructors
        public PictureState(NodeState parent) : base(parent)
        {
        }

        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DemoModel.ObjectTypes.PictureType, DemoModel.Namespaces.DemoModel, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAACcAAAB1cm46b3BjZm91bmRhdGlvbi5vcmc6MjAyNC0wMTpEZW1vTW9kZWwfAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0RJL/////8EYIACAQAAAAEAEwAAAFBpY3R1cmVUeXBlSW5zdGFuY2UB" +
           "AVwBAQFcAVwBAAD/////AQAAABVgiQoCAAAAAQALAAAAWWVsbG93VGhpbmcBAV0BAC4BAVkBXQEAAAAM" +
           "/////wEB/////wEAAAAVYKkKAgAAAAEABQAAAFNoYWRlAQFeAQAuAEReAQAADAQAAABQYWxlAAz/////" +
           "AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        public YellowState<string> YellowThing
        {
            get => m_yellowThing;

            set
            {
                if (!Object.ReferenceEquals(m_yellowThing, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_yellowThing = value;
            }
        }
        #endregion

        #region Overridden Methods
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_yellowThing != null)
            {
                children.Add(m_yellowThing);
            }

            base.GetChildren(context, children);
        }
            
        protected override void RemoveExplicitlyDefinedChild(BaseInstanceState child)
        {
            if (Object.ReferenceEquals(m_yellowThing, child))
            {
                m_yellowThing = null;
                return;
            }

            base.RemoveExplicitlyDefinedChild(child);
        }

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
                case DemoModel.BrowseNames.YellowThing:
                {
                    if (createOrReplace)
                    {
                        if (YellowThing == null)
                        {
                            if (replacement == null)
                            {
                                YellowThing = new YellowState<string>(this);
                            }
                            else
                            {
                                YellowThing = (YellowState<string>)replacement;
                            }
                        }
                    }

                    instance = YellowThing;
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
        private YellowState<string> m_yellowThing;
        #endregion
    }
    #endif
    #endregion

    #region WithTwoDimensionalVariableState Class
    #if (!OPCUA_EXCLUDE_WithTwoDimensionalVariableState)
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public partial class WithTwoDimensionalVariableState : BaseObjectState
    {
        #region Constructors
        public WithTwoDimensionalVariableState(NodeState parent) : base(parent)
        {
        }

        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DemoModel.ObjectTypes.WithTwoDimensionalVariableType, DemoModel.Namespaces.DemoModel, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

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
           "AgAAACcAAAB1cm46b3BjZm91bmRhdGlvbi5vcmc6MjAyNC0wMTpEZW1vTW9kZWwfAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0RJL/////8XYIkKAgAAAAEAAQAAAFgBAXkAAC8AP3kAAAAABgIAAAAC" +
           "AAAAAAAAAAAAAAABAf////8AAAAA";

        private const string InitializationString =
           "AgAAACcAAAB1cm46b3BjZm91bmRhdGlvbi5vcmc6MjAyNC0wMTpEZW1vTW9kZWwfAAAAaHR0cDovL29w" +
           "Y2ZvdW5kYXRpb24ub3JnL1VBL0RJL/////8EYIACAQAAAAEAJgAAAFdpdGhUd29EaW1lbnNpb25hbFZh" +
           "cmlhYmxlVHlwZUluc3RhbmNlAQF4AAEBeAB4AAAA/////wEAAAAXYIkKAgAAAAEAAQAAAFgBAXkAAC8A" +
           "P3kAAAAABgIAAAACAAAAAAAAAAAAAAABAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        public BaseDataVariableState X
        {
            get => m_x;

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
            
        protected override void RemoveExplicitlyDefinedChild(BaseInstanceState child)
        {
            if (Object.ReferenceEquals(m_x, child))
            {
                m_x = null;
                return;
            }

            base.RemoveExplicitlyDefinedChild(child);
        }

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
