using System;
using System.Collections.Generic;
using HanumanInstitute.OntraportApi.Converters;
using HanumanInstitute.OntraportApi.Models;
using Xunit;

namespace HanumanInstitute.OntraportApi.UnitTests
{
    public abstract class ApiPropertyBaseTests<P, T, N>
        where P : ApiPropertyBase<T, N>
    {
        private readonly string _key = "key1";
        private readonly ApiObject _host = new ApiObject();

        private P SetupProperty() => (P)Activator.CreateInstance(typeof(P), _host, _key);

        private void Set(string value) => _host.Data[_key] = value;

        [Fact]
        public void Value_NotSet_ReturnsNull()
        {
            var prop = SetupProperty();

            var result = prop.Value;

            Assert.Null(result);
        }

        [Fact]
        public void Value_SetRawNull_ReturnsNull()
        {
            var prop = SetupProperty();
            Set(null);

            var result = prop.Value;

            Assert.Null(result);
        }

        [Fact]
        public void Value_SetRawEmpty_ReturnsNull()
        {
            var prop = SetupProperty();
            Set(prop.NullString);

            var result = prop.Value;

            Assert.Null(result);
        }

        [Fact]
        public void Value_SetNull_ReturnsRawEmpty()
        {
            var prop = SetupProperty();

            prop.Value = default(N);

            Assert.Equal(prop.NullString, _host.Data[_key]);
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
            Set(prop.NullString);

            var result = prop.HasValue;

            Assert.False(result);
        }
    }
}
