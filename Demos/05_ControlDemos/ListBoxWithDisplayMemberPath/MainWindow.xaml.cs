using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListBoxWithDisplayMemberPath
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Student> myStudents = new ObservableCollection<Student>();
            
        public MainWindow()
        {
            InitializeComponent();

            myStudents.Add(new Student { GivenName = "Hans", FamilyName = "Hansen", Id = "12345", Grade = 12 });
            myStudents.Add(new Student { GivenName = "Benny", FamilyName = "Buksevand", Id = "67890", Grade = 12 });
            myStudents.Add(new Student { GivenName = "Jens", FamilyName = "Jensen", Id = "67890", Grade = 12 });
            myStudents.Add(new Student { GivenName = "Søren", FamilyName = "Sørensen", Id = "67890", Grade = 12 });
            lbxStudents.ItemsSource = myStudents;
            
        }

        private void lbxStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Student st = lbxStudents.SelectedValue as Student;
            MessageBox.Show("Name: " + st.GivenName + " " + st.FamilyName, "You selected");
        }
    }
}
