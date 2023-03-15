using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using HanumanInstitute.OntraportApi.Converters;
using HanumanInstitute.OntraportApi.Models;
using Xunit;

namespace HanumanInstitute.OntraportApi.UnitTests;

public class ApiPropertyDataListTests
{
    private readonly string _key = "key1";
    private readonly ApiObject _host = new ApiObject();

    private ApiPropertyList SetupProperty() => new ApiPropertyList(_host, _key);

    private void Set(string value) => _host.Data[_key] = value;

    public static IEnumerable<object[]> GetValues() => new[] {
        new object[] { "*/**/*", Array.Empty<int>() },
        new object[] { "*/*1*/*", new[] { 1 } },
        new object[] { "*/*1*/*22*/*", new[] { 1, 22 } },
        new object[] { "*/*1*/*22*/*333*/*", new[] { 1, 22, 333 } },
    };

    [Theory]
    [MemberData(nameof(GetValues))]
    public void Value_SetRawValue_ReturnsExpectedValue(string rawValue, IEnumerable<int> typedValue)
    {
        var prop = SetupProperty();
        Set(rawValue);

        var result = prop.Value;

        Assert.Equal(typedValue, result);
    }

    [Theory]
    [InlineData("")]
    [InlineData("*/*")]
    public void Value_SetInvalid_ReturnsEmptyList(string rawValue)
    {
        var prop = SetupProperty();
        Set(rawValue);

        var result = prop.Value;

        Assert.Empty(result);
    }

    [Theory]
    [MemberData(nameof(GetValues))]
    public void Value_SetValue_StoresExpectedRawValue(string rawValue, IEnumerable<int> typedValue)
    {
        var prop = SetupProperty();

        foreach (var item in typedValue) { 
            prop.Value?.Add(item);
        }
        prop.Changed();

        Assert.Equal(rawValue, prop.RawValue);
    }

    [Theory]
    [MemberData(nameof(GetValues))]
    [SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "Reviewed: Unused")]
    public void HasValue_Set_ReturnsTrue(string rawValue, IEnumerable<int> _)
    {
        var prop = SetupProperty();
        Set(rawValue);

        var result = prop.HasValue;

        Assert.Equal(!string.IsNullOrEmpty(rawValue), result);
    }
}