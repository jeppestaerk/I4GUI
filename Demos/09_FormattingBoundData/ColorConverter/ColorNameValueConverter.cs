using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Windows.Media;
using System.Reflection;

namespace ColorConverter
{
	class ColorNameValueConverter : IValueConverter
	{
		//private List<Color> namedColors = new List<Color>();
		private Dictionary<Color, string> namedColors = new Dictionary<Color, string>();

		public ColorNameValueConverter()
		{
			PropertyInfo[] colorProperties = typeof(Colors).GetProperties(BindingFlags.Static | BindingFlags.Public);
			Color stepColor;
			foreach (PropertyInfo pi in colorProperties)
			{
				if (pi.PropertyType == typeof(Color))
				{
					stepColor = (Color)pi.GetValue(null, null);
					namedColors[stepColor] = pi.Name;
				}
			}

		}

		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Color col = (Color)value;

			if(namedColors.ContainsKey(col))
				return namedColors[col];

			return DependencyProperty.UnsetValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
