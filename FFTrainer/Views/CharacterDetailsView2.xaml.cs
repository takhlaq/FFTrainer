using System.Windows;
using System.Windows.Controls;
using FFTrainer.ViewModels;
using GearTuple = System.Tuple<int, int, int>;
using WepTuple = System.Tuple<int, int, int, int>;
using System;
using System.Linq;
using FFTrainer.Models;
using System.Threading.Tasks;
using System.Windows.Threading;

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
            DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(20) };
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
                    if (_exdProvider.Dyes[i].Index == MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadDye)))
                        HeadDye.SelectedIndex = i;
                    if (_exdProvider.Dyes[i].Index == MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ChestDye)))
                        ChestBox.SelectedIndex = i;
                    if (_exdProvider.Dyes[i].Index == MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ArmsDye)))
                        ArmBox.SelectedIndex = i;
                    if (_exdProvider.Dyes[i].Index == MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponDye)))
                        MHBox.SelectedIndex = i;
                    if (_exdProvider.Dyes[i].Index == MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandDye)))
                        OHBox.SelectedIndex = i;
                    if (_exdProvider.Dyes[i].Index == MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LegsDye)))
                        LegBox.SelectedIndex = i;
                    if (_exdProvider.Dyes[i].Index == MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FeetDye)))
                        FeetBox.SelectedIndex = i;
                }
                timer.IsEnabled = false;
            };
            timer.Start();
        }
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        private ExdCsvReader _exdProvider = new ExdCsvReader();
        public static GearSet _gearSet = new GearSet();
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
            Task.Delay(100).Wait();
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
        public void SetupDefaults()
        {

            _gearSet.HeadGear = ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadPiece));
            _gearSet.BodyGear = ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Chest));
            _gearSet.HandsGear = ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Arms));
            _gearSet.LegsGear = ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Legs));
            _gearSet.FeetGear = ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Feet));
            _gearSet.EarGear = ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Ear));
            _gearSet.NeckGear = ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Neck));
            _gearSet.WristGear = ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Wrist));
            _gearSet.RRingGear = ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFinger));
            _gearSet.LRingGear = ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFinger));

            _gearSet.MainWep = ReadWepTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Job));
            _gearSet.OffWep = ReadWepTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Offhand));
        }
        public void FillDefaults()
        {

            headGearTextBox.Text = GearTupleToComma(_gearSet.HeadGear);
            bodyGearTextBox.Text = GearTupleToComma(_gearSet.BodyGear);
            handsGearTextBox.Text = GearTupleToComma(_gearSet.HandsGear);
            legsGearTextBox.Text = GearTupleToComma(_gearSet.LegsGear);
            feetGearTextBox.Text = GearTupleToComma(_gearSet.FeetGear);
            mainWepTextBox.Text = WepTupleToComma(_gearSet.MainWep);
            earGearTextBox.Text = GearTupleToComma(_gearSet.EarGear);
            neckGearTextBox.Text = GearTupleToComma(_gearSet.NeckGear);
            wristGearTextBox.Text = GearTupleToComma(_gearSet.WristGear);
            rRingGearTextBox.Text = GearTupleToComma(_gearSet.RRingGear);
            lRingGearTextBox.Text = GearTupleToComma(_gearSet.LRingGear);
            offWepTextBox.Text = WepTupleToComma(_gearSet.OffWep);
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
            var bytes = MemoryManager.Instance.MemLib.readBytes(offset, 4);

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
        private void XPos2_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (XPos2.Value.HasValue)
                if (XPos2.IsMouseOver || XPos2.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponX), "float", XPos2.Value.ToString());
        }

        private void XPos2_Copy_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (XPos2_Copy.Value.HasValue)
                if (XPos2_Copy.IsMouseOver || XPos2_Copy.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponY), "float", XPos2_Copy.Value.ToString());
        }

        private void XPos2_Copy1_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (XPos2_Copy1.Value.HasValue)
                if (XPos2_Copy1.IsMouseOver || XPos2_Copy1.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponZ), "float", XPos2_Copy1.Value.ToString());
        }

        private void WeaponRed_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (WeaponRed.Value.HasValue)
                if (WeaponRed.IsMouseOver || WeaponRed.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponRed), "float", WeaponRed.Value.ToString());
        }

        private void WeaponGreen_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (WeaponGreen.Value.HasValue)
                if (WeaponGreen.IsMouseOver || WeaponGreen.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponGreen), "float", WeaponGreen.Value.ToString());
        }

        private void WeaponBlue_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (WeaponBlue.Value.HasValue)
                if (WeaponBlue.IsMouseOver || WeaponBlue.IsKeyboardFocusWithin)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;

            GearPicker p = new GearPicker(_exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Head).ToArray());
            p.Owner = Application.Current.MainWindow;
            p.ShowDialog();

            if (p.Choice != null)
            {
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
                offWepTextBox.Text = p.Choice.ModelMain;
                WriteGear_Click();
            }
        }

        private void OXPos_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (OXPos.Value.HasValue)
                if (OXPos.IsMouseOver || OXPos.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandX), "float", OXPos.Value.ToString());
        }

        private void OYPos_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (OYPos.Value.HasValue)
                if (OYPos.IsMouseOver || OYPos.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandY), "float", OYPos.Value.ToString());
        }

        private void OZPos_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (OZPos.Value.HasValue)
                if (OZPos.IsMouseOver || OZPos.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandZ), "float", OZPos.Value.ToString());
        }

        private void OffRed_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (OffRed.Value.HasValue)
                if (OffRed.IsMouseOver || OffRed.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandRed), "float", OffRed.Value.ToString());
        }

        private void OffGreen_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (OffGreen.Value.HasValue)
                if (OffGreen.IsMouseOver || OffGreen.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandGreen), "float", OffGreen.Value.ToString());
        }

        private void OffBlue_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (OffBlue.Value.HasValue)
                if (OffBlue.IsMouseOver || OffBlue.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandBlue), "float", OffBlue.Value.ToString());
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
            headGearTextBox.Text = GearTupleToComma(_cGearSet.HeadGear);
            bodyGearTextBox.Text = GearTupleToComma(_cGearSet.BodyGear);
            handsGearTextBox.Text = GearTupleToComma(_cGearSet.HandsGear);
            legsGearTextBox.Text = GearTupleToComma(_cGearSet.LegsGear);
            feetGearTextBox.Text = GearTupleToComma(_cGearSet.FeetGear);
            earGearTextBox.Text = GearTupleToComma(_cGearSet.EarGear);
            neckGearTextBox.Text = GearTupleToComma(_cGearSet.NeckGear);
            wristGearTextBox.Text = GearTupleToComma(_cGearSet.WristGear);
            rRingGearTextBox.Text = GearTupleToComma(_cGearSet.RRingGear);
            lRingGearTextBox.Text = GearTupleToComma(_cGearSet.LRingGear);
            mainWepTextBox.Text = WepTupleToComma(_cGearSet.MainWep);
            offWepTextBox.Text = WepTupleToComma(_cGearSet.OffWep);
        }
    }
}
 