using System;
using System.Windows;
using FFTrainer.Models;
using System.ComponentModel;
using System.Threading;
using FFTrainer.ViewModels;
namespace FFTrainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker worker2;
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
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.EmoteSpeed2), CharacterDetails.EmoteSpeed2.GetBytes());
                }
                else
                {
                    CharacterDetails.EmoteSpeed1.value = MemoryManager.Instance.MemLib.readFloat((MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.EmoteSpeed1)));
                }
                if(CharacterDetails.Emote.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.Emote), CharacterDetails.Emote.GetBytes());
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
    }
}
