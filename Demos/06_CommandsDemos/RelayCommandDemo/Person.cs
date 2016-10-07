using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MvvmFoundation.Wpf;

namespace RelayCommandDemo
{
    public class Person : INotifyPropertyChanged
    {
        public Person()
        {
            BirthdayCommand = new RelayCommand(BirthdayCommandHandler);
        }

        public Person(string name, int age) : this()
        {
            this.name = name;
            this.age = age;
        }

        public ICommand BirthdayCommand { get; private set; }

        void BirthdayCommandHandler()
        {
            ++Age;
            MessageBox.Show(
              string.Format(
                "Happy Birthday, {0}, age {1}!",
                Name,
                Age),
              "Birthday");
        }


        // INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Notify(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
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
                Notify("Age");
            }
        }
    }
}
