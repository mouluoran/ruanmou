using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Model.Base;
namespace Model.ruanmou
{
    public class ZanRecord : BaseModel
    {
        public ZanRecord()
        {
            PrimaryKey = "ZanRId";
            DataBaseName = DataBaseEnum.ruanmou2014;
        }
        public int ZanRId { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public bool IsZan { get; set; }
        public int AskId { get; set; }
    }

}
