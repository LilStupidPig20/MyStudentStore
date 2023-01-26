using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace RTF.Mobile.Utils.Converters
{
    internal class EventTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isSocial = (bool)value;
            return isSocial ? new SolidColorBrush(Color.FromHex("#B7FFBA")) : new SolidColorBrush(Color.FromHex("#9FA3FF"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
