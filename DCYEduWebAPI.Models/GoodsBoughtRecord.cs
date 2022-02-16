using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYEduWebAPI.Models
{
    public class GoodsBoughtRecord
    {
        private int _boughtid = 0;
        private int _boughtgoodsid = 0;
        private string _boughtgoodsname = "";
        private string _boughttime = "";
        private int _cost = 0;
        private string _condition = "";
        private string _handler = "";
        private string _buyer = "";
        private string _buyercardnum = "";

        public int Boughtid { get => _boughtid; set => _boughtid = value; }
        public int Boughtgoodsid { get => _boughtgoodsid; set => _boughtgoodsid = value; }
        public string Boughtgoodsname { get => _boughtgoodsname; set => _boughtgoodsname = value; }
        public string Boughttime { get => _boughttime; set => _boughttime = value; }
        public int Cost { get => _cost; set => _cost = value; }
        public string Condition { get => _condition; set => _condition = value; }
        public string Handler { get => _handler; set => _handler = value; }
        public string Buyercardnum { get => _buyercardnum; set => _buyercardnum = value; }
        public string Buyer { get => _buyer; set => _buyer = value; }
    }
}
