using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Zad3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wpisz ścieżkę: ");
            string path = Console.ReadLine();
            while (!File.Exists(path))  // FileNotFoundException (nieistniejaca sciezka) i przy okazji ArgumentException (brak ścieżki)
            {
                path = Console.ReadLine();
            }
            Dictionary<string, int> dictionary = ReadFileToDictionary(path);
            WriteBestWord(dictionary);
        }

        static Dictionary<string, int> ReadFileToDictionary(string path)
        {
            Dictionary<String, int> dictionary = new Dictionary<string, int>();
            try
            {
                using (var sr = new StreamReader("C:\\Users\\kogol\\source\\repos\\dotNet_Lista7\\Zad1\\big.txt"))
                //using (var sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string stringLine = sr.ReadLine();
                        StringBuilder word = new StringBuilder();
                        foreach (char chc in stringLine)
                        {
                            if (Char.IsLetter(chc))
                            {
                                word.Append(chc);
                            }
                            else if (word.Length != 0)
                            {
                                AddWordToDictionary(dictionary, ref word);
                            }
                        }
                        if (word.Length != 0) AddWordToDictionary(dictionary, ref word);
                    }
                }
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine("Nie masz wystarczająco pamięci, aby przydzielić bufor dla zwaracanego ciagu:");
                Console.WriteLine(e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Ścieżka prowadzi do null:");
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("Ścieżka zawiera niepoprawną lub nieprawidłową składnię nazwy pliku, nazwy katalogu lub etykiety woluminu:");
                Console.WriteLine(e.Message);
            }
            return dictionary;
        }

        static void AddWordToDictionary(Dictionary<string, int> dictionary, ref StringBuilder word)
        {
            string smallWord = word.ToString().ToLower();
            int numberOfAppearances;
            if (dictionary.TryGetValue(smallWord, out numberOfAppearances))
            {
                dictionary[smallWord] = numberOfAppearances + 1;
            }
            else
            {
                dictionary.Add(smallWord, 1);
            }
            word.Clear();
        }

        static void WriteBestWord(Dictionary<string, int> dictionary)
        {
            int size;
            if (dictionary.Count < 10)
            {
                size = dictionary.Count;
            }
            else
            {
                size = 10;
            }
            int actualElement = 0;
            foreach (KeyValuePair<string, int> row in dictionary.OrderByDescending(key => key.Value))
            {
                if (actualElement++ != size)
                {
                    Console.WriteLine("Wyraz: {0} ; Liczba wystąpień: {1}", row.Key, row.Value);
                }
                else break;
            }
        }
    }
}
