using System.ComponentModel;
using SLS.Desktop.Properties;

namespace SLS.Desktop.Preferences
{
    public class SettingsModel : Observable
    {
        private static Settings Settings
        {
            get { return Settings.Default; }
        }

        [Category("Environment|General")]
        public string ProjectPath
        {
            get { return Settings.ProjectPath; }
            set
            {
                Settings.ProjectPath = value;
                OnPropertyChanged("ProjectPath");
            }
        }

        [Category("Environment|General")]
        public int UndoLevels
        {
            get { return Settings.UndoLevels; }
            set
            {
                Settings.UndoLevels = value;
                OnPropertyChanged("UndoLevels");
            }
        }

        [Category("Environment|Menus")]
        public int WindowMenuItems
        {
            get { return Settings.WindowMenuItems; }
            set
            {
                Settings.WindowMenuItems = value;
                OnPropertyChanged("WindowMenuItems");
            }
        }

        [Category("Environment|Menus")]
        public int MostRecentlyUsedItems
        {
            get { return Settings.MostRecentlyUsedItems; }
            set
            {
                Settings.MostRecentlyUsedItems = value;
                OnPropertyChanged("MostRecentlyUsedItems");
            }
        }

        [Category("Startup|Actions")]
        public bool ShowStartPage
        {
            get { return Settings.ShowStartPage; }
            set
            {
                Settings.ShowStartPage = value;
                OnPropertyChanged("ShowStartPage");
            }
        }

        [Category("Startup|News channel")]
        public string NewsChannel
        {
            get { return Settings.NewsChannel; }
            set
            {
                Settings.NewsChannel = value;
                OnPropertyChanged("NewsChannel");
            }
        }

        public void Save()
        {
            Settings.Save();
        }
    }
}
