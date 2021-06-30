namespace Bons_Enet
{
    public class GameModel
    {
        string title;
        string exePath;
        bool completed;
        string coverImage;
        float timePlayed;

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

        public string CoverImage
        {
            get { return coverImage; }

            set
            {
                if (CoverImage != value)
                {
                    coverImage = value;
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
    }
}