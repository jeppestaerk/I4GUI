using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindingByContext
{
   public class Person : INotifyPropertyChanged
   {
      // INotifyPropertyChanged Members
      public event PropertyChangedEventHandler PropertyChanged;
      protected void Notify([CallerMemberName]string propName = null)
      {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
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

      public Person() { }
      public Person(string name, int age)
      {
         this.name = name;
         this.age = age;
      }
   }
}
