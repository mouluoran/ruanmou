using Dal.ruanmou;
using Model.ruanmou;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.ruanmou
{
    public class CacheAdmin
    {
        //private static ICacheManager cacheManger = CacheFactory.GetInstance();
        ////获取当前用户
        //public static UserInfor GetCurrentUser(int userID)
        //{
        //    UserInfor _user = new UserInfor();
        //    string currentUserKey = "";
        //    if (userID == 0) return null;
        //    if (userID > 0)
        //    {
        //        currentUserKey = CacheKey.GetCurrentUserKey(userID);
        //        _user = cacheManger.Get(currentUserKey) as UserInfor;
        //        //第一次从数据库中取
        //        if (_user == null)
        //        {
        //            _user = UserInforDal.m_UserInforDal.GetModel(userID);
        //            if (_user == null) return null;
        //            //第一次从数据库之后存入缓存     
        //            SetCurrentUser(_user, userID);
        //        }
        //    }
        //    return _user;
        //}
        ////缓存当前用户
        //public static void SetCurrentUser(object obj, int userID)
        //{
        //    string currentUserKey = CacheKey.GetCurrentUserKey(userID);
        //    cacheManger.Set(currentUserKey, obj, 10);
        //}
        //public static void Remove(string key)
        //{
        //    if (!string.IsNullOrEmpty(key))
        //    {
        //        cacheManger.Remove(key);
        //    }
        //}
    }
}
