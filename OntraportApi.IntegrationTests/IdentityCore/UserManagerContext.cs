using System;
using System.Collections;
using System.Collections.Generic;
using HanumanInstitute.OntraportApi;
using HanumanInstitute.OntraportApi.IdentityCore;
using HanumanInstitute.OntraportApi.IntegrationTests;
using HanumanInstitute.OntraportApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using HanumanInstitute.Validators;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests.IdentityCore
{
    /// <summary>
    /// Provides a UserManager and all dependencies for testing.
    /// </summary>
    public class UserManagerContext : UserManagerContext<IdentityContact, OntraportIdentityUser, IdentityRole<string>>
    {
        public UserManagerContext(IList<string> validRoles = null, ITestOutputHelper output = null) : base(output)
        {
            if (validRoles != null)
            {
                Config.Value.ValidRoles.AddRange(validRoles);
            }
        }
    }

    /// <summary>
    /// Provides a UserManager and all dependencies for testing.
    /// </summary>
    public class UserManagerContext<TContact, TUser, TRole> : IDisposable
        where TContact : ApiContact, IIdentityContact, new()
        where TUser : OntraportIdentityUser, new()
        where TRole : IdentityRole<string>, new()
    {
        private readonly ITestOutputHelper _output;

        public UserManagerContext(ITestOutputHelper output = null)
        {
            if (output != null)
            {
                _output = output;
                AppDomain.CurrentDomain.UnhandledException += (s, e) => Dispose(true);
            }
        }

        public IOptions<OntraportIdentityConfig> Config => _config ??= Options.Create(new OntraportIdentityConfig());
        private IOptions<OntraportIdentityConfig> _config;

        public IOptions<IdentityOptions> IdentityOptions => _identityOptions ??= Options.Create(new IdentityOptions());
        private IOptions<IdentityOptions> _identityOptions;

        public UserManager<TUser> UserManager => _userManager ??= new UserManager<TUser>(UserStore, IdentityOptions, PasswordHasher, null, null, KeyNormalizer, ErrorDescriber, null, Mock.Of<ILogger<UserManager<TUser>>>());
        private UserManager<TUser> _userManager;

        public RoleManager<TRole> RoleManager => _roleManager ??= new RoleManager<TRole>(RoleStore, null, KeyNormalizer, ErrorDescriber, Mock.Of<ILogger<RoleManager<TRole>>>());
        private RoleManager<TRole> _roleManager;

        public IUserStore<TUser> UserStore => _userStore ??= new OntraportUserStore<TContact, TUser, TRole>(OntraportContacts, RoleStore);
        private IUserStore<TUser> _userStore;

        public IRoleStore<TRole> RoleStore => _roleStore ??= new OntraportRoleStore<TRole>(Config);
        private IRoleStore<TRole> _roleStore;

        public IPasswordHasher<TUser> PasswordHasher => _passwordHasher ??= new PasswordHasher<TUser>();
        private IPasswordHasher<TUser> _passwordHasher;

        public ILookupNormalizer KeyNormalizer => _keyNormalizer ??= new UpperInvariantLookupNormalizer();
        private ILookupNormalizer _keyNormalizer;

        public IdentityErrorDescriber ErrorDescriber => _errorDescriber ??= new IdentityErrorDescriber();
        private IdentityErrorDescriber _errorDescriber;

        public IOntraportContacts<TContact> OntraportContacts => _ontraportContacts ??= new OntraportContacts<TContact>(HttpClient, OntraportObjects);
        private IOntraportContacts<TContact> _ontraportContacts;

        public IOntraportObjects OntraportObjects => _ontraportObjects ??= new OntraportObjects(HttpClient);
        private IOntraportObjects _ontraportObjects;

        public OntraportHttpClient HttpClient => _httpClient ??= ConfigHelper.GetHttpClient(Log);
        private OntraportHttpClient _httpClient;

        public ILogger<OntraportHttpClient> Log => _log ??= new MockLogger<OntraportHttpClient>() { RecordResponses = false };
        private ILogger<OntraportHttpClient> _log;

        public async Task<TUser> FindOrCreateUserAsync(string email, string password)
        {
            var user = await UserManager.FindByNameAsync(email);
            if (user == null)
            {
                user = new TUser()
                {
                    UserName = email,
                    Email = email
                };
                await UserManager.CreateAsync(user, password);
            }
            return user;
        }



        private bool _disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _output?.WriteLine(Log.ToString());
                    _userStore?.Dispose();
                    _roleStore?.Dispose();
                    _userManager?.Dispose();
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
