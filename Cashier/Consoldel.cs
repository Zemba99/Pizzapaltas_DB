using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Data;
using MsRepository;
using TypeLib;
using Dapper;

namespace Cashier
{
    class Consoldel
    {
        /// <summary>
        /// Skapa en privat fält
        /// </summary>
        private static IRepository _repo;

        public static void ShowWindow()
        {
            // Skapa en instans av Reposittory,
            // använd denna för att komma åt databasem
            _repo = new Repository();
            int CurrentPos = 0;
            // Läs in alla aktuella ordrar

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\tOrdrar som ska hämtas\n");
                               
                var Orders = _repo.GetOrdersMaking().Result.AsList();
                 
                ///<summary>
                // Skriv ut alla ordrar
                ///</summary>
                for (int i = 0; i < Orders.Count; i++)
                {
                    if (CurrentPos == i) Console.ForegroundColor = ConsoleColor.Green;
                    else Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\tOrder ID: " + Orders[i].ID);
                }
                var Key = Console.ReadKey().Key;
                switch (Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                             CurrentPos--;                            
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        {
                            CurrentPos++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        {
                            if (Orders.Count > 0)
                            {
                                _repo.DeleteOrders(Orders[CurrentPos]);
                                Orders.RemoveAt(CurrentPos);                               
                            }                                                        
                        }
                        break;
                    default: break;
                }
                if (CurrentPos > Orders.Count-1)
                {
                    CurrentPos = 0;
                }
                if (CurrentPos < 0)
                {
                    CurrentPos = Orders.Count-1;
                }
            }           
        }
    }
}

















