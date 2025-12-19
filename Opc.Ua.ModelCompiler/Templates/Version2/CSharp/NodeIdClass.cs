// ***START***
/// <summary>
/// The well known identifiers for _NodeClass_ nodes.
/// </summary>
public static class _NodeClass_Ids {
    // ListOfIdentifiers

    /// <summary>
    /// Converts a value to a name for display.
    /// </summary>
    public static string ToName(string value)
    {
        foreach (var field in typeof(_NodeClass_Ids).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
        {
            if (field.GetValue(null).Equals(value))
            {
                return field.Name;
            }
        }

        return value?.ToString();
    }
}
// ***END***
