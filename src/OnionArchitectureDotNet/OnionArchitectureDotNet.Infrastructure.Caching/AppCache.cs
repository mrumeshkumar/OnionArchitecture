using System;
using System.Runtime.Caching;

namespace OnionArchitectureDotNet.Infrastructure.Caching
{
    public class AppCache : IAppCache
    {
        public  bool IsCacheExists(string cacheKey)
        {
            bool Flag = false;
            try
            {
                object  obj = MemoryCache.Default.Get(cacheKey);
                if ((obj != null))
                    Flag = true;
                return Flag;
            }
            catch
            {
               return Flag;
            }
        }

        public  T GetItemFromCache<T>(string cacheKey)
        {
            object obj;
            try
            {
                obj = MemoryCache.Default.Get(cacheKey);
            }
            catch (Exception ex)
            {
                throw (new ArgumentNullException(string.Format("Init of Cache {0} failed due to {1}", cacheKey, ex.Message)));
            }
            return (T)obj;
        }

        public  void SetCache<T>(string cacheKey, T cacheToSet)
        {
            CacheItemPolicy defaultCacheItemPolicy = new CacheItemPolicy();
            defaultCacheItemPolicy.AbsoluteExpiration = DateTimeOffset.Now.AddHours(2);
            try
            {
                if (cacheToSet != null)
                {
                    CacheItem cacheItem = new CacheItem(cacheKey, cacheToSet);
                    MemoryCache.Default.Set(cacheItem, defaultCacheItemPolicy);
                }
                else
                {
                    throw new ArgumentNullException(string.Format("Init of Cache {0} failed", cacheKey));
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(string.Format("Init of Cache {0} failed due to {1}", cacheKey, ex.Message));
            }
        }

        public  void SetCache<T>(string cacheKey, T cacheToSet, DateTimeOffset SlidingExpiration)
        {
            try
            {
                if (cacheToSet != null)
                {
                    MemoryCache.Default.Set(cacheKey, cacheToSet, SlidingExpiration);
                }
                else
                {
                    throw (new ArgumentNullException(string.Format("Init of Cache {0} failed", cacheKey)));
                }
            }
            catch (Exception ex)
            {
                throw (new ArgumentNullException(string.Format("Init of Cache {0} failed due to {1}", cacheKey, ex.Message)));
            }
        }

        public  void ClearCache(string cacheKey)
        {
            try
            {
                MemoryCache.Default.Remove(cacheKey);
            }
            catch (Exception ex)
            {
                throw (new ArgumentNullException(string.Format("Init of Cache {0} failed due to {1}", cacheKey, ex.Message)));

            }
        }
    }
}
