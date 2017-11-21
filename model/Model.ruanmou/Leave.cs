using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Model.Base;
namespace Model.ruanmou
{
    public class Leave : BaseModel
    {
        public Leave()
        {
            PrimaryKey = "LeaveId";
            DataBaseName = DataBaseEnum.ruanmou2014;
        }
        public int LeaveId { get; set; }
        public int UserId { get; set; }
        public string LeaveRecord { get; set; }
        public string CourseName { get; set; }
    }
}
