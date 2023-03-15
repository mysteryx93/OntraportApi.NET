using System;
using System.Threading.Tasks;
using HanumanInstitute.Validators;
using Xunit;

namespace HanumanInstitute.OntraportApi.IntegrationTests.IdentityCore;

public class RoleManagerTests
{
    private readonly string[] _roles = new[] { "Admin", "Manager" };

    [Theory]
    [InlineData("Admin", "Admin")]
    [InlineData("admin", "Admin")]
    [InlineData("ADMIN", "Admin")]
    [InlineData("manager", "Manager")]
    public async Task FindByIdAsync_Valid_ReturnsRoleWithProperCase(string roleId, string expected)
    {
        using var c = new UserManagerContext(_roles);

        var result = await c.RoleManager.FindByIdAsync(roleId.ToStringInvariant()).ConfigureAwait(false);

        Assert.NotNull(result);
        Assert.Equal(expected, result.Id, StringComparer.InvariantCulture);
    }

    [Theory]
    [InlineData("admi")]
    [InlineData("v")]
    public async Task FindByIdAsync_Invalid_ReturnsNull(string roleId)
    {
        using var c = new UserManagerContext(_roles);

        var result = await c.RoleManager.FindByIdAsync(roleId.ToStringInvariant()).ConfigureAwait(false);

        Assert.Null(result);
    }

    [Theory]
    [InlineData("Admin", "Admin")]
    [InlineData("admin", "Admin")]
    [InlineData("ADMIN", "Admin")]
    [InlineData("manager", "Manager")]
    public async Task FindByNameAsync_Valid_ReturnsRoleWithProperCase(string roleId, string expected)
    {
        using var c = new UserManagerContext(_roles);

        var result = await c.RoleManager.FindByNameAsync(roleId.ToStringInvariant()).ConfigureAwait(false);

        Assert.NotNull(result);
        Assert.Equal(expected, result.Name, StringComparer.InvariantCulture);
    }

    [Theory]
    [InlineData("admi")]
    [InlineData("v")]
    public async Task FindByNameAsync_Invalid_ReturnsNull(string roleId)
    {
        using var c = new UserManagerContext(_roles);

        var result = await c.RoleManager.FindByNameAsync(roleId.ToStringInvariant()).ConfigureAwait(false);

        Assert.Null(result);
    }

    [Fact]
    public async Task FindByIdAsync_NoRoleDefined_ReturnsNull()
    {
        using var c = new UserManagerContext(null);

        var result = await c.RoleManager.FindByIdAsync("Admin").ConfigureAwait(false);

        Assert.Null(result);
    }
}
