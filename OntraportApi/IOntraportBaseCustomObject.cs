using System.Collections.Generic;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Base class to provides Ontraport API support for custom objects.
    /// </summary>
    public interface IOntraportBaseCustomObject<T>  : IOntraportBaseDelete<T>
        where T : ApiCustomObjectBase
    {
        /// <summary>
        /// Looks for an existing object with a matching unique field and merges supplied data with existing data.
        /// </summary>
        /// <param name="values">The field values to set.</param>
        /// <returns>The updated ApiObject.</returns>
        Task<T> CreateOrMergeAsync(object values = null);

        /// <summary>
        /// Retrieves the custom fields data.
        /// </summary>
        /// <returns>A ResponseMetadata object.</returns>
        Task<ResponseMetadata> GetCustomFieldsAsync();

        /// <summary>
        /// Adds one or more objects to one or more sequences.
        /// </summary>
        /// <param name="sequenceIds">A list of the sequence(s) to which objects should be added.</param>
        /// <param name="searchOptions">The search options.</param>
        Task AddToSequenceAsync(IEnumerable<int> sequenceIds, ApiSearchOptions searchOptions = null);

        /// <summary>
        /// Adds one or more tags to one or more objects.
        /// </summary>
        /// <param name="tagIds">A list of the IDs of the tag(s) which should be added to objects.</param>
        /// <param name="searchOptions">The search options.</param>
        Task AddTagAsync(IEnumerable<int> tagIds, ApiSearchOptions searchOptions = null);

        /// <summary>
        /// Adds one or more tags to one or more objects by the tag name. This endpoint will create the tag if it doesn't exist.
        /// </summary>
        /// <param name="tagNames">A list of the names of the tag(s) which should be added to objects.</param>
        /// <param name="searchOptions">The search options.</param>
        Task AddTagNamesAsync(IEnumerable<string> tagNames, ApiSearchOptions searchOptions = null);

        /// <summary>
        /// Adds one or more objects to one or more campaigns.
        /// </summary>
        /// <param name="campaignIds">A list of the campaign(s) to which objects should be added.</param>
        /// <param name="searchOptions">The search options.</param>
        Task AddToCampaignAsync(IEnumerable<int> campaignIds, ApiSearchOptions searchOptions = null);

        /// <summary>
        /// Removes one or more objects from one or more sequences.
        /// </summary>
        /// <param name="sequenceIds">A list of the sequence(s) from which objects should be removed.</param>
        /// <param name="searchOptions">The search options.</param>
        Task RemoveFromSequenceAsync(IEnumerable<int> sequenceIds, ApiSearchOptions searchOptions = null);

        /// <summary>
        /// Removes one or more tags from one or more objects.
        /// </summary>
        /// <param name="tagIds">A list of the IDs of the tag(s) which should be removed from objects.</param>
        /// <param name="searchOptions">The search options.</param>
        Task RemoveTagAsync(IEnumerable<int> tagIds, ApiSearchOptions searchOptions = null);

        /// <summary>
        /// Removes one or more tags from one or more objects by the tag name.
        /// </summary>
        /// <param name="tagNames">A list of the names of the tag(s) which should be removed from objects.</param>
        /// <param name="searchOptions">The search options.</param>
        Task RemoveTagNamesAsync(IEnumerable<string> tagNames, ApiSearchOptions searchOptions = null);

        /// <summary>
        /// Removes one or more objects from one or more campaigns.
        /// </summary>
        /// <param name="campaignIds">A list of the campaign(s) from which objects should be removed.</param>
        /// <param name="searchOptions">The search options.</param>
        Task RemoveFromCampaignAsync(IEnumerable<int> campaignIds, ApiSearchOptions searchOptions = null);

        /// <summary>
        /// Pauses rules, sequences, and sequence subscribers.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        Task PauseRuleOrSequenceAsync(ApiSearchOptions searchOptions = null);

        /// <summary>
        /// Unpauses rules, sequences, and sequence subscribers.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        Task UnpauseRuleOrSequenceAsync(ApiSearchOptions searchOptions = null);

    }
}
