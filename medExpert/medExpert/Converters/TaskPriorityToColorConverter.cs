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
            AuditOperationStatus flag = (AuditOperationStatus)value;
            switch (flag)
            {
                case AuditOperationStatus.Created:
                    return "#3C63E7";
                case AuditOperationStatus.Executed:
                    return "#834EA0";
                case AuditOperationStatus.Running:
                    return "#3CBB78";
                case AuditOperationStatus.Signed:
                    return "#834EA0";
                case AuditOperationStatus.Signing:
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