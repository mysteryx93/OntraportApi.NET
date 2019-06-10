using System;
using System.Collections.Generic;
using EmergenceGuardian.OntraportApi.Converters;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class ApiPropertyDateTimeTests
    {
        private readonly string _key = "key1";
        private readonly ApiObject _host = new ApiObject();

        private ApiPropertyDateTime SetupProperty() => new ApiPropertyDateTime(_host, _key);

        private void Set(string value) => _host.Data[_key] = value;

        public static IEnumerable<object[]> ValueList => new[] {
            new object[] { new DateTimeOffset(2019, 01, 01, 01, 0, 0, TimeSpan.Zero), new DateTimeOffset(2019, 01, 01, 01, 0, 0, TimeSpan.Zero).ToUnixTimeSeconds().ToString() },
            new object[] { DateTimeOffset.FromUnixTimeSeconds(1),  "1" },
            new object[] { DateTimeOffset.FromUnixTimeSeconds(100000), "100000" }
        };

        [Fact]
        public void Value_NotSet_ThrowsException()
        {
            var prop = SetupProperty();

            void Act() => _ = prop.Value;

            Assert.Throws<NullReferenceException>(Act);
        }

        [Fact]
        public void Value_SetNull_ThrowsException()
        {
            var prop = SetupProperty();
            Set(null);

            void Act() => _ = prop.Value;

            Assert.Throws<NullReferenceException>(Act);
        }

        [Theory]
        [MemberData(nameof(ValueList))]
        public void Value_Set_ReturnsValue(DateTimeOffset expected, string value)
        {
            var prop = SetupProperty();
            Set(value);

            var result = prop.Value;

            Assert.True(Math.Abs((expected.UtcDateTime - result.UtcDateTime).TotalSeconds) < 1);
        }

        [Fact]
        public void NullableValue_NotSet_ReturnsNull()
        {
            var prop = SetupProperty();

            var result = prop.NullableValue;

            Assert.Null(result);
        }

        [Fact]
        public void NullableValue_SetNull_ReturnsNull()
        {
            var prop = SetupProperty();
            Set(null);

            var result = prop.NullableValue;

            Assert.Null(result);
        }

        [Theory]
        [MemberData(nameof(ValueList))]
        public void NullableValue_Set_ReturnsValue(DateTimeOffset expected, string value)
        {
            var prop = SetupProperty();
            Set(value);

            var result = prop.NullableValue;

            Assert.True(Math.Abs((expected.UtcDateTime - result.Value.UtcDateTime).TotalSeconds) < 1);
        }

        [Theory]
        [MemberData(nameof(ValueList))]
        public void SetNullableValue_Value_StoreExpectedValue(DateTimeOffset value, string expected)
        {
            var prop = SetupProperty();

            prop.NullableValue = value;

            Assert.Equal(expected, prop.RawValue);
        }

        [Fact]
        public void HasKey_NotSet_ReturnsFalse()
        {
            var prop = SetupProperty();

            var result = prop.HasKey;

            Assert.False(result);
        }

        [Fact]
        public void HasKey_SetNull_ReturnsTrue()
        {
            var prop = SetupProperty();
            Set(null);

            var result = prop.HasKey;

            Assert.True(result);
        }

        [Fact]
        public void HasValue_NotSet_ReturnsFalse()
        {
            var prop = SetupProperty();

            var result = prop.HasValue;

            Assert.False(result);
        }

        [Fact]
        public void HasValue_SetNull_ReturnsFalse()
        {
            var prop = SetupProperty();
            Set(null);

            var result = prop.HasValue;

            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(ValueList))]
        public void HasValue_Set_ReturnsTrue(DateTimeOffset expected, string value)
        {
            var prop = SetupProperty();
            Set(value);

            var result = prop.HasValue;

            Assert.True(result);
        }

        [Fact]
        public void NullableValue_SetEpoch0_ReturnsNull()
        {
            var prop = SetupProperty();
            Set("0");

            var result = prop.NullableValue;

            Assert.Null(result);
        }

        [Fact]
        public void NullableValue_SetNull_ReturnsEpoch0()
        {
            var prop = SetupProperty();

            prop.NullableValue = null;

            Assert.Equal("0", _host.Data[_key]);
        }

    }
}
