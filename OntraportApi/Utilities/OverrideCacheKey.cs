using System;
using System.Collections.Generic;

namespace HanumanInstitute.OntraportApi
{
    internal class OverrideCacheKey
    {
        public Type T { get; set; }
        public Type TOverride { get; set; }
        public IDictionary<string, string> WriteKeysOverride { get; }
        public IDictionary<string, string> ReadKeysOverride { get; }

        public OverrideCacheKey(Type t, Type tOverride, IDictionary<string, string> writeKeysOverride,
            IDictionary<string, string> readKeysOverride)
        {
            T = t;
            TOverride = tOverride;
            WriteKeysOverride = writeKeysOverride;
            ReadKeysOverride = readKeysOverride;
        }

        public string ApplyOn(string key)
        {
            if (WriteKeysOverride.TryGetValue(key, out var match))
            {
                return match;
            }
            return key;
        }
    }
}
