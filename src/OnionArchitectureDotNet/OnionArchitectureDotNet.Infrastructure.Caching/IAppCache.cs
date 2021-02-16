using System;

namespace OnionArchitectureDotNet.Infrastructure.Caching
{
    public  interface IAppCache
    {
        bool IsCacheExists(string cacheKey);
        T GetItemFromCache<T>(string cacheKey);
        void SetCache<T>(string cacheKey, T cacheToSet);
        void SetCache<T>(string cacheKey, T cacheToSet, DateTimeOffset SlidingExpiration);
        void ClearCache(string cacheKey);

    }
}
