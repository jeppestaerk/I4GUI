using System.Windows;

namespace _00_BeginnersApp
{
   public class Person
   {
      string name;
      public string Name
      {
         get { return this.name; }
         set { this.name = value; }
      }

      int age;
      public int Age
      {
         get { return this.age; }
         set { this.age = value; }
      }

      public Person() { }
      public Person(string name, int age)
      {
         this.name = name;
         this.age = age;
      }
   }

   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class Window1 : Window
   {
      Person person = new Person("Tom", 11);

      public Window1()
      {
         InitializeComponent();
         // Fill initial person fields
         this.nameTextBox.Text = person.Name;
         this.ageTextBox.Text = person.Age.ToString();

         // Handle the birthday button click event
         this.birthdayButton.Click += birthdayButton_Click;
      }

      void birthdayButton_Click(object sender, RoutedEventArgs e)
      {
         ++person.Age;
         //this.ageTextBox.Text = person.Age.ToString();

         // nameTextBox_TextChanged and ageTextBox_TextChanged
         // will make sure the Person object is up to date
         // when it's displayed in the message box
         MessageBox.Show(
           string.Format(
             "Happy Birthday, {0}, age {1}!",
             person.Name,
             person.Age),
           "Birthday");
      }
   }
}
