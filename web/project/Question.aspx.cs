using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model.ruanmou;
using DAL.ruanmou;
using System.Text;
using System.Data;
using com.DAL.Base;
namespace project
{
    public partial class Question : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }
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
            foreach (var user in list) {
                sb.Append(string.Format(@"  <li class=""soreitem"">
                            <span>
                                <img src=""upfile/HeadPic/{0}"" class=""soreuser-pic"" /></span>
                            <span class=""soreuser-name"">{1}</span>
                        </li>", user.HeadPic,user.NickName));
            }
            sb.Append("</ul>");
            return sb.ToString();
        }
    }
}