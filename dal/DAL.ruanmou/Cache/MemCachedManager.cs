using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.jk39.MemCached;
namespace Dal.ruanmou
{
    public class MemCachedManager : ICacheManager
    {
        private MemcachedClient m_CacheManager;

        public MemCachedManager()
        {
            m_CacheManager = MemcachedClient.GetInstance("Cacheruanmou");
        }
        public void Set(string key, object value)
        {
            m_CacheManager.Set(key, value);
        }
        public void Set(string key, object value, int timeout)
        {
            m_CacheManager.Set(key, value, DateTime.Now.AddMinutes(timeout));
        }
        public object Get(string key)
        {
            return m_CacheManager.Get(key);
        }
        public void Remove(string key)
        {
            m_CacheManager.Delete(key);
        }
        public void RemoveAll()
        {
            m_CacheManager.FlushAll();
        }
    }
}
