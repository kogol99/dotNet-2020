using System;

namespace Zad2
{
    public static class MyStringExtension
    {
        public static string ReplaceString(this string str)
        {
            string newString = "";
            int stringSize = str.Length;
            for(int i=0; i<stringSize; i++)
            {
                int asciiCode = (int)str[i];
                if ((asciiCode >= 65 && asciiCode <= 90) || (asciiCode >= 97 && asciiCode <= 122))
                {
                    if (i % 2 == 0)
                    {
                        if (asciiCode >= 97 && asciiCode <= 122)
                        {
                            int newAsciiCode = asciiCode - 32;
                            newString += (char)newAsciiCode;
                        }
                        else
                        {
                            newString += str[i];
                        }
                    }
                    else
                    {
                        if (asciiCode >= 97 && asciiCode <= 122)
                        {
                            newString += str[i];
                        }
                        else
                        {
                            int newAsciiCode = asciiCode + 32;
                            newString += (char)newAsciiCode;
                        }
                    }
                }
                else
                {
                    newString += ".";
                }
            }
            return newString;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            String tajemniczyString = "nazywam sie kot maciej i chcialbym wam pokazac fajne znaczki ;;1.3;'423,;123";
            Console.WriteLine(MyStringExtension.ReplaceString(tajemniczyString));
        }
    }
}
