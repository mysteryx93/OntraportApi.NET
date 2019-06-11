using System;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi.Converters
{
    /// <summary>
    /// Represents a String property on an ApiObject. Changes are tracked and can be returned with ApiObject.GetChanges().
    /// </summary>
    public class ApiPropertyString : ApiPropertyBase<string, string>
    {
        /// <summary>
        /// Initializes a new instance of the ApiPropertyString class for specified ApiObject host and field key.
        /// </summary>
        /// <param name="host">The ApiObject containing the data.</param>
        /// <param name="key">The field key represented by this property.</param>
        public ApiPropertyString(ApiObject host, string key) :
            base(host, key)
        { }

    }
}
