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

namespace Opgave1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Sailboat sailboat = new Sailboat();

        public MainWindow()
        {
            InitializeComponent();
            PreviewKeyDown += new KeyEventHandler(MainWindowPreviewKeyDown);
        }

        private void MainWindowPreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.L:
                {
                    if (Keyboard.Modifiers == ModifierKeys.Control)
                    {
                        FontSize += 2;
                        e.Handled = true;
                    }

                }
                    break;
                case Key.S:
                {
                    if (Keyboard.Modifiers == ModifierKeys.Control)
                    {
                        FontSize -= 2;
                        e.Handled = true;
                    }
                }
                    break;

            }
        }

        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            
            sailboat.Name = textBoxName.Text;
            sailboat.Length = double.Parse(textBoxLenght.Text);
            textResult.Text = sailboat.Hullspeed().ToString("F2");

        }

        private void ImageSailboatMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("The name of the boat is " + sailboat.Name);
        }
    }
}
