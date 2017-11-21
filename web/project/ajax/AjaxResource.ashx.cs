using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.ruanmou;
using DAL.ruanmou;
using System.Text;
using System.Web.Script.Serialization;
using com.Model.Base;
using com.Utility;
using com.DAL.Base;
namespace web.Ajax
{
    /// <summary>
    /// AjaxResource 的摘要说明
    /// </summary>
    public class AjaxResource : IHttpHandler
    {
        string json = "";
        HttpContext context;
        JavaScriptSerializer jss = new JavaScriptSerializer();
        ReturnMessage rm = new ReturnMessage();
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            context.Request.ContentEncoding = Encoding.GetEncoding("utf-8"); //必须加上，否则会产生乱码
            string cmd = context.Request["cmd"].ToString();
            switch (cmd)
            {
                case "add":
                    json = AddResource();
                    break;
                case "alter":
                    json = AlterResource();
                    break;
            }
            context.Response.Write(json);
        }
        /// <summary>
        /// 添加资源
        /// </summary>
        /// <returns></returns>
        public string AddResource()
        {
            string Title = context.Request.Form["Title"].ToString();
            string Text = context.Request.Form["Text"].ToString();
            string ClassName = context.Request.Form["ClassName"].ToString();
            string Author = context.Request.Form["Author"].ToString();

            Model.ruanmou.Resource rs = new Resource();
            rs.Title = Title;
            rs.Text = Text;
            rs.ClassName = ClassName;
            rs.Author = Author;
            rs.CreatedTime = DateTime.Now;
            ResourceDal.m_ResourceDal.Add(rs);
            rm.Info = "提交成功";
            rm.Success = true;
            rm.Redirect = "UadateResource.aspx";

            return jss.Serialize(rm);
        }
        /// <summary>
        /// 修改资源
        /// </summary>
        /// <returns></returns>
        public string AlterResource()
        {
            int id = Convert.ToInt32(context.Request.Form["ResourceId"].ToString());
            string Title = context.Request.Form["Title"].ToString();
            string Text = context.Request.Form["Text"].ToString();
            string ClassName = context.Request.Form["ClassName"].ToString();
            string Author = context.Request.Form["Author"].ToString();

            Resource rs = ResourceDal.m_ResourceDal.GetModel("ResourceId=@ResourceId", new List<dbParam>() { new dbParam() { ParamName = "@ResourceId", ParamValue = id } });
            if (rs != null)
            {
                rs.Title = Title;
                rs.Text = Text;
                rs.ClassName = ClassName;
                rs.Author = Author;
                ResourceDal.m_ResourceDal.Update(rs);
            }
            rm.Info = "修改成功";
            rm.Success = true;
            rm.Redirect = "UadateResource.aspx";
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