using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Newtonsoft.Json.Linq;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Base class to provides Ontraport API support for custom objects.
    /// </summary>
    public abstract class OntraportBaseCustomObject<T> : OntraportBaseDelete<T>, IOntraportBaseCustomObject<T> 
        where T : ApiCustomObjectBase
    {
        public OntraportBaseCustomObject(OntraportHttpClient apiRequest, string endpointSingular, string endpointPlural, string primarySearchKey) :
            base(apiRequest, endpointSingular, endpointPlural, primarySearchKey)
        { }

        /// <summary>
        /// Looks for an existing object with a matching unique field and merges supplied data with existing data.
        /// </summary>
        /// <param name="values">The field values to set.</param>
        /// <returns>The updated ApiObject.</returns>
        public async Task<T> CreateOrMergeAsync(object values = null)
        {
            var query = new Dictionary<string, object>();

            var json = await ApiRequest.PostAsync<JObject>(
                $"{EndpointPlural}/saveorupdate", query.AddObject(values));
            return await OnParseCreateOrMergeAsync(json);
        }

        /// <summary>
        /// When overriden in a derived class, allows custom parsing of CreateOrMergeAsync response.
        /// </summary>
        /// <param name="json">The JSON data to parse.</param>
        /// <returns>A T or object derived from it.</returns>
        protected virtual async Task<T> OnParseCreateOrMergeAsync(JObject json) =>
            await CreateApiObjectAsync(json["data"]);

        /// <summary>
        /// Retrieves the custom fields data.
        /// </summary>
        /// <returns>A ResponseMetadata object.</returns>
        public async Task<ResponseMetadata> GetCustomFieldsAsync()
        {
            var query = new Dictionary<string, object>
            {
                { "format", "byId" }
            };

            var json = await ApiRequest.GetAsync<JObject>(
                $"{EndpointPlural}/meta", query);
            var jsonObj = json["data"].First.First;

            var customFieldRegex = new Regex("^f[0-9]{4}$");
            var result = new ResponseMetadata()
            {
                Fields = new Dictionary<string, ApiFieldMetadata>()
            };
            result.Name = jsonObj["name"].ToString();
            foreach (var item in jsonObj["fields"].Children().OfType<JProperty>())
            {
                var key = item.Name;
                if (customFieldRegex.Match(key).Success)
                {
                    var value = item.Children().First().ToObject<ApiFieldMetadata>();
                    result.Fields.Add(key, value);
                }
            }
            return result;
        }
    }
}
