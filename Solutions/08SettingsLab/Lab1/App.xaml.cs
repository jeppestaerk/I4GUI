using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Lab1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Lab1.Properties.Settings.Default.Save();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (Lab1.Properties.Settings.Default.CallUpgrade)
            {
                Lab1.Properties.Settings.Default.Upgrade();
                Lab1.Properties.Settings.Default.CallUpgrade = false;
            }
        }
    }
}
