using System;
using System.Collections.Generic;
using EmergenceGuardian.OntraportApi.Converters;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;

namespace EmergenceGuardian.OntraportApi.UnitTests
{
    public class ApiPropertyDataIntBoolTests
    {
        private readonly string _key = "key1";
        private readonly ApiObject _host = new ApiObject();

        private ApiPropertyIntBool SetupProperty() => new ApiPropertyIntBool(_host, _key);

        private void Set(string value) => _host.Data[_key] = value;

        public static IEnumerable<object[]> GetValues() => new[] {
            new object[] { "1", true },
            new object[] { "0", false },
        };

        public static IEnumerable<object[]> GetValues2() => new[] {
            new object[] { "-1", false },
            new object[] { "true", true },
            new object[] { "false", false },
            new object[] { "True", true },
            new object[] { "False", false }
        };

        [Theory]
        [MemberData(nameof(GetValues))]
        [MemberData(nameof(GetValues2))]
        public void Value_SetRawValue_ReturnsExpectedValue(string rawValue, bool typedValue)
        {
            var prop = SetupProperty();
            Set(rawValue);

            var result = prop.Value;

            Assert.Equal(typedValue, result);
        }

        [Theory]
        [MemberData(nameof(GetValues))]
        public void Value_SetValue_StoresExpectedRawValue(string rawValue, bool typedValue)
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
        public void HasValue_Set_ReturnsTrue(string rawValue, bool typedValue)
        {
            var prop = SetupProperty();
            Set(rawValue);

            var result = prop.HasValue;

            Assert.True(result);
        }
    }
}
