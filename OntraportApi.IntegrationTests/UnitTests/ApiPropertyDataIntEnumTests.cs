using System.Collections.Generic;
using HanumanInstitute.OntraportApi.Converters;
using HanumanInstitute.OntraportApi.Models;
using Xunit;

namespace HanumanInstitute.OntraportApi.UnitTests;

public class ApiPropertyDataIntEnumTests
{
    private readonly string _key = "key1";
    private readonly ApiObject _host = new ApiObject();

    private ApiPropertyIntEnum<BulkMailStatus> SetupProperty() => new ApiPropertyIntEnum<BulkMailStatus>(_host, _key);

    private void Set(string value) => _host.Data[_key] = value;

    public static IEnumerable<object[]> GetValues() => new[] {
        new object[] { "0", BulkMailStatus.TransactionalOnly },
        new object[] { "1", BulkMailStatus.OptedIn },
        new object[] { "-2", BulkMailStatus.HardBounce }
    };

    [Theory]
    [MemberData(nameof(GetValues))]
    public void Value_SetRawValue_ReturnsExpectedValue(string rawValue, BulkMailStatus typedValue)
    {
        var prop = SetupProperty();
        Set(rawValue);

        var result = prop.Value;

        Assert.Equal(typedValue, result);
    }

    [Theory]
    [MemberData(nameof(GetValues))]
    public void Value_SetValue_StoresExpectedRawValue(string rawValue, BulkMailStatus typedValue)
    {
        var prop = SetupProperty();

        prop.Value = typedValue;

        Assert.Equal(rawValue, prop.RawValue);
    }

    [Theory]
    [MemberData(nameof(GetValues))]
#pragma warning disable xUnit1026 // typeValue not used
#pragma warning disable IDE0060   // typeValue not used
    public void HasValue_Set_ReturnsTrue(string rawValue, BulkMailStatus _)
    {
        var prop = SetupProperty();
        Set(rawValue);

        var result = prop.HasValue;

        Assert.True(result);
    }
}
