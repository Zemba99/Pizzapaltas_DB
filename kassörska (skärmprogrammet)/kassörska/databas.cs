using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace kassörska
{
    public class Databas
    {

        string ConnectionString = "Data Source=sql6009.site4now.net;Initial Catalog=DB_A53DDD_topdog;Persist Security Info=True;User ID=DB_A53DDD_topdog_admin;Password=falling-2apple";
        SqlConnection con;


        public void OpenConection()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }

        public void CloseConnection()
        {
            con.Close();
        }

        public void ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.ExecuteNonQuery();
        }


        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

       

    }
}
