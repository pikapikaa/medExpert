using medExpert.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace medExpert.Converters
{
    public class TaskStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TaskStatus flag = (TaskStatus)value;
            switch (flag)
            {
                case TaskStatus.New:
                    return "#3960E2";
                case TaskStatus.Assigned:
                    return "#3CBB78";
                case TaskStatus.InProgress:
                    return "#3CBB78";
                case TaskStatus.Executed:
                    return "#834EA0";
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