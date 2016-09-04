namespace Abstraction
{
    using System;

    public abstract class Figure
    {
        public Figure()
        {
        }

        public Figure(double radius)
        {
            this.ValidateData(radius);
            this.Radius = radius;
        }

        public Figure(double width, double height)
        {
            this.ValidateData(width);
            this.ValidateData(height);
            this.Width = width;
            this.Height = height;
        }
        
        public virtual double Width { get; private set; }

        public virtual double Height { get; private set; }

        public virtual double Radius { get; private set; }

        private void ValidateData(double data)
        {
            if (data <= 0)
            {
                throw new ArgumentOutOfRangeException("Data must be greater than zero!");
            }
        }
    }
}
