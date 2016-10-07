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

namespace ListBoxWithDataTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Student> myStudents = new ObservableCollection<Student>();
        ObservableCollection<Teacher> myTeachers = new ObservableCollection<Teacher>();

        public MainWindow()
        {
            InitializeComponent();
            myStudents.Add(new Student { GivenName = "Hans", FamilyName = "Hansen", Id = "12345", Grade = 12 });
            lbxStudents.ItemsSource = myStudents;
            myStudents.Add(new Student{GivenName="Benny", FamilyName="Buksevand", Id="67890", Grade=12});

            cbxTeachers.ItemsSource = myTeachers;
            myTeachers.Add(new Teacher { GivenName = "Ole", FamilyName = "Olsen", Id = "01010" });
            myTeachers.Add(new Teacher { GivenName = "Anne", FamilyName = "Andersen", Id = "10101" });
        }

        private void lbxStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Student st = lbxStudents.SelectedValue as Student;
            MessageBox.Show("Name: " + st.GivenName + " " + st.FamilyName, "You selected");
        }

        private void cbxTeachers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Teacher tc = cbxTeachers.SelectedItem as Teacher;
            MessageBox.Show("Name: " + tc.GivenName + " " + tc.FamilyName, "You selected");
        }
    }
}
