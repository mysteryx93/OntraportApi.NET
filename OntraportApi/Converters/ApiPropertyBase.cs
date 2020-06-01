using System;
using System.ComponentModel;
using System.Globalization;
using HanumanInstitute.OntraportApi.Models;

namespace HanumanInstitute.OntraportApi.Converters
{
    /// <summary>
    /// Represents a class property on an ApiObject. Changes are tracked and can be returned with ApiObject.GetChanges().
    /// </summary>
    /// <typeparam name="T">The data type of the property.</typeparam>
    /// <typeparam name="TNull">The nullable data type of the property.</typeparam>
    public abstract class ApiPropertyBase<T, TNull>
    {
        private readonly ApiObject _host;

        //public ApiPropertyBase() { }

        /// <summary>
        /// Initializes a new instance of the ApiProperty class for specified ApiObject host and field key.
        /// </summary>
        /// <param name="host">The ApiObject containing the data.</param>
        /// <param name="key">The field key represented by this property.</param>
        public ApiPropertyBase(ApiObject host, string key)
        {
            _host = host;
            Key = key;
        }

        /// <summary>
        /// Gets the field key represented by this property.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Gets whether the property contains a value.
        /// </summary>
        public bool HasValue => !IsNullValue(RawValue);

        /// <summary>
        /// Return whether specific value is to be considered null.
        /// </summary>
        protected bool IsNullValue(string? value) => value == null || value == NullString;

        /// <summary>
        /// Returns the string that represents a null value.
        /// </summary>
        public virtual string? NullString => "";

        /// <summary>
        /// Gets whether the property key is in the dictionary.
        /// </summary>
        public bool HasKey => _host.Data.ContainsKey(Key);

        /// <summary>
        /// Gets or sets the nullable value of the property.
        /// </summary>
        public TNull Value
        {
            get => Parse(RawValue);
            set => Set(value);
        }

        /// <summary>
        /// Returns the raw property value as a string.
        /// </summary>
        public string? RawValue => HasKey ? _host.Data[Key] : null;

        /// <summary>
        /// Returns Value as a string representation, or "null" if value is not set.
        /// </summary>
        /// <remarks>If it returned null, the debugger would display the full class name instead of "null" value.</remarks>
        public override string ToString() => HasValue ? Convert.ToString(Value, CultureInfo.InvariantCulture)! : "null";

        /// <summary>
        /// Gets the value of the property parsed as specified type.
        /// </summary>
        /// <returns>The parsed value.</returns>
        /// <exception cref="NullReferenceException">Value is null and P is non-nullable.</exception>
        protected virtual TNull Parse(string? value) => !IsNullValue(value) ? value!.Convert<TNull>() : default!;

        /// <summary>
        /// Sets the value of the property and tracks changes.
        /// </summary>
        /// <param name="value">The value to set.</param>
        protected void Set(TNull value)
        {
            if (!_host.EditedKeys.Contains(Key))
            {
                _host.EditedKeys.Add(Key);
            }
            var conv = Format(value);
            _host.Data[Key] = conv != null ? conv.ToStringInvariant() : NullString;
        }

        /// <summary>
        /// Formats the value into Ontraport's format. Can be overriden in derived classes.
        /// </summary>
        /// <param name="value">The value to format.</param>
        /// <returns>The formatted value.</returns>
        public virtual string? Format(TNull value) => value?.ToStringInvariant();
    }

}
