using DAL.ruanmou;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model.ruanmou;
using System.Text;
using com.Utility;
namespace project
{
    public partial class NewsList : System.Web.UI.Page
    {
        private int _page;

        public int page
        {
            get
            {
                try
                {
                    _page = Request.QueryString["page"] == null ? 1 : Convert.ToInt32(Request.QueryString["page"].ToString());
                }
                catch
                {
                    _page = 1;
                }
                return _page;
            }
            set { _page = value; }
        }

        public string GetPagerHtml()
        {
            string s = "";
            s = PagerDal.GetPagerHtml(page, 10, RNewsDal.m_RNewsDal.GetCount("1=1"));
            return s;
        }
        public string GetNewsList()
        {
            StringBuilder sb = new StringBuilder();
            List<RNews> list = RNewsDal.m_RNewsDal.GetList("1=1", 10, page, true, "*", "CreatedTime");
            foreach (var r in list)
            {
                string txt = CRegex.FilterHTML(r.Text).Length > 150 ? CRegex.FilterHTML(r.Text).Substring(0, 150) + "..." : CRegex.FilterHTML(r.Text);
                sb.Append(string.Format(@"<div class=""newsitem"">
                    <div class=""news_title""><a href=""NewsPage.aspx?newsid={0}"">{1}</a></div>
                    <div class=""news_con"">{2}</div>
                    <div><div class=""count"">浏览数({3})</div><div class=""date"">({4})&nbsp;&nbsp;&nbsp;&nbsp;{5}</div></div>
                </div>", r.NewsId, r.Title, txt, r.ViewCount, r.NewsClass, r.CreatedTime.GetDateTimeFormats('f')[0].ToString()));
            }
            return sb.ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}