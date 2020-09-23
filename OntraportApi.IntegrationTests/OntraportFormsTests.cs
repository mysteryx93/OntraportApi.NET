using System;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests
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
            using var c = CreateContext();

            var result = await c.Ontra.SelectSmartFormHtmlAsync(ValidId);

            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(1)]
        public async Task SelectAllFormBlocksAsync_ValidId_ReturnsString(int? page)
        {
            using var c = CreateContext();

            var result = await c.Ontra.SelectAllFormBlocksAsync(page);

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task SelectBlocksByFormNameAsync_ValidId_ReturnsString()
        {
            using var c = CreateContext();

            var result = await c.Ontra.SelectBlocksByFormNameAsync("OntraForm1");

            Assert.NotEmpty(result);
        }
    }
}
