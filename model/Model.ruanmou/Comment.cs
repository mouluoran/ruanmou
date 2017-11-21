using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Model.Base;
namespace Model.ruanmou
{
    public class Comment : BaseModel
    {
        public Comment()
        {
            PrimaryKey = "CommentId";
            DataBaseName = DataBaseEnum.ruanmou2014;
        }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int AskId { get; set; }
        public DateTime CreateTime { get; set; }
        public string ComText { get; set; }
        public string ClientIP { get; set; }
        public int ZanCount { get; set; }
        public bool IsAdopt { get; set; }
    }
}
