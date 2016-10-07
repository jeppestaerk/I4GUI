using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;

namespace SystemSettings
{
    /// <summary>
    /// Interaction logic for SystemInformationWindow.xaml
    /// </summary>
    public partial class SystemInformationWindow : Window
    {
        public SystemInformationWindow()
        {
            InitializeComponent();
            Type t = typeof(System.Windows.Forms.SystemInformation);
            PropertyInfo[] pi = t.GetProperties();

            foreach (var p in pi)
            {
                EnvironmentInfo i = new EnvironmentInfo(p.Name, p.GetValue(null, null).ToString());
                systemInfoListBox.Items.Add(i);
            }
        }
    }
}
