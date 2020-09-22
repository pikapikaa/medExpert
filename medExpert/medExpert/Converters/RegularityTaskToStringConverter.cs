using medExpert.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace medExpert.Converters
{
    public class RegularityTaskToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            Regularity regularity = (Regularity)value;
            switch (regularity)
            {
                case Regularity.Daily:
                    return "Ежедневно";
                case Regularity.Weekly:
                    return "Еженедельно";
                case Regularity.Monthly:
                    return "Ежемесячно";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}