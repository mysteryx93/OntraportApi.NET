using System;
using System.Collections.Generic;

namespace HanumanInstitute.OntraportApi.IdentityCore
{
    public interface IIdentityContact
    {
        public string? IdentityPasswordHash { get; set; }
        public bool GetRole(string roleName);
        public void SetRole(string roleName, bool value);
        public IList<string> Roles();
    }
}
