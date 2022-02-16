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
    public class BBSBll
    {
        BBSDal bdal = new();
        public bool AddDialogue(Dialogue dialogue)
        {
            int res = bdal.AddDialogue(dialogue);
            if (res > 0)
                return true;
            return false;
        }

        public List<Dialogue> GetDialoguesByClass(string className)
        {
            DataTable dt = bdal.GetDialoguesByClass(className);
            if (dt.Rows.Count <= 0)
                return null;
            List<Dialogue> list = new List<Dialogue>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                Dialogue d = new();
                d.DID = Int32.Parse(dt.Rows[i]["DID"].ToString());
                d.DName = dt.Rows[i]["DName"].ToString();
                d.DDetails = dt.Rows[i]["DDetails"].ToString();
                d.DURLs = dt.Rows[i]["DURLs"].ToString();
                d.DClass = dt.Rows[i]["DClass"].ToString();
                d.DType = dt.Rows[i]["DType"].ToString();
                d.DUid = dt.Rows[i]["DUid"].ToString();
                d.DWxid = dt.Rows[i]["DWxid"].ToString();
                d.DTime = dt.Rows[i]["DTime"].ToString();
                list.Add(d);
            }
            return list;
        }

        public List<DialogueSupport> GetSupports(int dID)
        {
            DataTable dt = bdal.GetSupports(dID);
            if (dt.Rows.Count <= 0)
                return null;
            List<DialogueSupport> list = new List<DialogueSupport>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                DialogueSupport ds = new();
                ds.DSID = Int32.Parse(dt.Rows[i]["DSID"].ToString());
                ds.DID = Int32.Parse(dt.Rows[i]["DID"].ToString());
                ds.DSUid = dt.Rows[i]["DSUid"].ToString();
                ds.DSWxid = dt.Rows[i]["DSWxid"].ToString();
                list.Add(ds);
            }
            return list;
        }

        public bool DeleteDialogue(int dID)
        {
            if (bdal.DeleteDialogue(dID) > 0)
                return true;
            return false;
        }

        public List<DialogueReply> GetReply(int dID)
        {
            DataTable dt = bdal.GetReply(dID);
            if (dt.Rows.Count <= 0)
                return null;
            List<DialogueReply> list = new List<DialogueReply>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DialogueReply dr = new();
                dr.DRID = Int32.Parse(dt.Rows[i]["DRID"].ToString());
                dr.DID = Int32.Parse(dt.Rows[i]["DID"].ToString());
                dr.DRUid = dt.Rows[i]["DRUid"].ToString();
                dr.DRWxid = dt.Rows[i]["DRWxid"].ToString();
                dr.DRTime= dt.Rows[i]["DRTime"].ToString();
                dr.DRDetails= dt.Rows[i]["DRDetails"].ToString();
                list.Add(dr);
            }
            return list;
        }

        public bool UpdateDialogue(Dialogue dialogue)
        {
            int res = bdal.UpdateDialogue(dialogue);
            if (res > 0)
                return true;
            return false;
        }

        public List<Dialogue> GetDialoguesByWxid(string wxid)
        {
            DataTable dt = bdal.GetDialoguesByWxid(wxid);
            if (dt.Rows.Count <= 0)
                return null;
            List<Dialogue> list = new List<Dialogue>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Dialogue d = new();
                d.DID = Int32.Parse(dt.Rows[i]["DID"].ToString());
                d.DName = dt.Rows[i]["DName"].ToString();
                d.DDetails = dt.Rows[i]["DDetails"].ToString();
                d.DURLs = dt.Rows[i]["DURLs"].ToString();
                d.DClass = dt.Rows[i]["DClass"].ToString();
                d.DType = dt.Rows[i]["DType"].ToString();
                d.DUid = dt.Rows[i]["DUid"].ToString();
                d.DWxid = dt.Rows[i]["DWxid"].ToString();
                d.DTime = dt.Rows[i]["DTime"].ToString();
                list.Add(d);
            }
            return list;
        }

        public List<Dialogue> GetDialoguesByUid(string uid)
        {
            DataTable dt = bdal.GetDialoguesByUid(uid);
            if (dt.Rows.Count <= 0)
                return null;
            List<Dialogue> list = new List<Dialogue>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Dialogue d = new();
                d.DID = Int32.Parse(dt.Rows[i]["DID"].ToString());
                d.DName = dt.Rows[i]["DName"].ToString();
                d.DDetails = dt.Rows[i]["DDetails"].ToString();
                d.DURLs = dt.Rows[i]["DURLs"].ToString();
                d.DClass = dt.Rows[i]["DClass"].ToString();
                d.DType = dt.Rows[i]["DType"].ToString();
                d.DUid = dt.Rows[i]["DUid"].ToString();
                d.DWxid = dt.Rows[i]["DWxid"].ToString();
                d.DTime = dt.Rows[i]["DTime"].ToString();
                list.Add(d);
            }
            return list;
        }
    }
}
