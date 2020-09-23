using System;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests
{
    public abstract class OntraportBaseWriteTests<T, TU> : OntraportBaseReadTests<T, TU>
        where T : OntraportBaseWrite<TU>
        where TU : ApiObject
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
            using var c = CreateContext();

            var result = await c.Ontra.CreateAsync();

            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task CreateAsync_ValidId_ReturnsData()
        {
            using var c = CreateContext();

            var result = await c.Ontra.UpdateAsync(ValidId, new {
                email = "c@test.com"
            });

            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task UpdateAsync_ValidId_ReturnsData()
        {
            using var c = CreateContext();

            var result = await c.Ontra.UpdateAsync(ValidId, new
            {
                email = "c@test.com"
            });

            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task SelectAsync_ByKeyValue_ReturnsData()
        {
            using var c = CreateContext();

            var result = await c.Ontra.SelectAsync(_validKeyValue!);

            Assert.NotEmpty(result.Data);
        }
    }
}
