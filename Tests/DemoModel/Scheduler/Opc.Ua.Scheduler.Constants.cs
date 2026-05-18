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
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CA1707 // Identifiers should not contain underscores

namespace Opc.Ua.Scheduler
{
    #region DataType Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class DataTypes
    {
        public const uint SpecialEventType = 70;

        public const uint SpecialEventPeriodType = 71;

        public const uint CalendarEntryType = 72;

        public const uint DateType = 73;

        public const uint Month = 74;

        public const uint DayOfMonth = 76;

        public const uint DayOfWeek = 78;

        public const uint DateRangeType = 80;

        public const uint TimeActionsType = 81;

        public const uint BaseActionType = 82;

        public const uint WriteLocalVariableActionType = 83;

        public const uint CallLocalMethodActionType = 84;

        public const uint TimeType = 85;

        public const uint DailyScheduleType = 86;
    }
    #endregion

    #region Method Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class Methods
    {
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Open = 17;

        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Close = 20;

        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Read = 22;

        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Write = 25;

        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition = 27;

        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_SetPosition = 30;

        public const uint CalendarType_AddDateListElements = 40;

        public const uint CalendarType_RemoveDateListElements = 43;

        public const uint ScheduleType_AddExceptionScheduleElements = 54;

        public const uint ScheduleType_RemoveExceptionScheduleElements = 57;
    }
    #endregion

    #region Object Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class Objects
    {
        public const uint OPCUASchedulerNamespaceMetadata = 1;

        public const uint SpecialEventType_Encoding_DefaultBinary = 87;

        public const uint SpecialEventPeriodType_Encoding_DefaultBinary = 88;

        public const uint CalendarEntryType_Encoding_DefaultBinary = 89;

        public const uint DateType_Encoding_DefaultBinary = 90;

        public const uint DateRangeType_Encoding_DefaultBinary = 91;

        public const uint TimeActionsType_Encoding_DefaultBinary = 92;

        public const uint BaseActionType_Encoding_DefaultBinary = 93;

        public const uint WriteLocalVariableActionType_Encoding_DefaultBinary = 94;

        public const uint CallLocalMethodActionType_Encoding_DefaultBinary = 95;

        public const uint TimeType_Encoding_DefaultBinary = 96;

        public const uint DailyScheduleType_Encoding_DefaultBinary = 97;

        public const uint SpecialEventType_Encoding_DefaultXml = 135;

        public const uint SpecialEventPeriodType_Encoding_DefaultXml = 136;

        public const uint CalendarEntryType_Encoding_DefaultXml = 137;

        public const uint DateType_Encoding_DefaultXml = 138;

        public const uint DateRangeType_Encoding_DefaultXml = 139;

        public const uint TimeActionsType_Encoding_DefaultXml = 140;

        public const uint BaseActionType_Encoding_DefaultXml = 141;

        public const uint WriteLocalVariableActionType_Encoding_DefaultXml = 142;

        public const uint CallLocalMethodActionType_Encoding_DefaultXml = 143;

        public const uint TimeType_Encoding_DefaultXml = 144;

        public const uint DailyScheduleType_Encoding_DefaultXml = 145;
    }
    #endregion

    #region ObjectType Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class ObjectTypes
    {
        public const uint CalendarType = 37;

        public const uint ScheduleType = 52;
    }
    #endregion

