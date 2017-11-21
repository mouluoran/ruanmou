using com.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Model.ruanmou;
using DAL.ruanmou;
namespace webnew.ajax
{
    /// <summary>
    /// myleftajax 的摘要说明
    /// </summary>
    public class myleftajax : IHttpHandler
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
                case "showleft":
                    json = ShowLeft();
                    break;
            }
            context.Response.Write(json);
        }
        public string ShowLeft()
        {
            UserInfor user = UserInforDal.CurrentUser();
            if (user != null)
            {
                rMessage.TypeID = user.UserType;
            }
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