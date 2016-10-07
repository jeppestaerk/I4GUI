using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ListBinding
{
    public class People : ObservableCollection<Person>
    {
        public People()
        {
            Add(new Person("Tom", 11));
            Add(new Person("John", 12));
            Add(new Person("Melissa", 38));
        }
    }

}
