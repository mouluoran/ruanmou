using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Model.Base;
namespace Model.ruanmou
{
    public class UserInfor:BaseModel
    {
        public UserInfor()
        {
            PrimaryKey = "UserId";
            DataBaseName = DataBaseEnum.ruanmou2014;
        }
        public int UserId { get; set; }
        public string RealName { get; set; }
        public string NickName { get; set; }
        public string Pwd { get; set; }
        public string PhoneNum { get; set; }
        public string Sex { get; set; }
        public string Phase { get; set; }
        public string QQ { get; set; }
        public string Message { get; set; }
        public int UserType { get; set; }//1表示管理员，2表示讲师，3表示学员，4表示咨询者
        public DateTime CreatedTime { get; set; }
        public string ClientIP { get; set; }
        public string HeadPic { get; set; }
    }
}
