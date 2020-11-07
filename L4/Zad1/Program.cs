using System;
using System.Xml.Linq;

namespace Zad1
{
    class Program
    {
        static void Main(string[] args)
        {
            GetFromConsoleXY("Wpisz a: ", "Wpisz b: ");
            int int1, int2;
            GetFromConsoleXY2("Wpisz a: ", "Wpisz b: ", out int1, out int2);
        }

        static (int, int) GetFromConsoleXY(string linia1, string linia2)
        {
#if (DEBUG)
            Console.WriteLine("Przypisywanie do zwrotnej krotki");
#endif
            int int1, int2;
            String read_str;
            do
            {
                Console.Write(linia1);
                read_str = Console.ReadLine();
            } while (!int.TryParse(read_str, out int1));
            do
            {
                Console.Write(linia2);
                read_str = Console.ReadLine();
            } while (!int.TryParse(read_str, out int2));
            return (int1, int2);
        }

        static void GetFromConsoleXY2(string linia1, string linia2, out int int1, out int int2)
        {
#if (DEBUG)
            Console.WriteLine("Przypisywanie do parametru metody void");
#endif
            String read_str;
            do
            {
                Console.Write(linia1);
                read_str = Console.ReadLine();
            } while (!int.TryParse(read_str, out int1));
            do
            {
                Console.Write(linia2);
                read_str = Console.ReadLine();
            } while (!int.TryParse(read_str, out int2));
        }
    }
}
