//TooSimpleWPF
using System;
using System.Windows;
using System.Windows.Controls;

namespace TooSimpleWPF
{
    class MyApp : Application
    {
        [STAThread]
        static void Main(string[] args)
        {
            MyApp app = new MyApp();
            Window window = new Window();
            window.FontSize = 40;
            TextBlock tbl = new TextBlock();
            tbl.Text = "Hello WPF world";
            tbl.Margin = new Thickness(20);
            window.Content = tbl;
            window.Show();
            app.Run();
        }
    }
}
