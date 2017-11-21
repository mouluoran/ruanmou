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
    /// AjaxNews 的摘要说明
    /// </summary>
    public class AjaxNews : IHttpHandler
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
                    json = AddNews();
                    break;
                case "alter":
                    json = AlterNews();
                    break;
            }
            context.Response.Write(json);
        }
        /// <summary>
        /// 添加新闻
        /// </summary>
        /// <returns></returns>
        public string AddNews()
        {
            string Title = context.Request.Form["Title"].ToString();
            string Text = context.Request.Form["Text"].ToString();
            string Text1 = CRegex.FilterHTML(Text);
            if (string.IsNullOrEmpty(Text1))
            {
                rm.Info = "内容不能为空";
                return jss.Serialize(rm);
            }
            string NewsClass = context.Request.Form["NewsClass"].ToString();
            Model.ruanmou.RNews n = new Model.ruanmou.RNews();
            n.Title = Title;
            n.Text = Text;
            n.CreatedTime = DateTime.Now;
            n.NewsClass = NewsClass;
            DAL.ruanmou.RNewsDal.m_RNewsDal.Add(n);
            rm.Info = "添加成功";
            rm.Success = true;
            rm.Redirect = "UpdateNews.aspx";

            return jss.Serialize(rm);
        }
        /// <summary>
        /// 修改新闻
        /// </summary>
        /// <returns></returns>
        public string AlterNews()
        {
            int NewsId = Convert.ToInt32(context.Request.Form["NewsId"].ToString());
            string Title = context.Request.Form["Title"].ToString();
            string Text = context.Request.Form["Text"].ToString();
            string NewsClass = context.Request.Form["NewsClass"].ToString();
            RNews rn = RNewsDal.m_RNewsDal.GetModel("NewsId=@NewsId", new List<dbParam>() { new dbParam() { ParamName = "@NewsId", ParamValue = Convert.ToInt32(NewsId) } });
            rn.Title = Title;
            rn.Text = Text;
            rn.NewsClass = NewsClass;
            RNewsDal.m_RNewsDal.Update(rn);
            rm.Info = "修改成功";
            rm.Success = true;
            rm.Redirect = "UpdateNews.aspx";
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