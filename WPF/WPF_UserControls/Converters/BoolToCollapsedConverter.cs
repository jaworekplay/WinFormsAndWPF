using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPF_UserControls.Converters
{
    public class BoolToCollapsedConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
            {
                if (b)
                {
                    return Visibility.Visible;
                }

                return Visibility.Collapsed;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}