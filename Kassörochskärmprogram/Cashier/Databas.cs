using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;





//namespace Cashier
//{
//    public class Databas
//    {
//        //connection string
//        private string ConnectionString = "Data Source=sql6009.site4now.net;Initial Catalog=DB_A53DDD_topdog;Persist Security Info=True;User ID=DB_A53DDD_topdog_admin;Password=falling-2apple";

//        SqlConnection con;

//        //open connection
//        public void OpenConection()
//        {
//            con = new SqlConnection(ConnectionString);
//            con.Open();
//        }

//        public void CloseConnection()
//        {
//            con.Close();
//        }
//        //method to use querys
//        public void ExecuteQueries(string Query_)
//        {
//            SqlCommand cmd = new SqlCommand(Query_, con);
//            cmd.ExecuteNonQuery();
//        }

//        //datareader method
//        public SqlDataReader DataReader(string Query_)
//        {
//            SqlCommand cmd = new SqlCommand(Query_, con);
//            SqlDataReader dr = cmd.ExecuteReader();
//            return dr;
//        }
//        //method to get the numbers of orders
//        public int Tester()
//        {
//            string stmt = "SELECT COUNT(*) FROM dbo.Orders WHERE Order_status=1";
//            int count = 0;

//            using (SqlConnection con = new SqlConnection(ConnectionString))
//            {
//                using (SqlCommand cmdCount = new SqlCommand(stmt, con))
//                {
//                    con.Open();
//                    count = (int)cmdCount.ExecuteScalar();
//                }
//            }
//            return count;
//        }

      

//    }
//}
