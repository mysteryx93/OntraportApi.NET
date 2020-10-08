using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests
{
    public class OntraportObjectsTests
    {
        private readonly ITestOutputHelper _output;

        public OntraportObjectsTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private const string SectionContact = "Contact Information";
        private const string SectionTest = "Test Section";
        private const int ValidContactId = 19;
        private const int ValidSequenceId = 1;
        private const int ValidTagId = 1;
        private const int ValidTagId2 = 3;

        protected OntraportContext<OntraportObjects> CreateContext() => new OntraportContext<OntraportObjects>(_output);

        [Fact]
        public async Task CreateAsync_Contact_ReturnsResultWithData()
        {
            using var c = CreateContext();

            var result = await c.Ontra.CreateAsync(ApiObjectType.Contact);

            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData("Name1", "a@test.com")]
        public async Task CreateAsync_ContactWithNameEmail_ReturnsSameNameEmail(string firstname, string email)
        {
            using var c = CreateContext();

            var result = await c.Ontra.CreateAsync(ApiObjectType.Contact, new
            {
                firstname,
                email
            });

            Assert.Equal(firstname, result["firstname"]);
            Assert.Equal(email, result["email"]);
        }

        [Fact]
        public async Task CreateOrMergeAsync_ContactWithEmail_ReturnsResultWithData()
        {
            using var c = CreateContext();

            var result = await c.Ontra.CreateOrMergeAsync(ApiObjectType.Contact, false, new
            {
                email = "a@test.com"
            });

            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData("Name1", "a@test.com")]
        public async Task CreateOrMergeAsync_ContactWithNameEmailSetNameBlank_ReturnsNameBlank(string firstname, string email)
        {
            using var c = CreateContext();

            await c.Ontra.CreateOrMergeAsync(ApiObjectType.Contact, false, new
            {
                firstname,
                email
            });
            var result2 = await c.Ontra.CreateOrMergeAsync(ApiObjectType.Contact, false, new
            {
                firstname = "",
                email
            });

            Assert.Empty(result2["firstname"]);
        }

        [Theory]
        [InlineData("Name1", "a@test.com")]
        public async Task CreateOrMergeAsync_ContactWithNameEmailSetBlankIgnore_NotReturnName(string firstname, string email)
        {
            using var c = CreateContext();

            await c.Ontra.CreateOrMergeAsync(ApiObjectType.Contact, false, new
            {
                firstname,
                email
            });
            var result2 = await c.Ontra.CreateOrMergeAsync(ApiObjectType.Contact, true, new
            {
                firstname = "",
                email
            });

            Assert.False(result2.ContainsKey("firstname"));
        }

        [Fact]
        public async Task CreateFieldsAsync_FieldsList_ReturnsSuccessObject()
        {
            using var c = CreateContext();
            var fields = new List<List<ApiFieldEditor>>
            {
                new List<ApiFieldEditor>() {
                    new ApiFieldEditor()
                    {
                        Alias = "FieldAdd5",
                        Type = ApiFieldType.drop
                    }
                },
                new List<ApiFieldEditor>(),
                new List<ApiFieldEditor>() {
                    new ApiFieldEditor()
                    {
                        Alias = "FieldAdd6",
                        Type = ApiFieldType.check
                    }
                }
            };

            var result = await c.Ontra.CreateFieldsAsync(ApiObjectType.Contact, SectionTest, fields);

            Assert.Equal(2, result.Success.Count);
            await Task.WhenAll(result.Success.Keys.Select(x => c.Ontra.DeleteFieldAsync(ApiObjectType.Contact, x)));
        }

        [Fact]
        public async Task SelectAsync_Contact_ReturnsResultWithData()
        {
            using var c = CreateContext();
            var contact = await c.Ontra.CreateOrMergeAsync(ApiObjectType.Contact, false, new { firstname = "aa", email = "a@test.com" });
            var contactId = int.Parse(contact["id"], CultureInfo.InvariantCulture);

            var result = await c.Ontra.SelectAsync(ApiObjectType.Contact, contactId);

            Assert.NotEmpty(result);
            Assert.Equal(contactId.ToString(CultureInfo.InvariantCulture), result["id"]);
        }

        [Fact]
        public async Task SelectByUniqueIdAsync_Contact_ReturnsResultWithData()
        {
            using var c = CreateContext();
            var contact = await c.Ontra.CreateOrMergeAsync(ApiObjectType.Contact, false, new { firstname = "aa", email = "a@test.com" });
            var contactUniqueId = int.Parse(contact["unique_id"], CultureInfo.InvariantCulture);

            var result = await c.Ontra.SelectByUniqueIdAsync(ApiObjectType.Contact, contactUniqueId);

            Assert.NotEmpty(result);
            Assert.Equal(contactUniqueId.ToString(CultureInfo.InvariantCulture), result["id"]);
        }

        [Fact]
        public async Task SelectMultipleAsync_NoParam_SelectAllContacts()
        {
            using var c = CreateContext();

            var result = await c.Ontra.SelectAsync(ApiObjectType.Contact);

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task SelectMultipleAsync_ById_SelectThoseContacts()
        {
            using var c = CreateContext();

            var result = await c.Ontra.SelectAsync(ApiObjectType.Contact, new ApiSearchOptions(new[] { 19, 20 }));

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task SelectMultipleAsync_ByCondition_SelectMatchingContacts()
        {
            using var c = CreateContext();

            var result = await c.Ontra.SelectAsync(ApiObjectType.Contact, searchOptions:
                new ApiSearchOptions()
                    .AddCondition("email", "=", "a@test.com")
                    .AddCondition("firstname", "=", "a", false)
            );

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task SelectMultipleAsync_ByConditionNull_SelectMatchingContacts()
        {
            using var c = CreateContext();

            var result = await c.Ontra.SelectAsync(ApiObjectType.Contact, searchOptions:
                new ApiSearchOptions()
                    .AddCondition("lastname", "=", null)
            );

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task SelectMultipleAsync_ByConditionList_SelectMatchingContacts()
        {
            using var c = CreateContext();

            var result = await c.Ontra.SelectAsync(ApiObjectType.Contact, searchOptions:
                new ApiSearchOptions()
                    .AddConditionInList("id", new[] { 20, 21 })
            );

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task SelectByTagAsync_TagId_ReturnsList()
        {
            using var c = CreateContext();

            var result = await c.Ontra.SelectByTagAsync(ApiObjectType.Contact, tagId: 1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task SelectByTagAsync_TagName_ReturnsList()
        {
            using var c = CreateContext();

            var result = await c.Ontra.SelectByTagAsync(ApiObjectType.Contact, tagName: "tag1");

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetCountByTagAsync_Count_ReturnsCount()
        {
            using var c = CreateContext();

            var result = await c.Ontra.GetCountByTagAsync(ApiObjectType.Contact, tagId: 1);

            Assert.True(result > 0);
        }

        [Fact]
        public async Task GetObjectIdByEmailAsync_ValidEmail_ReturnsId()
        {
            using var c = CreateContext();

            var result = await c.Ontra.GetObjectIdByEmailAsync(ApiObjectType.Contact, "a@test.com");

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetObjectIdByEmailAllAsync_ValidEmail_ReturnsList()
        {
            using var c = CreateContext();

            var result = await c.Ontra.GetObjectIdByEmailAllAsync(ApiObjectType.Contact, "a@test.com");

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetAllMetadataAsync_NoParam_ReturnsData()
        {
            using var c = CreateContext();

            var result = await c.Ontra.GetAllMetadataAsync();

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetMetadataAsync_ByName_ReturnsData()
        {
            using var c = CreateContext();

            var result = await c.Ontra.GetMetadataAsync(ApiObjectType.Message);

            Assert.NotEmpty(result.Fields);
        }

        [Fact]
        public async Task GetCollectionInfoAsync_Contacts_ReturnsData()
        {
            using var c = CreateContext();

            var result = await c.Ontra.GetCollectionInfoAsync(ApiObjectType.Product);

            Assert.NotEmpty(result.ListFields);
        }

        [Fact]
        public async Task SelectAllFieldsAsync_All_ReturnsData()
        {
            using var c = CreateContext();

            var result = await c.Ontra.SelectAllFieldsAsync(ApiObjectType.Contact);

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task SelectFieldByNameAsync_WithFieldName_ReturnsData()
        {
            using var c = CreateContext();

            var result = await c.Ontra.SelectFieldByNameAsync(ApiObjectType.Contact, "firstname");

            Assert.NotNull(result);
        }

        [Fact]
        public async Task SelectFieldsBySectionAsync_WithSectionName_ReturnsData()
        {
            using var c = CreateContext();

            var result = await c.Ontra.SelectFieldsBySectionAsync(ApiObjectType.Contact, SectionContact);

            Assert.NotEmpty(result.Fields);
        }

        [Fact]
        public async Task UpdateAsync_SetName_ReturnsSameName()
        {
            using var c = CreateContext();
            var name = "NewName4";

            var result = await c.Ontra.UpdateAsync(ApiObjectType.Contact, 19, new { firstname = name });

            Assert.Equal(name, result["firstname"]);
        }

        [Fact]
        public async Task UpdateFieldsAsync_NewFieldData_ResponseSuccess()
        {
            using var c = CreateContext();
            var fields = new List<List<ApiFieldEditor>>
            {
                new List<ApiFieldEditor>() {
                    new ApiFieldEditor()
                    {
                        //Field = "f1584",
                        Alias = "Field1",
                        Type = ApiFieldType.drop
                    }.ListReplace(new[] { "a", "b", "c" })
                },
                new List<ApiFieldEditor>(),
                new List<ApiFieldEditor>() {
                    new ApiFieldEditor()
                    {
                        //Field = "f1585",
                        Alias = "Field2",
                        Type = ApiFieldType.check
                    }
                }
            };

            var result = await c.Ontra.UpdateFieldsAsync(ApiObjectType.Contact, SectionTest, fields);

            // Server returns error!
            Assert.NotEmpty(result.Success);
        }

        [Fact]
        public async Task DeleteAsync_IdJustCreated_SelectReturnsNull()
        {
            using var c = CreateContext();
            var contact = await c.Ontra.CreateAsync(ApiObjectType.Contact);
            var contactId = int.Parse(contact["id"], CultureInfo.InvariantCulture);

            await c.Ontra.DeleteAsync(ApiObjectType.Contact, contactId);

            // Should throw Object Not Found.
            Assert.Null(await c.Ontra.SelectAsync(ApiObjectType.Contact, contactId));
        }

        [Fact]
        public async Task DeleteMultipleAsync_IdJustCreated_NoException()
        {
            using var c = CreateContext();
            var contact = await c.Ontra.CreateAsync(ApiObjectType.Contact);
            var contactId = int.Parse(contact["id"], CultureInfo.InvariantCulture);

            await c.Ontra.DeleteMultipleAsync(ApiObjectType.Contact, new ApiSearchOptions(new[] { contactId }));
        }

        [Fact]
        public async Task DeleteSectionAsync_NotEmpty_NoException()
        {
            using var c = CreateContext();
            var section = "test1";
            await c.Ontra.CreateFieldsAsync(ApiObjectType.Contact, section, null);

            await c.Ontra.DeleteSectionAsync(ApiObjectType.Contact, section);
        }

        [Fact]
        public async Task DeleteFieldAsync_NotEmpty_NoException()
        {
            using var c = CreateContext();
            var fields = new List<List<ApiFieldEditor>>()
            {
                new List<ApiFieldEditor>()
                {
                    new ApiFieldEditor()
                    {
                        Alias = "testfield2",
                        Type = ApiFieldType.text
                    }
                }
            };
            var result = await c.Ontra.CreateFieldsAsync(ApiObjectType.Contact, SectionTest, fields);
            var fieldName = result.Success.Keys.First();

            await c.Ontra.DeleteFieldAsync(ApiObjectType.Contact, fieldName);
        }

        [Fact]
        public async Task AddToSequenceAsync_ValidIds_NoException()
        {
            using var c = CreateContext();

            await c.Ontra.AddToSequenceAsync(ApiObjectType.Contact, new ApiSearchOptions(ValidContactId), new[] { ValidSequenceId });
        }

        [Fact]
        public async Task AddTagAsync_ValidIds_NoException()
        {
            using var c = CreateContext();

            await c.Ontra.AddTagAsync(ApiObjectType.Contact, new ApiSearchOptions(ValidContactId), new[] { ValidTagId, ValidTagId2 });
        }

        [Fact]
        public async Task AddTagNamesAsync_ValidNames_NoException()
        {
            using var c = CreateContext();

            await c.Ontra.AddTagNamesAsync(ApiObjectType.Contact, new ApiSearchOptions(ValidContactId), new[] { "tag10", "tag11" });
        }

        [Fact]
        public async Task AddToCampaignAsync_ValidIds_NoException()
        {
            using var c = CreateContext();

            await c.Ontra.AddToCampaignAsync(ApiObjectType.Contact, new ApiSearchOptions(ValidContactId), new[] { ValidSequenceId });
        }


        [Fact]
        public async Task RemoveFromSequenceAsync_ValidIds_NoException()
        {
            using var c = CreateContext();

            await c.Ontra.RemoveFromSequenceAsync(ApiObjectType.Contact, new ApiSearchOptions(ValidContactId), new[] { ValidSequenceId });
        }

        [Fact]
        public async Task RemoveTagAsync_ValidIds_NoException()
        {
            using var c = CreateContext();

            await c.Ontra.RemoveTagAsync(ApiObjectType.Contact, new ApiSearchOptions(ValidContactId), new[] { ValidTagId, ValidTagId2 });
        }

        [Fact]
        public async Task RemoveTagNamesAsync_ValidNames_NoException()
        {
            using var c = CreateContext();

            await c.Ontra.RemoveTagNamesAsync(ApiObjectType.Contact, new ApiSearchOptions(ValidContactId), new[] { "tag10", "tag11" });
        }

        [Fact]
        public async Task PauseRuleOrSequenceAsync_ValidIds_NoException()
        {
            using var c = CreateContext();

            await c.Ontra.PauseRuleOrSequenceAsync(ApiObjectType.Sequence, new ApiSearchOptions(ValidContactId));
        }

        [Fact]
        public async Task UnpauseRuleOrSequenceAsync_ValidIds_NoException()
        {
            using var c = CreateContext();

            await c.Ontra.UnpauseRuleOrSequenceAsync(ApiObjectType.Sequence, new ApiSearchOptions(ValidContactId));
        }
    }
}
