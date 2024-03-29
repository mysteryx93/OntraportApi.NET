﻿using System.Collections.Generic;
using HanumanInstitute.OntraportApi.Converters;
using HanumanInstitute.OntraportApi.Models;
using Xunit;

namespace HanumanInstitute.OntraportApi.UnitTests;

public class ApiPropertyDataBoolTests
{
    private readonly string _key = "key1";
    private readonly ApiObject _host = new ApiObject();

    private ApiPropertyBool SetupProperty() => new ApiPropertyBool(_host, _key);

    private void Set(string value) => _host.Data[_key] = value;

    public static IEnumerable<object[]> GetValues() => new[] {
        new object[] { "true", true },
        new object[] { "false", false },
    };

    public static IEnumerable<object[]> GetValues2() => new[] {
        new object[] { "True", true },
        new object[] { "False", false },
        new object[] { "0", false },
        new object[] { "1", true },
    };

    public static IEnumerable<object[]> GetValuesNull() => new[] {
        new object[] { "", null },
        new object[] { null, null },
    };

    [Theory]
    [MemberData(nameof(GetValues))]
    [MemberData(nameof(GetValues2))]
    public void Value_SetRawValue_ReturnsExpectedValue(string rawValue, bool? typedValue)
    {
        var prop = SetupProperty();
        Set(rawValue);

        var result = prop.Value;

        Assert.Equal(typedValue, result);
    }

    [Theory]
    [MemberData(nameof(GetValues))]
    public void Value_SetValue_StoresExpectedRawValue(string rawValue, bool? typedValue)
    {
        var prop = SetupProperty();

        prop.Value = typedValue;

        Assert.Equal(rawValue, prop.RawValue);
    }

    [Theory]
    [MemberData(nameof(GetValues))]
    [MemberData(nameof(GetValues2))]
#pragma warning disable xUnit1026 // typeValue not used
#pragma warning disable IDE0060   // typeValue not used
    public void HasValue_Set_ReturnsTrue(string rawValue, bool? _)
    {
        var prop = SetupProperty();
        Set(rawValue);

        var result = prop.HasValue;

        Assert.True(result);
    }

    [Theory]
    [MemberData(nameof(GetValuesNull))]
    public void Value_SetEmpty_ReturnsNull(string rawValue, bool? _)
    {
        var prop = SetupProperty();
        Set(rawValue);

        var result = prop.Value;

        Assert.Null(result);
    }
}
