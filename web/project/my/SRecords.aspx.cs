using com.DAL.Base;
using DAL.ruanmou;
using Model.ruanmou;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project
{
    public partial class SRecords : System.Web.UI.Page
    {
        public string GetSignStr()
        {
            StringBuilder sb = new StringBuilder();
            UserInfor user = UserInforDal.CurrentUser();
            if (user != null)
            {
                Sign s = SignDal.m_SignDal.GetModel("UserId=@UserId", new List<dbParam>() { new dbParam() { ParamName = "@UserId", ParamValue = user.UserId } });
                if (s != null)
                {
                    string resign = s.AbsentRecord;
                    if (!string.IsNullOrEmpty(resign.Trim()))
                    {
                        sb.Append(@"<table class=""table-bordered table-hover"" id=""leavetab"">");
                        string[] a = resign.Substring(0, resign.Length - 1).Split(';');
                        int iNext = 0;
                        for (int i = 0; i < a.Length; i++)
                        {
                            if (i % 6 == 0)
                            {
                                sb.Append("<tr>");
                                iNext = i;
                            }
                            sb.Append(string.Format(@"<td>{0} 旷课</td>", a[i].ToString()));

                            if (i == iNext + 5)
                            {
                                sb.Append("</tr>");
                            }
                            if (a.Length % 6 != 0)
                            {
                                if (i == a.Length - 1)
                                {
                                    sb.Append("</tr>");
                                }
                            }
                        }
                        sb.Append(@"</table>");
                    }
                    else
                    {
                        sb.Append("无旷课记录");
                    }
                }
            }
            else
            {
                sb.Append("无旷课记录");
            }
            return sb.ToString();
        }
        public int GetSignCount()
        {
            UserInfor user = UserInforDal.CurrentUser();
            int i = 0;
            if (user != null)
            {
                Sign s = SignDal.m_SignDal.GetModel("UserId=@UserId", new List<dbParam>() { new dbParam() { ParamName = "@UserId", ParamValue = user.UserId } });
                if (s != null)
                {
                    string resign = s.AbsentRecord;
                    if (!string.IsNullOrEmpty(resign.Trim()))
                    {
                        string[] a = resign.Substring(0, resign.Length - 1).Split(';');
                        i = a.Length;
                    }
                }
            }
            return i;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserInforDal.CurrentUser() == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}