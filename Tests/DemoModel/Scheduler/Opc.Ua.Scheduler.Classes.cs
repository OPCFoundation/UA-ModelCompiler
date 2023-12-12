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

namespace Opc.Ua.Scheduler
{
    #region CalendarState Class
    #if (!OPCUA_EXCLUDE_CalendarState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class CalendarState : BaseObjectState
    {
        #region Constructors
        /// <remarks />
        public CalendarState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Scheduler.ObjectTypes.CalendarType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler, namespaceUris);
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

            if (AddDateListElements != null)
            {
                AddDateListElements.Initialize(context, AddDateListElements_InitializationString);
            }

            if (RemoveDateListElements != null)
            {
                RemoveDateListElements.Initialize(context, RemoveDateListElements_InitializationString);
            }
        }

        #region Initialization String
        private const string AddDateListElements_InitializationString =
           "AQAAACYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvU2NoZWR1bGVyL/////8kYYIKBAAAAAEA" +
           "EwAAAEFkZERhdGVMaXN0RWxlbWVudHMBASgAAwAAAAAdAAAAQWRkcyBlbGVtZW50cyB0byB0aGUgRGF0" +
           "ZUxpc3QALwEBKAAoAAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBASkAAC4A" +
           "RCkAAACWAQAAAAEAKgEBJAAAAA8AAABDYWxlbmRhckVudHJpZXMBAUgAAQAAAAEAAAAAAAAAAAEAKAEB" +
           "AAAAAQAAAAEAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBASoAAC4ARCoA" +
           "AACWAQAAAAEAKgEBHwAAAAwAAABFbnRyeVJlc3VsdHMABgEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAB" +
           "AAAAAQH/////AAAAAA==";

        private const string RemoveDateListElements_InitializationString =
           "AQAAACYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvU2NoZWR1bGVyL/////8kYYIKBAAAAAEA" +
           "FgAAAFJlbW92ZURhdGVMaXN0RWxlbWVudHMBASsAAwAAAAAgAAAAUmVtb3ZlcyBlbGVtZW50cyBvZiB0" +
           "aGUgRGF0ZUxpc3QALwEBKwArAAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMB" +
           "ASwAAC4ARCwAAACWAQAAAAEAKgEBJAAAAA8AAABDYWxlbmRhckVudHJpZXMBAUgAAQAAAAEAAAAAAAAA" +
           "AAEAKAEBAAAAAQAAAAEAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAS0A" +
           "AC4ARC0AAACWAQAAAAEAKgEBHwAAAAwAAABFbnRyeVJlc3VsdHMABgEAAAABAAAAAAAAAAABACgBAQAA" +
           "AAEAAAABAAAAAQH/////AAAAAA==";

        private const string InitializationString =
           "AQAAACYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvU2NoZWR1bGVyL/////8EYIACAQAAAAEA" +
           "FAAAAENhbGVuZGFyVHlwZUluc3RhbmNlAQElAAEBJQAlAAAA/////wQAAAA1YIkKAgAAAAEADAAAAFBy" +
           "ZXNlbnRWYWx1ZQEBJgADAAAAAEYAAABJbmRpY2F0ZXMgaWYgdGhlIGN1cnJlbnQgZGF0ZSBpcyBpbiB0" +
           "aGUgRGF0ZUxpc3QgKHRydWUpIG9yIG5vdCAoZmFsc2UpAC8APyYAAAAAAf////8BAf////8AAAAAN2CJ" +
           "CgIAAAABAAgAAABEYXRlTGlzdAEBJwADAAAAAFkAAABBcnJheSBvZiBlbGVtZW50cyBlYWNoIGRlZmlu" +
           "aW5nIGVpdGhlciBhIHNwZWNpZmljIGRhdGUgb3IgZGF0ZSBwYXR0ZXJuLCBvciByYW5nZSBvZiBkYXRl" +
           "cwAuAEQnAAAAAQFIAAEAAAABAAAAAAAAAAEB/////wAAAAAkYYIKBAAAAAEAEwAAAEFkZERhdGVMaXN0" +
           "RWxlbWVudHMBASgAAwAAAAAdAAAAQWRkcyBlbGVtZW50cyB0byB0aGUgRGF0ZUxpc3QALwEBKAAoAAAA" +
           "AQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBASkAAC4ARCkAAACWAQAAAAEAKgEB" +
           "JAAAAA8AAABDYWxlbmRhckVudHJpZXMBAUgAAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAEAAAABAf//" +
           "//8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBASoAAC4ARCoAAACWAQAAAAEAKgEBHwAA" +
           "AAwAAABFbnRyeVJlc3VsdHMABgEAAAABAAAAAAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAACRh" +
           "ggoEAAAAAQAWAAAAUmVtb3ZlRGF0ZUxpc3RFbGVtZW50cwEBKwADAAAAACAAAABSZW1vdmVzIGVsZW1l" +
           "bnRzIG9mIHRoZSBEYXRlTGlzdAAvAQErACsAAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFy" +
           "Z3VtZW50cwEBLAAALgBELAAAAJYBAAAAAQAqAQEkAAAADwAAAENhbGVuZGFyRW50cmllcwEBSAABAAAA" +
           "AQAAAAAAAAAAAQAoAQEAAAABAAAAAQAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3Vt" +
           "ZW50cwEBLQAALgBELQAAAJYBAAAAAQAqAQEfAAAADAAAAEVudHJ5UmVzdWx0cwAGAQAAAAEAAAAAAAAA" +
           "AAEAKAEBAAAAAQAAAAEAAAABAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public BaseDataVariableState<bool> PresentValue
        {
            get
            {
                return m_presentValue;
            }

            set
            {
                if (!Object.ReferenceEquals(m_presentValue, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_presentValue = value;
            }
        }

        /// <remarks />
        public PropertyState<CalendarEntryType[]> DateList
        {
            get
            {
                return m_dateList;
            }

            set
            {
                if (!Object.ReferenceEquals(m_dateList, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_dateList = value;
            }
        }

        /// <remarks />
        public AddDateListElementsMethodState AddDateListElements
        {
            get
            {
                return m_addDateListElementsMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_addDateListElementsMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_addDateListElementsMethod = value;
            }
        }

        /// <remarks />
        public RemoveDateListElementsMethodState RemoveDateListElements
        {
            get
            {
                return m_removeDateListElementsMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_removeDateListElementsMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_removeDateListElementsMethod = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <remarks />
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_presentValue != null)
            {
                children.Add(m_presentValue);
            }

            if (m_dateList != null)
            {
                children.Add(m_dateList);
            }

            if (m_addDateListElementsMethod != null)
            {
                children.Add(m_addDateListElementsMethod);
            }

            if (m_removeDateListElementsMethod != null)
            {
                children.Add(m_removeDateListElementsMethod);
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
                case Opc.Ua.Scheduler.BrowseNames.PresentValue:
                {
                    if (createOrReplace)
                    {
                        if (PresentValue == null)
                        {
                            if (replacement == null)
                            {
                                PresentValue = new BaseDataVariableState<bool>(this);
                            }
                            else
                            {
                                PresentValue = (BaseDataVariableState<bool>)replacement;
                            }
                        }
                    }

                    instance = PresentValue;
                    break;
                }

                case Opc.Ua.Scheduler.BrowseNames.DateList:
                {
                    if (createOrReplace)
                    {
                        if (DateList == null)
                        {
                            if (replacement == null)
                            {
                                DateList = new PropertyState<CalendarEntryType[]>(this);
                            }
                            else
                            {
                                DateList = (PropertyState<CalendarEntryType[]>)replacement;
                            }
                        }
                    }

                    instance = DateList;
                    break;
                }

                case Opc.Ua.Scheduler.BrowseNames.AddDateListElements:
                {
                    if (createOrReplace)
                    {
                        if (AddDateListElements == null)
                        {
                            if (replacement == null)
                            {
                                AddDateListElements = new AddDateListElementsMethodState(this);
                            }
                            else
                            {
                                AddDateListElements = (AddDateListElementsMethodState)replacement;
                            }
                        }
                    }

                    instance = AddDateListElements;
                    break;
                }

                case Opc.Ua.Scheduler.BrowseNames.RemoveDateListElements:
                {
                    if (createOrReplace)
                    {
                        if (RemoveDateListElements == null)
                        {
                            if (replacement == null)
                            {
                                RemoveDateListElements = new RemoveDateListElementsMethodState(this);
                            }
                            else
                            {
                                RemoveDateListElements = (RemoveDateListElementsMethodState)replacement;
                            }
                        }
                    }

                    instance = RemoveDateListElements;
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
        private BaseDataVariableState<bool> m_presentValue;
        private PropertyState<CalendarEntryType[]> m_dateList;
        private AddDateListElementsMethodState m_addDateListElementsMethod;
        private RemoveDateListElementsMethodState m_removeDateListElementsMethod;
        #endregion
    }
    #endif
    #endregion

    #region AddDateListElementsMethodState Class
    #if (!OPCUA_EXCLUDE_AddDateListElementsMethodState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AddDateListElementsMethodState : MethodState
    {
        #region Constructors
        /// <remarks />
        public AddDateListElementsMethodState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        public new static NodeState Construct(NodeState parent)
        {
            return new AddDateListElementsMethodState(parent);
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
           "AQAAACYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvU2NoZWR1bGVyL/////8kYYIKBAAAAAEA" +
           "HQAAAEFkZERhdGVMaXN0RWxlbWVudHNNZXRob2RUeXBlAQEuAAMAAAAAHQAAAEFkZHMgZWxlbWVudHMg" +
           "dG8gdGhlIERhdGVMaXN0AC8BAS4ALgAAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1l" +
           "bnRzAQEvAAAuAEQvAAAAlgEAAAABACoBASQAAAAPAAAAQ2FsZW5kYXJFbnRyaWVzAQFIAAEAAAABAAAA" +
           "AAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRz" +
           "AQEwAAAuAEQwAAAAlgEAAAABACoBAR8AAAAMAAAARW50cnlSZXN1bHRzAAYBAAAAAQAAAAAAAAAAAQAo" +
           "AQEAAAABAAAAAQAAAAEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <remarks />
        public AddDateListElementsMethodStateMethodCallHandler OnCall;
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

            CalendarEntryType[] calendarEntries = (CalendarEntryType[])ExtensionObject.ToArray(_inputArguments[0], typeof(CalendarEntryType));

            int[] entryResults = (int[])_outputArguments[0];

            if (OnCall != null)
            {
                _result = OnCall(
                    _context,
                    this,
                    _objectId,
                    calendarEntries,
                    ref entryResults);
            }

            _outputArguments[0] = entryResults;

            return _result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <remarks />
    /// <exclude />
    public delegate ServiceResult AddDateListElementsMethodStateMethodCallHandler(
        ISystemContext _context,
        MethodState _method,
        NodeId _objectId,
        CalendarEntryType[] calendarEntries,
        ref int[] entryResults);
    #endif
    #endregion

    #region RemoveDateListElementsMethodState Class
    #if (!OPCUA_EXCLUDE_RemoveDateListElementsMethodState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class RemoveDateListElementsMethodState : MethodState
    {
        #region Constructors
        /// <remarks />
        public RemoveDateListElementsMethodState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        public new static NodeState Construct(NodeState parent)
        {
            return new RemoveDateListElementsMethodState(parent);
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
           "AQAAACYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvU2NoZWR1bGVyL/////8kYYIKBAAAAAEA" +
           "IAAAAFJlbW92ZURhdGVMaXN0RWxlbWVudHNNZXRob2RUeXBlAQExAAMAAAAAIAAAAFJlbW92ZXMgZWxl" +
           "bWVudHMgb2YgdGhlIERhdGVMaXN0AC8BATEAMQAAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0" +
           "QXJndW1lbnRzAQEyAAAuAEQyAAAAlgEAAAABACoBASQAAAAPAAAAQ2FsZW5kYXJFbnRyaWVzAQFIAAEA" +
           "AAABAAAAAAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJn" +
           "dW1lbnRzAQEzAAAuAEQzAAAAlgEAAAABACoBAR8AAAAMAAAARW50cnlSZXN1bHRzAAYBAAAAAQAAAAAA" +
           "AAAAAQAoAQEAAAABAAAAAQAAAAEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <remarks />
        public RemoveDateListElementsMethodStateMethodCallHandler OnCall;
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

            CalendarEntryType[] calendarEntries = (CalendarEntryType[])ExtensionObject.ToArray(_inputArguments[0], typeof(CalendarEntryType));

            int[] entryResults = (int[])_outputArguments[0];

            if (OnCall != null)
            {
                _result = OnCall(
                    _context,
                    this,
                    _objectId,
                    calendarEntries,
                    ref entryResults);
            }

            _outputArguments[0] = entryResults;

            return _result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <remarks />
    /// <exclude />
    public delegate ServiceResult RemoveDateListElementsMethodStateMethodCallHandler(
        ISystemContext _context,
        MethodState _method,
        NodeId _objectId,
        CalendarEntryType[] calendarEntries,
        ref int[] entryResults);
    #endif
    #endregion

    #region ScheduleState Class
    #if (!OPCUA_EXCLUDE_ScheduleState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ScheduleState : BaseObjectState
    {
        #region Constructors
        /// <remarks />
        public ScheduleState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Scheduler.ObjectTypes.ScheduleType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler, namespaceUris);
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

            if (ExceptionSchedule != null)
            {
                ExceptionSchedule.Initialize(context, ExceptionSchedule_InitializationString);
            }

            if (AddExceptionScheduleElements != null)
            {
                AddExceptionScheduleElements.Initialize(context, AddExceptionScheduleElements_InitializationString);
            }

            if (RemoveExceptionScheduleElements != null)
            {
                RemoveExceptionScheduleElements.Initialize(context, RemoveExceptionScheduleElements_InitializationString);
            }

            if (WeeklySchedule != null)
            {
                WeeklySchedule.Initialize(context, WeeklySchedule_InitializationString);
            }

            if (EffectivePeriod != null)
            {
                EffectivePeriod.Initialize(context, EffectivePeriod_InitializationString);
            }
        }

        #region Initialization String
        private const string ExceptionSchedule_InitializationString =
           "AQAAACYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvU2NoZWR1bGVyL/////83YIkKAgAAAAEA" +
           "EQAAAEV4Y2VwdGlvblNjaGVkdWxlAQE1AAMAAAAAugAAAEFuIGFycmF5IG9mIHNwZWNpYWwgZXZlbnRz" +
           "LiBJZiBwcmVzZW50LCBlYWNoIG9mIHRob3NlIHNwZWNpYWwgZXZlbnRzIGRlc2NyaWJlcyBhIHNlcXVl" +
           "bmNlIG9mIHNjaGVkdWxlIGFjdGlvbnMgdGhhdCB0YWtlIHByZWNlZGVuY2Ugb3ZlciBhIG5vcm1hbCBk" +
           "YXkncyBiZWhhdmlvdXIgb24gYSBzcGVjaWFsIGRheSBvciBkYXlzLgAuAEQ1AAAAAQFGAAEAAAABAAAA" +
           "AAAAAAEB/////wAAAAA=";

        private const string AddExceptionScheduleElements_InitializationString =
           "AQAAACYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvU2NoZWR1bGVyL/////8kYYIKBAAAAAEA" +
           "HAAAAEFkZEV4Y2VwdGlvblNjaGVkdWxlRWxlbWVudHMBATYAAwAAAAAmAAAAQWRkcyBlbGVtZW50cyB0" +
           "byB0aGUgRXhjZXB0aW9uU2NoZWR1bGUALwEBNgA2AAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5w" +
           "dXRBcmd1bWVudHMBATcAAC4ARDcAAACWAQAAAAEAKgEBIgAAAA0AAABTcGVjaWFsRXZlbnRzAQFGAAEA" +
           "AAABAAAAAAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJn" +
           "dW1lbnRzAQE4AAAuAEQ4AAAAlgEAAAABACoBAR8AAAAMAAAARW50cnlSZXN1bHRzAAYBAAAAAQAAAAAA" +
           "AAAAAQAoAQEAAAABAAAAAQAAAAEB/////wAAAAA=";

        private const string RemoveExceptionScheduleElements_InitializationString =
           "AQAAACYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvU2NoZWR1bGVyL/////8kYYIKBAAAAAEA" +
           "HwAAAFJlbW92ZUV4Y2VwdGlvblNjaGVkdWxlRWxlbWVudHMBATkAAwAAAAArAAAAUmVtb3ZlcyBlbGVt" +
           "ZW50cyBmcm9tIHRoZSBFeGNlcHRpb25TY2hlZHVsZQAvAQE5ADkAAAABAf////8CAAAAF2CpCgIAAAAA" +
           "AA4AAABJbnB1dEFyZ3VtZW50cwEBOgAALgBEOgAAAJYBAAAAAQAqAQEiAAAADQAAAFNwZWNpYWxFdmVu" +
           "dHMBAUYAAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAEAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABP" +
           "dXRwdXRBcmd1bWVudHMBATsAAC4ARDsAAACWAQAAAAEAKgEBHwAAAAwAAABFbnRyeVJlc3VsdHMABgEA" +
           "AAABAAAAAAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAAA==";

        private const string WeeklySchedule_InitializationString =
           "AQAAACYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvU2NoZWR1bGVyL/////83YIkKAgAAAAEA" +
           "DgAAAFdlZWtseVNjaGVkdWxlAQE8AAMAAAAAGAEAAEVhY2ggZW50cnkgcmVwcmVzZW50cyBvbmUgZGF5" +
           "IG9mIHRoZSB3ZWVrLiBUaGUgZmlyc3QgZW50cnkgaW4gdGhlIGFycmF5IHJlcHJlc2VudHMgTW9uZGF5" +
           "LCB0aGUgbGFzdCBTdW5kYXkuIEVhY2ggZWxlbWVudCBkZXNjcmliZXMgYSBzZXF1ZW5jZSBvZiB0aW1l" +
           "cyBhbmQgYSBsaXN0IG9mIGFjdGlvbnMgdGhhdCBwcm92aWRlcyBhIHNlcXVlbmNlIG9mIHNjaGVkdWxl" +
           "IGFjdGlvbnMgb24gb25lIGRheSBvZiB0aGUgd2VlayB3aGVuIG5vIEV4Y2VwdGlvblNjaGVkdWxlIGlz" +
           "IGluIGVmZmVjdC4ALgBEPAAAAAEBVgABAAAAAQAAAAcAAAABAf////8AAAAA";

        private const string EffectivePeriod_InitializationString =
           "AQAAACYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvU2NoZWR1bGVyL/////81YIkKAgAAAAEA" +
           "DwAAAEVmZmVjdGl2ZVBlcmlvZAEBPgADAAAAANsAAABTcGVjaWZpZXMgdGhlIHJhbmdlIG9mIGRhdGVz" +
           "IHdpdGhpbiB3aGljaCB0aGUgc2NoZWR1bGUgT2JqZWN0IGlzIGFjdGl2ZS4gVXBvbiBlbnRlcmluZyBp" +
           "dHMgZWZmZWN0aXZlIHBlcmlvZCwgdGhlIG9iamVjdCBzaGFsbCBleGVjdXRlIHRoZSBkZWZpbmVkIGFj" +
           "dGlvbnMgYXQgdGhlIGRlZmluZWQgdGltZXMsIG90aGVyd2lzZSBpdCBzaGFsbCBub3QgZXhlY3V0ZSBh" +
           "bnkgYWN0aW9ucy4ALgBEPgAAAAEBUAD/////AQH/////AAAAAA==";

        private const string InitializationString =
           "AQAAACYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvU2NoZWR1bGVyL/////8EYIACAQAAAAEA" +
           "FAAAAFNjaGVkdWxlVHlwZUluc3RhbmNlAQE0AAEBNAA0AAAA/////wcAAAA3YIkKAgAAAAEAEQAAAEV4" +
           "Y2VwdGlvblNjaGVkdWxlAQE1AAMAAAAAugAAAEFuIGFycmF5IG9mIHNwZWNpYWwgZXZlbnRzLiBJZiBw" +
           "cmVzZW50LCBlYWNoIG9mIHRob3NlIHNwZWNpYWwgZXZlbnRzIGRlc2NyaWJlcyBhIHNlcXVlbmNlIG9m" +
           "IHNjaGVkdWxlIGFjdGlvbnMgdGhhdCB0YWtlIHByZWNlZGVuY2Ugb3ZlciBhIG5vcm1hbCBkYXkncyBi" +
           "ZWhhdmlvdXIgb24gYSBzcGVjaWFsIGRheSBvciBkYXlzLgAuAEQ1AAAAAQFGAAEAAAABAAAAAAAAAAEB" +
           "/////wAAAAAkYYIKBAAAAAEAHAAAAEFkZEV4Y2VwdGlvblNjaGVkdWxlRWxlbWVudHMBATYAAwAAAAAm" +
           "AAAAQWRkcyBlbGVtZW50cyB0byB0aGUgRXhjZXB0aW9uU2NoZWR1bGUALwEBNgA2AAAAAQH/////AgAA" +
           "ABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBATcAAC4ARDcAAACWAQAAAAEAKgEBIgAAAA0AAABT" +
           "cGVjaWFsRXZlbnRzAQFGAAEAAAABAAAAAAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAABdgqQoC" +
           "AAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQE4AAAuAEQ4AAAAlgEAAAABACoBAR8AAAAMAAAARW50cnlS" +
           "ZXN1bHRzAAYBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAQAAAAEB/////wAAAAAkYYIKBAAAAAEAHwAA" +
           "AFJlbW92ZUV4Y2VwdGlvblNjaGVkdWxlRWxlbWVudHMBATkAAwAAAAArAAAAUmVtb3ZlcyBlbGVtZW50" +
           "cyBmcm9tIHRoZSBFeGNlcHRpb25TY2hlZHVsZQAvAQE5ADkAAAABAf////8CAAAAF2CpCgIAAAAAAA4A" +
           "AABJbnB1dEFyZ3VtZW50cwEBOgAALgBEOgAAAJYBAAAAAQAqAQEiAAAADQAAAFNwZWNpYWxFdmVudHMB" +
           "AUYAAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAEAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRw" +
           "dXRBcmd1bWVudHMBATsAAC4ARDsAAACWAQAAAAEAKgEBHwAAAAwAAABFbnRyeVJlc3VsdHMABgEAAAAB" +
           "AAAAAAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAADdgiQoCAAAAAQAOAAAAV2Vla2x5U2NoZWR1" +
           "bGUBATwAAwAAAAAYAQAARWFjaCBlbnRyeSByZXByZXNlbnRzIG9uZSBkYXkgb2YgdGhlIHdlZWsuIFRo" +
           "ZSBmaXJzdCBlbnRyeSBpbiB0aGUgYXJyYXkgcmVwcmVzZW50cyBNb25kYXksIHRoZSBsYXN0IFN1bmRh" +
           "eS4gRWFjaCBlbGVtZW50IGRlc2NyaWJlcyBhIHNlcXVlbmNlIG9mIHRpbWVzIGFuZCBhIGxpc3Qgb2Yg" +
           "YWN0aW9ucyB0aGF0IHByb3ZpZGVzIGEgc2VxdWVuY2Ugb2Ygc2NoZWR1bGUgYWN0aW9ucyBvbiBvbmUg" +
           "ZGF5IG9mIHRoZSB3ZWVrIHdoZW4gbm8gRXhjZXB0aW9uU2NoZWR1bGUgaXMgaW4gZWZmZWN0LgAuAEQ8" +
           "AAAAAQFWAAEAAAABAAAABwAAAAEB/////wAAAAA1YIkKAgAAAAAACQAAAExvY2FsVGltZQEBPQADAAAA" +
           "ACEBAABQcm92aWRlcyBpbmZvcm1hdGlvbiBhYm91dCB0aGUgbG9jYWwgdGltZSBvZiB0aGUgc2NoZWR1" +
           "bGUgT2JqZWN0LiBBbGwgc2NoZWR1bGVkIHRpbWVzIGFyZSBVVEMgdGltZS4gQ2xpZW50cyBuZWVkIHRv" +
           "IGNvbnNpZGVyIHRoaXMgUHJvcGVydHkgdG8gY2FsY3VsYXRlIHRoZSBsb2NhbCB0aW1lIG9mIHRoZSBz" +
           "Y2hlZHVsZS4gSWYgdGhpcyBQcm9wZXJ0eSBpcyBjaGFuZ2VkLCBpdCBpcyBzZXJ2ZXItc3BlY2lmaWMg" +
           "d2hldGhlciB0aGUgdGltZXMgb2YgdGhlIHNjaGVkdWxlIGFyZSBhZGp1c3RlZCBvciBub3QuAC4ARD0A" +
           "AAABANAi/////wEB/////wAAAAA1YIkKAgAAAAEADwAAAEVmZmVjdGl2ZVBlcmlvZAEBPgADAAAAANsA" +
           "AABTcGVjaWZpZXMgdGhlIHJhbmdlIG9mIGRhdGVzIHdpdGhpbiB3aGljaCB0aGUgc2NoZWR1bGUgT2Jq" +
           "ZWN0IGlzIGFjdGl2ZS4gVXBvbiBlbnRlcmluZyBpdHMgZWZmZWN0aXZlIHBlcmlvZCwgdGhlIG9iamVj" +
           "dCBzaGFsbCBleGVjdXRlIHRoZSBkZWZpbmVkIGFjdGlvbnMgYXQgdGhlIGRlZmluZWQgdGltZXMsIG90" +
           "aGVyd2lzZSBpdCBzaGFsbCBub3QgZXhlY3V0ZSBhbnkgYWN0aW9ucy4ALgBEPgAAAAEBUAD/////AQH/" +
           "////AAAAADVgiQoCAAAAAQATAAAAQXBwbHlMYXN0QWZ0ZXJTdGFydAEBPwADAAAAAHYAAABUaGUgQXBw" +
           "bHlMYXN0QWZ0ZXJTdGFydCBQcm9wZXJ0eSBkZWZpbmVzIGlmIHRoZSBsYXN0IHNldCBvZiBhY3Rpb25z" +
           "IHNoYWxsIGJlIGFwcGxpZWQgd2hlbiBzdGFydGluZyB0aGUgc2NoZWR1bGUgT2JqZWN0AC4ARD8AAAAA" +
           "Af////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public PropertyState<SpecialEventType[]> ExceptionSchedule
        {
            get
            {
                return m_exceptionSchedule;
            }

            set
            {
                if (!Object.ReferenceEquals(m_exceptionSchedule, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_exceptionSchedule = value;
            }
        }

        /// <remarks />
        public AddExceptionScheduleElementsMethodState AddExceptionScheduleElements
        {
            get
            {
                return m_addExceptionScheduleElementsMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_addExceptionScheduleElementsMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_addExceptionScheduleElementsMethod = value;
            }
        }

        /// <remarks />
        public RemoveExceptionScheduleElementsMethodState RemoveExceptionScheduleElements
        {
            get
            {
                return m_removeExceptionScheduleElementsMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_removeExceptionScheduleElementsMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_removeExceptionScheduleElementsMethod = value;
            }
        }

        /// <remarks />
        public PropertyState<DailyScheduleType[]> WeeklySchedule
        {
            get
            {
                return m_weeklySchedule;
            }

            set
            {
                if (!Object.ReferenceEquals(m_weeklySchedule, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_weeklySchedule = value;
            }
        }

        /// <remarks />
        public PropertyState<TimeZoneDataType> LocalTime
        {
            get
            {
                return m_localTime;
            }

            set
            {
                if (!Object.ReferenceEquals(m_localTime, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_localTime = value;
            }
        }

        /// <remarks />
        public PropertyState<DateRangeType> EffectivePeriod
        {
            get
            {
                return m_effectivePeriod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_effectivePeriod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_effectivePeriod = value;
            }
        }

        /// <remarks />
        public PropertyState<bool> ApplyLastAfterStart
        {
            get
            {
                return m_applyLastAfterStart;
            }

            set
            {
                if (!Object.ReferenceEquals(m_applyLastAfterStart, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_applyLastAfterStart = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <remarks />
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_exceptionSchedule != null)
            {
                children.Add(m_exceptionSchedule);
            }

            if (m_addExceptionScheduleElementsMethod != null)
            {
                children.Add(m_addExceptionScheduleElementsMethod);
            }

            if (m_removeExceptionScheduleElementsMethod != null)
            {
                children.Add(m_removeExceptionScheduleElementsMethod);
            }

            if (m_weeklySchedule != null)
            {
                children.Add(m_weeklySchedule);
            }

            if (m_localTime != null)
            {
                children.Add(m_localTime);
            }

            if (m_effectivePeriod != null)
            {
                children.Add(m_effectivePeriod);
            }

            if (m_applyLastAfterStart != null)
            {
                children.Add(m_applyLastAfterStart);
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
                case Opc.Ua.Scheduler.BrowseNames.ExceptionSchedule:
                {
                    if (createOrReplace)
                    {
                        if (ExceptionSchedule == null)
                        {
                            if (replacement == null)
                            {
                                ExceptionSchedule = new PropertyState<SpecialEventType[]>(this);
                            }
                            else
                            {
                                ExceptionSchedule = (PropertyState<SpecialEventType[]>)replacement;
                            }
                        }
                    }

                    instance = ExceptionSchedule;
                    break;
                }

                case Opc.Ua.Scheduler.BrowseNames.AddExceptionScheduleElements:
                {
                    if (createOrReplace)
                    {
                        if (AddExceptionScheduleElements == null)
                        {
                            if (replacement == null)
                            {
                                AddExceptionScheduleElements = new AddExceptionScheduleElementsMethodState(this);
                            }
                            else
                            {
                                AddExceptionScheduleElements = (AddExceptionScheduleElementsMethodState)replacement;
                            }
                        }
                    }

                    instance = AddExceptionScheduleElements;
                    break;
                }

                case Opc.Ua.Scheduler.BrowseNames.RemoveExceptionScheduleElements:
                {
                    if (createOrReplace)
                    {
                        if (RemoveExceptionScheduleElements == null)
                        {
                            if (replacement == null)
                            {
                                RemoveExceptionScheduleElements = new RemoveExceptionScheduleElementsMethodState(this);
                            }
                            else
                            {
                                RemoveExceptionScheduleElements = (RemoveExceptionScheduleElementsMethodState)replacement;
                            }
                        }
                    }

                    instance = RemoveExceptionScheduleElements;
                    break;
                }

                case Opc.Ua.Scheduler.BrowseNames.WeeklySchedule:
                {
                    if (createOrReplace)
                    {
                        if (WeeklySchedule == null)
                        {
                            if (replacement == null)
                            {
                                WeeklySchedule = new PropertyState<DailyScheduleType[]>(this);
                            }
                            else
                            {
                                WeeklySchedule = (PropertyState<DailyScheduleType[]>)replacement;
                            }
                        }
                    }

                    instance = WeeklySchedule;
                    break;
                }

                case Opc.Ua.BrowseNames.LocalTime:
                {
                    if (createOrReplace)
                    {
                        if (LocalTime == null)
                        {
                            if (replacement == null)
                            {
                                LocalTime = new PropertyState<TimeZoneDataType>(this);
                            }
                            else
                            {
                                LocalTime = (PropertyState<TimeZoneDataType>)replacement;
                            }
                        }
                    }

                    instance = LocalTime;
                    break;
                }

                case Opc.Ua.Scheduler.BrowseNames.EffectivePeriod:
                {
                    if (createOrReplace)
                    {
                        if (EffectivePeriod == null)
                        {
                            if (replacement == null)
                            {
                                EffectivePeriod = new PropertyState<DateRangeType>(this);
                            }
                            else
                            {
                                EffectivePeriod = (PropertyState<DateRangeType>)replacement;
                            }
                        }
                    }

                    instance = EffectivePeriod;
                    break;
                }

                case Opc.Ua.Scheduler.BrowseNames.ApplyLastAfterStart:
                {
                    if (createOrReplace)
                    {
                        if (ApplyLastAfterStart == null)
                        {
                            if (replacement == null)
                            {
                                ApplyLastAfterStart = new PropertyState<bool>(this);
                            }
                            else
                            {
                                ApplyLastAfterStart = (PropertyState<bool>)replacement;
                            }
                        }
                    }

                    instance = ApplyLastAfterStart;
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
        private PropertyState<SpecialEventType[]> m_exceptionSchedule;
        private AddExceptionScheduleElementsMethodState m_addExceptionScheduleElementsMethod;
        private RemoveExceptionScheduleElementsMethodState m_removeExceptionScheduleElementsMethod;
        private PropertyState<DailyScheduleType[]> m_weeklySchedule;
        private PropertyState<TimeZoneDataType> m_localTime;
        private PropertyState<DateRangeType> m_effectivePeriod;
        private PropertyState<bool> m_applyLastAfterStart;
        #endregion
    }
    #endif
    #endregion

    #region AddExceptionScheduleElementsMethodState Class
    #if (!OPCUA_EXCLUDE_AddExceptionScheduleElementsMethodState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AddExceptionScheduleElementsMethodState : MethodState
    {
        #region Constructors
        /// <remarks />
        public AddExceptionScheduleElementsMethodState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        public new static NodeState Construct(NodeState parent)
        {
            return new AddExceptionScheduleElementsMethodState(parent);
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
           "AQAAACYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvU2NoZWR1bGVyL/////8kYYIKBAAAAAEA" +
           "JgAAAEFkZEV4Y2VwdGlvblNjaGVkdWxlRWxlbWVudHNNZXRob2RUeXBlAQFAAAMAAAAAJgAAAEFkZHMg" +
           "ZWxlbWVudHMgdG8gdGhlIEV4Y2VwdGlvblNjaGVkdWxlAC8BAUAAQAAAAAEB/////wIAAAAXYKkKAgAA" +
           "AAAADgAAAElucHV0QXJndW1lbnRzAQFBAAAuAERBAAAAlgEAAAABACoBASIAAAANAAAAU3BlY2lhbEV2" +
           "ZW50cwEBRgABAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAQAAAAEB/////wAAAAAXYKkKAgAAAAAADwAA" +
           "AE91dHB1dEFyZ3VtZW50cwEBQgAALgBEQgAAAJYBAAAAAQAqAQEfAAAADAAAAEVudHJ5UmVzdWx0cwAG" +
           "AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAEAAAABAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <remarks />
        public AddExceptionScheduleElementsMethodStateMethodCallHandler OnCall;
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

            SpecialEventType[] specialEvents = (SpecialEventType[])ExtensionObject.ToArray(_inputArguments[0], typeof(SpecialEventType));

            int[] entryResults = (int[])_outputArguments[0];

            if (OnCall != null)
            {
                _result = OnCall(
                    _context,
                    this,
                    _objectId,
                    specialEvents,
                    ref entryResults);
            }

            _outputArguments[0] = entryResults;

            return _result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <remarks />
    /// <exclude />
    public delegate ServiceResult AddExceptionScheduleElementsMethodStateMethodCallHandler(
        ISystemContext _context,
        MethodState _method,
        NodeId _objectId,
        SpecialEventType[] specialEvents,
        ref int[] entryResults);
    #endif
    #endregion

    #region RemoveExceptionScheduleElementsMethodState Class
    #if (!OPCUA_EXCLUDE_RemoveExceptionScheduleElementsMethodState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class RemoveExceptionScheduleElementsMethodState : MethodState
    {
        #region Constructors
        /// <remarks />
        public RemoveExceptionScheduleElementsMethodState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        public new static NodeState Construct(NodeState parent)
        {
            return new RemoveExceptionScheduleElementsMethodState(parent);
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
           "AQAAACYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvU2NoZWR1bGVyL/////8kYYIKBAAAAAEA" +
           "KQAAAFJlbW92ZUV4Y2VwdGlvblNjaGVkdWxlRWxlbWVudHNNZXRob2RUeXBlAQFDAAMAAAAAKwAAAFJl" +
           "bW92ZXMgZWxlbWVudHMgZnJvbSB0aGUgRXhjZXB0aW9uU2NoZWR1bGUALwEBQwBDAAAAAQH/////AgAA" +
           "ABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAUQAAC4AREQAAACWAQAAAAEAKgEBIgAAAA0AAABT" +
           "cGVjaWFsRXZlbnRzAQFGAAEAAAABAAAAAAAAAAABACgBAQAAAAEAAAABAAAAAQH/////AAAAABdgqQoC" +
           "AAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQFFAAAuAERFAAAAlgEAAAABACoBAR8AAAAMAAAARW50cnlS" +
           "ZXN1bHRzAAYBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAQAAAAEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <remarks />
        public RemoveExceptionScheduleElementsMethodStateMethodCallHandler OnCall;
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

            SpecialEventType[] specialEvents = (SpecialEventType[])ExtensionObject.ToArray(_inputArguments[0], typeof(SpecialEventType));

            int[] entryResults = (int[])_outputArguments[0];

            if (OnCall != null)
            {
                _result = OnCall(
                    _context,
                    this,
                    _objectId,
                    specialEvents,
                    ref entryResults);
            }

            _outputArguments[0] = entryResults;

            return _result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <remarks />
    /// <exclude />
    public delegate ServiceResult RemoveExceptionScheduleElementsMethodStateMethodCallHandler(
        ISystemContext _context,
        MethodState _method,
        NodeId _objectId,
        SpecialEventType[] specialEvents,
        ref int[] entryResults);
    #endif
    #endregion
}
