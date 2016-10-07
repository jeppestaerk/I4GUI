using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace CommandBasics
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        Model model = new Model();

        public Window1()
        {
            InitializeComponent();

            InputBinding ib = new InputBinding(
                ApplicationCommands.Properties,
                new KeyGesture(Key.Enter, ModifierKeys.Alt));
            this.InputBindings.Add(ib);

            CommandBinding cb = new CommandBinding(ApplicationCommands.Properties);
            cb.Executed += new ExecutedRoutedEventHandler(cb_Executed);
            cb.Executed += new ExecutedRoutedEventHandler(model.Hello);
            this.CommandBindings.Add(cb);
        }

        void cb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Properties");
        }

    }



}