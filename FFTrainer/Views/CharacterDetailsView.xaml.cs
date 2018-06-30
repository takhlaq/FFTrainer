using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FFTrainer.Models;
using FFTrainer.ViewModels;
namespace FFTrainer.Views
{
    /// <summary>
    /// Interaction logic for CharacterDetailsView.xaml
    /// </summary>
    /// 
    public partial class CharacterDetailsView : UserControl
    {
        public CharacterDetailsView()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void BustZ_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (BustZ.IsMouseOver || BustZ.IsKeyboardFocusWithin || BustZ2.IsKeyboardFocusWithin || BustZ2.IsMouseOver)
                if (BustZ.Value > 0)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z), "float", BustZ.Value.ToString());
        }

        private void BustY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (BustY.IsMouseOver || BustY.IsKeyboardFocusWithin || BustY2.IsKeyboardFocusWithin || BustY2.IsMouseOver)
                if (BustY.Value > 0)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y), "float", BustY.Value.ToString());
        }

        private void BustX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (BustX.IsMouseOver || BustX.IsKeyboardFocusWithin || BustX2.IsKeyboardFocusWithin || BustX2.IsMouseOver)
                if (BustX.Value > 0)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "float", BustX.Value.ToString());
        }

        private void XPos_ValueChanged(object sender, EventArgs e)
        {
            if (XPos2.Value.HasValue)
                if (XPos.IsMouseOver || XPos.IsKeyboardFocusWithin || XPos2.IsKeyboardFocusWithin || XPos2.IsMouseOver)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.X), "float", XPos.Value.ToString());
        }

        private void Rotation1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Rot1.Value.HasValue)
                if (Rotation1.IsMouseOver || Rotation1.IsKeyboardFocusWithin || Rot1.IsKeyboardFocusWithin || Rot1.IsMouseOver)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation), "float", Rotation1.Value.ToString());
        }

        private void YPos_ValueChanged(object sender, EventArgs e)
        {
            if (YPos2.Value.HasValue)
                if (YPos.IsMouseOver || YPos.IsKeyboardFocusWithin || YPos2.IsKeyboardFocusWithin || YPos2.IsMouseOver)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Y), "float", YPos.Value.ToString());

        }

        private void ZPos_ValueChanged(object sender, EventArgs e)
        {
            if (Zpos2.Value.HasValue)
                if (ZPos.IsMouseOver || ZPos.IsKeyboardFocusWithin || Zpos2.IsKeyboardFocusWithin || Zpos2.IsMouseOver)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Z), "float", ZPos.Value.ToString());
        }

        private void Rotation2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Rot2.Value.HasValue)
                if (Rotation2.IsMouseOver || Rotation2.IsKeyboardFocusWithin || Rot2.IsKeyboardFocusWithin || Rot2.IsMouseOver)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation2), "float", Rotation2.Value.ToString());
        }

        private void Rotation3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Rot3.Value.HasValue)
                if (Rotation3.IsMouseOver || Rotation3.IsKeyboardFocusWithin || Rot3.IsKeyboardFocusWithin || Rot3.IsMouseOver)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation3), "float", Rotation3.Value.ToString());
        }

        private void Rotation4_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Rot4.Value.HasValue)
                if (Rotation4.IsMouseOver || Rotation4.IsKeyboardFocusWithin || Rot4.IsKeyboardFocusWithin || Rot4.IsMouseOver)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation4), "float", Rotation4.Value.ToString());
        }

        private void HeightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //   if (HeightSlider.IsMouseOver || HeightSlider.IsKeyboardFocusWithin || Height2x.IsKeyboardFocusWithin || Height2x.IsMouseOver)
            // if (HeightSlider.Value>=0.00001)MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Height), "float", HeightSlider.Value.ToString());
        }

        private void Height2x_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (Height2x.Value.HasValue)
                if (Height2x.IsMouseOver || Height2x.IsKeyboardFocusWithin || HeightSlider.IsKeyboardFocusWithin || HeightSlider.IsMouseOver)
                    if (Height2x.Value > 0) MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Height), "float", Height2x.Value.ToString());
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Highlights), "byte", "0");
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Highlights), "byte", "80");
        }

        private void CameraHeight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (CameraHeight.Value.HasValue)
                if (CameraHeight.IsMouseOver || CameraHeight.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CameraHeight), "float", CameraHeight.Value.ToString());
        }

        private void CamX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (CamX.Value.HasValue)
                if (CamX.IsMouseOver || CamX.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamX), "float", CamX.Value.ToString());
        }

        private void CamY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (CamY.Value.HasValue)
                if (CamY.IsMouseOver || CamY.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamY), "float", CamY.Value.ToString());
        }

        private void CamZ_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (CamZ.Value.HasValue)
                if (CamZ.IsMouseOver || CamZ.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamZ), "float", CamZ.Value.ToString());
        }

        private void MaxZoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (MaxZoom.Value.HasValue)
                if (MaxZoom.IsMouseOver || MaxZoom.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Max), "float", MaxZoom.Value.ToString());
        }

        private void Min_Zoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (Min_Zoom.Value.HasValue)
                if (Min_Zoom.IsMouseOver || Min_Zoom.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Min), "float", Min_Zoom.Value.ToString());
        }

        private void CurrentZoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (CurrentZoom.Value.HasValue)
                if (CurrentZoom.IsMouseOver || CurrentZoom.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CZoom), "float", CurrentZoom.Value.ToString());
        }

        private void CurrentFOV_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (CurrentFOV.Value.HasValue)
                if (CurrentFOV.IsMouseOver || CurrentFOV.IsKeyboardFocusWithin)
                {
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVC), "float", CurrentFOV.Value.ToString());
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVMAX), "float", CurrentFOV.Value.ToString());
                }
        }

        private void Muscletone_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (Muscletone.Value.HasValue)
                if (Muscletone.IsMouseOver || Muscletone.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.MuscleTone), "float", Muscletone.Value.ToString());
        }

        private void TailSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (TailSize.Value.HasValue)
                if (TailSize.IsMouseOver || TailSize.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.TailSize), "float", TailSize.Value.ToString());
        }

        private void CameraHeight2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (CameraHeight2.Value.HasValue)
                if (CameraHeight2.IsMouseOver || CameraHeight2.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraHeight), "float", CameraHeight2.Value.ToString());
        }

        private void CamYMin_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (CamYMin.Value.HasValue)
                if (CamYMin.IsMouseOver || CamYMin.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMin), "float", CamYMin.Value.ToString());
        }

        private void CamYMax_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (CamYMax.Value.HasValue)
                if (CamYMax.IsMouseOver || CamYMax.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMax), "float", CamYMax.Value.ToString());
        }

        private void FOV2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (FOV2.Value.HasValue)
                if (FOV2.IsMouseOver || FOV2.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOV2), "float", FOV2.Value.ToString());
        }

        private void HighlightTone_Copy5_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void HighlightTone_Copy4_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void HighlightTone_Copy3_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void HighlightTone_Copy2_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void HighlightTone_Copy1_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void HighlightTone_Copy_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void HighlightTone_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Hair_Color_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Head_Copy_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Head_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Head_Copy4_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Head_Copy3_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Head_Copy2_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Head_Copy1_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Voices_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void CamUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (CamUpDown.Value.HasValue)
                if (CamUpDown.IsMouseOver || CamUpDown.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraUpDown), "float", CamUpDown.Value.ToString());
        }

        private void HighlightTone_Copy6_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (EmoteBox.IsMouseOver)
                CharacterDetails.Emote.value = (int)EmoteBox.SelectedValue;
        }

        private void Emote_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (Emote.Value.HasValue)
                if (Emote.IsMouseOver || Emote.IsKeyboardFocusWithin)
                    CharacterDetails.EmoteX.value = (CharacterDetails.Emotes)Emote.Value;
        }
    }
}
