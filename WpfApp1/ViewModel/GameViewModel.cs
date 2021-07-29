using System.Collections.ObjectModel;

namespace Bons_Enet.ViewModel
{
    public class GameViewModel
    {
        public ObservableCollection<GameModel> Games { get; set; }

        public void LoadGameLibrary()
        {
            ObservableCollection<GameModel> loadedGames = new ObservableCollection<GameModel>();
            Games = loadedGames;
        }
    }
}