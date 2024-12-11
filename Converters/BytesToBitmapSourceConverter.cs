using System;
using System.Globalization;
using System.Windows.Data;
using CardGenerator.Helpers;

namespace CardGenerator.Converters;

/// <summary>
///     Converter for converting a byte array into a BitmapSource for displaying images.
/// </summary>
public class BytesToBitmapSourceConverter : IValueConverter
{
    /// <inheritdoc />
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not byte[] bValue) return null;

        return ImageHelpers.GetImageSource(bValue);
    }

    /// <inheritdoc />
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
