using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using SIO = System.IO;
using System.Diagnostics;

namespace Lab4
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow4 : Window
   {
      private List<BabyName> namesCollection;
      private string[,] rankMatrix = new string[11, 10];

      public MainWindow4()
      {
         InitializeComponent();
         for (int decade = 1900; decade < 2010; decade += 10)
             lstDecade.Items.Add(decade);
         Loaded += new RoutedEventHandler(MainWindow_Loaded);
         lstDecade.SelectionChanged += new SelectionChangedEventHandler(lstDecade_SelectionChanged);
         btnSearch.Click += new RoutedEventHandler(Search);
         //Trace.WriteLine("Font size: " + FontSize);
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

      private void MI_FileExitClick(object sender, RoutedEventArgs e)
      {
          Close();
      }

      private void MI_FontLarge(object sender, RoutedEventArgs e)
      {
          FontSize = 18.0;
      }

      private void MI_FontSmall(object sender, RoutedEventArgs e)
      {
          FontSize = 8.0;
      }

      private void MI_FontHuge(object sender, RoutedEventArgs e)
      {
          FontSize = 40.0;
      }

      private void MI_FontNormal(object sender, RoutedEventArgs e)
      {
          FontSize = 12.0;
      }

   }
}
