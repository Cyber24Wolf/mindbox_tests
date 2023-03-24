using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometryLib;

namespace GeometryLibTests
{
    [TestClass]
    public class EllipseUnitTest
    {

        [TestMethod]
        public void TestEllipseConstructor()
        {
            Assert.ThrowsException<WrongRadiusException>(() => {
                var ellipse = new Ellipse(0d, 5d);
            });

            Assert.ThrowsException<WrongRadiusException>(() => {
                var ellipse = new Ellipse(4d, 0d);
            });

            Assert.ThrowsException<WrongRadiusException>(() => {
                var ellipse = new Ellipse(-1d, 4d);
            });

            Assert.ThrowsException<WrongRadiusException>(() => {
                var ellipse = new Ellipse(0d, 0d);
            });
        }

        [TestMethod]
        public void TestEllipseArea()
        {
            var radiusA = 4d;
            var radiusB = 5d;
            var ellipse = new Ellipse(radiusA, radiusB);
            Assert.IsTrue(ellipse.GetArea() == Math.PI * radiusA * radiusB);
        }
    }
}
