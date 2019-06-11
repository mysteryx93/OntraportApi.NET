using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Newtonsoft.Json.Linq;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for CouponCode objects.
    /// </summary>
    public class OntraportCouponCodes : OntraportBaseRead<ApiCouponCode>, IOntraportCouponCodes
    {
        public OntraportCouponCodes(IOntraportRequestHelper apiRequest) :
            base(apiRequest, "CouponCode", "CouponCodes")
        {
        }

    }
}
