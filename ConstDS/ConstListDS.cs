using System;
using AbstractShapes;
using BasicShapes;
using DataSource;
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
                shapes.Add(new Rectangle(3, 4));
                shapes.Add(new Rectangle(2, 3));
                shapes.Add(new RectThreeAngle(3, 4));
            }
            else
            {
                for (int i=0; i < cnt/3; i++)
                {
                    shapes.Add(new Rectangle(2, 3));
                    shapes.Add(new Square(2));
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

        public void AddShape(string par)
        {
            throw new NotImplementedException();
        }

        public List<IShape> GetShapes()
        {
            return shapes;
        }
    }
}
