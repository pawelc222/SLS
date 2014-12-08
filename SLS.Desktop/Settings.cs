using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLS.Desktop.Properties
{
    internal sealed partial class Settings
    {

        public Settings()
        {
            this.SettingChanging += this.SettingChangingEventHandler;
            this.PropertyChanged += OnPropertyChanged;
            this.SettingsLoaded += OnSettingsLoaded;
            this.SettingsSaving += this.SettingsSavingEventHandler;
        }

        private void OnSettingsLoaded(object sender, SettingsLoadedEventArgs settingsLoadedEventArgs)
        {

            Console.WriteLine("OnSettingsLoaded");
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            Console.WriteLine("OnPropertyChanged");

        }

        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            Console.WriteLine("SettingChangingEventHandler");

        }

        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Console.WriteLine("SettingsSavingEventHandler");

        }
    }
}
