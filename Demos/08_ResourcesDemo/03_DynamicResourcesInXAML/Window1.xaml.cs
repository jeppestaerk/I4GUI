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

namespace _03_DynamicResourcesInXAML
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class Window1 : Window
   {
      Random rnd;

      public Window1()
      {
         InitializeComponent();
         rnd = new Random(DateTime.Now.Millisecond);
      }

      private void Button_Click(object sender, RoutedEventArgs e)
      {
         Color color = Color.FromRgb((byte)rnd.Next(255), (byte)rnd.Next(255), (byte)rnd.Next(255));
         Brush brush = new SolidColorBrush(color);
         this.Resources["myBrush"] = brush;
      }
   }
}
