using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.ruanmou;
using com.Model.Base;
using System.Web.Script.Serialization;
using System.Text;
using System.Web.SessionState;
using com.Utility;
using com.DAL.Base;
using DAL.ruanmou;

namespace project.ajax
{
    /// <summary>
    /// HeaderAjax 的摘要说明
    /// </summary>
    public class HeaderAjax : IHttpHandler
    {
        string json = "";
        HttpContext context;
        JavaScriptSerializer jss = new JavaScriptSerializer();
        ReturnMessage rm = new ReturnMessage();
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            context.Request.ContentEncoding = Encoding.GetEncoding("utf-8");
            string cmd = context.Request.Form["cmd"];
            switch (cmd)
            {
                case "checkislogin":
                    json = CheckIsLogin();
                    break;
                case "userlogin":
                    json = UserLogin();
                    break;
                case "vip":
                    json = CheckIsLoginAndVip();
                    break;
            }
            context.Response.Write(json);
        }
        public string UserLogin()
        {
            string username = context.Request.Form["username"].ToString();
            string pwd = context.Request.Form["pwd"].ToString();
            string umtype = context.Request.Form["umtype"].ToString();
            try
            {
                List<dbParam> list = new List<dbParam>() { };
                UserInfor user = null;

                if (umtype == "qq")
                {
                    list.Add(new dbParam() { ParamName = "@QQ", ParamValue = username });
                    list.Add(new dbParam() { ParamName = "@Pwd", ParamValue = pwd });
                    user = UserInforDal.m_UserInforDal.GetModel("QQ=@QQ and Pwd=@Pwd", list);
                }
                else
                {
                    list.Add(new dbParam() { ParamName = "@PhoneNum", ParamValue = username });
                    list.Add(new dbParam() { ParamName = "@Pwd", ParamValue = pwd });
                    user = UserInforDal.m_UserInforDal.GetModel("PhoneNum=@PhoneNum and Pwd=@Pwd", list);
                }
                if (user != null)
                {
                    cookieHelper.SetCookie("CLoginUser", cookieHelper.EncryptCookie(string.Format("{0}/{1}/{2}", WebHelp.GetIP(), user.PhoneNum, user.Pwd)), 60);
                    rm.Success = true;
                }
                else
                {
                    rm.Info = "用户名或密码错误";
                }

            }
            catch
            {
                rm.Info = "未知错误";
            }

            return jss.Serialize(rm);
        }
        public string CheckIsLogin()
        {
            if (UserInforDal.CurrentUser() != null)
            {
                rm.Success = true;
            }
            return jss.Serialize(rm);
        }
        public string CheckIsLoginAndVip()
        {
            if (UserInforDal.CurrentUser() != null)
            {
                //管理员、老师、VIP、软谋帮成员方可发帖、回帖
                if (UserInforDal.CurrentUser().UserType == 1 || UserInforDal.CurrentUser().UserType == 2 || UserInforDal.CurrentUser().UserType == 3 || UserInforDal.CurrentUser().UserType == 5)
                {
                    rm.Success = true;
                }
            }
            return jss.Serialize(rm);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}