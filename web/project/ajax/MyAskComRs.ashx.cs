using com.DAL.Base;
using com.Model.Base;
using DAL.ruanmou;
using Model.ruanmou;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using com.Utility;
namespace webnew.ajax
{
    /// <summary>
    /// MyAskComRs 的摘要说明
    /// </summary>
    public class MyAskComRs : IHttpHandler
    {
        HttpContext context = null;
        private string sResult = "";
        JavaScriptSerializer jss = new JavaScriptSerializer();
        Dictionary<string, object> dic = new Dictionary<string, object>();
        ReturnMessage rm = new ReturnMessage();
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            string cmd = context.Request.Form["cmd"];
            switch (cmd)
            {
                case "myasklist":
                    sResult = GetMyAskList();
                    break;
                case "mycomlist":
                    sResult = GetComList();
                    break;
                case "myrslist":
                    sResult = GetRSList();
                    break;
            }

            context.Response.Write(sResult);
        }
        public string GetRSList()
        {
            UserInfor user = UserInforDal.CurrentUser();
            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();
            sb.Append(" ClassName in(");
            if (user.Phase.IndexOf(",") > 0)
            {
                string[] aPhase = user.Phase.Split(',');
                for (int i = 0; i < aPhase.Length; i++)
                {
                    if (i == aPhase.Length - 1)
                    {
                        sb.Append(string.Format("'{0}'", aPhase[i].ToString()));
                    }
                    else
                    {
                        sb.Append(string.Format("'{0}',", aPhase[i].ToString()));
                    }
                }
            }
            else
            {
                sb.Append(string.Format("'{0}'",user.Phase));
            }
            sb.Append(")");
            List<Resource> list = ResourceDal.m_ResourceDal.GetList(sb.ToString());
            if (list.Count > 0) { 
               sb1.Append(@"  <li class=""listhead"">
                            <div class=""rstitle"">标题</div>
                            <div class=""rscate"">分类</div>
                            <div class=""rstime"">创建时间</div>
                            <div class=""rsviewcount"">浏览数</div>
                        </li>");
               foreach (var rs in list) {
                   sb1.Append(string.Format(@"<li class=""lrsitem"">
                            <div class=""irstitle""><i class=""layui-icon"" style=""color: #009688;""></i> <a href=""/my/RsInfor.aspx?rid={0}"" target=""_blank"">{1}</a></div>
                            <div class=""irscate"">{2}</div><div class=""irstime"">{3}</div><div class=""irsviewcount"">{4}</div>
                        </li>", rs.ResourceId, rs.Title, rs.ClassName, rs.CreatedTime.ToString("yyyy-MM-dd"), rs.VCount));
               }
            }
            return sb1.ToString();
        }
        public string GetComList()
        {
            UserInfor user = UserInforDal.CurrentUser();
            int pagesize = Convert.ToInt32(context.Request.Form["pagesize"]);
            int pageindex = Convert.ToInt32(context.Request.Form["pageindex"]);
            int icount = CommentDal.m_CommentDal.GetCount("UserId=@UserId", new List<dbParam>() { 
              new dbParam(){ ParamName="@UserId", ParamValue=user.UserId}
            });
            int pagecount = 0;
            if (icount % pagesize == 0)
            {
                pagecount = icount / pagesize;
            }
            else
            {
                double ic = Convert.ToDouble(icount);
                double pg = Convert.ToDouble(pagesize);
                pagecount = Convert.ToInt32(Math.Ceiling(ic / pg));
            }
            dic.Add("pagecount", pagecount);
            List<Comment> list = CommentDal.m_CommentDal.GetList(string.Format("UserId={0}", user.UserId), pagesize, pageindex, true, "AskId,CreateTime,ComText,ZanCount,IsAdopt", "CreateTime");
            StringBuilder sb = new StringBuilder();

            if (list.Count > 0)
            {
                sb.Append(@"<li class=""listhead"">
                             <div class=""rtitle"">回复内容</div>
                            <div class=""rtime"">评论时间</div>
                            <div class=""rzan"">被赞数目</div>
                            <div class=""rsdopt"">是否采纳</div>
                        </li>");
                foreach (var com in list)
                {
                    string irsdopt = "";
                    switch (com.IsAdopt)
                    {
                        case true:
                            irsdopt = "被采纳";
                            break;
                        case false:
                            irsdopt = "未采纳";
                            break;
                    }
                    string con = CRegex.FilterHTML(com.ComText).Length > 30 ? CRegex.FilterHTML(com.ComText).Substring(0, 30) + "..." : CRegex.FilterHTML(com.ComText);
                    sb.Append(string.Format(@" <li class=""lcomitem"">
                            <div class=""irtitle""><i class=""layui-icon"" style=""color: #009688;"">&#xe623;</i> <a href=""/QInfor.aspx?qid={0}"" target=""_blank"">{1}</a></div>
                            <div class=""irtime"">{2}</div>
                            <div class=""irzan"">{3}</div>
                            <div class=""irsdopt"">{4}</div>
                        </li>", com.AskId, con, com.CreateTime.ToString("yyyy-MM-dd"), com.ZanCount, irsdopt));
                }
            }
            else
            {
                sb.Append("你未回复过任何帖子");
            }
            dic.Add("pagelist", sb.ToString());
            return jss.Serialize(dic);

        }
        public string GetMyAskList()
        {
            UserInfor user = UserInforDal.CurrentUser();
            int pagesize = Convert.ToInt32(context.Request.Form["pagesize"]);
            int pageindex = Convert.ToInt32(context.Request.Form["pageindex"]);
            int icount = StuAskDal.m_StuAskDal.GetCount("UserId=@UserId", new List<dbParam>() { 
              new dbParam(){ ParamName="@UserId", ParamValue=user.UserId}
            });
            int pagecount = 0;
            if (icount % pagesize == 0)
            {
                pagecount = icount / pagesize;
            }
            else
            {
                double ic = Convert.ToDouble(icount);
                double pg = Convert.ToDouble(pagesize);
                pagecount = Convert.ToInt32(Math.Ceiling(ic / pg));
            }
            dic.Add("pagecount", pagecount);
            List<StuAsk> list = StuAskDal.m_StuAskDal.GetList(string.Format("UserId={0}", user.UserId), pagesize, pageindex, true, "AskId,Title,AskCategory,CreateTime,UserId,ViewCount,AskState,ReplyCount", "CreateTime");
            StringBuilder sb = new StringBuilder();

            if (list.Count > 0)
            {
                sb.Append(@"<li class=""listhead"">
                            <div class=""htitle"">标题</div>
                            <div class=""hcate"">分类</div>
                            <div class=""htime"">创建时间</div>
                            <div class=""hviewcount"">浏览数</div>
                            <div class=""hstate"">是否结贴</div>
                            <div class=""hrcount"">评论数</div>
                        </li>");
                foreach (var ask in list)
                {
                    string icate = "";
                    switch (ask.AskCategory)
                    {
                        case 1:
                            icate = "前端开发";
                            break;
                        case 2:
                            icate = "ASP.NET";
                            break;
                        case 3:
                            icate = "JAVA";
                            break;
                        case 4:
                            icate = "小程序";
                            break;
                    }
                    string istate = "";
                    switch (ask.AskState)
                    {
                        case 1:
                            istate = "已结贴";
                            break;
                        case 2:
                            istate = "未结帖";
                            break;
                    }
                    sb.Append(string.Format(@"  <li class=""laskitem"">
                            <div class=""ititle""><i class=""layui-icon"" style=""color: #009688;"">&#xe623;</i> <a href=""/QInfor.aspx?qid={0}"" target=""_blank"">{1}</a></div>
                            <div class=""icate"">{2}</div>
                            <div class=""itime"">{3}</div>
                            <div class=""iviewcount"">{4}</div>
                            <div class=""istate"">{5}</div>
                            <div class=""ircount"">{6}</div>
                        </li>", ask.AskId, ask.Title, icate, ask.CreateTime.ToString("yyyy-MM-dd"), ask.ViewCount, istate, ask.ReplyCount));
                }
            }
            else
            {
                sb.Append("你还未发过贴");
            }
            dic.Add("pagelist", sb.ToString());
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