using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace DCYEduWebAPI.DAL
{
    public class SqlHelper
    {
        public static string ConnectionStringLocal { get; set; } = "server=124.222.114.100;database=ShanHu;uid=sa;pwd=jhkd5960795.";

        public static string GetServerType()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("ServerConfig.xml");
            XmlNode node = xmlDoc.SelectSingleNode("ServerInf");
            return node.Attributes["servertype"].Value;
        }
        public static void SetConnStringLocal()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("ServerConfig.xml");
            XmlNode node = xmlDoc.SelectSingleNode("ServerInf");
            string server = node.Attributes["localserver"].Value;
            string initialcatalog = node.Attributes["localinitialcatalog"].Value;
            string uid = node.Attributes["localuid"].Value;
            string pwd = node.Attributes["localpwd"].Value;
            string con = string.Format("server={0};initial catalog={1};uid={2};pwd={3};", server, initialcatalog, uid, pwd);
            ConnectionStringLocal = con;
        }

        public static void SetConnStringCloud()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("ServerConfig.xml");
            XmlNode node = xmlDoc.SelectSingleNode("ServerInf");
            string server = node.Attributes["cloudserver"].Value;
            string initialcatalog = node.Attributes["cloudinitialcatalog"].Value;
            string uid = node.Attributes["clouduid"].Value;
            string pwd = node.Attributes["cloudpwd"].Value;
            string con = string.Format("server={0};initial catalog={1};uid={2};pwd={3};", server, initialcatalog, uid, pwd);
            ConnectionStringLocal = con;
        }

        public static DataTable ExecuteTable(string cmdText, params SqlParameter[] sqlParameters)
        {
            if (GetServerType() == "local")
                SetConnStringLocal();
            else
                SetConnStringCloud();
            using SqlConnection conn = new SqlConnection(ConnectionStringLocal);
            conn.Open();
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddRange(sqlParameters);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }

        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] sqlParameters)
        {
            if (GetServerType() == "local")
                SetConnStringLocal();
            else
                SetConnStringCloud();
            using SqlConnection conn = new SqlConnection(ConnectionStringLocal);
            conn.Open();
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddRange(sqlParameters);
            return cmd.ExecuteNonQuery();
        }

        

        public static object ExecuteScalar(string sql, params SqlParameter[] sqlParameters)
        {
            if (GetServerType() == "local")
                SetConnStringLocal();
            else
                SetConnStringCloud();
            using SqlConnection conn = new SqlConnection(ConnectionStringLocal);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(sqlParameters);
            return cmd.ExecuteScalar();
        }
    }
}
