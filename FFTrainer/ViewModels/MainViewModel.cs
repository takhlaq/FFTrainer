using System;
using System.ComponentModel;
using System.IO;
using System.Globalization;
using System.Threading;
using Memory;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Net;
using AutoUpdaterDotNET;
using FFTrainer.Models;

namespace FFTrainer.ViewModels
{
    public delegate void WorkEventHandler();
    public delegate void EntitySelectionEventHandler(string offset);
    public class Mediator
    {
        public event WorkEventHandler Work;
        public event EntitySelectionEventHandler EntitySelection;
        public CharacterDetails Characterdetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }

        public void SendEntitySelection(string offset)
        {
            EntitySelection?.Invoke(offset);
        }

        public void SendWork()
        {
            Work?.Invoke();
        }
    }
    public class MemoryManager
    {

        private static MemoryManager instance;
        /// <summary>
        /// Singleton instance of the MemoryManager
        /// </summary>
        public static MemoryManager Instance
        {
            get
            {
                // create an instance of the MemoryManager if the value is null
                if (instance == null)
                    instance = new MemoryManager();
                return instance;
            }
        }

        /// <summary>
        /// The mem instance
        /// </summary>
        private Mem memLib;
        public Mem MemLib
        {
            get => memLib;
        }

        public string BaseAddress { get; set; }
        public string CameraAddress { get; set; }
        public string GposeAddress { get; set; }
        public string EmoteAddress { get; set; }
        public string WeatherAddress { get; set; }
        public string TimeAddress { get; set; }
        public string TerritoryAddress { get; set; }

        /// <summary>
        /// Constructor for the singleton memory manager
        /// </summary>
        public MemoryManager()
        {
            // create a new instance of Mem
            memLib = new Mem();
        }

        /// <summary>
        /// Open the process in MemLib
        /// </summary>
        /// <param name="pid"></param>
        public void OpenProcess(int pid)
        {
            // open the process
            if (!memLib.OpenProcess(pid.ToString()))
                throw new Exception("Couldn't open process!");
        }

        /// <summary>
        /// Get a string for use in memlib
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
		public bool IsReady()
		{
			return !memLib.theProc.HasExited;
		}
        public string GetBaseAddress(long offset)
        {
            return (memLib.theProc.MainModule.BaseAddress.ToInt64() + offset).ToString("X");
        }

        /// <summary>
        /// Returns if there is a process opened
        /// </summary>
        /// <returns></returns>

        /// <summary>
        /// Adds two hex strings together
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string Add(string a, string b)
        {
            return (long.Parse(a, NumberStyles.HexNumber) + long.Parse(b, NumberStyles.HexNumber)).ToString("X");
        }

        public static string GetAddressString(params string[] addr)
        {
            var ret = "";

            foreach (var a in addr)
                ret += a + ",";

            return ret.TrimEnd(',');
        }
    }
    public class MainViewModel
    {
        private Mediator mediator;

        private BackgroundWorker worker;
        public Mem MemLib = new Mem();
        private CharacterDetailsViewModel characterDetails;
        public CharacterDetailsViewModel CharacterDetails { get => characterDetails; set => characterDetails = value; }

        public MainViewModel()
        {
            // open the process to FFXIV
            mediator = new Mediator();
            int gameProcId = MemLib.getProcIDFromName("ffxiv_dx11");
            MemoryManager.Instance.MemLib.OpenProcess(gameProcId);
            ServicePointManager.SecurityProtocol = (ServicePointManager.SecurityProtocol & SecurityProtocolType.Ssl3) | (SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.SystemDefault);
            AutoUpdater.Mandatory = true;
            AutoUpdater.RunUpdateAsAdmin = true;
            AutoUpdater.DownloadPath = Environment.CurrentDirectory;
            AutoUpdater.Start("https://raw.githubusercontent.com/SaberNaut/xd/master/Updates.xml");
            // initialize a background worker
            // load the settings
            var path = Path.Combine(Directory.GetCurrentDirectory(), "FFXIVTrainer.zip");
            var path2 = Path.Combine(Directory.GetCurrentDirectory(), "ZipExtractor.exe");
            if (File.Exists(path))File.Delete(path);
            if (File.Exists(path2))File.Delete(path2);
            LoadSettings();
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            // run the worker
            worker.RunWorkerAsync();
            characterDetails = new CharacterDetailsViewModel(mediator);
        }
        private void LoadSettings()
        {
            // create an xml serializer
            var serializer = new XmlSerializer(typeof(Settings), "");
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
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // no fancy tricks here boi
            MemoryManager.Instance.BaseAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.AoBOffset, NumberStyles.HexNumber)); ;
            MemoryManager.Instance.CameraAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.CameraOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.EmoteAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.GposeEmoteOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.GposeAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.GposeOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.TimeAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.TimeOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.WeatherAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.WeatherOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.TerritoryAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.TerritoryOffset, NumberStyles.HexNumber));
            while (true)
            {
                // sleep for 200 ms
                Thread.Sleep(500);
                // check if our memory manager is set
                mediator.SendWork();

            }
        }
    }
}