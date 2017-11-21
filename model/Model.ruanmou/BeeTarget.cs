using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Model.Base;
namespace Model.ruanmou
{
    public class BeeTarget : BaseModel
    {
        public BeeTarget()
        {
            PrimaryKey = "TargetId";
            DataBaseName = DataBaseEnum.ruanmou2014;
        }

        public int TargetId { get; set; }
        public string BeeQQ { get; set; }

        public string TargetQQ { get; set; }

 

        public string TranModel { get; set; } 

        public string ConverDate { get; set; }

        public string CourseType { get; set; }
    }
}
