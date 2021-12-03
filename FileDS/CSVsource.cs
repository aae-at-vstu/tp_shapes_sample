using System;
using System.Collections.Generic;
using System.IO;
using DataSource;
using AbstractShapes;

namespace CSVDataSource
{
    public class CSVsource : IDataSource
    {
        List<IShape> shl;
        String fname;
        IShapeFactory fct;

        public CSVsource(string _f, IShapeFactory _fct)
        {
            shl = new List<IShape>();
            fname = _f;
            fct = _fct;
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
                        IShape shape = fct.CreateShapeFromString(s);
                        if (shape != null)
                        {
                            shl.Add(shape);
                        }
                    }
                    catch { }
                }
            }
            catch { }
            return shl;
        }

        // Доделать !
        public void AddShape(string par)
        {
            try
            {
                StreamWriter wrtr = new StreamWriter(fname, true);
                wrtr.WriteLine();
                wrtr.WriteLine(par + ";0");
                wrtr.Close();

            }
            catch { }
        }
    }
}
