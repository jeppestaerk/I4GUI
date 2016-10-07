using System;
using System.Windows;
using System.Diagnostics;


namespace EventExamples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Debug.WriteLine("Got Button - PreviewMouseLeftButtonDown event"); 
        }

        private void Button_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Debug.WriteLine("Got Button - MouseLeftButtonDown event"); 
        }

        void PreviewMouseDownButton(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Got Button - PreviewMouseDown event"); 
        }

        void MouseDownButton(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Got Button - MouseDown event"); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Got Button - Click event");
        }

        private void Button_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Debug.WriteLine("Got Button - PreviewMouseLeftButtonUp event");
        }

        private void Button_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Debug.WriteLine("Got Button - PreviewMouseUp event");
        }

        private void Button_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Debug.WriteLine("Got Button - MouseLeftButtonUp event");
        }

        private void Button_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Debug.WriteLine("Got Button - MouseUp event");
        }
        


        void PreviewMouseDownGrid(object sender, RoutedEventArgs e)
        { Debug.WriteLine("PreviewMouseDownGrid"); }

        void MouseDownGrid(object sender, RoutedEventArgs e)
        { Debug.WriteLine("MouseDownGrid"); }


        void PreviewMouseDownCanvas(object sender, RoutedEventArgs e)
        {
            Object realSender = e.Source;
            //e.Handled = true;
            Debug.WriteLine("PreviewMouseDownCanvas"); 
        }

        void MouseDownCanvas(object sender, RoutedEventArgs e)
        { Debug.WriteLine("MouseDownCanvas"); }


        void PreviewMouseDownEllipse(object sender, RoutedEventArgs e)
        { Debug.WriteLine("PreviewMouseDownEllipse"); }

        void MouseDownEllipse(object sender, RoutedEventArgs e)
        { Debug.WriteLine("MouseDownEllipse"); }

        private void leftEyeEllipse_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void rightEyeEllipse_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void mouthPath_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void mouthPath_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void TextBlock_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void TextBlock_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void TextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void TextBlock_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void TextBlock_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void TextBlock_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void TextBlock_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        

    }
}
