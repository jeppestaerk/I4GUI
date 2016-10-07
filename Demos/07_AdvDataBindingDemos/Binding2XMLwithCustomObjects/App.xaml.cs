using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using StoreDatabase;

namespace Binding2XMLwithCustomObjects
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static StoreDb storeDb = new StoreDb();
        public static StoreDb StoreDb
        {
            get { return storeDb; }
        }
    }
}
