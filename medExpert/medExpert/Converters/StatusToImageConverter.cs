using medExpert.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace medExpert.Converters
{
    class StatusToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            AuditOperationStatus flag = (AuditOperationStatus)value;
            switch (flag)
            {
                case AuditOperationStatus.Created:
                    return "new_audits";
                case AuditOperationStatus.Executed:
                    return "audit_finished_green";
                case AuditOperationStatus.Running:
                    return "audit_running_yellow";
                case AuditOperationStatus.Signed:
                    return "audit_running_yellow";
                case AuditOperationStatus.Signing:
                    return "audit_running_yellow";
                default:
                    return "audit_new";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}