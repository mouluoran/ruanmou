using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.DAL.Base;
using Model.ruanmou;
using com.Utility;
using System.Web;
using Dal.ruanmou;
namespace DAL.ruanmou
{
    public class UserMenuDal : System.Web.UI.Page
    {
        private static ICacheManager cacheManger = CacheFactory.GetInstance();
        public static BaseDAL<UserMenu> m_UserMenuDal = new BaseDAL<UserMenu>();
        /// 根据某一个menuID获取菜单
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        public static UserMenu GetUserMenu(int menuID)
        {
            UserMenu menu = new UserMenu();
            string userMenuKey = "";
            if (menuID != 0)
            {
                userMenuKey = CacheKey.GetUserMenuKey(menuID);
            }
            menu = cacheManger.Get(userMenuKey) as UserMenu;
            if (menu == null)
            {
                menu = UserMenuDal.m_UserMenuDal.GetModel(menuID);
                if (menu == null) return null;
                cacheManger.Set(userMenuKey, menu, 60);
            }
            return menu;
        }
        /// <summary>
        /// 获取某一类用户的菜单集合
        /// </summary>
        /// <param name="userType"></param>
        /// <returns></returns>
        public static List<UserMenu> GetTypeMenuList(int userType)
        {
            List<UserMenu> sysList = new List<UserMenu>();
            string userTypeKey = "";
            if (userType != 0)
            {
                userTypeKey = CacheKey.GetTypeMenuKey(userType);
            }
            sysList = cacheManger.Get(userTypeKey) as List<UserMenu>;
            if (sysList == null)
            {
                sysList = UserMenuDal.m_UserMenuDal.GetList(string.Format("IsHave{0}='true'", userType));
                if (sysList == null) return null;
                cacheManger.Set(userTypeKey, sysList, 60);
            }
            return sysList;
        }
    }
}
