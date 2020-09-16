using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HanumanInstitute.OntraportApi.IdentityCore
{
    public class OntraportIdentityUser : IdentityUser<int>
    {
        internal IList<string> Roles { get; set; } = new List<string>();
    }
}
