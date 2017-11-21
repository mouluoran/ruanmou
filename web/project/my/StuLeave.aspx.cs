using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.ruanmou;
using Model.ruanmou;
using System.Text;
using com.DAL.Base;
namespace project
{
    public partial class StuLeave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserInforDal.CurrentUser() == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        public string GetLeaveStr()
        {
            StringBuilder sb = new StringBuilder();
            UserInfor user = UserInforDal.CurrentUser();
            if (user != null)
            {
                Leave l = LeaveDal.m_LeaveDal.GetModel("UserId=@UserId", new List<dbParam>() { new dbParam() { ParamName = "@UserId", ParamValue = user.UserId } });
                if (l != null)
                {
                    string releave = l.LeaveRecord;
                    if (!string.IsNullOrEmpty(releave.Trim()))
                    {
                        sb.Append(@"<table class=""table-bordered table-hover"" id=""leavetab"">");
                        string[] a = l.LeaveRecord.Substring(0, l.LeaveRecord.Length - 1).Split(';');
                        int iNext = 0;
                        for (int i = 0; i < a.Length; i++)
                        {
                            if (i % 6 == 0)
                            {
                                sb.Append("<tr>");
                                iNext = i;
                            }
                            sb.Append(string.Format(@"<td>{0} 请假</td>", a[i].ToString()));

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
                        sb.Append("无请假记录");
                    }
                }
            }
            else
            {
                sb.Append("无请假记录");
            }
            return sb.ToString();
        }
        public int GetLeaveCount()
        {
            UserInfor user = UserInforDal.CurrentUser();
            int i = 0;
            if (user != null)
            {
                Leave l = LeaveDal.m_LeaveDal.GetModel("UserId=@UserId", new List<dbParam>() { new dbParam() { ParamName = "@UserId", ParamValue = user.UserId } });
                if (l != null)
                {
                    string releave = l.LeaveRecord;
                    if (!string.IsNullOrEmpty(releave.Trim()))
                    {
                        string[] a = l.LeaveRecord.Substring(0, l.LeaveRecord.Length - 1).Split(';');
                        i = a.Length;
                    }
                }
            }
            return i;
        }
    }
}