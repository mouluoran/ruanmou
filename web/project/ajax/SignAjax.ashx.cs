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
    /// SignAjax 的摘要说明
    /// </summary>
    public class SignAjax : IHttpHandler
    {
        string json = "";
        HttpContext context;
        JavaScriptSerializer jss = new JavaScriptSerializer();
        ReturnMessage rm = new ReturnMessage();
        string todayDate = DateTime.Now.ToShortDateString().ToString().Replace('-', '/');
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
                case "addsign":
                    json = AddSign();
                    break;
            }
            context.Response.Write(json);
        }
        public string AddSign()
        {
            UserInfor user = UserInforDal.CurrentUser();
            List<dbParam> list = new List<dbParam>() { new dbParam() { ParamName = "@UserId", ParamValue = user.UserId } };
            Sign s = SignDal.m_SignDal.GetModel("UserId=@UserId", list);

            s.IsSign = true;
            s.IsAbsent = false;
            s.SignTime = DateTime.Now;

            SignDal.m_SignDal.Update(s);
            rm.Info = "签到成功";
            return jss.Serialize(rm);
        }
        public string ShowBtnInfor()
        {

            UserInfor user = UserInforDal.CurrentUser();
            CourseSet cs = CourseSetDal.m_CourseSetDal.GetModel("CourseName=@CourseName", new List<dbParam>() { new dbParam() { ParamName = "@CourseName", ParamValue = user.Phase } });
            List<dbParam> list = new List<dbParam>() { new dbParam() { ParamName = "@UserId", ParamValue = user.UserId } };
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

            Sign s1 = SignDal.m_SignDal.GetModel(" DateDiff(dd,SignTime,getdate())=0 and IsSign='true' and IsAbsent='false' and UserId=@UserId", list);
            if (s1 != null)
            {
                rm.Info = "今天已签到";
                return jss.Serialize(rm);
            }
            Sign s2 = SignDal.m_SignDal.GetModel(" DateDiff(dd,SignTime,getdate())=0 and IsSign='false' and IsAbsent='true' and UserId=@UserId", list);
            if (s2 != null)
            {
                rm.Info = "今天签到已过期";
                return jss.Serialize(rm);
            }
            string[] aWeek = cs.CWeek.Split(',');
            bool isC = false;
            foreach (var a in aWeek)
            {
                if (a == Week())
                {
                    isC = true;
                }
            }
            if (isC == false)
            {
                rm.Info = "今天没有课";
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
        /// <summary>
        /// 获取今天是星期几
        /// </summary>
        /// <returns></returns>
        public string Week()
        {
            string[] weekdays = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = weekdays[Convert.ToInt32(DateTime.Now.DayOfWeek)];
            return week;
        }
    }
}