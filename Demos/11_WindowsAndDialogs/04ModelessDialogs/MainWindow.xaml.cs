using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CustomDialogSample {
  public partial class MainWindow : System.Windows.Window {
     SettingsDialog dlg = null;

    public MainWindow() {
      InitializeComponent();

      settingsButton.Click += new RoutedEventHandler(SettingsButton_Click);
      Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing);
    }

    void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
      Properties.Settings.Default.Save();
    }

    void SettingsButton_Click(object sender, RoutedEventArgs e) {
      // Initialize the dialog
        if (dlg != null)
            dlg.Focus();
        else
       {
          dlg = new SettingsDialog();
          dlg.Owner = this;
          dlg.Reporter = Properties.Settings.Default.Reporter;
          dlg.ReportColor = Properties.Settings.Default.ReportColor;
          dlg.ReportFolder = Properties.Settings.Default.ReportFolder;

          // Listen for the Apply button and show the dialog modelessly
          dlg.Apply += new EventHandler(Dlg_Apply);
          dlg.Closed += new EventHandler(Dlg_Closed);
          dlg.Show();
       }
    }

    void Dlg_Closed(object sender, EventArgs e)
    {
       dlg = null;
       Focus();
    }

    void Dlg_Apply(object sender, EventArgs e) {
      // Pull the dialog out of the event args and apply the new settings
      SettingsDialog dlg = (SettingsDialog)sender;

      Properties.Settings.Default.Reporter = dlg.Reporter;
      Properties.Settings.Default.ReportColor = dlg.ReportColor;
      Properties.Settings.Default.ReportFolder = dlg.ReportFolder;
    }

  }
}