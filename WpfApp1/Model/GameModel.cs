namespace Bons_Enet
{
    public class GameModel
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

        public string ImagePath
        {
            get { return imagePath; }

            set
            {
                if (ImagePath != value)
                {
                    imagePath = value;
                }
            }
        }
    }
}