// Window1.cs
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
using System.ComponentModel;
using System.Diagnostics;


namespace WithBinding
{

   public partial class Window1 : Window
   {
      Person person = new Person("Tom", 11);

      public Window1()
      {
         InitializeComponent();

         // Init data binding
         Binding bindName = new Binding();
         bindName.Source = person;
         bindName.Path = new PropertyPath("Name");
         bindName.Mode = BindingMode.TwoWay;
         tbxName.SetBinding(TextBox.TextProperty, bindName);

         Binding bindAge = new Binding {Source = person, Path = new PropertyPath("Age")};
         tbxAge.SetBinding(TextBox.TextProperty, bindAge);

         // Alternative data binding using DataContext to specify the source
         //mainGrid.DataContext = person;
         //Binding bind = new Binding();
         //bind.Path = new PropertyPath("Name");
         //tbxName.SetBinding(TextBox.TextProperty, bind);
         //bind = new Binding();
         //bind.Path = new PropertyPath("Age");
         //tbxAge.SetBinding(TextBox.TextProperty, bind);

         this.birthdayButton.Click += birthdayButton_Click;
      }

      void birthdayButton_Click(object sender, RoutedEventArgs e)
      {
         ++person.Age;
         MessageBox.Show(
           string.Format(
             "Happy Birthday, {0}, age {1}!",
             person.Name,
             person.Age),
           "Birthday");
      }
   }
}

