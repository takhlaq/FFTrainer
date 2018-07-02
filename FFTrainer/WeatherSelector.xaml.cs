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
    /// Interaction logic for WeatherSelector.xaml
    /// </summary>
    public partial class WeatherSelector : Window
    {
        public ExdCsvReader.Weather Choice = null;

        private readonly List<ExdCsvReader.Weather> AllowedWeathers;

        public WeatherSelector(List<ExdCsvReader.Weather> allowedWeathers, int currentWeather)
        {
            InitializeComponent();

            AllowedWeathers = allowedWeathers;

            for (int i = 0; i < allowedWeathers.Count; i++)
            {
                comboBox.Items.Add(allowedWeathers[i].Name);

                if (allowedWeathers[i].Index == currentWeather)
                    comboBox.SelectedIndex = i;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Choice = AllowedWeathers[comboBox.SelectedIndex];
            Close();
        }
    }
}
