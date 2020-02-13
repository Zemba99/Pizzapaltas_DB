using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MsRepository;
using TypeLib;
using Dapper;
using System.Data.SqlClient;



namespace Pizza_palatset_db
{
    enum menues
    {
        Main, Pizza, Sallad, Pasta, Bevrage, current_order, Order, editpizza

    }

    class Mainwindow
    {
        private static IRepository _repo;
        private static menues currentmenue;
        public static void menue_choise()
        {
            int mycurrent_id = 0;
            List<Int32> items = new List<int>();
            _repo = new Repository();
            currentmenue = menues.Main;
            Console.WriteLine("Wellcome to pizzaplats press any key to continue");
            Console.ReadKey();
            //Add Neworder 

            while (true)
            {
                //var orders = _repo.GetOrders().Result.AsList();
                //foreach (var item in orders) ;
                //{
                //    mycurrent_id = item.ID;
                //}

                switch (currentmenue)
                {
                    case menues.Main:

                        Console.WriteLine("1: Pizza");
                        Console.WriteLine("2: Sallad");
                        Console.WriteLine("3: Pasta");
                        Console.WriteLine("4: Bevrage");
                        Console.WriteLine("5: your order");
                        Console.WriteLine("6: Order");
                        String choise = Console.ReadLine();
                        if (int.TryParse(choise, out int result))
                        {
                            if (result == 1) { currentmenue = menues.Pizza; }
                            if (result == 2) { currentmenue = menues.Sallad; }
                            if (result == 3) { currentmenue = menues.Pasta; }
                            if (result == 4) { currentmenue = menues.Bevrage; }
                            if (result == 5) { currentmenue = menues.current_order; }
                            if (result == 6) { currentmenue = menues.Order; }
                        }


                        break;
                    case menues.Pizza:

                        items.Clear();
                        var pizzas = _repo.GetPizzas().Result.AsList();

                        Console.Clear();
                        foreach (var item in pizzas)
                        {

                            Console.WriteLine(item.ID + ": " + item.Name + " " + item.Price + ":-");


                        }
                        String PizzaType = Console.ReadLine();

                        Console.Clear();
                        if (int.TryParse(PizzaType, out int type))
                        {
                            foreach (var item in pizzas)
                            {

                                var currentpizzacreate = _repo.GetCurrentpizza().Result.AsList();
                                if (item.ID == type)
                                {
                                    Console.WriteLine(item.Name + "\n");
                                    foreach (var item2 in currentpizzacreate)
                                    {


                                        if (item2.ID == type)
                                        {


                                            items.Add(item2.ingredient_id);
                                        }

                                    }


                                }



                            }
                        }



                        int i = 0;
                        int y = 0;
                        var ingredient = _repo.GetIngredients().Result.AsList();
                        items.Sort();

                        foreach (var Ingred in ingredient)
                        {

                            bool onpizza = false;
                            if (items.Count > 0 && items.Count != y)
                            {
                                items.Add(0);
                            }
                            if (items.Count > 0 && items[i] == Ingred.ID)
                            {
                                onpizza = true;

                            }
                            else
                            {
                                items.Add(0);
                                ;
                            }
                            y++;
                            if (onpizza)
                            {
                                Console.WriteLine(Ingred.Name + " [x]");
                                i++;

                            }
                            else
                            {
                                Console.WriteLine(Ingred.Name + " [ ]");
                            }
                        }
                            ;
                        Console.WriteLine("1 :Add to order");

                        Console.WriteLine("2 :Back to main meny");
                        String Done = Console.ReadLine();
                        Console.Clear();
                        if (int.TryParse(Done, out int GO))
                        {

                        }



                        currentmenue = menues.Main;
                        Console.ReadKey();
                        
                        break;
                    case menues.Bevrage:
                        var Beverages = _repo.GetBeverages().Result.AsList();
                        foreach (var item in Beverages)
                        {
                            Console.WriteLine(item.ID + ": " + item.Name + " " + item.Price + ":-");
                            //AddToPizzaOrder(mycurrent_id, item.ID);
                            //var Pasta_order = _repo.order_Beverages().Result.AsList();
                            //foreach (var item in Pastas_order)
                            //{
                            //    if(item.orderid == mycurrent_id)
                            //    {

                            //    }
                            //}    
                        }
                        Console.ReadKey();

                        currentmenue = menues.Main;
                        break;
                    case menues.current_order:
                        //loop all where in order = mycurrent_id
                        //sum of mycurrentod price
                        Console.ReadKey();
                        break;
                    case menues.Order:
                        //exit and set order to status to 1
                        currentmenue = menues.Main;
                        Console.ReadKey();
                        break;



                }




            }
        }

    }
}
