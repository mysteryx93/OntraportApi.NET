﻿namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Provides common API endpoints for all objects with delete methods.
    /// </summary>
    /// <typeparam name="T">The data object type deriving from ApiObject.</typeparam>
    public interface IOntraportBaseDelete<T> : IOntraportBaseWrite<T>
        where T : ApiObject
    {
        /// <summary>
        /// Deletes an existing object.
        /// </summary>
        /// <param name="objectId">The ID of the specific object.</param>
        Task DeleteAsync(long objectId, CancellationToken cancellationToken = default);

        /// <summary>
        /// This endpoint deletes a collection of objects. Use caution with this endpoint.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <returns>A list of objects matching the query.</returns>
        Task DeleteAsync(ApiSearchOptions searchOptions, CancellationToken cancellationToken = default);
    }
}
