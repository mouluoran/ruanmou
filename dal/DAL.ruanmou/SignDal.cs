using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.DAL.Base;
using Model.ruanmou;
using System.Data;
namespace DAL.ruanmou
{
    public class SignDal
    {
        public static BaseDAL<Sign> m_SignDal = new BaseDAL<Sign>();

        public static DataTable GetSignList(int pagesize, int pageindex, string sqlwhere,List<dbParam> list)
        {
            DataTable dt;
            string sql = string.Format(@"SELECT TOP {0} * 
FROM 
        (
        SELECT ROW_NUMBER() OVER (ORDER BY SignId desc) AS RowNumber,* FROM 
         (select U.UserId,U.NickName,U.PhoneNum,U.QQ,S.SignId,S.IsSign,S.IsAbsent,S.SignTime,S.CourseName,
S.AbsentRecord from UserInfor U inner join Sign S on
U.UserId=S.UserId where {2}) AB
        ) A
WHERE RowNumber > {0}*({1}-1)", pagesize, pageindex, sqlwhere);
            dt = SqlHelper.ExecuteDataTable(com.Model.Base.DataBaseEnum.ruanmou2014, sql, CommandType.Text, list);
            return dt;
        }
        public static DataTable GetSignListCount(string sqlWhere,List<dbParam> list)
        {
            DataTable dt;
            string sql = string.Format(@"select count(*) as rowNum from (select U.UserId,U.NickName,U.PhoneNum,U.QQ,S.SignId,S.IsSign,S.IsAbsent,S.SignTime,S.CourseName,
S.AbsentRecord from UserInfor U inner join Sign S on
U.UserId=S.UserId) AB where  {0}", sqlWhere);
            dt = SqlHelper.ExecuteDataTable(com.Model.Base.DataBaseEnum.ruanmou2014, sql, CommandType.Text, list);

            return dt;
        }
    }
}
