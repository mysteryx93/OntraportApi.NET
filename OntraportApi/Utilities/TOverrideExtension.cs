using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HanumanInstitute.OntraportApi.Models;

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
            foreach (var item in fieldsOverride)
            {
                if (item.FieldType == typeof(string) && item.Name.EndsWith("Key", StringComparison.Ordinal))
                {
                    foreach (var itemMatch in fieldsSource)
                    {
                        if (itemMatch.Name == item.Name)
                        {
                            try
                            {
                                var tValue = (string)itemMatch.GetValue(null);
                                var tOverrideValue = (string)item.GetValue(null);
                                writeKeysOverride.Add(tValue, tOverrideValue);
                                readKeysOverride.Add(tOverrideValue, tValue);                                
                            }
                            catch (ArgumentException)
                            {
                                throw new InvalidOperationException("To use TOverride, all keys on T and TOverride must be set to unique values.");
                            }
                            break;
                        }
                    }
                }
            }
            return new OverrideCacheKey(t, tOverride, writeKeysOverride, readKeysOverride);
        }

        // Static cache is enough considering this will be skipped in production. It serves only for developpement.
        private static readonly List<OverrideCacheKey> s_overrideFieldsCache = new List<OverrideCacheKey>();

        private class OverrideCacheKey
        {
            public Type T { get; set; }
            public Type TOverride { get; set; }
            public IDictionary<string, string> WriteKeysOverride { get; }
            public IDictionary<string, string> ReadKeysOverride { get; }

            public OverrideCacheKey(Type t, Type tOverride, IDictionary<string, string> writeKeysOverride, IDictionary<string, string> readKeysOverride)
            {
                T = t;
                TOverride = tOverride;
                WriteKeysOverride = writeKeysOverride;
                ReadKeysOverride = readKeysOverride;
            }
        }
    }
}
