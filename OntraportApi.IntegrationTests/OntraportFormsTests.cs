using System;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class OntraportFormsTests : OntraportBaseReadTests<OntraportForms, ApiForm>
    {
        public OntraportFormsTests(ITestOutputHelper output) :
            base(output, 1)
        {
        }

        [Fact]
        public async Task SelectSmartFormHtmlAsync_ValidId_ReturnsString()
        {
            var api = SetupApi();

            var result = await api.SelectSmartFormHtmlAsync(_validId);

            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(1)]
        public async Task SelectAllFormBlocksAsync_ValidId_ReturnsString(int? page)
        {
            var api = SetupApi();

            var result = await api.SelectAllFormBlocksAsync(page);

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task SelectBlocksByFormNameAsync_ValidId_ReturnsString()
        {
            var api = SetupApi();

            var result = await api.SelectBlocksByFormNameAsync("OntraForm1");

            Assert.NotEmpty(result);
        }
    }
}
