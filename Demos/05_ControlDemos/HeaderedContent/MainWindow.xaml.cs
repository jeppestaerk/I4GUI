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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HeaderedContent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string selectedText = "";

        public MainWindow()
        {
            InitializeComponent();
            selectedText = rb1.Content.ToString();
        }

        private void rbChecked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (sender as RadioButton);
            if (rb != null)
            {
                if (rb.Content != null)
                {
                    selectedText = rb.Content.ToString();
                    tbxChoise.Text = "You clicked " + selectedText + ".";
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(selectedText, "You have selected");
        }
    }
}
