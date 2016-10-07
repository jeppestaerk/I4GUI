using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MvvmFoundation.Wpf;
using System.Runtime.CompilerServices;

namespace RelayCommandAdv
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

        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
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
                NotifyPropertyChanged();
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
                NotifyPropertyChanged();
            }
        }
    }
}
