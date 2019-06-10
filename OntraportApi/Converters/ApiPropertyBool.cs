using System;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi.Converters
{
    /// <summary>
    /// Represents a boolean field stored as "true" or "false". ApiProperty of type bool would store as "True" or "False".
    /// </summary>
    public class ApiPropertyBool : ApiProperty<bool>
    {
        /// <summary>
        /// Initializes a new instance of the ApiPropertyBool class for specified ApiObject host and field key.
        /// </summary>
        /// <param name="host">The ApiObject containing the data.</param>
        /// <param name="key">The field key represented by this property.</param>
        public ApiPropertyBool(ApiObject host, string key) : 
            base(host, key, new JsonConverterBool())
        { }
    }
}
