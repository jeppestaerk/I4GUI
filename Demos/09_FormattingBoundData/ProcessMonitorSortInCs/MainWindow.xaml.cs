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
using System.ComponentModel;

namespace ProcessMonitorSortInCs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void sortOrderCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetNewSortOrder();
        }
        private void SetNewSortOrder()
        {
            string newSortOrder = ((ComboBoxItem)sortOrderCombo.SelectedItem).Content.ToString();
            SortDescription sortDesc = new SortDescription(newSortOrder, ListSortDirection.Ascending);
            CollectionViewSource src = (CollectionViewSource)FindResource("processesView");
            src.SortDescriptions.Clear();
            src.SortDescriptions.Add(sortDesc);
        }
    }
}
