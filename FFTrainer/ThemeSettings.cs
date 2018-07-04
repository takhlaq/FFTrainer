using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro;

namespace FFTrainer
{
    public class ThemeSettings
    {

        public AppTheme AppTheme { get; set; }
        public Accent Accent { get; set; }

        public static ThemeSettings Load()
        {
            var appTheme = ThemeManager.GetAppTheme(Properties.Settings.Default.AppThemeName);
            var accent = ThemeManager.GetAccent(Properties.Settings.Default.Accent);
            var settings = new ThemeSettings
            {
                Accent = accent,
                AppTheme = appTheme,
            };
            return settings;
        }

        public void Save()
        {
            Properties.Settings.Default.Accent = Accent.Name;
            Properties.Settings.Default.AppThemeName = AppTheme.Name;
            Properties.Settings.Default.Save();
        }

    }

}
