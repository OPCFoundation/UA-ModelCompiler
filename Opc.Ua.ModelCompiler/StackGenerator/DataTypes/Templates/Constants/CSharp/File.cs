// ***START***
namespace Opc.Ua.WebApi
{
    /// <summary>
    /// The well known identifiers for _ClassName_.
    /// </summary>
    public static class _ClassName_
    {
        // ListOfIdentifiers

        /// <summary>
        /// Converts a value to a name for display.
        /// </summary>
        public static string ToName(long value)
        {
            foreach (var field in typeof(_ClassName_).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
            {
                if (field.GetValue(null).Equals(value))
                {
                    return field.Name;
                }
            }

            return value.ToString();
        }
    }
    // StatusCodeHelpers
}
// ***END***