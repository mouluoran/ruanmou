using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Model.Base;
namespace Model.ruanmou
{
    public class BeeTeam : BaseModel
    {
        public BeeTeam()
        {
            PrimaryKey = "BeeId";
            DataBaseName = DataBaseEnum.ruanmou2014;
        }

        public int BeeId { get; set; }
        public string BeeQQ { get; set; }

        public string CreatedTime { get; set; }

        public string TargetQQS { get; set; }

        public int EffectiveNum { get; set; }

        public string CourseType { get; set; }

        public string IsAudit { get; set; }
    }
}
