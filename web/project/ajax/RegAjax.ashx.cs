using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.ruanmou;
using com.Model.Base;
using System.Web.Script.Serialization;
using System.Text;
using System.Web.SessionState;
using DAL.ruanmou;
using com.Utility;
using com.DAL.Base;
namespace project
{
    /// <summary>
    /// RegAjax 的摘要说明
    /// </summary>
    public class RegAjax : IHttpHandler, IRequiresSessionState
    {
        string json = "";
        HttpContext context;
        JavaScriptSerializer jss = new JavaScriptSerializer();
        ReturnMessage rm = new ReturnMessage();
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            context.Request.ContentEncoding = Encoding.GetEncoding("utf-8");
            string cmd = context.Request.QueryString["cmd"];
            switch (cmd)
            {
                case "checkphoneqq":
                    json = CheckPhoneNum();
                    break;
                case "reguser":
                    json = RegUser();
                    break;
            }
            context.Response.Write(json);
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        public string RegUser()
        {
            string pwd = context.Request.Form["pwd"].ToString();
            string phonenum = context.Request.Form["phonenum"].ToString();
            string qq = context.Request.Form["qq"].ToString();
            string phase = context.Request.Form["phase"].ToString();
            string checkcode = context.Request.Form["checkcode"].ToString();
            if (checkcode != context.Session["CheckCode"].ToString())
            {
                rm.Success = false;
                rm.Info = "验证码输入不正确";
            }
            else
            {
                try
                {
                    UserInfor user = new UserInfor();
                    user.NickName = "软谋学员";
                    user.Pwd = pwd;
                    user.PhoneNum = phonenum;
                    user.QQ = qq;
                    user.Phase = phase;
                    user.CreatedTime = DateTime.Now;
                    user.ClientIP = WebHelp.GetIP();//获取到访问者的ip地址
                    user.UserType = 4;//usertype=1管理员，2老师，3 vip学员，4一般注册用户，5为蜜蜂团
                    user.HeadPic = "man.GIF";
                    if (!UserInforDal.RegLimit())
                    {
                        rm.Info = "sorry，一天最多只能注册三次";
                    }
                    else
                    {
                        UserInforDal.m_UserInforDal.Add(user);
                        cookieHelper.SetCookie("CLoginUser", cookieHelper.EncryptCookie(string.Format("{0}/{1}/{2}", WebHelp.GetIP(), phonenum, pwd)), 20);
                        rm.Success = true;
                        rm.Info = "恭喜您，注册成功，3秒后返回首页...";
                    }
                }
                catch
                {
                    rm.Info = "未知错误";
                }
            }
            return jss.Serialize(rm);

        }
        /// <summary>
        /// 验证手机号
        /// </summary>
        /// <returns></returns>
        public string CheckPhoneNum()
        {
            string phonenum = context.Request.Form["phonenum"].ToString();
            string qq = context.Request.Form["qq"].ToString();
            rm.Success = true;
            try
            {
                List<dbParam> list = new List<dbParam>() { new dbParam() { ParamName = "@PhoneNum", ParamValue = phonenum } ,
                 new dbParam() { ParamName = "@QQ", ParamValue = qq }};
                UserInfor user = UserInforDal.m_UserInforDal.GetModel("PhoneNum=@PhoneNum or QQ=@QQ", list);
                if (user != null)
                {
                    rm.Success = false;
                    rm.Info = "该手机号或QQ号已经存在";
                }
            }
            catch
            {
                rm.Success = false;
                rm.Info = "未知错误";
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