using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LazyCache;
using LazyCache.Providers;

using Microsoft.Extensions.Caching.Memory;

namespace FactoryTesting
{
    public static class AppCacheExtensions
    {
        public static TData Get<TKey, TData>(this IAppCache appCache, TKey key)
        {
            ValidateKey(key);
            return appCache.Get<TData>(key.ToString());
        }
        public static TData GetOrAdd<TKey, TData>(this IAppCache appCache, TKey key, Func<TData> addItemFactory)
        {
            ValidateKey(key);
            return appCache.GetOrAdd<TData>(key.ToString(), addItemFactory);
        }
        private static void ValidateKey<TKey>(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (string.IsNullOrWhiteSpace(key.ToString()))
            {
                throw new ArgumentException($"{nameof(key)} must not be an empty string or whitespace");
            }
        }
    }

}
