using System;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi.Converters
{
    /// <summary>
    /// Represents a TimeSpan field stored in integer seconds format.
    /// </summary>
    public class ApiPropertyTimeSpan : ApiProperty<TimeSpan>
    {
        /// <summary>
        /// Initializes a new instance of the ApiPropertyTimeSpan class for specified ApiObject host and field key.
        /// </summary>
        /// <param name="host">The ApiObject containing the data.</param>
        /// <param name="key">The field key represented by this property.</param>
        public ApiPropertyTimeSpan(ApiObject host, string key) : 
            base(host, key, new JsonConverterTimeSpan())
        { }
    }
}
