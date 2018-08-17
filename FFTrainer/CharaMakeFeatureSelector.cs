using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFTrainer
{
    public partial class CharaMakeFeatureSelector : Form
    {
        private ExdCsvReader _reader;
        private int _tribe;
        private int _gender;

        public ExdCsvReader.CharaMakeCustomizeFeature Choice = null;

        // TODO: Make this usable for all features and not just hair
        public CharaMakeFeatureSelector(int tribe, int gender, ExdCsvReader reader)
        {
            InitializeComponent();

            _tribe = tribe;
            _gender = gender;
            _reader = reader;

            var feature = new ExdCsvReader().GetCharaMakeCustomizeFeature(855, true);

            Debug.WriteLine(feature);

            var col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "ID";
            col1.Name = "ID";

            var col2 = new DataGridViewImageColumn();
            col2.HeaderText = "Icon";
            col2.Name = "Icon";
            col2.ImageLayout = DataGridViewImageCellLayout.Zoom;

            featureGridView.Columns.Add(col1);
            featureGridView.Columns.Add(col2);

            FillHairStyles();
        }

        // Many thanks to Clorifex for this and GetFeature
        int GetHairstyleCustomizeIndex(int tribeKey, bool isMale)
        {
            switch (tribeKey)
            {
                case 1: // Midlander
                    return isMale ? 0 : 100;
                case 2: // Highlander
                    return isMale ? 200 : 300;
                case 3: // Wildwood
                case 4: // Duskwight
                    return isMale ? 400 : 500;
                case 5: // Plainsfolks
                case 6: // Dunesfolk
                    return isMale ? 600 : 700;
                case 7: // Seeker of the Sun
                case 8: // Keeper of the Moon
                    return isMale ? 800 : 900;
                case 9: // Sea Wolf
                case 10: // Hellsguard
                    return isMale ? 1000 : 1100;
                case 11: // Raen
                case 12: // Xaela
                    return isMale ? 1200 : 1300;
            }

            throw new NotImplementedException();
        }

        ExdCsvReader.CharaMakeCustomizeFeature GetFeature(int startIndex, int length, byte dataKey)
        {
            if (dataKey == 0)
                return null; // Custom or not specified.

            for (var i = 1; i < length; i++)
            {
                Debug.WriteLine(startIndex + i);
                var feature = _reader.CharaMakeFeatures[startIndex + i];

                if (feature.FeatureID == dataKey)
                {
                    return feature;
                }
            }

            return null; // Not found - custom.
        }

        private void FillHairStyles()
        {
            int added = 0;
            for (int i = 0; i < 200; i++)
            {
                var feature = GetFeature(GetHairstyleCustomizeIndex(_tribe, _gender == 0), 100, (byte)i);

                if (feature == null)
                    continue;

                featureGridView.Rows.Add(new object[] { feature.FeatureID, feature.Icon });
                featureGridView.Rows[added].Height = 100;
                added++;
            }
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okButton_Click_1(object sender, EventArgs e)
        {
            if (featureGridView.SelectedCells.Count == 0)
                Close();

            var cell =
                featureGridView.Rows[featureGridView.SelectedCells[0].RowIndex].Cells[0] as DataGridViewTextBoxCell;

            var value = cell.Value;

            Choice = GetFeature(GetHairstyleCustomizeIndex(_tribe, _gender == 0), 100,
                byte.Parse(value.ToString()));

            Close();
        }

        private void cancelButton_Click_1(object sender, EventArgs e)
        {

        }
    }
}
