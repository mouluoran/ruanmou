using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Model.Base;
namespace Model.ruanmou
{
    public class QQGroup : BaseModel
    {
        public QQGroup()
        {
            PrimaryKey = "Id";
            DataBaseName = DataBaseEnum.ruanmou2014;
        }
        public int Id { get; set; }
        public int GroupNumber { get; set; }
        public string Keyword { get; set; }
        public string GroupName { get; set; }
        public int GroupUserCount { get; set; }
    }
}
