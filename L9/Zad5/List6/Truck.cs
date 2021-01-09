using System;
using System.Collections.Generic;
using System.Text;

namespace Zad5
{
    class Truck : Car
    {
        public string TruckType { get; set; }
        public bool IsElevator { get; set; }
        public int LoadCapacity { get; set; }

        public Truck(string brand, string model, string typeOfFuel, int loadCapacity, string truckType, bool isElevator)
            : base(brand, model, typeOfFuel)
        {
            TruckType = truckType;
            IsElevator = isElevator;
            LoadCapacity = loadCapacity;
        }

        public void RenewElevatorTechnicalExamination()
        {
            IsElevator = true;
        }

        public override string ToString()
        {
            return $"Samochód ciężarowy: marka - {Brand}, model - {Model}, rodzaj paliwa - {TypeOfFuel}, nośność - {LoadCapacity}," +
                $" typ ciężarówki - {TruckType}, czy posiada windę - {IsElevator}";
        }
    }
}
