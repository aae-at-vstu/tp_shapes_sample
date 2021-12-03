using System;
using Shapes;

namespace Shape4ViewAdapter
{
    public class Shape4View
    {
        public String Name { get; set; }
        public String A { get; set; }
        public String B { get; set; }
        public String C { get; set; }
        public String Area { get; set; }
        public String Per { get; set; }
    }

    public class Shape4ViewAdapter
    {
        public static Shape4View getShape4View(IShape shp)
        {
            Shape4View s4v = new Shape4View();
            s4v.Area = shp.getArea().ToString();
            s4v.Per = shp.getPerimeter().ToString();
            s4v.Name = shp.Name;
            s4v.A = ""; s4v.B = ""; s4v.C = "";
            try
            {
                AShape ashp = (AShape)shp;
                s4v.A = ashp.A.ToString();
                s4v.B = ashp.B.ToString();
                if (ashp.Name == "rect_tri")  // Совсем некрасиво...
                    s4v.C = ((RectThreeAngle)ashp).C.ToString();
            }
            catch { }
            return s4v;
        }
    }
}
