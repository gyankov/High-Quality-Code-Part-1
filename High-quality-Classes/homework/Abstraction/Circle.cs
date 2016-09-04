namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        public Circle(double radius) : base(radius)
        {
        }

        public double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
