namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Provides common API endpoints for all objects with read methods.
    /// </summary>
    /// <typeparam name="T">The data object type deriving from ApiObject.</typeparam>
    public interface IOntraportBaseRead<T> 
        where T : ApiObject
    {
        /// <summary>
        /// Retrieves all the information for an existing object.
        /// </summary>
        /// <param name="id">The ID of the specific object.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The selected object.</returns>
        Task<T?> SelectAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a collection of objects based on a set of parameters.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="sortOptions">The sort options.</param>
        /// <param name="externs">If you have a relationship between your object and another object, you may want to include the data from a related field in your results. Each external field is listed in the format {object}//{field}.</param>
        /// <param name="listFields">A string array of the fields which should be returned in your results.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A list of objects matching the query.</returns>
        Task<IList<T>> SelectAsync(ApiSearchOptions? searchOptions = null, ApiSortOptions? sortOptions = null, IEnumerable<string>? externs = null, IEnumerable<string>? listFields = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the field meta data for the specified object type.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A ResponseMetaData object.</returns>
        Task<ResponseMetadata> GetMetadataAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves information about a collection of objects, such as the number of objects that match the given criteria.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A ResponseCollectionInfo object.</returns>
        Task<ResponseCollectionInfo?> GetCollectionInfoAsync(ApiSearchOptions? searchOptions = null, CancellationToken cancellationToken = default);
    }
}
