using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.DAL.Base;
using Model.ruanmou;
using System.Data;

namespace DAL.ruanmou
{
    public class LeaveDal
    {
        public static BaseDAL<Leave> m_LeaveDal = new BaseDAL<Leave>();

        public static DataTable GetLeaveList(int pagesize, int pageindex, string sqlwhere,List<dbParam> list)
        {
            DataTable dt;
            string sql = string.Format(@"SELECT TOP {0} * 
FROM 
        (
        SELECT ROW_NUMBER() OVER (ORDER BY LeaveId desc) AS RowNumber,* FROM 
         (select U.UserId,U.NickName,U.PhoneNum,U.QQ,L.LeaveId,L.LeaveRecord,L.CourseName
from UserInfor U inner join Leave L
on U.UserId=L.UserId) AB
        ) A
WHERE RowNumber > {0}*({1}-1) and {2}", pagesize, pageindex, sqlwhere);
            dt = SqlHelper.ExecuteDataTable(com.Model.Base.DataBaseEnum.ruanmou2014, sql, CommandType.Text, list);
            return dt;
        }
        public static DataTable GetLeaveListCount(string sqlWhere, List<dbParam> list)
        {
            DataTable dt;
            string sql = string.Format(@"select count(*) as rowNum from (select U.UserId,U.NickName,U.PhoneNum,U.QQ,L.LeaveId,L.LeaveRecord,L.CourseName
from UserInfor U inner join Leave L
on U.UserId=L.UserId) AB where  {0}", sqlWhere);
            dt = SqlHelper.ExecuteDataTable(com.Model.Base.DataBaseEnum.ruanmou2014, sql, CommandType.Text, list);

            return dt;
        }
    }
}
