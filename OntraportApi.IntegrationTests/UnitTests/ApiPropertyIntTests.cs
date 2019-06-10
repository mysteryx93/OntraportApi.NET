using System;
using EmergenceGuardian.OntraportApi.Converters;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class ApiPropertyIntTests
    {
        private readonly string _key = "key1";
        private readonly ApiObject _host = new ApiObject();

        private ApiProperty<int> SetupProperty() => new ApiPropertyInt(_host, _key);

        private void Set(int? value) => _host.Data[_key] = value.HasValue ? value.ToString() : null;

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
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(-5)]
        public void Value_Set_ReturnsValue(int value)
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
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(-5)]
        public void NullableValue_Set_ReturnsValue(int? value)
        {
            var prop = SetupProperty();
            Set(value);

            var result = prop.NullableValue;

            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("0", 0)]
        [InlineData("5", 5)]
        [InlineData("-5", -5)]
        public void SetNullableValue_Value_StoreExpectedValue(string expected, int? value)
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
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(-5)]
        public void HasValue_Set_ReturnsTrue(int? value)
        {
            var prop = SetupProperty();
            Set(value);

            var result = prop.HasValue;

            Assert.True(result);
        }
    }
}
