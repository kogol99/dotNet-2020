using System;

namespace Zad1
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] arr =
            {
                new Bike("Romet","XS3322","18",true),
                new Bike("Giant","MEN3212","20",false),
                new PassengerCar("Volvo","XC90","Hybrid","SUV",300),
                new PassengerCar("Mercedes-Benz","G900","Hybrid","SUV",887),
                new Truck("Volvo","FH500","Diesel",20000,"with trailer",false),
                new Truck("Mercedes-Benz", "Sprinter", "Diesel", 4500, "vans", false)
            };
            foreach (Vehicle vehicle in arr)
            {
                Console.WriteLine(vehicle);
            }
            int loadCapacity = 0;
            loadCapacity = CalculateLoadCapacity(arr);
            Console.WriteLine($"Nośność dla wszystkich pojazdów wynosi: {loadCapacity}");
        }

        public static int CalculateLoadCapacity(Vehicle[] arr)
        {
            int loadCapacity = 0;
            foreach (Vehicle vehicle in arr)
            {
                Truck auto = vehicle as Truck;
                if (auto != null)
                    loadCapacity += auto.LoadCapacity;
            }
            return loadCapacity;
        }
    }
}
