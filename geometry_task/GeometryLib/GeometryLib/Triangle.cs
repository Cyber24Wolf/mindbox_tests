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
            if (a == b || a == c || b == c)
            {
                throw new TriangleCannotExistException(a, b, c);
            }

            if (!ValidateVectorsDotProduct(a, b) ||
                !ValidateVectorsDotProduct(b, c) ||
                !ValidateVectorsDotProduct(c, a))
            {
                throw new TriangleCannotExistException(a, b, c);
            }

            // TODO calculate Area without distances somehow, it's too slow
            AB_Length = Vector2.Distance(a, b);
            BC_Length = Vector2.Distance(b, c);
            CA_Length = Vector2.Distance(a, c);

            if (AB_Length > BC_Length + CA_Length ||
                BC_Length > AB_Length + CA_Length ||
                CA_Length > AB_Length + BC_Length)
            {
                throw new TriangleCannotExistException(a, b, c);
            }

            A = a;
            B = b;
            C = c;

            var radius = (AB_Length + BC_Length - CA_Length) * 0.5d;
            InscribedCircle = new Circle(radius);
        }

        private bool ValidateVectorsDotProduct(Vector2 a, Vector2 b)
        {
            var dotProductAbs = Math.Abs(Vector2.Dot(Vector2.Normalize(a), Vector2.Normalize(b)));

            if (dotProductAbs >= 0.999f && dotProductAbs <= 1f)
            {
                return false;
            }

            return true;
        }

        // S = r * p, p - semi perimeter, r - radius of inscribed circle
        public double GetArea()
        {
            var semiPerimeter = (AB_Length + BC_Length + CA_Length) * 0.5d;
            return InscribedCircle.SmallRadius * semiPerimeter;
        }

        public bool IsRightTriangle()
        {
            return IsRightAngle(A,B) || IsRightAngle(B, C) || IsRightAngle(C, A);
        }

        private bool IsRightAngle(Vector2 a, Vector2 b)
        {

            var dotProduct = Vector2.Dot(a, b);
            if (dotProduct == 0f)
            {
                return true;
            }

            return false;
        }
    }

    [Serializable]
    public class TriangleCannotExistException : Exception
    {
        public TriangleCannotExistException(Vector2 a, Vector2 b, Vector2 c) : 
            base($"{typeof(TriangleCannotExistException)}\n Cannot generate triangle from Vectors a:{a} b:{b} c:{c}") { }
    }
}