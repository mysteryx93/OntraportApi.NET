using System;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi.Converters
{
    /// <summary>
    /// Represents a ValueType property on an ApiObject. Changes are tracked and can be returned with ApiObject.GetChanges().
    /// </summary>
    /// <typeparam name="T">A value type that cannot be null.</typeparam>
    public class ApiProperty<T> : ApiPropertyBase<T, T?>
        where T : struct
    {
        public ApiProperty() { }

        private readonly JsonConverterBase<T> _converter;

        /// <summary>
        /// Initializes a new instance of the ApiProperty class for specified ApiObject host and field key.
        /// </summary>
        /// <param name="host">The ApiObject containing the data.</param>
        /// <param name="key">The field key represented by this property.</param>
        public ApiProperty(ApiObject host, string key, JsonConverterBase<T> converter = null) : base(host, key, converter?.NullString)
        {
            _converter = converter;
        }

        protected override P Get<P>()
        {
            return _converter != null ? _converter.Parse<P>(RawValue) : base.Get<P>();
        }

        public override object FormatValue(object value)
        {
            return _converter != null ? _converter.Format((T?)value) : base.FormatValue(value);
        }

        /// <summary>
        /// Creates a null object if P is nullable, otherwise throws a NullReferenceException.
        /// </summary>
        /// <typeparam name="P">The type to set to null.</typeparam>
        protected P CreateNull<P>() => typeof(P) == typeof(Nullable<T>) ? default(P) : throw new NullReferenceException();
    }
}
