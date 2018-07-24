using FFTrainer.Views;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ResidentSelector.xaml
    /// </summary>
    public partial class ResidentSelector : Window
    {
        private ExdCsvReader.Resident[] _residents;
        public ExdCsvReader.Resident Choice = null;
        public class Residentxd
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public GearSet Gear { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        public ResidentSelector(ExdCsvReader.Resident[] residents)
        {
            InitializeComponent();
            _residents = residents;
            foreach (ExdCsvReader.Resident resident in _residents) residentlist.Items.Add(resident);


            _residents = residents;
            }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (residentlist.SelectedItem == null)
                Close();
            Choice = residentlist.SelectedItem as ExdCsvReader.Resident;
            Close();
        }

        private void textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = textbox.Text.ToLower();
            residentlist.Items.Clear();
            foreach (ExdCsvReader.Resident resident in _residents.Where(g => g.Name.ToLower().Contains(filter))) residentlist.Items.Add(resident);
        }
    }
}
