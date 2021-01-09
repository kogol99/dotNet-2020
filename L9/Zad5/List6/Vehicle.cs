using System;

namespace Zad5
{
    abstract class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public Vehicle(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }

        public void Run()
        {
            Console.WriteLine("Wrrrr");
        }

        public override string ToString()
        {
            return $"Pojazd: marka - {Brand}, model - {Model}";
        }
    }
}
