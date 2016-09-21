using System;
using System.Collections.Generic;
using System.IO;
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

namespace Delopgave3_alternativ
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(@"..\..\..\deltagerliste.csv", FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs, Encoding.Default);
                string str;
                string[] tokens;
                char[] separators = { ';' };
                List<string> lines = new List<string>();
                str = sr.ReadLine(); // Don't show the first line with headings

                while (!sr.EndOfStream)
                {
                    str = sr.ReadLine();
                    if (str != "")
                    {
                        tokens = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                        // Build the string to put into the listbox
                        if (tokens[0].Length > 20)
                            tokens[0] = tokens[0].Substring(0, 20);  // Limit first name to max 20 chars
                        string nextLine = string.Format("{0,-20} {1,-20} {2,-12} {3,20}", tokens[0], tokens[1], tokens[2], tokens[3]);
                        lines.Add(nextLine);
                    }
                }
                lbxDeltagere.ItemsSource = lines;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occured during file IO");
            }
            finally
            {
                sr.Close();
                fs.Close();
            }
        }
    }
}
