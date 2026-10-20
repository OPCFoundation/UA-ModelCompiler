/* ========================================================================
 * SPDX-FileCopyrightText: Copyright (c) 2005-2026, OPC Federation AISBL
 * SPDX-License-Identifier: MIT
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


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CA1515 // Consider making public types internal
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA1028 // Enum Storage should be Int32

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
           "AQAAACcAAAB1cm46b3BjZm91bmRhdGlvbi5vcmc6MjAyNC0wMTpEZW1vTW9kZWz/////FWCBAgIAAAAB" +
           "AB4AAABSZXN0cmljdGVkVmFyaWFibGVUeXBlSW5zdGFuY2UBAXoAAQF6AHoAAAAADAEB/////wQAAAAV" +
           "YIkLAgAAAAEABgAAAFllbGxvdwEBewAALwBEAE57AAAAAAb/////AQH/////AAAAABVgiQsCAAAAAQAB" +
           "AAAAWAEB0gAALwBEAE7SAAAAAAb/////AQH/////AAAAABVgiQsCAAAAAQABAAAAWQEB0wAALwBEAE7T" +
           "AAAAAAb/////AQH/////AAAAABVgiQsCAAAAAQABAAAAWgEB1AAALwBEAE7UAAAAAAb/////AQH/////" +
           "AAAAAA==";
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
           "AQAAACcAAAB1cm46b3BjZm91bmRhdGlvbi5vcmc6MjAyNC0wMTpEZW1vTW9kZWz/////BGCAAgEAAAAB" +
           "ABwAAABSZXN0cmljdGVkT2JqZWN0VHlwZUluc3RhbmNlAQF8AAEBfAB8AAAA/////wQAAAAEYIALAQAA" +
           "AAEABgAAAFB1cnBsZQEBewEALwEAVwkATnsBAAD/////BQAAABVgiQsCAAAAAAAMAAAAQ3VycmVudFN0" +
           "YXRlAQF9AQAvAQDICgBOfQEAAAAV/////wEB/////wIAAAAVYIkLAgAAAAAAAgAAAElkAQF+AQAuAEQA" +
           "Tn4BAAAAEf////8BAf////8AAAAAFWCJCwIAAAAAAAYAAABOdW1iZXIBAYABAC4ARABOgAEAAAAH////" +
           "/wEB/////wAAAAAVYIkLAgAAAAAADgAAAExhc3RUcmFuc2l0aW9uAQGCAQAvAQDPCgBOggEAAAAV////" +
           "/wEB/////wMAAAAVYIkLAgAAAAAAAgAAAElkAQGDAQAuAEQAToMBAAAAEf////8BAf////8AAAAAFWCJ" +
           "CwIAAAAAAAYAAABOdW1iZXIBAYUBAC4ARABOhQEAAAAH/////wEB/////wAAAAAVYIkLAgAAAAAADgAA" +
           "AFRyYW5zaXRpb25UaW1lAQGGAQAuAEQAToYBAAABACYB/////wEB/////wAAAAAVYIkLAgAAAAAACQAA" +
           "AERlbGV0YWJsZQEBigEALgBEAE6KAQAAAAH/////AQH/////AAAAABVgiQsCAAAAAAAKAAAAQXV0b0Rl" +
           "bGV0ZQEBiwEALgBEAE6LAQAAAAH/////AQH/////AAAAABVgiQsCAAAAAAAMAAAAUmVjeWNsZUNvdW50" +
           "AQGMAQAuAEQATowBAAAABv////8BAf////8AAAAAFWCJCwIAAAABAAMAAABSZWQBAX0AAC8BAXoAAE59" +
           "AAAAAAz/////AQH/////BAAAABVgiQsCAAAAAQAGAAAAWWVsbG93AQE5AAAvAEQATjkAAAAABv////8B" +
           "Af////8AAAAAFWCJCwIAAAABAAEAAABYAQHVAAAvAEQATtUAAAAABv////8BAf////8AAAAAFWCJCwIA" +
           "AAABAAEAAABZAQHWAAAvAEQATtYAAAAABv////8BAf////8AAAAAFWCJCwIAAAABAAEAAABaAQHXAAAv" +
           "AEQATtcAAAAABv////8BAf////8AAAAAFWDJCwIAAAAQAAAAUGlua19QbGFjZWhvbGRlcgEABgAAADxQ" +
           "aW5rPgEBhAAALwEBegABAPQshAAAAAAM/////wEB/////wQAAAAVYIkLAgAAAAEABgAAAFllbGxvdwEB" +
           "OgAALwBEAE46AAAAAAb/////AQH/////AAAAABVgiQsCAAAAAQABAAAAWAEB2AAALwBEAE7YAAAAAAb/" +
           "////AQH/////AAAAABVgiQsCAAAAAQABAAAAWQEB2QAALwBEAE7ZAAAAAAb/////AQH/////AAAAABVg" +
           "iQsCAAAAAQABAAAAWgEB2gAALwBEAE7aAAAAAAb/////AQH/////AAAAAARhggsEAAAAAQAIAAAAQmx1" +
           "ZVR5cGUBAVYBAC8BAVYBAE5WAQAAAQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        public ProgramStateMachineState Purple
        {
            get => m_purple;

            set
            {
                if (!Object.ReferenceEquals(m_purple, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_purple = value;
            }
        }

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
            if (m_purple != null)
            {
                children.Add(m_purple);
            }

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
            if (Object.ReferenceEquals(m_purple, child))
            {
                m_purple = null;
                return;
            }

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
                case DemoModel.BrowseNames.Purple:
                {
                    if (createOrReplace)
                    {
                        if (Purple == null)
                        {
                            if (replacement == null)
                            {
                                Purple = new ProgramStateMachineState(this);
                            }
                            else
                            {
                                Purple = (ProgramStateMachineState)replacement;
                            }
                        }
                    }

                    instance = Purple;
                    break;
                }

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
        private ProgramStateMachineState m_purple;
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
           "AQAAACcAAAB1cm46b3BjZm91bmRhdGlvbi5vcmc6MjAyNC0wMTpEZW1vTW9kZWz/////FWCBAgIAAAAB" +
           "ABIAAABZZWxsb3dUeXBlSW5zdGFuY2UBAVkBAQFZAVkBAAAADAEB/////wIAAAAVYKkLAgAAAAEABQAA" +
           "AFNoYWRlAQFaAQAuAEQATloBAAAMBAAAAFBhbGUADP////8BAf////8AAAAAFWCpCgIAAAAAABkAAABE" +
           "ZWZhdWx0SW5zdGFuY2VCcm93c2VOYW1lAQFbAQAuAERbAQAAFAEACwAAAFllbGxvd1RoaW5nABT/////" +
           "AQH/////AAAAAA==";
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

    #region BrightnessState Class
    #if (!OPCUA_EXCLUDE_BrightnessState)
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public partial class BrightnessState : BaseObjectState
    {
        #region Constructors
        public BrightnessState(NodeState parent) : base(parent)
        {
        }

        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DemoModel.ObjectTypes.BrightnessType, DemoModel.Namespaces.DemoModel, namespaceUris);
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
           "AQAAACcAAAB1cm46b3BjZm91bmRhdGlvbi5vcmc6MjAyNC0wMTpEZW1vTW9kZWz/////BGCAAgEAAAAB" +
           "ABYAAABCcmlnaHRuZXNzVHlwZUluc3RhbmNlAQFsAQEBbAFsAQAA/////wIAAAAEYMALAQAAABEAAABB" +
           "bWJlcl9QbGFjZWhvbGRlcgEABwAAADxBbWJlcj4BAW0BADEBAAMJAQD2LG0BAAD/////AQAAABVgiQsC" +
           "AAAAAAALAAAAU3RhdGVOdW1iZXIBAW4BAC4ARABObgEAAAAH/////wEB/////wAAAAAEYMALAQAAABEA" +
           "AABHcmVlbl9QbGFjZWhvbGRlcgEABwAAADxHcmVlbj4BAW8BACMBAPsIAQD0LG8BAAD/////AQAAABVg" +
           "iQsCAAAAAAAMAAAAQ3VycmVudFN0YXRlAQFwAQAvAQDDCgBOcAEAAAAV/////wEB/////wEAAAAVYIkL" +
           "AgAAAAAAAgAAAElkAQFxAQAuAEQATnEBAAAAGP////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
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
           "AQAAACcAAAB1cm46b3BjZm91bmRhdGlvbi5vcmc6MjAyNC0wMTpEZW1vTW9kZWz/////BGCAAgEAAAAB" +
           "ABMAAABQaWN0dXJlVHlwZUluc3RhbmNlAQFcAQEBXAFcAQAA/////wIAAAAVYIkLAgAAAAEACwAAAFll" +
           "bGxvd1RoaW5nAQFdAQAuAQFZAQBOXQEAAAAM/////wEB/////wEAAAAVYKkLAgAAAAEABQAAAFNoYWRl" +
           "AQFeAQAuAEQATl4BAAAMBAAAAFBhbGUADP////8BAf////8AAAAABGDACwEAAAASAAAASW5kaWdvX1Bs" +
           "YWNlaG9sZGVyAQAIAAAAPEluZGlnbz4BAXwBAC8BAWwBAQD2LHwBAAD/////AAAAAA==";
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
           "AQAAACcAAAB1cm46b3BjZm91bmRhdGlvbi5vcmc6MjAyNC0wMTpEZW1vTW9kZWz/////F2CJCwIAAAAB" +
           "AAEAAABYAQF5AAAvAD8AUHkAAAAABgIAAAACAAAAAAAAAAAAAAABAf////8AAAAA";

        private const string InitializationString =
           "AQAAACcAAAB1cm46b3BjZm91bmRhdGlvbi5vcmc6MjAyNC0wMTpEZW1vTW9kZWz/////BGCAAgEAAAAB" +
           "ACYAAABXaXRoVHdvRGltZW5zaW9uYWxWYXJpYWJsZVR5cGVJbnN0YW5jZQEBeAABAXgAeAAAAP////8B" +
           "AAAAF2CJCwIAAAABAAEAAABYAQF5AAAvAD8AUHkAAAAABgIAAAACAAAAAAAAAAAAAAABAf////8AAAAA";
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
