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
            o.Title = "Select the game's exe file or shortcut file (Does not support Steam files)";
            o.Filter = "Executable or Shortcut (*.exe, *.lnk) | *.exe";
            o.DereferenceLinks = true;
            if ((bool)o.ShowDialog())
            {
                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(o.FileName);

                FileInfo file = new FileInfo(o.FileName);

                HTTPClient httpClient = new HTTPClient();
                GameModel newGame;

                // Search idgb using oroduct name, file description and target location
                if (httpClient.FoundGameInDB(myFileVersionInfo.ProductName, out newGame))
                {
                    newGame.ExePath = o.FileName;
                    gameViewModelObject.Games.Add(newGame);
                }
                else if (httpClient.FoundGameInDB(myFileVersionInfo.FileDescription, out newGame))
                {
                    newGame.ExePath = o.FileName;
                    gameViewModelObject.Games.Add(newGame);
                }
                else if (httpClient.FoundGameInDB(file.Directory.Name, out newGame)) //search using the name of the folder the exe is in (hoping that folders are organized by name)
                {
                    newGame.ExePath = o.FileName;
                    gameViewModelObject.Games.Add(newGame);
                }
                else if (httpClient.FoundGameInDB(file.Name, out newGame)) //as a last resort search using the name the exe/shortcut file
                {
                    newGame.ExePath = o.FileName;
                    gameViewModelObject.Games.Add(newGame);
                }
                else
                {
                    // future update: if game is not found in igdb, prompt user with a search box to manually enter title.
                    //if search box still does not find game, allow user to enter game title and art manually.
                    Debug.WriteLine("Could not find " + file.Name + " in idgb. Adding app information from given exe file");
                    newGame.Title = file.Name;
                    newGame.ExePath = o.FileName;

                    // -need to add a default cover image for when idgb is not available, maybe just use app icon as cover image ?
                    //newGame.CoverPath = Utils.ConvertIconToImageSource.ToImageSourceString(o.FileName); 
                    //newGame.CoverSource = Utils.ConvertIconToImageSource.ToImageSource(o.FileName);

                    gameViewModelObject.Games.Add(newGame);
                }
            }
        }
    }
}