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
        private readonly string _validKeyValue;

        public OntraportBaseWriteTests(ITestOutputHelper output, int validId, string validKeyValue) : 
            base(output, validId)
        {
            _validKeyValue = validKeyValue;
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

            var result = await api.UpdateAsync(ValidId, new {
                email = "c@test.com"
            });

            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task UpdateAsync_ValidId_ReturnsData()
        {
            var api = SetupApi();

            var result = await api.UpdateAsync(ValidId, new
            {
                email = "c@test.com"
            });

            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task SelectAsync_ByKeyValue_ReturnsData()
        {
            var api = SetupApi();

            var result = await api.SelectAsync(_validKeyValue);

            Assert.NotEmpty(result.Data);
        }
    }
}
