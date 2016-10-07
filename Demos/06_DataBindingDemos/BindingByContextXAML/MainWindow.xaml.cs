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

namespace BindingByContextXAML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void birthdayButton_Click(object sender, RoutedEventArgs e)
        {
            ++person.Age;
            MessageBox.Show(
              string.Format(
                "Happy Birthday, {0}, age {1}!",
                person.Name,
                person.Age),
              "Birthday");
        }
    }
}
