using System;
using System.Collections.ObjectModel;

namespace Opgave1
{
    public class Agents : ObservableCollection<Agent>
    {
        public Agents()
        {
            Add(new Agent("009", "Jeppe Stærk", "Aarhus, DK", "Hacking", "EchoDelta"));
            Add(new Agent("008", "John Doe", "Aarhus, DK", "Eating", "EchoAlfa"));
        }
    }


    [Serializable]
    public class Agent
    {
        string id;
        string codeName;
        string speciality;
        string assignment;

        public Agent()
        {
        }

        public Agent(string aId, string aName, string aAddress, string aSpeciality, string aAssignment)
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
                id = value;
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
                codeName = value;
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
                speciality = value;
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
                assignment = value;
            }
        }
    }
}
