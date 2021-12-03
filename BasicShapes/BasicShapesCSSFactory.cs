using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AbstractShapes;

namespace BasicShapes
{
    public class BasicShapesCSFactory : IShapeFactory
    {
        public float A { get; set; }
        public float B { get; set; }

        public IShape CreateShapeFromString(String src)
        {
            IShape shape = null;
            String[] arr = src.Split(';');
            try
            {
                if (arr[0] == "0")
                    shape = new Rectangle(float.Parse(arr[1]), float.Parse(arr[2]));
                else if (arr[0] == "1")
                    shape = new RectThreeAngle(float.Parse(arr[1]), float.Parse(arr[2]));
                else if (arr[0] == "2")
                    shape = new Square(float.Parse(arr[1]));
                A = float.Parse(arr[1]);
                B = float.Parse(arr[2]);
            }
            catch { }
            return shape;
        }
    }
}
