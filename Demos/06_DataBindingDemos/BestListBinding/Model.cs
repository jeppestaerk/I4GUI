using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace BestListBinding
{
    public class Model : INotifyPropertyChanged
    {
        public Model()
        {
            family.Add(new Person("Tom", 11));
            family.Add(new Person("John", 12));
            family.Add(new Person("Melissa", 38));
            SelectedPerson = family[SelectedIndex];
        }

        ObservableCollection<Person> family = new ObservableCollection<Person>();
        public ObservableCollection<Person> Family
        {
            get { return family; }
        }

        int selectedIndex = 0;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (selectedIndex != value)
                {
                    selectedIndex = value;
                    Notify();
                }
            }
        }

        Person selectedPerson;

        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                if (selectedPerson != value)
                {
                    selectedPerson = value;
                    Notify();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Notify([CallerMemberName] string propName = null)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
