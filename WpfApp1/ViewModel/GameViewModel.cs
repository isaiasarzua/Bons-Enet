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

            //loadedGames.Add(new GameModel { Title = "Resident Evil 0", Completed = false });
            loadedGames.Add(new GameModel { Title = "Mount and Blade II", Completed = true, ImagePath = "MBIICover.jpg" });
            loadedGames.Add(new GameModel { Title = "Mortal Kombat 11", Completed = false, ImagePath = "Mk11Cover.jpg" });
            loadedGames.Add(new GameModel { Title = "Mount and Blade II", Completed = true, ImagePath = "MBIICover.jpg" });
            loadedGames.Add(new GameModel { Title = "Mortal Kombat 11", Completed = false, ImagePath = "Mk11Cover.jpg" });

            Games = loadedGames;
        }
    }
}