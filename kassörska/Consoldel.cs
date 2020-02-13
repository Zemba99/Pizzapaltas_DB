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
            
            // Läs in alla aktuella ordrar


            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                
                //lista på alla ordrar som är lagda och som tillagas
                var Orders = _repo.GetOrdersMaking().Result.AsList();
                //lista på alla ordar som är redo att hämtas
                var Orders2 = _repo.GetOrdersMakingtwo().Result.AsList();
                // Skriv ut alla ordrar
                ///</summary>
                Console.WriteLine("\tOrdrar som tillagas\n");
                for (int i = 0; i < Orders2.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\tOrder ID: " + Orders2[i].ID);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\tFärdiga ordrar\n");
                for (int i = 0; i < Orders.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\tOrder ID: " + Orders[i].ID);
                }
                //updatera varje 5 sec för att hämta ny info från datorbasen
                Thread.Sleep(5000);

            }
        }
    }
}
















