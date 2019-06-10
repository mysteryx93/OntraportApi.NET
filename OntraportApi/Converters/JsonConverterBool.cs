using System;

namespace EmergenceGuardian.OntraportApi.Converters
{
    /// <summary>
    /// Converts a "true" or "false" field into a boolean property.
    /// </summary>
    public class JsonConverterBool : JsonConverterBase<bool>
    {
        public override string NullString => "";

        public override object Format(bool? value) => 
            value.HasValue ? (value == true ? "true" : "false") : null;
    }
}
