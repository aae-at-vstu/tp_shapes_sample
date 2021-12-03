using System;
using System.Collections.Generic;
using System.Text;

using DataSource;
using ConstDS;
using DbLibEF;
using CSVDataSource;
using BasicShapes;

namespace ShapesController
{
    public class DSFactory : IDataSourceFactory
    {
        public IDataSource GetDataSource(int dsIdx)
        {
            if (dsIdx == 0)
                return new ShapesDbContext();
            else if (dsIdx == 2)
                return new ConstantListDS(10000000);
            else if (dsIdx == 3)
                return new CSVsource("shapes.csv", new BasicShapesCSFactory());
            else if (dsIdx == 4)
                return new ConstantListDS();
            else
                return null;
        }
    }
}
