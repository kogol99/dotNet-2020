using Microsoft.VisualBasic;
using System;
using System.Globalization;

namespace doNet_lab2_
{
    class Program
    {
        static void Main(string[] args)
        {
            String read_str;
            int arg1;
            double arg2;
            bool arg3;
            DateTime arg4;
            DateTime arg5;

            Console.WriteLine("Kamil Graczyk, 246994");

            do
            {
                Console.Write("\nPodaj inta: ");
                read_str = Console.ReadLine();
            } while (!int.TryParse(read_str, out arg1));
            Console.WriteLine($"Otrzymane dane: {arg1}");

            do
            {
                Console.Write("\nPodaj double: ");
                read_str = Console.ReadLine();
            }
            while (!double.TryParse(read_str, out arg2));
            Console.WriteLine($"Otrzymane dane: {arg2}");

            do
            {
                Console.Write("\nPodaj boola: ");
                read_str = Console.ReadLine();
            } while (!bool.TryParse(read_str, out arg3));
            Console.WriteLine($"Otrzymane dane: {arg3}");

            do
            {
                Console.Write("\nPodaj DataTime [dd.mm.rrrr]: ");
                read_str = Console.ReadLine();
            } while (!DateTime.TryParse(read_str, out arg4));
            Console.WriteLine($"Otrzymane dane: {arg4}");

            CultureInfo enUS = new CultureInfo("en-US");
            do
            {
                Console.Write("\nPodaj DataTimeExact [dd-mm-rrrr]: ");
                read_str = Console.ReadLine();
            } while (!DateTime.TryParseExact(read_str, "dd-M-yyyy", enUS, DateTimeStyles.None, out arg5));
            Console.WriteLine($"Otrzymane dane: {arg5}");
        }
    }
}
