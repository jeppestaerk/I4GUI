using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace ResourcesExample
{
    class NaiveResources
    {
        public static void NaiveUsage()
        {
            // Example 12-1. Naïve ResourceDictionary programming

            ResourceDictionary myDictionary = new ResourceDictionary();
            myDictionary.Add("myBrush", Brushes.Green);
            myDictionary.Add("HW", "Hello, world");

            Console.WriteLine(myDictionary["myBrush"]);
            Console.WriteLine(myDictionary["HW"]);

            // End of Example 12-1.
        }
    }
}
