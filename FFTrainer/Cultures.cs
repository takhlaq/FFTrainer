using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FFTrainer
{
    public class Cultures
    {
        public ICommand DialogCommand { get; private set; }
        public ICommand LanguageChangeCommand { get; private set; }

        public Cultures()
        {
            LanguageChangeCommand = new DelegateCommand((parameter) =>
            {
                var language = parameter as string;
                var dictionary = new ResourceDictionary();
                var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if ((bool)Properties.Settings.Default["FirstRun"] == true)Properties.Settings.Default["FirstRun"] = false;
                // Language Properties setting change
                Properties.Settings.Default.Language = language;
                Properties.Settings.Default.Save();

                // Current resource change
                language = string.IsNullOrEmpty(language) ? "English" : language;
                dictionary.Source = new Uri("/Resources/" + language + ".xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries[0] = dictionary;
                
                //Restart application.
                Process.Start(System.Windows.Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            });
        }
    }
}