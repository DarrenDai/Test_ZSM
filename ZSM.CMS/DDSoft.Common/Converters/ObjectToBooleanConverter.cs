using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DDSoft.Common.Converters
{
    /// <summary>
    /// Used for is enabled depending on a object
    /// </summary>
    [ValueConversion(typeof(object), typeof(Boolean))]
    public class ObjectToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? false : true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? new object() : null;
        }
    }
}

