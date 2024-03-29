﻿namespace HanumanInstitute.OntraportApi;

/// <summary>
/// Provides Ontraport API support for Offer objects.
/// Offer objects allow you to save the details of products, quantities, and prices of frequently used transactions as offers for rapid processing with other Contacts.
/// Offers can be associated with many other objects such as transactions and products. You can access additional functionality 
/// for adding offers to transactions and adding products to offers using the transaction API and the product API.
/// </summary>
public class OntraportOffers : OntraportBaseWrite<ApiOffer>, IOntraportOffers
{
    public OntraportOffers(OntraportHttpClient apiRequest) : 
        base(apiRequest, "Offer", "Offers", ApiOffer.NameKey)
    { }

    // Tool available to build an offer
    // https://api.ontraport.com/doc/#build-an-offer
}
