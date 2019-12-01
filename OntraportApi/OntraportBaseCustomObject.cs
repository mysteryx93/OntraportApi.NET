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
        private readonly IOntraportObjects _ontraObjects;
        private readonly int _objectTypeId;

        public OntraportBaseCustomObject(OntraportHttpClient apiRequest, IOntraportObjects ontraObjects,
            string endpointSingular, string endpointPlural, 
            int objectTypeId, string primarySearchKey) :
            base(apiRequest, endpointSingular, endpointPlural, primarySearchKey)
        {
            _ontraObjects = ontraObjects;
            _objectTypeId = objectTypeId;
        }

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
            return await CreateApiObjectAsync(json["data"]["attrs"] ?? json["data"]);
            // return await OnParseCreateOrMergeAsync(json);
        }

        /// <summary>
        /// When overriden in a derived class, allows custom parsing of CreateOrMergeAsync response.
        /// </summary>
        /// <param name="json">The JSON data to parse.</param>
        /// <returns>A T or object derived from it.</returns>
        //protected virtual async Task<T> OnParseCreateOrMergeAsync(JObject json) =>
        //    await CreateApiObjectAsync(json["data"]);

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

        /// <summary>
        /// Adds one or more objects to one or more sequences.
        /// </summary>
        /// <param name="sequenceIds">A list of the sequence(s) to which objects should be added.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task AddToSequenceAsync(IEnumerable<int> sequenceIds, ApiSearchOptions searchOptions = null) =>
            await _ontraObjects.AddToSequenceAsync((ApiObjectType)_objectTypeId, sequenceIds, searchOptions);

        /// <summary>
        /// Adds one or more tags to one or more objects.
        /// </summary>
        /// <param name="tagIds">A list of the IDs of the tag(s) which should be added to objects.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task AddTagAsync(IEnumerable<int> tagIds, ApiSearchOptions searchOptions = null) =>
            await _ontraObjects.AddTagAsync((ApiObjectType)_objectTypeId, tagIds, searchOptions);

        /// <summary>
        /// Adds one or more tags to one or more objects by the tag name. This endpoint will create the tag if it doesn't exist.
        /// </summary>
        /// <param name="tagNames">A list of the names of the tag(s) which should be added to objects.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task AddTagNamesAsync(IEnumerable<string> tagNames, ApiSearchOptions searchOptions = null) =>
            await _ontraObjects.AddTagNamesAsync((ApiObjectType)_objectTypeId, tagNames, searchOptions);

        /// <summary>
        /// Adds one or more objects to one or more campaigns.
        /// </summary>
        /// <param name="campaignIds">A list of the campaign(s) to which objects should be added.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task AddToCampaignAsync(IEnumerable<int> campaignIds, ApiSearchOptions searchOptions = null) =>
            await _ontraObjects.AddToCampaignAsync((ApiObjectType)_objectTypeId, campaignIds, searchOptions);

        /// <summary>
        /// Removes one or more objects from one or more sequences.
        /// </summary>
        /// <param name="sequenceIds">A list of the sequence(s) from which objects should be removed.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task RemoveFromSequenceAsync(IEnumerable<int> sequenceIds, ApiSearchOptions searchOptions = null) =>
            await _ontraObjects.RemoveFromSequenceAsync((ApiObjectType)_objectTypeId, sequenceIds, searchOptions);

        /// <summary>
        /// Removes one or more tags from one or more objects.
        /// </summary>
        /// <param name="tagIds">A list of the IDs of the tag(s) which should be removed from objects.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task RemoveTagAsync(IEnumerable<int> tagIds, ApiSearchOptions searchOptions = null) =>
            await _ontraObjects.RemoveTagAsync((ApiObjectType)_objectTypeId, tagIds, searchOptions);

        /// <summary>
        /// Removes one or more tags from one or more objects by the tag name.
        /// </summary>
        /// <param name="tagNames">A list of the names of the tag(s) which should be removed from objects.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task RemoveTagNamesAsync(IEnumerable<string> tagNames, ApiSearchOptions searchOptions = null) =>
            await _ontraObjects.RemoveTagNamesAsync((ApiObjectType)_objectTypeId, tagNames, searchOptions);

        /// <summary>
        /// Removes one or more objects from one or more campaigns.
        /// </summary>
        /// <param name="campaignIds">A list of the campaign(s) from which objects should be removed.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task RemoveFromCampaignAsync(IEnumerable<int> campaignIds, ApiSearchOptions searchOptions = null) =>
            await _ontraObjects.RemoveFromCampaignAsync((ApiObjectType)_objectTypeId, campaignIds, searchOptions);

        /// <summary>
        /// Pauses rules, sequences, and sequence subscribers.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        public async Task PauseRuleOrSequenceAsync(ApiSearchOptions searchOptions = null) =>
            await _ontraObjects.PauseRuleOrSequenceAsync((ApiObjectType)_objectTypeId, searchOptions);

        /// <summary>
        /// Unpauses rules, sequences, and sequence subscribers.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        public async Task UnpauseRuleOrSequenceAsync(ApiSearchOptions searchOptions = null) =>
            await _ontraObjects.UnpauseRuleOrSequenceAsync((ApiObjectType)_objectTypeId, searchOptions);
    }
}
