using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests
{
    public class OntraportContactsTests : OntraportBaseCustomObjectTests<OntraportContacts<ApiContact>, ApiContact>
    {
        public OntraportContactsTests(ITestOutputHelper output) :
            base(output, 19, "a@test.com")
        {
        }

        [Fact]
        public async Task SelectAsync_EditString_GetChangesReturnsKey()
        {
            var api = SetupApi();

            var result = await api.SelectAsync(ValidId);

            result.AddressField.Value = "abc";
            var changes = result.GetChanges();
            Assert.Contains(changes, x => x.Key == result.AddressField.Key);
        }

        [Fact]
        public async Task SelectAsync_EditDateTimeOffset_GetChangesReturnsKey()
        {
            var api = SetupApi();

            var result = await api.SelectAsync(ValidId);

            result.BirthdayField.Value = DateTimeOffset.Now;
            var changes = result.GetChanges();
            Assert.Contains(changes, x => x.Key == result.BirthdayField.Key);
        }

        [Fact]
        public async Task SelectAsync_EditDouble_GetChangesReturnsKey()
        {
            var api = SetupApi();

            var result = await api.SelectAsync(ValidId);

            result.AffiliateAmountField.Value = 100;
            var changes = result.GetChanges();
            Assert.Contains(changes, x => x.Key == result.AffiliateAmountField.Key);
        }

        [Fact]
        public async Task CreateOrMergeAsync_EmailFirstName_ReturnsSameFirstName()
        {
            var api = SetupApi();
            var firstName = "cc2";

            var result = await api.CreateOrMergeAsync(new
            {
                email = "a@test.com",
                firstname = firstName
            });

            Assert.Equal(firstName, result.FirstName);
        }

        [Fact]
        public async Task CreateOrMergeContact_WithTypedObject_ObjectHasRightValues()
        {
            var api = SetupApi();
            var newName = "Etienne";
            var newStatus = SaleStatus.Committed;
            var contact = new ApiContact()
            {
                Email = "LogTest@test.com",
                FirstName = newName,
                LastName = "Charland"
            };
            contact.StatusField.Value = newStatus;

            var result = await api.CreateOrMergeAsync(contact.GetChanges());

            var newContact = await api.SelectAsync("typed@test.com");
            Assert.Equal(newStatus, newContact.StatusField.Value);
            Assert.Equal(newName, newContact.FirstNameField.Value);
        }

        [Fact]
        public async Task UpdateContact_WithTypedObject_ObjectHasRightValues()
        {
            var api = SetupApi();
            var newName = "Etienne";
            var newStatus = SaleStatus.DemoScheduled;
            var contact = await api.SelectAsync("typed@test.com");
            contact.FirstName = newName;
            contact.LastNameField.Value = "Charlandd";
            contact.StatusField.Value = newStatus;
            contact.DateLastActivityField.Value = new DateTimeOffset(2019, 6, 1, 1, 1, 1, TimeSpan.Zero);

            var result = await api.UpdateAsync(contact.Id.Value, contact.GetChanges());

            var newContact = await api.SelectAsync("typed@test.com");
            Assert.Equal(newStatus, newContact.StatusField.Value);
            Assert.Equal(newName, newContact.FirstName);
        }

        [Fact]
        public async Task DeleteAsync_ByEmail_ThrowsNoException()
        {
            var api = SetupApi();
            var email = "delete_by_emailtest@test.com";
            var obj = await api.CreateAsync(new ApiContact()
            {
                Email = email
            }.GetChanges());

            await api.DeleteAsync(new ApiSearchOptions().AddCondition("email", "=", email));

            // Should throw Object Not Found.
            await Assert.ThrowsAsync<HttpRequestException>(() => api.SelectAsync(obj.Id.Value));
        }
    }
}
