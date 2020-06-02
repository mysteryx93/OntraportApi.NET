using System;
using HanumanInstitute.OntraportApi.Models;

namespace HanumanInstitute.OntraportApi.Converters
{
    /// <summary>
    /// Represents a ValueType property on an ApiObject. Changes are tracked and can be returned with ApiObject.GetChanges().
    /// </summary>
    /// <typeparam name="T">A value type that cannot be null.</typeparam>
    public class ApiProperty<T> : ApiPropertyBase<T, T?>
        where T : struct
    {
        /// <summary>
        /// Initializes a new instance of the ApiProperty class for specified ApiObject host and field key.
        /// </summary>
        /// <param name="host">The ApiObject containing the data.</param>
        /// <param name="key">The field key represented by this property.</param>
        public ApiProperty(ApiObject host, string key) :
            base(host, key, null)
        { }

        /// <summary>
        /// Initializes a new instance of the ApiProperty class for specified ApiObject host and field key.
        /// </summary>
        /// <param name="host">The ApiObject containing the data.</param>
        /// <param name="key">The field key represented by this property.</param>
        /// <param name="converter">A JsonConverter object to format and parse the data, if special formatting is needed.</param>
        public ApiProperty(ApiObject host, string key, JsonConverterBase<T?>? converter) :
            base(host, key, converter)
        { }
    }
}
