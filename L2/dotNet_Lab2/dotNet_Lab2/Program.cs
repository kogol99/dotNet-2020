using System;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;

namespace dotNet_Lab2
{
    class Zad1
    {
        public void FunkcjaKwadatrowa()
        {
            Console.WriteLine("Podaj wartosc a (ax^2+bx+c=0)");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj wartosc b (ax^2+bx+c=0)");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj wartosc c (ax^2+bx+c=0)");
            int c = int.Parse(Console.ReadLine());
            if (a == 0 & b == 0 & c == 0)
            {
                Console.WriteLine("Rownanie tozsamosciowe");
            }
            else if (a == 0)
            {
                Console.WriteLine("Nie jest to funkcja kwadratowa");
            }
            else
            {
                double delta = b * b - 4 * a * c;
                if (delta == 0)
                {
                    Console.WriteLine($"Wartość x wynosi: {((-b) / (2 * a)):N5}");
                }
                else if (delta > 0)
                {
                    Console.WriteLine($"Wartości x wynoszą: {(-b - Math.Sqrt(delta)) / (2 * a):N5}, {(-b + Math.Sqrt(delta)) / (2 * a):N5}");
                }
                else
                {
                    Console.WriteLine("Brak miejsc zerowych dla podanej funkcji");
                }
            }

        }
    }

    class Zad2
    {
        public void Reprezentacje()
        {
            Console.WriteLine("Podaj wartosc a");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj wartosc b");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"Zmienne: a: {a} (binarnie: {Convert.ToString(a,2)}) negacja: {Convert.ToInt32((~a).ToString()):X}(hex), " +
                $"b: {b} (binarnie {Convert.ToString(b, 2)}) negacja: {Convert.ToInt32((~b).ToString()):X}(hex). " +
                $"koniunkcja a i b = {Convert.ToInt32((a&b).ToString()):X}(hex), " +
                $"alternatywa a i b = {Convert.ToInt32((a|b).ToString()):X}(hex)"); 
        }
    }

    class Zad3
    {
        public void SprawdzanieWartosci()
        {
            int repeat = int.Parse(Console.ReadLine());
            int x1 = int.MinValue;
            int x2 = int.MinValue;
            for (int i=0; i<repeat; i++)
            {
                char read;
                string readNumber = "";
                do
                {
                    read = Convert.ToChar(Console.Read());
                    if (!Char.IsWhiteSpace(read))
                    {
                        readNumber += read;
                    }
                }
                while
                (!Char.IsWhiteSpace(read));
                int number = int.Parse(readNumber);
                if(number > x1)
                {
                    x2 = x1;
                    x1 = number;
                }
                else if (number < x1 & number > x2)
                {
                    x2 = number;
                }
            }
            if ( x2 == int.MinValue)
            {
                Console.WriteLine("Brak rozwiazania");
            }
            else
            {
                Console.WriteLine($"odpowiedź jest {x2}");
            }
            
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Zad1 zadanie = new Zad1();
            //zadanie.FunkcjaKwadatrowa();

            //Zad2 zad2 = new Zad2();
            //zad2.Reprezentacje();

            Zad3 zad3 = new Zad3();
            zad3.SprawdzanieWartosci();
        }
    }
}
