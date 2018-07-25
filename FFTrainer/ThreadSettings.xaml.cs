using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FFTrainer
{
    /// <summary>
    /// Interaction logic for ThreadSettings.xaml
    /// </summary>
    public partial class ThreadSettings : Window
    {
        public ThreadSettings()
        {
            InitializeComponent();
            WriteText.Value = Properties.Settings.Default.Write;
            ReadText.Value = Properties.Settings.Default.Read;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Write = (int)WriteText.Value;
            Properties.Settings.Default.Read = (int)ReadText.Value;
            Properties.Settings.Default.Save();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Write = 10;
            Properties.Settings.Default.Read = 500;
            Properties.Settings.Default.Save();
            WriteText.Value = 10;
            ReadText.Value = 500;
        }
    }
}