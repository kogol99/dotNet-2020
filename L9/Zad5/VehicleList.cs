using System;
using System.Collections.Generic;
using System.Text;

namespace Zad5
{
    class VehicleList
    {
        public List<Vehicle> Vehicles { get; }

        public VehicleList()
        {
            Vehicles = new List<Vehicle>();
        }

        public static double CountVehiclesLoadCapacity(List<Vehicle> vehicles)
        {
            double sumOfCapacity = 0;
            foreach (Vehicle vehicle in vehicles)
            {
                sumOfCapacity += (vehicle as Truck)?.LoadCapacity ?? 0;
            }
            return sumOfCapacity;
        }
    }
}
