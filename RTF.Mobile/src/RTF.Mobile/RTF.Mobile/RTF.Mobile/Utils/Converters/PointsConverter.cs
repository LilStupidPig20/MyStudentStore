using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace RTF.Mobile.Utils.Converters
{
    internal class PointsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var points = (int)value;
            return $"{points} балл{GetEnding(points)}";
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static string GetEnding(int number)
        {
            var remainder = number % 10;
            if (remainder == 0 || remainder >= 5) 
            {
                return "ов";
            }
            if (remainder == 1)
            {
                return string.Empty;
            }
            return "a";
        }
    }
}
