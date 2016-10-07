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

namespace ContentModel
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class Window1 : Window
   {
      Button btnContent;
      GroupBox gbHeadedContent;
      ListBox lbxItems;

      public Window1()
      {
         InitializeComponent();
         ContentControlExample();
         mainPanel.Children.Add(btnContent);
         HeadedContentControlExample();
         mainPanel.Children.Add(gbHeadedContent);
         ItemsControlExample();
         mainPanel.Children.Add(lbxItems);
      }

      private void ContentControlExample()
      {
         // Create a Button with a panel that contains multiple objects 
         // as its content.
         btnContent = new Button();
         StackPanel stackPanel1 = new StackPanel();
         stackPanel1.Margin = new Thickness(3.0d);
         Ellipse ellipse1 = new Ellipse();
         TextBlock textBlock1 = new TextBlock();

         ellipse1.Width = 40;
         ellipse1.Height = 40;
         ellipse1.Fill = Brushes.Blue;

         textBlock1.TextAlignment = TextAlignment.Center;
         textBlock1.Text = "Button";

         stackPanel1.Children.Add(ellipse1);
         stackPanel1.Children.Add(textBlock1);

         btnContent.Content = stackPanel1;
      }

      private void HeadedContentControlExample()
      {
         // Create a GroupBox with a panel that contains multiple objects 
         // as its content.
         gbHeadedContent = new GroupBox();
         gbHeadedContent.Header = "Header";
         gbHeadedContent.Margin = new Thickness(5.0d);

         StackPanel stackPanel1 = new StackPanel();
         stackPanel1.Margin = new Thickness(3.0d);
         Ellipse ellipse1 = new Ellipse();
         TextBlock textBlock1 = new TextBlock();

         ellipse1.Width = 40;
         ellipse1.Height = 40;
         ellipse1.Fill = Brushes.Blue;

         textBlock1.TextAlignment = TextAlignment.Center;
         textBlock1.Text = "GroupBox";

         stackPanel1.Children.Add(ellipse1);
         stackPanel1.Children.Add(textBlock1);

         gbHeadedContent.Content = stackPanel1;
      }

      private void ItemsControlExample()
      {
         lbxItems = new ListBox();
         // Add a String to the ListBox.
         lbxItems.Items.Add("This is a string in a ListBox");

         // Add a DateTime object to a ListBox.
         DateTime dateTime1 = new DateTime(2004, 3, 4, 13, 6, 55);
         lbxItems.Items.Add(dateTime1);

         // Add a Rectangle to the ListBox.
         lbxItems.Items.Add("Another item");

         // Add a panel that contains multpile objects to the ListBox.
         StackPanel stackPanel1 = new StackPanel();
         stackPanel1.Margin = new Thickness(3.0d);
         Ellipse ellipse1 = new Ellipse();
         TextBlock textBlock1 = new TextBlock();

         ellipse1.Width = 40;
         ellipse1.Height = 40;
         ellipse1.Fill = Brushes.Blue;

         textBlock1.TextAlignment = TextAlignment.Center;
         textBlock1.Text = "Text below an Ellipse";

         stackPanel1.Children.Add(ellipse1);
         stackPanel1.Children.Add(textBlock1);

         lbxItems.Items.Add(stackPanel1);
      }

      
   }
}
