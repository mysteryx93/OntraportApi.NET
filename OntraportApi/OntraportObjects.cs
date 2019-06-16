using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi
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
        public async Task<Dictionary<string, string>> CreateAsync(ApiObjectType objectType, object values = null)
        {
            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType }
            };

            return await _apiRequest.PostAsync<Dictionary<string, string>>(
                "objects", query.AddObject(values));
        }

        /// <summary>
        /// Looks for an existing object with a matching unique field and merges supplied data with existing data. If no unique field is supplied or if no existing object has a matching unique field, a new object will be created.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="ignoreBlanks">Whether or not blank strings should be ignored upon update. Defaults to false: blank strings passed to this endpoint will overwrite existing value.</param>
        /// <param name="values">Additional properties to set on the object.</param>
        /// <returns>The created or updated object.</returns>
        public async Task<Dictionary<string, string>> CreateOrMergeAsync(ApiObjectType objectType, bool ignoreBlanks = false, object values = null)
        {
            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "ignore_blanks", ignoreBlanks }
            };

            var result = await _apiRequest.PostAsync<JObject>(
                "objects/saveorupdate", query.AddObject(values));
            return result["data"]["attrs"].ToObject<Dictionary<string, string>>();
        }

        /// <summary>
        /// Create new fields and sections in an object record. If the section name doesn't exist, a new one will be created with that name.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="sectionName">The name of the section.</param>
        /// <param name="fields">An array of 3 columns containing fields containing arrays of field objects.</param>
        /// <returns>A list of field operations in a successful or error state.</returns>
        public async Task<ResponseSuccessList> CreateFieldsAsync(ApiObjectType objectType, string sectionName, IEnumerable<IEnumerable<ApiFieldEditor>> fields = null)
        {
            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "name", sectionName},
                { "fields", fields }
            };

            var result = await _apiRequest.PostAsync<JObject>(
                "objects/fieldeditor", query);
            return new ResponseSuccessList(result);
        }

        /// <summary>
        /// Retrieves all the information for an existing object of the specified object type.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="objectId">The ID of the specific object.</param>
        /// <returns>The selected object.</returns>
        public async Task<Dictionary<string, string>> SelectAsync(ApiObjectType objectType, int objectId)
        {
            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "id", objectId }
            };

            return await _apiRequest.GetAsync<Dictionary<string, string>>(
                "object", query);
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
            ApiSearchOptions searchOptions = null, ApiSortOptions sortOptions = null,
            IEnumerable<string> externs = null, IEnumerable<string> listFields = null)
        {
            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType }
            }
                .AddSearchOptions(searchOptions)
                .AddSortOptions(sortOptions)
                .AddIfHasValue("externs", externs)
                .AddIfHasValue("listFields", listFields);

            return await _apiRequest.GetAsync<List<Dictionary<string, string>>>(
                "objects", query);
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
            int? tagId = null, string tagName = null,
            ApiSearchOptions searchOptions = null, ApiSortOptions sortOptions = null,
            IEnumerable<string> externs = null, IEnumerable<string> listFields = null)
        {
            var json = await SelectByTagAsync(objectType, tagId, tagName, searchOptions, sortOptions, externs, listFields, true);
            return json["data"]["count"].Value<string>().Convert<int>();
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
            int? tagId = null, string tagName = null,
            ApiSearchOptions searchOptions = null, ApiSortOptions sortOptions = null,
            IEnumerable<string> externs = null, IEnumerable<string> listFields = null)
        {
            var json = await SelectByTagAsync(objectType, tagId, tagName, searchOptions, sortOptions, externs, listFields, false);
            return json["data"].ToObject<List<Dictionary<string, string>>>();
        }

        private async Task<JObject> SelectByTagAsync(ApiObjectType objectType,
            int? tagId = null, string tagName = null,
            ApiSearchOptions searchOptions = null, ApiSortOptions sortOptions = null,
            IEnumerable<string> externs = null, IEnumerable<string> listFields = null, bool count = false)
        {
            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { tagId.HasValue ? "tag_id" : "tag_name", (object)tagId ?? tagName },
                { "count", count ? "true" : "false" },
            }
                .AddSearchOptions(searchOptions)
                .AddSortOptions(sortOptions)
                .AddIfHasValue("externs", externs)
                .AddIfHasValue("listFields", listFields);

            return await _apiRequest.GetAsync<JObject>(
                "objects/tag", query);
        }

        /// <summary>
        /// Retrieves the first ID of contact object or custom object by their email fields.
        /// </summary>
        /// <param name="objectType">The object type id.</param>
        /// <param name="email">The email of the object you would like to retrieve.</param>
        /// <returns>The object ID.</returns>
        public async Task<int?> GetObjectIdByEmailAsync(ApiObjectType objectType, string email)
        {
            var json = await GetObjectIdByEmailAsync(objectType, email, false);
            var result = json["data"]["id"].Value<string>();
            return result != null ? result.Convert<int>() : (int?)null;
        }

        /// <summary>
        /// Retrieves all IDs of contact objects or custom objects by their email fields.
        /// </summary>
        /// <param name="objectType">The object type id.</param>
        /// <param name="email">The email of the object you would like to retrieve.</param>
        /// <param name="all">A binary integer flag indicating whether you would like to retrieve an array of all IDs for objects with a matching email. If false, only the first object will be returned.</param>
        /// <returns>A list of object IDs.</returns>
        public async Task<IEnumerable<int>> GetObjectIdByEmailAllAsync(ApiObjectType objectType, string email)
        {
            var json = await GetObjectIdByEmailAsync(objectType, email, true);
            return json["data"]["ids"].Values<int>();
        }

        private async Task<JObject> GetObjectIdByEmailAsync(ApiObjectType objectType, string email, bool all = false)
        {
            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "email", email },
                { "all", all ? 1 : 0 }
            };

            return await _apiRequest.GetAsync<JObject>(
                "object/getByEmail", query);
        }

        /// <summary>
        /// Retrieves the field meta data for the specified object type.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="indexByName">True to index by name, false to index by id.</param>
        /// <returns>A JObject providing raw access to the JSON data.</returns>
        public async Task<Dictionary<int, ResponseMetadata>> GetAllMetadataAsync()
        {
            var query = new Dictionary<string, object>
            {
                { "format", "byId" }
            };

            return await _apiRequest.GetAsync<Dictionary<int, ResponseMetadata>>(
                "objects/meta", query);
        }

        /// <summary>
        /// Retrieves the field meta data for the specified object type.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <returns>A JObject providing raw access to the JSON data.</returns>
        public async Task<ResponseMetadata> GetMetadataAsync(ApiObjectType objectType)
        {
            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "format", "byId" }
            };

            var result = await _apiRequest.GetAsync<JObject>(
                "objects/meta", query);
            return result["data"].First.First.ToObject<ResponseMetadata>();
        }

        /// <summary>
        /// Retrieves information about a collection of objects, such as the number of objects that match the given criteria.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <returns>A ResponseCollectionInfo object.</returns>
        public async Task<ResponseCollectionInfo> GetCollectionInfoAsync(ApiObjectType objectType, ApiSearchOptions searchOptions = null)
        {
            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
            }
                .AddSearchOptions(searchOptions);

            return await _apiRequest.GetAsync<ResponseCollectionInfo>(
                "objects/getInfo", query);
        }

        /// <summary>
        /// Retrieve information about the fields an object has within a section.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="sectionName">The name of the section.</param>
        /// <returns>A list of fields in that section.</returns>
        public async Task<ResponseSectionFields> SelectFieldsBySectionAsync(ApiObjectType objectType, string sectionName)
        {
            if (string.IsNullOrEmpty(sectionName)) throw new ArgumentException("sectionName is required.");

            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "section", sectionName }
            };

            return await _apiRequest.GetAsync<ResponseSectionFields>(
                "objects/fieldeditor", query);
        }

        /// <summary>
        /// Retrieve information about all fields and sections an object has.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <returns>A dictionary of sections each containing their fields.</returns>
        public async Task<Dictionary<int, ResponseSectionFields>> SelectAllFieldsAsync(ApiObjectType objectType)
        {
            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
            };

            return await _apiRequest.GetAsync<Dictionary<int, ResponseSectionFields>>(
                "objects/fieldeditor", query);
        }

        /// <summary>
        /// Retrieve information about a field an object has.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <returns>A object containing the field information.</returns>
        public async Task<ApiFieldInfo> SelectFieldByNameAsync(ApiObjectType objectType, string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName)) throw new ArgumentException("fieldName is required.");

            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "field", fieldName }
            };

            return await _apiRequest.GetAsync<ApiFieldInfo>(
                "objects/fieldeditor", query);
        }

        /// <summary>
        /// Updates an existing object with given data.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="objectId">The ID of the object to update.</param>
        /// <param name="values">Fields to set on the object.</param>
        /// <returns>A dictionary of updated fields.</returns>
        public async Task<Dictionary<string, string>> UpdateAsync(ApiObjectType objectType, int objectId, object values = null)
        {
            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "id", objectId }
            };

            var result = await _apiRequest.PutAsync<JObject>(
                "objects", query.AddObject(values));
            return result["data"]["attrs"].ToObject<Dictionary<string, string>>();
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
        public async Task<ResponseSuccessList> UpdateFieldsAsync(ApiObjectType objectType, string sectionName, IEnumerable<IEnumerable<ApiFieldEditor>> fields, string sectionDescription = null)
        {
            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "name", sectionName},
                { "fields", fields }
            }
                .AddIfHasValue("description", sectionDescription);

            var result = await _apiRequest.PutAsync<JObject>(
                "objects/fieldeditor", query);
            return new ResponseSuccessList(result);
        }

        /// <summary>
        /// Deletes an existing object of the specified object type.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="objectId">The ID of the specific object.</param>
        public async Task DeleteAsync(ApiObjectType objectType, int objectId)
        {
            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "id", objectId }
            };

            await _apiRequest.DeleteAsync<object>(
                "object", query, encodeJson: false);
        }

        /// <summary>
        /// This endpoint deletes a collection of objects. Use caution with this endpoint.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <returns>A list of objects matching the query.</returns>
        public async Task DeleteMultipleAsync(ApiObjectType objectType, ApiSearchOptions searchOptions = null)
        {
            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
            }
                .AddSearchOptions(searchOptions, true);

            await _apiRequest.DeleteAsync<object>(
                "objects", query);
        }

        /// <summary>
        /// Deletes a section in an object record. If attempting to delete a section, the section MUST be empty.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="sectionName">The name of the section.</param>
        public async Task DeleteSectionAsync(ApiObjectType objectType, string sectionName)
        {
            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "section", sectionName}
            };

            await _apiRequest.DeleteAsync<string>(
                "objects/fieldeditor", query);
        }

        /// <summary>
        /// Deletes a field in an object record.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="fieldName">The name of the field e.g f1234.</param>
        public async Task DeleteFieldAsync(ApiObjectType objectType, string fieldName)
        {
            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "field", fieldName}
            };

            await _apiRequest.DeleteAsync<string>(
                "objects/fieldeditor", query);
        }

        /// <summary>
        /// Adds one or more objects to one or more sequences.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="sequenceIds">A list of the sequence(s) to which objects should be added.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task AddToSequenceAsync(ApiObjectType objectType,
            IEnumerable<int> sequenceIds, ApiSearchOptions searchOptions = null)
        {
            if (sequenceIds == null || !sequenceIds.Any()) throw new ArgumentException("sequenceIds is required.");

            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "add_list", sequenceIds },
            }
                .AddSearchOptions(searchOptions, true);

            await _apiRequest.PutAsync<object>(
                "objects/sequence", query);
        }

        /// <summary>
        /// Adds one or more tags to one or more objects.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="tagIds">A list of the IDs of the tag(s) which should be added to objects.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task AddTagAsync(ApiObjectType objectType,
            IEnumerable<int> tagIds, ApiSearchOptions searchOptions = null)
        {
            if (tagIds == null || !tagIds.Any()) throw new ArgumentException("tagIds is required.");

            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "add_list", tagIds },
            }
                .AddSearchOptions(searchOptions, true);

            await _apiRequest.PutAsync<object>(
                "objects/tag", query);
        }

        /// <summary>
        /// Adds one or more tags to one or more objects by the tag name. This endpoint will create the tag if it doesn't exist.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="tagNames">A list of the names of the tag(s) which should be added to objects.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task AddTagNamesAsync(ApiObjectType objectType,
            IEnumerable<string> tagNames, ApiSearchOptions searchOptions = null)
        {
            if (tagNames == null || !tagNames.Any()) throw new ArgumentException("tagNames is required.");

            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "add_names", tagNames },
            }
                .AddSearchOptions(searchOptions, true);

            await _apiRequest.PutAsync<object>(
                "objects/tagByName", query);
        }

        /// <summary>
        /// Adds one or more objects to one or more campaigns.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="campaignIds">A list of the campaign(s) to which objects should be added.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task AddToCampaignAsync(ApiObjectType objectType,
            IEnumerable<int> campaignIds, ApiSearchOptions searchOptions = null)
        {
            if (campaignIds == null || !campaignIds.Any()) throw new ArgumentException("campaignIds is required.");

            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "add_list", campaignIds },
            }
                .AddSearchOptions(searchOptions, true);

            await _apiRequest.PutAsync<object>(
                "objects/subscribe", query);
        }

        /// <summary>
        /// Removes one or more objects from one or more sequences.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="sequenceIds">A list of the sequence(s) from which objects should be removed.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task RemoveFromSequenceAsync(ApiObjectType objectType,
            IEnumerable<int> sequenceIds, ApiSearchOptions searchOptions = null)
        {
            if (sequenceIds == null || !sequenceIds.Any()) throw new ArgumentException("sequenceIds is required.");

            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "remove_list", sequenceIds }
            }
                .AddSearchOptions(searchOptions);

            await _apiRequest.DeleteAsync<object>(
                "objects/sequence", query);
        }

        /// <summary>
        /// Removes one or more tags from one or more objects.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="tagIds">A list of the IDs of the tag(s) which should be removed from objects.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task RemoveTagAsync(ApiObjectType objectType,
            IEnumerable<int> tagIds, ApiSearchOptions searchOptions = null)
        {
            if (tagIds == null || !tagIds.Any()) throw new ArgumentException("tagIds is required.");

            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "remove_list", tagIds },
            }
                .AddSearchOptions(searchOptions);

            await _apiRequest.DeleteAsync<object>(
                "objects/tag", query);
        }

        /// <summary>
        /// Removes one or more tags from one or more objects by the tag name.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="tagNames">A list of the names of the tag(s) which should be removed from objects.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task RemoveTagNamesAsync(ApiObjectType objectType,
            IEnumerable<string> tagNames, ApiSearchOptions searchOptions = null)
        {
            if (tagNames == null || !tagNames.Any()) throw new ArgumentException("tagNames is required.");

            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "remove_names", tagNames },
            }
                .AddSearchOptions(searchOptions);

            await _apiRequest.DeleteAsync<object>(
                "objects/tagByName", query);
        }

        /// <summary>
        /// Removes one or more objects from one or more campaigns.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="campaignIds">A list of the campaign(s) from which objects should be removed.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task RemoveFromCampaignAsync(ApiObjectType objectType,
            IEnumerable<int> campaignIds, ApiSearchOptions searchOptions = null)
        {
            if (campaignIds == null || !campaignIds.Any()) throw new ArgumentException("campaignIds is required.");

            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
                { "remove_list", campaignIds },
            }
                .AddSearchOptions(searchOptions);

            await _apiRequest.DeleteAsync<object>(
                "objects/subscribe", query);
        }

        /// <summary>
        /// Pauses rules, sequences, and sequence subscribers.
        /// </summary>
        /// <param name="objectType">The object type: Rule, Sequence or Sequence Subscriber.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task PauseRuleOrSequenceAsync(ApiObjectType objectType, ApiSearchOptions searchOptions = null)
        {
            if (objectType != ApiObjectType.Rule && objectType != ApiObjectType.Sequence && objectType != ApiObjectType.SequenceSubscriber)
            {
                throw new ArgumentException("objectType must be Rule, Sequence or SequenceSubscriber.");
            }

            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
            }
                .AddSearchOptions(searchOptions);

            await _apiRequest.PostAsync<object>(
                "objects/pause", query);
        }

        /// <summary>
        /// Unpauses rules, sequences, and sequence subscribers.
        /// </summary>
        /// <param name="objectType">The object type: Rule, Sequence or Sequence Subscriber.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task UnpauseRuleOrSequenceAsync(ApiObjectType objectType, ApiSearchOptions searchOptions = null)
        {
            if (objectType != ApiObjectType.Rule && objectType != ApiObjectType.Sequence && objectType != ApiObjectType.SequenceSubscriber)
            {
                throw new ArgumentException("objectType must be Rule, Sequence or SequenceSubscriber.");
            }

            var query = new Dictionary<string, object>
            {
                { "objectID", (int)objectType },
            }
                .AddSearchOptions(searchOptions);

            await _apiRequest.PostAsync<object>(
                "objects/unpause", query);
        }
    }
}
