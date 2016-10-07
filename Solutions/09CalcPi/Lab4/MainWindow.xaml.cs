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
using System.Windows.Threading;
using System.Threading;
using System.Diagnostics;

namespace Lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int countCores;
        BackgroundThread[] worker;
        DateTime startTime;
        DateTime endTime;
        int totalDigits;

        public MainWindow()
        {
            InitializeComponent();
            countCores = Environment.ProcessorCount;
            tbxCores.Text = countCores.ToString();
        }

        private void miFileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            startTime = DateTime.Now;
            btnCalculate.IsEnabled = false;
            // Update statusbar
            sbiStatus.Content = "Calculating...";

            // Convert control's decimal Value to an integer
            totalDigits = ((int.Parse(this.tbxDigits.Text)));
            int digitsPrThread = (int)Math.Ceiling((double)totalDigits / (double)countCores);

            worker = new BackgroundThread[countCores];
            int start;
            int stop;

            // Must create all thread objects before starting the first!
            for (int i = 0; i < countCores; i++)
            {
                worker[i] = new BackgroundThread(i);
            }

            for (int i = 0; i < countCores; i++)
            {
                worker[i].evCompleted += new EventHandler<CalcPiEventArgs>(worker_evCompleted);
                start = 0 + i * digitsPrThread;
                stop = Math.Min((i + 1) * digitsPrThread, totalDigits);
                worker[i].CalcPi(start, stop);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        void worker_evCompleted(object sender, CalcPiEventArgs e)
        {
            bool allThreadsCompleted = true;
            lock (this)
                foreach (BackgroundThread bgw in worker)
                    if (bgw.IsCompleted == false)
                        allThreadsCompleted = false;
            if (allThreadsCompleted)
            {
                endTime = DateTime.Now;
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate
                {
                    // Show result
                    StringBuilder pi = new StringBuilder("3.", totalDigits + 3);
                    foreach (BackgroundThread bgw in worker)
                        pi.Append(bgw.Pi);
                    TimeSpan calcTime = endTime - startTime;
                    tblCalcTime.Text = calcTime.ToString();
                    tblkResults.Text = pi.ToString();
                    btnCalculate.IsEnabled = true;
                    // Update statusbar
                    sbiStatus.Content = "Ready";
                });
            }
        }

        private void tblCores_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                countCores = int.Parse(tbxCores.Text);
            }
            catch (Exception)
            {
                countCores = 1;
            }
        }
    }
}
