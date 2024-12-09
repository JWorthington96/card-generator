using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CardGenerator.Helpers;

public static class ImageHelpers
{
    public static byte[] GetImageBytes(Image image)
    {
        using var stream = new MemoryStream();
        image.Save(stream, ImageFormat.Bmp);

        return stream.ToArray();
    }

    public static BitmapSource GetImageStream(byte[] imageBytes)
    {
        using var stream = new MemoryStream();
        stream.Write(imageBytes);

        return GetImageStream(Image.FromStream(stream));
    }

    public static BitmapSource GetImageStream(Image myImage)
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

    [DllImport("gdi32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool DeleteObject(nint value);
}
