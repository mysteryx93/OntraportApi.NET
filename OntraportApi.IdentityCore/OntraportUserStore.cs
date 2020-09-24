using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;
using HanumanInstitute.Validators;
using Microsoft.AspNetCore.Identity;

namespace HanumanInstitute.OntraportApi.IdentityCore
{
    public class OntraportUserStore<TContact, TUser, TRole> :
                                    IUserStore<TUser>,
                                    IUserRoleStore<TUser>,
                                    IUserPasswordStore<TUser>,
                                    IUserEmailStore<TUser>
                                    //IUserLockoutStore<TUser>
        where TContact : ApiContact, IIdentityContact, new()
        where TUser : OntraportIdentityUser, new()
        where TRole : IdentityRole<string>, new()
    {
        private readonly IOntraportContacts<TContact> _ontraportContacts;
        private readonly IRoleStore<TRole> _roleStore;

        public OntraportUserStore(IOntraportContacts<TContact> ontraportContacts, IRoleStore<TRole> roleStore)
        {
            _ontraportContacts = ontraportContacts;
            _roleStore = roleStore;
        }

        private static TUser? GetUserFromContact(TContact? contact)
        {
            if (!string.IsNullOrEmpty(contact?.IdentityPasswordHash))
            {
                var result = new TUser()
                {
                    Id = contact.Id!.Value,
                    UserName = contact.Email,
                    Email = contact.Email,
                    PasswordHash = contact.IdentityPasswordHash
                };
                result.Roles.AddRange(contact.Roles());
                return result;
            }
            return null;
        }

        // *** IUserStore ***

        /// <summary>
        /// Creates the specified user in the user store.
        /// </summary>
        /// <param name="user">The user to create.</param>
        /// <param name="cancellationToken">The CancellationToken used to propagate notifications that the operation should be canceled.</param>
        /// <returns>An IdentityResult containing the creation result.</returns>
        /// <exception cref="System.Net.Http.HttpRequestException">An HTTP error occured while communicating with Ontraport.</exception>
        /// <exception cref="System.OperationCanceledException">The task timed out or was cancelled.</exception>
        public async Task<IdentityResult> CreateAsync(TUser user, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            user.NormalizedUserName.CheckNotNullOrEmpty(nameof(user.NormalizedUserName));
            user.PasswordHash.CheckNotNullOrEmpty(nameof(user.PasswordHash));
            // user.UserRole.CheckNotNullOrEmpty(nameof(user.UserRole));

            // Check if user account already exists.
            var contact = await _ontraportContacts.SelectAsync(user.NormalizedUserName, cancellationToken).ConfigureAwait(false);
            if (!string.IsNullOrEmpty(contact?.IdentityPasswordHash))
            {
                return IdentityResult.Failed(new IdentityError() { Description = "There is already an account with that email address." });
            }

            // Add password hash.
            contact = new TContact()
            {
                Email = user.NormalizedUserName,
                IdentityPasswordHash = user.PasswordHash
                // UserRole = user.UserRole
            };

            var newContact = await _ontraportContacts.CreateOrMergeAsync(contact.GetChanges(), cancellationToken).ConfigureAwait(false);
            if (newContact?.Id != null)
            {
                // Get the ID of the updated contact.
                user.Id = newContact.Id.Value;
            }
            return IdentityResult.Success;
        }

        /// <summary>
        /// Deletes the specified user from the user store.
        /// </summary>
        /// <param name="user">The user to delete.</param>
        /// <param name="cancellationToken">The CancellationToken used to propagate notifications that the operation should be canceled.</param>
        /// <returns>An IdentityResult containing the deletion result.</returns>
        /// <exception cref="System.Net.Http.HttpRequestException">An HTTP error occured while communicating with Ontraport.</exception>
        /// <exception cref="System.OperationCanceledException">The task timed out or was cancelled.</exception>
        public async Task<IdentityResult> DeleteAsync(TUser user, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            user.Id.CheckRange(nameof(user.Id), min: 1);

            // Remove password hash.
            var contact = new TContact()
            {
                IdentityPasswordHash = string.Empty
            };

            // Remove roles.
            var roles = await GetRolesAsync(user, cancellationToken).ConfigureAwait(false);
            foreach (var item in roles.ToList())
            {
                await RemoveFromRoleAsync(user, item, cancellationToken).ConfigureAwait(false);
            }

            // Update contact.
            var newContact = await _ontraportContacts.UpdateAsync(user.Id, contact.GetChanges(), cancellationToken).ConfigureAwait(false);
            if (newContact == null)
            {
                var msg = "There is no account with ID {0}.".FormatInvariant(user.Id);
                return IdentityResult.Failed(new IdentityError() { Description = msg });
            }
            return IdentityResult.Success;
        }

        /// <summary>
        /// Updates the specified user in the user store.
        /// </summary>
        /// <param name="user">The user to update.</param>
        /// <param name="cancellationToken">The CancellationToken used to propagate notifications that the operation should be canceled.</param>
        /// <returns>An IdentityResult containing the update result.</returns>
        /// <exception cref="System.Net.Http.HttpRequestException">An HTTP error occured while communicating with Ontraport.</exception>
        /// <exception cref="System.OperationCanceledException">The task timed out or was cancelled.</exception>
        public async Task<IdentityResult> UpdateAsync(TUser user, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            user.Id.CheckRange(nameof(user.Id), min: 1);

            // Update password hash.
            var contact = new TContact()
            {
                IdentityPasswordHash = user.PasswordHash
            };
            var newContact = await _ontraportContacts.UpdateAsync(user.Id, contact.GetChanges(), cancellationToken).ConfigureAwait(false);
            if (newContact == null)
            {
                var msg = "There is no account with ID {0}.".FormatInvariant(user.Id);
                return IdentityResult.Failed(new IdentityError() { Description = msg });
            }
            return IdentityResult.Success;
        }

        /// <summary>
        /// Returns the user with specified email.
        /// </summary>
        /// <param name="userId">The Ontraport ID of the user.</param>
        /// <param name="cancellationToken">The CancellationToken used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The user with specified ID, or null.</returns>
        /// <exception cref="System.Net.Http.HttpRequestException">An HTTP error occured while communicating with Ontraport.</exception>
        /// <exception cref="System.OperationCanceledException">The task timed out or was cancelled.</exception>
        [return: MaybeNull]
        public async Task<TUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var id = userId.Parse<int>();
            if (id == null)
            {
                throw new ArgumentException("userId is not a valid ID.", nameof(userId));
            }

            var contact = await _ontraportContacts.SelectAsync(id.Value, cancellationToken).ConfigureAwait(false);
            return GetUserFromContact(contact)!;
        }

