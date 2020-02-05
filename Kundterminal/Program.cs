using System;

namespace PizzaPalatzet_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Choise = { "Pizzas", "Sallads", "Pastas", "Bevrages" };
            int poss = 0;
            Console.CursorVisible = false;

                Console.WriteLine("Wellcome to PizzaPalatset Press enter to continue");
                Console.ReadKey();
                Console.Clear();
            while (true){
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("What do you like to order?");
                for (int i = 0; i < Choise.Length; i++)
                {
                   
                    if (poss == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(Choise[i]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(Choise[i]);
                    }
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Black;

                }
                    ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.DownArrow || key.KeyChar == 's')
                {
                        poss = poss + 1;
                        Console.Clear();
                    if (poss == Choise.Length)
                    {
                        poss = 0;
                    }
                    }
                    if (key.Key == ConsoleKey.UpArrow || key.KeyChar == 'w')
                    {
                        poss = poss - 1;
                        Console.Clear();
                        if (poss < 0)
                        {
                        poss = Choise.Length - 1;
                        }
                    }
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                        window2.item(Choise[poss]);
                    }
                   


            }
        }
    }
}
