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
using System.IO;

namespace Delopgave3
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
                StringWriter swr = new StringWriter();

                str = sr.ReadLine(); // Don't show the first line with headings

                while (!sr.EndOfStream)
                {
                    str = sr.ReadLine();
                    if (str[0] == ';')
                        str = " " + str;
                    if (str != "")
                    {
                        tokens = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                        // Build the string to put into the listbox
                        if (tokens[1].Length > 28)
                            tokens[1] = tokens[1].Substring(0, 31);

                        //for (int i = 0; i < 4; ++i)
                        //{
                        //    swr.Write("{0,-20}", tokens[i]);
                        //}
                        swr.Write("{0,-12}", tokens[0]);
                        swr.Write("{0,-32}", tokens[1]);
                        swr.Write("{0,-12}", tokens[2]);
                        swr.Write("{0,-32}", tokens[3]);

                        lbxDeltagere.Items.Add(swr.ToString());
                        swr = new StringWriter();
                    }
                }
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
