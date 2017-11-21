using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Model.Base;
namespace Model.ruanmou
{
    public class RNews:BaseModel
    {
        public RNews()
        {
            PrimaryKey = "NewsId";
            DataBaseName = DataBaseEnum.ruanmou2014;
        }

         public int NewsId{get;set;}
         public string Title { get; set; }
         public string Text { get; set; }
         public DateTime CreatedTime { get; set; }
         public string NewsClass { get; set; }
         public int ViewCount { get; set; }
    }
}
