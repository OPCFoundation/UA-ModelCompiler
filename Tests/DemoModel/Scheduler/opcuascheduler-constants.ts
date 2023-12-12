
export enum DataTypeIds {
   SpecialEventType = 'i=70',
   SpecialEventPeriodType = 'i=71',
   CalendarEntryType = 'i=72',
   DateType = 'i=73',
   Month = 'i=74',
   DayOfMonth = 'i=76',
   DayOfWeek = 'i=78',
   DateRangeType = 'i=80',
   TimeActionsType = 'i=81',
   BaseActionType = 'i=82',
   WriteLocalVariableActionType = 'i=83',
   CallLocalMethodActionType = 'i=84',
   TimeType = 'i=85',
   DailyScheduleType = 'i=86'
}

export enum MethodIds {
   OPCUASchedulerNamespaceMetadata_NamespaceFile_Open = 'i=17',
   OPCUASchedulerNamespaceMetadata_NamespaceFile_Close = 'i=20',
   OPCUASchedulerNamespaceMetadata_NamespaceFile_Read = 'i=22',
   OPCUASchedulerNamespaceMetadata_NamespaceFile_Write = 'i=25',
   OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition = 'i=27',
   OPCUASchedulerNamespaceMetadata_NamespaceFile_SetPosition = 'i=30',
   CalendarType_AddDateListElements = 'i=40',
   CalendarType_RemoveDateListElements = 'i=43',
   ScheduleType_AddExceptionScheduleElements = 'i=54',
   ScheduleType_RemoveExceptionScheduleElements = 'i=57'
}

export enum ObjectIds {
   OPCUASchedulerNamespaceMetadata = 'i=1'
}

export enum ObjectTypeIds {
   CalendarType = 'i=37',
   ScheduleType = 'i=52'
}

export enum VariableIds {
   OPCUASchedulerNamespaceMetadata_NamespaceUri = 'i=2',
   OPCUASchedulerNamespaceMetadata_NamespaceVersion = 'i=3',
   OPCUASchedulerNamespaceMetadata_NamespacePublicationDate = 'i=4',
   OPCUASchedulerNamespaceMetadata_IsNamespaceSubset = 'i=5',
   OPCUASchedulerNamespaceMetadata_StaticNodeIdTypes = 'i=6',
   OPCUASchedulerNamespaceMetadata_StaticNumericNodeIdRange = 'i=7',
   OPCUASchedulerNamespaceMetadata_StaticStringNodeIdPattern = 'i=8',
   OPCUASchedulerNamespaceMetadata_NamespaceFile_Size = 'i=10',
   OPCUASchedulerNamespaceMetadata_NamespaceFile_Writable = 'i=11',
   OPCUASchedulerNamespaceMetadata_NamespaceFile_UserWritable = 'i=12',
   OPCUASchedulerNamespaceMetadata_NamespaceFile_OpenCount = 'i=13',
   OPCUASchedulerNamespaceMetadata_NamespaceFile_Open_InputArguments = 'i=18',
   OPCUASchedulerNamespaceMetadata_NamespaceFile_Open_OutputArguments = 'i=19',
   OPCUASchedulerNamespaceMetadata_NamespaceFile_Close_InputArguments = 'i=21',
   OPCUASchedulerNamespaceMetadata_NamespaceFile_Read_InputArguments = 'i=23',
   OPCUASchedulerNamespaceMetadata_NamespaceFile_Read_OutputArguments = 'i=24',
   OPCUASchedulerNamespaceMetadata_NamespaceFile_Write_InputArguments = 'i=26',
   OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition_InputArguments = 'i=28',
   OPCUASchedulerNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments = 'i=29',
   OPCUASchedulerNamespaceMetadata_NamespaceFile_SetPosition_InputArguments = 'i=31',
   OPCUASchedulerNamespaceMetadata_DefaultRolePermissions = 'i=33',
   OPCUASchedulerNamespaceMetadata_DefaultUserRolePermissions = 'i=34',
   OPCUASchedulerNamespaceMetadata_DefaultAccessRestrictions = 'i=35',
   Month_EnumStrings = 'i=194',
   DayOfMonth_EnumStrings = 'i=195',
   DayOfWeek_EnumStrings = 'i=79',
   OpcUaScheduler_BinarySchema = 'i=98',
   OpcUaScheduler_BinarySchema_NamespaceUri = 'i=100',
   OpcUaScheduler_BinarySchema_Deprecated = 'i=101',
   OpcUaScheduler_BinarySchema_SpecialEventType = 'i=102',
   OpcUaScheduler_BinarySchema_SpecialEventPeriodType = 'i=105',
   OpcUaScheduler_BinarySchema_CalendarEntryType = 'i=108',
   OpcUaScheduler_BinarySchema_DateType = 'i=111',
   OpcUaScheduler_BinarySchema_DateRangeType = 'i=114',
   OpcUaScheduler_BinarySchema_TimeActionsType = 'i=117',
   OpcUaScheduler_BinarySchema_BaseActionType = 'i=120',
   OpcUaScheduler_BinarySchema_WriteLocalVariableActionType = 'i=123',
   OpcUaScheduler_BinarySchema_CallLocalMethodActionType = 'i=126',
   OpcUaScheduler_BinarySchema_TimeType = 'i=129',
   OpcUaScheduler_BinarySchema_DailyScheduleType = 'i=132',
   OpcUaScheduler_XmlSchema = 'i=146',
   OpcUaScheduler_XmlSchema_NamespaceUri = 'i=148',
   OpcUaScheduler_XmlSchema_Deprecated = 'i=149',
   OpcUaScheduler_XmlSchema_SpecialEventType = 'i=150',
   OpcUaScheduler_XmlSchema_SpecialEventPeriodType = 'i=153',
   OpcUaScheduler_XmlSchema_CalendarEntryType = 'i=156',
   OpcUaScheduler_XmlSchema_DateType = 'i=159',
   OpcUaScheduler_XmlSchema_DateRangeType = 'i=162',
   OpcUaScheduler_XmlSchema_TimeActionsType = 'i=165',
   OpcUaScheduler_XmlSchema_BaseActionType = 'i=168',
   OpcUaScheduler_XmlSchema_WriteLocalVariableActionType = 'i=171',
   OpcUaScheduler_XmlSchema_CallLocalMethodActionType = 'i=174',
   OpcUaScheduler_XmlSchema_TimeType = 'i=177',
   OpcUaScheduler_XmlSchema_DailyScheduleType = 'i=180'
}

export class StatusCode {
   public static isGood(code?: number): boolean {
      return !code || (code & 0xD0000000) === 0;
   }
   public static isUncertain(code?: number): boolean {
      return (code ?? 0 & 0x40000000) !== 0;
   }
   public static isBad(code?: number): boolean {
      return (code ?? 0 & 0x80000000) !== 0;
   }
}