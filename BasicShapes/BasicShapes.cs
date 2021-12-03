using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AbstractShapes;

namespace BasicShapes
{
    public class Rectangle : ABShape
    {
        public Rectangle()  { }

        public Rectangle(float _a, float _b) : base(_a, _b) { }

        public override String Name { get => "Rectangle"; }

        public override float getArea()
        {
            return a * b;
        }

        public override float getPerimeter()
        {
            return 2 * (a + b);
        }
    }

    public class RectThreeAngle : ABShape
    {
        public RectThreeAngle() { }

        public RectThreeAngle(float _a, float _b) : base(_a, _b) { }

        public override String Name { get => "rect_tri"; }

        public override float getArea()
        {
            return a * b / 2;  
        }

        public override float getPerimeter()
        {
            return a + b + C;
        }

        public float C {
            get {
                return (float)Math.Sqrt(a * a + b * b);
            }
        }

        public override string ToString2()
        {
            return base.ToString2() + " c = " + C.ToString();
        }
    }

    public class Square : AShape
    {
	    float a;

        public Square() { }

        public Square(float _a) 
	    {
	        a = _a;
	    }

        public override String Name { get => "Square"; }

        public float A { get => a; set { a = value; } }

        public override float getArea()
        {
            return a * a;
        }

        public override float getPerimeter()
        {
            return 4 * a;
        }

        public override string ToString2()
        {
            return " a = " + a.ToString();
        }
    }
}
