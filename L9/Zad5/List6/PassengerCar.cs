using System;
using System.Collections.Generic;
using System.Text;

namespace Zad5
{
    class PassengerCar : Car
    {
        public string BodyType { get; set; }
        public int Horsepower { get; set; }

        public PassengerCar(string brand, string model, string typeOfFuel, string bodyType, int horsepower)
            : base(brand, model, typeOfFuel)
        {
            BodyType = bodyType;
            Horsepower = horsepower;
        }

        public void CrankUpEngine(int horsepower)
        {
            Horsepower += horsepower;
        }

        public override string ToString()
        {
            return $"Samochód osobowy: marka - {Brand}, model - {Model}, rodzaj paliwa - {TypeOfFuel}," +
                $" typ nadwozia - {BodyType}, moc silnika (KM) - {Horsepower}";
        }
    }
}
