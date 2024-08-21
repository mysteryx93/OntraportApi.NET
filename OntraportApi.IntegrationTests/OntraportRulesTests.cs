using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportRulesTest(ITestOutputHelper output) : 
    OntraportBaseDeleteTests<OntraportRules, ApiRule>(output, 1, "rule1");
