using System;
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
using System.Collections.Generic;
using System.Diagnostics;

namespace ListBinding {

  public partial class ListBinding10Window : Window {
      List<Person> family = new List<Person>();

    public ListBinding10Window() {
      InitializeComponent();
      family.Add(new Person("Tom", 11));
      family.Add(new Person("John", 12));
      family.Add(new Person("Melissa", 38));
      lbxPersons.ItemsSource = family;
      this.birthdayButton.Click += birthdayButton_Click;
    }

    void birthdayButton_Click(object sender, RoutedEventArgs e) 
    {
        Person person = lbxPersons.SelectedValue as Person;
      ++person.Age;
      MessageBox.Show(
        string.Format(
          "Happy Birthday, {0}, age {1}!",
          person.Name,
          person.Age),
        "Birthday");
    }

    private void btnNew_Click(object sender, RoutedEventArgs e)
    {
        family.Add(new Person("No Name", 0));
        lbxPersons.Items.Refresh();
        lbxPersons.SelectedIndex = lbxPersons.Items.Count - 1;
    }

    private void btnBack_Click(object sender, RoutedEventArgs e)
    {
        if (lbxPersons.SelectedIndex > 0)
            lbxPersons.SelectedIndex--;
    }

    private void btnForward_Click(object sender, RoutedEventArgs e)
    {
        if (lbxPersons.SelectedIndex < lbxPersons.Items.Count - 1)
            lbxPersons.SelectedIndex++;
    }

    private void TextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        lbxPersons.Items.Refresh();
    }
  }
}
