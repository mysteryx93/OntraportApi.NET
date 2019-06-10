using System;
using EmergenceGuardian.OntraportApi.Models;
using Newtonsoft.Json.Serialization;

namespace EmergenceGuardian.OntraportApi.Converters
{
    /// <summary>
    /// Represents an enumeration stored as string.
    /// </summary>
    public class ApiPropertyStringEnum<T> : ApiProperty<T>
        where T : struct
    {
        /// <summary>
        /// Initializes a new instance of the ApiPropertyStringEnum class for specified ApiObject host and field key.
        /// </summary>
        /// <param name="host">The ApiObject containing the data.</param>
        /// <param name="key">The field key represented by this property.</param>
        /// <param name="lowerCase">Whether to format Enum values as lowercase.</param>
        public ApiPropertyStringEnum(ApiObject host, string key) : 
            base(host, key, new JsonConverterStringEnum<T>())
        { }
    }
}
