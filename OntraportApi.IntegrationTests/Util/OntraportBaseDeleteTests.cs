using System;
using System.Net.Http;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Converters;
using HanumanInstitute.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests
{
    public abstract class OntraportBaseDeleteTests<T, TU> : OntraportBaseWriteTests<T, TU>
        where T : OntraportBaseDelete<TU, TU>
        where TU : ApiObject
    {
        public OntraportBaseDeleteTests(ITestOutputHelper output, int validId, string validKeyValue) : 
            base(output, validId, validKeyValue)
        {
        }

        [Fact]
        public async Task DeleteAsync_IdJustCreated_ThrowsNoException()
        {
            using var c = CreateContext();
            var obj = await c.Ontra.CreateAsync();

            await c.Ontra.DeleteAsync(obj.Id!.Value);

            Assert.Null(await c.Ontra.SelectAsync(obj.Id.Value));
        }

        [Fact]
        public async Task DeleteMultipleAsync_IdJustCreated_NoException()
        {
            using var c = CreateContext();
            var obj = await c.Ontra.CreateAsync();

            await c.Ontra.DeleteAsync(new ApiSearchOptions(obj.Id!.Value));

            Assert.Null(await c.Ontra.SelectAsync(obj.Id.Value));
        }
    }
}
