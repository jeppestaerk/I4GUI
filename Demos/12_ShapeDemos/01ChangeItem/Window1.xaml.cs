// Changing a shape at runtime.

using System.Windows;
using System.Windows.Shapes;

namespace ChangeItem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
            : base()
        {
            InitializeComponent();
            mainCanvas.MouseLeftButtonDown += OnClick;
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            Shape r = e.Source as Shape;
            //Ellipse r = e.Source as Ellipse;
            if (r != null)
            {
                r.Width += 10;
            }
        }
    }
}