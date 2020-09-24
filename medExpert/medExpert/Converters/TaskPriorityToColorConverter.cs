using medExpert.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace medExpert.Converters
{
    public class TaskPriorityToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           Priority priority = (Priority)value;
            switch (priority)
            {
                case Priority.Low:
                    return "gray";
                case Priority.Medium:
                    return "green";
                case Priority.High:
                    return "red";
                case Priority.Urgent:
                    return "red";
                case Priority.Critical:
                    return "red";
                default:
                    return "white";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}