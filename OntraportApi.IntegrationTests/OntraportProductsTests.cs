using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportProductsTests(ITestOutputHelper output) : 
    OntraportBaseDeleteTests<OntraportProducts, ApiProduct>(output, 1, "product1");
