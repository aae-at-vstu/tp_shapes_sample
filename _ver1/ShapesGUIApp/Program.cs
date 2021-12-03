using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presenter;

namespace ShapesGUIApp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmShapes frm = new frmShapes(); 
            frm.Pres = new Presenter.Presenter(frm);
            Application.Run(frm);
        }
    }
}
