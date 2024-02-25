using System;
using System.Globalization;

namespace Weather.UI.Converters
{
    public class DoubleToTemperatureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double temperature)
            {
                return $"{temperature}°c";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new object();
        }
    }

}
