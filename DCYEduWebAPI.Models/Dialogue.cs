using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYEduWebAPI.Models
{
    public class Dialogue
    {
        private int _DID = 0;
        private string _DName = "";
        private string _DDetails = "";
        private string _DURLs = "";
        private string _DClass = "";
        private string _DType = "";
        private string _DUid = "";
        private string _DWxid = "";
        private string _DTime = "";

        public int DID { get => _DID; set => _DID = value; }
        public string DName { get => _DName; set => _DName = value; }
        public string DDetails { get => _DDetails; set => _DDetails = value; }
        public string DURLs { get => _DURLs; set => _DURLs = value; }
        public string DClass { get => _DClass; set => _DClass = value; }
        public string DType { get => _DType; set => _DType = value; }
        public string DUid { get => _DUid; set => _DUid = value; }
        public string DWxid { get => _DWxid; set => _DWxid = value; }
        public string DTime { get => _DTime; set => _DTime = value; }
    }
}
