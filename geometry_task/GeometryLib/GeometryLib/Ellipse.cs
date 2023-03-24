using System;

namespace GeometryLib
{
    public class Ellipse : IFlat
    {
        public double SmallRadius { get; private set; }
        public double BigRadius { get; private set; }

        public Ellipse(double radiusA, double radiusB)
        {
            SmallRadius = Math.Min(radiusA, radiusB);
            BigRadius = Math.Max(radiusA, radiusB);
        }

        public double GetArea()
        {
            return Math.PI * SmallRadius * BigRadius;
        }
    }
}
