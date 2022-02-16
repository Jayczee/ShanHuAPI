using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYEduWebAPI.Models
{
    public class DialogueSupport
    {
        private int _DSID = 0;
        private int _DID = 0;
        private string _DSUid = "";
        private string _DSWxid = "";

        public int DSID { get => _DSID; set => _DSID = value; }
        public int DID { get => _DID; set => _DID = value; }
        public string DSUid { get => _DSUid; set => _DSUid = value; }
        public string DSWxid { get => _DSWxid; set => _DSWxid = value; }
    }
}
