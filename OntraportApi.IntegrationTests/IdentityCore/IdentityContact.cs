﻿using System;
using System.Collections.Generic;
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
        public virtual string IdentityPasswordHashKey => "f1824";
        /// <summary>
        /// Gets or sets the login password hash.
        /// </summary>
        public string IdentityPasswordHash { get => IdentityPasswordHashField.Value; set => IdentityPasswordHashField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date and time, in UTC, when any user lockout ends.
        /// </summary>
        public ApiPropertyDateTime IdentityLockoutEndField => _identityLockoutEndField ??= new ApiPropertyDateTime(this, IdentityLockoutEndKey);
        private ApiPropertyDateTime _identityLockoutEndField;
        public virtual string IdentityLockoutEndKey => "f1834";
        /// <summary>
        /// Gets or sets the date and time, in UTC, when any user lockout ends.
        /// </summary>
        public DateTimeOffset? IdentityLockoutEnd { get => IdentityLockoutEndField.Value; set => IdentityLockoutEndField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the number of failed login attempts for the current user.
        /// </summary>
        public ApiProperty<int> IdentityAccessFailedCountField => _identityAccessFailedCountField ??= new ApiProperty<int>(this, IdentityAccessFailedCountKey);
        private ApiProperty<int> _identityAccessFailedCountField;
        public virtual string IdentityAccessFailedCountKey => "f1835";
        /// <summary>
        /// Gets or sets the number of failed login attempts for the current user.
        /// </summary>
        public int? IdentityAccessFailedCount { get => IdentityAccessFailedCountField.Value; set => IdentityAccessFailedCountField.Value = value; }

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
        int IIdentityContact.IdentityAccessFailedCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        /// <summary>
        /// Gets or sets a flag indicating if the user could be locked out. Users can be locked out unless they are admins.
        /// </summary>
        public bool IdentityLockoutEnabled {
            get => IsAdmin == false;
            set { } 
        }
    }
}