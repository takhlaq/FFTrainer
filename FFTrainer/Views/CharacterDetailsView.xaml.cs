using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Controls;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using FFTrainer.Models;
using System.Linq;
using FFTrainer.ViewModels;
using Newtonsoft.Json;
using FFTrainer.Util;

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
            DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(40)};
            timer.Tick += delegate
            {
                for (int i = 0; i < _exdProvider.Races.Count; i++)
                {
                    RaceBox.Items.Add(_exdProvider.Races[i].Name);
                }
                for (int i = 0; i < _exdProvider.Tribes.Count; i++)
                {
                    ClanBox.Items.Add(_exdProvider.Tribes[i].Name);
                }
                timer.IsEnabled = false;
            };
            timer.Start();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Highlights), "byte", "0");
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Highlights), "byte", "80");
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
            CharacterDetails.ScaleX.freeze = false;
            CharacterDetails.ScaleY.freeze = false;
            CharacterDetails.ScaleZ.freeze = false;
        }
        private void Height2x_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Height2x.Value.HasValue)
                    if (Height2x.Value > 0) MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Height), "float", Height2x.Value.ToString());
            Height2x.ValueChanged -= Height2x_ValueChanged;
        }
        private void Height2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Height2x.Value.HasValue)
                    if (Height2x.Value > 0) MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Height), "float", Height2x.Value.ToString());
            HeightSlider.ValueChanged -= Height2_ValueChanged;
        }
        private void Height2x_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (Height2x.IsMouseOver || Height2x.IsKeyboardFocusWithin)
            {
                Height2x.ValueChanged -= Height2x_ValueChanged;
                Height2x.ValueChanged += Height2x_ValueChanged;
            }
            if (HeightSlider.IsKeyboardFocusWithin || HeightSlider.IsMouseOver)
            {
                HeightSlider.ValueChanged -= Height2_ValueChanged;
                HeightSlider.ValueChanged += Height2_ValueChanged;
            }
        }

        private void XPos2_V(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (XPos2.Value.HasValue)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.X), "float", XPos2.Value.ToString());
            XPos2.ValueChanged -= XPos2_V;
        }
        private void XPos2xd(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (XPos2.Value.HasValue)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.X), "float", XPos.Value.ToString());
            XPos.ValueChanged -= XPos2xd;
        }
        private void XPos2_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (XPos2.IsKeyboardFocusWithin || XPos2.IsMouseOver)
            {
                XPos2.ValueChanged -= XPos2_V;
                XPos2.ValueChanged += XPos2_V;
            }
            if(XPos.IsMouseOver || XPos.IsKeyboardFocusWithin)
            {
                XPos.ValueChanged -= XPos2xd;
                XPos.ValueChanged += XPos2xd;
            }
        }

        private void BustX2s(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BustX.Value > 0)
                 MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "float", BustX2.Value.ToString());
            BustX2.ValueChanged -= BustX2s;
        }
        private void BustX2a(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (BustX.Value > 0)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "float", BustX.Value.ToString());
            BustX.ValueChanged -= BustX2a;
        }
        private void BustX2_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (BustX2.IsKeyboardFocusWithin || BustX2.IsMouseOver)
            {
                BustX2.ValueChanged -= BustX2s;
                BustX2.ValueChanged += BustX2s;
            }
            if (BustX.IsMouseOver || BustX.IsKeyboardFocusWithin)
            {
                BustX.ValueChanged -= BustX2a;
                BustX.ValueChanged += BustX2a;
            }
        }



        private void BustY2_(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BustY.Value > 0)
               MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y), "float", BustY2.Value.ToString());
            BustY2.ValueChanged -= BustY2_;
        }
        private void BustY1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (BustY.Value > 0)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y), "float", BustY.Value.ToString());
            BustY.ValueChanged -= BustY1;
        }
        private void BustY2_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (BustY2.IsKeyboardFocusWithin || BustY2.IsMouseOver)
            {
                BustY2.ValueChanged -= BustY2_;
                BustY2.ValueChanged += BustY2_;
            }
            if (BustY.IsKeyboardFocusWithin || BustY.IsMouseOver)
            {
                BustY.ValueChanged -= BustY1;
                BustY.ValueChanged += BustY1;
            }
        }
        private void BustZ2_(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BustZ.Value > 0)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z), "float", BustZ2.Value.ToString());
            BustZ2.ValueChanged -= BustZ2_;
        }
        private void BustZ1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (BustZ.Value > 0)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z), "float", BustZ.Value.ToString());
            BustZ.ValueChanged -= BustZ1;
        }
        private void BustZ2_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (BustZ2.IsKeyboardFocusWithin || BustZ2.IsMouseOver)
            {
                BustZ2.ValueChanged -= BustZ2_;
                BustZ2.ValueChanged += BustZ2_;
            }
            if (BustZ.IsKeyboardFocusWithin || BustZ.IsMouseOver)
            {
                BustZ.ValueChanged -= BustZ1;
                BustZ.ValueChanged += BustZ1;
            }
        }


        private void YPos2_V(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (YPos2.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Y), "float", YPos2.Value.ToString());
            YPos2.ValueChanged -= YPos2_V;
        }
        private void YPos2xd(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (YPos2.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Y), "float", YPos.Value.ToString());
            YPos.ValueChanged -= YPos2xd;
        }
        private void YPos2_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (YPos2.IsKeyboardFocusWithin || YPos2.IsMouseOver)
            {
                YPos2.ValueChanged -= YPos2_V;
                YPos2.ValueChanged += YPos2_V;
            }
            if (YPos.IsMouseOver || YPos.IsKeyboardFocusWithin)
            {
                YPos.ValueChanged -= YPos2xd;
                YPos.ValueChanged += YPos2xd;
            }
        }


        private void ZPos2_V(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ZPos2.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Z), "float", ZPos2.Value.ToString());
            ZPos2.ValueChanged -= ZPos2_V;
        }
        private void ZPos2xd(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ZPos2.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Z), "float", ZPos.Value.ToString());
            ZPos.ValueChanged -= ZPos2xd;
        }
        private void ZPos2_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (ZPos2.IsKeyboardFocusWithin || ZPos2.IsMouseOver)
            {
                ZPos2.ValueChanged -= ZPos2_V;
                ZPos2.ValueChanged += ZPos2_V;
            }
            if (ZPos.IsMouseOver || ZPos.IsKeyboardFocusWithin)
            {
                ZPos.ValueChanged -= ZPos2xd;
                ZPos.ValueChanged += ZPos2xd;
            }
        }


        private void Rot1V(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Rot1.Value.HasValue)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation), "float", Rot1.Value.ToString());
            Rot1.ValueChanged -= Rot1V;
        }
        private void Rot1S(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Rot1.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation), "float", Rot1.Value.ToString());
            Rotation1.ValueChanged -= Rot1S;
        }

        private void Rot1_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (Rot1.IsKeyboardFocusWithin || Rot1.IsMouseOver)
            {
                Rot1.ValueChanged -= Rot1V;
                Rot1.ValueChanged += Rot1V;
            }
            if (Rotation1.IsMouseOver || Rotation1.IsKeyboardFocusWithin)
            {
                Rotation1.ValueChanged -= Rot1S;
                Rotation1.ValueChanged += Rot1S;
            }
        }

        private void Rot2V(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Rot2.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation2), "float", Rot2.Value.ToString());
            Rot2.ValueChanged -= Rot2V;
        }
        private void Rot2S(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Rot2.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation2), "float", Rot2.Value.ToString());
            Rotation2.ValueChanged -= Rot2S;
        }

        private void Rot2_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (Rot2.IsKeyboardFocusWithin || Rot2.IsMouseOver)
            {
                Rot2.ValueChanged -= Rot2V;
                Rot2.ValueChanged += Rot2V;
            }
            if (Rotation2.IsMouseOver || Rotation2.IsKeyboardFocusWithin)
            {
                Rotation2.ValueChanged -= Rot2S;
                Rotation2.ValueChanged += Rot2S;
            }
        }

        private void Rot3V(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Rot3.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation3), "float", Rot3.Value.ToString());
            Rot3.ValueChanged -= Rot3V;
        }
        private void Rot3S(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Rot3.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation3), "float", Rot3.Value.ToString());
            Rotation3.ValueChanged -= Rot3S;
        }

        private void Rot3_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (Rot3.IsKeyboardFocusWithin || Rot3.IsMouseOver)
            {
                Rot3.ValueChanged -= Rot3V;
                Rot3.ValueChanged += Rot3V;
            }
            if (Rotation3.IsMouseOver || Rotation3.IsKeyboardFocusWithin)
            {
                Rotation3.ValueChanged -= Rot3S;
                Rotation3.ValueChanged += Rot3S;
            }
        }

        private void Rot4V(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Rot4.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation4), "float", Rot4.Value.ToString());
            Rot4.ValueChanged -= Rot4V;
        }
        private void Rot4S(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Rot4.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation4), "float", Rot4.Value.ToString());
            Rotation4.ValueChanged -= Rot4S;
        }

        private void Rot4_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (Rot4.IsKeyboardFocusWithin || Rot4.IsMouseOver)
            {
                Rot4.ValueChanged -= Rot4V;
                Rot4.ValueChanged += Rot4V;
            }
            if (Rotation4.IsMouseOver || Rotation4.IsKeyboardFocusWithin)
            {
                Rotation4.ValueChanged -= Rot4S;
                Rotation4.ValueChanged += Rot4S;
            }
        }

        private void CameraHeight_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CameraHeight.IsMouseOver || CameraHeight.IsKeyboardFocusWithin)
            {
                CameraHeight.ValueChanged -= CameraHeight_;
                CameraHeight.ValueChanged += CameraHeight_;
            }
        }

        private void CameraHeight_(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CameraHeight.Value.HasValue)
                if (CameraHeight.IsMouseOver || CameraHeight.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CameraHeight), "float", CameraHeight.Value.ToString());
            CameraHeight.ValueChanged -= CameraHeight_;
        }

        private void CamX_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CamX.IsMouseOver || CamX.IsKeyboardFocusWithin)
            {
                CamX.ValueChanged -= CamX_;
                CamX.ValueChanged += CamX_;
            }
        }

        private void CamX_(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamX.Value.HasValue)
                if (CamX.IsMouseOver || CamX.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamX), "float", CamX.Value.ToString());
            CamX.ValueChanged -= CamX_;
        }


        private void CamY_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CamY.IsMouseOver || CamY.IsKeyboardFocusWithin)
            {
                CamY.ValueChanged -= CamY_;
                CamY.ValueChanged += CamY_;
            }
        }

        private void CamY_(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamY.Value.HasValue)
                if (CamY.IsMouseOver || CamY.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamY), "float", CamY.Value.ToString());
            CamY.ValueChanged -= CamY_;
        }


        private void CamZ_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CamZ.IsMouseOver || CamZ.IsKeyboardFocusWithin)
            {
                CamZ.ValueChanged -= CamZ_;
                CamZ.ValueChanged += CamZ_;
            }
        }

        private void CamZ_(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamZ.Value.HasValue)
                if (CamZ.IsMouseOver || CamZ.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamZ), "float", CamZ.Value.ToString());
            CamZ.ValueChanged -= CamZ_;
        }

        private void MuscleT(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Muscletone.Value.HasValue)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.MuscleTone), "float", Muscletone.Value.ToString());
            Muscletone.ValueChanged -= MuscleT;
        }

        private void Muscletone_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
                if (Muscletone.IsMouseOver || Muscletone.IsKeyboardFocusWithin)
                {
                Muscletone.ValueChanged -= MuscleT;
                Muscletone.ValueChanged += MuscleT;
                }
        }
        private void TailSz(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (TailSize.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.TailSize), "float", TailSize.Value.ToString());
            TailSize.ValueChanged -= TailSz;
        }

        private void TailSize_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (TailSize.IsMouseOver || TailSize.IsKeyboardFocusWithin)
            {
                TailSize.ValueChanged -= TailSz;
                TailSize.ValueChanged += TailSz;
            }
        }

        private void Emote_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (Emote.Value.HasValue)
                if (Emote.IsMouseOver || Emote.IsKeyboardFocusWithin)
                    CharacterDetails.EmoteX.value = (int)Emote.Value;
        }

        private void Namexd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            e.Handled = true;
            CharacterDetails.Name.value = Namexd.Text.Replace("\0", string.Empty);
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Name), "string", Namexd.Text+"\0\0\0\0\0\0\0\0\0\0");
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RenderToggle), "int", "2");
            Task.Delay(50).Wait();
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RenderToggle), "int", "0");
        }

        private void Transp_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (Transp.IsMouseOver || Transp.IsKeyboardFocusWithin)
            {
                Transp.ValueChanged -= Transps;
                Transp.ValueChanged += Transps;
            }
        }
        private void Transps(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Transp.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Transparency), "float", Transp.Value.ToString());
            Transp.ValueChanged -= Transps;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharaMakeFeatureList())
                return;

            var c = new CharaMakeFeatureSelector(CharacterDetails.Clan.value, (int)CharacterDetails.Gender.value, _exdProvider);
            c.ShowDialog();

            if (c.Choice != null)
            {
                if (CharacterDetails.Hair.freeze == false) { CharacterDetails.Hair.freeze = true; CharacterDetails.Hair.freezetest = true; }
                CharacterDetails.Hair.value = (byte)c.Choice.FeatureID;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Hair), CharacterDetails.Hair.GetBytes());
                if (CharacterDetails.Hair.freezetest == true) CharacterDetails.Hair.freeze = false; CharacterDetails.Hair.freezetest = false;
            }
        }
        public ExdCsvReader feature;
        private bool CheckCharaMakeFeatureList()
        {
            if (_exdProvider.CharaMakeFeatures == null)
            {
                _exdProvider.MakeCharaMakeFeatureList();
                if (_exdProvider.CharaMakeFeatures == null)
                {
                    return false;
                }
            }
            return true;
        }
        private CmpReader _colorMap = new CmpReader(Properties.Resources.human);
        private void HairColor_Click(object sender, RoutedEventArgs e)
        {
            var c = new CharaMakeColorSelector(_colorMap, 3584, 255, (int) CharacterDetails.HairTone.value);
            c.ShowDialog();

            if (c.Choice != -1)
            {
                if (CharacterDetails.HairTone.freeze == false) { CharacterDetails.HairTone.freeze = true; CharacterDetails.HairTone.freezetest = true; }
                CharacterDetails.HairTone.value = (byte)c.Choice;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairTone), CharacterDetails.HairTone.GetBytes());
                if (CharacterDetails.HairTone.freezetest == true) CharacterDetails.HairTone.freeze = false; CharacterDetails.HairTone.freezetest = false;
             //   FillDefaults();
            }
        }

        private void SkinColor_Click(object sender, RoutedEventArgs e)
        {
            var seearchE = 3328; // leave this at default
            if (CharacterDetails.Race.value == 1 && CharacterDetails.Clan.value == 1 
                || CharacterDetails.Race.value == 1 && CharacterDetails.Clan.value == 2 || 
                CharacterDetails.Race.value==2 && CharacterDetails.Clan.value==3 ||
                CharacterDetails.Race.value==4 && CharacterDetails.Clan.value==7||
                CharacterDetails.Race.value == 3 && CharacterDetails.Clan.value == 6) seearchE = 3328;
            if (CharacterDetails.Race.value == 4 && CharacterDetails.Clan.value == 8||CharacterDetails.Race.value==2&&CharacterDetails.Clan.value==4) seearchE = 21248;
            if (CharacterDetails.Race.value == 6 && CharacterDetails.Clan.value == 11) seearchE = 29440;
            if (CharacterDetails.Race.value == 6 && CharacterDetails.Clan.value == 12) seearchE = 32768;
            if (CharacterDetails.Race.value == 3 && CharacterDetails.Clan.value == 5) seearchE = 4608;
            if (CharacterDetails.Race.value == 5 && CharacterDetails.Clan.value == 9) seearchE = 5120;
            if (CharacterDetails.Race.value == 5 && CharacterDetails.Clan.value == 10) seearchE = 8448;
            var c = new CharaMakeColorSelector(_colorMap, seearchE, 255, (int)CharacterDetails.Skintone.value);
            c.ShowDialog();

            if (c.Choice != -1)
            {
                if (CharacterDetails.Skintone.freeze == false) { CharacterDetails.Skintone.freeze = true; CharacterDetails.Skintone.freezetest = true; }
                CharacterDetails.Skintone.value = (byte)c.Choice;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Skintone), CharacterDetails.Skintone.GetBytes());
                if (CharacterDetails.Skintone.freezetest == true) CharacterDetails.Skintone.freeze = false; CharacterDetails.Skintone.freezetest = false;
            }
        }

        private void LipColor_Click(object sender, RoutedEventArgs e)
        {
            var c = new CharaMakeColorSelector(_colorMap, 1152, 255, (int)CharacterDetails.LipsTone.value);
            c.ShowDialog();

            if (c.Choice != -1)
            {
                if (CharacterDetails.LipsTone.freeze == false) { CharacterDetails.LipsTone.freeze = true; CharacterDetails.LipsTone.freezetest = true; }
                CharacterDetails.LipsTone.value = (byte)c.Choice;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsTone), CharacterDetails.LipsTone.GetBytes());
                if (CharacterDetails.LipsTone.freezetest == true) CharacterDetails.LipsTone.freeze = false; CharacterDetails.LipsTone.freezetest = false;
            }
        }

        private void FacePaintColor_Click(object sender, RoutedEventArgs e)
        {
            var c = new CharaMakeColorSelector(_colorMap, 1152, 255, (int)CharacterDetails.FacePaintColor.value);
            c.ShowDialog();

            if (c.Choice != -1)
            {
                if (CharacterDetails.FacePaintColor.freeze == false) { CharacterDetails.FacePaintColor.freeze = true; CharacterDetails.FacePaintColor.freezetest = true; }
                CharacterDetails.FacePaintColor.value = (byte)c.Choice;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), CharacterDetails.FacePaintColor.GetBytes());
                if (CharacterDetails.FacePaintColor.freezetest == true) CharacterDetails.FacePaintColor.freeze = false; CharacterDetails.FacePaintColor.freezetest = false;
            }
        }

        private void HighColor_Click(object sender, RoutedEventArgs e)
        {
            var c = new CharaMakeColorSelector(_colorMap, 6144, 255, (int)CharacterDetails.HighlightTone.value);
            c.ShowDialog();

            if (c.Choice != -1)
            {
                if (CharacterDetails.HighlightTone.freeze == false) { CharacterDetails.HighlightTone.freeze = true; CharacterDetails.HighlightTone.freezetest = true; }
                CharacterDetails.HighlightTone.value = (byte)c.Choice;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightTone), CharacterDetails.HighlightTone.GetBytes());
                if (CharacterDetails.HighlightTone.freezetest == true) CharacterDetails.HighlightTone.freeze = false; CharacterDetails.HighlightTone.freezetest = false;
            }
        }

        private void LeftEyeColor_Click(object sender, RoutedEventArgs e)
        {
            var c = new CharaMakeColorSelector(_colorMap, 6144, 255, (int)CharacterDetails.LeftEye.value);
            c.ShowDialog();

            if (c.Choice != -1)
            {
                if (CharacterDetails.LeftEye.freeze == false) { CharacterDetails.LeftEye.freeze = true; CharacterDetails.LeftEye.freezetest = true; }
                CharacterDetails.LeftEye.value = (byte)c.Choice;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEye), CharacterDetails.LeftEye.GetBytes());
                if (CharacterDetails.LeftEye.freezetest == true) CharacterDetails.LeftEye.freeze = false; CharacterDetails.LeftEye.freezetest = false;
            }
        }

        private void RightEyeColor_Click(object sender, RoutedEventArgs e)
        {
            var c = new CharaMakeColorSelector(_colorMap, 6144, 255, (int)CharacterDetails.RightEye.value);
            c.ShowDialog();

            if (c.Choice != -1)
            {
                if (CharacterDetails.RightEye.freeze == false) { CharacterDetails.RightEye.freeze = true; CharacterDetails.RightEye.freezetest = true; }
                CharacterDetails.RightEye.value = (byte)c.Choice;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEye), CharacterDetails.RightEye.GetBytes());
                if (CharacterDetails.RightEye.freezetest == true) CharacterDetails.RightEye.freeze = false; CharacterDetails.RightEye.freezetest = false;
            }
        }

        private void RefresHNPC_Click(object sender, RoutedEventArgs e)
        {
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EntityType), "byte", "2");
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RenderToggle), "int", "2");
            Task.Delay(50).Wait();
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RenderToggle), "int", "0");
            Task.Delay(50).Wait();
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EntityType), "byte", "1");
        }
    }
}