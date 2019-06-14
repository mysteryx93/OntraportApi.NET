using System;
using EmergenceGuardian.OntraportApi.Converters;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class ApiPropertyIntBoolTests
    {
        private readonly string _key = "key1";
        private readonly ApiObject _host = new ApiObject();

        private ApiPropertyIntBool SetupProperty() => new ApiPropertyIntBool(_host, _key);

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
        [InlineData("0", false)]
        [InlineData("1", true)]
        [InlineData("-1", false)]
        [InlineData("false", false)]
        [InlineData("true", true)]
        [InlineData("False", false)]
        [InlineData("True", true)]
        public void Value_Set_ReturnsExpectedValue(string value, bool expected)
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

            var result = prop.Value;

            Assert.Null(result);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("0", false)]
        [InlineData("1", true)]
        [InlineData("-1", false)]
        [InlineData("false", false)]
        [InlineData("true", true)]
        [InlineData("False", false)]
        [InlineData("True", true)]
        public void NullableValue_Set_ReturnsExpectedValue(string value, bool? expectedValue)
        {
            var prop = SetupProperty();
            Set(value);

            var result = prop.Value;

            Assert.Equal(expectedValue, result);
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
        [InlineData("0")]
        [InlineData("1")]
        [InlineData("-1")]
        public void HasValue_Set_ReturnsTrue(string value)
        {
            var prop = SetupProperty();
            Set(value);

            var result = prop.HasValue;

            Assert.True(result);
        }
    }
}
