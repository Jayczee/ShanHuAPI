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
    public class BBSDal
    {
        public int AddDialogue(Dialogue dialogue)
        {
            int res = SqlHelper.ExecuteNonQuery("insert into Dialogues(DName,DDetails,DURLs,DClass,DType,DUid,DWxid,DTime)values(@para1,@para2,@para3,@para4,@para5,@para6,@para7,@para8)",
                new SqlParameter("@para1",dialogue.DName),
                new SqlParameter("@para2", dialogue.DDetails),
                new SqlParameter("@para3", dialogue.DURLs),
                new SqlParameter("@para4", dialogue.DClass),
                new SqlParameter("@para5", dialogue.DType),
                new SqlParameter("@para6", dialogue.DUid),
                new SqlParameter("@para7", dialogue.DWxid),
                new SqlParameter("@para8", DateTime.Now.ToString("G")));
            return res;
        }

        public DataTable GetDialoguesByClass(string className)
        {
            return SqlHelper.ExecuteTable("select * from Dialogues where DClass=@para1",
                new SqlParameter("@para1", className));
        }

        public DataTable GetDialoguesByUid(string uid)
        {
            return SqlHelper.ExecuteTable("select * from Dialogues where DUid=@para1",
                new SqlParameter("@para1", uid));
        }

        public DataTable GetDialoguesByWxid(string wxid)
        {
            return SqlHelper.ExecuteTable("select * from Dialogues where DWxid=@para1",
                new SqlParameter("@para1", wxid));
        }

        public DataTable GetSupports(int dID)
        {
            return SqlHelper.ExecuteTable("select * from DialogueSupport where DID=@para1",
                new SqlParameter("@para1", dID));
        }

        public int UpdateDialogue(Dialogue dialogue)
        {
            int res = SqlHelper.ExecuteNonQuery("update Dialogues set DName=@para1,DDetails=@para2,DURLs=@para3,DClass=@para4,DType=@para5,DUid=@para6,DWxid=@para7,DTime=@para8 where DID=@para9",
                new SqlParameter("@para1", dialogue.DName),
                new SqlParameter("@para2", dialogue.DDetails),
                new SqlParameter("@para3", dialogue.DURLs),
                new SqlParameter("@para4", dialogue.DClass),
                new SqlParameter("@para5", dialogue.DType),
                new SqlParameter("@para6", dialogue.DUid),
                new SqlParameter("@para7", dialogue.DWxid),
                new SqlParameter("@para8", DateTime.Now.ToString("G")),
                new SqlParameter("@para9",dialogue.DID));
            return res;
        }

        public int DeleteDialogue(int dID)
        {
            return SqlHelper.ExecuteNonQuery("delete from Dialogues where DID=@para1",
                new SqlParameter("@para1",dID));
        }

        public DataTable GetReply(int dID)
        {
            return SqlHelper.ExecuteTable("select * from DialogueReply where DID=@para1",
                new SqlParameter("@para1", dID));
        }
    }
}
