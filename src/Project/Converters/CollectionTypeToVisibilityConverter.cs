using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Project.Converters
{
    public class CollectionTypeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string currentType = value as string;
            string expectedType = parameter as string;

            return currentType == expectedType ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}