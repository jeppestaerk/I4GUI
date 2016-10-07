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

namespace SystemSettings
{
    /// <summary>
    /// Interaction logic for EnvironmentWindow.xaml
    /// </summary>
    public partial class EnvironmentWindow : Window
    {
        public EnvironmentWindow()
        {
            InitializeComponent();
            EnvironmentInfo info = new EnvironmentInfo("CommandLine", Environment.CommandLine);
            environmentListBox.Items.Add(info);
            info = new EnvironmentInfo("CurrentDirectory", Environment.CurrentDirectory);
            environmentListBox.Items.Add(info);
            info = new EnvironmentInfo("ExitCode", Environment.ExitCode.ToString());
            environmentListBox.Items.Add(info);
            info = new EnvironmentInfo("HasShutdownStarted", Environment.HasShutdownStarted.ToString());
            environmentListBox.Items.Add(info);
            info = new EnvironmentInfo("Is64BitOperatingSystem", Environment.Is64BitOperatingSystem.ToString());
            environmentListBox.Items.Add(info);
            info = new EnvironmentInfo("Is64BitProcess", Environment.Is64BitProcess.ToString());
            environmentListBox.Items.Add(info);
            info = new EnvironmentInfo("MachineName", Environment.MachineName);
            environmentListBox.Items.Add(info);
            string nl = Environment.NewLine;
            string nlHex = "0x";
            foreach (char ch in nl)
            {
                int c = (int)ch;
                nlHex += string.Format("{0:X}", c);
            }
            info = new EnvironmentInfo("NewLine", nlHex);
            environmentListBox.Items.Add(info);
            info = new EnvironmentInfo("OSVersion", Environment.OSVersion.ToString());
            environmentListBox.Items.Add(info);
            info = new EnvironmentInfo("ProcessorCount", Environment.ProcessorCount.ToString());
            environmentListBox.Items.Add(info);
            info = new EnvironmentInfo("SystemDirectory", Environment.SystemDirectory.ToString());
            environmentListBox.Items.Add(info);
            info = new EnvironmentInfo("SystemPageSize", Environment.SystemPageSize.ToString() + " bytes");
            environmentListBox.Items.Add(info);
            info = new EnvironmentInfo("TickCount", Environment.TickCount.ToString() + " Ticks");
            environmentListBox.Items.Add(info);
            info = new EnvironmentInfo("UserDomainName", Environment.UserDomainName);
            environmentListBox.Items.Add(info);
            info = new EnvironmentInfo("UserInteractive", Environment.UserInteractive.ToString());
            environmentListBox.Items.Add(info);
            info = new EnvironmentInfo("UserName", Environment.UserName);
            environmentListBox.Items.Add(info);
            info = new EnvironmentInfo("Version", Environment.Version.ToString());
            environmentListBox.Items.Add(info);
            info = new EnvironmentInfo("WorkingSet", Environment.WorkingSet.ToString() + " bytes");
            environmentListBox.Items.Add(info);
        }
    }
}
