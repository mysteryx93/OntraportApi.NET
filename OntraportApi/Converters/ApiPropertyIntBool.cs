using System;
using HanumanInstitute.OntraportApi.Models;

namespace HanumanInstitute.OntraportApi.Converters
{
    /// <summary>
    /// Represents a boolean field stored as "1" or "0". ApiProperty of type bool would store as "True" or "False".
    /// </summary>
    public class ApiPropertyIntBool : ApiProperty<bool>
    {
        /// <summary>
        /// Initializes a new instance of the ApiPropertyIntBool class for specified ApiObject host and field key.
        /// </summary>
        /// <param name="host">The ApiObject containing the data.</param>
        /// <param name="key">The field key represented by this property.</param>
        public ApiPropertyIntBool(ApiObject host, string key) : 
            base(host, key, new JsonConverterIntBool()) { }
    }
}
