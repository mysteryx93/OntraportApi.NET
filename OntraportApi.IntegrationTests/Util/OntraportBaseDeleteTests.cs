using System;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Converters;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public abstract class OntraportBaseDeleteTests<T, U> : OntraportBaseWriteTests<T, U>
        where T : OntraportBaseDelete<U>
        where U : ApiObject
    {
        public OntraportBaseDeleteTests(ITestOutputHelper output, int validId, string validKeyValue) : 
            base(output, validId, validKeyValue)
        {
        }

        [Fact]
        public async Task DeleteAsync_IdJustCreated_ThrowsNoException()
        {
            var api = SetupApi();
            var obj = await api.CreateAsync();

            await api.DeleteAsync(obj.Id.Value);

            // Should throw Object Not Found.
            await Assert.ThrowsAsync<System.Net.WebException>(() => api.SelectAsync(obj.Id.Value));
        }

        [Fact]
        public async Task DeleteMultipleAsync_IdJustCreated_NoException()
        {
            var api = SetupApi();
            var obj = await api.CreateAsync();

            await api.DeleteMultipleAsync(new ApiSearchOptions(obj.Id.Value));

            // Should throw Object Not Found.
            await Assert.ThrowsAsync<System.Net.WebException>(() => api.SelectAsync(obj.Id.Value));
        }
    }
}
