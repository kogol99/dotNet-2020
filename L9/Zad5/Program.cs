using System;
using System.Collections.Generic;
using System.Reflection;
using static System.Console;

namespace Zad5
{
    class Program
    {
        static List<Vehicle> GetVehiclesList()
        {
            List<Vehicle> vehicles = new List<Vehicle>(){
            new Bike("Romet", "XS3322", "18", true),
            new Bike("Giant", "MEN3212", "20", false),
            new PassengerCar("Volvo", "XC90", "Hybrid", "SUV", 300),
            new PassengerCar("Mercedes-Benz", "G900", "Hybrid", "SUV", 887),
            new Truck("Volvo", "FH500", "Diesel", 20000, "with trailer", false),
            new Truck("Mercedes-Benz", "Sprinter", "Diesel", 4500, "vans", false)
            };
            return vehicles;
        }

        static double GetVehiclesCapacity(VehicleList garage)
        {
            MethodInfo methodInfo = garage.GetType().GetMethod("CountVehiclesLoadCapacity",
                new Type[] { typeof(List<Vehicle>) });
            double sumOfcapacity = (double)methodInfo.Invoke(garage,
                new object[] { garage.Vehicles });

            return sumOfcapacity;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Graczyk Kamil, 246994");
            Console.WriteLine($"{Environment.MachineName}\n");

            VehicleList garage = new VehicleList();
            garage.Vehicles.AddRange(GetVehiclesList());
            double result = GetVehiclesCapacity(garage);
            WriteLine("\nŁączna nośćność pojazdów: " + result);
        }
    }
}
