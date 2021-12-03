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
            RectThreeAngle tri = new RectThreeAngle(3, 4);
            Assert.AreEqual(3 * 4 / 2, tri.getArea());
            Assert.AreEqual(3 + 4 + tri.C, tri.getPerimeter());
        }

        [TestMethod]
        public void TestShapeList()
        {
            RectThreeAngle tri = new RectThreeAngle(3, 4);
            Square sq = new Square(2, 2);
            ShapesList sh = new ShapesList();
            sh.AddShape(tri);
            sh.AddShape(sq);
            Assert.AreEqual(tri.getArea() + sq.getArea(), sh.GetTotalArea());
            Assert.AreEqual(tri.getPerimeter() + sq.getPerimeter(), sh.GetTotalPerimeter());
        }

    }
}
