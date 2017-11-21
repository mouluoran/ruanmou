using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using DAL.ruanmou;
using Model.ruanmou;
using com.DAL.Base;
using System.Data;
using com.Utility;
namespace project
{
    public partial class QInfor : System.Web.UI.Page
    {
        public string GetAskViewTop()
        {
            StringBuilder sb = new StringBuilder();
            List<StuAsk> list = StuAskDal.m_StuAskDal.GetList("1=1", 10, 1, true, "AskId,Title,ViewCount", "ViewCount");
            sb.Append(@" <ol class=""fly-list-one"">");
            foreach (var ask in list)
            {
                string title = ask.Title.Length > 15 ? ask.Title.Substring(0, 15) + "..." : ask.Title;
                sb.Append(string.Format(@"<li><a href=""QInfor.aspx?qid={0}"">{1}</a><span>浏览{2}次</span></li>", ask.AskId, title, ask.ViewCount));

            }
            sb.Append(@" </ol>");
            return sb.ToString();
        }
        public string GetAskReplyTop()
        {
            StringBuilder sb = new StringBuilder();
            List<StuAsk> list = StuAskDal.m_StuAskDal.GetList("1=1", 10, 1, true, "AskId,Title,ReplyCount", "ReplyCount");
            sb.Append(@" <ol class=""fly-list-one"">");
            foreach (var ask in list)
            {
                string title = ask.Title.Length > 15 ? ask.Title.Substring(0, 15) + "..." : ask.Title;
                sb.Append(string.Format(@"<li><a href=""QInfor.aspx?qid={0}"">{1}</a><span>回复{2}次</span></li>", ask.AskId, title, ask.ReplyCount));

            }
            sb.Append(@" </ol>");
            return sb.ToString();
        }
        public string GetTeacherTeam()
        {
            StringBuilder sb = new StringBuilder();
            List<UserInfor> list = UserInforDal.m_UserInforDal.GetList("UserType=2");
            sb.Append("<ul>");
            foreach (var user in list)
            {
                sb.Append(string.Format(@"  <li class=""soreitem"">
                            <span>
                                <img src=""upfile/HeadPic/{0}"" class=""soreuser-pic"" /></span>
                            <span class=""soreuser-name"">{1}</span>
                        </li>", user.HeadPic, user.NickName));
            }
            sb.Append("</ul>");
            return sb.ToString();
        }
        private int _askId = 0;

        public int AskId
        {
            get
            {
                try
                {
                    _askId = Request.QueryString["qid"] == null ? 0 : Convert.ToInt32(Request.QueryString["qid"].ToString());
                }
                catch (Exception ex)
                {
                    _askId = 0;
                }
                return _askId;
            }
            set { _askId = value; }
        }
        StuAsk ask = null;
        public string GetAskCon()
        {
            StringBuilder sb = new StringBuilder();
            if (AskId > 0)
            {
                ask = StuAskDal.m_StuAskDal.GetModel("AskId=@AskId", new List<dbParam>() { 
                  new dbParam(){ ParamName="@AskId",ParamValue=AskId}
                });
                if (ask != null)
                {
                    string AskState = ask.AskState == 1 ? "已结贴" : "未结帖";
                    sb.Append(string.Format("<h1>{0}</h1>", ask.Title));
                    sb.Append(string.Format(@" <div class=""fly-tip fly-detail-hint"">
                        <span>{0}</span>
                        <div class=""fly-list-hint""><i title=""回答"">回复：</i> {1}次<i title=""人气"">浏览：</i>{2}次<i><a href=""#dpostask"" id=""areply"">回复</a></i></div>
                    </div>", AskState, ask.ReplyCount, ask.ViewCount));

                    UserInfor user = UserInforDal.m_UserInforDal.GetModel("UserId=@UserId", new List<dbParam>() { 
                  new dbParam(){ ParamName="@UserId",ParamValue=ask.UserId}
                });
                    if (user != null)
                    {
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
                            case 4:
                                cat = "小程序";
                                break;
                        }
                        sb.Append(string.Format(@"   <div class=""detail-about"">
                        <a class=""jie-user"" href=""javascript:;"">
                            <img src=""/upfile/HeadPic/{0}"">
                            <cite>【{1}】<em>发布于{2}</em></cite></a>
                        <div class=""detail-hits""><span style=""color: #FF7200"">分类：{3}</span></div>
                    </div>", user.HeadPic, user.NickName, ask.CreateTime.ToString("g"), cat));
                    }
                    sb.Append(string.Format(@"<div class=""detail-body photos"" style=""margin-bottom: 20px;"">{0}</div>", ask.AskText));
                }
            }
            else
            {
                sb.Append("没有相关数据");
            }
            return sb.ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            hidQId.Value = AskId.ToString();
            StuAsk ask = StuAskDal.m_StuAskDal.GetModel(string.Format("AskId=@AskId"), new List<dbParam>() {
                 new dbParam(){ ParamName="@AskId", ParamValue=AskId}
            });
            ask.ViewCount += 1;
            StuAskDal.m_StuAskDal.Update(ask);
        }


    }
}