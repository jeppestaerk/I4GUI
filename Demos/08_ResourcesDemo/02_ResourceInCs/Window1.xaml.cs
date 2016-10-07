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

namespace _02_ResourceInCs
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class Window1 : Window
   {
      Button btnMyButton;

      public Window1()
      {
         InitializeComponent();
         ResourceDictionary myDictionary = new ResourceDictionary();
         myDictionary.Add("myBrush", Brushes.Green);
         myDictionary.Add("HW", "Hello, world");
         this.Resources = myDictionary;

         btnMyButton = new Button();
         btnMyButton.Content = "Click Me";

         // NOT the best way to retrieve resources - NO search
         // btnMyButton.Background = (Brush) this.Resources["myBrush"];

         // The normal way to look for a resource - will search for the resource
         btnMyButton.Background = (Brush)this.FindResource("myBrush");
         this.Content = btnMyButton;   
      }
   }
}
