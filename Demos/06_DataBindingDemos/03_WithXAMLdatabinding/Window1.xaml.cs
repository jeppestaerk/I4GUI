using System.Windows;

namespace WithXAMLdatabinding
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        
        public Window1()
        {
            InitializeComponent();
            birthdayButton.Click += birthdayButton_Click;
        }

        void birthdayButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the Person from the Application object (see App.xaml.cs)
            Person person = ((App)Application.Current).Person;

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
