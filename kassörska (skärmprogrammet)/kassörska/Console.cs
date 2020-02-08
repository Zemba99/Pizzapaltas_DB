using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;


namespace kassörska
{
    class Consolen
    {


        public static void ShowWindow()
        {
            string val = "SELECT * FROM dbo.Orders WHERE Order_status = 1";
            string val2 = "SELECT * FROM dbo.Orders WHERE Order_status = 2";
            Databas a = new Databas();



            bool alltid = true;



            while (alltid)
            {

                a.OpenConection();
                SqlDataReader dr = a.DataReader(val);

                Console.WriteLine("Ordar väntar: \n");

                while (dr.Read())
                {



                    Console.WriteLine(dr["ID"].ToString());


                }
                Console.WriteLine();

                dr.Close();

                dr = a.DataReader(val2);
                Console.WriteLine("Ordar redo att hämtas: \n");
                while (dr.Read())
                {



                    Console.WriteLine(dr["ID"].ToString());


                }

                System.Threading.Thread.Sleep(5000);
                    Console.Clear();
                   dr.Close();
                   a.CloseConnection();
                 

            }
        





       
    }
    }
}
        
    

    

