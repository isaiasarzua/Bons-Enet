using Bons_Enet.CustomControls;
using Bons_Enet.Resources;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Bons_Enet.ViewModel
{
    public class GameViewModel
    {
        public ObservableCollection<Game> Games
        {
            get;
            set;
        }
        public void LoadStudents()
        {
            ObservableCollection<Game> loadedGames = new ObservableCollection<Game>();

            loadedGames.Add(new Game { Title = "Resident Evil 0", Completed = false, ImagePath = "562008-resident-evil-0-nintendo-switch-front-cover.jpg" });
            loadedGames.Add(new Game { Title = "Mount and Blade II", Completed = true, ImagePath = "MBIICover.jpg" });
            loadedGames.Add(new Game { Title = "Mortal Kombat 11", Completed = false, ImagePath = "Mk11Cover.jpg" });
            loadedGames.Add(new Game { Title = "Mount and Blade II", Completed = true, ImagePath = "MBIICover.jpg" });
            loadedGames.Add(new Game { Title = "Mortal Kombat 11", Completed = false, ImagePath = "Mk11Cover.jpg" });

            Games = loadedGames;
        }

        private Game selectedGame;
        public Game SelectedGame
        {
            get
            {
                return selectedGame;
            }
            set
            {
                //NotifyPropertyChanged("SelectedProperty");
                //value.StartGame();
                selectedGame = value;
            }
        }
    }
}