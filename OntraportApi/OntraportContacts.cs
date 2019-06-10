using System;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Newtonsoft.Json.Linq;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for Contact objects.
    /// Contact objects allow you to keep up-to-date records for all the contacts you are managing.
    /// Contacts can be associated with many other objects such as tasks, tags, rules, and sequences. You can access additional functionality 
    /// for tagging contacts and adding and removing contacts from sequences using the objects API with an objectID of 0.
    /// </summary>
    public class OntraportContacts : OntraportBaseCustomObject<ApiContact>, IOntraportContacts
    {
        public OntraportContacts(IApiRequestHelper apiRequest) : 
            base(apiRequest, "Contact", "Contacts", "email")
        { }

        protected override async Task<ApiContact> OnParseCreateOrMergeAsync(JObject json) =>
            await CreateApiObjectAsync(json["data"]["attrs"]);
    }
}
