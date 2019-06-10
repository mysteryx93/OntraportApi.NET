using System;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi.Converters
{
    /// <summary>
    /// Represents an Integer property.
    /// </summary>
    public class ApiPropertyInt : ApiProperty<int>
    {
        /// <summary>
        /// Initializes a new instance of the ApiPropertyInt class for specified ApiObject host and field key.
        /// </summary>
        /// <param name="host">The ApiObject containing the data.</param>
        /// <param name="key">The field key represented by this property.</param>
        public ApiPropertyInt(ApiObject host, string key) :
            base(host, key)
        { }
    }
}
