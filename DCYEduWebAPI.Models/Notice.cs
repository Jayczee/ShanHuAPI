using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYEduWebAPI.Models
{
    public class Notice
    {
        private int _NID=0;
        private string _NTime="";
        private string _NTitle="";
        private string _NDetails="";
        private string _NTeacher="";
        private string _NClass="";

        public int NID { get => _NID; set => _NID = value; }
        public string NTime { get => _NTime; set => _NTime = value; }
        public string NTitle { get => _NTitle; set => _NTitle = value; }
        public string NDetails { get => _NDetails; set => _NDetails = value; }
        public string NTeacher { get => _NTeacher; set => _NTeacher = value; }
        public string NClass { get => _NClass; set => _NClass = value; }

    }
}
