// ***START***
/// <summary>
/// Helper class for working with OPC UA status codes.
/// </summary>
public static class StatusUtils
{
    /// <summary>
    /// Returns true if the code is good.
    /// </summary>
    public static bool IsGood(object code)
    {
        return (ToCode(code) & 0xD0000000) == 0;
    }
    /// <summary>
    /// Returns true if the code is uncertain.
    /// </summary>
    public static bool IsUncertain(object code)
    {
        return (ToCode(code) & 0x40000000) != 0;
    }
    /// <summary>
    /// Returns true if the code is bad.
    /// </summary>
    public static bool IsBad(object code)
    {
        return (ToCode(code) & 0x80000000) != 0;
    }
    /// <summary>
    /// Returns top 16 bits which represent the unique code for the error.
    /// </summary>
    public static long CodeBits(object code)
    {
        return (ToCode(code) & 0xFFFF0000);
    }
    /// <summary>
    /// Returns bottom 16 bits which represent the additional information about the error.
    /// </summary>
    public static long InfoBits(object code)
    {
        return (ToCode(code) & 0x0000FFFF);
    }
    /// <summary>
    /// Returns the code formatted as text.
    /// </summary>
    public static string ToText(object code)
    {
        var number = ToCode(code);

        foreach (var field in typeof(StatusCodes).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
        {
            if (field.GetValue(null).Equals(number))
            {
                return field.Name;
            }
        }

        return "0x" + number.ToString("X8");
    }
    private static long ToCode(object value)
    {
        if (value == null)
        {
            return 0;
        }
        if (value is long code)
        {
            return code;
        }
        var field = value.GetType().GetField("Code");
        if (field != null)
        {
            var fv = field.GetValue(value) as long?;
            if (fv != null)
            {
                return fv.Value;
            }
        }
        var property = value.GetType().GetProperty("Code");
        if (property != null)
        {
            var pv = property.GetValue(value) as long?;
            if (pv != null)
            {
                return pv.Value;
            }
        }
        return 0;
    }
}
// ***END***