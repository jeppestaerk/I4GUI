using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace NumberConverter
{
    class DateTimeValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime dt = (DateTime)value;
            if (parameter != null)
            {
                string s = parameter as string;
                if (s != null)
                    return dt.ToString(s);
                else
                    return dt.ToString();
            }
            else
                return dt.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
