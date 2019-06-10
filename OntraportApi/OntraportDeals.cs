using System;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for Deals objects.
    /// </summary>
    public class OntraportDeals : OntraportBaseCustomObject<ApiDeal>, IOntraportDeals
    {
        public OntraportDeals(IApiRequestHelper apiRequest) : 
            base(apiRequest, "Deal", "Deals", "name")
        { }

    }
}
