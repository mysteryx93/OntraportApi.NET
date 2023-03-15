namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// A flag that indicates a contact's bulk email status.
/// </summary>
public enum BulkMailStatus
{
    TransactionalOnly = 0,
    OptedIn = 1,
    DoubleOptIn = 2,
    HardBounce = -2,
    UnderReview = -5
}
