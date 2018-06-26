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
        private BackgroundWorker worker2;
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        public MainWindow()
        {
            InitializeComponent();

        }
        private void CharacterDetailsView_Loaded()
        {

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
            worker2.DoWork += Worker_DoWork2;
            // run the worker
            worker2.RunWorkerAsync();
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
                //
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