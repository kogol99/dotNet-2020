using System.Collections.Generic;
using static System.Console;

namespace Zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Student test: ");
            StudentTest();
            WriteLine("\n\nMixedNumber test: ");
            MixedNumberTest();
        }

        static void IntTest()
        {
            ListOfArrayList<int> list1 = new ListOfArrayList<int>(2) { 1, 2, 3};
            ListOfArrayList<int> list2 = new ListOfArrayList<int>(2) { 10, 11, 12, 13, 14 };
            WriteLine(list1);
            WriteLine(list2);
            list1 += list2;
            WriteLine(list1);
        }
        static void StringTest()
        {
            ListOfArrayList<string> list1 = new ListOfArrayList<string>(2) { "Ala", "ma", "kota"};
            ListOfArrayList<string> list2 = new ListOfArrayList<string>(2) { "a", "Kajtek", "psa" };
            WriteLine(list1);
            WriteLine(list2);
            list1 += list2;
            WriteLine(list1);
        }
        static void StudentTest()
        {
            ListOfArrayList<Student> list1 = new ListOfArrayList<Student>(2) { new Student("Kamil", "Graczyk", 246994, "246994@pwr.edu.pl"), new Student("Andrzej", "Nowak", 246987, "246987@pwr.edu.pl") };
            ListOfArrayList<Student> list2 = new ListOfArrayList<Student>(2) { new Student("Jarosław", "Ciamajda", 287465, "287465@pwr.edu.pl") };
            WriteLine("Lista1:");
            WriteLine(list1);
            WriteLine("Lista2:");
            WriteLine(list2);
            WriteLine("Wynik lista1+lista2:");
            list1 += list2;
            WriteLine(list1);
        }
        static void MixedNumberTest()
        {
            ListOfArrayList<MixedNumber> list1 = new ListOfArrayList<MixedNumber>(2) { new MixedNumber(2.3), new MixedNumber(3,2), new MixedNumber(22,23,32)};
            ListOfArrayList<MixedNumber> list2 = new ListOfArrayList<MixedNumber>(2) { new MixedNumber(2,1), new MixedNumber(2.1), new MixedNumber(2,1,2)};
            WriteLine("Lista1:");
            WriteLine(list1);
            WriteLine("Lista2:");
            WriteLine(list2);
            WriteLine("Wynik lista1+lista2:");
            list1 += list2;
            WriteLine(list1);
        }
    }
}
