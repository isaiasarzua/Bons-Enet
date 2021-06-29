using Microsoft.Win32;
using System;
using System.Diagnostics;
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
            gameViewModelObject.LoadGameLibrary();
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

        private void LoadGame_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            o.Title = "Select the game's exe file or shortcut file (This does not support Steam files)";
            o.Filter = "Executable or Shortcut (*.exe, *.lnk) | *.exe";
            o.DereferenceLinks = true;
            if ((bool)o.ShowDialog())
            {
                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(o.FileName);

                Debug.WriteLine(myFileVersionInfo.ProductName); //looks like product name will be good for searching with
                Debug.WriteLine(myFileVersionInfo.FileName);
                Debug.WriteLine(o.FileName);
                Debug.WriteLine(o.SafeFileName);

                HTTPClient httpClient = new HTTPClient();

                GameModel newGame;

                if (httpClient.FoundGameInDB("earth defense force 5", out newGame))
                {
                    gameViewModelObject.Games.Add(newGame);
                }

                //GameModel NewGame = httpClient.newGame();

                //NewGame.ExePath = o.FileName;

                //gameViewModelObject.Games.Add(NewGame);
            }
        }
    }
}