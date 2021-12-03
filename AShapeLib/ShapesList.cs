using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AbstractShapes;

namespace ShapesHandlers
{
    public delegate void PercentChangedHandler();

    public class ShapesList
    {
        List<IShape> shapes;

        public event PercentChangedHandler PercentChangedEvent;

        public ShapesList()
        {
            shapes = new List<IShape>();
        }

        public ShapesList(List<IShape> _shapes)
        {
            shapes = _shapes;
        }

        public void AddShape(IShape shape)
        {
            shapes.Add(shape);
        }

        public void Clear()
        {
            shapes.Clear();
        }

        public float GetTotalArea()
        {
            float tot = 0;
            int nMax = shapes.Count;
            int cnt = 0;
            bool lEvent = PercentChangedEvent != null;
            foreach (IShape shape in shapes)
            {
                tot += shape.getArea();
                if (lEvent)
                {
                    cnt++;
                    if (cnt >= nMax / 100)
                    {
                        PercentChangedEvent();
                        cnt = 0;
                    }
                }
            }
            return tot;
        }

        public float GetTotalPerimeter()
        {
            bool lEvent = PercentChangedEvent != null;
            float tot = 0;
            int nMax = shapes.Count;
            int cnt = 0;
            foreach (IShape shape in shapes)
            {
                tot += shape.getPerimeter();
                if (lEvent)
                {
                    cnt++;
                    if (cnt >= nMax / 100)
                    {
                        PercentChangedEvent();
                        cnt = 0;
                    }
                }
            }
            return tot;
        }

        public List<String> GetStrList()
        {
            List<String> strl = new List<string>();
            foreach (IShape shape in shapes)
                strl.Add(shape.ToString());
            return strl;
        }
    }
}
