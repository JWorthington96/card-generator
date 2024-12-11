using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CardGenerator.Helpers;

/// <summary>
/// The image helpers.
/// </summary>
public static class ImageHelpers
{
    /// <summary>
    /// Get the byte array for an image.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <returns>An array of byte</returns>
    public static byte[] GetImageBytes(Image image)
    {
        using var stream = new MemoryStream();
        image.Save(stream, ImageFormat.Bmp);

        return stream.ToArray();
    }

    /// <summary>
    /// Get the bitmap source for an byte array.
    /// </summary>
    /// <param name="imageBytes">The image bytes.</param>
    /// <returns>A BitmapSource</returns>
    public static BitmapSource GetImageSource(byte[] imageBytes)
    {
        using var stream = new MemoryStream();
        stream.Write(imageBytes);

        return GetImageSource(Image.FromStream(stream));
    }

    /// <summary>
    /// Get the bitmap source for an image stream.
    /// </summary>
    /// <param name="myImage">The my image.</param>
    /// <returns>A BitmapSource</returns>
    public static BitmapSource GetImageSource(Image myImage)
    {
        var bitmap = new Bitmap(myImage);
        nint bmpPt = bitmap.GetHbitmap();
        BitmapSource bitmapSource =
         System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
               bmpPt,
               nint.Zero,
               Int32Rect.Empty,
               BitmapSizeOptions.FromEmptyOptions());

        //freeze bitmapSource and clear memory to avoid memory leaks
        bitmapSource.Freeze();
        DeleteObject(bmpPt);

        return bitmapSource;
    }

    /// <summary>
    /// Deletes an object in memory.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>True if it was deleted, false if not.</returns>
    [DllImport("gdi32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool DeleteObject(nint value);
}
