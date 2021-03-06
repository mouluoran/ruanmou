﻿using com.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using DAL.ruanmou;
using Model.ruanmou;
using com.Utility;
namespace web.ajax
{
    /// <summary>
    /// ChangePwdAajx 的摘要说明
    /// </summary>
    public class ChangePwdAajx : IHttpHandler
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
                case "pwdchange":
                    json = ChangePwd();
                    break;
            }
            context.Response.Write(json);
        }
        public string ChangePwd()
        {
            string pwd = context.Request["pwd"].ToString();

            UserInfor user = UserInforDal.CurrentUser();
            if (user == null)
            {
                rMessage.Info = "尚未登陆";
                return m_JavaScriptSerializer.Serialize(rMessage);
            }
            user.Pwd = pwd;
            UserInforDal.m_UserInforDal.Update(user);
            rMessage.Info = "密码修改成功";

            return m_JavaScriptSerializer.Serialize(rMessage);
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