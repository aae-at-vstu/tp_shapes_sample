using System;
using System.Collections.Generic;
using Shapes;

namespace DataSourceIF
{
    public interface IDataSource
    {
        List<IShape> GetShapes();
        //List<String> GetShapesStr();    // Некрасиво, пока - так...
        int ShapesCount { get; set; }
    }
}
