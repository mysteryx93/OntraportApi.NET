using System;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// The contact's Sales Stage.
    /// </summary>
    public enum SaleStatus
    {
        Closed_Lost = 1,
        Closed_Won = 2,
        Committed = 3,
        Consideration = 4,
        DemoScheduled = 5,
        QualifiedLead = 6,
        NewProspect = 7
    }
}
