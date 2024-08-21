namespace HanumanInstitute.OntraportApi;

/// <summary>
/// Provides Ontraport API support for Purchases objects.
/// Purchases allow you to view and process purchases which have already been made. For every completed sale of a product, a purchase object is created. 
/// </summary>
public class OntraportPurchases : OntraportBaseDelete<ApiPurchase>, IOntraportPurchases
{
    public OntraportPurchases(OntraportHttpClient apiRequest) : 
        base(apiRequest, "Purchase", "Purchases", ApiPurchase.ContactIdKey)
    { }

}
