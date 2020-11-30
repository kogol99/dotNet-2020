using System;
using System.Collections.Generic;
using System.Text;

namespace Zad1
{
    abstract class Car: Vehicle
    {
        public string TypeOfFuel { get; set; }


        public Car(string brand, string model, string typeOfFuel) : base(brand, model)
        {
            TypeOfFuel = typeOfFuel;
        }
        
        public bool CanIInstallLpg()
        {
            if (TypeOfFuel == "Petrol") return true;
            else return false;
        }

        public override string ToString()
        {
            return $"Samochód: marka - {Brand}, model - {Model}, rodzaj paliwa - {TypeOfFuel}";
        }
    }
}
