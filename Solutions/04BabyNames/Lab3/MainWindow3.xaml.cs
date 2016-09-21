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
using SIO = System.IO;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow3 : Window
    {
        private List<BabyName> namesCollection;
        private string[,] rankMatrix = new string[11, 10];

        public MainWindow3()
        {
            InitializeComponent();
            for (int decade = 1900; decade < 2010; decade += 10)
                lstDecade.Items.Add(decade);

            Loaded += new RoutedEventHandler(MainWindow_Loaded);
            lstDecade.SelectionChanged += new SelectionChangedEventHandler(lstDecade_SelectionChanged);
            btnSearch.Click += new RoutedEventHandler(Search);
        }

        void Search(object sender, RoutedEventArgs e)
        {
            // get the name entered by the user:
            string name = tbxName.Text;

            // search through collection...
            int i;
            if (name == "")
                i = namesCollection.Count + 1;
            else
                i = namesCollection.IndexOf(new BabyName(name + " 1 1 1 1 1 1 1 1 1 1 1"));

            // Alternative manual search 
            //for (i = 0; i < namesCollection.Count; ++i)
            //{
            //   if (namesCollection[i].Name == name)
            //      break;
            //}

            if (-1 < i && i < namesCollection.Count)
            {
                tblkError.Text = "";
                BabyName theName = namesCollection[i];
                tboxAveRank.Text = theName.AverageRank().ToString();
                if (theName.Trend() > 0)
                    tboxTrend.Text = "More popular";
                else if (theName.Trend() == 0)
                    tboxTrend.Text = "Inconclusive";
                else
                    tboxTrend.Text = "Less popular";

                int rank;
                lstNameRanking.Items.Clear();
                for (int year = 1900; year < 2001; year += 10)
                {
                    rank = theName.Rank(year);
                    lstNameRanking.Items.Add(string.Format("{0:####}   {1:####}", year, rank));
                }
            }
            else
            {
                tblkError.Text = "Name not found!";
                tboxAveRank.Text = "";
                tboxTrend.Text = "";
                lstNameRanking.Items.Clear();
            }
        }

        void lstDecade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int decade;

            decade = (int)lstDecade.SelectedItem;
            decade = (decade - 1900) / 10;
            lstTopBabyNames.Items.Clear();
            for (int i = 1; i < 11; ++i)
            {
                lstTopBabyNames.Items.Add(string.Format("{0,2} {1}", i, rankMatrix[decade, i - 1]));
            }
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            bool fileFound = true;
            string file;
            file = SIO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "babynames.txt");
            try
            {
                this.namesCollection = Utility.ReadBabyNameData(file);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error occured while starting Lab. 4.3:");
                Application.Current.Shutdown();
                fileFound = false;
            }

            if (fileFound)
                foreach (BabyName name in namesCollection)
                {
                    for (int decade = 1900; decade < 2010; decade += 10)
                    {
                        int rank = name.Rank(decade);
                        int decadeIndex = (decade - 1900) / 10;
                        if (0 < rank && rank < 11)
                            if (rankMatrix[decadeIndex, rank - 1] == null)
                                rankMatrix[decadeIndex, rank - 1] = name.Name;
                            else
                                rankMatrix[decadeIndex, rank - 1] += " and " + name.Name;
                    }
                }
        }

    }
}
