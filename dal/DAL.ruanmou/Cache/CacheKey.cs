using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal.ruanmou
{
    public class CacheKey
    {
        public static string GetCurrentUserKey(int userID)
        {
            return "CurrentUserKey" + userID.ToString();
        }
        public static string GetTypeMenuKey(int userType)
        {
            return "MenuKey" + userType.ToString();
        }
        public static string GetUserMenuKey(int menuID)
        {
            return "UserMenuKey" + menuID.ToString();
        }
    }
}
