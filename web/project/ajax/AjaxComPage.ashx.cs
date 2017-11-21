using com.Model.Base;
using DAL.ruanmou;
using Model.ruanmou;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace webnew.ajax
{
    /// <summary>
    /// AjaxComPage 的摘要说明
    /// </summary>
    public class AjaxComPage : IHttpHandler
    {

        ReturnMessage rm = new ReturnMessage();
        JavaScriptSerializer jss = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            int userid = Convert.ToInt32(context.Request.Form["userid"].ToString());
            int askid = Convert.ToInt32(context.Request.Form["askid"].ToString());
            int zancount = Convert.ToInt32(context.Request.Form["zancount"].ToString());
            bool isadopt = Convert.ToBoolean(context.Request.Form["isadopt"].ToString());
            int comid = Convert.ToInt32(context.Request.Form["comid"].ToString());
            string comtext = context.Request.Form["comtext"].ToString();
            Comment com = CommentDal.m_CommentDal.GetModel(comid);
            if (com != null)
            {
                com.UserId = userid;
                com.AskId = askid;
                com.ZanCount = zancount;
                com.IsAdopt = isadopt;
                com.ComText = comtext;
                CommentDal.m_CommentDal.Update(com);
            }

            rm.Success = true;
            rm.Info = "更新成功";
            rm.Redirect = "CommentM.aspx";
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