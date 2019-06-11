using System;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for Companies objects.
    /// </summary>
    public class OntraportCompanies : OntraportBaseCustomObject<ApiCompany>, IOntraportCompanies
    {
        public OntraportCompanies(IOntraportRequestHelper apiRequest) : 
            base(apiRequest, "Company", "Companies", "name")
        { }

    }
}
