namespace HanumanInstitute.OntraportApi;

/// <summary>
/// Provides common API endpoints for all objects with delete methods.
/// </summary>
/// <typeparam name="T">The data object type deriving from ApiObject.</typeparam>
public abstract class OntraportBaseDelete<T> : OntraportBaseDelete<T, T>, IOntraportBaseDelete<T> 
    where T : ApiObject
{
    public OntraportBaseDelete(OntraportHttpClient apiRequest, string endpointSingular, string endpointPlural, string? primarySearchKey) :
        base(apiRequest, endpointSingular, endpointPlural, primarySearchKey)
    { }
}

/// <summary>
/// Provides common API endpoints for all objects with delete methods.
/// TOverride can be used to configure Live and Sandbox accounts with a common interface and different Field IDs.
/// </summary>
/// <typeparam name="T">The data object type deriving from ApiObject.</typeparam>
/// <typeparam name="TOverride">A sub-type that overrides T members.</typeparam>
public abstract class OntraportBaseDelete<T, TOverride> : OntraportBaseWrite<T, TOverride>
    where T : ApiObject
    where TOverride : T
{
    public OntraportBaseDelete(OntraportHttpClient apiRequest, string endpointSingular, string endpointPlural, string? primarySearchKey) :
        base(apiRequest, endpointSingular, endpointPlural, primarySearchKey)
    { }

    /// <summary>
    /// Deletes an existing object.
    /// </summary>
    /// <param name="objectId">The ID of the specific object.</param>
    public virtual async Task DeleteAsync(long objectId, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>
        {
            { "id", objectId }
        };

        await ApiRequest.DeleteAsync<object>(
            EndpointSingular, query, false, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// This endpoint deletes a collection of objects. Use caution with this endpoint.
    /// </summary>
    /// <param name="searchOptions">The search options.</param>
    /// <returns>A list of objects matching the query.</returns>
    public virtual async Task DeleteAsync(ApiSearchOptions searchOptions, CancellationToken cancellationToken = default)
    {
        Check.NotNull(searchOptions);

        var keysOverride = this.GetKeysOverride();
        var query = new Dictionary<string, object?>()
            .AddSearchOptions(searchOptions, keysOverride, true);

        await ApiRequest.DeleteAsync<object>(
            EndpointPlural, query, true, cancellationToken).ConfigureAwait(false);
    }
}
