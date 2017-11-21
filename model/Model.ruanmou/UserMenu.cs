using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Model.Base;
namespace Model.ruanmou
{
    public class UserMenu:BaseModel
    {
        public UserMenu()
        {
            PrimaryKey = "MenuId";
            DataBaseName = DataBaseEnum.ruanmou2014;
        }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int ParentId { get; set; }
        public string Linkurl { get; set; }
        public bool Ishave1 { get; set; }
        public bool Ishave2 { get; set; }
        public bool Ishave3 { get; set; }
        public bool Ishave4 { get; set; }
    }
}
