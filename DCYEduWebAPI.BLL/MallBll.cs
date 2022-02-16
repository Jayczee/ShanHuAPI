using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DCYEduWebAPI.Models;
using System.Data;
using DCYEduWebAPI.DAL;
using System.Xml;
using System.Net;

namespace DCYEduWebAPI.BLL
{
    public class MallBll
    {
        UserBll ubll = new();
        MallDal mdal = new();
        
        public List<Goods> GetGoodsInfo(string uid,string ip)
        {
            if (!ubll.CheckRequest(uid, ip))
                return null;
            DataTable dt = mdal.GetGoodsInfo();
            if (dt.Rows.Count <= 0)
                return null;
            List<Goods> list = new List<Goods>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                Goods goods = new();
                goods.Goodsid =Int32.Parse(dt.Rows[i]["GoodsID"].ToString());
                goods.Goodsname = dt.Rows[i]["GoodsName"].ToString();
                goods.Storage = Int32.Parse(dt.Rows[i]["Storage"].ToString());
                goods.Goodsdetails = dt.Rows[i]["GoodsDetails"].ToString();
                goods.Goodsurllocal = dt.Rows[i]["PictureURLLocal"].ToString();
                goods.Goodsurlcloud= dt.Rows[i]["PictureURLCloud"].ToString();
                goods.Goodsprice = Int32.Parse(dt.Rows[i]["Price"].ToString());
                list.Add(goods);
            }
            return list;
        }

        public bool AddGoodsInfo(Goods goods,string uid,string ip)
        {
            if (!ubll.CheckRequest(uid, ip))
                return false;
            int res = mdal.AddGoodsInfo(goods);
            if (res > 0)
                return true;
            return false;
        }

        public bool UpdateGoodsInfo(Goods goods, string uid, string ip)
        {
            if (!ubll.CheckRequest(uid, ip))
                return false;
            int res = mdal.UpdateGoodsInfo(goods);
            if (res > 0)
                return true;
            return false;
        }

        public bool DeleteGoodsInfoByID(string goodsID, string uid, string ip)
        {
            if (!ubll.CheckRequest(uid, ip))
                return false;
            int res = mdal.DeleteGoodsInfoByID(goodsID);
            if (res > 0)
                return true;
            return false;
        }

