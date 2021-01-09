using System;

using static System.Console;

namespace Zad1
{

    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Graczyk Kamil, 246994");
            WriteLine($"{Environment.MachineName}\n");
            //WriteLine("Int test: ");
            //intTest();
            //WriteLine("\n\nString test: ");
            //stringTest();
            WriteLine("\n\nStudent test: ");
            studentTest();
            WriteLine("\n\nMixedNumber test: ");
            mixedNumberTest();
        }

        static void intTest()
        {
            var array = new ListOfArrayList<int>(4);
            array.Add(1);
            array.Add(3);
            array.Add(6);
            array.Add(2);

            array.Add(8);
            array.Add(0);
            array.Add(4);
            array.Add(7);

            array.Add(1);
            WriteLine("Aktualna tablica: ");
            WriteLine(array);
            WriteLine("Metoda Remove(3)");
            array.Remove(3);
            WriteLine("Aktualna tablica: ");
            WriteLine(array);

            WriteLine("Metoda Trim()");
            array.Trim();
            WriteLine("Aktualna tablica: ");
            WriteLine(array);

            WriteLine("Metoda array[7]: ");
            WriteLine(array[7]);

            WriteLine("Metoda Clear()");
            array.Clear();
            WriteLine("Aktualna tablica: ");
            WriteLine(array);
        }

        static void stringTest()
        {
            var array = new ListOfArrayList<string>(2);
            array.Add("Ala");
            array.Add("ma");

            string kot = "kota";
            array.Add(kot);

            WriteLine("Aktualna tablica: ");
            WriteLine(array);
            WriteLine("Count: ");
            WriteLine(array.Count);

            WriteLine("Metoda Contains(kot): ");
            WriteLine(array.Contains(kot));
            WriteLine("Metoda IndexOf(kot): ");
            WriteLine(array.IndexOf(kot));
        }

        static void studentTest()
        {
            var array = new ListOfArrayList<Student>(1);

            Student ja = new Student("Kamil", "Graczyk", 246994, "246994@pwr.edu.pl");
            array.Add(ja);
            array.Add(new Student("Jan", "Nowak", 249874, "249874@pwr.edu.pl"));
            array.Add(new Student("Zigniew", "Kowalski", 247896, "247896@pwr.edu.pl"));

            WriteLine("Aktualna tablica: ");
            WriteLine(array);

            WriteLine("Metoda RemoveAt(2)");
            array.RemoveAt(2);

            WriteLine("Aktualna tablica: ");
            WriteLine(array);

            WriteLine("Metoda IndexOf(new Student(\"Kamil\", \"Graczyk\", 246994, \"246994@pwr.edu.pl\"))");
            WriteLine(array.IndexOf(new Student("Kamil", "Graczyk", 246994, "246994@pwr.edu.pl")));

            WriteLine("Metoda Contains(new Student(\"Kamil\", \"Graczyk\", 246994, \"246994@pwr.edu.pl\"))");
            WriteLine(array.Contains(new Student("Kamil", "Graczyk", 246994, "246994@pwr.edu.pl")));

            WriteLine("Metoda Trim()");
            array.Trim();

            WriteLine("Aktualna tablica: ");
            WriteLine(array);

            WriteLine("Metoda Remove(ja)");
            array.Remove(ja);

            WriteLine("Aktualna tablica: ");
            WriteLine(array);

            WriteLine("Count");
            WriteLine(array.Count);

            WriteLine("Metoda Clear()");
            array.Clear();

            WriteLine("Aktualna tablica: ");
            WriteLine(array);
        }

        static void mixedNumberTest()
        {
            var array = new ListOfArrayList<MixedNumber>(3);

            MixedNumber myNumber = new MixedNumber(5.25);
            array.Add(myNumber);
            array.Add(new MixedNumber(43,23));
            array.Add(new MixedNumber(10.25));
            array.Add(new MixedNumber(81,2));

            WriteLine("Aktualna tablica: ");
            WriteLine(array);

            WriteLine("Metoda RemoveAt(2)");
            array.RemoveAt(2);

            WriteLine("Aktualna tablica: ");
            WriteLine(array);

            WriteLine("Metoda IndexOf(myNumber)");
            WriteLine(array.IndexOf(myNumber));

            WriteLine("Metoda Contains(myNumber)");
            WriteLine(array.Contains(myNumber));

            WriteLine("Metoda Trim()");
            array.Trim();

            WriteLine("Aktualna tablica: ");
            WriteLine(array);

            WriteLine("Metoda Remove(myNumber)");
            array.Remove(myNumber);

            WriteLine("Aktualna tablica: ");
            WriteLine(array);

            WriteLine("Count");
            WriteLine(array.Count);

            WriteLine("Metoda Clear()");
            array.Clear();

            WriteLine("Aktualna tablica: ");
            WriteLine(array);
        }
    }
}
