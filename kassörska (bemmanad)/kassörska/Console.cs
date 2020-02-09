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
            // vad som ska hämtas från datorbasen
            string val = "SELECT * FROM dbo.Orders WHERE Order_status = 1";
            int number = 0;
            
            int poss = 1;
            Databas a = new Databas();


            // för att loopen alltid ska var igång
            bool alltid = true;
            

            // loop så att consolen ska kunna uppdateras
            while (alltid)
            {


                a.OpenConection();
                SqlDataReader dr = a.DataReader(val);
                int test = a.Tester();
                Console.WriteLine("Ordar som ska hämtas: \n");
                dr.Read();
                while (dr.Read())
                {
                    
                    

                    Console.WriteLine(dr["ID"].ToString());



                
                     //set test as the last posible number
                    test = number;
                // go oute of loop
                   dr.Close();
                //if last vlue is it change all exlse to normal
                Console.BackgroundColor = ConsoleColor.Black;
                }
                // if you press down or s
                Console.ForegroundColor = ConsoleColor.Black;
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.DownArrow || key.KeyChar == 's')
                {
                    // poss gouse down one position in the text
                    poss = poss + 1;
                // and start going thru the oredrs
                    dr.Read();
                    //clear the window
                    Console.Clear();
                    //reset the number on orders
                    number = 0;
                }
                // same as down but oppisit way
                if (key.Key == ConsoleKey.UpArrow || key.KeyChar == 'w')
                {
                    poss = poss - 1;
                    dr.Read();
                    Console.Clear();
                    number = 0;
                }
                    // if u press enter
                    if (key.Key == ConsoleKey.Enter)
                    {
                    Console.ForegroundColor = ConsoleColor.White;
                    // clear window
                    Console.Clear();



                    //set number to 0
                    number = 0;
                    // write oute the rite order



                       foreach (var item in dr)
                       {
                        number++;
                        if (key.Key == ConsoleKey.Enter &&  number == poss)
                        {
                            a.ExecuteQueries("DELETE FROM dbo.Orders WHERE COUNT()");
                        }
                        //when poss is number the write the item
                        if (poss == number)
                        {
                            

                            Console.WriteLine($"{item}");



                        }
                       }
                    }
                    else { }

                //look if u go over or under the posible value go to lowest numberor highest
                if (poss > test)
                {
                    poss = 1;
                }
                if (poss == 0)
                {
                    poss = test;
                }
                
            }
        }
    }
}















    





        
    
                    
                    
                  

                   
                  
                   
                   
                  
                       
                    
                       
                       
                 

                  
                
                
                

    

