using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportTransactionsTests(ITestOutputHelper output) : OntraportBaseReadTests<OntraportTransactions, ApiTransaction>(output, 1)
{
    private const int ValidOrder3Products = 142;

    [Fact]
    public async Task LogTransaction_Order_LoggedProperly()
    {
        using var c = CreateContext();
        var contactId = await c.OntraObjects.GetObjectIdByEmailAsync(ApiObjectType.Contact, "a@test.com");
        var offer = new ApiTransactionOffer()
            .AddProduct(1, 2, 100);

        var result = await c.Ontra.LogTransactionAsync(contactId.Value, offer);

        Assert.NotEqual(0, result);
    }
    
    [Fact]
    public async Task LogTransaction_Order3Products_LoggedProperly()
    {
        using var c = CreateContext();
        var contactId = await c.OntraObjects.GetObjectIdByEmailAsync(ApiObjectType.Contact, "a@test.com");
        var offer = new ApiTransactionOffer()
            .AddProduct(39, 1, 5)
            .AddProduct(40, 1, 5)
            .AddProduct(41, 1, 5);

        var result = await c.Ontra.LogTransactionAsync(contactId.Value, offer);

        Assert.NotEqual(0, result);
    }

    [Fact]
    public async Task SelectAsync_ValidId_ParsesOffer()
    {
        using var c = CreateContext();

        var result = await c.Ontra.SelectAsync(ValidId);

        Assert.NotNull(result.Offer);
        Assert.NotEmpty(result.Offer.Products);
    }
    
    [Fact]
    public async Task SelectAsync_ValidId3Products_ParsesOffer()
    {
        using var c = CreateContext();

        var result = await c.Ontra.SelectAsync(ValidId);

        Assert.NotNull(result.Offer);
        Assert.NotEmpty(result.Offer.Products);
    }
}
