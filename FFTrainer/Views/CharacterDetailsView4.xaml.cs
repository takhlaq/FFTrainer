using FFTrainer.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FFTrainer.Views
{
    /// <summary>
    /// Interaction logic for CharacterDetailsView4.xaml
    /// </summary>
    public partial class CharacterDetailsView4 : UserControl
    {
        public CharacterDetailsView4()
        {
            InitializeComponent();
        }

        private void MaxZoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (MaxZoom.Value.HasValue)
                if (MaxZoom.IsMouseOver || MaxZoom.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Max), "float", MaxZoom.Value.ToString());
        }

        private void Min_Zoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Min_Zoom.Value.HasValue)
                if (Min_Zoom.IsMouseOver || Min_Zoom.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Min), "float", Min_Zoom.Value.ToString());
        }

        private void CurrentZoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CurrentZoom.Value.HasValue)
                if (CurrentZoom.IsMouseOver || CurrentZoom.IsKeyboardFocusWithin || CZoom2.IsKeyboardFocusWithin||CZoom2.IsMouseOver)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CZoom), "float", CurrentZoom.Value.ToString());
        }

        private void CurrentFOV_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CurrentFOV.Value.HasValue)
                if (CurrentFOV.IsMouseOver || CurrentFOV.IsKeyboardFocusWithin || FOV1S.IsMouseOver ||FOV1S.IsKeyboardFocusWithin)
                {
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVC), "float", CurrentFOV.Value.ToString());
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVMAX), "float", CurrentFOV.Value.ToString());
                }
        }


        private void CameraHeight2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CameraHeight2.Value.HasValue)
                if (CameraHeight2.IsMouseOver || CameraHeight2.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraHeight), "float", CameraHeight2.Value.ToString());
        }

        private void CamYMin_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamYMin.Value.HasValue)
                if (CamYMin.IsMouseOver || CamYMin.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMin), "float", CamYMin.Value.ToString());
        }

        private void CamYMax_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamYMax.Value.HasValue)
                if (CamYMax.IsMouseOver || CamYMax.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMax), "float", CamYMax.Value.ToString());
        }

        private void FOV2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (FOV2.Value.HasValue)
                if (FOV2.IsMouseOver || FOV2.IsKeyboardFocusWithin || FOV2S.IsMouseOver||FOV2.IsKeyboardFocused)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOV2), "float", FOV2.Value.ToString());
        }
        private void CamUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamUpDown.Value.HasValue)
                if (CamUpDown.IsMouseOver || CamUpDown.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraUpDown), "float", CamUpDown.Value.ToString());
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Timexd.IsMouseOver || Timexd.IsKeyboardFocusWithin||Timexd.IsMouseDirectlyOver)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.TimeAddress, Settings.Instance.Character.TimeControl), "byte", Timexd.Value.ToString());
        }


        private void NumericUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Weather.IsMouseOver || Weather.IsKeyboardFocusWithin)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.WeatherAddress, Settings.Instance.Character.Weather), "byte", Weather.Value.ToString());
        }
    }
}
