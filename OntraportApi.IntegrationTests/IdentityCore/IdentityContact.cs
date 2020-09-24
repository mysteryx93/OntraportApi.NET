using System;
using System.Collections.Generic;
using System.Text;
using HanumanInstitute.OntraportApi.Converters;
using HanumanInstitute.OntraportApi.IdentityCore;
using HanumanInstitute.OntraportApi.Models;
using HanumanInstitute.Validators;

namespace HanumanInstitute.OntraportApi.IntegrationTests.IdentityCore
{
    public class IdentityContact : ApiContact, IIdentityContact
    {
        /// <summary>
        /// Returns a ApiProperty object to get or set the login password hash.
        /// </summary>
        public ApiPropertyString IdentityPasswordHashField => _identityPasswordHashField ??= new ApiPropertyString(this, IdentityPasswordHashKey);
        private ApiPropertyString _identityPasswordHashField;
        public const string IdentityPasswordHashKey = "f1824";
        /// <summary>
        /// Gets or sets the login password hash.
        /// </summary>
        public string IdentityPasswordHash { get => IdentityPasswordHashField.Value; set => IdentityPasswordHashField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set whether the user is an admin.
        /// </summary>
        public ApiPropertyBool IsAdminField => _isAdminField ??= new ApiPropertyBool(this, IsAdminKey);
        private ApiPropertyBool _isAdminField;
        public const string IsAdminKey = "f1825";
        /// <summary>
        /// Gets or sets whether the user is an admin.
        /// </summary>
        public bool? IsAdmin { get => IsAdminField.Value; set => IsAdminField.Value = value; }

        /// <summary>
        /// Additional role for testing.
        /// </summary>
        public ApiPropertyBool IsManagerField => _isManagerField ??= new ApiPropertyBool(this, IsManagerKey);
        private ApiPropertyBool _isManagerField;
        public const string IsManagerKey = "f1826";
        public bool? IsManager { get => IsManagerField.Value; set => IsManagerField.Value = value; }


        public bool GetRole(string roleName)
        {
            roleName.CheckNotNullOrEmpty(nameof(roleName));

            if (roleName.EqualsInvariant("ADMIN"))
            {
                return IsAdmin ?? false;
            }
            else if (roleName.EqualsInvariant("MANAGER"))
            {
                return IsManager ?? false;
            }
            return false;
        }

        public IList<string> Roles()
        {
            var result = new List<string>();
            if (IsAdmin == true)
            {
                result.Add("Admin");
            }
            if (IsManager == true)
            {
                result.Add("Manager");
            }
            return result;
        }

        public void SetRole(string roleName, bool value)
        {
            roleName.CheckNotNullOrEmpty(nameof(roleName));

            if (roleName.EqualsInvariant("ADMIN"))
            {
                IsAdmin = value;
            }
            else if (roleName.EqualsInvariant("MANAGER"))
            {
                IsManager = value;
            }
        }
    }
}
