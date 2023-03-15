using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HanumanInstitute.OntraportApi.Models;
using HanumanInstitute.Validators;

namespace HanumanInstitute.OntraportApi
{
    internal static class TOverrideExtension
    {
        /// <summary>
        /// If T and TOverride are different, replaces key names from T with key names from TOverride using reflection to iterate and match key names.
        /// Reflection is used once per type and the result is cached. In production code, this code is skipped.
        /// </summary>
        /// <typeparam name="T">The ApiObject to convert.</typeparam>
        /// <typeparam name="TOverride">The derived class containing new key definitions.</typeparam>
        /// <param name="list">The list of key/values to override key names for.</param>
        /// <returns>A new dictionary with replaced key names.</returns>
        internal static IDictionary<string, object?> WriteOverrideFields<T, TOverride>(this IDictionary<string, object?> list)
            where T : ApiObject
            where TOverride : T
        {
            if (typeof(T) == typeof(TOverride)) { return list; }

            var keysOverride = GetKeysOverride(typeof(T), typeof(TOverride)).WriteKeysOverride;

            // Replace key names.
            if (keysOverride.Any())
            {
                var result = new Dictionary<string, object?>(list.Count);
                foreach (var item in list)
                {
                    if (keysOverride.TryGetValue(item.Key, out var match))
                    {
                        result.Add(match, item.Value);
                    }
                    else
                    {
                        result.Add(item.Key, item.Value);
                    }
                }
                return result;
            }
            return list;
        }

        /// <summary>
        /// If T and TOverride are different, replaces key names from TOverride with key names from T using reflection to iterate and match key names.
        /// Reflection is used once per type and the result is cached. In production code, this code is skipped.
        /// </summary>
        /// <typeparam name="T">The ApiObject to convert.</typeparam>
        /// <typeparam name="TOverride">The derived class containing new key definitions.</typeparam>
        /// <param name="list">The list of key/values to override key names for.</param>
        /// <returns>A new dictionary with replaced key names.</returns>
        internal static IDictionary<string, string?> ReadOverrideFields<T, TOverride>(this IDictionary<string, string?> list)
            where T : ApiObject
            where TOverride : T
        {
            if (typeof(T) == typeof(TOverride)) { return list; }

            var keysOverride = GetKeysOverride(typeof(T), typeof(TOverride)).ReadKeysOverride;

            // Replace key names.
            if (keysOverride.Any())
            {
                var result = new Dictionary<string, string?>(list.Count);
                foreach (var item in list)
                {
                    if (keysOverride.TryGetValue(item.Key, out var match))
                    {
                        result.Add(match, item.Value);
                    }
                    else
                    {
                        result.Add(item.Key, item.Value);
                    }
                }
                return result;
            }
            return list;
        }
        
        internal static void WriteOverrideFields<T, TOverride>(this IList<ApiSearchConditionBase> list)
            where T : ApiObject
            where TOverride : T
        {
            if (typeof(T) == typeof(TOverride)) { return; }

            var keysOverride = GetKeysOverride(typeof(T), typeof(TOverride)).WriteKeysOverride;

            // Replace key names.
            if (keysOverride.Any())
            {
                foreach (var item in list)
                {
                    if (keysOverride.TryGetValue(item.Field, out var match))
                    {
                        item.Field = match;
                    }
                }
            }
        }

        // /// <summary>
        // /// Returns the field key overriden for testing via reflection, when using TOverride.
        // /// </summary>
        // /// <param name="ontra">The Ontraport object.</param>
        // /// <param name="fieldKey">The field key to evaluate.</param>
        // /// <typeparam name="T">The normal object type.</typeparam>
        // /// <typeparam name="TOverride">The override type containing new key values for testing.</typeparam>
        // /// <returns>A new key from TOverride if any, or fieldKey.</returns>
        // private static string GetFieldKeyWithOverride<T, TOverride>(this OntraportBaseCustomObject<T, TOverride> ontra, string fieldKey)
        //     where T : ApiCustomObjectBase
        //     where TOverride : T
        // {
        //     if (typeof(T) == typeof(TOverride)) { return fieldKey; }
        //
        //     var keysOverride = GetKeysOverride(typeof(T), typeof(TOverride)).ReadKeysOverride;
        //     if (keysOverride.TryGetValue(fieldKey, out var match))
        //     {
        //         return match;
        //     }
        //     return fieldKey;
        // }

        internal static OverrideCacheKey GetKeysOverride<T, TOverride>(this OntraportBaseRead<T, TOverride> ontra)
            where T : ApiObject
            where TOverride : T =>
            GetKeysOverride(typeof(T), typeof(TOverride));

        private static OverrideCacheKey GetKeysOverride(Type t, Type tOverride)
        {
            lock (s_overrideFieldsCache)
            {
                foreach (var item in s_overrideFieldsCache)
                {
                    if (item.T == t && item.TOverride == tOverride)
                    {
                        return item;
                    }
                }

                var result = FetchKeysOverride(t, tOverride);
                s_overrideFieldsCache.Add(result);
                return result;
            }
        }

        /// <summary>
        /// Find all public constants on TOverride ending by "Key" and match with constants of same name on T.
        /// Result dictionary will say "replace {TKey} with {TOverrideKey}".
        /// </summary>
        private static OverrideCacheKey FetchKeysOverride(Type t, Type tOverride)
        {
            var writeKeysOverride = new Dictionary<string, string>();
            var readKeysOverride = new Dictionary<string, string>();
            // Get all constants.
            var fieldsSource = t.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            var fieldsOverride = tOverride.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            var duplicate = string.Empty;
            foreach (var item in fieldsOverride)
            {
                if (item.FieldType == typeof(string) && item.Name.EndsWith("Key", StringComparison.Ordinal))
                {
                    foreach (var itemMatch in fieldsSource)
                    {
                        if (itemMatch.Name == item.Name)
                        {
                            var tValue = (string)itemMatch.GetValue(null);
                            var tOverrideValue = (string)item.GetValue(null);
                            duplicate = string.Empty;
                            try
                            {
                                writeKeysOverride.Add(tValue, tOverrideValue);
                            }
                            catch (ArgumentException)
                            {
                                duplicate += $" Field {tValue} on T is duplicate.";
                            }
                            try
                            {
                                readKeysOverride.Add(tOverrideValue, tValue);
                            }
                            catch (ArgumentException)
                            {
                                duplicate += $" Field {tOverrideValue} on TOverride is duplicate.";
                            }
                            if (duplicate.HasValue())
                            {
                                throw new InvalidOperationException("To use TOverride, all keys on T and TOverride must be set to unique values." + duplicate);
                            }

                            break;
                        }
                    }
                }
            }
            return new OverrideCacheKey(t, tOverride, writeKeysOverride, readKeysOverride);
        }

        // Static cache is enough considering this will be skipped in production. It serves only for development.
        private static readonly List<OverrideCacheKey> s_overrideFieldsCache = new List<OverrideCacheKey>();
    }
}
