using System;
using System.Collections.Generic;
using System.IO;
using DataSourceIF;
using Shapes;

namespace CSVDataSource
{
    public class CSVsource : IDataSource
    {
        List<IShape> shl;
        //List<String> strl;
        String fname;

        public CSVsource(string _f)
        {
            shl = new List<IShape>();
            fname = _f;
            //strl = new List<string>();
        }

        public int ShapesCount {
            get => shl.Count; set { } }

        public List<IShape> GetShapes()
        {
            shl = new List<IShape>();
            try
            {
                StreamReader rdr = new StreamReader(fname);
                String all = rdr.ReadToEnd();
                String[] arr = all.Split(new string[] { "\r\n" },
                    StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in arr)
                {
                    try
                    {
                        if (s.StartsWith("id")) continue;
                        //String[] arr1 = s.Split(';');
                        IShape shape = ShapeCreator.CreateShapeFromCSString(s);
                        if (shape != null)
                        {
                            shl.Add(shape);
                            //strl.Add(s);
                        }
                    }
                    catch { }
                }
            }
            catch { }
            return shl;
        }

        //public List<String> GetShapesStr()
        //{
        //    return strl;
        //}
    }
}
