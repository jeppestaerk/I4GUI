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


namespace ButtonClick
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : System.Windows.Window
    {

        public Window1()
        {
            InitializeComponent();
            btnStart.Click += new RoutedEventHandler(btnStart_Click2);
        }


        void ButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button was clicked");
        }

        private void btnLuncMissile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnStart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Hej");
        }

        private void btnStart_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Got Click");
        }

        private void btnStart_Click2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Got the same Click");
        }
    }
}