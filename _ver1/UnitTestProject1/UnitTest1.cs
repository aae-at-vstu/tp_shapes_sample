using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapeUnitTests
{
    [TestClass]
    public class ShapeTests
    {
        [TestMethod]
        public void TestSquare()
        {
            Square sq = new Square(3, 4);
            Assert.AreEqual(3 * 4, sq.getArea());
        }

        [TestMethod]
        public void TestRectThreeAngle()
        {
            RectThreeAngle sq = new RectThreeAngle(3, 4);
            Assert.AreEqual(3 * 4 / 2, sq.getArea());
        }

    }
}
