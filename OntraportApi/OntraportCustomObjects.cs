using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Newtonsoft.Json.Linq;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for CustomObject objects.
    /// This provides the list of custom objects and their IDs.
    /// To use those custom objects, refer to the classes specific to each object or use OntraportObjects with the ID obtained here.
    /// You can cast any integer to ApiObjectType such as (ApiObjectType)10000.
    /// </summary>
    public class OntraportCustomObjects : OntraportBaseRead<ApiCustomObject>, IOntraportCustomObjects
    {
        public OntraportCustomObjects(OntraportHttpClient apiRequest) :
            base(apiRequest, "CustomObject", "CustomObjects")
        { }

        /// <summary>
        /// Retrieves all the information for custom object by its plural name.
        /// </summary>
        /// <param name="pluralName">The plural name of the object.</param>
        /// <returns>The selected object.</returns>
        public async Task<ApiCustomObject> SelectAsync(string pluralName)
        {
            var result = await SelectAsync(new ApiSearchOptions().AddCondition("plural", "=", pluralName));
            return result.FirstOrDefault();
        }
    }
}
