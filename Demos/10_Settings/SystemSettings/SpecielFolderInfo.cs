using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemSettings
{
    public class SpecielFolderInfo
    {
        public SpecielFolderInfo(string name, string path)
        {
            FolderName = name;
            Path = path;
        }

        public string FolderName { get; set; }
        public string Path { get; set; }
    }
}
