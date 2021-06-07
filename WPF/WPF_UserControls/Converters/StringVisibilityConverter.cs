using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WPF_UserControls.Converters
{
    public class StringVisibilityConverter : IMultiValueConverter
    {
        public const int TextIndex = 0, KeyboardFocusIndex = 1;
        public Visibility WhenEmpty { get; set; }
        public Visibility WhenNull { get; set; }
        public Visibility WhenNotNullOrEmpty { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine($"First parameter {values[TextIndex]}, Second parameter: {values[KeyboardFocusIndex]}");
            if (values[TextIndex] == null && values[KeyboardFocusIndex] == null)
            {
                return WhenNull;
            }
            if (values[TextIndex] is string s && !string.IsNullOrEmpty(s) || (values[KeyboardFocusIndex] is bool b && b))
            {
                Console.WriteLine($"keyboard focused Returning {WhenNotNullOrEmpty}");
                return WhenNotNullOrEmpty;
            }
            return WhenNull;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
