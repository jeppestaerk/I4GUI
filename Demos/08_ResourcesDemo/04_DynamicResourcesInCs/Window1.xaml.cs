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

namespace _04_DynamicResourcesInCs
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class Window1 : Window
   {
      Button btn;
      Random rnd;

      public Window1()
      {
         InitializeComponent();
         ResourceDictionary myDictionary = new ResourceDictionary();
         myDictionary.Add("myBrush", new SolidColorBrush(Colors.Green));
         this.Resources = myDictionary;
         this.SetResourceReference(Control.BackgroundProperty, "myBrush");
         
         rnd = new Random(DateTime.Now.Millisecond);
         btn = new Button();
         btn.Content = "Click Me";
         btn.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
         btn.VerticalAlignment = System.Windows.VerticalAlignment.Center;
         mainGrid.Children.Add(btn);
         btn.Click += new RoutedEventHandler(btn_Click);
      }

      void btn_Click(object sender, RoutedEventArgs e)
      {
         Color color = Color.FromRgb((byte)rnd.Next(255), (byte)rnd.Next(255), (byte)rnd.Next(255));
         Brush brush = new SolidColorBrush(color);
         this.Resources["myBrush"] = brush;
      }
   }
}
