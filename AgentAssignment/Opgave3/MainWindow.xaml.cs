using System.Windows;

namespace Opgave1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            buttonBack.Click += new RoutedEventHandler(buttonBack_Click);
            buttonForward.Click += new RoutedEventHandler(buttonForward_Click);
            buttonAddNew.Click += new RoutedEventHandler(buttonAddNew_Click);
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxAgents.SelectedIndex > 0)
            {
                listBoxAgents.SelectedIndex = --listBoxAgents.SelectedIndex;
            }
        }

        private void buttonForward_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxAgents.SelectedIndex < listBoxAgents.Items.Count - 1)
            {
                listBoxAgents.SelectedIndex = ++listBoxAgents.SelectedIndex;
            }
        }

        private void buttonAddNew_Click(object sender, RoutedEventArgs e)
        {
            Agents agents = (Agents)FindResource("agents");
            agents.Add(new Agent());
            listBoxAgents.SelectedIndex = listBoxAgents.Items.Count - 1;
            textBoxId.Focus();
        }
    }
}
