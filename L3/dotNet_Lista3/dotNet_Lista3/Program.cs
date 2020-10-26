using System;
using System.Linq;

using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Collections;
using static System.Array;


namespace dotNet_Lista3
{
    class Zad1 { 
        public void Stworz()
        {
            int n, m;
            String read_str;
            do
            {
                Console.Write("\nPodaj wymiar n: ");
                read_str = Console.ReadLine();
            } while (!int.TryParse(read_str, out n));

            do
            {
                Console.Write("\nPodaj wymiar m: ");
                read_str = Console.ReadLine();
            } while (!int.TryParse(read_str, out m));

            int[,] array2D = new int[n, m];
            WyplenijTablice2D(n, m, array2D);
            Console.WriteLine("Pierwotna tablica dwuwymiarowa");
            WypiszTablice2D(n, m, array2D);
            OdwrocTablice2D(n, m, array2D);
            Console.WriteLine("Odwrócona tablica dwuwymiarowa");
            WypiszTablice2D(n, m, array2D);
            
            int[][] arrayArrays = new int[n][];
            for (int i = 0; i < m; i++)
            {
                arrayArrays[i] = new int[m];
            }
            WyplenijTabliceTablic(n, m, arrayArrays);
            Console.WriteLine("\nPierwotna tablica tablic");
            WypiszTabliceTablic(n, m, arrayArrays);
            OdwrocTabliceTablic(n, m, arrayArrays);
            Console.WriteLine("Odwrócona tablica tablic");
            WypiszTabliceTablic(n, m, arrayArrays);

        }

        void WyplenijTablice2D(int n, int m, int[,] array)
        {
            Random rnd = new Random();
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    array[i,j] = rnd.Next(100);
                }
            }
        }

        void WypiszTablice2D(int n, int m, int[,] array)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.Write("\n");
            }
        }

        void OdwrocTablice2D(int n, int m, int[,] array)
        {
            for(int i = 0; i < n/2; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int v = array[i, j];
                    array[i, j] = array[n - 1 - i, j];
                    array[n - 1 - i, j] = v;
                }
            }
        }

        void WyplenijTabliceTablic(int n, int m, int[][] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i][j] = rnd.Next(100);
                }
            }
        }

        void WypiszTabliceTablic(int n, int m, int[][] array)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.Write("\n");
            }
        }

        void OdwrocTabliceTablic(int n, int m, int[][] array)
        {
            for (int i = 0; i < n / 2; i++)
            {
                int[] v = array[i];
                array[i] = array[n - 1 - i];
                array[n - 1 - i] = v;
            }
        }
    }

    class Zad2
    {
        public void Stworz()
        {
            Console.WriteLine("Podaj imię");
            string imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko");
            string nazwisko = Console.ReadLine();
            string read_str;
            int wiek;
            do
            {
                Console.WriteLine("Podaj wiek");
                read_str = Console.ReadLine();
            } while (!int.TryParse(read_str, out wiek));

            int placa;
            do
            {
                Console.WriteLine("Podaj płacę");
                read_str = Console.ReadLine();
            } while (!int.TryParse(read_str, out placa));

            var krotka = (imie, nazwisko, wiek, placa);

            WypiszZKrokitSposob1(krotka);
            WypiszZKrokitSposob2(krotka);
            WypiszZKrokitSposob3(krotka);

            var krotkaAnonimowa = new { nameA = imie, surnameA = nazwisko, ageA = wiek, salaryA = placa };

            WypiszZKrotkiAnonimowej(krotkaAnonimowa);

        }

        void WypiszZKrokitSposob1((string, string, int, int) krotka)
        {
            Console.WriteLine($"Pan/Pani {krotka.Item1} {krotka.Item2} mając {krotka.Item3} lat zarabia {krotka.Item4} zł miesięcznie.");
        }

        void WypiszZKrokitSposob2((string name, string surname, int age, int money) krotka)
        {
            Console.WriteLine($"Pan/Pani {krotka.name} {krotka.surname} mając {krotka.age} lat zarabia {krotka.money} zł miesięcznie.");
        }

        void WypiszZKrokitSposob3((string name, string surname, int age, int money) krotka)
        {
            (string name, string surname, int age, int money) = krotka;
            Console.WriteLine($"Pan/Pani {name} {surname} mając {age} lat zarabia {money} zł miesięcznie.");
        }

        void WypiszZKrotkiAnonimowej(dynamic anonim)
        {
            Console.WriteLine($"Pan/Pani {anonim.nameA} {anonim.surnameA} mając {anonim.ageA} lat zarabia {anonim.salaryA} zł miesięcznie.");
        }
    }

    class Zad3
    {
        public void Stworz()
        {
            int @class = 16;
            Console.WriteLine($"Urodziłem się {@class}. dnia miesiąca.");
        }
    }

    class Zad4
    {
        public void Stworz()
        {
            int[] array = { 4, 5, 7, 2, 5, 8, 0, 1, 4, 8, 20, 35, 735, 446, 3 };
            Wydrukuj(array);

            Console.WriteLine("\nKopiowanie tablicy: ");
            int[] copyArray = new int[array.Length];
            Copy(array, copyArray, array.Length);
            Wydrukuj(copyArray);

            Console.WriteLine("\nWyszukiwanie indexu elementu wiekszego od 6: ");
            Console.WriteLine(FindIndex(array, elem => elem > 6));

            Console.WriteLine("\nOdwrocenie tablicy: ");
            Reverse(array);
            Wydrukuj(array);

            Console.WriteLine("\nPosortowanie tablicy: ");
            Sort(array);
            Wydrukuj(array);

            Console.WriteLine("\nUstawienie wartości 999 na indexie 4 : ");
            array.SetValue(999, 4);
            Wydrukuj(array);
        }

        void Wydrukuj(int[] array)
        {
            Console.WriteLine("Zawartość tablicy: ");
            for(int i=0; i<array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Zad1 zadanie = new Zad1();
            //zadanie.Stworz();

            //Zad2 zadanie2 = new Zad2();
            //zadanie2.Stworz();

            //Zad3 zadanie3 = new Zad3();
            //zadanie3.Stworz();

            //Zad4 zadanie4 = new Zad4();
            //zadanie4.Stworz();

            //Zadanie 5 zostało umieszczone w zadaniu 2.
        }
    }
}
