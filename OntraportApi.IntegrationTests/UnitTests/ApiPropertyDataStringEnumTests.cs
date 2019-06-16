using System;
using System.Collections.Generic;
using EmergenceGuardian.OntraportApi.Converters;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;

namespace EmergenceGuardian.OntraportApi.UnitTests
{
    public class ApiPropertyDataStringEnumTests
    {
        private readonly string _key = "key1";
        private readonly ApiObject _host = new ApiObject();

        private ApiPropertyStringEnum<BulkMailStatus> SetupProperty() => new ApiPropertyStringEnum<BulkMailStatus>(_host, _key);

        private void Set(string value) => _host.Data[_key] = value;

        public static IEnumerable<object[]> GetValues() => new[] {
            new object[] { "transactional_only", BulkMailStatus.TransactionalOnly },
            new object[] { "opted_in", BulkMailStatus.OptedIn },
            new object[] { "hard_bounce", BulkMailStatus.HardBounce }
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
        public void HasValue_Set_ReturnsTrue(string rawValue, BulkMailStatus typedValue)
        {
            var prop = SetupProperty();
            Set(rawValue);

            var result = prop.HasValue;

            Assert.True(result);
        }
    }
}
