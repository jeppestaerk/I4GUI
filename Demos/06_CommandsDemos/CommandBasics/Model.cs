using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CommandBasics
{
    public class Model
    {
        public void Hello(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Hello from the model layer");
        }
    }
}
