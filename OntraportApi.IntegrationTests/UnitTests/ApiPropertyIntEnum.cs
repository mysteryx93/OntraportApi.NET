using System;
using EmergenceGuardian.OntraportApi.Converters;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class ApiPropertyIntEnumTests
    {
        private readonly string _key = "key1";
        private readonly ApiObject _host = new ApiObject();

        private ApiPropertyIntEnum<BulkMailStatus> SetupProperty() => new ApiPropertyIntEnum<BulkMailStatus>(_host, _key);

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
        [InlineData("0", BulkMailStatus.TransactionalOnly)]
        [InlineData("1", BulkMailStatus.OptedIn)]
        [InlineData("-2", BulkMailStatus.HardBounce)]
        public void Value_Set_ReturnsExpectedValue(string value, BulkMailStatus expected)
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
        [InlineData("0", BulkMailStatus.TransactionalOnly)]
        [InlineData("1", BulkMailStatus.OptedIn)]
        [InlineData("-2", BulkMailStatus.HardBounce)]
        public void NullableValue_Set_ReturnsExpectedValue(string value, BulkMailStatus? expectedValue)
        {
            var prop = SetupProperty();
            Set(value);

            var result = prop.Value;

            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("0", BulkMailStatus.TransactionalOnly)]
        [InlineData("1", BulkMailStatus.OptedIn)]
        [InlineData("-2", BulkMailStatus.HardBounce)]
        public void SetNullableValue_Value_StoreExpectedValue(string expected, BulkMailStatus? value)
        {
            var prop = SetupProperty();

            prop.Value = value;

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

        [Fact]
        public void HasValue_SetEmpty_ReturnsFalse()
        {
            var prop = SetupProperty();
            Set("");

            var result = prop.HasValue;

            Assert.False(result);
        }

        [Theory]
        [InlineData("0")]
        [InlineData("-2")]
        public void HasValue_Set_ReturnsTrue(string value)
        {
            var prop = SetupProperty();
            Set(value);

            var result = prop.HasValue;

            Assert.True(result);
        }
    }
}
