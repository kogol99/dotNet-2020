using System;
using System.Collections.Generic;

namespace Zad2
{
    class Program
    {
        public static void PrintColor(object[] arr)
        {
            foreach (object obj in arr)
            {
                IHasInterior figure = obj as IHasInterior;
                if (figure != null)
                    Console.WriteLine($"{figure.InteriorColor}");
                else
                    Console.WriteLine($"no color");
            }
        }

        public static void MovePostion(object[] arr)
        {
            foreach (object obj in arr)
            {
                if (obj is IFigure)
                {
                    Console.WriteLine($"Before: {obj}");
                    (obj as IFigure).moveTo(0, 0);
                    Console.WriteLine($"After: {obj}");
                }
            }
        }

        static void Main(string[] args)
        {
            object[] arr =
            {
                new Ring(1.1, 1),
                new Ring(2.5, -2.5),
                new Triangle(3.2, 12),
                new Triangle(2, 10),
                new Trapeze(2.9, 1.09),
                new Trapeze(5, 5),
            };

            IHasInterior figure = (IHasInterior)arr[0];
            figure.InteriorColor = "Red";
            figure = (IHasInterior)arr[1];
            figure.InteriorColor = "Green";
            figure = (IHasInterior)arr[2];
            figure.InteriorColor = "Blue";

            PrintColor(arr);

            MovePostion(arr);
        }
    }
}
