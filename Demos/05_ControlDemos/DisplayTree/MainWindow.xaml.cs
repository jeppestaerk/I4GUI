using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DisplayTree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button b = new Button();
            b.Content = "Hello World";
            b.Width = 100.0;
            b.Height = 35;
            b.Margin = new Thickness(10.0, 10.0, 0.0, 0.0);
            b.VerticalAlignment = VerticalAlignment.Top;
            b.HorizontalAlignment = HorizontalAlignment.Left;

            ListBox l = new ListBox();
            l.Items.Add("Hello");
            l.Items.Add("There");
            l.Items.Add("World");
            l.Margin= new Thickness( 10.0, 100.0,0.0, 0.0);
            l.VerticalAlignment = VerticalAlignment.Top;
            l.HorizontalAlignment = HorizontalAlignment.Left;
            mainGrid.Children.Add(b);
            mainGrid.Children.Add(l);


        }
    }
}
