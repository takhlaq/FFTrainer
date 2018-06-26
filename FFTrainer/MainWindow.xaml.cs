using System;
using System.Windows;
using FFTrainer.Models;
using System.ComponentModel;
using System.Threading;
using FFTrainer.ViewModels;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Win32;

namespace FFTrainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    public partial class MainWindow : Window
    {
        private BackgroundWorker worker2, worker3;
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        public MainWindow()
        {
            InitializeComponent();

        }
        private void CharacterDetailsView_Loaded()
        {

        }
        private void Worker_DoWork3(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (!CharacterDetails.Job.freeze)
                {
                    CharacterDetails.Job.value = (CharacterDetails.Jobs)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Job));
                    CharacterDetails.WeaponBase.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponBase));
                    CharacterDetails.WeaponV.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponV));
                    CharacterDetails.WeaponDye.value = (CharacterDetails.Dyes)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponDye));
                }
                else
                {
                    int xd = (int)CharacterDetails.Job.value;
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Job), "int", xd.ToString());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponBase), CharacterDetails.WeaponBase.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponV), CharacterDetails.WeaponV.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponDye), CharacterDetails.WeaponDye.GetBytes());
                }
                if (CharacterDetails.HeadPiece.freeze)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadPiece), CharacterDetails.HeadPiece.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadV), CharacterDetails.HeadV.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadDye), CharacterDetails.HeadDye.GetBytes());
                }
                else
                {
                    CharacterDetails.HeadPiece.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadPiece));
                    CharacterDetails.HeadV.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadV));
                    CharacterDetails.HeadDye.value = (CharacterDetails.Dyes)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadDye));
                }
                if (CharacterDetails.Chest.freeze)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Chest), CharacterDetails.Chest.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ChestV), CharacterDetails.ChestV.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ChestDye), CharacterDetails.ChestDye.GetBytes());
                }
                else
                {
                    CharacterDetails.Chest.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Chest));
                    CharacterDetails.ChestV.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ChestV));
                    CharacterDetails.ChestDye.value = (CharacterDetails.Dyes)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ChestDye));
                }
                if (CharacterDetails.Arms.freeze)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Arms), CharacterDetails.Arms.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ArmsV), CharacterDetails.ArmsV.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ArmsDye), CharacterDetails.ArmsDye.GetBytes());
                }
                else
                {
                    CharacterDetails.Arms.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Arms));
                    CharacterDetails.ArmsV.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ArmsV));
                    CharacterDetails.ArmsDye.value = (CharacterDetails.Dyes)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ArmsDye));
                }
                if (CharacterDetails.Legs.freeze)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Legs), CharacterDetails.Legs.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LegsV), CharacterDetails.LegsV.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LegsDye), CharacterDetails.LegsDye.GetBytes());
                }
                else
                {
                    CharacterDetails.Legs.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Legs));
                    CharacterDetails.LegsV.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LegsV));
                    CharacterDetails.LegsDye.value = (CharacterDetails.Dyes)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LegsDye));
                }
                if (CharacterDetails.Feet.freeze)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Feet), CharacterDetails.Feet.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FeetVa), CharacterDetails.FeetVa.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FeetDye), CharacterDetails.FeetDye.GetBytes());
                }
                else
                {
                    CharacterDetails.Feet.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Feet));
                    CharacterDetails.FeetVa.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FeetVa));
                    CharacterDetails.FeetDye.value = (CharacterDetails.Dyes)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FeetDye));
                }

                if (CharacterDetails.LFinger.freeze)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFinger), CharacterDetails.LFinger.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFingerVa), CharacterDetails.LFingerVa.GetBytes());
                }
                else
                {
                    CharacterDetails.LFinger.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFinger));
                    CharacterDetails.LFingerVa.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFingerVa));
                }
                if (CharacterDetails.RFinger.freeze)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFinger), CharacterDetails.RFinger.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFingerVa), CharacterDetails.RFingerVa.GetBytes());
                }
                else
                {
                    CharacterDetails.RFinger.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFinger));
                    CharacterDetails.RFingerVa.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFingerVa));
                }
                if (CharacterDetails.Wrist.freeze)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Wrist), CharacterDetails.Wrist.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WristVa), CharacterDetails.WristVa.GetBytes());
                }
                else
                {
                    CharacterDetails.Wrist.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Wrist));
                    CharacterDetails.WristVa.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WristVa));
                }
                if (CharacterDetails.Neck.freeze)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Neck), CharacterDetails.Neck.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.NeckVa), CharacterDetails.NeckVa.GetBytes());
                }
                else
                {
                    CharacterDetails.Neck.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Neck));
                    CharacterDetails.NeckVa.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.NeckVa));
                }
                if (CharacterDetails.Ear.freeze)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Ear), CharacterDetails.Ear.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EarVa), CharacterDetails.EarVa.GetBytes());
                }
                else
                {
                    CharacterDetails.Ear.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Ear));
                    CharacterDetails.EarVa.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EarVa));
                }
                if (!CharacterDetails.Race.freeze)
                    CharacterDetails.Race.value = (CharacterDetails.Races)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Race));
                else
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Race), CharacterDetails.Race.GetBytes());

                if (!CharacterDetails.Clan.freeze)
                    CharacterDetails.Clan.value = (CharacterDetails.Clans)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Clan));
                else
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Clan), CharacterDetails.Clan.GetBytes());

                if (!CharacterDetails.Gender.freeze)
                    CharacterDetails.Gender.value = (CharacterDetails.Genders)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Gender));
                else
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Gender), CharacterDetails.Gender.GetBytes());
                if (CharacterDetails.Head.freeze)
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Head), CharacterDetails.Head.GetBytes());
                else CharacterDetails.Head.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Head));

                if (CharacterDetails.Hair.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Hair), CharacterDetails.Hair.GetBytes());
                else CharacterDetails.Hair.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Hair));
                if (CharacterDetails.TailType.freeze)
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailType), CharacterDetails.TailType.GetBytes());
                else CharacterDetails.TailType.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailType));

                if (CharacterDetails.HairTone.freeze)
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairTone), CharacterDetails.HairTone.GetBytes());
                else CharacterDetails.HairTone.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairTone));

                CharacterDetails.Highlights.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Highlights));

                if (CharacterDetails.HighlightTone.freeze)
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightTone), CharacterDetails.HighlightTone.GetBytes());
                else CharacterDetails.HighlightTone.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightTone));

                if (CharacterDetails.Skintone.freeze)
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Skintone), CharacterDetails.Skintone.GetBytes());
                else CharacterDetails.Skintone.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Skintone));

                if (CharacterDetails.Lips.freeze)
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Lips), CharacterDetails.Lips.GetBytes());
                else CharacterDetails.Lips.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Lips));

                if (CharacterDetails.LipsTone.freeze)
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsTone), CharacterDetails.LipsTone.GetBytes());
                else CharacterDetails.LipsTone.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsTone));

                if (CharacterDetails.Nose.freeze)
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Nose), CharacterDetails.Nose.GetBytes());
                else CharacterDetails.Nose.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Nose));

                if (CharacterDetails.FacePaintColor.freeze)
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), CharacterDetails.FacePaintColor.GetBytes());
                else CharacterDetails.FacePaintColor.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor));

                if (CharacterDetails.FacePaint.freeze)
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaint), CharacterDetails.FacePaint.GetBytes());
                else CharacterDetails.FacePaint.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaint));

                if (CharacterDetails.LeftEye.freeze)
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEye), CharacterDetails.LeftEye.GetBytes());
                else CharacterDetails.LeftEye.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEye));

                if (CharacterDetails.RightEye.freeze)
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEye), CharacterDetails.RightEye.GetBytes());
                else CharacterDetails.RightEye.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEye));

                if (CharacterDetails.Eye.freeze)
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Eye), CharacterDetails.Eye.GetBytes());
                else CharacterDetails.Eye.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Eye));

                if (CharacterDetails.FacialFeatures.freeze)
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacialFeatures), CharacterDetails.FacialFeatures.GetBytes());
                else CharacterDetails.FacialFeatures.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacialFeatures));

                Thread.Sleep(100);
            }
        }
        private void Worker_DoWork2(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (CharacterDetails.EmoteSpeed1.freeze)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.EmoteSpeed1), CharacterDetails.EmoteSpeed1.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.EmoteSpeed2), CharacterDetails.EmoteSpeed1.GetBytes());
                }
                else
                {
                    CharacterDetails.EmoteSpeed1.value = MemoryManager.Instance.MemLib.readFloat((MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.EmoteSpeed1)));
                }
                if (CharacterDetails.Emote.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.Emote), CharacterDetails.Emote.GetBytes());
                else CharacterDetails.Emote.value = (int)MemoryManager.Instance.MemLib.read2Byte((MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.Emote)));
                Thread.Sleep(1);
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
            worker2 = new BackgroundWorker();
            worker3 = new BackgroundWorker();
            worker2.DoWork += Worker_DoWork2;
            worker3.DoWork += Worker_DoWork3;
            // run the worker
            worker2.RunWorkerAsync();
            worker3.RunWorkerAsync();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/nxu2Ydp");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dig = new SaveFileDialog();
            dig.Filter = "Json File(*.json)|*.json";
            dig.InitialDirectory = Environment.CurrentDirectory;
            if (dig.ShowDialog() == true)
            {
                CharacterDetails Save1 = new CharacterDetails(); // CharacterDetails is class with all address
                Save1 = CharacterDetails;
                string details = JsonConvert.SerializeObject(Save1,Formatting.Indented);
                File.WriteAllText(dig.FileName, details);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Filter = "Json File(*.json)|*.json";
            dig.DefaultExt = ".json";
            if (dig.ShowDialog() == true)
            {
                CharacterDetails load1 = JsonConvert.DeserializeObject<CharacterDetails>(File.ReadAllText(dig.FileName));
                CharacterDetailsViewModel.TestxD = true; // This will check Files are being loaded in
                CharacterDetails.Height.value = load1.Height.value;
                CharacterDetails.BustX.value = load1.BustX.value;
                CharacterDetails.BustY.value = load1.BustY.value;
                CharacterDetails.BustZ.value = load1.BustZ.value;
                CharacterDetails.Race.freeze = true;
                CharacterDetails.Clan.freeze = true;
                CharacterDetails.Gender.freeze = true;
                CharacterDetails.Head.freeze = true;
                CharacterDetails.TailType.freeze = true;
                CharacterDetails.Nose.freeze = true;
                CharacterDetails.Lips.freeze = true;
                CharacterDetails.Voices.freeze = true;
                CharacterDetails.Hair.freeze = true;
                CharacterDetails.HairTone.freeze = true;
                CharacterDetails.HighlightTone.freeze = true;
                CharacterDetails.LipsTone.freeze = true;
                CharacterDetails.Skintone.freeze = true;
                CharacterDetails.FacialFeatures.freeze = true;
                CharacterDetails.Eye.freeze = true;
                CharacterDetails.RightEye.freeze = true;
                CharacterDetails.LeftEye.freeze = true;
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
                CharacterDetails.TailSize.value = load1.TailSize.value;
                CharacterDetails.MuscleTone.value = load1.MuscleTone.value;
                CharacterDetails.Ear.value = load1.Ear.value;
                CharacterDetails.EarVa.value = load1.EarVa.value;
                CharacterDetails.Neck.value = load1.Neck.value;
                CharacterDetails.NeckVa.value = load1.NeckVa.value;
                CharacterDetails.Wrist.value = load1.Wrist.value;
                CharacterDetails.WristVa.value = load1.WristVa.value;
                CharacterDetails.RFinger.value = load1.RFinger.value;
                CharacterDetails.RFingerVa.value = load1.RFingerVa.value;
                CharacterDetails.LFinger.value = load1.LFinger.value;
                CharacterDetails.LFingerVa.value = load1.LFingerVa.value;
                CharacterDetails.Job.value = load1.Job.value;
                CharacterDetails.WeaponBase.value = load1.WeaponBase.value;
                CharacterDetails.WeaponV.value = load1.WeaponV.value;
                CharacterDetails.WeaponDye.value = load1.WeaponDye.value;
                CharacterDetails.HeadPiece.value = load1.HeadPiece.value;
                CharacterDetails.HeadV.value = load1.HeadV.value;
                CharacterDetails.HeadDye.value = load1.HeadDye.value;
                CharacterDetails.Chest.value = load1.Chest.value;
                CharacterDetails.ChestV.value = load1.ChestV.value;
                CharacterDetails.ChestDye.value = load1.ChestDye.value;
                CharacterDetails.Arms.value = load1.Arms.value;
                CharacterDetails.ArmsV.value = load1.ArmsV.value;
                CharacterDetails.ArmsDye.value = load1.ArmsDye.value;
                CharacterDetails.Legs.value = load1.Legs.value;
                CharacterDetails.LegsV.value = load1.LegsV.value;
                CharacterDetails.LegsDye.value = load1.LegsDye.value;
                CharacterDetails.Feet.value = load1.Feet.value;
                CharacterDetails.FeetVa.value = load1.FeetVa.value;
                CharacterDetails.FeetDye.value = load1.FeetDye.value;
                CharacterDetails.Race.value = load1.Race.value;
                CharacterDetails.Clan.value = load1.Clan.value;
                CharacterDetails.Gender.value = load1.Gender.value;
                CharacterDetails.Head.value = load1.Head.value;
                CharacterDetails.TailType.value = load1.TailType.value;
                CharacterDetails.Nose.value = load1.Nose.value;
                CharacterDetails.Lips.value = load1.Lips.value;
                CharacterDetails.LipsTone.value = load1.LipsTone.value;
                CharacterDetails.Voices.value = load1.Voices.value;
                CharacterDetails.Hair.value = load1.Hair.value;
                CharacterDetails.HairTone.value = load1.HairTone.value;
                CharacterDetails.Highlights.value = load1.Highlights.value;
                CharacterDetails.HighlightTone.value = load1.HighlightTone.value;
                CharacterDetails.Skintone.value = load1.Skintone.value;
                CharacterDetails.FacialFeatures.value = load1.FacialFeatures.value;
                CharacterDetails.Eye.value = load1.Eye.value;
                CharacterDetails.RightEye.value = load1.LeftEye.value;
                CharacterDetails.LeftEye.value = load1.LeftEye.value;
                CharacterDetails.FacePaint.value = load1.FacePaint.value;
                CharacterDetails.FacePaintColor.value = load1.FacePaintColor.value;
                CharacterDetails.WeaponRed.value = load1.WeaponRed.value;
                CharacterDetails.WeaponBlue.value = load1.WeaponBlue.value;
                CharacterDetails.WeaponGreen.value = load1.WeaponGreen.value;
                CharacterDetails.SkinRedGloss.value = load1.SkinRedGloss.value;
                CharacterDetails.SkinRedPigment.value = load1.SkinRedPigment.value;
                CharacterDetails.SkinGreenGloss.value = load1.SkinGreenGloss.value;
                CharacterDetails.SkinBlueGloss.value = load1.SkinBlueGloss.value;
                CharacterDetails.SkinBluePigment.value = load1.SkinBluePigment.value;
                CharacterDetails.HairBluePigment.value = load1.HairBluePigment.value;
                CharacterDetails.HairGreenPigment.value = load1.HairGreenPigment.value;
                CharacterDetails.HairRedPigment.value = load1.HairRedPigment.value;
                CharacterDetails.HairGlowRed.value = load1.HairGlowRed.value;
                CharacterDetails.HairGlowBlue.value = load1.HairGlowBlue.value;
                CharacterDetails.HairGlowGreen.value = load1.HairGlowGreen.value;
                CharacterDetails.HighlightRedPigment.value = load1.HighlightRedPigment.value;
                CharacterDetails.HighlightBluePigment.value = load1.HighlightBluePigment.value;
                CharacterDetails.HighlightGreenPigment.value = load1.HighlightGreenPigment.value;
                CharacterDetails.LeftEyeBlue.value = load1.LeftEyeBlue.value;
                CharacterDetails.LeftEyeGreen.value = load1.LeftEyeGreen.value;
                CharacterDetails.LeftEyeRed.value = load1.LeftEyeRed.value;
                CharacterDetails.RightEyeRed.value = load1.RightEyeRed.value;
                CharacterDetails.RightEyeGreen.value = load1.RightEyeGreen.value;
                CharacterDetails.RightEyeBlue.value = load1.RightEyeBlue.value;
                CharacterDetails.LipsBrightness.value = load1.LipsBrightness.value;
                CharacterDetails.LipsR.value = load1.LipsR.value;
                CharacterDetails.LipsB.value = load1.LipsB.value;
                CharacterDetails.LipsG.value = load1.LipsG.value;
                CharacterDetailsViewModel.TestxD = false; // This will check Files finshed loading


                /* using (StreamReader reader = File.OpenText(dig.FileName))
                 {
                     JsonSerializer serializer = new JsonSerializer();
                     CharacterDetails load1 = (CharacterDetails)serializer.Deserialize(reader, typeof(CharacterDetails));
                     CharacterDetails = load1;
                 }*/
            }
        }
    }
}
/*
 *             var serializer = new XmlSerializer(typeof(Settings), "");
            // create namespace to remove it for the serializer
            var ns = new XmlSerializerNamespaces();
            // add blank namespaces
            ns.Add("", "");
           // string xmlData = Properties.Resources.Settings;
            var document = XDocument.Load(@"https://raw.githubusercontent.com/SaberNaut/xd/master/Settings.xml");
            // using a stream reader
            using (StringReader reader = new StringReader(document.ToString()))
            {
                try
                {
                    Settings.Instance = (Settings)serializer.Deserialize(reader);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
*/