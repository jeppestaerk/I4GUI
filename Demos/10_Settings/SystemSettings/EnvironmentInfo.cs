using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemSettings
{
    public class EnvironmentInfo
    {
        public EnvironmentInfo(string name, string value)
        {
            PropertyName = name;
            Value = value;
        }

        public string PropertyName { get; set; }
        public string Value { get; set; }
    }
}
