using System;

namespace Zad1
{
    class Bike : Vehicle
    {
        public string FrameSize { get; set; }
        public bool IsBikeTrunk { get; set; }

        public Bike(string brand, string model, string frameSize, bool isBikeTrunk) : base(brand, model)
        {
            FrameSize = frameSize;
            IsBikeTrunk = isBikeTrunk;
        }

        public void GetBikeReady()
        {
            Console.WriteLine("Rower gotowy do jazdy");
        }

        public override string ToString()
        {
            return $"Rower: marka - {Brand}, model - {Model}, rozmiar ramy - {FrameSize}, czy posiada bagażnik - {IsBikeTrunk}";
        }
    }
}
