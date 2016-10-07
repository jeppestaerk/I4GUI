using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;
using System.Resources;
using System.IO;
using System.Globalization;
using System.Windows.Resources;


namespace AssemblyResources
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : System.Windows.Window
    {
        bool winter = false;

        public Window1()
        {
            InitializeComponent();
        }

        private void cmdPlay_Click(object sender, RoutedEventArgs e)
        {
            if (winter)
            {
                img.Source = new BitmapImage(new Uri("images/Blue hills.jpg", UriKind.Relative));
                Ding.Stop();
                Ding.Play();
            }
            else
            {
                Sound.Stop();
                Sound.Play();
                img.Source = new BitmapImage(new Uri("pack://application:,,,/images/winter.jpg"));
                
            }
            winter = !winter;
        }
    }
}