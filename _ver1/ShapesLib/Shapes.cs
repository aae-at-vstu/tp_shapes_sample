using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public interface IShape
    {
        String Name { get; }
        float getArea();
        float getPerimeter();
    }

    public abstract class AShape : IShape
    {
        protected float a;
        protected float b;

        public AShape(float _a, float _b)
        {
            a = _a;
            b = _b;
        }

        public float A { get => a; }
        public float B { get => b; }

        public abstract String Name { get; }
        public abstract float getArea();
        public abstract float getPerimeter();

        public override string ToString()
        {
            return "a = " + a.ToString() + " b = " + b.ToString() +
                " area = " + getArea().ToString() +
                " perimeter = " + getPerimeter().ToString();
        }
    }

    public class ShapeCreator
    {
        public static IShape CreateShapeFromCSString(String src)
        {
            IShape shape = null;
            String[] arr = src.Split(';');
            try
            {
                if (arr[0] == "0")
                    shape = new Square(float.Parse(arr[1]), float.Parse(arr[2]));
                else
                    shape = new RectThreeAngle(float.Parse(arr[1]), float.Parse(arr[2]));
            }
            catch { }
            return shape;
        }
    }
    
    public class Square : AShape
    {
        public Square(float _a, float _b) : base(_a, _b) { }

        public override String Name { get => "square"; }

        public override float getArea()
        {
            return a * b;
        }

        public override float getPerimeter()
        {
            return 2 * (a + b);
        }

        public override string ToString()
        {
            return Name + ": " + base.ToString();
        }
    }

    public class RectThreeAngle : AShape
    {
        public RectThreeAngle(float _a, float _b) : base(_a, _b) { }

        public override String Name { get => "rect_tri"; }

        public override float getArea()
        {
            return a * b / 2;  
        }

        public override float getPerimeter()
        {
            //return a + b + (float)Math.Sqrt(a * a + b * b);
            return a + b + C;
        }

        public float C {
            get {
                return (float)Math.Sqrt(a * a + b * b);
            }
        }

        public override string ToString()
        {
            return Name + ": " + " c = " + C.ToString() + " " + base.ToString();
        }
    }
}
