using DCYEduWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DCYEduWebAPI.DAL
{
    public class NoticeDal
    {
        public int UpdateNotice(Notice not)
        {
            int res = SqlHelper.ExecuteNonQuery("insert into SchoolNotice(NTime,NTitle,NDetails,NTeacher,NClass)values(@para1,@para2,@para3,@para4,@para5)",
                new SqlParameter("@para1", not.NTime),
                new SqlParameter("@para2", not.NTitle),
                new SqlParameter("@para3", not.NDetails),
                new SqlParameter("@para4", not.NTeacher),
                new SqlParameter("@para5", not.NClass));
            return res;
        }

        public int DeleteNotice(int NID)
        {
            int res = SqlHelper.ExecuteNonQuery("delete from SchoolNotice where NID=@para1",
                new SqlParameter("@para1",NID));
            return res;
        }

        public DataTable GetNoticesByClassName(string className)
        {
            DataTable dt = SqlHelper.ExecuteTable("select * from SchoolNotice where NClass=@para1",
                new SqlParameter("@para1", className));
            return dt;
        }

        public DataTable GetStudentsByNID(int NID)
        {
            DataTable dt = SqlHelper.ExecuteTable("select * from (select * from student s INNER JOIN classinfo c on s.SClassNo=c.CNo) t WHERE t.CName=(SELECT NClass from SchoolNotice where NID=@para1)",
                new SqlParameter("@para1", NID));
            return dt;
        }

        public DataTable GetReadConByNID(int NID)
        {
            DataTable dt = SqlHelper.ExecuteTable("select * from NoticeReadRecord where NID=@para1)",
                new SqlParameter("@para1", NID));
            return dt;
        }

        public object GetStuRecByCardNum(string CardNum)
        {
            return SqlHelper.ExecuteScalar("select NRID from NoticeReadRecord where SCardNum=@para1",
                new SqlParameter("@para1", CardNum));
        }

        public int SetNoticeReadCondition(int nID, int sCardNum)
        {
            DataTable dt = SqlHelper.ExecuteTable("select * from NoticeReadRecord where NID =@para1 and SCardNum=@para2",
                new SqlParameter("@para1", nID),
                new SqlParameter("@para2", sCardNum));
            if (dt.Rows.Count>0)
                return 1;
            return SqlHelper.ExecuteNonQuery("insert into NoticeReadRecord(NID,SCardNum)values(@para1,@para2)",
                new SqlParameter("@para1", nID),
                new SqlParameter("@para2", sCardNum));
        }
    }
}
