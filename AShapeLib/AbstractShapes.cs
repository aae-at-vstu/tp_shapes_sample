using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShapes
{
    public interface IShape
    {
        int Id { get; set; }
        String Name { get; }
        String Value { get; }
        float getArea();
        float getPerimeter();
    }

    public abstract class AShape : IShape
    {
        public int Id { get; set; }
        public abstract String Name { get; }
        public abstract float getArea();
        public abstract float getPerimeter();
        public abstract string ToString2();

        public override string ToString()
        {
            return Name + ": " + ToString2() + 
                " area = " + getArea().ToString() +
                " perimeter = " + getPerimeter().ToString();
        }

        public String Value
        {
            get => ToString2() +
                " area = " + getArea().ToString() +
                " perimeter = " + getPerimeter().ToString();
        } 
    }

    public abstract class ABShape : AShape
    {
        protected float a;
        protected float b;

        public ABShape() { }
        public ABShape(float _a, float _b)
        {
            a = _a;
            b = _b;
        }

        public float A { get => a; set { a = value; } }
        public float B { get => b; set { b = value; } }

        public override string ToString2()
        {
            return " a = " + a.ToString() + " b = " + b.ToString();
        }
    }

    public interface IShapeFactory 
    {
	IShape CreateShapeFromString(String src);
	//IShape CreateShapeFromFList(IList<float> lst);
    }	
}
