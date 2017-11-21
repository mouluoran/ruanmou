using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.ruanmou;
using DAL.ruanmou;
using com.Model.Base;
using System.Web.Script.Serialization;
namespace webnew.ajax
{
    /// <summary>
    /// AjaxAskPage 的摘要说明
    /// </summary>
    public class AjaxAskPage : IHttpHandler
    {
        ReturnMessage rm = new ReturnMessage();
        JavaScriptSerializer jss = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            int ViewCount = Convert.ToInt32(context.Request.Form["recount"].ToString());
            int AskState = Convert.ToInt32(context.Request.Form["askState"].ToString());
            int IsReply = Convert.ToInt32(context.Request.Form["isReply"].ToString());
            int AskId = Convert.ToInt32(context.Request.Form["AskId"].ToString());
            string Title = context.Request.Form["Title"].ToString();
            string AskText =context.Request.Form["Text"].ToString();
            int AskCategory =Convert.ToInt32(context.Request.Form["AskCategory"].ToString());
            int UserId = Convert.ToInt32(context.Request.Form["UserId"].ToString());
            StuAsk ask = StuAskDal.m_StuAskDal.GetModel(AskId);
            ask.ViewCount = ViewCount;
            ask.AskState = AskState;
            ask.IsReply = IsReply;
            ask.Title = Title;
            ask.AskText = AskText;
            ask.AskCategory = AskCategory;
            ask.UserId = UserId;
            StuAskDal.m_StuAskDal.Update(ask);
            rm.Success = true;
            rm.Info = "更新成功";
            rm.Redirect = "AskM.aspx";
            context.Response.Write(jss.Serialize(rm));
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