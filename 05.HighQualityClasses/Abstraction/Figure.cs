namespace Abstraction
{
    using System;

    public abstract class Figure
    {
        protected Figure()
        {

        }

        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();
    }
}
