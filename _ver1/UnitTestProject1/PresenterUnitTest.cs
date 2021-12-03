using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presenter;
using DataSourceIF;
using Shapes;
using Shape4ViewAdapter;

namespace PresenterTests
{
    class MockView : IView
    {
        public String Log { get; set; }
        public bool Yes { get; set; }
        public List<String> Shapes { get; set; }

        public MockView()
        {
            Log = "";
            Yes = true;
            Shapes = new List<string>();
        }

        public bool AskYesOrNo(string quest)
        {
            Log += "AskYesNo(" + quest + ");";
            return Yes;
        }

        public void ShowMessage(string msg)
        {
            Log += "ShowMessage(" + msg + ");";
        }

        //public void ShowShapeList(List<string> shapes)
        //{
        //    int cnt = shapes == null ? 0 : shapes.Count;
        //    Log += "ShowShapeList() - " + cnt + " items;";
        //    Shapes = shapes;
        //}

        public void ShowShapeList(List<Shape4View> shapes)
        {
            int cnt = shapes == null ? 0 : shapes.Count;
            Log += "ShowShapeList() - " + cnt + " items;";
            //Shapes = ;
            foreach(Shape4View shape in shapes)
            {
                Shapes.Add(shape.Name + ":" + shape.A + " " + shape.B +
                    " " + shape.C + " area = " + shape.Area + " per = " + shape.Per);
            }
        }

        public void ShowTotResults(float area, float perimeter)
        {
            Log += "ShowTotResults(" + area + "," + perimeter + ");";
        }

        public void OneMorePercent() { }
    }

    class MockDataSource : IDataSource
    {
        List<IShape> shapes;

        public MockDataSource(List<IShape> shl)
        {
            shapes = shl;
        }

        public int ShapesCount
        {
            get { return shapes.Count; } set { }
        }

        public List<IShape> GetShapes()
        {
            return shapes;
        }

        public List<String> GetShapesStr()
        {
            return new List<string>();  // ?!
        }

    }

    [TestClass]
    public class PresenterUnitTest
    {
        [TestMethod]
        public void TestPresenter()
        {
            List<IShape> shl = new List<IShape>();
            shl.Add(new Square(1, 1));
            shl.Add(new Square(2, 2));

            MockDataSource ds = new MockDataSource(shl);
            MockView mv = new MockView();
            Presenter.Presenter pres = new Presenter.Presenter(mv);
            pres.ShowReport(ds);
            Assert.AreEqual("ShowTotResults(" + (5.0).ToString() + "," + 
                      (12.0).ToString() + ");ShowShapeList() - 0 items;", mv.Log);
        }
    }
}
