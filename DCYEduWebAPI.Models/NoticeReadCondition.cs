using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYEduWebAPI.Models
{
    public class NoticeReadCondition
    {
        private string _SCardNum="";
        private string _SName="";
        private string _Con="未读";

        public string SCardNum { get => _SCardNum; set => _SCardNum = value; }
        public string SName { get => _SName; set => _SName = value; }
        public string Con { get => _Con; set => _Con = value; }
    }
}
