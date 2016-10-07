using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;

namespace ColorConverter
{
	class ColorMultiConverter : IMultiValueConverter
	{
		#region IMultiValueConverter Members

		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			bool inverse = (parameter != null) && (string.Compare(parameter.ToString(), "inverse", true) == 0);

			byte R = System.Convert.ToByte((double)values[0]);
			byte G = System.Convert.ToByte((double)values[1]);
			byte B = System.Convert.ToByte((double)values[2]);

			Color newColor;
			if (inverse)
				newColor = Color.FromRgb((byte)(255 - R), (byte)(255 - G), (byte)(255 - B));
			else
				newColor = Color.FromRgb(R, G, B);

			return newColor;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			Color oldColor = (Color)value;
			double R = (double)oldColor.R;
			double G = (double)oldColor.G;
			double B = (double)oldColor.B;

			return new object[] { R, G, B };
		}

		#endregion
	}
}
