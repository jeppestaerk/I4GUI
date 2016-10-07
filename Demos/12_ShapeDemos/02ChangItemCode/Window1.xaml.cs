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

namespace _02ChangItemCode
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class Window1 : Window
   {
      public Window1()
      {
         InitializeComponent();
         // <Canvas x:Name="mainCanvas">
         Canvas mainCanvas = new Canvas();
         this.Content = mainCanvas;

         // <Ellipse Canvas.Left="10" Canvas.Top="30" Fill="Indigo" Width="40" Height="20" />
         Ellipse elp1 = new Ellipse();
         mainCanvas.Children.Add(elp1);
         Canvas.SetLeft(elp1, 10.0d);
         Canvas.SetTop(elp1, 30.0d);
         elp1.Fill = Brushes.Indigo;
         elp1.Width = 40;
         elp1.Height = 20;
         elp1.Stroke = Brushes.Pink;
         elp1.StrokeThickness = 4;

         // Be smart
         Brush[] brushes = { Brushes.Indigo, Brushes.Blue, Brushes.Cyan, Brushes.LightGreen, Brushes.Yellow};

         for (int i = 1; i < 5; ++i)
         {
            elp1 = new Ellipse();
            mainCanvas.Children.Add(elp1);
            Canvas.SetLeft(elp1, 10.0d + i * 10.0d);
            Canvas.SetTop(elp1, 30.0d + i * 10.0d);
            elp1.Fill = brushes[i];
            elp1.Width = 40;
            elp1.Height = 20;
         }

         mainCanvas.MouseLeftButtonDown += OnClick;
      }

      private void OnClick(object sender, RoutedEventArgs e)
      {
         Ellipse r = e.Source as Ellipse;
         if (r != null)
         {
            r.Width += 10;
         }
      }
   }
}
