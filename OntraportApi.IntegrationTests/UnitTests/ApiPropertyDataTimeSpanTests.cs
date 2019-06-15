using System;
using System.Collections.Generic;
using EmergenceGuardian.OntraportApi.Converters;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class ApiPropertyDataTimeSpanTests
    {
        private readonly string _key = "key1";
        private readonly ApiObject _host = new ApiObject();

        private ApiPropertyTimeSpan SetupProperty() => new ApiPropertyTimeSpan(_host, _key);

        private void Set(string value) => _host.Data[_key] = value;

        public static IEnumerable<object[]> GetValues() => new[] {
            new object[] { "1", TimeSpan.FromSeconds(1) },
            new object[] { -10, TimeSpan.FromSeconds(-10) },
            new object[] { "100000", TimeSpan.FromSeconds(100000) }
        };

        [Theory]
        [MemberData(nameof(GetValues))]
        public void Value_SetRawValue_ReturnsExpectedValue(string rawValue, TimeSpan typedValue)
        {
            var prop = SetupProperty();
            Set(rawValue);

            var result = prop.Value;

            Assert.Equal(typedValue, result);
        }

        [Theory]
        [MemberData(nameof(GetValues))]
        public void Value_SetValue_StoresExpectedRawValue(string rawValue, TimeSpan typedValue)
        {
            var prop = SetupProperty();

            prop.Value = typedValue;

            Assert.Equal(rawValue, prop.RawValue);
        }

        [Theory]
        [MemberData(nameof(GetValues))]
#pragma warning disable xUnit1026 // typeValue not used
#pragma warning disable IDE0060   // typeValue not used
        public void HasValue_Set_ReturnsTrue(string rawValue, TimeSpan typedValue)
        {
            var prop = SetupProperty();
            Set(rawValue);

            var result = prop.HasValue;

            Assert.True(result);
        }
    }
}
