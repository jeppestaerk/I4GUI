using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListBoxWithDisplayMemberPath
{
    public class Student
    {
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Id { get; set; }
        public int Grade { get; set; }

        public string FullName { get { return "Id: " + Id + "   " + GivenName + " " + FamilyName; } }

        //public override string ToString()
        //{
        //    return FullName + "  " + Grade;
        //}
    }
}
