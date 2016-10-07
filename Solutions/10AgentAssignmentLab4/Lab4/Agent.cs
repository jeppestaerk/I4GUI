using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AgentAssignment
{
    [Serializable]
    public class Agent : INotifyPropertyChanged
    {
        string id;
        string codeName;
        string speciality;
        string assignment;

        public Agent()
        {
        }

        public Agent(string aId, string aName, string aSpeciality, string aAssignment)
        {
            id = aId;
            codeName = aName;
            speciality = aSpeciality;
            assignment = aAssignment;
        }

        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
                {
                    id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string CodeName
        {
            get
            {
                return codeName;
            }
            set
            {
                if (codeName != value)
                {
                    codeName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Speciality
        {
            get
            {
                return speciality;
            }
            set
            {
                if (speciality != value)
                {
                    speciality = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Assignment
        {
            get
            {
                return assignment;
            }
            set
            {
                if (assignment != value)
                {
                    assignment = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
