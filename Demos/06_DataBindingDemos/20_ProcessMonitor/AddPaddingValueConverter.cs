using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ProcessMonitor
{
    public class AddPaddingValueConverter : IValueConverter
    {
        public AddPaddingValueConverter() { }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double d = System.Convert.ToDouble(value);
            return d + 20;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double d = System.Convert.ToDouble(value);
            return d - 20;
        }
    }
}
