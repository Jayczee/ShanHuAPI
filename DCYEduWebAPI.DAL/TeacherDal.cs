using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DCYEduWebAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace DCYEduWebAPI.DAL
{
    public class TeacherDal
    {
        public DataTable GetTeacherInf(string uid)
        {
            DataTable res = SqlHelper.ExecuteTable("select * from Teacher where Uid=@para1",
                new SqlParameter("@para1", uid));
            return res;
        }

        public bool UpdateTeacherInf(Teacher t)
        {
            int res = SqlHelper.ExecuteNonQuery("update Teacher set Tname =@para1,TCardNum=@para2,PhoneNumber=@para3 where Uid=@para4",
                new SqlParameter("@para1", t.tname),
                new SqlParameter("@para2",t.cardnum),
                new SqlParameter("@para3",t.phonenum),
                new SqlParameter("@para4",t.uid)) ;
            if (res >= 1)
                return true;
            return false;
        }

        public DataTable GetClassInf(string uid)
        {
            DataTable res = SqlHelper.ExecuteTable("select * from classinfo where CTUid1=@para1 or CTUid2=@para2",
                new SqlParameter("@para1", uid),
                new SqlParameter("@para2", uid));
            return res;
        }

        public DataTable GetAllClass()
        {
            DataTable res = SqlHelper.ExecuteTable("select * from classinfo");
            return res;
        }

        public int CheckPower(string uid)
        {
            object obj= SqlHelper.ExecuteScalar("select Userkind from userinf where Uid=@para1",
                new SqlParameter("@para1", uid));
            if (obj != null)
                return Int32.Parse(obj.ToString());
            return -1;
        }
    }
}
