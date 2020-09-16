using System;
using System.Collections.Generic;
using HanumanInstitute.Validators;

namespace HanumanInstitute.OntraportApi.IdentityCore
{
    public class OntraportIdentityConfig
    {
        public OntraportIdentityConfig() { }

        public OntraportIdentityConfig(IList<string> validRoles)
        {
            ValidRoles.AddRange(validRoles);
        }

        /// <summary>
        /// Gets or sets the roles that are valid for this application.
        /// </summary>
        public IList<string> ValidRoles { get; } = new List<string>();
    }
}
