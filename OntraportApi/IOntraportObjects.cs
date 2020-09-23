using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Provides common Ontraport API support for all object types.
    /// The objects API provides powerful and versatile functionality for a wide variety of our objects. Although we provide many endpoints 
    /// for specific object types, using generic object endpoints with an object type ID provides an interface for most objects.
    /// </summary>
    public interface IOntraportObjects
    {
        /// <summary>
        /// This endpoint will add a new object to your database. It can be used for any object type as long as the correct parameters are supplied. This endpoint allows duplication; if you want to avoid duplicates you should merge instead.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="values">Fields to set on the object.</param>
        /// <returns>The created object.</returns>
        Task<Dictionary<string, string>> CreateAsync(ApiObjectType objectType, object? values = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Looks for an existing object with a matching unique field and merges supplied data with existing data. If no unique field is supplied or if no existing object has a matching unique field, a new object will be created.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="ignoreBlanks">Whether or not blank strings should be ignored upon update. Defaults to false: blank strings passed to this endpoint will overwrite existing value.</param>
        /// <param name="values">Additional properties to set on the object.</param>
        /// <returns>The created or updated object.</returns>
        Task<Dictionary<string, string>> CreateOrMergeAsync(ApiObjectType objectType, bool ignoreBlanks = false, object? values = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create new fields and sections in an object record. If the section name doesn't exist, a new one will be created with that name.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="sectionName">The name of the section.</param>
        /// <param name="fields">An array of 3 columns containing fields containing arrays of field objects.</param>
        /// <returns>A list of field operations in a successful or error state.</returns>
        Task<ResponseSuccessList> CreateFieldsAsync(ApiObjectType objectType, string sectionName, IEnumerable<IEnumerable<ApiFieldEditor>>? fields = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all the information for an existing object of the specified object type.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="objectId">The ID of the specific object.</param>
        /// <returns>The selected object.</returns>
        Task<Dictionary<string, string>?> SelectAsync(ApiObjectType objectType, int objectId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a collection of objects based on a set of parameters.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="sortOptions">The sort options.</param>
        /// <param name="externs">If you have a relationship between your object and another object, you may want to include the data from a related field in your results. Each external field is listed in the format {object}//{field}.</param>
        /// <param name="listFields">A string array of the fields which should be returned in your results.</param>
        /// <returns>A list of objects matching the query.</returns>
        Task<List<Dictionary<string, string>>> SelectAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions = null, ApiSortOptions? sortOptions = null, IEnumerable<string>? externs = null, IEnumerable<string>? listFields = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the number of objects having a specified tag.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="tagId">The ID of the tag you would like to filter your objects by. Either TagId or TagName is required.</param>
        /// <param name="tagName">The name of the tag you would like to filter your objects by. Either TagId or TagName is required.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="sortOptions">The sort options.</param>
        /// <param name="externs">If you have a relationship between your object and another object, you may want to include the data from a related field in your results. Each external field is listed in the format {object}//{field}.</param>
        /// <param name="listFields">A string array of the fields which should be returned in your results.</param>
        /// <returns>The number of objects matching the query.</returns>
        Task<int> GetCountByTagAsync(ApiObjectType objectType, int? tagId = null, string? tagName = null, ApiSearchOptions? searchOptions = null, ApiSortOptions? sortOptions = null, IEnumerable<string>? externs = null, IEnumerable<string>? listFields = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a collection of objects having a specified tag.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="tagId">The ID of the tag you would like to filter your objects by. Either TagId or TagName is required.</param>
        /// <param name="tagName">The name of the tag you would like to filter your objects by. Either TagId or TagName is required.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="sortOptions">The sort options.</param>
        /// <param name="externs">If you have a relationship between your object and another object, you may want to include the data from a related field in your results. Each external field is listed in the format {object}//{field}.</param>
        /// <param name="listFields">A string array of the fields which should be returned in your results.</param>
        /// <returns>A list of objects matching the query.</returns>
        Task<List<Dictionary<string, string>>> SelectByTagAsync(ApiObjectType objectType, int? tagId = null, string? tagName = null, ApiSearchOptions? searchOptions = null, ApiSortOptions? sortOptions = null, IEnumerable<string>? externs = null, IEnumerable<string>? listFields = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the first ID of contact object or custom object by their email fields.
        /// </summary>
        /// <param name="objectType">The object type id.</param>
        /// <param name="email">The email of the object you would like to retrieve.</param>
        /// <returns>The object ID.</returns>
        Task<int?> GetObjectIdByEmailAsync(ApiObjectType objectType, string email, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all IDs of contact objects or custom objects by their email fields.
        /// </summary>
        /// <param name="objectType">The object type id.</param>
        /// <param name="email">The email of the object you would like to retrieve.</param>
        /// <param name="all">A binary integer flag indicating whether you would like to retrieve an array of all IDs for objects with a matching email. If false, only the first object will be returned.</param>
        /// <returns>A list of object IDs.</returns>
        Task<IEnumerable<int>> GetObjectIdByEmailAllAsync(ApiObjectType objectType, string email, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the field meta data for the specified object type.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="indexByName">True to index by name, false to index by id.</param>
        /// <returns>A JsonElement providing raw access to the JSON data.</returns>
        Task<Dictionary<int, ResponseMetadata>> GetAllMetadataAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the field meta data for the specified object type.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <returns>A JsonElement providing raw access to the JSON data.</returns>
        Task<ResponseMetadata?> GetMetadataAsync(ApiObjectType objectType, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves information about a collection of objects, such as the number of objects that match the given criteria.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <returns>A ResponseCollectionInfo object.</returns>
        Task<ResponseCollectionInfo?> GetCollectionInfoAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve information about the fields an object has within a section.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="sectionName">The name of the section.</param>
        /// <returns>A list of fields in that section.</returns>
        Task<ResponseSectionFields?> SelectFieldsBySectionAsync(ApiObjectType objectType, string sectionName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve information about all fields and sections an object has.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <returns>A dictionary of sections each containing their fields.</returns>
        Task<Dictionary<int, ResponseSectionFields>> SelectAllFieldsAsync(ApiObjectType objectType, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve information about a field an object has.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <returns>A object containing the field information.</returns>
        Task<ApiFieldInfo?> SelectFieldByNameAsync(ApiObjectType objectType, string fieldName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing object with given data.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="objectId">The ID of the object to update.</param>
        /// <param name="values">Fields to set on the object.</param>
        /// <returns>A dictionary of updated fields.</returns>
        Task<Dictionary<string, string>> UpdateAsync(ApiObjectType objectType, int objectId, object? values = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update fields and sections in an object record. The section MUST exist in order to update it. Any fields that do not already exist 
        /// will be created. Fields can be matched either by their alias (displayed name), or by the actual name of the field e.g. f1234.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="sectionName">The name of the section.</param>
        /// <param name="fields">An array of columns containing fields containing arrays of Field objects.</param>
        /// <param name="sectionDescription">A description for the new Section.</param>
        /// <returns></returns>
        Task<ResponseSuccessList> UpdateFieldsAsync(ApiObjectType objectType, string sectionName, IEnumerable<IEnumerable<ApiFieldEditor>> fields, string? sectionDescription = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an existing object of the specified object type.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="objectId">The ID of the specific object.</param>
        Task DeleteAsync(ApiObjectType objectType, int objectId, CancellationToken cancellationToken = default);

        /// <summary>
        /// This endpoint deletes a collection of objects. Use caution with this endpoint.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <returns>A list of objects matching the query.</returns>
        Task DeleteMultipleAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a section in an object record. If attempting to delete a section, the section MUST be empty.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="sectionName">The name of the section.</param>
        Task DeleteSectionAsync(ApiObjectType objectType, string sectionName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a field in an object record.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="fieldName">The name of the field e.g f1234.</param>
        Task DeleteFieldAsync(ApiObjectType objectType, string fieldName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds one or more objects to one or more sequences.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="sequenceIds">A list of the sequence(s) to which objects should be added.</param>
        Task AddToSequenceAsync(ApiObjectType objectType, ApiSearchOptions searchOptions, IEnumerable<int> sequenceIds, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds one or more tags to one or more objects.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="tagIds">A list of the IDs of the tag(s) which should be added to objects.</param>
        Task AddTagAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions, IEnumerable<int> tagIds, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds one or more tags to one or more objects by the tag name. This endpoint will create the tag if it doesn't exist.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="tagNames">A list of the names of the tag(s) which should be added to objects.</param>
        Task AddTagNamesAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions, IEnumerable<string> tagNames, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds one or more objects to one or more campaigns.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="campaignIds">A list of the campaign(s) to which objects should be added.</param>
        Task AddToCampaignAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions, IEnumerable<int> campaignIds, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes one or more objects from one or more sequences.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="sequenceIds">A list of the sequence(s) from which objects should be removed.</param>
        Task RemoveFromSequenceAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions, IEnumerable<int> sequenceIds, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes one or more tags from one or more objects.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="tagIds">A list of the IDs of the tag(s) which should be removed from objects.</param>
        Task RemoveTagAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions, IEnumerable<int> tagIds, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes one or more tags from one or more objects by the tag name.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="tagNames">A list of the names of the tag(s) which should be removed from objects.</param>
        Task RemoveTagNamesAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions, IEnumerable<string> tagNames, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes one or more objects from one or more campaigns.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="campaignIds">A list of the campaign(s) from which objects should be removed.</param>
        Task RemoveFromCampaignAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions, IEnumerable<int> campaignIds, CancellationToken cancellationToken = default);

        /// <summary>
        /// Pauses rules, sequences, and sequence subscribers.
        /// </summary>
        /// <param name="objectType">The object type: Rule, Sequence or Sequence Subscriber.</param>
        /// <param name="searchOptions">The search options.</param>
        Task PauseRuleOrSequenceAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions, CancellationToken cancellationToken = default);

        /// <summary>
        /// Unpauses rules, sequences, and sequence subscribers.
        /// </summary>
        /// <param name="objectType">The object type: Rule, Sequence or Sequence Subscriber.</param>
        /// <param name="searchOptions">The search options.</param>
        Task UnpauseRuleOrSequenceAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions, CancellationToken cancellationToken = default);
    }
}
