using System.Collections.Generic;
using HanumanInstitute.Validators;

namespace HanumanInstitute.OntraportApi.IdentityCore;

public class OntraportIdentityConfig
{
    public OntraportIdentityConfig() { }

    /// <summary>
    /// Gets or sets the roles that are valid for this application.
    /// </summary>
    public ICollection<string> Roles { get; } = new List<string>();

    /// <summary>
    /// Adds specified role to the application.
    /// </summary>
    /// <param name="role">The role to add.</param>
    public OntraportIdentityConfig AddRole(string role)
    {
        Roles.Add(role);
        return this;
    }

    /// <summary>
    /// Adds specified roles to the application.
    /// </summary>
    /// <param name="roles">The roles to add.</param>
    public OntraportIdentityConfig AddRoles(IList<string> roles)
    {
        Roles.AddRange(roles);
        return this;
    }
}
