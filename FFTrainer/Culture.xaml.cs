using System.Windows;

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
