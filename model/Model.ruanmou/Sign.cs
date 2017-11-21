using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Model.Base;
namespace Model.ruanmou
{
    public class Sign : BaseModel
    {
        public Sign()
        {
            PrimaryKey = "SignId";
            DataBaseName = DataBaseEnum.ruanmou2014;
        }
        public int SignId { get; set; }
        public int UserId { get; set; }
        //public string SignRecord { get; set; }
        public string CourseName { get; set; }
        public string AbsentRecord { get; set; }
        public DateTime SignTime { get; set; }
        public bool IsSign { get; set; }
        public bool IsAbsent { get; set; }
    }
}
