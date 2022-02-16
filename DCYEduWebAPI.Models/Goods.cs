using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYEduWebAPI.Models
{
    public class Goods
    {
        private int _goodsid = 0;
        private string _goodsname = "";
        private int _storage = 0;
        private string _goodsdetails = "";
        private string _goodsurl = "";
        private string _goodsurlcloud = "";
        private int _goodsprice = 0;

        public int Goodsid { get => _goodsid; set => _goodsid = value; }
        public string Goodsname { get => _goodsname; set => _goodsname = value; }
        public int Storage { get => _storage; set => _storage = value; }
        public string Goodsdetails { get => _goodsdetails; set => _goodsdetails = value; }
        public string Goodsurllocal { get => _goodsurl; set => _goodsurl = value; }
        public int Goodsprice { get => _goodsprice; set => _goodsprice = value; }
        public string Goodsurlcloud { get => _goodsurlcloud; set => _goodsurlcloud = value; }
    }
}
