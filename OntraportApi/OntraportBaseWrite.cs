using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;
using Res = HanumanInstitute.OntraportApi.Properties.Resources;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Provides common API endpoints for all objects with update methods.
    /// </summary>
    /// <typeparam name="T">The data object type deriving from ApiObject.</typeparam>
    public abstract class OntraportBaseWrite<T> : OntraportBaseWrite<T, T>
        where T : ApiObject
    {
        public OntraportBaseWrite(OntraportHttpClient apiRequest, string endpointSingular, string endpointPlural, string? primarySearchKey) :
            base(apiRequest, endpointSingular, endpointPlural, primarySearchKey)
        { }
    }
    /// <summary>
    /// Provides common API endpoints for all objects with update methods.
    /// TOverride can be used to configure Live and Sandbox accounts with a common interface and different Field IDs.
    /// </summary>
    /// <typeparam name="T">The data object type deriving from ApiObject.</typeparam>
    /// <typeparam name="TOverride">A sub-type that overrides T members.</typeparam>
    public abstract class OntraportBaseWrite<T, TOverride> : OntraportBaseRead<T>, IOntraportBaseWrite<T>
        where T : ApiObject
        where TOverride : T
    {
        protected string? PrimarySearchKey { get; }

        public OntraportBaseWrite(OntraportHttpClient apiRequest, string endpointSingular, string endpointPlural, string? primarySearchKey) :
            base(apiRequest, endpointSingular, endpointPlural)
        {
            PrimarySearchKey = primarySearchKey;
        }

        /// <summary>
        /// Retrieves all the information for an existing object.
        /// </summary>
        /// <param name="keyValue">The key value of the specific object, usually the name or email.</param>
        /// <returns>The selected object.</returns>
        public async Task<T?> SelectAsync(string keyValue, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(PrimarySearchKey)) { throw new InvalidOperationException(Res.InvalidMethodForObjectType); }

            var result = await SelectAsync(new ApiSearchOptions().AddCondition(PrimarySearchKey, "=", keyValue), cancellationToken: cancellationToken).ConfigureAwait(false);
            return result.FirstOrDefault();
        }

        /// <summary>
        /// This endpoint will add a new object to your database. It can be used for any object type as long as the correct parameters are supplied. This endpoint allows duplication; if you want to avoid duplicates you should merge instead.
        /// </summary>
        /// <param name="values">Fields to set on the object.</param>
        /// <returns>The created object.</returns>
        public async Task<T> CreateAsync(object? values = null, CancellationToken cancellationToken = default)
        {
            var json = await ApiRequest.PostJsonAsync(
                EndpointPlural,
                new Dictionary<string, object?>().AddObject(values), cancellationToken).ConfigureAwait(false);
            return await json.RunAndCatchAsync(x => OnParseCreate(x)).ConfigureAwait(false);
        }

        /// <summary>
        /// When overriden in a derived class, allows custom parsing of CreateAsync response.
        /// </summary>
        /// <param name="json">The JSON data to parse.</param>
        /// <returns>A T or object derived from it.</returns>
        protected virtual T OnParseCreate(JsonElement json) =>
            CreateApiObject(json.JsonData());

        /// <summary>
        /// Updates an existing object with given data.
        /// </summary>
        /// <param name="objectId">The ID of the object to update.</param>
        /// <param name="values">Fields to set on the object.</param>
        /// <returns>A dictionary of updated fields.</returns>
        public async Task<T> UpdateAsync(int objectId, object? values = null, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "id", objectId }
            };

            var json = await ApiRequest.PutJsonAsync(
                EndpointPlural, query.AddObject(values), cancellationToken).ConfigureAwait(false);
            return await json.RunAndCatchAsync(x => OnParseUpdate(x)).ConfigureAwait(false);
        }

        /// <summary>
        /// When overriden in a derived class, allows custom parsing of UpdateAsync response.
        /// </summary>
        /// <param name="json">The JSON data to parse.</param>
        /// <returns>A T or object derived from it.</returns>
        protected virtual T OnParseUpdate(JsonElement json) =>
            CreateApiObject(json.JsonData().JsonChild("attrs"));
    }
}
