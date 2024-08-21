using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportMessagesTests(ITestOutputHelper output) : 
    OntraportBaseWriteTests<OntraportMessages, ApiMessage>(output, 2, "Message1");
