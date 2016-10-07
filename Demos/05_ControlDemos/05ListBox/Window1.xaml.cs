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
using System.Collections.ObjectModel;

namespace ListBox
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class Window1 : Window
   {
       IList<string> myCollection;
       int count = 3;
       
      public Window1()
      {
         InitializeComponent();
         myCollection = new List<string>();
         //myCollection = new ObservableCollection<string>();
         myCollection.Add("item 1");
         myCollection.Add("item 2");
         myCollection.Add("item 3");
         listBox1.ItemsSource = myCollection;
      }

      private void button1_Click(object sender, RoutedEventArgs e)
      {
          count++;
          myCollection.Add("New item " + count);
          //listBox1.Items.Refresh(); // Only needed if you don't use an ObservableCollection!
      }

      private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
          string str = (string)listBox1.SelectedItem;
          MessageBox.Show(str, "You selected:");
      }
   }
}
