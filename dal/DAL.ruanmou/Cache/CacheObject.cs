using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal.ruanmou
{
    /// <summary>
    /// 缓存对象，常用于列表或需要利用到缓存时间的对象
    /// </summary>
    [Serializable]
    public class CacheObject
    {
        public object Object { get; set; }

        public int Count { get; set; }

        public DateTime CacheTime
        {
            get { return _CacheTime; }
            set { _CacheTime = value; }
        }private DateTime _CacheTime = DateTime.Now;
    }
}
