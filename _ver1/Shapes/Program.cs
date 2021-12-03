using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Shapes;
using Presenter;
using Shape4ViewAdapter;

namespace ShapesConsoleApp
{
    public class ConsoleView : IView
    {
        public bool AskYesOrNo(string quest)
        {
            Console.WriteLine(quest);
            return Console.ReadKey().Key == ConsoleKey.Y;
        }

        public void ShowMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        //public void ShowShapeList(List<string> shapes)
        //{
        //    Console.WriteLine();
        //    foreach (string s in shapes)
        //        Console.WriteLine(s);
        //}

        public void ShowShapeList(List<Shape4View> shapes)
        {
            Console.WriteLine();
            foreach (Shape4View shape in shapes)
            {
                Console.WriteLine(shape.Name + ":" + shape.A + " " + shape.B +
                    " " + shape.C + " area = " + shape.Area + " per = " + shape.Per);
            }
        }


        public void ShowTotResults(float area, float perimeter)
        {
            Console.WriteLine("Total area = " + area.ToString());
            Console.WriteLine("Total perimeter = " + perimeter.ToString());
        }

        public void OneMorePercent() { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Presenter.Presenter p = new Presenter.Presenter(new ConsoleView());
            if (args.Length == 0)
                p.ShowReport();
            else
                p.ShowReport(Int32.Parse(args[0]));
        }
    }
}
