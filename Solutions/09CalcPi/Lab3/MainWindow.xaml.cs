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
using System.Threading;
using System.Diagnostics;
using System.Threading;
using CalcPiAlgoritm;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundThread worker;
        int countCores;
        DateTime startTime;
        DateTime endTime;

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
            btnCalculate.IsEnabled = false;
            tblkResults.Clear();
            // Update statusbar
            sbiStatus.Content = "Calculating...";

            // Convert control's decimal Value to an integer
            int digits = ((int.Parse(this.tbxDigits.Text)));
            worker = new BackgroundThread();
            worker.evCompleted += new EventHandler(worker_evCompleted); // long form
            worker.evUpdate += ShowProgress;
            progressBar.Maximum = digits;
            worker.CalcPi(digits);
        }

        void ShowProgress(Object sender, EventArgs e)
        {
            PiUpdateEventArgs pe = e as PiUpdateEventArgs;

            // To be run on UI thread
            Dispatcher.BeginInvoke(new Action(() =>
            {
                // Display progress in UI
                tblkResults.Text += pe.Pi;

                progressBar.Value = pe.DigitsSoFar;
                progressBar.Visibility = Visibility.Visible;

                if (pe.DigitsSoFar == pe.TotalDigits)
                {
                    // Reset UI
                    sbiStatus.Content = "Ready";
                    progressBar.Visibility = Visibility.Hidden;
                    btnCalculate.IsEnabled = true;
                }
            }));
        }

        void worker_evCompleted(object sender, EventArgs e)
        {
            // To be run on UI thread
            Dispatcher.BeginInvoke(new Action(() =>
            {
                // Show result
                tblkResults.Text = worker.Pi;
                tblCalcTime.Text = worker.CalculationTime.ToString();
                btnCalculate.IsEnabled = true;
                sbiStatus.Content = "Ready";
                progressBar.Visibility = Visibility.Hidden;
            }));
        }
    }
}
