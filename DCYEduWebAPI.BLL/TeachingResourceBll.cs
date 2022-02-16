using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DCYEduWebAPI.DAL;
using DCYEduWebAPI.Models;
using System.Data;

namespace DCYEduWebAPI.BLL
{
    public class TeachingResourceBll
    {
        UserBll ubll = new();
        TeachingResourceDal trdal = new();
        public List<TeachingResource> GetTeachingResourcesByClassName(string className, string uid, string ip)
        {
            if (!ubll.CheckRequest(uid, ip))
                return null;
            DataTable dt = trdal.GetTeachingResourcesByClassName(className);
            if (dt.Rows.Count <= 0)
                return null;
            List<TeachingResource> list = new();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                TeachingResource tr = new();
                tr.TRID = Int32.Parse(dt.Rows[i]["TRID"].ToString());
                tr.TRName = dt.Rows[i]["TRName"].ToString();
                tr.TRType = dt.Rows[i]["TRType"].ToString();
                tr.TRURL = dt.Rows[i]["TRURL"].ToString();
                tr.TRDetails = dt.Rows[i]["TRDetails"].ToString();
                tr.TRTime = dt.Rows[i]["TRTime"].ToString();
                tr.TRClass = dt.Rows[i]["TRClass"].ToString();
                tr.TRTeacher = dt.Rows[i]["TRTeacher"].ToString();
                list.Add(tr);
            }
            return list;
        }

        public bool DeleteTeachingResources(string trid, string uid, string ip)
        {
            if (!ubll.CheckRequest(uid, ip))
                return false;
            int res = trdal.DeleteTeachingResources(trid);
            if (res >= 1)
                return true;
            return false;
        }

        public bool AddTeachingResources(TeachingResource tr, string uid, string ip)
        {
            if (!ubll.CheckRequest(uid, ip))
                return false;
            int res = trdal.AddTeachingResources(tr);
            if (res > 0)
                return true;
            return false;
        }
    }
}
