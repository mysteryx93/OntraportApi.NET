using System;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public abstract class OntraportBaseCustomObjectTests<T, U> : OntraportBaseDeleteTests<T, U>
        where T : OntraportBaseCustomObject<U>
        where U : ApiCustomObject
    {
        public OntraportBaseCustomObjectTests(ITestOutputHelper output, int validId) :
            base(output, validId)
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

            var result = await api.SelectCustomFieldsAsync();

            Assert.NotNull(result);
        }
    }
}
