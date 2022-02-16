using System;
using System.Collections.Generic;
using System.Data;
using DCYEduWebAPI.DAL;
using DCYEduWebAPI.Models;
using Microsoft.AspNetCore.Http;
using System.Xml;

namespace DCYEduWebAPI.BLL
{
    public class UserBll
    {
        UserDal userdal = new UserDal();
        StudentsDal sdal = new();
        public User Login(string uid,string pwd,string ip)
        {
            DataTable dt = userdal.LoginCheck(uid, pwd);
            if (dt.Rows.Count > 0)
            {
                User user = new();
                DataRow dr = dt.Rows[0];
                user.uid = dr["Uid"].ToString();
                user.userkind = Int32.Parse(dr["UserKind"].ToString());
                SetUserLoginTime(user.uid);
                SetUserLoginIP(uid, ip);
                user.lastlogintime = DateTime.Now.ToString("F");
                user.lastloginip = ip;
                return user;
            }
            else
                return null;
        }

        private int SetUserLoginTime(string uid)
        {
            DateTime time = DateTime.Now;
            return userdal.SetUserLoginTime(uid, time.ToString("F"));
        }

        public Student WXLogin(string wxid)
        {
            DataTable dt = userdal.WXLogin(wxid);
            if (dt.Rows.Count <= 0)
                return null;
            Student s = new();
            s.Sname = dt.Rows[0]["SName"].ToString();
            s.Sphonenum= dt.Rows[0]["SPhone"].ToString();
            s.Scardnum= dt.Rows[0]["SCardNum"].ToString();
            s.Sclass= dt.Rows[0]["SClassNo"].ToString();
            s.Spoints = Int32.Parse(dt.Rows[0]["SPoints"].ToString());
            s.Syear= dt.Rows[0]["SYear"].ToString();
            s.Swxid= dt.Rows[0]["SWxId"].ToString();
            s.Swxid2= dt.Rows[0]["SWxId2"].ToString();
            return s;
        }

        private int SetUserLoginIP(string uid,string ip)
        {
            return userdal.SetUserLoginIP(uid,ip);
        }

        public string GetLastLoginIP(string uid)
        {
            return userdal.GetLastLoginIP(uid);
        }

        public string GetLastLoginTime(string uid)
        {
            return userdal.GetLastLoginTime(uid);
        }

        public bool CheckRequest(string uid,string ip)
        {
            string servertype = SqlHelper.GetServerType();
            if (servertype != "local")//检查代码是本地部署还是云端部署，云端部署给WX小程序用直接返回true
                return true;
            string lastip = GetLastLoginIP(uid);
            if (ip != lastip)
                return false;
            DateTime t = Convert.ToDateTime(GetLastLoginTime(uid));
            TimeSpan ts = Convert.ToDateTime(DateTime.Now.ToString("F")).Subtract(t);
            double itv = ts.TotalSeconds;
            if (itv > 3600*12)
                return false;
            return true;
        }

        public int WXBind(string stuName,string stuCardNum,string wxid)
        {
            return userdal.WXBind(stuName,stuCardNum, wxid);
        }
    }
}
