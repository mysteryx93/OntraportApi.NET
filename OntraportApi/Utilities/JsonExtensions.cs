using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using HanumanInstitute.Validators;
using Res = HanumanInstitute.OntraportApi.Properties.Resources;

namespace HanumanInstitute.OntraportApi
{
    internal static partial class JsonExtensions
    {
        /// <summary>
        /// Deserializes a JsonElement as an object, which is not supported in .NET 3.1.
        /// </summary>
        /// <exception cref="JsonException">The JSON data could not be parsed.</exception>
        public static T ToObject<T>(this JsonElement element, JsonSerializerOptions? options = null)
        {
            var bufferWriter = new ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(bufferWriter))
            {
                element.WriteTo(writer);
            }

            try
            {
                return JsonSerializer.Deserialize<T>(bufferWriter.WrittenSpan, options ?? OntraportSerializerOptions.Default);
            }
            catch (JsonException ex)
            {
                // Throw an error message that is more useful for debugging.
                var msg = "Could not deserialize JSON into object {0}.\n{1}".FormatInvariant(typeof(T).Name, element.GetRawText());
                throw new JsonException(msg, ex);
            }
        }


        /// <summary>
        /// Returns the Data element and throws an exception if not found or null.
        /// </summary>
        /// <param name="json">The root response JsonElement.</param>
        /// <returns>The Data JsonElement.</returns>
        /// <exception cref="InvalidOperationException">json was null, or json["data"] was null.</exception>
        public static JsonElement JsonData(this JsonElement json)
            => json.JsonChild("data");


        /// <summary>
        /// Returns the content of json[child] and returns defaultValue or throws an exception if not found or null.
        /// </summary>
        /// <param name="json">The Json to retrieve data for.</param>
        /// <param name="child">The child property to retrieve.</param>
        /// <param name="defaultValue">If specified, this value will be returned in case child is not found. Otherwise, an exception will be thrown.</param>
        /// <returns>The content of json[child].</returns>
        /// <exception cref="InvalidOperationException">json was null, or json[child] was null.</exception>
        public static JsonElement JsonChild(this JsonElement json, string child, JsonElement? defaultValue = null)
        {
            child.CheckNotNullOrEmpty(nameof(child));

            if (json.TryGetProperty(child, out var data))
            {
                if (data.ValueKind != JsonValueKind.Null)
                {
                    return data;
                }
            }
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException(Res.InvalidResponseData);
        }

        /// <summary>
        /// Returns the first array element of a JsonElement and throws an exception if not found or null.
        /// </summary>
        /// <param name="json">The Json to retrieve data for.</param>
        /// <returns>The content of json[child].</returns>
        /// <exception cref="InvalidOperationException">json was null, or json[child] was null.</exception>
        public static JsonElement JsonFirst(this JsonElement json)
        {
            var iter = json.EnumerateObject();
            if (iter.Any())
            {
                var first = iter.First();
                if (first.Value.ValueKind != JsonValueKind.Null)
                {
                    return first.Value;
                }
            }
            throw new InvalidOperationException(Res.InvalidResponseData);
        }

        [return: MaybeNull]
        public static T GetValue<T>(this ref Utf8JsonReader reader)
        {
            var value = reader.TokenType switch
            {
                JsonTokenType.String => ReadString<T>(ref reader),
                JsonTokenType.False => false,
                JsonTokenType.True => true,
                JsonTokenType.Null => null,
                JsonTokenType.Number => ReadNumber<T>(ref reader),
                _ => throw new JsonException()
            };
            if (typeof(T) == typeof(string) && value?.GetType() != typeof(string))
            {
                // False cannot be converted to String without this.
                return (T)(object)value?.ToStringInvariant()!;
            }
            return (T)value!;
        }

