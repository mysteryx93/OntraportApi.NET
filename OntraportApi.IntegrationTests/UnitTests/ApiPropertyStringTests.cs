using System;
using EmergenceGuardian.OntraportApi.Converters;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class ApiPropertyStringTests
    {
        private readonly string _key = "key1";
        private readonly ApiObject _host = new ApiObject();

        private ApiPropertyString SetupProperty() => new ApiPropertyString(_host, _key);

        private void Set(string value) => _host.Data[_key] = value;

        [Fact]
        public void Value_NotSet_ReturnsNull()
        {
            var prop = SetupProperty();

            var result = prop.Value;

            Assert.Null(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("abc")]
        public void Value_Set_ReturnsValue(string value)
        {
            var prop = SetupProperty();
            Set(value);

            var result = prop.Value;

            Assert.Equal(value, result);
        }

        [Fact]
        public void NullableValue_NotSet_ReturnsNull()
        {
            var prop = SetupProperty();

            var result = prop.NullableValue;

            Assert.Null(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("abc")]
        public void NullableValue_Set_ReturnsValue(string value)
        {
            var prop = SetupProperty();
            Set(value);

            var result = prop.NullableValue;

            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("5", "5")]
        public void SetNullableValue_Value_StoreExpectedValue(string expected, string value)
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
        [InlineData("")]
        [InlineData("abc")]
        public void HasValue_Set_ReturnsTrue(string value)
        {
            var prop = SetupProperty();
            Set(value);

            var result = prop.HasValue;

            Assert.True(result);
        }
    }
}
