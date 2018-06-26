using System.Windows;
using System.Windows.Controls;
using FFTrainer.ViewModels;

namespace FFTrainer.Views
{
    /// <summary>
    /// Interaction logic for CharacterDetailsView3.xaml
    /// </summary>
    public partial class CharacterDetailsView3 : UserControl
    {
        public CharacterDetailsView3()
        {
            InitializeComponent();
        }

        private void RedP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (RedP.Value.HasValue)
                if (RedP.IsMouseOver || RedP.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedPigment), "float", RedP.Value.ToString());
        }

        private void GreenP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (GreenP.Value.HasValue)
                if (GreenP.IsMouseOver || GreenP.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenPigment), "float", GreenP.Value.ToString());
        }

        private void BlueP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (BlueP.Value.HasValue)
                if (BlueP.IsMouseOver || BlueP.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBluePigment), "float", BlueP.Value.ToString());
        }

        private void RedG_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (RedG.Value.HasValue)
                if (RedG.IsMouseOver || RedG.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedGloss), "float", RedG.Value.ToString());
        }

        private void GreenG_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (GreenG.Value.HasValue)
                if (GreenG.IsMouseOver || GreenG.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenGloss), "float", GreenG.Value.ToString());
        }

        private void BlueG_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (BlueG.Value.HasValue)
                if (BlueG.IsMouseOver || BlueG.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBlueGloss), "float", BlueG.Value.ToString());
        }

        private void LipsBright_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (LipsBright.Value.HasValue)
                if (LipsBright.IsMouseOver || LipsBright.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsBrightness), "float", LipsBright.Value.ToString());
        }

        private void LipsRed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (LipsRed.Value.HasValue)
               if (LipsRed.IsMouseOver || LipsRed.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsR), "float", LipsRed.Value.ToString());
        }

        private void LipsGreen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (LipsGreen.Value.HasValue)
                if (LipsGreen.IsMouseOver || LipsGreen.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsG), "float", LipsGreen.Value.ToString());
        }

        private void LipsBlue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (LipsBlue.Value.HasValue)
                if (LipsBlue.IsMouseOver || LipsBlue.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsB), "float", LipsBlue.Value.ToString());
        }

        private void HairRed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (HairRed.Value.HasValue)
               if (HairRed.IsMouseOver || HairRed.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairRedPigment), "float", HairRed.Value.ToString());
        }

        private void HairGreen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (HairGreen.Value.HasValue)
               if (HairGreen.IsMouseOver || HairGreen.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGreenPigment), "float", HairGreen.Value.ToString());
        }

        private void HairBlue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (HairBlue.Value.HasValue)
                if (HairBlue.IsMouseOver || HairBlue.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairBluePigment), "float", HairBlue.Value.ToString());
        }

        private void HairRedGlow_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (HairRedGlow.Value.HasValue)
                if (HairRedGlow.IsMouseOver || HairRedGlow.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowRed), "float", HairRedGlow.Value.ToString());
        }

        private void HairGreenGlow_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (HairGreenGlow.Value.HasValue)
                if (HairGreenGlow.IsMouseOver || HairGreenGlow.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowGreen), "float", HairGreenGlow.Value.ToString());
        }

        private void HairBlueGlow_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (HairBlueGlow.Value.HasValue)
               if (HairBlueGlow.IsMouseOver || HairBlueGlow.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowBlue), "float", HairBlueGlow.Value.ToString());
        }

        private void HRP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (HRP.Value.HasValue)
               if (HRP.IsMouseOver || HRP.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightRedPigment), "float", HRP.Value.ToString());
        }

        private void HGP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (HGP.Value.HasValue)
               if (HGP.IsMouseOver || HGP.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightGreenPigment), "float", HGP.Value.ToString());
        }

        private void HBP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (HBP.Value.HasValue)
             if (HBP.IsMouseOver || HBP.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightBluePigment), "float", HBP.Value.ToString());
        }

        private void LEyeR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (LEyeR.Value.HasValue)
               if (LEyeR.IsMouseOver || LEyeR.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeRed), "float", LEyeR.Value.ToString());
        }

        private void LeyeG_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (LeyeG.Value.HasValue)
               if (LeyeG.IsMouseOver || LeyeG.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeGreen), "float", LeyeG.Value.ToString());
        }

        private void LeyeB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (LeyeB.Value.HasValue)
               if (LeyeB.IsMouseOver || LeyeB.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeBlue), "float", LeyeB.Value.ToString());
        }

        private void ReyeR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (ReyeR.Value.HasValue)
              if (ReyeR.IsMouseOver || ReyeR.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeRed), "float", ReyeR.Value.ToString());
        }

        private void ReyeG_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (ReyeG.Value.HasValue)
              if (ReyeG.IsMouseOver || ReyeG.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeGreen), "float", ReyeG.Value.ToString());
        }

        private void ReyeB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if(ReyeB.Value.HasValue)
              if (ReyeB.IsMouseOver || ReyeB.IsKeyboardFocusWithin || CharacterDetailsViewModel.TestxD == true)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeBlue), "float", ReyeB.Value.ToString());
        }
    }
}
