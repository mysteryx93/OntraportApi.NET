using System;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class OntraportRulesTests : OntraportBaseDeleteTests<OntraportRules, ApiRule>
    {
        public OntraportRulesTests(ITestOutputHelper output) :
            base(output, 1, "rule1")
        {
        }


    }
}
