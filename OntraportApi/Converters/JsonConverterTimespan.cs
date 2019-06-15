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

        public override TimeSpan? Parse(string value) => 
            !IsNullValue(value) ? TimeSpan.FromSeconds(value.Convert<long>()) : (TimeSpan?)null;

        public override string Format(TimeSpan? value) => 
            value != null ? ((TimeSpan)value).TotalSeconds.ToString() : "0";
    }
}
