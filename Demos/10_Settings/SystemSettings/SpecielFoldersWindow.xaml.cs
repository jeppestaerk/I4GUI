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
    /// Interaction logic for SpecielFoldersWindow.xaml
    /// </summary>
    public partial class SpecielFoldersWindow : Window
    {
        public SpecielFoldersWindow()
        {
            InitializeComponent();
            foreach (Environment.SpecialFolder value in Enum.GetValues(typeof(Environment.SpecialFolder)))
            {
                SpecielFolderInfo fi = new SpecielFolderInfo(value.ToString(), Environment.GetFolderPath(value));
                specialFoldersListBox.Items.Add(fi);

            }
        }
    }
}
