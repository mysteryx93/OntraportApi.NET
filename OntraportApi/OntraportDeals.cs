using System;
using HanumanInstitute.OntraportApi.Models;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for Deals objects.
    /// </summary>
    /// <typeparam name="T">A type deriving from ApiDeal exposing additional custom fields.</typeparam>
    public class OntraportDeals<T> : OntraportBaseCustomObject<T>, IOntraportDeals<T>
        where T : ApiDeal
    {
        public OntraportDeals(OntraportHttpClient apiRequest, IOntraportObjects ontraObjects) : 
            base(apiRequest, ontraObjects, "Deal", "Deals", (int)ApiObjectType.Deal, ApiDeal.NameKey)
        { }
    }
}
