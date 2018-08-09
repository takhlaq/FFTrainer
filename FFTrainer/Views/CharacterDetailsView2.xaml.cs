using System.Windows;
using System.Windows.Controls;
using FFTrainer.ViewModels;
using GearTuple = System.Tuple<int, int, int>;
using WepTuple = System.Tuple<int, int, int, int>;
using System;
using System.Linq;
using FFTrainer.Models;
using System.Windows.Threading;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

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
            _exdProvider.DyeList();
            DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(60) };
            timer.Tick += delegate
            {
                for (int i = 0; i < _exdProvider.Dyes.Count; i++)
                {
                    HeadDye.Items.Add(_exdProvider.Dyes[i].Name);
                    ChestBox.Items.Add(_exdProvider.Dyes[i].Name);
                    ArmBox.Items.Add(_exdProvider.Dyes[i].Name);
                    MHBox.Items.Add(_exdProvider.Dyes[i].Name);
                    OHBox.Items.Add(_exdProvider.Dyes[i].Name);
                    LegBox.Items.Add(_exdProvider.Dyes[i].Name);
                    FeetBox.Items.Add(_exdProvider.Dyes[i].Name);
                }
                timer.IsEnabled = false;
            };
            timer.Start();
        }
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        private ExdCsvReader _exdProvider = new ExdCsvReader();
        public static GearSet _cGearSet = new GearSet();
        public void WriteGear_Click()
        {
            if (CharacterDetails.HeadPiece.freeze == true) { CharacterDetails.HeadPiece.freeze = false; CharacterDetails.HeadPiece.Activated = true; }
            if (CharacterDetails.Chest.freeze == true) { CharacterDetails.Chest.freeze = false; CharacterDetails.Chest.Activated = true; }
            if (CharacterDetails.Arms.freeze == true) { CharacterDetails.Arms.freeze = false; CharacterDetails.Arms.Activated = true; }
            if (CharacterDetails.Legs.freeze == true) { CharacterDetails.Legs.freeze = false; CharacterDetails.Legs.Activated = true; }
            if (CharacterDetails.Feet.freeze == true) { CharacterDetails.Feet.freeze = false; CharacterDetails.Feet.Activated = true; }
            if (CharacterDetails.Neck.freeze == true) { CharacterDetails.Neck.freeze = false; CharacterDetails.Neck.Activated = true; }
            if (CharacterDetails.Ear.freeze == true) { CharacterDetails.Ear.freeze = false; CharacterDetails.Ear.Activated = true; }
            if (CharacterDetails.Wrist.freeze == true) { CharacterDetails.Wrist.freeze = false; CharacterDetails.Wrist.Activated = true; }
            if (CharacterDetails.RFinger.freeze == true) { CharacterDetails.RFinger.freeze = false; CharacterDetails.RFinger.Activated = true; }
            if (CharacterDetails.LFinger.freeze == true) { CharacterDetails.LFinger.freeze = false; CharacterDetails.LFinger.Activated = true; }
            if (CharacterDetails.Job.freeze == true) { CharacterDetails.Job.freeze = false; CharacterDetails.Job.Activated = true; }
            if (CharacterDetails.Offhand.freeze == true) { CharacterDetails.Offhand.freeze = false; CharacterDetails.Offhand.Activated = true; }
            _cGearSet.HeadGear = CommaToGearTuple(headGearTextBox.Text);
            _cGearSet.BodyGear = CommaToGearTuple(bodyGearTextBox.Text);
            _cGearSet.HandsGear = CommaToGearTuple(handsGearTextBox.Text);
            _cGearSet.LegsGear = CommaToGearTuple(legsGearTextBox.Text);
            _cGearSet.FeetGear = CommaToGearTuple(feetGearTextBox.Text);
            _cGearSet.NeckGear = CommaToGearTuple(neckGearTextBox.Text);
            _cGearSet.EarGear = CommaToGearTuple(earGearTextBox.Text);
            _cGearSet.RRingGear = CommaToGearTuple(rRingGearTextBox.Text);
            _cGearSet.LRingGear = CommaToGearTuple(lRingGearTextBox.Text);
            _cGearSet.WristGear = CommaToGearTuple(wristGearTextBox.Text);
            _cGearSet.MainWep = CommaToWepTuple(mainWepTextBox.Text);
            _cGearSet.OffWep = CommaToWepTuple(offWepTextBox.Text);
            WriteCurrentGearTuples();
        }
        public void WriteCurrentGearTuples()
        {
            if (_cGearSet.HeadGear == null)
                return;
            CharacterDetails.Job.value = _cGearSet.MainWep.Item1;
            CharacterDetails.WeaponBase.value = (byte)_cGearSet.MainWep.Item2;
            CharacterDetails.WeaponV.value = (byte)_cGearSet.MainWep.Item3;
            CharacterDetails.WeaponDye.value = (byte)_cGearSet.MainWep.Item4;
            CharacterDetails.Offhand.value = _cGearSet.OffWep.Item1;
            CharacterDetails.OffhandBase.value = (byte)_cGearSet.OffWep.Item2;
            CharacterDetails.OffhandV.value = (byte)_cGearSet.OffWep.Item3;
            CharacterDetails.OffhandDye.value = (byte)_cGearSet.OffWep.Item4;
            CharacterDetails.HeadPiece.value = _cGearSet.HeadGear.Item1;
            CharacterDetails.HeadV.value = (byte)_cGearSet.HeadGear.Item2;
            CharacterDetails.HeadDye.value = (byte)_cGearSet.HeadGear.Item3;
            CharacterDetails.Chest.value = _cGearSet.BodyGear.Item1;
            CharacterDetails.ChestV.value = (byte)_cGearSet.BodyGear.Item2;
            CharacterDetails.ChestDye.value = (byte)_cGearSet.BodyGear.Item3;
            CharacterDetails.Arms.value = _cGearSet.HandsGear.Item1;
            CharacterDetails.ArmsV.value = (byte)_cGearSet.HandsGear.Item2;
            CharacterDetails.ArmsDye.value = (byte)_cGearSet.HandsGear.Item3;
            CharacterDetails.Legs.value = _cGearSet.LegsGear.Item1;
            CharacterDetails.LegsV.value = (byte)_cGearSet.LegsGear.Item2;
            CharacterDetails.LegsDye.value = (byte)_cGearSet.LegsGear.Item3;
            CharacterDetails.Feet.value = _cGearSet.FeetGear.Item1;
            CharacterDetails.FeetVa.value = (byte)_cGearSet.FeetGear.Item2;
            CharacterDetails.FeetDye.value = (byte)_cGearSet.FeetGear.Item3;
            CharacterDetails.Neck.value = _cGearSet.NeckGear.Item1;
            CharacterDetails.NeckVa.value = (byte)_cGearSet.NeckGear.Item2;
            CharacterDetails.Ear.value = _cGearSet.EarGear.Item1;
            CharacterDetails.EarVa.value = (byte)_cGearSet.EarGear.Item2;
            CharacterDetails.Wrist.value = _cGearSet.WristGear.Item1;
            CharacterDetails.WristVa.value = (byte)_cGearSet.WristGear.Item2;
            CharacterDetails.RFinger.value = _cGearSet.RRingGear.Item1;
            CharacterDetails.RFingerVa.value = (byte)_cGearSet.RRingGear.Item2;
            CharacterDetails.LFinger.value = _cGearSet.LRingGear.Item1;
            CharacterDetails.LFingerVa.value = (byte)_cGearSet.LRingGear.Item2;
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadPiece), GearTupleToByteAry(_cGearSet.HeadGear));
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Chest), GearTupleToByteAry(_cGearSet.BodyGear));
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Arms), GearTupleToByteAry(_cGearSet.HandsGear));
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Legs), GearTupleToByteAry(_cGearSet.LegsGear));
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Feet), GearTupleToByteAry(_cGearSet.FeetGear));
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Job), WepTupleToByteAry(_cGearSet.MainWep));
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Offhand), WepTupleToByteAry(_cGearSet.OffWep));
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Ear), GearTupleToByteAry(_cGearSet.EarGear));
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Neck), GearTupleToByteAry(_cGearSet.NeckGear));
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Wrist), GearTupleToByteAry(_cGearSet.WristGear));
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFinger), GearTupleToByteAry(_cGearSet.RRingGear));
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFinger), GearTupleToByteAry(_cGearSet.LRingGear));
            if (CharacterDetails.HeadPiece.Activated == true) { CharacterDetails.HeadPiece.freeze = true; CharacterDetails.HeadPiece.Activated = false; }
            if (CharacterDetails.Chest.Activated == true) { CharacterDetails.Chest.freeze = true; CharacterDetails.Chest.Activated = false; }
            if (CharacterDetails.Arms.Activated == true) { CharacterDetails.Arms.freeze = true; CharacterDetails.Arms.Activated = false; }
            if (CharacterDetails.Legs.Activated == true) { CharacterDetails.Legs.freeze = true; CharacterDetails.Legs.Activated = false; }
            if (CharacterDetails.Feet.Activated == true) { CharacterDetails.Feet.freeze = true; CharacterDetails.Feet.Activated = false; }
            if (CharacterDetails.Neck.Activated == true) { CharacterDetails.Neck.freeze = true; CharacterDetails.Neck.Activated = false; }
            if (CharacterDetails.Ear.Activated == true) { CharacterDetails.Ear.freeze = true; CharacterDetails.Ear.Activated = false; }
            if (CharacterDetails.Wrist.Activated == true) { CharacterDetails.Wrist.freeze = true; CharacterDetails.Wrist.Activated = false; }
            if (CharacterDetails.RFinger.Activated == true) { CharacterDetails.RFinger.freeze = true; CharacterDetails.RFinger.Activated = false; }
            if (CharacterDetails.LFinger.Activated == true) { CharacterDetails.LFinger.freeze = true; CharacterDetails.LFinger.Activated = false; }
            if (CharacterDetails.Job.Activated == true) { CharacterDetails.Job.freeze = true; CharacterDetails.Job.Activated = false; }
            if (CharacterDetails.Offhand.Activated == true) { CharacterDetails.Offhand.freeze = true; CharacterDetails.Offhand.Activated = false; }
        }
        public static byte[] WepTupleToByteAry(WepTuple tuple)
        {
            byte[] bytes = new byte[8];

            BitConverter.GetBytes((Int16)tuple.Item1).CopyTo(bytes, 0);
            BitConverter.GetBytes((Int16)tuple.Item2).CopyTo(bytes, 2);
            BitConverter.GetBytes((Int16)tuple.Item3).CopyTo(bytes, 4);
            BitConverter.GetBytes((Int16)tuple.Item4).CopyTo(bytes, 6);

            return bytes;
        }
        public static GearTuple ReadGearTuple(string offset)
        {
            var bytes = MemoryManager.Instance.MemLib.readBytes(offset.ToString(), 4);

            return new GearTuple(BitConverter.ToInt16(bytes, 0), bytes[2], bytes[3]);
        }
        public static WepTuple ReadWepTuple(string offset)
        {
            var bytes = MemoryManager.Instance.MemLib.readBytes(offset, 8);

            return new WepTuple(BitConverter.ToInt16(bytes, 0), BitConverter.ToInt16(bytes, 2), BitConverter.ToInt16(bytes, 4), BitConverter.ToInt16(bytes, 6));
        }

        public static string WepTupleToComma(WepTuple tuple)
        {
            return $"{tuple.Item1},{tuple.Item2},{tuple.Item3},{tuple.Item4}";
        }
        public static WepTuple CommaToWepTuple(string input)
        {
            var parts = input.Split(',');
            return new WepTuple(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
        }
        public static string GearTupleToComma(GearTuple tuple)
        {
            return $"{tuple.Item1},{tuple.Item2},{tuple.Item3}";
        }

        public static GearTuple CommaToGearTuple(string input)
        {
            var parts = input.Split(',');
            return new GearTuple(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
        }

        public static byte[] GearTupleToByteAry(GearTuple tuple)
        {
            byte[] bytes = new byte[4];

            BitConverter.GetBytes((Int16)tuple.Item1).CopyTo(bytes, 0);
            bytes[2] = (byte)tuple.Item2;
            bytes[3] = (byte)tuple.Item3;

            return bytes;
        }


        private void XPos2_V(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (XPos2.Value.HasValue)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponX), "float", XPos2.Value.ToString());
            XPos2.ValueChanged -= XPos2_V;
        }
        private void XPos2_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (XPos2.IsKeyboardFocusWithin || XPos2.IsMouseOver)
            {
                XPos2.ValueChanged -= XPos2_V;
                XPos2.ValueChanged += XPos2_V;
            }
        }

        private void XPos2_V2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (XPos2_Copy.Value.HasValue)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponY), "float", XPos2_Copy.Value.ToString());
            XPos2_Copy.ValueChanged -= XPos2_V2;
        }

        private void XPos2_Copy_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (XPos2_Copy.IsKeyboardFocusWithin || XPos2_Copy.IsMouseOver)
            {
                XPos2_Copy.ValueChanged -= XPos2_V2;
                XPos2_Copy.ValueChanged += XPos2_V2;
            }
        }

        private void XPos2_Copy1v(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (XPos2_Copy1.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponZ), "float", XPos2_Copy1.Value.ToString());
            XPos2_Copy1.ValueChanged -= XPos2_Copy1v;
        }

        private void XPos2_Copy1_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (XPos2_Copy1.IsKeyboardFocusWithin || XPos2_Copy1.IsMouseOver)
            {
                XPos2_Copy1.ValueChanged -= XPos2_Copy1v;
                XPos2_Copy1.ValueChanged += XPos2_Copy1v;
            }
        }

        private void WeaponRedxd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (WeaponRed.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponRed), "float", WeaponRed.Value.ToString());
            WeaponRed.ValueChanged -= WeaponRedxd;
        }

        private void WeaponRed_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (WeaponRed.IsKeyboardFocusWithin || WeaponRed.IsMouseOver)
            {
                WeaponRed.ValueChanged -= WeaponRedxd;
                WeaponRed.ValueChanged += WeaponRedxd;
            }
        }

        private void WeaponGreenxD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (WeaponGreen.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponGreen), "float", WeaponGreen.Value.ToString());
            WeaponGreen.ValueChanged -= WeaponGreenxD;
        }

        private void WeaponGreen_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (WeaponGreen.IsKeyboardFocusWithin || WeaponGreen.IsMouseOver)
            {
                WeaponGreen.ValueChanged -= WeaponGreenxD;
                WeaponGreen.ValueChanged += WeaponGreenxD;
            }
        }

        private void WeaponBluexD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (WeaponBlue.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponBlue), "float", WeaponBlue.Value.ToString());
            WeaponBlue.ValueChanged -= WeaponBluexD;
        }

        private void WeaponBlue_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (WeaponBlue.IsKeyboardFocusWithin || WeaponBlue.IsMouseOver)
            {
                WeaponBlue.ValueChanged -= WeaponBluexD;
                WeaponBlue.ValueChanged += WeaponBluexD;
            }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;

            GearPicker p = new GearPicker(_exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Head).ToArray());
            p.Owner = Application.Current.MainWindow;
            p.ShowDialog();

            if (p.Choice != null)
            {
            //    if (CharacterDetails.HeadPiece.freeze == true) { CharacterDetails.HeadPiece.freeze = false; CharacterDetails.HeadPiece.Activated = true; }
                CharacterDetails.HeadSlot.value = p.Choice.ModelMain;
                headGearTextBox.Text = p.Choice.ModelMain;
                WriteGear_Click();
            }

        }
        private bool CheckItemList()
        {
            if (_exdProvider.Items == null)
            {
                _exdProvider.MakeItemList();
                if (_exdProvider.Items == null)
                {
                    return false;
                }
            }
            return true;
        }

        private void SearchChest_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;

            GearPicker p = new GearPicker(_exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Body).ToArray());
            p.Owner = Application.Current.MainWindow;
            p.ShowDialog();

            if (p.Choice != null)
            {
               // if (CharacterDetails.Chest.freeze == true) { CharacterDetails.Chest.freeze = false; CharacterDetails.Chest.Activated = true; }
                CharacterDetails.BodySlot.value = p.Choice.ModelMain;
                bodyGearTextBox.Text = p.Choice.ModelMain;
                WriteGear_Click();
            }
        }

        private void SearchHand_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;

            GearPicker p = new GearPicker(_exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Hands).ToArray());
            p.Owner = Application.Current.MainWindow;
            p.ShowDialog();

            if (p.Choice != null)
            {
          //      if (CharacterDetails.Arms.freeze == true) { CharacterDetails.Arms.freeze = false; CharacterDetails.Arms.Activated = true; }
                CharacterDetails.ArmSlot.value = p.Choice.ModelMain;
                handsGearTextBox.Text = p.Choice.ModelMain;
                WriteGear_Click();
            }
        }

        private void SearchLeg_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;

            GearPicker p = new GearPicker(_exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Legs).ToArray());
            p.Owner = Application.Current.MainWindow;
            p.ShowDialog();

            if (p.Choice != null)
            {
             //   if (CharacterDetails.Legs.freeze == true) { CharacterDetails.Legs.freeze = false; CharacterDetails.Legs.Activated = true; }
                CharacterDetails.LegSlot.value = p.Choice.ModelMain;
                legsGearTextBox.Text = p.Choice.ModelMain;
                WriteGear_Click();
            }
        }

        private void SearchWep_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;

            GearPicker p = new GearPicker(_exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Wep && !c.ModelMain.Contains("0,0,0,0")).ToArray());
            p.Owner = Application.Current.MainWindow;
            p.ShowDialog();

            if (p.Choice != null)
            {
              //  if (CharacterDetails.Job.freeze == true) { CharacterDetails.Job.freeze = false; CharacterDetails.Job.Activated = true; }
                CharacterDetails.WeaponSlot.value = p.Choice.ModelMain;
                mainWepTextBox.Text = p.Choice.ModelMain;
                WriteGear_Click();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;

            GearPicker p = new GearPicker(_exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Ears).ToArray());
            p.Owner = Application.Current.MainWindow;
            p.ShowDialog();

            if (p.Choice != null)
            {
              //  if (CharacterDetails.Ear.freeze == true) { CharacterDetails.Ear.freeze = false; CharacterDetails.Ear.Activated = true; }
                CharacterDetails.EarSlot.value = p.Choice.ModelMain;
                earGearTextBox.Text = p.Choice.ModelMain;
                WriteGear_Click();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;

            GearPicker p = new GearPicker(_exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Neck).ToArray());
            p.Owner = Application.Current.MainWindow;
            p.ShowDialog();

            if (p.Choice != null)
            {
              //  if (CharacterDetails.Neck.freeze == true) { CharacterDetails.Neck.freeze = false; CharacterDetails.Neck.Activated = true; }
                CharacterDetails.NeckSlot.value = p.Choice.ModelMain;
                neckGearTextBox.Text = p.Choice.ModelMain;
                WriteGear_Click();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;

            GearPicker p = new GearPicker(_exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Wrists).ToArray());
            p.Owner = Application.Current.MainWindow;
            p.ShowDialog();

            if (p.Choice != null)
            {
             //   if (CharacterDetails.Wrist.freeze == true) { CharacterDetails.Wrist.freeze = false; CharacterDetails.Wrist.Activated = true; }
                CharacterDetails.WristSlot.value = p.Choice.ModelMain;
                wristGearTextBox.Text = p.Choice.ModelMain;
                WriteGear_Click();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;

            GearPicker p = new GearPicker(_exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Ring).ToArray());
            p.Owner = Application.Current.MainWindow;
            p.ShowDialog();

            if (p.Choice != null)
            {
              //  if (CharacterDetails.RFinger.freeze == true) { CharacterDetails.RFinger.freeze = false; CharacterDetails.RFinger.Activated = true; }
                CharacterDetails.RFingerSlot.value = p.Choice.ModelMain;
                rRingGearTextBox.Text = p.Choice.ModelMain;
                WriteGear_Click();
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;

            GearPicker p = new GearPicker(_exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Ring).ToArray());
            p.Owner = Application.Current.MainWindow;
            p.ShowDialog();

            if (p.Choice != null)
            {
             //   if (CharacterDetails.LFinger.freeze == true) { CharacterDetails.LFinger.freeze = false; CharacterDetails.LFinger.Activated = true; }
                CharacterDetails.LFingerSlot.value = p.Choice.ModelMain;
                lRingGearTextBox.Text = p.Choice.ModelMain;
                WriteGear_Click();
            }
        }

        private void SearchWep_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;

            GearPicker p = new GearPicker(_exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Wep && !c.ModelMain.Contains("0,0,0,0")).ToArray());
            p.Owner = Application.Current.MainWindow;
            p.ShowDialog();

            if (p.Choice != null)
            {
              //  if (CharacterDetails.Offhand.freeze == true) { CharacterDetails.Offhand.freeze = false; CharacterDetails.Offhand.Activated = true; }
                CharacterDetails.OffhandSlot.value = p.Choice.ModelMain;
                offWepTextBox.Text = p.Choice.ModelMain;
                WriteGear_Click();
            }
        }

        private void OXPOSXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (OXPos.Value.HasValue)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandX), "float", OXPos.Value.ToString());
            OXPos.ValueChanged -= OXPOSXD;
        }

        private void OXPos_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (OXPos.IsKeyboardFocusWithin || OXPos.IsMouseOver)
            {
                OXPos.ValueChanged -= OXPOSXD;
                OXPos.ValueChanged += OXPOSXD;
            }
        }

        private void OYPOSXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (OYPos.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandY), "float", OYPos.Value.ToString());
            OYPos.ValueChanged -= OYPOSXD;
        }

        private void OYPos_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (OYPos.IsKeyboardFocusWithin || OYPos.IsMouseOver)
            {
                OYPos.ValueChanged -= OYPOSXD;
                OYPos.ValueChanged += OYPOSXD;
            }
        }

        private void OZPosXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (OZPos.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandZ), "float", OZPos.Value.ToString());
            OZPos.ValueChanged -= OZPosXD;
        }

        private void OZPos_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (OZPos.IsKeyboardFocusWithin || OZPos.IsMouseOver)
            {
                OZPos.ValueChanged -= OZPosXD;
                OZPos.ValueChanged += OZPosXD;
            }
        }
        private void OFfRedxD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (OffRed.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandRed), "float", OffRed.Value.ToString());
            OffRed.ValueChanged -= OFfRedxD;
        }
        private void OffRed_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (OffRed.IsKeyboardFocusWithin || OffRed.IsMouseOver)
            {
                OffRed.ValueChanged -= OFfRedxD;
                OffRed.ValueChanged += OFfRedxD;
            }
        }

        private void OFFGXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (OffGreen.Value.HasValue)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandGreen), "float", OffGreen.Value.ToString());
            OffGreen.ValueChanged -= OFFGXD;
        }

        private void OffGreen_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (OffGreen.IsKeyboardFocusWithin || OffGreen.IsMouseOver)
            {
                OffGreen.ValueChanged -= OFFGXD;
                OffGreen.ValueChanged += OFFGXD;
            }
        }

        private void OFFBXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (OffBlue.Value.HasValue)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandBlue), "float", OffBlue.Value.ToString());
            OffBlue.ValueChanged -= OFFBXD;
        }

        private void OffBlue_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (OffBlue.IsKeyboardFocusWithin || OffBlue.IsMouseOver)
            {
                OffBlue.ValueChanged -= OFFBXD;
                OffBlue.ValueChanged += OFFBXD;
            }
        }

        private void OffhandID_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void OffBase_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void OffVariant_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void MainHand_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void SearchFeet_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;

            GearPicker p = new GearPicker(_exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Feet).ToArray());
            p.Owner = Application.Current.MainWindow;
            p.ShowDialog();

            if (p.Choice != null)
            {
                if (CharacterDetails.Feet.freeze == true) { CharacterDetails.Feet.freeze = false; CharacterDetails.Feet.Activated = true; }
                feetGearTextBox.Text = p.Choice.ModelMain;
                WriteGear_Click();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {

        }
        private bool CheckResidentList()
        {
            if (_exdProvider.Residents == null)
            {
                _exdProvider.MakeResidentList();
                if (_exdProvider.Residents == null)
                    return false;
            }
            return true;
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (!CheckResidentList())
                return;

            ResidentSelector f = new ResidentSelector(_exdProvider.Residents.Values.Where(c => c.IsGoodNpc()).ToArray());
            f.Owner = Application.Current.MainWindow;
            f.ShowDialog();

            if (f.Choice == null)
                return;

            var gs = f.Choice.Gear;

         //   gs.Customize = _cGearSet.Customize ?? _gearSet.Customize;

            _cGearSet = gs;

            FillCustoms();
            WriteCurrentGearTuples();
        }
        private void FillCustoms()
        {
            if (CharacterDetails.HeadPiece.freeze == true) { CharacterDetails.HeadPiece.freeze = false; CharacterDetails.HeadPiece.Activated = true; }
            if (CharacterDetails.Chest.freeze == true) { CharacterDetails.Chest.freeze = false; CharacterDetails.Chest.Activated = true; }
            if (CharacterDetails.Arms.freeze == true) { CharacterDetails.Arms.freeze = false; CharacterDetails.Arms.Activated = true; }
            if (CharacterDetails.Legs.freeze == true) { CharacterDetails.Legs.freeze = false; CharacterDetails.Legs.Activated = true; }
            if (CharacterDetails.Feet.freeze == true) { CharacterDetails.Feet.freeze = false; CharacterDetails.Feet.Activated = true; }
            if (CharacterDetails.Neck.freeze == true) { CharacterDetails.Neck.freeze = false; CharacterDetails.Neck.Activated = true; }
            if (CharacterDetails.Ear.freeze == true) { CharacterDetails.Ear.freeze = false; CharacterDetails.Ear.Activated = true; }
            if (CharacterDetails.Wrist.freeze == true) { CharacterDetails.Wrist.freeze = false; CharacterDetails.Wrist.Activated = true; }
            if (CharacterDetails.RFinger.freeze == true) { CharacterDetails.RFinger.freeze = false; CharacterDetails.RFinger.Activated = true; }
            if (CharacterDetails.LFinger.freeze == true) { CharacterDetails.LFinger.freeze = false; CharacterDetails.LFinger.Activated = true; }
            if (CharacterDetails.Job.freeze == true) { CharacterDetails.Job.freeze = false; CharacterDetails.Job.Activated = true; }
            if (CharacterDetails.Offhand.freeze == true) { CharacterDetails.Offhand.freeze = false; CharacterDetails.Offhand.Activated = true; }
            CharacterDetails.HeadSlot.value= GearTupleToComma(_cGearSet.HeadGear);
            CharacterDetails.BodySlot.value= GearTupleToComma(_cGearSet.BodyGear);
            CharacterDetails.ArmSlot.value = GearTupleToComma(_cGearSet.HandsGear);
            CharacterDetails.LegSlot.value = GearTupleToComma(_cGearSet.LegsGear);
            CharacterDetails.FeetSlot.value = GearTupleToComma(_cGearSet.FeetGear);
            CharacterDetails.EarSlot.value = GearTupleToComma(_cGearSet.EarGear);
            CharacterDetails.NeckSlot.value = GearTupleToComma(_cGearSet.NeckGear);
            CharacterDetails.RFingerSlot.value = GearTupleToComma(_cGearSet.RRingGear);
            CharacterDetails.LFingerSlot.value = GearTupleToComma(_cGearSet.LRingGear);
            CharacterDetails.WeaponSlot.value = WepTupleToComma(_cGearSet.MainWep);
            CharacterDetails.OffhandSlot.value = WepTupleToComma(_cGearSet.OffWep);
        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RenderToggle), "int", "2");
            Task.Delay(50).Wait();
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RenderToggle), "int", "0");
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
    }
}
 