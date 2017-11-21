using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.ruanmou;
using Model.ruanmou;
using System.Web.Script.Serialization;
using com.DAL.Base;
namespace webnew.ajax
{
    /// <summary>
    /// AuditionAjax 的摘要说明
    /// </summary>
    public class AuditionAjax : IHttpHandler
    {
        Dictionary<string, object> dic = new Dictionary<string, object>();
        JavaScriptSerializer jss = new JavaScriptSerializer();
        public string sMsg = "";
        HttpContext context = null;
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            string type = context.Request.Params["type"];
            switch (type)
            {
                case "1":
                    sMsg = GetBeeTeamList();
                    break;
                case "2":
                    sMsg = GetSuccessList();
                    break;
            }
            context.Response.Write(sMsg);
        }
        public string GetSuccessList()
        {
            int page = Convert.ToInt32(context.Request.QueryString["page"]);
            int limit = Convert.ToInt32(context.Request.QueryString["limit"]);
            List<BeeTarget> list = BeeTargetDal.m_BeeTargetDal.GetList(string.Format("BeeQQ='{0}'", UserInforDal.CurrentUser().QQ), limit, page, true, "*", "ConverDate");
            int count = BeeTargetDal.m_BeeTargetDal.GetCount(string.Format("BeeQQ='{0}'", UserInforDal.CurrentUser().QQ));
            dic.Add("count", count);
            dic.Add("data", list);
            dic.Add("code", 0);
            dic.Add("msg", "");
            return jss.Serialize(dic);
        }
        public string GetBeeTeamList()
        {
            int page = Convert.ToInt32(context.Request.QueryString["page"]);
            int limit = Convert.ToInt32(context.Request.QueryString["limit"]);
            List<BeeTeam> list = BeeTeamDal.m_BeeTeamDal.GetList(string.Format("BeeQQ='{0}'", UserInforDal.CurrentUser().QQ), limit, page, true, "*", "CreatedTime");
            int count = BeeTeamDal.m_BeeTeamDal.GetCount(string.Format("BeeQQ='{0}'", UserInforDal.CurrentUser().QQ));
            dic.Add("count", count);
            dic.Add("data", list);
            dic.Add("code", 0);
            dic.Add("msg", "");
            return jss.Serialize(dic);
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