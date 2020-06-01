using System;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// The contact's Sales Stage.
    /// </summary>
    public enum SaleStatus
    {
        ClosedLost = 1,
        ClosedWon = 2,
        Committed = 3,
        Consideration = 4,
        DemoScheduled = 5,
        QualifiedLead = 6,
        NewProspect = 7
    }
}
