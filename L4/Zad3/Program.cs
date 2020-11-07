using System;
using System.ComponentModel;

namespace Zad3
{
    class Program
    {
        static void Main(string[] args)
        {
            (int licznikParzysteCalkowite, int licznikRzeczywisteDodatnie, int licznikNapisyCoNajmniej5Znakow, int licznikPozostaleTypy) = CountMyTypes(2, 4.0, "Graczyk", "Kamil", 246994);
            Console.WriteLine("Było:\nParzystych calkowitych: " + Convert.ToString(licznikParzysteCalkowite) + "\nRzeczywistych dodatnich: " + Convert.ToString(licznikRzeczywisteDodatnie) + "\nNapisow z co najmniej 5 znakami: " + Convert.ToString(licznikNapisyCoNajmniej5Znakow) + "\nPozostalych typow: " + Convert.ToString(licznikPozostaleTypy));
        }

        static (int, int, int, int) CountMyTypes(params dynamic[] tab)
        {
            int licznikParzysteCalkowite = 0;
            int licznikRzeczywisteDodatnie = 0;
            int licznikNapisyCoNajmniej5Znakow = 0;
            int licznikPozostaleTypy = 0;
            foreach (dynamic obj in tab)
            {
                switch (obj)
                {
                    case int liczba when liczba % 2 == 0:
#if (DEBUG)
                        Console.WriteLine(Convert.ToString(obj) + " - Parametr zakwalifikowany jako liczba calkowita parzysta.");
#endif
                        licznikParzysteCalkowite++;
                        break;
                    case double liczba when liczba > 0:
#if (DEBUG)
                        Console.WriteLine(Convert.ToString(obj) + " - Parametr zakwalifikowany jako liczba rzeczywista dodatnia.");
#endif
                        licznikRzeczywisteDodatnie++;
                        break;
                    case string ciagZnakow when ciagZnakow.Length >= 5:
#if (DEBUG)
                        Console.WriteLine(Convert.ToString(obj) + " - Parametr zakwalifikowany jako ciag znakow dlugoscia wynoszacy co najmniej 5 znakow.");
#endif
                        licznikNapisyCoNajmniej5Znakow++;
                        break;
                    default:
#if (DEBUG)
                        Console.WriteLine(Convert.ToString(obj) + " - Parametr zakwalifikowany jako pozostaly typ.");
#endif
                        licznikPozostaleTypy++;
                        break;
                }
            }
            return (licznikParzysteCalkowite, licznikParzysteCalkowite, licznikNapisyCoNajmniej5Znakow, licznikPozostaleTypy);
        }
    }
}
