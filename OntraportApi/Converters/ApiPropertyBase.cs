using System;
using System.ComponentModel;
using System.Globalization;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi.Converters
{
    /// <summary>
    /// Represents a class property on an ApiObject. Changes are tracked and can be returned with ApiObject.GetChanges().
    /// </summary>
    /// <typeparam name="T">The data type of the property.</typeparam>
    /// <typeparam name="N">The nullable data type of the property.</typeparam>
    public abstract class ApiPropertyBase<T, N>
    {
        private readonly ApiObject _host;
        private readonly string _nullString;

        public ApiPropertyBase() { }

        /// <summary>
        /// Initializes a new instance of the ApiProperty class for specified ApiObject host and field key.
        /// </summary>
        /// <param name="host">The ApiObject containing the data.</param>
        /// <param name="key">The field key represented by this property.</param>
        public ApiPropertyBase(ApiObject host, string key, string nullString = null)
        {
            _host = host;
            Key = key;
            _nullString = nullString;
        }

        /// <summary>
        /// Gets the field key represented by this property.
        /// </summary>
        public string Key { get; private set; }


        /// <summary>
        /// Gets whether the property contains a value.
        /// </summary>
        public virtual bool HasValue
        {
            get
            {
                var value = RawValue;
                return (value != null && value != _nullString);
            }
        }

        /// <summary>
        /// Gets whether the property key is in the dictionary.
        /// </summary>
        public bool HasKey => _host.Data.ContainsKey(Key);

        /// <summary>
        /// Gets or sets the value of the property.
        /// </summary>
        public T Value
        {
            get => Get<T>();
            set => Set(value);
        }

        /// <summary>
        /// Gets or sets the nullable value of the property.
        /// </summary>
        public N NullableValue
        {
            get => Get<N>();
            set => Set(value);
        }

        /// <summary>
        /// Returns the raw property value as a string.
        /// </summary>
        public string RawValue => HasKey ? _host.Data[Key] : null;

        /// <summary>
        /// Returns Value as a string representation, or null if value is not set.
        /// </summary>
        public override string ToString() => HasValue ? Convert.ToString(Value, CultureInfo.InvariantCulture) : "null";

        /// <summary>
        /// Gets the value of the property parsed as specified type.
        /// </summary>
        /// <typeparam name="P">The type in which to return the value.</typeparam>
        /// <returns>The parsed value.</returns>
        /// <exception cref="NullReferenceException">Value is null and P is non-nullable.</exception>
        protected virtual P Get<P>()
        {
            var value = RawValue;
            return value != null ? Parse<P>() :
                default(P) == null ? default(P) : throw new NullReferenceException();
        }

        /// <summary>
        /// Sets the value of the property and tracks changes.
        /// </summary>
        /// <param name="value">The value to set.</param>
        protected void Set(object value)
        {
            if (!_host.EditedKeys.Contains(Key))
            {
                _host.EditedKeys.Add(Key);
            }
            value = FormatValue(value);
            _host.Data[Key] = value != null ? Convert.ToString(value, CultureInfo.InvariantCulture) : null;
        }

        /// <summary>
        /// Formats the value into Ontraport's format. Can be overriden in derived classes.
        /// </summary>
        /// <param name="value">The value to format.</param>
        /// <returns>The formatted value.</returns>
        public virtual object FormatValue(object value) => value;

        /// <summary>
        /// Parses the property value into specified type.
        /// </summary>
        /// <typeparam name="P">The data type to convert the value to.</typeparam>
        /// <returns>The converted value.</returns>
        protected P Parse<P>() => (P)TypeDescriptor.GetConverter(typeof(P)).ConvertFromString(null, CultureInfo.InvariantCulture, RawValue);
    }

}
