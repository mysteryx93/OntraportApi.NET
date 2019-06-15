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
        public override T? Parse(string value) =>
            !IsNullValue(value) ? (T?)Enum.Parse(typeof(T), value) : (T?)null;

        public override string Format(T? value) => 
            value != null ? ((int)(object)value).ToString() : null;
    }
}
