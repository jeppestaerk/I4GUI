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

namespace Demo1
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class Window1 : Window
   {
      public Window1()
      {
         InitializeComponent();

         // Add a listbox
         ListBox lb = new ListBox();
         lb.Width = 100;
         lb.Items.Add("Hello");
         lb.Items.Add("There");
         lb.Items.Add("World");
         Ellipse elp = new Ellipse();
         elp.Fill = Brushes.Blue;
         elp.Width = 80;
         elp.Height = 20;
         lb.Items.Add(elp);
         Grid.SetRow(lb, 0);
         myGrid.Children.Add(lb);

         // Add a simple button
         Button sb = new Button();
         sb.Content = "Click Me";
         sb.Click += sb_Click;
         sb.HorizontalAlignment = HorizontalAlignment.Center;
         sb.Margin = new Thickness(5.0);
         Grid.SetRow(sb, 1);
         myGrid.Children.Add(sb);

         // Add a rich content button
         Button b = new Button();
         StackPanel sp = new StackPanel();
         sp.Orientation = Orientation.Horizontal;
         Ellipse left = new Ellipse();
         left.Fill = Brushes.Blue;
         left.Width = 20;
         left.Height = 20;
         TextBlock text = new TextBlock();
         text.Inlines.Add(new Run("Hello "));
         text.Inlines.Add(new Bold(new Run("World")));
         Ellipse right = new Ellipse();
         right.Fill = Brushes.Red;
         right.Width = 20;
         right.Height = 20;
         sp.Children.Add(left);
         sp.Children.Add(text);
         sp.Children.Add(right);
         b.Content = sp;
         b.HorizontalAlignment = HorizontalAlignment.Center;
         b.Margin = new Thickness(5.0);
         Grid.SetRow(b, 2);
         myGrid.Children.Add(b);
      }

      void sb_Click(object sender, RoutedEventArgs e)
      {
          MessageBox.Show("You clicked me...");
      }

   }
}
