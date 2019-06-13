using System;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for Companies objects.
    /// </summary>
    public class OntraportCompanies : OntraportCompanies<ApiCompany>, IOntraportCompanies
    {
        public OntraportCompanies(OntraportHttpClient apiRequest) : base(apiRequest)
        { }
    }

    /// <summary>
    /// Provides Ontraport API support for Companies objects.
    /// </summary>
    /// <typeparam name="T">A type deriving from ApiCompany exposing additional custom fields.</typeparam>
    public class OntraportCompanies<T> : OntraportBaseCustomObject<T>, IOntraportCompanies<T>
        where T : ApiCompany
    {
        public OntraportCompanies(OntraportHttpClient apiRequest) : 
            base(apiRequest, "Company", "Companies", "name")
        { }

    }
}
