
export enum DataTypeIds {
   EnumUnderscoreTest = 'i=68',
   HeaterStatus = 'i=1',
   Vector = 'i=3',
   WorkOrderStatusType = 'i=4',
   WorkOrderType = 'i=5',
   SampleUnion = 'i=41',
   SampleStructureWithOptionalFields = 'i=42',
   SampleUnionAllowSubtypes = 'i=43',
   SampleStructureAllowSubtypes = 'i=44'
}

export enum MethodIds {
   RestrictedObjectType_Blue = 'i=127',
   TestObject_Blue = 'i=71'
}

export enum ObjectIds {
   Seeker = 'i=95',
   TestObject = 'i=128',
   Test_Error = 'i=93',
   Test_ErrorComponent = 'i=94',
   Vector_Encoding_DefaultBinary = 'i=21',
   SampleUnion_Encoding_DefaultBinary = 'i=45',
   SampleStructureWithOptionalFields_Encoding_DefaultBinary = 'i=46',
   SampleUnionAllowSubtypes_Encoding_DefaultBinary = 'i=47',
   SampleStructureAllowSubtypes_Encoding_DefaultBinary = 'i=48',
   Vector_Encoding_DefaultXml = 'i=6',
   SampleUnion_Encoding_DefaultXml = 'i=62',
   SampleStructureWithOptionalFields_Encoding_DefaultXml = 'i=63',
   SampleUnionAllowSubtypes_Encoding_DefaultXml = 'i=64',
   SampleStructureAllowSubtypes_Encoding_DefaultXml = 'i=65',
   Vector_Encoding_DefaultJson = 'i=79',
   SampleUnion_Encoding_DefaultJson = 'i=82',
   SampleStructureWithOptionalFields_Encoding_DefaultJson = 'i=83',
   SampleUnionAllowSubtypes_Encoding_DefaultJson = 'i=84',
   SampleStructureAllowSubtypes_Encoding_DefaultJson = 'i=85'
}

export enum ObjectTypeIds {
   RestrictedObjectType = 'i=124',
   WithTwoDimensionalVariableType = 'i=120'
}

export enum VariableIds {
   Seeker_Identities = 'i=10',
   Seeker_AddIdentity_InputArguments = 'i=25',
   Seeker_RemoveIdentity_InputArguments = 'i=29',
   Seeker_AddApplication_InputArguments = 'i=32',
   Seeker_RemoveApplication_InputArguments = 'i=35',
   Seeker_AddEndpoint_InputArguments = 'i=52',
   Seeker_RemoveEndpoint_InputArguments = 'i=55',
   EnumUnderscoreTest_EnumValues = 'i=69',
   TestObject_Red = 'i=60',
   TestObject_Red_Yellow = 'i=61',
   HeaterStatus_EnumStrings = 'i=2',
   DemoModel_BinarySchema = 'i=24',
   DemoModel_BinarySchema_NamespaceUri = 'i=26',
   DemoModel_BinarySchema_Deprecated = 'i=49',
   DemoModel_BinarySchema_Vector = 'i=27',
   DemoModel_BinarySchema_WorkOrderStatusType = 'i=30',
   DemoModel_BinarySchema_WorkOrderType = 'i=33',
   DemoModel_BinarySchema_SampleUnion = 'i=50',
   DemoModel_BinarySchema_SampleStructureWithOptionalFields = 'i=53',
   DemoModel_BinarySchema_SampleUnionAllowSubtypes = 'i=56',
   DemoModel_BinarySchema_SampleStructureAllowSubtypes = 'i=59',
   DemoModel_XmlSchema = 'i=9',
   DemoModel_XmlSchema_NamespaceUri = 'i=11',
   DemoModel_XmlSchema_Deprecated = 'i=66',
   DemoModel_XmlSchema_Vector = 'i=12',
   DemoModel_XmlSchema_WorkOrderStatusType = 'i=15',
   DemoModel_XmlSchema_WorkOrderType = 'i=18',
   DemoModel_XmlSchema_SampleUnion = 'i=67',
   DemoModel_XmlSchema_SampleStructureWithOptionalFields = 'i=70',
   DemoModel_XmlSchema_SampleUnionAllowSubtypes = 'i=73',
   DemoModel_XmlSchema_SampleStructureAllowSubtypes = 'i=76'
}

export enum VariableTypeIds {
   RestrictedVariableType = 'i=122'
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