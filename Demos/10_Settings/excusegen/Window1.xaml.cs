using System;
using System.Windows;
using System.Configuration;

namespace excusegen {
  public partial class Window1 : Window {
    string[] excuses = {
    "Jury Duty",
    "Abducted by Aliens",
    "Car Trouble",
    "Traffic Was Bad",
    "Spicy Food",
    "Full Moon",
    "Huh?",
    "Amnesia",
    "No Hablo Ingleses",
    "I've Got a Headache",
    "24-Hour Flu",
    "What Memo?",
    "It's In the Mail",
    "My Fish Died",
    "I Was Mugged",
    "The Voices Told Me To",
    "My Dog Ate It",
    "Kryptonite",
    "It's Not My Job",
  };

    public Window1() {
      InitializeComponent();
      this.newExcuseButton.Click += newExcuseButton_Click;

      // If there is no "last excuse," show a random excuse
      if( string.IsNullOrEmpty(Properties.Settings.Default.LastExcuse) ) {
        ShowNextExcuse();
      }
      // Show the excuse from the last session
      // NOTE: let the binding do this
      //else {
      //  excuseTextBlock.Text = Properties.Settings.Default.LastExcuse;
      //}
    }

    void newExcuseButton_Click(object sender, RoutedEventArgs e) {
      ShowNextExcuse();
    }

    Random rnd = new Random();
    void ShowNextExcuse() {
      // Pick a random excuse, saving it for the next session
      // and checking for animals
      do {
        Properties.Settings.Default.LastExcuse =
          excuses[rnd.Next(excuses.Length - 1)];
      }
      while( Properties.Settings.Default.ExcludeAnimalExcuses &&
              HasAnimal(Properties.Settings.Default.LastExcuse) );

      // Show the current excuse
      // NOTE: let the binding do this
      excuseTextBlock.Text = Properties.Settings.Default.LastExcuse;
    }

    bool HasAnimal(string excuse) {
      return excuse.Contains("Dog") || excuse.Contains("Fish");
    }

    protected override void OnClosed(EventArgs e) {
      base.OnClosed(e);

      // Save user settings between sessions
      Properties.Settings.Default.Save();
    }

    private void btnFolder_Click(object sender, RoutedEventArgs e)
    {
		// Must add reference to System.Configuration
        Configuration config = ConfigurationManager.OpenExeConfiguration(
                               ConfigurationUserLevel.PerUserRoamingAndLocal);
        MessageBox.Show(config.FilePath, "Local user config path:");
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string path2 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    }



  }
}