        /// <summary>
        /// Returns the user with specified email.
        /// </summary>
        /// <param name="normalizedUserName">The email of the user.</param>
        /// <param name="cancellationToken">The CancellationToken used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The user with specified ID, or null.</returns>
        /// <exception cref="System.Net.Http.HttpRequestException">An HTTP error occured while communicating with Ontraport.</exception>
        /// <exception cref="System.OperationCanceledException">The task timed out or was cancelled.</exception>
        [return: MaybeNull]
        public Task<TUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken) =>
            FindByEmailAsync(normalizedUserName, cancellationToken);

        public Task<string> GetNormalizedUserNameAsync(TUser user, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetUserIdAsync(TUser user, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            return Task.FromResult(user.Id.ToStringInvariant());
        }

        public Task<string> GetUserNameAsync(TUser user, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            return Task.FromResult(user.UserName);
        }

        public Task SetNormalizedUserNameAsync(TUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            normalizedName.CheckNotNullOrEmpty(nameof(normalizedName));

            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(TUser user, string userName, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            userName.CheckNotNullOrEmpty(nameof(userName));

            user.UserName = userName;
            return Task.CompletedTask;
        }


        // *** IUserPasswordStore ***

        public Task SetPasswordHashAsync(TUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            passwordHash.CheckNotNullOrEmpty(nameof(passwordHash));

            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(TUser user, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(TUser user, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            return Task.FromResult(user.PasswordHash.HasValue());
        }


        // *** IUserEmailStore ***

        public Task SetEmailAsync(TUser user, string email, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            email.CheckNotNullOrEmpty(nameof(email));

            user.Email = email;
            return Task.CompletedTask;
        }

        public Task<string> GetEmailAsync(TUser user, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(TUser user, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            return Task.FromResult(user.EmailConfirmed);
        }

        public Task SetEmailConfirmedAsync(TUser user, bool confirmed, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            user.EmailConfirmed = confirmed;
            return Task.CompletedTask;
        }

        [return: MaybeNull]
        public async Task<TUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            normalizedEmail.CheckNotNullOrEmpty(nameof(normalizedEmail));

            var contact = await _ontraportContacts.SelectAsync(normalizedEmail, cancellationToken).ConfigureAwait(false);
            return GetUserFromContact(contact)!;
        }

        public Task<string> GetNormalizedEmailAsync(TUser user, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            return Task.FromResult(user.NormalizedEmail);
        }

        public Task SetNormalizedEmailAsync(TUser user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            normalizedEmail.CheckNotNullOrEmpty(nameof(normalizedEmail));

            user.NormalizedEmail = normalizedEmail;
            return Task.CompletedTask;
        }


        // *** IUserRoleStore ***

        public Task AddToRoleAsync(TUser user, string roleName, CancellationToken cancellationToken) =>
            SetRoleValueAsync(user, roleName, true, cancellationToken);

        public Task RemoveFromRoleAsync(TUser user, string roleName, CancellationToken cancellationToken) =>
            SetRoleValueAsync(user, roleName, false, cancellationToken);

        private async Task SetRoleValueAsync(TUser user, string roleName, bool newValue, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            roleName.CheckNotNullOrEmpty(nameof(roleName));

            // Validate role name.
            var role = await _roleStore.FindByIdAsync(roleName, cancellationToken).ConfigureAwait(false);
            if (role == null)
            {
                throw new ArgumentException("roleName value '{0}' is not valid role name.".FormatInvariant(roleName));
            }

            // Add/remove from Ontraport.
            var contact = new TContact();
            contact.SetRole(roleName, newValue);
            var result = await _ontraportContacts.UpdateAsync(user.Id, contact.GetChanges(), cancellationToken).ConfigureAwait(false);
            if (result?.Id == null)
            {
                throw new InvalidOperationException("Could not update contact with ID {0}".FormatInvariant(user.Id));
            }

            // Add/remove role in memory.
            lock (user.Roles)
            {
                if (newValue && !user.Roles.Contains(role.Id))
                {
                    user.Roles.Add(role.Id);
                }
                else if (!newValue && user.Roles.Contains(role.Id))
                {
                    user.Roles.Remove(role.Id);
                }
            }
        }

        public Task<IList<string>> GetRolesAsync(TUser user, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            return Task.FromResult(user.Roles.AsReadOnly());
        }

        public Task<bool> IsInRoleAsync(TUser user, string roleName, CancellationToken cancellationToken)
        {
            user.CheckNotNull(nameof(user));
            roleName.CheckNotNullOrEmpty(nameof(roleName));

            var result = user.Roles.Any(x => x.EqualsInvariant(roleName));
            return Task.FromResult(result);
        }

        public virtual Task<IList<TUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            // It can't be done here. If you want the list, you must query the database manually.
            throw new NotImplementedException();
        }


        // *** IUserLockoutStore ***

        public Task<DateTimeOffset?> GetLockoutEndDateAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(TUser user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetLockoutEnabledAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(TUser user, bool enabled, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }



        private bool _disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
