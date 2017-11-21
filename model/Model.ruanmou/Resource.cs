using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Model.Base;
namespace Model.ruanmou
{
    public class Resource : BaseModel
    {
        public Resource()
        {
            PrimaryKey = "ResourceId";
            DataBaseName = DataBaseEnum.ruanmou2014;
        }
        public int ResourceId { get; set; }
        public string ClassName { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedTime { get; set; }
        public int VCount { get; set; }
        public string Author { get; set; }
    }
}
