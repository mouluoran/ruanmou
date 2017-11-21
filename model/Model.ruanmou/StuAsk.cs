using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Model.Base;
namespace Model.ruanmou
{
    public class StuAsk : BaseModel
    {
        public StuAsk()
        {
            PrimaryKey = "AskId";
            DataBaseName = DataBaseEnum.ruanmou2014;
        }
        public int AskId { get; set; }
        public string Title { get; set; }
        public string AskText { get; set; }
        public int AskCategory { get; set; }//1表示前端，2表示.net，3表示java，4小程序
        public DateTime CreateTime { get; set; }
        public int UserId { get; set; }
        public string ClientIP { get; set; }
        public int AskState { get; set; }//1表示结帖，2表示未结贴
        public int IsReply { get; set; }//1表示回复，2表示已回复

        public int ViewCount { get; set; }
        public int ReplyCount { get; set; }
    }

}
