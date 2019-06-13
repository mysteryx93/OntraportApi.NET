using System;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for Deals objects.
    /// </summary>
    public interface IOntraportDeals : IOntraportDeals<ApiDeal>
    {
    }

    /// <summary>
    /// Provides Ontraport API support for Deals objects.
    /// </summary>
    /// <typeparam name="T">A type deriving from ApiDeal exposing additional custom fields.</typeparam>
    public interface IOntraportDeals<T> : IOntraportBaseCustomObject<T>
        where T : ApiDeal
    {
    }
}
