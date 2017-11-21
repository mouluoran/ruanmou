using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.DAL.Base;

namespace Dal.ruanmou
{
    public class MsCacheManager : ICacheManager
    {
        private BaseCacheDAL m_CacheManager;

        public MsCacheManager()
        {
            m_CacheManager = new BaseCacheDAL("Cacheruanmou");
        }

        public object Get(string key)
        {
            return m_CacheManager.GetCache(key);
        }

        public void Set(string key, object value)
        {
            m_CacheManager.SetCache(key, value, 0);
        }

        public void Set(string key, object value, int timeout)
        {
            m_CacheManager.SetCache(key, value, timeout);
        }

        public void Remove(string key)
        {
            m_CacheManager.Remove(key);
        }

        public void RemoveAll()
        {
            m_CacheManager.RemoveAll();
        }
    }
}
