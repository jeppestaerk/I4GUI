 using System;
using System.Windows;
using System.Windows.Documents;

namespace Lab3_3
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class Window1 : Window
   {
      public Window1()
      {
         InitializeComponent();
         btnShowEnvironment.Click += new RoutedEventHandler(btnShowEnvironment_Click);
      }

      void btnShowEnvironment_Click(object sender, RoutedEventArgs e)
      {
         tbkEnv.Inlines.Add("Folder for personel documents: " +
            Environment.GetFolderPath(Environment.SpecialFolder.Personal));
         tbkEnv.Inlines.Add("\nFolder for application specific user settings: " +
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
         tbkEnv.Inlines.Add("\nSystem folder: " + Environment.GetFolderPath(Environment.SpecialFolder.System));
         tbkEnv.Inlines.Add("\n\nCurrent directory: " + Environment.CurrentDirectory);

         // GetLogicalDrives returns an array of strings
         string str = "\nLogical drives: ";
         string[] drives = Environment.GetLogicalDrives();
         foreach (string s in drives)
            str += s.Substring(0, 2) + " ";
         tbkEnv.Inlines.Add(str);

         tbkEnv.Inlines.Add("\n\nMachine name: " + Environment.MachineName);
         tbkEnv.Inlines.Add("\nUser name: " + Environment.UserName);
         tbkEnv.Inlines.Add(new Bold(new Run("\n\nStackTrace:\n")));
         tbkEnv.Inlines.Add(Environment.StackTrace);
      }
   }
}
