using System;
using System.ComponentModel;
using System.Globalization;

namespace HanumanInstitute.OntraportApi.Models
{
    internal static class StringExtensions
    {
        /// <summary>
        /// Converts the property value into specified type.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <typeparam name="T">The data type to convert the value to.</typeparam>
        /// <returns>The converted value.</returns>
        public static T Convert<T>(this string value) => (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(null, CultureInfo.InvariantCulture, value);

        /// <summary>
        /// Converts the property value into specified type.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="type">The data type to convert the value to.</param>
        /// <returns>The converted value.</returns>
        public static object Convert(this string value, Type type) => TypeDescriptor.GetConverter(type).ConvertFromString(null, CultureInfo.InvariantCulture, value);

        /// <summary>
        /// Converts a value to string using invariant culture.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A string value.</returns>
        public static string ToStringInvariant(this object value) => System.Convert.ToString(value, CultureInfo.InvariantCulture) ?? string.Empty;
    }
}
