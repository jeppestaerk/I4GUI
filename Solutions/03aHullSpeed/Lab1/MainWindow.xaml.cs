using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab1
{
   /// <summary>
   /// Interaction logic for Window.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
       Sailboat boat;

      public MainWindow()
      {
         InitializeComponent();
         boat = new Sailboat();
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
