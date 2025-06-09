using System.Text.Json;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Provides common Ontraport API support for all object types.
    /// The objects API provides powerful and versatile functionality for a wide variety of our objects. Although we provide many endpoints 
    /// for specific object types, using generic object endpoints with an object type ID provides an interface for most objects.
    /// </summary>
    public class OntraportObjects : IOntraportObjects
    {
        private readonly OntraportHttpClient _apiRequest;

        public OntraportObjects(OntraportHttpClient apiRequest)
        {
            _apiRequest = apiRequest;
        }

        /// <summary>
        /// This endpoint will add a new object to your database. It can be used for any object type as long as the correct parameters are supplied. This endpoint allows duplication; if you want to avoid duplicates you should merge instead.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="values">Fields to set on the object.</param>
        /// <returns>The created object.</returns>
        public async Task<Dictionary<string, string>> CreateAsync(ApiObjectType objectType, object? values = null, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType }
            };

            return await _apiRequest.PostAsync<Dictionary<string, string>>(
                "objects", query.AddObject(values), true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Looks for an existing object with a matching unique field and merges supplied data with existing data. If no unique field is supplied or if no existing object has a matching unique field, a new object will be created.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="ignoreBlanks">Whether or not blank strings should be ignored upon update. Defaults to false: blank strings passed to this endpoint will overwrite existing value.</param>
        /// <param name="values">Additional properties to set on the object.</param>
        /// <returns>The created or updated object.</returns>
        public async Task<Dictionary<string, string>> CreateOrMergeAsync(ApiObjectType objectType, bool ignoreBlanks = false, object? values = null, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "ignore_blanks", ignoreBlanks }
            };

            var json = await _apiRequest.PostJsonAsync(
                "objects/saveorupdate", query.AddObject(values), true, cancellationToken).ConfigureAwait(false);
            return await json.RunAndCatchAsync(x => x.JsonData().JsonChild("attrs").ToObject<Dictionary<string, string>>()).ConfigureAwait(false);
        }

        /// <summary>
        /// Create new fields and sections in an object record. If the section name doesn't exist, a new one will be created with that name.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="sectionName">The name of the section.</param>
        /// <param name="fields">An array of 3 columns containing fields containing arrays of field objects.</param>
        /// <returns>A list of field operations in a successful or error state.</returns>
        public async Task<ResponseSuccessList> CreateFieldsAsync(ApiObjectType objectType, string sectionName, IEnumerable<IEnumerable<ApiFieldEditor>>? fields = null, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "name", sectionName},
                { "fields", fields }
            };

            var json = await _apiRequest.PostJsonAsync(
                "objects/fieldeditor", query, true, cancellationToken).ConfigureAwait(false);
            return await json.RunAndCatchAsync(x => new ResponseSuccessList(x)).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves all the information for an existing object of the specified object type.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="objectId">The ID of the specific object.</param>
        /// <returns>The selected object.</returns>
        public async Task<Dictionary<string, string>?> SelectAsync(ApiObjectType objectType, long objectId, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "id", objectId }
            };

            return await _apiRequest.GetAsync<Dictionary<string, string>>(
                "object", query, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a collection of objects based on a set of parameters.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="sortOptions">The sort options.</param>
        /// <param name="externs">If you have a relationship between your object and another object, you may want to include the data from a related field in your results. Each external field is listed in the format {object}//{field}.</param>
        /// <param name="listFields">A string array of the fields which should be returned in your results.</param>
        /// <returns>A list of objects matching the query.</returns>
        public async Task<List<Dictionary<string, string>>> SelectAsync(ApiObjectType objectType,
            ApiSearchOptions? searchOptions = null, ApiSortOptions? sortOptions = null,
            IEnumerable<string>? externs = null, IEnumerable<string>? listFields = null, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType }
            }
                .AddSearchOptions(searchOptions, null)
                .AddSortOptions(sortOptions, null)
                .AddFields(externs, listFields, null);

            return await _apiRequest.GetAsync<List<Dictionary<string, string>>>(
                "objects", query, true, cancellationToken).ConfigureAwait(false)
                ?? new List<Dictionary<string, string>>();
        }

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
        public async Task<int> GetCountByTagAsync(ApiObjectType objectType,
            long? tagId = null, string? tagName = null,
            ApiSearchOptions? searchOptions = null, ApiSortOptions? sortOptions = null,
            IEnumerable<string>? externs = null, IEnumerable<string>? listFields = null, CancellationToken cancellationToken = default)
        {
            var json = await SelectByTagAsync(
                objectType, tagId, tagName, searchOptions, sortOptions, externs, listFields, true, cancellationToken).ConfigureAwait(false);
            return await json.RunStructAndCatchAsync(x => {
                var count = x.JsonData().JsonChild("count");
                return count.GetString().Convert<int>();
            }).ConfigureAwait(false);
        }

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
        public async Task<List<Dictionary<string, string>>> SelectByTagAsync(ApiObjectType objectType,
            long? tagId = null, string? tagName = null,
            ApiSearchOptions? searchOptions = null, ApiSortOptions? sortOptions = null,
            IEnumerable<string>? externs = null, IEnumerable<string>? listFields = null, CancellationToken cancellationToken = default)
        {
            var json = await SelectByTagAsync(
                objectType, tagId, tagName, searchOptions, sortOptions, externs, listFields, false, cancellationToken).ConfigureAwait(false);
            return await json.RunAndCatchAsync(x => x.JsonData().ToObject<List<Dictionary<string, string>>>()).ConfigureAwait(false)
                ?? new List<Dictionary<string, string>>();
        }

        private async Task<JsonElement?> SelectByTagAsync(ApiObjectType objectType,
            long? tagId = null, string? tagName = null,
            ApiSearchOptions? searchOptions = null, ApiSortOptions? sortOptions = null,
            IEnumerable<string>? externs = null, IEnumerable<string>? listFields = null, bool count = false, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { tagId.HasValue ? "tag_id" : "tag_name", (object?)tagId ?? tagName },
                { "count", count ? "true" : "false" },
            }
                .AddSearchOptions(searchOptions, null)
                .AddSortOptions(sortOptions, null)
                .AddFields(externs, listFields, null);

            return await _apiRequest.GetJsonAsync(
                "objects/tag", query, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves the first ID of contact object or custom object by their email fields.
        /// </summary>
        /// <param name="objectType">The object type id.</param>
        /// <param name="email">The email of the object you would like to retrieve.</param>
        /// <returns>The object ID.</returns>
        public async Task<long?> GetObjectIdByEmailAsync(ApiObjectType objectType, string email, CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmpty(email);

            var json = await GetObjectIdByEmailAsync(
                objectType, email, false, cancellationToken).ConfigureAwait(false);
            return await json.RunStructAndCatchAsync(x => {
                var id = x.JsonData().JsonChild("id");
                return id.GetString().Convert<int?>();
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves all IDs of contact objects or custom objects by their email fields.
        /// </summary>
        /// <param name="objectType">The object type id.</param>
        /// <param name="email">The email of the object you would like to retrieve.</param>
        /// <param name="all">A binary integer flag indicating whether you would like to retrieve an array of all IDs for objects with a matching email. If false, only the first object will be returned.</param>
        /// <returns>A list of object IDs.</returns>
        public async Task<IEnumerable<long>> GetObjectIdByEmailAllAsync(ApiObjectType objectType, string email, CancellationToken cancellationToken = default)
        {
            Check.NotNull(email);

            var json = await GetObjectIdByEmailAsync(
                objectType, email, true, cancellationToken).ConfigureAwait(false);
            return await json.RunAndCatchAsync(x => x.JsonData().JsonChild("ids").EnumerateArray().Select(x => x.GetString().Convert<long>())).ConfigureAwait(false)
                ?? [];
        }

        private async Task<JsonElement?> GetObjectIdByEmailAsync(ApiObjectType objectType, string email, bool all = false, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "email", email },
                { "all", all ? 1 : 0 }
            };

            return await _apiRequest.GetJsonAsync(
                "object/getByEmail", query, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves the field meta data for the specified object type.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="indexByName">True to index by name, false to index by id.</param>
        /// <returns>A JsonElement providing raw access to the JSON data.</returns>
        public async Task<Dictionary<string, ResponseMetadata>> GetAllMetadataAsync(CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "format", "byId" }
            };

            var result = await _apiRequest.GetAsync<Dictionary<string, ResponseMetadata>>(
                "objects/meta", query, false, cancellationToken).ConfigureAwait(false);
            return result!;
        }

        /// <summary>
        /// Retrieves the field meta data for the specified object type.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <returns>A JsonElement providing raw access to the JSON data.</returns>
        public async Task<ResponseMetadata?> GetMetadataAsync(ApiObjectType objectType, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "format", "byId" }
            };

            var json = await _apiRequest.GetJsonAsync(
                "objects/meta", query, true, cancellationToken).ConfigureAwait(false);
            return await json.RunAndCatchAsync(x => x.JsonData().JsonFirst().ToObject<ResponseMetadata>()).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information about a collection of objects, such as the number of objects that match the given criteria.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <returns>A ResponseCollectionInfo object.</returns>
        public async Task<ResponseCollectionInfo?> GetCollectionInfoAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions = null, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
            }
                .AddSearchOptions(searchOptions, null);

            return await _apiRequest.GetAsync<ResponseCollectionInfo>(
                "objects/getInfo", query, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve information about the fields an object has within a section.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="sectionName">The name of the section.</param>
        /// <returns>A list of fields in that section.</returns>
        public async Task<ResponseSectionFields?> SelectFieldsBySectionAsync(ApiObjectType objectType, string sectionName, CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmpty(sectionName);

            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "section", sectionName }
            };

            return await _apiRequest.GetAsync<ResponseSectionFields>(
                "objects/fieldeditor", query, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve information about all fields and sections an object has.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <returns>A dictionary of sections each containing their fields.</returns>
        public async Task<Dictionary<string, ResponseSectionFields>> SelectAllFieldsAsync(ApiObjectType objectType, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
            };

            var result = await _apiRequest.GetAsync<Dictionary<string, ResponseSectionFields>>(
                "objects/fieldeditor", query, false, cancellationToken).ConfigureAwait(false);
            return result!;
        }

        /// <summary>
        /// Retrieve information about a field an object has.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <returns>A object containing the field information.</returns>
        public async Task<ApiFieldInfo?> SelectFieldByNameAsync(ApiObjectType objectType, string fieldName, CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmpty(fieldName);

            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "field", fieldName }
            };

            return await _apiRequest.GetAsync<ApiFieldInfo>(
                "objects/fieldeditor", query, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates an existing object with given data.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="objectId">The ID of the object to update.</param>
        /// <param name="values">Fields to set on the object.</param>
        /// <returns>A dictionary of updated fields.</returns>
        public async Task<Dictionary<string, string>> UpdateAsync(ApiObjectType objectType, long objectId, object? values = null, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "id", objectId }
            };

            var json = await _apiRequest.PutJsonAsync(
                "objects", query.AddObject(values), cancellationToken).ConfigureAwait(false);
            return await json.RunAndCatchAsync(x => x.JsonData().JsonChild("attrs").ToObject<Dictionary<string, string>>()).ConfigureAwait(false);
        }

        /// <summary>
        /// Update fields and sections in an object record. The section MUST exist in order to update it. Any fields that do not already exist 
        /// will be created. Fields can be matched either by their alias (displayed name), or by the actual name of the field e.g. f1234.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="sectionName">The name of the section.</param>
        /// <param name="fields">An array of columns containing fields containing arrays of Field objects.</param>
        /// <param name="sectionDescription">A description for the new Section.</param>
        /// <returns></returns>
        public async Task<ResponseSuccessList> UpdateFieldsAsync(ApiObjectType objectType, string sectionName, IEnumerable<IEnumerable<ApiFieldEditor>> fields, string? sectionDescription = null, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "name", sectionName},
                { "fields", fields }
            }
                .AddIfHasValue("description", sectionDescription);

            var json = await _apiRequest.PutJsonAsync(
                "objects/fieldeditor", query, cancellationToken).ConfigureAwait(false);
            return await json.RunAndCatchAsync(x => new ResponseSuccessList(x)).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes an existing object of the specified object type.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="objectId">The ID of the specific object.</param>
        public async Task DeleteAsync(ApiObjectType objectType, long objectId, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "id", objectId }
            };

            await _apiRequest.DeleteAsync<object>(
                "object", query, false, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// This endpoint deletes a collection of objects. Use caution with this endpoint.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <returns>A list of objects matching the query.</returns>
        public async Task DeleteMultipleAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions = null, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
            }
                .AddSearchOptions(searchOptions, null, true);

            await _apiRequest.DeleteAsync<object>(
                "objects", query, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes a section in an object record. If attempting to delete a section, the section MUST be empty.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="sectionName">The name of the section.</param>
        public async Task DeleteSectionAsync(ApiObjectType objectType, string sectionName, CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmpty(sectionName);

            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "section", sectionName}
            };

            await _apiRequest.DeleteAsync<string>(
                "objects/fieldeditor", query, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes a field in an object record.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="fieldName">The name of the field e.g f1234.</param>
        public async Task DeleteFieldAsync(ApiObjectType objectType, string fieldName, CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmpty(fieldName);

            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "field", fieldName}
            };

            await _apiRequest.DeleteAsync<string>(
                "objects/fieldeditor", query, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds one or more objects to one or more sequences.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="sequenceIds">A list of the sequence(s) to which objects should be added.</param>
        public async Task AddToSequenceAsync(ApiObjectType objectType, ApiSearchOptions searchOptions, IEnumerable<long> sequenceIds, CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmpty(sequenceIds);

            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "add_list", sequenceIds },
            }
                .AddSearchOptions(searchOptions, null, true);

            await _apiRequest.PutAsync<object>(
                "objects/sequence", query, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds one or more tags to one or more objects.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="tagIds">A list of the IDs of the tag(s) which should be added to objects.</param>
        public async Task AddTagAsync(ApiObjectType objectType,
            ApiSearchOptions? searchOptions, IEnumerable<long> tagIds, CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmpty(tagIds);

            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "add_list", tagIds },
            }
                .AddSearchOptions(searchOptions, null, true);

            await _apiRequest.PutAsync<object>(
                "objects/tag", query, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds one or more tags to one or more objects by the tag name. This endpoint will create the tag if it doesn't exist.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="tagNames">A list of the names of the tag(s) which should be added to objects.</param>
        public async Task AddTagNamesAsync(ApiObjectType objectType,
            ApiSearchOptions? searchOptions, IEnumerable<string> tagNames, CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmpty(tagNames);

            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "add_names", tagNames },
            }
                .AddSearchOptions(searchOptions, null, true);

            await _apiRequest.PutAsync<object>(
                "objects/tagByName", query, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds one or more objects to one or more campaigns.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="campaignIds">A list of the campaign(s) to which objects should be added.</param>
        public async Task AddToCampaignAsync(ApiObjectType objectType,
            ApiSearchOptions? searchOptions, IEnumerable<long> campaignIds, CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmpty(campaignIds);

            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "add_list", campaignIds },
            }
                .AddSearchOptions(searchOptions, null, true);

            await _apiRequest.PutAsync<object>(
                "objects/subscribe", query, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Removes one or more objects from one or more sequences.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="sequenceIds">A list of the sequence(s) from which objects should be removed.</param>
        public async Task RemoveFromSequenceAsync(ApiObjectType objectType,
            ApiSearchOptions? searchOptions, IEnumerable<long> sequenceIds, CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmpty(sequenceIds);

            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "remove_list", sequenceIds }
            }
                .AddSearchOptions(searchOptions, null);

            await _apiRequest.DeleteAsync<object>(
                "objects/sequence", query, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Removes one or more tags from one or more objects.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="tagIds">A list of the IDs of the tag(s) which should be removed from objects.</param>
        public async Task RemoveTagAsync(ApiObjectType objectType,
            ApiSearchOptions? searchOptions, IEnumerable<long> tagIds, CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmpty(tagIds);

            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "remove_list", tagIds },
            }
                .AddSearchOptions(searchOptions, null);

            await _apiRequest.DeleteAsync<object>(
                "objects/tag", query, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Removes one or more tags from one or more objects by the tag name.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="tagNames">A list of the names of the tag(s) which should be removed from objects.</param>
        public async Task RemoveTagNamesAsync(ApiObjectType objectType,
            ApiSearchOptions? searchOptions, IEnumerable<string> tagNames, CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmpty(tagNames);

            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "remove_names", tagNames },
            }
                .AddSearchOptions(searchOptions, null);

            await _apiRequest.DeleteAsync<object>(
                "objects/tagByName", query, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Removes one or more objects from one or more campaigns.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="campaignIds">A list of the campaign(s) from which objects should be removed.</param>
        public async Task RemoveFromCampaignAsync(ApiObjectType objectType,
            ApiSearchOptions? searchOptions, IEnumerable<long> campaignIds, CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmpty(campaignIds);

            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
                { "remove_list", campaignIds }
            }
                .AddSearchOptions(searchOptions, null);

            await _apiRequest.DeleteAsync<object>(
                "objects/subscribe", query, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Pauses rules, sequences, and sequence subscribers.
        /// </summary>
        /// <param name="objectType">The object type: Rule, Sequence or Sequence Subscriber.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task PauseRuleOrSequenceAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions, CancellationToken cancellationToken = default)
        {
            if (objectType != ApiObjectType.Rule && objectType != ApiObjectType.Sequence && objectType != ApiObjectType.SequenceSubscriber)
            {
                throw new ArgumentException(Properties.Resources.ObjectTypeMustBeSequence);
            }

            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
            }
                .AddSearchOptions(searchOptions, null);

            await _apiRequest.PostAsync<object>(
                "objects/pause", query, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Unpauses rules, sequences, and sequence subscribers.
        /// </summary>
        /// <param name="objectType">The object type: Rule, Sequence or Sequence Subscriber.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task UnpauseRuleOrSequenceAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions, CancellationToken cancellationToken = default)
        {
            if (objectType != ApiObjectType.Rule && objectType != ApiObjectType.Sequence && objectType != ApiObjectType.SequenceSubscriber)
            {
                throw new ArgumentException(Properties.Resources.ObjectTypeMustBeSequence);
            }

            var query = new Dictionary<string, object?>
            {
                { "objectID", (long)objectType },
            }
                .AddSearchOptions(searchOptions, null);

            await _apiRequest.PostAsync<object>(
                "objects/unpause", query, true, cancellationToken).ConfigureAwait(false);
        }
    }
}
