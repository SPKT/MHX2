using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;

namespace SPKTCore.Core
{
    public interface ICache
    {
        object Get(string cache_key);
        List<string> GetCacheKeys();
        void Set(string cache_key, object cache_object);
        void Set(string cache_key, object cache_object, DateTime expiration);
        void Set(string cache_key, object cache_object, TimeSpan expiration);
        void Set(string cache_key, object cache_object, DateTime expiration, CacheItemPriority priority);
        void Set(string cache_key, object cache_object, TimeSpan expiration, CacheItemPriority priority);
        void Delete(string cache_key);
        bool Exists(string cache_key);
        void Flush();
    }       
}
