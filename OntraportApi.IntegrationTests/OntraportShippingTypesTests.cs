using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportShippingTypesTests : OntraportBaseDeleteTests<OntraportShippingTypes, ApiShippingType>
{
    public OntraportShippingTypesTests(ITestOutputHelper output) :
        base(output, 1, "shippingType1")
    {
    }
}
