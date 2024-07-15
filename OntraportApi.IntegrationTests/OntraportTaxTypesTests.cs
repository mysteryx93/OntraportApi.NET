using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportTaxTypesTests : OntraportBaseDeleteTests<OntraportTaxTypes, ApiTaxType>
{
    public OntraportTaxTypesTests(ITestOutputHelper output) :
        base(output, 1, "taxType1")
    {
    }
}
