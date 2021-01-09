using System;
using System.Collections.Generic;
using System.Text;

namespace Zad1
{
    class MixedNumber
    {
        public int licznik;
        public int mianownik;
        public static int licznikZmian { get; private set; }
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
