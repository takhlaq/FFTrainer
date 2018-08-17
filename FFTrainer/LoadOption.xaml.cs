using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FFTrainer
{
    /// <summary>
    /// Interaction logic for GearPicker.xaml
    /// </summary>
    public partial class LoadOption : Window
    {
        public string Choice = "";
        public LoadOption()
        {
            InitializeComponent();
        }

        private void ListBoxItem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            Choice = All.Name;
            Close();
        }

        private void ListBoxItem_MouseDoubleClick_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            Choice = App.Name;
            Close();
        }

        private void ListBoxItem_MouseDoubleClick_2(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Choice = Xuip.Name;
            Close();
        }

        private void All_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            e.Handled = true;
            Choice = All.Name;
            Close();
        }

        private void App_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            e.Handled = true;
            Choice = App.Name;
            Close();
        }

        private void Xuip_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            e.Handled = true;
            Choice = Xuip.Name;
            Close();
        }
    }
}