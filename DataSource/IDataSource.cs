using System;
using System.Collections.Generic;
using AbstractShapes;

namespace DataSource
{
    public interface IDataSource
    {
        List<IShape> GetShapes();
        void AddShape(string par);
        int ShapesCount { get; set; }
    }

    public interface IDataSourceFactory
    {
        IDataSource GetDataSource(int dsIdx);
    }
}
