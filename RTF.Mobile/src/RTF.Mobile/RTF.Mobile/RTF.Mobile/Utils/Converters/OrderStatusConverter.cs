using RTF.Mobile.Infrastructure.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace RTF.Mobile.Utils.Converters
{
    public class OrderStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (OrderStatus)value;
            if (status == OrderStatus.Accepted)
            {
                return "Принят";
            }
            if (status == OrderStatus.Cancelled)
            {
                return "Отменен";
            }
            if (status == OrderStatus.InProgress)
            {
                return "В обработке";
            }
            return "Ожидает в точке выдачи";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
