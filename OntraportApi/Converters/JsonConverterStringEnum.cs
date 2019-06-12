using System;
using Newtonsoft.Json.Serialization;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi.Converters
{
    /// <summary>
    /// Converts a string field into an enumeration.
    /// </summary>
    /// <typeparam name="T">The enumeration type.</typeparam>
    public class JsonConverterStringEnum<T> : JsonConverterBase<T>
        where T : struct
    {
        private readonly NamingStrategy _namingStrategy = new SnakeCaseNamingStrategy();

        public override string NullString => "";

        public override P Parse<P>(string value, string jsonPath = null)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var result = value.Convert<P>();
                if (result != null)
                {
                    return (P)(object)result;
                }
            }
            return CreateNull<P>(jsonPath);
        }

        public override object Format(T? value) => 
            value != null ? _namingStrategy.GetPropertyName(value.ToString(), false) : null;
    }
}
