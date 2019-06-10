using System;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi.Converters
{
    /// <summary>
    /// Represents a DateTimeOffset field stored in Unix Epoch seconds format.
    /// </summary>
    public class ApiPropertyDateTime : ApiProperty<DateTimeOffset>
    {
        /// <summary>
        /// Initializes a new instance of the ApiPropertyDateTime class for specified ApiObject host and field key.
        /// </summary>
        /// <param name="host">The ApiObject containing the data.</param>
        /// <param name="key">The field key represented by this property.</param>
        public ApiPropertyDateTime(ApiObject host, string key) : 
            base(host, key, new JsonConverterDateTime())
        { }
    }
}
