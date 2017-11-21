using com.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Model.ruanmou;
using DAL.ruanmou;
using System.Text;
using com.Utility;
using com.DAL.Base;
namespace project
{
    /// <summary>
    /// QueAjax 的摘要说明
    /// </summary>
    public class QueAjax : IHttpHandler
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
                case "GetAskList":
                    sResult = GetAskList();
                    break;
                case "PostAsk":
                    sResult = PostAsk();
                    break;
            }

            context.Response.Write(sResult);
        }
        public string PostAsk()
        {
            string title = context.Request.Form["title"];
            int cate = Convert.ToInt32(context.Request.Form["cate"].ToString());
            string con = context.Request.Form["text"];
            if (CRegex.FilterHTML(con) == "")
            {
                rm.Info = "内容不能为空";
                return jss.Serialize(rm);
            }
            if (CRegex.FilterHTML(con).Length > 700 || CRegex.FilterHTML(con).Length < 6)
            {
                rm.Info = "问题内容长度在6~700之间";
                return jss.Serialize(rm);
            }
            else
            {
                string strIP = WebHelp.GetIP();
                List<dbParam> list = new List<dbParam>() { new dbParam() { ParamName = "@ClientIP", ParamValue = strIP },
                new dbParam() { ParamName = "@Time", ParamValue =  DateTime.Now.ToString("yyyy-MM-dd") }};
                int count = StuAskDal.m_StuAskDal.GetCount(" ClientIP=@ClientIP and CONVERT(varchar(100), CreateTime, 23)=@Time", list);
                if (count >= 3)
                {
                    rm.Info = "一天最多只能发帖三次";
                    jss.Serialize(rm);
                }
                else
                {
                    UserInfor user = UserInforDal.CurrentUser();//获取当前登陆用户
                    if (user.UserType == 4)
                    {
                        rm.Info = "只有软谋正式学员才能发帖";
                        jss.Serialize(rm);
                    }
                    else
                    {
                        StuAsk s = new StuAsk();
                        s.Title = title;
                        s.AskCategory = cate;
                        s.AskText = con;
                        s.ClientIP = WebHelp.GetIP();
                        s.UserId = user.UserId;
                        s.CreateTime = DateTime.Now;
                        s.AskState = 2;
                        s.IsReply = 2;
                        int qid = StuAskDal.m_StuAskDal.Add(s);
                        rm.Success = true;
                        rm.Info = "提交成功";
                    }
                }
            }
            return jss.Serialize(rm);

        }
        List<dbParam> listPm = null;
        public string GetAskList()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                int pagesize = Convert.ToInt32(context.Request.Form["pagesize"]);
                int pageindex = Convert.ToInt32(context.Request.Form["pageindex"]);
                int icount = StuAskDal.m_StuAskDal.GetCount(GetSqlWhere(), listPm);
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
                List<StuAsk> list = StuAskDal.m_StuAskDal.GetList(GetSqlWhere(), pagesize, pageindex, true, "AskId,Title,AskText,AskCategory,CreateTime,UserId,ViewCount,AskState,IsReply,ReplyCount", "CreateTime", listPm);
                if (list != null && list.Count > 0)
                {
                    foreach (var ask in list)
                    {
                        string statebg = "";
                        string statename = "";
                        if (ask.IsReply == 1)
                        {
                            statebg = "reply";
                            statename = "回答";
                        }
                        if (ask.IsReply == 2)
                        {
                            statebg = "noreply";
                            statename = "待答";
                        }
                        if (ask.AskState == 1)
                        {
                            statebg = "solved";
                            statename = "解决";
                        }
                        string cat = "";
                        switch (ask.AskCategory)
                        {
                            case 1:
                                cat = "前端开发";
                                break;
                            case 2:
                                cat = "ASP.NET";
                                break;
                            case 3:
                                cat = "JAVA";
                                break;
                        }

                        sb.Append(string.Format(@"<ul>
                    <li class=""askstatus"">
                        <a class=""{0}"" href=""javascript:;"">
                            <strong>{1}</strong>
                            <p>{2}</p>
                        </a>
                    </li>
                    <li class=""askpv"">
                        <div>
                            <strong>{3}</strong>
                            <p>浏览</p>
                        </div>
                    </li>
                    <li class=""asktit"">
                        <p class=""caption cf"">
                        </p>
                        <h3><a href=""QInfor.aspx?qid={4}"" target=""_blank"">【{5}】{6}</a></h3>
                        <p></p>
                        <p class=""mark"">
                            <span>{7}-{8}提问</span>
                        </p>
                    </li>
                </ul>", statebg, ask.ReplyCount, statename, ask.ViewCount, ask.AskId, cat, ask.Title,
                     UserInforDal.m_UserInforDal.GetModel("UserId=@UserId", new List<dbParam>() { new dbParam() { ParamName = "@UserId", ParamValue = ask.UserId } }).NickName,
                    ask.CreateTime.ToString("f")));
                    }

                    dic.Add("pagelist", sb.ToString());
                }
                return jss.Serialize(dic);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetSqlWhere()
        {
            string askcategory = context.Request.Form["askcategory"];
            string askstate = context.Request.Form["askstate"];
            string isreply = context.Request.Form["isreply"];
            StringBuilder sb = new StringBuilder();
            listPm = new List<dbParam>();
            sb.Append("1=1");
            if (askcategory == "0")
            {
                sb.Append(" and AskCategory>0");
            }
            else
            {
                sb.Append(" and AskCategory=@AskCategory");
                listPm.Add(new dbParam() { ParamName = "@AskCategory", ParamValue = Convert.ToInt32(askcategory) });
            }
            if (askstate == "0")
            {
                sb.Append(" and AskState>0");
            }
            else
            {
                sb.Append(" and AskState=@AskState");
                listPm.Add(new dbParam() { ParamName = "@AskState", ParamValue = Convert.ToInt32(askstate) });
            }
            if (isreply == "0")
            {
                sb.Append(" and IsReply>0");
            }
            else
            {
                sb.Append(" and IsReply=@IsReply");
                listPm.Add(new dbParam() { ParamName = "@IsReply", ParamValue = Convert.ToInt32(isreply) });
            }
            return sb.ToString();
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