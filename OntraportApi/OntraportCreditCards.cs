namespace HanumanInstitute.OntraportApi;

/// <summary>
/// Provides Ontraport API support for CreditCard objects.
/// Credit cards objects store data for a contact's saved credit cards, including card information, type, status, and billing details.
/// </summary>
public class OntraportCreditCards : OntraportBaseRead<ApiCreditCard>, IOntraportCreditCards
{
    public OntraportCreditCards(OntraportHttpClient apiRequest) :
        base(apiRequest, "CreditCard", "CreditCards")
    { }

    /// <summary>
    /// Sets the status of an existing card to default and adjusts the status of the current default card.
    /// </summary>
    /// <param name="creditCardId">The credit card ID.</param>
    /// <returns>An ApiCreditCard containing updated fields.</returns>
    public async Task<ApiCreditCard?> SetDefaultAsync(int creditCardId, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>
        {
            { "id", creditCardId }
        };

        var json = await ApiRequest.PutJsonAsync(
            $"{EndpointSingular}/default", query, cancellationToken).ConfigureAwait(false);
        return await json.RunAndCatchAsync(x => CreateApiObject(x)).ConfigureAwait(false);
    }
}
