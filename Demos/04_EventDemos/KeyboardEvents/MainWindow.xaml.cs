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
using System.Collections.ObjectModel;

namespace KeyboardEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<KeyEventInfo> _keyEvents = new ObservableCollection<KeyEventInfo>();

        public MainWindow()
        {
            InitializeComponent();
            lviEvents.ItemsSource = _keyEvents;
            KeyDown += new KeyEventHandler(MainWindow_KeyDown);
            TextInput += new TextCompositionEventHandler(MainWindow_TextInput);
            PreviewKeyDown += new KeyEventHandler(MainWindow_KeyDown);
            PreviewTextInput += new TextCompositionEventHandler(MainWindow_TextInput);
            PreviewKeyUp += new KeyEventHandler(MainWindow_KeyDown);
        }

        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            _keyEvents.Add(new KeyEventInfo(e));
        }

        protected override void OnKeyUp(KeyEventArgs args)
        {
            base.OnKeyUp(args);
            _keyEvents.Add(new KeyEventInfo(args));
            lviEvents.ScrollIntoView(lviEvents.Items[ lviEvents.Items.Count - 1] );
        }

        void MainWindow_TextInput(object sender, TextCompositionEventArgs e)
        {
            _keyEvents.Add(new KeyEventInfo(e));
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            _keyEvents.Clear();
        }

    }
}
