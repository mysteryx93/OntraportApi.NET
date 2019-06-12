using System;

namespace EmergenceGuardian.OntraportApi.Converters
{
    /// <summary>
    /// Converts an integer field into an enumeration.
    /// </summary>
    /// <typeparam name="T">The enumeration type.</typeparam>
    public class JsonConverterIntEnum<T> : JsonConverterBase<T>
        where T : struct
    {
        public override string NullString => "";

        public override P Parse<P>(string value, string jsonPath = null)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return (P)(object)Enum.Parse(typeof(T), value);
            }
            return CreateNull<P>(jsonPath);
        }

        public override object Format(T? value) => value != null ? (int)(object)value : (int?)null;
    }
}
