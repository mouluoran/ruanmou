using com.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Model.ruanmou;
using DAL.ruanmou;
using com.DAL.Base;

namespace webnew.ajax
{
    /// <summary>
    /// LeaveAjax 的摘要说明
    /// </summary>
    public class LeaveAjax : IHttpHandler
    {
        string json = "";
        HttpContext context;
        JavaScriptSerializer jss = new JavaScriptSerializer();
        ReturnMessage rm = new ReturnMessage();
        string todayDate = DateTime.Now.ToShortDateString().ToString();

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            context.Request.ContentEncoding = Encoding.GetEncoding("utf-8");
            string cmd = context.Request.QueryString["cmd"];
            switch (cmd)
            {
                case "showbtninfor":
                    json = ShowBtnInfor();
                    break;
                case "addleave":
                    json = AddLeave();
                    break;
            }
            context.Response.Write(json);
        }
        public string AddLeave()
        {
            UserInfor user = UserInforDal.CurrentUser();
            List<dbParam> list = new List<dbParam>() { new dbParam() { ParamName = "@UserId", ParamValue = user.UserId } };
            Leave s = LeaveDal.m_LeaveDal.GetModel("UserId=@UserId", list);
            s.LeaveRecord = s.LeaveRecord.Trim() + todayDate + ";";
            LeaveDal.m_LeaveDal.Update(s);

            //请假后，则记签到
            Sign s1 = SignDal.m_SignDal.GetModel("UserId=@UserId", list);
            s1.SignTime = DateTime.Now;
            s1.IsSign = true;
            s1.IsAbsent = false;

            SignDal.m_SignDal.Update(s1);

            rm.Info = "请假成功";
            return jss.Serialize(rm);
        }
        public string ShowBtnInfor()
        {

            UserInfor user = UserInforDal.CurrentUser();
            List<dbParam> list = new List<dbParam>() { new dbParam() { ParamName = "@UserId", ParamValue = user.UserId } };
            Leave s = LeaveDal.m_LeaveDal.GetModel("UserId=@UserId", list);
            Sign s1 = SignDal.m_SignDal.GetModel(" DateDiff(dd,SignTime,getdate())=0 and IsSign='true' and IsAbsent='false' and UserId=@UserId", list);
            if (s1 != null)
            {
                rm.Info = "今天已签到";
                return jss.Serialize(rm);
            }
            Sign s2 = SignDal.m_SignDal.GetModel(" DateDiff(dd,SignTime,getdate())=0 and IsSign='false' and IsAbsent='true' and UserId=@UserId", list);
            if (s2 != null)
            {
                rm.Info = "今天请假已过期";
                return jss.Serialize(rm);
            }
            CourseSet cs = CourseSetDal.m_CourseSetDal.GetModel("CourseName=@CourseName", new List<dbParam>() { new dbParam() { ParamName = "@CourseName", ParamValue = user.Phase } });
            if (DateTime.Now < cs.StartTime)
            {
                rm.Info = user.Phase + "还未开始";
                return jss.Serialize(rm);
            }
            if (DateTime.Now > cs.EndTime)
            {
                rm.Info = user.Phase + "已经结束";
                return jss.Serialize(rm);
            }
            string[] aWeek = cs.CWeek.Split(',');
            bool b = false;
            foreach (var a in aWeek)
            {
                if (a == Week())
                {
                    b = true;
                }
            }
            if (b == false)
            {
                rm.Info = "今天没课";
                return jss.Serialize(rm);
            }
            if (!string.IsNullOrEmpty(s.LeaveRecord))
            {
                string strRecord = s.LeaveRecord.Substring(0, s.LeaveRecord.Length - 1).Trim();
                string[] aRecord = strRecord.Split(';');
                foreach (var a in aRecord)
                {
                    if (a == todayDate)
                    {
                        rm.Info = "今天已请假";
                    }
                }
            }
            return jss.Serialize(rm);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public string Week()
        {
            string[] weekdays = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = weekdays[Convert.ToInt32(DateTime.Now.DayOfWeek)];
            return week;
        }
    }
}