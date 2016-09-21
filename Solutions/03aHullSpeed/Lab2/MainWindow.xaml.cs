using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Sailboat boat = new Sailboat();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(tbxName);
        }

        private void btnCalculateHullSpeed_Click(object sender, RoutedEventArgs e)
        {
            tbxHullSpeed.Text = boat.Hullspeed().ToString("F1");
        }

        private void tbxLength_TextChanged(object sender, TextChangedEventArgs e)
        {
            boat.Length = Double.Parse(tbxLength.Text);
        }

        private void tbxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            boat.Name = tbxName.Text;
        }
    }
}
