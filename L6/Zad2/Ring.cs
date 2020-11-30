namespace Zad2
{
    class Ring : IHasInterior
    {
        public double XPosition { get; set; }
        public double YPosition { get; set; }

        string IHasInterior.InteriorColor { get; set; }

        public Ring(double x, double y)
        {
            XPosition = x;
            YPosition = y;
        }
    }
}
