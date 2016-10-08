using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Opgave1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Agents agents = new Agents();
        public MainWindow()
        {
            InitializeComponent();
            agents.Add(new Agent("009", "Jeppe Stærk", "Aarhus, DK", "Hacking", "EchoDelta"));
            agents.Add(new Agent("008", "John Doe", "Aarhus, DK", "Eating", "EchoAlfa"));
            mainGrid.DataContext = agents;
        }
    }
}
