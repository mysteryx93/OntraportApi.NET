using System.Collections.Generic;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Base class to provides Ontraport API support for custom objects.
    /// </summary>
    public interface IOntraportBaseCustomObject<T> : IOntraportBaseDelete<T>
        where T : ApiCustomObjectBase
    {
        /// <summary>
        /// Looks for an existing object with a matching unique field and merges supplied data with existing data.
        /// </summary>
        /// <param name="values">The field values to set.</param>
        /// <returns>The updated ApiObject.</returns>
        Task<T> CreateOrMergeAsync(object? values = null);

        /// <summary>
        /// Retrieves the custom fields data.
        /// </summary>
        /// <returns>A ResponseMetadata object.</returns>
        Task<ResponseMetadata> GetCustomFieldsAsync();

        /// <summary>
        /// Adds an object to a sequence.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="sequenceId">The id of the sequence to which the object should be added.</param>
        Task AddToSequenceAsync(int id, int sequenceId);

        /// <summary>
        /// Adds an object to one or more sequences.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="sequenceIds">A list of the sequence(s) to which objects should be added.</param>
        Task AddToSequenceAsync(int id, IEnumerable<int> sequenceIds);

        /// <summary>
        /// Adds one or more objects to one or more sequences.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="sequenceIds">A list of the sequence(s) to which objects should be added.</param>
        Task AddToSequenceAsync(ApiSearchOptions searchOptions, IEnumerable<int> sequenceIds);

        /// <summary>
        /// Adds a tag to an object.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="tagId">The ID of the tag which should be added to the object.</param>
        Task AddTagAsync(int id, int tagId);

        /// <summary>
        /// Adds one or more tags to an object.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="tagIds">A list of the IDs of the tag(s) which should be added to objects.</param>
        Task AddTagAsync(int id, IEnumerable<int> tagIds);

        /// <summary>
        /// Adds one or more tags to one or more objects.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="tagIds">A list of the IDs of the tag(s) which should be added to objects.</param>
        Task AddTagAsync(ApiSearchOptions searchOptions, IEnumerable<int> tagIds);

        /// <summary>
        /// Adds a tag to an object by the tag name. This endpoint will create the tag if it doesn't exist.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="tagName">The name of the tag which should be added to the object.</param>
        Task AddTagNamesAsync(int id, string tagName);

        /// <summary>
        /// Adds one or more tags to an object by the tag name. This endpoint will create the tag if it doesn't exist.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="tagNames">A list of the names of the tag(s) which should be added to objects.</param>
        Task AddTagNamesAsync(int id, IEnumerable<string> tagNames);

        /// <summary>
        /// Adds one or more tags to one or more objects by the tag name. This endpoint will create the tag if it doesn't exist.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="tagNames">A list of the names of the tag(s) which should be added to objects.</param>
        Task AddTagNamesAsync(ApiSearchOptions searchOptions, IEnumerable<string> tagNames);

        /// <summary>
        /// Adds an object to a campaign.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="campaignId">The campaign to which the object should be added.</param>
        Task AddToCampaignAsync(int id, int campaignId);

        /// <summary>
        /// Adds an object to one or more campaigns.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="campaignIds">A list of the campaign(s) to which objects should be added.</param>
        Task AddToCampaignAsync(int id, IEnumerable<int> campaignIds);

        /// <summary>
        /// Adds one or more objects to one or more campaigns.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="campaignIds">A list of the campaign(s) to which objects should be added.</param>
        Task AddToCampaignAsync(ApiSearchOptions searchOptions, IEnumerable<int> campaignIds);

        /// <summary>
        /// Removes an object from a sequence.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="sequenceId">The sequence from which the object should be removed.</param>
        Task RemoveFromSequenceAsync(int id, int sequenceId);

        /// <summary>
        /// Removes an object from one or more sequences.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="sequenceIds">A list of the sequence(s) from which objects should be removed.</param>
        Task RemoveFromSequenceAsync(int id, IEnumerable<int> sequenceIds);

        /// <summary>
        /// Removes one or more objects from one or more sequences.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="sequenceIds">A list of the sequence(s) from which objects should be removed.</param>
        Task RemoveFromSequenceAsync(ApiSearchOptions searchOptions, IEnumerable<int> sequenceIds);

        /// <summary>
        /// Removes a tag from an object.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="tagId">The ID of the tag which should be removed from the object.</param>
        Task RemoveTagAsync(int id, int tagId);

        /// <summary>
        /// Removes one or more tags from an object.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="tagIds">A list of the IDs of the tag(s) which should be removed from objects.</param>
        Task RemoveTagAsync(int id, IEnumerable<int> tagIds);

        /// <summary>
        /// Removes one or more tags from one or more objects.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="tagIds">A list of the IDs of the tag(s) which should be removed from objects.</param>
        Task RemoveTagAsync(ApiSearchOptions searchOptions, IEnumerable<int> tagIds);

        /// <summary>
        /// Removes a tag from an object by the tag name.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="tagName">The name of the tag which should be removed from the object.</param>
        Task RemoveTagNamesAsync(int id, string tagName);

        /// <summary>
        /// Removes one or more tags from an object by the tag name.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="tagNames">A list of the names of the tag(s) which should be removed from objects.</param>
        Task RemoveTagNamesAsync(int id, IEnumerable<string> tagNames);

        /// <summary>
        /// Removes one or more tags from one or more objects by the tag name.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="tagNames">A list of the names of the tag(s) which should be removed from objects.</param>
        Task RemoveTagNamesAsync(ApiSearchOptions searchOptions, IEnumerable<string> tagNames);

        /// <summary>
        /// Removes an object from a campaign.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="campaignId">The campaign from which the object should be removed.</param>
        Task RemoveFromCampaignAsync(int id, int campaignId);

        /// <summary>
        /// Removes an object from one or more campaigns.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        /// <param name="campaignIds">A list of the campaign(s) from which objects should be removed.</param>
        Task RemoveFromCampaignAsync(int id, IEnumerable<int> campaignIds);

        /// <summary>
        /// Removes one or more objects from one or more campaigns.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="campaignIds">A list of the campaign(s) from which objects should be removed.</param>
        Task RemoveFromCampaignAsync(ApiSearchOptions searchOptions, IEnumerable<int> campaignIds);

        /// <summary>
        /// Pauses rules, sequences, and sequence subscribers.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        Task PauseRuleOrSequenceAsync(int id);

        /// <summary>
        /// Pauses rules, sequences, and sequence subscribers.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        Task PauseRuleOrSequenceAsync(ApiSearchOptions searchOptions);

        /// <summary>
        /// Unpauses rules, sequences, and sequence subscribers.
        /// </summary>
        /// <param name="id">The id of the object to affect.</param>
        Task UnpauseRuleOrSequenceAsync(int id);

        /// <summary>
        /// Unpauses rules, sequences, and sequence subscribers.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        Task UnpauseRuleOrSequenceAsync(ApiSearchOptions searchOptions);

    }
}
