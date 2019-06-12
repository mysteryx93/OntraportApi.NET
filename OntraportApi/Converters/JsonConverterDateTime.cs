using System;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi.Converters
{
    /// <summary>
    /// Converts a Unix Epoch seconds field into a DateTimeOffset property.
    /// </summary>
    public class JsonConverterDateTime : JsonConverterBase<DateTimeOffset>
    {
        public bool Milliseconds { get; private set; } = false;

        public JsonConverterDateTime()
        { }

        public JsonConverterDateTime(bool milliseconds)
        {
            Milliseconds = milliseconds;
        }

        public override string NullString => "0";

        public override P Parse<P>(string value, string jsonPath = null)
        {
            var valueLong = value.Convert<long?>();
            if (valueLong.HasValue && valueLong > 0)
            {
                return (P)(object)
                    (Milliseconds ? 
                    DateTimeOffset.FromUnixTimeMilliseconds(valueLong.Value) : 
                    DateTimeOffset.FromUnixTimeSeconds(valueLong.Value));
            }
            return CreateNull<P>(jsonPath);
        }

        public override object Format(DateTimeOffset? value) => 
            value != null ? Milliseconds ?
                ((DateTimeOffset)value).ToUnixTimeMilliseconds() :
                ((DateTimeOffset)value).ToUnixTimeSeconds() : 0;
    }
}
