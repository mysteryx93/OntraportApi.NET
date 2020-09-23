using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace HanumanInstitute.OntraportApi.Converters
{
    /// <summary>
    /// Converts a string field into an enumeration, using SnakeCase naming strategy by default.
    /// </summary>
    /// <typeparam name="T">The enumeration type.</typeparam>
    public class JsonConverterStringEnum<T> : JsonConverterBase<T?>
        where T : struct
    {
        private readonly JsonNamingPolicy _namingPolicy;

        public JsonConverterStringEnum() : this(null)
        { }

        public JsonConverterStringEnum(JsonNamingPolicy? namingStrategy)
        {
            _namingPolicy = namingStrategy ?? new SnakeCaseNamingPolicy();
        }

        public override string? NullString => null;


        [SuppressMessage("Globalization", "CA1307:Specify StringComparison", Justification = "Reviewed: Replace overload with culture is not available in .NET Standard 2.0")]
        public override T? Parse(string? value) =>
            !IsNullValue(value) ? value?.Replace("_", "")?.Convert<T?>() : (T?)null;

        public override string? Format(T? value) =>
            value != null ? _namingPolicy.ConvertName(value.ToStringInvariant()) : null;
    }
}
