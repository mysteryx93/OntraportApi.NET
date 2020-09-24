using System;
using HanumanInstitute.OntraportApi.Models;
using HanumanInstitute.OntraportApi.IdentityCore;
using System.Threading.Tasks;
using Xunit;
using HanumanInstitute.Validators;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests.IdentityCore
{
    public class UserManagerTests
    {
        private readonly ITestOutputHelper _output;

        public UserManagerTests(ITestOutputHelper output = null)
        {
            _output = output;
        }

        private readonly string[] _roles = new[] { "Admin", "Manager" };
        //private readonly string[] _roleAdmin = new[] { "Admin" };

        private const int ContactIdWithPassword = 118;
        private const int ContactIdNoPassword = 115;
        private const int ContactIdInvalid = 116;
        private const string ContactEmailWithPassword = "identity_withpass@test.com";
        private const string ContactEmailNoPassword = "identity_nopass@test.com";
        private const string ContactEmailInvalid = "identity_invalid@test.com";
        private const string Password = "bingo";

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("abc")]
        [InlineData("-----")]
        [InlineData("0.5")]
        public async Task FindByIdAsync_InvalidInt_ThrowsException(string contactId)
        {
            using var c = new UserManagerContext(_roles, _output);

            Task<OntraportIdentityUser> Act() => c.UserManager.FindByIdAsync(contactId.ToStringInvariant());

            await Assert.ThrowsAsync<ArgumentException>(Act);
        }

        [Theory]
        [InlineData(ContactIdNoPassword)]
        [InlineData(ContactIdInvalid)]
        public async Task FindByIdAsync_NoPassword_ReturnsNull(int contactId)
        {
            using var c = new UserManagerContext(_roles, _output);

            var result = await c.UserManager.FindByIdAsync(contactId.ToStringInvariant()).ConfigureAwait(false);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(ContactIdWithPassword)]
        public async Task FindByIdAsync_WithPassword_ReturnsIdentity(int contactId)
        {
            using var c = new UserManagerContext(_roles, _output);

            var result = await c.UserManager.FindByIdAsync(contactId.ToStringInvariant()).ConfigureAwait(false);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(ContactEmailNoPassword)]
        [InlineData(ContactEmailInvalid)]
        public async Task FindByNameAsync_EmailNoPassword_ReturnsNull(string email)
        {
            using var c = new UserManagerContext(_roles, _output);

            var result = await c.UserManager.FindByNameAsync(email).ConfigureAwait(false);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(ContactEmailWithPassword)]
        public async Task FindByNameAsync_EmailWithPassword_ReturnsIdentity(string email)
        {
            using var c = new UserManagerContext(_roles, _output);

            var result = await c.UserManager.FindByNameAsync(email).ConfigureAwait(false);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(ContactEmailWithPassword)]
        public async Task FindByNameAsync_UpperCaseEmailWithPassword_ReturnsIdentity(string email)
        {
            using var c = new UserManagerContext(_roles, _output);

            var result = await c.UserManager.FindByNameAsync(email.ToUpperInvariant()).ConfigureAwait(false);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(ContactEmailNoPassword)]
        [InlineData(ContactEmailInvalid)]
        public async Task FindByEmailAsync_EmailNoPassword_ReturnsNull(string email)
        {
            using var c = new UserManagerContext(_roles, _output);

            var result = await c.UserManager.FindByEmailAsync(email).ConfigureAwait(false);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(ContactEmailWithPassword)]
        public async Task FindByEmailAsync_EmailWithPassword_ReturnsIdentity(string email)
        {
            using var c = new UserManagerContext(_roles, _output);

            var result = await c.UserManager.FindByEmailAsync(email).ConfigureAwait(false);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(ContactEmailWithPassword)]
        public async Task FindByEmailAsync_UpperCaseEmailWithPassword_ReturnsIdentity(string email)
        {
            using var c = new UserManagerContext(_roles, _output);

            var result = await c.UserManager.FindByEmailAsync(email.ToUpperInvariant()).ConfigureAwait(false);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateAsync_NewEmail_IdReturned()
        {
            const string NewEmail = "CreateAsyncTest@test.com";
            using var c = new UserManagerContext(_roles, _output);
            var exist = await c.UserManager.FindByNameAsync(NewEmail);
            if (exist != null)
            {
                await c.UserManager.DeleteAsync(exist);
            }

            var user = new OntraportIdentityUser()
            {
                UserName = NewEmail,
                Email = NewEmail
            };
            var result = await c.UserManager.CreateAsync(user, Password);

            Assert.True(result.Succeeded);
            Assert.True(user.Id > 0);
        }

        [Fact]
        public async Task CreateAsync_ExistingEmail_ReturnsFailure()
        {
            const string NewEmail = "CreateAsyncDuplicate@test.com";
            using var c = new UserManagerContext(_roles, _output);

            var user = new OntraportIdentityUser()
            {
                UserName = NewEmail,
                Email = NewEmail
            };
            var result = await c.UserManager.CreateAsync(user, Password);

            Assert.False(result.Succeeded);
        }

        [Fact]
        public async Task DeleteAsync_ValidId_LeaveContactAndRemovePassword()
        {
            const string NewEmail = "DeleteAsync@test.com";
            using var c = new UserManagerContext(_roles, _output);
            var user = await c.FindOrCreateUserAsync(NewEmail, Password);

            var result = await c.UserManager.DeleteAsync(user);

            Assert.True(result.Succeeded);
            var exist = await c.OntraportContacts.SelectAsync(user.Id);
            Assert.NotNull(exist);
            Assert.Empty(exist.IdentityPasswordHash);
        }

        [Fact]
        public async Task DeleteAsync_InvalidId_ThrowsException()
        {
            const string NewEmail = "DeleteInvalid@test.com";
            using var c = new UserManagerContext(_roles, _output);
            var user = new OntraportIdentityUser()
            {
                Id = int.MaxValue,
                UserName = NewEmail,
                Email = NewEmail
            };

            Task<IdentityResult> Act() => c.UserManager.DeleteAsync(user);

            await Assert.ThrowsAsync<HttpRequestException>(Act);
        }

        [Fact]
        public async Task UpdateAsync_ExistingEmail_ReturnsFailure()
        {
            const string NewEmail = "UpdateAsync@test.com";
            using var c = new UserManagerContext(_roles, _output);
            var user = await c.FindOrCreateUserAsync(NewEmail, Password);

            await c.UserManager.ChangePasswordAsync(user, Password, Password);
            var result = await c.UserManager.UpdateAsync(user);

            Assert.True(result.Succeeded);
        }

        [Theory]
        [InlineData("Admin")]
        [InlineData("MANAGER")]
        public async Task AddToRoleAsync_Valid_IsInRole(string role)
        {
            const string NewEmail = "AddToRoleAsync@test.com";
            using var c = new UserManagerContext(_roles, _output);
            var user = await c.FindOrCreateUserAsync(NewEmail, Password);

            var result = await c.UserManager.AddToRoleAsync(user, role);

            Assert.True(await c.UserManager.IsInRoleAsync(user, role));
            await c.UserManager.DeleteAsync(user);
            Assert.True(result.Succeeded);
        }

        [Theory]
        [InlineData("aaa")]
        public async Task AddToRoleAsync_Invalid_IsInRole(string role)
        {
            const string NewEmail = "AddToRoleAsync@test.com";
            using var c = new UserManagerContext(_roles, _output);
            var user = await c.FindOrCreateUserAsync(NewEmail, Password);

            Task Act() => c.UserManager.AddToRoleAsync(user, role);

            await Assert.ThrowsAsync<ArgumentException>(Act);
        }

        [Theory]
        [InlineData("Admin")]
        [InlineData("MANAGER")]
        public async Task RemoveFromRoleAsync_Valid_IsInRole(string role)
        {
            const string NewEmail = "AddToRoleAsync@test.com";
            using var c = new UserManagerContext(_roles, _output);
            var user = await c.FindOrCreateUserAsync(NewEmail, Password);
            await c.UserManager.AddToRoleAsync(user, role);

            var result = await c.UserManager.RemoveFromRoleAsync(user, role);

            Assert.False(await c.UserManager.IsInRoleAsync(user, role));
            await c.UserManager.DeleteAsync(user);
            Assert.True(result.Succeeded);
        }

        [Fact]
        public async Task GetRolesAsync_TwoRoles_ReturnsBoth()
        {
            const string NewEmail = "AddToRoleAsync@test.com";
            using var c = new UserManagerContext(_roles, _output);
            var user = await c.FindOrCreateUserAsync(NewEmail, Password);
            await c.UserManager.AddToRoleAsync(user, _roles[0]);
            await c.UserManager.AddToRoleAsync(user, _roles[1]);

            var result = await c.UserManager.GetRolesAsync(user);

            Assert.Contains(_roles[0], result);
            Assert.Contains(_roles[1], result);
            await c.UserManager.DeleteAsync(user);
        }
    }
}
