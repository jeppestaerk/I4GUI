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
using System.Diagnostics;


namespace MouseInput
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : System.Windows.Window
    {
        // Example mouse capture

        public Window1()
        {
            InitializeComponent();

            myEllipse.MouseDown += myEllipse_MouseDown;
            myEllipse.MouseMove += myEllipse_MouseMove;
            myEllipse.MouseUp += myEllipse_MouseUp;
        }

        void myEllipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(myEllipse);
            Debug.WriteLine("myEllipse_MouseDOWN: " + Mouse.GetPosition(myEllipse));
        }

        void myEllipse_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
            Debug.WriteLine("myEllipse_MouseUP: " + Mouse.GetPosition(myEllipse));
        }

        void myEllipse_MouseMove(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("myEllipse_MouseMove: " + Mouse.GetPosition(myEllipse));
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point pos = Mouse.GetPosition(this);
            Debug.WriteLine("Window.OnMouseMove: " + pos);
        }


        // Temporary mouse cursor override

        private void StartSlowWork()
        {
            Mouse.OverrideCursor = Cursors.AppStarting;
        }

        private void SlowWorkCompleted()
        {
            Mouse.OverrideCursor = null;
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Source != myEllipse)
            {
                StartSlowWork();
            }
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            SlowWorkCompleted();
        }

    }
}