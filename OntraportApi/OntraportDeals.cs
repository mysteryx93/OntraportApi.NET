﻿using System;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for Deals objects.
    /// </summary>
    public class OntraportDeals : OntraportDeals<ApiDeal>, IOntraportDeals
    {
        public OntraportDeals(OntraportHttpClient apiRequest) :
            base(apiRequest)
        { }
    }

    /// <summary>
    /// Provides Ontraport API support for Deals objects.
    /// </summary>
    /// <typeparam name="T">A type deriving from ApiDeal exposing additional custom fields.</typeparam>
    public class OntraportDeals<T> : OntraportBaseCustomObject<T>, IOntraportDeals<T>
        where T : ApiDeal
    {
        public OntraportDeals(OntraportHttpClient apiRequest) : 
            base(apiRequest, "Deal", "Deals", "name")
        { }
    }
}
