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
    public class OntraportContacts : OntraportContacts<ApiContact>, IOntraportContacts
    {
        public OntraportContacts(IOntraportRequestHelper apiRequest) : base(apiRequest)
        { }
    }

    /// <summary>
    /// Provides Ontraport API support for Contact objects.
    /// Contact objects allow you to keep up-to-date records for all the contacts you are managing.
    /// Contacts can be associated with many other objects such as tasks, tags, rules, and sequences. You can access additional functionality 
    /// for tagging contacts and adding and removing contacts from sequences using the objects API with an objectID of 0.
    /// </summary>
    /// <typeparam name="T">A type deriving from ApiContact exposing additional custom fields.</typeparam>
    public class OntraportContacts<T> : OntraportBaseCustomObject<T>, IOntraportContacts<T>
        where T : ApiContact
    {
        public OntraportContacts(IOntraportRequestHelper apiRequest) : 
            base(apiRequest, "Contact", "Contacts", "email")
        { }

        protected override async Task<T> OnParseCreateOrMergeAsync(JObject json) =>
            await CreateApiObjectAsync(json["data"]["attrs"]);
    }
}
