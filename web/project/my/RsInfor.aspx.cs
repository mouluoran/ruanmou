using DAL.ruanmou;
using Model.ruanmou;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.DAL.Base;
namespace project
{
    public partial class RsInfor : System.Web.UI.Page
    {
        private int _rid = 0;

        public int Rid
        {
            get
            {
                try
                {
                    _rid = Request.QueryString["rid"] == null ? 0 : Convert.ToInt32(Request.QueryString["rid"].ToString());
                }
                catch
                {
                    _rid = 0;
                }
                return _rid;
            }
            set { _rid = value; }
        }
        public string GetRsInfor()
        {
            if (Rid > 0)
            {
                Resource rs = ResourceDal.m_ResourceDal.GetModel(string.Format("ResourceId=@ResourceId"), new List<dbParam>() {
                   new dbParam(){ ParamName="@ResourceId", ParamValue=Rid}
                });
                return rs.Text;
            }
            else
            {
                return "没有相关资源";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfor user = UserInforDal.CurrentUser();
            if (user == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!(user.UserType == 3 || user.UserType == 5))
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }
    }
}