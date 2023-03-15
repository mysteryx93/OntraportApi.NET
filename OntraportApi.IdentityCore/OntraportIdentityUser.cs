using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HanumanInstitute.OntraportApi.IdentityCore;

/// <summary>
/// Base IdentityUser class that stores the list of roles internally. You must use OntraportIdentityUser instead of IdentityUser.
/// </summary>
public class OntraportIdentityUser : IdentityUser<int>
{
    /// <summary>
    /// Gets or sets the internal roles cache.
    /// </summary>
    internal IList<string> Roles { get; } = new List<string>();
}