    #region Variable Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class Variables
    {
        public const uint OPCUASchedulerNamespaceMetadata_NamespaceUri = 2;

        public const uint OPCUASchedulerNamespaceMetadata_NamespaceVersion = 3;

        public const uint OPCUASchedulerNamespaceMetadata_NamespacePublicationDate = 4;

        public const uint OPCUASchedulerNamespaceMetadata_IsNamespaceSubset = 5;

        public const uint OPCUASchedulerNamespaceMetadata_StaticNodeIdTypes = 6;

        public const uint OPCUASchedulerNamespaceMetadata_StaticNumericNodeIdRange = 7;

        public const uint OPCUASchedulerNamespaceMetadata_StaticStringNodeIdPattern = 8;

        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Size = 10;

        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Writable = 11;

        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_UserWritable = 12;

        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_OpenCount = 13;

        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Open_InputArguments = 18;

        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Open_OutputArguments = 19;

        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Close_InputArguments = 21;

        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Read_InputArguments = 23;

        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Read_OutputArguments = 24;

        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_Write_InputArguments = 26;

        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition_InputArguments = 28;

        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments = 29;

        public const uint OPCUASchedulerNamespaceMetadata_NamespaceFile_SetPosition_InputArguments = 31;

        public const uint OPCUASchedulerNamespaceMetadata_DefaultRolePermissions = 33;

        public const uint OPCUASchedulerNamespaceMetadata_DefaultUserRolePermissions = 34;

        public const uint OPCUASchedulerNamespaceMetadata_DefaultAccessRestrictions = 35;

        public const uint CalendarType_PresentValue = 38;

        public const uint CalendarType_DateList = 39;

        public const uint CalendarType_AddDateListElements_InputArguments = 41;

        public const uint CalendarType_AddDateListElements_OutputArguments = 42;

        public const uint CalendarType_RemoveDateListElements_InputArguments = 44;

        public const uint CalendarType_RemoveDateListElements_OutputArguments = 45;

        public const uint ScheduleType_ExceptionSchedule = 53;

        public const uint ScheduleType_AddExceptionScheduleElements_InputArguments = 55;

        public const uint ScheduleType_AddExceptionScheduleElements_OutputArguments = 56;

        public const uint ScheduleType_RemoveExceptionScheduleElements_InputArguments = 58;

        public const uint ScheduleType_RemoveExceptionScheduleElements_OutputArguments = 59;

        public const uint ScheduleType_WeeklySchedule = 60;

        public const uint ScheduleType_LocalTime = 61;

        public const uint ScheduleType_EffectivePeriod = 62;

        public const uint ScheduleType_ApplyLastAfterStart = 63;

        public const uint Month_EnumStrings = 194;

        public const uint DayOfMonth_EnumStrings = 195;

        public const uint DayOfWeek_EnumStrings = 79;

        public const uint OpcUaScheduler_BinarySchema = 98;

        public const uint OpcUaScheduler_BinarySchema_NamespaceUri = 100;

        public const uint OpcUaScheduler_BinarySchema_Deprecated = 101;

        public const uint OpcUaScheduler_BinarySchema_SpecialEventType = 102;

        public const uint OpcUaScheduler_BinarySchema_SpecialEventPeriodType = 105;

        public const uint OpcUaScheduler_BinarySchema_CalendarEntryType = 108;

        public const uint OpcUaScheduler_BinarySchema_DateType = 111;

        public const uint OpcUaScheduler_BinarySchema_DateRangeType = 114;

        public const uint OpcUaScheduler_BinarySchema_TimeActionsType = 117;

        public const uint OpcUaScheduler_BinarySchema_BaseActionType = 120;

        public const uint OpcUaScheduler_BinarySchema_WriteLocalVariableActionType = 123;

        public const uint OpcUaScheduler_BinarySchema_CallLocalMethodActionType = 126;

        public const uint OpcUaScheduler_BinarySchema_TimeType = 129;

        public const uint OpcUaScheduler_BinarySchema_DailyScheduleType = 132;

        public const uint OpcUaScheduler_XmlSchema = 146;

        public const uint OpcUaScheduler_XmlSchema_NamespaceUri = 148;

        public const uint OpcUaScheduler_XmlSchema_Deprecated = 149;

        public const uint OpcUaScheduler_XmlSchema_SpecialEventType = 150;

        public const uint OpcUaScheduler_XmlSchema_SpecialEventPeriodType = 153;

        public const uint OpcUaScheduler_XmlSchema_CalendarEntryType = 156;

        public const uint OpcUaScheduler_XmlSchema_DateType = 159;

        public const uint OpcUaScheduler_XmlSchema_DateRangeType = 162;

        public const uint OpcUaScheduler_XmlSchema_TimeActionsType = 165;

        public const uint OpcUaScheduler_XmlSchema_BaseActionType = 168;

        public const uint OpcUaScheduler_XmlSchema_WriteLocalVariableActionType = 171;

        public const uint OpcUaScheduler_XmlSchema_CallLocalMethodActionType = 174;

        public const uint OpcUaScheduler_XmlSchema_TimeType = 177;

        public const uint OpcUaScheduler_XmlSchema_DailyScheduleType = 180;
    }
    #endregion

    #region DataType Node Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class DataTypeIds
    {
        public static readonly ExpandedNodeId SpecialEventType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.SpecialEventType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId SpecialEventPeriodType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.SpecialEventPeriodType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId CalendarEntryType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.CalendarEntryType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId DateType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.DateType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId Month = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.Month, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId DayOfMonth = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.DayOfMonth, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId DayOfWeek = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.DayOfWeek, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId DateRangeType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.DateRangeType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId TimeActionsType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.TimeActionsType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId BaseActionType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.BaseActionType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId WriteLocalVariableActionType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.WriteLocalVariableActionType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId CallLocalMethodActionType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.CallLocalMethodActionType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId TimeType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.TimeType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId DailyScheduleType = new ExpandedNodeId(Opc.Ua.Scheduler.DataTypes.DailyScheduleType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);
    }
    #endregion

