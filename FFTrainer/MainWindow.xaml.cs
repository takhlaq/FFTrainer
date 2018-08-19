using System;
using System.Windows;
using FFTrainer.Models;
using System.ComponentModel;
using System.Threading;
using FFTrainer.ViewModels;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.Threading.Tasks;
using MahApps.Metro.Controls;
using FFTrainer.Views;
using System.Windows.Threading;
using AutoUpdaterDotNET;
using System.Net;
using MahApps.Metro;
using System.Linq;
using System.Windows.Controls;
using System.Diagnostics;
namespace FFTrainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    public partial class MainWindow : MetroWindow
    {
        private BackgroundWorker worker2;
        public static bool CurrentlySaving = false;
        private ExdCsvReader _exdProvider = new ExdCsvReader();
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        public MainWindow()
        {
            InitializeComponent();
            Properties.Settings.Default.Upgrade();
            _exdProvider.EmoteList();
            //load our settings
            var language = Properties.Settings.Default.Language;
            var dictionary = new ResourceDictionary();
            language = string.IsNullOrEmpty(language) ? "English" : language;
            dictionary.Source = new Uri("/Resources/" + language + ".xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries[0] = dictionary;
            if ((bool)Properties.Settings.Default["TopApp"] == true) Application.Current.MainWindow.Topmost = true;
            DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(60) };
            timer.Tick += delegate
            {
                worker2 = new BackgroundWorker();
                worker2.DoWork += Worker_DoWork2;
                // run the worker
                worker2.RunWorkerAsync();
                Emotesx = _exdProvider.Emotes.Values.ToArray();
                foreach (ExdCsvReader.Emote xD in Emotesx)
                {
                    if (xD.Realist == true)
                    {
                        EmoteBox.Items.Add(new Emotexd
                        {
                            Index = Convert.ToInt32(xD.Index),
                            Name = xD.Name.ToString()
                        });
                    }
                }
                timer.IsEnabled = false;
            };
            timer.Start();
        }
        private void Worker_DoWork2(object sender, DoWorkEventArgs e)
        {
                while (true)
                {
                    if (CharacterDetails.Rotation4.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation4), CharacterDetails.Rotation4.GetBytes());
                    if (CharacterDetails.Rotation3.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation3), CharacterDetails.Rotation3.GetBytes());
                    if (CharacterDetails.Rotation2.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation2), CharacterDetails.Rotation2.GetBytes());
                    if (CharacterDetails.Rotation.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation), CharacterDetails.Rotation.GetBytes());
                    if (CharacterDetails.Z.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Z), CharacterDetails.Z.GetBytes());
                    if (CharacterDetails.Y.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Y), CharacterDetails.Y.GetBytes());
                    if (CharacterDetails.X.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.X), CharacterDetails.X.GetBytes());
                    if (CharacterDetails.BustZ.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z), CharacterDetails.BustZ.GetBytes());
                    if (CharacterDetails.BustY.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y), CharacterDetails.BustY.GetBytes());
                    if (CharacterDetails.BustX.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), CharacterDetails.BustX.GetBytes());
                    if (CharacterDetails.Height.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Height), CharacterDetails.Height.GetBytes());
                    if (CharacterDetails.Voices.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Voices), CharacterDetails.Voices.GetBytes());
                    if (CharacterDetails.CameraUpDown.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraUpDown), CharacterDetails.CameraUpDown.GetBytes());
                    if (CharacterDetails.FOV2.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOV2), CharacterDetails.FOV2.GetBytes());
                    if (CharacterDetails.CameraYAMax.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMax), CharacterDetails.CameraYAMax.GetBytes());
                    if (CharacterDetails.CameraYAMin.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMin), CharacterDetails.CameraYAMin.GetBytes());
                    if (CharacterDetails.CameraHeight2.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraHeight), CharacterDetails.CameraHeight2.GetBytes());
                    if (CharacterDetails.Weather.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.WeatherAddress, Settings.Instance.Character.Weather), CharacterDetails.Weather.GetBytes());
                    if (CharacterDetails.CameraHeight.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CameraHeight), CharacterDetails.CameraHeight.GetBytes());
                    if (CharacterDetails.CamX.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamX), CharacterDetails.CamX.GetBytes());
                    if (CharacterDetails.CamY.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamY), CharacterDetails.CamY.GetBytes());
                    if (CharacterDetails.CamZ.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamZ), CharacterDetails.CamZ.GetBytes());
                    if (CharacterDetails.FOVMAX.freeze)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVMAX), CharacterDetails.FOVMAX.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVC), CharacterDetails.FOVC.GetBytes());
                    }
                    if (CharacterDetails.Max.freeze && CharacterDetailsViewModel.NotAllowed == false) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Max), CharacterDetails.Max.GetBytes());
                    if (CharacterDetails.Min.freeze && CharacterDetailsViewModel.NotAllowed == false) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Min), CharacterDetails.Min.GetBytes());
                    if (CharacterDetails.CZoom.freeze && CharacterDetailsViewModel.NotAllowed == false) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CZoom), CharacterDetails.CZoom.GetBytes());
                    if (CharacterDetails.MuscleTone.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.MuscleTone), CharacterDetails.MuscleTone.GetBytes());
                    if (CharacterDetails.OffhandRed.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandRed), CharacterDetails.OffhandRed.GetBytes());
                    if (CharacterDetails.OffhandGreen.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandGreen), CharacterDetails.OffhandGreen.GetBytes());
                    if (CharacterDetails.OffhandBlue.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandBlue), CharacterDetails.OffhandBlue.GetBytes());
                    if (CharacterDetails.OffhandX.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandX), CharacterDetails.OffhandX.GetBytes());
                    if (CharacterDetails.OffhandY.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandY), CharacterDetails.OffhandY.GetBytes());
                    if (CharacterDetails.OffhandZ.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandZ), CharacterDetails.OffhandZ.GetBytes());
                    if (CharacterDetails.WeaponX.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponX), CharacterDetails.WeaponX.GetBytes());
                    if (CharacterDetails.WeaponY.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponY), CharacterDetails.WeaponY.GetBytes());
                    if (CharacterDetails.WeaponZ.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponZ), CharacterDetails.WeaponZ.GetBytes());
                    if (CharacterDetails.TailSize.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.TailSize), CharacterDetails.TailSize.GetBytes());
                    if (CharacterDetails.WeaponBlue.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponBlue), CharacterDetails.WeaponBlue.GetBytes());
                    if (CharacterDetails.WeaponGreen.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponGreen), CharacterDetails.WeaponGreen.GetBytes());
                    if (CharacterDetails.WeaponRed.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponRed), CharacterDetails.WeaponRed.GetBytes());
                    if (CharacterDetails.SkinRedPigment.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedPigment), CharacterDetails.SkinRedPigment.GetBytes());
                    if (CharacterDetails.SkinGreenPigment.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenPigment), CharacterDetails.SkinGreenPigment.GetBytes());
                    if (CharacterDetails.SkinBluePigment.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBluePigment), CharacterDetails.SkinBluePigment.GetBytes());
                    if (CharacterDetails.SkinRedGloss.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedGloss), CharacterDetails.SkinRedGloss.GetBytes());
                    if (CharacterDetails.SkinGreenGloss.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenGloss), CharacterDetails.SkinGreenGloss.GetBytes());
                    if (CharacterDetails.SkinBlueGloss.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBlueGloss), CharacterDetails.SkinBlueGloss.GetBytes());
                    if (CharacterDetails.HairRedPigment.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairRedPigment), CharacterDetails.HairRedPigment.GetBytes());
                    if (CharacterDetails.HairGreenPigment.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGreenPigment), CharacterDetails.HairGreenPigment.GetBytes());
                    if (CharacterDetails.HairBluePigment.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairBluePigment), CharacterDetails.HairBluePigment.GetBytes());
                    if (CharacterDetails.HairGlowRed.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowRed), CharacterDetails.HairGlowRed.GetBytes());
                    if (CharacterDetails.HairGlowGreen.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowGreen), CharacterDetails.HairGlowGreen.GetBytes());
                    if (CharacterDetails.HairGlowBlue.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowBlue), CharacterDetails.HairGlowBlue.GetBytes());
                    if (CharacterDetails.HighlightRedPigment.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightRedPigment), CharacterDetails.HighlightRedPigment.GetBytes());
                    if (CharacterDetails.HighlightGreenPigment.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightGreenPigment), CharacterDetails.HighlightGreenPigment.GetBytes());
                    if (CharacterDetails.HighlightBluePigment.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightBluePigment), CharacterDetails.HighlightBluePigment.GetBytes());
                    if (CharacterDetails.LeftEyeRed.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeRed), CharacterDetails.LeftEyeRed.GetBytes());
                    if (CharacterDetails.LeftEyeGreen.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeGreen), CharacterDetails.LeftEyeGreen.GetBytes());
                    if (CharacterDetails.LeftEyeBlue.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeBlue), CharacterDetails.LeftEyeBlue.GetBytes());
                    if (CharacterDetails.RightEyeRed.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeRed), CharacterDetails.RightEyeRed.GetBytes());
                    if (CharacterDetails.RightEyeGreen.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeGreen), CharacterDetails.RightEyeGreen.GetBytes());
                    if (CharacterDetails.RightEyeBlue.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeBlue), CharacterDetails.RightEyeBlue.GetBytes());
                    if (CharacterDetails.LipsBrightness.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsBrightness), CharacterDetails.LipsBrightness.GetBytes());
                    if (CharacterDetails.LipsR.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsR), CharacterDetails.LipsR.GetBytes());
                    if (CharacterDetails.LipsG.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsG), CharacterDetails.LipsG.GetBytes());
                    if (CharacterDetails.LipsB.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsB), CharacterDetails.LipsB.GetBytes());
                    if (CharacterDetails.ScaleZ.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Scale.Z), CharacterDetails.ScaleZ.GetBytes());
                    if (CharacterDetails.ScaleY.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Scale.Y), CharacterDetails.ScaleY.GetBytes());
                    if (CharacterDetails.ScaleX.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Scale.X), CharacterDetails.ScaleX.GetBytes());
                    if (CharacterDetails.LimbalR.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalR), CharacterDetails.LimbalR.GetBytes());
                    if (CharacterDetails.LimbalB.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalB), CharacterDetails.LimbalB.GetBytes());
                    if (CharacterDetails.LimbalG.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalG), CharacterDetails.LimbalG.GetBytes());
                    if (CharacterDetails.Wetness.Activated) MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Wetness), "float", "1");
                    if (CharacterDetails.SWetness.Activated) MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.SWetness), "float", "5");
                    if (CharacterDetails.Job.freeze && !CharacterDetails.Job.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Job), CharacterDetails.Job.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponBase), CharacterDetails.WeaponBase.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponV), CharacterDetails.WeaponV.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponDye), CharacterDetails.WeaponDye.GetBytes());
                    }
                    if (CharacterDetails.Offhand.freeze && !CharacterDetails.Offhand.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Offhand), CharacterDetails.Offhand.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandBase), CharacterDetails.OffhandBase.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandV), CharacterDetails.OffhandV.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandDye), CharacterDetails.OffhandDye.GetBytes());
                    }
                    if (CharacterDetails.HeadPiece.freeze && !CharacterDetails.HeadPiece.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadPiece), CharacterDetails.HeadPiece.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadV), CharacterDetails.HeadV.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadDye), CharacterDetails.HeadDye.GetBytes());
                    }
                    if (CharacterDetails.Chest.freeze && !CharacterDetails.Chest.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Chest), CharacterDetails.Chest.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ChestV), CharacterDetails.ChestV.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ChestDye), CharacterDetails.ChestDye.GetBytes());
                    }
                    if (CharacterDetails.Arms.freeze && !CharacterDetails.Arms.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Arms), CharacterDetails.Arms.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ArmsV), CharacterDetails.ArmsV.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ArmsDye), CharacterDetails.ArmsDye.GetBytes());
                    }
                    if (CharacterDetails.Legs.freeze && !CharacterDetails.Legs.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Legs), CharacterDetails.Legs.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LegsV), CharacterDetails.LegsV.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LegsDye), CharacterDetails.LegsDye.GetBytes());
                    }
                    if (CharacterDetails.Feet.freeze && !CharacterDetails.Feet.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Feet), CharacterDetails.Feet.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FeetVa), CharacterDetails.FeetVa.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FeetDye), CharacterDetails.FeetDye.GetBytes());
                    }
                    if (CharacterDetails.LFinger.freeze && !CharacterDetails.LFinger.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFinger), CharacterDetails.LFinger.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFingerVa), CharacterDetails.LFingerVa.GetBytes());
                    }
                    if (CharacterDetails.RFinger.freeze && !CharacterDetails.RFinger.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFinger), CharacterDetails.RFinger.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFingerVa), CharacterDetails.RFingerVa.GetBytes());
                    }
                    if (CharacterDetails.Wrist.freeze && !CharacterDetails.Wrist.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Wrist), CharacterDetails.Wrist.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WristVa), CharacterDetails.WristVa.GetBytes());
                    }
                    if (CharacterDetails.Neck.freeze && !CharacterDetails.Neck.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Neck), CharacterDetails.Neck.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.NeckVa), CharacterDetails.NeckVa.GetBytes());
                    }
                    if (CharacterDetails.Ear.freeze && !CharacterDetails.Ear.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Ear), CharacterDetails.Ear.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EarVa), CharacterDetails.EarVa.GetBytes());
                    }
                    if (CharacterDetails.ModelType.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ModelType), CharacterDetails.ModelType.GetBytes());
                    if (CharacterDetails.BodyType.freeze && !CharacterDetails.BodyType.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.BodyType), CharacterDetails.BodyType.GetBytes());
                    if (CharacterDetails.Race.freeze && !CharacterDetails.Race.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Race), CharacterDetails.Race.GetBytes());
                    if (CharacterDetails.Clan.freeze && !CharacterDetails.Clan.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Clan), CharacterDetails.Clan.GetBytes());
                    if (CharacterDetails.Gender.freeze && !CharacterDetails.Gender.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Gender), CharacterDetails.Gender.GetBytes());
                    if (CharacterDetails.Head.freeze && !CharacterDetails.Head.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Head), CharacterDetails.Head.GetBytes());
                    if (CharacterDetails.Hair.freeze && !CharacterDetails.Hair.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Hair), CharacterDetails.Hair.GetBytes());
                    if (CharacterDetails.TailType.freeze && !CharacterDetails.TailType.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailType), CharacterDetails.TailType.GetBytes());
                    if (CharacterDetails.HairTone.freeze && !CharacterDetails.HairTone.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairTone), CharacterDetails.HairTone.GetBytes());
                    if (CharacterDetails.HighlightTone.freeze && !CharacterDetails.HighlightTone.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightTone), CharacterDetails.HighlightTone.GetBytes());
                    if (CharacterDetails.Skintone.freeze && !CharacterDetails.Skintone.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Skintone), CharacterDetails.Skintone.GetBytes());
                    if (CharacterDetails.Lips.freeze && !CharacterDetails.Lips.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Lips), CharacterDetails.Lips.GetBytes());
                    if (CharacterDetails.LipsTone.freeze && !CharacterDetails.LipsTone.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsTone), CharacterDetails.LipsTone.GetBytes());
                    if (CharacterDetails.Nose.freeze && !CharacterDetails.Nose.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Nose), CharacterDetails.Nose.GetBytes());
                    if (CharacterDetails.FacePaintColor.freeze && !CharacterDetails.FacePaintColor.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), CharacterDetails.FacePaintColor.GetBytes());
                    if (CharacterDetails.FacePaint.freeze && !CharacterDetails.FacePaint.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaint), CharacterDetails.FacePaint.GetBytes());
                    if (CharacterDetails.LeftEye.freeze && !CharacterDetails.LeftEye.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEye), CharacterDetails.LeftEye.GetBytes());
                    if (CharacterDetails.RightEye.freeze && !CharacterDetails.RightEye.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEye), CharacterDetails.RightEye.GetBytes());
                    if (CharacterDetails.Eye.freeze && !CharacterDetails.Eye.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Eye), CharacterDetails.Eye.GetBytes());
                    if (CharacterDetails.EyeBrowType.freeze && !CharacterDetails.EyeBrowType.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EyeBrowType), CharacterDetails.EyeBrowType.GetBytes());
                    if (CharacterDetails.FacialFeatures.freeze && !CharacterDetails.FacialFeatures.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacialFeatures), CharacterDetails.FacialFeatures.GetBytes());
                    if (CharacterDetails.RHeight.freeze && !CharacterDetails.RHeight.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RHeight), CharacterDetails.RHeight.GetBytes());
                    if (CharacterDetails.RBust.freeze && !CharacterDetails.RBust.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RBust), CharacterDetails.RBust.GetBytes());
                    if (CharacterDetails.Jaw.freeze && !CharacterDetails.Jaw.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Jaw), CharacterDetails.Jaw.GetBytes());
                    if (CharacterDetails.TailorMuscle.freeze && !CharacterDetails.TailorMuscle.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailorMuscle), CharacterDetails.TailorMuscle.GetBytes());
                    if (CharacterDetails.FreezeFacial.Activated) MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.FreezeFacial), "float", "0");
                    if (CharacterDetails.EmoteSpeed1.freeze)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.EmoteSpeed1), CharacterDetails.EmoteSpeed1.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.EmoteSpeed2), CharacterDetails.EmoteSpeed1.GetBytes());
                    }
                    if (CharacterDetails.Emote.freeze)
                {
                    if (CharacterDetails.Emote.value > 6558) CharacterDetails.Emote.value = 6558;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.Emote), CharacterDetails.Emote.GetBytes());
                }
                    Thread.Sleep(Properties.Settings.Default.Write);
                }
        }
        private void GposeMode_Checked(object sender, RoutedEventArgs e)
        {
            CharacterDetailsViewModel.baseAddr = MemoryManager.Instance.GposeAddress;
        }

        private void GposeMode_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetailsViewModel.baseAddr = MemoryManager.Add(MemoryManager.Instance.BaseAddress, CharacterDetailsViewModel.eOffset);
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/nxu2Ydp");
        }
        private MetroWindow accentThemeTestWindow;
        private Window LanguageWindow;
        private void ChangeAppStyleButtonClick(object sender, RoutedEventArgs e)
        {
            if (accentThemeTestWindow != null)
            {
                accentThemeTestWindow.Activate();
                return;
            }

            accentThemeTestWindow = new AccentStyleWindow();
            accentThemeTestWindow.Owner = this;
            accentThemeTestWindow.Closed += (o, args) => accentThemeTestWindow = null;
            accentThemeTestWindow.Left = this.Left + this.ActualWidth / 2.0;
            accentThemeTestWindow.Top = this.Top + this.ActualHeight / 2.0;
            accentThemeTestWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CurrentlySaving = true;
            SaveFileDialog dig = new SaveFileDialog();
            dig.Filter = "Json File(*.json)|*.json";
            dig.InitialDirectory = Environment.CurrentDirectory;
            if (dig.ShowDialog() == true)
            {
                CharacterDetails Save1 = new CharacterDetails(); // CharacterDetails is class with all address
                Save1 = CharacterDetails;
                string details = JsonConvert.SerializeObject(Save1,Formatting.Indented);
                File.WriteAllText(dig.FileName, details);
                CurrentlySaving = false;
            }
            else CurrentlySaving = false;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var appTheme = ThemeManager.GetAppTheme(Properties.Settings.Default.AppThemeName);
            var accent = ThemeManager.GetAccent(Properties.Settings.Default.Accent);
            ThemeManager.ChangeAppStyle(Application.Current, accent, appTheme);
            if ((bool)Properties.Settings.Default["FirstRun"] == true)
            {
                //Create new instance of Dialog you want to show
                var fdf = new Culture();
                fdf.Owner = this;
                //Show the dialog
                fdf.ShowDialog();
            }
            DataContext = new MainViewModel();
        }
        private void ThreadSetting(object sender, RoutedEventArgs e)
        {
            //Create new instance of Dialog you want to show
            var SetThreads = new ThreadSettings();
            SetThreads.Owner = this;
            //Show the dialog
            SetThreads.ShowDialog();
        }
        private void ChangeLang(object sender, RoutedEventArgs e)
        {
            if (LanguageWindow != null)
            {
                LanguageWindow.Activate();
                return;
            }
            LanguageWindow = new Culture();
            LanguageWindow.Owner = this;
            LanguageWindow.Closed += (o, args) => LanguageWindow = null;
            LanguageWindow.Left = this.Left + this.ActualWidth / 2.0;
            LanguageWindow.Top = this.Top + this.ActualHeight / 2.0;
            LanguageWindow.Show();
        }
        private void Alwaystop(object sender, RoutedEventArgs e)
        {
            if ((bool)Properties.Settings.Default["TopApp"] == false)
            {
                Properties.Settings.Default["TopApp"] = true;
                Properties.Settings.Default.Save();
                Application.Current.MainWindow.Topmost = true;
            }
            else
            {
                Properties.Settings.Default["TopApp"] = false;
                Properties.Settings.Default.Save();
                Application.Current.MainWindow.Topmost = false;
            }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            ServicePointManager.SecurityProtocol = (ServicePointManager.SecurityProtocol & SecurityProtocolType.Ssl3) | (SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.SystemDefault);
            AutoUpdater.RunUpdateAsAdmin = true;
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.LetUserSelectRemindLater = false;
            AutoUpdater.DownloadPath = Environment.CurrentDirectory;
            AutoUpdater.Start("https://raw.githubusercontent.com/SaberNaut/xd/master/Updates.xml");
        }
        public static ExdCsvReader.Emote[] Emotesx;
        public class Emotexd
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (EmoteFlyout.IsOpen == false)
                EmoteFlyout.IsOpen = true;
            else EmoteFlyout.IsOpen = false;
        }

        private void EmoteBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (EmoteBox.SelectedItem == null)
                return;
            var item = (ListBox)sender;
            var Value = (Emotexd)item.SelectedItem;
            CharacterDetails.Emote.value = (int)Value.Index;
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string filter = searchTextBox.Text.ToLower();
            EmoteBox.Items.Clear();
            foreach (ExdCsvReader.Emote xD in Emotesx.Where(g => g.Name.ToLower().Contains(filter)))
                if (xD.Realist == true)
                {
                    EmoteBox.Items.Add(new Emotexd
                    {
                        Index = Convert.ToInt32(xD.Index),
                        Name = xD.Name.ToString()
                    });
                }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var c = new LoadOption();
            c.Owner = this;
            c.ShowDialog();
            if (c.Choice == "All") dqwewqw();
            if (c.Choice == "App") Appereanco();
            if (c.Choice == "Xuip") Equipo();
        }

        private void dqwewqw()
        {
            OpenFileDialog dig = new OpenFileDialog(); 
            dig.Filter = "Json File(*.json)|*.json";
            dig.DefaultExt = ".json";
            if (dig.ShowDialog() == true)
            {
                CharacterDetails load1 = JsonConvert.DeserializeObject<CharacterDetails>(File.ReadAllText(dig.FileName));
                Loadbutton.IsEnabled = false;
                var characterDetailsView = new CharacterDetailsView();
                var characterDetailsView2 = new CharacterDetailsView2();
                var characterDetailsView3 = new CharacterDetailsView3();
                {
                    if (CharacterDetails.MuscleTone.freeze == true) { CharacterDetails.MuscleTone.freeze = false; CharacterDetails.MuscleTone.freezetest = true; characterDetailsView.MuscleCheck.IsChecked = false; }
                    if (CharacterDetails.TailSize.freeze == true) { CharacterDetails.TailSize.freeze = false; CharacterDetails.TailSize.freezetest = true; characterDetailsView.TailSizeCheck.IsChecked = false; }
                    if (CharacterDetails.BustX.freeze == true) { CharacterDetails.BustX.freeze = false; CharacterDetails.BustX.freezetest = true; characterDetailsView.BustXCheck.IsChecked = false; }
                    if (CharacterDetails.BustY.freeze == true) { CharacterDetails.BustY.freeze = false; CharacterDetails.BustY.freezetest = true; characterDetailsView.BustYCheck.IsChecked = false; }
                    if (CharacterDetails.BustZ.freeze == true) { CharacterDetails.BustZ.freeze = false; CharacterDetails.BustZ.freezetest = true; characterDetailsView.BustZCheck.IsChecked = false; }
                    if (CharacterDetails.LipsBrightness.freeze == true) { CharacterDetails.LipsBrightness.freeze = false; CharacterDetails.LipsBrightness.freezetest = true; characterDetailsView3.LipBright.IsChecked = false; }
                    if (CharacterDetails.SkinBlueGloss.freeze == true) { CharacterDetails.SkinBlueGloss.freeze = false; CharacterDetails.SkinBlueGloss.freezetest = true; characterDetailsView3.BlueGloss.IsChecked = false; }
                    if (CharacterDetails.SkinGreenGloss.freeze == true) { CharacterDetails.SkinGreenGloss.freeze = false; CharacterDetails.SkinGreenGloss.freezetest = true; characterDetailsView3.GreenGloss.IsChecked = false; }
                    if (CharacterDetails.SkinRedGloss.freeze == true) { CharacterDetails.SkinRedGloss.freeze = false; CharacterDetails.SkinRedGloss.freezetest = true; characterDetailsView3.RedGloss.IsChecked = false; }
                    if (CharacterDetails.SkinBluePigment.freeze == true) { CharacterDetails.SkinBluePigment.freeze = false; CharacterDetails.SkinBluePigment.freezetest = true; characterDetailsView3.SkinBlue.IsChecked = false; }
                    if (CharacterDetails.SkinGreenPigment.freeze == true) { CharacterDetails.SkinGreenPigment.freeze = false; CharacterDetails.SkinGreenPigment.freezetest = true; characterDetailsView3.SkinGreen.IsChecked = false; }
                    if (CharacterDetails.SkinRedPigment.freeze == true) { CharacterDetails.SkinRedPigment.freeze = false; CharacterDetails.SkinRedPigment.freezetest = true; characterDetailsView3.SkinRed.IsChecked = false; }
                    if (CharacterDetails.HighlightBluePigment.freeze == true) { CharacterDetails.HighlightBluePigment.freeze = false; CharacterDetails.HighlightBluePigment.freezetest = true; characterDetailsView3.HLBP.IsChecked = false; }
                    if (CharacterDetails.HighlightGreenPigment.freeze == true) { CharacterDetails.HighlightGreenPigment.freeze = false; CharacterDetails.HighlightGreenPigment.freezetest = true; characterDetailsView3.HLGP.IsChecked = false; }
                    if (CharacterDetails.HighlightRedPigment.freeze == true) { CharacterDetails.HighlightRedPigment.freeze = false; CharacterDetails.HighlightRedPigment.freezetest = true; characterDetailsView3.HLRP.IsChecked = false; }
                    if (CharacterDetails.HairGlowBlue.freeze == true) { CharacterDetails.HairGlowBlue.freeze = false; CharacterDetails.HairGlowBlue.freezetest = true; characterDetailsView3.HairBGCheck.IsChecked = false; }
                    if (CharacterDetails.HairGlowGreen.freeze == true) { CharacterDetails.HairGlowGreen.freeze = false; CharacterDetails.HairGlowGreen.freezetest = true; characterDetailsView3.HairGGCheck.IsChecked = false; }
                    if (CharacterDetails.HairGlowRed.freeze == true) { CharacterDetails.HairGlowRed.freeze = false; CharacterDetails.HairGlowRed.freezetest = true; characterDetailsView3.HairRGCheck.IsChecked = false; }
                    if (CharacterDetails.HairGreenPigment.freeze == true) { CharacterDetails.HairGreenPigment.freeze = false; CharacterDetails.HairGreenPigment.freezetest = true; characterDetailsView3.HairGreenP.IsChecked = false; }
                    if (CharacterDetails.HairBluePigment.freeze == true) { CharacterDetails.HairBluePigment.freeze = false; CharacterDetails.HairBluePigment.freezetest = true; characterDetailsView3.HairBlueP.IsChecked = false; }
                    if (CharacterDetails.HairRedPigment.freeze == true) { CharacterDetails.HairRedPigment.freeze = false; CharacterDetails.HairRedPigment.freezetest = true; characterDetailsView3.HairRedP.IsChecked = false; }
                    if (CharacterDetails.Height.freeze == true) { CharacterDetails.Height.freeze = false; CharacterDetails.Height.freezetest = true; characterDetailsView.HeightCheck.IsChecked = false; }
                    if (CharacterDetails.WeaponGreen.freeze == true) { CharacterDetails.WeaponGreen.freeze = false; CharacterDetails.WeaponGreen.freezetest = true; characterDetailsView2.Green.IsChecked = false; }
                    if (CharacterDetails.WeaponBlue.freeze == true) { CharacterDetails.WeaponBlue.freeze = false; CharacterDetails.WeaponBlue.freezetest = true; characterDetailsView2.Blue.IsChecked = false; }
                    if (CharacterDetails.WeaponRed.freeze == true) { CharacterDetails.WeaponRed.freeze = false; CharacterDetails.WeaponRed.freezetest = true; characterDetailsView2.Red.IsChecked = false; }
                    if (CharacterDetails.WeaponZ.freeze == true) { CharacterDetails.WeaponZ.freeze = false; CharacterDetails.WeaponZ.freezetest = true; characterDetailsView2.ScaleZ.IsChecked = false; }
                    if (CharacterDetails.WeaponY.freeze == true) { CharacterDetails.WeaponY.freeze = false; CharacterDetails.WeaponY.freezetest = true; characterDetailsView2.ScaleY.IsChecked = false; }
                    if (CharacterDetails.WeaponX.freeze == true) { CharacterDetails.WeaponX.freeze = false; CharacterDetails.WeaponX.freezetest = true; characterDetailsView2.ScaleX.IsChecked = false; }
                    if (CharacterDetails.OffhandZ.freeze == true) { CharacterDetails.OffhandZ.freeze = false; CharacterDetails.OffhandZ.freezetest = true; characterDetailsView2.ScaleZ2.IsChecked = false; }
                    if (CharacterDetails.OffhandY.freeze == true) { CharacterDetails.OffhandY.freeze = false; CharacterDetails.OffhandY.freezetest = true; characterDetailsView2.ScaleY2.IsChecked = false; }
                    if (CharacterDetails.OffhandX.freeze == true) { CharacterDetails.OffhandX.freeze = false; CharacterDetails.OffhandX.freezetest = true; characterDetailsView2.ScaleX2.IsChecked = false; }
                    if (CharacterDetails.OffhandRed.freeze == true) { CharacterDetails.OffhandRed.freeze = false; CharacterDetails.OffhandRed.freezetest = true; characterDetailsView2.Red2.IsChecked = false; }
                    if (CharacterDetails.OffhandBlue.freeze == true) { CharacterDetails.OffhandBlue.freeze = false; CharacterDetails.OffhandBlue.freezetest = true; characterDetailsView2.Blue2.IsChecked = false; }
                    if (CharacterDetails.OffhandGreen.freeze == true) { CharacterDetails.OffhandGreen.freeze = false; CharacterDetails.OffhandGreen.freezetest = true; characterDetailsView2.Green2.IsChecked = false; }
                    if (CharacterDetails.RightEyeBlue.freeze == true) { CharacterDetails.RightEyeBlue.freeze = false; CharacterDetails.RightEyeBlue.freezetest = true; characterDetailsView3.BluePigment2.IsChecked = false; }
                    if (CharacterDetails.RightEyeGreen.freeze == true) { CharacterDetails.RightEyeGreen.freeze = false; CharacterDetails.RightEyeGreen.freezetest = true; characterDetailsView3.GreenPigment2.IsChecked = false; }
                    if (CharacterDetails.RightEyeRed.freeze == true) { CharacterDetails.RightEyeRed.freeze = false; CharacterDetails.RightEyeRed.freezetest = true; characterDetailsView3.RedPigment2.IsChecked = false; }
                    if (CharacterDetails.LeftEyeBlue.freeze == true) { CharacterDetails.LeftEyeBlue.freeze = false; CharacterDetails.LeftEyeBlue.freezetest = true; characterDetailsView3.BEyePigment.IsChecked = false; }
                    if (CharacterDetails.LeftEyeGreen.freeze == true) { CharacterDetails.LeftEyeGreen.freeze = false; CharacterDetails.LeftEyeGreen.freezetest = true; characterDetailsView3.GEyePigment.IsChecked = false; }
                    if (CharacterDetails.LeftEyeRed.freeze == true) { CharacterDetails.LeftEyeRed.freeze = false; CharacterDetails.LeftEyeRed.freezetest = true; characterDetailsView3.REyePigment.IsChecked = false; }
                    if (CharacterDetails.LipsB.freeze == true) { CharacterDetails.LipsB.freeze = false; CharacterDetails.LipsB.freezetest = true; characterDetailsView3.BluePigment.IsChecked = false; }
                    if (CharacterDetails.LipsG.freeze == true) { CharacterDetails.LipsG.freeze = false; CharacterDetails.LipsG.freezetest = true; characterDetailsView3.GreenPigment.IsChecked = false; }
                    if (CharacterDetails.LipsR.freeze == true) { CharacterDetails.LipsR.freeze = false; CharacterDetails.LipsR.freezetest = true; characterDetailsView3.RedPigment.IsChecked = false; }
                    if (CharacterDetails.LimbalB.freeze == true) { CharacterDetails.LimbalB.freeze = false; CharacterDetails.LimbalB.freezetest = true; characterDetailsView3.LimbalB.IsChecked = false; }
                    if (CharacterDetails.LimbalG.freeze == true) { CharacterDetails.LimbalG.freeze = false; CharacterDetails.LimbalG.freezetest = true; characterDetailsView3.LimbalG.IsChecked = false; }
                    if (CharacterDetails.LimbalR.freeze == true) { CharacterDetails.LimbalR.freeze = false; CharacterDetails.LimbalR.freezetest = true; characterDetailsView3.LimbalR.IsChecked = false; }
                    if (CharacterDetails.BodyType.freeze == false) { CharacterDetails.BodyType.freeze = true; CharacterDetails.BodyType.freezetest = true; }
                }
                CharacterDetails.Race.freeze = true;
                CharacterDetails.Clan.freeze = true;
                CharacterDetails.Gender.freeze = true;
                CharacterDetails.Head.freeze = true;
                CharacterDetails.TailType.freeze = true;
                CharacterDetails.Nose.freeze = true;
                CharacterDetails.Lips.freeze = true;
                CharacterDetails.BodyType.freeze = true;
                CharacterDetails.Voices.freeze = true;
                CharacterDetails.Hair.freeze = true;
                CharacterDetails.HairTone.freeze = true;
                CharacterDetails.HighlightTone.freeze = true;
                CharacterDetails.Jaw.freeze = true;
                CharacterDetails.RBust.freeze = true;
                CharacterDetails.RHeight.freeze = true;
                CharacterDetails.LipsTone.freeze = true;
                CharacterDetails.Skintone.freeze = true;
                CharacterDetails.FacialFeatures.freeze = true;
                CharacterDetails.TailorMuscle.freeze = true;
                CharacterDetails.Eye.freeze = true;
                CharacterDetails.RightEye.freeze = true;
                CharacterDetails.EyeBrowType.freeze = true;
                CharacterDetails.LeftEye.freeze = true;
                CharacterDetails.Offhand.freeze = true;
                CharacterDetails.FacePaint.freeze = true;
                CharacterDetails.FacePaintColor.freeze = true;
                CharacterDetails.Job.freeze = true;
                CharacterDetails.HeadPiece.freeze = true;
                CharacterDetails.Chest.freeze = true;
                CharacterDetails.Arms.freeze = true;
                CharacterDetails.Legs.freeze = true;
                CharacterDetails.Feet.freeze = true;
                CharacterDetails.Ear.freeze = true;
                CharacterDetails.Neck.freeze = true;
                CharacterDetails.Wrist.freeze = true;
                CharacterDetails.RFinger.freeze = true;
                CharacterDetails.LFinger.freeze = true;
                Task.Delay(450).Wait();
                CharacterDetails.Height.value = load1.Height.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Height), "float", load1.Height.value.ToString());
                CharacterDetails.MuscleTone.value = load1.MuscleTone.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.MuscleTone), "float", load1.MuscleTone.value.ToString());
                CharacterDetails.TailSize.value = load1.TailSize.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.TailSize), "float", load1.TailSize.value.ToString());
                CharacterDetails.BustX.value = load1.BustX.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "float", load1.BustX.value.ToString());
                CharacterDetails.BustY.value = load1.BustY.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y), "float", load1.BustY.value.ToString());
                CharacterDetails.BustZ.value = load1.BustZ.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z), "float", load1.BustZ.value.ToString());
                CharacterDetails.HairRedPigment.value = load1.HairRedPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairRedPigment), "float", load1.HairRedPigment.value.ToString());
                CharacterDetails.HairBluePigment.value = load1.HairBluePigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairBluePigment), "float", load1.HairBluePigment.value.ToString());
                CharacterDetails.HairGreenPigment.value = load1.HairGreenPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGreenPigment), "float", load1.HairGreenPigment.value.ToString());
                CharacterDetails.HairGlowRed.value = load1.HairGlowRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowRed), "float", load1.HairGlowRed.value.ToString());
                CharacterDetails.HairGlowGreen.value = load1.HairGlowGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowGreen), "float", load1.HairGlowGreen.value.ToString());
                CharacterDetails.HairGlowBlue.value = load1.HairGlowBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowBlue), "float", load1.HairGlowBlue.value.ToString());
                CharacterDetails.HighlightRedPigment.value = load1.HighlightRedPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightRedPigment), "float", load1.HighlightRedPigment.value.ToString());
                CharacterDetails.HighlightGreenPigment.value = load1.HighlightGreenPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightGreenPigment), "float", load1.HighlightGreenPigment.value.ToString());
                CharacterDetails.HighlightBluePigment.value = load1.HighlightBluePigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightBluePigment), "float", load1.HighlightBluePigment.value.ToString());
                CharacterDetails.SkinRedPigment.value = load1.SkinRedPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedPigment), "float", load1.SkinRedPigment.value.ToString());
                CharacterDetails.SkinGreenPigment.value = load1.SkinGreenPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenPigment), "float", load1.SkinGreenPigment.value.ToString());
                CharacterDetails.SkinBluePigment.value = load1.SkinBluePigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBluePigment), "float", load1.SkinBluePigment.value.ToString());
                CharacterDetails.SkinRedGloss.value = load1.SkinRedGloss.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedGloss), "float", load1.SkinRedGloss.value.ToString());
                CharacterDetails.SkinGreenGloss.value = load1.SkinGreenGloss.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenGloss), "float", load1.SkinGreenGloss.value.ToString());
                CharacterDetails.SkinBlueGloss.value = load1.SkinBlueGloss.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBlueGloss), "float", load1.SkinBlueGloss.value.ToString());
                CharacterDetails.LipsBrightness.value = load1.LipsBrightness.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsBrightness), "float", load1.LipsBrightness.value.ToString());
                CharacterDetails.LipsR.value = load1.LipsR.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsR), "float", load1.LipsR.value.ToString());
                CharacterDetails.LipsG.value = load1.LipsG.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsG), "float", load1.LipsG.value.ToString());
                CharacterDetails.LipsB.value = load1.LipsB.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsB), "float", load1.LipsB.value.ToString());
                CharacterDetails.LimbalR.value = load1.LimbalR.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalR), "float", load1.LimbalR.value.ToString());
                CharacterDetails.LimbalG.value = load1.LimbalG.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalG), "float", load1.LimbalG.value.ToString());
                CharacterDetails.LimbalB.value = load1.LimbalB.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalB), "float", load1.LimbalB.value.ToString());
                CharacterDetails.LeftEyeRed.value = load1.LeftEyeRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeRed), "float", load1.LeftEyeRed.value.ToString());
                CharacterDetails.LeftEyeGreen.value = load1.LeftEyeGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeGreen), "float", load1.LeftEyeGreen.value.ToString());
                CharacterDetails.LeftEyeBlue.value = load1.LeftEyeBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeBlue), "float", load1.LeftEyeBlue.value.ToString());
                CharacterDetails.RightEyeRed.value = load1.RightEyeRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeRed), "float", load1.RightEyeRed.value.ToString());
                CharacterDetails.RightEyeGreen.value = load1.RightEyeGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeGreen), "float", load1.RightEyeGreen.value.ToString());
                CharacterDetails.RightEyeBlue.value = load1.RightEyeBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeBlue), "float", load1.RightEyeBlue.value.ToString());
                CharacterDetails.WeaponX.value = load1.WeaponX.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponX), "float", load1.WeaponX.value.ToString());
                CharacterDetails.WeaponY.value = load1.WeaponY.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponY), "float", load1.WeaponY.value.ToString());
                CharacterDetails.WeaponZ.value = load1.WeaponZ.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponZ), "float", load1.WeaponZ.value.ToString());
                CharacterDetails.WeaponRed.value = load1.WeaponRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponRed), "float", load1.WeaponRed.value.ToString());
                CharacterDetails.WeaponBlue.value = load1.WeaponBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponBlue), "float", load1.WeaponBlue.value.ToString());
                CharacterDetails.WeaponGreen.value = load1.WeaponGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponGreen), "float", load1.WeaponGreen.value.ToString());
                CharacterDetails.OffhandBlue.value = load1.OffhandBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandBlue), "float", load1.OffhandBlue.value.ToString());
                CharacterDetails.OffhandGreen.value = load1.OffhandGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandGreen), "float", load1.OffhandGreen.value.ToString());
                CharacterDetails.OffhandRed.value = load1.OffhandRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandRed), "float", load1.OffhandRed.value.ToString());
                CharacterDetails.OffhandX.value = load1.OffhandX.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandX), "float", load1.OffhandX.value.ToString());
                CharacterDetails.OffhandY.value = load1.OffhandY.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandY), "float", load1.OffhandY.value.ToString());
                CharacterDetails.OffhandZ.value = load1.OffhandZ.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandZ), "float", load1.OffhandZ.value.ToString());
                CharacterDetails.Jaw.value = load1.Jaw.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Jaw), load1.Jaw.GetBytes());
                CharacterDetails.RHeight.value = load1.RHeight.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RHeight), load1.RHeight.GetBytes());
                CharacterDetails.EyeBrowType.value = load1.EyeBrowType.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EyeBrowType), load1.EyeBrowType.GetBytes());
                CharacterDetails.RBust.value = load1.RBust.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RBust), load1.RBust.GetBytes());
                CharacterDetails.Ear.value = load1.Ear.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Ear), load1.Ear.GetBytes());
                CharacterDetails.EarVa.value = load1.EarVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EarVa), load1.EarVa.GetBytes());
                CharacterDetails.Neck.value = load1.Neck.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Neck), load1.Neck.GetBytes());
                CharacterDetails.NeckVa.value = load1.NeckVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.NeckVa), load1.NeckVa.GetBytes());
                CharacterDetails.Wrist.value = load1.Wrist.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Wrist), load1.Wrist.GetBytes());
                CharacterDetails.WristVa.value = load1.WristVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WristVa), load1.WristVa.GetBytes());
                CharacterDetails.RFinger.value = load1.RFinger.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFinger), load1.RFinger.GetBytes());
                CharacterDetails.RFingerVa.value = load1.RFingerVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFingerVa), load1.RFingerVa.GetBytes());
                CharacterDetails.LFinger.value = load1.LFinger.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFinger), load1.LFinger.GetBytes());
                CharacterDetails.LFingerVa.value = load1.LFingerVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFingerVa), load1.LFingerVa.GetBytes());
                CharacterDetails.Job.value = load1.Job.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Job), load1.Job.GetBytes());
                CharacterDetails.WeaponBase.value = load1.WeaponBase.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponBase), load1.WeaponBase.GetBytes());
                CharacterDetails.WeaponV.value = load1.WeaponV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponV), load1.WeaponV.GetBytes());
                CharacterDetails.WeaponDye.value = load1.WeaponDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponDye), load1.WeaponDye.GetBytes());
                CharacterDetails.HeadPiece.value = load1.HeadPiece.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadPiece), load1.HeadPiece.GetBytes());
                CharacterDetails.HeadV.value = load1.HeadV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadV), load1.HeadV.GetBytes());
                CharacterDetails.HeadDye.value = load1.HeadDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadDye), load1.HeadDye.GetBytes());
                CharacterDetails.Chest.value = load1.Chest.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Chest), load1.Chest.GetBytes());
                CharacterDetails.ChestV.value = load1.ChestV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ChestV), load1.ChestV.GetBytes());
                CharacterDetails.ChestDye.value = load1.ChestDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ChestDye), load1.ChestDye.GetBytes());
                CharacterDetails.Arms.value = load1.Arms.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Arms), load1.Arms.GetBytes());
                CharacterDetails.ArmsV.value = load1.ArmsV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ArmsV), load1.ArmsV.GetBytes());
                CharacterDetails.ArmsDye.value = load1.ArmsDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ArmsDye), load1.ArmsDye.GetBytes());
                CharacterDetails.Legs.value = load1.Legs.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Legs), load1.Legs.GetBytes());
                CharacterDetails.LegsV.value = load1.LegsV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LegsV), load1.LegsV.GetBytes());
                CharacterDetails.LegsDye.value = load1.LegsDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LegsDye), load1.LegsDye.GetBytes());
                CharacterDetails.Feet.value = load1.Feet.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Feet), load1.Feet.GetBytes());
                CharacterDetails.FeetVa.value = load1.FeetVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FeetVa), load1.FeetVa.GetBytes());
                CharacterDetails.FeetDye.value = load1.FeetDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FeetDye), load1.FeetDye.GetBytes());
                CharacterDetails.Race.value = load1.Race.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Race), load1.Race.GetBytes());
                CharacterDetails.TailorMuscle.value = load1.TailorMuscle.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailorMuscle), load1.TailorMuscle.GetBytes());
                CharacterDetails.Clan.value = load1.Clan.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Clan), load1.Clan.GetBytes());
                CharacterDetails.Gender.value = load1.Gender.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Gender), load1.Gender.GetBytes());
                CharacterDetails.Head.value = load1.Head.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Head), load1.Head.GetBytes());
                CharacterDetails.TailType.value = load1.TailType.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailType), load1.TailType.GetBytes());
                CharacterDetails.Nose.value = load1.Nose.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Nose), load1.Nose.GetBytes());
                CharacterDetails.Lips.value = load1.Lips.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Lips), load1.Lips.GetBytes());
                CharacterDetails.LipsTone.value = load1.LipsTone.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsTone), load1.LipsTone.GetBytes());
                CharacterDetails.Voices.value = load1.Voices.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Voices), load1.Voices.GetBytes());
                CharacterDetails.Hair.value = load1.Hair.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Hair), load1.Hair.GetBytes());
                CharacterDetails.HairTone.value = load1.HairTone.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairTone), load1.HairTone.GetBytes());
                CharacterDetails.Highlights.value = load1.Highlights.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Highlights), load1.Highlights.GetBytes());
                CharacterDetails.HighlightTone.value = load1.HighlightTone.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightTone), load1.HighlightTone.GetBytes());
                CharacterDetails.Skintone.value = load1.Skintone.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Skintone), load1.Skintone.GetBytes());
                CharacterDetails.FacialFeatures.value = load1.FacialFeatures.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacialFeatures), load1.FacialFeatures.GetBytes());
                CharacterDetails.Eye.value = load1.Eye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Eye), load1.Eye.GetBytes());
                CharacterDetails.RightEye.value = load1.RightEye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEye), load1.RightEye.GetBytes());
                CharacterDetails.LeftEye.value = load1.LeftEye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEye), load1.LeftEye.GetBytes());
                CharacterDetails.FacePaint.value = load1.FacePaint.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaint), load1.FacePaint.GetBytes());
                CharacterDetails.FacePaintColor.value = load1.FacePaintColor.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), load1.FacePaintColor.GetBytes());
                CharacterDetails.Offhand.value = load1.Offhand.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Offhand), load1.Offhand.GetBytes());
                CharacterDetails.OffhandBase.value = load1.OffhandBase.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandBase), load1.OffhandBase.GetBytes());
                CharacterDetails.OffhandV.value = load1.OffhandV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandV), load1.OffhandV.GetBytes());
                CharacterDetails.OffhandDye.value = load1.OffhandDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandV), load1.OffhandDye.GetBytes());
                byte? NullableCheck = load1.BodyType.value;
                if (NullableCheck != null)
                {
                    CharacterDetails.BodyType.value = load1.BodyType.value;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), load1.FacePaintColor.GetBytes());
                }
                else
                {
                    CharacterDetails.BodyType.value = 0;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), CharacterDetails.BodyType.GetBytes());
                }
                Task.Delay(400).Wait();
                {
                    if (CharacterDetails.BodyType.freezetest == true) { CharacterDetails.BodyType.freeze = false; CharacterDetails.BodyType.freezetest = false; }
                    if (CharacterDetails.MuscleTone.freezetest == true) { CharacterDetails.MuscleTone.freeze = true; CharacterDetails.MuscleTone.freezetest = false; characterDetailsView.MuscleCheck.IsChecked = true; }
                    if (CharacterDetails.TailSize.freezetest == true) { CharacterDetails.TailSize.freeze = true; CharacterDetails.TailSize.freezetest = false; characterDetailsView.TailSizeCheck.IsChecked = true; }
                    if (CharacterDetails.BustX.freezetest == true) { CharacterDetails.BustX.freeze = true; CharacterDetails.BustX.freezetest = false; characterDetailsView.BustXCheck.IsChecked = true; }
                    if (CharacterDetails.BustY.freezetest == true) { CharacterDetails.BustY.freeze = true; CharacterDetails.BustY.freezetest = false; characterDetailsView.BustYCheck.IsChecked = true; }
                    if (CharacterDetails.BustZ.freezetest == true) { CharacterDetails.BustZ.freeze = true; CharacterDetails.BustZ.freezetest = false; characterDetailsView.BustZCheck.IsChecked = true; }
                    if (CharacterDetails.LipsBrightness.freezetest == true) { CharacterDetails.LipsBrightness.freeze = true; CharacterDetails.LipsBrightness.freezetest = false; characterDetailsView3.LipBright.IsChecked = true; }
                    if (CharacterDetails.SkinBlueGloss.freezetest == true) { CharacterDetails.SkinBlueGloss.freeze = true; CharacterDetails.SkinBlueGloss.freezetest = false; characterDetailsView3.BlueGloss.IsChecked = true; }
                    if (CharacterDetails.SkinGreenGloss.freezetest == true) { CharacterDetails.SkinGreenGloss.freeze = true; CharacterDetails.SkinGreenGloss.freezetest = false; characterDetailsView3.GreenGloss.IsChecked = true; }
                    if (CharacterDetails.SkinRedGloss.freezetest == true) { CharacterDetails.SkinRedGloss.freeze = true; CharacterDetails.SkinRedGloss.freezetest = false; characterDetailsView3.RedGloss.IsChecked = true; }
                    if (CharacterDetails.SkinBluePigment.freezetest == true) { CharacterDetails.SkinBluePigment.freeze = true; CharacterDetails.SkinBluePigment.freezetest = false; characterDetailsView3.SkinBlue.IsChecked = true; }
                    if (CharacterDetails.SkinGreenPigment.freezetest == true) { CharacterDetails.SkinGreenPigment.freeze = true; CharacterDetails.SkinGreenPigment.freezetest = false; characterDetailsView3.SkinGreen.IsChecked = true; }
                    if (CharacterDetails.SkinRedPigment.freezetest == true) { CharacterDetails.SkinRedPigment.freeze = true; CharacterDetails.SkinRedPigment.freezetest = false; characterDetailsView3.SkinRed.IsChecked = true; }
                    if (CharacterDetails.HighlightBluePigment.freezetest == true) { CharacterDetails.HighlightBluePigment.freeze = true; CharacterDetails.HighlightBluePigment.freezetest = false; characterDetailsView3.HLBP.IsChecked = true; }
                    if (CharacterDetails.HighlightGreenPigment.freezetest == true) { CharacterDetails.HighlightGreenPigment.freeze = true; CharacterDetails.HighlightGreenPigment.freezetest = false; characterDetailsView3.HLGP.IsChecked = true; }
                    if (CharacterDetails.HighlightRedPigment.freezetest == true) { CharacterDetails.HighlightRedPigment.freeze = true; CharacterDetails.HighlightRedPigment.freezetest = false; characterDetailsView3.HLRP.IsChecked = true; }
                    if (CharacterDetails.HairGlowBlue.freezetest == true) { CharacterDetails.HairGlowBlue.freeze = true; CharacterDetails.HairGlowBlue.freezetest = false; characterDetailsView3.HairBGCheck.IsChecked = true; }
                    if (CharacterDetails.HairGlowGreen.freezetest == true) { CharacterDetails.HairGlowGreen.freeze = true; CharacterDetails.HairGlowGreen.freezetest = false; characterDetailsView3.HairGGCheck.IsChecked = true; }
                    if (CharacterDetails.HairGlowRed.freezetest == true) { CharacterDetails.HairGlowRed.freeze = true; CharacterDetails.HairGlowRed.freezetest = false; characterDetailsView3.HairRGCheck.IsChecked = true; }
                    if (CharacterDetails.HairGreenPigment.freezetest == true) { CharacterDetails.HairGreenPigment.freeze = true; CharacterDetails.HairGreenPigment.freezetest = false; characterDetailsView3.HairGreenP.IsChecked = true; }
                    if (CharacterDetails.HairBluePigment.freezetest == true) { CharacterDetails.HairBluePigment.freeze = true; CharacterDetails.HairBluePigment.freezetest = false; characterDetailsView3.HairBlueP.IsChecked = true; }
                    if (CharacterDetails.HairRedPigment.freezetest == true) { CharacterDetails.HairRedPigment.freeze = true; CharacterDetails.HairRedPigment.freezetest = false; characterDetailsView3.HairRedP.IsChecked = true; }
                    if (CharacterDetails.Height.freezetest == true) { CharacterDetails.Height.freeze = true; CharacterDetails.Height.freezetest = false; characterDetailsView.HeightCheck.IsChecked = false; }
                    if (CharacterDetails.WeaponGreen.freezetest == true) { CharacterDetails.WeaponGreen.freeze = true; CharacterDetails.WeaponGreen.freezetest = false; characterDetailsView2.Green.IsChecked = true; }
                    if (CharacterDetails.WeaponBlue.freezetest == true) { CharacterDetails.WeaponBlue.freeze = true; CharacterDetails.WeaponBlue.freezetest = false; characterDetailsView2.Blue.IsChecked = true; }
                    if (CharacterDetails.WeaponRed.freezetest == true) { CharacterDetails.WeaponRed.freeze = true; CharacterDetails.WeaponRed.freezetest = false; characterDetailsView2.Red.IsChecked = true; }
                    if (CharacterDetails.WeaponZ.freezetest == true) { CharacterDetails.WeaponZ.freeze = true; CharacterDetails.WeaponZ.freezetest = false; characterDetailsView2.ScaleZ.IsChecked = true; }
                    if (CharacterDetails.WeaponY.freezetest == true) { CharacterDetails.WeaponY.freeze = true; CharacterDetails.WeaponY.freezetest = false; characterDetailsView2.ScaleY.IsChecked = true; }
                    if (CharacterDetails.WeaponX.freezetest == true) { CharacterDetails.WeaponX.freeze = true; CharacterDetails.WeaponX.freezetest = false; characterDetailsView2.ScaleX.IsChecked = true; }
                    if (CharacterDetails.OffhandZ.freezetest == true) { CharacterDetails.OffhandZ.freeze = true; CharacterDetails.OffhandZ.freezetest = false; characterDetailsView2.ScaleZ2.IsChecked = true; }
                    if (CharacterDetails.OffhandY.freezetest == true) { CharacterDetails.OffhandY.freeze = true; CharacterDetails.OffhandY.freezetest = false; characterDetailsView2.ScaleY2.IsChecked = true; }
                    if (CharacterDetails.OffhandX.freezetest == true) { CharacterDetails.OffhandX.freeze = true; CharacterDetails.OffhandX.freezetest = false; characterDetailsView2.ScaleX2.IsChecked = true; }
                    if (CharacterDetails.OffhandRed.freezetest == true) { CharacterDetails.OffhandRed.freeze = true; CharacterDetails.OffhandRed.freezetest = false; characterDetailsView2.Red2.IsChecked = true; }
                    if (CharacterDetails.OffhandBlue.freezetest == true) { CharacterDetails.OffhandBlue.freeze = true; CharacterDetails.OffhandBlue.freezetest = false; characterDetailsView2.Blue2.IsChecked = true; }
                    if (CharacterDetails.OffhandGreen.freezetest == true) { CharacterDetails.OffhandGreen.freeze = true; CharacterDetails.OffhandGreen.freezetest = false; characterDetailsView2.Green2.IsChecked = true; }
                    if (CharacterDetails.RightEyeBlue.freezetest == true) { CharacterDetails.RightEyeBlue.freeze = true; CharacterDetails.RightEyeBlue.freezetest = false; characterDetailsView3.BluePigment2.IsChecked = true; }
                    if (CharacterDetails.RightEyeGreen.freezetest == true) { CharacterDetails.RightEyeGreen.freeze = true; CharacterDetails.RightEyeGreen.freezetest = false; characterDetailsView3.GreenPigment2.IsChecked = true; }
                    if (CharacterDetails.RightEyeRed.freezetest == true) { CharacterDetails.RightEyeRed.freeze = true; CharacterDetails.RightEyeRed.freezetest = false; characterDetailsView3.RedPigment2.IsChecked = true; }
                    if (CharacterDetails.LeftEyeBlue.freezetest == true) { CharacterDetails.LeftEyeBlue.freeze = true; CharacterDetails.LeftEyeBlue.freezetest = false; characterDetailsView3.BEyePigment.IsChecked = true; }
                    if (CharacterDetails.LeftEyeGreen.freezetest == true) { CharacterDetails.LeftEyeGreen.freeze = true; CharacterDetails.LeftEyeGreen.freezetest = false; characterDetailsView3.GEyePigment.IsChecked = true; }
                    if (CharacterDetails.LeftEyeRed.freezetest == true) { CharacterDetails.LeftEyeRed.freeze = true; CharacterDetails.LeftEyeRed.freezetest = false; characterDetailsView3.REyePigment.IsChecked = true; }
                    if (CharacterDetails.LipsB.freezetest == true) { CharacterDetails.LipsB.freeze = true; CharacterDetails.LipsB.freezetest = false; characterDetailsView3.BluePigment.IsChecked = true; }
                    if (CharacterDetails.LipsG.freezetest == true) { CharacterDetails.LipsG.freeze = true; CharacterDetails.LipsG.freezetest = false; characterDetailsView3.GreenPigment.IsChecked = true; }
                    if (CharacterDetails.LipsR.freezetest == true) { CharacterDetails.LipsR.freeze = true; CharacterDetails.LipsR.freezetest = false; characterDetailsView3.RedPigment.IsChecked = true; }
                    if (CharacterDetails.LimbalR.freezetest == true) { CharacterDetails.LimbalR.freeze = true; CharacterDetails.LimbalR.freezetest = false; characterDetailsView3.LimbalR.IsChecked = true; }
                    if (CharacterDetails.LimbalB.freezetest == true) { CharacterDetails.LimbalB.freeze = true; CharacterDetails.LimbalB.freezetest = false; characterDetailsView3.LimbalB.IsChecked = true; }
                    if (CharacterDetails.LimbalG.freezetest == true) { CharacterDetails.LimbalG.freeze = true; CharacterDetails.LimbalG.freezetest = false; characterDetailsView3.LimbalG.IsChecked = true; }
                }
                Loadbutton.IsEnabled = true;
            }
        }
        private KonamiSequence sequence = new KonamiSequence();
        private void MetroWindow_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(Properties.Settings.Default.UnlockedK == false)
                if(haha.IsSelected)
                    if (sequence.IsCompletedBy(e.Key))
                    {
                        Properties.Settings.Default.UnlockedK = true;
                        Properties.Settings.Default.Save();
                        Process.Start(System.Windows.Application.ResourceAssembly.Location);
                        Application.Current.Shutdown();
                    }
        }
        private void Equipo()
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Filter = "Json File(*.json)|*.json";
            dig.DefaultExt = ".json";
            if (dig.ShowDialog() == true)
            {
                CharacterDetails load1 = JsonConvert.DeserializeObject<CharacterDetails>(File.ReadAllText(dig.FileName));
                Loadbutton.IsEnabled = false;
                var characterDetailsView = new CharacterDetailsView();
                var characterDetailsView2 = new CharacterDetailsView2();
                var characterDetailsView3 = new CharacterDetailsView3();
                {
                    if (CharacterDetails.WeaponGreen.freeze == true) { CharacterDetails.WeaponGreen.freeze = false; CharacterDetails.WeaponGreen.freezetest = true; characterDetailsView2.Green.IsChecked = false; }
                    if (CharacterDetails.WeaponBlue.freeze == true) { CharacterDetails.WeaponBlue.freeze = false; CharacterDetails.WeaponBlue.freezetest = true; characterDetailsView2.Blue.IsChecked = false; }
                    if (CharacterDetails.WeaponRed.freeze == true) { CharacterDetails.WeaponRed.freeze = false; CharacterDetails.WeaponRed.freezetest = true; characterDetailsView2.Red.IsChecked = false; }
                    if (CharacterDetails.WeaponZ.freeze == true) { CharacterDetails.WeaponZ.freeze = false; CharacterDetails.WeaponZ.freezetest = true; characterDetailsView2.ScaleZ.IsChecked = false; }
                    if (CharacterDetails.WeaponY.freeze == true) { CharacterDetails.WeaponY.freeze = false; CharacterDetails.WeaponY.freezetest = true; characterDetailsView2.ScaleY.IsChecked = false; }
                    if (CharacterDetails.WeaponX.freeze == true) { CharacterDetails.WeaponX.freeze = false; CharacterDetails.WeaponX.freezetest = true; characterDetailsView2.ScaleX.IsChecked = false; }
                    if (CharacterDetails.OffhandZ.freeze == true) { CharacterDetails.OffhandZ.freeze = false; CharacterDetails.OffhandZ.freezetest = true; characterDetailsView2.ScaleZ2.IsChecked = false; }
                    if (CharacterDetails.OffhandY.freeze == true) { CharacterDetails.OffhandY.freeze = false; CharacterDetails.OffhandY.freezetest = true; characterDetailsView2.ScaleY2.IsChecked = false; }
                    if (CharacterDetails.OffhandX.freeze == true) { CharacterDetails.OffhandX.freeze = false; CharacterDetails.OffhandX.freezetest = true; characterDetailsView2.ScaleX2.IsChecked = false; }
                    if (CharacterDetails.OffhandRed.freeze == true) { CharacterDetails.OffhandRed.freeze = false; CharacterDetails.OffhandRed.freezetest = true; characterDetailsView2.Red2.IsChecked = false; }
                    if (CharacterDetails.OffhandBlue.freeze == true) { CharacterDetails.OffhandBlue.freeze = false; CharacterDetails.OffhandBlue.freezetest = true; characterDetailsView2.Blue2.IsChecked = false; }
                    if (CharacterDetails.OffhandGreen.freeze == true) { CharacterDetails.OffhandGreen.freeze = false; CharacterDetails.OffhandGreen.freezetest = true; characterDetailsView2.Green2.IsChecked = false; }
                }
                CharacterDetails.Offhand.freeze = true;
                CharacterDetails.Job.freeze = true;
                CharacterDetails.HeadPiece.freeze = true;
                CharacterDetails.Chest.freeze = true;
                CharacterDetails.Arms.freeze = true;
                CharacterDetails.Legs.freeze = true;
                CharacterDetails.Feet.freeze = true;
                CharacterDetails.Ear.freeze = true;
                CharacterDetails.Neck.freeze = true;
                CharacterDetails.Wrist.freeze = true;
                CharacterDetails.RFinger.freeze = true;
                CharacterDetails.LFinger.freeze = true;
                Task.Delay(450).Wait();
                CharacterDetails.WeaponX.value = load1.WeaponX.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponX), "float", load1.WeaponX.value.ToString());
                CharacterDetails.WeaponY.value = load1.WeaponY.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponY), "float", load1.WeaponY.value.ToString());
                CharacterDetails.WeaponZ.value = load1.WeaponZ.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponZ), "float", load1.WeaponZ.value.ToString());
                CharacterDetails.WeaponRed.value = load1.WeaponRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponRed), "float", load1.WeaponRed.value.ToString());
                CharacterDetails.WeaponBlue.value = load1.WeaponBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponBlue), "float", load1.WeaponBlue.value.ToString());
                CharacterDetails.WeaponGreen.value = load1.WeaponGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponGreen), "float", load1.WeaponGreen.value.ToString());
                CharacterDetails.OffhandBlue.value = load1.OffhandBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandBlue), "float", load1.OffhandBlue.value.ToString());
                CharacterDetails.OffhandGreen.value = load1.OffhandGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandGreen), "float", load1.OffhandGreen.value.ToString());
                CharacterDetails.OffhandRed.value = load1.OffhandRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandRed), "float", load1.OffhandRed.value.ToString());
                CharacterDetails.OffhandX.value = load1.OffhandX.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandX), "float", load1.OffhandX.value.ToString());
                CharacterDetails.OffhandY.value = load1.OffhandY.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandY), "float", load1.OffhandY.value.ToString());
                CharacterDetails.OffhandZ.value = load1.OffhandZ.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandZ), "float", load1.OffhandZ.value.ToString());
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RBust), load1.RBust.GetBytes());
                CharacterDetails.Ear.value = load1.Ear.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Ear), load1.Ear.GetBytes());
                CharacterDetails.EarVa.value = load1.EarVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EarVa), load1.EarVa.GetBytes());
                CharacterDetails.Neck.value = load1.Neck.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Neck), load1.Neck.GetBytes());
                CharacterDetails.NeckVa.value = load1.NeckVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.NeckVa), load1.NeckVa.GetBytes());
                CharacterDetails.Wrist.value = load1.Wrist.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Wrist), load1.Wrist.GetBytes());
                CharacterDetails.WristVa.value = load1.WristVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WristVa), load1.WristVa.GetBytes());
                CharacterDetails.RFinger.value = load1.RFinger.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFinger), load1.RFinger.GetBytes());
                CharacterDetails.RFingerVa.value = load1.RFingerVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFingerVa), load1.RFingerVa.GetBytes());
                CharacterDetails.LFinger.value = load1.LFinger.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFinger), load1.LFinger.GetBytes());
                CharacterDetails.LFingerVa.value = load1.LFingerVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFingerVa), load1.LFingerVa.GetBytes());
                CharacterDetails.Job.value = load1.Job.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Job), load1.Job.GetBytes());
                CharacterDetails.WeaponBase.value = load1.WeaponBase.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponBase), load1.WeaponBase.GetBytes());
                CharacterDetails.WeaponV.value = load1.WeaponV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponV), load1.WeaponV.GetBytes());
                CharacterDetails.WeaponDye.value = load1.WeaponDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponDye), load1.WeaponDye.GetBytes());
                CharacterDetails.HeadPiece.value = load1.HeadPiece.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadPiece), load1.HeadPiece.GetBytes());
                CharacterDetails.HeadV.value = load1.HeadV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadV), load1.HeadV.GetBytes());
                CharacterDetails.HeadDye.value = load1.HeadDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadDye), load1.HeadDye.GetBytes());
                CharacterDetails.Chest.value = load1.Chest.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Chest), load1.Chest.GetBytes());
                CharacterDetails.ChestV.value = load1.ChestV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ChestV), load1.ChestV.GetBytes());
                CharacterDetails.ChestDye.value = load1.ChestDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ChestDye), load1.ChestDye.GetBytes());
                CharacterDetails.Arms.value = load1.Arms.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Arms), load1.Arms.GetBytes());
                CharacterDetails.ArmsV.value = load1.ArmsV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ArmsV), load1.ArmsV.GetBytes());
                CharacterDetails.ArmsDye.value = load1.ArmsDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ArmsDye), load1.ArmsDye.GetBytes());
                CharacterDetails.Legs.value = load1.Legs.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Legs), load1.Legs.GetBytes());
                CharacterDetails.LegsV.value = load1.LegsV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LegsV), load1.LegsV.GetBytes());
                CharacterDetails.LegsDye.value = load1.LegsDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LegsDye), load1.LegsDye.GetBytes());
                CharacterDetails.Feet.value = load1.Feet.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Feet), load1.Feet.GetBytes());
                CharacterDetails.FeetVa.value = load1.FeetVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FeetVa), load1.FeetVa.GetBytes());
                CharacterDetails.FeetDye.value = load1.FeetDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FeetDye), load1.FeetDye.GetBytes());
                CharacterDetails.Offhand.value = load1.Offhand.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Offhand), load1.Offhand.GetBytes());
                CharacterDetails.OffhandBase.value = load1.OffhandBase.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandBase), load1.OffhandBase.GetBytes());
                CharacterDetails.OffhandV.value = load1.OffhandV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandV), load1.OffhandV.GetBytes());
                CharacterDetails.OffhandDye.value = load1.OffhandDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandV), load1.OffhandDye.GetBytes());
                Task.Delay(400).Wait();
                {
                    if (CharacterDetails.WeaponGreen.freezetest == true) { CharacterDetails.WeaponGreen.freeze = true; CharacterDetails.WeaponGreen.freezetest = false; characterDetailsView2.Green.IsChecked = true; }
                    if (CharacterDetails.WeaponBlue.freezetest == true) { CharacterDetails.WeaponBlue.freeze = true; CharacterDetails.WeaponBlue.freezetest = false; characterDetailsView2.Blue.IsChecked = true; }
                    if (CharacterDetails.WeaponRed.freezetest == true) { CharacterDetails.WeaponRed.freeze = true; CharacterDetails.WeaponRed.freezetest = false; characterDetailsView2.Red.IsChecked = true; }
                    if (CharacterDetails.WeaponZ.freezetest == true) { CharacterDetails.WeaponZ.freeze = true; CharacterDetails.WeaponZ.freezetest = false; characterDetailsView2.ScaleZ.IsChecked = true; }
                    if (CharacterDetails.WeaponY.freezetest == true) { CharacterDetails.WeaponY.freeze = true; CharacterDetails.WeaponY.freezetest = false; characterDetailsView2.ScaleY.IsChecked = true; }
                    if (CharacterDetails.WeaponX.freezetest == true) { CharacterDetails.WeaponX.freeze = true; CharacterDetails.WeaponX.freezetest = false; characterDetailsView2.ScaleX.IsChecked = true; }
                    if (CharacterDetails.OffhandZ.freezetest == true) { CharacterDetails.OffhandZ.freeze = true; CharacterDetails.OffhandZ.freezetest = false; characterDetailsView2.ScaleZ2.IsChecked = true; }
                    if (CharacterDetails.OffhandY.freezetest == true) { CharacterDetails.OffhandY.freeze = true; CharacterDetails.OffhandY.freezetest = false; characterDetailsView2.ScaleY2.IsChecked = true; }
                    if (CharacterDetails.OffhandX.freezetest == true) { CharacterDetails.OffhandX.freeze = true; CharacterDetails.OffhandX.freezetest = false; characterDetailsView2.ScaleX2.IsChecked = true; }
                    if (CharacterDetails.OffhandRed.freezetest == true) { CharacterDetails.OffhandRed.freeze = true; CharacterDetails.OffhandRed.freezetest = false; characterDetailsView2.Red2.IsChecked = true; }
                    if (CharacterDetails.OffhandBlue.freezetest == true) { CharacterDetails.OffhandBlue.freeze = true; CharacterDetails.OffhandBlue.freezetest = false; characterDetailsView2.Blue2.IsChecked = true; }
                    if (CharacterDetails.OffhandGreen.freezetest == true) { CharacterDetails.OffhandGreen.freeze = true; CharacterDetails.OffhandGreen.freezetest = false; characterDetailsView2.Green2.IsChecked = true; }
                }
                Loadbutton.IsEnabled = true;
            }
        }
        private void Appereanco()
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Filter = "Json File(*.json)|*.json";
            dig.DefaultExt = ".json";
            if (dig.ShowDialog() == true)
            {
                CharacterDetails load1 = JsonConvert.DeserializeObject<CharacterDetails>(File.ReadAllText(dig.FileName));
                Loadbutton.IsEnabled = false;
                var characterDetailsView = new CharacterDetailsView();
                var characterDetailsView2 = new CharacterDetailsView2();
                var characterDetailsView3 = new CharacterDetailsView3();
                {
                    if (CharacterDetails.MuscleTone.freeze == true) { CharacterDetails.MuscleTone.freeze = false; CharacterDetails.MuscleTone.freezetest = true; characterDetailsView.MuscleCheck.IsChecked = false; }
                    if (CharacterDetails.TailSize.freeze == true) { CharacterDetails.TailSize.freeze = false; CharacterDetails.TailSize.freezetest = true; characterDetailsView.TailSizeCheck.IsChecked = false; }
                    if (CharacterDetails.BustX.freeze == true) { CharacterDetails.BustX.freeze = false; CharacterDetails.BustX.freezetest = true; characterDetailsView.BustXCheck.IsChecked = false; }
                    if (CharacterDetails.BustY.freeze == true) { CharacterDetails.BustY.freeze = false; CharacterDetails.BustY.freezetest = true; characterDetailsView.BustYCheck.IsChecked = false; }
                    if (CharacterDetails.BustZ.freeze == true) { CharacterDetails.BustZ.freeze = false; CharacterDetails.BustZ.freezetest = true; characterDetailsView.BustZCheck.IsChecked = false; }
                    if (CharacterDetails.LipsBrightness.freeze == true) { CharacterDetails.LipsBrightness.freeze = false; CharacterDetails.LipsBrightness.freezetest = true; characterDetailsView3.LipBright.IsChecked = false; }
                    if (CharacterDetails.SkinBlueGloss.freeze == true) { CharacterDetails.SkinBlueGloss.freeze = false; CharacterDetails.SkinBlueGloss.freezetest = true; characterDetailsView3.BlueGloss.IsChecked = false; }
                    if (CharacterDetails.SkinGreenGloss.freeze == true) { CharacterDetails.SkinGreenGloss.freeze = false; CharacterDetails.SkinGreenGloss.freezetest = true; characterDetailsView3.GreenGloss.IsChecked = false; }
                    if (CharacterDetails.SkinRedGloss.freeze == true) { CharacterDetails.SkinRedGloss.freeze = false; CharacterDetails.SkinRedGloss.freezetest = true; characterDetailsView3.RedGloss.IsChecked = false; }
                    if (CharacterDetails.SkinBluePigment.freeze == true) { CharacterDetails.SkinBluePigment.freeze = false; CharacterDetails.SkinBluePigment.freezetest = true; characterDetailsView3.SkinBlue.IsChecked = false; }
                    if (CharacterDetails.SkinGreenPigment.freeze == true) { CharacterDetails.SkinGreenPigment.freeze = false; CharacterDetails.SkinGreenPigment.freezetest = true; characterDetailsView3.SkinGreen.IsChecked = false; }
                    if (CharacterDetails.SkinRedPigment.freeze == true) { CharacterDetails.SkinRedPigment.freeze = false; CharacterDetails.SkinRedPigment.freezetest = true; characterDetailsView3.SkinRed.IsChecked = false; }
                    if (CharacterDetails.HighlightBluePigment.freeze == true) { CharacterDetails.HighlightBluePigment.freeze = false; CharacterDetails.HighlightBluePigment.freezetest = true; characterDetailsView3.HLBP.IsChecked = false; }
                    if (CharacterDetails.HighlightGreenPigment.freeze == true) { CharacterDetails.HighlightGreenPigment.freeze = false; CharacterDetails.HighlightGreenPigment.freezetest = true; characterDetailsView3.HLGP.IsChecked = false; }
                    if (CharacterDetails.HighlightRedPigment.freeze == true) { CharacterDetails.HighlightRedPigment.freeze = false; CharacterDetails.HighlightRedPigment.freezetest = true; characterDetailsView3.HLRP.IsChecked = false; }
                    if (CharacterDetails.HairGlowBlue.freeze == true) { CharacterDetails.HairGlowBlue.freeze = false; CharacterDetails.HairGlowBlue.freezetest = true; characterDetailsView3.HairBGCheck.IsChecked = false; }
                    if (CharacterDetails.HairGlowGreen.freeze == true) { CharacterDetails.HairGlowGreen.freeze = false; CharacterDetails.HairGlowGreen.freezetest = true; characterDetailsView3.HairGGCheck.IsChecked = false; }
                    if (CharacterDetails.HairGlowRed.freeze == true) { CharacterDetails.HairGlowRed.freeze = false; CharacterDetails.HairGlowRed.freezetest = true; characterDetailsView3.HairRGCheck.IsChecked = false; }
                    if (CharacterDetails.HairGreenPigment.freeze == true) { CharacterDetails.HairGreenPigment.freeze = false; CharacterDetails.HairGreenPigment.freezetest = true; characterDetailsView3.HairGreenP.IsChecked = false; }
                    if (CharacterDetails.HairBluePigment.freeze == true) { CharacterDetails.HairBluePigment.freeze = false; CharacterDetails.HairBluePigment.freezetest = true; characterDetailsView3.HairBlueP.IsChecked = false; }
                    if (CharacterDetails.HairRedPigment.freeze == true) { CharacterDetails.HairRedPigment.freeze = false; CharacterDetails.HairRedPigment.freezetest = true; characterDetailsView3.HairRedP.IsChecked = false; }
                    if (CharacterDetails.Height.freeze == true) { CharacterDetails.Height.freeze = false; CharacterDetails.Height.freezetest = true; characterDetailsView.HeightCheck.IsChecked = false; }
                    if (CharacterDetails.RightEyeBlue.freeze == true) { CharacterDetails.RightEyeBlue.freeze = false; CharacterDetails.RightEyeBlue.freezetest = true; characterDetailsView3.BluePigment2.IsChecked = false; }
                    if (CharacterDetails.RightEyeGreen.freeze == true) { CharacterDetails.RightEyeGreen.freeze = false; CharacterDetails.RightEyeGreen.freezetest = true; characterDetailsView3.GreenPigment2.IsChecked = false; }
                    if (CharacterDetails.RightEyeRed.freeze == true) { CharacterDetails.RightEyeRed.freeze = false; CharacterDetails.RightEyeRed.freezetest = true; characterDetailsView3.RedPigment2.IsChecked = false; }
                    if (CharacterDetails.LeftEyeBlue.freeze == true) { CharacterDetails.LeftEyeBlue.freeze = false; CharacterDetails.LeftEyeBlue.freezetest = true; characterDetailsView3.BEyePigment.IsChecked = false; }
                    if (CharacterDetails.LeftEyeGreen.freeze == true) { CharacterDetails.LeftEyeGreen.freeze = false; CharacterDetails.LeftEyeGreen.freezetest = true; characterDetailsView3.GEyePigment.IsChecked = false; }
                    if (CharacterDetails.LeftEyeRed.freeze == true) { CharacterDetails.LeftEyeRed.freeze = false; CharacterDetails.LeftEyeRed.freezetest = true; characterDetailsView3.REyePigment.IsChecked = false; }
                    if (CharacterDetails.LipsB.freeze == true) { CharacterDetails.LipsB.freeze = false; CharacterDetails.LipsB.freezetest = true; characterDetailsView3.BluePigment.IsChecked = false; }
                    if (CharacterDetails.LipsG.freeze == true) { CharacterDetails.LipsG.freeze = false; CharacterDetails.LipsG.freezetest = true; characterDetailsView3.GreenPigment.IsChecked = false; }
                    if (CharacterDetails.LipsR.freeze == true) { CharacterDetails.LipsR.freeze = false; CharacterDetails.LipsR.freezetest = true; characterDetailsView3.RedPigment.IsChecked = false; }
                    if (CharacterDetails.LimbalB.freeze == true) { CharacterDetails.LimbalB.freeze = false; CharacterDetails.LimbalB.freezetest = true; characterDetailsView3.LimbalB.IsChecked = false; }
                    if (CharacterDetails.LimbalG.freeze == true) { CharacterDetails.LimbalG.freeze = false; CharacterDetails.LimbalG.freezetest = true; characterDetailsView3.LimbalG.IsChecked = false; }
                    if (CharacterDetails.LimbalR.freeze == true) { CharacterDetails.LimbalR.freeze = false; CharacterDetails.LimbalR.freezetest = true; characterDetailsView3.LimbalR.IsChecked = false; }
                if (CharacterDetails.BodyType.freeze == false) { CharacterDetails.BodyType.freeze = true; CharacterDetails.BodyType.freezetest = true; }
              }
                CharacterDetails.Race.freeze = true;
                CharacterDetails.Clan.freeze = true;
                CharacterDetails.Gender.freeze = true;
                CharacterDetails.Head.freeze = true;
                CharacterDetails.TailType.freeze = true;
                CharacterDetails.Nose.freeze = true;
                CharacterDetails.Lips.freeze = true;
                CharacterDetails.BodyType.freeze = true;
                CharacterDetails.Voices.freeze = true;
                CharacterDetails.Hair.freeze = true;
                CharacterDetails.HairTone.freeze = true;
                CharacterDetails.HighlightTone.freeze = true;
                CharacterDetails.Jaw.freeze = true;
                CharacterDetails.RBust.freeze = true;
                CharacterDetails.RHeight.freeze = true;
                CharacterDetails.LipsTone.freeze = true;
                CharacterDetails.Skintone.freeze = true;
                CharacterDetails.FacialFeatures.freeze = true;
                CharacterDetails.TailorMuscle.freeze = true;
                CharacterDetails.Eye.freeze = true;
                CharacterDetails.RightEye.freeze = true;
                CharacterDetails.EyeBrowType.freeze = true;
                CharacterDetails.LeftEye.freeze = true;
                CharacterDetails.FacePaint.freeze = true;
                CharacterDetails.FacePaintColor.freeze = true;
                CharacterDetails.BodyType.freeze = true;
                Task.Delay(450).Wait();
                CharacterDetails.Height.value = load1.Height.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Height), "float", load1.Height.value.ToString());
                CharacterDetails.MuscleTone.value = load1.MuscleTone.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.MuscleTone), "float", load1.MuscleTone.value.ToString());
                CharacterDetails.TailSize.value = load1.TailSize.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.TailSize), "float", load1.TailSize.value.ToString());
                CharacterDetails.BustX.value = load1.BustX.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "float", load1.BustX.value.ToString());
                CharacterDetails.BustY.value = load1.BustY.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y), "float", load1.BustY.value.ToString());
                CharacterDetails.BustZ.value = load1.BustZ.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z), "float", load1.BustZ.value.ToString());
                CharacterDetails.HairRedPigment.value = load1.HairRedPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairRedPigment), "float", load1.HairRedPigment.value.ToString());
                CharacterDetails.HairBluePigment.value = load1.HairBluePigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairBluePigment), "float", load1.HairBluePigment.value.ToString());
                CharacterDetails.HairGreenPigment.value = load1.HairGreenPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGreenPigment), "float", load1.HairGreenPigment.value.ToString());
                CharacterDetails.HairGlowRed.value = load1.HairGlowRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowRed), "float", load1.HairGlowRed.value.ToString());
                CharacterDetails.HairGlowGreen.value = load1.HairGlowGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowGreen), "float", load1.HairGlowGreen.value.ToString());
                CharacterDetails.HairGlowBlue.value = load1.HairGlowBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowBlue), "float", load1.HairGlowBlue.value.ToString());
                CharacterDetails.HighlightRedPigment.value = load1.HighlightRedPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightRedPigment), "float", load1.HighlightRedPigment.value.ToString());
                CharacterDetails.HighlightGreenPigment.value = load1.HighlightGreenPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightGreenPigment), "float", load1.HighlightGreenPigment.value.ToString());
                CharacterDetails.HighlightBluePigment.value = load1.HighlightBluePigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightBluePigment), "float", load1.HighlightBluePigment.value.ToString());
                CharacterDetails.SkinRedPigment.value = load1.SkinRedPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedPigment), "float", load1.SkinRedPigment.value.ToString());
                CharacterDetails.SkinGreenPigment.value = load1.SkinGreenPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenPigment), "float", load1.SkinGreenPigment.value.ToString());
                CharacterDetails.SkinBluePigment.value = load1.SkinBluePigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBluePigment), "float", load1.SkinBluePigment.value.ToString());
                CharacterDetails.SkinRedGloss.value = load1.SkinRedGloss.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedGloss), "float", load1.SkinRedGloss.value.ToString());
                CharacterDetails.SkinGreenGloss.value = load1.SkinGreenGloss.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenGloss), "float", load1.SkinGreenGloss.value.ToString());
                CharacterDetails.SkinBlueGloss.value = load1.SkinBlueGloss.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBlueGloss), "float", load1.SkinBlueGloss.value.ToString());
                CharacterDetails.LipsBrightness.value = load1.LipsBrightness.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsBrightness), "float", load1.LipsBrightness.value.ToString());
                CharacterDetails.LipsR.value = load1.LipsR.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsR), "float", load1.LipsR.value.ToString());
                CharacterDetails.LipsG.value = load1.LipsG.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsG), "float", load1.LipsG.value.ToString());
                CharacterDetails.LipsB.value = load1.LipsB.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsB), "float", load1.LipsB.value.ToString());
                CharacterDetails.LimbalR.value = load1.LimbalR.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalR), "float", load1.LimbalR.value.ToString());
                CharacterDetails.LimbalG.value = load1.LimbalG.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalG), "float", load1.LimbalG.value.ToString());
                CharacterDetails.LimbalB.value = load1.LimbalB.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalB), "float", load1.LimbalB.value.ToString());
                CharacterDetails.LeftEyeRed.value = load1.LeftEyeRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeRed), "float", load1.LeftEyeRed.value.ToString());
                CharacterDetails.LeftEyeGreen.value = load1.LeftEyeGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeGreen), "float", load1.LeftEyeGreen.value.ToString());
                CharacterDetails.LeftEyeBlue.value = load1.LeftEyeBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeBlue), "float", load1.LeftEyeBlue.value.ToString());
                CharacterDetails.RightEyeRed.value = load1.RightEyeRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeRed), "float", load1.RightEyeRed.value.ToString());
                CharacterDetails.RightEyeGreen.value = load1.RightEyeGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeGreen), "float", load1.RightEyeGreen.value.ToString());
                CharacterDetails.RightEyeBlue.value = load1.RightEyeBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeBlue), "float", load1.RightEyeBlue.value.ToString());
                CharacterDetails.Jaw.value = load1.Jaw.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Jaw), load1.Jaw.GetBytes());
                CharacterDetails.RHeight.value = load1.RHeight.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RHeight), load1.RHeight.GetBytes());
                CharacterDetails.EyeBrowType.value = load1.EyeBrowType.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EyeBrowType), load1.EyeBrowType.GetBytes());
                CharacterDetails.RBust.value = load1.RBust.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RBust), load1.RBust.GetBytes());
                CharacterDetails.Race.value = load1.Race.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Race), load1.Race.GetBytes());
                CharacterDetails.TailorMuscle.value = load1.TailorMuscle.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailorMuscle), load1.TailorMuscle.GetBytes());
                CharacterDetails.Clan.value = load1.Clan.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Clan), load1.Clan.GetBytes());
                CharacterDetails.Gender.value = load1.Gender.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Gender), load1.Gender.GetBytes());
                CharacterDetails.Head.value = load1.Head.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Head), load1.Head.GetBytes());
                CharacterDetails.TailType.value = load1.TailType.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailType), load1.TailType.GetBytes());
                CharacterDetails.Nose.value = load1.Nose.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Nose), load1.Nose.GetBytes());
                CharacterDetails.Lips.value = load1.Lips.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Lips), load1.Lips.GetBytes());
                CharacterDetails.LipsTone.value = load1.LipsTone.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsTone), load1.LipsTone.GetBytes());
                CharacterDetails.Voices.value = load1.Voices.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Voices), load1.Voices.GetBytes());
                CharacterDetails.Hair.value = load1.Hair.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Hair), load1.Hair.GetBytes());
                CharacterDetails.HairTone.value = load1.HairTone.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairTone), load1.HairTone.GetBytes());
                CharacterDetails.Highlights.value = load1.Highlights.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Highlights), load1.Highlights.GetBytes());
                CharacterDetails.HighlightTone.value = load1.HighlightTone.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightTone), load1.HighlightTone.GetBytes());
                CharacterDetails.Skintone.value = load1.Skintone.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Skintone), load1.Skintone.GetBytes());
                CharacterDetails.FacialFeatures.value = load1.FacialFeatures.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacialFeatures), load1.FacialFeatures.GetBytes());
                CharacterDetails.Eye.value = load1.Eye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Eye), load1.Eye.GetBytes());
                CharacterDetails.RightEye.value = load1.RightEye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEye), load1.RightEye.GetBytes());
                CharacterDetails.LeftEye.value = load1.LeftEye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEye), load1.LeftEye.GetBytes());
                CharacterDetails.FacePaint.value = load1.FacePaint.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaint), load1.FacePaint.GetBytes());
                CharacterDetails.FacePaintColor.value = load1.FacePaintColor.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), load1.FacePaintColor.GetBytes());
                byte? NullableCheck = load1.BodyType.value;
                if (NullableCheck!=null)
                {
                    CharacterDetails.BodyType.value = load1.BodyType.value;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), load1.FacePaintColor.GetBytes());
                }
                else
                {
                    CharacterDetails.BodyType.value = 0;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), CharacterDetails.BodyType.GetBytes());
                }
                Task.Delay(400).Wait();
                {
                    if (CharacterDetails.BodyType.freezetest == true) { CharacterDetails.BodyType.freeze = false; CharacterDetails.BodyType.freezetest = false; }
                    if (CharacterDetails.MuscleTone.freezetest == true) { CharacterDetails.MuscleTone.freeze = true; CharacterDetails.MuscleTone.freezetest = false; characterDetailsView.MuscleCheck.IsChecked = true; }
                    if (CharacterDetails.TailSize.freezetest == true) { CharacterDetails.TailSize.freeze = true; CharacterDetails.TailSize.freezetest = false; characterDetailsView.TailSizeCheck.IsChecked = true; }
                    if (CharacterDetails.BustX.freezetest == true) { CharacterDetails.BustX.freeze = true; CharacterDetails.BustX.freezetest = false; characterDetailsView.BustXCheck.IsChecked = true; }
                    if (CharacterDetails.BustY.freezetest == true) { CharacterDetails.BustY.freeze = true; CharacterDetails.BustY.freezetest = false; characterDetailsView.BustYCheck.IsChecked = true; }
                    if (CharacterDetails.BustZ.freezetest == true) { CharacterDetails.BustZ.freeze = true; CharacterDetails.BustZ.freezetest = false; characterDetailsView.BustZCheck.IsChecked = true; }
                    if (CharacterDetails.LipsBrightness.freezetest == true) { CharacterDetails.LipsBrightness.freeze = true; CharacterDetails.LipsBrightness.freezetest = false; characterDetailsView3.LipBright.IsChecked = true; }
                    if (CharacterDetails.SkinBlueGloss.freezetest == true) { CharacterDetails.SkinBlueGloss.freeze = true; CharacterDetails.SkinBlueGloss.freezetest = false; characterDetailsView3.BlueGloss.IsChecked = true; }
                    if (CharacterDetails.SkinGreenGloss.freezetest == true) { CharacterDetails.SkinGreenGloss.freeze = true; CharacterDetails.SkinGreenGloss.freezetest = false; characterDetailsView3.GreenGloss.IsChecked = true; }
                    if (CharacterDetails.SkinRedGloss.freezetest == true) { CharacterDetails.SkinRedGloss.freeze = true; CharacterDetails.SkinRedGloss.freezetest = false; characterDetailsView3.RedGloss.IsChecked = true; }
                    if (CharacterDetails.SkinBluePigment.freezetest == true) { CharacterDetails.SkinBluePigment.freeze = true; CharacterDetails.SkinBluePigment.freezetest = false; characterDetailsView3.SkinBlue.IsChecked = true; }
                    if (CharacterDetails.SkinGreenPigment.freezetest == true) { CharacterDetails.SkinGreenPigment.freeze = true; CharacterDetails.SkinGreenPigment.freezetest = false; characterDetailsView3.SkinGreen.IsChecked = true; }
                    if (CharacterDetails.SkinRedPigment.freezetest == true) { CharacterDetails.SkinRedPigment.freeze = true; CharacterDetails.SkinRedPigment.freezetest = false; characterDetailsView3.SkinRed.IsChecked = true; }
                    if (CharacterDetails.HighlightBluePigment.freezetest == true) { CharacterDetails.HighlightBluePigment.freeze = true; CharacterDetails.HighlightBluePigment.freezetest = false; characterDetailsView3.HLBP.IsChecked = true; }
                    if (CharacterDetails.HighlightGreenPigment.freezetest == true) { CharacterDetails.HighlightGreenPigment.freeze = true; CharacterDetails.HighlightGreenPigment.freezetest = false; characterDetailsView3.HLGP.IsChecked = true; }
                    if (CharacterDetails.HighlightRedPigment.freezetest == true) { CharacterDetails.HighlightRedPigment.freeze = true; CharacterDetails.HighlightRedPigment.freezetest = false; characterDetailsView3.HLRP.IsChecked = true; }
                    if (CharacterDetails.HairGlowBlue.freezetest == true) { CharacterDetails.HairGlowBlue.freeze = true; CharacterDetails.HairGlowBlue.freezetest = false; characterDetailsView3.HairBGCheck.IsChecked = true; }
                    if (CharacterDetails.HairGlowGreen.freezetest == true) { CharacterDetails.HairGlowGreen.freeze = true; CharacterDetails.HairGlowGreen.freezetest = false; characterDetailsView3.HairGGCheck.IsChecked = true; }
                    if (CharacterDetails.HairGlowRed.freezetest == true) { CharacterDetails.HairGlowRed.freeze = true; CharacterDetails.HairGlowRed.freezetest = false; characterDetailsView3.HairRGCheck.IsChecked = true; }
                    if (CharacterDetails.HairGreenPigment.freezetest == true) { CharacterDetails.HairGreenPigment.freeze = true; CharacterDetails.HairGreenPigment.freezetest = false; characterDetailsView3.HairGreenP.IsChecked = true; }
                    if (CharacterDetails.HairBluePigment.freezetest == true) { CharacterDetails.HairBluePigment.freeze = true; CharacterDetails.HairBluePigment.freezetest = false; characterDetailsView3.HairBlueP.IsChecked = true; }
                    if (CharacterDetails.HairRedPigment.freezetest == true) { CharacterDetails.HairRedPigment.freeze = true; CharacterDetails.HairRedPigment.freezetest = false; characterDetailsView3.HairRedP.IsChecked = true; }
                    if (CharacterDetails.Height.freezetest == true) { CharacterDetails.Height.freeze = true; CharacterDetails.Height.freezetest = false; characterDetailsView.HeightCheck.IsChecked = false; }
                    if (CharacterDetails.RightEyeBlue.freezetest == true) { CharacterDetails.RightEyeBlue.freeze = true; CharacterDetails.RightEyeBlue.freezetest = false; characterDetailsView3.BluePigment2.IsChecked = true; }
                    if (CharacterDetails.RightEyeGreen.freezetest == true) { CharacterDetails.RightEyeGreen.freeze = true; CharacterDetails.RightEyeGreen.freezetest = false; characterDetailsView3.GreenPigment2.IsChecked = true; }
                    if (CharacterDetails.RightEyeRed.freezetest == true) { CharacterDetails.RightEyeRed.freeze = true; CharacterDetails.RightEyeRed.freezetest = false; characterDetailsView3.RedPigment2.IsChecked = true; }
                    if (CharacterDetails.LeftEyeBlue.freezetest == true) { CharacterDetails.LeftEyeBlue.freeze = true; CharacterDetails.LeftEyeBlue.freezetest = false; characterDetailsView3.BEyePigment.IsChecked = true; }
                    if (CharacterDetails.LeftEyeGreen.freezetest == true) { CharacterDetails.LeftEyeGreen.freeze = true; CharacterDetails.LeftEyeGreen.freezetest = false; characterDetailsView3.GEyePigment.IsChecked = true; }
                    if (CharacterDetails.LeftEyeRed.freezetest == true) { CharacterDetails.LeftEyeRed.freeze = true; CharacterDetails.LeftEyeRed.freezetest = false; characterDetailsView3.REyePigment.IsChecked = true; }
                    if (CharacterDetails.LipsB.freezetest == true) { CharacterDetails.LipsB.freeze = true; CharacterDetails.LipsB.freezetest = false; characterDetailsView3.BluePigment.IsChecked = true; }
                    if (CharacterDetails.LipsG.freezetest == true) { CharacterDetails.LipsG.freeze = true; CharacterDetails.LipsG.freezetest = false; characterDetailsView3.GreenPigment.IsChecked = true; }
                    if (CharacterDetails.LipsR.freezetest == true) { CharacterDetails.LipsR.freeze = true; CharacterDetails.LipsR.freezetest = false; characterDetailsView3.RedPigment.IsChecked = true; }
                    if (CharacterDetails.LimbalR.freezetest == true) { CharacterDetails.LimbalR.freeze = true; CharacterDetails.LimbalR.freezetest = false; characterDetailsView3.LimbalR.IsChecked = true; }
                    if (CharacterDetails.LimbalB.freezetest == true) { CharacterDetails.LimbalB.freeze = true; CharacterDetails.LimbalB.freezetest = false; characterDetailsView3.LimbalB.IsChecked = true; }
                    if (CharacterDetails.LimbalG.freezetest == true) { CharacterDetails.LimbalG.freeze = true; CharacterDetails.LimbalG.freezetest = false; characterDetailsView3.LimbalG.IsChecked = true; }
                }
                Loadbutton.IsEnabled = true;
            }
        }
    }
}