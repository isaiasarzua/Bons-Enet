using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Bons_Enet.Utils
{
    internal static class ConvertIconToImageSource
    {
        public static ImageSource ToImageSource(this Icon icon)
        {
            ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(
                 icon.Handle,
                 Int32Rect.Empty,
                 BitmapSizeOptions.FromEmptyOptions());

            return imageSource;
        }
        public static ImageSource ToImageSource(this string path)
        {
            Icon icon = Icon.ExtractAssociatedIcon(path);

            ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(
                 icon.Handle,
                 Int32Rect.Empty,
                 BitmapSizeOptions.FromEmptyOptions());

            return imageSource;
        }
        public static string ToImageSource(this string path)
        {
            Icon icon = Icon.ExtractAssociatedIcon(path);

            ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(
                 icon.Handle,
                 Int32Rect.Empty,
                 BitmapSizeOptions.FromEmptyOptions());

            BitmapImage test = (BitmapImage)imageSource;

            return test.UriSource;
        }
    }
}