        public List<GoodsBoughtRecord> GetBoughtRecordByClass(string classname, string uid, string ip)
        {
            if (!ubll.CheckRequest(uid, ip))
                return null;
            DataTable dt = mdal.GetBoughtRecordByClass(classname);
            if (dt.Rows.Count <= 0)
                return null;
            List<GoodsBoughtRecord> list = new List<GoodsBoughtRecord>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                GoodsBoughtRecord gbr = new();
                gbr.Boughtid = Int32.Parse(dt.Rows[i]["BoughtID"].ToString());
                gbr.Boughtgoodsid = Int32.Parse(dt.Rows[i]["BoughtGoodsID"].ToString());
                gbr.Boughtgoodsname = dt.Rows[i]["BoughtGoodsName"].ToString();
                gbr.Boughttime = dt.Rows[i]["BoughtTime"].ToString();
                gbr.Cost = Int32.Parse(dt.Rows[i]["Cost"].ToString());
                gbr.Condition = dt.Rows[i]["Condition"].ToString();
                gbr.Handler = dt.Rows[i]["Handler"].ToString();
                gbr.Buyercardnum = dt.Rows[i]["BuyerCardNum"].ToString();
                gbr.Buyer = dt.Rows[i]["Buyer"].ToString();
                list.Add(gbr);
            }
            return list;
        }

        public bool UpdateBoughtRecord(int boughtid, string con, string uid, string ip)
        {
            if (!ubll.CheckRequest(uid, ip))
                return false;
            int res = mdal.UpdateBoughtRecord(boughtid, con,uid);
            if (res > 0)
                return true;
            return false;
        }

        public string GetLocalFileURL(string filename)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("ServerConfig.xml");
            XmlNode node = xmlDoc.SelectSingleNode("ServerInf");
            string server = node.Attributes["localserver"].Value;
            string port = node.Attributes["localport"].Value;
            string url = "Http://" + server + ":" + port + "/UploadFile/" + filename;
            return url;
        }
        public string GetCloudFileURL(string filename)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("ServerConfig.xml");
            XmlNode node = xmlDoc.SelectSingleNode("ServerInf");
            string server = node.Attributes["cloudserver"].Value;
            string port = node.Attributes["cloudport"].Value;
            string url = "Http://" + server + ":" + port + "/CloudFiles/" + filename;
            return url;
        }

        public int BuyGoods(int goodsID, string wxId)
        {
            DataTable dt = mdal.GetGoodsInfoByGoodsID(goodsID);
            if (dt.Rows.Count <= 0)
                return -1;
            Goods goods = new();
            goods.Goodsid = Int32.Parse(dt.Rows[0]["GoodsID"].ToString());
            goods.Goodsname = dt.Rows[0]["GoodsName"].ToString();
            goods.Storage = Int32.Parse(dt.Rows[0]["Storage"].ToString());
            goods.Goodsdetails = dt.Rows[0]["GoodsDetails"].ToString();
            goods.Goodsurllocal = dt.Rows[0]["PictureURLLocal"].ToString();
            goods.Goodsurlcloud = dt.Rows[0]["PictureURLCloud"].ToString();
            goods.Goodsprice = Int32.Parse(dt.Rows[0]["Price"].ToString());
            Student s = ubll.WXLogin(wxId);
            if (s.Spoints < goods.Goodsprice)
                return 0;
            mdal.BuyGoods(goods, s,wxId);
            return 1;
        }

        public string UploadFileToCloud(string files,FileStream fs, Dictionary<string, string> dic = null)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("ServerConfig.xml");
            XmlNode node = xmlDoc.SelectSingleNode("ServerInf");
            string server = node.Attributes["cloudserver"].Value;
            string port = node.Attributes["cloudport"].Value;
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(string.Format("http://"+server+":"+port+"/Mall/FileUploadCloud"));
            webReq.Method = "POST";
            webReq.KeepAlive = true;

            string boundary = "----" + DateTime.Now.Ticks.ToString("x");
            string formdataTemplate = "--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: application/octet-stream\r\n\r\n";
            string dataTemplate = "\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";

            webReq.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
            Stream requestStream = webReq.GetRequestStream();
            //尾
            var footer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            string filename = Path.GetFileName(files);
            var formdata = string.Format(formdataTemplate, "file", filename);
            //文件头
            var formdataByte = Encoding.ASCII.GetBytes(formdata);
            int b = (int)fs.Length;
            byte[] bt = new byte[b];
            fs.Read(bt, 0, b);
            fs.Flush();
            fs.Close();
            requestStream.Write(formdataByte, 0, formdataByte.Length);//写入 文件头
            requestStream.Write(bt, 0, bt.Length);//写入 文件
            if (dic != null && dic.Keys.Count > 0)
            {
                foreach (var kk in dic)
                {
                    string key = kk.Key;
                    string val = kk.Value;
                    var dataByte = Encoding.ASCII.GetBytes(string.Format(dataTemplate, key, val));
                    requestStream.Write(dataByte, 0, dataByte.Length);//写入 参数1
                }
            }
            requestStream.Write(footer, 0, footer.Length);//写入 尾

            requestStream.Close();


            HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string Info = sr.ReadToEnd();
            sr.Close();
            response.Close();
            try
            {
                /*以下代码保证通过模拟B端调用API上传文件到云服务器时 返回的数据经过二次API返回导致返回信息包含多余字符 处理掉这些字符使得这个模拟浏览器请求API的方法返回正常值*/
                int pos = Info.IndexOf("Http");//由于返回的响应info在特殊字符中加入了双引号，所以要手动定位删掉没用的信息
                /*未经处理的的响应信息差不多是这样的{"fileName":"ab3c435e-d7df-415f-814e-668ba542171f.txt","cloudpath":"Http://103.131.169.83:83/CloudFiles/ab3c435e-d7df-415f-814e-668ba542171f.txt"}*/
                Info = Info.Substring(pos);//从Http开始截取，把前面的全部裁掉
                int len = Info.Length;
                Info = Info.Substring(0, len - 2);//裁掉最后的"和}
            }
            catch (Exception e)
            {

            }
            return Info;
        }

    }
}
