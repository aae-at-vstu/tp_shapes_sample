using System;
using Shapes;
using DataSourceIF;
using System.Collections.Generic;

namespace ConstDS 
{
    public class ConstantListDS : IDataSource
    {
        List<IShape> shapes;

        public ConstantListDS(int cnt = 3)
        {
            shapes = new List<IShape>();
            if (cnt == 3)
            {
                shapes.Add(new Square(3, 4));
                shapes.Add(new Square(2, 2));
                shapes.Add(new RectThreeAngle(3, 4));
            }
            else
            {
                for (int i=0; i < cnt/2; i++)
                {
                    shapes.Add(new Square(2, 2));
                    shapes.Add(new RectThreeAngle(3, 4));
                }
            }
        }

        public int ShapesCount
        {
            get
            {
                return shapes.Count;
            }

            set { }
        }

        public List<IShape> GetShapes()
        {
            return shapes;
        }

        //public List<String> GetShapesStr()
        //{
        //    return new List<string>() { "0;3;4;0", "0;2;2;0", "1;3;4;0"};
        //}
    }
}
