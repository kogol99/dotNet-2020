using System;

namespace Zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawCard("Graczyk", "Kamil", "X", 3, 5);
        }

        static void wypiszLinieObramowania(int dlugoscWizytowki, int szerokoscObramowania, string znakObramowania)
        {
            for (int j = 0; j < szerokoscObramowania; j++)
            {
                for (int i = 0; i < dlugoscWizytowki; i++)
                {
                    Console.Write(znakObramowania);
                }
                Console.WriteLine();
            }
        }

        static (int, int) wyliczPrzerwy(int dlugoscWizytowki, int szerokoscObramowania, string linia)
        {
            int pozostalaIloscZnakow = dlugoscWizytowki - linia.Length - (szerokoscObramowania * 2);
            int pozostalaIloscZnakowLewa, pozostalaIloscZnakowPrawa;
            if (pozostalaIloscZnakow % 2 == 0)
            {
                pozostalaIloscZnakowLewa = pozostalaIloscZnakow / 2;
                pozostalaIloscZnakowPrawa = pozostalaIloscZnakow / 2;
            }
            else
            {
                pozostalaIloscZnakowLewa = pozostalaIloscZnakow / 2;
                pozostalaIloscZnakowPrawa = pozostalaIloscZnakow / 2 + 1;
            }
            return (pozostalaIloscZnakowLewa, pozostalaIloscZnakowPrawa);
        }

        static void wypiszLinijkeWizytowki(string linia2, int dlugoscLinii, int dlugoscWizytowki, int pozostalaIloscZnakowLewa, int pozostalaIloscZnakowPrawa, int szerokoscObramowania, string znakObramowania)
        {
            for (int i = 0; i < dlugoscWizytowki; i++)
            {
                if (i < szerokoscObramowania)
                {
                    Console.Write(znakObramowania);
                }
                else if (i < szerokoscObramowania + pozostalaIloscZnakowLewa)
                {
                    Console.Write(" ");
                }
                else if (i < szerokoscObramowania + pozostalaIloscZnakowLewa + dlugoscLinii)
                {
                    Console.Write(linia2);
                    i += dlugoscLinii - 1;
                }
                else if (i < szerokoscObramowania + pozostalaIloscZnakowLewa + dlugoscLinii + pozostalaIloscZnakowPrawa)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(znakObramowania);
                }
            }
            Console.WriteLine();
        }

        static void DrawCard(string linia1, string linia2, string znakObramowania, int szerokoscObramowania, int minimalnaDlugosc)
        {
            int dlugoscWizytowki = minimalnaDlugosc;
            if(linia1.Length > linia2.Length)
            {
                if(linia1.Length + szerokoscObramowania * 2 > minimalnaDlugosc)
                {
                    dlugoscWizytowki = linia1.Length + szerokoscObramowania * 2;
                }
            }
            else
            {
                if (linia2.Length + szerokoscObramowania * 2 > minimalnaDlugosc)
                {
                    dlugoscWizytowki = linia2.Length + szerokoscObramowania * 2;
                }
            }

            // linia 1++
            wypiszLinieObramowania(dlugoscWizytowki, szerokoscObramowania, znakObramowania);
            
            int pozostalaIloscZnakowLewa, pozostalaIloscZnakowPrawa;
            // linia (2)
            (pozostalaIloscZnakowLewa, pozostalaIloscZnakowPrawa) = wyliczPrzerwy(dlugoscWizytowki, szerokoscObramowania, linia1);
            wypiszLinijkeWizytowki(linia1, linia1.Length, dlugoscWizytowki, pozostalaIloscZnakowLewa, pozostalaIloscZnakowPrawa, szerokoscObramowania, znakObramowania);

            // linia (3)
            (pozostalaIloscZnakowLewa, pozostalaIloscZnakowPrawa) = wyliczPrzerwy(dlugoscWizytowki, szerokoscObramowania, linia2);
            wypiszLinijkeWizytowki(linia2, linia2.Length, dlugoscWizytowki, pozostalaIloscZnakowLewa, pozostalaIloscZnakowPrawa, szerokoscObramowania, znakObramowania);

            // linia 4++
            wypiszLinieObramowania(dlugoscWizytowki, szerokoscObramowania, znakObramowania);
        }
    }
}
