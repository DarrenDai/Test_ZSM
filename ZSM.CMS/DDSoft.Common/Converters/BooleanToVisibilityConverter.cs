using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DDSoft.Common.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (((value is bool) && ((bool)value)) ? Visibility.Visible : Visibility.Collapsed);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (!(value is Visibility) ? ((object)0) : ((object)(((Visibility)value) == Visibility.Visible)));
        }
    }
}

