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

namespace Opgave3
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
            FileStream fileStream = new FileStream(@"..\..\deltagerliste.csv", FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);

            string str;
            string[] tokens;
            char[] separators = { ';' };
            StringWriter stringWriter = new StringWriter();

            str = streamReader.ReadLine();
            tBlockDeltager.Text = str;

            while (!streamReader.EndOfStream)
            {
                str = streamReader.ReadLine();
                if (str[0] == ';')
                {
                    str = " " + str;
                }
                if (str != "")
                {
                    tokens = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);


                    stringWriter.Write("{0,-15}", tokens[0]);
                    stringWriter.Write("{0,-50}", tokens[1]);
                    stringWriter.Write("{0,-15}", tokens[2]);
                    stringWriter.Write("{0,-50}", tokens[3]);

                    lBoxDeltager.Items.Add(stringWriter.ToString());

                    stringWriter = new StringWriter();
                }

            }

            stringWriter.Close();
            streamReader.Close();
            fileStream.Close();
        }
    }
}
