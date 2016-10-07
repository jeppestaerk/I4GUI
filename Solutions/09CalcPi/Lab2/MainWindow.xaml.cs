using System;
using System.Text;
using System.Windows;
using System.ComponentModel;
using CalcPiAlgoritm;

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int digits;
        BackgroundWorker bgworker;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void miFileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            btnCalculate.IsEnabled = false;
            btnCancel.IsEnabled = true;
            // Update statusbar
            sbiStatus.Content = "Calculating...";
            progressBar.Visibility = Visibility.Visible;

            // Convert control's decimal Value to an integer
            digits = ((int.Parse(this.tbxDigits.Text)));
            bgworker = new BackgroundWorker();
            bgworker.DoWork += new DoWorkEventHandler(CalcPi);
            bgworker.ProgressChanged += new ProgressChangedEventHandler(bgworker_ProgressChanged);
            bgworker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgworker_RunWorkerCompleted);
            bgworker.WorkerReportsProgress = true;
            bgworker.WorkerSupportsCancellation = true;
            bgworker.RunWorkerAsync(digits);
        }

        void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StringBuilder pi = e.Result as StringBuilder;
            tblkResults.Text = pi.ToString();
            btnCalculate.IsEnabled = true;
            btnCancel.IsEnabled = false;
            sbiStatus.Content = "Ready";
            progressBar.Visibility = Visibility.Hidden; ;
        }

        void bgworker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Display progress in UI
            StringBuilder pi = e.UserState as StringBuilder;
            tblkResults.Text = pi.ToString();
            progressBar.Value = e.ProgressPercentage;
        }

        void CalcPi(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Retrieve argument 
            int digits = (int)e.Argument;

            StringBuilder pi = new StringBuilder("3", digits + 2);

            worker.ReportProgress(0, pi);

            if (digits > 0)
            {
                pi.Append(".");

                for (int i = 0; i < digits; i += 9)
                {
                    int nineDigits = NineDigitsOfPi.StartingAt(i + 1);
                    int digitCount = Math.Min(digits - i, 9);
                    string ds = string.Format("{0:D9}", nineDigits);
                    pi.Append(ds.Substring(0, digitCount));

                    // Show progress
                    worker.ReportProgress((i * 100) / digits, pi);
                    if (worker.CancellationPending)
                        break;
                }
                e.Result = pi;
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            bgworker.CancelAsync();
        }
    }
}
