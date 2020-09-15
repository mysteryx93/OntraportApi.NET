using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Converters;
using HanumanInstitute.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests
{
    public abstract class OntraportBaseReadTests<T, TU>
        where T : OntraportBaseRead<TU>
        where TU : ApiObject
    {
        protected ITestOutputHelper Output { get; private set; }
        protected int ValidId { get; private set; }

        public OntraportBaseReadTests(ITestOutputHelper output, int validId)
        {
            Output = output;
            ValidId = validId;
        }

        protected T SetupApi()
        {
            var httpClient = ConfigHelper.GetHttpClient();
            var ontraObjects = new OntraportObjects(httpClient);
            if (IsGenericTypeOf(typeof(OntraportBaseCustomObject<>), typeof(T)))
            {
                return (T)Activator.CreateInstance(typeof(T), httpClient, ontraObjects)!;
            }
            else
            {
                return (T)Activator.CreateInstance(typeof(T), httpClient)!;
            }
        }

        protected OntraportObjects SetupObjectsApi()
        {
            return new OntraportObjects(ConfigHelper.GetHttpClient());
        }

        [Fact]
        public async Task SelectAsync_ValidId_ReturnsData()
        {
            var api = SetupApi();

            var result = await api.SelectAsync(ValidId);

            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task SelectMultipleAsync_ValidId_ReturnsData()
        {
            var api = SetupApi();

            var result = await api.SelectAsync(new ApiSearchOptions(ValidId));

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task SelectMultipleAsync_NoArgs_ReturnsAll()
        {
            var api = SetupApi();

            var result = await api.SelectAsync();

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task SelectMetadataAsync_NoArg_ReturnsData()
        {
            var api = SetupApi();

            var result = await api.GetMetadataAsync();

            Assert.NotEmpty(result.Fields);
        }

        [Fact]
        public async Task SelectCollectionInfoAsync_NoArg_ReturnsData()
        {
            var api = SetupApi();

            var result = await api.GetCollectionInfoAsync();

            Assert.NotEmpty(result.ListFields);
        }

        [Fact]
        public async Task SelectAsync_ValidId_AllPropertiesHaveKey()
        {
            var api = SetupApi();
            var hasError = false;

            var result = await api.SelectAsync(ValidId);

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
            Assert.False(hasError, "Some keys are not present in the dictionary and have been listed in output.");
        }

        [Fact]
        public async Task SelectAsync_ValidId_AllApiPropertiesEndWithField()
        {
            var api = SetupApi();
            var hasError = false;

            var result = await api.SelectAsync(ValidId);

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
            Assert.False(hasError, "Some ApiProperty members don't end with Field.");
        }

        [Fact]
        public async Task SelectAsync_ValidId_AllFieldPropertiesHaveMatchingValueProperty()
        {
            var api = SetupApi();
            var hasError = false;

            var result = await api.SelectAsync(ValidId);

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
            var api = SetupApi();
            var hasError = false;

            var result = await api.SelectAsync(ValidId);

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
}
