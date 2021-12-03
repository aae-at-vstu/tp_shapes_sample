using System;
using System.Collections.Generic;
using Shapes;
using DataSourceIF;
using ConstDS;
using CSVDataSource;
using Shape4ViewAdapter;

namespace Presenter
{
    public interface IView
    {
        void ShowMessage(string msg);
        bool AskYesOrNo(string quest);
        void ShowTotResults(float area, float perimeter);
        void ShowShapeList(List<Shape4View> shapes);
        void OneMorePercent();
        //void ShowShapeList(List<IShape> shapes);
    }

    public class Presenter
    {
        IView view;
        IDataSource ids;

        public Presenter(IView iv)
        {
            view = iv;
            N_Max = 1000000;
            //ids = _ids;
        }

        public int N_Max { get; set; }

        // Для отчета по БД или текстовому файлу - по переданному id
        // сам источник формируется внутри по данным по умолчанию
        public void ShowReport(int ds_type_id = 0)  // Некрасиво !
        {
            // Инициализация источника данных [из фабрики]
            // Логика прецедента 
            if (ds_type_id == 1)
                ShowReport(new CSVsource("shapes.csv"));
                //ShowReport(new ConstantListDS(6));
            else if (ds_type_id == 2)
                ShowReport(new ConstantListDS(N_Max));  
            else
                ShowReport(new ConstantListDS(3)); // Магическая константа !
        }

        // Для отчета по данным, переданным в виде строк извне
        public void ShowReport(List<string> lst)  // Некрасиво !
        {
            // Формирование источника данных из списка строк
            List<IShape> sl = new List<IShape>();
            // Логика прецедента
            foreach (string s in lst)
                sl.Add(ShapeCreator.CreateShapeFromCSString(s));

            ShowReport(sl);
        }

        // Обработчик события
        public void PercentChanged()
        {
            view.OneMorePercent();
        }

        // Для отчета по данным, переданным через ссылку на источник данных 
        // извне
        public void ShowReport(IDataSource _ids)  // Некрасиво !
        {
            ShowReport(_ids.GetShapes());
        }

        // Для отчета по данным, переданным через ссылку на источник данных 
        // извне
        public void ShowReport(List<IShape> _sl)  // Некрасиво !
        {
            // Логика прецедента
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

                // Основные результаты
                float totArea = sl.GetTotalArea();
                float totPerimeter = sl.GetTotalPerimeter();

                view.ShowTotResults(totArea, totPerimeter);

                // Магическая константа
                bool lShowDetails = nShapes <= 5;
                if (!lShowDetails && (nShapes <= 100))
                {
                    lShowDetails = view.AskYesOrNo("Количество фигур = " + nShapes.ToString() +
                        " Выводить их ?");
                }
                if (nShapes > 100)
                {
                    view.ShowMessage("Слишком много фигур для отображения !");
                }
                if (lShowDetails)
                {
                    // Выдать еще и список исходных фигур 
                    // в виде списка строк (пока не раскрывая, каких !)
                    //view.ShowShapeList(ids.GetShapesStr());
                    //view.ShowShapeList(sl.GetStrList());
                    //view.ShowShapeList(ids.GetShapes());

                    List<Shape4View> l4view = new List<Shape4View>();
                    foreach (IShape sh in _sl/*ids.GetShapes()*/)
                    {
                        l4view.Add(Shape4ViewAdapter.Shape4ViewAdapter.getShape4View(sh));
                    }
                    view.ShowShapeList(l4view);
                }
            }
            else
            {
                view.ShowMessage("Нет данных для обработки !");
            }
        }
    }
}
