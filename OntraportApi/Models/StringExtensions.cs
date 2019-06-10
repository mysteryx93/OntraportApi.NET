using System;
using System.ComponentModel;
using System.Globalization;

namespace EmergenceGuardian.OntraportApi.Models
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts the property value into specified type.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <typeparam name="P">The data type to convert the value to.</typeparam>
        /// <returns>The converted value.</returns>
        public static P Convert<P>(this string value) => (P)TypeDescriptor.GetConverter(typeof(P)).ConvertFromString(null, CultureInfo.InvariantCulture, value);

        /// <summary>
        /// Converts the property value into specified type.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="type">The data type to convert the value to.</param>
        /// <returns>The converted value.</returns>
        public static object Convert(this string value, Type type) => TypeDescriptor.GetConverter(type).ConvertFromString(null, CultureInfo.InvariantCulture, value);
    }
}
