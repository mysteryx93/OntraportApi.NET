using System;
using Newtonsoft.Json.Serialization;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi.Converters
{
    /// <summary>
    /// Converts a string field into an enumeration, using SnakeCase naming strategy by default.
    /// </summary>
    /// <typeparam name="T">The enumeration type.</typeparam>
    public class JsonConverterStringEnum<T> : JsonConverterBase<T>
        where T : struct
    {
        private readonly NamingStrategy _namingStrategy;

        public JsonConverterStringEnum() : this(null)
        { }

        public JsonConverterStringEnum(NamingStrategy namingStrategy)
        {
            _namingStrategy = namingStrategy ?? new SnakeCaseNamingStrategy();
        }

        public override string NullString => null;

        public override Nullable<T> Parse(string value) =>
            !IsNullValue(value) ? value.Replace("_", "").Convert<T?>() : (T?)null;

        public override string Format(T? value) => 
            value != null ? _namingStrategy.GetPropertyName(value.ToStringInvariant(), false) : null;
    }
}
