using System;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi.Converters
{
    /// <summary>
    /// Converts a Unix Epoch seconds field into a DateTimeOffset property.
    /// </summary>
    public class JsonConverterDateTime : JsonConverterBase<DateTimeOffset>
    {
        public override string NullString => "0";

        public override P Parse<P>(string value)
        {
            var valueLong = value.Convert<long?>();
            if (valueLong.HasValue && valueLong > 0)
            {
                return (P)(object)DateTimeOffset.FromUnixTimeSeconds(valueLong.Value);
            }
            return CreateNull<P>();
        }

        public override object Format(DateTimeOffset? value) => 
            value != null ? ((DateTimeOffset)value).ToUnixTimeSeconds() : 0;
    }
}
