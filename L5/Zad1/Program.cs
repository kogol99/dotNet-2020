using System;
using System.Text.RegularExpressions;

namespace Zad1
{
    class Program
    {
        static void Main(string[] args)
        {
            MixedNumber test1 = new MixedNumber(1, -151, -10);
            Console.WriteLine(test1);
            MixedNumber test3 = new MixedNumber(1.32);
            MixedNumber test4 = new MixedNumber(16, 5);
            Console.WriteLine("Dodawanie: " + test3 + " oraz " + test4 + " = " + (test3 + test4));

            MixedNumber test5 = new MixedNumber(2, 1, 2);
            MixedNumber test6 = new MixedNumber(-1, 1, 4);
            Console.WriteLine("Dodawanie: " + test5 + " oraz " + test6 + " = " + (test5 + test6));

            MixedNumber test7 = new MixedNumber(-2, 1, 2);
            MixedNumber test8 = new MixedNumber(1, 1, 4);
            Console.WriteLine("Dodawanie: " + test7 + " oraz " + test8 + " = " + (test7 + test8));

            MixedNumber test9 = new MixedNumber(-1, 1, 2);
            MixedNumber test10 = new MixedNumber(1, 1, 2);
            Console.WriteLine("Dodawanie: " + test9 + " oraz " + test10 + " = " + (test9 + test10));

            Console.WriteLine("Licznik zmian dla 2 dodawanej liczby: " + test10.licznikZmian);
        }

        public static MixedNumber dodawanie(MixedNumber zestaw1, MixedNumber zestaw2)
        {
            if (zestaw1.calkowita == 0 && zestaw2.calkowita == 0)
            {
                return new MixedNumber((zestaw1.licznik * zestaw2.mianownik) + (zestaw2.licznik * zestaw1.mianownik), zestaw1.mianownik * zestaw2.mianownik);
            }
            else if (zestaw1.calkowita < 0 && zestaw2.calkowita >= 0)
            {
                return new MixedNumber(Math.Round(zestaw1.calkowita + zestaw2.calkowita - Math.Round((double)zestaw1.licznik / zestaw1.mianownik, 5) + Math.Round((double)zestaw2.licznik / zestaw2.mianownik, 5), 5));
            }
            else if (zestaw1.calkowita >= 0 && zestaw2.calkowita < 0)
            {
                return new MixedNumber(Math.Round(zestaw1.calkowita + zestaw2.calkowita + Math.Round((double)zestaw1.licznik / zestaw1.mianownik, 5) - Math.Round((double)zestaw2.licznik / zestaw2.mianownik, 5), 5));
            }
            else
            {
                return new MixedNumber(zestaw1.calkowita + zestaw2.calkowita, (zestaw1.licznik * zestaw2.mianownik) + (zestaw2.licznik * zestaw1.mianownik), zestaw1.mianownik * zestaw2.mianownik);
            }
        }
    }

    class MixedNumber
    {
        public int licznik;
        public int mianownik;
        public int licznikZmian { get; set; } = 0;
        public int calkowita { get; set; }
        public int Licznik
        {
            get
            {
                return licznik;
            }
            set
            {
                licznik = Math.Abs(value);
            }
        }
        public int Mianownik
        {
            get
            {
                return mianownik;
            }
            set
            {
                if (value == 0) throw (new DivideByZeroException("Mianownik nie może być równy 0"));
                mianownik = Math.Abs(value);
            }
        }

        public MixedNumber(int calkowita, int licznik, int mianownik)
        {
            licznik = System.Math.Abs(licznik);
            mianownik = System.Math.Abs(mianownik);
            ZoptymalizujUlamek(ref calkowita, ref licznik, ref mianownik);
            this.calkowita = calkowita;
            Licznik = licznik;
            Mianownik = mianownik;
        }

        public MixedNumber(int licznik, int mianownik) : this(0, licznik, mianownik)
        {
        }

        public MixedNumber(double liczba)
        {
            int calkowita = Convert.ToInt32(liczba);
            int licznik = Math.Abs(Convert.ToInt32((liczba % 1) * 100));
            int mianownik = 100;
            ZoptymalizujUlamek(ref calkowita, ref licznik, ref mianownik);
            this.calkowita = calkowita;
            Licznik = licznik;
            Mianownik = mianownik;
        }

        int NWD(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }

        void WylaczCzescCalkowita(ref int calkowita, ref int licznik, ref int mianownik)
        {
            if (mianownik != 0)
            {
                int dodatkowaCzescCalkowita = licznik / mianownik;
                if (dodatkowaCzescCalkowita >= 1)
                {
                    calkowita += dodatkowaCzescCalkowita;
                    licznik = licznik % mianownik;
                }
            }
            licznikZmian++;
        }

        void SkrocUlamek(ref int licznik, ref int mianownik)
        {
            if (licznik != 0)
            {
                int nWD = NWD(licznik, mianownik);
                licznik /= nWD;
                mianownik /= nWD;
            }
            licznikZmian++;
        }

        void ZoptymalizujUlamek(int calkowita, int licznik, int mianownik)
        {
            ZoptymalizujUlamek(ref calkowita, ref licznik, ref mianownik);
        }

        void ZoptymalizujUlamek(ref int calkowita, ref int licznik, ref int mianownik)
        {
            WylaczCzescCalkowita(ref calkowita, ref licznik, ref mianownik);
            SkrocUlamek(ref licznik, ref mianownik);
        }

        public override string ToString()
        {
            string wynik = "";
            if (this.calkowita != 0)
            {
                wynik += this.calkowita + " ";
            }
            if (Licznik != 0)
            {
                wynik += Licznik + "/" + Mianownik;
            }
            if (this.calkowita == 0 && Licznik == 0)
            {
                wynik += "0";
            }
            return wynik;

        }

        public static MixedNumber operator +(MixedNumber zestaw1, MixedNumber zestaw2)
        {
            if (zestaw1.calkowita == 0 && zestaw2.calkowita == 0)
            {
                return new MixedNumber((zestaw1.licznik * zestaw2.mianownik) + (zestaw2.licznik * zestaw1.mianownik), zestaw1.mianownik * zestaw2.mianownik);
            }
            else if (zestaw1.calkowita < 0 && zestaw2.calkowita >= 0)
            {
                return new MixedNumber(Math.Round(zestaw1.calkowita + zestaw2.calkowita - Math.Round((double)zestaw1.licznik / zestaw1.mianownik, 5) + Math.Round((double)zestaw2.licznik / zestaw2.mianownik, 5), 5));
            }
            else if (zestaw1.calkowita >= 0 && zestaw2.calkowita < 0)
            {
                return new MixedNumber(Math.Round(zestaw1.calkowita + zestaw2.calkowita + Math.Round((double)zestaw1.licznik / zestaw1.mianownik, 5) - Math.Round((double)zestaw2.licznik / zestaw2.mianownik, 5), 5));
            }
            else
            {
                return new MixedNumber(zestaw1.calkowita + zestaw2.calkowita, (zestaw1.licznik * zestaw2.mianownik) + (zestaw2.licznik * zestaw1.mianownik), zestaw1.mianownik * zestaw2.mianownik);
            }
        }
    }
}
