namespace Zad2
{
    class Trapeze : IFigure
    {
        public double XPosition { get; set; }
        public double YPosition { get; set; }

        public void moveTo(double x, double y)
        {
            XPosition = x;
            YPosition = y;
        }

        public Trapeze(double x, double y)
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
