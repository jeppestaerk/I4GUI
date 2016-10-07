// Window1.xaml.cs

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
using System.ComponentModel; // INotifyPropertyChanged
using System.Runtime.CompilerServices; // CallerMemberName

namespace WithoutBinding
{

    public class Person : INotifyPropertyChanged
    {
        // INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify([CallerMemberName]string propName = null)
        {
            var tempEvent = PropertyChanged;
            if (tempEvent != null)
            {
                tempEvent(this, new PropertyChangedEventArgs(propName));
            }
        }

        string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name == value) { return; }
                this.name = value;
                Notify("Name");
            }
        }

        int age;
        public int Age
        {
            get { return this.age; }
            set
            {
                if (this.age == value) { return; }
                this.age = value;
                Notify();
            }
        }

        public Person() { }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }

    public partial class Window1 : Window
    {
        Person person = new Person("Tom", 11);

        public Window1()
        {
            InitializeComponent();

            // Fill initial person fields
            this.nameTextBox.Text = person.Name;
            this.ageTextBox.Text = person.Age.ToString();

            // Watch for changes in Tom's properties
            person.PropertyChanged += PersonPropertyChanged;

            // Watch for changes in the controls
            this.nameTextBox.TextChanged += NameTextBoxTextChanged;
            this.ageTextBox.TextChanged += AgeTextBoxTextChanged;

            // Handle the birthday button click event
            this.birthdayButton.Click += BirthdayButtonClick;
        }

        void PersonPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            switch (e.PropertyName)
            {
                case "Name":
                    this.nameTextBox.Text = person.Name;
                    break;

                case "Age":
                    this.ageTextBox.Text = person.Age.ToString();
                    break;
            }
        }

        void NameTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            person.Name = nameTextBox.Text;
        }

        void AgeTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            int age = 0;
            if (int.TryParse(ageTextBox.Text, out age))
            {
                person.Age = age;
            }
        }

        void BirthdayButtonClick(object sender, RoutedEventArgs e)
        {
            ++person.Age;

            // NameTextBoxTextChanged and AgeTextBoxTextChanged
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
