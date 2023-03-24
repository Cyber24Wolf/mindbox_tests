using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometryLib;

namespace GeometryLibTests
{
    [TestClass]
    public class CircleUnitTest
    {
        [TestMethod]
        public void TestCircleConstructor()
        {
            Assert.ThrowsException<WrongRadiusException>(() => {                
                var cicle = new Circle(0d);
            });

            Assert.ThrowsException<WrongRadiusException>(() => {
                var cicle = new Circle(-20d);
            });
        }

        [TestMethod]
        public void TestCicleArea()
        {
            var radius = 10d;
            var circle = new Circle(radius);
            Assert.IsTrue(circle.GetArea() == Math.PI * radius * radius);
        }

        [TestMethod]
        public void TestCircleRadiuses()
        {
            var radius = 5d;
            var circle = new Circle(radius);
            Assert.IsTrue(circle.BigRadius == circle.SmallRadius);
        }
    }
}
