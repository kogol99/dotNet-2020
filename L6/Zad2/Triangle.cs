namespace Zad2
{
    class Triangle : IFigure, IHasInterior
    {
        public double XPosition { get; set; }
        public double YPosition { get; set; }

        string IHasInterior.InteriorColor { get; set; }

        public void moveTo(double x, double y)
        {
            XPosition = x;
            YPosition = y;
        }

        public Triangle(double x, double y)
        {
            XPosition = x;
            YPosition = y;
        }

        public override string ToString()
        {
            return $"Position: {XPosition};{YPosition}";
        }
    }
}
