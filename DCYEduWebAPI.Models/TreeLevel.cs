using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYEduWebAPI.Models
{
    public class TreeLevel
    {
        private int _L1 = 0;
        private int _L2 = 0;
        private int _L3 = 0;
        private int _L4 = 0;
        private int _L5 = 0;

        public int L1 { get => _L1; set => _L1 = value; }
        public int L2 { get => _L2; set => _L2 = value; }
        public int L3 { get => _L3; set => _L3 = value; }
        public int L4 { get => _L4; set => _L4 = value; }
        public int L5 { get => _L5; set => _L5 = value; }
    }
}
