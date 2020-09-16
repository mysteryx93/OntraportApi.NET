using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using HanumanInstitute.Validators;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace HanumanInstitute.OntraportApi.IdentityCore
{
    /// <summary>
    /// Role store for Ontraport-based authentication. Roles collection is read-only and must be defined using IOptions&lt;OntraportIdentityConfig>
    /// </summary>
    /// <typeparam name="TRole">The type of IdenityRole&lt;string>.</typeparam>
    public class OntraportRoleStore<TRole> : IRoleStore<TRole>
        where TRole : IdentityRole<string>, new()
    {
        private readonly IOptions<OntraportIdentityConfig> _config;

        public OntraportRoleStore(IOptions<OntraportIdentityConfig> config)
        {
            _config = config;
        }

        private TRole? FindRole(string roleId)
        {
            var roleName = _config.Value.ValidRoles.FirstOrDefault(x => x.EqualsInvariant(roleId));
            if (roleName != null)
            {
                return new TRole()
                {
                    Id = roleName,
                    Name = roleName
                };
            }
            return null;
        }

        public Task<IdentityResult> CreateAsync(TRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(TRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(TRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [return: MaybeNull]
        public Task<TRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            roleId.CheckNotNullOrEmpty(nameof(roleId));
            return Task.FromResult(FindRole(roleId))!;
        }

        [return: MaybeNull]
        public Task<TRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            normalizedRoleName.CheckNotNullOrEmpty(nameof(normalizedRoleName));
            return Task.FromResult(FindRole(normalizedRoleName))!;
        }

        public Task<string> GetNormalizedRoleNameAsync(TRole role, CancellationToken cancellationToken)
        {
            role.CheckNotNull(nameof(role));
            return Task.FromResult(role.NormalizedName);
        }

        public Task<string> GetRoleIdAsync(TRole role, CancellationToken cancellationToken)
        {
            role.CheckNotNull(nameof(role));
            return Task.FromResult(role.Id);
        }

        public Task<string> GetRoleNameAsync(TRole role, CancellationToken cancellationToken)
        {
            role.CheckNotNull(nameof(role));
            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(TRole role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetRoleNameAsync(TRole role, string roleName, CancellationToken cancellationToken)
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

