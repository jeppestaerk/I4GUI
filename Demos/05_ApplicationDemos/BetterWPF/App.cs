using System;
using System.Windows;

namespace BetterWPF
{
    /// <summary>
    /// The application class contains the message pump 
    /// </summary>
    public class App : Application
    {
        [STAThread]
        static void Main(string[] args)
        {
            App app = new App();
            app.Startup += app.AppStartingUp;
            app.Run();
        }

        void AppStartingUp(object sender, StartupEventArgs e)
        {
            // Let the Window initialize itself
            Window window = new MainWindow();
            window.Show();
        }
    }
}
