using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class OntraportObjectsTests
    {
        private const string SectionContact = "Contact Information";
        private const string SectionTest = "Test Section";
        private const int ValidContactId = 19;
        private const int ValidSequenceId = 1;
        private const int ValidTagId = 1;
        private const int ValidTagId2 = 3;

        private OntraportObjects SetupApi()
        {
            var config = new ConfigHelper().GetConfig();
            var requestHelper = new OntraportRequestHelper(config, new WebRequestService());
            return new OntraportObjects(requestHelper);
        }

        [Fact]
        public async Task CreateAsync_Contact_ReturnsResultWithData()
        {
            var api = SetupApi();

            var result = await api.CreateAsync(ApiObjectType.Contact);

            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData("Name1", "a@test.com")]
        public async Task CreateAsync_ContactWithNameEmail_ReturnsSameNameEmail(string firstname, string email)
        {
            var api = SetupApi();

            var result = await api.CreateAsync(ApiObjectType.Contact, new
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
            var api = SetupApi();

            var result = await api.CreateOrMergeAsync(ApiObjectType.Contact, false, new
            {
                email = "a@test.com"
            });

            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData("Name1", "a@test.com")]
        public async Task CreateOrMergeAsync_ContactWithNameEmailSetNameBlank_ReturnsNameBlank(string firstname, string email)
        {
            var api = SetupApi();

            await api.CreateOrMergeAsync(ApiObjectType.Contact, false, new
            {
                firstname,
                email
            });
            var result2 = await api.CreateOrMergeAsync(ApiObjectType.Contact, false, new
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
            var api = SetupApi();

            await api.CreateOrMergeAsync(ApiObjectType.Contact, false, new
            {
                firstname,
                email
            });
            var result2 = await api.CreateOrMergeAsync(ApiObjectType.Contact, true, new
            {
                firstname = "",
                email
            });

            Assert.False(result2.ContainsKey("firstname"));
        }

        [Fact]
        public async Task CreateFieldsAsync_FieldsList_ReturnsSuccessObject()
        {
            var api = SetupApi();
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

            var result = await api.CreateFieldsAsync(ApiObjectType.Contact, SectionTest, fields);

            Assert.Equal(2, result.Success.Count);
            await Task.WhenAll(result.Success.Keys.Select(x => api.DeleteFieldAsync(ApiObjectType.Contact, x)));
        }

        [Fact]
        public async Task SelectAsync_Contact_ReturnsResultWithData()
        {
            var api = SetupApi();
            var contact = await api.CreateOrMergeAsync(ApiObjectType.Contact, false, new { firstname = "aa", email = "a@test.com" });
            var contactId = int.Parse(contact["id"]);

            var result = await api.SelectAsync(ApiObjectType.Contact, contactId);

            Assert.NotEmpty(result);
            Assert.Equal(contactId.ToString(), result["id"]);
        }

        [Fact]
        public async Task SelectMultipleAsync_NoParam_SelectAllContacts()
        {
            var api = SetupApi();

            var result = await api.SelectMultipleAsync(ApiObjectType.Contact);

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task SelectMultipleAsync_ById_SelectThoseContacts()
        {
            var api = SetupApi();

            var result = await api.SelectMultipleAsync(ApiObjectType.Contact, new ApiSearchOptions(new[] { 19, 20 }));

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task SelectMultipleAsync_ByCondition_SelectMatchingContacts()
        {
            var api = SetupApi();

            var result = await api.SelectMultipleAsync(ApiObjectType.Contact, searchOptions:
                new ApiSearchOptions()
                    .AddCondition("email", "=", "a@test.com")
                    .AddCondition("firstname", "=", "a", false)
            );

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task SelectMultipleAsync_ByConditionNull_SelectMatchingContacts()
        {
            var api = SetupApi();

            var result = await api.SelectMultipleAsync(ApiObjectType.Contact, searchOptions:
                new ApiSearchOptions()
                    .AddCondition("lastname", "=", null)
            );

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task SelectMultipleAsync_ByConditionList_SelectMatchingContacts()
        {
            var api = SetupApi();

            var result = await api.SelectMultipleAsync(ApiObjectType.Contact, searchOptions:
                new ApiSearchOptions()
                    .AddConditionInList("id", new[] { 20, 21 })
            );

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task SelectByTagAsync_TagId_ReturnsList()
        {
            var api = SetupApi();

            var result = await api.SelectByTagAsync(ApiObjectType.Contact, tagId: 1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task SelectByTagAsync_TagName_ReturnsList()
        {
            var api = SetupApi();

            var result = await api.SelectByTagAsync(ApiObjectType.Contact, tagName: "tag1");

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetCountByTagAsync_Count_ReturnsCount()
        {
            var api = SetupApi();

            var result = await api.GetCountByTagAsync(ApiObjectType.Contact, tagId: 1);

            Assert.True(result > 0);
        }

        [Fact]
        public async Task GetObjectIdByEmailAsync_ValidEmail_ReturnsId()
        {
            var api = SetupApi();

            var result = await api.GetObjectIdByEmailAsync(ApiObjectType.Contact, "a@test.com");

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetObjectIdByEmailAllAsync_ValidEmail_ReturnsList()
        {
            var api = SetupApi();

            var result = await api.GetObjectIdByEmailAllAsync(ApiObjectType.Contact, "a@test.com");

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetAllMetadataAsync_NoParam_ReturnsData()
        {
            var api = SetupApi();

            var result = await api.GetAllMetadataAsync();

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetMetadataAsync_ByName_ReturnsData()
        {
            var api = SetupApi();

            var result = await api.GetMetadataAsync(ApiObjectType.Message);

            Assert.NotEmpty(result.Fields);
        }

        [Fact]
        public async Task GetCollectionInfoAsync_Contacts_ReturnsData()
        {
            var api = SetupApi();

            var result = await api.GetCollectionInfoAsync(ApiObjectType.Product);

            Assert.NotEmpty(result.ListFields);
        }

        [Fact]
        public async Task SelectAllFieldsAsync_All_ReturnsData()
        {
            var api = SetupApi();

            var result = await api.SelectAllFieldsAsync(ApiObjectType.Contact);

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task SelectFieldByNameAsync_WithFieldName_ReturnsData()
        {
            var api = SetupApi();

            var result = await api.SelectFieldByNameAsync(ApiObjectType.Contact, "firstname");

            Assert.NotNull(result);
        }

        [Fact]
        public async Task SelectFieldsBySectionAsync_WithSectionName_ReturnsData()
        {
            var api = SetupApi();

            var result = await api.SelectFieldsBySectionAsync(ApiObjectType.Contact, SectionContact);

            Assert.NotEmpty(result.Fields);
        }

        [Fact]
        public async Task UpdateAsync_SetName_ReturnsSameName()
        {
            var api = SetupApi();
            var name = "NewName";

            var result = await api.UpdateAsync(ApiObjectType.Contact, 19, new { firstname = name });

            Assert.Equal(name, result["firstname"]);
        }

        [Fact]
        public async Task UpdateFieldsAsync_NewFieldData_ResponseSuccess()
        {
            var api = SetupApi();
            var fields = new List<List<ApiFieldEditor>>
            {
                new List<ApiFieldEditor>() {
                    new ApiFieldEditor()
                    {
                        Field = "f1584",
                        //Alias = "Field1",
                        Type = ApiFieldType.drop
                    }.ListReplace(new[] { "a", "b", "c" })
                },
                new List<ApiFieldEditor>(),
                new List<ApiFieldEditor>() {
                    new ApiFieldEditor()
                    {
                        Field = "f1585",
                        //Alias = "Field2",
                        Type = ApiFieldType.check
                    }
                }
            };

            var result = await api.UpdateFieldsAsync(ApiObjectType.Contact, SectionTest, fields);

            // Server returns error!
            Assert.NotEmpty(result.Success);
        }

        [Fact]
        public async Task DeleteAsync_IdJustCreated_ThrowsNoException()
        {
            var api = SetupApi();
            var contact = await api.CreateAsync(ApiObjectType.Contact);
            var contactId = int.Parse(contact["id"]);

            await api.DeleteAsync(ApiObjectType.Contact, contactId);

            // Should throw Object Not Found.
            await Assert.ThrowsAsync<System.Net.WebException>(() => api.SelectAsync(ApiObjectType.Contact, contactId));
        }

        [Fact]
        public async Task DeleteMultipleAsync_IdJustCreated_NoException()
        {
            var api = SetupApi();
            var contact = await api.CreateAsync(ApiObjectType.Contact);
            var contactId = int.Parse(contact["id"]);

            await api.DeleteMultipleAsync(ApiObjectType.Contact, new ApiSearchOptions(new[] { contactId }));
        }

        [Fact]
        public async Task DeleteSectionAsync_NotEmpty_NoException()
        {
            var api = SetupApi();
            var section = "test1";
            await api.CreateFieldsAsync(ApiObjectType.Contact, section, null);

            await api.DeleteSectionAsync(ApiObjectType.Contact, section);
        }

        [Fact]
        public async Task DeleteFieldAsync_NotEmpty_NoException()
        {
            var api = SetupApi();
            var fields = new List<List<ApiFieldEditor>>()
            {
                new List<ApiFieldEditor>()
                {
                    new ApiFieldEditor()
                    {
                        Alias = "testfield",
                        Type = ApiFieldType.text
                    }
                }
            };
            var result = await api.CreateFieldsAsync(ApiObjectType.Contact, SectionTest, fields);
            var fieldName = result.Success.Keys.First();

            await api.DeleteFieldAsync(ApiObjectType.Contact, fieldName);
        }

        [Fact]
        public async Task AddToSequenceAsync_ValidIds_NoException()
        {
            var api = SetupApi();

            await api.AddToSequenceAsync(ApiObjectType.Contact, new[] { ValidSequenceId }, new ApiSearchOptions(ValidContactId));
        }

        [Fact]
        public async Task AddTagAsync_ValidIds_NoException()
        {
            var api = SetupApi();

            await api.AddTagAsync(ApiObjectType.Contact, new[] { ValidTagId, ValidTagId2 }, new ApiSearchOptions(ValidContactId));
        }

        [Fact]
        public async Task AddTagNamesAsync_ValidNames_NoException()
        {
            var api = SetupApi();

            await api.AddTagNamesAsync(ApiObjectType.Contact, new[] { "tag10", "tag11" }, new ApiSearchOptions(ValidContactId));
        }

        [Fact]
        public async Task AddToCampaignAsync_ValidIds_NoException()
        {
            var api = SetupApi();

            await api.AddToCampaignAsync(ApiObjectType.Contact, new[] { ValidSequenceId }, new ApiSearchOptions(ValidContactId));
        }


        [Fact]
        public async Task RemoveFromSequenceAsync_ValidIds_NoException()
        {
            var api = SetupApi();

            await api.RemoveFromSequenceAsync(ApiObjectType.Contact, new[] { ValidSequenceId }, new ApiSearchOptions(ValidContactId));
        }

        [Fact]
        public async Task RemoveTagAsync_ValidIds_NoException()
        {
            var api = SetupApi();

            await api.RemoveTagAsync(ApiObjectType.Contact, new[] { ValidTagId, ValidTagId2 }, new ApiSearchOptions(ValidContactId));
        }

        [Fact]
        public async Task RemoveTagNamesAsync_ValidNames_NoException()
        {
            var api = SetupApi();

            await api.RemoveTagNamesAsync(ApiObjectType.Contact, new[] { "tag10", "tag11" }, new ApiSearchOptions(ValidContactId));
        }

        [Fact]
        public async Task PauseRuleOrSequenceAsync_ValidIds_NoException()
        {
            var api = SetupApi();

            await api.PauseRuleOrSequenceAsync(ApiObjectType.Sequence, new ApiSearchOptions(ValidContactId));
        }

        [Fact]
        public async Task UnpauseRuleOrSequenceAsync_ValidIds_NoException()
        {
            var api = SetupApi();

            await api.UnpauseRuleOrSequenceAsync(ApiObjectType.Sequence, new ApiSearchOptions(ValidContactId));
        }
    }
}
