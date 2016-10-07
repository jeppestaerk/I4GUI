// Project 12_BestListBinding
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BestListBinding
{
    public class Person : INotifyPropertyChanged
    {
        string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name == value) { return; }
                this.name = value;
                Notify();
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

        // INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
