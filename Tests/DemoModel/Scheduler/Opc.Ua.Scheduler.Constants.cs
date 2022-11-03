/* ========================================================================
 * Copyright (c) 2005-2022 The OPC Foundation, Inc. All rights reserved.
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
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;

namespace Opc.Ua.Scheduler
{
    #region DataType Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class DataTypes
    {
        /// <remarks />
        public const uint SpecialEventType = 70;

        /// <remarks />
        public const uint SpecialEventPeriodType = 71;

        /// <remarks />
        public const uint CalendarEntryType = 72;

        /// <remarks />
        public const uint DateType = 73;

        /// <remarks />
        public const uint Month = 74;

        /// <remarks />
        public const uint DayOfMonth = 76;

        /// <remarks />
        public const uint DayOfWeek = 78;

        /// <remarks />
        public const uint DateRangeType = 80;

        /// <remarks />
        public const uint TimeActionsType = 81;

        /// <remarks />
        public const uint BaseActionType = 82;

        /// <remarks />
        public const uint WriteLocalVariableActionType = 83;

        /// <remarks />
        public const uint CallLocalMethodActionType = 84;

        /// <remarks />
        public const uint TimeType = 85;

        /// <remarks />
        public const uint DailyScheduleType = 86;
    }
    #endregion

    #region Method Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Methods
    {
        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Open = 17;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Close = 20;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Read = 22;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Write = 25;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition = 27;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_SetPosition = 30;

        /// <remarks />
        public const uint CalendarType_AddDateListElements = 40;

        /// <remarks />
        public const uint CalendarType_RemoveDateListElements = 43;

        /// <remarks />
        public const uint ScheduleType_AddExceptionScheduleElements = 54;

        /// <remarks />
        public const uint ScheduleType_RemoveExceptionScheduleElements = 57;
    }
    #endregion

    #region Object Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Objects
    {
        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata = 1;

        /// <remarks />
        public const uint SpecialEventType_Encoding_DefaultBinary = 87;

        /// <remarks />
        public const uint SpecialEventPeriodType_Encoding_DefaultBinary = 88;

        /// <remarks />
        public const uint CalendarEntryType_Encoding_DefaultBinary = 89;

        /// <remarks />
        public const uint DateType_Encoding_DefaultBinary = 90;

        /// <remarks />
        public const uint DateRangeType_Encoding_DefaultBinary = 91;

        /// <remarks />
        public const uint TimeActionsType_Encoding_DefaultBinary = 92;

        /// <remarks />
        public const uint BaseActionType_Encoding_DefaultBinary = 93;

        /// <remarks />
        public const uint WriteLocalVariableActionType_Encoding_DefaultBinary = 94;

        /// <remarks />
        public const uint CallLocalMethodActionType_Encoding_DefaultBinary = 95;

        /// <remarks />
        public const uint TimeType_Encoding_DefaultBinary = 96;

        /// <remarks />
        public const uint DailyScheduleType_Encoding_DefaultBinary = 97;

        /// <remarks />
        public const uint SpecialEventType_Encoding_DefaultXml = 135;

        /// <remarks />
        public const uint SpecialEventPeriodType_Encoding_DefaultXml = 136;

        /// <remarks />
        public const uint CalendarEntryType_Encoding_DefaultXml = 137;

        /// <remarks />
        public const uint DateType_Encoding_DefaultXml = 138;

        /// <remarks />
        public const uint DateRangeType_Encoding_DefaultXml = 139;

        /// <remarks />
        public const uint TimeActionsType_Encoding_DefaultXml = 140;

        /// <remarks />
        public const uint BaseActionType_Encoding_DefaultXml = 141;

        /// <remarks />
        public const uint WriteLocalVariableActionType_Encoding_DefaultXml = 142;

        /// <remarks />
        public const uint CallLocalMethodActionType_Encoding_DefaultXml = 143;

        /// <remarks />
        public const uint TimeType_Encoding_DefaultXml = 144;

        /// <remarks />
        public const uint DailyScheduleType_Encoding_DefaultXml = 145;

        /// <remarks />
        public const uint SpecialEventType_Encoding_DefaultJson = 183;

        /// <remarks />
        public const uint SpecialEventPeriodType_Encoding_DefaultJson = 184;

        /// <remarks />
        public const uint CalendarEntryType_Encoding_DefaultJson = 185;

        /// <remarks />
        public const uint DateType_Encoding_DefaultJson = 186;

        /// <remarks />
        public const uint DateRangeType_Encoding_DefaultJson = 187;

        /// <remarks />
        public const uint TimeActionsType_Encoding_DefaultJson = 188;

        /// <remarks />
        public const uint BaseActionType_Encoding_DefaultJson = 189;

        /// <remarks />
        public const uint WriteLocalVariableActionType_Encoding_DefaultJson = 190;

        /// <remarks />
        public const uint CallLocalMethodActionType_Encoding_DefaultJson = 191;

        /// <remarks />
        public const uint TimeType_Encoding_DefaultJson = 192;

        /// <remarks />
        public const uint DailyScheduleType_Encoding_DefaultJson = 193;
    }
    #endregion

    #region ObjectType Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypes
    {
        /// <remarks />
        public const uint CalendarType = 37;

        /// <remarks />
        public const uint ScheduleType = 52;
    }
    #endregion

    #region Variable Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceUri = 2;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceVersion = 3;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespacePublicationDate = 4;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_IsNamespaceSubset = 5;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_StaticNodeIdTypes = 6;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_StaticNumericNodeIdRange = 7;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_StaticStringNodeIdPattern = 8;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Size = 10;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Writable = 11;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_UserWritable = 12;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_OpenCount = 13;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Open_InputArguments = 18;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Open_OutputArguments = 19;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Close_InputArguments = 21;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Read_InputArguments = 23;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Read_OutputArguments = 24;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Write_InputArguments = 26;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition_InputArguments = 28;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments = 29;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_SetPosition_InputArguments = 31;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_DefaultRolePermissions = 33;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_DefaultUserRolePermissions = 34;

        /// <remarks />
        public const uint OPCUASchedulerNamespaceMetadata_DefaultAccessRestrictions = 35;

        /// <remarks />
        public const uint CalendarType_PresentValue = 38;

        /// <remarks />
        public const uint CalendarType_DateList = 39;

        /// <remarks />
        public const uint CalendarType_AddDateListElements_InputArguments = 41;

        /// <remarks />
        public const uint CalendarType_AddDateListElements_OutputArguments = 42;

        /// <remarks />
        public const uint CalendarType_RemoveDateListElements_InputArguments = 44;

        /// <remarks />
        public const uint CalendarType_RemoveDateListElements_OutputArguments = 45;

        /// <remarks />
        public const uint ScheduleType_ExceptionSchedule = 53;

        /// <remarks />
        public const uint ScheduleType_AddExceptionScheduleElements_InputArguments = 55;

        /// <remarks />
        public const uint ScheduleType_AddExceptionScheduleElements_OutputArguments = 56;

        /// <remarks />
        public const uint ScheduleType_RemoveExceptionScheduleElements_InputArguments = 58;

        /// <remarks />
        public const uint ScheduleType_RemoveExceptionScheduleElements_OutputArguments = 59;

        /// <remarks />
        public const uint ScheduleType_WeeklySchedule = 60;

        /// <remarks />
        public const uint ScheduleType_LocalTime = 61;

        /// <remarks />
        public const uint ScheduleType_EffectivePeriod = 62;

        /// <remarks />
        public const uint ScheduleType_ApplyLastAfterStart = 63;

        /// <remarks />
        public const uint Month_EnumStrings = 194;

        /// <remarks />
        public const uint DayOfMonth_EnumStrings = 195;

        /// <remarks />
        public const uint DayOfWeek_EnumStrings = 79;

        /// <remarks />
        public const uint OpcUaScheduler_BinarySchema = 98;

        /// <remarks />
        public const uint OpcUaScheduler_BinarySchema_NamespaceUri = 100;

        /// <remarks />
        public const uint OpcUaScheduler_BinarySchema_Deprecated = 101;

        /// <remarks />
        public const uint OpcUaScheduler_BinarySchema_SpecialEventType = 102;

        /// <remarks />
        public const uint OpcUaScheduler_BinarySchema_SpecialEventPeriodType = 105;

        /// <remarks />
        public const uint OpcUaScheduler_BinarySchema_CalendarEntryType = 108;

        /// <remarks />
        public const uint OpcUaScheduler_BinarySchema_DateType = 111;

        /// <remarks />
        public const uint OpcUaScheduler_BinarySchema_DateRangeType = 114;

        /// <remarks />
        public const uint OpcUaScheduler_BinarySchema_TimeActionsType = 117;

        /// <remarks />
        public const uint OpcUaScheduler_BinarySchema_BaseActionType = 120;

        /// <remarks />
        public const uint OpcUaScheduler_BinarySchema_WriteLocalVariableActionType = 123;

        /// <remarks />
        public const uint OpcUaScheduler_BinarySchema_CallLocalMethodActionType = 126;

        /// <remarks />
        public const uint OpcUaScheduler_BinarySchema_TimeType = 129;

        /// <remarks />
        public const uint OpcUaScheduler_BinarySchema_DailyScheduleType = 132;

        /// <remarks />
        public const uint OpcUaScheduler_XmlSchema = 146;

        /// <remarks />
        public const uint OpcUaScheduler_XmlSchema_NamespaceUri = 148;

        /// <remarks />
        public const uint OpcUaScheduler_XmlSchema_Deprecated = 149;

        /// <remarks />
        public const uint OpcUaScheduler_XmlSchema_SpecialEventType = 150;

        /// <remarks />
        public const uint OpcUaScheduler_XmlSchema_SpecialEventPeriodType = 153;

        /// <remarks />
        public const uint OpcUaScheduler_XmlSchema_CalendarEntryType = 156;

        /// <remarks />
        public const uint OpcUaScheduler_XmlSchema_DateType = 159;

        /// <remarks />
        public const uint OpcUaScheduler_XmlSchema_DateRangeType = 162;

        /// <remarks />
        public const uint OpcUaScheduler_XmlSchema_TimeActionsType = 165;

        /// <remarks />
        public const uint OpcUaScheduler_XmlSchema_BaseActionType = 168;

        /// <remarks />
        public const uint OpcUaScheduler_XmlSchema_WriteLocalVariableActionType = 171;

        /// <remarks />
        public const uint OpcUaScheduler_XmlSchema_CallLocalMethodActionType = 174;

        /// <remarks />
        public const uint OpcUaScheduler_XmlSchema_TimeType = 177;

        /// <remarks />
        public const uint OpcUaScheduler_XmlSchema_DailyScheduleType = 180;
    }
    #endregion

    #region DataType Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class DataTypeIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId SpecialEventType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.SpecialEventType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId SpecialEventPeriodType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.SpecialEventPeriodType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId CalendarEntryType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.CalendarEntryType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId DateType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.DateType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId Month = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.Month, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId DayOfMonth = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.DayOfMonth, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId DayOfWeek = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.DayOfWeek, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId DateRangeType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.DateRangeType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId TimeActionsType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.TimeActionsType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId BaseActionType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.BaseActionType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId WriteLocalVariableActionType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.WriteLocalVariableActionType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId CallLocalMethodActionType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.CallLocalMethodActionType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId TimeType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.TimeType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId DailyScheduleType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.DailyScheduleType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);
    }
    #endregion

    #region Method Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class MethodIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Open = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.OPCUASchedulerNamespaceMetadata_NamespaceFile_Open, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Close = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.OPCUASchedulerNamespaceMetadata_NamespaceFile_Close, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Read = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.OPCUASchedulerNamespaceMetadata_NamespaceFile_Read, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Write = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.OPCUASchedulerNamespaceMetadata_NamespaceFile_Write, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_SetPosition = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.OPCUASchedulerNamespaceMetadata_NamespaceFile_SetPosition, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId CalendarType_AddDateListElements = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.CalendarType_AddDateListElements, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId CalendarType_RemoveDateListElements = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.CalendarType_RemoveDateListElements, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId ScheduleType_AddExceptionScheduleElements = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.ScheduleType_AddExceptionScheduleElements, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId ScheduleType_RemoveExceptionScheduleElements = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.ScheduleType_RemoveExceptionScheduleElements, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);
    }
    #endregion

    #region Object Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.OPCUASchedulerNamespaceMetadata, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId SpecialEventType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.SpecialEventType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId SpecialEventPeriodType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.SpecialEventPeriodType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId CalendarEntryType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.CalendarEntryType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId DateType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.DateType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId DateRangeType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.DateRangeType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId TimeActionsType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.TimeActionsType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId BaseActionType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.BaseActionType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId WriteLocalVariableActionType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.WriteLocalVariableActionType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId CallLocalMethodActionType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.CallLocalMethodActionType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId TimeType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.TimeType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId DailyScheduleType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.DailyScheduleType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId SpecialEventType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.SpecialEventType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId SpecialEventPeriodType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.SpecialEventPeriodType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId CalendarEntryType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.CalendarEntryType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId DateType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.DateType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId DateRangeType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.DateRangeType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId TimeActionsType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.TimeActionsType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId BaseActionType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.BaseActionType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId WriteLocalVariableActionType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.WriteLocalVariableActionType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId CallLocalMethodActionType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.CallLocalMethodActionType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId TimeType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.TimeType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId DailyScheduleType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.DailyScheduleType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId SpecialEventType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.SpecialEventType_Encoding_DefaultJson, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId SpecialEventPeriodType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.SpecialEventPeriodType_Encoding_DefaultJson, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId CalendarEntryType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.CalendarEntryType_Encoding_DefaultJson, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId DateType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.DateType_Encoding_DefaultJson, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId DateRangeType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.DateRangeType_Encoding_DefaultJson, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId TimeActionsType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.TimeActionsType_Encoding_DefaultJson, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId BaseActionType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.BaseActionType_Encoding_DefaultJson, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId WriteLocalVariableActionType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.WriteLocalVariableActionType_Encoding_DefaultJson, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId CallLocalMethodActionType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.CallLocalMethodActionType_Encoding_DefaultJson, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId TimeType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.TimeType_Encoding_DefaultJson, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId DailyScheduleType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.DailyScheduleType_Encoding_DefaultJson, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypeIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId CalendarType = new ExpandedNodeId(Opc.Ua.Scheduler.ObjectTypes.CalendarType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId ScheduleType = new ExpandedNodeId(Opc.Ua.Scheduler.ObjectTypes.ScheduleType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);
    }
    #endregion

    #region Variable Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceUri = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceUri, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceVersion = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceVersion, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespacePublicationDate = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespacePublicationDate, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_IsNamespaceSubset = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_IsNamespaceSubset, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_StaticNodeIdTypes = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_StaticNodeIdTypes, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_StaticNumericNodeIdRange = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_StaticNumericNodeIdRange, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_StaticStringNodeIdPattern = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_StaticStringNodeIdPattern, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Size = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_Size, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Writable = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_Writable, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_UserWritable = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_UserWritable, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_OpenCount = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_OpenCount, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_Open_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_Open_OutputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_Close_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_Read_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_Read_OutputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_Write_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_SetPosition_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_DefaultRolePermissions = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_DefaultRolePermissions, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_DefaultUserRolePermissions = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_DefaultUserRolePermissions, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_DefaultAccessRestrictions = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_DefaultAccessRestrictions, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId CalendarType_PresentValue = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.CalendarType_PresentValue, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId CalendarType_DateList = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.CalendarType_DateList, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId CalendarType_AddDateListElements_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.CalendarType_AddDateListElements_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId CalendarType_AddDateListElements_OutputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.CalendarType_AddDateListElements_OutputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId CalendarType_RemoveDateListElements_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.CalendarType_RemoveDateListElements_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId CalendarType_RemoveDateListElements_OutputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.CalendarType_RemoveDateListElements_OutputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId ScheduleType_ExceptionSchedule = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.ScheduleType_ExceptionSchedule, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId ScheduleType_AddExceptionScheduleElements_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.ScheduleType_AddExceptionScheduleElements_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId ScheduleType_AddExceptionScheduleElements_OutputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.ScheduleType_AddExceptionScheduleElements_OutputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId ScheduleType_RemoveExceptionScheduleElements_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.ScheduleType_RemoveExceptionScheduleElements_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId ScheduleType_RemoveExceptionScheduleElements_OutputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.ScheduleType_RemoveExceptionScheduleElements_OutputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId ScheduleType_WeeklySchedule = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.ScheduleType_WeeklySchedule, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId ScheduleType_LocalTime = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.ScheduleType_LocalTime, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId ScheduleType_EffectivePeriod = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.ScheduleType_EffectivePeriod, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId ScheduleType_ApplyLastAfterStart = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.ScheduleType_ApplyLastAfterStart, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId Month_EnumStrings = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.Month_EnumStrings, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId DayOfMonth_EnumStrings = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.DayOfMonth_EnumStrings, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId DayOfWeek_EnumStrings = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.DayOfWeek_EnumStrings, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_NamespaceUri = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_NamespaceUri, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_Deprecated = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_Deprecated, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_SpecialEventType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_SpecialEventType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_SpecialEventPeriodType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_SpecialEventPeriodType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_CalendarEntryType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_CalendarEntryType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_DateType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_DateType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_DateRangeType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_DateRangeType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_TimeActionsType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_TimeActionsType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_BaseActionType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_BaseActionType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_WriteLocalVariableActionType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_WriteLocalVariableActionType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_CallLocalMethodActionType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_CallLocalMethodActionType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_TimeType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_TimeType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_DailyScheduleType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_DailyScheduleType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_NamespaceUri = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_NamespaceUri, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_Deprecated = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_Deprecated, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_SpecialEventType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_SpecialEventType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_SpecialEventPeriodType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_SpecialEventPeriodType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_CalendarEntryType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_CalendarEntryType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_DateType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_DateType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_DateRangeType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_DateRangeType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_TimeActionsType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_TimeActionsType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_BaseActionType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_BaseActionType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_WriteLocalVariableActionType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_WriteLocalVariableActionType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_CallLocalMethodActionType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_CallLocalMethodActionType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_TimeType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_TimeType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_DailyScheduleType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_DailyScheduleType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);
    }
    #endregion

    #region BrowseName Declarations
    /// <remarks />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class BrowseNames
    {
        /// <remarks />
        public const string AddDateListElements = "AddDateListElements";

        /// <remarks />
        public const string AddExceptionScheduleElements = "AddExceptionScheduleElements";

        /// <remarks />
        public const string ApplyLastAfterStart = "ApplyLastAfterStart";

        /// <remarks />
        public const string BaseActionType = "BaseActionType";

        /// <remarks />
        public const string CalendarEntryType = "CalendarEntryType";

        /// <remarks />
        public const string CalendarType = "CalendarType";

        /// <remarks />
        public const string CallLocalMethodActionType = "CallLocalMethodActionType";

        /// <remarks />
        public const string DailyScheduleType = "DailyScheduleType";

        /// <remarks />
        public const string DateList = "DateList";

        /// <remarks />
        public const string DateRangeType = "DateRangeType";

        /// <remarks />
        public const string DateType = "DateType";

        /// <remarks />
        public const string DayOfMonth = "DayOfMonth";

        /// <remarks />
        public const string DayOfWeek = "DayOfWeek";

        /// <remarks />
        public const string EffectivePeriod = "EffectivePeriod";

        /// <remarks />
        public const string ExceptionSchedule = "ExceptionSchedule";

        /// <remarks />
        public const string Month = "Month";

        /// <remarks />
        public const string OpcUaScheduler_BinarySchema = "Opc.Ua.Scheduler";

        /// <remarks />
        public const string OpcUaScheduler_XmlSchema = "Opc.Ua.Scheduler";

        /// <remarks />
        public const string OPCUASchedulerNamespaceMetadata = "http://opcfoundation.org/UA/Scheduler/";

        /// <remarks />
        public const string PresentValue = "PresentValue";

        /// <remarks />
        public const string RemoveDateListElements = "RemoveDateListElements";

        /// <remarks />
        public const string RemoveExceptionScheduleElements = "RemoveExceptionScheduleElements";

        /// <remarks />
        public const string ScheduleType = "ScheduleType";

        /// <remarks />
        public const string SpecialEventPeriodType = "SpecialEventPeriodType";

        /// <remarks />
        public const string SpecialEventType = "SpecialEventType";

        /// <remarks />
        public const string TimeActionsType = "TimeActionsType";

        /// <remarks />
        public const string TimeType = "TimeType";

        /// <remarks />
        public const string WeeklySchedule = "WeeklySchedule";

        /// <remarks />
        public const string WriteLocalVariableActionType = "WriteLocalVariableActionType";
    }
    #endregion

    #region Namespace Declarations
    /// <remarks />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the OpcUaScheduler namespace (.NET code namespace is 'Opc.Ua.Scheduler').
        /// </summary>
        public const string OpcUaScheduler = "http://opcfoundation.org/UA/Scheduler/";

        /// <summary>
        /// The URI for the OpcUaSchedulerXsd namespace (.NET code namespace is 'Opc.Ua.Scheduler').
        /// </summary>
        public const string OpcUaSchedulerXsd = "http://opcfoundation.org/UA/Scheduler/Types.xsd";

        /// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";

        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";
    }
    #endregion
}
