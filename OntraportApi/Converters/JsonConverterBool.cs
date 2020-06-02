using System;

namespace HanumanInstitute.OntraportApi.Converters
{
    /// <summary>
    /// Converts a "true" or "false" field into a boolean property.
    /// </summary>
    public class JsonConverterBool : JsonConverterBase<bool?>
    {
        public override string Format(bool? value) => 
            value.HasValue ? (value == true ? "true" : "false") : "";
    }
}
