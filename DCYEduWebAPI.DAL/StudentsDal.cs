using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DCYEduWebAPI.Models;

namespace DCYEduWebAPI.DAL
{
    public class StudentsDal
    {
        public DataTable GetStudentsByClassName(string classname)
        {
            DataTable res = SqlHelper.ExecuteTable("select * from student where SClassNo=(select CNo from classinfo where CName=@para1)",
                new SqlParameter("@para1", classname));
            return res;
        }

        public string GetClassNoByName(string classname)
        {
            object obj = SqlHelper.ExecuteScalar("select CNo from classinfo where CName=@para1",
                new SqlParameter("@para1", classname));
            if (obj == null)
                return "";
            return obj.ToString();
        }

        public string GetClassNameByNo(string no)
        {
            object obj = SqlHelper.ExecuteScalar("select CName from classinfo where CNo=@para1",
                new SqlParameter("@para1", no));
            if (obj == null)
                return "";
            return obj.ToString();
        }

        public DataTable GetStudentsBySCardNum(string sCardNum)
        {
            DataTable res = SqlHelper.ExecuteTable("select * from student where SCardNum=@para1",
                new SqlParameter("@para1", sCardNum));
            return res;
        }

        public bool UpdateStudentByCardNum(Student s)
        {
            string sno = GetClassNoByName(s.Sclass);
            int res = SqlHelper.ExecuteNonQuery("update student set Sname =@para1,SClassNo=@para2,SYear=@para3,SPoints=@para4,SWxId=@para5,SPhone=@para6 where SCardNum=@para7,SWxId2=@para8",
                new SqlParameter("@para1", s.Sname),
                new SqlParameter("@para2", sno),
                new SqlParameter("@para3", s.Syear),
                new SqlParameter("@para4", s.Spoints),
                new SqlParameter("@para5", s.Swxid),
                new SqlParameter("@para6", s.Sphonenum),
                new SqlParameter("@para7", s.Scardnum),
                new SqlParameter("@para8",s.Swxid2));
            if (res >= 1)
                return true;
            return false;
        }

        
    }
}
