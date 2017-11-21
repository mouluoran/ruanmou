using com.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using DAL.ruanmou;
using Model.ruanmou;
using System.Text;
namespace web.ajax
{
    /// <summary>
    /// MyIndexAjax 的摘要说明
    /// </summary>
    public class MyIndexAjax : IHttpHandler
    {
        private JavaScriptSerializer m_JavaScriptSerializer = new JavaScriptSerializer();
        string json = "";
        HttpContext context;
        ReturnMessage rMessage = new ReturnMessage();
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            context.Request.ContentEncoding = Encoding.GetEncoding("utf-8"); //必须加上，否则会产生乱码
            //接收浏览器 get/post 过来的参数cmd
            string cmd = context.Request["cmd"].ToString();

            switch (cmd)
            {
                case "showinfor":
                    json = ShowInfor();
                    break;
                case "updateinfor":
                    json = UpdateInfor();
                    break;
            }
            context.Response.Write(json);
        }
        public string UpdateInfor()
        {
            string nickname = context.Request.Form["nickname"].ToString();
            string realname = context.Request["realname"].ToString();
            string phonenum = context.Request["phonenum"].ToString();
            string qq = context.Request["qq"].ToString();
            string sex = context.Request["sex"].ToString();
            UserInfor user = UserInforDal.CurrentUser();
            user.RealName = realname;
            user.PhoneNum = phonenum;
            user.QQ = qq;
            user.Sex = sex;
            user.NickName = nickname;
            UserInforDal.m_UserInforDal.Update(user);
            rMessage.Info = "信息修改成功";
            return m_JavaScriptSerializer.Serialize(rMessage);
        }
        public string ShowInfor()
        {
            return m_JavaScriptSerializer.Serialize(UserInforDal.CurrentUser());
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