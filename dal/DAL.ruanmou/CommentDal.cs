using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.DAL.Base;
using Model.ruanmou;
using System.Data;
namespace DAL.ruanmou
{
    public class CommentDal
    {
        public static BaseDAL<Comment> m_CommentDal = new BaseDAL<Comment>();
        public static DataTable GetComList(int askid)
        {
            DataTable dt;
            List<dbParam> list = new List<dbParam>() { new dbParam() { ParamName = "@AskId", ParamValue = askid } };
            string sql = @"select UI.HeadPic,UI.NickName,UI.UserType,CM.ComText,CM.IsAdopt,CM.ZanCount,CM.CreateTime,CM.CommentId
from UserInfor UI inner join Comment CM on UI.UserId=CM.UserId where CM.AskId=@AskId and UI.UserType!=2 order by CM.CreateTime desc";
            dt = SqlHelper.ExecuteDataTable(com.Model.Base.DataBaseEnum.ruanmou2014, sql, CommandType.Text, list);
            return dt;
        }
        public static DataTable GetRMBComList(int askid)
        {
            DataTable dt;
            List<dbParam> list = new List<dbParam>() { new dbParam() { ParamName = "@AskId", ParamValue = askid } };
            string sql = @"select UI.HeadPic,UI.NickName,UI.UserType,CM.ComText,CM.IsAdopt,CM.ZanCount,CM.CreateTime,CM.CommentId
from UserInfor UI inner join Comment CM on UI.UserId=CM.UserId where CM.AskId=@AskId and UI.UserType=2 order by CM.IsAdopt desc";
            dt = SqlHelper.ExecuteDataTable(com.Model.Base.DataBaseEnum.ruanmou2014, sql, CommandType.Text, list);
            return dt;
        }
    }
}
