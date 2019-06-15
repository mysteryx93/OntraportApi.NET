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

        public override DateTimeOffset? Parse(string value)
        {
            if (!IsNullValue(value))
            {
                var valueLong = value.Convert<long>();
                return Milliseconds ?
                    DateTimeOffset.FromUnixTimeMilliseconds(valueLong) :
                    DateTimeOffset.FromUnixTimeSeconds(valueLong);
            }
            return null;
        }

        public override string Format(DateTimeOffset? value) => 
            value != null ? Milliseconds ?
                ((DateTimeOffset)value).ToUnixTimeMilliseconds().ToString() :
                ((DateTimeOffset)value).ToUnixTimeSeconds().ToString() : "0";
    }
}
