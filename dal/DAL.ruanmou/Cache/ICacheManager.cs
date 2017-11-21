using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal.ruanmou
{
    public interface ICacheManager
    {
        object Get(string key);
        void Set(string key, object value);
        void Set(string key, object value, int timeout);
        void Remove(string key);
        void RemoveAll();
    }
}
