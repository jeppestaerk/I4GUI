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

namespace Opgave1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<BabyName> listBabyNames;
        private string[,] rankMatrix = new string[11,10];
        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
            listBoxDecades.SelectionChanged += new SelectionChangedEventHandler(listBoxDecades_SelectionChanged);
        }

        void listBoxDecades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem item = listBoxDecades.SelectedItems as ListBoxItem;

            if (item != null)
            {
                int decade = (Convert.ToInt32(item.Content) - 1900) / 10;
                listBoxNames.Items.Clear();
                for (int i = 1; i < 11; ++i)
                {
                    listBoxNames.Items.Add(string.Format("{0,3} {1}", i, rankMatrix[decade, i - 1]));
                }
            }
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            FileStream fileStream = new FileStream(@"../../babynames.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);

            try
            {
                listBabyNames = new List<BabyName>();
                string inputLine = streamReader.ReadLine();

                while (inputLine != null)
                {
                    listBabyNames.Add(new BabyName(inputLine));
                    inputLine = streamReader.ReadLine();
                    listBoxNames.Items.Add(inputLine);
                }

                foreach (BabyName babyName in listBabyNames)
                {
                    for (int decade = 1900; decade < 2010; decade += 10)
                    {
                        int rank = babyName.Rank(decade);
                        int decadeIndex = (decade - 1900) / 10;
                        if (0 < rank && rank < 11)
                        {
                            if (rankMatrix[decadeIndex, rank - 1] == null)
                            {
                                rankMatrix[decadeIndex, rank - 1] = babyName.Name;
                            }
                            else
                            {
                                rankMatrix[decadeIndex, rank - 1] += " and " + babyName.Name;
                            }
                        }
                    }
                }
            }
            finally
            {
                streamReader.Close();
                fileStream.Close();
            }


        }
    }
}
