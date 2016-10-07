// Window1.xaml.cs
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
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel; // INotifyPropertyChanged
using System.Collections.ObjectModel; // ObserverableCollection<T>

namespace ListBinding
{
    public partial class BetterListBindingWindow : Window
    {

        public BetterListBindingWindow()
        {
            InitializeComponent();

            btnBirthday.Click += btnBirthday_Click;
            btnBack.Click += btnBack_Click;
            btnForward.Click += btnForward_Click;
            btnAdd.Click += new RoutedEventHandler(btnAdd_Click);
        }

        void btnBirthday_Click(object sender, RoutedEventArgs e)
        {
            People family = (People)this.FindResource("family");
            ICollectionView view = CollectionViewSource.GetDefaultView(family);
            Person person = (Person)view.CurrentItem;

            ++person.Age;
            MessageBox.Show(
              string.Format(
                "Happy Birthday, {0}, age {1}!",
                person.Name,
                person.Age),
              "Birthday");
        }

        void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (lbxPersons.SelectedIndex > 0)
                lbxPersons.SelectedIndex--;
        }

        void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (lbxPersons.SelectedIndex < lbxPersons.Items.Count - 1)
                lbxPersons.SelectedIndex++;
        }

        void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            People people = (People)this.FindResource("family");
            people.Add(new Person("", 0));
            lbxPersons.SelectedIndex = lbxPersons.Items.Count - 1;
            tbxName.Focus();
        }
    }

}