        private static object? ReadNumber<T>(ref Utf8JsonReader reader)
        {
            var t = typeof(T);
            if (t == typeof(bool) || t == typeof(bool?))
            {
                return reader.GetInt16() == 1;
            }
            else if (t == typeof(short) || t == typeof(short?))
            {
                return reader.GetInt16();
            }
            else if (t == typeof(int) || t == typeof(int?))
            {
                return reader.GetInt32();
            }
            else if (t == typeof(long) || t == typeof(long?))
            {
                return reader.GetInt64();
            }
            else if (t == typeof(float) || t == typeof(float?))
            {
                return reader.GetSingle();
            }
            else if (t == typeof(double) || t == typeof(double?))
            {
                return reader.GetDouble();
            }
            else if (t == typeof(string))
            {
                return reader.GetDecimal().ToStringInvariant();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private static object? ReadString<T>(ref Utf8JsonReader reader)
        {
            var t = typeof(T);
            if (t == typeof(string))
            {
                return reader.GetString();
            }
            else
            {
                return reader.GetString().Convert(t);
            }
        }

        /// <summary>
        /// Runs a task and throws InvalidOperationException if JsonException is thrown. If json is null, it will return null.
        /// </summary>
        public static async Task<T?> RunAndCatchAsync<T>(this JsonElement? json, Func<JsonElement, Task<T>> task)
            where T : class
        {
            if (json == null) { return default; }
            task.CheckNotNull(nameof(task));

            try
            {
                return await task.Invoke(json.Value).ConfigureAwait(false);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException(Res.InvalidResponseData, ex);
            }
        }

        /// <summary>
        /// Runs a task and throws InvalidOperationException if JsonException is thrown. If json is null, it will return null.
        /// </summary>
        public static async Task<T?> RunAndCatchAsync<T>(this JsonElement? json, Func<JsonElement, T> task)
            where T : class
        {
            return await RunAndCatchAsync<T>(json,
                new Func<JsonElement, Task<T>>(x => Task.Run<T>(() => task.Invoke(x)))).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a task and throws InvalidOperationException if JsonException is thrown.
        /// </summary>
        public static Task<T> RunAndCatchAsync<T>(this JsonElement json, Func<JsonElement, Task<T>> task)
            where T : class =>
            RunAndCatchAsync(new JsonElement?(json), task)!;

        /// <summary>
        /// Runs a task and throws InvalidOperationException if JsonException is thrown.
        /// </summary>
        public static Task<T> RunAndCatchAsync<T>(this JsonElement json, Func<JsonElement, T> task)
            where T : class =>
            RunAndCatchAsync(new JsonElement?(json), task)!;


        /// <summary>
        /// Runs a task and throws InvalidOperationException if JsonException is thrown. If json is null, it will return null.
        /// </summary>
        public static async Task<T> RunStructAndCatchAsync<T>(this JsonElement? json, Func<JsonElement, Task<T>> task)
        {
            if (json == null) { return default!; }

            task.CheckNotNull(nameof(task));

            try
            {
                return await task(json.Value).ConfigureAwait(false);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException(Res.InvalidResponseData, ex);
            }
        }

        /// <summary>
        /// Runs a task and throws InvalidOperationException if JsonException is thrown. If json is null, it will return null.
        /// </summary>
        public static Task<T> RunStructAndCatchAsync<T>(this JsonElement? json, Func<JsonElement, T> task) =>
            RunStructAndCatchAsync<T>(json,
                new Func<JsonElement, Task<T>>(x => Task.Run<T>(() => task.Invoke(x))));

        /// <summary>
        /// Runs a task and throws InvalidOperationException if JsonException is thrown.
        /// </summary>
        public static Task<T> RunStructAndCatchAsync<T>(this JsonElement json, Func<JsonElement, Task<T>> task) =>
            RunStructAndCatchAsync(new JsonElement?(json), task);

        /// <summary>
        /// Runs a task and throws InvalidOperationException if JsonException is thrown.
        /// </summary>
        public static Task<T> RunStructAndCatchAsync<T>(this JsonElement json, Func<JsonElement, T> task) =>
            RunStructAndCatchAsync(new JsonElement?(json), task);
    }
}
