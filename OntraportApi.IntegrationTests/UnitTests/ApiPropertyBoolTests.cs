using System;
using EmergenceGuardian.OntraportApi.Converters;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class ApiPropertyBoolTests
    {
        private readonly string _key = "key1";
        private readonly ApiObject _host = new ApiObject();

        private ApiPropertyBool SetupProperty() => new ApiPropertyBool(_host, _key);

        private void Set(string value) => _host.Data[_key] = value;

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
        [InlineData("true", true)]
        [InlineData("false", false)]
        [InlineData("True", true)]
        [InlineData("False", false)]
        public void Value_Set_ReturnsValue(string value, bool expected)
        {
            var prop = SetupProperty();
            Set(value);

            var result = prop.Value;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void NullableValue_NotSet_ReturnsNull()
        {
            var prop = SetupProperty();

            var result = prop.NullableValue;

            Assert.Null(result);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("true", true)]
        [InlineData("false", false)]
        [InlineData("True", true)]
        [InlineData("False", false)]
        public void NullableValue_Set_ReturnsValue(string value, bool? expected)
        {
            var prop = SetupProperty();
            Set(value);

            var result = prop.NullableValue;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("true", true)]
        [InlineData("false", false)]
        public void SetNullableValue_Value_StoreExpectedValue(string expected, bool? value)
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
        [InlineData("false")]
        [InlineData("true")]
        public void HasValue_Set_ReturnsTrue(string value)
        {
            var prop = SetupProperty();
            Set(value);

            var result = prop.HasValue;

            Assert.True(result);
        }
    }
}
