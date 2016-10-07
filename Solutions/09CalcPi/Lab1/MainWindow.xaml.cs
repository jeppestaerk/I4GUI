using System;
using System.Windows;
using System.Windows.Threading;

namespace Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundThread worker;

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
            // Update statusbar
            sbiStatus.Content = "Calculating...";
            progressBar.Visibility = Visibility.Visible;
            tblkResults.Clear();

            // Convert control's decimal Value to an integer
            int digits = ((int.Parse(this.tbxDigits.Text)));
            worker = new BackgroundThread();
            worker.evCompleted += new EventHandler(worker_evCompleted); // long form
            worker.evUpdate += ShowProgress;
            progressBar.Maximum = digits;
            worker.CalcPi(digits);
        }

        public delegate void MyDelegateType();

        void ShowProgress(Object sender, EventArgs e)
        {
            PiUpdateEventArgs pe = e as PiUpdateEventArgs;

            // To be run on UI thread
            MyDelegateType methodForUiThread = delegate
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
            };

            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, methodForUiThread);
        }

        void worker_evCompleted(object sender, EventArgs e)
        {
            // To be run on UI thread
            Dispatcher.BeginInvoke(new Action(()=>
            {
                // Show result
                tblkResults.Text = worker.Pi;
                btnCalculate.IsEnabled = true;
                sbiStatus.Content = "Ready";
                progressBar.Visibility = Visibility.Hidden;
            }));
        }
    }
}
