using System;
using System.Collections.Generic;

namespace HanumanInstitute.OntraportApi.IdentityCore
{
    /// <summary>
    /// This interface must be implemented by a class deriving from ApiContact or ApiCustomObject. The properties must be defined as Custom Fields to store the data.
    /// </summary>
    public interface IIdentityContact
    {
        /// <summary>
        /// Gets or sets a salted and hashed representation of the password for this user.
        /// </summary>
        public string? IdentityPasswordHash { get; set; }
        /// <summary>
        /// Gets or sets the date and time, in UTC, when any user lockout ends.
        /// </summary>
        public DateTimeOffset? IdentityLockoutEnd { get; set; }
        /// <summary>
        /// Gets or sets the number of failed login attempts for the current user.
        /// </summary>
        public int? IdentityAccessFailedCount { get; set; }
        /// <summary>
        /// Gets or sets a flag indicating if the user could be locked out.
        /// </summary>
        public bool? IdentityLockoutEnabled { get; set; }

        /// <summary>
        /// Returns whether the user is part of specified role.
        /// </summary>
        /// <param name="roleName">The name of the role.</param>
        public bool GetRole(string roleName);
        /// <summary>
        /// Adds or removes the user to/from specified role.
        /// </summary>
        /// <param name="roleName">The name of the role to add or remove.</param>
        /// <param name="value">True to add, False to remove.</param>
        public void SetRole(string roleName, bool value);
        /// <summary>
        /// Returns the list of all roles the user belongs to.
        /// </summary>
        public IList<string> Roles();
    }
}
