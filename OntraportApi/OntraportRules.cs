using System;
using HanumanInstitute.OntraportApi.Models;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for Rule objects.
    /// The rule object was ONTRAPORT’s main automation component in the management of objects in various situations before the release of the 
    /// Campaign Builder. Rules are set to perform a user-specified “Action” when a certain "Event" occurs, which is also defined in the 
    /// category of “Triggers”, and such criteria in triggering a rule to act can be further detailed out through user-specified “Conditions”.
    /// </summary>
    public class OntraportRules : OntraportBaseDelete<ApiRule>, IOntraportRules
    {
        public OntraportRules(OntraportHttpClient apiRequest) : 
            base(apiRequest, "Rule", "Rules", ApiRule.NameKey)
        { }

    }
}
