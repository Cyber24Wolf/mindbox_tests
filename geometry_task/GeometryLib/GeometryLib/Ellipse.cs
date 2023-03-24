using System;

namespace GeometryLib
{
    public class Ellipse : IFlat
    {
        public double SmallRadius { get; private set; }
        public double BigRadius { get; private set; }

        public Ellipse(double radiusA, double radiusB)
        {
            if (!ValidateRadius(radiusA) && !ValidateRadius(radiusB))
            {
                SmallRadius = 0d;
                BigRadius = 0d;
                return;
            }

            SmallRadius = Math.Min(radiusA, radiusB);
            BigRadius = Math.Max(radiusA, radiusB);
        }

        // if radius is valid return true.
        private bool ValidateRadius(double radius)
        {
            if (radius == 0d)
            {
                throw new WrongRadiusException(radius);
            }

            return true;
        }

        public double GetArea()
        {
            return Math.PI * SmallRadius * BigRadius;
        }
    }

    [Serializable]
    public class WrongRadiusException : Exception
    {
        public WrongRadiusException(double radius) : base($"{typeof(WrongRadiusException)}\n Can\'t hold the {radius}") { }
    }
}
