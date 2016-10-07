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
using System.Windows.Threading;
using System.Diagnostics;


namespace KeyboardInput
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : System.Windows.Window
    {

        DispatcherTimer dt;
        public Window1()
        {
            InitializeComponent();

            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(0.5);
            dt.Tick += new EventHandler(dt_Tick);
            dt.Start();
        }

        void dt_Tick(object sender, EventArgs e)
        {
        
            bool isCopy = false;

            // Example 4-12. Reading keyboard modifiers

            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0)
            {
                isCopy = true;
            }

            // End of Example 4-12.


            // Example 4-13. Reading individual key state

            bool homeKeyPressed = Keyboard.IsKeyDown(Key.Home);

            // End of Example 4-13.


            Debug.WriteLine("Ctrl state: " + isCopy + ", Home pressed: " + homeKeyPressed);
        }

    }
}