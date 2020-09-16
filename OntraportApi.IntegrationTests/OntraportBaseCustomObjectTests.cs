using System;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests
{
    public abstract class OntraportBaseCustomObjectTests<T, TU> : OntraportBaseDeleteTests<T, TU>
        where T : OntraportBaseCustomObject<TU, TU>
        where TU : ApiCustomObjectBase
    {
        public OntraportBaseCustomObjectTests(ITestOutputHelper output, int validId, string validKeyValue) :
            base(output, validId, validKeyValue)
        {
        }

        [Fact]
        public async Task CreateOrMergeAsync_ObjectWithEmail_ReturnsResultWithData()
        {
            var api = SetupApi();

            var result = await api.CreateOrMergeAsync(new
            {
                email = "a@test.com",
                firstname = "AAA"
            });

            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task SelectCustomFieldsAsync_NoArg_ReturnsData()
        {
            var api = SetupApi();

            var result = await api.GetCustomFieldsAsync();

            Assert.NotNull(result);
            foreach (var item in result.Fields)
            {
                Output.WriteLine($"{item.Key} {item.Value}");
            }
        }
    }
}
