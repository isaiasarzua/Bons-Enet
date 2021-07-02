using System.Windows.Media;

namespace Bons_Enet
{
    public class GameModel
    {
        string title;
        string exePath;
        bool completed;
        string coverPath;
        float timePlayed;
        ImageSource coverSource;

        public string Title
        {
            get { return title; }

            set
            {
                if (title != value)
                {
                    title = value;
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
                }
            }
        }

        public string CoverPath
        {
            get { return coverPath; }

            set
            {
                if (CoverPath != value)
                {
                    coverPath = value;
                }
            }
        }

        public float TimePlayed
        {
            get { return timePlayed; }

            set
            {
                if (TimePlayed != value)
                {
                    timePlayed = value;
                }
            }
        }

        public ImageSource CoverSource
        {
            get { return coverSource; }

            set
            {
                if (coverSource != value)
                {
                    coverSource = value;
                }
            }
        }
    }
}