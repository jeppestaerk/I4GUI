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
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Resources;
using System.Collections;
using System.Windows.Resources;


namespace BinaryResources
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : System.Windows.Window
    {

        public Window1()
        {
            InitializeComponent();

            UseAssemblyManifestResource();


            foreach (string streamName in GetResourceNames(
                typeof(Window1).Assembly, Thread.CurrentThread.CurrentUICulture))
            {
                Debug.WriteLine(streamName);
            }



        }



        private void UseAssemblyManifestResource()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Stream s = asm.GetManifestResourceStream("BinaryResources.MyStream.txt");
            StreamReader r = new StreamReader(s);
            Debug.WriteLine(r.ReadToEnd());
        }

        static List<string> GetResourceNames(Assembly asm,
                       System.Globalization.CultureInfo culture)
        {

            string resourceName = asm.GetName().Name + ".g";
            ResourceManager rm = new ResourceManager(resourceName, asm);
            ResourceSet resourceSet = rm.GetResourceSet(culture, true, true);
            List<string> resources = new List<string>();
            foreach (DictionaryEntry resource in resourceSet)
            {

                resources.Add((string) resource.Key);
            }
            rm.ReleaseAllResources();
            return resources;
        }

        public Stream GetImageAsResource()
        {
            Uri resourcePath = new Uri("Images/Sunset.jpg", UriKind.Relative);
            StreamResourceInfo ri = Application.GetResourceStream(resourcePath);
            Stream data = ri.Stream;

            return data;
        }


        public Stream GetImageAsContent()
        {
            Uri resourcePath = new Uri("Sunset.jpg", UriKind.Relative);
            StreamResourceInfo ri = Application.GetContentStream(resourcePath);
            Stream data = ri.Stream;

            return data;
        }


        public ResourceDictionary GetResourceDictionary()
        {
            Uri resourcePath = new Uri("MyResources.xaml");
            ResourceDictionary rd = (ResourceDictionary)
                Application.LoadComponent(resourcePath);
            return rd;
        }
    }
}