using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
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
        private ExdCsvReader _exdProvider = new ExdCsvReader();
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        public CharacterDetailsView()
        {
            InitializeComponent();
            _exdProvider.RaceList();
            _exdProvider.TribeList();
            DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(20)};
            timer.Tick += delegate
            {
                for (int i = 0; i < _exdProvider.Races.Count; i++)
                {
                    RaceBox.Items.Add(_exdProvider.Races[i].Name);

                    if (_exdProvider.Races[i].Index == MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Race)))
                        RaceBox.SelectedIndex = i;
                }
                for (int i = 0; i < _exdProvider.Tribes.Count; i++)
                {
                    ClanBox.Items.Add(_exdProvider.Tribes[i].Name);
                    if (_exdProvider.Tribes[i].Index == MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Clan)))
                        ClanBox.SelectedIndex = i;
                }
                timer.IsEnabled = false;
            };
            timer.Start();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        private void Height2x_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
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

        private void CameraHeight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CameraHeight.Value.HasValue)
                if (CameraHeight.IsMouseOver || CameraHeight.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CameraHeight), "float", CameraHeight.Value.ToString());
        }

        private void CamX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamX.Value.HasValue)
                if (CamX.IsMouseOver || CamX.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamX), "float", CamX.Value.ToString());
        }

        private void CamY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamY.Value.HasValue)
                if (CamY.IsMouseOver || CamY.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamY), "float", CamY.Value.ToString());
        }

        private void CamZ_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamZ.Value.HasValue)
                if (CamZ.IsMouseOver || CamZ.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamZ), "float", CamZ.Value.ToString());
        }
        
        private void Muscletone_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Muscletone.Value.HasValue)
                if (Muscletone.IsMouseOver || Muscletone.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.MuscleTone), "float", Muscletone.Value.ToString());
        }

        private void TailSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (TailSize.Value.HasValue)
                if (TailSize.IsMouseOver || TailSize.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.TailSize), "float", TailSize.Value.ToString());
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

        private void HighlightTone_Copy6_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (EmoteBox.IsMouseOver)
                if(EmoteBox.SelectedValue!=null&&(int)EmoteBox.SelectedValue>=1)
                    CharacterDetails.Emote.value = (int)EmoteBox.SelectedValue;
        }

        private void Emote_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Emote.Value.HasValue)
                if (Emote.IsMouseOver || Emote.IsKeyboardFocusWithin)
                    CharacterDetails.EmoteX.value = (CharacterDetails.Emotes)Emote.Value;
        }

        private void AddBust_Click(object sender, RoutedEventArgs e)
        {
            CharacterDetails.BustX.value += (float)0.0016;
            CharacterDetails.BustY.value += (float)0.004;
            CharacterDetails.BustZ.value += (float)0.00368;
            var bustx = CharacterDetails.BustX.value;
            var busty = CharacterDetails.BustY.value;
            var bustz = CharacterDetails.BustZ.value;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z), "float", bustz.ToString());
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y), "float", busty.ToString());
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "float", bustx.ToString());
        }

        private void MinusBust_Click(object sender, RoutedEventArgs e)
        {
            CharacterDetails.BustX.value -= (float)0.0016;
            CharacterDetails.BustY.value -= (float)0.004;
            CharacterDetails.BustZ.value -= (float)0.00368;
            var bustx = CharacterDetails.BustX.value;
            var busty = CharacterDetails.BustY.value;
            var bustz = CharacterDetails.BustZ.value;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z), "float", bustz.ToString());
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y), "float", busty.ToString());
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "float", bustx.ToString());
        }


        private void BustSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BustSelect.SelectedIndex == 0)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "1F 85 6B 3F CD CC 4C 3F 60 E5 50 3F");
            if (BustSelect.SelectedIndex == 1)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "B2 9D 6F 3F 3D 0A 57 3F 1A 51 5A 3F");
            if (BustSelect.SelectedIndex == 2)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "46 B6 73 3F AE 47 61 3F 12 BE 63 3F");
            if (BustSelect.SelectedIndex == 3)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "D9 CE 77 3F 1F 85 6B 3F DC 29 6D 3F");
            if (BustSelect.SelectedIndex == 4)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "6D E7 7B 3F 8F C2 75 3F 3E 96 76 3F");
            if (BustSelect.SelectedIndex == 5)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "00 00 80 3F 00 00 80 3F 00 00 80 3F");
            if (BustSelect.SelectedIndex == 6)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "4A 0C 82 3F B8 1E 85 3F D3 B7 84 3F");
            if (BustSelect.SelectedIndex == 7)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "93 18 84 3F 71 3D 8A 3F 04 6E 89 3F");
            if (BustSelect.SelectedIndex == 8)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "DD 24 86 3F 29 5C 8F 3F 35 24 8E 3F");
            if (BustSelect.SelectedIndex == 9)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "27 31 88 3F E1 7A 94 3F 65 DA 92 3F");
            if (BustSelect.SelectedIndex == 10)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "71 3D 8A 3F 9A 99 99 3F 50 8D 97 3F");
            if (BustSelect.SelectedIndex == 11)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "29 5C 8F 3F 66 66 A6 3F 10 58 A3 3F");
            if (BustSelect.SelectedIndex == 12)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "E1 7A 94 3F 33 33 B3 3F A0 1A AF 3F");
            if (BustSelect.SelectedIndex == 13)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "9A 99 99 3F 00 00 C0 3F 04 E7 BA 3F");
            if (BustSelect.SelectedIndex == 14)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "52 B8 9E 3F CD CC CC 3F 7D AE C6 3F");
            if (BustSelect.SelectedIndex == 15)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "0A D7 A3 3F 9A 99 D9 3F F7 75 D2 3F");
            if (BustSelect.SelectedIndex == 16)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "C3 F5 A8 3F 66 66 E6 3F 71 3D DE 3F");
            if (BustSelect.SelectedIndex == 17)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "7B 14 AE 3F 33 33 F3 3F EA 04 EA 3F");
            if (BustSelect.SelectedIndex == 18)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "33 33 B3 3F 00 00 00 40 64 CC F5 3F");
            if (BustSelect.SelectedIndex == 19)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "CD CC CC 3F 00 00 20 40 E2 58 18 40");
            if (BustSelect.SelectedIndex == 20)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "bytes", "66 66 E6 3F 00 00 40 40 92 CB 35 40");
        }

        private void BustX2_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BustX.IsMouseOver || BustX.IsKeyboardFocusWithin || BustX2.IsKeyboardFocusWithin || BustX2.IsMouseOver || AddBust.IsMouseOver)
                if (BustX.Value > 0)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "float", BustX.Value.ToString());
        }

        private void BustY2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BustY.IsMouseOver || BustY.IsKeyboardFocusWithin || BustY2.IsKeyboardFocusWithin || BustY2.IsMouseOver || AddBust.IsMouseOver)
                if (BustY.Value > 0)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y), "float", BustY.Value.ToString());
        }

        private void BustZ2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BustZ.IsMouseOver || BustZ.IsKeyboardFocusWithin || BustZ2.IsKeyboardFocusWithin || BustZ2.IsMouseOver || AddBust.IsMouseOver)
                if (BustZ.Value > 0)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z), "float", BustZ.Value.ToString());
        }

        private void HighlightTone_Copy7_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void HeightReal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void BustReal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void JawType_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Namexd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        { }

        public void LoadingUpXd()
        {
            for (int i = 0; i < _exdProvider.Races.Count; i++)
            {
                RaceBox.Items.Add(_exdProvider.Races[i].Name);

                if (_exdProvider.Races[i].Index == MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Race)))
                    RaceBox.SelectedIndex = i;
            }
            for (int i = 0; i < _exdProvider.Tribes.Count; i++)
            {
                ClanBox.Items.Add(_exdProvider.Tribes[i].Name);
                if (_exdProvider.Tribes[i].Index == MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Clan)))
                    ClanBox.SelectedIndex = i;
            }
        }

        private void Unfreeze_Click(object sender, RoutedEventArgs e)
        {
            CharacterDetails.TimeControl.freeze = false;
            CharacterDetails.Weather.freeze = false;
            CharacterDetails.CZoom.freeze = false;
            CharacterDetails.CameraYAMax.freeze = false;
            CharacterDetails.FOVC.freeze = false;
            CharacterDetails.CameraHeight2.freeze = false;
            CharacterDetails.CameraUpDown.freeze = false;
            CharacterDetails.CameraYAMin.freeze = false;
            CharacterDetails.CameraYAMax.freeze = false;
            CharacterDetails.Min.freeze = false;
            CharacterDetails.FOVMAX.freeze = false;
            CharacterDetails.Max.freeze = false;
            CharacterDetails.CamZ.freeze = false;
            CharacterDetails.CamY.freeze = false;
            CharacterDetails.CamX.freeze = false;
            CharacterDetails.CameraHeight.freeze = false;
            CharacterDetails.EmoteSpeed1.freeze = false;
            CharacterDetails.Emote.freeze = false;
            CharacterDetails.MuscleTone.freeze = false;
            CharacterDetails.TailSize.freeze = false;
            CharacterDetails.BustX.freeze = false;
            CharacterDetails.BustY.freeze = false;
            CharacterDetails.BustZ.freeze = false;
            CharacterDetails.LipsBrightness.freeze = false;
            CharacterDetails.SkinBlueGloss.freeze = false;
            CharacterDetails.SkinGreenGloss.freeze = false;
            CharacterDetails.SkinRedGloss.freeze = false;
            CharacterDetails.SkinBluePigment.freeze = false;
            CharacterDetails.SkinGreenPigment.freeze = false;
            CharacterDetails.SkinRedPigment.freeze = false;
            CharacterDetails.HighlightBluePigment.freeze = false;
            CharacterDetails.HighlightGreenPigment.freeze = false;
            CharacterDetails.HighlightRedPigment.freeze = false;
            CharacterDetails.HairGlowBlue.freeze = false;
            CharacterDetails.HairGlowGreen.freeze = false;
            CharacterDetails.HairGlowRed.freeze = false;
            CharacterDetails.HairGreenPigment.freeze = false;
            CharacterDetails.HairBluePigment.freeze = false;
            CharacterDetails.HairRedPigment.freeze = false;
            CharacterDetails.Height.freeze = false;
            CharacterDetails.WeaponGreen.freeze = false;
            CharacterDetails.WeaponBlue.freeze = false;
            CharacterDetails.WeaponRed.freeze = false;
            CharacterDetails.WeaponZ.freeze = false;
            CharacterDetails.WeaponY.freeze = false;
            CharacterDetails.WeaponX.freeze = false;
            CharacterDetails.OffhandZ.freeze = false;
            CharacterDetails.OffhandY.freeze = false;
            CharacterDetails.OffhandX.freeze = false;
            CharacterDetails.OffhandRed.freeze = false;
            CharacterDetails.OffhandBlue.freeze = false;
            CharacterDetails.OffhandGreen.freeze = false;
            CharacterDetails.RightEyeBlue.freeze = false;
            CharacterDetails.RightEyeGreen.freeze = false;
            CharacterDetails.RightEyeRed.freeze = false;
            CharacterDetails.LeftEyeBlue.freeze = false;
            CharacterDetails.LeftEyeGreen.freeze = false;
            CharacterDetails.LeftEyeRed.freeze = false;
            CharacterDetails.LipsB.freeze = false;
            CharacterDetails.LipsG.freeze = false;
            CharacterDetails.LipsR.freeze = false;
            CharacterDetails.LimbalB.freeze = false;
            CharacterDetails.LimbalG.freeze = false;
            CharacterDetails.LimbalR.freeze = false;
            CharacterDetails.Race.freeze = false;
            CharacterDetails.Clan.freeze = false;
            CharacterDetails.Gender.freeze = false;
            CharacterDetails.Head.freeze = false;
            CharacterDetails.TailType.freeze = false;
            CharacterDetails.Nose.freeze = false;
            CharacterDetails.Lips.freeze = false;
            CharacterDetails.Voices.freeze = false;
            CharacterDetails.Hair.freeze = false;
            CharacterDetails.HairTone.freeze = false;
            CharacterDetails.HighlightTone.freeze = false;
            CharacterDetails.Jaw.freeze = false;
            CharacterDetails.RBust.freeze = false;
            CharacterDetails.RHeight.freeze = false;
            CharacterDetails.LipsTone.freeze = false;
            CharacterDetails.Skintone.freeze = false;
            CharacterDetails.FacialFeatures.freeze = false;
            CharacterDetails.TailorMuscle.freeze = false;
            CharacterDetails.Eye.freeze = false;
            CharacterDetails.RightEye.freeze = false;
            CharacterDetails.EyeBrowType.freeze = false;
            CharacterDetails.LeftEye.freeze = false;
            CharacterDetails.Offhand.freeze = false;
            CharacterDetails.FacePaint.freeze = false;
            CharacterDetails.FacePaintColor.freeze = false;
            CharacterDetails.Job.freeze = false;
            CharacterDetails.HeadPiece.freeze = false;
            CharacterDetails.Chest.freeze = false;
            CharacterDetails.Arms.freeze = false;
            CharacterDetails.Legs.freeze = false;
            CharacterDetails.Feet.freeze = false;
            CharacterDetails.Ear.freeze = false;
            CharacterDetails.Neck.freeze = false;
            CharacterDetails.Wrist.freeze = false;
            CharacterDetails.RFinger.freeze = false;
            CharacterDetails.LFinger.freeze = false;
        }
    }
}

/*
        private void BustZ_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (BustZ.IsMouseOver || BustZ.IsKeyboardFocusWithin || BustZ2.IsKeyboardFocusWithin || BustZ2.IsMouseOver || TestxDdada.IsMouseOver)
                if (BustZ.Value > 0)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z), "float", BustZ.Value.ToString());
        }

        private void BustY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (BustY.IsMouseOver || BustY.IsKeyboardFocusWithin || BustY2.IsKeyboardFocusWithin || BustY2.IsMouseOver || TestxDdada.IsMouseOver)
                if (BustY.Value > 0)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y), "float", BustY.Value.ToString());
        }

        private void BustX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (BustX.IsMouseOver || BustX.IsKeyboardFocusWithin || BustX2.IsKeyboardFocusWithin || BustX2.IsMouseOver || TestxDdada.IsMouseOver)
                if (BustX.Value > 0)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "float", BustX.Value.ToString());
        }
*/