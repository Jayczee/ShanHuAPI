using DCYEduWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYEduWebAPI.DAL
{
    public class TeachingResourceDal
    {
        public DataTable GetTeachingResourcesByClassName(string className)
        {
            DataTable res = SqlHelper.ExecuteTable("select * from TeachingResource where TRClass=@para1",
                new SqlParameter("@para1",className));
            return res;
        }

        public int AddTeachingResources(TeachingResource tr)
        {
            int res = SqlHelper.ExecuteNonQuery("insert into TeachingResource(TRName,TRType,TRURL,TRDetails,TRTime,TRClass,TRTeacher)values(@para1,@para2,@para3,@para4,@para5,@para6,@para7)",
                new SqlParameter("@para1",tr.TRName),
                new SqlParameter("@para2",tr.TRType),
                new SqlParameter("@para3",tr.TRURL),
                new SqlParameter("@para4",tr.TRDetails),
                new SqlParameter("@para5",tr.TRTime),
                new SqlParameter("@para6",tr.TRClass),
                new SqlParameter("@para7",tr.TRTeacher));
            return res;
        }

        public int DeleteTeachingResources(string trid)
        {
            int res = SqlHelper.ExecuteNonQuery("delete from TeachingResource where trid = @para1",
                new SqlParameter("@para1",trid));
            return res;
        }
    }
}
