using System.Windows;
using System.Windows.Controls;
using FFTrainer.ViewModels;

namespace FFTrainer.Views
{
    /// <summary>
    /// Interaction logic for CharacterDetailsView2.xaml
    /// </summary>
    public partial class CharacterDetailsView2 : UserControl
    {
        public CharacterDetailsView2()
        {
            InitializeComponent();
        }

        private void XPos2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (XPos2.Value.HasValue)
              //  if (XPos2.IsMouseOver || XPos2.IsKeyboardFocusWithin)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponX), "float", XPos2.Value.ToString());
        }

        private void XPos2_Copy_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (XPos2_Copy.Value.HasValue)
              //  if (XPos2_Copy.IsMouseOver || XPos2_Copy.IsKeyboardFocusWithin)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponY), "float", XPos2_Copy.Value.ToString());
        }

        private void XPos2_Copy1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (XPos2_Copy1.Value.HasValue)
             //   if (XPos2_Copy1.IsMouseOver || XPos2_Copy1.IsKeyboardFocusWithin)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponZ), "float", XPos2_Copy1.Value.ToString());
        }

        private void WeaponRed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (WeaponRed.Value.HasValue)
              //  if (WeaponRed.IsMouseOver || WeaponRed.IsKeyboardFocusWithin)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponRed), "float", WeaponRed.Value.ToString());
        }

        private void WeaponGreen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (WeaponGreen.Value.HasValue)
              //  if (WeaponGreen.IsMouseOver || WeaponGreen.IsKeyboardFocusWithin)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponGreen), "float", WeaponGreen.Value.ToString());
        }

        private void WeaponBlue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (WeaponBlue.Value.HasValue)
              //  if (WeaponBlue.IsMouseOver || WeaponBlue.IsKeyboardFocusWithin)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponBlue), "float", WeaponBlue.Value.ToString());
        }

        private void Head_Base_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Chest_Base_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Arm_Base_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Legs_Base_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Feet_Base_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Head_Variant_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Chest_Variant_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Arm_Variant_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Legs_Variant_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Feet_Variant_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void NeckBase_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Ear_Base_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void WristBase_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void RFingerBase_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void LFingerBase_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void EarV_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void NeckV_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void WristV_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void RFingerV_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void LFingerV_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Head_Copy_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Head_Copy4_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }
    }
}
