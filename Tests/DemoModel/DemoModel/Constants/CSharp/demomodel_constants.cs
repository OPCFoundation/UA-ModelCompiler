namespace DemoModel.WebApi
{
    /// <summary>
    /// The namespaces used in the model.
    /// </summary>
    public static class Namespaces
    {
        /// <remarks />
        public const string Uri = "urn:opcfoundation.org:2024-01:DemoModel";
    }

    /// <summary>
    /// The browse names defined in the model.
    /// </summary>
    public static class BrowseNames
    {
        /// <remarks />
        public const string Blue = "Blue";
        /// <remarks />
        public const string DemoModel_BinarySchema = "DemoModel";
        /// <remarks />
        public const string DemoModel_XmlSchema = "DemoModel";
        /// <remarks />
        public const string EnumUnderscoreTest = "EnumUnderscoreTest";
        /// <remarks />
        public const string HeaterStatus = "HeaterStatus";
        /// <remarks />
        public const string Person = "Person";
        /// <remarks />
        public const string Pink_Placeholder = "<Pink>";
        /// <remarks />
        public const string Red = "Red";
        /// <remarks />
        public const string RestrictedObjectType = "RestrictedObjectType";
        /// <remarks />
        public const string RestrictedVariableType = "RestrictedVariableType";
        /// <remarks />
        public const string SampleStructureAllowSubtypes = "SampleStructureAllowSubtypes";
        /// <remarks />
        public const string SampleStructureWithOptionalFields = "SampleStructureWithOptionalFields";
        /// <remarks />
        public const string SampleUnion = "SampleUnion";
        /// <remarks />
        public const string SampleUnionAllowSubtypes = "SampleUnionAllowSubtypes";
        /// <remarks />
        public const string Seeker = "Seeker";
        /// <remarks />
        public const string Student = "Student";
        /// <remarks />
        public const string Test_Error = "Test_Error";
        /// <remarks />
        public const string Test_ErrorComponent = "Test_ErrorComponent";
        /// <remarks />
        public const string TestObject = "TestObject";
        /// <remarks />
        public const string Vector = "Vector";
        /// <remarks />
        public const string WithTwoDimensionalVariableType = "WithTwoDimensionalVariableType";
        /// <remarks />
        public const string WorkOrderStatusType = "WorkOrderStatusType";
        /// <remarks />
        public const string WorkOrderType = "WorkOrderType";
        /// <remarks />
        public const string X = "X";
        /// <remarks />
        public const string Y = "Y";
        /// <remarks />
        public const string Yellow = "Yellow";
        /// <remarks />
        public const string Z = "Z";
    }

    /// <summary>
    /// The well known identifiers for DataType nodes.
    /// </summary>
    public static class DataTypeIds {
        /// <remarks />
        public const string EnumUnderscoreTest = "nsu=" + Namespaces.Uri + ";i=68";
        /// <remarks />
        public const string HeaterStatus = "nsu=" + Namespaces.Uri + ";i=1";
        /// <remarks />
        public const string Vector = "nsu=" + Namespaces.Uri + ";i=3";
        /// <remarks />
        public const string WorkOrderStatusType = "nsu=" + Namespaces.Uri + ";i=4";
        /// <remarks />
        public const string WorkOrderType = "nsu=" + Namespaces.Uri + ";i=5";
        /// <remarks />
        public const string SampleUnion = "nsu=" + Namespaces.Uri + ";i=41";
        /// <remarks />
        public const string SampleStructureWithOptionalFields = "nsu=" + Namespaces.Uri + ";i=42";
        /// <remarks />
        public const string SampleUnionAllowSubtypes = "nsu=" + Namespaces.Uri + ";i=43";
        /// <remarks />
        public const string SampleStructureAllowSubtypes = "nsu=" + Namespaces.Uri + ";i=44";
        /// <remarks />
        public const string Person = "nsu=" + Namespaces.Uri + ";i=222";
        /// <remarks />
        public const string Student = "nsu=" + Namespaces.Uri + ";i=223";

        /// <summary>
        /// Converts a value to a name for display.
        /// </summary>
        public static string ToName(string value)
        {
            foreach (var field in typeof(DataTypeIds).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
            {
                if (field.GetValue(null).Equals(value))
                {
                    return field.Name;
                }
            }

            return value.ToString();
        }
    }

    /// <summary>
    /// The well known identifiers for Method nodes.
    /// </summary>
    public static class MethodIds {
        /// <remarks />
        public const string RestrictedObjectType_Blue = "nsu=" + Namespaces.Uri + ";i=127";
        /// <remarks />
        public const string TestObject_Blue = "nsu=" + Namespaces.Uri + ";i=71";

        /// <summary>
        /// Converts a value to a name for display.
        /// </summary>
        public static string ToName(string value)
        {
            foreach (var field in typeof(MethodIds).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
            {
                if (field.GetValue(null).Equals(value))
                {
                    return field.Name;
                }
            }

            return value.ToString();
        }
    }

    /// <summary>
    /// The well known identifiers for Object nodes.
    /// </summary>
    public static class ObjectIds {
        /// <remarks />
        public const string Seeker = "nsu=" + Namespaces.Uri + ";i=95";
        /// <remarks />
        public const string TestObject = "nsu=" + Namespaces.Uri + ";i=128";
        /// <remarks />
        public const string Test_Error = "nsu=" + Namespaces.Uri + ";i=93";
        /// <remarks />
        public const string Test_ErrorComponent = "nsu=" + Namespaces.Uri + ";i=94";
        /// <remarks />
        public const string Vector_Encoding_DefaultBinary = "nsu=" + Namespaces.Uri + ";i=21";
        /// <remarks />
        public const string WorkOrderStatusType_Encoding_DefaultBinary = "nsu=" + Namespaces.Uri + ";i=22";
        /// <remarks />
        public const string WorkOrderType_Encoding_DefaultBinary = "nsu=" + Namespaces.Uri + ";i=23";
        /// <remarks />
        public const string SampleUnion_Encoding_DefaultBinary = "nsu=" + Namespaces.Uri + ";i=45";
        /// <remarks />
        public const string SampleStructureWithOptionalFields_Encoding_DefaultBinary = "nsu=" + Namespaces.Uri + ";i=46";
        /// <remarks />
        public const string SampleUnionAllowSubtypes_Encoding_DefaultBinary = "nsu=" + Namespaces.Uri + ";i=47";
        /// <remarks />
        public const string SampleStructureAllowSubtypes_Encoding_DefaultBinary = "nsu=" + Namespaces.Uri + ";i=48";
        /// <remarks />
        public const string Person_Encoding_DefaultBinary = "nsu=" + Namespaces.Uri + ";i=224";
        /// <remarks />
        public const string Student_Encoding_DefaultBinary = "nsu=" + Namespaces.Uri + ";i=225";
        /// <remarks />
        public const string Vector_Encoding_DefaultXml = "nsu=" + Namespaces.Uri + ";i=6";
        /// <remarks />
        public const string WorkOrderStatusType_Encoding_DefaultXml = "nsu=" + Namespaces.Uri + ";i=7";
        /// <remarks />
        public const string WorkOrderType_Encoding_DefaultXml = "nsu=" + Namespaces.Uri + ";i=8";
        /// <remarks />
        public const string SampleUnion_Encoding_DefaultXml = "nsu=" + Namespaces.Uri + ";i=62";
        /// <remarks />
        public const string SampleStructureWithOptionalFields_Encoding_DefaultXml = "nsu=" + Namespaces.Uri + ";i=63";
        /// <remarks />
        public const string SampleUnionAllowSubtypes_Encoding_DefaultXml = "nsu=" + Namespaces.Uri + ";i=64";
        /// <remarks />
        public const string SampleStructureAllowSubtypes_Encoding_DefaultXml = "nsu=" + Namespaces.Uri + ";i=65";
        /// <remarks />
        public const string Person_Encoding_DefaultXml = "nsu=" + Namespaces.Uri + ";i=232";
        /// <remarks />
        public const string Student_Encoding_DefaultXml = "nsu=" + Namespaces.Uri + ";i=233";
        /// <remarks />
        public const string Vector_Encoding_DefaultJson = "nsu=" + Namespaces.Uri + ";i=79";
        /// <remarks />
        public const string WorkOrderStatusType_Encoding_DefaultJson = "nsu=" + Namespaces.Uri + ";i=80";
        /// <remarks />
        public const string WorkOrderType_Encoding_DefaultJson = "nsu=" + Namespaces.Uri + ";i=81";
        /// <remarks />
        public const string SampleUnion_Encoding_DefaultJson = "nsu=" + Namespaces.Uri + ";i=82";
        /// <remarks />
        public const string SampleStructureWithOptionalFields_Encoding_DefaultJson = "nsu=" + Namespaces.Uri + ";i=83";
        /// <remarks />
        public const string SampleUnionAllowSubtypes_Encoding_DefaultJson = "nsu=" + Namespaces.Uri + ";i=84";
        /// <remarks />
        public const string SampleStructureAllowSubtypes_Encoding_DefaultJson = "nsu=" + Namespaces.Uri + ";i=85";
        /// <remarks />
        public const string Person_Encoding_DefaultJson = "nsu=" + Namespaces.Uri + ";i=240";
        /// <remarks />
        public const string Student_Encoding_DefaultJson = "nsu=" + Namespaces.Uri + ";i=241";

        /// <summary>
        /// Converts a value to a name for display.
        /// </summary>
        public static string ToName(string value)
        {
            foreach (var field in typeof(ObjectIds).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
            {
                if (field.GetValue(null).Equals(value))
                {
                    return field.Name;
                }
            }

            return value.ToString();
        }
    }

    /// <summary>
    /// The well known identifiers for ObjectType nodes.
    /// </summary>
    public static class ObjectTypeIds {
        /// <remarks />
        public const string RestrictedObjectType = "nsu=" + Namespaces.Uri + ";i=124";
        /// <remarks />
        public const string WithTwoDimensionalVariableType = "nsu=" + Namespaces.Uri + ";i=120";

        /// <summary>
        /// Converts a value to a name for display.
        /// </summary>
        public static string ToName(string value)
        {
            foreach (var field in typeof(ObjectTypeIds).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
            {
                if (field.GetValue(null).Equals(value))
                {
                    return field.Name;
                }
            }

            return value.ToString();
        }
    }

    /// <summary>
    /// The well known identifiers for Variable nodes.
    /// </summary>
    public static class VariableIds {
        /// <remarks />
        public const string Seeker_Identities = "nsu=" + Namespaces.Uri + ";i=10";
        /// <remarks />
        public const string Seeker_AddIdentity_InputArguments = "nsu=" + Namespaces.Uri + ";i=25";
        /// <remarks />
        public const string Seeker_RemoveIdentity_InputArguments = "nsu=" + Namespaces.Uri + ";i=29";
        /// <remarks />
        public const string Seeker_AddApplication_InputArguments = "nsu=" + Namespaces.Uri + ";i=32";
        /// <remarks />
        public const string Seeker_RemoveApplication_InputArguments = "nsu=" + Namespaces.Uri + ";i=35";
        /// <remarks />
        public const string Seeker_AddEndpoint_InputArguments = "nsu=" + Namespaces.Uri + ";i=52";
        /// <remarks />
        public const string Seeker_RemoveEndpoint_InputArguments = "nsu=" + Namespaces.Uri + ";i=55";
        /// <remarks />
        public const string EnumUnderscoreTest_EnumValues = "nsu=" + Namespaces.Uri + ";i=69";
        /// <remarks />
        public const string RestrictedVariableType_Yellow = "nsu=" + Namespaces.Uri + ";i=123";
        /// <remarks />
        public const string RestrictedVariableType_X = "nsu=" + Namespaces.Uri + ";i=210";
        /// <remarks />
        public const string RestrictedVariableType_Y = "nsu=" + Namespaces.Uri + ";i=211";
        /// <remarks />
        public const string RestrictedVariableType_Z = "nsu=" + Namespaces.Uri + ";i=212";
        /// <remarks />
        public const string RestrictedObjectType_Red = "nsu=" + Namespaces.Uri + ";i=125";
        /// <remarks />
        public const string RestrictedObjectType_Red_Yellow = "nsu=" + Namespaces.Uri + ";i=57";
        /// <remarks />
        public const string RestrictedObjectType_Red_X = "nsu=" + Namespaces.Uri + ";i=213";
        /// <remarks />
        public const string RestrictedObjectType_Red_Y = "nsu=" + Namespaces.Uri + ";i=214";
        /// <remarks />
        public const string RestrictedObjectType_Red_Z = "nsu=" + Namespaces.Uri + ";i=215";
        /// <remarks />
        public const string RestrictedObjectType_Pink_Placeholder = "nsu=" + Namespaces.Uri + ";i=132";
        /// <remarks />
        public const string RestrictedObjectType_Pink_Placeholder_Yellow = "nsu=" + Namespaces.Uri + ";i=58";
        /// <remarks />
        public const string RestrictedObjectType_Pink_Placeholder_X = "nsu=" + Namespaces.Uri + ";i=216";
        /// <remarks />
        public const string RestrictedObjectType_Pink_Placeholder_Y = "nsu=" + Namespaces.Uri + ";i=217";
        /// <remarks />
        public const string RestrictedObjectType_Pink_Placeholder_Z = "nsu=" + Namespaces.Uri + ";i=218";
        /// <remarks />
        public const string TestObject_Red = "nsu=" + Namespaces.Uri + ";i=60";
        /// <remarks />
        public const string TestObject_Red_Yellow = "nsu=" + Namespaces.Uri + ";i=61";
        /// <remarks />
        public const string TestObject_Red_X = "nsu=" + Namespaces.Uri + ";i=219";
        /// <remarks />
        public const string TestObject_Red_Y = "nsu=" + Namespaces.Uri + ";i=220";
        /// <remarks />
        public const string TestObject_Red_Z = "nsu=" + Namespaces.Uri + ";i=221";
        /// <remarks />
        public const string HeaterStatus_EnumStrings = "nsu=" + Namespaces.Uri + ";i=2";
        /// <remarks />
        public const string WithTwoDimensionalVariableType_X = "nsu=" + Namespaces.Uri + ";i=121";
        /// <remarks />
        public const string DemoModel_BinarySchema = "nsu=" + Namespaces.Uri + ";i=24";
        /// <remarks />
        public const string DemoModel_BinarySchema_NamespaceUri = "nsu=" + Namespaces.Uri + ";i=26";
        /// <remarks />
        public const string DemoModel_BinarySchema_Deprecated = "nsu=" + Namespaces.Uri + ";i=49";
        /// <remarks />
        public const string DemoModel_BinarySchema_Vector = "nsu=" + Namespaces.Uri + ";i=27";
        /// <remarks />
        public const string DemoModel_BinarySchema_WorkOrderStatusType = "nsu=" + Namespaces.Uri + ";i=30";
        /// <remarks />
        public const string DemoModel_BinarySchema_WorkOrderType = "nsu=" + Namespaces.Uri + ";i=33";
        /// <remarks />
        public const string DemoModel_BinarySchema_SampleUnion = "nsu=" + Namespaces.Uri + ";i=50";
        /// <remarks />
        public const string DemoModel_BinarySchema_SampleStructureWithOptionalFields = "nsu=" + Namespaces.Uri + ";i=53";
        /// <remarks />
        public const string DemoModel_BinarySchema_SampleUnionAllowSubtypes = "nsu=" + Namespaces.Uri + ";i=56";
        /// <remarks />
        public const string DemoModel_BinarySchema_SampleStructureAllowSubtypes = "nsu=" + Namespaces.Uri + ";i=59";
        /// <remarks />
        public const string DemoModel_BinarySchema_Person = "nsu=" + Namespaces.Uri + ";i=226";
        /// <remarks />
        public const string DemoModel_BinarySchema_Student = "nsu=" + Namespaces.Uri + ";i=229";
        /// <remarks />
        public const string DemoModel_XmlSchema = "nsu=" + Namespaces.Uri + ";i=9";
        /// <remarks />
        public const string DemoModel_XmlSchema_NamespaceUri = "nsu=" + Namespaces.Uri + ";i=11";
        /// <remarks />
        public const string DemoModel_XmlSchema_Deprecated = "nsu=" + Namespaces.Uri + ";i=66";
        /// <remarks />
        public const string DemoModel_XmlSchema_Vector = "nsu=" + Namespaces.Uri + ";i=12";
        /// <remarks />
        public const string DemoModel_XmlSchema_WorkOrderStatusType = "nsu=" + Namespaces.Uri + ";i=15";
        /// <remarks />
        public const string DemoModel_XmlSchema_WorkOrderType = "nsu=" + Namespaces.Uri + ";i=18";
        /// <remarks />
        public const string DemoModel_XmlSchema_SampleUnion = "nsu=" + Namespaces.Uri + ";i=67";
        /// <remarks />
        public const string DemoModel_XmlSchema_SampleStructureWithOptionalFields = "nsu=" + Namespaces.Uri + ";i=70";
        /// <remarks />
        public const string DemoModel_XmlSchema_SampleUnionAllowSubtypes = "nsu=" + Namespaces.Uri + ";i=73";
        /// <remarks />
        public const string DemoModel_XmlSchema_SampleStructureAllowSubtypes = "nsu=" + Namespaces.Uri + ";i=76";
        /// <remarks />
        public const string DemoModel_XmlSchema_Person = "nsu=" + Namespaces.Uri + ";i=234";
        /// <remarks />
        public const string DemoModel_XmlSchema_Student = "nsu=" + Namespaces.Uri + ";i=237";

        /// <summary>
        /// Converts a value to a name for display.
        /// </summary>
        public static string ToName(string value)
        {
            foreach (var field in typeof(VariableIds).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
            {
                if (field.GetValue(null).Equals(value))
                {
                    return field.Name;
                }
            }

            return value.ToString();
        }
    }

    /// <summary>
    /// The well known identifiers for VariableType nodes.
    /// </summary>
    public static class VariableTypeIds {
        /// <remarks />
        public const string RestrictedVariableType = "nsu=" + Namespaces.Uri + ";i=122";

        /// <summary>
        /// Converts a value to a name for display.
        /// </summary>
        public static string ToName(string value)
        {
            foreach (var field in typeof(VariableTypeIds).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
            {
                if (field.GetValue(null).Equals(value))
                {
                    return field.Name;
                }
            }

            return value.ToString();
        }
    }
    
}