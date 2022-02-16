using DCYEduWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DCYEduWebAPI.DAL;

namespace DCYEduWebAPI.BLL
{
    public class StudentsBll
    {
        UserBll ubll = new();
        StudentsDal sdal = new();
        public List<Student> GetStudentsByClassName(string classname, string uid, string ip)
        {
            if (!ubll.CheckRequest(uid, ip))
                return null;
            List<Student> list = new List<Student>();
            DataTable dt = sdal.GetStudentsByClassName(classname);
            if (dt.Rows.Count <= 0)
                return null;
            else
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    Student s = new Student();
                    s.Sname = dt.Rows[i]["SName"].ToString();
                    s.Scardnum = dt.Rows[i]["SCardNum"].ToString();
                    s.Sclass = classname;
                    s.Syear = dt.Rows[i]["SYear"].ToString();
                    s.Swxid = dt.Rows[i]["SWxId"].ToString();
                    s.Spoints = Int32.Parse(dt.Rows[i]["SPoints"].ToString());
                    s.Sphonenum = dt.Rows[i]["SPhone"].ToString();
                    s.Swxid2 = dt.Rows[i]["SWxId2"].ToString();
                    s.Stotalpoints = Int32.Parse(dt.Rows[i]["STotalPoints"].ToString());
                    list.Add(s);
                }
            return list;
        }

        public bool UpDateStudentByCardNum(Student s, string uid, string ip)
        {
            if (!ubll.CheckRequest(uid, ip))
                return false;
            return sdal.UpdateStudentByCardNum(s);
        }

        public Student GetStudentBySCardNum(string sCardNum, string uid, string ip)
        {
            if (!ubll.CheckRequest(uid, ip))
                return null;
            DataTable dt = sdal.GetStudentsBySCardNum(sCardNum);
            if (dt.Rows.Count <= 0)
                return null;
            Student s = new();
            DataRow dr = dt.Rows[0];
            s.Scardnum = sCardNum;
            s.Sname = dr["SName"].ToString();
            s.Sclass = GetClassNameByNo(dr["SClassNo"].ToString());
            s.Syear = dr["SYear"].ToString();
            s.Swxid = dr["SWxId"].ToString();
            s.Spoints = Int32.Parse(dr["SPoints"].ToString());
            s.Sphonenum = dr["SPhone"].ToString();
            s.Swxid2 = dr["SWxId2"].ToString();
            s.Stotalpoints= Int32.Parse(dr["STotalPoints"].ToString());
            return s;
        }

        string GetClassNoByName(string classname)
        {
            return sdal.GetClassNoByName(classname);
        }

        string GetClassNameByNo(string no)
        {
            return sdal.GetClassNameByNo(no);
        }
    }
}
