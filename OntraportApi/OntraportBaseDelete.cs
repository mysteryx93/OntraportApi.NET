using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Provides common API endpoints for all objects with delete methods.
    /// </summary>
    /// <typeparam name="T">The data object type deriving from ApiObject.</typeparam>
    public abstract class OntraportBaseDelete<T> : OntraportBaseWrite<T>, IOntraportBaseDelete<T> 
        where T : ApiObject
    {
        public OntraportBaseDelete(OntraportHttpClient apiRequest, string endpointSingular, string endpointPlural, string? primarySearchKey) :
            base(apiRequest, endpointSingular, endpointPlural, primarySearchKey)
        { }

        /// <summary>
        /// Deletes an existing object.
        /// </summary>
        /// <param name="objectId">The ID of the specific object.</param>
        public virtual async Task DeleteAsync(int objectId)
        {
            var query = new Dictionary<string, object?>
            {
                { "id", objectId }
            };

            await ApiRequest.DeleteAsync<object>(
                EndpointSingular, query, encodeJson: false).ConfigureAwait(false);
        }

        /// <summary>
        /// This endpoint deletes a collection of objects. Use caution with this endpoint.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <returns>A list of objects matching the query.</returns>
        public virtual async Task DeleteAsync(ApiSearchOptions searchOptions)
        {
            var query = new Dictionary<string, object?>()
                .AddSearchOptions(searchOptions, true);

            await ApiRequest.DeleteAsync<object>(
                EndpointPlural, query).ConfigureAwait(false);
        }
    }
}
