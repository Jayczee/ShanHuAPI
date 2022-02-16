using DCYEduWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYEduWebAPI.DAL
{
    public class MallDal
    {
        public DataTable GetGoodsInfo()
        {
            DataTable res = SqlHelper.ExecuteTable("select * from Goods");
            return res;
        }

        public int AddGoodsInfo(Goods goods)
        {
            int res= SqlHelper.ExecuteNonQuery("insert into Goods(GoodsName,Storage,GoodsDetails,PictureURLLocal,Price,PictureURLCloud)values(@para1,@para2,@para3,@para4,@para5,@para6)",
                new SqlParameter("@para1",goods.Goodsname),
                new SqlParameter("@para2",goods.Storage),
                new SqlParameter("@para3",goods.Goodsdetails),
                new SqlParameter("@para4",goods.Goodsurllocal),
                new SqlParameter("@para5",goods.Goodsprice),
                new SqlParameter("@para6",goods.Goodsurlcloud));
            return res;
        }

        public int UpdateGoodsInfo(Goods goods)
        {
            int res = SqlHelper.ExecuteNonQuery("update Goods set GoodsName=@para1,Storage=@para2,GoodsDetails=@para3,PictureURLLocal=@para4,Price=@para5 ,PictureURLCloud=@para7 where GoodsID=@para6",
                 new SqlParameter("@para1", goods.Goodsname),
                new SqlParameter("@para2", goods.Storage),
                new SqlParameter("@para3", goods.Goodsdetails),
                new SqlParameter("@para4", goods.Goodsurllocal),
                new SqlParameter("@para5", goods.Goodsprice),
                new SqlParameter("@para7", goods.Goodsurlcloud),
            new SqlParameter("@para6",goods.Goodsid));
            return res;
        }

        public int DeleteGoodsInfoByID(string goodsID)
        {
            int res = SqlHelper.ExecuteNonQuery("Delete Goods where GoodsID=@para1",
                new SqlParameter("@para1", goodsID));
            return res;
        }

        public DataTable GetBoughtRecordByClass(string classname)
        {
            DataTable res = SqlHelper.ExecuteTable("select BoughtID,BoughtGoodsID,BoughtGoodsName,BoughtTime,Cost,Condition,Handler,BuyerCardNum,Buyer from GoodsBoughtRecord as b INNER JOIN (select * from student as s INNER JOIN classinfo as c ON s.SClassNo=c.CNo) as a on b.BuyerCardNum=a.SCardNum WHERE CName=@para1",
                new SqlParameter("@para1",classname));
            return res;
        }

        public int UpdateBoughtRecord(int boughtid, string con,string uid)
        {
            int res = SqlHelper.ExecuteNonQuery("update GoodsBoughtRecord set Condition=@para1,Handler=(select TName from teacher where Uid =@para3) where BoughtID=@para2",
                new SqlParameter("@para1", con),
                new SqlParameter("@para2",boughtid),
                new SqlParameter("@para3",uid));
            return res;
        }

        public DataTable GetGoodsInfoByGoodsID(int goodsID)
        {
            return SqlHelper.ExecuteTable("select * from Goods WHERE GoodsID=@para1",
                new SqlParameter("@para1", goodsID));
        }

        public void BuyGoods(Goods goods,Student s,string wxid)
        {
            SqlHelper.ExecuteNonQuery("update student set SPoints =@para1 where SWxId=@para2 or SWxId2=@para2",
                new SqlParameter("@para1",s.Spoints-goods.Goodsprice),
                new SqlParameter("@para2",wxid));
            SqlHelper.ExecuteNonQuery("insert into GoodsBoughtRecord(BoughtGoodsID,BoughtGoodsName,BoughtTime,Cost,Condition,BuyerCardNum,Buyer)values(@para1,@para2,@para3,@para4,@para5,@para6,@para7)",
                new SqlParameter("@para1", goods.Goodsid),
                new SqlParameter("@para2", goods.Goodsname),
                new SqlParameter("@para3", DateTime.Now.ToString("G")),
                new SqlParameter("@para4", goods.Goodsprice),
                new SqlParameter("@para5", "待处理"),
                new SqlParameter("@para6", s.Scardnum),
                new SqlParameter("@para7",s.Sname));
        }
    }
}
