using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DCYEduWebAPI.Models;
using DCYEduWebAPI.DAL;
using System.Data;

namespace DCYEduWebAPI.BLL
{
    public class TeacherBll
    {
        TeacherDal tdal= new();
        UserBll userbll = new();
        public Teacher GetTeacherInf(string uid,string ip)
        {
            if (!userbll.CheckRequest(uid, ip))
                return null;
            DataTable dt=tdal.GetTeacherInf(uid);
            DataRow dr = dt.Rows[0];
            Teacher t = new();
            t.tname = dr["Tname"].ToString();
            t.uid = dr["Uid"].ToString();
            t.cardnum = dr["TCardNum"].ToString();
            t.wxid = dr["WxId"].ToString();
            t.phonenum = dr["PhoneNumber"].ToString();
            return t;
        }

        public bool UpdateTeacherInf(Teacher t)
        {
            return tdal.UpdateTeacherInf(t);
        }

        public List<string> GetClassInf(string uid, string ip)
        {
            if (!userbll.CheckRequest(uid, ip))
                return null;
            DataTable dt = tdal.GetClassInf(uid);
            if (dt.Container == null)
            {
                if (tdal.CheckPower(uid) == -1)
                    return null;
                else if (tdal.CheckPower(uid) == 0)
                    dt = tdal.GetAllClass();
                List<string> list = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                    list.Add(dt.Rows[i]["CName"].ToString());
                return list;
            }
            else
            {
                List<string> list = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                    list.Add(dt.Rows[i]["CName"].ToString());
                return list;
            }
        }
    }
}
