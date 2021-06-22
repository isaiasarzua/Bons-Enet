using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Media;

namespace Bons_Enet
{
    public class GameModel { }

    public class Game : INotifyPropertyChanged
    {
        string title;
        string exePath;
        bool completed;
        string imagePath;
        float timePlayed;

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                if (title != value)
                {
                    title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }

        public bool Completed
        {
            get { return completed; }

            set
            {
                if (completed != value)
                {
                    completed = value;
                    RaisePropertyChanged("Completed");
                }
            }
        }

        public string ExePath
        {
            get { return exePath; }

            set
            {
                if (exePath != value)
                {
                    exePath = value;
                    RaisePropertyChanged("ExePath");
                }
            }
        }

        public string ImagePath
        {
            get { return imagePath; }

            set
            {
                if (ImagePath != value)
                {
                    imagePath = "../Resources/" + value;
                    RaisePropertyChanged("LastName");
                    RaisePropertyChanged("FullName");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}