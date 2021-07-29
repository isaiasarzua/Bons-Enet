using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

        public BitmapImage CoverImage
        {
            //get => if (CoverPath != value) new BitmapImage(new Uri(CoverPath, UriKind.Absolute));

            //get
            //{
            //    if (CoverPath != null)
            //    {
            //        BitmapImage img = new BitmapImage(new Uri(CoverPath, UriKind.Absolute));
            //        return img;
            //    }
            //    else
            //        return null;
            //}

            get => CoverPath != null ? new BitmapImage(new Uri(CoverPath, UriKind.Absolute)) : null;
        }
    }
}