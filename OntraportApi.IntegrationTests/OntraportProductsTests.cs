﻿using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportProductsTests : OntraportBaseDeleteTests<OntraportProducts, ApiProduct>
{
    public OntraportProductsTests(ITestOutputHelper output) :
        base(output, 1, "product1")
    {
    }


}
