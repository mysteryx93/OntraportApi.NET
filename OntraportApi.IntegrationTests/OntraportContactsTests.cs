using System;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportContactsTests : OntraportBaseCustomObjectTests<OntraportContacts<ApiContact>, ApiContact>
{
    public OntraportContactsTests(ITestOutputHelper output) :
        base(output, 19, "a@test.com")
    {
    }

    [Fact]
    public async Task SelectAsync_GroupId_ReturnsData()
    {
        using var c = CreateContext();

        var result = await c.Ontra.SelectAsync(new ApiSearchOptions() { GroupId = 1 });

        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task SelectAsync_EditString_GetChangesReturnsKey()
    {
        using var c = CreateContext();

        var result = await c.Ontra.SelectAsync(ValidId);

        result.AddressField.Value = "abc";
        var changes = result.GetChanges();
        Assert.Contains(changes, x => x.Key == result.AddressField.Key);
    }

    [Fact]
    public async Task SelectAsync_EditDateTimeOffset_GetChangesReturnsKey()
    {
        using var c = CreateContext();

        var result = await c.Ontra.SelectAsync(ValidId);

        result.BirthdayField.Value = DateTimeOffset.Now;
        var changes = result.GetChanges();
        Assert.Contains(changes, x => x.Key == result.BirthdayField.Key);
    }

    [Fact]
    public async Task SelectAsync_EditDouble_GetChangesReturnsKey()
    {
        using var c = CreateContext();

        var result = await c.Ontra.SelectAsync(ValidId);

        result.AffiliateAmountField.Value = 100;
        var changes = result.GetChanges();
        Assert.Contains(changes, x => x.Key == result.AffiliateAmountField.Key);
    }

    [Fact]
    public async Task CreateOrMergeAsync_EmailFirstName_ReturnsSameFirstName()
    {
        using var c = CreateContext();
        var firstName = "cc2";

        var result = await c.Ontra.CreateOrMergeAsync(new
        {
            email = "a@test.com",
            firstname = firstName
        });

        Assert.Equal(firstName, result.FirstName);
    }

    [Fact]
    public async Task CreateOrMergeContact_WithTypedObject_ObjectHasRightValues()
    {
        using var c = CreateContext();
        var email = "createormerge@test.com";
        var newName = "Etienne";
        var newStatus = SaleStatus.ClosedLost;
        var contact = new ApiContact()
        {
            Email = email,
            FirstName = newName,
            LastName = "Charland",
            Status = newStatus
        };

        await c.Ontra.CreateOrMergeAsync(contact.GetChanges());

        var newContact = await c.Ontra.SelectAsync(email);
        Assert.Equal(newStatus, newContact.StatusField.Value);
        Assert.Equal(newName, newContact.FirstNameField.Value);
    }

    [Fact]
    public async Task UpdateContact_WithTypedObject_ObjectHasRightValues()
    {
        using var c = CreateContext();
        var newName = "Etienne";
        var newStatus = SaleStatus.DemoScheduled;
        var contact = await c.Ontra.SelectAsync("typed@test.com");
        contact.FirstName = newName;
        contact.LastNameField.Value = "Charlandd";
        contact.StatusField.Value = newStatus;
        contact.DateLastActivityField.Value = new DateTimeOffset(2019, 6, 1, 1, 1, 1, TimeSpan.Zero);

        await c.Ontra.UpdateAsync(contact.Id!.Value, contact.GetChanges());

        var newContact = await c.Ontra.SelectAsync("typed@test.com");
        Assert.Equal(newStatus, newContact.StatusField.Value);
        Assert.Equal(newName, newContact.FirstName);
    }

    [Fact]
    public async Task DeleteAsync_ByEmail_SelectReturnsNull()
    {
        using var c = CreateContext();
        var email = "delete_by_emailtest@test.com";
        var obj = await c.Ontra.CreateAsync(new ApiContact()
        {
            Email = email
        }.GetChanges());

        await c.Ontra.DeleteAsync(new ApiSearchOptions().AddCondition("email", "=", email));
            
        Assert.Null(await c.Ontra.SelectAsync(obj.Id!.Value));
    }
}