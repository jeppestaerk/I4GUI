using System;
using System.Windows.Data;

namespace ProcessMonitorSortInCs
{
    public class IsLargeValueConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            Int64 convertedValue = System.Convert.ToInt64(value);
            Int64 threshold = 10000000;

            if (parameter != null)
                threshold = System.Convert.ToInt64(parameter);

            if (convertedValue > threshold)
                return true;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}