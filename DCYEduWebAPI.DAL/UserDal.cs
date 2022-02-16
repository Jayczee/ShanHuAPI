using System;
using System.Data;
using System.Data.SqlClient;
using DCYEduWebAPI.Models;

namespace DCYEduWebAPI.DAL
{
    public class UserDal
    {
       public DataTable LoginCheck(string uid,string pwd)
        {
            DataTable res = SqlHelper.ExecuteTable("select * from userinf where Uid=@para1 and Pwd=@para2",
                new SqlParameter("@para1", uid),
                new SqlParameter("@para2", pwd));
            return res;
        }

        public int SetUserLoginTime(string uid,string time)
        {
            int res = SqlHelper.ExecuteNonQuery("update userinf set LastLoginTime = @Time where Uid=@uid",
                new SqlParameter("@uid", uid),
                new SqlParameter("@Time",Convert.ToDateTime(time)));
            return res;
        }

        public int SetUserLoginIP(string uid,string ip)
        {
            int res = SqlHelper.ExecuteNonQuery("update userinf set LastLoginIP = @ip",
                new SqlParameter("@ip", ip),
                new SqlParameter("@uid", uid));
            return res;
        }

        public string GetLastLoginIP(string uid)
        {
            object res = SqlHelper.ExecuteScalar("select LastLoginIP from userinf where Uid = @para1",
                new SqlParameter("@para1", uid));
            if (res != null)
                return res.ToString();
            else
                return "";
        }

        public DataTable WXLogin(string wxid)
        {
            return SqlHelper.ExecuteTable("select * from student where SWxId=@para1 or SWxId2=@para1",
                new SqlParameter("@para1",wxid));
        }

        public string GetLastLoginTime(string uid)
        {
            object res = SqlHelper.ExecuteScalar("select LastLoginTime from userinf where Uid = @para1",
                new SqlParameter("@para1", uid));
            if (res != null)
                return res.ToString();
            else
                return "";
        }

        public int WXBind(string stuName,string stuCardNum, string wxid)
        {
            DataTable dt = SqlHelper.ExecuteTable("select * from student where SName = @para1 and SCardNum=@para2",
                new SqlParameter("@para1",stuName),
                new SqlParameter("@para2",stuCardNum));
            if (dt.Rows.Count <= 0)
                return -1;
            if (dt.Rows[0]["SWxId"] == null || dt.Rows[0]["SWxId"].ToString() == "")
            {
                return SqlHelper.ExecuteNonQuery("update student set SWxId = @para3 where SName = @para1 and SCardNum=@para2",
                    new SqlParameter("@para1", stuName),
                    new SqlParameter("@para2", stuCardNum),
                    new SqlParameter("@para3", wxid));
            }
            else if (dt.Rows[0]["SWxId2"] == null || dt.Rows[0]["SWxId2"].ToString() == "")
            {
                return SqlHelper.ExecuteNonQuery("update student set SWxId2 = @para3 where SName = @para1 and SCardNum=@para2",
                    new SqlParameter("@para1", stuName),
                    new SqlParameter("@para2", stuCardNum),
                    new SqlParameter("@para3", wxid));
            }
            else
                return 0;
        }
    }
}
