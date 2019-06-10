using System;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi.Converters
{
    /// <summary>
    /// Represents a Double property.
    /// </summary>
    public class ApiPropertyDouble : ApiProperty<double>
    {
        /// <summary>
        /// Initializes a new instance of the ApiPropertyDouble class for specified ApiObject host and field key.
        /// </summary>
        /// <param name="host">The ApiObject containing the data.</param>
        /// <param name="key">The field key represented by this property.</param>
        public ApiPropertyDouble(ApiObject host, string key) :
            base(host, key)
        { }
    }
}
