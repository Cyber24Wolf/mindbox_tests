using System;
using System.Numerics;

namespace GeometryLib
{
    public class Triangle : IFlat
    {
        public Vector2 A { get; private set; }
        public Vector2 B { get; private set; }
        public Vector2 C { get; private set; }

        public double AB_Length { get; private set; }
        public double BC_Length { get; private set; }
        public double CA_Length { get; private set; }

        public Circle InscribedCircle { get; private set; }

        public Triangle(Vector2 a, Vector2 b, Vector2 c)
        {
            // TODO calculate Area without distances somehow, it's too slow
            AB_Length = Vector2.Distance(a, b);
            BC_Length = Vector2.Distance(b, c);
            CA_Length = Vector2.Distance(a, c);

            if (AB_Length <= BC_Length + CA_Length ||
                BC_Length <= AB_Length + CA_Length ||
                CA_Length <= AB_Length + BC_Length)
            {
                throw new TriangleCannotExistException(A, B, C);
            }

            A = a;
            B = b;
            C = c;

            var radius = (AB_Length + BC_Length - CA_Length) * 0.5d;
            InscribedCircle = new Circle(radius);
        }

        // S = r * p, p - semi perimeter, r - radius of inscribed circle
        public double GetArea()
        {
            var semiPerimeter = (AB_Length + BC_Length + CA_Length) * 0.5d;
            return InscribedCircle.SmallRadius * semiPerimeter;
        }

        [Serializable]
        public class TriangleCannotExistException : Exception
        {
            public TriangleCannotExistException(Vector2 a, Vector2 b, Vector2 c) : base($"{typeof(TriangleCannotExistException)}\n Cannot generate triangle from Vectors a:{a} b:{b} c:{c}") { }
        }
    }
}