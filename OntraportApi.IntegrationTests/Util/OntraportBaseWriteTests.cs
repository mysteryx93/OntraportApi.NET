using System;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public abstract class OntraportBaseWriteTests<T, U> : OntraportBaseReadTests<T, U>
        where T : OntraportBaseWrite<U>
        where U : ApiObject
    {
        public OntraportBaseWriteTests(ITestOutputHelper output, int validId) : 
            base(output, validId)
        {
        }

        [Fact]
        public async Task CreateAsync_Empty_ReturnsData()
        {
            var api = SetupApi();

            var result = await api.CreateAsync();

            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task CreateAsync_ValidId_ReturnsData()
        {
            var api = SetupApi();

            var result = await api.UpdateAsync(_validId, new {
                email = "c@test.com"
            });

            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task UpdateAsync_ValidId_ReturnsData()
        {
            var api = SetupApi();

            var result = await api.UpdateAsync(_validId, new
            {
                email = "c@test.com"
            });

            Assert.NotEmpty(result.Data);
        }
    }
}
