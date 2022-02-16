using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYEduWebAPI.Models
{
    public class TeachingResource
    {
        private int _TRID=0;
        private string _TRName="";
        private string _TRType = "";
        private string _TRURL = "";
        private string _TRDetails = "";
        private string _TRTime = "";
        private string _TRClass = "";
        private string _TRTeacher = "";

        public int TRID { get => _TRID; set => _TRID = value; }
        public string TRName { get => _TRName; set => _TRName = value; }
        public string TRType { get => _TRType; set => _TRType = value; }
        public string TRURL { get => _TRURL; set => _TRURL = value; }
        public string TRDetails { get => _TRDetails; set => _TRDetails = value; }
        public string TRTime { get => _TRTime; set => _TRTime = value; }
        public string TRClass { get => _TRClass; set => _TRClass = value; }
        public string TRTeacher { get => _TRTeacher; set => _TRTeacher = value; }
    }
}
