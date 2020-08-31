using medExpert.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace medExpert.Converters
{
    class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            AuditOperationStatus flag = (AuditOperationStatus)value;
            switch (flag)
            {
                case AuditOperationStatus.Created:
                    return "#3960E2";
                case AuditOperationStatus.Executed:
                    return "#00C395";
                case AuditOperationStatus.Running:
                    return "#FFB800";
                case AuditOperationStatus.Signed:
                    return "#FFB800";
                case AuditOperationStatus.Signing:
                    return "#FFB800";
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
