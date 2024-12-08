using System;
using System.Globalization;
using System.Windows.Data;
using DrinkingBuddy.Helpers;

namespace DrinkingBuddy.Converters
{
    public class BytesToBitmapSourceConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not byte[] bValue) return null;

            return ImageHelpers.GetImageStream(bValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
