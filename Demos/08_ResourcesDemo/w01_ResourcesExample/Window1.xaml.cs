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


namespace ResourcesExample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : System.Windows.Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        public void BadResourceRetrieval()
        {
            // Example 12-3. Retrieving resources from an element’s
            // ResourceDictionary the wrong way

            // NOT the best way to retrieve resources
            Brush b = (Brush) this.Resources["myBrush"];
            String s = (String) this.Resources["HW"];

            // End of Example 12-3.
        }


        public void BetterResourceRetrieval()
        {
            // Example 12-4. Using FindResource

            Brush b = (Brush) this.FindResource("myBrush");
            String s = (String) this.FindResource("HW");

            // End of Example 12-4.
        }

        public void RetrieveFromGrid()
        {
            // Example 12-5. FrameworkElement.Resources vs FindResource

            // Returns null
            Brush b1 = (Brush) myGrid.Resources["myBrush"];

            // Returns SolidColorBrush from Window.Resources
            Brush b2 = (Brush) myGrid.FindResource("myBrush");

            // End of Example 12-5.
        }

        public void RetrieveSystemResource()
        {
            // Example 12-7. Retrieving a system scope resource

            Brush toolTipBackground = (Brush) myGrid.FindResource(SystemColors.InfoBrushKey);

            // End of Example 12-7.
        }

        public void BadSystemResourceRetrieval()
        {
            // Example 12-8. Retrieving a system resource through its corresponding property

            Brush toolTipBackground = SystemColors.InfoBrush;

            // End of Example 12-8.
        }

        public void OverrideSystemColours()
        {
            // Example 12-9. Application overriding system colors

            // (Hypothetical function for retrieving settings)
            Color col = GetColorFromUserSettings();

            Application.Current.Resources[SystemColors.InfoBrushKey] =
               new SolidColorBrush(Colors.Red);

            // End of Example 12-9.
        }

        private Color GetColorFromUserSettings()
        {
            return Colors.Azure;
        }

        public void DifferentlyBadSystemResourceRetrieval()
        {
            // Example 12-13. How not to use a system resource value

            this.Background = (Brush) this.FindResource(SystemColors.ControlBrushKey);

            // End of Example 12-13.
        }

        public void AssociatePropertyWithSystemResource()
        {
            // Example 12-14. Self-updating system resource reference

            this.SetResourceReference(Window.BackgroundProperty, SystemColors.ControlBrushKey);

            // End of Example 12-14.
        }
    }
}