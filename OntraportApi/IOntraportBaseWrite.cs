namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Provides common API endpoints for all objects with update methods.
    /// </summary>
    /// <typeparam name="T">The data object type deriving from ApiObject.</typeparam>
    public interface IOntraportBaseWrite<T> : IOntraportBaseRead<T>
        where T : ApiObject
    {
        /// <summary>
        /// Retrieves all the information for an existing object.
        /// </summary>
        /// <param name="id">The ID of the specific object.</param>
        /// <returns>The selected object.</returns>
        Task<T?> SelectAsync(string keyValue, CancellationToken cancellationToken = default);

        /// <summary>
        /// This endpoint will add a new object to your database. It can be used for any object type as long as the correct parameters are supplied. This endpoint allows duplication; if you want to avoid duplicates you should merge instead.
        /// </summary>
        /// <param name="values">Fields to set on the object.</param>
        /// <returns>The created object.</returns>
        Task<T> CreateAsync(object? values = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing object with given data.
        /// </summary>
        /// <param name="objectId">The ID of the object to update.</param>
        /// <param name="values">Fields to set on the object.</param>
        /// <returns>An object containing updated fields.</returns>
        Task<T> UpdateAsync(long objectId, object? values = null, CancellationToken cancellationToken = default);
    }
}
