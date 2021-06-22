using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Bons_Enet.Pages
{
    /// <summary>
    /// Interaction logic for LibraryPage.xaml
    /// </summary>
    public partial class LibraryPage : Page
    {
        ViewModel.GameViewModel gameViewModelObject = new ViewModel.GameViewModel();

        public LibraryPage()
        {
            InitializeComponent();
        }

        private void GameViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            gameViewModelObject.LoadStudents();
            GameViewControl.DataContext = gameViewModelObject;
        }

        public string UserName
        {
            get => (string)GetValue(UserNameProperty);
            set => SetValue(UserNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for UserName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserNameProperty =
            DependencyProperty.Register("UserName", typeof(string), typeof(LibraryPage));

        private void introLoadRefBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            o.Title = "Select the game's exe file or shortcut file (This does not support Steam files)";
            o.Filter = "Executable or Shortcut (*.exe, *.lnk) | *.exe";
            o.DereferenceLinks = true;
            if ((bool)o.ShowDialog() && o.DereferenceLinks == true)
            {
                Debug.WriteLine("o.FileName: " + o.FileName);

                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(o.FileName);

                gameViewModelObject.Games.Add(new Game { Title = myFileVersionInfo.FileDescription, Completed = false, ExePath = o.FileName, ImagePath = "562008-resident-evil-0-nintendo-switch-front-cover.jpg" });
            }
        }
    }
}