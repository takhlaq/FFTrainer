using FFTrainer.Models;
using FFTrainer.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace FFTrainer.Views
{
    /// <summary>
    /// Interaction logic for CharacterDetailsView4.xaml
    /// </summary>
    public partial class CharacterDetailsView4 : UserControl
    {
        private ExdCsvReader _exdProvider = new ExdCsvReader();
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        public CharacterDetailsView4()
        {
            InitializeComponent();
            _exdProvider.MakeWeatherList();
            _exdProvider.MakeWeatherRateList();
            _exdProvider.MakeTerritoryTypeList();
            if(Properties.Settings.Default.UnlockedK == true)
            {
                HousingPlace.IsEnabled = true;
                HousingPlace.Visibility = Visibility.Visible;
            }
        }

        private void MaxZoom_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (MaxZoom.Value.HasValue && CharacterDetailsViewModel.NotAllowed == false)
                if (MaxZoom.IsMouseOver || MaxZoom.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Max), "float", MaxZoom.Value.ToString());
        }

        private void Min_Zoom_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (Min_Zoom.Value.HasValue && CharacterDetailsViewModel.NotAllowed == false)
                if (Min_Zoom.IsMouseOver || Min_Zoom.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Min), "float", Min_Zoom.Value.ToString());
        }

        private void CurrentZoom_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CurrentZoom.Value.HasValue && CharacterDetailsViewModel.NotAllowed == false)
                if (CurrentZoom.IsMouseOver || CurrentZoom.IsKeyboardFocusWithin || CZoom2.IsKeyboardFocusWithin||CZoom2.IsMouseOver)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CZoom), "float", CurrentZoom.Value.ToString());
        }

        private void CurrentFOV_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CurrentFOV.Value.HasValue)
                if (CurrentFOV.IsMouseOver || CurrentFOV.IsKeyboardFocusWithin || FOV1S.IsMouseOver ||FOV1S.IsKeyboardFocusWithin)
                {
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVC), "float", CurrentFOV.Value.ToString());
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVMAX), "float", CurrentFOV.Value.ToString());
                }
        }


        private void CameraHeight2_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CameraHeight2.Value.HasValue)
                if (CameraHeight2.IsMouseOver || CameraHeight2.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraHeight), "float", CameraHeight2.Value.ToString());
        }

        private void CamYMin_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CamYMin.Value.HasValue)
                if (CamYMin.IsMouseOver || CamYMin.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMin), "float", CamYMin.Value.ToString());
        }

        private void CamYMax_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CamYMax.Value.HasValue)
                if (CamYMax.IsMouseOver || CamYMax.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMax), "float", CamYMax.Value.ToString());
        }

        private void FOV2_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (FOV2.Value.HasValue)
                if (FOV2.IsMouseOver || FOV2.IsKeyboardFocusWithin || FOV2S.IsMouseOver||FOV2.IsKeyboardFocused)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOV2), "float", FOV2.Value.ToString());
        }
        private void CamUpDown_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CamUpDown.Value.HasValue)
                if (CamUpDown.IsMouseOver || CamUpDown.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraUpDown), "float", CamUpDown.Value.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int territory = MemoryManager.Instance.MemLib.readInt(MemoryManager.GetAddressString(MemoryManager.Instance.TerritoryAddress, Settings.Instance.Character.Territory));

            if (!_exdProvider.TerritoryTypes.ContainsKey(territory))
            {
                System.Windows.MessageBox.Show("Could not find your current zone. Make sure you are using the latest version.", "Oh no!");
                return;
            }

            if (_exdProvider.TerritoryTypes[territory].WeatherRate == null)
            {
                System.Windows.MessageBox.Show("Setting weather is not supported for your current zone.", "Oh no!");
                return;
            }

            var c = new WeatherSelector(_exdProvider.TerritoryTypes[territory].WeatherRate.AllowedWeathers, MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(MemoryManager.Instance.WeatherAddress, Settings.Instance.Character.Weather)));
            c.Owner = Application.Current.MainWindow;
            c.ShowDialog();

            if (c.Choice != null)
            {
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.WeatherAddress, Settings.Instance.Character.Weather), "byte", c.Choice.Index.ToString());
            }
        }

        private void Slider_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (Timexd.IsMouseOver || Timexd.IsKeyboardFocusWithin || Timexd.IsMouseDirectlyOver)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.TimeAddress, Settings.Instance.Character.TimeControl), "byte", Timexd.Value.ToString());
        }

        private void HousingPlace_Checked(object sender, RoutedEventArgs e)
        {
            if(HousingPlace.IsChecked==true)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.HousingOffset, "byte", "01");
        }

        private void Weather_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Weather.Value.HasValue)
                if (Weather.IsMouseOver || Weather.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.WeatherAddress, Settings.Instance.Character.Weather), "byte", Weather.Value.ToString());
        }

        private void HousingPlace_Unchecked(object sender, RoutedEventArgs e)
        {
           MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.HousingOffset, "byte", "00");
        }
    }
}