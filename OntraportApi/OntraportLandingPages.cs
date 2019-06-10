using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Newtonsoft.Json.Linq;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for LandingPage objects.
    /// Landing page objects contain the data for one-off web pages a prospect can land on after clicking on an online marketing call-to-action.
    /// We support professionally designed ONTRApage templates as well as redirects to other landing pages, "code mode" and legacy HTML pages.
    /// </summary>
    public class OntraportLandingPages : OntraportBaseRead<ApiLandingPage>, IOntraportLandingPages
    {
        public OntraportLandingPages(IApiRequestHelper apiRequest) : 
            base(apiRequest, "LandingPage", "LandingPages")
        { }

    }
}
