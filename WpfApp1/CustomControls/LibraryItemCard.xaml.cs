using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Bons_Enet.CustomControls
{
    /// <summary>
    /// Interaction logic for LibraryItemCard.xaml
    /// </summary>
    public partial class LibraryItemCard : UserControl
    {
        public LibraryItemCard()
        {
            InitializeComponent();
        }

        public ImageSource ImageSource
        {
            get => (ImageSource)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(LibraryItemCard));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(LibraryItemCard));



        public string ExePath
        {
            get => (string)GetValue(ExePathProperty);
            set => SetValue(ExePathProperty, value);
        }

        // Using a DependencyProperty as the backing store for exePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExePathProperty =
            DependencyProperty.Register("ExePath", typeof(string), typeof(LibraryItemCard));

        private void StartGame(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(Title);
            Debug.WriteLine(ExePath);

            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.FileName = ExePath;
            myProcess.Start();

            var window = (MainWindow)Application.Current.MainWindow;
            window.WindowState = WindowState.Minimized;
        }
    }
}