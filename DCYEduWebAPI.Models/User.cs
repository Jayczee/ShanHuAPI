using System;

namespace DCYEduWebAPI.Models
{
    public class User
    {
        private string _uid = "";
        private int _userkind = 0;
        private string _lastlogintime = "";
        private string _laseloginip = "";
        
        public string uid { get { return _uid; } set { _uid = value; } }
        public int userkind { get { return _userkind; } set { _userkind = value; } }
        public string lastlogintime { get { return _lastlogintime; } set { _lastlogintime = value; } }
        public string lastloginip { get { return _laseloginip; } set { _laseloginip = value; } }

    }
}
