using System;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for Offer objects.
    /// Offer objects allow you to save the details of products, quantities, and prices of frequently used transactions as offers for rapid processing with other Contacts.
    /// Offers can be associated with many other objects such as transactions and products. You can access additional functionality 
    /// for adding offers to transactions and adding products to offers using the transaction API and the product API.
    /// </summary>
    public interface IOntraportOffers : IOntraportBaseWrite<ApiOffer>
    {
    }
}
