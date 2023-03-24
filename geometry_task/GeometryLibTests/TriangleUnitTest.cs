using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometryLib;
using System.Numerics;

namespace GeometryLibTests
{
    [TestClass]
    public class TriangleUnitTest
    {
        [TestMethod]
        public void TestTriangleConstructor()
        {
            Assert.ThrowsException<TriangleCannotExistException>(() => {
                var triangle = new Triangle(Vector2.Zero, Vector2.UnitX * 5f, Vector2.UnitX * 5f);
            });

            Assert.ThrowsException<TriangleCannotExistException>(() => {
                var triangle = new Triangle(new Vector2(2f, 2f), new Vector2(4f, 4f), new Vector2(5f, 5f));
            });
        }

        [TestMethod]
        public void TestRightAngle()
        {
            var triangle = new Triangle(Vector2.Zero, Vector2.UnitX, Vector2.UnitY);
            Assert.IsTrue(triangle.IsRightTriangle());

            triangle = new Triangle(Vector2.UnitX, Vector2.Zero, Vector2.UnitY);
            Assert.IsTrue(triangle.IsRightTriangle());

            triangle = new Triangle(Vector2.UnitX, Vector2.UnitY, Vector2.Zero);
            Assert.IsTrue(triangle.IsRightTriangle());

            triangle = new Triangle(new Vector2(1f, 1f), new Vector2(5f, 3f), new Vector2(4f, 2f));
            Assert.IsFalse(triangle.IsRightTriangle());
        }
    }
}
