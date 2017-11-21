using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Model.ruanmou;
using DAL.ruanmou;
using com.DAL.Base;
namespace project
{
    public partial class NewsPage : System.Web.UI.Page
    {
        private int _NewsId;
        public int NewsId
        {
            get
            {
                try
                {
                    _NewsId = Request.QueryString["newsid"] == null ? 0 : int.Parse(Request.QueryString["newsid"]);
                }
                catch
                {
                    _NewsId = 0;
                }
                return _NewsId;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.ruanmou.RNews ns = RNewsDal.m_RNewsDal.GetModel("NewsId=@NewsId", new List<dbParam>() { new dbParam() { ParamName = "@NewsId", ParamValue = NewsId } });
                if (ns != null)
                {
                    ns.ViewCount += 1;
                    RNewsDal.m_RNewsDal.Update(ns);
                    GetNews();
                }
            }
        }
        public string GetTitle()
        {
            string sTitle = "";
            if (NewsId > 0)
            {
                Model.ruanmou.RNews rn = RNewsDal.m_RNewsDal.GetModel("NewsId=@NewsId", new List<dbParam>() { new dbParam() { ParamName = "@NewsId", ParamValue = NewsId } });
                if (rn != null)
                {
                    sTitle = rn.Title;
                }
            }
            return sTitle;
        }
        public string GetNews()
        {
            StringBuilder sb = new StringBuilder();
            if (NewsId > 0)
            {
                Model.ruanmou.RNews rn = RNewsDal.m_RNewsDal.GetModel("NewsId=@NewsId", new List<dbParam>() { new dbParam() { ParamName = "@NewsId", ParamValue = NewsId } });
                if (rn != null)
                {
                    sb.Append(string.Format(@" <h1 class=""qitem_title"">{0}</h1>
                <div class=""qitem_question"">
                    <div class=""qitem_item"">
                        <div class=""q_content"">{1}</div>
                        <div class=""question_author"">
                            <span class=""v-split"">|</span>
                            <span>{2}</span>
                            <span class=""v-split"">|</span>
                            <span>浏览数: ({3})</span>
                            <span class=""v-split"">|</span>
                            <span>发表于：{4}</span>
                        </div>
                    </div>
                </div>", rn.Title, rn.Text, rn.NewsClass, rn.ViewCount, rn.CreatedTime.GetDateTimeFormats('f')[0].ToString()));
                }
            }
            return sb.ToString();
        }
    }
}