using System;
using System.Windows;
using System.Windows.Controls;

namespace BetterWPF
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            Title="Better WPF";
            Height= 350;
            Width = 525;
            FontSize = 40;
            TextBlock tbl = new TextBlock();
            tbl.Text = "Hello WPF world \n\n- No XAML used!";
            tbl.Margin = new Thickness(20);
            Content = tbl;
        }
    }
}
