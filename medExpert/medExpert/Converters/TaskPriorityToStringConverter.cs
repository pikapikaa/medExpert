using medExpert.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace medExpert.Converters
{
    public class TaskPriorityToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            Priority priority = (Priority)value;
            switch (priority)
            {
                case Priority.Low:
                    return "Низкий";
                case Priority.Medium:
                    return "Средний";
                case Priority.High:
                    return "Высокий";
                case Priority.Urgent:
                    return "Срочный";
                case Priority.Critical:
                    return "Критический";
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