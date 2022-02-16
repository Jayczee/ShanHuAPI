using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYEduWebAPI.Models
{
    public class Teacher
    {
        private string _uid = "";
        private string _tname = "";
        private string _cardnum = "";
        private string _wxid = "";
        private string _phonenum = "";

        public string uid { get { return _uid; } set { _uid = value; } }
        public string tname { get { return _tname; } set { _tname = value; } }
        public string cardnum { get { return _cardnum; } set{ _cardnum = value; } } 
        public string wxid { get { return _wxid; } set { _wxid = value; } }
        public string phonenum { get { return _phonenum; } set { _phonenum = value; } }
    }
}