    #region Method Node Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class MethodIds
    {
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Open = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.OPCUASchedulerNamespaceMetadata_NamespaceFile_Open, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Close = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.OPCUASchedulerNamespaceMetadata_NamespaceFile_Close, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Read = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.OPCUASchedulerNamespaceMetadata_NamespaceFile_Read, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Write = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.OPCUASchedulerNamespaceMetadata_NamespaceFile_Write, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_SetPosition = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.OPCUASchedulerNamespaceMetadata_NamespaceFile_SetPosition, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId CalendarType_AddDateListElements = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.CalendarType_AddDateListElements, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId CalendarType_RemoveDateListElements = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.CalendarType_RemoveDateListElements, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId ScheduleType_AddExceptionScheduleElements = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.ScheduleType_AddExceptionScheduleElements, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId ScheduleType_RemoveExceptionScheduleElements = new ExpandedNodeId(Opc.Ua.Scheduler.Methods.ScheduleType_RemoveExceptionScheduleElements, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);
    }
    #endregion

    #region Object Node Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class ObjectIds
    {
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.OPCUASchedulerNamespaceMetadata, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId SpecialEventType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.SpecialEventType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId SpecialEventPeriodType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.SpecialEventPeriodType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId CalendarEntryType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.CalendarEntryType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId DateType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.DateType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId DateRangeType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.DateRangeType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId TimeActionsType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.TimeActionsType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId BaseActionType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.BaseActionType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId WriteLocalVariableActionType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.WriteLocalVariableActionType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId CallLocalMethodActionType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.CallLocalMethodActionType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId TimeType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.TimeType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId DailyScheduleType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.DailyScheduleType_Encoding_DefaultBinary, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId SpecialEventType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.SpecialEventType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId SpecialEventPeriodType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.SpecialEventPeriodType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId CalendarEntryType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.CalendarEntryType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId DateType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.DateType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId DateRangeType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.DateRangeType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId TimeActionsType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.TimeActionsType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId BaseActionType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.BaseActionType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId WriteLocalVariableActionType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.WriteLocalVariableActionType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId CallLocalMethodActionType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.CallLocalMethodActionType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId TimeType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.TimeType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId DailyScheduleType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Scheduler.Objects.DailyScheduleType_Encoding_DefaultXml, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class ObjectTypeIds
    {
        public static readonly ExpandedNodeId CalendarType = new ExpandedNodeId(Opc.Ua.Scheduler.ObjectTypes.CalendarType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId ScheduleType = new ExpandedNodeId(Opc.Ua.Scheduler.ObjectTypes.ScheduleType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);
    }
    #endregion

    #region Variable Node Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class VariableIds
    {
        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceUri = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceUri, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceVersion = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceVersion, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespacePublicationDate = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespacePublicationDate, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_IsNamespaceSubset = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_IsNamespaceSubset, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_StaticNodeIdTypes = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_StaticNodeIdTypes, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_StaticNumericNodeIdRange = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_StaticNumericNodeIdRange, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_StaticStringNodeIdPattern = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_StaticStringNodeIdPattern, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Size = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_Size, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Writable = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_Writable, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_UserWritable = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_UserWritable, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_OpenCount = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_OpenCount, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_Open_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_Open_OutputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_Close_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_Read_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_Read_OutputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_Write_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_NamespaceFile_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_NamespaceFile_SetPosition_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_DefaultRolePermissions = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_DefaultRolePermissions, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_DefaultUserRolePermissions = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_DefaultUserRolePermissions, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OPCUASchedulerNamespaceMetadata_DefaultAccessRestrictions = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OPCUASchedulerNamespaceMetadata_DefaultAccessRestrictions, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId CalendarType_PresentValue = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.CalendarType_PresentValue, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId CalendarType_DateList = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.CalendarType_DateList, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId CalendarType_AddDateListElements_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.CalendarType_AddDateListElements_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId CalendarType_AddDateListElements_OutputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.CalendarType_AddDateListElements_OutputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId CalendarType_RemoveDateListElements_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.CalendarType_RemoveDateListElements_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId CalendarType_RemoveDateListElements_OutputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.CalendarType_RemoveDateListElements_OutputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId ScheduleType_ExceptionSchedule = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.ScheduleType_ExceptionSchedule, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId ScheduleType_AddExceptionScheduleElements_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.ScheduleType_AddExceptionScheduleElements_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId ScheduleType_AddExceptionScheduleElements_OutputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.ScheduleType_AddExceptionScheduleElements_OutputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId ScheduleType_RemoveExceptionScheduleElements_InputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.ScheduleType_RemoveExceptionScheduleElements_InputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId ScheduleType_RemoveExceptionScheduleElements_OutputArguments = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.ScheduleType_RemoveExceptionScheduleElements_OutputArguments, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId ScheduleType_WeeklySchedule = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.ScheduleType_WeeklySchedule, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId ScheduleType_LocalTime = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.ScheduleType_LocalTime, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId ScheduleType_EffectivePeriod = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.ScheduleType_EffectivePeriod, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId ScheduleType_ApplyLastAfterStart = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.ScheduleType_ApplyLastAfterStart, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId Month_EnumStrings = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.Month_EnumStrings, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId DayOfMonth_EnumStrings = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.DayOfMonth_EnumStrings, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId DayOfWeek_EnumStrings = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.DayOfWeek_EnumStrings, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_NamespaceUri = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_NamespaceUri, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_Deprecated = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_Deprecated, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_SpecialEventType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_SpecialEventType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_SpecialEventPeriodType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_SpecialEventPeriodType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_CalendarEntryType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_CalendarEntryType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_DateType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_DateType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_DateRangeType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_DateRangeType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_TimeActionsType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_TimeActionsType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_BaseActionType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_BaseActionType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_WriteLocalVariableActionType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_WriteLocalVariableActionType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_CallLocalMethodActionType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_CallLocalMethodActionType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_TimeType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_TimeType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_BinarySchema_DailyScheduleType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_BinarySchema_DailyScheduleType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_NamespaceUri = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_NamespaceUri, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_Deprecated = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_Deprecated, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_SpecialEventType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_SpecialEventType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_SpecialEventPeriodType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_SpecialEventPeriodType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_CalendarEntryType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_CalendarEntryType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_DateType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_DateType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_DateRangeType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_DateRangeType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_TimeActionsType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_TimeActionsType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_BaseActionType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_BaseActionType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_WriteLocalVariableActionType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_WriteLocalVariableActionType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_CallLocalMethodActionType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_CallLocalMethodActionType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_TimeType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_TimeType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);

        public static readonly ExpandedNodeId OpcUaScheduler_XmlSchema_DailyScheduleType = new ExpandedNodeId(Opc.Ua.Scheduler.Variables.OpcUaScheduler_XmlSchema_DailyScheduleType, Opc.Ua.Scheduler.Namespaces.OpcUaScheduler);
    }
    #endregion

    #region BrowseName Declarations
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class BrowseNames
    {
        public const string AddDateListElements = "AddDateListElements";

        public const string AddExceptionScheduleElements = "AddExceptionScheduleElements";

        public const string ApplyLastAfterStart = "ApplyLastAfterStart";

        public const string BaseActionType = "BaseActionType";

        public const string CalendarEntryType = "CalendarEntryType";

        public const string CalendarType = "CalendarType";

        public const string CallLocalMethodActionType = "CallLocalMethodActionType";

        public const string DailyScheduleType = "DailyScheduleType";

        public const string DateList = "DateList";

        public const string DateRangeType = "DateRangeType";

        public const string DateType = "DateType";

        public const string DayOfMonth = "DayOfMonth";

        public const string DayOfWeek = "DayOfWeek";

        public const string EffectivePeriod = "EffectivePeriod";

        public const string ExceptionSchedule = "ExceptionSchedule";

        public const string Month = "Month";

        public const string OpcUaScheduler_BinarySchema = "Opc.Ua.Scheduler";

        public const string OpcUaScheduler_XmlSchema = "Opc.Ua.Scheduler";

        public const string OPCUASchedulerNamespaceMetadata = "http://opcfoundation.org/UA/Scheduler/";

        public const string PresentValue = "PresentValue";

        public const string RemoveDateListElements = "RemoveDateListElements";

        public const string RemoveExceptionScheduleElements = "RemoveExceptionScheduleElements";

        public const string ScheduleType = "ScheduleType";

        public const string SpecialEventPeriodType = "SpecialEventPeriodType";

        public const string SpecialEventType = "SpecialEventType";

        public const string TimeActionsType = "TimeActionsType";

        public const string TimeType = "TimeType";

        public const string WeeklySchedule = "WeeklySchedule";

        public const string WriteLocalVariableActionType = "WriteLocalVariableActionType";
    }
    #endregion

    #region Namespace Declarations
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
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