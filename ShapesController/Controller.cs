using System;
using System.Collections.Generic;

using AbstractShapes;
using BasicShapes;
using ShapesHandlers;
using DataSource;
using ConstDS;
using CSVDataSource;
using Shape4ViewAdapter;

namespace ShapesController
{
    public delegate void OnePercentChangedHandler();

    public class Controller
    {
        IDataSource ds;
        IDataSourceFactory dsf;
        List<IShape> shapes;
        OnePercentChangedHandler pch;

        public Controller(IDataSourceFactory ids, OnePercentChangedHandler _pch)
        {
            N_Max = 100000000;
            dsf = ids;
            pch = _pch;
        }

        public int N_Max { get; set; }

        public float TotArea { get; set; }

        public float TotPerimeter { get; set; }

        public int Count { get; set; }

        public void AddShape(string par, int ds_type_id)
        {
            ds = dsf.GetDataSource(ds_type_id);
            ds.AddShape(par);
            CalcReport(ds_type_id);
        }

        // Для отчета по БД или текстовому файлу - по переданному id
        // сам источник формируется внутри по данным по умолчанию
        public void CalcReport(int ds_type_id = 0)
        {
            // Инициализация источника данных [из фабрики]
            ds = dsf.GetDataSource(ds_type_id);
            // Логика прецедента
            CalcReport(ds);
        }

        // Для отчета по данным, переданным в виде строк извне
        // В этой версии - не используется...
        public void CalcReport(List<string> lst)
        {
            // Формирование источника данных из списка строк
            List<IShape> sl = new List<IShape>();
            IShapeFactory sf = new BasicShapesCSFactory();
            // Логика прецедента
            foreach (string s in lst)
                sl.Add(sf.CreateShapeFromString(s));
            CalcReport(sl);
        }

        // Для отчета по данным, переданным через ссылку на источник данных 
        // извне
        public void CalcReport(IDataSource _ids)  // Некрасиво !
        {
            if (_ids != null)
                CalcReport(_ids.GetShapes());
        }

        // Для отчета по данным, переданным через ссылку на источник данных 
        // извне
        public void CalcReport(List<IShape> _sl)  // Некрасиво !
        {
            if (_sl != null)
            {
                // Объект списка
                ShapesList sl = new ShapesList(_sl);

                int nShapes = _sl.Count; // ids.ShapesCount;

                // Если nShapes очень большое - выводить прогресс-бар ?...
                if (nShapes >= 1000)
                {
                    sl.PercentChangedEvent += PercentChanged;
                }

                TotArea = sl.GetTotalArea();
                TotPerimeter = sl.GetTotalPerimeter();
                Count = nShapes;

                shapes = _sl;
            }
        }

        public List<Shape4View> GetList()
        {
            // Выдать еще и список исходных фигур 
            // в виде списка строк (пока не раскрывая, каких !)
            List<Shape4View> l4view = new List<Shape4View>();
            if (shapes != null)
            {
                foreach (IShape sh in shapes)
                {
                    l4view.Add(Shape4ViewAdapter.Shape4ViewAdapter.getShape4View(sh));
                }
            }
            return l4view;
        }

        public void PercentChanged()
        {
            pch();
        }

    }
}
