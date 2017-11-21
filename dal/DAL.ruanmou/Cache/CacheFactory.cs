using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Dal.ruanmou
{
    public class CacheFactory
    {
        private static ICacheManager _instance = null;
        private static object m_LockObj = new object();

        private CacheFactory() { }

        static CacheFactory()
        {
            GetInstance();
        }
        public static ICacheManager GetInstance()
        {
            if (_instance == null)
            {
                lock (m_LockObj)
                {
                    if (_instance == null)
                    {
                        string cacheType = ConfigurationSettings.AppSettings["CacheType"];
                        if (cacheType == "MemCacheManager")
                            _instance = new MemCachedManager();
                        else
                            _instance = new MsCacheManager();
                    }
                }
            }
            return _instance;
        }

        public static void ResetCacheManager()
        {
            _instance = null;
        }
    }
}
