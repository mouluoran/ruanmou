using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Model.Base;
namespace Model.ruanmou
{
    public class CourseSet:BaseModel
    {
        public CourseSet()
        {
            PrimaryKey = "CourseSetId";
            DataBaseName = DataBaseEnum.ruanmou2014;
        }
        public int CourseSetId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CWeek { get; set; }
        public string CourseName { get; set; }
    }
}
