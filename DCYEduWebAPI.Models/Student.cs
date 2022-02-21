using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYEduWebAPI.Models
{
    public class Student
    {
        private string _sname = "";
        private string _scardnum = "";
        private string _sclass = "";
        private string _syear = "";
        private int _spoints = 0;
        private string _swxid = "";
        private string _sphonenum = "";
        private string _swxid2 = "";
        private int _stotalpoints = 0;
        private string _ssex = "";

        public string Sname { get => _sname; set => _sname = value; }
        public string Scardnum { get => _scardnum; set => _scardnum = value; }
        public string Sclass { get => _sclass; set => _sclass = value; }
        public string Syear { get => _syear; set => _syear = value; }
        public int Spoints { get => _spoints; set => _spoints = value; }
        public string Swxid { get => _swxid; set => _swxid = value; }
        public string Sphonenum { get => _sphonenum; set => _sphonenum = value; }
        public string Swxid2 { get => _swxid2; set => _swxid2 = value; }
        public int Stotalpoints { get => _stotalpoints; set => _stotalpoints = value; }
        public string Ssex { get => _ssex; set => _ssex = value; }
    }
}
