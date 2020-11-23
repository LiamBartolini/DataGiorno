using System;
using Bartolini.Liam._4H.DataGiorno.Models;

namespace Bartolini.Liam._4H.DataGiorno
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Data data = new Data("/, 01, 2003");
                Console.WriteLine("Data originale: ");
                Console.WriteLine(data.Out());

                data.Mod(31, 11, 2020);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nData Modificata");
                Console.WriteLine(data.Out());
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }
    }
}