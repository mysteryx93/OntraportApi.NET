using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Converters;
using HanumanInstitute.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public abstract class OntraportBaseReadTests<T, TU>
    where T : OntraportBaseRead<TU, TU>
    where TU : ApiObject
{
    protected ITestOutputHelper Output { get; private set; }
    protected int ValidId { get; private set; }

    public OntraportBaseReadTests(ITestOutputHelper output, int validId)
    {
        Output = output;
        ValidId = validId;
    }

    /// <summary>
    /// Creates a context that initializes all classes required for Ontraport API tests
    /// </summary>
    protected OntraportContext<T> CreateContext() => new OntraportContext<T>(Output);

    [Fact]
    public async Task SelectAsync_ValidId_ReturnsData()
    {
        using var c = CreateContext();

        var result = await c.Ontra.SelectAsync(ValidId);

        Assert.NotEmpty(result?.Data);
    }

    [Fact]
    public async Task SelectMultipleAsync_ValidId_ReturnsData()
    {
        using var c = CreateContext();

        var result = await c.Ontra.SelectAsync(new ApiSearchOptions(ValidId));

        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task SelectMultipleAsync_NoArgs_ReturnsAll()
    {
        using var c = CreateContext();

        var result = await c.Ontra.SelectAsync();

        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task SelectMetadataAsync_NoArg_ReturnsData()
    {
        using var c = CreateContext();

        var result = await c.Ontra.GetMetadataAsync();

        Assert.NotEmpty(result.Fields);
    }

    [Fact]
    public async Task SelectCollectionInfoAsync_NoArg_ReturnsData()
    {
        using var c = CreateContext();

        var result = await c.Ontra.GetCollectionInfoAsync();

        Assert.NotEmpty(result.ListFields);
    }

    [Fact]
    public async Task SelectAsync_ValidId_AllPropertiesHaveKey()
    {
        using var c = CreateContext();
        var hasError = false;

        var result = await c.Ontra.SelectAsync(ValidId);

        foreach (var propInfo in result.GetType().GetProperties())
        {
            if (IsGenericTypeOf(typeof(ApiPropertyBase<,>), propInfo.PropertyType))
            {
                var prop = propInfo.GetValue(result);
                var hasKeyInfo = prop!.GetType().GetProperty("HasKey");
                if (hasKeyInfo != null)
                {
                    var hasKey = (bool)hasKeyInfo.GetValue(prop)!;
                    if (!hasKey)
                    {
                        hasError = true;
                        var keyInfo = prop.GetType().GetProperty("Key");
                        var key = keyInfo?.GetValue(prop);
                        Output.WriteLine(key?.ToString());
                    }
                }
            }
        }
        Output.WriteLine(string.Empty);
        Assert.False(hasError, "Some keys are not present in the dictionary and have been listed in output.");
    }

    [Fact]
    public async Task SelectAsync_ValidId_AllApiPropertiesEndWithField()
    {
        using var c = CreateContext();
        var hasError = false;

        var result = await c.Ontra.SelectAsync(ValidId);

        foreach (var propInfo in result.GetType().GetProperties())
        {
            if (IsGenericTypeOf(typeof(ApiPropertyBase<,>), propInfo.PropertyType))
            {
                if (!propInfo.Name.EndsWith("Field", StringComparison.InvariantCulture))
                {
                    hasError = true;
                    Output.WriteLine(propInfo.Name);
                }
            }
        }
        Output.WriteLine(string.Empty);
        Assert.False(hasError, "Some ApiProperty members don't end with Field.");
    }

    [Fact]
    public async Task SelectAsync_ValidId_AllFieldPropertiesHaveMatchingValueProperty()
    {
        using var c = CreateContext();
        var hasError = false;

        var result = await c.Ontra.SelectAsync(ValidId);

        foreach (var propInfo in result.GetType().GetProperties())
        {
            if (IsGenericTypeOf(typeof(ApiPropertyBase<,>), propInfo.PropertyType))
            {
                var valuePropName = propInfo.Name.Substring(0, propInfo.Name.Length - "Field".Length);
                var valueProp = result.GetType().GetProperty(valuePropName);

                if (valueProp == null)
                {
                    hasError = true;
                    Output.WriteLine(propInfo.Name);
                }
            }
        }
        Output.WriteLine(string.Empty);
        Assert.False(hasError, "Some Field properties don't have a matching value property without 'Field'.");
    }

    private bool IsGenericTypeOf(Type genericType, Type someType)
    {
        if (someType.IsGenericType
            && genericType == someType.GetGenericTypeDefinition()) return true;

        return someType.BaseType != null
               && IsGenericTypeOf(genericType, someType.BaseType);
    }

    [Fact]
    public async Task SelectAsync_ValidId_AllKeysHaveProperties()
    {
        using var c = CreateContext();
        var hasError = false;

        var result = await c.Ontra.SelectAsync(ValidId);

        var propList = GetAllFieldProperties(result);
        var customFieldRegex = new Regex("^f[0-9]{4}$");
        foreach (var key in result.Data.Keys)
        {
            if (!customFieldRegex.Match(key).Success)
            {
                if (!propList.Contains(key))
                {
                    hasError = true;
                    Output.WriteLine($"{key} :      {result.Data[key]}");
                }
            }
        }
        Output.WriteLine(string.Empty);
        Assert.False(hasError, "Some dictionary keys don't have properties and have been listed in output.");
    }

    private List<string> GetAllFieldProperties(TU obj)
    {
        var result = new List<string>();
        foreach (var propInfo in obj.GetType().GetProperties())
        {
            if (IsGenericTypeOf(typeof(ApiPropertyBase<,>), propInfo.PropertyType))
            {
                var prop = propInfo.GetValue(obj);
                var keyInfo = prop!.GetType().GetProperty("Key");
                if (keyInfo != null)
                {
                    var key = keyInfo.GetValue(prop);
                    result.Add(key?.ToString() ?? string.Empty);
                }
            }
        }
        return result;
    }
}
