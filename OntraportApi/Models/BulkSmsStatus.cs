using System;
using System.Collections.Generic;
using System.Text;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// A flag that indicates whether or not a contact is opted in to receive bulk texts.
    /// </summary>
    public enum BulkSmsStatus
    {
        OptedOut = 0,
        OptedIn = 1,
        DoubleOptIn = 2,
        HardBounce = -2
    }
}
