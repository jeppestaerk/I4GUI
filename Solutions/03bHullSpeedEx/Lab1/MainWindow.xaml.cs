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
         PreviewKeyDown += new KeyEventHandler(MainWindow_PreviewKeyDown);
      }

      void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
      {
          switch  (e.Key)
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
                      if ((Keyboard.Modifiers == ModifierKeys.Control) && FontSize >= 6)
                      {
                          FontSize -= 2;
                          e.Handled = true;
                      }
                  }
                  break;
              default:
                  break;
          }
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
          if (tbxLength.Text.Trim() != "")
              try
              {
                  boat.Length = Double.Parse(tbxLength.Text);
              }
              catch
              {
                  MessageBox.Show("The length field must only contaion numbers");
              }
      }

      private void tbxName_TextChanged(object sender, TextChangedEventArgs e)
      {
          boat.Name = tbxName.Text;
      }

      private void Image_MouseDown(object sender, MouseButtonEventArgs e)
      {
          MessageBox.Show("The name of the ship is " + boat.Name);
      }
   }
}
