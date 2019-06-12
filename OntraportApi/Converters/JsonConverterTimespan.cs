using System;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi.Converters
{
    /// <summary>
    /// Converts an integer field in seconds into a TimeSpan property.
    /// </summary>
    public class JsonConverterTimeSpan : JsonConverterBase<TimeSpan>
    {
        public override string NullString => "0";

        public override P Parse<P>(string value, string jsonPath = null)
        {
            var valueLong = value.Convert<long?>();
            if (valueLong.HasValue && valueLong > 0)
            {
                return (P)(object)TimeSpan.FromSeconds(valueLong.Value);
            }
            return CreateNull<P>(jsonPath);
        }

        public override object Format(TimeSpan? value) => 
            value != null ? (long)((TimeSpan)value).TotalSeconds : 0;
    }
}
