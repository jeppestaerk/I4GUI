// Example 12-25. Window1.xaml.cs—switching skins code behind

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace SimpleSkin
{

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();

            EnsureSkins();

            chooseGreenSkin.Click += SkinChanged;
            chooseBlueSkin.Click += SkinChanged;
        }

        static ResourceDictionary greenSkin;
        static ResourceDictionary blueSkin;

        void EnsureSkins()
        {
            // this method is called each time a new Window1 is constructed,
            // so make sure we only load the resources the first time
            greenSkin = new ResourceDictionary();
            greenSkin.Source = new Uri("GreenSkin.xaml", UriKind.Relative);
            blueSkin = new ResourceDictionary();
            blueSkin.Source = new Uri("BlueSkin.xaml", UriKind.Relative);
        }

        void SkinChanged(object o, EventArgs e)
        {
            if (chooseGreenSkin.IsChecked.Value)
            {
                ApplySkin(greenSkin);
            }
            else
            {
                ApplySkin(blueSkin);
            }
        }

        void ApplySkin(ResourceDictionary newSkin)
        {
            Collection<ResourceDictionary> appMergedDictionaries =
                Application.Current.Resources.MergedDictionaries;

            // remove the old skins (MergedDictionary.Clear won't do the trick)
            if (appMergedDictionaries.Count != 0)
            {
                appMergedDictionaries.Remove(appMergedDictionaries[0]);
            }

            // add the new skin
            appMergedDictionaries.Add(newSkin);
        }
    }
}

// End of Example 12-25.
