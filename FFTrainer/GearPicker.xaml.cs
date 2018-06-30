using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FFTrainer
{
    /// <summary>
    /// Interaction logic for GearPicker.xaml
    /// </summary>
    public partial class GearPicker : Window
    {
        public ExdCsvReader.Item[] _items;

        public ExdCsvReader.Item Choice = null;

        public GearPicker(ExdCsvReader.Item[] items)
        {
            InitializeComponent();

            _items = items;
            foreach (ExdCsvReader.Item game in _items) listBox1.Items.Add(game);
        }
        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = searchTextBox.Text.ToLower();
            listBox1.Items.Clear();
            foreach (ExdCsvReader.Item game in _items.Where(g => g.Name.ToLower().Contains(filter))) listBox1.Items.Add(game);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;

            Choice = listBox1.SelectedItem as ExdCsvReader.Item;
            Close();
        }
    }
}