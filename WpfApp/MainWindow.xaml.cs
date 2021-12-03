using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ShapesController;
using Shape4ViewAdapter;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller c;

        public MainWindow()
        {
            InitializeComponent();
            c = new Controller(new DSFactory(), OneMorePercent);
        }

        private int DataSourceIndex
        {
            get
            {
                return (bool)rb1.IsChecked ? 0 : (bool)rb2.IsChecked ? 1 :
                (bool)rb3.IsChecked ? 2 : (bool)rb4.IsChecked ? 3 :
                (bool)rb5.IsChecked ? 4 : -1;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowResults();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                c.AddShape(cmbShape.SelectedIndex.ToString() + ";"
                    + txtA.Text + ";" + txtB.Text, DataSourceIndex);
                ShowResults();
            }
            catch { }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowResults();
        }

        public void ShowResults()
        {
            c.CalcReport(DataSourceIndex);
            totSquare.Content = c.TotArea.ToString();
            totPerimeter.Content = c.TotPerimeter.ToString();
            bool lShow = (c.Count <= 10) && !(c.Count > 100);
            if (c.Count > 10 && c.Count <= 100)
                lShow = MessageBox.Show("В списке " + c.Count.ToString() + 
                    " фигур. Выводить ?","Список фигур", 
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes;
            if (c.Count > 100)
                MessageBox.Show("Слишком много фигур для отображения !");
            else if (lShow)
                ShowShapeList(c.GetList());
        }

        public void ShowShapeList(List<Shape4View> shapes)
        {
            dg.ItemsSource = shapes;
            pb.Value = 0;
            pb.InvalidateVisual();
        }

        public void OneMorePercent()
        {
            pb.Value += 1;
            pb.InvalidateVisual();
            Action emptyDelegate = delegate { };
            Dispatcher.Invoke(emptyDelegate, DispatcherPriority.Render);
        }
    }
}
