using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.ruanmou;
using DAL.ruanmou;
using System.Web.Script.Serialization;
using com.DAL.Base;
namespace webnew.ajax
{
    /// <summary>
    /// BeeAjax 的摘要说明
    /// </summary>
    public class BeeAjax : IHttpHandler
    {
        public string rMsg = "";
        HttpContext context = null;
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            string type = context.Request.Form["type"];
            switch (type)
            {
                case "insert":
                    rMsg = InsertQQs();
                    break;
            }
            context.Response.Write(rMsg);
        }

        public string InsertQQs()
        {
            string qq = UserInforDal.CurrentUser().QQ;
            string d = context.Request.Form["d"];
            string qqs = context.Request.Form["qqs"];
            string coursetype = context.Request.Form["coursetype"];
            List<dbParam> list = new List<dbParam>(){
               new dbParam(){ ParamName="@TargetQQS", ParamValue=qqs}
            };
            int count = BeeTeamDal.m_BeeTeamDal.GetCount("TargetQQS=@TargetQQS", list);
            if (count > 0)
            {
                return "exis";
            }
            else
            {
                BeeTeam b = new BeeTeam();
                b.BeeQQ = qq;
                b.CreatedTime = d;
                b.TargetQQS = qqs;
                b.EffectiveNum = 0;
                b.IsAudit = "未审";
                b.CourseType = coursetype;
                if (BeeTeamDal.m_BeeTeamDal.Add(b) > 0)
                {
                    return "ok";
                }
                else
                {
                    return "error";
                }
            }
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