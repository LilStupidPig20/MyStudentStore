using System;
using System.Globalization;
using Xamarin.Forms;

namespace RTF.Mobile.Utils.Converters
{
    class UpDownEnabiltyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var count = (int)value;
            return count > 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
