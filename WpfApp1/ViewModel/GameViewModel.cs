using System.Collections.ObjectModel;

namespace Bons_Enet.ViewModel
{
    public class GameViewModel
    {
        public ObservableCollection<GameModel> Games
        {
            get;
            set;
        }

        public void LoadGameLibrary()
        {
            ObservableCollection<GameModel> loadedGames = new ObservableCollection<GameModel>();

            loadedGames.Add(new GameModel { Title = "Mount and Blade II", Completed = true, CoverImage = "MBIICover.jpg", TimePlayed = 0 });
            loadedGames.Add(new GameModel { Title = "Mortal Kombat 11", Completed = false, CoverImage = "Mk11Cover.jpg", TimePlayed = 0 });

            Games = loadedGames;
        }
    }
}