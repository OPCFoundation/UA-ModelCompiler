namespace ModelCompiler
{
    internal static class DesignQueryExtensions
    {
        public static bool HasOptionalFields(this DataTypeDesign dataType)
        {
            return dataType.HasFields && dataType.Fields.Any(field => field.IsOptional);
        }

        public static bool HasBaseStructureBaseType(this DataTypeDesign dataType)
        {
            return ((DataTypeDesign)dataType.BaseTypeNode).BasicDataType == BasicDataType.Structure;
        }

        public static bool HasCustomBaseType(this DataTypeDesign dataType)
        {
            return ((DataTypeDesign)dataType.BaseTypeNode).BasicDataType == BasicDataType.UserDefined;
        }
    }
}
