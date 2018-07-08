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
    /// Interaction logic for Culture.xaml
    /// </summary>
    /// //public partial class WeatherSelector : Window
    public partial class Culture : Window
    {
        public Culture()
        {
            InitializeComponent();
            DataContext = new Cultures();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
