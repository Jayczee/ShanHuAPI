using DCYEduWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DCYEduWebAPI.DAL;
using System.Data;

namespace DCYEduWebAPI.BLL
{
    public class NoticeBll
    {
        NoticeDal ndal = new();
        UserBll ubll = new();
        public bool UpdateNotice(Notice not)
        {
            int res= ndal.UpdateNotice(not);
            if (res > 0)
                return true;
            return false;
        }

        public bool DeleteNotice(int NID, string uid,string ip)
        {
            if (!ubll.CheckRequest(uid, ip))
                return false;
            int res = ndal.DeleteNotice(NID);
            if (res > 0)
                return true;
            return false;
        }

        public List<Notice> GetNoticesByClassName(string className, string uid, string ip)
        {
            if (!ubll.CheckRequest(uid, ip))
                return null;
            DataTable dt = ndal.GetNoticesByClassName(className);
            if (dt.Rows.Count <= 0)
                return null;
            List<Notice> list = new List<Notice>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                Notice no = new();
                no.NID = Int32.Parse(dt.Rows[i]["NID"].ToString());
                no.NTime= dt.Rows[i]["NTime"].ToString();
                no.NTitle= dt.Rows[i]["NTitle"].ToString();
                no.NDetails= dt.Rows[i]["NDetails"].ToString();
                no.NTeacher= dt.Rows[i]["NTeacher"].ToString(); 
                no.NClass= dt.Rows[i]["NClass"].ToString();
                list.Add(no);
            }
            return list;
        }

        public bool SetNoticeReadCondition(int nID, int sCardNum)
        {
            int res = ndal.SetNoticeReadCondition(nID, sCardNum);
            if (res >= 1)
                return true;
            return false;
        }

        public List<NoticeReadCondition> GetNoticeReadConditions(int nID, string uid, string ip)
        {
            if (!ubll.CheckRequest(uid, ip))
                return null;
            DataTable dtstu = ndal.GetStudentsByNID(nID);
            if (dtstu.Rows.Count <= 0)
                return null;
            List<NoticeReadCondition> list = new List<NoticeReadCondition>();
            for(int i = 0; i < dtstu.Rows.Count; i++)
            {
                NoticeReadCondition nrc = new();
                nrc.SCardNum = dtstu.Rows[i]["SCardNum"].ToString();
                nrc.SName= dtstu.Rows[i]["SName"].ToString();
                if (ndal.GetStuRecByCardNum(nrc.SCardNum) != null)
                    nrc.Con = "已读";
                list.Add(nrc);

            }
            return list;
        }
    }
}
