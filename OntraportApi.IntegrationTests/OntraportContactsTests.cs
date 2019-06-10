using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class OntraportContactsTests : OntraportBaseDeleteTests<OntraportContacts, ApiContact>
    {
        public OntraportContactsTests(ITestOutputHelper output) :
            base(output, 19)
        {
        }

        [Fact]
        public async Task SelectAsync_EditString_GetChangesReturnsKey()
        {
            var api = SetupApi();

            var result = await api.SelectAsync(_validId);

            result.Address.Value = "abc";
            var changes = result.GetChanges();
            Assert.Contains(changes, x => x.Key == result.Address.Key);
        }

        [Fact]
        public async Task SelectAsync_EditDateTimeOffset_GetChangesReturnsKey()
        {
            var api = SetupApi();

            var result = await api.SelectAsync(_validId);

            result.Birthday.Value = DateTimeOffset.Now;
            var changes = result.GetChanges();
            Assert.Contains(changes, x => x.Key == result.Birthday.Key);
        }

        [Fact]
        public async Task SelectAsync_EditDouble_GetChangesReturnsKey()
        {
            var api = SetupApi();

            var result = await api.SelectAsync(_validId);

            result.AffiliateAmount.Value = Math.PI;
            var changes = result.GetChanges();
            Assert.Contains(changes, x => x.Key == result.AffiliateAmount.Key);
        }

        [Fact]
        public async Task CreateOrMergeAsync_EmailFirstName_ReturnsSameFirstName()
        {
            var api = SetupApi();
            var firstName = "cc";

            var result = await api.CreateOrMergeAsync(new
            {
                email = "a@test.com",
                firstname = firstName
            });

            Assert.Equal(firstName, result.FirstNameValue);
        }

        [Fact]
        public async Task CreateOrMergeContact_WithTypedObject_ObjectHasRightValues()
        {
            var api = SetupApi();
            var newName = "Etienne2";
            var newStatus = SaleStatus.Consideration;
            var contact = new ApiContact()
            {
                EmailValue = "typed@test.com",
                FirstNameValue = newName,
                LastNameValue = "Charland"
            };
            contact.Status.Value = newStatus;

            var result = await api.CreateOrMergeAsync(contact.GetChanges());

            var newContact = await api.SelectAsync("typed@test.com");
            Assert.Equal(newStatus, newContact.Status.Value);
            Assert.Equal(newName, newContact.FirstName.Value);
        }

        [Fact]
        public async Task UpdateContact_WithTypedObject_ObjectHasRightValues()
        {
            var api = SetupApi();
            var newName = "Etienne";
            var newStatus = SaleStatus.DemoScheduled;
            var contact = await api.SelectAsync("typed@test.com");
            contact.FirstNameValue = newName;
            contact.LastName.Value = "Charlandd";
            contact.Status.Value = newStatus;
            contact.DateLastActivity.Value = new DateTimeOffset(2019, 6, 1, 1, 1, 1, TimeSpan.Zero);

            var result = await api.UpdateAsync(contact.Id.Value, contact.GetChanges());

            var newContact = await api.SelectAsync("typed@test.com");
            Assert.Equal(newStatus, newContact.Status.Value);
            Assert.Equal(newName, newContact.FirstNameValue);
        }
    }
}
