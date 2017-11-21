using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.DAL.Base;
using Model.ruanmou;
using com.Utility;
using System.Web;
using System.Data;
namespace DAL.ruanmou
{
    public class UserInforDal : System.Web.UI.Page
    {
        public static BaseDAL<UserInfor> m_UserInforDal = new BaseDAL<UserInfor>();

        /// <summary>
        /// 注册限制
        /// </summary>
        /// <returns></returns>
        public static bool RegLimit()
        {
            bool b = true;
            List<dbParam> list = new List<dbParam>() { new dbParam() { ParamName = "@ClientIP", ParamValue = WebHelp.GetIP() },
                new dbParam() { ParamName = "@Time", ParamValue =  DateTime.Now.ToString("yyyy-MM-dd") }};
            int count = UserInforDal.m_UserInforDal.GetCount(" ClientIP=@ClientIP and CONVERT(varchar(100), CreatedTime, 23)=@Time", list);
            if (count >= 3)
            {
                b = false;
            }
            return b;
        }
        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns></returns>
        public static UserInfor CurrentUser()
        {
            UserInfor user = null;
            if (System.Web.HttpContext.Current.Request.Cookies["CLoginUser"] == null || System.Web.HttpContext.Current.Request.Cookies["CLoginUser"].Value == "")
            {
                return user;
            }
            else
            {
                string strLoginUser = cookieHelper.DecryptCookie(System.Web.HttpContext.Current.Request.Cookies["CLoginUser"].Value);
                string[] aLoginUser = strLoginUser.Split('/');
                if (aLoginUser.Length != 3)
                {
                    user = null;
                }
                if (WebHelp.GetIP() != aLoginUser[0])
                {
                    user = null;
                }
                else
                {
                    user = UserInforDal.m_UserInforDal.GetModel("PhoneNum=@PhoneNum", new List<dbParam>() { new dbParam() { ParamName = "@PhoneNum", ParamValue =aLoginUser[1].ToString() } });
                    if (user.Pwd != aLoginUser[2])
                    {
                        user = null;
                    }
                }
            }
            return user;
        }

        public static UserInfor CurrentMUser()
        {
            UserInfor user = null;
            if (System.Web.HttpContext.Current.Request.Cookies["MLoginUser"] == null || System.Web.HttpContext.Current.Request.Cookies["MLoginUser"].Value == "")
            {
                return user;
            }
            else
            {
                string strLoginUser = cookieHelper.DecryptCookie(System.Web.HttpContext.Current.Request.Cookies["MLoginUser"].Value);
                string[] aLoginUser = strLoginUser.Split('/');
                if (aLoginUser.Length != 3)
                {
                    user = null;
                }
                if (WebHelp.GetIP() != aLoginUser[0])
                {
                    user = null;
                }
                else
                {
                    user = UserInforDal.m_UserInforDal.GetModel("PhoneNum=@PhoneNum", new List<dbParam>() { new dbParam() { ParamName = "@PhoneNum", ParamValue = aLoginUser[1].ToString() } });
                    if (user.Pwd != aLoginUser[2])
                    {
                        user = null;
                    }
                }
            }
            return user;
        }
    }
}
