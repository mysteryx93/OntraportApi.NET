using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;
using Newtonsoft.Json.Linq;

namespace HanumanInstitute.OntraportApi
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
            int objectTypeId, string? primarySearchKey) :
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
        public async Task<T> CreateOrMergeAsync(object? values = null)
        {
            var query = new Dictionary<string, object?>();

            var json = await ApiRequest.PostAsync<JObject>(
                $"{EndpointPlural}/saveorupdate", query.AddObject(values)).ConfigureAwait(false);
            var data = JsonData(json);
            return await CreateApiObjectAsync(data["attrs"] ?? data).ConfigureAwait(false);
            // return await OnParseCreateOrMergeAsync(json);
        }

        /// <summary>
        /// Retrieves the custom fields data.
        /// </summary>
        /// <returns>A ResponseMetadata object.</returns>
        public async Task<ResponseMetadata> GetCustomFieldsAsync()
        {
            var query = new Dictionary<string, object?>
            {
                { "format", "byId" }
            };

            var json = await ApiRequest.GetAsync<JObject>(
                $"{EndpointPlural}/meta", query).ConfigureAwait(false);
            var jsonObj = JsonData(json).First?.First;
            if (jsonObj == null)
            {
                throw new NullReferenceException(Properties.Resources.ResponseDataNull);
            }

            var customFieldRegex = new Regex("^f[0-9]{4}$");
            var result = new ResponseMetadata()
            {
                Name = jsonObj["name"]?.ToString() ?? string.Empty
            };
            var childs = jsonObj["fields"]?.Children().OfType<JProperty>();
            if (childs != null)
            {
                foreach (var item in childs)
                {
                    var key = item.Name;
                    if (customFieldRegex.Match(key).Success)
                    {
                        var value = item.Children().First().ToObject<ApiFieldMetadata>() ?? new ApiFieldMetadata();
                        result.Fields.Add(key, value);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Adds an object to a sequence.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="sequenceId">The id of the sequence to which the object should be added.</param>
        public async Task AddToSequenceAsync(int id, int sequenceId) =>
            await _ontraObjects.AddToSequenceAsync((ApiObjectType)_objectTypeId, new ApiSearchOptions(id), new[] { sequenceId }).ConfigureAwait(false);

        /// <summary>
        /// Adds an object to one or more sequences.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="sequenceIds">A list of the sequence(s) to which objects should be added.</param>
        public async Task AddToSequenceAsync(int id, IEnumerable<int> sequenceIds) =>
            await _ontraObjects.AddToSequenceAsync((ApiObjectType)_objectTypeId, new ApiSearchOptions(id), sequenceIds).ConfigureAwait(false);

        /// <summary>
        /// Adds one or more objects to one or more sequences.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="sequenceIds">A list of the sequence(s) to which objects should be added.</param>
        public async Task AddToSequenceAsync(ApiSearchOptions searchOptions, IEnumerable<int> sequenceIds) =>
            await _ontraObjects.AddToSequenceAsync((ApiObjectType)_objectTypeId, searchOptions, sequenceIds).ConfigureAwait(false);

        /// <summary>
        /// Adds a tag to an object.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="tagId">The ID of the tag which should be added to the object.</param>
        public async Task AddTagAsync(int id, int tagId) =>
            await _ontraObjects.AddTagAsync((ApiObjectType)_objectTypeId, new ApiSearchOptions(id), new[] { tagId }).ConfigureAwait(false);

        /// <summary>
        /// Adds one or more tags to an object.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="tagIds">A list of the IDs of the tag(s) which should be added to objects.</param>
        public async Task AddTagAsync(int id, IEnumerable<int> tagIds) =>
            await _ontraObjects.AddTagAsync((ApiObjectType)_objectTypeId, new ApiSearchOptions(id), tagIds).ConfigureAwait(false);

        /// <summary>
        /// Adds one or more tags to one or more objects.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="tagIds">A list of the IDs of the tag(s) which should be added to objects.</param>
        public async Task AddTagAsync(ApiSearchOptions searchOptions, IEnumerable<int> tagIds) =>
            await _ontraObjects.AddTagAsync((ApiObjectType)_objectTypeId, searchOptions, tagIds).ConfigureAwait(false);

        /// <summary>
        /// Adds a tag to an object by the tag name. This endpoint will create the tag if it doesn't exist.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="tagName">The name of the tag which should be added to the object.</param>
        public async Task AddTagNamesAsync(int id, string tagName) =>
            await _ontraObjects.AddTagNamesAsync((ApiObjectType)_objectTypeId, new ApiSearchOptions(id), new[] { tagName }).ConfigureAwait(false);

        /// <summary>
        /// Adds one or more tags to an object by the tag name. This endpoint will create the tag if it doesn't exist.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="tagNames">A list of the names of the tag(s) which should be added to objects.</param>
        public async Task AddTagNamesAsync(int id, IEnumerable<string> tagNames) =>
            await _ontraObjects.AddTagNamesAsync((ApiObjectType)_objectTypeId, new ApiSearchOptions(id), tagNames).ConfigureAwait(false);

        /// <summary>
        /// Adds one or more tags to one or more objects by the tag name. This endpoint will create the tag if it doesn't exist.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="tagNames">A list of the names of the tag(s) which should be added to objects.</param>
        public async Task AddTagNamesAsync(ApiSearchOptions searchOptions, IEnumerable<string> tagNames) =>
            await _ontraObjects.AddTagNamesAsync((ApiObjectType)_objectTypeId, searchOptions, tagNames).ConfigureAwait(false);

        /// <summary>
        /// Adds an object to a campaign.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="campaignId">The campaign to which the object should be added.</param>
        public async Task AddToCampaignAsync(int id, int campaignId) =>
            await _ontraObjects.AddToCampaignAsync((ApiObjectType)_objectTypeId, new ApiSearchOptions(id), new[] { campaignId }).ConfigureAwait(false);

        /// <summary>
        /// Adds an object to one or more campaigns.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="campaignIds">A list of the campaign(s) to which objects should be added.</param>
        public async Task AddToCampaignAsync(int id, IEnumerable<int> campaignIds) =>
            await _ontraObjects.AddToCampaignAsync((ApiObjectType)_objectTypeId, new ApiSearchOptions(id), campaignIds).ConfigureAwait(false);

        /// <summary>
        /// Adds one or more objects to one or more campaigns.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="campaignIds">A list of the campaign(s) to which objects should be added.</param>
        public async Task AddToCampaignAsync(ApiSearchOptions searchOptions, IEnumerable<int> campaignIds) =>
            await _ontraObjects.AddToCampaignAsync((ApiObjectType)_objectTypeId, searchOptions, campaignIds).ConfigureAwait(false);

        /// <summary>
        /// Removes an object from a sequence.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="sequenceId">The sequence from which the object should be removed.</param>
        public async Task RemoveFromSequenceAsync(int id, int sequenceId) =>
            await _ontraObjects.RemoveFromSequenceAsync((ApiObjectType)_objectTypeId, new ApiSearchOptions(id), new[] { sequenceId }).ConfigureAwait(false);

        /// <summary>
        /// Removes an objects from one or more sequences.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="sequenceIds">A list of the sequence(s) from which objects should be removed.</param>
        public async Task RemoveFromSequenceAsync(int id, IEnumerable<int> sequenceIds) =>
            await _ontraObjects.RemoveFromSequenceAsync((ApiObjectType)_objectTypeId, new ApiSearchOptions(id), sequenceIds).ConfigureAwait(false);

        /// <summary>
        /// Removes one or more objects from one or more sequences.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="sequenceIds">A list of the sequence(s) from which objects should be removed.</param>
        public async Task RemoveFromSequenceAsync(ApiSearchOptions searchOptions, IEnumerable<int> sequenceIds) =>
            await _ontraObjects.RemoveFromSequenceAsync((ApiObjectType)_objectTypeId, searchOptions, sequenceIds).ConfigureAwait(false);

        /// <summary>
        /// Removes a tag from an object.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="tagId">The ID of the tag which should be removed from the object.</param>
        public async Task RemoveTagAsync(int id, int tagId) =>
            await _ontraObjects.RemoveTagAsync((ApiObjectType)_objectTypeId, new ApiSearchOptions(id), new[] { tagId }).ConfigureAwait(false);

        /// <summary>
        /// Removes one or more tags from an object.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="tagIds">A list of the IDs of the tag(s) which should be removed from objects.</param>
        public async Task RemoveTagAsync(int id, IEnumerable<int> tagIds) =>
            await _ontraObjects.RemoveTagAsync((ApiObjectType)_objectTypeId, new ApiSearchOptions(id), tagIds).ConfigureAwait(false);

        /// <summary>
        /// Removes one or more tags from one or more objects.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="tagIds">A list of the IDs of the tag(s) which should be removed from objects.</param>
        public async Task RemoveTagAsync(ApiSearchOptions searchOptions, IEnumerable<int> tagIds) =>
            await _ontraObjects.RemoveTagAsync((ApiObjectType)_objectTypeId, searchOptions, tagIds).ConfigureAwait(false);

        /// <summary>
        /// Removes a tag from an object by the tag name.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="tagName">The name of the tag which should be removed from the object.</param>
        public async Task RemoveTagNamesAsync(int id, string tagName) =>
            await _ontraObjects.RemoveTagNamesAsync((ApiObjectType)_objectTypeId, new ApiSearchOptions(id), new[] { tagName }).ConfigureAwait(false);

        /// <summary>
        /// Removes one or more tags from an object by the tag name.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="tagNames">A list of the names of the tag(s) which should be removed from objects.</param>
        public async Task RemoveTagNamesAsync(int id, IEnumerable<string> tagNames) =>
            await _ontraObjects.RemoveTagNamesAsync((ApiObjectType)_objectTypeId, new ApiSearchOptions(id), tagNames).ConfigureAwait(false);

        /// <summary>
        /// Removes one or more tags from one or more objects by the tag name.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="tagNames">A list of the names of the tag(s) which should be removed from objects.</param>
        public async Task RemoveTagNamesAsync(ApiSearchOptions searchOptions, IEnumerable<string> tagNames) =>
            await _ontraObjects.RemoveTagNamesAsync((ApiObjectType)_objectTypeId, searchOptions, tagNames).ConfigureAwait(false);

        /// <summary>
        /// Removes an object from a campaign.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="campaignId">The campaign from which the object should be removed.</param>
        public async Task RemoveFromCampaignAsync(int id, int campaignId) =>
            await _ontraObjects.RemoveFromCampaignAsync((ApiObjectType)_objectTypeId, new ApiSearchOptions(id), new[] { campaignId }).ConfigureAwait(false);

        /// <summary>
        /// Removes an object from one or more campaigns.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="campaignIds">A list of the campaign(s) from which objects should be removed.</param>
        public async Task RemoveFromCampaignAsync(int id, IEnumerable<int> campaignIds) =>
            await _ontraObjects.RemoveFromCampaignAsync((ApiObjectType)_objectTypeId, new ApiSearchOptions(id), campaignIds).ConfigureAwait(false);

        /// <summary>
        /// Removes one or more objects from one or more campaigns.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="campaignIds">A list of the campaign(s) from which objects should be removed.</param>
        public async Task RemoveFromCampaignAsync(ApiSearchOptions searchOptions, IEnumerable<int> campaignIds) =>
            await _ontraObjects.RemoveFromCampaignAsync((ApiObjectType)_objectTypeId, searchOptions, campaignIds).ConfigureAwait(false);

        /// <summary>
        /// Pauses rules, sequences, and sequence subscribers.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        public async Task PauseRuleOrSequenceAsync(int id) =>
            await _ontraObjects.PauseRuleOrSequenceAsync((ApiObjectType)_objectTypeId, new ApiSearchOptions(id)).ConfigureAwait(false);

        /// <summary>
        /// Pauses rules, sequences, and sequence subscribers.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        public async Task PauseRuleOrSequenceAsync(ApiSearchOptions searchOptions) =>
            await _ontraObjects.PauseRuleOrSequenceAsync((ApiObjectType)_objectTypeId, searchOptions).ConfigureAwait(false);

        /// <summary>
        /// Unpauses rules, sequences, and sequence subscribers.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        public async Task UnpauseRuleOrSequenceAsync(int id) =>
            await _ontraObjects.UnpauseRuleOrSequenceAsync((ApiObjectType)_objectTypeId, new ApiSearchOptions(id)).ConfigureAwait(false);

        /// <summary>
        /// Unpauses rules, sequences, and sequence subscribers.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        public async Task UnpauseRuleOrSequenceAsync(ApiSearchOptions searchOptions) =>
            await _ontraObjects.UnpauseRuleOrSequenceAsync((ApiObjectType)_objectTypeId, searchOptions).ConfigureAwait(false);
    }
}
