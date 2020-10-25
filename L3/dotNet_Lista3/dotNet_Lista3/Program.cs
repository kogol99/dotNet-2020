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
        public void stworz()
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
            wyplenijTablice2D(n, m, array2D);
            wypiszTablice2D(n, m, array2D);
            odwrocTablice2D(n, m, array2D);
            Console.Write("\n");
            wypiszTablice2D(n, m, array2D);

            int[][] arrayArrays = new int[n][];
            for (int i = 0; i < m; i++)
            {
                arrayArrays[i] = new int[m];
            }
            wyplenijTabliceTablic(n, m, arrayArrays);
            wypiszTabliceTablic(n, m, arrayArrays);
            odwrocTabliceTablic(n, m, arrayArrays);
            Console.Write("\n");
            wypiszTabliceTablic(n, m, arrayArrays);

        }

        void wyplenijTablice2D(int n, int m, int[,] array)
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

        void wypiszTablice2D(int n, int m, int[,] array)
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

        void odwrocTablice2D(int n, int m, int[,] array)
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

        void wyplenijTabliceTablic(int n, int m, int[][] array)
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

        void wypiszTabliceTablic(int n, int m, int[][] array)
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

        void odwrocTabliceTablic(int n, int m, int[][] array)
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
        public void stworz()
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


            (string, string, int, int) krotka= (imie, nazwisko, wiek, placa);
            var krotkaAnonimowa = (imie, nazwisko, wiek, placa);

            wypiszZKrokitSposob1(krotka);
            wypiszZKrokitSposob2(krotka);
            wypiszZKrokitSposob3(krotka);
            wypiszZKrokitSposob1(krotkaAnonimowa);
            wypiszZKrokitSposob2(krotkaAnonimowa);
            wypiszZKrokitSposob3(krotkaAnonimowa);

        }

        void wypiszZKrokitSposob1((string, string, int, int) krotka)
        {
            Console.WriteLine($"Pan/Pani {krotka.Item1} {krotka.Item2} mając {krotka.Item3} lat zarabia {krotka.Item4} zł miesięcznie.");
        }

        void wypiszZKrokitSposob2((string name, string surname, int age, int money) krotka)
        {
            Console.WriteLine($"Pan/Pani {krotka.name} {krotka.surname} mając {krotka.age} lat zarabia {krotka.money} zł miesięcznie.");
        }

        void wypiszZKrokitSposob3((string name, string surname, int age, int money) krotka)
        {
            (string name, string surname, int age, int money) = krotka;
            Console.WriteLine($"Pan/Pani {name} {surname} mając {age} lat zarabia {money} zł miesięcznie.");
        }
    }

    class Zad3
    {
        public void stworz()
        {
            int @class = 16;
            Console.WriteLine($"Urodziłem się {@class}. dnia miesiąca.");
        }
    }

    class Zad4
    {
        public void stworz()
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
            //zadanie.stworz();

            //Zad2 zadanie2 = new Zad2();
            //zadanie2.stworz();

            //Zad3 zadanie3 = new Zad3();
            //zadanie3.stworz();

            //Zad4 zadanie4 = new Zad4();
            //zadanie4.stworz();

            //Zadanie 5 zostało umieszczone w zadaniu 2.
        }
    }
}
