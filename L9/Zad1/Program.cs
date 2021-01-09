using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static System.Console;

namespace Zad1
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Graczyk Kamil, 246994");
            WriteLine($"{Environment.MachineName}\n");

            string path = "";
            WriteLine("Czy poprawna sciezka: 'C:\\kogol\\text.txt' = " + CheckPath("C:\\kogol\\text.txt"));
            WriteLine("Czy poprawna sciezka: '' = " + CheckPath(""));
            WriteLine("Czy poprawna sciezka: 'C:\\kogol\\' = " + CheckPath("C:\\kogol\\"));

            while (!CheckPath(path))  // FileNotFoundException, ArgumentException
            {
                WriteLine("Wpisz ścieżkę: ");
                path = ReadLine();
            }
            Dictionary<string, int> dictionary = ReadFileToDictionary(path);
            WriteBestWord(dictionary);
        }

        static bool CheckPath(string path)
        {
            return File.Exists(path);
        }

        static Dictionary<string, int> ReadFileToDictionary(string path)
        {
            Dictionary<String, int> dictionary = new Dictionary<string, int>();
            try
            {
                using (var sr = new StreamReader(path))
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
                WriteLine("Nie masz wystarczająco pamięci, aby przydzielić bufor dla zwaracanego ciagu:");
                WriteLine(e.Message);
            }
            catch (ArgumentNullException e)
            {
                WriteLine("Ścieżka prowadzi do null:");
                WriteLine(e.Message);
            }
            catch (IOException e)
            {
                WriteLine("Ścieżka zawiera niepoprawną lub nieprawidłową składnię nazwy pliku, nazwy katalogu lub etykiety woluminu:");
                WriteLine(e.Message);
            }
            catch (Exception e)
            {
                WriteLine("Niewyjaśniony błąd:");
                WriteLine(e.Message);
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
            var data = (from row in dictionary
                        orderby row.Value descending
                        select row).Take(10);
            foreach (KeyValuePair<String, int> row in data) WriteLine($" {row.Key} - wystąpień: {row.Value}");
        }

    }
}
