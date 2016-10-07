using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmFoundation.Wpf;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RelayCommandAdv
{
    public class People : ObservableCollection<Person>, INotifyPropertyChanged
    {
        public People()
        {
            Add(new Person("Tom", 11));
            Add(new Person("John", 12));
            Add(new Person("Melissa", 38));
        }

        #region Commands

        ICommand _addCommand;
        public ICommand AddCommand
        {
            get { return _addCommand ?? (_addCommand = new RelayCommand(AddPerson)); }
        }

        private void AddPerson()
        {
            Add(new Person());
            CurrentIndex = Count - 1;
        }

        ICommand _nextCommand;
        public ICommand NextCommand
        {
            get
            {
                return _nextCommand ?? (_nextCommand = new RelayCommand(
                    () => ++CurrentIndex,
                    () => CurrentIndex < (Count - 1)));
            }
        }

        ICommand _PreviusCommand;
        public ICommand PreviusCommand
        {
            get { return _PreviusCommand ?? (_PreviusCommand = new RelayCommand(PreviusCommandExecute, PreviusCommandCanExecute)); }
        }

        private void PreviusCommandExecute()
        {
            if (CurrentIndex > 0)
                --CurrentIndex;
        }

        private bool PreviusCommandCanExecute()
        {
            if (CurrentIndex > 0)
                return true;
            else
                return false;
        }

        #endregion // Commands

        #region Properties

        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                if (currentIndex != value)
                {
                    currentIndex = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public new event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Fields

        int currentIndex = -1;

        #endregion // Fields
    }
}
