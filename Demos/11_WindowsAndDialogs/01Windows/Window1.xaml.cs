using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using System.ComponentModel;

namespace _01Windows
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class Window1 : Window
   {
      public Window1()
      {
         // watch events
         this.Activated += new EventHandler(Window1_Activated);
         this.Closed += new EventHandler(Window1_Closed);
         this.Closing += new System.ComponentModel.CancelEventHandler(Window1_Closing);
         this.ContentRendered += new EventHandler(Window1_ContentRendered);
         this.Deactivated += new EventHandler(Window1_Deactivated);
         this.Initialized += new EventHandler(Window1_Initialized);
         this.Loaded += new RoutedEventHandler(Window1_Loaded);
         this.LocationChanged += new EventHandler(Window1_LocationChanged);
         this.SourceInitialized += new EventHandler(Window1_SourceInitialized);
         this.StateChanged += new EventHandler(Window1_StateChanged);
         this.Unloaded += new RoutedEventHandler(Window1_Unloaded);

         Debug.WriteLine("ctor.pre-InitComp");
         InitializeComponent();
         Debug.WriteLine("ctor.post-InitComp");

         // restore state from user settings
         try
         {
            Rect restoreBounds = Properties.Settings.Default.MainRestoreBounds;
            WindowState = WindowState.Normal;
            Left = restoreBounds.Left;
            Top = restoreBounds.Top;
            Width = restoreBounds.Width;
            Height = restoreBounds.Height;

            WindowState = Properties.Settings.Default.MainWindowState;
         }
         catch { }

         // watch for main window to close
         Closing += window_Closing;
      }

      // save state as window closes
      void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         Properties.Settings.Default.MainRestoreBounds = RestoreBounds;
         Properties.Settings.Default.MainWindowState = WindowState;
         Properties.Settings.Default.Save();
      }

      void button_Click(object sender, RoutedEventArgs e)
      {
         Button button = (Button)sender;
         WindowStyle style = (WindowStyle)Enum.Parse(typeof(WindowStyle), (string)button.Content);
         ResizeMode resize = (ResizeMode)Enum.Parse(typeof(ResizeMode), (string)resizeCombo.Text);

         Window window = new Window();
         window.Initialized += new EventHandler(window_Initialized);
         window.Unloaded += new RoutedEventHandler(window_Unloaded);

         // do look 'n' feel
         //window.Background = Brushes.Yellow;
         window.WindowStyle = style;
         window.ResizeMode = resize;
         //window.Owner = this;
         if (Properties.Settings.Default.ShowResizeMode)
         {
            window.Content = " WindowStyle." + style.ToString() + "\r\n ResizeMode." + resize.ToString() + "\r\n (" + Properties.Settings.Default.OsThemeLabel + ")";
         }
         else
         {
            window.Content = " WindowStyle." + style.ToString() + "\r\n\r\n (" + Properties.Settings.Default.OsThemeLabel + ")";
         }
         window.Width = 220;
         window.Height = 100;
         window.MouseDown += delegate(object sender2, MouseButtonEventArgs e2) { window.DragMove(); };
         window.Title = "The Title";

         if (modalCheckBox.IsChecked == true) { window.ShowDialog(); }
         else { window.Show(); }
      }

      void window_Unloaded(object sender, RoutedEventArgs e)
      {
         Debug.WriteLine("window_Unloaded");
      }

      void window_Initialized(object sender, EventArgs e)
      {
         Debug.WriteLine("window_Initialized");
      }

      void button2_Click(object sender, RoutedEventArgs e)
      {
         Window window = new Window();

         // TODO: remove
         //window.Show(); // render window so ActualWidth is calculated
         //window.MinWidth = 200;
         //window.MaxWidth = 400;
         //window.Width = 100;
         //Debug.Assert(window.Width == 100); // regardless of min/max settings
         //Debug.Assert(window.ActualWidth == 200); // bound by min/max settings
         //return;

         window.Title = "Location & Size Tracking";
         window.LocationChanged += delegate(object sender2, EventArgs e2) { SetLocationSizeTrackingWindowContext(window); };
         window.SizeChanged += delegate(object sender2, SizeChangedEventArgs e2) { SetLocationSizeTrackingWindowContext(window); };
         window.MouseLeftButtonUp += delegate(object sender2, MouseButtonEventArgs e2) { window.Width = 200; window.Height = 200; SetLocationSizeTrackingWindowContext(window); };
         window.MouseRightButtonUp += delegate(object sender2, MouseButtonEventArgs e2) { window.MinWidth = 100; window.MinHeight = 200; SetLocationSizeTrackingWindowContext(window); };
         DependencyPropertyDescriptor.FromProperty(Window.WindowStateProperty, typeof(Window)).AddValueChanged(window, delegate(object sender2, EventArgs e2)
         {
            Debug.WriteLine(string.Format(
              "Location/Size=({0}, {1}: {2}x{3})\r\nActualSize= ({4}, {5})\r\nRestoreBounds=({6}, {7}: {8}x{9})",
              window.Left, window.Top, window.Width, window.Height,
              window.ActualWidth, window.ActualHeight,
              window.RestoreBounds.Left, window.RestoreBounds.Top, window.RestoreBounds.Width, window.RestoreBounds.Height));
         });
         window.MinWidth = 200;
         window.MinHeight = 200;
         window.MaxWidth = 600;
         window.MaxHeight = 600;
         window.SizeToContent = SizeToContent.WidthAndHeight;
         window.Owner = this;
         window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

         if (modalCheckBox.IsChecked == true) { window.ShowDialog(); }
         else { window.Show(); }
      }

      void SetLocationSizeTrackingWindowContext(Window window)
      {
         window.Content = string.Format(
         "TopMost= {0}\r\nLocation= ({1}, {2})\r\nSize= ({3}, {4})\r\nMinSize= ({5}, {6})\r\nMaxSize= ({7}, {8})\r\nActualSize=({9}, {10})",
         window.Topmost,
         window.Left, window.Top,
         window.Width, window.Height,
         window.MinWidth, window.MinHeight,
         window.MaxWidth, window.MaxHeight,
         window.ActualWidth, window.ActualHeight);
      }

      void Window1_Unloaded(object sender, RoutedEventArgs e)
      {
         Debug.WriteLine("Window1_Unloaded");
         Debug.WriteLine(string.Format("\t:Actual size= {0}x{1}", ActualWidth, ActualHeight));
      }

      void Window1_StateChanged(object sender, EventArgs e)
      {
         Debug.WriteLine("Window1_StateChanged");
         Debug.WriteLine(string.Format("\t:Actual size= {0}x{1}", ActualWidth, ActualHeight));
      }

      void Window1_SourceInitialized(object sender, EventArgs e)
      {
         Debug.WriteLine("Window1_SourceInitialized");
         Debug.WriteLine(string.Format("\t:Actual size= {0}x{1}", ActualWidth, ActualHeight));
      }

      void Window1_LocationChanged(object sender, EventArgs e)
      {
         Debug.WriteLine("Window1_LocationChanged");
         Debug.WriteLine(string.Format("\t:Actual size= {0}x{1}", ActualWidth, ActualHeight));
      }

      void Window1_Loaded(object sender, RoutedEventArgs e)
      {
         Debug.WriteLine("Window1_Loaded");
         Debug.WriteLine(string.Format("\t:Actual size= {0}x{1}", ActualWidth, ActualHeight));
      }

      void Window1_Deactivated(object sender, EventArgs e)
      {
         Debug.WriteLine("Window1_Deactivated");
         Debug.WriteLine(string.Format("\t:Actual size= {0}x{1}", ActualWidth, ActualHeight));
      }

      void Window1_ContentRendered(object sender, EventArgs e)
      {
         Debug.WriteLine("Window1_ContentRendered");
         Debug.WriteLine(string.Format("\t:Actual size= {0}x{1}", ActualWidth, ActualHeight));
      }

      void Window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         Debug.WriteLine("Window1_Closing");
         Debug.WriteLine(string.Format("\t:Actual size= {0}x{1}", ActualWidth, ActualHeight));
      }

      void Window1_Closed(object sender, EventArgs e)
      {
         Debug.WriteLine("Window1_Closed");
         Debug.WriteLine(string.Format("\t:Actual size= {0}x{1}", ActualWidth, ActualHeight));
      }

      void Window1_Activated(object sender, EventArgs e)
      {
         Debug.WriteLine("Window1_Activated");
         Debug.WriteLine(string.Format("\t:Actual size= {0}x{1}", ActualWidth, ActualHeight));
      }

      void Window1_Initialized(object sender, EventArgs e)
      {
         Debug.WriteLine("Window1_Initialized");
         Debug.WriteLine(string.Format("\t:Actual size= {0}x{1}", ActualWidth, ActualHeight));
      }

      protected override void OnInitialized(EventArgs e)
      {
         base.OnInitialized(e);
         Debug.WriteLine("Window1.OnInitialized");
         Debug.WriteLine(string.Format("\t:Actual size= {0}x{1}", ActualWidth, ActualHeight));
      }
   }
}
