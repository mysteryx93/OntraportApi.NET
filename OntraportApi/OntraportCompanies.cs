using System;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for Companies objects.
    /// </summary>
    public class OntraportCompanies : OntraportBaseCustomObject<ApiCompany>, IOntraportCompanies
    {
        public OntraportCompanies(IApiRequestHelper apiRequest) : 
            base(apiRequest, "Company", "Companies", "name")
        { }

        /// <summary>
        /// The ObjectTypeId of this object to use with the OntraportObjects class.
        /// </summary>
        public static int ObjectTypeId => _objectTypeId ?? (_objectTypeId = -1).Value;
        private static int? _objectTypeId;
    }
}
