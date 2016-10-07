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

namespace GraphingWithShapes
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        ObservableCollection<NameValuePair> dataPoints = new ObservableCollection<NameValuePair>();
        private List<Color> columnColors = new List<Color>() { Colors.Blue, Colors.Red, Colors.Green };

		public MainWindow()
		{
			InitializeComponent();

            // Add some points so I don't have to keep retyping them
            dataPoints.Add(new NameValuePair("First", 10));
            dataPoints.Add(new NameValuePair("Second", 20));
            dataPoints.Add(new NameValuePair("Third", 5));
            dataPoints.Add(new NameValuePair("Fourth", 15));
            dataPoints.Add(new NameValuePair("Fifth", 34));
            dataPoints.Add(new NameValuePair("Sixth", 3));
            dataPoints.Add(new NameValuePair("Seventh", 40));
            dataPoints.Add(new NameValuePair("Eigth", 12));
            dataPoints.Add(new NameValuePair("Ninth", 3));
            dataPoints.Add(new NameValuePair("Tenth", 17));
            dataPoints.Add(new NameValuePair("First", 10));
            dataPoints.Add(new NameValuePair("Second", 20));
            dataPoints.Add(new NameValuePair("Third", 5));
            dataPoints.Add(new NameValuePair("Fourth", 15));
            dataPoints.Add(new NameValuePair("Fifth", 34));
            dataPoints.Add(new NameValuePair("Sixth", 3));
            dataPoints.Add(new NameValuePair("Seventh", 40));
            dataPoints.Add(new NameValuePair("Eigth", 12));
            dataPoints.Add(new NameValuePair("Ninth", 3));
            dataPoints.Add(new NameValuePair("Tenth", 17));
            dataPoints.Add(new NameValuePair("First", 10));
            dataPoints.Add(new NameValuePair("Second", 20));
            dataPoints.Add(new NameValuePair("Third", 5));
            dataPoints.Add(new NameValuePair("Fourth", 15));
            dataPoints.Add(new NameValuePair("Fifth", 34));
            dataPoints.Add(new NameValuePair("Sixth", 3));
            dataPoints.Add(new NameValuePair("Seventh", 40));
            dataPoints.Add(new NameValuePair("Eigth", 12));
            dataPoints.Add(new NameValuePair("Ninth", 3));
            dataPoints.Add(new NameValuePair("Tenth", 17));
            dataPoints.Add(new NameValuePair("First", 10));
            dataPoints.Add(new NameValuePair("Second", 20));
            dataPoints.Add(new NameValuePair("Third", 5));
            dataPoints.Add(new NameValuePair("Fourth", 15));
            dataPoints.Add(new NameValuePair("Fifth", 34));
            dataPoints.Add(new NameValuePair("Sixth", 3));
            dataPoints.Add(new NameValuePair("Seventh", 40));
            dataPoints.Add(new NameValuePair("Eigth", 12));
            dataPoints.Add(new NameValuePair("Ninth", 3));
            dataPoints.Add(new NameValuePair("Tenth", 17));
            dataPoints.Add(new NameValuePair("First", 10));
            dataPoints.Add(new NameValuePair("Second", 20));
            dataPoints.Add(new NameValuePair("Third", 5));
            dataPoints.Add(new NameValuePair("Fourth", 15));



            // Bind the listbox to the collection
            Binding binding = new Binding();
            binding.Source = dataPoints;
            valuesList.SetBinding(ListBox.ItemsSourceProperty, binding);
            SetData(dataPoints);
        }

        private void addValueBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = addValueNameTextBox.Text.Trim();
            if (name.Length == 0)
            {
                MessageBox.Show("Please enter a name");
                return;
            }

            string valueAsString = addValueValueTextBox.Text.Trim();
            double valueAsDouble = 0;
            try
            {
                valueAsDouble = Convert.ToDouble(valueAsString);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid value");
                return;
            }

            NameValuePair nvp = new NameValuePair(name, valueAsDouble);
            dataPoints.Add(nvp);
            //valuesList.Items.Add(nvp);

            addValueNameTextBox.Text = "";
            addValueValueTextBox.Text = "";
        }

        private void valuesList_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Delete) && (valuesList.SelectedIndex >= 0))
            {
                dataPoints.RemoveAt(valuesList.SelectedIndex);
            }
        }

        public void SetData(ObservableCollection<NameValuePair> data)
        {
            dataPoints = data;
            dataPoints.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(dataPoints_CollectionChanged);
            Update();
        }

        void dataPoints_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Update();
        }

        /// <summary>Called when data has changed - graph must be updated</summary>
        public void Update()
        {
            Dictionary<Rectangle, NameValuePair> usedRects = new Dictionary<Rectangle, NameValuePair>();
            Rectangle rect;
            
            foreach (NameValuePair nvp in dataPoints)
            {
                if (nvp.Tag == null)
                {
                    // Make sure that there is one rectangle for each data-point
                    rect = new Rectangle();
                    rect.Stroke = Brushes.Black;
                    rect.StrokeThickness = 1;
                    rect.MouseDown += new MouseButtonEventHandler(rect_MouseDown);
                    rect.Tag = nvp;
                    usedRects[rect] = nvp;
                    graphCanvas.Children.Add(rect);
                    nvp.Tag = rect;
                }
                else
                {
                    usedRects[nvp.Tag as Rectangle] = nvp;
                }
            }

            // Get rid of unused rects
            int i = 0;
            UIElement elem;
            while (i < graphCanvas.Children.Count)
            {
                elem = graphCanvas.Children[i];
                if ((elem is Rectangle) && !usedRects.ContainsKey((Rectangle)elem))
                    graphCanvas.Children.RemoveAt(i);
                else
                    i++;
            }

            CalculatePositionsAndSizes();
        }

        private void rect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                Rectangle rect = sender as Rectangle;
                NameValuePair nvp = rect.Tag as NameValuePair;

                if (nvp != null)
                    MessageBox.Show("Name: " + nvp.Name + ", Value: " + nvp.Value.ToString());
            }
        }

        public void CalculatePositionsAndSizes()
        {
            if (dataPoints == null)
                return;

            double spaceToUseY = graphCanvas.ActualHeight * 0.8;
            double spaceToUseX = graphCanvas.ActualWidth * 0.8;

            double barWidth = spaceToUseX / dataPoints.Count;
            double largestValue = GetLargestValue();
            double unitHeight = spaceToUseY / largestValue;

            double bottom = graphCanvas.ActualHeight * 0.1;
            double left = graphCanvas.ActualWidth * 0.1;

            Rectangle rect;
            int nIndex = 0;
            foreach (NameValuePair nvp in dataPoints)
            {
                rect = nvp.Tag as Rectangle;
                if (rect != null)
                {
                    rect.Width = barWidth;
                    rect.Height = nvp.Value * unitHeight;
                    rect.Fill = new SolidColorBrush(columnColors[nIndex++ % columnColors.Count]);
                    Canvas.SetLeft(rect, left);
                    Canvas.SetBottom(rect, bottom);
                    left += rect.Width;
                }
            }
        }

        public double GetLargestValue()
        {
            double value = 0;
            foreach (NameValuePair nvp in dataPoints)
            {
                value = Math.Max(value, nvp.Value);
            }

            return value;
        }

        private void main_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CalculatePositionsAndSizes();
        }
	}
}
