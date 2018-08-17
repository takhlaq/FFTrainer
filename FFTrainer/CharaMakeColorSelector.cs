using FFTrainer.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFTrainer
{
    public partial class CharaMakeColorSelector : Form
    {
        private int _startIndex;

        public int Choice = -1;

        public CharaMakeColorSelector(CmpReader colorMap, int start, int length, int selection)
        {
            InitializeComponent();

            for (int i = start; i < start + length; i++)
            {
                var item = new ListViewItem((i - start).ToString());
                item.BackColor = colorMap.Colors[i];

                colorListView.Items.Add(item);
            }

            _startIndex = start;

            colorListView.SelectedIndices.Add(selection);
        }

        private void okButton_Click_1(object sender, EventArgs e)
        {
            if (colorListView.SelectedIndices.Count == 0)
            {
                MessageBox.Show("No selected color!");
                return;
            }

            Choice = colorListView.SelectedIndices[0];
            Close();
        }

        private void colorListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}