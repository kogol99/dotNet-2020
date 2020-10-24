using System;
using System.Linq;

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


    class Program
    {
        static void Main(string[] args)
        {
            Zad1 zadanie = new Zad1();
            zadanie.stworz();

        }
    }
}
