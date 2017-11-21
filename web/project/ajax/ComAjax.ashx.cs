using com.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Model.ruanmou;
using DAL.ruanmou;
using com.Utility;
using com.DAL.Base;
using System.Data;
namespace project
{
    /// <summary>
    /// ComAjax 的摘要说明
    /// </summary>
    public class ComAjax : IHttpHandler
    {
        string json = "";
        HttpContext context;
        JavaScriptSerializer jss = new JavaScriptSerializer();
        ReturnMessage rm = new ReturnMessage();
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            context.Request.ContentEncoding = Encoding.GetEncoding("utf-8");
            string cmd = context.Request.Form["cmd"];
            switch (cmd)
            {
                case "add":
                    json = AddCom();
                    break;
                case "comlist":
                    json = GetComList(Convert.ToInt32(context.Request.Form["askid"].ToString()));
                    break;
                case "clcomlist":
                    json = GetComList(Convert.ToInt32(context.Request.Form["askid"].ToString()), Convert.ToInt32(context.Request.Form["comid"].ToString()));
                    break;
                case "checkisower":
                    json = CheckIsOwer(Convert.ToInt32(context.Request.Form["askid"].ToString()));
                    break;
                case "dianzan":
                    json = DianZan(Convert.ToInt32(context.Request.Form["askid"].ToString()), Convert.ToInt32(context.Request.Form["comid"].ToString()));
                    break;
            }
            context.Response.Write(json);
        }
        public string DianZan(int askid, int comid)
        {
            UserInfor user = UserInforDal.CurrentUser();
            List<dbParam> list = new List<dbParam>() {new dbParam(){ ParamName="@UserId", ParamValue=user.UserId},
            new dbParam(){ ParamName="@CommentId", ParamValue=comid}, new dbParam(){ ParamName="@AskId", ParamValue=askid}};
            ZanRecord zan = ZanRecordDal.m_ZanRecordDal.GetModel(@"UserId=@UserId and CommentId=@CommentId and AskId=@AskId and
            IsZan='true'", list);
            if (zan == null)
            {
                ZanRecord z = new ZanRecord();
                rm.Info = "点赞成功";
                rm.Success = true;
                z.UserId = user.UserId;
                z.CommentId = comid;
                z.AskId = askid;
                z.IsZan = true;
                ZanRecordDal.m_ZanRecordDal.Add(z);
                Comment com = CommentDal.m_CommentDal.GetModel("CommentId=@CommentId", new List<dbParam>() { 
                        new dbParam(){ ParamName="@CommentId", ParamValue=comid}
                        });
                com.ZanCount += 1;
                CommentDal.m_CommentDal.Update(com);
            }
            else
            {
                rm.Info = "不能重复点赞";
            }
            return jss.Serialize(rm);
        }
        public string CheckIsOwer(int askid)
        {
            StuAsk ask = StuAskDal.m_StuAskDal.GetModel("AskId=@AskId", new List<dbParam>() { 
                        new dbParam(){ ParamName="@AskId", ParamValue=askid}
                        });
            if (ask.UserId == UserInforDal.CurrentUser().UserId)
            {
                rm.Success = true;
            }
            return jss.Serialize(rm);
        }
        public string GetComList(int AskId, int ComId)
        {
            StuAsk ask = StuAskDal.m_StuAskDal.GetModel("AskId=@AskId", new List<dbParam>() { 
                        new dbParam(){ ParamName="@AskId", ParamValue=AskId}
                        });
            ask.AskState = 1;
            StuAskDal.m_StuAskDal.Update(ask);
            Comment com = CommentDal.m_CommentDal.GetModel("CommentId=@CommentId", new List<dbParam>() { 
                        new dbParam(){ ParamName="@CommentId", ParamValue=ComId}
                        });
            com.IsAdopt = true;
            CommentDal.m_CommentDal.Update(com);
            return GetComList(AskId);
        }
        public string GetComList(int AskId)
        {
            StringBuilder sb = new StringBuilder();
            StuAsk ask = StuAskDal.m_StuAskDal.GetModel("AskId=@AskId", new List<dbParam>() { 
                        new dbParam(){ ParamName="@AskId", ParamValue=AskId}
                        });
            if (ask != null)
            {
                sb.Append(string.Format(@"<h2 class=""page-title"">热忱回答<span>（<em id=""jiedaCount"">{0}</em>）</span></h2>", ask.ReplyCount));
            }
            if (AskId > 0)
            {
                sb.Append(@"<ul class=""jieda photos"" id=""jieda"">");
                int AskState = ask.AskState;
                DataTable dt = CommentDal.GetRMBComList(AskId);
                int rCount = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    if (AskState == 2)
                    {
                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            sb.Append(string.Format(@"  <li class=""jieda-daan"">
                        <div class=""detail-about detail-about-reply"">
                            <a class=""jie-user"" href=""javascript:;"">
                                <img src=""/upfile/HeadPic/{0}"">
                                <cite><i>{1}楼：{2}</i><em style=""color: #5FB878"">(老师答疑)</em> </cite></a>
                            <div class=""detail-hits""><span>{3}</span></div>
                        </div>
                        <div class=""detail-body jieda-body"">{4}</div>
                        <div class=""jieda-reply""><span class=""jieda-zan"" id=""zan-{6}""><i class=""iconfont icon-zan""></i><em>{5}</em></span><span class=""reply""><i class=""iconfont icon-svgmoban53""></i>回复</span><span class=""adopt"" id=""adopt-{6}""><i class=""iconfont icon-room""></i>采纳</span></div>
                    </li>", dt.Rows[i][0].ToString(), i + 1, dt.Rows[i][1].ToString(), Convert.ToDateTime(dt.Rows[i][6].ToString()).ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][7].ToString()));
                        }
                    }
                    else
                    {
                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            bool IsAdopt = Convert.ToBoolean(dt.Rows[i][4].ToString());
                            if (IsAdopt)
                            {
                                sb.Append(string.Format(@"  <li class=""jieda-daan"">
                                        <div class=""detail-about detail-about-reply"">
                                            <a class=""jie-user"" href=""javascript:;"">
                                                <img src=""/upfile/HeadPic/{0}"">
                                                <cite><i>{1}楼：{2}</i><em style=""color: #5FB878"">(老师答疑)</em> </cite></a>
                                            <div class=""detail-hits""><span>{3}</span></div>
                                            <i class=""iconfont icon-caina"" title=""最佳答案""></i>
                                        </div>
                                        <div class=""detail-body jieda-body"">{4}</div>
                                        <div class=""jieda-reply""><span class=""jieda-zan"" id=""zan-{6}""><i class=""iconfont icon-zan""></i><em>{5}</em>          </span><span class=""reply""><i class=""iconfont icon-svgmoban53""></i>回复</span></div>
                                    </li>", dt.Rows[i][0].ToString(), i + 1, dt.Rows[i][1].ToString(), Convert.ToDateTime(dt.Rows[i][6].ToString()).ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][7].ToString()));
                            }
                            else
                            {
                                sb.Append(string.Format(@"  <li class=""jieda-daan"">
                                        <div class=""detail-about detail-about-reply"">
                                            <a class=""jie-user"" href=""javascript:;"">
                                                <img src=""/upfile/HeadPic/{0}"">
                                                <cite><i>{1}楼：{2}</i><em style=""color: #5FB878"">(老师答疑)</em> </cite></a>
                                            <div class=""detail-hits""><span>{3}</span></div>
                                        </div>
                                        <div class=""detail-body jieda-body"">{4}</div>
                                        <div class=""jieda-reply""><span class=""jieda-zan"" id=""zan-{6}""><i class=""iconfont icon-zan""></i><em>{5}</em>          </span><span class=""reply""><i class=""iconfont icon-svgmoban53""></i>回复</span></div>
                                    </li>", dt.Rows[i][0].ToString(), i + 1, dt.Rows[i][1].ToString(), Convert.ToDateTime(dt.Rows[i][6].ToString()).ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][7].ToString()));
                            }
                        }

                    }
                }

                DataTable dt1 = CommentDal.GetComList(AskId);
                if (dt1.Rows.Count > 0)
                {
                    for (var j = 0; j < dt1.Rows.Count; j++)
                    {
                        sb.Append(string.Format(@"<li class=""jieda-daan"">
                                        <div class=""detail-about detail-about-reply"">
                                            <a class=""jie-user"" href=""javascript:;"">
                                                <img src=""/upfile/HeadPic/{0}"">
                                                <cite><i>{1}楼：{2}</i></cite></a>
                                            <div class=""detail-hits""><span>{3}</span></div>
                                        </div>
                                        <div class=""detail-body jieda-body"">{4}</div>
                                        <div class=""jieda-reply""><span class=""jieda-zan"" class=""zan""><i class=""iconfont icon-zan""></i><em>{5}</em></span><span class=""reply""><i class=""iconfont icon-svgmoban53""></i>回复</span></div>
                                    </li>", dt1.Rows[j][0].ToString(), j + 1 + rCount, dt1.Rows[j][1].ToString(), Convert.ToDateTime(dt1.Rows[j][6].ToString()).ToString(), dt1.Rows[j][3].ToString(), dt1.Rows[j][5].ToString()));
                    }
                }

                sb.Append("</ul>");
            }
            return sb.ToString();
        }
        public string AddCom()
        {
            int askid = Convert.ToInt32(context.Request.Form["askid"].ToString());
            string text = context.Request.Form["comtext"].ToString();
            if (CRegex.FilterHTML(text) == "")
            {
                rm.Info = "内容不能为空";
                return jss.Serialize(rm);
            }
            if (CRegex.FilterHTML(text).Length > 700 || CRegex.FilterHTML(text).Length < 6)
            {
                rm.Info = "回复内容长度在6~700之间";
                return jss.Serialize(rm);
            }
            else
            {
                string strIP = WebHelp.GetIP();
                List<dbParam> list = new List<dbParam>() { new dbParam() { ParamName = "@ClientIP", ParamValue = strIP },
                new dbParam() { ParamName = "@Time", ParamValue =  DateTime.Now.ToString("yyyy-MM-dd") }};
                int count = CommentDal.m_CommentDal.GetCount(" ClientIP=@ClientIP and CONVERT(varchar(100), CreateTime, 23)=@Time", list);
                UserInfor user = UserInforDal.CurrentUser();
                if (count >= 10 && user.UserType == 3)//vip学员一天只能回复10次
                {
                    rm.Info = "一天最多只能回复10次";
                    jss.Serialize(rm);
                }
                else
                {
                    if (user.UserType == 4)
                    {
                        rm.Info = "只有软谋正式学员才能评论";
                        jss.Serialize(rm);
                    }
                    else
                    {
                        Comment com = new Comment();
                        com.AskId = askid;
                        com.ComText = text;
                        com.CreateTime = DateTime.Now;
                        com.ClientIP = WebHelp.GetIP();
                        com.UserId = user.UserId;
                        CommentDal.m_CommentDal.Add(com);
                        rm.Success = true;
                        rm.Info = "评论成功";
                        StuAsk ask = StuAskDal.m_StuAskDal.GetModel("AskId=@AskId", new List<dbParam>() { 
                        new dbParam(){ ParamName="@AskId", ParamValue=askid}
                        });
                        ask.ReplyCount += 1;
                        ask.IsReply = 1;
                        StuAskDal.m_StuAskDal.Update(ask);
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
    }
}