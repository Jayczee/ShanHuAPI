using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYEduWebAPI.Models
{
    public class DialogueReply
    {
        private int _DRID = 0;
        private int _DID = 0;
        private string _DRUid = "";
        private string _DRWxid = "";
        private string _DRDetails = "";
        private string _DRTime = "";

        public int DRID { get => _DRID; set => _DRID = value; }
        public int DID { get => _DID; set => _DID = value; }
        public string DRUid { get => _DRUid; set => _DRUid = value; }
        public string DRWxid { get => _DRWxid; set => _DRWxid = value; }
        public string DRDetails { get => _DRDetails; set => _DRDetails = value; }
        public string DRTime { get => _DRTime; set => _DRTime = value; }
    }
}
